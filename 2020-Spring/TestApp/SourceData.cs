using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    /// <summary>
    /// Тестовые данные
    /// </summary>
    public class SourceData
    {
        public string A;
        public string B;
        public double Result;

        public SourceData(string a, string b, double result)
        {
            A = a;
            B = b;
            Result = result;
        }

        /// <summary>
        /// Формирование тестовых данных
        /// </summary>
        /// <returns></returns>
        public static List<SourceData> GetData()
        {
            var list = new List<SourceData>();
            list.Add(new SourceData("1", "2", 3));
            list.Add(new SourceData("2", "2", 4));
            list.Add(new SourceData("-5", "5", 0));
            return list;
        }
    }
}
