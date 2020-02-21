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
        /// Конструктор класса без параметров
        /// </summary>
        public MainForm()
        {
            // Инициализация компонентов дизайнера
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button0_Click(object sender, EventArgs e)
        {
            // Создание нового пустого списка пар чисел
            var list = new List<Pair>();

            // Перебор всех пар чисел от 2 до 99
            // сумма который не больше заданного числа max
            for (int a = 2; a < max; a++)
            {
                for (int b = a + 1; b < max; b++)
                {
                    if (a + b < max)
                    {
                        list.Add(new Pair(a, b));
                    }
                }
            }

            // 1. Группируем список по суммам
            foreach (var group in list.GroupBy(a => a.Sum).ToList())
            {
                // Если такая пара чисел одна
                // то Фридрих (который знает сумму) смог бы выбрать
                // Но он пока не может выбрать, поэтому
                if (group.Count() == 1)
                {
                    // Удалим ее из списка
                    list.Remove(list.First(a=> a.Sum == group.Key));
                }
            }

            // 2. Группируем список по произведениям
            foreach (var group in list.GroupBy(a => a.Mul).ToList())
            {
                // Если такая пара чисел одна
                // то Милс (который знает произведение) смог бы выбрать
                // Но он пока не может выбрать, поэтому
                if (group.Count() == 1)
                {
                    // Удалим ее из списка
                    list.Remove(list.First(a => a.Mul == group.Key));
                }
            }

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
                    }
                }
            }

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
                    }
                }
            }

            MessageBox.Show($"Ответ: {list[0].A} и {list[0].B}");
        }
    }
}
