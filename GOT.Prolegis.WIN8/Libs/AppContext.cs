using GOT.Prolegis.Portable.Authentication;
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
        private IAuthenticationModel _authModel;

        public dynamic AuthUser { get; set; }

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
            List<User> users = await _authModel.CheckDatabaseUser(msnUser);

            if (users.Count() == 0)
            {
                _authModel.InsertMsnUser(msnUser);
            }

            return true;
        }
        #endregion
    }
}
