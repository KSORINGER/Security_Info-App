using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SecureInfo.Infrastructure.Commands
{
    class LocalizationCommands : Command
    {
        private static string CurrentLanguage = "eng";
        public override bool CanExecute(object parameter)
        {
            if (!(parameter is ComboBoxItem comboBoxItem)) return false;
            if (comboBoxItem.Name.ToString() != CurrentLanguage)
            {
                CurrentLanguage = comboBoxItem.Name.ToString();
                return true;
            }
            return false;
        }

        public override void Execute(object parameter)
        {
            if (!(parameter is ComboBoxItem comboBoxItem)) return;
            ResourceDictionary dictionary = new ResourceDictionary();
            switch (comboBoxItem.Name.ToString())
            {
                case "ukr":
                    dictionary.Source = new Uri(@"..\Resources\Locals\ukr.xaml", UriKind.Relative);
                    break;
                case "eng":
                    dictionary.Source = new Uri(@"..\Resources\Locals\eng.xaml", UriKind.Relative);
                    break;
                default:
                    dictionary.Source = new Uri(@"..\Resources\Locals\eng.xaml", UriKind.Relative);
                    break;
            }
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }
    }
}
