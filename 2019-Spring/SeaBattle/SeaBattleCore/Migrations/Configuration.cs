namespace SeaBattle.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SeaBattle.DB>
    {
        public Configuration()
        {
            // Разрешение автоматических миграций
            AutomaticMigrationsEnabled = true;
            // Разрешение автоматических миграций с потерей данных
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SeaBattle.DB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
