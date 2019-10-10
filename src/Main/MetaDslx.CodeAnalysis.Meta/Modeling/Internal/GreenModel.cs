using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Modeling.Internal
{
    internal class Unassigned
    {

    }

    internal class GreenModel
    {
        private readonly ModelId id;
        private readonly string name;
        private readonly ModelVersion version;
        private readonly ImmutableList<SymbolId> strongSymbols;
        // TODO: replace with immutable weak dictionaries:
        private readonly ImmutableDictionary<SymbolId, GreenSymbol> symbols;
        private readonly ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>> lazyProperties;
        private readonly ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>> references;

        internal GreenModel(ModelId id, string name, ModelVersion version)
        {
            this.id = id;
            this.name = name;
            this.version = version;
            this.symbols = ImmutableDictionary<SymbolId, GreenSymbol>.Empty;
            this.strongSymbols = ImmutableList<SymbolId>.Empty;
            this.lazyProperties = ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>.Empty;
            this.references = ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>>.Empty;
        }

        private GreenModel(ModelId id,
            string name,
            ModelVersion version,
            ImmutableDictionary<SymbolId, GreenSymbol> symbols,
            ImmutableList<SymbolId> strongSymbols,
            ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>> lazyProperties,
            ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>> references)
        {
            Debug.Assert(symbols != null);
            Debug.Assert(lazyProperties != null);
            Debug.Assert(references != null);
            this.id = id;
            this.name = name;
            this.version = version;
            this.symbols = symbols;
            this.strongSymbols = strongSymbols;
            this.lazyProperties = lazyProperties;
            this.references = references;
        }

        internal GreenModel Update(
            string name,
            ModelVersion version,
            ImmutableDictionary<SymbolId, GreenSymbol> symbols,
            ImmutableList<SymbolId> strongSymbols,
            ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>> lazyProperties,
            ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>> references)
        {
            if (this.name != name || this.version != version || this.symbols != symbols || 
                this.strongSymbols != strongSymbols || 
                this.lazyProperties != lazyProperties || this.references != references)
            {
                return new GreenModel(this.id, name, version, symbols, strongSymbols, lazyProperties, references);
            }
            return this;
        }

        internal ModelId Id { get { return this.id; } }
        internal string Name { get { return this.name; } }
        internal ModelVersion Version { get { return this.version; } }
        internal ImmutableDictionary<SymbolId, GreenSymbol> Symbols { get { return this.symbols; } }
        internal ImmutableList<SymbolId> StrongSymbols { get { return this.strongSymbols; } }
        internal ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>> LazyProperties { get { return this.lazyProperties; } }
        internal ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>> References { get { return this.references; } }

        internal GreenModel AddSymbol(SymbolId id, bool weak)
        {
            Debug.Assert(!this.symbols.ContainsKey(id), "The green model already contains this symbol.");
            return this.Update(this.name, this.version, this.symbols.Add(id, id.SymbolInfo.EmptyGreenSymbol), weak ? this.strongSymbols : this.strongSymbols.Add(id), this.lazyProperties, this.references);
        }

        internal GreenModel RemoveSymbol(SymbolId id)
        {
            Debug.Assert(!this.lazyProperties.ContainsKey(id));
            ImmutableDictionary<SymbolId, GreenSymbol> symbols = this.symbols;
            ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>> refs;
            if (this.references.TryGetValue(id, out refs))
            {
                foreach (var refEntry in refs)
                {
                    GreenSymbol symbol;
                    if (this.symbols.TryGetValue(refEntry.Key, out symbol))
                    {
                        GreenSymbol oldSymbol = symbol;
                        foreach (var prop in refEntry.Value)
                        {
                            object value;
                            if (symbol.Properties.TryGetValue(prop, out value))
                            {
                                if (value is GreenList)
                                {
                                    GreenList list = (GreenList)value;
                                    symbol = symbol.Update(
                                        symbol.Parent == id ? null : symbol.Parent,
                                        symbol.Children.RemoveAll(item => item == id),
                                        symbol.Properties.SetItem(prop, list.RemoveAll(id)));
                                }
                                else if ((SymbolId)value == id)
                                {
                                    symbol = symbol.Update(
                                        symbol.Parent == id ? null : symbol.Parent,
                                        symbol.Children.RemoveAll(item => item == id),
                                        symbol.Properties.SetItem(prop, GreenSymbol.Unassigned));
                                }
                            }
                        }
                        if (symbol != oldSymbol)
                        {
                            symbols.SetItem(refEntry.Key, symbol);
                        }
                    }
                }
                return this.Update(
                    this.name,
                    this.version,
                    symbols.Remove(id),
                    this.strongSymbols.Remove(id),
                    this.lazyProperties.Remove(id),
                    this.references.Remove(id));
            }
            return this;
        }

        internal GreenModel ReplaceSymbol(SymbolId id, SymbolId targetSid)
        {
            Debug.Assert(!this.lazyProperties.ContainsKey(id));
            ImmutableDictionary<SymbolId, GreenSymbol> symbols = this.symbols;
            ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>> refs;
            if (this.references.TryGetValue(id, out refs))
            {
                ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>> targetRefs;
                if (!this.references.TryGetValue(targetSid, out targetRefs))
                {
                    targetRefs = ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>.Empty;
                }
                foreach (var refEntry in refs)
                {
                    GreenSymbol symbol;
                    if (this.symbols.TryGetValue(refEntry.Key, out symbol))
                    {
                        GreenSymbol oldSymbol = symbol;
                        ImmutableHashSet<ModelProperty> targetProps;
                        if (!targetRefs.TryGetValue(refEntry.Key, out targetProps))
                        {
                            targetProps = ImmutableHashSet<ModelProperty>.Empty;
                        }
                        foreach (var prop in refEntry.Value)
                        {
                            object value;
                            if (symbol.Properties.TryGetValue(prop, out value))
                            {
                                if (value is GreenList)
                                {
                                    GreenList list = (GreenList)value;
                                    symbol = symbol.Update(
                                        symbol.Parent == id ? targetSid : symbol.Parent,
                                        symbol.Children.Replace(id, targetSid),
                                        symbol.Properties.SetItem(prop, list.Replace(id, targetSid)));
                                    targetProps = targetProps.Add(prop);
                                }
                                else if ((SymbolId)value == id)
                                {
                                    symbol = symbol.Update(
                                        symbol.Parent == id ? targetSid : symbol.Parent,
                                        symbol.Children.Replace(id, targetSid),
                                        symbol.Properties.SetItem(prop, targetSid));
                                    targetProps = targetProps.Add(prop);
                                }
                            }
                        }
                        if (symbol != oldSymbol)
                        {
                            symbols.SetItem(refEntry.Key, symbol);
                        }
                        if (targetProps.Count > 0)
                        {
                            targetRefs = targetRefs.SetItem(refEntry.Key, targetProps);
                        }
                    }
                }
                return this.Update(
                    this.name,
                    this.version,
                    symbols.Remove(id),
                    this.strongSymbols.Remove(id), 
                    this.lazyProperties.Remove(id), 
                    targetRefs.Count > 0 ? this.references.Remove(id).SetItem(targetSid, targetRefs) : this.references.Remove(id));
            }
            return this;
        }

        internal GreenModel PurgeWeakSymbols(HashSet<SymbolId> strongSymbols)
        {
            var symbols = this.symbols;
            var references = this.references;
            foreach (var id in this.symbols.Keys)
            {
                if (!strongSymbols.Contains(id))
                {
                    symbols = symbols.Remove(id);
                    references = references.Remove(id);
                }
            }
            return this.Update(this.name, this.version, symbols, this.strongSymbols, this.lazyProperties, references);
        }

        public override string ToString()
        {
            return this.Name + " (" + this.Version + ")";
        }

        public string ToFullString()
        {
            return this.Name + " (" + this.Version + ": " + this.Id.Guid + ")";
        }
    }
}
