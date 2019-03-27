using System.Data.Entity.Migrations;

namespace CMS.CMS.DAL.Migrations
{
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
