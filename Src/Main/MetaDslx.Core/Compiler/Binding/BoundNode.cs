using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.Compiler.Binding
{
    public class BoundNode
    {
        private const int IsBoundFlag = 1 << 0;
        private const int HasErrorsFlag = 1 << 1;
        private const int CompilerGeneratedFlag = 1 << 2;
#if DEBUG
        /// <summary>
        /// Captures the fact that consumers of the node already checked the state of the WasCompilerGenerated bit.
        /// Allows to assert on attempts to set WasCompilerGenerated bit after that.
        /// </summary>
        private const int WasCompilerGeneratedIsCheckedFlag = 1 << 3;
#endif

        private readonly int _kind;
        private readonly RedNode _redNode;
        private readonly BoundTree _boundTree;
        private int _attributes;

        public BoundNode(int kind, RedNode redNode, BoundTree boundTree)
        {
            Debug.Assert(redNode != null);

            _kind = kind;
            _redNode = redNode;
            _boundTree = boundTree;
        }

        public BoundNode(int kind, RedNode redNode, BoundTree boundTree, bool hasErrors) 
            : this(kind, redNode, boundTree)
        {
            if (hasErrors)
            {
                _attributes = BoundNode.HasErrorsFlag;
            }
        }

        public RedNode RedNode
        {
            get { return _redNode; }
        }

        public BoundNode Parent
        {
            get
            {
                return this.Compilation.Bind(_redNode.Parent);
            }
        }

        /// <summary>
        /// Determines if a bound node, or associated syntax or type has an error (not a warning) 
        /// diagnostic associated with it.
        /// 
        /// Typically used in the binder as a way to prevent cascading errors. 
        /// In most other cases a more lightweight HasErrors should be used.
        /// </summary>
        public virtual bool HasAnyErrors
        {
            get
            {
                // NOTE: check Syntax rather than WasCompilerGenerated because sequence points can have null syntax.
                return (this.HasErrors || this.RedNode != null && this.RedNode.HasErrors);
            }
        }

        /// <summary>
        /// Determines if a bound node, or any child, grandchild, etc has an error (not warning)
        /// diagnostic associated with it. The HasError bit is initially set for a node by providing it
        /// to the node constructor. If any child nodes of a node have
        /// the HasErrors bit set, then it is automatically set to true on the parent bound node.
        /// 
        /// HasErrors indicates that the tree is not emittable and used to short-circuit lowering/emit stages.
        /// NOTE: not having HasErrors does not guarantee that we do not have any diagnostic associated
        ///       with corresponding syntax or type.
        /// </summary>
        public bool HasErrors
        {
            get
            {
                return (_attributes & BoundNode.HasErrorsFlag) != 0;
            }
        }

        public SyntaxTree SyntaxTree
        {
            get
            {
                var syntax = RedNode;
                return syntax == null ? null : syntax.SyntaxTree;
            }
        }

        public BoundTree BoundTree
        {
            get { return _boundTree; }
        }

        public CompilationBase Compilation
        {
            get { return _boundTree.Compilation; }
        }

        /// <remarks>
        /// NOTE: not generally set in rewriters.
        /// </remarks>
        public bool WasCompilerGenerated
        {
            get
            {
#if DEBUG
                _attributes |= BoundNode.WasCompilerGeneratedIsCheckedFlag;
#endif
                return (_attributes & BoundNode.CompilerGeneratedFlag) != 0;
            }
            internal set
            {
#if DEBUG
                Debug.Assert((_attributes & BoundNode.WasCompilerGeneratedIsCheckedFlag) == 0,
                    "compiler generated flag should not be set after reading it");
#endif

                if (value)
                {
                    _attributes |= BoundNode.CompilerGeneratedFlag;
                }
                else
                {
                    Debug.Assert((_attributes & BoundNode.CompilerGeneratedFlag) == 0,
                        "compiler generated flag should not be reset here");
                }
            }
        }

        // PERF: it is very uncommon for a flag being forcibly reset 
        //       so we do not support it in general (making the commonly used implementation simpler) 
        //       and instead have a special method to do resetting.
        public void ResetCompilerGenerated(bool newCompilerGenerated)
        {
#if DEBUG
            Debug.Assert((_attributes & BoundNode.WasCompilerGeneratedIsCheckedFlag) == 0,
                "compiler generated flag should not be set after reading it");
#endif
            if (newCompilerGenerated)
            {
                _attributes |= BoundNode.CompilerGeneratedFlag;
            }
            else
            {
                _attributes &= ~BoundNode.CompilerGeneratedFlag;
            }
        }

        public int RawKind
        {
            get { return _kind; }
        }

        public TBinder GetBinder<TBinder>()
            where TBinder : class
        {
            return this.Binder.GetBinder<TBinder>();
        }

        public ImmutableArray<Binder> Binders
        {
            get { return this.Compilation.GetBinders(this.RedNode); }
        }

        public Binder ParentBinder
        {
            get
            {
                return this.Parent?.Binder ?? (Binder)this.Compilation.GetDefaultBinder<IBinder>();
            }
        }

        public Binder TopBinder
        {
            get
            {
                var binders = this.Binders;
                if (binders.Length > 0) return binders[0];
                else return this.ParentBinder;
            }
        }

        public Binder Binder
        {
            get
            {
                var binders = this.Binders;
                if (binders.Length > 0) return binders[binders.Length - 1];
                else return this.ParentBinder;
            }
        }

        public Lazy<TValue> GetSingleValue<TValue>(Action<LookupResult<TValue>> selector)
        {
            return new Lazy<TValue>(() => this.GetSingleValueLazy(selector));
        }

        private TValue GetSingleValueLazy<TValue>(Action<LookupResult<TValue>> selector)
        {
            LookupResult<TValue> lookupResult = LookupResult<TValue>.GetInstance();
            try
            {
                selector(lookupResult);
                return lookupResult.GetSingleResultOrDefault();
            }
            finally
            {
                lookupResult.Free();
            }
        }

        public Lazy<ImmutableArray<TValue>> GetMultipleValues<TValue>(Action<LookupResult<TValue>> selector)
        {
            return new Lazy<ImmutableArray<TValue>>(() => this.GetMultipleValuesLazy(selector));
        }

        private ImmutableArray<TValue> GetMultipleValuesLazy<TValue>(Action<LookupResult<TValue>> selector)
        {
            LookupResult<TValue> lookupResult = LookupResult<TValue>.GetInstance();
            try
            {
                selector(lookupResult);
                return lookupResult.GetResults();
            }
            finally
            {
                lookupResult.Free();
            }
        }
    }
}
