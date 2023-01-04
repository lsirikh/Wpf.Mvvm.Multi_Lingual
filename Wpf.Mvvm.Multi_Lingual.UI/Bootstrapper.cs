using Autofac;
using Caliburn.Micro;
using Ironwall.Framework;
using Ironwall.Framework.Modules;
using Ironwall.Framework.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Mvvm.Library.Language.Models;
using Wpf.Mvvm.Library.Language.Services;
using Wpf.Mvvm.Library.Sample1.ViewModels;
using Wpf.Mvvm.Multi_Lingual.UI.Models;
using Wpf.Mvvm.Multi_Lingual.UI.ViewModels;

namespace Wpf.Mvvm.Multi_Lingual.UI
{
    public class Bootstrapper
        : ParentBootstrapper<ShellViewModel>
    {
        #region - Ctors -
        public Bootstrapper()
        {
            Initialize();
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            try
            {
                Process[] procs = Process.GetProcessesByName("Ironwall.Monitoring.UI");
                // 두번 이상 실행되었을 때 처리할 내용을 작성합니다.
                if (procs.Length > 1)
                {
                    var t = (AssemblyTitleAttribute)System.Reflection.Assembly.GetEntryAssembly().GetCustomAttributes(true)[3];
                    MessageBox.Show($"{t.Title}(Ironwall.Monitoring.UI) is already running...", "Redundant Execution");
                    Application.Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"중복실행 확인 중 오류 발생: {ex.ToString()}");
            }


            base.OnStartup(sender, e);


            #region - Visual Tree Check -
            ///To activate program as visual tree checking version
            ///Uncomment this code

            await DisplayRootViewForAsync<ShellViewModel>();
            await Start();
            #endregion
        }

        protected override void OnExit(object sender, EventArgs e)
        {
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            try
            {
                base.ConfigureContainer(builder);
                builder.RegisterType<MainPageViewModel>().SingleInstance();
                builder.RegisterType<SelectionLanguageViewModel>().SingleInstance();
                builder.RegisterType<LanguageService>().As<LanguageService>().As<IService>().SingleInstance();

                builder.RegisterType<Sample1ViewModel>().SingleInstance();

                var setupModel = new SetupModel();
                builder.RegisterInstance(setupModel).SingleInstance();
            }
            catch (Exception)
            {
            }
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            var assemblies = new List<Assembly>();
            assemblies.AddRange(base.SelectAssemblies());
            //Load new ViewModels here
            string[] fileEntries = Directory.GetFiles(Directory.GetCurrentDirectory());

            assemblies.AddRange(from fileName in fileEntries
                                where fileName.Contains("Wpf.Mvvm.Library.Sample1.dll")
                                select Assembly.LoadFile(fileName));
            assemblies.AddRange(from fileName in fileEntries
                                where fileName.Contains("Wpf.Mvvm.Library.LanguageService.dll")
                                select Assembly.LoadFile(fileName));
            return assemblies;
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        #endregion
    }
}
