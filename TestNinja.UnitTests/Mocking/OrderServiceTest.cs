using Moq;
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
    public class OrderServiceTest
    {
        private Mock<IStorage> _storage;
        private OrderService _orderService;

        [SetUp]
        public void SetUp()
        {
            _storage = new Mock<IStorage>();
            _orderService = new OrderService(_storage.Object);
        }

        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            var order = new Order();
            _orderService.PlaceOrder(order);
            _storage.Verify(s => s.Store(order)); //Testing the Interaction between Two Objects use varify
        }
    }
}
