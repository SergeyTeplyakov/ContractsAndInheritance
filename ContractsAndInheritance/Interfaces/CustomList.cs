using System.Collections.Generic;

namespace ContractsAndInheritance.Interfaces
{
    public class CustomList : IList
    {
        private readonly List<string> _backingList = new List<string>();

        public void Add(string s)
        {
            // IList postcondition is Count = OldCount + 1,
            // we're violating that postcondition
            _backingList.Add(s);
            _backingList.Add(s);
        }

        public int Count
        {
            get
            {
                return _backingList.Count;
            }
        }

        public bool Contains(string s)
        {
            return _backingList.Contains(s);
        }
    }
}