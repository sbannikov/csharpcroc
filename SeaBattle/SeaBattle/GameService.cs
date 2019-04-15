using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SeaBattle.Data;

namespace SeaBattle
{
    /// <summary>
    /// Игровой сервис
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class GameService : IGameService
    {
        /// <summary>
        /// Выстрел по заданной клетке
        /// </summary>
        /// <param name="cell">Клетка</param>
        public void Fire(Cell cell)
        {
            Program.fire.Enqueue(cell);
        }

        /// <summary>
        /// Имя игрока
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return Environment.MachineName;
        }

        /// <summary>
        /// Результат выстрела по заданной клетке
        /// </summary>
        /// <param name="cell">Клетка</param>
        public void Result(Cell cell)
        {
            Program.result.Enqueue(cell);
        }
    }
}
