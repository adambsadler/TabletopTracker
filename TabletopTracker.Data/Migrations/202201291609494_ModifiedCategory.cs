namespace TabletopTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Publisher", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Category", "guid");
            DropColumn("dbo.Publisher", "guid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Publisher", "guid", c => c.Guid(nullable: false));
            AddColumn("dbo.Category", "guid", c => c.Guid(nullable: false));
            DropColumn("dbo.Publisher", "OwnerId");
            DropColumn("dbo.Category", "OwnerId");
        }
    }
}
