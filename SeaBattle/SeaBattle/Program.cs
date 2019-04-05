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
        static internal Database.IDatabase db;

        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        [STAThread()]
        static void Main()
        {
            try
            {
                // Создание базы данных
                // См. также
                // https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1063-implement-idisposable-correctly
                using ((IDisposable)(db = new Database.SeaBattleEntities()))
                {
                    // Регистрация сеанса
                    db.Register();
                    // Запуск главной формы
                    Application.Run(new MainForm());
                }
            }
            catch (Exception ex)
            {
               ShowException(ex);
            }
        }

        /// <summary>
        /// Вывод на экран сведения об исключении
        /// </summary>
        /// <param name="ex">Исключение</param>
        internal static void ShowException(Exception ex)
        {
            // Текст внешнего исключения
            string m = ex.GetType().FullName + ": " + ex.Message;
            // Собираем тексты всех вложенных исключений
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                // Перевод строки
                m += System.Environment.NewLine;
                m += System.Environment.NewLine;
                // Текст исключения
                m += $"{ex.GetType().FullName} : {ex.Message}";
            }
            // Выводим полное сообщение об ошибке
            MessageBox.Show(m, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);            
        }
    }
}
