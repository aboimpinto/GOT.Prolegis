namespace GOT.Prolegis.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Prolegis.tblEntity",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        IsClient = c.Boolean(nullable: false),
                        IsSupplier = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "Prolegis.tblUserReferenceTable",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ReferenceTable = c.String(),
                        ReferenceId = c.Int(nullable: false),
                        ReferenceValue = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "Prolegis.tblUser",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ExternalKey = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("Prolegis.tblUser");
            DropTable("Prolegis.tblUserReferenceTable");
            DropTable("Prolegis.tblEntity");
        }
    }
}
