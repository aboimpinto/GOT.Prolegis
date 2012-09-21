using GalaSoft.MvvmLight;
using GOT.Prolegis.Portable.Authentication;
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
        #region Private Fields 
        private AppContext _appContext;
        #endregion

        #region #Constuctor
        public ProlegisViewModelBase(AppContext appContext)
        {
            _appContext = appContext;
            
        }

        #endregion

        public async virtual void InitializeViewModel()
        {
            _appContext.AuthUser =  await GetUserLogged();

            bool bInDatabase = await _appContext.CheckDatabaseUser(_appContext.AuthUser);
        }

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
        #endregion
    }
}
