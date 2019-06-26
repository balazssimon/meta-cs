﻿using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding
{
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public abstract class BoundNode
    {
        private const int NotCompleted = 0;
        private const int Completing = 1;
        private const int Completed = 2;

        private int _completionState;

        private readonly BoundKind _kind;
        private BoundNodeAttributes _attributes;
        private readonly BoundTree _boundTree;
        private ImmutableArray<BoundNode> _childBoundNodes;
        private readonly LanguageSyntaxNode _syntax;

        [Flags()]
        private enum BoundNodeAttributes : byte
        {
            HasErrors = 1 << 0,
            CompilerGenerated = 1 << 1,
#if DEBUG
            /// <summary>
            /// Captures the fact that consumers of the node already checked the state of the WasCompilerGenerated bit.
            /// Allows to assert on attempts to set WasCompilerGenerated bit after that.
            /// </summary>
            WasCompilerGeneratedIsChecked = 1 << 2,
#endif
            IsSuppressed = 1 << 4,
        }

        protected BoundNode(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors)
        {
            Debug.Assert(syntax != null);

            _kind = kind;
            _boundTree = boundTree;
            _childBoundNodes = childBoundNodes;
            _syntax = syntax;

            if (hasErrors)
            {
                _attributes = BoundNodeAttributes.HasErrors;
            }
        }

        public Language Language => _syntax.Language;

        public BoundTree BoundTree => _boundTree;

        protected LanguageCompilation Compilation => _boundTree.Compilation;

        protected MutableModel ModelBuilder => _boundTree.ModelBuilder;

        protected DiagnosticBag DiagnosticBag => _boundTree.DiagnosticBag;

        public LanguageSyntaxNode Syntax => _syntax;


        /// <summary>
        /// Determines if a bound node, or associated syntax or type has an error (not a warning) 
        /// diagnostic associated with it.
        /// 
        /// Typically used in the binder as a way to prevent cascading errors. 
        /// In most other cases a more lightweight HasErrors should be used.
        /// </summary>
        public bool HasAnyErrors
        {
            get
            {
                // NOTE: check Syntax rather than WasCompilerGenerated because sequence points can have null syntax.
                if (this.HasErrors || _syntax != null && _syntax.HasErrors)
                {
                    return true;
                }
                var expression = this as BoundExpression;
                return expression?.Type?.IsErrorType() == true;
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
        public bool HasErrors => (_attributes & BoundNodeAttributes.HasErrors) != 0;

        public SyntaxTree SyntaxTree => _syntax?.SyntaxTree;

        protected void CopyAttributes(BoundNode original)
        {
            this.WasCompilerGenerated = original.WasCompilerGenerated;

            Debug.Assert(original is BoundExpression || !original.IsSuppressed);
            this.IsSuppressed = original.IsSuppressed;
        }

        /// <remarks>
        /// NOTE: not generally set in rewriters.
        /// </remarks>
        public bool WasCompilerGenerated
        {
            get
            {
#if DEBUG
                _attributes |= BoundNodeAttributes.WasCompilerGeneratedIsChecked;
#endif
                return (_attributes & BoundNodeAttributes.CompilerGenerated) != 0;
            }
            internal set
            {
#if DEBUG
                Debug.Assert((_attributes & BoundNodeAttributes.WasCompilerGeneratedIsChecked) == 0,
                    "compiler generated flag should not be set after reading it");
#endif

                if (value)
                {
                    _attributes |= BoundNodeAttributes.CompilerGenerated;
                }
                else
                {
                    Debug.Assert((_attributes & BoundNodeAttributes.CompilerGenerated) == 0,
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
            Debug.Assert((_attributes & BoundNodeAttributes.WasCompilerGeneratedIsChecked) == 0,
                "compiler generated flag should not be set after reading it");
#endif
            if (newCompilerGenerated)
            {
                _attributes |= BoundNodeAttributes.CompilerGenerated;
            }
            else
            {
                _attributes &= ~BoundNodeAttributes.CompilerGenerated;
            }
        }

        public bool IsSuppressed
        {
            get
            {
                return (_attributes & BoundNodeAttributes.IsSuppressed) != 0;
            }
            protected set
            {
                Debug.Assert((_attributes & BoundNodeAttributes.IsSuppressed) == 0, "flag should not be set twice or reset");
                if (value)
                {
                    _attributes |= BoundNodeAttributes.IsSuppressed;
                }
            }
        }

        public BoundKind Kind => _kind;

        public ImmutableArray<BoundNode> ChildBoundNodes => _childBoundNodes;

        public virtual BoundNode Accept(BoundTreeVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public void ForceComplete(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            if (Interlocked.CompareExchange(ref _completionState, Completing, NotCompleted) == NotCompleted)
            {
                foreach (var child in this.ChildBoundNodes)
                {
                    child.ForceComplete(cancellationToken);
                }
                this.ForceCompleteNode(cancellationToken);
                Interlocked.CompareExchange(ref _completionState, Completed, Completing);
            }
        }

        protected virtual void ForceCompleteNode(CancellationToken cancellationToken)
        {

        }

        public Binder GetBinder()
        {
            return this.Compilation.GetBinder(_syntax);
        }

        public Binder GetEnclosingBinder()
        {
            return this.BoundTree.GetEnclosingBinder(_syntax);
        }

        public ImmutableArray<BoundIdentifier> GetIdentifiers()
        {
            ArrayBuilder<BoundIdentifier> identifiers = ArrayBuilder<BoundIdentifier>.GetInstance();
            this.AddIdentifiers(identifiers);
            return identifiers.ToImmutableAndFree();
        }

        public ImmutableArray<BoundQualifier> GetQualifiers()
        {
            ArrayBuilder<BoundQualifier> qualifiers = ArrayBuilder<BoundQualifier>.GetInstance();
            this.AddQualifiers(qualifiers);
            return qualifiers.ToImmutableAndFree();
        }

        public ImmutableArray<BoundName> GetNames()
        {
            ArrayBuilder<BoundName> names = ArrayBuilder<BoundName>.GetInstance();
            this.AddNames(names);
            return names.ToImmutableAndFree();
        }

        public ImmutableArray<BoundProperty> GetProperties(string property = null)
        {
            ArrayBuilder<BoundProperty> properties = ArrayBuilder<BoundProperty>.GetInstance();
            this.AddProperties(properties, property);
            return properties.ToImmutableAndFree();
        }

        public ImmutableArray<BoundValues> GetValues(string currentProperty = null, string rootProperty = null)
        {
            ArrayBuilder<BoundValues> values = ArrayBuilder<BoundValues>.GetInstance();
            this.AddValues(values, currentProperty, rootProperty);
            return values.ToImmutableAndFree();
        }

        public ImmutableArray<BoundIdentifier> GetChildIdentifiers()
        {
            ArrayBuilder<BoundIdentifier> identifiers = ArrayBuilder<BoundIdentifier>.GetInstance();
            foreach (var child in _childBoundNodes)
            {
                child.AddIdentifiers(identifiers);
            }
            return identifiers.ToImmutableAndFree();
        }

        public ImmutableArray<BoundQualifier> GetChildQualifiers()
        {
            ArrayBuilder<BoundQualifier> qualifiers = ArrayBuilder<BoundQualifier>.GetInstance();
            foreach (var child in _childBoundNodes)
            {
                child.AddQualifiers(qualifiers);
            }
            return qualifiers.ToImmutableAndFree();
        }

        public ImmutableArray<BoundName> GetChildNames()
        {
            ArrayBuilder<BoundName> names = ArrayBuilder<BoundName>.GetInstance();
            foreach (var child in _childBoundNodes)
            {
                child.AddNames(names);
            }
            return names.ToImmutableAndFree();
        }

        public ImmutableArray<BoundProperty> GetChildProperties(string property = null)
        {
            ArrayBuilder<BoundProperty> properties = ArrayBuilder<BoundProperty>.GetInstance();
            foreach (var child in _childBoundNodes)
            {
                child.AddProperties(properties, property);
            }
            return properties.ToImmutableAndFree();
        }

        public ImmutableArray<BoundValues> GetChildValues(string currentProperty = null, string rootProperty = null)
        {
            ArrayBuilder<BoundValues> values = ArrayBuilder<BoundValues>.GetInstance();
            foreach (var child in _childBoundNodes)
            {
                child.AddValues(values, currentProperty, rootProperty);
            }
            return values.ToImmutableAndFree();
        }

        public virtual void AddIdentifiers(ArrayBuilder<BoundIdentifier> identifiers)
        {
        }

        public virtual void AddQualifiers(ArrayBuilder<BoundQualifier> qualifiers)
        {
        }

        public virtual void AddNames(ArrayBuilder<BoundName> names)
        {
        }

        public virtual void AddProperties(ArrayBuilder<BoundProperty> properties, string property = null)
        {
        }

        public virtual void AddValues(ArrayBuilder<BoundValues> values, string currentProperty = null, string rootProperty = null)
        {
        }

#if true //DEBUG
        private class BoundTreeDumper
        {
            private BoundTreeDumper() : base() { }

            public static string Dump(BoundNode node)
            {
                StringBuilder sb = new StringBuilder();
                Dump(sb, string.Empty, node);
                return sb.ToString();
            }

            private static void Dump(StringBuilder sb, string indent, BoundNode node)
            {
                if (node == null) return;
                sb.AppendFormat("{0}{1}Syntax (Bound{2}) -> {3}", indent, node.Syntax.Kind, node.Kind, node);
                sb.AppendLine();
                foreach (var child in node.ChildBoundNodes)
                {
                    Dump(sb, indent + "  ", child);
                }
            }
        }

        public virtual string Dump()
        {
            return BoundTreeDumper.Dump(this);
        }
#endif

        internal string GetDebuggerDisplay()
        {
            var result = GetType().Name;
            if (Syntax != null)
            {
                result += " " + Syntax.ToString();
            }
            return result;
        }

    }
}