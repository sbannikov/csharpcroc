using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    /// <summary>
    /// Главный класс программы
    /// </summary>
    static class Program
    {
        /// <summary>
        /// База данных
        /// </summary>
        static internal Database.Database db;

        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        [STAThread()]
        static void Main()
        {
            try
            {
                // Создание базы данных
                using (db = new Database.Database())
                {
                    // Регистрация сеанса
                    db.Register();
                    // Запуск главной формы
                    Application.Run(new MainForm());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
