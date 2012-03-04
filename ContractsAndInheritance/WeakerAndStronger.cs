using System.Diagnostics.Contracts;
using NUnit.Framework;

namespace ContractsAndInheritance
{
    class Base
    {
        public virtual object Foo(string s)
        {
            Contract.Requires(!string.IsNullOrEmpty(s));
            Contract.Ensures(Contract.Result<object>() != null);
            return new object();
        }

    }

    class Derived : Base
    {
        public override object Foo(string s)
        {
            // Now we're requiring empty string
            Contract.Requires(s != null);
            // And returning only strings
            Contract.Ensures(Contract.Result<object>() is string);
            return s;
        }
    }

    [TestFixture]
    class TestLiskovSubstituionPrinciiple
    {
        [Test]
        [ExpectedException(ExpectedExceptionName = 
            "System.Diagnostics.Contracts.__ContractsRuntime+ContractException")]
        public void TestWeakerPrecondition()
        {
            // Code contracts does not support preconditions in derived types,
            // so this test will fail with precondition violation and
            // static checker warns us about it!
            var d = new Derived();
            d.Foo("");
        }

        [Test]
        public void TestStrongerPostcondition()
        {
            var d = new Derived();
            var r = d.Foo("42");
            Assert.IsInstanceOf<string>(r);
        }
    }
}