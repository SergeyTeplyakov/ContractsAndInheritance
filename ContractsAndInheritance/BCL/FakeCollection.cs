using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ContractsAndInheritance.BCL
{
    public class FakeCollection : ICollection<string>
    {
        private readonly ICollection<string> _backingList = new List<string>();

        public IEnumerator<string> GetEnumerator()
        {
            return _backingList.GetEnumerator();
        }

        public void Clear()
        {
            _backingList.Clear();
        }

        public void Add(string item)
        {
            if (_backingList.Contains(item))
            {
                _backingList.Remove(item);
            }
            else
            {
                _backingList.Add(item);
            }
        }

        public bool Contains(string item)
        {
            return _backingList.Contains(item);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            _backingList.CopyTo(array, arrayIndex);
        }

        public bool Remove(string item)
        {
            return _backingList.Remove(item);
        }

        public int Count
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() == _backingList.Count);
                return _backingList.Count;
            }
        }

        public bool IsReadOnly
        {
            get { return _backingList.IsReadOnly; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}