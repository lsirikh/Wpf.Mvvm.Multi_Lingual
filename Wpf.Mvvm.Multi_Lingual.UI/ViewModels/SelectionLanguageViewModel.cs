using Caliburn.Micro;
using Ironwall.Framework.ViewModels.ConductorViewModels;
using Ironwall.Libraries.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf.Mvvm.Library.Language.Models;
using Wpf.Mvvm.Library.Language.Services;
using Wpf.Mvvm.Multi_Lingual.UI.Models;
using Wpf.Mvvm.Multi_Lingual.UI.Models.Messages;

namespace Wpf.Mvvm.Multi_Lingual.UI.ViewModels
{
    public class SelectionLanguageViewModel
        : BaseViewModel
    {
        #region - Ctors -
        public SelectionLanguageViewModel(
            SetupModel setupModel
            , LanguageService languageService
            , IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            _setupModel = setupModel;
            _languageService = languageService;
            LangComboList = new ObservableCollection<LanguageModel>();
            LangComboList.Add(new LanguageModel() { Id = 0, Language = "English", Code = LanguageConst.ENGLISH });
            LangComboList.Add(new LanguageModel() { Id = 1, Language = "Korean", Code = LanguageConst.KOREAN });
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            ApplyLanguage(_setupModel.Language);

            foreach (var item in LangComboList)
            {
                if (item.Code == _setupModel.Language)
                {
                    SelectedIndex = item.Id;
                }
            }
            return base.OnActivateAsync(cancellationToken);
        }

        protected override Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            return base.OnDeactivateAsync(close, cancellationToken);
        }
        #endregion
        #region - Binding Methods -
        public void SelectionChanged(object sender, SelectionChangedEventArgs eventArgs)
        {
            ApplyLanguage((eventArgs.AddedItems[0] as LanguageModel).Id);
        }

        private void ApplyLanguage(int id)
        {
            foreach (var item in LangComboList)
            {
                if (item.Id == id)
                {
                    SetComboLanguage(item.Code);
                }
            }
        }
        private void ApplyLanguage(string langCode)
        {
            SetComboLanguage(langCode);
        }

        private void SetComboLanguage(string code)
        {
            switch (code)
            {
                case LanguageConst.ENGLISH:
                    {
                        LangComboList[0].Language = "English";
                        LangComboList[1].Language = "Korean";
                    }
                    break;
                case LanguageConst.KOREAN:
                    {
                        LangComboList[0].Language = "영어";
                        LangComboList[1].Language = "한국어";
                    }
                    break;
                default:
                    break;
            }
            _setupModel.Language = code;

            _languageService.SwitchLanguage(code);

            NotifyOfPropertyChange(() => LangComboList[0].Language);
            NotifyOfPropertyChange(() => LangComboList[1].Language);
            Refresh();
        }

        #endregion
        #region - Processes -
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                NotifyOfPropertyChange(() => SelectedIndex);
            }
        }
        public ObservableCollection<LanguageModel> LangComboList { get;set; }
        public UserControl ViewContext { get; private set; }
        #endregion
        #region - Attributes -
        private int _selectedIndex;
        private SetupModel _setupModel;
        private LanguageService _languageService;
        #endregion
    }

}
