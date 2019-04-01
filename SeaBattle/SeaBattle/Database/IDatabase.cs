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
    public interface IDatabase : IDisposable
    {
        /// <summary>
        /// Регистрация сеанса в базе данных
        /// </summary>
        void Register();
    }
}
