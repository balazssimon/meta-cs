using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    interface ITxCollection
    {
        void Apply(TxCommand command);
    }

    internal enum TxCommandKind
    {
        Add,
        Remove,
        Replace
    }

    internal abstract class TxCommand
    {
        private ITxCollection collection;
        private TxCommandKind kind;

        public TxCommand(ITxCollection collection, TxCommandKind kind)
        {
            this.collection = collection;
            this.kind = kind;
        }

        public ITxCollection Collection { get { return this.collection; } }
        public TxCommandKind Kind { get { return this.kind; } }

        public void Apply()
        {
            this.collection.Apply(this);
        }
    }

    internal class HashSetTxCommand<T> : TxCommand
    {
        private T item;

        public HashSetTxCommand(ITxCollection collection, TxCommandKind kind, T item)
            : base(collection, kind)
        {
            Debug.Assert(kind == TxCommandKind.Add || kind == TxCommandKind.Remove);
            this.item = item;
        }

        public T Item { get { return this.item; } }
    }

    internal class HashSetMultiTxCommand<T> : TxCommand
    {
        private HashSet<T> items;

        public HashSetMultiTxCommand(ITxCollection collection, TxCommandKind kind, HashSet<T> items)
            : base(collection, kind)
        {
            this.items = items;
        }

        public HashSet<T> Items { get { return this.items; } }
    }

    internal class ListTxCommand<T> : TxCommand
    {
        private int index;
        private T item;

        public ListTxCommand(ITxCollection collection, TxCommandKind kind, int index, T item)
            : base(collection, kind)
        {
            Debug.Assert(index >= 0);
            this.index = index;
            this.item = item;
        }

        public int Index { get { return this.index; } }
        public T Item { get { return this.item; } }
    }

    internal class ListMultiTxCommand<T> : TxCommand
    {
        private List<T> items;

        public ListMultiTxCommand(ITxCollection collection, TxCommandKind kind, List<T> items)
            : base(collection, kind)
        {
            Debug.Assert(kind == TxCommandKind.Replace);
            this.items = items;
        }

        public List<T> Items { get { return this.items; } }
    }

    internal class DictionaryTxCommand<TKey, TValue> : TxCommand
    {
        private TKey key;
        private TValue value;

        public DictionaryTxCommand(ITxCollection collection, TxCommandKind kind, TKey key, TValue value)
            : base(collection, kind)
        {
            this.key = key;
            this.value = value;
        }

        public TKey Key { get { return this.key; } }
        public TValue Value { get { return this.value; } }
    }

    internal class DictionaryMultiTxCommand<TKey, TValue> : TxCommand
    {
        private Dictionary<TKey, TValue> entries;

        public DictionaryMultiTxCommand(ITxCollection collection, TxCommandKind kind, Dictionary<TKey, TValue> entries)
            : base(collection, kind)
        {
            Debug.Assert(kind == TxCommandKind.Replace);
            this.entries = entries;
        }

        public Dictionary<TKey, TValue> Entries { get { return this.entries; } }
    }

    internal class TxHashSet<T> : ISet<T>, ITxCollection
    {
        private HashSet<T> items;

        public TxHashSet()
        {
            this.items = new HashSet<T>();
        }

        public void Apply(TxCommand command)
        {
            HashSetTxCommand<T> cmd = command as HashSetTxCommand<T>;
            if (cmd != null)
            {
                switch (cmd.Kind)
                {
                    case TxCommandKind.Add:
                        this.items.Add(cmd.Item);
                        break;
                    case TxCommandKind.Remove:
                        this.items.Remove(cmd.Item);
                        break;
                    case TxCommandKind.Replace:
                        Debug.Assert(false);
                        break;
                    default:
                        Debug.Assert(false);
                        break;
                }
            }
            else
            {
                HashSetMultiTxCommand<T> mcmd = command as HashSetMultiTxCommand<T>;
                if (mcmd != null)
                {
                    switch (mcmd.Kind)
                    {
                        case TxCommandKind.Add:
                            this.items.UnionWith(mcmd.Items);
                            break;
                        case TxCommandKind.Remove:
                            this.items.ExceptWith(mcmd.Items);
                            break;
                        case TxCommandKind.Replace:
                            Interlocked.Exchange(ref this.items, mcmd.Items);
                            break;
                        default:
                            Debug.Assert(false);
                            break;
                    }
                }
                else
                {
                    Debug.Assert(false);
                }
            }
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Add(T item)
        {
            if (CollectionTxScope.HasTransaction)
            {
                if (this.items.Add(item))
                {
                    CollectionTxScope.Current.AddCommand(new HashSetTxCommand<T>(this, TxCommandKind.Remove, item));
                    return true;
                }
                return false;
            }
            else
            {
                return this.items.Add(item);
            }
        }

        public void Clear()
        {
            if (CollectionTxScope.HasTransaction)
            {
                if (this.items.Count > 0)
                {
                    CollectionTxScope.Current.AddCommand(new HashSetMultiTxCommand<T>(this, TxCommandKind.Replace, this.items));
                    Interlocked.Exchange(ref this.items, new HashSet<T>());
                }
            }
            else
            {
                this.items.Clear();
            }
        }

        public bool Contains(T item)
        {
            return this.items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            if (CollectionTxScope.HasTransaction)
            {
                HashSet<T> removedItems = new HashSet<T>(this.items);
                this.items.ExceptWith(other);
                removedItems.ExceptWith(this.items);
                if (removedItems.Count > 0)
                {
                    CollectionTxScope.Current.AddCommand(new HashSetMultiTxCommand<T>(this, TxCommandKind.Add, removedItems));
                }
            }
            else
            {
                this.items.ExceptWith(other);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            if (CollectionTxScope.HasTransaction)
            {
                HashSet<T> removedItems = new HashSet<T>(this.items);
                this.items.IntersectWith(other);
                removedItems.ExceptWith(this.items);
                if (removedItems.Count > 0)
                {
                    CollectionTxScope.Current.AddCommand(new HashSetMultiTxCommand<T>(this, TxCommandKind.Add, removedItems));
                }
            }
            else
            {
                this.items.IntersectWith(other);
            }
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return this.items.IsProperSubsetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return this.items.IsProperSupersetOf(other);
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            return this.items.IsSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            return this.items.IsSupersetOf(other);
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            return this.items.Overlaps(other);
        }

        public bool Remove(T item)
        {
            if (CollectionTxScope.HasTransaction)
            {
                if (this.items.Remove(item))
                {
                    CollectionTxScope.Current.AddCommand(new HashSetTxCommand<T>(this, TxCommandKind.Add, item));
                    return true;
                }
                return false;
            }
            else
            {
                return this.items.Remove(item);
            }
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            return this.items.SetEquals(other);
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (CollectionTxScope.HasTransaction)
            {
                HashSet<T> addedItems = new HashSet<T>(other);
                HashSet<T> removedItems = new HashSet<T>(this.items);
                addedItems.ExceptWith(this.items);
                removedItems.IntersectWith(other);
                this.items.SymmetricExceptWith(other);
                if (addedItems.Count > 0)
                {
                    CollectionTxScope.Current.AddCommand(new HashSetMultiTxCommand<T>(this, TxCommandKind.Remove, addedItems));
                }
                if (removedItems.Count > 0)
                {
                    CollectionTxScope.Current.AddCommand(new HashSetMultiTxCommand<T>(this, TxCommandKind.Add, removedItems));
                }
            }
            else
            {
                this.items.SymmetricExceptWith(other);
            }
        }

        public void UnionWith(IEnumerable<T> other)
        {
            if (CollectionTxScope.HasTransaction)
            {
                HashSet<T> addedItems = new HashSet<T>(other);
                addedItems.ExceptWith(this.items);
                this.items.UnionWith(other);
                if (addedItems.Count > 0)
                {
                    CollectionTxScope.Current.AddCommand(new HashSetMultiTxCommand<T>(this, TxCommandKind.Remove, addedItems));
                }
            }
            else
            {
                this.items.UnionWith(other);
            }
        }

        void ICollection<T>.Add(T item)
        {
            this.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    internal class TxList<T> : IList<T>, ITxCollection
    {
        private List<T> items;

        public TxList()
        {
            this.items = new List<T>();
        }

        public void Apply(TxCommand command)
        {
            ListTxCommand<T> cmd = command as ListTxCommand<T>;
            if (cmd != null)
            {
                switch (cmd.Kind)
                {
                    case TxCommandKind.Add:
                        Debug.Assert(cmd.Index >= 0 && cmd.Index <= this.items.Count);
                        this.items.Insert(cmd.Index, cmd.Item);
                        break;
                    case TxCommandKind.Remove:
                        Debug.Assert(cmd.Index >= 0 && cmd.Index < this.items.Count);
                        this.items.RemoveAt(cmd.Index);
                        break;
                    case TxCommandKind.Replace:
                        Debug.Assert(cmd.Index >= 0 && cmd.Index < this.items.Count);
                        this.items[cmd.Index] = cmd.Item;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                ListMultiTxCommand<T> mcmd = command as ListMultiTxCommand<T>;
                if (mcmd != null)
                {
                    switch (mcmd.Kind)
                    {
                        case TxCommandKind.Replace:
                            Interlocked.Exchange(ref this.items, mcmd.Items);
                            break;
                        default:
                            Debug.Assert(false);
                            break;
                    }
                }
                else
                {
                    Debug.Assert(false);
                }
            }
        }

        public T this[int index]
        {
            get
            {
                return this.items[index];
            }
            set
            {
                if (CollectionTxScope.HasTransaction)
                {
                    T oldValue = this.items[index];
                    this.items[index] = value;
                    CollectionTxScope.Current.AddCommand(new ListTxCommand<T>(this, TxCommandKind.Replace, index, oldValue));
                }
                else
                {
                    this.items[index] = value;
                }
            }
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            this.items.Add(item);
            if (CollectionTxScope.HasTransaction)
            {
                CollectionTxScope.Current.AddCommand(new ListTxCommand<T>(this, TxCommandKind.Remove, this.items.Count - 1, item));
            }
        }

        public void Clear()
        {
            if (CollectionTxScope.HasTransaction)
            {
                if (this.items.Count > 0)
                {
                    CollectionTxScope.Current.AddCommand(new ListMultiTxCommand<T>(this, TxCommandKind.Replace, this.items));
                    Interlocked.Exchange(ref this.items, new List<T>());
                }
            }
            else
            {
                this.items.Clear();
            }
        }

        public bool Contains(T item)
        {
            return this.items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return this.items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.items.Insert(index, item);
            if (CollectionTxScope.HasTransaction)
            {
                CollectionTxScope.Current.AddCommand(new ListTxCommand<T>(this, TxCommandKind.Remove, index, item));
            }
        }

        public bool Remove(T item)
        {
            if (CollectionTxScope.HasTransaction)
            {
                int index = this.items.IndexOf(item);
                if (index >= 0)
                {
                    this.items.RemoveAt(index);
                    CollectionTxScope.Current.AddCommand(new ListTxCommand<T>(this, TxCommandKind.Add, index, item));
                    return true;
                }
                return false;
            }
            else
            {
                return this.items.Remove(item);
            }
        }

        public void RemoveAt(int index)
        {
            if (CollectionTxScope.HasTransaction)
            {
                T item = this.items[index];
                this.items.RemoveAt(index);
                CollectionTxScope.Current.AddCommand(new ListTxCommand<T>(this, TxCommandKind.Add, index, item));
            }
            else
            {
                this.items.RemoveAt(index);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    internal class TxDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, ITxCollection
    {
        private Dictionary<TKey, TValue> entries;

        public TxDictionary()
        {
            this.entries = new Dictionary<TKey, TValue>();
        }

        public void Apply(TxCommand command)
        {
            DictionaryTxCommand<TKey, TValue> cmd = command as DictionaryTxCommand<TKey, TValue>;
            if (cmd != null)
            {
                switch (cmd.Kind)
                {
                    case TxCommandKind.Add:
                        this.entries.Add(cmd.Key, cmd.Value);
                        break;
                    case TxCommandKind.Remove:
                        this.entries.Remove(cmd.Key);
                        break;
                    case TxCommandKind.Replace:
                        this.entries[cmd.Key] = cmd.Value;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                DictionaryMultiTxCommand<TKey, TValue> mcmd = command as DictionaryMultiTxCommand<TKey, TValue>;
                if (mcmd != null)
                {
                    switch (mcmd.Kind)
                    {
                        case TxCommandKind.Replace:
                            Interlocked.Exchange(ref this.entries, mcmd.Entries);
                            break;
                        default:
                            Debug.Assert(false);
                            break;
                    }
                }
                else
                {
                    Debug.Assert(false);
                }
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.entries[key];
            }
            set
            {
                if (CollectionTxScope.HasTransaction)
                {
                    TValue oldValue;
                    if (this.entries.TryGetValue(key, out oldValue))
                    {
                        this.entries[key] = value;
                        CollectionTxScope.Current.AddCommand(new DictionaryTxCommand<TKey, TValue>(this, TxCommandKind.Replace, key, oldValue));
                    }
                    else
                    {
                        this.entries[key] = value;
                        CollectionTxScope.Current.AddCommand(new DictionaryTxCommand<TKey, TValue>(this, TxCommandKind.Remove, key, value));
                    }
                }
                else
                {
                    this.entries[key] = value;
                }
            }
        }

        public int Count
        {
            get
            {
                return this.entries.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                return this.entries.Keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                return this.entries.Values;
            }
        }

        public void Add(TKey key, TValue value)
        {
            this.entries.Add(key, value);
            if (CollectionTxScope.HasTransaction)
            {
                CollectionTxScope.Current.AddCommand(new DictionaryTxCommand<TKey, TValue>(this, TxCommandKind.Remove, key, value));
            }
        }

        public void Clear()
        {
            if (CollectionTxScope.HasTransaction)
            {
                if (this.entries.Count > 0)
                {
                    CollectionTxScope.Current.AddCommand(new DictionaryMultiTxCommand<TKey, TValue>(this, TxCommandKind.Replace, this.entries));
                    Interlocked.Exchange(ref this.entries, new Dictionary<TKey, TValue>());
                }
            }
            else
            {
                this.entries.Clear();
            }
        }

        public bool ContainsKey(TKey key)
        {
            return this.entries.ContainsKey(key);
        }

        public IEnumerator GetEnumerator()
        {
            return this.entries.GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            if (CollectionTxScope.HasTransaction)
            {
                TValue oldValue;
                if (this.entries.TryGetValue(key, out oldValue))
                {
                    this.entries.Remove(key);
                    CollectionTxScope.Current.AddCommand(new DictionaryTxCommand<TKey, TValue>(this, TxCommandKind.Add, key, oldValue));
                    return true;
                }
                return false;
            }
            else
            {
                return this.entries.Remove(key);
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return this.entries.TryGetValue(key, out value);
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            this.Add(item.Key, item.Value);
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            return ((ICollection<KeyValuePair<TKey, TValue>>)this.entries).Contains(item);
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>)this.entries).CopyTo(array, arrayIndex);
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return ((ICollection<KeyValuePair<TKey, TValue>>)this.entries).GetEnumerator();
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            return this.Remove(item.Key);
        }
    }

    internal enum TxContextState
    {
        Commited,
        RolledBack,
        Disposing,
        Disposed
    }


    internal class CollectionTxContext : IDisposable
    {
        private TxContextState state;
        private List<TxCommand> commands;

        public CollectionTxContext()
        {
            this.state = TxContextState.RolledBack;
            this.commands = null;
        }

        public virtual void AddCommand(TxCommand command)
        {
            if (this.commands == null) this.commands = new List<TxCommand>();
            this.commands.Add(command);
        }

        public void Commit()
        {
            if (this.state == TxContextState.RolledBack)
            {
                this.state = TxContextState.Commited;
            }
        }

        public void Rollback()
        {
            if (this.state == TxContextState.Commited)
            {
                this.state = TxContextState.RolledBack;
            }
        }

        public void Dispose()
        {
            if (this.state == TxContextState.Disposing || this.state == TxContextState.Disposed) return;
            bool rollback = this.state == TxContextState.RolledBack;
            this.state = TxContextState.Disposing;
            if (rollback)
            {
                for (int i = this.commands.Count - 1; i >= 0; i--)
                {
                    this.commands[i].Apply();
                }
            }
            this.state = TxContextState.Disposed;
        }
    }

    internal class DummyCollectionTxContext : CollectionTxContext
    {
        public override void AddCommand(TxCommand command)
        {
            return;
        }
    }

    internal class CollectionTxScope : IDisposable
    {
        private static DummyCollectionTxContext dummy = new DummyCollectionTxContext();
        private static ThreadLocal<List<CollectionTxContext>> contexts = new ThreadLocal<List<CollectionTxContext>>(() => new List<CollectionTxContext>());

        public CollectionTxScope()
        {
            CollectionTxScope.contexts.Value.Insert(0, new CollectionTxContext());
        }

        public static bool HasTransaction
        {
            get { return CollectionTxScope.contexts.Value.Count > 0; }
        }

        public static CollectionTxContext Current
        {
            get
            {
                List<CollectionTxContext> contextList = CollectionTxScope.contexts.Value;
                if (contextList.Count == 0) return CollectionTxScope.dummy;
                else return contextList[0];
            }
        }

        public void Commit()
        {
            CollectionTxScope.Current.Commit();
        }

        public void Rollback()
        {
            CollectionTxScope.Current.Rollback();
        }

        public void Dispose()
        {
            List<CollectionTxContext> contextList = CollectionTxScope.contexts.Value;
            Debug.Assert(contextList.Count > 0);
            CollectionTxContext context = contextList[0];
            contextList.RemoveAt(0);
            context.Dispose();
        }
    }
}
