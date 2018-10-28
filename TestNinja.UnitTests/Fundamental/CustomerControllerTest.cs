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
    class CustomerControllerTest
    {

        private CustomerController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new CustomerController();
        }
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var result = _controller.GetCustomer(0);

            //exactly NotFound Object
            Assert.That(result, Is.TypeOf<NotFound>());

            //NotFound or one of its derivatives
            Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
            var result = _controller.GetCustomer(5);

            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
