using GOT.Prolegis.Portable.Authentication;
using GOT.Prolegis.WIN8.Libs;
using GOT.Prolegis.WIN8.Model.Intefaces;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOT.Prolegis.WIN8.Model
{
    [Export(typeof(IAuthenticationModel))]
    public class AuthenticationModel : IAuthenticationModel 
    {
        #region Constructor 
        [ImportingConstructor]
        public AuthenticationModel() 
        {
        }
        #endregion

        #region IAuthenticationModel Implementation 
        public async Task<List<tblUser>> CheckDatabaseUser(dynamic msnUser) 
        {
            string msnId = msnUser.id;
            return await App.MobileService.GetTable<tblUser>().Where(x => x.ExternalKey == msnId).ToListAsync();
        }
        public async void InsertMsnUser(dynamic msnUser) 
        {
            tblUser userAux = new tblUser()
            {
                FirstName = msnUser.first_name,
                LastName = msnUser.last_name,
                ExternalKey = msnUser.id
            };

            await App.MobileService.GetTable<tblUser>().InsertAsync(userAux);
        }
        #endregion
    }
}
