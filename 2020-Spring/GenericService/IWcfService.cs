using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GenericServiceApp
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IWcfService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IWcfService
    {
        /// <summary>
        /// Сложение вещественных чисел
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <returns></returns>
        [OperationContract()]
        Result<double> AdditionDouble(string sx, string sy);
    }
}
