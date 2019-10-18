using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBattleWeb
{
    /// <summary>
    /// Кнопка со координатами
    /// </summary>
    public class CellButton : System.Web.UI.WebControls.Button
    {
        /// <summary>
        /// Абсцисса
        /// </summary>
        readonly public int X;
        /// <summary>
        /// Ордината
        /// </summary>
        readonly public int Y;

        /// <summary>
        /// Конструктор кнопки
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        public CellButton(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}