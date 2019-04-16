// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Collections;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal partial class SourceNamedTypeSymbol
    {
        private Tuple<NamedTypeSymbol, ImmutableArray<NamedTypeSymbol>> _lazyDeclaredBases;

        private NamedTypeSymbol _lazyBaseType = ErrorTypeSymbol.UnknownResultType;
        private ImmutableArray<NamedTypeSymbol> _lazyInterfaces;

        /// <summary>
        /// Gets the BaseType of this type. If the base type could not be determined, then 
        /// an instance of ErrorType is returned. If this kind of type does not have a base type
        /// (for example, interfaces), null is returned. Also the special class System.Object
        /// always has a BaseType of null.
        /// </summary>
        internal sealed override NamedTypeSymbol BaseTypeNoUseSiteDiagnostics
        {
            get
            {
                if (ReferenceEquals(_lazyBaseType, ErrorTypeSymbol.UnknownResultType))
                {
                    // force resolution of bases in containing type
                    // to make base resolution errors more deterministic
                    if ((object)ContainingType != null)
                    {
                        var tmp = ContainingType.BaseTypeNoUseSiteDiagnostics;
                    }

                    var diagnostics = DiagnosticBag.GetInstance();
                    var acyclicBase = this.MakeAcyclicBaseType(diagnostics);
                    if (ReferenceEquals(Interlocked.CompareExchange(ref _lazyBaseType, acyclicBase, ErrorTypeSymbol.UnknownResultType), ErrorTypeSymbol.UnknownResultType))
                    {
                        AddDeclarationDiagnostics(diagnostics);
                    }
                    diagnostics.Free();
                }

                return _lazyBaseType;
            }
        }

        /// <summary>
        /// Gets the set of interfaces that this type directly implements. This set does not include
        /// interfaces that are base interfaces of directly implemented interfaces.
        /// </summary>
        internal sealed override ImmutableArray<NamedTypeSymbol> InterfacesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved)
        {
            if (_lazyInterfaces.IsDefault)
            {
                if (basesBeingResolved != null && basesBeingResolved.ContainsReference(this.OriginalDefinition))
                {
                    return ImmutableArray<NamedTypeSymbol>.Empty;
                }

                var diagnostics = DiagnosticBag.GetInstance();
                var acyclicInterfaces = MakeAcyclicInterfaces(basesBeingResolved, diagnostics);
                if (ImmutableInterlocked.InterlockedCompareExchange(ref _lazyInterfaces, acyclicInterfaces, default(ImmutableArray<NamedTypeSymbol>)).IsDefault)
                {
                    AddDeclarationDiagnostics(diagnostics);
                }
                diagnostics.Free();
            }

            return _lazyInterfaces;
        }

        protected override void CheckBase(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        protected override void CheckInterfaces(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal Tuple<NamedTypeSymbol, ImmutableArray<NamedTypeSymbol>> GetDeclaredBases(ConsList<TypeSymbol> basesBeingResolved)
        {
            if (ReferenceEquals(_lazyDeclaredBases, null))
            {
                var diagnostics = DiagnosticBag.GetInstance();
                if (Interlocked.CompareExchange(ref _lazyDeclaredBases, MakeDeclaredBases(basesBeingResolved, diagnostics), null) == null)
                {
                    AddDeclarationDiagnostics(diagnostics);
                }
                diagnostics.Free();
            }

            return _lazyDeclaredBases;
        }

        internal override NamedTypeSymbol GetDeclaredBaseType(ConsList<TypeSymbol> basesBeingResolved)
        {
            return GetDeclaredBases(basesBeingResolved).Item1;
        }

        internal override ImmutableArray<NamedTypeSymbol> GetDeclaredInterfaces(ConsList<TypeSymbol> basesBeingResolved)
        {
            return GetDeclaredBases(basesBeingResolved).Item2;
        }

        private Tuple<NamedTypeSymbol, ImmutableArray<NamedTypeSymbol>> MakeDeclaredBases(ConsList<TypeSymbol> basesBeingResolved, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private static CSharpSyntaxNode GetBaseListOpt(SingleTypeDeclaration decl)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        // process the base list for one part of a partial class, or for the only part of any other type declaration.
        private Tuple<NamedTypeSymbol, ImmutableArray<NamedTypeSymbol>> MakeOneDeclaredBases(ConsList<TypeSymbol> newBasesBeingResolved, SingleTypeDeclaration decl, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Returns true if the type cannot be used as an explicit base class.
        /// </summary>
        private static bool IsRestrictedBaseType(SpecialType specialType)
        {
            switch (specialType)
            {
                case SpecialType.System_Array:
                case SpecialType.System_Enum:
                case SpecialType.System_Delegate:
                case SpecialType.System_MulticastDelegate:
                case SpecialType.System_ValueType:
                    return true;
            }

            return false;
        }

        private ImmutableArray<NamedTypeSymbol> MakeAcyclicInterfaces(ConsList<TypeSymbol> basesBeingResolved, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private NamedTypeSymbol MakeAcyclicBaseType(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }
    }
}
