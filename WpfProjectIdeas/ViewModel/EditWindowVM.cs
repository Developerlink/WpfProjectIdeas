using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProjectIdeas.Model;

namespace WpfProjectIdeas.ViewModel
{
    public class EditWindowVM : INotifyPropertyChanged
    {
        public ProjectIdea ProjectIdea { get; set; }



        public EditWindowVM()
        {

        }

        public EditWindowVM(ProjectIdea projectIdea)
        {

        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
