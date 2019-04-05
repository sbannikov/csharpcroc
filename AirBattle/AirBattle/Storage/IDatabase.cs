using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBattle.Storage
{
    /// <summary>
    /// Интерфейс базы данных
    /// </summary>
    public interface IDatabase 
    {
        /// <summary>
        /// Регистрация приложения в списке активных приложений
        /// </summary>
        void Register();
    }
}
