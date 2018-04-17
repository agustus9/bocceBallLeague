namespace bocceBallLeague.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTeamPlayerandGames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Teams_Id", c => c.Int());
            AddColumn("dbo.Teams", "Games_Id", c => c.Int());
            CreateIndex("dbo.Games", "Teams_Id");
            CreateIndex("dbo.Teams", "Games_Id");
            AddForeignKey("dbo.Games", "Teams_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.Teams", "Games_Id", "dbo.Games", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "Games_Id", "dbo.Games");
            DropForeignKey("dbo.Games", "Teams_Id", "dbo.Teams");
            DropIndex("dbo.Teams", new[] { "Games_Id" });
            DropIndex("dbo.Games", new[] { "Teams_Id" });
            DropColumn("dbo.Teams", "Games_Id");
            DropColumn("dbo.Games", "Teams_Id");
        }
    }
}
