using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceWeb
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IOurService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IOurService
    {
        [OperationContract]
        Result Division(string sx, string sy);
    }
}
