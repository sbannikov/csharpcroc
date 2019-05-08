using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGworker
{
    public partial class MainForm : Form
    {
        private Color back;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            // Запомнить фон
            back = buttonGo.BackColor;
        }

        /// <summary>
        /// Интегрируемая функция
        /// </summary>
        /// <param name="x">Аргумент</param>
        /// <returns></returns>
        private double f(double x)
        {
            return Math.Sin(x);
        }

        /// <summary>
        /// Интеграл методом прямоугольников
        /// </summary>
        /// <param name="a">Нижний предел</param>
        /// <param name="b">Верхний предел</param>
        /// <param name="N">Количество интервалов</param>
        /// <returns></returns>
        private double Integrator(double a, double b, long N, BackgroundWorker w)
        {
            double R = 0; // результат
            double delta = (b - a) / N;
            long n = N / 100; // Количество итераций на 1%
            long i = 0;
            int percent = 0;

            // Цикл интегрирования
            for (double x = a; x < b; x += delta)
            {
                // Интегрирование
                R += f(x) * delta;
                int currentPercent = (int) Math.Round((x - a) / (b - a) * 100, 0);
                // Определение хода выполнения
                if (currentPercent != percent)
                {
                    // Сообщить о ходе выполнения процесса
                    w.ReportProgress(currentPercent);
                    // Сбросить счетчик
                    percent = currentPercent;
                }
                // Проверка на досрочное завершение
                if (w.CancellationPending)
                {
                    return R;
                }
            }
            return R;
        }

        /// <summary>
        /// Запуск фонового процесса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (worker1.IsBusy)
            {
                MessageBox.Show("Занято!!!!!");
            }
            else
            {
                // Запуск фонового потока
                worker1.RunWorkerAsync();
                worker2.RunWorkerAsync();
                // немного дизайна
                buttonGo.BackColor = Color.LightCoral;
            }
        }

        /// <summary>
        /// Фоновый поток выполнения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            long N = long.Parse(textN.Text);
            e.Result = Integrator(0, Math.PI / 2, N, (BackgroundWorker)sender).ToString();
        }

        /// <summary>
        /// Завершение выполнения асинхронной операции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (sender == worker1)
            {
                textResult1.Text = (string)e.Result;
            }
            else
            {
                textResult2.Text = (string)e.Result;
            }
            // отметить завершение в интерфейсе
            buttonGo.BackColor = back;
            progress.Value = 0;
        }

        /// <summary>
        /// Отобразить ход выполнения процесса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Досрочный останов потока
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            // Останов
            worker1.CancelAsync();
        }
    }
}
