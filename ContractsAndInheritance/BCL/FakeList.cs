using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ContractsAndInheritance.BCL
{
    public class FakeList : IList<string>
    {
        private readonly IList<string> _backingList = new List<string>();

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
            //_backingList.Add(item);
            //_backingList.Add(item);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _backingList.GetEnumerator();
        }

        public void Clear()
        {
            _backingList.Clear();
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

        public int IndexOf(string item)
        {
            var idx = _backingList.IndexOf(item);
            Contract.Assume(idx + Count <= _backingList.Count);
            return idx;
        }

        public void Insert(int index, string item)
        {
            _backingList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _backingList.RemoveAt(index);
        }

        public string this[int index]
        {
            get { return _backingList[index]; }
            set { _backingList[index] = value; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}