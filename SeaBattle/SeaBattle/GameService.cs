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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class GameService : IGameService
    {
        /// <summary>
        /// Имя игрока
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return Environment.MachineName;
        }
    }
}
