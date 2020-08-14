using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest1
    {

        [Test]
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

    }

}
