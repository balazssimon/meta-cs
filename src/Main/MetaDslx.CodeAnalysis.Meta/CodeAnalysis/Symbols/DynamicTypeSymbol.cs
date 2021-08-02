using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(SymbolParts = SymbolParts.None, ModelObjectOption = ParameterOption.Disabled)]
    public sealed partial class DynamicTypeSymbol : TypeSymbol
    {
        internal static readonly DynamicTypeSymbol Instance = new DynamicTypeSymbol();

        private DynamicTypeSymbol()
        {
        }

        public override string Name => "dynamic";

        public override bool IsReferenceType => true;

        public override ImmutableArray<Location> Locations => ImmutableArray<Location>.Empty;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public override ImmutableArray<NamedTypeSymbol> BaseTypes => ImmutableArray<NamedTypeSymbol>.Empty;

        public override bool IsStatic => false;

        public override bool IsValueType => false;

        public sealed override bool IsReadOnly => false;

        public sealed override ObsoleteAttributeData? ObsoleteAttributeData
        {
            get { return null; }
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return visitor.VisitDynamicType(this, argument);
        }

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitDynamicType(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitDynamicType(this);
        }

        public override Symbol? ContainingSymbol
        {
            get
            {
                return null;
            }
        }

        public override Accessibility DeclaredAccessibility
        {
            get
            {
                return Accessibility.NotApplicable;
            }
        }

        public override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            return false;
        }

        public override int GetHashCode()
        {
            // return the distinguished value for 'object' because the hash code ignores the distinction
            // between dynamic and object.  It also ignores custom modifiers.
            return (int)Microsoft.CodeAnalysis.SpecialType.System_Object;
        }

        public override bool Equals(TypeSymbol? t2, TypeCompareKind comparison)
        {
            if ((object?)t2 == null)
            {
                return false;
            }

            if (ReferenceEquals(this, t2) || t2 is DynamicTypeSymbol)
            {
                return true;
            }

            if ((comparison & TypeCompareKind.IgnoreDynamic) != 0)
            {
                var other = t2 as NamedTypeSymbol;
                return (object?)other != null && other.SpecialType == Microsoft.CodeAnalysis.SpecialType.System_Object;
            }

            return false;
        }

    }
}
