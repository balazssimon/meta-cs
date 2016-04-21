using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable5
{
    // GREEN:

    public interface GreenSymbol
    {
        Type ImmutableType { get; }
        Type MutableType { get; }
        ImmutableRedSymbol CreateImmutableRed(ImmutableRedModel model);
        MutableRedSymbol CreateMutableRed(MutableRedModel model);
    }

    internal class GreenLazyItem
    {
        private Func<object> lazy;

        internal GreenLazyItem(Func<object> lazy)
        {
            this.lazy = lazy;
        }
    }

    internal class GreenLazySymbol
    {
        private Func<object> lazy;

        internal GreenLazySymbol(Func<object> lazy)
        {
            this.lazy = lazy;
        }
    }

    internal abstract class GreenList
    {
        private GreenSymbol parent;
        private ModelProperty property;
        private bool allowMultipleItems;

        internal GreenList(GreenSymbol parent, ModelProperty property, bool allowMultipleItems = false)
        {
            this.parent = parent;
            this.property = property;
            this.allowMultipleItems = allowMultipleItems;
        }

        internal GreenSymbol Parent { get { return this.parent; } }
        internal ModelProperty Property { get { return this.property; } }
        internal bool AllowMultipleItems { get { return this.allowMultipleItems; } }

        //public abstract bool Contains(object item);
    }

    internal class GreenValueList : GreenList//, IReadOnlyList<object>
    {
        private List<object> items;

        internal GreenValueList(GreenSymbol parent, ModelProperty property, bool allowMultipleItems = false)
            : base(parent, property, allowMultipleItems)
        {
            this.items = new List<object>();
        }

        internal GreenValueList(GreenValueList other)
            : base(other.Parent, other.Property, other.AllowMultipleItems)
        {
            this.items = new List<object>(other.items);
        }
    }

    internal class GreenSymbolList : GreenList//, IReadOnlyList<GreenSymbol>
    {
        private List<GreenSymbol> items;

        internal GreenSymbolList(GreenSymbol parent, ModelProperty property, bool allowMultipleItems = false)
            : base(parent, property, allowMultipleItems)
        {
            this.items = new List<GreenSymbol>();
        }

        internal GreenSymbolList(GreenSymbolList other)
            : base(other.Parent, other.Property, other.AllowMultipleItems)
        {
            this.items = new List<GreenSymbol>(other.items);
        }
    }

    internal class GreenModel
    {
        private static readonly IReadOnlyList<GreenSymbol> emptySymbolList = new List<GreenSymbol>();
        protected Dictionary<GreenSymbol, GreenSymbolEntry> symbols;

        internal GreenModel()
        {
        }

        internal GreenModel(Dictionary<GreenSymbol, GreenSymbolEntry> symbols)
        {
            this.symbols = symbols;
        }

        internal IEnumerable<GreenSymbol> Symbols
        {
            get
            {
                if (this.symbols != null) return this.symbols.Keys;
                else return GreenModel.emptySymbolList;
            }
        }

        internal virtual GreenModelTransaction BeginTransaction(MutableRedModel model)
        {
            return new GreenModelTransaction(this, model);
        }

        internal class GreenSymbolEntry
        {
            internal Dictionary<ModelProperty, object> properties;
            internal Dictionary<GreenSymbol, HashSet<ModelProperty>> references;

            internal GreenSymbolEntry()
            {
            }

            internal GreenSymbolEntry(GreenSymbolEntry other)
            {
                this.properties = other.properties != null ?
                    other.properties.ToDictionary(entry => entry.Key,
                        entry => entry.Value is GreenSymbolList ? new GreenSymbolList((GreenSymbolList)entry.Value) :
                                 entry.Value is GreenValueList ? new GreenValueList((GreenValueList)entry.Value) :
                                 entry.Value)
                    : null;
                this.references = other.references != null ? other.references.ToDictionary(entry => entry.Key, entry => new HashSet<ModelProperty>(entry.Value)) : null;
            }

            internal GreenSymbolEntry Clone()
            {
                return new GreenSymbolEntry(this);
            }

            internal void CreateProperties()
            {
                if (this.properties == null)
                {
                    this.properties = new Dictionary<ModelProperty, object>();
                }
            }

            internal void CreateReferences()
            {
                if (this.references == null)
                {
                    this.references = new Dictionary<GreenSymbol, HashSet<ModelProperty>>();
                }
            }
        }

    }

    internal class GreenModelTransaction : GreenModel
    {
        private GreenModel baseModel;
        private GreenModelTransaction parentTransaction;

        private MutableRedModel redModel;
        private Dictionary<GreenSymbol, MutableRedSymbol> redSymbols;
        private Dictionary<GreenLazyItem, object> lazyItems;
        private bool allowLazyEval = false;

        internal GreenModelTransaction(GreenModel baseModel, MutableRedModel redModel)
        {
            if (baseModel == null) throw new ArgumentNullException(nameof(baseModel));
            if (redModel == null) throw new ArgumentNullException(nameof(redModel));
            this.baseModel = baseModel;
            this.redModel = redModel;
            this.redSymbols = null;
            this.lazyItems = null;
        }

        internal GreenModelTransaction(GreenModelTransaction parentTransaction, MutableRedModel redModel)
        {
            if (parentTransaction == null) throw new ArgumentNullException(nameof(parentTransaction));
            if (redModel == null) throw new ArgumentNullException(nameof(redModel));
            this.baseModel = parentTransaction;
            this.parentTransaction = parentTransaction;
            this.redModel = redModel;
            this.allowLazyEval = parentTransaction.allowLazyEval;
            this.redSymbols = null;
            this.lazyItems = null;
        }

        internal bool IsChanged
        {
            get
            {
                return this.symbols != null && (!this.parentTransaction?.IsChanged ?? false);
            }
        }
    }

    // RED interface:

    // Symbol:

    public interface RedSymbol
    {
        RedModel MModel { get; }
        object MGetValue(ModelProperty property);
    }

    public interface ImmutableRedSymbol : RedSymbol
    {
        new ImmutableRedModel MModel { get; }
    }

    public interface MutableRedSymbol : RedSymbol
    {
        new MutableRedModel MModel { get; }
        bool MAddValue(ModelProperty property, object value);
        bool MAddLazyValue(ModelProperty property, Func<object> value);
        bool MRemoveValue(ModelProperty property, object value);
    }

    // List:

    public interface ImmutableModelList<out T> : IReadOnlyList<T>
    {
    }

    public interface ModelList<T> : IList<T>
    {
        void AddLazy(Func<T> lazy);
    }

    // Model:

    public interface RedModel
    {

    }

    // RED implementation:

    // Symbol:

    public abstract class RedSymbolBase : RedSymbol
    {
        private GreenSymbol green;
        private RedModel model;

        public RedSymbolBase(GreenSymbol green, RedModel model)
        {
            this.green = green;
            this.model = model;
        }

        internal GreenSymbol Green { get { return this.green; } }
        public RedModel Model { get { return this.model; } }

        public abstract RedModel MModel { get; }
        public abstract object MGetValue(ModelProperty property);
    }

    public sealed class ImmutableRedModel : RedModel
    {
        private GreenModel green;
        private Dictionary<GreenSymbol, ImmutableRedSymbol> symbols;
        private Dictionary<GreenLazyItem, object> lazyItems;

        internal ImmutableRedModel(GreenModel green)
        {
            this.green = green;
            this.symbols = new Dictionary<GreenSymbol, ImmutableRedSymbol>();
            this.lazyItems = new Dictionary<GreenLazyItem, object>();
        }
    }

    public sealed class MutableRedModel : RedModel
    {
        private GreenModelTransaction rootTransaction;
        private GreenModelTransaction currentTransaction;
        private ImmutableRedModel originalImmutableModel;

        public MutableRedModel()
            : this(new GreenModel(), null)
        {
        }

        internal MutableRedModel(GreenModel green)
            : this(green, null)
        {
        }

        internal MutableRedModel(GreenModel green, ImmutableRedModel originalImmutableModel)
        {
            this.originalImmutableModel = originalImmutableModel;
            this.currentTransaction = green.BeginTransaction(this);
            this.rootTransaction = this.currentTransaction;
        }

        internal GreenModelTransaction Transaction { get { return this.currentTransaction; } }
    }
}