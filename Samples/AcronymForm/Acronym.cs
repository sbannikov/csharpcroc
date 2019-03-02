using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Acronym
{
    /// <summary>
    /// Сокращение
    /// </summary>
    public class Acronym
    {
        /// <summary>
        /// Сокращение
        /// </summary>
        [XmlAttribute(AttributeName ="Name")]
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [XmlText()]
        public string Description { get; set; }

        /// <summary>
        /// Свойство, которое игнорируется десериализацией
        /// </summary>
        [XmlIgnore()]
        public string Other { get; set; }
    }
}
