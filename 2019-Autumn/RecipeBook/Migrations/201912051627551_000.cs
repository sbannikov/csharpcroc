namespace RecipeBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _000 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Diameter = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Mass = c.Double(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pizzas");
        }
    }
}
