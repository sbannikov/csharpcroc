namespace RecipeBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pizzas", "Name", c => c.String(nullable: false, maxLength: 127));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pizzas", "Name", c => c.String());
        }
    }
}
