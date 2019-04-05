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
        static internal Storage.IDatabase db;

        /// <summary>
        /// Точка входа в приложение
        /// </summary>        
        [STAThread()]
        static void Main()
        {
            try
            {
                // База данных ADO.NET или Entity Framework
                // см. также 
                // https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1063-implement-idisposable-correctly
                using ((IDisposable)(db = new Storage.Database()))
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
