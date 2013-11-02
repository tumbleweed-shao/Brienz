using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Brienz.ViewModel
{
    public class ChangeFileStatusCommand:ICommand
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
            if (parameter != null)
            {
                Console.Write(parameter.ToString());
            }
            else
            {
                Console.Write("未设置CommandParameter");
            }
        }
    }
}
