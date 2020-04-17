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
using NLog;

namespace GenericServiceApp
{
    /// <summary>
    /// Класс службы Windows
    /// </summary>
    partial class GenericService : ServiceBase
    {
        /// <summary>
        /// Объект для ведения журнала сообщений
        /// </summary>
        public static readonly Logger Log = LogManager.GetLogger("GenericService");

        /// <summary>
        /// Домик для сервиса
        /// </summary>
        private ServiceHost host;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public GenericService()
        {
            InitializeComponent();

            // Путь для отслеживания изменений
            watch.Path = Properties.Settings.Default.Root;
            // Подписка на события
            watch.Changed += Watch_Event;
            watch.Created += Watch_Event;
            watch.Deleted += Watch_Event;
            watch.Renamed += Watch_Event;

            // Домик для сервиса
            host = new ServiceHost(typeof (WcfService));
        }

        /// <summary>
        /// Событие изменения файловой системы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Watch_Event(object sender, System.IO.FileSystemEventArgs e)
        {
            try
            {
                Log.Trace($"Watch_Event ({sender}, {e})");
                Log.Info($"{e.ChangeType};{e.FullPath}");
                Log.Trace("Watch_Event - выход");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Запуск сервиса вручную
        /// </summary>
        public void Start()
        {
            OnStart(null);
        }

        /// <summary>
        /// Запуск службы
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            try
            {
                host.Open();
                watch.EnableRaisingEvents = true;
                EventLog.WriteEntry("Сервис запущен", EventLogEntryType.Information, 1);
                Log.Info("Сервис запущен");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex);
            }
        }

        /// <summary>
        /// Останов службы
        /// </summary>
        protected override void OnStop()
        {
            try
            {
                host.Close();
                watch.EnableRaisingEvents = false;
                EventLog.WriteEntry("Сервис остановлен", EventLogEntryType.Information, 2);
                Log.Info("Сервис остановлен");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Приостанов сервиса
        /// </summary>
        protected override void OnPause()
        {
            try
            {
                watch.EnableRaisingEvents = false;
                EventLog.WriteEntry("Сервис приостановлен", EventLogEntryType.Information, 3);
                Log.Info("Сервис приостановлен");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Возобновление сервиса
        /// </summary>
        protected override void OnContinue()
        {
            try
            {
                watch.EnableRaisingEvents = true;
                EventLog.WriteEntry("Сервис возобновлен", EventLogEntryType.Information, 4);
                Log.Info("Сервис возобновлен");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}
