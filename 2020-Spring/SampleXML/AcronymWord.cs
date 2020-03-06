using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SampleXML
{
    /// <summary>
    /// Сокращение
    /// </summary>
    public class AcronymWord
    {
        /// <summary>
        /// Сокращение
        /// </summary>
        [XmlAttribute()]
        public string Name;

        /// <summary>
        /// Категория (предметная область)
        /// </summary>
        [XmlAttribute()]
        public string Category;

        /// <summary>
        /// Расшифровка и описание
        /// </summary>
        [XmlText()]
        public string Description;
    }
}
