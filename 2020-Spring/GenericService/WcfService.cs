using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GenericServiceApp
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "WcfService" в коде и файле конфигурации.
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple
        )]
    public class WcfService : IWcfService
    {
        /// <summary>
        /// Уникальный идентификатор объекта
        /// </summary>
        private Guid id = Guid.NewGuid();

        public Result<double> AdditionDouble(string sx, string sy)
        {
            try
            {
                // Протоколирование вызова
                GenericService.Log.Trace($"ID = {id} AdditionDouble ({sx}, {sy})");

                // Текущие региональные настройки операционной системы
                IFormatProvider format = System.Globalization.CultureInfo.CurrentCulture;
                double x = double.Parse(sx, format);
                double y = double.Parse(sy, format);
                return new Result<double>(x + y);
            }
            catch (Exception ex)
            {
                return new Result<double>(ex);
            }
        }
    }
}
