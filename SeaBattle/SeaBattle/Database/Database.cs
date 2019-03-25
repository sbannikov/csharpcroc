using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SeaBattle.Database
{
    /// <summary>
    /// Служебная база данных
    /// </summary>
    public sealed class Database : IDisposable
    {
        /// <summary>
        /// Соединение с базой данных
        /// </summary>
        private SqlConnection conn;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Database()
        {
            // Создание соединения с базой данных
            conn = new SqlConnection();
            // Строка соединения из конфигурации
            conn.ConnectionString = Properties.Settings.Default.ConnectionString;
            // Открытие соединения
            conn.Open();
        }

        /// <summary>
        /// Регистрация сеанса в базе данных
        /// </summary>
        public void Register()
        {
            bool exists;
            // Текущая метка времени
            DateTime now = DateTime.Now;
            // Проверка на существование записи
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT 1 FROM [Sessions] WHERE [ComputerName] = @name";
                cmd.Parameters.AddWithValue("name", conn.WorkstationId);
                // Выполнение скалярного запроса
                object result = cmd.ExecuteScalar();
                // Признак существования записи о моем компьютере в БД
                exists = (result != null);
            }
            if (exists)
            {
                // Изменяем существующую строчку
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Вставка данных
                    cmd.CommandText = "UPDATE [Sessions] SET [TimeStamp] = @now WHERE [ComputerName] = @name";
                    cmd.Parameters.AddWithValue("name", conn.WorkstationId);
                    cmd.Parameters.AddWithValue("now", now);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                // Добавляем новую строчку
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Вставка данных
                    cmd.CommandText = "INSERT INTO [Sessions] ([ComputerName], [TimeStamp]) VALUES (@name, @now)";
                    cmd.Parameters.AddWithValue("name", conn.WorkstationId);
                    cmd.Parameters.AddWithValue("now", now);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Освобождение общих ресурсов
        /// </summary>
        public void Dispose()
        {
            // Закрытие соединения
            conn.Close();
        }
    }
}
