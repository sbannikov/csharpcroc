﻿using System;
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
    public class WordList : IEqualityComparer<Word>
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

        /// <summary>
        /// Сохранение словаря в XML-файл
        /// </summary>
        /// <param name="name">Имя файла</param>
        public void Save(string name)
        {
            // Сериализатор - десериализатор
            XmlSerializer ser = new XmlSerializer(typeof(WordList));
            // Настройки
            var settings = new XmlWriterSettings()
            {
                Indent = true // Строки по-человечески
            };
            // Писатель
            using (XmlWriter wrt = XmlWriter.Create(name, settings))
            {
                // Формирование XML-файла
                ser.Serialize(wrt, this);
            }
        }

        /// <summary>
        /// Сравнение слов на равенство
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(Word x, Word y)
        {
            return x.Name == y.Name;
        }

        /// <summary>
        /// Хэш объекта
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(Word obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}