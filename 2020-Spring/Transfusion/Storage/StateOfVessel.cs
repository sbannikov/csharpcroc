using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        /// Идентификатор состояния
        /// </summary>
        public Nullable<Guid> StateID { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        [ForeignKey("StateID")]
        public State State { get; set; }
        /// <summary>
        /// Идентификатор сосуда
        /// </summary>
        public Nullable<Guid> VesselID { get; set; }
        /// <summary>
        /// Сосуд
        /// </summary>
        [ForeignKey("VesselID")]
        public Vessel Vessel { get; set; }

        /// <summary>
        /// Уровень жидкости в данном сосуде
        /// NULL - если не определено (для конечного состояния)
        /// </summary>
        public int? Value { get; set; }
    }
}
