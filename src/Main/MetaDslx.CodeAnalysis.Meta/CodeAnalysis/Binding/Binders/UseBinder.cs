using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.CSharp;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class UseBinder : Binder
    {
        private readonly ImmutableArray<Type> _types;
        private readonly string _autoPrefix;
        private readonly string _autoSuffix;

        public UseBinder(Binder next, SyntaxNodeOrToken syntax, ImmutableArray<Type> types, string autoPrefix, string autoSuffix)
            : base(next, syntax)
        {
            _types = types;
            _autoPrefix = autoPrefix;
            _autoSuffix = autoSuffix;
        }

        protected override LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            LookupConstraints result = base.AdjustConstraints(constraints);
            if (!_types.IsEmpty)
            {
                if (!string.IsNullOrEmpty(_autoPrefix) || !string.IsNullOrEmpty(_autoSuffix)) result = result.WithAutomaticName(_autoPrefix, _autoSuffix);
                result = result.WithAdditionalValidators(this);
            }
            return result;
        }

        protected override bool IsViable(DeclaredSymbol symbol, LookupConstraints constraints)
        {
            if (_types.IsDefaultOrEmpty) return true;
            if (symbol is MergedNamespaceSymbol mns)
            {
                if (_types.Any(t => t.IsAssignableFrom(mns.GetType()))) return true;
                foreach (var ns in mns.ConstituentNamespaces)
                {
                    if (ns is IModelSymbol nms)
                    {
                        var mtype = nms.ModelObjectType;
                        return mtype != null && _types.Any(t => t.IsAssignableFrom(mtype));
                    }
                }
                return false;
            }
            else if (symbol is CSharpNamedTypeSymbol cnts)
            {
                var cntsFullName = cnts.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                var cntsBases = cnts.AllBaseTypesNoUseSiteDiagnostics;
                foreach (var type in _types)
                {
                    var fullName = "global::"+type.FullName;
                    if (cntsFullName == fullName) return true;
                    foreach (var cntsBase in cntsBases)
                    {
                        var cntsBaseFullName = cntsBase.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                        if (cntsBaseFullName == fullName) return true;
                    }
                }
                return _types.Any(t => t == typeof(Type));
            }
            if (symbol is IModelSymbol ms)
            {
                var mtype = ms.ModelObjectType;
                return mtype != null && _types.Any(t => t.IsAssignableFrom(mtype));
            }
            return false;
        }

        public override string ToString()
        {
            return $"Use: {string.Join(", ", _types.Select(t => t.Name))}";
        }
    }
}
