using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirBattle
{
    /// <summary>
    /// Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Размер поля
        /// </summary>
        private const int n = 10;
        /// <summary>
        /// Размер кнопки
        /// </summary>
        private const int buttonSize = 48;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainForm()
        {
            // Инициализация компонентов дизайнера
            InitializeComponent();
        }

        /// <summary>
        /// Создание метки в ячейке сетки
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        /// <param name="text">Текст метки</param>
        private void AddLabel(int x, int y, string text)
        {
            // Создание новой метки
            Label label = new Label()
            {
                // Текст метки
                Text = text,
                // Размер метки
                Size = new Size(buttonSize, buttonSize),
                // Шрифт метки
                Font = new Font(FontFamily.GenericMonospace, 32),
                // Выравнивание текста
                TextAlign = ContentAlignment.MiddleCenter,
                // Положение метки
                Location = new Point(buttonSize * x, buttonSize * y + menu.Height)
            };
            // Добавление метки на форму
            Controls.Add(label);
        }

        /// <summary>
        /// Обработка события загрузки формы
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Параметры события</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Формирование квадратного поля
            for (int x = 1; x <= n; x++)
            {
                for (int y = 1; y <= n; y++)
                {
                    // Создание новой кнопки
                    // Использование инициализатора
                    Button b = new Button()
                    {
                        // Размер кнопки
                        Size = new Size(buttonSize, buttonSize),
                        // Положение кнопки
                        Location = new Point(buttonSize * x, buttonSize * y + menu.Height)
                    };
                    // Добавление обработчика кнопки
                    b.Click += Button_Click;
                    // Добавление кнопки на форму
                    Controls.Add(b);
                }
            }
            // Формирование подписей
            for (int a = 1; a <= n; a++)
            {
                // Буквенная подпись по горизонтали
                AddLabel(a, 0, Convert.ToChar(a + Convert.ToInt16('А') - 1).ToString());
                // Цифровая подпись по вертикали
                AddLabel(0, a, (a - 1).ToString());
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку
        /// </summary>
        /// <param name="sender">Кнопка</param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            // Приведение типа
            Button b = (Button)sender;
            // Перекрасить кнопку
            b.BackColor = Color.OrangeRed;
        }

        /// <summary>
        /// Пункт меню - Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Закрыть форму
            this.Close();
        }
    }
}
