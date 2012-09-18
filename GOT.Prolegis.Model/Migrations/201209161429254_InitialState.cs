namespace GOT.Prolegis.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Prolegis.Entity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityTypeId = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Prolegis.EntityType", t => t.EntityTypeId, cascadeDelete: true)
                .Index(t => t.EntityTypeId);
            
            CreateTable(
                "Prolegis.EntityType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("Prolegis.Entity", new[] { "EntityTypeId" });
            DropForeignKey("Prolegis.Entity", "EntityTypeId", "Prolegis.EntityType");
            DropTable("Prolegis.EntityType");
            DropTable("Prolegis.Entity");
        }
    }
}
