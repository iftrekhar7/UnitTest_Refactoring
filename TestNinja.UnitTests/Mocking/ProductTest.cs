using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class ProductTest
    {
        private Product _product;

        [SetUp]
        public void SetUp()
        {
            _product = new Product {ListPrice = 100 };
        }

        [Test]
        public void GetPrice_GoldCustomer_ApplyThirtyPercentDiscount()
        {
            var result = _product.GetPrice(new Customer { IsGold = true });

            Assert.That(result, Is.EqualTo(70));
        }
    }
}
