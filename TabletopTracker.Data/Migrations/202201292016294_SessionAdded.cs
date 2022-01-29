namespace TabletopTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SessionAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Session", "GameId", "dbo.Game");
            DropIndex("dbo.Session", new[] { "GameId" });
            AddColumn("dbo.Session", "OwnerId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Session", "GameId", c => c.Int());
            AlterColumn("dbo.Session", "Date", c => c.DateTimeOffset(nullable: false, precision: 7));
            CreateIndex("dbo.Session", "GameId");
            AddForeignKey("dbo.Session", "GameId", "dbo.Game", "GameId");
            DropColumn("dbo.Session", "guid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Session", "guid", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Session", "GameId", "dbo.Game");
            DropIndex("dbo.Session", new[] { "GameId" });
            AlterColumn("dbo.Session", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Session", "GameId", c => c.Int(nullable: false));
            DropColumn("dbo.Session", "OwnerId");
            CreateIndex("dbo.Session", "GameId");
            AddForeignKey("dbo.Session", "GameId", "dbo.Game", "GameId", cascadeDelete: true);
        }
    }
}
