using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest
{
    /// <summary>
    /// Тестовые данные
    /// </summary>
    public class Source
    {
        public string A;
        public string B;
        public double Result;

        public Source(string a, string b, double result)
        {
            A = a;
            B = b;
            Result = result;
        }

        /// <summary>
        /// Список тестовых данных
        /// </summary>
        /// <returns></returns>
        public static List<Source> GetData()
        {
            var list = new List<Source>();
            // Здесь можно сформировать список по-другому, например, из БД
            list.Add(new Source("1", "2", 0.5));
            list.Add(new Source("3", "1", 3));
            list.Add(new Source("0", "1", 0));
            list.Add(new Source("3", "0", double.PositiveInfinity));
            list.Add(new Source("-4", "0", double.NegativeInfinity));
            list.Add(new Source(null, null, double.NaN));
            return list;
        }
    }
}
