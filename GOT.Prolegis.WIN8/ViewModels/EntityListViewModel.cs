using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GOT.Prolegis.Portable.Entities;
using GOT.Prolegis.WIN8.Libs;
using GOT.Prolegis.WIN8.Libs.MVVM;
using GOT.Prolegis.WIN8.Model.Intefaces;
using GOT.Prolegis.WIN8.ViewModels.Interfaces;
using System.Collections.Generic;
using System.Composition;

namespace GOT.Prolegis.WIN8.ViewModels
{
    [Export(typeof(ProlegisViewModelBase))]
    [ExportMetadata("Name", "EntityListViewModel")]
    public class EntityListViewModel : ProlegisViewModelBase, IEntityListViewModel
    {
        #region Private Fields 
        private IEntityModel _entityModel;

        private IEnumerable<tblEntity> _entities;
        private tblEntity _entitySelected;
        #endregion

        #region Constructor
        [ImportingConstructor]
        public EntityListViewModel(IEntityModel entityModel) : base() 
        {
            _entityModel = entityModel;

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
        public override async void InitializeViewModel()
        {
            base.InitializeViewModel();

            this.Entities = await _entityModel.ListEntities();
        }
        #endregion

        #region IEntityListViewModel Implementation 
        public IEnumerable<tblEntity> Entities 
        {
            get { return _entities; }
            set 
            {
                _entities = value;
                RaisePropertyChanged(() => Entities);
            }
        }
        public tblEntity EntitySelected 
        {
            get { return _entitySelected; }
            set 
            {
                _entitySelected = value;
                RaisePropertyChanged(() => EntitySelected);

                if (_entitySelected == null) return;
                Messenger.Default.Send<WindowNavigationArgs>(new WindowNavigationArgs()
                {
                    WindowName = "EditEntity",
                    Parameter = EntitySelected
                });
            }
        }

        public RelayCommand NewEntityCommand { get; private set; }
        #endregion
    }
}
