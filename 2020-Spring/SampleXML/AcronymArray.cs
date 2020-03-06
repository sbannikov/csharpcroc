using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SampleXML
{
    /// <summary>
    /// Список сокращений
    /// </summary>
    [XmlRoot("AcronymList", Namespace = "http://www.orioner.ru/croc")]
    public class AcronymArray
    {
        /// <summary>
        /// Список сокращений
        /// </summary>
        [XmlElement(ElementName = "Acronym")]
        public AcronymWord[] List;

        /// <summary>
        /// Чтение объекта из XML
        /// </summary>
        /// <param name="name">Имя файла или URL</param>
        /// <returns></returns>
        public static AcronymArray Load(string name)
        {
            // Объект для десериализации
            var s = new XmlSerializer(typeof(AcronymArray));
            // Подготовка к чтению XML-файла
            XmlReader reader = XmlReader.Create(name);
            // Десериализация
            return (AcronymArray)s.Deserialize(reader);
        }

        /// <summary>
        /// Сохранить объект в XML-файл
        /// </summary>
        /// <param name="name">Имя файла</param>
        public void Save(string name)
        {
            // Объект для десериализации
            var s = new XmlSerializer(typeof(AcronymArray));
            // Настройка записи
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true // Человеческое форматирование XML
            };
            // Писатель XML-файлов
            using (XmlWriter writer = XmlWriter.Create(name, settings))
            {
                // Сериализация - формирование файла
                s.Serialize(writer, this);
            }
        }
    }
}
