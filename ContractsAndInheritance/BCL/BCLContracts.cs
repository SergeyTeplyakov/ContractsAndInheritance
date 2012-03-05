using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace ContractsAndInheritance.BCL
{
    /*
// From mscorlib.Contracts.dll
[ContractClassFor(typeof(ICollection<>))]
internal abstract class ICollectionContract<T> : ICollection<T>, IEnumerable<T>, IEnumerable
{
    public void Add([MarshalAs(UnmanagedType.Error)] T item)
    {
        Contract.Ensures(this.Count >= Contract.OldValue<int>(this.Count), "this.Count >= Contract.OldValue(this.Count)");
    }

    public void Clear()
    {
        Contract.Ensures(this.Count == 0, "this.Count == 0");
    }

    public int Count
    {
        get
        {
            int num = 0;
            Contract.Ensures(Contract.Result<int>() >= 0, "Contract.Result<int>() >= 0");
            return num;
        }
    }
}

// From mscorlib.Contracts.dll
[ContractClassFor(typeof (IList<>))]
internal abstract class IListContract<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
{
    void ICollection<T>.Add([MarshalAs(UnmanagedType.Error)] T item)
    {
        Contract.Ensures(this.Count == (Contract.OldValue<int>(this.Count) + 1), "Count == Contract.OldValue(Count) + 1");
    }

    public int Count
    {
        get
        {
            int num = 0;
            return num;
        }
    }
}
    */
}