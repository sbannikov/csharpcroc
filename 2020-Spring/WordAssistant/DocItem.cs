using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace WordAssistant
{
    /// <summary>
    /// Документ для списка выбора
    /// </summary>
    [Obsolete("Следует использовать шаблон класса ListItem<T>")]
    public class DocItem
    {
        /// <summary>
        /// Документ Word
        /// </summary>
        public readonly Document Doc;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="doc">Документ Word</param>
        public DocItem(Document doc)
        {
            Doc = doc;
        }

        /// <summary>
        /// Строковое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Doc.Name;
        }
    }
}
