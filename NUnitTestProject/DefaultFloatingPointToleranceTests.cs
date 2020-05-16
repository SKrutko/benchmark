using NUnit.Framework;

[assembly: Description("Assembly description here")]

namespace Tests
{
    [TestFixture]
    [DefaultFloatingPointTolerance(1)]
    [Description("Test fixtrure to test floating point tolerance.")]
    public class ToleranceTest
    {
        [Test]
        [TestOf(typeof(float))]
        public void ComparisonUsingDefaultFloatingPointToleranceFromFixture()
        {
            // Passes due to the DefaultFloatingPointToleranceAttribute from the fixture.
            Assert.That(1f, Is.EqualTo(2));
        }

        [Test]
        [Description("Test case to test floating point tolerance.")]
        [TestOf("integer")]

        public void ComparisonOfIntegersDoNotUseTolerance()
        {
            // Fails as DefaultFloatingPointTolerance only effects comparisons
            // of floats and doubles.
            Assert.That(1, Is.EqualTo(2));
        }

        [Test]
        [Explicit]
        public void ComparisonUsingSpecificTolerance()
        {
            // Fails as 1 is not equal to 2 using the speficied tolerance 0.
            Assert.That(1f, Is.EqualTo(2).Within(0));
        }

        [Test]
        [DefaultFloatingPointTolerance(2)]
        public void ComparisonUsingDefaultFloatingPointToleranceFromTest()
        {
            // Passes due to the  DefaultFloatingPointTolerance from the test.
            Assert.That(2f, Is.EqualTo(4));
        }
    }
}