using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderService
{
    enum EventID
    {
        /// <summary>
        /// Запуск сервиса
        /// </summary>
        StartService = 1,
        /// <summary>
        /// Останов сервиса
        /// </summary>
        StopService,
        /// <summary>
        /// Приостанов сервиса
        /// </summary>
        PauserService,
        /// <summary>
        /// Возобновление сервиса
        /// </summary>
        ContinueService,
        /// <summary>
        /// Срабатывание таймера
        /// </summary>
        TimerEvent,
        /// <summary>
        /// Исключение при работе сервиса 
        /// </summary>
        Exception = 1000
    }
}
