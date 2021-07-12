// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Collections;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    /// <summary>
    /// Represents a named type symbol whose members are declared in source.
    /// </summary>
    public partial class SourceNamedTypeSymbol
    {
        private SourceDeclaration _sourceDeclaration;
        private ImmutableArray<NamedTypeSymbol> _lazyDeclaredBases;
        private ImmutableArray<NamedTypeSymbol> _lazyBaseTypes;
        private ImmutableArray<(CompletionPart start, CompletionPart finish)> _phaseBinders;

        public virtual bool IsPartial => _declaration.Merge;

        #region Syntax

        public override bool IsScript => _declaration.IsScript;

        public override bool IsSubmission => _declaration.IsSubmission;

        public override bool IsImplicit => _declaration.IsImplicit;

        public override bool IsImplicitlyDeclared
        {
            get
            {
                return IsImplicit || IsScript || IsSubmission;
            }
        }

        public override string MetadataName => _declaration.MetadataName;

        public override bool MangleName => _declaration.Name != _declaration.MetadataName;

        protected SourceDeclaration SourceDeclaration
        {
            get
            {
                if (_sourceDeclaration == null)
                {
                    Interlocked.CompareExchange(ref _sourceDeclaration, new SourceDeclaration(this, _declaration), null);
                }
                return _sourceDeclaration;
            }
        }

        public override LexicalSortKey GetLexicalSortKey()
        {
            return this.SourceDeclaration.GetLexicalSortKey();
        }

        #endregion

        #region members

        public override IEnumerable<string> MemberNames => this.SourceDeclaration.MemberNames;

        #endregion

        public virtual void EnsureSymbolDefinitionsNoted()
        {
            // TODO:MetaDslx
        }

        public override void CheckMembers(Dictionary<string, ImmutableArray<DeclaredSymbol>> result, DiagnosticBag diagnostics)
        {
            // TODO:MetaDslx
        }

        /// <summary>
        /// Gets the set of interfaces that this type directly implements. This set does not include
        /// interfaces that are base interfaces of directly implemented interfaces.
        /// </summary>
        public override ImmutableArray<NamedTypeSymbol> GetBaseTypesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved)
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
            if (_lazyDeclaredBases.IsDefault)
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

            foreach (var decl in this.MergedDeclaration.Declarations)
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
            var result = ArrayBuilder<NamedTypeSymbol>.GetInstance();
            var symbolFacts = Language.SymbolFacts;
            foreach (var prop in symbolFacts.GetPropertiesForSymbol(this.ModelObject, SymbolConstants.DeclaredBaseTypesProperty))
            {
                var baseTypeObjects = symbolFacts.GetPropertyValues(this.ModelObject, prop);
                if (baseTypeObjects != null)
                {
                    var baseTypeSymbols = SymbolFactory.ResolveSymbols(baseTypeObjects.Where(bto => bto != null));
                    foreach (var value in baseTypeSymbols)
                    {
                        var symbol = value as NamedTypeSymbol;
                        if (symbol != null)
                        {
                            result.Add(symbol);
                        }
                        else
                        {
                            diagnostics.Add(ModelErrorCode.ERR_InvalidBaseType, Location.None, value); // TODO: MetaDslx location
                        }
                    }
                }
            }
            return result.ToImmutableAndFree();
        }

        protected virtual void CheckBaseTypes(DiagnosticBag diagnostics)
        {
            // TODO: MetaDslx
        }
    }
}
