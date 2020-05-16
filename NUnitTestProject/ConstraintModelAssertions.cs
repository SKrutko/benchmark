using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;


namespace NUnitTestProject
{
    [TestFixture]
    class ConstraintModelAssertions
    {
        [NonParallelizable]
        [Test]
        public void IsAssertions()
        {
            Assert.That(0, Is.EqualTo(0));
            Assert.That(0, Is.Not.EqualTo(1));
            Assert.That(null, Is.Null);
            Assert.That("a", Is.Not.Null);
            Assert.That(0, Is.Zero);
            Assert.That(true);
            Assert.That(true, Is.True);
            Assert.That(false, Is.False);
        }
    }
}
