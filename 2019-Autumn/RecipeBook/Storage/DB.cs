namespace RecipeBook.Storage
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class DB : DbContext
    {
        // Контекст настроен для использования строки подключения "DB" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "RecipeBook.Storage.DB" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "DB" 
        // в файле конфигурации приложения.

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public DB() : base("DB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DB, Migrations.Configuration>());
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        /// <summary>
        /// Пицца
        /// </summary>
        public virtual DbSet<Pizza> Pizzas { get; set; }

        /// <summary>
        /// Ингредиенты
        /// </summary>
        public virtual DbSet<Ingredient>  Ingredients{ get; set; }

    }
}