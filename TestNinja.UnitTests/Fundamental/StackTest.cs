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
    public class StackTest
    {
        private Fundamentals.Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Fundamentals.Stack<string>();
        }

        [Test]
        public void Push_NullArguments_ThrowArgsNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ArgIsValid_AddtheObjectToTheStack()
        {
            _stack.Push("a");
            var count = _stack.Count;
            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {

            var count = _stack.Count;
            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackWithFewObject_ReturnObjectOnTheTop()
        {
            _stack.Push("d");
            _stack.Push("c");
            _stack.Push("b");
            _stack.Push("a");

            var result = _stack.Pop();
            Assert.That(result, Is.EquivalentTo("a"));
        }

        [Test]
        public void Pop_StackWithFewObject_RemoveObjectOnTheTop()
        {
            _stack.Push("d");
            _stack.Push("c");
            _stack.Push("b");
            _stack.Push("a");
            _stack.Pop();
            Assert.That(_stack.Count, Is.EqualTo(3));
        }

        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithFewObject_ReturnObjectOnTheTop()
        {
            _stack.Push("d");
            _stack.Push("c");
            _stack.Push("b");
            _stack.Push("a");

            var result = _stack.Peek();
            Assert.That(result, Is.EquivalentTo("a"));
        }

        [Test]
        public void Peek_StackWithFewObject_DoesNotRemoveObjectFromStack()
        {
            _stack.Push("d");
            _stack.Push("c");
            _stack.Push("b");
            _stack.Push("a");
            _stack.Peek();
            Assert.That(_stack.Count, Is.EqualTo(4));
        }
    }
}
