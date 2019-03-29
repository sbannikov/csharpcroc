using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Пространство имен приложения
/// </summary>
namespace AirBattle
{
    /// <summary>
    /// Главный класс приложение
    /// </summary>
    static class Program
    {
        /// <summary>
        /// База данных
        /// </summary>
        static internal Storage.Database db;

        /// <summary>
        /// Точка входа в приложение
        /// </summary>        
        [STAThread()]
        static void Main()
        {
            try
            {
                // База данных
                using (db = new Storage.Database())
                {
                    // Регистрация клиента в базе данных
                    db.Register();
                    // Запуск главной формы программы
                    Application.Run(new MainForm());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Воздушный бой", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
