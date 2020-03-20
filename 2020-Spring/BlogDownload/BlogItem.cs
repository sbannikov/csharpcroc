using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BlogDownload
{
    /// <summary>
    /// Запись в блоге
    /// </summary>
    public class BlogItem
    {
        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        public Guid ID;
        /// <summary>
        /// Дата публикации
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// Тема публикации
        /// </summary>
        public string Topic;
        /// <summary>
        /// Суффикс URL
        /// </summary>
        public string URL;
        /// <summary>
        /// Признак публикации в Instagram 
        /// </summary>
        public bool Instagram;
        /// <summary>
        /// Полная ссылка на картинку
        /// </summary>
        public string Image;

        /// <summary>
        /// Конструктор из базы данных
        /// Порядок столбцов: [ID], [Date], [Topic], [URL], [Instagram], [Image]
        /// </summary>
        /// <param name="reader"></param>
        public BlogItem(SqlDataReader reader)
        {
            ID = reader.GetGuid(0);
            Date = reader.GetDateTime(1);
            Topic = reader.GetString(2);
            URL = reader.GetString(3);
            string i = reader.GetString(4);          
            Instagram = (i.ToLower() == "да");
            // Проверка на NULL
            if (!reader.IsDBNull(5))
            {
                Image = reader.GetString(5);
            }
        }
    }
}
;