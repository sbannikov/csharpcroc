using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsChallenge
{
    /// <summary>
    /// Пара чисел
    /// </summary>
    public class Pair
    {
        /// <summary>
        /// Первое число
        /// </summary>
        readonly public int A;
        /// <summary>
        /// Второе число
        /// </summary>
        readonly public int B;
        /// <summary>
        /// Сумма чисел
        /// </summary>
        readonly public int Sum;
        /// <summary>
        /// Произведение чисел
        /// </summary>
        readonly public int Mul;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Pair(int a, int b)
        {
            A = a;
            B = b;
            Sum = a + b;
            Mul = a * b;
        }
    }
}
