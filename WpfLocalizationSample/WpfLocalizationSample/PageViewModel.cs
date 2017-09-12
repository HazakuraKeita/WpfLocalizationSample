using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfLocalizationSample
{
    public class PageViewModel : INotifyPropertyChanged
    {
        public ICommand DialogCommand { get; private set; }
        public ICommand LanguageChangeCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public PageViewModel()
        {
            DialogCommand = new DelegateCommand((parameter) =>
            {
                new Dialogs.MainWindow().ShowDialog();
            });

            LanguageChangeCommand = new DelegateCommand((parameter) =>
            {
                var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                configuration.AppSettings.Settings["Language"].Value = parameter as string;
                configuration.Save();

                Application.Current.MainWindow.Close();
            });
        }
    }
}
