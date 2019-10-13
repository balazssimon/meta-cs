using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class LookupConstraints
    {
        public readonly NamespaceOrTypeSymbol QualifierOpt;
        public readonly string Name;
        public readonly string MetadataName;
        public readonly ImmutableArray<ModelObjectDescriptor> Kinds;
        public readonly ConsList<TypeSymbol> BasesBeingResolved;
        public readonly LookupOptions Options;
        public readonly bool Diagnose;
        public readonly Binder OriginalBinder;
        public readonly TypeSymbol AccessThroughType;
        public HashSet<DiagnosticInfo> UseSiteDiagnostics;

        public LookupConstraints(
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
        {
            QualifierOpt = qualifierOpt;
            Name = name;
            MetadataName = metadataName ?? name;
            Kinds = kinds;
            BasesBeingResolved = basesBeingResolved;
            OriginalBinder = originalBinder;
            AccessThroughType = accessThroughType;
            Options = options;
            Diagnose = diagnose;
            UseSiteDiagnostics = useSiteDiagnostics;
        }

        public virtual LookupConstraints Update(
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
                return new LookupConstraints(name, metadataName, kinds, qualifierOpt, basesBeingResolved, originalBinder, accessThroughType, options, diagnose, useSiteDiagnostics);
            }
            return this;
        }

        public LookupConstraints WithName(string name, string metadataName = null)
        {
            return Update(name, metadataName ?? name, this.Kinds, this.QualifierOpt, this.BasesBeingResolved, this.OriginalBinder, this.AccessThroughType, this.Options, this.Diagnose, this.UseSiteDiagnostics);
        }

        public LookupConstraints WithQualifier(NamespaceOrTypeSymbol qualifierOpt)
        {
            return Update(this.Name, this.MetadataName, this.Kinds, qualifierOpt, this.BasesBeingResolved, this.OriginalBinder, this.AccessThroughType, this.Options, this.Diagnose, this.UseSiteDiagnostics);
        }

        public LookupConstraints WithOptions(LookupOptions options)
        {
            return Update(this.Name, this.MetadataName, this.Kinds, this.QualifierOpt, this.BasesBeingResolved, this.OriginalBinder, this.AccessThroughType, options, this.Diagnose, this.UseSiteDiagnostics);
        }

        public LookupConstraints WithDiagnose(bool diagnose)
        {
            return Update(this.Name, this.MetadataName, this.Kinds, this.QualifierOpt, this.BasesBeingResolved, this.OriginalBinder, this.AccessThroughType, this.Options, diagnose, this.UseSiteDiagnostics);
        }

        public LookupConstraints WithDiagnoseAndOriginalBinder(bool diagnose, Binder originalBinder)
        {
            return Update(this.Name, this.MetadataName, this.Kinds, this.QualifierOpt, this.BasesBeingResolved, originalBinder, this.AccessThroughType, this.Options, diagnose, this.UseSiteDiagnostics);
        }

        public LookupConstraints WithOriginalBinder(Binder originalBinder)
        {
            return Update(this.Name, this.MetadataName, this.Kinds, this.QualifierOpt, this.BasesBeingResolved, originalBinder, this.AccessThroughType, this.Options, this.Diagnose, this.UseSiteDiagnostics);
        }

        public LookupConstraints WithUseSiteDiagnostics(HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return Update(this.Name, this.MetadataName, this.Kinds, this.QualifierOpt, this.BasesBeingResolved, this.OriginalBinder, this.AccessThroughType, this.Options, this.Diagnose, useSiteDiagnostics);
        }

        public LookupConstraints WithAccessThroughType(TypeSymbol accessThroughType)
        {
            return Update(this.Name, this.MetadataName, this.Kinds, this.QualifierOpt, this.BasesBeingResolved, this.OriginalBinder, accessThroughType, this.Options, this.Diagnose, this.UseSiteDiagnostics);
        }

        public LookupConstraints WithQualifierAndAccessThroughType(NamespaceOrTypeSymbol qualifierOpt, TypeSymbol accessThroughType)
        {
            return Update(this.Name, this.MetadataName, this.Kinds, qualifierOpt, this.BasesBeingResolved, this.OriginalBinder, accessThroughType, this.Options, this.Diagnose, this.UseSiteDiagnostics);
        }

        public virtual bool AreValid()
        {
            return this.Options.AreValid();
        }

        public bool IsMemberLookup
        {
            get { return (object)this.QualifierOpt != null; }
        }

        public bool CanConsiderMembers()
        {
            return this.Options.CanConsiderMembers();
        }

        public bool CanConsiderLocals()
        {
            return this.Options.CanConsiderLocals();
        }

        public bool CanConsiderTypes()
        {
            return this.Options.CanConsiderTypes();
        }

        public bool CanConsiderNamespaces()
        {
            return this.Options.CanConsiderNamespaces();
        }

        public bool IsAttributeTypeLookup()
        {
            return this.Options.IsAttributeTypeLookup();
        }

        public bool IsVerbatimNameAttributeTypeLookup()
        {
            return this.Options.IsVerbatimNameAttributeTypeLookup();
        }
    }
}
