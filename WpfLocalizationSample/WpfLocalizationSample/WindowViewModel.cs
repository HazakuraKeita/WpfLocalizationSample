using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfLocalizationSample
{
    public class WindowViewModel : INotifyPropertyChanged
    {
        public ICommand ResourceChangeCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public WindowViewModel()
        {
            ResourceChangeCommand = new DelegateCommand((parameter) =>
            {
                var language = parameter as string;
                var dictionary = new ResourceDictionary();

                dictionary.Source = new Uri("./Resources/" + language + ".xaml", UriKind.Relative);
            });
        }
    }
}
