using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Reflection;
using System.Configuration.Install;

namespace ReaderService
{
    /// <summary>
    /// Главный класс программы
    /// </summary>
    class Program
    {
        /// <summary>
        /// Главная функция программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string arg1 = args.Count() > 0 ? args[0] : "";
            arg1 = arg1.ToLower().Trim();
            SnmpReaderService svc;

            // Имя сервиса (исполняемого файла)
            string name = Assembly.GetExecutingAssembly().Location;

            switch (arg1)
            {
                case "": // Запуск сервиса
                    svc = new SnmpReaderService();
                    ServiceBase.Run(svc);
                    break;

                case "console":
                    svc = new SnmpReaderService();
                    svc.StartService();
                    Console.WriteLine("Сервис запущен. Для останова нажмите Enter");
                    Console.ReadLine();
                    svc.StopService();
                    break;

                case "install":
                    // Добавление сервиса
                    ManagedInstallerClass.InstallHelper(new string[] { name });
                    break;

                case "uninstall":
                    // Удаление сервиса
                    ManagedInstallerClass.InstallHelper(new string[] { "/u", name });
                    break;

            }
        }
    }
}
