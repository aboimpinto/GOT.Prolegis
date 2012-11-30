using GOT.Prolegis.Portable.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GOT.Prolegis.Web.Services
{
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        Task<tblUser> GetUser(string externalKey);

        [OperationContract]
        Task InsertUser(tblUser user);
    }
}
