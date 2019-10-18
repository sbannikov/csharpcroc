using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBattle.Data
{
    /// <summary>
    /// Состояние клетки
    /// </summary>
    public enum State
    {
        /// <summary>
        /// Клетки нет (промах)
        /// </summary>
        None,
        /// <summary>
        /// Живая клетка
        /// </summary>
        Active,
        /// <summary>
        /// Убитая клетка
        /// </summary>
        Hit 
    }

    /// <summary>
    /// Пример использования набора целочисленных констант
    /// </summary>
    public static class StateClass
    {
        /// <summary>
        /// Живая клетка
        /// </summary>
        public const int Active = 0;
        /// <summary>
        /// Убитая клетка
        /// </summary>
        public const int Hit = 1;
    }
}
