// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using MetaDslx.CodeAnalysis.Symbols.Source;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// A <see cref="MissingModuleSymbol"/> is a special kind of <see cref="ModuleSymbol"/> that represents
    /// a module that couldn't be found.
    /// </summary>
    internal class MissingModuleSymbol : ModuleSymbol
    {
        protected readonly AssemblySymbol assembly;
        protected readonly int ordinal;
        protected readonly MissingNamespaceSymbol globalNamespace;

        public MissingModuleSymbol(AssemblySymbol assembly, int ordinal)
        {
            Debug.Assert((object)assembly != null);
            Debug.Assert(ordinal >= -1);

            this.assembly = assembly;
            this.ordinal = ordinal;
            globalNamespace = new MissingNamespaceSymbol(this);
        }

        public sealed override bool IsError => true;

        public override SymbolFactory SymbolFactory => null;

        public override int Ordinal
        {
            get
            {
                return ordinal;
            }
        }

        public override Machine Machine
        {
            get
            {
                return Machine.I386;
            }
        }

        public override bool Bit32Required
        {
            get
            {
                return false;
            }
        }

        public sealed override bool IsMissing
        {
            get
            {
                return true;
            }
        }

        public override string Name
        {
            get
            {
                // Once we switch to a non-hardcoded name, GetHashCode/Equals should be adjusted.
                return "<Missing Module>";
            }
        }

        public override AssemblySymbol ContainingAssembly
        {
            get
            {
                return assembly;
            }
        }

        public override Symbol ContainingSymbol
        {
            get
            {
                return assembly;
            }
        }

        public override NamespaceSymbol GlobalNamespace
        {
            get
            {
                return globalNamespace;
            }
        }

        public override int GetHashCode()
        {
            return assembly.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            MissingModuleSymbol other = obj as MissingModuleSymbol;

            return (object)other != null && assembly.Equals(other.assembly);
        }

        public override ImmutableArray<Location> Locations => ImmutableArray<Location>.Empty;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;


        public override ICollection<string> NamespaceNames
        {
            get
            {
                return SpecializedCollections.EmptyCollection<string>();
            }
        }

        public override ICollection<string> TypeNames
        {
            get
            {
                return SpecializedCollections.EmptyCollection<string>();
            }
        }

        public override NamedTypeSymbol LookupTopLevelMetadataType(ref MetadataTypeName emittedName)
        {
            return new MissingMetadataTypeSymbol.TopLevel(this, ref emittedName);
        }

        public override ImmutableArray<AssemblyIdentity> ReferencedAssemblies => ImmutableArray<AssemblyIdentity>.Empty;

        public override ImmutableArray<AssemblySymbol> ReferencedAssemblySymbols => ImmutableArray<AssemblySymbol>.Empty;

        internal override void SetReferences(ModuleReferences<AssemblySymbol> moduleReferences, SourceAssemblySymbol originatingSourceAssemblyDebugOnly)
        {
            throw ExceptionUtilities.Unreachable;
        }

        public override bool HasUnifiedReferences
        {
            get { return false; }
        }

        public override bool GetUnificationUseSiteDiagnostic(ref DiagnosticInfo result, TypeSymbol dependentType)
        {
            throw ExceptionUtilities.Unreachable;
        }

        internal override bool HasAssemblyCompilationRelaxationsAttribute
        {
            get { return false; }
        }

        internal override bool HasAssemblyRuntimeCompatibilityAttribute
        {
            get { return false; }
        }

        internal override CharSet? DefaultMarshallingCharSet
        {
            get { return null; }
        }

        public override ModuleMetadata GetMetadata() => null;
    }

    internal sealed class MissingModuleSymbolWithName : MissingModuleSymbol
    {
        private readonly string _name;

        public MissingModuleSymbolWithName(AssemblySymbol assembly, string name)
            : base(assembly, ordinal: -1)
        {
            Debug.Assert(name != null);

            _name = name;
        }

        public override string Name
        {
            get
            {
                return _name;
            }
        }

        public override int GetHashCode()
        {
            return Hash.Combine(assembly.GetHashCode(), StringComparer.OrdinalIgnoreCase.GetHashCode(_name));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            MissingModuleSymbolWithName other = obj as MissingModuleSymbolWithName;

            return (object)other != null && assembly.Equals(other.assembly) && string.Equals(_name, other._name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
