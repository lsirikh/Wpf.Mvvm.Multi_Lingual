using Ironwall.Framework.ViewModels.ConductorViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Mvvm.Multi_Lingual.UI.Models;

namespace Wpf.Mvvm.Multi_Lingual.UI.ViewModels
{
    public class MainPageViewModel
        : BaseViewModel
    {
        #region - Ctors -
        public MainPageViewModel()
        {

            People = new ObservableCollection<PersonModel>()
            {
                new PersonModel(){Id=1,Name="홍길동", Age=20, Gender="남자"},
                new PersonModel(){Id=2,Name="홍길동", Age=25, Gender="남자"},
                new PersonModel(){Id=3,Name="홍길순", Age=30, Gender="여자"},
                new PersonModel(){Id=4,Name="홍미정", Age=50, Gender="여자"},
                new PersonModel(){Id=5,Name="홍길동", Age=30, Gender="남자"},
            };
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public ObservableCollection<PersonModel> People { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
