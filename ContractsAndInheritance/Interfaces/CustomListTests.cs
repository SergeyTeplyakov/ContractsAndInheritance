using System;
using System.Diagnostics.Contracts;
using NUnit.Framework;

namespace ContractsAndInheritance.Interfaces
{
    [TestFixture]
    public class CustomListTests
    {
        [TestCase]
        public void TestAddToListTwiceAddsTwoElement()
        {
            var list = new CustomList();
            int oldCount = list.Count;

            list.Add("foo");
            list.Add("foo");

            Assert.That(list.Count, Is.GreaterThanOrEqualTo(oldCount));
            Assert.IsTrue(list.Contains("foo"));
            Assert.That(list.Count, Is.EqualTo(oldCount + 2));
        }
    }

    [ContractClass(typeof(ShapeContract))]
    interface IShape
    {
        // Postcondition: Contract.Result<string>() != null
        string DoSomething();
    }

    [ContractClassFor(typeof(IShape))]
    abstract class ShapeContract : IShape
    {
        string IShape.DoSomething()
        {
            Contract.Ensures(Contract.Result<string>() != null);
            throw new NotImplementedException();
        }
    }

    [ContractClass(typeof(BaseShapeContract))]
    abstract class BaseShape : IShape
    {
        // Stronger postcondition: Contract.Result<string>() != string.Empty
        public abstract string DoSomething();
    }

    [ContractClassFor(typeof(BaseShape))]
    abstract class BaseShapeContract : BaseShape
    {
        public override string DoSomething()
        {
            Contract.Ensures(Contract.Result<string>() != string.Empty);
            throw new NotImplementedException();
        }
    }

    class CustomShape : BaseShape, IShape
    {
        public override string DoSomething()
        {
            // And what postcondition to use?
            return string.Empty;
        }
    }

    [TestFixture]
    class TestCustomShape
    {
        [Test]
        public void TestDoSomething()
        {
            var customShape = new CustomShape();
            var result = customShape.DoSomething();
            Assert.IsNotNullOrEmpty(result);

        }
    }
}