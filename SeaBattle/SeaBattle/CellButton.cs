using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    /// <summary>
    /// Кнопка поля
    /// </summary>
    public class CellButton : System.Windows.Forms.Button
    {
        /// <summary>
        /// Абцисса
        /// </summary>
        public int X;
        /// <summary>
        /// Ордината
        /// </summary>
        public int Y;

        /// <summary>
        /// Признак поля игрока
        /// </summary>
        public bool My;

        /// <summary>
        /// Конструктор со значениями
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        /// <param name="my">Признак поля игрока</param>
        public CellButton(int x, int y, bool my) 
        {
            X = x;
            Y = y;
            My = my;
        }
    }
}
