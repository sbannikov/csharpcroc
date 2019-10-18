using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Data
{
    /// <summary>
    /// Состояние клетки
    /// </summary>
    public enum State
    {
        /// <summary>
        /// Незанятая клетка
        /// </summary>
        None,
        /// <summary>
        /// Живая клетка
        /// </summary>
       Alive,
       /// <summary>
       /// Ранен или убит
       /// </summary>
       Hit
    }
}
