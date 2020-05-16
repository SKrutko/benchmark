using NUnit.Framework;

namespace NUnitTestProject
{
    public class OrderTests
    {

        static int a = 0;
        int b = 0;
        [Test]
        [Order(3)]

        public void athird()
        {
            Assert.AreEqual(2, a);
            Assert.AreEqual(0, b);
            a++;
            b++;
        }
        [Test]
        [Order(1)]

        public void FirstInOrder()
        {
            Assert.AreEqual(0, a);
            Assert.AreEqual(0, b);

            a++;
            b++;
        }
        [Test]
        [Order(2)]
        public void bsecond()
        {
            Assert.AreEqual(1, a);
            Assert.AreEqual(0, b);

            a++;
            b++;
        }
    }
}
