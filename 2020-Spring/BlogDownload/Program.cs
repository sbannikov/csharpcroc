using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlogDownload
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var db = new Database();
                Console.WriteLine("Соединение установлено");
                Console.WriteLine($"В базе данных {db.GetBlogCount()} публикаций");
                var list = db.GetBlogItems();
                Console.WriteLine($"К загрузке {list.Count()} публикаций");
                foreach (var item in list)
                {
                    item.Download();
                    Console.WriteLine($"{item} загружен");
                    item.Save(db);
                    // Прерываемся если пользователь нажал кнопку
                    if (Console.KeyAvailable) { break; }
                    Thread.Sleep(5000);                
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Нажмите Enter для завершения");
                Console.ReadLine();
            }
        }
    }
}
