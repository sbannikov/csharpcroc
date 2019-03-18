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
    }
}
