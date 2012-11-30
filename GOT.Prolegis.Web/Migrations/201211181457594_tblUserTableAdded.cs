namespace GOT.Prolegis.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblUserTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUsers",
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
            DropTable("dbo.tblUsers");
        }
    }
}
