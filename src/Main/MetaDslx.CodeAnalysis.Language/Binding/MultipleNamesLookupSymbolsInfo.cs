// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Microsoft.CodeAnalysis.CSharp.Binding
{
    public class MultipleNamesLookupSymbolsInfo<TSymbol>
        where TSymbol: class
    {
        // PERF: This is a very frequent allocation, so the aim is to keep
        // it as small as possible.
        private struct UniqueSymbolOrMultiNames 
        {
            // For most situations, the set of arities is small and
            // the values are in the low single digits. However, the
            // theoretical max for arity is 32,767 (Int16.MaxValue).
            // The arities field is, therefore, a bitvector of the
            // arity values from zero to 31.
            // If an arity greater than 31 is encountered, then
            // uniqueSymbolOrArities becomes a HashSet for bits
            // 32 and above.

            // This (object) field may be a TSymbol, null or a HashSet<int>
            // If it's a (string,TSymbol) tuple:
            //   Then _uniqueSymbolOrMultiNames is interpreted as a unique
            //   arity (which may be any value)
            // If it's ConsList<string>:
            //   Then _uniqueSymbolOrMultiNames is interpreted as a ConsList<string>
            //   of multi names.
            // Otherwise it's a HashSet<string>:
            //   Then _uniqueSymbolOrMultiNames is interpreted as a HashSet<string>
            //   of multi names.
            private object _uniqueSymbolOrMultiNames;

            public UniqueSymbolOrMultiNames(TSymbol uniqueSymbol, string multiName)
            {
                _uniqueSymbolOrMultiNames = uniqueSymbol;
                //if there's no unique symbol, how can there be a multi name?
                Debug.Assert((uniqueSymbol != null) || (multiName == null));
            }

            public void AddSymbol(TSymbol symbol, string multiName)
            {
                if (symbol != null && symbol == _uniqueSymbolOrMultiNames)
                {
                    return;
                }

                if (this.HasUniqueSymbol)
                {
                    // The symbol is no longer unique. So clear the
                    // UniqueSymbol field and record the unique name
                    // before adding the new name value.
                    var (uniqueName, _) = (Tuple<string,TSymbol>)_uniqueSymbolOrMultiNames;
                    Debug.Assert(_uniqueSymbolOrMultiNames is TSymbol);
                    _uniqueSymbolOrMultiNames = new ConsList<string>(uniqueName, ConsList<string>.Empty);
                }
                AddMultiName(multiName);
            }

            private void AddMultiName(string multiName)
            {
                Debug.Assert(!this.HasUniqueSymbol);
                ConsList<string> multiNamesList = _uniqueSymbolOrMultiNames as ConsList<string>;
                HashSet<string> multiNamesSet;
                if (multiNamesList != null)
                {
                    int count = 0;
                    foreach (var sn in multiNamesList)
                    {
                        if (sn == multiName) return;
                        ++count;
                    }
                    if (count < 31)
                    {
                        _uniqueSymbolOrMultiNames = new ConsList<string>(multiName, multiNamesList);
                        return;
                    }
                    else
                    {
                        multiNamesSet = new HashSet<string>(multiNamesList);
                        _uniqueSymbolOrMultiNames = multiNamesSet;
                    }
                }
                else
                {
                    multiNamesSet = _uniqueSymbolOrMultiNames as HashSet<string>;
                }
                if (multiNamesSet != null)
                {
                    multiNamesSet.Add(multiName);
                }
                Debug.Assert(multiNamesSet == null || multiNamesSet.Contains(multiName));
            }

            private bool HasUniqueSymbol => _uniqueSymbolOrMultiNames != null && !(_uniqueSymbolOrMultiNames is ConsList<string> || _uniqueSymbolOrMultiNames is HashSet<string>);

            public void GetUniqueSymbolOrMultiNames(out IEnumerable<string> multiNames, out TSymbol uniqueSymbol)
            {
                if (this.HasUniqueSymbol)
                {
                    multiNames = null;
                    uniqueSymbol = (TSymbol)_uniqueSymbolOrMultiNames;
                }
                else
                {
                    multiNames = (ConsList<string>)_uniqueSymbolOrMultiNames;
                    uniqueSymbol = null;
                }
            }

            public IEnumerator<string> GetEnumerator()
            {
                Debug.Assert(!this.HasUniqueSymbol);
                return ((ConsList<string>)_uniqueSymbolOrMultiNames).GetEnumerator();
            }

            public int Count
            {
                get
                {
                    Debug.Assert(!this.HasUniqueSymbol);
                    int count = ((ConsList<string>)_uniqueSymbolOrMultiNames).Count();
                    return count;
                }
            }

#if DEBUG
            internal TSymbol UniqueSymbol => _uniqueSymbolOrMultiNames as TSymbol;
#endif
        }

        private readonly IEqualityComparer<string> _comparer;
        private readonly Dictionary<string, UniqueSymbolOrMultiNames> _nameMap;
        internal string FilterName { get; set; }

        protected MultipleNamesLookupSymbolsInfo(IEqualityComparer<string> comparer)
        {
            _comparer = comparer;
            _nameMap = new Dictionary<string, UniqueSymbolOrMultiNames>(comparer);
        }

        public bool CanBeAdded(string name) => FilterName == null || _comparer.Equals(name, FilterName);

        public void AddSymbol(TSymbol symbol, string name, string multiName)
        {
            UniqueSymbolOrMultiNames pair;
            if (!_nameMap.TryGetValue(name, out pair))
            {
                // First time seeing a symbol with this name.  Create a mapping for it from the name
                // to the one arity we've seen, and also store around the symbol as it's currently
                // unique.
                pair = new UniqueSymbolOrMultiNames(symbol, multiName);
                _nameMap.Add(name, pair);
            }
            else
            {
                pair.AddSymbol(symbol, multiName);

                // Since 'pair' is a struct, the dictionary must be updated with the new value
                _nameMap[name] = pair;
            }

#if DEBUG
            // After adding this symbol, the name must map to it (if it's unique), or it must map to
            // nothing (if it's not unique).  If it maps to another symbol then we've done something
            // horribly wrong.
            Debug.Assert(pair.UniqueSymbol == null || pair.UniqueSymbol == symbol);
#endif
        }

        public ICollection<string> Names => _nameMap.Keys;

        public int Count => _nameMap.Count;

        /// <summary>
        /// If <paramref name="uniqueSymbol"/> is set, then <paramref name="multipleNames"/> will be null.
        /// The only name in that case will be encoded in the symbol. 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="multipleNames"></param>
        /// <param name="uniqueSymbol"></param>
        /// <returns></returns>
        public bool TryGetMultipleNamesAndUniqueSymbol(
            string name,
            out IEnumerable<string> multipleNames,
            out TSymbol uniqueSymbol)
        {
            Debug.Assert(CanBeAdded(name));

            UniqueSymbolOrMultiNames pair;
            if (!_nameMap.TryGetValue(name, out pair))
            {
                multipleNames = null;
                uniqueSymbol = null;
                return false;
            }

            // If a unique symbol is set (not null), then its name should be determined
            // by inspecting the symbol.
            pair.GetUniqueSymbolOrMultiNames(out multipleNames, out uniqueSymbol);
            return true;
        }

        public void Clear()
        {
            _nameMap.Clear();
            FilterName = null;
        }
    }
}
