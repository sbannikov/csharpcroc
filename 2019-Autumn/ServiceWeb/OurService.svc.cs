using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceWeb
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "OurService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы OurService.svc или OurService.svc.cs в обозревателе решений и начните отладку.   
    public class OurService : IOurService
    {
        public Result Division(string sx, string sy)
        {
            try
            {
                double x = double.Parse(sx, System.Globalization.CultureInfo.InvariantCulture);
                double y = double.Parse(sy, System.Globalization.CultureInfo.InvariantCulture);
                return new Result(x / y);
            }
            catch (Exception ex)
            {
                return new Result(ex);
            }
        }
    }
}
