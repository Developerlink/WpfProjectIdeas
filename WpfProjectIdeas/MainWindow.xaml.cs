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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfProjectIdeas.Classes;
using SQLite;
using System.Collections.ObjectModel;
using static WpfProjectIdeas.Classes.SQLiteAction;
using System.Reflection;

namespace WpfProjectIdeas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string orderSelection = "Name";
        public MainWindow()
        {
            InitializeComponent();

            ReadData();
        }       

        // TODO: Listview skal være responsiv.
        // TODO: Lav custom commands ala ctrl+n og ctrl+s for new- og save-funktionalitet.
        // TODO: Lav custom controls til list view og databind på den avancerede måde.


        private void NewProjectIdeaBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenEditProjectIdeaWindow();
        }

        private void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProjectIdea selectedProjectIdea = (ProjectIdea)projectIdeaListView.SelectedItem;

            if (selectedProjectIdea != null)
            {
                OpenEditProjectIdeaWindow(selectedProjectIdea);
            }
        }

        private void EditProjectIdeaListView_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProjectIdea selectedProjectIdea = (ProjectIdea)projectIdeaListView.SelectedItem;
            OpenEditProjectIdeaWindow(selectedProjectIdea);
        }

        private void EditProjectIdea_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            ProjectIdea selectedProjectIdea = (ProjectIdea)projectIdeaListView.SelectedItem;
            int currentIndex = projectIdeaListView.SelectedIndex;

            if (e.Key == Key.Enter)
            {
                OpenEditProjectIdeaWindow(selectedProjectIdea);
            }
            else if (e.Key == Key.Delete)
            {
                // Don't try to delete anything if there are no items in list.
                if(projectIdeaListView.Items.Count > 0)
                {
                    DeleteFromDB(selectedProjectIdea);
                    ReadData();
                    // Jump to the correct index via the current index.
                    SetListviewSelectedItemVia(currentIndex);
                }

            }
        }

        private void OpenEditProjectIdeaWindow()
        {
            EditProjectIdeaWindow editProjectIdeaWindow = new EditProjectIdeaWindow();
            editProjectIdeaWindow.ShowDialog();
            ReadData();
        }
        private void OpenEditProjectIdeaWindow(ProjectIdea projectIdea)
        {
            if (projectIdea != null)
            {
                EditProjectIdeaWindow editProjectIdeaWindow = new EditProjectIdeaWindow(projectIdea);
                editProjectIdeaWindow.ShowDialog();
                ReadData();
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.N)
            {
                OpenEditProjectIdeaWindow();
            }
            else if (e.Key == Key.Right)
            {
                if(projectIdeaListView.Items.Count > 0)
                {
                    projectIdeaListView.SelectedItem = projectIdeaListView.Items[0];
                    projectIdeaListView.Focus();
                }
            }
        }            

        private void OrderSelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)orderSelectionComboBox.SelectedItem;
            string orderSelection = item.Content.ToString();

            switch (orderSelection)
            {
                case "Frontend":
                    this.orderSelection = orderSelection;
                        break;
                    case "Backend":
                    this.orderSelection = orderSelection;
                        break;
                    case "Start date":
                    this.orderSelection = orderSelection;
                        break;
                    case "End date":
                    this.orderSelection = orderSelection;
                        break;
                    default:
                    this.orderSelection = orderSelection;
                        break;
            }
            ReadData();
        }

        void ReadData()
        {
            List<ProjectIdea> projectIdeaList;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<ProjectIdea>();

                switch (orderSelection)
                {
                    case "Frontend":
                        projectIdeaList = conn.Table<ProjectIdea>().OrderBy(projectIdea => projectIdea.Frontend).ToList();
                        break;
                    case "Backend":
                        projectIdeaList = conn.Table<ProjectIdea>().OrderBy(projectIdea => projectIdea.Backend).ToList();
                        break;
                    case "Start date":
                        projectIdeaList = conn.Table<ProjectIdea>().OrderBy(projectIdea => projectIdea.StartDate).ToList();
                        break;
                    case "End date":
                        projectIdeaList = conn.Table<ProjectIdea>().OrderBy(projectIdea => projectIdea.EndDate).ToList();
                        break;
                    default:
                        projectIdeaList = conn.Table<ProjectIdea>().OrderBy(projectIdea => projectIdea.Name).ToList();
                        break;
                }

            }
            if (projectIdeaList != null)
            {
                projectIdeaListView.ItemsSource = projectIdeaList;
            }
        }

        void SetListviewSelectedItemVia(int index)
        {
            // If index of deleted item is the last go back 1 item. 
            if(index == projectIdeaListView.Items.Count)
            {
                projectIdeaListView.SelectedIndex = index - 1;
            }
            else
            {
                projectIdeaListView.SelectedIndex = index;
            }
        }
    }
}
