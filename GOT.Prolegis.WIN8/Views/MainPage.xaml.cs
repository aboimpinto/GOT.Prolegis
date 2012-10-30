using Microsoft.Live;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Composition;
using System.Reflection;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;
using GOT.Prolegis.WIN8.Libs.MVVM;
using GOT.Prolegis.WIN8.Views;
using System.Composition.Hosting;

namespace GOT.Prolegis.WIN8
{
    public sealed partial class MainPage : Page
    {
        #region Public Properties 
        [ImportMany]
        public IEnumerable<Lazy<Page, WindowMetadata>> LazyWindowList { get; set; }
        #endregion

        #region Constructor
        public MainPage()
        {
            var containerConfiguration = new ContainerConfiguration().WithAssembly(typeof(App).GetTypeInfo().Assembly);
            CompositionHost host = containerConfiguration.CreateContainer();
            host.SatisfyImports(this);

            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }
        #endregion

        #region Page Events 
        void MainPage_Loaded(object sender, RoutedEventArgs e) 
        {
            Messenger.Default.Register<WindowNavigationArgs>(this, result =>
            {
                var oWindow = this.LazyWindowList.Single(x => x.Metadata.Name == result.WindowName).Value;
                if (oWindow.DataContext is ProlegisViewModelBase) ((ProlegisViewModelBase)oWindow.DataContext).InitializeViewModel();

                this.MainContent.Child = oWindow;
            });
        }
        protected override void OnNavigatedTo(NavigationEventArgs e) 
        {
            ((ProlegisViewModelBase)DataContext).InitializeViewModel();
        }
        #endregion

        

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var liveIdClient = new LiveAuthClient();
            Task<LiveLoginResult> tskLoginResult = liveIdClient.LoginAsync(new string[] { "wl.signin" });
            tskLoginResult.Wait();

            switch (tskLoginResult.Result.Status)
            {
                case LiveConnectSessionStatus.Connected:

                    try
                    {
                        LiveConnectClient client = new LiveConnectClient(tskLoginResult.Result.Session);
                        LiveOperationResult liveOperationResult = await client.GetAsync("me");

                        dynamic operationResult = liveOperationResult.Result;
                        string name = string.Format("Hello {0} ", operationResult.first_name);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("ERRO, {0}", ex.Message), ex);
                    }

                    break;
                case LiveConnectSessionStatus.NotConnected:
                    int j = 10;
                    break;
                default:
                    int z = 10;
                    break;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.MainContent.Child = new EntitiesList();
        }
    }
}
