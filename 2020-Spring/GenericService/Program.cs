using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration.Install;
using System.ServiceProcess;

namespace GenericServiceApp
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
                    GenericService svc = new GenericService();
                    // Запуск сервиса
                    ServiceBase.Run(svc);
                    break;
            }
        }
    }
}
