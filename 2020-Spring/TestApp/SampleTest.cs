using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp
{
    [TestFixture()]
    public class SampleTest
    {
        /// <summary>
        /// Простейший тест
        /// </summary>
        [Test()]
        public void Test1()
        {
            Assert.AreEqual(4, 2 * 2);
        }

        /// <summary>
        /// Тест, который не будет пройден
        /// </summary>
        [Test()]
        public void Test2()
        {
            // Если удалить комментарий, то тест не будет пройден
            // Assert.AreEqual(5, 2 * 2);
        }
    }
}
