using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AirBattle.Data;

namespace SeaBattleTest
{
    [TestFixture(Author = "Банников С.Н.")]
    public class CoreTest
    {
        /// <summary>
        /// Пример теста без параметров
        /// </summary>
        [Test()]
        public void Test1()
        {
            Cell cell = new Cell(4, 4);
            Assert.IsTrue(cell.CheckCellNear(5, 4));
            Assert.IsTrue(cell.CheckCellNear(4, 5));
            Assert.IsTrue(cell.CheckCellNear(3, 4));
            Assert.IsTrue(cell.CheckCellNear(4, 3));
            Assert.IsFalse(cell.CheckCellNear(3, 3));
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(-1)]
        public void Test2(double x)
        {
            Assume.That(x >= 0);
            Assert.AreEqual(x * x, Math.Pow(x, 2));
        }

        /// <summary>
        /// Тест с набором данных
        /// </summary>
        /// <param name="data"></param>
        [TestCaseSource(typeof (CoreTestData), "CheckCellNearData")]
        public void Test3(CoreTestData data)
        {
            // Проверка на корректность тестовых данных
            Assume.That(data.X1 >= 0);
            Assume.That(data.X2 >= 0);
            Assume.That(data.Y1 >= 0);
            Assume.That(data.Y2 >= 0);
            // Собственно тестирование
            Cell cell = new Cell(data.X1, data.Y1);
            if (data.Result)
            {
                Assert.IsTrue(cell.CheckCellNear(data.X2, data.Y2));
            }
            else
            {
                Assert.IsFalse(cell.CheckCellNear(data.X2, data.Y2));
            }
        }
    }
}
