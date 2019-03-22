using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AirBattle.Data
{
    /// <summary>
    /// Состояние игры
    /// </summary>
    [XmlRoot(Namespace = "http://vk.com/csharpcroc")]
    public class Game
    {
        /// <summary>
        /// Размер поля
        /// </summary>
        public const int FieldSize = 10;

        /// <summary>
        /// Моё поле
        /// </summary>
        public Field My;
        /// <summary>
        /// Поле противника
        /// </summary>
        public Field Enemy;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Game()
        {
            My = new Field();
            Enemy = new Field();
        }

        /// <summary>
        /// Загрузка игры из XML-файла
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Game Load(string name)
        {
            // Де-сериализатор
            var ser = new XmlSerializer(typeof(Game));
            // Файл для чтения данных
            using (XmlReader rdr = XmlReader.Create(name))
            {
                // Десериализация
                return (Game)ser.Deserialize(rdr);
            }
        }

        /// <summary>
        /// Сохранение игры в XML-файл
        /// </summary>
        /// <param name="name">Имя создаваемого файла</param>
        public void Save(string name)
        {
            // Сериализатор
            var ser = new XmlSerializer(typeof (Game));
            // Настройки записи XML-файла
            var settings = new XmlWriterSettings()
            {
                // Красивое выравнивание XML-кода
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
