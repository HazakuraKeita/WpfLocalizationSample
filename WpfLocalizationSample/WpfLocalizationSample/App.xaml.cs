using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfLocalizationSample
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var language = ConfigurationManager.AppSettings["Language"];
            var dictionary = new ResourceDictionary();

            language = string.IsNullOrEmpty(language) ? "Japanese" : language;
            dictionary.Source = new Uri("/Resources;component/Resources/" + language + ".xaml", UriKind.Relative);
            Resources.MergedDictionaries[0] = dictionary;
        }
    }
}