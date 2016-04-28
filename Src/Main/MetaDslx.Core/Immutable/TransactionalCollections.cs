using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Collections.Transactional
{
    public enum TransactionPropagation
    {
        NestedTx,
        NewTx,
        DisableTx
    }

    public enum TransactionContexState
    {
        Commited,
        RolledBack,
        Disposing,
        Disposed
    }

    public interface ITransactionalCollection
    {
        void Apply(TxCommand command);
    }

    public enum TxCommandKind
    {
        Add,
        Remove,
        Replace,
        Clear
    }

    public abstract class TxCommand
    {
        private ITransactionalCollection target;
        private TxCommandKind kind;

        public TxCommand(ITransactionalCollection target, TxCommandKind kind)
        {
            this.target = target;
            this.kind = kind;
        }

        public ITransactionalCollection Target { get { return this.target; } }
        public TxCommandKind Kind { get { return this.kind; } }

        public void Apply()
        {
            this.target.Apply(this);
        }
    }

    public class ValueTxCommand<T> : TxCommand
    {
        private T value;

        public ValueTxCommand(ITransactionalCollection target, TxCommandKind kind, T value)
            : base(target, kind)
        {
            Debug.Assert(kind == TxCommandKind.Replace || kind == TxCommandKind.Clear);
            this.value = value;
        }

        public T Value { get { return this.value; } }
    }

    public class HashSetTxCommand<T> : TxCommand
    {
        private T item;

        public HashSetTxCommand(ITransactionalCollection target, TxCommandKind kind, T item)
            : base(target, kind)
        {
            Debug.Assert(kind == TxCommandKind.Add || kind == TxCommandKind.Remove);
            this.item = item;
        }

        public T Item { get { return this.item; } }
    }

    public class HashSetMultiTxCommand<T> : TxCommand
    {
        private HashSet<T> items;

        public HashSetMultiTxCommand(ITransactionalCollection target, TxCommandKind kind, HashSet<T> items)
            : base(target, kind)
        {
            this.items = items;
        }

        public HashSet<T> Items { get { return this.items; } }
    }

    public class ListTxCommand<T> : TxCommand
    {
        private int index;
        private T item;

        public ListTxCommand(ITransactionalCollection target, TxCommandKind kind, int index, T item)
            : base(target, kind)
        {
            Debug.Assert(index >= 0);
            this.index = index;
            this.item = item;
        }

        public int Index { get { return this.index; } }
        public T Item { get { return this.item; } }
    }

    public class ListMultiTxCommand<T> : TxCommand
    {
        private List<T> items;

        public ListMultiTxCommand(ITransactionalCollection target, TxCommandKind kind, List<T> items)
            : base(target, kind)
        {
            Debug.Assert(kind == TxCommandKind.Replace);
            this.items = items;
        }

        public List<T> Items { get { return this.items; } }
    }

    public class DictionaryTxCommand<TKey, TValue> : TxCommand
    {
        private TKey key;
        private TValue value;

        public DictionaryTxCommand(ITransactionalCollection target, TxCommandKind kind, TKey key, TValue value)
            : base(target, kind)
        {
            this.key = key;
            this.value = value;
        }

        public TKey Key { get { return this.key; } }
        public TValue Value { get { return this.value; } }
    }

    public class DictionaryMultiTxCommand<TKey, TValue> : TxCommand
    {
        private Dictionary<TKey, TValue> entries;

        public DictionaryMultiTxCommand(ITransactionalCollection target, TxCommandKind kind, Dictionary<TKey, TValue> entries)
            : base(target, kind)
        {
            Debug.Assert(kind == TxCommandKind.Replace);
            this.entries = entries;
        }

        public Dictionary<TKey, TValue> Entries { get { return this.entries; } }
    }

    public class TxValue<T> : ITransactionalCollection
    {
        private T value;

        public TxValue()
        {
        }

        public TxValue(T value)
        {
            this.value = value;
            if (CollectionTxContext.HasTransaction)
            {
                CollectionTxContext.Current.AddCommand(new ValueTxCommand<T>(this, TxCommandKind.Clear, default(T)));
            }
        }

        public void Apply(TxCommand command)
        {
            ValueTxCommand<T> cmd = command as ValueTxCommand<T>;
            if (cmd != null)
            {
                switch (cmd.Kind)
                {
                    case TxCommandKind.Replace:
                        this.value = cmd.Value;
                        break;
                    case TxCommandKind.Clear:
                        this.value = default(T);
                        break;
                    default:
                        break;
                }
            }
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (CollectionTxContext.HasTransaction)
                {
                    CollectionTxContext.Current.AddCommand(new ValueTxCommand<T>(this, TxCommandKind.Replace, this.value));
                }
                this.value = value;
            }
        }
    }

    public class TxHashSet<T> : ISet<T>, ITransactionalCollection
    {
        private HashSet<T> items;

        public TxHashSet()
        {
            this.items = new HashSet<T>();
        }

        public TxHashSet(IEnumerable<T> items)
        {
            this.items = new HashSet<T>(items);
            if (CollectionTxContext.HasTransaction)
            {
                CollectionTxContext.Current.AddCommand(new HashSetMultiTxCommand<T>(this, TxCommandKind.Clear, null));
            }
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
                        case TxCommandKind.Clear:
                            this.items.Clear();
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
            if (CollectionTxContext.HasTransaction)
            {
                if (this.items.Add(item))
                {
                    CollectionTxContext.Current.AddCommand(new HashSetTxCommand<T>(this, TxCommandKind.Remove, item));
                    return true;
                }
                return false;
            }
            else
            {
                return this.items.Add(item);
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public void Clear()
        {
            if (CollectionTxContext.HasTransaction)
            {
                if (this.items.Count > 0)
                {
                    CollectionTxContext.Current.AddCommand(new HashSetMultiTxCommand<T>(this, TxCommandKind.Replace, this.items));
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
            if (CollectionTxContext.HasTransaction)
            {
                HashSet<T> removedItems = new HashSet<T>(this.items);
                this.items.ExceptWith(other);
                removedItems.ExceptWith(this.items);
                if (removedItems.Count > 0)
                {
                    CollectionTxContext.Current.AddCommand(new HashSetMultiTxCommand<T>(this, TxCommandKind.Add, removedItems));
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
            if (CollectionTxContext.HasTransaction)
            {
                HashSet<T> removedItems = new HashSet<T>(this.items);
                this.items.IntersectWith(other);
                removedItems.ExceptWith(this.items);
                if (removedItems.Count > 0)
                {
                    CollectionTxContext.Current.AddCommand(new HashSetMultiTxCommand<T>(this, TxCommandKind.Add, removedItems));
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
            if (CollectionTxContext.HasTransaction)
            {
                if (this.items.Remove(item))
                {
                    CollectionTxContext.Current.AddCommand(new HashSetTxCommand<T>(this, TxCommandKind.Add, item));
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
            if (CollectionTxContext.HasTransaction)
            {
                HashSet<T> addedItems = new HashSet<T>(other);
                HashSet<T> removedItems = new HashSet<T>(this.items);
                addedItems.ExceptWith(this.items);
                removedItems.IntersectWith(other);
                this.items.SymmetricExceptWith(other);
                if (addedItems.Count > 0)
                {
                    CollectionTxContext.Current.AddCommand(new HashSetMultiTxCommand<T>(this, TxCommandKind.Remove, addedItems));
                }
                if (removedItems.Count > 0)
                {
                    CollectionTxContext.Current.AddCommand(new HashSetMultiTxCommand<T>(this, TxCommandKind.Add, removedItems));
                }
            }
            else
            {
                this.items.SymmetricExceptWith(other);
            }
        }

        public void UnionWith(IEnumerable<T> other)
        {
            if (CollectionTxContext.HasTransaction)
            {
                HashSet<T> addedItems = new HashSet<T>(other);
                addedItems.ExceptWith(this.items);
                this.items.UnionWith(other);
                if (addedItems.Count > 0)
                {
                    CollectionTxContext.Current.AddCommand(new HashSetMultiTxCommand<T>(this, TxCommandKind.Remove, addedItems));
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

    public class TxList<T> : IList<T>, IReadOnlyList<T>, ITransactionalCollection
    {
        private List<T> items;

        public TxList()
        {
            this.items = new List<T>();
        }

        public TxList(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
            if (CollectionTxContext.HasTransaction)
            {
                CollectionTxContext.Current.AddCommand(new ListMultiTxCommand<T>(this, TxCommandKind.Clear, null));
            }
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
                        Debug.Assert(false);
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
                        case TxCommandKind.Clear:
                            this.items.Clear();
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
                if (CollectionTxContext.HasTransaction)
                {
                    T oldValue = this.items[index];
                    this.items[index] = value;
                    CollectionTxContext.Current.AddCommand(new ListTxCommand<T>(this, TxCommandKind.Replace, index, oldValue));
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
            if (CollectionTxContext.HasTransaction)
            {
                CollectionTxContext.Current.AddCommand(new ListTxCommand<T>(this, TxCommandKind.Remove, this.items.Count - 1, item));
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public void Clear()
        {
            if (CollectionTxContext.HasTransaction)
            {
                if (this.items.Count > 0)
                {
                    CollectionTxContext.Current.AddCommand(new ListMultiTxCommand<T>(this, TxCommandKind.Replace, this.items));
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
            if (CollectionTxContext.HasTransaction)
            {
                CollectionTxContext.Current.AddCommand(new ListTxCommand<T>(this, TxCommandKind.Remove, index, item));
            }
        }

        public bool Remove(T item)
        {
            if (CollectionTxContext.HasTransaction)
            {
                int index = this.items.IndexOf(item);
                if (index >= 0)
                {
                    this.items.RemoveAt(index);
                    CollectionTxContext.Current.AddCommand(new ListTxCommand<T>(this, TxCommandKind.Add, index, item));
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
            if (CollectionTxContext.HasTransaction)
            {
                T item = this.items[index];
                this.items.RemoveAt(index);
                CollectionTxContext.Current.AddCommand(new ListTxCommand<T>(this, TxCommandKind.Add, index, item));
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

    public class TxDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, ITransactionalCollection
    {
        private Dictionary<TKey, TValue> entries;

        public TxDictionary()
        {
            this.entries = new Dictionary<TKey, TValue>();
        }

        public TxDictionary(IDictionary<TKey, TValue> dictionary)
        {
            this.entries = new Dictionary<TKey, TValue>(dictionary);
            if (CollectionTxContext.HasTransaction)
            {
                CollectionTxContext.Current.AddCommand(new DictionaryMultiTxCommand<TKey, TValue>(this, TxCommandKind.Clear, null));
            }
        }

        public TxDictionary(IDictionary<TKey, TValue> dictionary, Func<TValue, TValue> entryMap)
        {
            this.entries = new Dictionary<TKey, TValue>();
            foreach (var entry in dictionary)
            {
                this.entries.Add(entry.Key, entryMap(entry.Value));
            }
            if (CollectionTxContext.HasTransaction)
            {
                CollectionTxContext.Current.AddCommand(new DictionaryMultiTxCommand<TKey, TValue>(this, TxCommandKind.Clear, null));
            }
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
                        Debug.Assert(false);
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
                        case TxCommandKind.Clear:
                            this.entries.Clear();
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
                if (CollectionTxContext.HasTransaction)
                {
                    TValue oldValue;
                    if (this.entries.TryGetValue(key, out oldValue))
                    {
                        this.entries[key] = value;
                        CollectionTxContext.Current.AddCommand(new DictionaryTxCommand<TKey, TValue>(this, TxCommandKind.Replace, key, oldValue));
                    }
                    else
                    {
                        this.entries[key] = value;
                        CollectionTxContext.Current.AddCommand(new DictionaryTxCommand<TKey, TValue>(this, TxCommandKind.Remove, key, value));
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
            if (CollectionTxContext.HasTransaction)
            {
                CollectionTxContext.Current.AddCommand(new DictionaryTxCommand<TKey, TValue>(this, TxCommandKind.Remove, key, value));
            }
        }

        public void Clear()
        {
            if (CollectionTxContext.HasTransaction)
            {
                if (this.entries.Count > 0)
                {
                    CollectionTxContext.Current.AddCommand(new DictionaryMultiTxCommand<TKey, TValue>(this, TxCommandKind.Replace, this.entries));
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

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return ((ICollection<KeyValuePair<TKey, TValue>>)this.entries).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Remove(TKey key)
        {
            if (CollectionTxContext.HasTransaction)
            {
                TValue oldValue;
                if (this.entries.TryGetValue(key, out oldValue))
                {
                    this.entries.Remove(key);
                    CollectionTxContext.Current.AddCommand(new DictionaryTxCommand<TKey, TValue>(this, TxCommandKind.Add, key, oldValue));
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

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            return this.Remove(item.Key);
        }
    }

    public class CollectionTxContext : IDisposable
    {
        internal static DummyCollectionTxContext dummy = new DummyCollectionTxContext();
        internal static ThreadLocal<List<CollectionTxContext>> contexts = new ThreadLocal<List<CollectionTxContext>>(() => new List<CollectionTxContext>());
        private TransactionPropagation propagation;
        private TransactionContexState state;
        private List<TxCommand> commands;

        internal CollectionTxContext(TransactionPropagation propagation)
        {
            this.propagation = propagation;
            this.state = TransactionContexState.RolledBack;
            this.commands = null;
        }

        public TransactionPropagation Propagation
        {
            get { return this.propagation; }
        }

        public TransactionContexState State
        {
            get { return this.state; }
        }

        internal IReadOnlyList<TxCommand> Commands
        {
            get { return this.commands; }
        }

        public void AddCommand(TxCommand command)
        {
            if (this.propagation == TransactionPropagation.DisableTx) return;
            if (this.commands == null) this.commands = new List<TxCommand>();
            this.commands.Add(command);
        }

        public void Commit()
        {
            if (this.state == TransactionContexState.RolledBack)
            {
                this.state = TransactionContexState.Commited;
            }
        }

        public void Rollback()
        {
            if (this.state == TransactionContexState.Commited)
            {
                this.state = TransactionContexState.RolledBack;
            }
        }

        public void Dispose()
        {
            if (this.state == TransactionContexState.Disposing || this.state == TransactionContexState.Disposed) return;
            bool commit = this.state == TransactionContexState.Commited;
            bool rollback = this.state == TransactionContexState.RolledBack;
            this.state = TransactionContexState.Disposing;
            if (this.commands != null)
            {
                if (commit)
                {
                    CollectionTxContext parent = CollectionTxContext.Current;
                    if (this.Propagation == TransactionPropagation.NestedTx && parent.Propagation != TransactionPropagation.DisableTx)
                    {
                        if (this.commands.Count > 0)
                        {
                            if (parent.commands == null) parent.commands = new List<TxCommand>();
                            parent.commands.AddRange(this.commands);
                        }
                    }
                }
                else if (rollback)
                {
                    for (int i = this.commands.Count - 1; i >= 0; i--)
                    {
                        this.commands[i].Apply();
                    }
                }
                this.commands.Clear();
            }
            this.state = TransactionContexState.Disposed;
        }

        public static bool HasTransaction
        {
            get { return CollectionTxContext.contexts.Value.Count > 0; }
        }

        public static CollectionTxContext Current
        {
            get
            {
                List<CollectionTxContext> contextList = CollectionTxContext.contexts.Value;
                if (contextList.Count == 0) return CollectionTxContext.dummy;
                else return contextList[0];
            }
        }

    }

    internal class DummyCollectionTxContext : CollectionTxContext
    {
        internal DummyCollectionTxContext()
            : base(TransactionPropagation.DisableTx)
        {
        }
    }

    public class CollectionTxScope : IDisposable
    {
        private CollectionTxContext context;

        public CollectionTxScope(TransactionPropagation propagation = TransactionPropagation.NestedTx)
        {
            this.context = new CollectionTxContext(propagation);
            CollectionTxContext.contexts.Value.Insert(0, this.context);
        }

        public TransactionContexState State
        {
            get { return this.context.State; }
        }

        public void Commit()
        {
            this.context.Commit();
        }

        public void Rollback()
        {
            this.context.Rollback();
        }

        public void Dispose()
        {
            List<CollectionTxContext> contextList = CollectionTxContext.contexts.Value;
            Debug.Assert(contextList.Count > 0);
            Debug.Assert(contextList[0] == this.context); 
            contextList.RemoveAt(0);
            context.Dispose();
        }
    }
}
