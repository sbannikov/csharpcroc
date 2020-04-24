namespace TransfusionNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            // Коррекция таблицы Puzzles для того, чтобы миграция отработала корректно
            Sql("UPDATE [dbo].[Puzzles] SET Name = '' WHERE NAME IS NULL");

            CreateTable(
                "dbo.Moves",
                c => new
                {
                    ID = c.Guid(nullable: false),
                    FromState_ID = c.Guid(),
                    FromVessel_ID = c.Guid(),
                    ToState_ID = c.Guid(),
                    ToVessel_ID = c.Guid(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.States", t => t.FromState_ID)
                .ForeignKey("dbo.Vessels", t => t.FromVessel_ID)
                .ForeignKey("dbo.States", t => t.ToState_ID)
                .ForeignKey("dbo.Vessels", t => t.ToVessel_ID)
                .Index(t => t.FromState_ID)
                .Index(t => t.FromVessel_ID)
                .Index(t => t.ToState_ID)
                .Index(t => t.ToVessel_ID);

            CreateTable(
                "dbo.States",
                c => new
                {
                    ID = c.Guid(nullable: false),
                    SType = c.Int(nullable: false),
                    PuzzleID = c.Guid(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Puzzles", t => t.PuzzleID)
                .Index(t => t.PuzzleID);

            CreateTable(
                "dbo.StateOfVessels",
                c => new
                {
                    ID = c.Guid(nullable: false),
                    StateID = c.Guid(),
                    VesselID = c.Guid(),
                    Value = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                // Каскадное удаление объектов разрешено
                .ForeignKey("dbo.States", t => t.StateID, cascadeDelete: true)
                .ForeignKey("dbo.Vessels", t => t.VesselID, cascadeDelete: true)
                .Index(t => t.StateID)
                .Index(t => t.VesselID);

            AlterColumn("dbo.Puzzles", "Name", c => c.String(nullable: false, maxLength: 127));

            // Автоматическое заполнение поля ID
            AlterColumn("dbo.Puzzles", "ID", c => c.Guid(nullable: false, defaultValueSql: "NEWID()"));
        }

        public override void Down()
        {
            DropForeignKey("dbo.Moves", "ToVessel_ID", "dbo.Vessels");
            DropForeignKey("dbo.Moves", "ToState_ID", "dbo.States");
            DropForeignKey("dbo.Moves", "FromVessel_ID", "dbo.Vessels");
            DropForeignKey("dbo.Moves", "FromState_ID", "dbo.States");
            DropForeignKey("dbo.StateOfVessels", "VesselID", "dbo.Vessels");
            DropForeignKey("dbo.StateOfVessels", "StateID", "dbo.States");
            DropForeignKey("dbo.States", "PuzzleID", "dbo.Puzzles");
            DropIndex("dbo.StateOfVessels", new[] { "VesselID" });
            DropIndex("dbo.StateOfVessels", new[] { "StateID" });
            DropIndex("dbo.States", new[] { "PuzzleID" });
            DropIndex("dbo.Moves", new[] { "ToVessel_ID" });
            DropIndex("dbo.Moves", new[] { "ToState_ID" });
            DropIndex("dbo.Moves", new[] { "FromVessel_ID" });
            DropIndex("dbo.Moves", new[] { "FromState_ID" });
            AlterColumn("dbo.Puzzles", "Name", c => c.String());
            DropTable("dbo.StateOfVessels");
            DropTable("dbo.States");
            DropTable("dbo.Moves");
        }
    }
}
