namespace RecipeBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 127),
                    })
                .PrimaryKey(t => t.ID);
            
            // Задано значение по умолчанию
            AddColumn("dbo.Pizzas", "Сalorie", c => c.Int(nullable: false, defaultValue: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pizzas", "Сalorie");
            DropTable("dbo.Ingredients");
        }
    }
}
