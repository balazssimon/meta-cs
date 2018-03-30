using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public abstract class BinderFactoryVisitor : SyntaxVisitor<Binder> 
    {
        private readonly BinderFactory _binderFactory;
        private int _position;
        private bool _forChild;

        public BinderFactoryVisitor(BinderFactory binderFactory)
        {
            _binderFactory = binderFactory;
        }

        public BinderFactory BinderFactory
        {
            get { return _binderFactory; }
        }

        public CompilationBase Compilation
        {
            get { return _binderFactory.Compilation; }
        }

        public SyntaxTree SyntaxTree
        {
            get { return _binderFactory.SyntaxTree; }
        }

        public int Position
        {
            get { return _position; }
        }

        public bool ForChild
        {
            get { return _forChild; }
        }

        public virtual void Reset(int position, bool forChild)
        {
            _position = position;
            _forChild = forChild;
        }

        protected virtual Binder CreateRootBinder(Binder parentBinder, RedNode node)
        {
            Binder outerBinder = parentBinder ?? this.BinderFactory.BuckStopsHereBinder;
            var parentSymbol = this.GetContainingSymbol(outerBinder, node);
            return this.CreateRootBinderCore(outerBinder, node, parentSymbol);
        }

        protected virtual Binder CreateRootBinderCore(Binder parentBinder, RedNode node, ISymbol container)
        {
            return new RootBinder(parentBinder, node, container);
        }

        protected virtual Binder CreateBodyBinder(Binder parentBinder, RedNode node)
        {
            return this.CreateBodyBinderCore(parentBinder, node);
        }

        protected virtual Binder CreateBodyBinderCore(Binder parentBinder, RedNode node)
        {
            return new ScopeBinder(parentBinder, node);
        }

        protected virtual Binder CreateSymbolDefBinder(Binder parentBinder, RedNode node, Type symbolType)
        {
            return this.CreateSymbolDefBinderCore(parentBinder, node, symbolType);
        }

        protected virtual Binder CreateSymbolDefBinderCore(Binder parentBinder, RedNode node, Type symbolType)
        {
            return new SymbolDefBinder(parentBinder, node, symbolType, symbolType);
        }

        protected virtual Binder CreateSymbolCtrBinder(Binder parentBinder, RedNode node, Type symbolType)
        {
            return this.CreateSymbolCtrBinderCore(parentBinder, node, symbolType);
        }

        protected virtual Binder CreateSymbolCtrBinderCore(Binder parentBinder, RedNode node, Type symbolType)
        {
            return new SymbolCtrBinder(parentBinder, node, symbolType);
        }

        protected virtual Binder CreateSymbolUseBinder(Binder parentBinder, RedNode node, ImmutableArray<Type> symbolTypes)
        {
            return this.CreateSymbolUseBinderCore(parentBinder, node, symbolTypes, ImmutableArray<Type>.Empty);
        }

        protected virtual Binder CreateSymbolUseBinderCore(Binder parentBinder, RedNode node, ImmutableArray<Type> symbolTypes, ImmutableArray<Type> nestingSymbolTypes)
        {
            return new SymbolUseBinder(parentBinder, node, symbolTypes, nestingSymbolTypes);
        }

        protected virtual Binder CreatePropertyBinder(Binder parentBinder, RedNode node, string name)
        {
            return this.CreatePropertyBinderCore(parentBinder, node, name, Optional<object>.None);
        }

        protected virtual Binder CreatePropertyBinder(Binder parentBinder, RedNode node, string name, object value)
        {
            return this.CreatePropertyBinderCore(parentBinder, node, name, new Optional<object>(value));
        }

        protected virtual Binder CreatePropertyBinderCore(Binder parentBinder, RedNode node, string name, Optional<object> valueOpt)
        {
            return new PropertyBinder(parentBinder, node, name, valueOpt);
        }

        protected virtual Binder CreateIdentifierBinder(Binder parentBinder, RedNode node)
        {
            return this.CreateIdentifierBinderCore(parentBinder, node);
        }

        protected virtual Binder CreateIdentifierBinderCore(Binder parentBinder, RedNode node)
        {
            return new IdentifierBinder(parentBinder, node, this.Compilation.SymbolResolution.GetName(node));
        }

        protected virtual Binder CreateQualifierBinder(Binder parentBinder, RedNode node)
        {
            return this.CreateQualifierBinderCore(parentBinder, node);
        }

        protected virtual Binder CreateQualifierBinderCore(Binder parentBinder, RedNode node)
        {
            return new QualifierBinder(parentBinder, node);
        }

        protected virtual Binder CreateNameBinder(Binder parentBinder, RedNode node)
        {
            return this.CreateNameBinderCore(parentBinder, node);
        }

        protected virtual Binder CreateNameBinderCore(Binder parentBinder, RedNode node)
        {
            return new NameBinder(parentBinder, node);
        }

        protected virtual Binder CreateValueBinder(Binder parentBinder, RedNode node)
        {
            return this.CreateValueBinderCore(parentBinder, node, this.Compilation.SymbolResolution.GetValue(node));
        }

        protected virtual Binder CreateValueBinder(Binder parentBinder, RedNode node, object value)
        {
            return this.CreateValueBinderCore(parentBinder, node, value);
        }

        protected virtual Binder CreateValueBinderCore(Binder parentBinder, RedNode node, object value)
        {
            return new ValueBinder(parentBinder, node, value);
        }

        protected virtual Binder CreateEnumValueBinder(Binder parentBinder, RedNode node, Type enumType)
        {
            return this.CreateEnumValueBinderCore(parentBinder, node, enumType, this.Compilation.SymbolResolution.GetEnumLiteral(node, enumType));
        }

        protected virtual Binder CreateEnumValueBinderCore(Binder parentBinder, RedNode node, Type enumType, object value)
        {
            return new EnumValueBinder(parentBinder, node, enumType, value);
        }

        protected virtual Binder GetParentBinder(RedNode node)
        {
            return this.BinderFactory.GetBinder(node.Parent, node.SpanStart);
        }

        protected virtual Binder GetContainingBinder(RedNode node)
        {
            Binder resultBinder;
            if (node.Parent == null)
            {
                resultBinder = null;
            }
            else
            {
                resultBinder = this._binderFactory.GetBinder(node.Parent);
            }
            return resultBinder;
        }

        protected virtual ISymbol GetContainingSymbol(Binder binder, RedNode node)
        {
            var container = binder.ContainingSymbol;
            if ((object)container == null)
            {
                if (node.Parent == null)
                {
                    if (this.SyntaxTree.Options.Kind != SourceCodeKind.Regular)
                    {
                        container = this.Compilation.ScriptSymbol;
                    }
                    else
                    {
                        container = this.Compilation.GlobalNamespace;
                    }
                }
            }
            return container;
        }

        protected virtual ISymbol GetChildSymbol(string childName, TextSpan childSpan, ISymbol container, Type kind)
        {
            if (container == null) return null;
            foreach (ISymbol sym in container.MGetMembers())
            {
                if (childName != null && sym.MName != childName)
                {
                    continue;
                }
                if (kind != null && sym.IsOfKind(kind))
                {
                    continue;
                }

                var syntaxReferences = (ImmutableArray<SyntaxReference>)sym.MGet(CompilerAttachedProperties.DeclaringSyntaxReferencesProperty);
                foreach (var reference in syntaxReferences)
                {
                    if (reference.SyntaxTree == this.SyntaxTree && reference.Span.OverlapsWith(childSpan))
                    {
                        return sym;
                    }
                }
            }
            return null;
        }

    }
}
