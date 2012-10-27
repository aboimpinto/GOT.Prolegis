using GOT.Prolegis.Portable.Authentication;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOT.Prolegis.WIN8.Model.Intefaces
{
    public interface IAuthenticationModel
    {
        Task<List<tblUser>> CheckDatabaseUser(dynamic msdnUser);
        void InsertMsnUser(dynamic msnUser);
    }
}
