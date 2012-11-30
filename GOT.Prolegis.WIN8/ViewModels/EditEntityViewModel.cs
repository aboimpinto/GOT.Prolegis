using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GOT.Prolegis.WIN8.Libs;
using GOT.Prolegis.WIN8.Libs.MVVM;
using GOT.Prolegis.WIN8.Model.Intefaces;
using GOT.Prolegis.WIN8.ViewModels.Interfaces;
using System.Composition;

namespace GOT.Prolegis.WIN8.ViewModels
{
    [Export(typeof(ProlegisViewModelBase))]
    [ExportMetadata("Name", "EditEntityViewModel")]
    public class EditEntityViewModel : ProlegisViewModelBase, IEditEntityViewModel
    {
        #region Private Fields 
        private IEntityModel _entityModel;

        //private tblEntity _entity; 
        #endregion

        #region Constructor 
        [ImportingConstructor]
        public EditEntityViewModel(IEntityModel entityModel) : base() 
        {
            _entityModel = entityModel;

            SaveEntityCommand = new RelayCommand(() =>
            {
                //_entityModel.SaveEntity(this.Entity);

                Messenger.Default.Send<WindowNavigationArgs>(new WindowNavigationArgs()
                {
                    WindowName = "EntitiesList",
                    Parameter = null
                });
            });
        }
        #endregion

        #region Override Methods 
        public override async void InitializeViewModel()
        {
            base.InitializeViewModel();

            //if (this.WindowParamers == null) this.Entity = new tblEntity() { IsClient = true };
            //else this.Entity = this.WindowParamers as tblEntity;
        }
        #endregion

        #region IEditEntityViewModel Implementation
        //public tblEntity Entity 
        //{
        //    get { return _entity; }
        //    set 
        //    {
        //        _entity = value;
        //        RaisePropertyChanged(() => Entity);
        //    }
        //}

        public RelayCommand SaveEntityCommand { get; private set; }
        #endregion
    }
}
