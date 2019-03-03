using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicForms.Logicals
{
    public partial class LogicalControl : UserControl
    {
        /// <summary>
        /// Выход - исходящая связь
        /// </summary>
        internal LogicalLink Output;

        /// <summary>
        /// Относительная координата входа
        /// 2 - для инвертора (НЕ)
        /// 6 - для элементов И и ИЛИ
        /// </summary>
        internal int input;

        /// <summary>
        /// Код для логического выражения
        /// </summary>
        internal string Code;

        public LogicalControl()
        {
            InitializeComponent();
        }
    }
}
