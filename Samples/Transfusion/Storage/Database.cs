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
        public Database(DbContextOptions<Database> options) : base(options)
        {
            Database.EnsureCreated();
        }       

        /// <summary>
        /// Добавление всех возможных ходов для состояния
        /// </summary>
        /// <param name="state">Состояние</param>
        public void AddMoves(State state)
        {
            foreach (Vessel fromV in state.Puzzle.Vessels)
            {
                foreach (Vessel toV in state.Puzzle.Vessels)
                {
                    if (fromV == toV)
                    {
                        // нельзя перелить из сосуда в него же
                    }
                    else if (state.StateOfVessels.First(a => a.VesselID == fromV.ID).Value == 0)
                    {
                        // нельзя перелить из пустого сосуда
                    }
                    else if (state.StateOfVessels.First(a => a.VesselID == toV.ID).Value == toV.Volume)
                    {
                        // нельзя перелить в полный сосуд
                    }
                    else // переливание возможно
                    {
                        // Контроль на существование переливания в БД
                        // Если переливание уже существует
                        if (Moves.FirstOrDefault(a => a.FromState.ID == state.ID &&
                                                      a.FromVessel.ID == fromV.ID &&
                                                      a.ToVessel.ID == toV.ID) != null)
                        {
                            // переходим к следующей комбинации
                            continue;
                        }

                        // Создание нового переливания
                        Move move = new Move()
                        {
                            FromState = state,
                            ToState = null, // состояние будет определено потом, при расчете хода
                            FromVessel = fromV,
                            ToVessel = toV
                        };
                        // Сохранение переливания в БД
                        Moves.Add(move);
                    }
                }
            }
            // Сохранение изменений в БД
            SaveChanges();
        }

        /// <summary>
        /// Вернуть состояние заданного типа
        /// <para>Создает новое состояние, если оно не существует</para>
        /// </summary>
        /// <param name="puzzleid">Идентификатор головоломки</param>
        /// <param name="type">Тип состояния</param>
        /// <returns></returns>
        public State GetState(Guid puzzleid, StateType type)
        {
            State state = States.Where(a => a.SType == type && a.PuzzleID == puzzleid).FirstOrDefault();
            
            // Проверка на наличие состояния заданного типа
            if (state == null)
            {
                // Создание состояния заданного типа
                state = new State()
                {
                    PuzzleID = puzzleid,
                    SType = type
                };
                // Добавление в таблицу состояний
                States.Add(state);
                // Сохранение изменений в БД
                SaveChanges();
            }

            return state;
        }
    }
}
