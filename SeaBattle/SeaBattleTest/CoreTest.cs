using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SeaBattle
{
    [TestFixture(
        Author = "Банников С.Н.", 
        Category = "Тесты базовой библиотеки классов игры")]
    public class CoreTest
    {
        [Test()]
        public void Test1()
        {
            Data.Cell cell = new Data.Cell(3, 3);
            Assert.IsTrue(cell.CheckNear(2, 3));
            Assert.IsTrue(cell.CheckNear(3, 2));
            Assert.IsTrue(cell.CheckNear(3, 4));
            Assert.IsTrue(cell.CheckNear(4, 3));
            Assert.IsFalse(cell.CheckNear(4, 4));
        }

        [TestCase(4)]
        [TestCase(5)]
        public void Test2(double x)
        {
            Assert.AreEqual(x * x, 16);
        }

        [TestCaseSource(typeof (CoreTestData), "CheckNearData")]
        public void Test3(CoreTestData data)
        {
            // Считаем, что координаты неотрицательны
            Assume.That(data.X1 >= 0);
            Assume.That(data.X2 >= 0);
            Assume.That(data.Y1 >= 0);
            Assume.That(data.Y2 >= 0);
            // Тестирование на корректных данных
            Data.Cell cell = new Data.Cell(data.X1, data.Y1);
            bool result = cell.CheckNear(data.X2, data.Y2);
            Assert.AreEqual(result, data.Result);
        }
    }
}
