using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace GenericServiceApp
{
    /// <summary>
    /// Установщик сервиса
    /// </summary>
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}
