using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Drawing;

namespace AirBattle.Data
{
    /// <summary>
    /// Клетка
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Цвет кораблей
        /// </summary>
        public static readonly Color ShipColor = Color.OrangeRed;

        /// <summary>
        /// Абсцисса
        /// </summary>
        [XmlAttribute(AttributeName = "x")]
        public int X;
        /// <summary>
        /// Ордината
        /// </summary>
        [XmlAttribute(AttributeName = "y")]
        public int Y;
        /// <summary>
        /// Состояние клетки
        /// </summary>
        [XmlAttribute(AttributeName = "state")]
        public State CellState;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Cell()
        { }

        /// <summary>
        /// Конструктор по координатам
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// Проверка доступности клетки
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        /// <returns></returns>
        public bool CheckCellAvail(int x, int y)
        {
            int dist = Math.Max(Math.Abs(X - x), Math.Abs(Y - y));
            return dist > 1;
        }

        /// <summary>
        /// Проверка на соседнюю клетку
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        /// <returns></returns>
        public bool CheckCellNear(int x, int y)
        {
            int dist = Math.Abs(X - x) + Math.Abs(Y - y);
            return dist == 1;
        }
    }
}
