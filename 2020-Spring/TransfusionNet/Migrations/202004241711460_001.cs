namespace TransfusionNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vessels",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        Volume = c.Int(nullable: false),
                        PuzzleID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Puzzles", t => t.PuzzleID)
                .Index(t => t.PuzzleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vessels", "PuzzleID", "dbo.Puzzles");
            DropIndex("dbo.Vessels", new[] { "PuzzleID" });
            DropTable("dbo.Vessels");
        }
    }
}
