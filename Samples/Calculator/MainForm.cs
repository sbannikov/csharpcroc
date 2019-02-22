using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Это - поле
        /// </summary>
        private double x;

        /// <summary>
        /// Второй операнд
        /// </summary>
        private double y;

        /// <summary>
        /// Признак того, что надо начать ввод нового числа
        /// </summary>
        private bool flag = false;

        /// <summary>
        /// Операция арифметическая 
        /// </summary>
        private Operations operation = Operations.NoOperation;

        /// <summary>
        /// 0 - вводим целое число
        /// меньше 0 - показатель степени числа 10
        /// </summary>
        private int factor;

        /// <summary>
        /// Это - свойство
        /// </summary>
        private double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                // Преобразование в строку
                if (trackBase.Value != 10)
                {
                    resultText.Text = Transformator.ConvertTo(x, trackBase.Value);
                }
                else if (factor < 0)
                {
                    // Обработка конечных нулей
                    string format = "0.";

                    for (int i = 1; i < Math.Abs(factor); i++)
                    {
                        format += "0";
                    }

                    resultText.Text = x.ToString(format);
                }
                else
                {
                    resultText.Text = x.ToString();
                }
            }
        }

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            X = 0;
            factor = 0;
        }

        /// <summary>
        /// Обработчик события нажатия на цифру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNumber_Click(object sender, EventArgs e)
        {
            // Преобразование типа
            Button b = (Button)sender;
            int digit;

            // потенциально опасный
            // digit = int.Parse(b.Tag.ToString());

            // Не надо ли начать ввод нового числа?
            if (flag)
            {
                x = 0;
                flag = false;
                factor = 0;
            }

            // безопасный вариант
            if (int.TryParse(b.Tag.ToString(), out digit))
            {
                if (factor == 0)
                {
                    // Целая часть числа
                    X = X * trackBase.Value + digit;
                }
                else
                {
                    // дробная часть числа
                    X = X + digit * Math.Pow(trackBase.Value, factor--);
                }
            }
            else
            {
                MessageBox.Show("так не бывает!!!");
            }
        }

        /// <summary>
        /// Обработчик запятой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonComma_Click(object sender, EventArgs e)
        {
            if (factor == 0)
            {
                factor = -1;
                resultText.Text += ",";
            }
        }

        /// <summary>
        /// Обработчик нажатия действия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOperation_Click(object sender, EventArgs e)
        {
            // Преобразование типа
            Button b = (Button)sender;
            string tag = b.Tag.ToString();

            try
            {
                operation = (Operations)System.Enum.Parse(typeof(Operations), tag);
            }
            catch (Exception)
            {
                operation = Operations.NoOperation;
                MessageBox.Show("Программист ошибся!", "Внутренняя ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            /*
             * Вариант для .NET 4.0
            if (!Enum.TryParse<Operation>(tag.ToString(), out op))
            {
                op = Operation.None;
            }
             */

            // Запомнили операцию
            // operation = Operations.Addition;
            // Запомнили операнд
            y = X;
            // Установить флаг
            flag = true;
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "равно"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            flag = true;
            factor = 0;

            switch (operation)
            {
                case Operations.Addition:
                    X = X + y;
                    break;

                case Operations.Substraction:
                    X = y - X;
                    break;

                case Operations.Multiplication:
                    X = X * y;
                    break;

                case Operations.Division:
                    X = y / X;
                    break;
            }

            operation = Operations.NoOperation;
        }

        /// <summary>
        /// Нажатие на кнопку очистки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            X = 0;
            flag = true;
            factor = 0;
            operation = Operations.NoOperation;
        }

        /// <summary>
        /// Выход из программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Изменение основания системы счисления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBase_Scroll(object sender, EventArgs e)
        {
            // Индикация
            labelBase.Text = string.Format((string)labelBase.Tag, trackBase.Value);
            // x -- значение индикатора
            // resultText.Text -- представлением его на экране
            // resultText.Text = Transformator.ConvertTo(X, trackBase.Value);            
            X = X;

            for (int i = 0; i <= 15; i++)
            {
                string name = string.Format("button{0}", i);
                this.Controls[name].Enabled = i < trackBase.Value;
            }
        }

        /// <summary>
        /// В момент загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainForm_Load(object sender, EventArgs e)
        {
            // Инициализация формы
        }

        /// <summary>
        /// Копирование в буфер обмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Копирование числа в буфер обмена
            System.Windows.Forms.Clipboard.SetText(resultText.Text);
        }

        /// <summary>
        /// Вставить из буфера обмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = System.Windows.Forms.Clipboard.GetText();
            double n;

            /* Этот кусок выбрасывает исключение, и за счет этого время выполнения увеличивается
            try
            {
                X = double.Parse(s);
            }
            catch (Exception)
            {
                MessageBox.Show("В буфере обмена было не число!", "Калькулятор", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             */

            if (!double.TryParse(s, out n))
            {
                MessageBox.Show("В буфере обмена было не число!", "Калькулятор", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string pasted = X.ToString();
                int position = pasted.IndexOf(",");
                if (position >= 0)
                {
                    factor = -(pasted.Length - position - 1);
                }
                else
                {
                    factor = 0;
                }
                // Вычисленный factor влияет на результат выполнения свойства X
                X = n;
            }
        }

        /// <summary>
        /// Вычисление квадратного корня
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRoot_Click(object sender, EventArgs e)
        {
            X = Math.Sqrt(X);
        }
    }
}
