using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    /// <summary>
    /// Коды событий
    /// </summary>
    public enum  EventID
    {
        /// <summary>
        /// Код не задан
        /// </summary>
        None = 0,
        /// <summary>
        /// Запуск сервиса
        /// </summary>
        Start,
        /// <summary>
        /// Останов сервиса
        /// </summary>
        Stop,
        /// <summary>
        /// Приостанов сервиса
        /// </summary>
        Pause,
        /// <summary>
        /// Возобновление сервиса
        /// </summary>
        Continue,
        /// <summary>
        /// Событие файловой системы
        /// </summary>
        Watcher,
        /// <summary>
        /// Исключение при работе сервисе
        /// </summary>
        Exception = 1000
    }
}
