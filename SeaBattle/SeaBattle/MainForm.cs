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
                    var b = new Button()
                    {
                        Size = new Size(32, 32),
                        Location = new Point(40 * x, 40 * y)
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
            Button b = (Button)sender;
            b.BackColor = Color.OrangeRed;
        }
    }
}
