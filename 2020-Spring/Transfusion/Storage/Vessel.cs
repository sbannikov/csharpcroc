using System;
using System.Collections.Generic;
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
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Номер сосуда - натуральное число");
                }
                number = value;
            }
        }

        /// <summary>
        /// Головоломка, к которой относится сосуд
        /// </summary>
        public Puzzle Puzzle { get; set; }
    }
}
