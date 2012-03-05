using System.Diagnostics.Contracts;

namespace ContractsAndInheritance.Interfaces
{
    [ContractClass(typeof(ListContract))]
    public interface IList : ICollection
    { }

    [ContractClassFor(typeof(IList))]
    internal abstract class ListContract : IList
    {
        public void Add(string s)
        {
            // Lets create stronger postcondition than ICollection.Add
            Contract.Ensures(Count == Contract.OldValue(Count) + 1);
        }
        // Постусловия свойства Count и метода Contains не поменялись
        public int Count
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return 0;
            }
        }

        public bool Contains(string s)
        {
            return false;
        }
    }
}