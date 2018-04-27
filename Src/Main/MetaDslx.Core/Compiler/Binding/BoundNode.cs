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
        private readonly ImmutableArray<Binder> _binders;
        private int _attributes;

        public BoundNode(int kind, RedNode redNode, BoundTree boundTree, ImmutableArray<Binder> binders)
        {
            Debug.Assert(redNode != null);

            _kind = kind;
            _redNode = redNode;
            _boundTree = boundTree;
            _binders = binders;
        }

        public BoundNode(int kind, RedNode redNode, BoundTree boundTree, ImmutableArray<Binder> binders, bool hasErrors) 
            : this(kind, redNode, boundTree, binders)
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

        public ImmutableArray<Binder> Binders
        {
            get { return _binders; }
        }

        internal Binder TopBinder
        {
            get
            {
                if (_binders.Length > 0) return _binders[0];
                else return this.Compilation.GetBinder(this.RedNode.Parent);
            }
        }

        internal Binder BottomBinder
        {
            get
            {
                if (_binders.Length > 0) return _binders[_binders.Length - 1];
                else return this.Compilation.GetBinder(this.RedNode.Parent);
            }
        }

        internal Binder Binder
        {
            get
            {
                return this.BottomBinder;
            }
        }

        public void Bind(BoundTree boundTree, ImmutableArray<Binder> binders)
        {
            int oldAttributes = _attributes;
            if (Interlocked.Exchange(ref _attributes, _attributes | BoundNode.IsBoundFlag) == oldAttributes)
            {
                foreach (var binder in _binders)
                {
                    binder.InternalBind(this);
                }
            }
        }

        public Binder GetPreviousBinderInNode(Binder binder)
        {
            int index = this.Binders.IndexOf(binder);
            if (index + 1 < this.Binders.Length)
            {
                return this.Binders[index + 1];
            }
            return null;
        }

        public bool ExecuteCurrent<TBinder>(Func<TBinder, bool> action)
            where TBinder : class
        {
            return this.ExecuteCurrent(this.TopBinder, action);
        }

        public bool ExecuteCurrent<TBinder>(Binder binder, Func<TBinder, bool> action)
            where TBinder : class
        {
            int index = this.Binders.IndexOf(binder);
            while (index >= 0)
            {
                IBinder currentBinder = this.Binders[index];
                if (this.TryExecute(currentBinder, action))
                {
                    return true;
                }
                --index;
            }
            return false;
        }

        public bool ExecuteCurrentOrInherited<TBinder>(Func<TBinder, bool> action)
            where TBinder : class
        {
            return this.ExecuteInherited<TBinder>(this.Binder, action);
        }

        public bool ExecuteInherited<TBinder>(Func<TBinder, bool> action)
            where TBinder : class
        {
            return this.ExecuteInherited<TBinder>(this.Parent.BottomBinder, action);
        }

        public bool ExecuteInherited<TBinder>(Binder binder, Func<TBinder, bool> action)
            where TBinder : class
        {
            if (binder == null)
            {
                return false;
            }
            IBinder currentBinder = binder;
            while (currentBinder != null)
            {
                if (this.TryExecute(currentBinder, action))
                {
                    return true;
                }
                currentBinder = currentBinder.Next;
            }
            return false;
        }

        public bool ExecuteCurrentOrSynthesized<TBinder>(Func<TBinder, bool> action)
            where TBinder : class
        {
            return this.ExecuteCurrentOrSynthesized<TBinder>(this.TopBinder, action);
        }

        public bool ExecuteSynthesized<TBinder>(Func<TBinder, bool> action)
            where TBinder : class
        {
            return this.ExecuteCurrentOrSynthesized<TBinder>(null, action);
        }

        public bool ExecuteCurrentOrSynthesized<TBinder>(Binder binder, Func<TBinder, bool> action)
            where TBinder : class
        {
            if (binder != null)
            {
                int index = this.Binders.IndexOf(binder);
                if (index >= 0)
                {
                    while (index < this.Binders.Length)
                    {
                        if (this.TryExecute(this.Binders[index], action))
                        {
                            return true;
                        }
                        ++index;
                    }
                }
            }
            bool success = false;
            Stack<RedNode> nodeStack = new Stack<RedNode>();
            nodeStack.Push(this.RedNode);
            while (nodeStack.Count > 0)
            {
                RedNode currentNode = nodeStack.Pop();
                bool stop = false;
                if (currentNode != this.RedNode)
                {
                    var binders = this.Compilation.Bind(currentNode).Binders;
                    for (int i = 0; i < binders.Length; i++)
                    {
                        if (this.TryExecute(binders[i], action))
                        {
                            stop = true;
                            success = true;
                        }
                    }
                }
                if (!stop && (currentNode is SyntaxNode))
                {
                    foreach (var child in ((SyntaxNode)currentNode).ChildNodesAndTokens())
                    {
                        nodeStack.Push(child);
                    }
                }
            }
            return success;
        }

        public Lazy<TValue> GetCurrentLazy<TBinder, TValue>(Func<TBinder, Optional<TValue>> selector)
            where TBinder : class
        {
            return new Lazy<TValue>(() => this.GetCurrent(selector));
        }

        public TValue GetCurrent<TBinder, TValue>(Func<TBinder, Optional<TValue>> selector)
            where TBinder : class
        {
            TValue result;
            this.TryGetCurrent(selector, out result);
            return result;
        }

        public bool TryGetCurrent<TBinder, TValue>(Func<TBinder, Optional<TValue>> selector, out TValue value)
            where TBinder : class
        {
            int index = this.Binders.Length - 1;
            while (index >= 0)
            {
                IBinder currentBinder = this.Binders[index];
                if (this.TryGetValue(currentBinder, selector, out value))
                {
                    return true;
                }
                --index;
            }
            value = default(TValue);
            return false;
        }

        public Lazy<TValue> GetCurrentOrInheritedLazy<TBinder, TValue>(Func<TBinder, Optional<TValue>> selector)
            where TBinder : class
        {
            return new Lazy<TValue>(() => this.GetCurrentOrInherited(selector));
        }

        public TValue GetCurrentOrInherited<TBinder, TValue>(Func<TBinder, Optional<TValue>> selector)
            where TBinder : class
        {
            TValue result;
            this.TryGetInherited(this.Binder, selector, out result);
            return result;
        }

        public Lazy<TValue> GetInheritedLazy<TBinder, TValue>(Func<TBinder, Optional<TValue>> selector)
            where TBinder : class
        {
            return new Lazy<TValue>(() => this.GetInherited(selector));
        }

        public TValue GetInherited<TBinder, TValue>(Func<TBinder, Optional<TValue>> selector)
            where TBinder : class
        {
            TValue result;
            this.TryGetInherited(this.Parent.BottomBinder, selector, out result);
            return result;
        }

        public TValue GetInherited<TBinder, TValue>(Binder binder, Func<TBinder, Optional<TValue>> selector)
            where TBinder : class
        {
            TValue result;
            this.TryGetInherited(binder, selector, out result);
            return result;
        }

        public bool TryGetInherited<TBinder,TValue>(Binder binder, Func<TBinder,Optional<TValue>> selector, out TValue value)
            where TBinder: class
        {
            if (binder == null)
            {
                value = default(TValue);
                return false;
            }
            IBinder currentBinder = binder;
            while (currentBinder != null)
            {
                if (this.TryGetValue(currentBinder, selector, out value))
                {
                    return true;
                }
                currentBinder = currentBinder.Next;
            }
            value = default(TValue);
            return false;
        }

        public Lazy<ImmutableArray<TValue>> GetCurrentOrSynthesizedLazy<TBinder, TValue>(Func<TBinder, Optional<TValue>> selector)
            where TBinder : class
        {
            return new Lazy<ImmutableArray<TValue>>(() => this.GetCurrentOrSynthesized(selector));
        }

        public ImmutableArray<TValue> GetCurrentOrSynthesized<TBinder, TValue>(Func<TBinder, Optional<TValue>> selector)
            where TBinder : class
        {
            ImmutableArray<TValue> result;
            this.TryGetSynthesized(this.TopBinder, selector, out result);
            return result;
        }

        public Lazy<ImmutableArray<TValue>> GetSynthesizedLazy<TBinder, TValue>(Func<TBinder, Optional<TValue>> selector)
            where TBinder : class
        {
            return new Lazy<ImmutableArray<TValue>>(() => this.GetSynthesized(selector));
        }

        public ImmutableArray<TValue> GetSynthesized<TBinder, TValue>(Func<TBinder, Optional<TValue>> selector)
            where TBinder : class
        {
            ImmutableArray<TValue> result;
            this.TryGetSynthesized(null, selector, out result);
            return result;
        }

        public ImmutableArray<TValue> GetSynthesized<TBinder, TValue>(Binder binder, Func<TBinder, Optional<TValue>> selector)
            where TBinder : class
        {
            ImmutableArray<TValue> result;
            this.TryGetSynthesized(binder, selector, out result);
            return result;
        }

        public bool TryGetSynthesized<TBinder, TValue>(Binder binder, Func<TBinder, Optional<TValue>> selector, out ImmutableArray<TValue> values)
            where TBinder : class
        {
            ArrayBuilder<TValue> valuesBuilder = ArrayBuilder<TValue>.GetInstance();
            try
            {
                if (binder != null)
                {
                    int index = this.Binders.IndexOf(binder);
                    if (index >= 0)
                    {
                        while (index < this.Binders.Length)
                        {
                            TValue value;
                            if (this.TryGetValue(this.Binders[index], selector, out value))
                            {
                                valuesBuilder.Add(value);
                                return true;
                            }
                            ++index;
                        }
                    }
                }
                Stack<RedNode> nodeStack = new Stack<RedNode>();
                nodeStack.Push(this.RedNode);
                while(nodeStack.Count > 0)
                {
                    RedNode currentNode = nodeStack.Pop();
                    bool added = false;
                    if (currentNode != this.RedNode)
                    {
                        var binders = this.Compilation.Bind(currentNode).Binders;
                        for (int i = 0; i < binders.Length; i++)
                        {
                            TValue value;
                            if (this.TryGetValue(binders[i], selector, out value))
                            {
                                valuesBuilder.Add(value);
                                added = true;
                            }
                        }
                    }
                    if (!added && (currentNode is SyntaxNode))
                    {
                        foreach (var child in ((SyntaxNode)currentNode).ChildNodesAndTokens())
                        {
                            nodeStack.Push(child);
                        }
                    }
                }
                values = valuesBuilder.ToImmutable();
                return values.Length > 0;
            }
            finally
            {
                valuesBuilder.Free();
            }
        }

        private bool TryExecute<TBinder>(IBinder binder, Func<TBinder, bool> action)
            where TBinder : class
        {
            TBinder typedBinder = binder as TBinder;
            if (typedBinder != null)
            {
                return action(typedBinder);
            }
            return false;
        }

        private bool TryGetValue<TBinder, TValue>(IBinder binder, Func<TBinder, Optional<TValue>> selector, out TValue value)
            where TBinder : class
        {
            TBinder typedBinder = binder as TBinder;
            if (typedBinder != null)
            {
                var result = selector(typedBinder);
                if (result.HasValue)
                {
                    value = result.Value;
                    return true;
                }
            }
            value = default(TValue);
            return false;
        }
    }
}
