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
}