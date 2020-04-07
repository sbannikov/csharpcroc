using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        /// Идентификатор головоломки
        /// </summary>
        public Nullable<Guid> PuzzleID { get; set; }
        /// <summary>
        /// Головоломка
        /// </summary>
        [ForeignKey("PuzzleID")] 
        public Puzzle Puzzle { get; set; }
    }
}
