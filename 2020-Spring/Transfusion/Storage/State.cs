using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transfusion.Storage
{
    /// <summary>
    /// Состояние
    /// </summary>
    public class State : Entity
    {
        /// <summary>
        /// Тип состояния
        /// </summary>
        public StateType SType { get; set; }
        /// <summary>
        /// Головоломка
        /// </summary>
        public Puzzle Puzzle { get; set; }
    }
}
