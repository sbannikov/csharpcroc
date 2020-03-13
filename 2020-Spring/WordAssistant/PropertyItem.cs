using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace WordAssistant
{
    /// <summary>
    /// Свойство документа для списка
    /// </summary>
    [Obsolete("Следует использовать шаблон класса ListItem<T>")]
    public class PropertyItem
    {
        /// <summary>
        /// Документ Word
        /// </summary>
        public readonly CustomProperty Prop;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="doc">Свойство документа</param>
        public PropertyItem(CustomProperty prop)
        {
            Prop = prop;
        }

        /// <summary>
        /// Строковое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Prop.Name;
        }
    }
}
