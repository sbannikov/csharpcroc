using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DemoTest
{
    [TestFixture(Author = "Банников Сергей")]
    public class Test1
    {
        /// <summary>
        /// Проверка деления по-простому
        /// </summary>
        [Test()]
        public void Test01()
        {
            Assert.AreEqual(0.5, Worker.Division("1", "2").Value);
            Assert.AreEqual(2, Worker.Division("2", "1").Value);
            Assert.AreEqual(double.PositiveInfinity, Worker.Division("1", "0").Value);
            Assert.AreEqual(0, Worker.Division("0", "1").Value);
            Assert.AreEqual(double.NaN, Worker.Division("ABBA", "1").Value);
        }

        /// <summary>
        /// Проверка корректности расчета
        /// </summary>
        [Test()]
        public void Test02()
        {
            Assert.IsTrue(Worker.Division("1", "2").IsValid);
            Assert.IsTrue(Worker.Division("2", "1").IsValid);
            Assert.IsTrue(Worker.Division("1", "0").IsValid);
            Assert.IsTrue(Worker.Division("0", "1").IsValid);
            Assert.IsFalse(Worker.Division("ABBA", "1").IsValid);
        }

        /// <summary>
        /// Проверка с фиксированным набором входных данных
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <param name="a3"></param>
        [TestCase(1, 2, 0.5)]
        [TestCase(2, 1, 2)]
        [TestCase(1, 0, double.PositiveInfinity)]
        [TestCase(0, 1, 0)]
        [TestCase("TEST ME", 1, double.NaN)]
        [TestCase(1, "TEST ME", double.NaN)]
        public void Test03(object a1, object a2, object a3)
        {
            Assert.AreEqual(a3, Worker.Division(a1.ToString(), a2.ToString()).Value);
        }

        [TestCaseSource(typeof(Source), "GetData")]
        public void Test04(Source item)
        {
            // Проверка данных на корректность
            Assume.That(item.A != null);
            Assume.That(item.B != null);

            // Тестируем только на корректных данных
            Assert.AreEqual(item.Result, Worker.Division(item.A, item.B).Value);

        }
    }
}
