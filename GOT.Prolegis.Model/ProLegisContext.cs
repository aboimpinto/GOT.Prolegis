using System.Data.Entity;
using GOT.Prolegis.Portable.Entities;
using GOT.Prolegis.Portable.GeneralData;
using GOT.Prolegis.Portable.Authentication;

namespace GOT.Prolegis.Model
{
    public class ProLegisContext : DbContext
    {
        // Entities 
        public IDbSet<tblEntity> tblEntities { get; set; }

        // General Data
        public IDbSet<tblUserReferenceTable> tblUserReferenceTables { get; set; }

        // Authentication
        public IDbSet<tblUser> tblUsers { get; set; }


        #region Constructor
        public ProLegisContext() : base("ProLegisContext")
        {
        }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // update-database -Verbose -ConnectionString "Server=tcp:gswf5v1eeb.database.windows.net,1433;Database=ProLegisContext;User ID=imagoSA@gswf5v1eeb;Password=_Paulo2001;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;" -ConnectionProviderName "System.Data.SqlClient"

            modelBuilder.Entity<tblEntity>().ToTable("tblEntity", "Prolegis");
            modelBuilder.Entity<tblUserReferenceTable>().ToTable("tblUserReferenceTable", "Prolegis");
            modelBuilder.Entity<tblUser>().ToTable("tblUser", "Prolegis");

            base.OnModelCreating(modelBuilder);
        }
    }
}
