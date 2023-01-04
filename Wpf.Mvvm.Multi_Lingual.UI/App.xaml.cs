using Caliburn.Micro;
using Ironwall.Framework.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Mvvm.Library.Language.Services;
using Wpf.Mvvm.Multi_Lingual.UI.Properties;

namespace Wpf.Mvvm.Multi_Lingual.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {

        }
        public LanguageService LanguageService { get; private set; }

        protected override void OnActivated(EventArgs e)
        {
            //Get LanguageService single instance from Container
            LanguageService = IoC.Get<LanguageService>();
            //Event link
            LanguageService.SetChange += ChangeLanguage;
            base.OnActivated(e);
        }

        protected override void OnDeactivated(EventArgs e)
        {
            //Event unlink
            LanguageService.SetChange -= ChangeLanguage;
            base.OnDeactivated(e);
        }

        private void ChangeLanguage(string langCode)
        {
            //Get Dictionary Data
            ResourceDictionary dictionary = new ResourceDictionary();
            var CurrentDirectory = Directory.GetCurrentDirectory();

            ClearLangDictionary();

            switch (langCode)
            {
                case "en-US":
                    {
                        dictionary.Source = new Uri("../Resources/StringResources.xaml", UriKind.Relative);
                    }
                    break;
                case "ko-KR":
                    {
                        dictionary.Source = new Uri("../../Resources/StringResources.ko.xaml", UriKind.Relative);
                    }
                    break;
                default:
                    {
                        dictionary.Source = new Uri("../../Resources/StringResources.xaml", UriKind.Relative);
                    }
                    break;
            }
            Resources.MergedDictionaries.Add(dictionary);

            
        }

        /// <summary>
        /// Function : ClearLangDictionary<br/>
        /// Explain : Current loaded language data will be cleared
        /// </summary>
        private void ClearLangDictionary()
        {
            var korDictionary = new ResourceDictionary();
            var enDictionary = new ResourceDictionary();
            enDictionary.Source = new Uri("../Resources/StringResources.xaml", UriKind.Relative);
            korDictionary.Source = new Uri("../Resources/StringResources.ko.xaml", UriKind.Relative);
            Resources.MergedDictionaries.Remove(enDictionary);
            Resources.MergedDictionaries.Remove(korDictionary);
        }
    }

}
