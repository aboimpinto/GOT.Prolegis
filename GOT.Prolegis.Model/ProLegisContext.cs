using System.Data.Entity;
using GOT.Prolegis.Portable.Entities;
using GOT.Prolegis.Portable.GeneralData;

namespace GOT.Prolegis.Model
{
    public class ProLegisContext : DbContext
    {
        // Entities 
        public IDbSet<Entity> Entities { get; set; }

        // General Data
        public IDbSet<EntityType> EntityTypes { get; set; }

        #region Constructor
        public ProLegisContext() : base("ProLegisContext")
        {
        }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // update-database -Verbose -ConnectionString "Server=tcp:gswf5v1eeb.database.windows.net,1433;Database=ProLegisContext;User ID=imagoSA@gswf5v1eeb;Password=_Paulo2001;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;" -ConnectionProviderName "System.Data.SqlClient"

            modelBuilder.Entity<Entity>().ToTable("Entity", "Prolegis");
            modelBuilder.Entity<EntityType>().ToTable("EntityType", "Prolegis");

            base.OnModelCreating(modelBuilder);
        }
    }
}
