using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Acronym
{
    /// <summary>
    /// Список сокращений
    /// </summary>
    [XmlRoot(Namespace = "http://www.orioner.ru/croc", ElementName = "AcronymList")]
    public class AcronymList : IEqualityComparer<Acronym>
    {
        /// <summary>
        /// Список сокращений
        /// </summary>
        [XmlElement(ElementName = "Acronym")]
        public Acronym[] List { get; set; }

        /// <summary>
        /// Загрузить список сокращений из заданного файла
        /// </summary>
        /// <param name="fileName">Имя файла или URL</param>
        /// <returns></returns>
        public static AcronymList Load(string fileName)
        {
            // Создание сериализатора
            XmlSerializer s = new XmlSerializer(typeof(AcronymList));
            // Открываем XML-файл на чтение
            XmlReader reader = XmlReader.Create(fileName);
            // Формирование объекта в памяти на основе XML-файла
            AcronymList list = (AcronymList)s.Deserialize(reader);//Фабрика классов
            // Возврат результата
            return list;
        }

        /// <summary>
        /// Сравнение объектов 
        /// </summary>
        /// <param name="x">Первый объект</param>
        /// <param name="y">Второй объект</param>
        /// <returns></returns>
        public bool Equals(Acronym x, Acronym y)
        {
            return x.Name == y.Name;
        }

        /// <summary>
        /// Хеш-код объекта
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <returns></returns>
        public int GetHashCode(Acronym obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
