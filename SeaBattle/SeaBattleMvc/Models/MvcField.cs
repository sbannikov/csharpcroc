using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeaBattleMvc.Models
{
    public class MvcField
    {
        /// <summary>
        /// Игровое поле в виде двойного массива
        /// </summary>
        public MvcCell[,] cell = new MvcCell[10, 10];

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="game">Игра</param>
        public MvcField(SeaBattle.Data.Game game)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    cell[x, y] = new MvcCell();
                }
            }
            // Заполнение поля
            foreach (var ship in game.My.Ships)
            {
                foreach (var c in ship.Cells)
                {
                    cell[c.X, c.Y].State = SeaBattle.Data.State.Alive;
                }
            }
        }
    }
}