using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transfusion.Storage
{
    public enum StateType
    {
        /// <summary>
        /// Состояние не определено
        /// </summary>
        None = 0,
        /// <summary>
        /// Начальное состояние игры
        /// </summary>
        Start = 1,
        /// <summary>
        /// Промежуточное состояние
        /// </summary>
        Intermediate = 2,
        /// <summary>
        /// Целевое состояние (могут быть неполные данные)
        /// </summary>
        Final = 3,
        /// <summary>
        /// Конечное состояние после решения
        /// </summary>
        Solution = 4
    }
}
