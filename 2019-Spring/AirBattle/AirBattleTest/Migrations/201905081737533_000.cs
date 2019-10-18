namespace SeaBattleTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _000 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoreTestDatas",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        X1 = c.Int(nullable: false),
                        Y1 = c.Int(nullable: false),
                        X2 = c.Int(nullable: false),
                        Y2 = c.Int(nullable: false),
                        Result = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CoreTestDatas");
        }
    }
}
