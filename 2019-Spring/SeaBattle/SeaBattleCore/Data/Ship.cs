using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Data
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
            // Клетка корабля
            Cell cell = new Cell()
            {
                X = x,
                Y = y,
                CellState = State.Alive
            };
            // Массив из одного элемента
            Cells = new Cell[1] { cell };
        }

        /// <summary>
        /// Конструктор двухпалубного корабля
        /// </summary>
        /// <param name="cell">Первая клетка</param>
        /// <param name="x">Абсцисса второй клетки</param>
        /// <param name="y">Ордината второй клетки</param>
        public Ship(Cell cell, int x, int y)
        {
            // Клетка корабля
            Cell cell2 = new Cell()
            {
                X = x,
                Y = y,
                CellState = State.Alive
            };
            // Массив из двух элементов
            Cells = new Cell[2] { cell, cell2 };
        }

        /// <summary>
        /// Проверка доступности клетки для размещения корабля
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        /// <returns></returns>
        public bool CheckAround(int x, int y)
        {
            if (Cells != null)
            {
                foreach (Cell cell in Cells)
                {
                    if (!cell.CheckAround(x, y))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Проверка состояния клетки
        /// </summary>
        /// <param name="cell">Проверяемая клетка</param>
        /// <returns>Состояние клетки корабля или None, если клетка не принадлежит кораблю</returns>
        public State CellState(Cell cell)
        {
            if (Cells != null)
            {
                foreach (Cell c in Cells)
                {
                    if ((c.X == cell.X) && (c.Y == cell.Y))
                    {
                        return c.CellState;
                    }
                }
            }
            // Клетка не принадлежит кораблю
            return State.None;
        }
    }
}
