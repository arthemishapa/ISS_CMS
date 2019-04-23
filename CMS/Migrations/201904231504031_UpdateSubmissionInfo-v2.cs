namespace CMS.CMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSubmissionInfov2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Submissions", "Representation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Submissions", "Representation", c => c.String());
        }
    }
}
