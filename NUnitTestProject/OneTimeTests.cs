using NUnit.Framework;


namespace NUnitTestProject
{
    [TestFixture]
    public class SuccessTests
    {
        static int a = 0;
        [OneTimeSetUp]
        public void Init()
        {
            a++;
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            a--;
        }

        [Test]
        public void Test1()
        {
            Assert.AreNotEqual(a, 0);
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(a, 1);

        }
    }

    public class PublicOneTimeTests
    {
        static int a = 0;
        [OneTimeSetUp]
        public static void Init()
        {
            a++;
        }

        [OneTimeTearDown]
        public static void Cleanup()
        {
            a--;
        }

        [Test]
        public void Test()
        {
            Assert.AreNotEqual(a, 0);
        }
    }
}
