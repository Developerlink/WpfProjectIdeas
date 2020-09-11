using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfProjectIdeas.Classes
{
    public static class CustomCommand
    {
		public static readonly RoutedUICommand AddNew = new RoutedUICommand
			(
				"Add new project idea",
				"Add new project idea",
				typeof(CustomCommand),
				new InputGestureCollection()
				{
					new KeyGesture(Key.N, ModifierKeys.Control)
				}
			);

		//Define more commands here, just like the one above
	}
}

