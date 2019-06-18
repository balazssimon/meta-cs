using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class SourceNamedTypeSymbol : SourceMemberContainerTypeSymbol
    {
        private ImmutableArray<NamedTypeSymbol> _lazyDeclaredBases;
        private ImmutableArray<NamedTypeSymbol> _lazyBaseTypes;

        public SourceNamedTypeSymbol(NamespaceOrTypeSymbol containingSymbol, MergedDeclaration declaration, DiagnosticBag diagnostics)
            : base(containingSymbol, declaration, diagnostics)
        {
            Debug.Assert(!declaration.IsImplicit && !declaration.IsSubmission && !declaration.IsScript);
        }

        public override SymbolKind Kind => SymbolKind.NamedType;

        /// <summary>
        /// Gets the set of interfaces that this type directly implements. This set does not include
        /// interfaces that are base interfaces of directly implemented interfaces.
        /// </summary>
        public sealed override ImmutableArray<NamedTypeSymbol> GetBaseTypesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved)
        {
            if (_lazyBaseTypes.IsDefault)
            {
                if (basesBeingResolved != null && basesBeingResolved.ContainsReference(this.OriginalDefinition))
                {
                    return ImmutableArray<NamedTypeSymbol>.Empty;
                }

                var diagnostics = DiagnosticBag.GetInstance();
                var acyclicBaseTypes = MakeAcyclicBaseTypes(basesBeingResolved, diagnostics);
                if (ImmutableInterlocked.InterlockedInitialize(ref _lazyBaseTypes, acyclicBaseTypes))
                {
                    AddDeclarationDiagnostics(diagnostics);
                }
                diagnostics.Free();
            }

            return _lazyBaseTypes;
        }

        private ImmutableArray<NamedTypeSymbol> MakeAcyclicBaseTypes(ConsList<TypeSymbol> basesBeingResolved, DiagnosticBag diagnostics)
        {
            var declaredBaseTypes = GetDeclaredBaseTypes(basesBeingResolved: basesBeingResolved);
            ArrayBuilder<NamedTypeSymbol> result = ArrayBuilder<NamedTypeSymbol>.GetInstance();
            foreach (var t in declaredBaseTypes)
            {
                if (BaseTypeAnalysis.TypeDependsOn(depends: t, on: this))
                {
                    result.Add(new ExtendedErrorTypeSymbol(t, LookupResultKind.NotReferencable,
                        diagnostics.Add(InternalErrorCode.ERR_CycleInInterfaceInheritance, Locations[0], this, t)));
                    continue;
                }
                else
                {
                    result.Add(t);
                }

                HashSet<DiagnosticInfo> useSiteDiagnostics = null;

                if (t.DeclaringCompilation != this.DeclaringCompilation)
                {
                    t.AddUseSiteDiagnostics(ref useSiteDiagnostics);

                    foreach (var @interface in t.AllBaseTypesNoUseSiteDiagnostics)
                    {
                        if (@interface.DeclaringCompilation != this.DeclaringCompilation)
                        {
                            @interface.AddUseSiteDiagnostics(ref useSiteDiagnostics);
                        }
                    }
                }

                if (!useSiteDiagnostics.IsNullOrEmpty())
                {
                    diagnostics.Add(Locations[0], useSiteDiagnostics);
                }
            }

            return result.ToImmutableAndFree();
        }

        protected ImmutableArray<NamedTypeSymbol> GetDeclaredBases(ConsList<TypeSymbol> basesBeingResolved)
        {
            if (ReferenceEquals(_lazyDeclaredBases, null))
            {
                var diagnostics = DiagnosticBag.GetInstance();
                if (ImmutableInterlocked.InterlockedInitialize(ref _lazyDeclaredBases, MakeDeclaredBases(basesBeingResolved, diagnostics)))
                {
                    AddDeclarationDiagnostics(diagnostics);
                }
                diagnostics.Free();
            }

            return _lazyDeclaredBases;
        }

        public override ImmutableArray<NamedTypeSymbol> GetDeclaredBaseTypes(ConsList<TypeSymbol> basesBeingResolved)
        {
            return GetDeclaredBases(basesBeingResolved);
        }

        private ImmutableArray<NamedTypeSymbol> MakeDeclaredBases(ConsList<TypeSymbol> basesBeingResolved, DiagnosticBag diagnostics)
        {
            Debug.Assert(basesBeingResolved == null || !basesBeingResolved.ContainsReference(this.OriginalDefinition));
            var newBasesBeingResolved = basesBeingResolved.Prepend(this.OriginalDefinition);
            var baseTypes = ArrayBuilder<NamedTypeSymbol>.GetInstance();
            var baseTypeLocations = PooledDictionary<NamedTypeSymbol, Location>.GetInstance();

            foreach (var decl in _declaration.Declarations)
            {
                ImmutableArray<NamedTypeSymbol> partBaseTypes = ResolveBaseTypes(newBasesBeingResolved, decl, diagnostics);
                if (partBaseTypes.IsEmpty) continue;

                foreach (var t in partBaseTypes)
                {
                    if (!baseTypeLocations.ContainsKey(t))
                    {
                        baseTypes.Add(t);
                        baseTypeLocations.Add(t, decl.NameLocation);
                    }
                }
            }

            HashSet<DiagnosticInfo> useSiteDiagnostics = null;
            var baseTypesRO = baseTypes.ToImmutableAndFree();
            this.CheckDeclaredBaseTypes(baseTypesRO, baseTypeLocations, diagnostics, ref useSiteDiagnostics);
            baseTypeLocations.Free();
            diagnostics.Add(Locations[0], useSiteDiagnostics);

            return baseTypesRO;
        }

        protected virtual void CheckDeclaredBaseTypes(ImmutableArray<NamedTypeSymbol> baseTypes, PooledDictionary<NamedTypeSymbol, Location> baseTypeLocations, DiagnosticBag diagnostics, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {

        }

        // process the base list for one part of a partial class, or for the only part of any other type declaration.
        protected virtual ImmutableArray<NamedTypeSymbol> ResolveBaseTypes(ConsList<TypeSymbol> newBasesBeingResolved, SingleDeclaration decl, DiagnosticBag diagnostics)
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        protected override void CheckBaseTypes(DiagnosticBag diagnostics)
        {
            
        }
    }
}