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
    }
}
