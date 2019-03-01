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
using SnmpSharpNet;

namespace ReaderService
{
    partial class SnmpReaderService : ServiceBase
    {
        /// <summary>
        /// Таймер
        /// </summary>
        private Timer timer;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public SnmpReaderService()
        {
            InitializeComponent();
            // Инициализация таймера
            timer = new Timer(Properties.Settings.Default.Timer);
            // Включение вызова метода в цепочку вызовов события 
            timer.Elapsed += Timer_Elapsed;
        }

        /// <summary>
        /// Обработчик события таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                // Отключение
                timer.Enabled = false;
                // Адрес источника данных по SNMP
                // Адрес берется из конфигурации
                IpAddress peer = new IpAddress(Properties.Settings.Default.Host);

                // Параметры вызова по протоколу SNMP
                // Вторая версия протокола, community string public - чтение данных
                AgentParameters param = new AgentParameters(SnmpVersion.Ver2, new OctetString("public"));
                // Точка подключения по SNMP
                UdpTarget target = new UdpTarget((System.Net.IPAddress)peer, 161, 2000, 1);
                // Список запрашиваемых данных и режим запроса - GET
                Pdu pdu = new Pdu(PduType.Get);

                // 1.3.6.1.2.1.1.1.0 - SysDescr
                // 1.3.6.1.2.1.1.3.0 - SysUpTime
                // Добавление OID в список запрашиваемых данных
                pdu.VbList.Add("1.3.6.1.2.1.1.1.0");
                pdu.VbList.Add("1.3.6.1.2.1.1.3.0");
                // Выполнение запроса по SNMP
                SnmpV2Packet res = (SnmpV2Packet)target.Request(pdu, param);
                foreach (Vb v in res.Pdu.VbList)
                {
                    EventLog.WriteEntry(v.ToString(), EventLogEntryType.Information, (int)EventID.TimerEvent);
                }
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
            finally
            {
                // Включение таймера
                timer.Enabled = true;
            }
        }

        /// <summary>
        /// Протоколирование исключения
        /// /// </summary>
        /// <param name="ex">Исключение</param>
        private void WriteException(Exception ex)
        {
            string message;
            message = string.Format("{0}: {1}", ex.GetType().FullName, ex.Message);
            EventLog.WriteEntry(message, EventLogEntryType.Error, (int)EventID.Exception);
        }

        #region "События сервиса"

        /// <summary>
        /// Событие запуска сервиса
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            try
            {
                timer.Enabled = true;
                EventLog.WriteEntry("Сервис запущен", EventLogEntryType.Information, (int)EventID.StartService);
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
            try
            {
                timer.Enabled = false;
                EventLog.WriteEntry("Сервис остановлен", EventLogEntryType.Information, (int)EventID.StopService);
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }

        /// <summary>
        /// Событие приостанова сервиса
        /// </summary>
        protected override void OnPause()
        {
            try
            {
                timer.Enabled = false;
                EventLog.WriteEntry("Сервис приостановлен", EventLogEntryType.Information, (int)EventID.PauserService);
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }

        /// <summary>
        /// Событие возобновления сервиса
        /// </summary>
        protected override void OnContinue()
        {
            try
            {
                timer.Enabled = true;
                EventLog.WriteEntry("Сервис возобновлен", EventLogEntryType.Information, (int)EventID.ContinueService);
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }

        #endregion

        #region "Консольный режим"
        /// <summary>
        /// Запуск сервиса
        /// </summary>
        public void StartService()
        {
            OnStart(null);
        }

        /// <summary>
        /// Останов сервиса
        /// </summary>
        public void StopService()
        {
            OnStop();
        }
        #endregion
    }
}
