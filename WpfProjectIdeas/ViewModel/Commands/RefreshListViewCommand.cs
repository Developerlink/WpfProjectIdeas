using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfProjectIdeas.ViewModel.Commands
{
    public class RefreshListViewCommand : ICommand
    {
        public StartWindowVM VM { get; set; }

        public event EventHandler CanExecuteChanged;

        public RefreshListViewCommand(StartWindowVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            VM.ReadData();
        }
    }
}
