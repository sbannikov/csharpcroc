using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;

namespace AirBattle
{
    /// <summary>
    /// Сервис
    /// </summary>
    partial class GameService : ServiceBase
    {
        /// <summary>
        /// Таймер
        /// </summary>
        private Timer timer;

        /// <summary>
        /// Наблюдатель файловой системы
        /// </summary>
        private FileSystemWatcher watch;

        /// <summary>
        /// Домик для сервиса
        /// </summary>
        private ServiceHost host;

        /// <summary>
        /// Веб-сервис
        /// </summary>
        private WcfService svc;

        /// <summary>
        /// Конструктор
        /// </summary>
        public GameService()
        {
            InitializeComponent();
            // Инициализация таймера
            timer = new Timer();
            timer.Interval = 1000 * 60;
            timer.Elapsed += Timer_Elapsed;
            // Наблюдатель файловой системы
            watch = new FileSystemWatcher()
            {
                Path = @"c:\folder",
                IncludeSubdirectories = true,
                Filter = "*.*"
            };
            watch.Changed += Watch_Event;
            watch.Created+= Watch_Event;
            watch.Deleted+= Watch_Event;
            watch.Renamed+= Watch_Event;
            // Сервис
            svc = new WcfService();
            host = new ServiceHost(svc);
        }

        /// <summary>
        /// Событие наблюдения за файловой системой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Watch_Event(object sender, FileSystemEventArgs e)
        {
            string m;
            m = $"{e.ChangeType}: {e.FullPath}";
            EventLog.WriteEntry(m, EventLogEntryType.Information, (int)EventID.Watch);
        }

        /// <summary>
        /// Событие таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                timer.Enabled = false;
                // Полезная нагрузка
                EventLog.WriteEntry("Таймер сработал", EventLogEntryType.Information, (int)EventID.Timer);
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
            finally
            {
                timer.Enabled = true;
            }
        }

        /// <summary>
        /// Запуск сервиса
        /// </summary>
        public void Start()
        {
            OnStart(null);
        }

        /// <summary>
        /// Протоколирование исключений
        /// </summary>
        /// <param name="ex">Исключение</param>
        private void WriteException(Exception ex)
        {
            EventLog.WriteEntry(ex.Message, EventLogEntryType.Error, (int)EventID.Exception);
        }

        /// <summary>
        /// Событие запуска сервиса
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            try
            {
                // Включение таймера
                timer.Enabled = true;
                watch.EnableRaisingEvents = true;
                host.Open();
                EventLog.WriteEntry("Сервис запущен", EventLogEntryType.Information, (int)EventID.Start);
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }

        /// <summary>
        /// Событие останова сервиса
        /// </summary>
        protected override void OnStop()
        {
            // Выключение таймера
            timer.Enabled = false;
            watch.EnableRaisingEvents = false;
            host.Close();
            EventLog.WriteEntry("Сервис остановлен", EventLogEntryType.Information, (int)EventID.Stop);
        }

        /// <summary>
        /// Событие приостанова сервиса
        /// </summary>
        protected override void OnPause()
        {
            // Выключение таймера
            timer.Enabled = false;
            watch.EnableRaisingEvents = false;
            host.Close();
            EventLog.WriteEntry("Сервис приостановлен", EventLogEntryType.Information, (int)EventID.Pause);
        }

        /// <summary>
        /// Событие возобновления сервиса
        /// </summary>
        protected override void OnContinue()
        {
            // Включение таймера
            timer.Enabled = true;
            watch.EnableRaisingEvents = true;
            host.Open();
            EventLog.WriteEntry("Сервис возобновлен", EventLogEntryType.Information, (int)EventID.Continue);
        }
    }
}
