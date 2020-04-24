namespace TransfusionNet.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TransfusionNet.Storage.DB>
    {
        public Configuration()
        {
            // Не следует разрешать автоматические миграции
            AutomaticMigrationsEnabled = false;
            ContextKey = "TransfusionNet.Storage.DB";
        }

        protected override void Seed(TransfusionNet.Storage.DB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
