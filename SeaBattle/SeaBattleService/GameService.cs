using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace SeaBattle
{
    partial class GameService : ServiceBase
    {
        private Timer timer;

        public GameService()
        {
            InitializeComponent();
            timer = new Timer();
            // Интервал в миллисекундах
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        /// <summary>
        /// Срабатывание таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                timer.Enabled = false;
                // здесь ваша реклама
                WriteEvent("Таймер сработал", EventLogEntryType.Information, EventID.Timer);
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
        /// Протоколирование
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="type"></param>
        /// <param name="id"></param>
        private void WriteEvent(string msg, EventLogEntryType type, EventID id)
        {
            EventLog.WriteEntry(msg, type, (int)id);
        }

        private void WriteException(Exception ex)
        {
            WriteEvent(ex.Message, EventLogEntryType.Error, EventID.Exception);
        }

        /// <summary>
        /// Запуск сервиса вручную
        /// </summary>
        public void Start()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                timer.Enabled = true;
                WriteEvent("Сервис запущен", EventLogEntryType.Information, EventID.Start);
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
                timer.Enabled = false;
                WriteEvent("Сервис остановлен", EventLogEntryType.Information, EventID.Stop);
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
                timer.Enabled = false;
                WriteEvent("Сервис приостановлен", EventLogEntryType.Information, EventID.Pause);
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
                timer.Enabled = true;
                WriteEvent("Сервис возобновлен", EventLogEntryType.Information, EventID.Continue);
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }
    }
}
