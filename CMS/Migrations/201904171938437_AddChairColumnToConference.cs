namespace CMS.CMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChairColumnToConference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conferences", "ChairId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Conferences", "ChairId");
            AddForeignKey("dbo.Conferences", "ChairId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Conferences", "ChairId", "dbo.AspNetUsers");
            DropIndex("dbo.Conferences", new[] { "ChairId" });
            DropColumn("dbo.Conferences", "ChairId");
        }
    }
}
