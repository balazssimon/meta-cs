using MetaDslx.CodeAnalysis.PooledObjects;
using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public sealed class LookupCandidates
    {
        private readonly ArrayBuilder<DeclaredSymbol> _symbolList;

        private readonly ObjectPool<LookupCandidates> _pool;

        private LookupCandidates(ObjectPool<LookupCandidates> pool)
        {
            _pool = pool;
            _symbolList = new ArrayBuilder<DeclaredSymbol>();
        }

        public bool IsClear
        {
            get
            {
                return _symbolList.Count == 0;
            }
        }

        public void Clear()
        {
            _symbolList.Clear();
        }

        public void Add(DeclaredSymbol symbol)
        {
            _symbolList.Add(symbol);
        }

        public ArrayBuilder<DeclaredSymbol> Symbols
        {
            get
            {
                return _symbolList;
            }
        }

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
