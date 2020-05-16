using NUnit.Framework;

namespace NUnitTestProject
{
    class ParametrizedTest
    {
        [TestCase(12, 3, 4)]
        [TestCase(12, 2, 6)]
        [TestCase(12, 4, 3)]
        [Category("TestCasesCategory")]
        public void DivideTest_TestCase1(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }

        [TestCase(12, 3, ExpectedResult = 4)]
        [TestCase(12, 2, ExpectedResult = 6)]
        [TestCase(12, 4, ExpectedResult = 3)]
        [Category("TestCasesCategory")]
        public int DivideTest(int n, int d)
        {
            return n / d;
        }

        [TestCaseSource("DivideCases")]
        [Category("TestCasesCategory")]

        public void TestCaseSource_DivideTest1(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }

        static object[] DivideCases =
        {
        new object[] { 12, 3, 4 },
        new object[] { 12, 2, 6 },
        new object[] { 12, 4, 3 }
            };


        [Test]
        [Category("TestCasesCategory")]
        public void RandomTes1t(
                [Values(1, 2, 3)] int x,
                [Random(-1.0, 1.0, 5)] double d)
        {
        }

        [Test]
        public void RangeTest1(
    [Values(1, 2, 3)] int x,
    [Range(0.2, 0.6, 0.2)] double d)
        {
        }

        [Test]
        [Category("ValuesCategory")]
        [Sequential]
        public void ValuesTest1(
[Values(1, 2, 3)] int x,
[Values(3, 2, 1)] int y)
        {
            Assert.AreEqual(4, x + y);
        }


        [Test]
        [Category("ValuesCategory")]
        public void ValuesSourceTest1(
[ValueSource(typeof(int), "give2")] int x,
[Values(3, 5, 1)] int y)
        {
            Assert.AreEqual(1, (x + y) % 2);
        }

        public static int give2()
        {
            return 2;
        }
    }

    class ValuesClass
    {

        [Test]
        [Category("ValuesCategory")]
        [Combinatorial]
        public void CombinatorialValuesTest1(
        [Values(0, 2, 4)] int x,
        [Values(3, 5, 1)] int y)
        {
            Assert.AreEqual(1, (x + y) % 2);
        }

        [Test]
        [Category("ValuesCategory")]
        [Pairwise]
        public void PairwiselValuesTest1(
[Values(0, 2, 4)] int x,
[Values(3, 5, 1)] int y)
        {
            Assert.AreEqual(1, (x + y) % 2);
        }

    }


}
