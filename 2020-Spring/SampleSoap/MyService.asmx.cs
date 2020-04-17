using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SampleSoap
{
    /// <summary>
    /// Простой сервис
    /// </summary>
    [WebService(Namespace = "http://croc.ru/csharp", Description = "Учебный веб-сервис")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class MyService : System.Web.Services.WebService
    {
        /// <summary>
        /// Сложение двух вещественных чисел
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <returns></returns>
        [WebMethod(Description = "Сложение двух вещественных чисел")]
        public Result<double> Addition(string sx, string sy)
        {
            try
            {
                // Текущие региональные настройки операционной системы
                IFormatProvider format = System.Globalization.CultureInfo.CurrentCulture;
                double x = double.Parse(sx, format);
                double y = double.Parse(sy, format);
                return new Result<double>(x + y);
            }
            catch (Exception ex)
            {
                return new Result<double>(ex);
            }
        }

        /// <summary>
        /// Сложение двух целых чисел
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <returns></returns>
        [WebMethod(Description = "Сложение двух целых чисел")]
        public Result<int> AdditionInteger(string sx, string sy)
        {
            try
            {
                // Текущие региональные настройки операционной системы
                IFormatProvider format = System.Globalization.CultureInfo.CurrentCulture;
                int x = int.Parse(sx, format);
                int y = int.Parse(sy, format);
                return new Result<int>(x + y);
            }
            catch (Exception ex)
            {
                return new Result<int>(ex);
            }
        }




        [WebMethod(Description = "Метод просто для примера")]
        public string HelloWorld()
        {
            return "Привет всем!";
        }
    }
}
