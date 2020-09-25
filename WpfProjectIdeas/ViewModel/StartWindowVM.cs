using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfProjectIdeas.Model;
using WpfProjectIdeas.ViewModel.Helpers;
using WpfProjectIdeas.ViewModel.Commands;

namespace WpfProjectIdeas.ViewModel
{
    public class StartWindowVM : INotifyPropertyChanged
    {
        public ObservableCollection<ProjectIdea> ProjectIdeas { get; set; }

        public StartWindowVM()
        {
            ProjectIdeas = new ObservableCollection<ProjectIdea>();
            ReadData();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ReadData()
        {
            var projectIdeas = SQLiteAction.GetProjectIdeas();
            ProjectIdeas.Clear();
            foreach(var idea in projectIdeas)
            {
                ProjectIdeas.Add(idea);
            }
        }


    }
}
