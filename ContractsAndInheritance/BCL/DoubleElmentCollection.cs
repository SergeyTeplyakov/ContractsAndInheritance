using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ContractsAndInheritance.BCL
{
    public class DoubleElementCollection : ICollection<string>
    {
        private readonly List<string> _backingList = new List<string>();

        public void Add(string item)
        {

            // Вместо добавления элемент один раз, добавляем его 2 раза
            _backingList.Add(item);
            _backingList.Add(item);
        }

        // Остальные методы не важны
        #region Implementation of ICollection<T>

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
            get { return ((ICollection<string>)_backingList).IsReadOnly; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}