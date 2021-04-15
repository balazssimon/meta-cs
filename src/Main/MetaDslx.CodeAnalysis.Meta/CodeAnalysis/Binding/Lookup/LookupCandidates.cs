using Microsoft.CodeAnalysis.PooledObjects;
using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Binding
{
    public sealed class LookupCandidates 
    {
        private readonly ObjectPool<LookupCandidates> _pool;
        private readonly HashSet<DeclaredSymbol> _symbolList;
        private readonly HashSet<DiagnosticInfo> _useSiteDiagnostics;

        private LookupCandidates(ObjectPool<LookupCandidates> pool)
        {
            _pool = pool;
            _symbolList = new HashSet<DeclaredSymbol>();
            _useSiteDiagnostics = new HashSet<DiagnosticInfo>();
        }

        public bool IsClear => _symbolList.Count == 0;
        public int Count => _symbolList.Count;

        public void Clear()
        {
            _symbolList.Clear();
            _useSiteDiagnostics.Clear();
        }

        public void Add(DeclaredSymbol symbol)
        {
            _symbolList.Add(symbol);
        }

        public void AddRange(IEnumerable<DeclaredSymbol> symbols)
        {
            _symbolList.UnionWith(symbols);
        }

        public void Merge(LookupCandidates candidates)
        {
            _symbolList.UnionWith(candidates.Symbols);
            _useSiteDiagnostics.UnionWith(candidates.UseSiteDiagnostics);
        }

        public HashSet<DeclaredSymbol> Symbols => _symbolList;
        public HashSet<DiagnosticInfo> UseSiteDiagnostics => _useSiteDiagnostics;

        // global pool
        //TODO: consider if global pool is ok.
        private static readonly ObjectPool<LookupCandidates> s_poolInstance = CreatePool();

        // if someone needs to create a pool
        public static ObjectPool<LookupCandidates> CreatePool()
        {
            ObjectPool<LookupCandidates> pool = null;
            pool = new ObjectPool<LookupCandidates>(() => new LookupCandidates(pool), 128); // we rarely need more than 10
            return pool;
        }

        public static LookupCandidates GetInstance()
        {
            var instance = s_poolInstance.Allocate();
            Debug.Assert(instance.IsClear);
            return instance;
        }

        public void Free()
        {
            this.Clear();
            if (_pool != null)
            {
                _pool.Free(this);
            }
        }

    }
}
