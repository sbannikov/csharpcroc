using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransfusionNet.Storage
{
    /// <summary>
    /// Ход игры
    /// </summary>
    public class Move : Entity
    {
        /// <summary>
        /// Исходное состояние
        /// </summary>
        public virtual State FromState { get; set; }
        /// <summary>
        /// Конечное состояние
        /// </summary>
        public virtual State ToState { get; set; }
        /// <summary>
        /// Сосуд, из которого отливаем воду
        /// </summary>
        public virtual Vessel FromVessel { get; set; }
        /// <summary>
        /// Сосуд, в который наливаем воду
        /// </summary>
        public virtual Vessel ToVessel { get; set; }
    }
}
