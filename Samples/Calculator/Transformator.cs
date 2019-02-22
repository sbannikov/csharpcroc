using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public static class Transformator
    {
        /// <summary>
        /// Символы для старших систем счисления
        /// </summary>
        private const string Letters = "ABCDEFGHIJK";

        /// <summary>
        /// Преобразование в заданную систему счисления
        /// </summary>
        /// <param name="x"></param>
        /// <param name="Base"></param>
        /// <returns></returns>
        public static string ConvertTo(double x, int Base)
        {
            int n = (int)Math.Round(x);
            string s = "";

            do
            {
                int b = n % Base;
                if (b >= 10)
                {
                    s = Letters.Substring(b - 10, 1) + s;
                }
                else
                {
                    s = b.ToString() + s;
                }
                n = n / Base;
            }
            while (n > 0);

            return s;
        }
    }
}
;