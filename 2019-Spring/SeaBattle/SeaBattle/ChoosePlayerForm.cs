using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class ChoosePlayerForm : Form
    {
        /// <summary>
        /// Конструтор формы
        /// </summary>
        public ChoosePlayerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка данных в форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChoosePlayerForm_Load(object sender, EventArgs e)
        {
            // Цикл по всем активным игрокам
            foreach (Database.Sessions s in Program.db.PlayerList())
            {
                // Добавление объекта в список
                list.Items.Add(s);
            }
        }
    }
}
