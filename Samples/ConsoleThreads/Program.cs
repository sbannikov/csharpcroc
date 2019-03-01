using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleThreads
{
    class Program
    {
        /// <summary>
        /// Список потоков
        /// </summary>
        internal static List<Worker> list = new List<Worker>();

        static int count = 8;

        /// <summary>
        /// Главный метод
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            for (int i = 0; i < count; i++)
            {
                // Создать объект и поместить в список
                list.Add(new Worker());
            }

            // Если удалить эту строку, то не будет реализован
            // синхронный запуск всех потоков одновременно
            // (такое же изменение надо сделать в классе Worker)
            lock (Worker.locker)
            {
                // Запуск потоков
                foreach (Worker w in list)
                {
                    w.thread.Start();
                }
            }
            // Обработчик Ctrl+C
            Console.CancelKeyPress += Console_CancelKeyPress;

            // Ожидание завершения вычисления
            foreach (Worker w in list)
            {
                w.thread.Join();
            }

            // Вывод результата
            Console.WriteLine();
            foreach (Worker w in list)
            {
                Console.WriteLine(w);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Нажатие Ctrl+C
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            list[--count].thread.Abort();
            // Отмена завершения приложения
            e.Cancel = true;
        }
    }
}
