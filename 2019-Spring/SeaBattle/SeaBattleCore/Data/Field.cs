using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Data
{
    /// <summary>
    /// Поле
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Массив кораблей
        /// </summary>
        public Ship[] Ships;

        /// <summary>
        /// Добавление однопалубного корабля
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        public void AddShip1(int x, int y)
        {
            // Создание нового корабля
            var ship = new Ship(x, y);
            if (Ships == null)
            {
                Ships = new Ship[1] { ship };
            }
            else
            {
                List<Ship> list = Ships.ToList();
                list.Add(ship);
                Ships = list.ToArray();
            }
        }

        /// <summary>
        /// Создание двухпалубного корабля
        /// </summary>
        /// <param name="cell">Первая клетка</param>
        /// <param name="x">Абсцисса второй клетки</param>
        /// <param name="y">Ордината второй клетки</param>
        public void AddShip2(Cell cell, int x, int y)
        {
            // Создание нового корабля
            var ship = new Ship(cell, x, y);
            if (Ships == null)
            {
                Ships = new Ship[1] { ship };
            }
            else
            {
                // Динамическое расширение массива
                Array.Resize(ref Ships, Ships.Length + 1);
                // Заполнение последнего элемента массива
                Ships[Ships.Length - 1] = ship;
            }
        }

        /// <summary>
        /// Проверка доступности клетки для размещения корабля
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        /// <returns></returns>
        public bool CheckAround(int x, int y)
        {
            if (Ships != null)
            {
                foreach (Ship ship in Ships)
                {
                    if (!ship.CheckAround(x, y))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public State CellState(Cell cell)
        {
            if (Ships != null)
            {
                foreach (Ship ship in Ships)
                {
                    State s = ship.CellState(cell);
                    if (s != State.None)
                    {
                        return s;
                    }
                }
            }
            // Клетка не принадлежит никакому кораблю
            return State.None;
        }
    }
}