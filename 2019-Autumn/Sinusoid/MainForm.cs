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
                // Очистка прошлых ошибок
                errors.Clear();
                bool ok = true;
                // Получение пределов
                double min;
                if (!double.TryParse(textMininum.Text, out min))
                {
                    errors.SetError(textMininum, "Минимум задан некорректно");
                    errors.SetIconAlignment(textMininum, ErrorIconAlignment.MiddleLeft);
                    ok = false;
                }

                double max;
                if (!double.TryParse(textMaximum.Text, out max))
                {
                    errors.SetError(textMaximum, "Максимум задан некорректно");
                    errors.SetIconAlignment(textMaximum, ErrorIconAlignment.MiddleLeft);
                    ok = false;
                }

                if (ok && (min >= max))
                {
                    errors.SetError(textMininum, "Минимум больше максимума");
                    errors.SetIconAlignment(textMininum, ErrorIconAlignment.MiddleLeft);
                    errors.SetError(textMaximum, "Максимум меньше минимума");
                    errors.SetIconAlignment(textMaximum, ErrorIconAlignment.MiddleLeft);
                    ok = false;
                }

                if (ok)
                {

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Минимум теряет фокус
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textMininum_Leave(object sender, EventArgs e)
        {
            double min;
            if (!double.TryParse(textMininum.Text, out min))
            {
                errors.SetError(textMininum, "Минимум задан некорректно");
                errors.SetIconAlignment(textMininum, ErrorIconAlignment.MiddleLeft);
            }
            else
            {
                errors.SetError(textMininum, null);
            }
        }

        /// <summary>
        /// Мышь вошла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.CornflowerBlue;
        }

        /// <summary>
        /// Мышь ушла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.LightGray;
        }

        /// <summary>
        /// Мышь сидит на кнопке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_MouseHover(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.ForestGreen;
        }

        /// <summary>
        /// Асинхронное действие (в отдельном потоке)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Parameters p = (Parameters)e.Argument;

            int percent = -1;

            for (long i = p.Minimum; i < p.Maximum; i++)
            {
                // Пауза процесса на 10 мс
                System.Threading.Thread.Sleep(10);
                // Проверка на досрочное завершение
                if (worker.CancellationPending)
                {
                    return;
                }
                // Расчет % выполнения задания
                int newPercent = (int)(100.0 *
                    (i - p.Minimum) /
                    (p.Maximum - p.Minimum));
                // Изменился ли % с прошлого раза
                if (newPercent != percent)
                {
                    percent = newPercent;
                    // Отображение процесса
                    worker.ReportProgress(percent);
                }
            }
        }

        /// <summary>
        /// Запуск процесса в отдельном потоке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            worker.RunWorkerAsync(new Parameters(textMininum.Text, textMaximum.Text));
        }

        /// <summary>
        /// Отображение процесса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Запрос досрочного завершения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopButton_Click(object sender, EventArgs e)
        {
            worker.CancelAsync();
        }

        /// <summary>
        /// Завершение процесса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Обнулить % прогресса
            progress.Value = 0;
            // Отображение графика
            button_Click(null, null);
        }
    }
}
