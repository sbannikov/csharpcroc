using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsChallenge
{
    /// <summary>
    /// Решение задачи
    /// https://www.adme.ru/svoboda-avtorskie-kolonki/esli-vy-reshite-etu-golovolomku-vam-ne-strashny-nikakie-zhiznennye-trudnosti-1699015/
    /// </summary>
    class Program
    {
        /// <summary>
        /// Сумма чисел a и b не превышает это число
        /// </summary>
        private const int max = 100;

        /// <summary>
        /// Главная функция
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var list = new List<Pair>();

            // Первичное заполнение списка пар чисел
            // Числа больше единицы
            // Числа не равны друг другу (считаем что a < b)
            // Сумма чисел меньше max
            for (int a = 2; a < 100; a++)
            {
                for (int b = a + 1; b < max; b++)
                {
                    // Проверка на предельную сумму
                    if ((a + b) >= max) { continue; }

                    list.Add(new Pair(a, b));
                }
            }
            Console.WriteLine("Шаг 0: {0} пар чисел", list.Count);

            // Шаг 1. Группируем по суммам
            var g1 = list.GroupBy(a => a.Sum).ToList();
            foreach (var group in g1)
            {                
                // Если сумма чисел является уникальной в последовательности,
                // то Фридрих, который знает сумму, уже знал бы оба числа
                // Но он не знает
                if (group.Count() == 1)
                {
                    // Удаляем такие пары из последовательности
                    // Исходя из условия группировки, такой элемент только один
                    list.Remove(list.Where(a => a.Sum == group.Key).First());
                }
            }
            Console.WriteLine("Шаг 1: {0} пар чисел", list.Count);

            // Шаг 2. Группируем по произведениям
            var g2 = list.GroupBy(a => a.Mul).ToList();
            foreach (var group in g2)
            {
                // Если произведение чисел является уникальной в последовательности,
                // то Милс, который знает произведение, уже знал бы оба числа
                // Но он всё еще не знает
                if (group.Count() == 1)
                {
                    // Удаляем такие пары из последовательности
                    // Исходя из условия группировки, такой элемент только один
                    list.Remove(list.Where(a => a.Mul == group.Key).First());
                }
            }
            Console.WriteLine("Шаг 2: {0} пар чисел", list.Count);

            // Шаг 3. Снова группируем по суммам
            var g3 = list.GroupBy(a => a.Sum).ToList();
            foreach (var group in g3)
            {
                // Сумма чисел является уникальной в последовательности,
                // так как Фридрих, который знает сумму, уже знает решение
                // Удаляем все остальные комбинации
                if (group.Count() > 1)
                {                    
                    foreach (var item in group)
                    {
                        list.Remove(item);
                    }
                }
            }
            Console.WriteLine("Шаг 3: {0} пар чисел", list.Count);

            // Шаг 4. Группируем по произведениям
            var g4 = list.GroupBy(a => a.Mul).ToList();
            Console.WriteLine("Ответ:");
            foreach (var group in g4)
            {
                // Фридрих уже нашел решение, 
                // поэтому Милс, который знает только произведение,
                // может выбрать ответ
                if (group.Count() == 1)
                {
                    var item = group.First();
                    Console.WriteLine("A={0} B={1} {0}+{1}={2} {0}*{1}={3}", item.A, item.B, item.Sum, item.Mul);
                }
            }           
        }
    }
}
