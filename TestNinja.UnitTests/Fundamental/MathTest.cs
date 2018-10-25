using NUnit.Framework;
using TestNinja.Fundamentals;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests.Fundamental
{
    [TestFixture]
    public class MathTest
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnSumOfArguments()
        {
            var sum = _math.Add(200, 2);

            Assert.That(sum, Is.EqualTo(202));
        }

        [TestCase(1, 2, 2)]
        [TestCase(4, 3, 4)]
        [TestCase(2, 2, 2)]
        [Test]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var max = _math.Max(a,b);

            Assert.That(max, Is.EqualTo(expectedResult));
        }

        [Ignore("redundant")]
        [Test]
        public void Max_ArgumentsAreEqual_ReturnSameArgument()
        {
            Math math = new Math();
            var max = math.Max(10, 10);

            Assert.That(max, Is.EqualTo(10));
        }
    }
}
