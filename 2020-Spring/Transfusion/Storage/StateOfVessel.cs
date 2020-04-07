using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transfusion.Storage
{
    /// <summary>
    /// Состояние конкретного сосуда
    /// </summary>
    public class StateOfVessel : Entity
    {
        /// <summary>
        /// Состояние
        /// </summary>
        public State State { get; set; }
        /// <summary>
        /// Сосуд
        /// </summary>
        public Vessel Vessel { get; set; }

        /// <summary>
        /// Уровень жидкости в данном сосуде
        /// NULL - если не определено (для конечного состояния)
        /// </summary>
        public int? Value { get; set; }
    }
}
