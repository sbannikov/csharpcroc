using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Transfusion.Storage
{
    /// <summary>
    /// Головоломка
    /// </summary>
    public class Puzzle : Entity
    {
        /// <summary>
        /// Наименование головоломки
        /// </summary>
        [MaxLength(64)]
        [Required()]
        public string Name { get; set; }

        /// <summary>
        /// Сосуды
        /// </summary>
        public virtual ICollection<Vessel> Vessels { get; set; }

        /// <summary>
        /// Состояния
        /// </summary>
        public virtual ICollection<State> States { get; set; }
    }
}
