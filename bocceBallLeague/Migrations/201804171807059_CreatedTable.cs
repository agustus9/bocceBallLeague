namespace bocceBallLeague.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeTeam = c.String(),
                        AwayTeam = c.String(),
                        AwayScore = c.Int(nullable: false),
                        DateHappened = c.DateTime(nullable: false),
                        Notes = c.String(),
                        HomeTeamId = c.Int(),
                        HomeTeams_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.HomeTeams_Id)
                .Index(t => t.HomeTeams_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mascot = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        NickName = c.String(),
                        Number = c.Int(nullable: false),
                        ThrowingArm = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "HomeTeams_Id", "dbo.Teams");
            DropIndex("dbo.Games", new[] { "HomeTeams_Id" });
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Games");
        }
    }
}
