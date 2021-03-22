// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Immutable;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding
{
    /// <summary>
    /// represents one-to-one symbol -> SingleLookupResult filter.
    /// </summary>
    public delegate SingleLookupResult LookupFilter(Symbol sym);

    /// <summary>
    /// A LookupResult summarizes the result of a name lookup within a scope It also allows
    /// combining name lookups from different scopes in an easy way.
    /// 
    /// A LookupResult can be ONE OF:
    ///    empty - nothing found.
    ///    a viable result - this kind of result prevents lookup into further scopes of lower priority.
    ///                      Viable results should be without error; ambiguity is handled in the caller.
    ///                      (Note that handling multiple "viable" results is not the same as in the VB compiler)
    ///    a non-accessible result - this kind of result means that search continues into further scopes of lower priority for
    ///                      a viable result. An error is attached with the inaccessibility errors. Non-accessible results take priority over
    ///                      non-viable results.
    ///    a non-viable result - a result that means that the search continues into further scopes of lower priority for
    ///                          a viable or non-accessible result. An error is attached with the error that indicates
    ///                          why the result is non-viable.  A typical reason would be that it is the wrong kind of symbol.
    /// 
    /// Note that the class is poolable so its instances can be obtained from a pool via GetInstance.
    /// Also it is a good idea to call Free on instances after they no longer needed.
    /// 
    /// The typical pattern is "caller allocates / caller frees" -
    ///    
    ///    var result = LookupResult.GetInstance();
    ///  
    ///    scope.Lookup(result, "goo");
    ///    ... use result ...
    ///         
    ///    result.Clear();
    ///    anotherScope.Lookup(result, "moo");
    ///    ... use result ...
    /// 
    ///    result.Free();   //result and its content is invalid after this
    ///    
    /// 
    /// 
    /// </summary>
    /// <remarks>
    /// Currently LookupResult is intended only for name lookup, not for overload resolution. It is
    /// not clear if overload resolution will work with the structure as is, require enhancements,
    /// or be best served by an alternate mechanism.
    /// 
    /// We might want to extend this to a more general priority scheme.
    /// 
    /// </remarks>
    public sealed class LookupResult
    {
        // the kind of result.
        private LookupResultKind _kind;

        // If there is more than one symbol, they are stored in this list.
        private readonly ArrayBuilder<DeclaredSymbol> _symbolList;

        // the error of the result, if it is NonViable or Inaccessible
        private DiagnosticInfo _error;

        private readonly ObjectPool<LookupResult> _pool;

        private LookupResult(ObjectPool<LookupResult> pool)
        {
            _pool = pool;
            _kind = LookupResultKind.Empty;
            _symbolList = new ArrayBuilder<DeclaredSymbol>();
            _error = null;
        }

        public bool IsClear
        {
            get
            {
                return _kind == LookupResultKind.Empty && _error == null && _symbolList.Count == 0;
            }
        }

        public void Clear()
        {
            _kind = LookupResultKind.Empty;
            _symbolList.Clear();
            _error = null;
        }

        public LookupResultKind Kind
        {
            get
            {
                return _kind;
            }
        }

        /// <summary>
        /// Return the single symbol if there is exactly one, otherwise null.
        /// </summary>
        public DeclaredSymbol SingleSymbolOrDefault
        {
            get
            {
                return (_symbolList.Count == 1) ? _symbolList[0] : null;
            }
        }

        public ArrayBuilder<DeclaredSymbol> Symbols
        {
            get
            {
                return _symbolList;
            }
        }

        public DiagnosticInfo Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// Is the result viable with one or more symbols?
        /// </summary>
        public bool IsMultiViable
        {
            get
            {
                return Kind == LookupResultKind.Viable;
            }
        }

        /// <summary>
        /// NOTE: Even there is a single viable symbol, it may be an error type symbol.
        /// </summary>
        public bool IsSingleViable
        {
            get
            {
                return Kind == LookupResultKind.Viable && _symbolList.Count == 1;
            }
        }

        public static SingleLookupResult Good(DeclaredSymbol symbol)
        {
            return new SingleLookupResult(LookupResultKind.Viable, symbol, null);
        }

        public static SingleLookupResult WrongArity(DeclaredSymbol symbol, DiagnosticInfo error)
        {
            return new SingleLookupResult(LookupResultKind.WrongArity, symbol, error);
        }

        public static SingleLookupResult Empty()
        {
            return new SingleLookupResult(LookupResultKind.Empty, null, null);
        }

        public static SingleLookupResult NotReferencable(DeclaredSymbol symbol, DiagnosticInfo error)
        {
            return new SingleLookupResult(LookupResultKind.NotReferencable, symbol, error);
        }

        public static SingleLookupResult StaticInstanceMismatch(DeclaredSymbol symbol, DiagnosticInfo error)
        {
            return new SingleLookupResult(LookupResultKind.StaticInstanceMismatch, symbol, error);
        }

        public static SingleLookupResult Inaccessible(DeclaredSymbol symbol, DiagnosticInfo error)
        {
            return new SingleLookupResult(LookupResultKind.Inaccessible, symbol, error);
        }

        public static SingleLookupResult NotInvocable(DeclaredSymbol unwrappedSymbol, DeclaredSymbol symbol, bool diagnose)
        {
            /*var diagInfo = diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_NonInvocableMemberCalled, unwrappedSymbol) : null;
            return new SingleLookupResult(LookupResultKind.NotInvocable, symbol, diagInfo);*/
            throw new NotImplementedException("TODO:MetaDslx");
        }

        public static SingleLookupResult NotLabel(DeclaredSymbol symbol, DiagnosticInfo error)
        {
            return new SingleLookupResult(LookupResultKind.NotLabel, symbol, error);
        }

        public static SingleLookupResult NotTypeOrNamespace(DeclaredSymbol symbol, DiagnosticInfo error)
        {
            return new SingleLookupResult(LookupResultKind.NotATypeOrNamespace, symbol, error);
        }

        public static SingleLookupResult NotTypeOrNamespace(DeclaredSymbol unwrappedSymbol, DeclaredSymbol symbol, bool diagnose)
        {
            // TODO: determine correct diagnosis 
            var diagInfo = diagnose ? new LanguageDiagnosticInfo(InternalErrorCode.ERR_BadSKknown, unwrappedSymbol.Name, unwrappedSymbol.GetKindText(), "type or namespace") : null;
            return new SingleLookupResult(LookupResultKind.NotATypeOrNamespace, symbol, diagInfo);
        }

        public static SingleLookupResult NotAnAttributeType(DeclaredSymbol symbol, DiagnosticInfo error)
        {
            return new SingleLookupResult(LookupResultKind.NotAnAttributeType, symbol, error);
        }

        public static SingleLookupResult WrongSymbol(DeclaredSymbol unwrappedSymbol, DeclaredSymbol symbol, ImmutableArray<Type> expectedTypes, bool diagnose)
        {
            var psb = PooledStringBuilder.GetInstance();
            var sb = psb.Builder;
            if (!expectedTypes.IsDefaultOrEmpty)
            {
                foreach (var type in expectedTypes)
                {
                    if (sb.Length > 0) sb.Append(", ");
                    sb.Append(type.Name);
                }
            }
            var modelSymbol = unwrappedSymbol as IModelSymbol;
            var diagInfo = diagnose ? new LanguageDiagnosticInfo(ModelErrorCode.ERR_BadModelObject, unwrappedSymbol.Name, modelSymbol?.ModelObjectType?.Name, sb.ToString()) : null;
            return new SingleLookupResult(LookupResultKind.WrongSymbol, symbol, diagInfo);
        }


        /// <summary>
        /// Set current result according to another.
        /// </summary>
        public void SetFrom(SingleLookupResult other)
        {
            _kind = other.Kind;
            _symbolList.Clear();
            _symbolList.Add(other.Symbol);
            _error = other.Error;
        }

        /// <summary>
        /// Set current result according to another.
        /// </summary>
        public void SetFrom(LookupResult other)
        {
            _kind = other._kind;
            _symbolList.Clear();
            _symbolList.AddRange(other._symbolList);
            _error = other._error;
        }

        public void SetFrom(DiagnosticInfo error)
        {
            this.Clear();
            _error = error;
        }

        // Merge another result with this one, with the current result being prioritized
        // over the other if they are of equal "goodness". Mutates the current result.
        public void MergePrioritized(LookupResult other)
        {
            if (other.Kind > Kind)
            {
                SetFrom(other);
            }
        }

        /// <summary>
        /// Merge another result with this one, with the symbols combined if both
        /// this and other are viable. Otherwise the highest priority result wins (this if equal 
        /// priority and non-viable.)
        /// </summary>
        public void MergeEqual(LookupResult other)
        {
            if (Kind > other.Kind)
            {
                return;
            }
            else if (other.Kind > Kind)
            {
                this.SetFrom(other);
            }
            else if (Kind != LookupResultKind.Viable)
            {
                // this makes the operator not symmetrical, but so far we do not care.
                // it is really a matter of which error gets reported.
                return;
            }
            else
            {
                // Merging two viable results together. We will always end up with at least two symbols.
                _symbolList.AddRange(other._symbolList);
            }
        }

        public void MergeEqual(SingleLookupResult result)
        {
            if (Kind > result.Kind)
            {
                // existing result is better
            }
            else if (result.Kind > Kind)
            {
                this.SetFrom(result);
            }
            else if ((object)result.Symbol != null)
            {
                // Same goodness. Include all symbols
                _symbolList.Add(result.Symbol);
            }
        }

        // global pool
        //TODO: consider if global pool is ok.
        private static readonly ObjectPool<LookupResult> s_poolInstance = CreatePool();

        // if someone needs to create a pool
        public static ObjectPool<LookupResult> CreatePool()
        {
            ObjectPool<LookupResult> pool = null;
            pool = new ObjectPool<LookupResult>(() => new LookupResult(pool), 128); // we rarely need more than 10
            return pool;
        }

        public static LookupResult GetInstance()
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
