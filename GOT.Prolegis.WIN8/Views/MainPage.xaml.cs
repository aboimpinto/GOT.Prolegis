using GOT.Prolegis.WIN8.ViewModels;
using Microsoft.Live;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GOT.Prolegis.WIN8
{
    public sealed partial class MainPage : Page
    {
        MainPageViewModel _viewModel;

        public MainPage()
        {
            //_viewModel = new MainPageViewModel();
            //this.DataContext = _viewModel;

            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //var liveIdClient = new LiveAuthClient();
            //Task<LiveLoginResult> tskLoginResult = liveIdClient.LoginAsync(new string[] { "wl.signin" });
            //tskLoginResult.Wait();

            //switch (tskLoginResult.Result.Status)
            //{
            //    case LiveConnectSessionStatus.Connected:

            //        //LiveConnectClient client = new LiveConnectClient(tskLoginResult.Result.Session);
            //        //Task<LiveOperationResult> tskResult = client.GetAsync("me");
            //        //tskResult.Wait();
            //        //LiveOperationResult opResult = tskResult.Result;

            //        var user = GetLiveUser(tskLoginResult.Result.Session);

            //        //string firstName = opResult.Result["first_name"].ToString();
            //        var firstName = user.Result;

            //        break;
            //    case LiveConnectSessionStatus.NotConnected:
            //        int j = 10;
            //        break;
            //    default:
            //        int z = 10;
            //        break;
            //}

        }

        //private async string GetLiveUser(LiveConnectSession session)
        //{
            
        //}

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
    }
}
