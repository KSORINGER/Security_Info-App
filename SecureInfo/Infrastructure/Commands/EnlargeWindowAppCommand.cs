using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecureInfo.Infrastructure.Commands
{
    class EnlargeWindowAppCommand : Command
    {
        public override bool CanExecute(object parameter)
         => true;

        public override void Execute(object parameter)
        {
            if(Application.Current.MainWindow.WindowState == WindowState.Normal)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }
    }
}
