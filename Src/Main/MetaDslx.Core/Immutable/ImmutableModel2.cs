using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable2
{
    public delegate object LazyValueDelegate(ISymbol context);

    internal enum LazyEvaluationState
    {
        Initialized,
        Evaluating,
        Evaluated
    }

    internal enum ListEvaluationState
    {
        Initialized,
        EvaluatingLazy,
        EvaluatingProperties,
        Evaluated
    }

    internal class LazyEvalInfo : IEquatable<LazyEvalInfo>
    {
        private static ThreadLocal<List<LazyEvalInfo>> evalInfoStack = new ThreadLocal<List<LazyEvalInfo>>(() => new List<LazyEvalInfo>());
        private ISymbol symbol;
        private ModelProperty property;
        private object lazyEvaluator;

        private LazyEvalInfo(ISymbol symbol, ModelProperty property, object lazyEvaluator)
        {
            this.symbol = symbol;
            this.property = property;
            this.lazyEvaluator = lazyEvaluator;
        }

        public override bool Equals(object obj)
        {
            if (obj is LazyEvalInfo)
            {
                return this.Equals((LazyEvalInfo)obj);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.symbol.GetHashCode() ^ this.lazyEvaluator.GetHashCode();
        }

        public bool Equals(LazyEvalInfo other)
        {
            return this.symbol == other.symbol && this.lazyEvaluator == other.lazyEvaluator;
        }

        public static LazyEvalInfo Push(ISymbol symbol, ModelProperty property, object lazyEvaluator)
        {
            LazyEvalInfo info = new LazyEvalInfo(symbol, property, lazyEvaluator);
            if (evalInfoStack.Value.Contains(info))
            {
                throw new ModelException("Circular dependency in lazy evaluation.");
            }
            evalInfoStack.Value.Add(info);
            return info;
        }

        public static void Pop(LazyEvalInfo info)
        {
            Debug.Assert(evalInfoStack.Value.Count > 0);
            Debug.Assert(evalInfoStack.Value[evalInfoStack.Value.Count - 1] == info);
            evalInfoStack.Value.RemoveAt(evalInfoStack.Value.Count - 1);
        }
    }

    internal class LazyValue
    {
        private LazyEvaluationState state;
        private LazyValueDelegate calculate;
        private object value;

        public LazyValue(LazyValueDelegate calculate)
        {
            this.state = LazyEvaluationState.Initialized;
            this.calculate = calculate;
        }

        public bool IsValueCreated
        {
            get { return this.state == LazyEvaluationState.Evaluated; }
        }

        public object CachedValue
        {
            get { return this.state == LazyEvaluationState.Evaluated ? value : null; }
        }

        public object GetValue(ISymbol context, ModelProperty property)
        {
            LazyEvalInfo evalInfo = null;
            lock (this)
            {
                if (this.state == LazyEvaluationState.Evaluated)
                {
                    return this.value;
                }
                else if (this.state == LazyEvaluationState.Evaluating)
                {
                    return null;
                }
                else
                {
                    this.state = LazyEvaluationState.Evaluating;
                }
            }
            evalInfo = LazyEvalInfo.Push(context, property, this);
            try
            {
                Interlocked.CompareExchange(ref this.value, calculate(context), null);
            }
            finally
            {
                LazyEvalInfo.Pop(evalInfo);
            }
            lock(this)
            {
                this.state = LazyEvaluationState.Evaluated;
            }
            return this.value;
        }
    }

    public interface ISymbol
    {
        object GetValue(ModelProperty property);
    }

    public interface IImmutableSymbol : ISymbol
    {

    }

    public interface IMutableSymbol : ISymbol
    {
        void SetValue(ModelProperty property, object value);
        void SetValueLazy(ModelProperty property, LazyValueDelegate value);
        bool AddValue(ModelProperty property, object value);
        bool AddValueLazy(ModelProperty property, LazyValueDelegate value);
        bool RemoveValue(ModelProperty property, object value);
    }

    public abstract class GreenSymbol
    {
        public GreenSymbol()
        {
        }

        public abstract RedSymbol CreateRed(RedModel model);
    }

    public interface IGreenList : IReadOnlyList<object>
    {
        bool Add(object item);
        bool Remove(object item);
        bool HasLazyItems { get; }
    }

    public class GreenList : IGreenList
    {
        private int lazyEvaluatorCount = 0;
        private List<object> items = new List<object>();

        public int Count
        {
            get { return this.items.Count; }
        }

        public bool HasLazyItems
        {
            get { return this.lazyEvaluatorCount > 0; }
        }

        public object this[int index]
        {
            get { return this.items[index]; }
        }

        public bool Add(object item)
        {
            if (this.items.Contains(item)) return false;
            this.items.Add(item);
            if (item is LazyValue) ++this.lazyEvaluatorCount;
            return true;
        }

        public bool Remove(object item)
        {
            if (!this.items.Contains(item)) return false;
            this.items.Remove(item);
            if (item is LazyValue) --this.lazyEvaluatorCount;
            return true;
        }

        public IEnumerator<object> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class GreenMultiList : IGreenList
    {
        private int lazyEvaluatorCount = 0;
        private List<object> items = new List<object>();

        public int Count
        {
            get { return this.items.Count; }
        }

        public bool HasLazyItems
        {
            get { return this.lazyEvaluatorCount > 0; }
        }

        public object this[int index]
        {
            get { return this.items[index]; }
        }

        public bool Add(object item)
        {
            this.items.Add(item);
            if (item is LazyValue) ++this.lazyEvaluatorCount;
            return true;
        }

        public bool Remove(object item)
        {
            if (!this.items.Contains(item)) return false;
            this.items.Remove(item);
            if (item is LazyValue) --this.lazyEvaluatorCount;
            return true;
        }

        public bool RemoveAll(object item)
        {
            int removedCount = this.items.RemoveAll(i => i == item);
            if (item is LazyValue)
            {
                this.lazyEvaluatorCount -= removedCount;
            }
            return removedCount > 0;
        }

        public IEnumerator<object> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class RedList : IReadOnlyList<object>
    {
        private ListEvaluationState state;
        private RedSymbol parent;
        private ModelProperty property;
        private IGreenList greenList;
        private List<object> redItems;

        public RedList(RedSymbol parent, ModelProperty property, IGreenList greenList)
        {
            this.parent = parent;
            this.property = property;
            this.greenList = greenList;
            this.state = ListEvaluationState.Initialized;
        }

        public RedSymbol Parent { get { return this.parent; } }

        public ModelProperty Property { get { return this.property; } }

        private void Add(object item)
        {
            lock (this.redItems)
            {
                if (this.greenList is GreenList)
                {
                    if (!this.redItems.Contains(item))
                    {
                        this.redItems.Add(item);
                    }
                }
                else
                {
                    this.redItems.Add(item);
                }
            }
        }

        internal void InternalAddItem(object item)
        {
            this.EvaluateLazyItems();
            this.Add(item);
        }

        public object this[int index]
        {
            get
            {
                if (this.state == ListEvaluationState.Evaluated) return this.redItems[index];
                this.Evaluate();
                return this.redItems[index];
            }
        }

        public int Count
        {
            get
            {
                if (this.state == ListEvaluationState.Evaluated) return this.redItems.Count;
                this.Evaluate();
                return this.redItems.Count;
            }
        }

        public IEnumerator<object> GetEnumerator()
        {
            if (this.state == ListEvaluationState.Evaluated) return this.redItems.GetEnumerator();
            this.Evaluate();
            return this.redItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal void Evaluate()
        {
            if (this.state == ListEvaluationState.Evaluated) return;
            this.EvaluateLazyItems();
            lock(this)
            {
                this.state = ListEvaluationState.EvaluatingProperties;
            }
            this.parent.Model.EvaluateRelatedProperties(this.property);
            lock (this)
            {
                this.state = ListEvaluationState.Evaluated;
            }
        }

        internal void EvaluateLazyItems()
        {
            if (this.state == ListEvaluationState.Evaluated) return;
            if (this.state == ListEvaluationState.EvaluatingProperties) return;
            lock (this)
            {
                if (this.state == ListEvaluationState.Initialized)
                {
                    if (this.greenList.HasLazyItems)
                    {
                        this.state = ListEvaluationState.EvaluatingLazy;
                    }
                    else
                    {
                        this.state = ListEvaluationState.EvaluatingProperties;
                        return;
                    }
                }
                else if (this.state == ListEvaluationState.EvaluatingLazy)
                {
                    throw new ModelException("Circular lazy reference in lists.");
                }
                else
                {
                    return;
                }
            }
            for (int i = 0, n = this.greenList.Count; i < n; i++)
            {
                object value = this.parent.Model.GetListItemValue(this, this.greenList[i]);
                this.Add(value);
            }
        }
    }

    public class RedSymbol : IImmutableSymbol
    {
        private RedModel model;
        private GreenSymbol green;
        private Dictionary<ModelProperty, object> values;

        public RedSymbol(GreenSymbol green, RedModel model)
        {
            this.green = green;
            this.model = model;
            this.values = new Dictionary<ModelProperty, object>();
        }

        public RedModel Model { get { return this.model; } }
        public GreenSymbol Green { get { return this.green; } }

        public object GetValue(ModelProperty property)
        {
            object result = null;
            lock(this.values)
            {
                if (this.values.TryGetValue(property, out result)) return result;
            }
            result = this.model.GetValue(this.green, property);
            lock (this.values)
            {
                this.values.Add(property, result);
                return result;
            }
        }
    }

    public class GreenModelPart
    {
        private object id;
        private Dictionary<GreenSymbol, Dictionary<ModelProperty, object>> symbols = new Dictionary<GreenSymbol, Dictionary<ModelProperty, object>>();

        public GreenModelPart()
        {
            this.id = new object();
        }

        public GreenModelPart(object id)
        {
            this.id = id;
        }

        public object Id { get { return this.id; } }
        internal Dictionary<GreenSymbol, Dictionary<ModelProperty, object>> Symbols { get { return this.symbols; } }

        public bool ContainsSymbol(GreenSymbol symbol)
        {
            return this.symbols.ContainsKey(symbol);
        }

        public bool TryGetValue(GreenSymbol symbol, ModelProperty property, out object value)
        {
            Dictionary<ModelProperty, object> properties = null;
            if (this.symbols.TryGetValue(symbol, out properties))
            {
                if (properties.TryGetValue(property, out value))
                {
                    return true;
                }
            }
            value = null;
            return false;
        }
    }

    public class GreenModel
    {
        internal Dictionary<object, GreenModelPart> parts = new Dictionary<object, GreenModelPart>();

        internal GreenModel(GreenModelPart part)
        {
            this.parts.Add(part.Id, part);
        }

        internal GreenModel(GreenModel oldModel, GreenModelPart part)
        {
            this.parts = oldModel.parts.ToDictionary(entry => entry.Key, entry => entry.Value);
            this.parts[part.Id] = part;
        }

        internal GreenModel(GreenModel oldModel, IEnumerable<GreenModelPart> parts)
        {
            this.parts = oldModel.parts.ToDictionary(entry => entry.Key, entry => entry.Value);
            foreach (var part in parts)
            {
                this.parts[part.Id] = part;
            }
        }

        public GreenModel WithPart(GreenModelPart part)
        {
            GreenModelPart oldModel = null;
            if (this.parts.TryGetValue(part.Id, out oldModel))
            {
                if (part == oldModel) return this;
            }
            return new GreenModel(this, part);
        }

        public GreenModel WithParts(IEnumerable<GreenModelPart> parts)
        {
            List<GreenModelPart> changedParts = new List<GreenModelPart>();
            foreach (var part in parts)
            {
                GreenModelPart oldModel = null;
                if (this.parts.TryGetValue(part.Id, out oldModel))
                {
                    if (part != oldModel)
                    {
                        changedParts.Add(part);
                    }
                }
            }
            if (changedParts.Count == 0) return this;
            else return new GreenModel(this, changedParts);
        }

        public IEnumerable<GreenModelPart> Parts
        {
            get { return this.parts.Values; }
        }

        public List<object> GetValue(GreenSymbol symbol, ModelProperty property)
        {
            List<object> result = new List<object>();
            foreach (var part in this.parts.Values)
            {
                object value;
                if (part.TryGetValue(symbol, property, out value))
                {
                    if (!result.Contains(value))
                    {
                        result.Add(value);
                    }
                }
            }
            return result;
        }

        public ModelBuilder Builder()
        {
            return new ModelBuilder(this);
        }
    }

    public class RedModel
    {
        private GreenModel green;
        private Dictionary<GreenSymbol, RedSymbol> symbols = new Dictionary<GreenSymbol, RedSymbol>();
        private HashSet<ModelProperty> evaluatingProps = new HashSet<ModelProperty>();
        private HashSet<ModelProperty> evaluatedProps = new HashSet<ModelProperty>();

        public RedModel(GreenModel green)
        {
            this.green = green;
        }

        public GreenModel Green { get { return this.green; } }

        internal RedSymbol GetRedSymbol(GreenSymbol symbol)
        {
            RedSymbol result = null;
            lock (this.symbols)
            {
                if (!this.symbols.TryGetValue(symbol, out result))
                {
                    result = symbol.CreateRed(this);
                    if (result != null)
                    {
                        this.symbols.Add(symbol, result);
                    }
                }
            }
            return result;
        }

        public object GetListItemValue(RedList list, object greenValue)
        {
            if (greenValue is GreenSymbol)
            {
                return this.GetRedSymbol((GreenSymbol)greenValue);
            }
            else if (greenValue is LazyValue)
            {
                return ((LazyValue)greenValue).GetValue(list.Parent, list.Property);
            }
            else
            {
                return greenValue;
            }
        }

        public object GetValue(GreenSymbol symbol, ModelProperty property)
        {
            List<object> greenValues = this.green.GetValue(symbol, property);
            if (greenValues.Count == 0) return null;
            if (greenValues.Count == 1)
            {
                object greenValue = greenValues[0];
                if (greenValue is GreenSymbol)
                {
                    return this.GetRedSymbol((GreenSymbol)greenValue);
                }
                else if (greenValue is IGreenList)
                {
                    RedSymbol red = this.GetRedSymbol(symbol);
                    Debug.Assert(red != null);
                    return new RedList(red, property, (IGreenList)greenValue);
                }
                else if (greenValue is LazyValue)
                {
                    RedSymbol red = this.GetRedSymbol(symbol);
                    Debug.Assert(red != null);
                    return ((LazyValue)greenValue).GetValue(red, property);
                }
                else
                {
                    return greenValue;
                }
            }
            else if (property.IsCollection)
            {
                RedSymbol red = this.GetRedSymbol(symbol);
                Debug.Assert(red != null);
                bool multi = greenValues[0] is GreenMultiList;
                IGreenList values = null;
                if (multi) values = new GreenList();
                else values = new GreenMultiList();
                // TODO: lazy list initializers
                foreach (var greenValue in greenValues)
                {
                    if (!multi && greenValue is GreenList)
                    {
                        foreach (var value in ((GreenList)greenValue))
                        {
                            values.Add(value);
                        }
                    }
                    else if (multi && greenValue is GreenMultiList)
                    {
                        foreach (var value in ((GreenMultiList)greenValue))
                        {
                            values.Add(value);
                        }
                    }
                    else
                    {
                        throw new ModelException("Invalid property value type. It should be " + (multi ? typeof(GreenMultiList).Name : typeof(GreenList).Name) + ".");
                    }
                }
                return new RedList(red, property, values);
            }
            else
            {
                throw new ModelException("Conflicting values.");
            }
        }

        internal void EvaluateProperty(ModelProperty property)
        {
            lock(this)
            {
                if (this.evaluatedProps.Contains(property)) return;
                if (this.evaluatingProps.Contains(property)) return;
                this.evaluatingProps.Add(property);
            }
            foreach (var greenModelPart in this.green.Parts)
            {
                foreach (var greenEntry in greenModelPart.Symbols)
                {
                    object value;
                    if (greenEntry.Value.TryGetValue(property, out value))
                    {
                        if (value is LazyValue)
                        {
                            RedSymbol redSymbol = this.GetRedSymbol(greenEntry.Key);
                            Debug.Assert(redSymbol != null);
                            redSymbol.GetValue(property);
                        }
                        else if (value is IGreenList)
                        {
                            if (((IGreenList)value).HasLazyItems)
                            {
                                RedSymbol redSymbol = this.GetRedSymbol(greenEntry.Key);
                                Debug.Assert(redSymbol != null);
                                RedList redList = redSymbol.GetValue(property) as RedList;
                                Debug.Assert(redList != null);
                                redList.EvaluateLazyItems();
                            }
                        }
                    }
                }
            }
            lock (this)
            {
                this.evaluatingProps.Remove(property);
                this.evaluatedProps.Add(property);
            }
            this.EvaluateRelatedProperties(property);
        }

        internal void EvaluateRelatedProperties(ModelProperty property)
        {
            foreach (var prop in property.OppositeProperties)
            {
                this.EvaluateProperty(prop);
            }
            foreach (var prop in property.SubsettedProperties)
            {
                this.EvaluateProperty(prop);
            }
            foreach (var prop in property.RedefinedProperties)
            {
                this.EvaluateProperty(prop);
            }
            foreach (var prop in property.SubsettingProperties)
            {
                this.EvaluateProperty(prop);
            }
            foreach (var prop in property.RedefiningProperties)
            {
                this.EvaluateProperty(prop);
            }
        }

        public ModelBuilder Builder()
        {
            return this.green.Builder();
        }
    }

    public class ObjectBuilder
    {
        private ModelBuilder model;
        private GreenModelPart part;
        private GreenSymbol target;

        public ObjectBuilder(ModelBuilder model, GreenModelPart part, GreenSymbol target)
        {
            this.model = model;
            this.part = part;
            this.target = target;
        }

        public void AddValue(ModelProperty property, object value)
        {
            this.model.AddValue(this.part, this.target, property, value);
        }

        public void RemoveValue(ModelProperty property, object value)
        {
            this.model.RemoveValue(this.part, this.target, property, value);
        }
    }

    public class ModelBuilder
    {
        private GreenModel model;
        private ModelTransactionCommand transaction;
        private ModelTransactionCommand currentTransaction;

        internal protected ModelBuilder(GreenModel model)
        {
            this.model = model;
        }

        public RedModel ToImmutable()
        {
            return new RedModel(this.Fork());
        }

        private GreenModel Fork()
        {
            return null;
        }

        internal ModelTransactionCommand Transaction
        {
            get
            {
                if (this.transaction == null)
                {
                    Interlocked.CompareExchange(ref this.transaction, new ModelTransactionCommand(this.model), null);
                }
                return this.transaction;
            }
        }

        internal ModelTransactionCommand CurrentTransaction
        {
            get
            {
                if (this.currentTransaction == null)
                {
                    Interlocked.CompareExchange(ref this.currentTransaction, this.Transaction, null);
                }
                return this.currentTransaction;
            }
        }
        public void BeginTransaction()
        {
            Interlocked.Exchange(ref this.currentTransaction, this.CurrentTransaction.BeginTransaction());
        }

        public void CommitTransaction()
        {
            Interlocked.Exchange(ref this.currentTransaction, this.CurrentTransaction.CommitTransaction());
        }

        public void RollbackTransaction()
        {
            Interlocked.Exchange(ref this.currentTransaction, this.CurrentTransaction.RollbackTransaction());
        }

        public void AddPart(GreenModelPart part)
        {
            this.CurrentTransaction.AddPart(part);
        }

        public void AddParts(IEnumerable<GreenModelPart> parts)
        {
            this.CurrentTransaction.AddParts(parts);
        }

        public void RemovePart(GreenModelPart part)
        {
            this.CurrentTransaction.RemovePart(part);
        }

        public void AddObject(GreenModelPart part, GreenSymbol symbol)
        {
            this.CurrentTransaction.AddSymbol(part, symbol);
        }

        public void RemoveObject(GreenModelPart part, GreenSymbol symbol)
        {
            this.CurrentTransaction.RemoveSymbol(part, symbol);
        }

        public void AddValue(GreenModelPart part, GreenSymbol symbol, ModelProperty property, object value)
        {
            this.CurrentTransaction.AddValue(part, symbol, property, value);
        }

        public void RemoveValue(GreenModelPart part, GreenSymbol symbol, ModelProperty property, object value)
        {
            this.CurrentTransaction.RemoveValue(part, symbol, property, value);
        }
    }



    internal class ModelBuildCommand
    {
    }

    internal class ModelTransactionCommand : ModelBuildCommand
    {
        private GreenModel model;
        private ModelTransactionCommand parent;
        private Dictionary<object, Dictionary<GreenSymbol, Dictionary<ModelProperty, object>>> symbols;
        private HashSet<GreenSymbol> deletedSymbols;
        private List<ModelBuildCommand> commands;

        public ModelTransactionCommand(GreenModel group)
        {
            this.model = group;
        }

        public ModelTransactionCommand(ModelTransactionCommand parent)
        {
            this.parent = parent;
        }

        public GreenModel Model
        {
            get { return this.model ?? this.parent?.Model; }
        }

        public List<ModelBuildCommand> Commands
        {
            get
            {
                if (this.commands == null)
                {
                    Interlocked.CompareExchange(ref this.commands, new List<ModelBuildCommand>(), null);
                }
                return this.commands;
            }
        }

        public Dictionary<object, Dictionary<GreenSymbol, Dictionary<ModelProperty, object>>> Symbols
        {
            get
            {
                if (this.symbols == null)
                {
                    Interlocked.CompareExchange(ref this.symbols, new Dictionary<object, Dictionary<GreenSymbol, Dictionary<ModelProperty, object>>>(), null);
                }
                return this.symbols;
            }
        }

        public ModelTransactionCommand BeginTransaction()
        {
            lock(this.Commands)
            {
                ModelTransactionCommand result = new ModelTransactionCommand(this);
                this.Commands.Add(result);
                return result;
            }
        }

        public ModelTransactionCommand CommitTransaction()
        {
            if (this.parent == null) return this;
            lock (this.parent.Commands)
            {
                this.parent.Commands.Remove(this);
                this.parent.Merge(this);
                return this.parent;
            }
        }

        public ModelTransactionCommand RollbackTransaction()
        {
            if (this.parent == null) return new ModelTransactionCommand(this.model);
            lock (this.parent.Commands)
            {
                this.parent.Commands.Remove(this);
                return this.parent;
            }
        }

        private void Merge(ModelTransactionCommand child)
        {
            // TODO
        }

        public void AddPart(GreenModelPart part)
        {
            Interlocked.Exchange(ref this.model, this.Model.WithPart(part));
        }

        public void AddParts(IEnumerable<GreenModelPart> parts)
        {
            Interlocked.Exchange(ref this.model, this.Model.WithParts(parts));
        }

        public void RemovePart(GreenModelPart part)
        {
            // TODO
        }

        public void AddSymbol(GreenModelPart part, GreenSymbol symbol)
        {
            // TODO
        }

        public void RemoveSymbol(GreenModelPart part, GreenSymbol symbol)
        {
            // TODO
        }

        public void AddValue(GreenModelPart part, GreenSymbol symbol, ModelProperty property, object value)
        {
            // TODO
        }

        public void RemoveValue(GreenModelPart part, GreenSymbol symbol, ModelProperty property, object value)
        {
            // TODO
        }

        private Dictionary<ModelProperty, object> GetSymbol(object modelPartId, GreenSymbol symbol, bool clone = true)
        {
            Dictionary<GreenSymbol, Dictionary<ModelProperty, object>> modelPart = null;
            lock (this.Symbols)
            {
                if (!this.symbols.TryGetValue(modelPartId, out modelPart))
                {
                    modelPart = new Dictionary<GreenSymbol, Dictionary<ModelProperty, object>>();
                    this.symbols.Add(modelPartId, modelPart);
                }
            }
            Dictionary<ModelProperty, object> result = null;
            result = this.FindSymbol(modelPartId, symbol, FindObjectFlags.This);
            if (result != null) return result;
            result = this.FindSymbol(modelPartId, symbol, FindObjectFlags.Ancestors | FindObjectFlags.Default);
            if (clone)
            {
                Dictionary<ModelProperty, object> clonedResult = null;
                lock (result)
                {
                    clonedResult = result.ToDictionary(entry => entry.Key, entry => entry.Value);
                }
                result = clonedResult;
                lock(modelPart)
                {
                    modelPart.Add(symbol, result);
                }
            }
            return result;
        }

        [Flags]
        private enum FindObjectFlags
        {
            This = 1,
            Ancestors = 2,
            Default = 4,
            All = This | Ancestors | Default
        }

        private Dictionary<ModelProperty, object> FindSymbol(object modelPartId, GreenSymbol symbol, FindObjectFlags flags = FindObjectFlags.All)
        {
            Dictionary<ModelProperty, object> result = null;
            ModelTransactionCommand cmd = this;
            if (!flags.HasFlag(FindObjectFlags.This))
            {
                cmd = cmd.parent;
            }
            while (result == null && cmd != null)
            {
                Dictionary<GreenSymbol, Dictionary<ModelProperty, object>> modelPart = null;
                lock (cmd.Symbols)
                {
                    if (cmd.symbols.TryGetValue(modelPartId, out modelPart))
                    {
                        if (modelPart.TryGetValue(symbol, out result))
                        {
                            return result;
                        }
                    }
                }
                if (!flags.HasFlag(FindObjectFlags.Ancestors)) break;
                cmd = cmd.parent;
            }
            if (!flags.HasFlag(FindObjectFlags.Default))
            {
                return null;
            }
            else 
            {
                return this.FindDefaultSymbol(modelPartId, symbol);
            }
        }

        private Dictionary<ModelProperty, object> FindDefaultSymbol(object modelPartId, GreenSymbol symbol, FindObjectFlags flags = FindObjectFlags.All)
        {
            Dictionary<ModelProperty, object> result = null;
            ModelTransactionCommand cmd = this;
            if (!flags.HasFlag(FindObjectFlags.This))
            {
                cmd = cmd.parent;
            }
            while (result == null && cmd != null)
            {
                lock (cmd.Model)
                {
                    GreenModelPart model = null;
                    if (cmd.model.parts.TryGetValue(modelPartId, out model))
                    {
                        if (model.Symbols.TryGetValue(symbol, out result))
                        {
                            return result;
                        }
                    }
                }
                if (!flags.HasFlag(FindObjectFlags.Ancestors)) break;
                cmd = cmd.parent;
            }
            return null;
        }

        private Dictionary<GreenSymbol, Dictionary<ModelProperty, object>> GetSymbols(object modelPartId)
        {
            lock(this.Symbols)
            {
                Dictionary<GreenSymbol, Dictionary<ModelProperty, object>> result = null;
                if (this.symbols.TryGetValue(modelPartId, out result))
                {
                    return result;
                }
            }
            return this.GetSymbolsFromParent(modelPartId);
        }

        private Dictionary<GreenSymbol, Dictionary<ModelProperty, object>> GetSymbolsFromParent(object modelPartId)
        {
            Dictionary<GreenSymbol, Dictionary<ModelProperty, object>> result = null;
            if (this.parent != null)
            {
                result = this.parent.GetSymbols(modelPartId);
            }
            else if (this.model != null)
            {
                lock (this.Model)
                {
                    result = this.model.Parts.FirstOrDefault(m => m.Id == modelPartId)?.Symbols;
                }
            }
            return result;
        }
    }

    internal class ModelValueCommand : ModelBuildCommand
    {
        public GreenSymbol Target { get; private set; }
        public ModelProperty Property { get; private set; }
        public object Value { get; private set; }

        public ModelValueCommand(GreenSymbol target, ModelProperty property, object value)
        {
            this.Target = target;
            this.Property = property;
            this.Value = value;
        }
    }

    internal class ModelAddValueCommand : ModelValueCommand
    {
        public ModelAddValueCommand(GreenSymbol target, ModelProperty property, object value)
            : base(target, property, value)
        {
        }
    }

    internal class ModelRemoveValueCommand : ModelValueCommand
    {
        public ModelRemoveValueCommand(GreenSymbol target, ModelProperty property, object value)
            : base(target, property, value)
        {
        }
    }
}
