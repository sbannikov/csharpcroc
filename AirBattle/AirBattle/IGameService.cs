using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AirBattle
{
    [ServiceContract]
    public interface IGameService
    {
        /// <summary>
        /// Запрос имени
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string GetName();

        /// <summary>
        /// Выстрел
        /// </summary>
        /// <param name="cell">Клетка поля</param>
        [OperationContract]
        void Fire(Data.Cell cell);

        /// <summary>
        /// Сообщить результаты выстрела
        /// </summary>
        /// <param name="cell">Клетка поля</param>
        [OperationContract]
        void Result(Data.Cell cell);

    }
}
