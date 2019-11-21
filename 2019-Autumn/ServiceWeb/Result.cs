using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWeb
{
    public class Result
    {
        public double Value;
        public string Message;
        public bool IsValid;

        /// <summary>
        /// Конструктор без параметров для сериализации
        /// </summary>
        public Result() 
        {
            Value = double.NaN;
            Message = null;
            IsValid = false;
        }

        /// <summary>
        /// Конструктор по значению
        /// </summary>
        /// <param name="x">Значение</param>
        public Result(double x)
        {
            Value = x;
            Message = null;
            IsValid = true;
        }

        /// <summary>
        /// Конструктор по исключению
        /// </summary>
        /// <param name="ex">Исключение</param>
        public Result(Exception ex)
        {
            Value = double.NaN;
            Message = ex.Message;
            IsValid = false;
        }
    }
}