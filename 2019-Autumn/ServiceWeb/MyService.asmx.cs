using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiceWeb
{
    /// <summary>
    /// Сводное описание для MyService
    /// </summary>
    [WebService(Namespace = "http://www.orioner.ru")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class MyService : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Привет всем!";
        }

        /// <summary>
        /// Деление вещественных чисел
        /// </summary>
        /// <param name="x">Делимое</param>
        /// <param name="y">Делитель</param>
        /// <returns></returns>
        [WebMethod(Description = "Деление вещественных чисел")]
        public Result Division(string sx, string sy)
        {
            try
            {
                double x = double.Parse(sx, System.Globalization.CultureInfo.InvariantCulture);
                double y = double.Parse(sy, System.Globalization.CultureInfo.InvariantCulture);
                return new Result (x / y);
            }
            catch (Exception ex)
            {
                return new Result(ex);
            }
        }
    }
}
