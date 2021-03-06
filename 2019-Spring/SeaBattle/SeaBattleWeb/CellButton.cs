﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeaBattleWeb
{
    /// <summary>
    /// Кнопка поля боя
    /// </summary>
    public class CellButton : System.Web.UI.WebControls.Button
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
        /// Конструктор со значениями
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