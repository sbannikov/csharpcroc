using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirBattle
{
    public partial class ChoosePlayerForm : Form
    {
        /// <summary>
        /// Конструктор формы
        /// </summary>
        public ChoosePlayerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработка события загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChoosePlayerForm_Load(object sender, EventArgs e)
        {
            // Заполнение списка игроков
            foreach (Storage.Session s in Program.db.GetSessions())
            {
                list.Items.Add(s);
            }
        }
    }
}
