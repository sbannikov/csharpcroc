using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp
{
    [TestFixture()]
    public class ServiceTest
    {
        /// <summary>
        /// Клиент веб-сервиса
        /// </summary>
        private WcfReference.WcfServiceClient client;

        /// <summary>
        /// Конструктор теста
        /// </summary>
        public ServiceTest()
        {
            client = new WcfReference.WcfServiceClient();
        }

        /// <summary>
        /// Проверка соединения
        /// </summary>
        [Test()]
        public void Test1()
        {
            // Проверка на открытие клиента
            client.Open();
            Assert.AreEqual(System.ServiceModel.CommunicationState.Opened, client.State);
        }

        [Test()]
        public void Test2()
        {
            // Проверка соединения     
            Assume.That(client.State == System.ServiceModel.CommunicationState.Opened);
            // Проверка успешного сложения
            Assert.AreEqual(3, client.AdditionDouble("1", "2").Value);
        }

        [Test()]
        public void Test3()
        {
            // Проверка некорректного преобразования
            Assert.AreEqual(false, client.AdditionDouble("A", "B").IsValid);
        }

        [TestCase(1, 2, 3)]
        [TestCase(2, 2, 4)]
        [TestCase(3, -3, 0)]
        [TestCase(1.1, 2.2, 3.3)]
        public void Test4(object x, object y, object sum)
        {
            // Проверка успешного сложения
            Assert.AreEqual(sum, client.AdditionDouble(x.ToString(), y.ToString()).Value);
            Assert.AreEqual(true, client.AdditionDouble(x.ToString(), y.ToString()).IsValid);
        }

        [TestCaseSource(typeof (SourceData), "GetData")]
        public void Test5(SourceData item)
        {
            // Проверка успешного сложения
            Assert.AreEqual(item.Result, client.AdditionDouble(item.A, item.B).Value);
            Assert.AreEqual(true, client.AdditionDouble(item.A, item.B).IsValid);
        }

        [Test()]
        public void Test6()
        {
            client.Close();
            Assert.AreEqual(System.ServiceModel.CommunicationState.Closed, client.State);
            client = null;
        }

    }
}
