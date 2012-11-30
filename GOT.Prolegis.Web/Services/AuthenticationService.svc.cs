using GOT.Prolegis.Portable.Authentication;
using GOT.Prolegis.Web.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GOT.Prolegis.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Private Fields 
        private ProlegisContext _context;
        #endregion

        #region Constructor
        public AuthenticationService()
        {
            _context = new ProlegisContext();
        }
        #endregion

        #region IAutenticationService Implementation 
        public async Task<tblUser> GetUser(string externalKey)
        {
            return _context.tblUsers.Where(x => x.ExternalKey == externalKey).FirstOrDefault();
        }
        public Task InsertUser(tblUser user)
        {
            return null;

            //try
            //{
            //    _context.tblUsers.Add(user);
            //    _context.SaveChanges();

            //    return new Task();
            //}
            //catch
            //{
            //    return new Task();
            //}
        }
        #endregion
    }
}
