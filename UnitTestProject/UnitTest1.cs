using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest1
    {
        private int counter = 0;

        [Test]
        [Ignore("csak")]
        public void TestMethod1()
        {
            var mock = new Mock<IFoo>();
            var calls = 0;
            var callArgs = new List<string>();

            mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
                .Callback(() => calls++)
                .Returns(true).Callback(() => calls++);

            DoSeomthing(mock.Object);

            mock.VerifySet(foo => foo.Name = "pistike");

            mock.Verify();

            Assert.That(true);
        }

        public void DoSeomthing(IFoo ifoo)
        {
            //bool result = ifoo.DoSomething("w");
            ifoo.Name = "pistika";
        }

        [Test]
        [Retry(3)]
        [TestCase(10, 10)]
        [TestCase(20, 20)]
        [TestCase(30, 50)]
        [TestCase(40, 40)]
        [TestCase(50, 50)]
        [TestCase(10, 20)]
        public void TestMethod2(int hehe, int haha)
        {
            counter++;

            Assert.That(hehe, Is.EqualTo(haha));
        }
    }
}