namespace CMS.CMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserRequesterId = c.String(),
                        UserChairId = c.String(),
                        ConferenceId = c.Int(nullable: false),
                        SessionId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Requests");
        }
    }
}
