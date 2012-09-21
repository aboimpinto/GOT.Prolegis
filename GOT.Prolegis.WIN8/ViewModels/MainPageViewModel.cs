using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOT.Prolegis.WIN8.Libs.MVVM;
using GOT.Prolegis.WIN8.Libs;
using System.Collections.ObjectModel;

namespace GOT.Prolegis.WIN8.ViewModels
{
    [Export(typeof(ProlegisViewModelBase))]
    [ExportMetadata("Name", "MainPageViewModel")]
    public class MainPageViewModel : ProlegisViewModelBase
    {
        private ObservableCollection<string> _mainMenuSource;

        public ObservableCollection<string> MainMenuSource 
        {
            get { return _mainMenuSource; }
            set 
            {
                _mainMenuSource = value;
                RaisePropertyChanged(() => MainMenuSource);
            }
        }

        #region Constructor 
        [ImportingConstructor]
        public MainPageViewModel(AppContext appContext) : base(appContext)
        {
            if (IsInDesignMode)
            {
                this.MainMenuSource = new ObservableCollection<string>();
                this.MainMenuSource.Add("Dossiers");
                this.MainMenuSource.Add("Clientes");
                this.MainMenuSource.Add("Configurações");
            }
        }
        #endregion

        public override async void InitializeViewModel()
        {
            base.InitializeViewModel();

            this.MainMenuSource = new ObservableCollection<string>();
            this.MainMenuSource.Add("Dossiers");
            this.MainMenuSource.Add("Clientes");
            this.MainMenuSource.Add("Configurações");

        }

        
    }
}
