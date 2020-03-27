using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Diagnostics;

namespace GenericServiceApp
{
    /// <summary>
    /// Главный класс программы
    /// </summary>
    class Program
    {
        /// <summary>
        /// Сервис
        /// </summary>
        private static GenericService svc;

        /// <summary>
        /// Главная функция программы
        /// </summary>
        /// <param name="args">Параметры командной строки</param>
        static void Main(string[] args)
        {
            // Интерактивный запуск без параметров командной строки
            if (Environment.UserInteractive && (args.Count() ==0))
            {
                Console.WriteLine("Это сервис");
                return;
            }

            // Имя исполняемого файла сервиса
            // Примечание: GetExecutingAssembly - текущая сборка, но не главный исполняемый файл
            string name = Assembly.GetEntryAssembly().Location;

            // Параметр командной строки
            string arg1 = args.Count() > 0 ? args[0] : "";
            // Преобразование в строчные буквы
            arg1 = arg1.ToLower();

            // Селектор режимов запуска
            switch (arg1)
            {
                case "console":
                    // Создание сервиса
                    svc = new GenericService();
                    svc.Start();
                    Console.Title = "Сервис в консольном режиме";
                    // Номер версии файла
                    string version = FileVersionInfo.GetVersionInfo(name).FileVersion.ToString();
                    Console.WriteLine($"{svc.ServiceName} {version}");
                    Console.WriteLine("Сервис запущен в консольном режиме. Для останова нажмите Enter");
                    Console.ReadLine();
                    svc.Stop();
                    break;

                case "install":
                    // Установка сервиса (службы) операционной системы
                    ManagedInstallerClass.InstallHelper(new string[] { name });
                    break;

                case "uninstall":
                case "delete":
                case "remove":
                    // Удаление сервиса (службы) операционной системы
                    ManagedInstallerClass.InstallHelper(new string[] { "/u", name });
                    break;

                default:
                    // Создание сервиса
                    svc = new GenericService();
                    // Запуск сервиса
                    ServiceBase.Run(svc);
                    break;
            }
        }
    }
}
