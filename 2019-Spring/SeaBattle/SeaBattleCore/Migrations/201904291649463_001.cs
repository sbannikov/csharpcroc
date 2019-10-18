namespace SeaBattle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoreDatas",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CoreDatas");
        }
    }
}
