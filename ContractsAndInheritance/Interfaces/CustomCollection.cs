using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ContractsAndInheritance.Interfaces
{
    internal class CustomCollection : ICollection
    {
        private readonly List<string> _backingList = new List<string>();
        public void Add(string s)
        {
            Contract.Requires(s != null);
            // Ok, we're crazy enough to violate precondition
            // of ICollection interface
            if (Contains(s))
                _backingList.Remove(s);
            else
                _backingList.Add(s);
        }

        public int Count
        {
            get
            {
                // We should add some hints to static checker to eliminate a warning
                Contract.Ensures(Contract.Result<int>() == _backingList.Count);
                return _backingList.Count;
            }
        }

        public bool Contains(string s)
        {
            return _backingList.Contains(s);
        }
    }
}