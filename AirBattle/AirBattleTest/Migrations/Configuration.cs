namespace SeaBattleTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SeaBattleTest.DB>
    {
        public Configuration()
        {
            // –азрешение автоматической миграции
            AutomaticMigrationsEnabled = true;
            // –азрешение автоматической миграции c потерей данных
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SeaBattleTest.DB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
