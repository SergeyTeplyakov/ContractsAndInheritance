using NUnit.Framework;

namespace ContractsAndInheritance.Interfaces
{
    [TestFixture]
    public class CustomCollectionTests
    {
        [Test]
        public void TestAddTwiceAddsTwoElements()
        {
            var collection = new CustomCollection();
            int oldCount = collection.Count;

            collection.Add("");
            collection.Add("");

            Assert.That(collection.Count, Is.EqualTo(oldCount + 2));
        }
    }

}