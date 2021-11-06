using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required()]
        public virtual State FromState { get; set; }
        /// <summary>
        /// Конечное состояние
        /// </summary>    
        public virtual State ToState { get; set; }
        /// <summary>
        /// Сосуд, из которого отливаем воду
        /// </summary>
        [Required()] 
        public virtual Vessel FromVessel { get; set; }
        /// <summary>
        /// Сосуд, в который наливаем воду
        /// </summary>   
        public virtual Vessel ToVessel { get; set; }
    }
}
