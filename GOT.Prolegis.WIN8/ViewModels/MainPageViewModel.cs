using GOT.Prolegis.WIN8.Libs.MVVM;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOT.Prolegis.WIN8.ViewModels
{
    [Export("ViewModel")]
    [ExportMetadata("Name", "MainPageViewModel")]
    public class MainPageViewModel : ProlegisViewModelBase
    {
        #region Constructor 
        public MainPageViewModel()
        {

        }
        #endregion
    }
}
