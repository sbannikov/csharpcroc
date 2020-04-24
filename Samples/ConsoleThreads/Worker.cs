using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleThreads
{
    public class Worker
    {
        /// <summary>
        /// Нижний предел
        /// </summary>
        private double a;
        /// <summary>
        /// Верхний предел
        /// </summary>
        private double b;
        /// <summary>
        /// Количество итераций
        /// </summary>
        private long N;
        /// <summary>
        /// Результат вычисления
        /// </summary>
        private double R;
        /// <summary>
        /// Поток
        /// </summary>
        internal Thread thread;
        /// <summary>
        /// Номер потока, начиная с 1
        /// </summary>
        private int myNumber;

        private DateTime start;

        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        static private Random r = new Random();

        /// <summary>
        /// Объект для блокировки потоков
        /// </summary>
        static internal object locker = new object();

        /// <summary>
        /// Количество созданных экземпляров класса
        /// </summary>
        static int count = 0;

        /// <summary>
        /// Порядковый номер потока, начиная с 1
        /// </summary>
        static int number = 0;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Worker()
        {
            // Случайное число от 0 до 1
            a = r.NextDouble();
            // Случайное число от 2 до 3
            b = 2 + r.NextDouble();
            // Количество итераций 50m - 500m
            N = r.Next(15000000, 150000000);
            // Поток
            thread = new Thread(Work);
            // Увеличение счетчика
            ++count;
            // Сохранение номера потока
            myNumber = ++number;
        }

        /// <summary>
        /// Деструктор класса
        /// </summary>
        ~Worker()
        {
            --count;
        }

        /// <summary>
        /// Интегрируемая функция
        /// </summary>
        /// <param name="x">Аргумент</param>
        /// <returns></returns>
        static private double f(double x)
        {
            return Math.Sin(x);
        }

        /// <summary>
        /// Метод, выполняемый в отдельном потоке
        /// </summary>
        private void Work()
        {
            try
            {
                // Ожидание общей разблокировки
                // Если удалить эту строку, то не будет реализован
                // синхронный запуск всех потоков одновременно
                // (такое же изменение надо сделать в методе Main)
                lock (locker)
                {
                }

                start = DateTime.Now;
                R = 0; // результат
                double delta = (b - a) / N;
                long n = N / 100; // Количество итераций на 1%          
                int percent = 0;

                // Цикл интегрирования
                for (double x = a; x < b; x += delta)
                {
                    // Интегрирование
                    R += f(x) * delta;
                    int currentPercent = (int)Math.Round((x - a) / (b - a) * 100, 0);
                    // Определение хода выполнения
                    if (currentPercent != percent)
                    {
                        if (Console.WindowWidth > myNumber * 8)
                        {
                            // Примечание
                            // Если удалить следующую строку, то правильность вывода информации на экран нарушится
                            lock (locker)
                            {
                                Console.SetCursorPosition(myNumber * 8, 0);
                                Console.Write(currentPercent + "%");
                            }
                        }
                        // Сбросить счетчик
                        percent = currentPercent;
                    }
                }
            }
            catch (ThreadAbortException)
            {
                lock (locker)
                {
                    Console.SetCursorPosition(myNumber * 8, 0);
                    Console.Write("***%");
                }
            }
        }

        /// <summary>
        /// Строковое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("# {0} {5:HH:mm:ss.ffffff}: a = {1}, b = {2}, N = {3}, интеграл = {4}", myNumber, a, b, N, R, start);
        }
    }
}
