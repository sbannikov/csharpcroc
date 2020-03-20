using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BlogDownload
{
    /// <summary>
    /// База данных ADO.NET
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Соединение с базой данных
        /// </summary>
        private SqlConnection conn;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Database()
        {
            conn = new SqlConnection();
            // Строка соединения указывается в настройках приложения
            conn.ConnectionString = Properties.Settings.Default.ConnectionString;
            // Открыть соединение
            conn.Open();
        }

        /// <summary>
        /// Прочитать список записей из БД
        /// </summary>
        /// <returns></returns>
        public List<BlogItem> GetBlogItems()
        {
            var list = new List<BlogItem>();

            // Формирование запроса к БД
            SqlCommand cmd = conn.CreateCommand();
            // Только записи с заполненным полем URL
            cmd.CommandText = "SELECT [ID], [Date], [Topic], [URL], ISNULL([Instagram], ''), [Image] FROM [Blog] WHERE NOT URL IS NULL";

            // Выполнение запроса на чтение таблицы
            SqlDataReader rdr = cmd.ExecuteReader();

            // Последовательная обработка всех строк набора данных
            while (rdr.Read())
            {
                var item = new BlogItem(rdr);
                list.Add(item);
            }

            return list;
        }

    }
}
