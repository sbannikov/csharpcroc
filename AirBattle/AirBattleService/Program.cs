using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Configuration.Install;
using System.Reflection;

namespace AirBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GameService svc;

                // Первый параметр командной строки
                string arg1 = (args.Count() > 0) ? args[0] : null;
                // Имя испольняемого файла сервиса
                string name = Assembly.GetExecutingAssembly().Location;

                switch (arg1)
                {
                    case null:
                        svc = new GameService();
                        ServiceBase.Run(svc);
                        break;

                    case "install":
                        ManagedInstallerClass.InstallHelper(new string[] { name });
                        break;

                    case "uninstall":
                        ManagedInstallerClass.InstallHelper(new string[] { "/u", name });
                        break;

                    case "console":
                        svc = new GameService();
                        svc.Start();
                        Console.WriteLine("Сервис запущен");
                        Console.ReadLine();
                        svc.Stop();
                        break;
                }
            }
            catch (Exception ex)
            {
                if (Environment.UserInteractive)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
                else
                {
                    // @@@ Дописать протоколирование
                }
            }
        }
    }
}
