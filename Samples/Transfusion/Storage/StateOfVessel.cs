using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Guid StateID { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        [ForeignKey("StateID")]
        public virtual State State { get; set; }
        /// <summary>
        /// Идентификатор сосуда
        /// </summary>
        public Guid VesselID { get; set; }
        /// <summary>
        /// Сосуд
        /// </summary>
        [ForeignKey("VesselID")]
        public virtual Vessel Vessel { get; set; }

        /// <summary>
        /// Уровень жидкости в данном сосуде
        /// NULL - если не определено (для конечного состояния)
        /// </summary>
        [Display(Name = "Уровень жидкости")]
        public int? Value { get; set; }

        /// <summary>
        /// Свободное место в сосуде
        /// </summary>
        public int Free
        {
            get
            {
                return (Vessel == null) ? 0 : (Vessel.Volume - Value.Value);
            }
        }

        /// <summary>
        /// Строковое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
