using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AirBattle.Data;

namespace AirBattle
{
    /// <summary>
    /// WCF-сервис
    /// </summary>
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Single)]
    public class GameService : IGameService
    {
        /// <summary>
        /// Сохранить выстрел в очереди
        /// </summary>
        /// <param name="cell">Клетка выстрела</param>
        public void Fire(Cell cell)
        {
            Program.fire.Enqueue(cell);
        }

        /// <summary>
        /// Запрос имени
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            // Вернуть имя компьютера
            return Environment.MachineName;
        }

        /// <summary>
        /// Сохранить результат выстрела в очереди
        /// </summary>
        /// <param name="cell">Результат выстрела</param>
        public void Result(Cell cell)
        {
            Program.result.Enqueue(cell);
        }
    }
}
