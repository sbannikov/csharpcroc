using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;

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
        /// Ссылка на источник изображения в Интернет
        /// </summary>
        public string Image;
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Body;

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

        /// <summary>
        /// Загрузить статью из интернета
        /// </summary>
        public void Download()
        {
            // Загрузка веб-страницы
            WebClient client = new WebClient();
            string url = Properties.Settings.Default.Root + URL;
            string s = client.DownloadString(url);

            // Сохранение загруженной веб-страницы в файл
            System.IO.File.WriteAllText($@"c:\blog\{URL}.html", s);

            // Неудачная попытка анализа веб-страницы как XML
            // XDocument doc = XDocument.Parse(s);

            // Поиск заголовока по регулярному выражению
            var title = Regex.Match(s, @"<meta property=""og:title"" content=""([^""]+)""/>");
            if (title.Success)
            {
                Console.WriteLine(title.Groups[1].Value);
            }

            // Поиск текста сообщения регулярным выражением
            var body = Regex.Match(s, @"<meta property=""og:description"" content=""([^""]+)""/>");
            if (body.Success)
            {
                Body = body.Groups[1].Value;
            }

            // Поиск текста сообщения регулярным выражением
            var picture = Regex.Match(s, @"<meta property=""og:image"" content=""([^""]+)""/>");
            if (picture.Success)
            {
                // Адрес картинки на сайте Wix
                string urli = picture.Groups[1].Value;
                // Загрузка картинки в файл
                client.DownloadFile(urli, $@"c:\blog\{URL}.png");
            }
        }

        /// <summary>
        /// Сохранение текста сообщения в БД
        /// </summary>
        /// <param name="db"></param>
        public void Save(Database db)
        {
            // Создание параметрического запроса
            SqlCommand cmd = db.GetCommand();
            cmd.CommandText = "UPDATE Blog SET Body = @body WHERE ID = @id";
            cmd.Parameters.AddWithValue("body", Body);
            cmd.Parameters.AddWithValue("id", ID);

            // Обновление записи в БД
            int result = cmd.ExecuteNonQuery();
            // Несколько избыточный контроль корректности выполнения запроса
            if (result != 1)
            {
                throw new ApplicationException("Ошибка при обновлении данных");
            }
        }

        /// <summary>
        /// Строковое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return URL;
        }
    }
}
