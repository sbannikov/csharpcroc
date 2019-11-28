using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.ServiceModel;
using System.Configuration.Install;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Первый аргумент командной строки
                string arg1 = (args.Count() > 0) ? args[0] : string.Empty;

                // Имя исполняемого файла
                string name = System.Reflection.Assembly.GetExecutingAssembly().Location;

                switch (arg1.ToLower())
                {
                    case "install":
                        ManagedInstallerClass.InstallHelper(new string[] { name });
                        break;

                    case "delete":
                        ManagedInstallerClass.InstallHelper(new string[] { "/u", name });
                        break;

                    case "console":
                        Console.Title = "Консольное приложение";
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Привет, я сервис в консольном режиме");
                        var svc = new WinService();
                        svc.Start();
                        Console.ReadLine();
                        svc.Stop();
                        break;

                    default:
                        if (Environment.UserInteractive)
                        {
                            Console.WriteLine("Привет, я сервис. Запускай меня в консоли с параметром console");
                        }
                        else
                        {
                            // Запуск сервиса в режиме сервиса
                            ServiceBase.Run(new WinService());
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                if (Environment.UserInteractive)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
            }
            finally
            {
#if DEBUG
                if (Environment.UserInteractive)
                {
                    Console.ReadLine();
                }
#endif
            }
        }
    }
}
