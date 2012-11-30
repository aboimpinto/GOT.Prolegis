using GOT.Prolegis.Portable.Authentication;
using GOT.Prolegis.Web.Services;
using GOT.Prolegis.WIN8.Libs;
using GOT.Prolegis.WIN8.Model.Intefaces;
using GOT.Prolegis.WIN8.ServiceProxies;
using System.Composition;
using System.Threading.Tasks;

namespace GOT.Prolegis.WIN8.Model
{
    [Export(typeof(IAuthenticationModel))]
    public class AuthenticationModel : IAuthenticationModel 
    {
        private AuthenticationServiceProxy _proxy;

        #region Constructor 
        [ImportingConstructor]
        public AuthenticationModel(AuthenticationServiceProxy proxy)
        {
            _proxy = proxy;
        }
        #endregion

        #region IAuthenticationModel Implementation 
        public async Task<tblUser> CheckDatabaseUser(dynamic msnUser)
        {
            string msnId = msnUser.id;
            return await _proxy.GetUser(msnId);
        }
        public async Task<bool> InsertMsnUser(dynamic msnUser) 
        {
            //tblUser userAux = new tblUser()
            //{
            //    FirstName = msnUser.first_name,
            //    LastName = msnUser.last_name,
            //    ExternalKey = msnUser.id
            //};

            //await ServiceModel.InsertUser(userAux);
            return true;
        }
        #endregion
    }
}
