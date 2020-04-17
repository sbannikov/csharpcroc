using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleSoap
{
    /// <summary>
    /// Результат вычислений
    /// </summary>
    public class Result<T> 
    {
        /// <summary>
        /// Значение
        /// </summary>
        public T Value;

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message;

        /// <summary>
        /// Корректность значения
        /// </summary>

        public bool IsValid;

        /// <summary>
        /// Конструктор по умолчанию для сериализации
        /// </summary>
        public Result() { }

        /// <summary>
        /// Конструктор по значению
        /// </summary>
        /// <param name="x">Значение</param>
        public Result(T x)
        {
            Value = x;
            IsValid = true;
            Message = null;
        }

        /// <summary>
        /// Конструктор по ошибке
        /// </summary>
        /// <param name="ex"></param>
        public Result(Exception ex)
        {            
            IsValid = false;
            Message = ex.Message;
        }
    }
}