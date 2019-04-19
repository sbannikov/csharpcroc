using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AirBattle.Storage
{
    /// <summary>
    /// База данных при помощи ADO.NET
    /// </summary>
    public sealed class Database : IDisposable, IDatabase
    {
        /// <summary>
        /// Соединение с базой данных
        /// </summary>
        private SqlConnection conn;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Database()
        {
            // Создание объекта соединения
            conn = new SqlConnection();
            // Строка соединения с базой данных - из конфигурации
            conn.ConnectionString = Properties.Settings.Default.ConnectionString;
            // Открытие соединения
            conn.Open();
        }

        /// <summary>
        /// Освобождение ресурсов
        /// </summary>
        public void Dispose()
        {
            conn.Close();
        }

        /// <summary>
        /// Список текущих сеансов
        /// </summary>
        /// <returns></returns>
        public List<Session> GetSessions()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Регистрация приложения в списке активных приложений
        /// </summary>
        public void Register()
        {
            // Текущая метка времени
            DateTime now = DateTime.Now;
            // Признак существования записи
            bool exists;
            // Проверка на существование записи
            using (SqlCommand cmd = conn.CreateCommand())
            {
                // Текст команды
                cmd.CommandText = "SELECT 1 FROM [dbo].[Session] WHERE [ComputerName] = @name";
                // Параметры запроса
                cmd.Parameters.AddWithValue("name", conn.WorkstationId);
                // Исполнение команды
                object o = cmd.ExecuteScalar();
                // Формирование признака существования записи
                exists = (o != null);
            }
            if (exists)
            {
                // Создание команды
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Текст команды
                    cmd.CommandText = "UPDATE [dbo].[Session] SET [TimeStamp] = @now WHERE  [ComputerName] = @name";
                    // Параметры запроса
                    cmd.Parameters.AddWithValue("name", conn.WorkstationId);
                    cmd.Parameters.AddWithValue("now", now);
                    // Исполнение команды
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                // Создание команды
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Текст команды
                    cmd.CommandText = "INSERT INTO [dbo].[Session] ([ComputerName], [TimeStamp]) VALUES (@name, @now)";
                    // Параметры запроса
                    cmd.Parameters.AddWithValue("name", conn.WorkstationId);
                    cmd.Parameters.AddWithValue("now", now);
                    // Исполнение команды
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
