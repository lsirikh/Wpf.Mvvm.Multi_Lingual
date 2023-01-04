using Ironwall.Framework.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wpf.Mvvm.Library.Language.Models;

namespace Wpf.Mvvm.Library.Language.Services
{
    public class LanguageService
        : IService
    {

        #region - Ctors -
        public LanguageService(SetupModel setupModel)
        {
            _setupModel = setupModel;
        }
        #endregion
        #region - Implementation of Interface -
        public Task ExecuteAsync(CancellationToken token = default)
        {
            SwitchLanguage(_setupModel.Language);
            return Task.CompletedTask;
        }

        public void Stop()
        {
        }
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        public void SwitchLanguage(string langCode = null)
        {
            try
            {
                DispatcherService.Invoke((System.Action)(() =>
                {
                    ///UI 쓰레드에 의해 점유중인 자원에 대해선 자원에 
                    ///수정을 가할 때 UI 쓰레드의 Dispatcher에 작업을 위임해야 한다.
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(langCode);
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langCode);
                    System.Globalization.CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
                    Debug.WriteLine($"{nameof(ChangeLanguage)} in {nameof(LanguageService)} : {currentCulture.Name}");
                }));

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Raised Exception in {nameof(ChangeLanguage)}({nameof(LanguageService)} : {ex.Message})");
            }

            SetChange?.Invoke(langCode);
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        public delegate void ChangeLanguage(string langCode);
        public event ChangeLanguage SetChange;
        private SetupModel _setupModel;
        #endregion

    }
}
