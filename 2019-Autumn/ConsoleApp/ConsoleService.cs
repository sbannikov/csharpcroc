using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ConsoleApp
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ConsoleService" в коде и файле конфигурации.
    [ServiceBehavior(
          InstanceContextMode = InstanceContextMode.PerCall,
          ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ConsoleService : IConsoleService
    {
        private Guid id = Guid.NewGuid();

        public Result Division(string sx, string sy)
        {
            try
            {
                double x = double.Parse(sx, System.Globalization.CultureInfo.InvariantCulture);
                double y = double.Parse(sy, System.Globalization.CultureInfo.InvariantCulture);
                Console.WriteLine($"{sx} {sy}");
                System.Threading.Thread.Sleep(10000);
                Console.WriteLine("Я проснулся (Лунтик)");
                return new Result(x / y) { ID = id };
            }
            catch (Exception ex)
            {
                return new Result(ex);
            }
        }
    }
}
