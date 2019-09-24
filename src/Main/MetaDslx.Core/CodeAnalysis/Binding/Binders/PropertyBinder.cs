using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class PropertyBinder : Binder
    {
        private readonly string _propertyName;
        private readonly Optional<object> _propertyValueOpt;
        private ImmutableArray<object> _lazyValues;
        private SymbolPropertyOwner _owner;
        private Type _ownerType;

        public PropertyBinder(Binder next, string propertyName, Optional<object> propertyValueOpt, SymbolPropertyOwner owner, Type ownerType)
            : base(next)
        {
            _propertyName = propertyName;
            _propertyValueOpt = propertyValueOpt;
            _owner = owner;
            _ownerType = ownerType;
            if (_propertyValueOpt.HasValue)
            {
                _lazyValues = ImmutableArray.Create(_propertyValueOpt.Value);
            }
            else
            {
                _lazyValues = default(ImmutableArray<object>);
            }
        }

        public override DeclaredSymbol GetDeclarationSymbol()
        {
            switch (_owner)
            {
                case SymbolPropertyOwner.CurrentSymbol:
                    return this.GetParentDeclaredSymbol();
                case SymbolPropertyOwner.CurrentScope:
                    return this.GetParentDeclaredScope();
                case SymbolPropertyOwner.AncestorSymbol:
                    return this.GetAncestorDeclaredSymbol();
                case SymbolPropertyOwner.AncestorScope:
                    return this.GetAncestorDeclaredScope();
                default:
                    throw new NotImplementedException();
            }
        }

        private DeclaredSymbol GetParentDeclaredSymbol()
        {
            var current = this.Next;
            while (current != null)
            {
                if (current is SymbolDefBinder symbolDefBinder)
                {
                    var result = symbolDefBinder.LastDeclaredSymbol;
                    if (result != null) return result;
                    else break;
                }
                current = current.Next;
            }
            return (NamespaceOrTypeSymbol)this.Compilation.CreateErrorNamespaceSymbol(this.Compilation.GlobalNamespace, string.Empty);
        }

        private DeclaredSymbol GetParentDeclaredScope()
        {
            var current = this.Next;
            while (current != null)
            {
                if (current is ScopeBinder scopeBinder)
                {
                    var result = scopeBinder.DeclaredSymbol;
                    if (result != null) return result;
                    else break;
                }
                current = current.Next;
            }
            return (NamespaceOrTypeSymbol)this.Compilation.CreateErrorNamespaceSymbol(this.Compilation.GlobalNamespace, string.Empty);
        }

        private DeclaredSymbol GetAncestorDeclaredSymbol()
        {
            var current = this.Next;
            while (current != null)
            {
                if (current is SymbolDefBinder symbolDefBinder)
                {
                    var result = symbolDefBinder.LastDeclaredSymbol;
                    if (result != null && (_ownerType == null || _ownerType.IsAssignableFrom(result.GetType())))
                    {
                        return result;
                    }
                }
                current = current.Next;
            }
            return (NamespaceOrTypeSymbol)this.Compilation.CreateErrorNamespaceSymbol(this.Compilation.GlobalNamespace, string.Empty);
        }

        private DeclaredSymbol GetAncestorDeclaredScope()
        {
            var current = this.Next;
            while (current != null)
            {
                if (current is ScopeBinder scopeBinder)
                {
                    var result = scopeBinder.DeclaredSymbol;
                    if (result != null && (_ownerType == null || _ownerType.IsAssignableFrom(result.GetType())))
                    {
                        return result;
                    }
                }
                current = current.Next;
            }
            return (NamespaceOrTypeSymbol)this.Compilation.CreateErrorNamespaceSymbol(this.Compilation.GlobalNamespace, string.Empty);
        }
    }
}
