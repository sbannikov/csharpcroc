using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Database
{
    /// <summary>
    /// Регистрация игрока
    /// </summary>
    partial class Sessions
    {
        /// <summary>
        /// Строковое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ComputerName;
        }
    }
}
