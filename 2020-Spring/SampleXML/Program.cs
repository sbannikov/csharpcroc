using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleXML
{
    class Program
    {
        /// <summary>
        /// Главная функция
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                // Загрузка XML в память
                var list = AcronymArray.Load("http://orioner.ru/croc/AcronymList.xml");
                // Статистика
                Console.WriteLine($"Загружено {list.List.Count()} сокращений");

                foreach (var a in list.List.GroupBy(a => a.Name.Substring(0, 1)).ToList())
                {
                    Console.WriteLine($"{a.Key} - {a.Count()}");
                }

                // Сохранение в файл
                list.Save(@"C:\TEST.XML");
            }
            catch (InvalidOperationException ex)
            {
                // Протоколирование исключения
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Некорректная операция");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (Exception ex)
            {
                // Протоколирование исключения
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                // Подождать нажатия Enter
                Console.ReadLine();
            }
        }
    }
}
