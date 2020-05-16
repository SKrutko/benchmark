using NUnit.Framework;
using System.Globalization;
using benchmark;
using System.Collections.Generic;
using System;

[assembly: LevelOfParallelism(3)]

namespace NUnitTestProject
{
    [TestFixture]
    class TestClass1
    {

        [TestCase(0, 3)]
        public void CombinatorialValuesTest(int x, int y)
        {
            Assert.AreEqual(1, (x + y) % 2);
        }

        [TestCase(2, 2)]
        [TestCase(1, 2)]
        public void TestMethod(int a, int b)
        {
            int expectedResult = a + b;
            int actualResult = Program.Add(a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [Repeat(3)]
        [TestOf("boolean")]
        public void TestMethod1()
        {
            Assert.True(true);
        }

        [Test]
        [Retry(3)]
        public void RetryTest()
        {
            Assert.IsTrue(true);
        }


        [Test]
        [RequiresThread]
        public void RequiresThreadTest()
        {
            Assert.False(false);
        }
    }

    
    [TestFixture]
    [Description("description from class level")]
    class TestMix
    {
        [Test]
        [Author("Sofia Krutko", "sonya.krutko@gmail.com")]
        public void AuthorTest()
        {
            Assert.IsFalse(false);
        }

        [Test]
        [Parallelizable]
        public void ParallelizableTest()
        {
            Assert.IsFalse(false);
        }

        [Test]
        [Platform("NET-2.0")]
        public void Platform()
        {
            Assert.IsTrue(true);
        }

        [Test]
        [MaxTime(20)]
        [Author("Sofia Krutko", "sonya.krutko@gmail.com")]
        public void MaxTimeTest()
        {
            Assert.IsTrue(true);
        }

        [Test]
        [MaxTime(20)]
        [Ignore("Will fail because of max time")]
        public void SleepTest()
        {
            System.Threading.Thread.Sleep(30);
            Assert.IsTrue(true);
        }

        [Test]
        [Timeout(20)]
        public void TimeoutTest()
        {
            System.Threading.Thread.Sleep(30);
            Assert.IsTrue(true);
        }
    }

    [TestFixtureSource("FixtureArgs")]

    public class MyTestClass
    {
        public MyTestClass(string word, int num)
        {
        }


        static object[] FixtureArgs = {
        new object[] { "Question", 1 },
        new object[] { "Answer", 42 }
    };
    }

    public class SetUpClass
    {
        int b = 0;
        [SetUp]
        public void setup()
        {
            b = 0;
        }
        [Test]
        public void athird()
        {
            Assert.AreEqual(0, b);
            b++;
        }
        [Test]
        public void first()
        {
            Assert.AreEqual(0, b);
            b++;
        }
        [Test]
        public void bsecond()
        {
            Assert.AreEqual(0, b);
            b++;
        }
    }

    public class TearDownClass
    {
        int b = 0;
        [TearDown]
        public void after()
        {
            b = 0;
        }
        [Test]
        public void athird()
        {
            Assert.AreEqual(0, b);
            b++;
        }
        [Test]
        public void first()
        {
            Assert.AreEqual(0, b);
            b++;
        }
        [Test]
        public void bsecond()
        {
            Assert.AreEqual(0, b);
            b++;
        }
    }
    [SingleThreaded]
    public class SingleThreadedClass
    {
        [Test]
        public void SingleThreadedTest()
        {
            Assert.IsTrue(true);
        }
    }

    public class CultureClass
    {
        [Test]
        [Culture("pl-PL")]
        [Description("Should be ignored because culture is not PL")]
        [Property("culture", "pl")]
        public void CulturePL()
        {
            Assert.AreEqual(new System.Globalization.CultureInfo("pl-PL"), CultureInfo.CurrentCulture);
        }

        [Test]
        [Culture("en-US")]
        public void CultureUS()
        {
            Assert.AreEqual(new System.Globalization.CultureInfo("en-US"), CultureInfo.CurrentCulture);
        }

        [Test]
        [SetCulture("pl-PL")]
        public void SetCulturePL()
        {
            Assert.AreEqual(new System.Globalization.CultureInfo("pl-PL"), CultureInfo.CurrentCulture);
        }

        [Test]
        [SetUICulture("pl-PL")]
        public void SetUICulturePL()
        {
            Assert.AreEqual(new CultureInfo("pl-PL"), CultureInfo.CurrentUICulture);
        }

    }

    [SetUpFixture]
    public class MySetUpClass
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }

    public class AssertionsExamples
    {
        [Test]
        public void AssertionsMix()
        {
            Assert.True(true);
            Assert.False(false);
            StringAssert.DoesNotContain("DCB", "ABCDEFG");
            CollectionAssert.AllItemsAreNotNull(new List<int>() { 1, 2, 3, 4, 5, 6 });
            FileAssert.DoesNotExist("somefile.txt");
            DirectoryAssert.DoesNotExist("abcd");
        }


        [Test]
        public void testAssertions()
        {
            Assert.IsNull(null);
            Assert.IsNotNull("a");
            Assert.Null(null);
            Assert.NotNull("a");
            Assert.Zero(0);
            Assert.AreEqual("a", "a");
            Assert.AreNotEqual("a", "b");
            Assert.AreSame("a", "a");
            Assert.AreNotSame("a", "b");
            Assert.IsInstanceOf(typeof(string), "a");
            Assert.IsNotInstanceOf(typeof(int), "a");
            Assert.Pass();
        }

        [Test]
        public void ingnoreTest()
        {
            Assert.Ignore();
        }

        [Test]
        public void failTest()
        {
            Assert.Fail();
        }
        [Test]
        public void inconclusiveTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void testStrings()
        {
            string actual = "ABCDEFG";
            StringAssert.Contains("BCD", actual);
            StringAssert.DoesNotContain("DCB", actual);
            StringAssert.StartsWith("ABC", actual);
            StringAssert.DoesNotStartWith("BCD", actual);
            StringAssert.EndsWith("FG", actual);
            StringAssert.DoesNotEndWith("BCD", actual);
            StringAssert.AreEqualIgnoringCase("abcdefg", actual);
            StringAssert.AreNotEqualIgnoringCase("aaaaaaa", actual);
            StringAssert.IsMatch("A.+", actual);
            StringAssert.DoesNotMatch("K", actual);
        }

        [Test]
        public void testCollections()
        {
            List<int> collection = new List<int>() { 1, 2, 3, 4, 5, 6 };
            CollectionAssert.AllItemsAreInstancesOfType(collection, typeof(int) );
            CollectionAssert.AllItemsAreNotNull(collection);
            CollectionAssert.AllItemsAreUnique(collection);
            CollectionAssert.AreEqual(new List<int>() { 1, 2, 3, 4, 5, 6 }, collection);
            CollectionAssert.AreNotEqual(new List<int>() { 1, 2, 3, 4, 5 }, collection);
            CollectionAssert.AreEquivalent(new List<int>() { 2, 1, 4, 3, 5, 6 }, collection);
            CollectionAssert.Contains(collection, 2);
            CollectionAssert.DoesNotContain(collection, 10);
            CollectionAssert.IsSubsetOf(collection, new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 });
            CollectionAssert.IsNotSubsetOf(collection, new List<int>() { 1, 2, 3, 4, 7, 8 });
            CollectionAssert.IsEmpty(new List<int>());
        }

        [Test]
        public void testFiles()
        {
            FileAssert.DoesNotExist("somefile.txt");
        }

        [Test]
        public void testDirectories()
        {
            DirectoryAssert.DoesNotExist("abcd");
        }
    }


}
