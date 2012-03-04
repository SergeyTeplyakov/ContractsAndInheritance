using System.Diagnostics.Contracts;

namespace ContractsAndInheritance.Interfaces
{
    [ContractClass(typeof(ListContract))]
    public interface IList : ICollection
    { }

    [ContractClassFor(typeof(IList))]
    internal abstract class ListContract : IList, ICollection
    {
        public void Add(string s)
        {
            Contract.Requires(s != null);
            Contract.Ensures(Count == Contract.OldValue(Count) + 1);
        }

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