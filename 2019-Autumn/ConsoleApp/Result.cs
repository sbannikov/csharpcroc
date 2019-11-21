using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleApp
{
    public class Result
    {
        public double Value;
        public string Message;
        public bool IsValid;
        public Guid ID;

        /// <summary>
        /// Конструктор без параметров для сериализации
        /// </summary>
        public Result() 
        {
            ID = Guid.NewGuid();
            Value = double.NaN;
            Message = null;
            IsValid = false;
        }

        /// <summary>
        /// Конструктор по значению
        /// </summary>
        /// <param name="x">Значение</param>
        public Result(double x) : this()
        {
            Value = x;
            IsValid = true;
        }

        /// <summary>
        /// Конструктор по исключению
        /// </summary>
        /// <param name="ex">Исключение</param>
        public Result(Exception ex) : this()
        {
            Value = double.NaN;
            Message = ex.Message;
            IsValid = false;
        }
    }
}