using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GOT.Prolegis.WIN8.Libs;
using GOT.Prolegis.WIN8.Libs.MVVM;
using GOT.Prolegis.WIN8.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOT.Prolegis.WIN8.ViewModels
{
    [Export(typeof(ProlegisViewModelBase))]
    [ExportMetadata("Name", "EntityListViewModel")]
    public class EntityListViewModel : ProlegisViewModelBase, IEntityListViewModel
    {
        #region Constructor
        [ImportingConstructor]
        public EntityListViewModel(AppContext appContext) : base(appContext)
        {
            NewEntityCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send<WindowNavigationArgs>(new WindowNavigationArgs()
                {
                    WindowName = "EditEntity",
                    Parameter = null
                });
            });
        }
        #endregion

        #region Override Methods
        #endregion

        #region IEntityListViewModel Implementation 
        public RelayCommand NewEntityCommand { get; private set; }
        #endregion
    }
}
