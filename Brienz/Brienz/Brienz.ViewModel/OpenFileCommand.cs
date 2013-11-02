using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Brienz.ViewModel
{
    public class OpenFileCommand:ICommand
    {
        private bool canExe;
        public OpenFileCommand(bool canexe)
        {
            this.canExe = canexe; 
        }
        public bool CanExecute(object parameter)
        {
            if (canExe) { return true; } return false;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            string oo = TreeViewAttachedProps.SelectedItemValue;
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
