using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ConsoleApp
{
    class Program
    {
        /// <summary>
        /// Домик для сервиса
        /// </summary>
        private static ServiceHost host;

        static void Main(string[] args)
        {
            try
            {
                // Домик для сервиса
                host = new ServiceHost(typeof (ConsoleService));
                host.Open();

                // Оформление
                Console.Title = "Консольное приложение";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Привет, я консольное приложение");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
