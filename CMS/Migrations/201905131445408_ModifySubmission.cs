namespace CMS.CMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifySubmission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "Abstract", c => c.String());
            AddColumn("dbo.Submissions", "Filename", c => c.String());
            DropColumn("dbo.Submissions", "Data");
            DropColumn("dbo.Submissions", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Submissions", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Submissions", "Data", c => c.String());
            DropColumn("dbo.Submissions", "Filename");
            DropColumn("dbo.Submissions", "Abstract");
        }
    }
}
