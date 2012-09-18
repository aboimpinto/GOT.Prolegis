namespace GOT.Prolegis.Model.Migrations
{
    using GOT.Prolegis.Portable.GeneralData;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GOT.Prolegis.Model.ProLegisContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GOT.Prolegis.Model.ProLegisContext context)
        {
            context.EntityTypes.AddOrUpdate(x => x.Id,
                           new EntityType { Id = 1, Name = "Cliente" },
                           new EntityType { Id = 1, Name = "Fornecedor" },
                           new EntityType { Id = 1, Name = "Outros" });
        }
    }
}
