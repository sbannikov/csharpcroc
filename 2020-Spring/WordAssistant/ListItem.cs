using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordAssistant
{
    /// <summary>
    /// Элемент для отображения в списках объекта типа T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListItem<T> 
    {
        /// <summary>
        /// Документ Word
        /// </summary>
        public readonly T Item;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="doc">Свойство документа</param>
        public ListItem(T item)
        {
            Item = item;
        }

        /// <summary>
        /// Строковое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {            
            // Явное приведение к динамическому типу для разрешения типа данных на этапе выполнения
            return ((dynamic)Item).Name;
        }
    }
}
