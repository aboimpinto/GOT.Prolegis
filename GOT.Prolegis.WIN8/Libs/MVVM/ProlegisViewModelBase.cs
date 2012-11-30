using GalaSoft.MvvmLight;
using GOT.Prolegis.WIN8.Libs.NavigationService;
using GOT.Prolegis.WIN8.Model.Intefaces;
using Microsoft.Live;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOT.Prolegis.WIN8.Libs.MVVM
{
    public abstract class ProlegisViewModelBase : ViewModelBase
    {
        #region Public Properties 
        public object WindowParamers { get; set; }
        public AppContext AppContext { get; set; }
        public INavigationService NavigationService { get; set; }
        #endregion

        #region Constuctor 
        public ProlegisViewModelBase() 
        {
            this.Initialize(ImagoContainer.CurrentContainer.GetExport<AppContext>(), ImagoContainer.CurrentContainer.GetExport<INavigationService>());
        }
        public ProlegisViewModelBase(AppContext appContext, INavigationService navigationService) 
        {
            this.Initialize(appContext, navigationService);
        }

        #endregion

        #region Virtual Methods 
        public async virtual void InitializeViewModel() 
        {
            if (this.AppContext.AuthUser == null)
            {
                this.AppContext.AuthUser = await GetUserLogged();
                bool bInDatabase = await this.AppContext.CheckDatabaseUser(this.AppContext.AuthUser);
            }
        }
        #endregion

        #region Private Methods 
        private async Task<dynamic> GetUserLogged() 
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
                        return operationResult;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("ERRO, {0}", ex.Message), ex);
                    }
                case LiveConnectSessionStatus.NotConnected:
                    break;
            }

            return null;
        }
        private void Initialize(AppContext appContext, INavigationService navigationService)
        {
            this.AppContext = appContext;
            this.NavigationService = navigationService;
        }
        #endregion
    }
}
