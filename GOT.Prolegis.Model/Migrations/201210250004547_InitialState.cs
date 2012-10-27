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
                        Id = c.Int(nullable: false, identity: true),
                        EntityTypeId = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Prolegis.tblUserReferenceTable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReferenceTable = c.String(),
                        ReferenceId = c.Int(nullable: false),
                        ReferenceValue = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Prolegis.tblUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ExternalKey = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Prolegis.tblUser");
            DropTable("Prolegis.tblUserReferenceTable");
            DropTable("Prolegis.tblEntity");
        }
    }
}
