using System.Diagnostics.Contracts;

namespace ContractsAndInheritance.Interfaces
{
    /// <summary>
    /// Custom collection interface
    /// </summary>
    [ContractClass(typeof(CollectionContract))]
    public interface ICollection
    {
        void Add(string s);
        int Count { get; }
        bool Contains(string s);
    }

    /// <summary>
    /// Contract class for <see cref="ICollection"/>.
    /// </summary>
    [ContractClassFor(typeof(ICollection))]
    internal abstract class CollectionContract : ICollection
    {
        public void Add(string s)
        {
            Contract.Requires(!string.IsNullOrEmpty(s));
            Contract.Ensures(Count >= Contract.OldValue(Count));
            Contract.Ensures(Contains(s));
        }

        public int Count
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return default(int);
            }
        }

        [Pure]
        public bool Contains(string s)
        {
            return default(bool);
        }
    }
}