using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sinusoid
{
    /// <summary>
    /// Главная форма программы
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие нажатия на кнопку
        /// </summary>
        /// <param name="sender">Объект-инициатор</param>
        /// <param name="e">Параметры события</param>
        private void button_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Привет!");
            try
            {
                // Получение пределов
                double min;
                if (!double.TryParse(textMininum.Text, out min))
                {
                    MessageBox.Show("Минимум задан некорректно", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                double max;
                if (!double.TryParse(textMaximum.Text, out max))
                {
                    MessageBox.Show("Максимум задан некорректно", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (min >= max)
                {
                    MessageBox.Show("Максимум меньше минимума", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Пределы по оси абсцисс
                chart.ChartAreas[0].AxisX.Minimum = min;
                chart.ChartAreas[0].AxisX.Maximum = max;

                // Создание графика заново
                chart.Series.Clear();
                Series series = chart.Series.Add("sin");
                series.ChartType = SeriesChartType.Spline;
                series.Color = Color.Coral;

                double delta = (max - min) / 100;
                double x = min;

                for (int i = 0; i <= 100; i++)
                {
                    double y = Math.Sin(x);
                    series.Points.AddXY(x, y);
                    x += delta;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
