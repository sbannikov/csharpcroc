using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

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
        /// Домик для сервиса
        /// </summary>
        static internal ServiceHost host;

        /// <summary>
        /// Главная форма
        /// </summary>
        static internal MainForm form;

        /// <summary>
        /// Очередь выстрелов
        /// </summary>
        static internal ConcurrentQueue<Data.Cell> fire;

        /// <summary>
        /// Очередь результатов выстрелов
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
                // Создание очередей
                fire = new ConcurrentQueue<Data.Cell>();
                result = new ConcurrentQueue<Data.Cell>();
                // Создание базы данных
                // См. также
                // https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1063-implement-idisposable-correctly
                using ((IDisposable)(db = new Database.SeaBattleEntities()))
                {
                    // Регистрация сеанса
                    db.Register();
                    // Создание главной формы
                    form = new MainForm();
                    // Запуск сервиса в отдельном потоке 
                    Task.Factory.StartNew(() =>
                    {
                        // Создание нового сервиса и хостинга для него
                        host = new ServiceHost(new GameService());
                        // Запуск сервиса
                        host.Open();
                    });
                    // Запуск главной формы                    
                    Application.Run(form);
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
            finally
            {
                // Проверка на сущестование хостинга
                if (host != null)
                {
                    // Останов сервиса
                    host.Close();
                }
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
                m += Environment.NewLine;
                m += Environment.NewLine;
                // Текст исключения
                m += $"{ex.GetType().FullName} : {ex.Message}";
            }
            // Выводим полное сообщение об ошибке
            MessageBox.Show(m, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
