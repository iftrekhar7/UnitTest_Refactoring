using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamental
{
    [TestFixture]
    public class HtmlFormatterTest
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEnclosedTheStringWithStrongElement()
        {
            HtmlFormatter htmlFormatter = new HtmlFormatter();
            var result = htmlFormatter.FormatAsBold("Abc");

            //Specific
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

            //More General

            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc").IgnoreCase);
        }
    }
}
