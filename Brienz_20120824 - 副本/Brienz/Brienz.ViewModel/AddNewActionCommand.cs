using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Brienz.Util;

namespace Brienz.ViewModel
{
    public class AddNewActionCommand:ICommand
    {

        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            Console.WriteLine("dfdfd");
        }
    }
}
