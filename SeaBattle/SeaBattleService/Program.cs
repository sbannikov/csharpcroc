using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Configuration.Install;
using System.Reflection;

namespace SeaBattle
{
    class Program
    {
        /// <summary>
        /// Главная функция
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Первый аргумент командной строки
            string arg1 = (args.Count() > 0) ? args[0] : "";
            // Приведение к маленьким буквам
            arg1 = arg1.ToLower();

            // Имя исполняемого файла
            string name = Assembly.GetExecutingAssembly().Location;
            // Создание сервиса
            var svc = new GameService();

            // Селектор по первому параметру командной строки
            switch (arg1)
            {
                case "console":
                    svc.Start();
                    Console.WriteLine("Сервис запущен, нажмите Enter для его завершения");
                    Console.ReadLine();
                    svc.Stop();
                    break;

                case "install":
                    ManagedInstallerClass.InstallHelper(new string[] { name });
                    break;

                case "delete":
                    ManagedInstallerClass.InstallHelper(new string[] { "/u", name });
                    break;

                default:
                    ServiceBase.Run(svc);
                    break;
            }

            // В случае интерактивного запуска 
            if (Environment.UserInteractive)
            {
                Console.ReadLine();
            }
        }
    }
}
