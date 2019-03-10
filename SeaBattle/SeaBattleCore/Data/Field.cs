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
    }
}
