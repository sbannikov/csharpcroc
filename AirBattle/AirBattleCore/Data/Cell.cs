using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AirBattle.Data
{
    /// <summary>
    /// Клетка
    /// </summary>
    public class Cell
    {
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
    }
}
