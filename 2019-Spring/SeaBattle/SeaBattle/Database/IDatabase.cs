using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Database
{
    /// <summary>
    /// База данных
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Регистрация сеанса в базе данных
        /// </summary>
        void Register();

        /// <summary>
        /// Список игроков
        /// </summary>
        /// <returns></returns>
        List<Sessions> PlayerList();
    }
}
