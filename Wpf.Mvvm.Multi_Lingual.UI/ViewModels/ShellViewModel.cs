using Caliburn.Micro;
using Ironwall.Framework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wpf.Mvvm.Library.Language.Services;
using Wpf.Mvvm.Library.Sample1.ViewModels;

namespace Wpf.Mvvm.Multi_Lingual.UI.ViewModels
{
    public class ShellViewModel
        : BaseShellViewModel
    {
        #region - Ctors -
        public ShellViewModel(
            MainPageViewModel mainPageViewModel
            , SelectionLanguageViewModel selectionLanguageViewModel
            , Sample1ViewModel sample1ViewModel
            , LanguageService languageService)
        {
            MainPageViewModel = mainPageViewModel;
            SelectionLanguageViewModel = selectionLanguageViewModel;
            Sample1ViewModel = sample1ViewModel;
            _languageService = languageService;
            _languageService.SetChange += _languageService_SetChange;
        }

        

        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            await MainPageViewModel.ActivateAsync();
            await SelectionLanguageViewModel.ActivateAsync();
            await Sample1ViewModel.ActivateAsync();
            await base.OnActivateAsync(cancellationToken);
        }

        protected override async Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            await MainPageViewModel.DeactivateAsync(true);
            await SelectionLanguageViewModel.DeactivateAsync(true);
            await Sample1ViewModel.DeactivateAsync(true);
            await base.OnDeactivateAsync(close, cancellationToken);
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        private void _languageService_SetChange(string langCode)
        {
            Title = Properties.Languages.Lang.MainTitle;
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public string Title
        {
            get { return _title; }
            set 
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        public MainPageViewModel MainPageViewModel { get; }
        public SelectionLanguageViewModel SelectionLanguageViewModel { get; }
        public Sample1ViewModel Sample1ViewModel { get; }
        #endregion
        #region - Attributes -
        private LanguageService _languageService;
        private string _title;
        #endregion
    }
}
