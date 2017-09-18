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
                var language = parameter as string;
                var dictionary = new ResourceDictionary();
                var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Language config setting change
                configuration.AppSettings.Settings["Language"].Value = language;
                configuration.Save();
                
                // Current resource change
                language = string.IsNullOrEmpty(language) ? "Japanese" : language;
                dictionary.Source = new Uri("/Resources;component/Resources/" + language + ".xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries[0] = dictionary;
            });
        }
    }
}