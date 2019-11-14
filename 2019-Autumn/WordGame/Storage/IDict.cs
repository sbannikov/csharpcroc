using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.Storage
{
    /// <summary>
    /// Словарь словарных слов
    /// </summary>
    public interface IDict
    {
        /// <summary>
        /// Проверка на наличие слова в словаре
        /// </summary>
        /// <param name="s">Слово</param>
        /// <returns></returns>
        bool Contains(string s);

        /// <summary>
        /// Добавление слова в словарь
        /// </summary>
        /// <param name="s">Новое слово</param>
        void Append(string s);
    }
}
