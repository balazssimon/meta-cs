﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// A <see cref="MissingAssemblySymbol"/> is a special kind of <see cref="AssemblySymbol"/> that represents
    /// an assembly that couldn't be found.
    /// </summary>
    public class MissingAssemblySymbol : AssemblySymbol
    {
        protected readonly AssemblyIdentity identity;
        protected readonly MissingModuleSymbol moduleSymbol;

        private ImmutableArray<ModuleSymbol> _lazyModules;

        public MissingAssemblySymbol(AssemblyIdentity identity)
        {
            Debug.Assert(identity != null);
            this.identity = identity;
            moduleSymbol = new MissingModuleSymbol(this, 0);
        }

        public sealed override bool IsMissing
        {
            get
            {
                return true;
            }
        }

        public override AssemblyIdentity Identity
        {
            get
            {
                return identity;
            }
        }

        public override ImmutableArray<ModuleSymbol> Modules
        {
            get
            {
                if (_lazyModules.IsDefault)
                {
                    _lazyModules = ImmutableArray.Create<ModuleSymbol>(moduleSymbol);
                }

                return _lazyModules;
            }
        }

        public override int GetHashCode()
        {
            return identity.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MissingAssemblySymbol);
        }

        public bool Equals(MissingAssemblySymbol other)
        {
            if ((object)other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return identity.Equals(other.Identity);
        }

        public override ImmutableArray<Location> Locations
        {
            get
            {
                return ImmutableArray<Location>.Empty;
            }
        }

        public sealed override NamespaceSymbol GlobalNamespace
        {
            get
            {
                return this.moduleSymbol.GlobalNamespace;
            }
        }

        public override ICollection<string> TypeNames
        {
            get
            {
                return SpecializedCollections.EmptyCollection<string>();
            }
        }

        public override ICollection<string> NamespaceNames
        {
            get
            {
                return SpecializedCollections.EmptyCollection<string>();
            }
        }

        public override bool MightContainExtensionMethods
        {
            get
            {
                return false;
            }
        }

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public override AssemblyMetadata GetMetadata() => null;

        public override NamedTypeSymbol GetDeclaredSpecialType(SpecialType type)
        {
            return null;
        }

        public override NamedTypeSymbol GetTypeByMetadataName(string fullyQualifiedMetadataName)
        {
            return null;
        }

        public override bool GivesAccessTo(IAssemblySymbol toAssembly)
        {
            return false;
        }

        internal override NamedTypeSymbol LookupTopLevelMetadataTypeWithCycleDetection(ref MetadataTypeName emittedName, ConsList<AssemblySymbol> visitedAssemblies, bool digThroughForwardedTypes)
        {
            return null;
        }
    }
}
