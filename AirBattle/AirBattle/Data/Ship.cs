using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBattle.Data
{
    /// <summary>
    /// Корабль
    /// </summary>
    public class Ship
    {
        /// <summary>
        /// Клетки корабля
        /// </summary>
        public Cell[] Cells;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Ship()
        {
        }

        /// <summary>
        /// Конструктор однопалубного корабля
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        public Ship(int x, int y)
        {
            // Создание новой клетки
            var cell = new Cell()
            {
                X = x,
                Y = y,
                CellState = State.Active
            };
            // Создание массива из одной клетки
            Cells = new Cell[1] { cell };
        }
    }
}
