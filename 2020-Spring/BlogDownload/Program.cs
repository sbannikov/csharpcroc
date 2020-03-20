using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var list = db.GetBlogItems();
                Console.WriteLine("Список загружен");
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
