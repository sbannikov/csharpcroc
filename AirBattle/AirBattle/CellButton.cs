using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBattle
{
    public class CellButton : System.Windows.Forms.Button
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
        /// Признак собственного поля
        /// </summary>
        readonly public bool My;

        /// <summary>
        /// Конструктор кнопки
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        /// <param name="my">Признак собственного поля</param>
        public CellButton(int x, int y, bool my)
        {
            X = x;
            Y = y;
            My = my;
        }
    }
}
