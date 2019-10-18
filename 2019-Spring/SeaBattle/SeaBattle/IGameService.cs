using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SeaBattle
{
    /// <summary>
    /// Игровой сервис
    /// </summary>
    [ServiceContract]
    public interface IGameService
    {
        /// <summary>
        /// Запрос имени игрока
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string GetName();

        /// <summary>
        /// Выстрел по заданной клетке
        /// </summary>
        /// <param name="cell">Клетка</param>
        [OperationContract]
        void Fire(Data.Cell cell);

        /// <summary>
        /// Результат выстрела по заданной клетке
        /// </summary>
        /// <param name="cell">Клетка</param>
        [OperationContract]
        void Result(Data.Cell cell);
    }
}
