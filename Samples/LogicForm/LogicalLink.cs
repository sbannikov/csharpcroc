using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicForms
{
    /// <summary>
    /// Логическая связь между элементами
    /// </summary>
    public class LogicalLink
    {
        /// <summary>
        /// Исходящий элемент связи
        /// </summary>
        public Logicals.LogicalControl From;
        /// <summary>
        /// Входящий элемент связи
        /// </summary>
        public Logicals.LogicalControl To;
    }
}
