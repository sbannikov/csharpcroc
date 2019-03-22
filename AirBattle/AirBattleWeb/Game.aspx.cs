using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AirBattle.Data;

namespace AirBattleWeb
{
    /// <summary>
    /// Класс веб-страницы
    /// </summary>
    public partial class Game : System.Web.UI.Page
    {
        /// <summary>
        /// Состояние игры
        /// </summary>
        private AirBattle.Data.Game game;

        /// <summary>
        /// Обработчик события инициализации страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                // Формирование поля
                for (int y = 1; y <= AirBattle.Data.Game.FieldSize; y++)
                {
                    for (int x = 1; x <= AirBattle.Data.Game.FieldSize; x++)
                    {
                        // Создание новой кнопки
                        CellButton b = new CellButton(x, y)
                        {
                            Width = 48,
                            Height = 48
                        };
                        // Добавление кнопки в панель
                        panel.Controls.Add(b);
                    }
                    // Создание литерала
                    Literal literal = new Literal()
                    {
                        Text = "<br/>"
                    };
                    // Добавление литерала в панель
                    panel.Controls.Add(literal);
                }
                // Загрузка состояния игры из файла
                game = AirBattle.Data.Game.Load(@"C:\GAME.XML");
                // Подсветка кораблей
                foreach (Ship ships in game.My.Ships)
                {
                    // Все клетки корабля
                    foreach (Cell cell in ships.Cells)
                    {
                        foreach (Control c in panel.Controls)
                        {
                            // Проверка на соответствие типу
                            if (!(c is CellButton)) continue;
                            // Явное приведение типа
                            CellButton b = (CellButton)c;
                            // Проверка на соответствие координат
                            if ((b.X == cell.X) && (b.Y == cell.Y))
                            {
                                // Покрасить кнопку
                                b.BackColor = System.Drawing.Color.Indigo;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }
        }

        /// <summary>
        /// Обработчик события загрузки страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}