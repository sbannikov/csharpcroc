using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBattle.Storage
{
    partial class Session 
    {
        /// <summary>
        /// Строковое представление моего объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ComputerName;
        }
    }
}
