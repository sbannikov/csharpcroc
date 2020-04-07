using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Transfusion.Storage
{
    /// <summary>
    /// База данных
    /// </summary>
    public class Database : DbContext
    {
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
        /// <summary>
        /// Конструктор БД
        /// </summary>
        public Database()
        {
        }
    }
}
