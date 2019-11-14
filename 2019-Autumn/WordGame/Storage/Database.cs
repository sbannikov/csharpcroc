using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WordGame.Storage
{
    /// <summary>
    /// База данных
    /// </summary>
    public class Database : IDict, IDisposable
    {
        /// <summary>
        /// Соединение с базой данных
        /// </summary>
        private SqlConnection conn;

        /// <summary>
        /// Конструктор БД
        /// </summary>
        public Database()
        {
            // Соединение с БД
            conn = new SqlConnection()
            {
                // Типовая строка соединения с Microsoft SQL Server
                ConnectionString = "Data Source=172.26.28.15;Initial Catalog=GAME;User ID=student;Password=Cr0c0k;App=WordGame;"
            };
            // Открыть и установить соединение
            conn.Open();
        }

        /// <summary>
        /// Проверка на наличие слова в словаре
        /// </summary>
        /// <param name="s">Слово</param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Word FROM Dictionary WHERE (Word = @s COLLATE Cyrillic_General_CI_AS) AND (Approved = 1)";
                cmd.Parameters.AddWithValue("s", s);
                object result = cmd.ExecuteScalar();
                return result != null;
            }
        }

        /// <summary>
        /// Добавление слова в базу данных
        /// </summary>
        /// <param name="s">Новое слово</param>
        public void Append(string s)
        {
            // Проверка на наличие слова в словаре
            if (Contains(s))
            {
                return;
            }

            // Добавление слова в словарь
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = $"INSERT INTO Dictionary (Word) VALUES (UPPER(@s))";
                cmd.Parameters.AddWithValue("s", s);
                int result = cmd.ExecuteNonQuery();
                if (result != 1)
                {
                    throw new Exception("О ужас, запись не записалась!");
                }
            }
        }

        /// <summary>
        /// Освобождение ресурсов
        /// </summary>
        public void Dispose()
        {
            conn.Dispose();
        }
    }
}