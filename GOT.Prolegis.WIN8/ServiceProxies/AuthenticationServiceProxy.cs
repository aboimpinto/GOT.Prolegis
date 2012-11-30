using GOT.Prolegis.Portable.Authentication;
using GOT.Prolegis.Web.Services;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GOT.Prolegis.WIN8.ServiceProxies
{
    [Export(typeof(IAuthenticationService))]
    public class AuthenticationServiceProxy : ClientBase<IAuthenticationService>, IAuthenticationService
    {
        #region Constructor 
        public AuthenticationServiceProxy() : base(new BasicHttpBinding(), new EndpointAddress(string.Format("{0}/Services/AuthenticationService.svc", App.BackendUrl))) { }
        #endregion

        #region IAuthenticationService Implementation
        public Task<tblUser> GetUser(string externalKey)
        {
            return base.Channel.GetUser(externalKey);
        }

        public Task InsertUser(tblUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
