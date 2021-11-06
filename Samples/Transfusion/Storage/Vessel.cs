using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Transfusion.Storage
{
    /// <summary>
    /// Сосуд
    /// </summary>
    public class Vessel : Entity
    {
        /// <summary>
        /// Порядковый номер сосуда, начиная с 1
        /// </summary>        
        private int number;

        /// <summary>
        /// Порядковый номер сосуда, начиная с 1
        /// </summary>
        [Display(Name = "Порядковый номер, начиная с 1")]
        [Required()]
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                // Несколько избыточный контроль корректности данных
                if (value < 1)
                {
                    throw new Exception("Номер сосуда - натуральное число");
                }
                number = value;
            }
        }

        /// <summary>
        /// Объем
        /// </summary>
        [Display(Name = "Объем")]
        public int Volume { get; set; }

        /// <summary>
        /// Идентификатор головоломки
        /// </summary>
        public Guid PuzzleID { get; set; }

        /// <summary>
        /// Головоломка, к которой относится сосуд
        /// </summary>
        [ForeignKey("PuzzleID")]
        public virtual Puzzle Puzzle { get; set; }
    }
}
