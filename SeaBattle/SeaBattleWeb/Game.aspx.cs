using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeaBattleWeb
{
    public partial class Game : System.Web.UI.Page
    {
        /// <summary>
        /// Инициализация страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            for (int y = 0; y < 10; y++) // Цикл по строкам
            {
                for (int x = 0; x < 10; x++) // Цикл по столбцам
                {
                    // Создание новой кнопки
                    var b = new CellButton(x, y)
                    {
                        Height = new Unit(48),
                        Width = new Unit(48)
                    };
                    // Обработчик кнопки
                    b.Click += button_Click;
                    // Добавление кнопки в панель
                    panel.Controls.Add(b);
                }
                // Добавление перевода строки
                var space = new Literal()
                {
                    Text = "<br />"
                };
                // Добавление HTML-кода в панель
                panel.Controls.Add(space);
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            // Приведение типа
            Button b = (Button)sender;
            // Изменение цвета
            b.BackColor = System.Drawing.Color.DeepPink;
        }

        /// <summary>
        /// Загрузка страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            SeaBattle.Data.Game game;
            game = SeaBattle.Data.Game.Load(@"c:\game.xml");
            // Цикл по всем кораблям
            foreach (var ship in game.My.Ships)
            {
                // Цикл по всем клеткам корабля
                foreach (var cell in ship.Cells)
                {
                    // Цикл по кнопкам
                    foreach (var control in panel.Controls)
                    {
                        // Проверка на тип элемента управления
                        if (!(control is CellButton)) continue;
                        CellButton b = (CellButton)control;
                        if ((b.X == cell.X) && (b.Y == cell.Y))
                        {
                            b.BackColor = System.Drawing.Color.Gold;
                        }
                    }
                }
            }
        }
    }
}