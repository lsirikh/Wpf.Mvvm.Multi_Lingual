using Caliburn.Micro;
using Ironwall.Framework.ViewModels.ConductorViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wpf.Mvvm.Library.Language.Services;
using static Wpf.Mvvm.Library.Language.Services.LanguageService;

namespace Wpf.Mvvm.Library.Sample1.ViewModels
{
    public class Sample1ViewModel
        : BaseViewModel
    {
        #region - Ctors -
        public Sample1ViewModel(
            IEventAggregator eventAggregator
            , LanguageService languageService)
            : base(eventAggregator)
        {
            _languageService = languageService;
            _languageService.SetChange += _languageService_SetChange;
        }

        
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            return base.OnActivateAsync(cancellationToken);
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        private void _languageService_SetChange(string langCode)
        {
            //System.Globalization.CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            //Debug.WriteLine($"{nameof(ChangeLanguage)} in {nameof(Sample1ViewModel)} : {currentCulture.Name}");
            Label = Properties.Languages.Lang.Sample1_Name;
            Data = Properties.Languages.Lang.Sample1_Content;
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -

        public string Label
        {
            get { return _label; }
            set 
            { 
                _label = value;
                NotifyOfPropertyChange(() => Label);
            }
        }
        public string Data
        {
            get { return _data; }
            set 
            { 
                _data = value; 
                NotifyOfPropertyChange(() => Data);
            }
        }
        #endregion
        #region - Attributes -
        private string _label;
        private string _data;
        private LanguageService _languageService;
        #endregion
    }
}
