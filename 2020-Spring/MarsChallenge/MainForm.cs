using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsChallenge
{
    /// <summary>
    /// Главная форма
    /// Решение задачи
    /// https://www.adme.ru/svoboda-avtorskie-kolonki/esli-vy-reshite-etu-golovolomku-vam-ne-strashny-nikakie-zhiznennye-trudnosti-1699015/
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Максимальная сумма двух чисел
        /// </summary>
        private const int max = 100;

        /// <summary>
        /// Список пар чисел
        /// </summary>
        private List<Pair> list = new List<Pair>();

        /// <summary>
        /// Конструктор класса без параметров
        /// </summary>
        public MainForm()
        {
            // Инициализация компонентов дизайнера
            InitializeComponent();
        }       

        /// <summary>
        /// Имя ячейки с заданными координатами
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        /// <returns></returns>
        private static string getName(int x, int y)
        {
            return $"cell{x:000}{y:000}";
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int x = 2; x < max; x++)
            {
                for (int y = 2; y < max; y++)
                {
                    var lbl = new Label()
                    {
                        Size = new Size(4, 4),
                        // Учет высоты панели инструментов
                        Location = new Point(x * 4, y * 4 + tool.Height),
                        BackColor = Color.Yellow,
                        // Четыре варианта сформировать имя метки
                        Name = getName(x, y)
                        /*
                        Name = "cell" + x.ToString("000") + y.ToString("000"),
                        Name = "cell" + string.Format("{0:000}", x) + string.Format("{0:000}", y),
                        Name = "cell" + string.Format("{0:000}{1:000}", x, y),
                        */
                    };
                    Controls.Add(lbl);
                }
            }
        }

        /// <summary>
        /// Перекрасить ячейку в заданный цвет
        /// </summary>
        /// <param name="pair">Пара чисел</param>
        /// <param name="color">Цвет</param>
        private void SetColor(Pair pair, Color color)
        {
            string name = getName(pair.A, pair.B);
            Label lbl = (Label)Controls[name];
            lbl.BackColor = color;
        }

        /// <summary>
        /// Шаг решения задачи 0
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие</param>
        /// <param name="e">Параметры события</param>
        private void toolStripButton0_Click(object sender, EventArgs e)
        {
            // Перебор всех пар чисел от 2 до 99
            // сумма который не больше заданного числа max
            for (int a = 2; a < max; a++)
            {
                for (int b = a + 1; b < max; b++)
                {
                    if (a + b < max)
                    {
                        // Добавление нового объекта
                        var pair = new Pair(a, b);
                        list.Add(pair);
                        // Визуализация
                        SetColor(pair, Color.MistyRose);
                    }
                }
            }
        }
        /// <summary>
        /// Шаг решения задачи 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // 1. Группируем список по суммам
            foreach (var group in list.GroupBy(a => a.Sum).ToList())
            {
                // Если такая пара чисел одна
                // то Фридрих (который знает сумму) смог бы выбрать
                // Но он пока не может выбрать, поэтому
                if (group.Count() == 1)
                {
                    // Удалим ее из списка
                    var pair = list.First(a => a.Sum == group.Key);
                    list.Remove(pair);
                    // Визуализация
                    SetColor(pair, Color.DarkRed);
                }
            }
        }

        /// <summary>
        /// Шаг решения задачи 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // 2. Группируем список по произведениям
            foreach (var group in list.GroupBy(a => a.Mul).ToList())
            {
                // Если такая пара чисел одна
                // то Милс (который знает произведение) смог бы выбрать
                // Но он пока не может выбрать, поэтому
                if (group.Count() == 1)
                {
                    // Удалим ее из списка
                    var pair = list.First(a => a.Mul == group.Key);
                    list.Remove(pair);
                    // Визуализация
                    SetColor(pair, Color.Navy);
                }
            }
        }

        /// <summary>
        /// Шаг решения задачи 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // 3. Группируем список по суммам
            foreach (var group in list.GroupBy(a => a.Sum).ToList())
            {
                // Если такая пара чисел не одна
                // то Фридрих (который знает сумму) не смог бы выбрать
                // Но он уже выбрал, поэтому
                if (group.Count() > 1)
                {
                    // Удалим все пары из этой группы
                    foreach (var item in group)
                    {
                        // Удалим ее из списка
                        list.Remove(item);
                        // Визуализация
                        SetColor(item, Color.Aqua);
                    }
                }
            }
        }

        /// <summary>
        /// Шаг решения задачи 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            // 4. Группируем список по произведениям
            foreach (var group in list.GroupBy(a => a.Mul).ToList())
            {
                // Если такая пара чисел не одна
                // то Милс (который знает произведение) не смог бы выбрать
                // Но он уже выбрал, поэтому
                if (group.Count() > 1)
                {
                    // Удалим все пары из этой группы
                    foreach (var item in group)
                    {
                        // Удалим ее из списка
                        list.Remove(item);
                        // Визуализация
                        SetColor(item, Color.MintCream);
                    }
                }
            }
            MessageBox.Show($"Ответ: {list[0].A} и {list[0].B}");
        }
    }
}
