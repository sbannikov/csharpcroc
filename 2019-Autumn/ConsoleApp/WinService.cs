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

namespace ConsoleApp
{
    partial class WinService : ServiceBase
    {
        /// <summary>
        /// Домик для сервиса
        /// </summary>
        private ServiceHost host;

        /// <summary>
        /// Наблюдатель за файловой системой
        /// </summary>
        private System.IO.FileSystemWatcher watcher;

        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        public WinService()
        {
            InitializeComponent();

            watcher = new System.IO.FileSystemWatcher()
            {
                Path = @"C:\Users\Student\Documents"
            };
            // Единый обработчик событий файловой системы
            watcher.Changed += watcher_Event;
            watcher.Created += watcher_Event;
            watcher.Deleted += watcher_Event;
            watcher.Renamed += watcher_Event;
        }

        /// <summary>
        /// Событие файловой системы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void watcher_Event(object sender, System.IO.FileSystemEventArgs e)
        {
            EventLog.WriteEntry($"{e.ChangeType}: {e.Name}", EventLogEntryType.Information, (int)EventID.Watcher);
        }

        /// <summary>
        /// Протоколирование исключения
        /// </summary>
        /// <param name="ex"></param>
        private void WriteException(Exception ex)
        {
            EventLog.WriteEntry(ex.Message, EventLogEntryType.Error, (int)EventID.Exception);
        }

        /// <summary>
        /// Запуск сервиса в консольном режиме
        /// </summary>
        public void Start()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                // Домик для сервиса
                host = new ServiceHost(typeof(ConsoleService));
                host.Open();

                // Начать слежение за файловой системой
                watcher.EnableRaisingEvents = true;
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }

        protected override void OnStop()
        {
            try
            {
                host.Close();
                watcher.EnableRaisingEvents = false;
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }

        protected override void OnPause()
        {
            try
            {
                host.Close();
                watcher.EnableRaisingEvents = false;
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }

        protected override void OnContinue()
        {
            try
            {
                // Домик для сервиса
                host = new ServiceHost(typeof(ConsoleService));
                host.Open();

                // Начать слежение за файловой системой
                watcher.EnableRaisingEvents = true;
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }
    }
}
