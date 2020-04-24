using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TransfusionNet.Storage
{
    /// <summary>
    /// Головоломка
    /// </summary>
    public class Puzzle : Entity
    {
        /// <summary>
        /// Наименование головоломки
        /// </summary>
        [MaxLength(127)]
        [Required()]
        public string Name { get; set; }

        /// <summary>
        /// Сосуды
        /// </summary>
       // public virtual ICollection<Vessel> Vessels { get; set; }

        /// <summary>
        /// Состояния
        /// </summary>
        // public virtual ICollection<State> States { get; set; }
    }
}
