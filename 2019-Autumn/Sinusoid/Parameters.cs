using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinusoid
{
    /// <summary>
    /// Параметры процесса
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Минимум
        /// </summary>
        public long Minimum;
        /// <summary>
        /// Максимум
        /// </summary>
        public long Maximum;

        /// <summary>
        /// Конструктор по строковым значениям
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public Parameters(string min, string max)
        {
            Minimum = long.Parse(min);
            Maximum = long.Parse(max);
        }
    }
}
