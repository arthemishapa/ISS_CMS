namespace CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Affilation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Affilation", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
