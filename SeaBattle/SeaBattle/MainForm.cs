using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Cостояние игры
        /// </summary>
        private Data.Game game = new Data.Game();

        /// <summary>
        /// Длина корабля
        /// </summary>
        private int cells = 0;

        /// <summary>
        /// Конструктор формы по умолчанию
        /// </summary>
        public MainForm()
        {
            // Инициализация компонентов формы
            InitializeComponent();
        }

        /// <summary>
        /// Обработка события загрузки формы
        /// </summary>
        /// <param name="sender">Форма</param>
        /// <param name="e">Параметры события</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    // Создание кнопки
                    var b = new CellButton(x, y)
                    {
                        Size = new Size(32, 32),
                        // Учет высоты меню и высоты панели инструментов при добавлении кнопки
                        Location = new Point(40 * x, 40 * y + menu.Height + tool.Height)
                    };
                    // Обработчик события
                    b.Click += buttonClick;
                    // Добавление кнопки на форму
                    Controls.Add(b);
                }
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки
        /// </summary>
        /// <param name="sender">Кнопка</param>
        /// <param name="e"></param>
        private void buttonClick(object sender, EventArgs e)
        {
            // Приведение типа данных
            CellButton b = (CellButton)sender;
            // Расстановка кораблей
            switch (cells)
            {
                case 1: // Однопалубный корабль
                    // Покрасить кнопку-корабль
                    b.BackColor = Color.OrangeRed;
                    // Отлипнуть кнопку
                    ship1.Checked = false;
                    // Создать корабль
                    game.My.AddShip1(b.X, b.Y);
                    break;
            }
            // Возврат в основной режим
            cells = 0;
        }

        /// <summary>
        /// Выход из программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Закрыть главную форму
            this.Close();
        }

        /// <summary>
        /// Расстановка однопалубного корабля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ship1_Click(object sender, EventArgs e)
        {
            // "залипание" кнопки
            ship1.Checked = true;
            // Разрешение добавления однопалубного корабля
            cells = 1;
        }

        /// <summary>
        /// Сохранение игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.Save(@"c:\game.xml");
        }
    }
}
