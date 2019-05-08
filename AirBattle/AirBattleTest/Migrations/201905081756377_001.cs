namespace SeaBattleTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CoreTestDatas", "Description", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CoreTestDatas", "Description");
        }
    }
}
