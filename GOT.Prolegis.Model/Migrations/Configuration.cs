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
            context.tblUserReferenceTables.AddOrUpdate(x => x.id,
                           new tblUserReferenceTable { id = 1, ReferenceTable = "EntityType", ReferenceId = 1, ReferenceValue = "Cliente", IsActive = true, UserId = 1 },
                           new tblUserReferenceTable { id = 1, ReferenceTable = "EntityType", ReferenceId = 2, ReferenceValue = "Fornecedor", IsActive = true, UserId = 1 },
                           new tblUserReferenceTable { id = 1, ReferenceTable = "EntityType", ReferenceId = 3, ReferenceValue = "Outros", IsActive = true, UserId = 1 });

            //context.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[Prolegis].[vwEntityType]')) DROP TABLE [Prolegis].[vwEntityType]");
            //context.Database.ExecuteSqlCommand(@"CREATE VIEW [Prolegis].[vwEntityType] AS SELECT TOP (100) PERCENT ReferenceId AS Id, ReferenceValue AS EntityType FROM [Prolegis].tblUserReferenceTable WHERE (ReferenceTable = 'EntityType') AND (IsActive = 1) ORDER BY Id");
            //context.SaveChanges();
        }
    }
}
