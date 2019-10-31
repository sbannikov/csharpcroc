using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace WordGame.Storage
{
    /// <summary>
    /// Словарь слов
    /// </summary>
    [XmlRoot(ElementName = "WordList", Namespace = "http://www.orioner.ru/croc")]
    public class WordList
    {
        /// <summary>
        /// Массив словарных слов
        /// </summary>
        [XmlElement(ElementName = "Word")]
        public Word[] Words;

        /// <summary>
        /// Загрузить XML-файл 
        /// </summary>
        /// <param name="name">Имя XML-файла</param>
        /// <returns></returns>
        public static WordList Load(string name)
        {
            // Сериализатор - десериализатор
            XmlSerializer ser = new XmlSerializer(typeof(WordList));
            // Читатель XML-файла
            XmlReader rdr = XmlReader.Create(name);
            // Десериализация
            object list = ser.Deserialize(rdr);
            // Приведение типа и возврат результата
            return (WordList)list;
        }
    }
}