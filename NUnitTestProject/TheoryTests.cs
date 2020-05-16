using NUnit.Framework;
using System;

namespace NUnitTestProject
{
    public class SqrtTests
    {
        [DatapointSource]
        public double[] values = new double[] { 0.0, 1.0, -1.0, 42.0 };

        [Theory]
        public void SquareRootDefinition(double num)
        {
            Assume.That(num >= 0.0);

            double sqrt = Math.Sqrt(num);

            Assert.That(sqrt >= 0.0);
            Assert.That(sqrt * sqrt, Is.EqualTo(num).Within(0.000001));
        }
    }

    [TestFixture(typeof(int))]
    [TestFixture(typeof(double))]
    public class TheorySampleTestsGeneric<T>
    {
        [Datapoint]
        public double[] ArrayDouble1 = { 1.2, 3.4 };
        [Datapoint]
        public double[] ArrayDouble2 = { 5.6, 7.8 };
        [Datapoint]
        public int[] ArrayInt = { 0, 1, 2, 3 };

        [Theory]
        public void TestGenericForArbitraryArray(T[] array)
        {
            Assert.That(array.Length, Is.EqualTo(4));
        }
    }
}
