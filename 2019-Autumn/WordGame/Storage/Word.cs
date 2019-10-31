using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WordGame.Storage
{
    /// <summary>
    /// Словарное слово из словаря
    /// </summary>
    public class Word
    {
        /// <summary>
        /// Само слово
        /// </summary>
        [XmlAttribute(AttributeName = "Name")]
        public string Name;

        /// <summary>
        /// Пользователь, который занес слово в словарь
        /// </summary>
        [XmlAttribute(AttributeName = "Author")]
        public string Author;

        /// <summary>
        /// Слово проверено модератором
        /// null - слово не проверено
        /// true - слово одобрено
        /// false - слово запрещено
        /// </summary>
        [XmlAttribute(AttributeName = "Approved")]
        public bool Approved;

        /// <summary>
        /// Описание слово
        /// </summary>
        [XmlText()]
        public string Description;
    }
}