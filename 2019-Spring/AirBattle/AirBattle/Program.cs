using System;
using System.Collections.Concurrent;
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
        /// Очередь для выстрелов
        /// </summary>
        static internal ConcurrentQueue<Data.Cell> fire;

        /// <summary>
        /// Очередь для результатов выстрелов
        /// </summary>
        static internal ConcurrentQueue<Data.Cell> result;

        /// <summary>
        /// Точка входа в приложение
        /// </summary>        
        [STAThread()]
        static void Main()
        {
            try
            {
                // Создание очередей для межпоточного взаимодействия
                fire = new ConcurrentQueue<Data.Cell>();
                result = new ConcurrentQueue<Data.Cell>();
                // База данных ADO.NET или Entity Framework
                // см. также 
                // https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1063-implement-idisposable-correctly
                using ((IDisposable)(db = new Storage.AirBattleEntities()))
                {
                    // Регистрация клиента в базе данных
                    db.Register();
                    // Запуск главной формы программы
                    Application.Run(new MainForm());
                }
            }
            catch (Exception ex)
            {
                string m = ex.Message;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    m += Environment.NewLine;
                    m += ex.Message;
                }
                MessageBox.Show(m, "Воздушный бой", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
