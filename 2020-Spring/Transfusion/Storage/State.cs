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
        public virtual StateType SType { get; set; }
        /// <summary>
        /// Идентификатор головоломки
        /// </summary>
        public Nullable<Guid> PuzzleID { get; set; }
        /// <summary>
        /// Головоломка
        /// </summary>
        [ForeignKey("PuzzleID")]
        public virtual Puzzle Puzzle { get; set; }

        /// <summary>
        /// Состояния сосудов
        /// </summary>
        public virtual ICollection<StateOfVessel> StateOfVessels { get; set; }
    }
}
