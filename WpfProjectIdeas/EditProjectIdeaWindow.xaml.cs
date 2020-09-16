using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfProjectIdeas.Classes;
using SQLite;
using static WpfProjectIdeas.Classes.SQLiteAction;
using static WpfProjectIdeas.Classes.RandomMaker;
using Microsoft.Win32;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;

namespace WpfProjectIdeas
{
    /// <summary>
    /// Interaction logic for EditProjectIdeaWindow.xaml
    /// </summary>
    public partial class EditProjectIdeaWindow : Window
    {
        ProjectIdea localProjectIdea = new ProjectIdea();
        public EditProjectIdeaWindow()
        {
            InitializeComponent();
        }
        public EditProjectIdeaWindow(ProjectIdea projectIdea)
        {
            InitializeComponent();

            this.localProjectIdea = projectIdea;
            DisplayDataFromExisting(projectIdea);
        }

        #region Button Clicks
        #region CRUD
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(projectTitleTextBox.Text))
            {
                ShowInputRequestMessage();
            }
            else
            {
                SaveChangesToLocalObject(localProjectIdea);
                SaveNewToDB(localProjectIdea);
                ClearAllFields();
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(projectTitleTextBox.Text))
            {
                ShowInputRequestMessage();
            }
            else
            {
                SaveChangesToLocalObject(localProjectIdea);
                UpdateToDB(localProjectIdea);
                Close();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteFromDB(localProjectIdea);
            Close();
        }
        private void DisplayDataFromExisting(ProjectIdea projectIdea)
        {
            projectTitleTextBox.Text = projectIdea.Name;
            markupLanguageTextBox.Text = projectIdea.Frontend;
            languageTextBox.Text = projectIdea.Backend;
            startDatePicker.SelectedDate = projectIdea.StartDate;
            endDatePicker.SelectedDate = projectIdea.EndDate;
            descriptionTextBox.Text = projectIdea.Description;
            desktopCheckbox.IsChecked = projectIdea.Desktop;
            webCheckbox.IsChecked = projectIdea.Web;
            mobileCheckbox.IsChecked = projectIdea.Mobile;
            IOTCheckbox.IsChecked = projectIdea.IOT;
            dragDropCheckbox.IsChecked = projectIdea.DragDrop;
            animationCheckbox.IsChecked = projectIdea.Animation;
            APICheckbox.IsChecked = projectIdea.API;
            AICheckbox.IsChecked = projectIdea.AI;
            soundCheckbox.IsChecked = projectIdea.Sound;
            videoCheckbox.IsChecked = projectIdea.Video;
            imageCheckbox.IsChecked = projectIdea.Image;
            threeDModelCheckbox.IsChecked = projectIdea.ThreeDModel;
            dataScrapeCheckbox.IsChecked = projectIdea.DataScrape;
            chatCheckbox.IsChecked = projectIdea.Chat;
            interDeviceCheckbox.IsChecked = projectIdea.InterDevice;
            serverCheckbox.IsChecked = projectIdea.Server;
        }
        #endregion       

        private void BackupDataButton_Click(object sender, RoutedEventArgs e)
        {
            BackupDatabase();
        }

        private void ClearAllFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            ClearAllFields();
        }

        private void CreateDummyDataButton_Click(object sender, RoutedEventArgs e)
        {
            CreateDummyData();
        }
        #endregion

        #region Key Downs       
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Insert:
                    if (string.IsNullOrEmpty(projectTitleTextBox.Text))
                    {
                        ShowInputRequestMessage();
                    }
                    else
                    {
                        SaveChangesToLocalObject(localProjectIdea);
                        SaveNewToDB(localProjectIdea);
                        ClearAllFields();
                    }
                    break;
                case Key.PageUp:
                    if (string.IsNullOrEmpty(projectTitleTextBox.Text))
                    {
                        ShowInputRequestMessage();
                    }
                    else
                    {
                        SaveChangesToLocalObject(localProjectIdea);
                        UpdateToDB(localProjectIdea);
                        Close();
                    }
                    break;
                case Key.PageDown:
                    BackupDatabase();
                    break;
                case Key.End:
                    ClearAllFields();
                    break;
                case Key.Home:
                    CreateDummyData();
                    break;
                default:
                    break;
            }
        }

        // Takes care of both datepickers.
        private void DatePicker_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DatePicker selectedDatepicker = sender as DatePicker;
                selectedDatepicker.IsDropDownOpen = true;
            }
        }

        private void Checkbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CheckBox selectedCheckBox = sender as CheckBox;
                selectedCheckBox.IsChecked = !selectedCheckBox.IsChecked;
            }
        }
        #endregion

        #region Other eventhandlers
        private void DescriptionTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            descriptionTextBox.Text = "";
            descriptionTextBox.Foreground = new SolidColorBrush(Colors.Black);
        }
        #endregion

        #region Helpers    
        private void BackupDatabase()
        {
            // Displays a SaveFileDialog so the user can copy the database
            // in the app folder bin.
            SaveFileDialog saveBackupDBDialog = new SaveFileDialog();
            saveBackupDBDialog.InitialDirectory = "C:\\Desktop";
            saveBackupDBDialog.Filter = "SQLite db-file|*.db";
            saveBackupDBDialog.Title = "Save a backup of database";
            // Suggested default name when opening the dialog.
            saveBackupDBDialog.FileName = "ProjectIdeasDB_backup";
            saveBackupDBDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveBackupDBDialog.FileName != "")
            {
                // Path and filename of the source database.
                string source = App.databasePath;
                string destination = saveBackupDBDialog.FileName;
                //string databaseBackupFolder = System.IO.Path.GetDirectoryName(saveBackupDBDialog.FileName);

                try
                {
                    File.Copy(source, destination, true);
                    // Open folder in explorer to verify that backup has been created.
                    // This Process.Start interferes with closing the dialog so it is no longer used.
                    //Process.Start(databaseBackupFolder);
                }
                catch
                {
                    //backupDone = false;
                }
            }

            Activate();
        }
        private void CreateDummyData()
        {
            projectTitleTextBox.Text = GetRandomProjectName();
            markupLanguageTextBox.Text = GetRandomFrontendTech();
            languageTextBox.Text = GetRandomBackendTech();
            startDatePicker.SelectedDate = GetRandomDateQuick();
            endDatePicker.SelectedDate = GetRandomDateFromNowToDate(2020, 12, 24);
            descriptionTextBox.Foreground = new SolidColorBrush(Colors.Black);
            descriptionTextBox.Text = GetRandomFillerText();
            desktopCheckbox.IsChecked = GetRandomBool();
            AICheckbox.IsChecked = GetRandomBool();
            soundCheckbox.IsChecked = GetRandomBool();
        }

        private void SaveChangesToLocalObject(ProjectIdea projectIdea)
        {
            projectIdea.Name = projectTitleTextBox.Text;
            projectIdea.Frontend = markupLanguageTextBox.Text;
            projectIdea.Backend = languageTextBox.Text;
            projectIdea.StartDate = startDatePicker.SelectedDate.Value.Date;
            projectIdea.EndDate = endDatePicker.SelectedDate.Value.Date;
            projectIdea.Description = descriptionTextBox.Text;
            projectIdea.Desktop = desktopCheckbox.IsChecked.GetValueOrDefault();
            projectIdea.Web = webCheckbox.IsChecked.GetValueOrDefault();
            projectIdea.Mobile = mobileCheckbox.IsChecked.GetValueOrDefault();
            projectIdea.IOT = IOTCheckbox.IsChecked.GetValueOrDefault();
            projectIdea.DragDrop = dragDropCheckbox.IsChecked.GetValueOrDefault();
            projectIdea.Animation = animationCheckbox.IsChecked.GetValueOrDefault();
            projectIdea.API = APICheckbox.IsChecked.GetValueOrDefault();
            projectIdea.AI = AICheckbox.IsChecked.GetValueOrDefault();
            projectIdea.Sound = soundCheckbox.IsChecked.GetValueOrDefault();
            projectIdea.Video = videoCheckbox.IsChecked.GetValueOrDefault();
            projectIdea.Image = imageCheckbox.IsChecked.GetValueOrDefault();
            projectIdea.ThreeDModel = threeDModelCheckbox.IsChecked.GetValueOrDefault();
            projectIdea.DataScrape = dataScrapeCheckbox.IsChecked.GetValueOrDefault();
            projectIdea.Chat = chatCheckbox.IsChecked.GetValueOrDefault();
            projectIdea.InterDevice = interDeviceCheckbox.IsChecked.GetValueOrDefault();
            projectIdea.Server = serverCheckbox.IsChecked.GetValueOrDefault();
        }        

        private void ClearAllFields()
        {
            projectTitleTextBox.Text = "";
            markupLanguageTextBox.Text = "";
            languageTextBox.Text = "";
            startDatePicker.SelectedDate = null;
            endDatePicker.SelectedDate = null;
            descriptionTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            descriptionTextBox.Text = "Enter description";            
            desktopCheckbox.IsChecked = false;
            webCheckbox.IsChecked = false;
            mobileCheckbox.IsChecked = false;
            IOTCheckbox.IsChecked = false;
            dragDropCheckbox.IsChecked = false;
            animationCheckbox.IsChecked = false;
            APICheckbox.IsChecked = false;
            AICheckbox.IsChecked = false;
            soundCheckbox.IsChecked = false;
            videoCheckbox.IsChecked = false;
            imageCheckbox.IsChecked = false;
            threeDModelCheckbox.IsChecked = false;
            dataScrapeCheckbox.IsChecked = false;
            chatCheckbox.IsChecked = false;
            interDeviceCheckbox.IsChecked = false;
            serverCheckbox.IsChecked = false;
        }   

        private void ShowInputRequestMessage()
        {
            MessageBox.Show("The name of the project cannot be empty", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        static DateTime RandomDateGenerator()
        {
            DateTime start = new DateTime(2020, 1, 1);

            Random rnd = new Random();
            int range = ((TimeSpan)(DateTime.Today - start)).Days;   
            return start.AddDays(rnd.Next(range));
        }

        #endregion

        

    }
}
                