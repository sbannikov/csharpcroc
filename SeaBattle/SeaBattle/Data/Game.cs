using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SeaBattle.Data
{
    /// <summary>
    /// Состояние игры
    /// </summary>
    [XmlRoot(ElementName = "Game",
        Namespace = "http://vk.com/csharpcroc")]
    public class Game
    {
        /// <summary>
        /// Мое поле с кораблями
        /// </summary>
        [XmlElement(ElementName = "MyField")]
        public Field My;
        /// <summary>
        /// Вражеское поле с кораблями
        /// </summary>
        [XmlElement(ElementName = "EnemyField")]
        public Field Enemy;

        /// <summary>
        /// Конструтор по умолчанию
        /// </summary>
        public Game()
        {
            My = new Field();
            Enemy = new Field();
        }

        /// <summary>
        /// Сохранить объект в XML-файл
        /// </summary>
        /// <param name="name"></param>
        public void Save(string name)
        {
            // Сериализатор
            var ser = new XmlSerializer(typeof(Game));
            // Настройки XML-файла
            var settings = new XmlWriterSettings()
            {
                // Выравнивание тегов красиво для человека
                Indent = true
            };
            // XML-файл для сериализации
            using (XmlWriter wrt = XmlWriter.Create(name, settings))
            {
                // Сериализация
                ser.Serialize(wrt, this);
            }
        }
    }
}
