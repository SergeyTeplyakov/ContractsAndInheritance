using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using NUnit.Framework;

namespace ContractsAndInheritance.BCL
{
    [TestFixture]
    public class DoubleElementCollectionTests
    {

        [Test]
        public void Test1()
        {
            var t1 = typeof(List<>);
            var t2 = typeof(ICollection<>);
            Console.WriteLine(t1.GetInterfaces().Any(x =>
  x.IsGenericType &&
  x.GetGenericTypeDefinition() == t2));

            var type = typeof(ICollection<>);
            var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
                .SelectMany(s => s.GetTypes())
                .Where(t => !t.IsInterface)
                .Where(p => type.IsAssignableFrom(p) ||
                            (p.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == type)));

            foreach (var t in types)
                Console.WriteLine(t);
            //foreach(var t in GetType().Assembly.GetTypes())
            //    Console.WriteLine(t);


            //var r = GetType().Assembly.GetTypes().Where(t => t.IsAssignableFrom(typeof(ICollection<>)));
            //foreach(var tt in r)
            //    Console.WriteLine(tt);
        }
        [Test]
        public void TestAddMethodAddsOnlyOneElement()
        {
            ICollection<string> collection = new DoubleElementCollection();
            int oldCount = collection.Count;
            collection.Add("foo");

            Assert.That(collection.Count, Is.EqualTo(oldCount + 1));
        }
        [TestCaseSource("GetAllCollections")]
        public void TestAddToCollectionTwiceAddsTwoElement(ICollection<string> collection)
        {
            int oldCount = collection.Count;
            // Единственным предусловием метода Add является то, что текущая коллекция
            // не является только для чтения! Нужно уважать свою часть контракта,
            // чтобы другие вполняли свою;)
            if (collection.IsReadOnly)
            {
                Console.WriteLine("Current list type ({0}) is readonly. Skipping it...",
                    collection.GetType());
                return;
            }

            collection.Add("foo");
            collection.Add("foo");

            Assert.That(collection.Count, Is.GreaterThanOrEqualTo(oldCount));
            Assert.IsTrue(collection.Contains("foo"));
            //Assert.That(collection.Count, Is.EqualTo(oldCount + 2));
        }

        [TestCaseSource("GetAllLists")]
        public void TestAddToListTwiceAddsTwoElement(IList<string> list)
        {
            int oldCount = list.Count;

            list.Add("foo");
            list.Add("foo");

            Assert.That(list.Count, Is.GreaterThanOrEqualTo(oldCount));
            Assert.IsTrue(list.Contains("foo"));
            Assert.That(list.Count, Is.EqualTo(oldCount + 2));
        }



        private static ICollection<string>[] GetAllCollections()
        {
            return new ICollection<string>[]
    {
        new System.Collections.ObjectModel.Collection<string>(),
        new System.Collections.ObjectModel.ReadOnlyCollection<string>(new List<string>()),
        new System.ComponentModel.BindingList<string>(),
        new System.Collections.Generic.LinkedList<string>(),
        new System.Collections.Generic.SortedSet<string>(),
        new System.Collections.ObjectModel.ObservableCollection<string>(),
        new System.Runtime.CompilerServices.ReadOnlyCollectionBuilder<string>(),
        new System.Collections.Generic.HashSet<string>(),
        new string[]{}, 
        new FakeCollection(), 
    };


            /*
             *
     

        System.Security.Cryptography.CngPropertyCollection
        System.Security.Cryptography.ManifestSignatureInformationCollection
        System.Dynamic.ExpandoObject
        System.Linq.Expressions.Set`1[T]
        System.Runtime.CompilerServices.ReadOnlyCollectionBuilder`1[T]
        System.Runtime.CompilerServices.TrueReadOnlyCollection`1[T]
        System.Collections.Generic.HashSet`1[T]
        System.Dynamic.ExpandoObject+KeyCollection
        System.Dynamic.ExpandoObject+ValueCollection
        System.Linq.Expressions.BlockExpressionList
        System.Linq.Expressions.ListArgumentProvider

             * */
        }

        private static ICollection<string>[] GetAllLists()
        {
            return new IList<string>[]
    {
        new List<string>(),
        new Collection<string>(), 
        new BindingList<string>(),
        new ObservableCollection<string>(),
        new ReadOnlyCollection<string>(new List<string>()),
        new string[]{},
        new FakeList(), 
    };
        }
    }
}