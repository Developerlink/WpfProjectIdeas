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

namespace WpfProjectIdeas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ReadData();
        }

        // TODO: Release build programmet
        // TODO: Skriv alle projekt-ideer ind i programmet
        // TODO: Lav en ekstern fixme.txt ELLER brug funktionalitet i vs til at finde alle todo's og skriv ind i txt-fil for mig
        // TODO: Zip en kopi og put i onedrive
        // TODO: Upload til github
        // TODO: Memory test og opdater keychain numbers og regel for ændring af password year+tkhyear+tthyear+lnhyear

        // TODO: Listview skal være responsiv.
        // TODO: Lav custom commands ala ctrl+n og ctrl+s for new- og save-funktionalitet.
        // TODO: Lav custom controls til list view og databind på den avancerede måde.


        private void NewProjectIdeaBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenEditProjectIdeaWindow();
        }

        void ReadData()
        {
            List<ProjectIdea> projectIdeaList;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<ProjectIdea>();
                projectIdeaList = conn.Table<ProjectIdea>().ToList();
            }
            if (projectIdeaList != null)
            {
                projectIdeaListView.ItemsSource = projectIdeaList;
            }
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

            if (e.Key == Key.Enter)
            {
                OpenEditProjectIdeaWindow(selectedProjectIdea);
            }
            else if (e.Key == Key.Delete)
            {
                DeleteFromDB(selectedProjectIdea);
                ReadData();
                
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
    }
}
