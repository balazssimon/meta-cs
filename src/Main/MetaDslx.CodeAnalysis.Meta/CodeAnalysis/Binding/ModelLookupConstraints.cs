using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class ModelLookupConstraints : LookupConstraints
    {
        public readonly ImmutableArray<ModelObjectDescriptor> Kinds;

        public ModelLookupConstraints(
            string name = null,
            string metadataName = null,
            ImmutableArray<ModelObjectDescriptor> kinds = default,
            NamespaceOrTypeSymbol qualifierOpt = null,
            ConsList<TypeSymbol> basesBeingResolved = null,
            Binder originalBinder = null,
            TypeSymbol accessThroughType = null,
            LookupOptions options = LookupOptions.Default,
            bool diagnose = true,
            HashSet<DiagnosticInfo> useSiteDiagnostics = null)
            : base(name, metadataName, qualifierOpt, basesBeingResolved, originalBinder, accessThroughType, options, diagnose, useSiteDiagnostics)
        {
            Kinds = kinds;
        }

        protected virtual LookupConstraints Update(
            string name,
            string metadataName,
            ImmutableArray<ModelObjectDescriptor> kinds,
            NamespaceOrTypeSymbol qualifierOpt,
            ConsList<TypeSymbol> basesBeingResolved,
            Binder originalBinder,
            TypeSymbol accessThroughType,
            LookupOptions options,
            bool diagnose,
            HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            if (!ReferenceEquals(qualifierOpt, this.QualifierOpt) || name != this.Name || metadataName != this.MetadataName ||
                kinds != this.Kinds || !ReferenceEquals(basesBeingResolved, this.BasesBeingResolved) || !ReferenceEquals(originalBinder, this.OriginalBinder) ||
                !ReferenceEquals(accessThroughType, this.AccessThroughType) ||
                options != this.Options || diagnose != this.Diagnose || !ReferenceEquals(useSiteDiagnostics, this.UseSiteDiagnostics))
            {
                return new ModelLookupConstraints(name, metadataName, kinds, qualifierOpt, basesBeingResolved, originalBinder, accessThroughType, options, diagnose, useSiteDiagnostics);
            }
            return this;
        }

        protected override LookupConstraints Update(string name, string metadataName, NamespaceOrTypeSymbol qualifierOpt, ConsList<TypeSymbol> basesBeingResolved, Binder originalBinder, TypeSymbol accessThroughType, LookupOptions options, bool diagnose, HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return this.Update(name, metadataName,this.Kinds, qualifierOpt, basesBeingResolved, originalBinder, accessThroughType, options, diagnose, useSiteDiagnostics);
        }

        public override bool IsViable(Symbol symbol)
        {
            var modelSymbol = symbol as IModelSymbol;
            if (modelSymbol == null) return false;
            if (Kinds.IsDefault) return true;
            if (Kinds.IsEmpty) return true;
            return Kinds.Any(st => st.ImmutableType.IsAssignableFrom(modelSymbol.ModelSymbolInfo.ImmutableType));
        }
    }
}
