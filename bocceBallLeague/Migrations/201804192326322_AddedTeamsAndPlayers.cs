namespace bocceBallLeague.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTeamsAndPlayers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teams", "Games_Id", "dbo.Games");
            DropIndex("dbo.Teams", new[] { "Games_Id" });
            DropColumn("dbo.Games", "HomeTeamId");
            RenameColumn(table: "dbo.Games", name: "Teams_Id", newName: "AwayTeamId");
            RenameColumn(table: "dbo.Games", name: "HomeTeams_Id", newName: "HomeTeamId");
            RenameIndex(table: "dbo.Games", name: "IX_HomeTeams_Id", newName: "IX_HomeTeamId");
            RenameIndex(table: "dbo.Games", name: "IX_Teams_Id", newName: "IX_AwayTeamId");
            AddColumn("dbo.Games", "HomeScore", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "TeamId", c => c.Int());
            CreateIndex("dbo.Players", "TeamId");
            AddForeignKey("dbo.Players", "TeamId", "dbo.Teams", "Id");
            AddForeignKey("dbo.Games", "AwayTeamId", "dbo.Teams", "Id");
            AddForeignKey("dbo.Games", "HomeTeamId", "dbo.Teams", "Id");
            DropColumn("dbo.Games", "HomeTeam");
            DropColumn("dbo.Games", "AwayTeam");
            DropColumn("dbo.Teams", "Games_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teams", "Games_Id", c => c.Int());
            AddColumn("dbo.Games", "AwayTeam", c => c.String());
            AddColumn("dbo.Games", "HomeTeam", c => c.String());
            DropForeignKey("dbo.Games", "HomeTeamId", "dbo.Teams");
            DropForeignKey("dbo.Games", "AwayTeamId", "dbo.Teams");
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropColumn("dbo.Players", "TeamId");
            DropColumn("dbo.Games", "HomeScore");
            RenameIndex(table: "dbo.Games", name: "IX_AwayTeamId", newName: "IX_Teams_Id");
            RenameIndex(table: "dbo.Games", name: "IX_HomeTeamId", newName: "IX_HomeTeams_Id");
            RenameColumn(table: "dbo.Games", name: "HomeTeamId", newName: "HomeTeams_Id");
            RenameColumn(table: "dbo.Games", name: "AwayTeamId", newName: "Teams_Id");
            AddColumn("dbo.Games", "HomeTeamId", c => c.Int());
            CreateIndex("dbo.Teams", "Games_Id");
            AddForeignKey("dbo.Teams", "Games_Id", "dbo.Games", "Id");
        }
    }
}
