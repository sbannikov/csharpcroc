using System;
using System.Collections.Generic;
using System.Text;

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
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        public Pair(int a, int b)
        {
            A = a;
            B = b;
            Sum = a + b;
            Mul = a * b;
        }

        public override string ToString() => $"{A} -- {B}";        
    }
}
