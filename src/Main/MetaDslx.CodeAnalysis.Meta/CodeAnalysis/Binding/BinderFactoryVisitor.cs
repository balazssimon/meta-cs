﻿using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public abstract class BinderFactoryVisitor : SyntaxVisitor<Binder>
    {
        private static object CompilationUnitScriptUsings = new object();
        private static object CompilationUnitUsings = new object();
        private static object CompilationUnitScript = new object();
        private static object Normal = new object();

        private readonly BinderFactory _factory;
        private int _position;
        private bool _forChild;

        protected BinderFactoryVisitor(BinderFactory factory)
        {
            _factory = factory;
        }

        internal void Initialize(int position, bool forChild)
        {
            _position = position;
            _forChild = forChild;
        }

        protected Language Language => _factory.Language;

        protected LanguageCompilation Compilation => _factory.Compilation;

        protected SyntaxTree SyntaxTree => _factory.SyntaxTree;

        protected BuckStopsHereBinder BuckStopsHereBinder => _factory.BuckStopsHereBinder;

        protected bool InScript => _factory.InScript;

        protected BinderFactory BinderFactory => _factory;

        protected int Position => _position;

        protected bool ForChild => _forChild;

        public override Binder DefaultVisit(SyntaxNode parent)
        {
            return VisitCore(parent.Parent);
        }

        // node, for which we are trying to find a binder is not supposed to be null
        // so we do not need to handle null in the Visit
        public override Binder Visit(SyntaxNode node)
        {
            return VisitCore(node);
        }

        //PERF: nonvirtual implementation of Visit
        protected Binder VisitCore(SyntaxNode node)
        {
            return ((LanguageSyntaxNode)node).Accept(this);
        }

        protected Binder VisitParent(SyntaxNode node)
        {
            _forChild = true;
            return VisitCore(node.Parent);
        }

        protected virtual Binder CreateScopeBinder(SyntaxNodeOrToken syntax, Binder parentBinder)
        {
            return this.CreateScopeBinderCore(syntax, parentBinder);
        }

        protected virtual Binder CreateScopeBinderCore(SyntaxNodeOrToken syntax, Binder parentBinder)
        {
            return new ScopeBinder(syntax, parentBinder);
        }

        protected virtual Binder CreateSymbolDefBinder(SyntaxNodeOrToken syntax, Binder parentBinder, Type type, string nestingProperty = null, bool merge = false)
        {
            return this.CreateSymbolDefBinderCore(syntax, parentBinder, type);
        }

        protected virtual Binder CreateSymbolDefBinderCore(SyntaxNodeOrToken syntax, Binder parentBinder, Type type)
        {
            return new SymbolDefBinder(syntax, parentBinder, type, type);
        }

        protected virtual Binder CreateSymbolUseBinder(SyntaxNodeOrToken syntax, Binder parentBinder, ImmutableArray<Type> types)
        {
            return this.CreateSymbolUseBinderCore(syntax, parentBinder, types, ImmutableArray<Type>.Empty);
        }

        protected virtual Binder CreateSymbolUseBinderCore(SyntaxNodeOrToken syntax, Binder parentBinder, ImmutableArray<Type> types, ImmutableArray<Type> nestingTypes)
        {
            return new SymbolUseBinder(syntax, parentBinder, types, nestingTypes);
        }

        protected virtual Binder CreateAttributeBinder(SyntaxNodeOrToken syntax, Binder parentBinder, ImmutableArray<Type> types)
        {
            return this.CreateAttributeBinderCore(syntax, parentBinder, types, ImmutableArray<Type>.Empty);
        }

        protected virtual Binder CreateAttributeBinderCore(SyntaxNodeOrToken syntax, Binder parentBinder, ImmutableArray<Type> types, ImmutableArray<Type> nestingTypes)
        {
            return new AttributeBinder(syntax, parentBinder, types, nestingTypes);
        }

        protected virtual Binder CreatePropertyBinder(SyntaxNodeOrToken syntax, Binder parentBinder, string name, SymbolPropertyOwner owner = SymbolPropertyOwner.CurrentSymbol, Type ownerType = null)
        {
            return this.CreatePropertyBinderCore(syntax, parentBinder, name, default, owner, ownerType);
        }

        protected virtual Binder CreatePropertyBinder(SyntaxNodeOrToken syntax, Binder parentBinder, string name, object value, SymbolPropertyOwner owner = SymbolPropertyOwner.CurrentSymbol, Type ownerType = null)
        {
            return this.CreatePropertyBinderCore(syntax, parentBinder, name, new Optional<object>(value), owner, ownerType);
        }

        protected virtual Binder CreatePropertyBinderCore(SyntaxNodeOrToken syntax, Binder parentBinder, string name, Optional<object> valueOpt, SymbolPropertyOwner owner, Type ownerType)
        {
            return new PropertyBinder(syntax, parentBinder, name, valueOpt, owner, ownerType);
        }

        protected virtual Binder CreateIdentifierBinder(SyntaxNodeOrToken syntax, Binder parentBinder)
        {
            return this.CreateIdentifierBinderCore(syntax, parentBinder);
        }

        protected virtual Binder CreateIdentifierBinderCore(SyntaxNodeOrToken syntax, Binder parentBinder)
        {
            return new IdentifierBinder(syntax, parentBinder);
        }

        protected virtual Binder CreateQualifierBinder(SyntaxNodeOrToken syntax, Binder parentBinder)
        {
            return this.CreateQualifierBinderCore(syntax, parentBinder);
        }

        protected virtual Binder CreateQualifierBinderCore(SyntaxNodeOrToken syntax, Binder parentBinder)
        {
            return new QualifierBinder(syntax, parentBinder);
        }

        protected virtual Binder CreateNameBinder(SyntaxNodeOrToken syntax, Binder parentBinder)
        {
            return this.CreateNameBinderCore(syntax, parentBinder);
        }

        protected virtual Binder CreateNameBinderCore(SyntaxNodeOrToken syntax, Binder parentBinder)
        {
            return new NameBinder(syntax, parentBinder);
        }

        protected virtual Binder CreateValueBinder(SyntaxNodeOrToken syntax, Binder parentBinder)
        {
            return this.CreateValueBinderCore(syntax, parentBinder, Language.SyntaxFacts.ExtractValue(syntax));
        }

        protected virtual Binder CreateValueBinder(SyntaxNodeOrToken syntax, Binder parentBinder, object value)
        {
            return this.CreateValueBinderCore(syntax, parentBinder, value);
        }

        protected virtual Binder CreateValueBinderCore(SyntaxNodeOrToken syntax, Binder parentBinder, object value)
        {
            return new ValueBinder(syntax, parentBinder, value);
        }

        protected virtual Binder CreateEnumValueBinder(SyntaxNodeOrToken syntax, Binder parentBinder, Type enumType)
        {
            return this.CreateEnumValueBinderCore(syntax, parentBinder, enumType);
        }

        protected virtual Binder CreateEnumValueBinderCore(SyntaxNodeOrToken syntax, Binder parentBinder, Type enumType)
        {
            return new EnumValueBinder(syntax, parentBinder, Language.SyntaxFacts.ExtractName(syntax), enumType);
        }

        protected Binder GetParentBinder(LanguageSyntaxNode node)
        {
            if (InScript && node.Kind == Language.SyntaxFacts.CompilationUnitKind)
            {
                // Although namespaces are not allowed in script code we still bind them so that we don't report useless errors.
                // A namespace in script code is not bound within the scope of a Script class, 
                // but still within scope of compilation unit extern aliases and usings.
                return GetCompilationUnitBinder(node, inUsing: false, inScript: false);
            }
            else
            {
                return VisitCore(node.Parent);
            }
        }

        public abstract Binder GetImportsBinder(LanguageSyntaxNode unit, bool inUsing);

        /// <summary>
        /// Returns true if containingNode has a child that contains the specified position
        /// and has kind UsingDirective.
        /// </summary>
        /// <remarks>
        /// Usings can't see other usings, so this is extra info when looking at a namespace
        /// or compilation unit scope.
        /// </remarks>
        protected bool IsInUsing(LanguageSyntaxNode containingNode)
        {
            TextSpan containingSpan = containingNode.Span;
            var syntaxFacts = Language.SyntaxFacts;

            SyntaxToken token;
            if (containingNode.Kind != syntaxFacts.CompilationUnitKind && _position == containingSpan.End)
            {
                // This occurs at EOF
                token = containingNode.GetLastToken();
                Debug.Assert(token == this.SyntaxTree.GetRoot().GetLastToken());
            }
            else if (_position < containingSpan.Start || _position > containingSpan.End) //NB: > not >=
            {
                return false;
            }
            else
            {
                token = containingNode.FindToken(_position);
            }

            var node = token.Parent;
            while (node != null && node != containingNode)
            {
                // ACASEY: the restriction that we're only interested in children
                // of containingNode (vs descendants) seems to be required for cases like
                // GetSemanticInfoTests.BindAliasQualifier, which binds an alias name
                // within a using directive.
                if (syntaxFacts.IsUsingDirective(node) && node.Parent == containingNode)
                {
                    return true;
                }

                node = node.Parent;
            }
            return false;
        }

        protected InContainerBinder GetCompilationUnitBinder(LanguageSyntaxNode compilationUnit, bool inUsing, bool inScript)
        {
            if (compilationUnit != SyntaxTree.GetRoot())
            {
                throw new ArgumentOutOfRangeException(nameof(compilationUnit), "node not part of tree");
            }

            var extraInfo = inUsing
                ? (inScript ? CompilationUnitScriptUsings : CompilationUnitUsings)
                : (inScript ? CompilationUnitScript : Normal);  // extra info for the cache.

            Binder result;
            if (!this.BinderFactory.TryGetBinder(compilationUnit, extraInfo, out result))
            {
                result = new SpecialSymbolBinder(null, this.BuckStopsHereBinder);

                if (inScript)
                {
                    LanguageCompilation compilation = this.Compilation;
                    Debug.Assert((object)compilation.ScriptClass != null);

                    //
                    // Binder chain in script/interactive code:
                    //
                    // + global imports
                    //   + current and previous submission imports (except using aliases)
                    //     + global namespace
                    //       + host object members
                    //         + previous submissions and corresponding using aliases
                    //           + script class members and using aliases
                    //

                    bool isSubmissionTree = compilation.IsSubmissionSyntaxTree(compilationUnit.SyntaxTree);
                    if (!isSubmissionTree)
                    {
                        result = result.WithAdditionalFlags(BinderFlags.InLoadedSyntaxTree);
                    }

                    // This is declared here so it can be captured.  It's initialized below.
                    InContainerBinder scriptClassBinder = null;

                    if (inUsing)
                    {
                        result = result.WithAdditionalFlags(BinderFlags.InScriptUsing);
                    }
                    else
                    {
                        result = new InContainerBinder(container: null, next: result, imports: compilation.GlobalImports);

                        // NB: This binder has a full Imports object, but only the non-alias imports are
                        // ever consumed.  Aliases are actually checked in scriptClassBinder (below).
                        // Note: #loaded trees don't consume previous submission imports.
                        result = compilation.PreviousSubmission == null || !isSubmissionTree
                            ? new InContainerBinder(result, basesBeingResolved => scriptClassBinder.GetImports(basesBeingResolved))
                            : new InContainerBinder(result, basesBeingResolved =>
                                compilation.GetPreviousSubmissionImports().Concat(scriptClassBinder.GetImports(basesBeingResolved)));
                    }

                    result = new InContainerBinder(compilation.GlobalNamespace, result);

                    if (compilation.HostObjectType != null)
                    {
                        result = new HostObjectModelBinder(result);
                    }

                    scriptClassBinder = new InContainerBinder(compilation.ScriptClass, result, compilationUnit, inUsing: inUsing);
                    result = scriptClassBinder;
                }
                else
                {
                    //
                    // Binder chain in regular code:
                    //
                    // + global namespace with top-level imports
                    // 
                    result = new InContainerBinder(Compilation.GlobalNamespace, result, compilationUnit, inUsing: inUsing);
                }
                this.BinderFactory.TryAddBinder(compilationUnit, extraInfo, ref result);
            }

            return (InContainerBinder)result;
        }


    }
}
