using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamental
{
    [TestFixture]
    public class FizzBuzzTest
    {
        [Test]
        [TestCase(15, "FizzBuzz")]
        [TestCase(12, "Fizz")]
        [TestCase(20, "Buzz")]
        [TestCase(11, "11")]
        [TestCase(-10, "Buzz")]
        public void FizzBuzz_WhenCalled_ReturnString(int a, string expected)
        {
            var result = FizzBuzz.GetOutput(a);
            Assert.That(result, Is.EqualTo(expected));
        }

        //[Test]
        //public void FizzBuzz_()
        //{

        //}

        //[Test]
        //public void FizzBuzz_()
        //{

        //}

        //[Test]
        //public void FizzBuzz_()
        //{

        //}
    }
}
