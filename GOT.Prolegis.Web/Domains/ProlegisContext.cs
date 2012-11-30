using GOT.Prolegis.Portable.Authentication;
using System.Data.Entity;

namespace GOT.Prolegis.Web.Domains
{
    public class ProlegisContext : DbContext
    {
        //update-database -Verbose -ConnectionString "Server=tcp:gswf5v1eeb.database.windows.net,1433;Database=ProLegisContext;User ID=imagoSA@gswf5v1eeb;Password=_Paulo2001;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;" -ConnectionProviderName "System.Data.SqlClient"

        #region Public Properties 
        public IDbSet<tblUser> tblUsers { get; set; }
        #endregion

        #region Consctructor
        public ProlegisContext() : base("ProlegisContext") { }
        #endregion
    }
}