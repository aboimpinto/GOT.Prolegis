using GOT.Prolegis.Portable.Authentication;
using GOT.Prolegis.WIN8.Libs.NavigationService;
using GOT.Prolegis.WIN8.Model;
using GOT.Prolegis.WIN8.Model.Intefaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOT.Prolegis.WIN8.Libs
{
    [Export(typeof(AppContext))]
    [Shared]
    public class AppContext
    {
        #region Private Fields 
        private IAuthenticationModel _authModel;
        private INavigationService _navigationService;
        #endregion

        #region Public Properties 
        public dynamic AuthUser { get; set; }
        #endregion

        #region Constructor 
        [ImportingConstructor]
        public AppContext(IAuthenticationModel authModel) 
        {
            _authModel = authModel;
        }
        #endregion

        #region Public Methods 
        public async Task<bool> CheckDatabaseUser(dynamic msnUser) 
        {
            List<tblUser> users = await _authModel.CheckDatabaseUser(msnUser);

            if (users.Count() == 0)
            {
                _authModel.InsertMsnUser(msnUser);
            }

            return true;
        }
        #endregion
    }
}
