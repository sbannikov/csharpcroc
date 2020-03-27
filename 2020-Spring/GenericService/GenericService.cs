using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace GenericServiceApp
{
    /// <summary>
    /// Класс службы Windows
    /// </summary>
    partial class GenericService : ServiceBase
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public GenericService()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Запуск службы
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            // TODO: Добавьте код для запуска службы.
        }

        /// <summary>
        /// Останов службы
        /// </summary>
        protected override void OnStop()
        {
            // TODO: Добавьте код, выполняющий подготовку к остановке службы.
        }
    }
}
