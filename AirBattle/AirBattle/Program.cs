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
        /// Точка входа в приложение
        /// </summary>        
        [STAThread()]
        static void Main()
        {
            // Запуск главной формы программы
            Application.Run(new MainForm());
        }
    }
}
