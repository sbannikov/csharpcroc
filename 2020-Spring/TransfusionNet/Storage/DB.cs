namespace TransfusionNet.Storage
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DB : DbContext
    {
        // Контекст настроен для использования строки подключения "DB" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "TransfusionNet.Storage.DB" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "DB" 
        // в файле конфигурации приложения.
        public DB() : base("DB")
        {
        }

        /// <summary>
        /// Выполнить миграцию до последней версии схемы данных
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DB, Migrations.Configuration>());
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        /// <summary>
        /// Ход
        /// </summary>
        public DbSet<Move> Moves { get; set; }
        /// <summary>
        /// Головоломки
        /// </summary>
        public DbSet<Puzzle> Puzzles { get; set; }
        /// <summary>
        /// Состояния
        /// </summary>
        public DbSet<State> States { get; set; }
        /// <summary>
        /// Состояния сосудов
        /// </summary>
        public DbSet<StateOfVessel> StatesOfVessels { get; set; }
        /// <summary>
        /// Сосуды
        /// </summary>
        public DbSet<Vessel> Vessels { get; set; }
    }
}