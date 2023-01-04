using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Mvvm.Library.Language.Models
{
    public class SetupModel
    {
        private string _language = Properties.Settings.Default.Language;

        public string Language
        {
            get { return _language; }
            set
            {
                _language = value;
                Properties.Settings.Default.Language = Language;
                Properties.Settings.Default.Save();
            }
        }
    }
}
