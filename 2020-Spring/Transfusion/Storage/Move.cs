using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transfusion.Storage
{
    /// <summary>
    /// Ход игры
    /// </summary>
    public class Move : Entity
    {
        /// <summary>
        /// Исходное состояние
        /// </summary>
        public State FromState { get; set; }
        /// <summary>
        /// Конечное состояние
        /// </summary>
        public State ToState { get; set; }
        /// <summary>
        /// Сосуд, из которого отливаем воду
        /// </summary>
        public Vessel FromVessel { get; set; }
        /// <summary>
        /// Сосуд, в который наливаем воду
        /// </summary>
        public Vessel ToVessel { get; set; }
    }
}
