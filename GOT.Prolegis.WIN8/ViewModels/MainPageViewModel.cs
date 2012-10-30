using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOT.Prolegis.WIN8.Libs.MVVM;
using GOT.Prolegis.WIN8.Libs;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;
using GOT.Prolegis.WIN8.Dto;

namespace GOT.Prolegis.WIN8.ViewModels
{
    [Export(typeof(ProlegisViewModelBase))]
    [ExportMetadata("Name", "MainPageViewModel")]
    public class MainPageViewModel : ProlegisViewModelBase
    {
        #region Private Fields 
        private ObservableCollection<MenuItemDto> _mainMenuSource;
        private MenuItemDto _menuSelectedItem;
        #endregion

        #region Public Properties
        public ObservableCollection<MenuItemDto> MainMenuSource 
        {
            get { return _mainMenuSource; }
            set 
            {
                _mainMenuSource = value;
                RaisePropertyChanged(() => MainMenuSource);
            }
        }
        public MenuItemDto MenuSelectedItem 
        {
            get { return _menuSelectedItem; }
            set
            {
                _menuSelectedItem = value;
                RaisePropertyChanged(() => MenuSelectedItem);
                Messenger.Default.Send<WindowNavigationArgs>(new WindowNavigationArgs()
                {
                    WindowName=_menuSelectedItem.NavigationWindow,
                    Parameter = null
                });
            }
        }
        #endregion

        #region Constructor
        [ImportingConstructor]
        public MainPageViewModel(AppContext appContext) : base(appContext)
        {
            if (IsInDesignMode)
            {
                this.MainMenuSource = new ObservableCollection<MenuItemDto>();
                this.MainMenuSource.Add(new MenuItemDto() { MenuItem = "Dossiers", NavigationWindow = "DossiersList" });
                this.MainMenuSource.Add(new MenuItemDto() { MenuItem = "Entities", NavigationWindow = "EntitiesList" });
                this.MainMenuSource.Add(new MenuItemDto() { MenuItem = "Configurations", NavigationWindow = "Configurations" });
            }
        }
        #endregion

        #region Override Methods 
        public override async void InitializeViewModel()
        {
            base.InitializeViewModel();

            this.MainMenuSource = new ObservableCollection<MenuItemDto>();
            this.MainMenuSource.Add(new MenuItemDto() { MenuItem = "Dossiers", NavigationWindow = "DossiersList" });
            this.MainMenuSource.Add(new MenuItemDto() { MenuItem = "Entities", NavigationWindow = "EntitiesList" });
            this.MainMenuSource.Add(new MenuItemDto() { MenuItem = "Configurations", NavigationWindow = "Configurations" });
        }
        #endregion
    }
}
