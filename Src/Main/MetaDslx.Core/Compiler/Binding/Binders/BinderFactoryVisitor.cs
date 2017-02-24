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

namespace MetaDslx.Compiler.Binding.Binders
{
    public abstract class BinderFactoryVisitor : DetailedSyntaxVisitor<Binder> 
    {
        private readonly BinderFactory _binderFactory;
        private int _position;
        private bool _forChild;

        public BinderFactoryVisitor(BinderFactory binderFactory)
            : base(false, false)
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

        protected virtual Binder CreateRootBinderCore(Binder parentBinder, RedNode node, IMetaSymbol container)
        {
            return new RootBinder(parentBinder, node, container);
        }

        protected virtual Binder CreateBodyBinder(Binder parentBinder, RedNode node)
        {
            IMetaSymbol parentSymbol = parentBinder.ContainingSymbol;
            IMetaSymbol symbol = this.GetChildSymbol(null, node.Span, parentSymbol, null);
            if (symbol == null) return parentBinder;
            return this.CreateBodyBinderCore(parentBinder, node, symbol);
        }

        protected virtual Binder CreateBodyBinderCore(Binder parentBinder, RedNode node, IMetaSymbol container)
        {
            return new BodyBinder(parentBinder, node, container);
        }

        protected virtual Binder CreateSymbolBinder(Binder parentBinder, RedNode node, Type symbolType)
        {
            return this.CreateSymbolBinderCore(parentBinder, node, symbolType);
        }

        protected virtual Binder CreateSymbolBinderCore(Binder parentBinder, RedNode node, Type symbolType)
        {
            return new SymbolBinder(parentBinder, node, symbolType);
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
            return this.CreateSymbolUseBinderCore(parentBinder, node, symbolTypes);
        }

        protected virtual Binder CreateSymbolUseBinderCore(Binder parentBinder, RedNode node, ImmutableArray<Type> symbolTypes)
        {
            return new SymbolUseBinder(parentBinder, node, symbolTypes);
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
            return new IdentifierBinder(parentBinder, node, this.GetName(node));
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
            return this.CreateValueBinderCore(parentBinder, node, this.GetValue(node));
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
            return this.CreateEnumValueBinderCore(parentBinder, node, enumType, this.GetEnumLiteral(node, enumType));
        }

        protected virtual Binder CreateEnumValueBinderCore(Binder parentBinder, RedNode node, Type enumType, object value)
        {
            return new EnumValueBinder(parentBinder, node, enumType, value);
        }

        public virtual string GetName(RedNode node)
        {
            string valueStr = node.ToString();
            return valueStr;
        }

        public virtual object GetValue(RedNode node)
        {
            string valueStr = node.ToString();
            return this.GetValue(valueStr);
        }

        public virtual object GetValue(string value)
        {
            if (value == "null") return null;
            if (value.Length >= 3 && value.StartsWith("@\'") && value.EndsWith("\'"))
            {
                return value.Substring(2, value.Length - 3).Replace("\'\'", "\'");
            }
            else if (value.Length >= 2 && value.StartsWith("\'") && value.EndsWith("\'"))
            {
                return Regex.Unescape(value.Substring(1, value.Length - 2));
            }
            else if (value.Length >= 3 && value.StartsWith("@\"") && value.EndsWith("\""))
            {
                return value.Substring(2, value.Length - 3).Replace("\"\"", "\"");
            }
            else if (value.Length >= 2 && value.StartsWith("\"") && value.EndsWith("\""))
            {
                return Regex.Unescape(value.Substring(1, value.Length - 2));
            }
            bool boolValue;
            if (bool.TryParse(value, out boolValue))
            {
                return boolValue;
            }
            int intValue;
            if (int.TryParse(value, out intValue))
            {
                return intValue;
            }
            long longValue;
            if (long.TryParse(value, out longValue))
            {
                return longValue;
            }
            float floatValue;
            if (float.TryParse(value, out floatValue))
            {
                return floatValue;
            }
            double doubleValue;
            if (double.TryParse(value, out doubleValue))
            {
                return doubleValue;
            }
            return value;
        }

        public virtual object GetEnumLiteral(RedNode node, Type enumType)
        {
            string enumLiteralName = this.GetName(node);
            long enumLiteral;
            if (Enum.TryParse(enumLiteralName, out enumLiteral))
            {
                return enumLiteral;
            }
            return null;
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

        protected virtual IMetaSymbol GetContainingSymbol(Binder binder, RedNode node)
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

        protected virtual IMetaSymbol GetChildSymbol(string childName, TextSpan childSpan, IMetaSymbol container, Type kind)
        {
            if (container == null) return null;
            //container.MGet(CompilerAttachedProperties.PropertiesToMembersMapProperty);
            foreach (IMetaSymbol sym in container.MChildren)
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

        public override Binder VisitToken(SyntaxToken token)
        {
            return this.GetParentBinder(token);
        }
    }
}
