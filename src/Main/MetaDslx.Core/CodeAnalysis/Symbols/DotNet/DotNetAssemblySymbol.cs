using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    internal sealed class DotNetAssemblySymbol : AssemblySymbol
    {
        private Microsoft.CodeAnalysis.CSharp.Symbols.AssemblySymbol _assembly;
        private ImmutableArray<ModuleSymbol> _lazyModules;

        private DotNetAssemblySymbol(Microsoft.CodeAnalysis.CSharp.Symbols.AssemblySymbol assembly)
        {
            Debug.Assert(assembly != null);
        }

        internal DotNetAssemblySymbol Create(Microsoft.CodeAnalysis.CSharp.Symbols.AssemblySymbol assembly)
        {
            return new DotNetAssemblySymbol(assembly);
        }

        public IAssemblySymbol CSharpAssembly => _assembly;

        public override bool IsInteractive => _assembly.IsInteractive;
        public override AssemblyIdentity Identity => _assembly.Identity;
        public override INamespaceSymbol GlobalNamespace => _assembly.GlobalNamespace;
        public override ImmutableArray<ModuleSymbol> Modules
        {
            get
            {
                if (_lazyModules.IsDefault)
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyModules, _assembly.Modules.Select(m => new DotNetModuleSymbol(this, m)).ToImmutableArray<ModuleSymbol>());
                }
                return _lazyModules;
            }
        }

        /// <summary>
        /// Gets the set of type identifiers from this assembly.
        /// </summary>
        /// <remarks>
        /// These names are the simple identifiers for the type, and do not include namespaces,
        /// outer type names, or type parameters.
        /// 
        /// This functionality can be used for features that want to quickly know if a name could be
        /// a type for performance reasons.  For example, classification does not want to incur an
        /// expensive binding call cost if it knows that there is no type with the name that they
        /// are looking at.
        /// </remarks>
        public override ICollection<string> TypeNames => _assembly.TypeNames;

        /// <summary>
        /// Gets the set of namespace names from this assembly.
        /// </summary>
        public override ICollection<string> NamespaceNames => _assembly.NamespaceNames;

        /// <summary>
        /// Returns true if this assembly might contain extension methods. If this property
        /// returns false, there are no extension methods in this assembly.
        /// </summary>
        /// <remarks>
        /// This property allows the search for extension methods to be narrowed quickly.
        /// </remarks>
        public override bool MightContainExtensionMethods => _assembly.MightContainExtensionMethods;

        /// <summary>
        /// If this symbol represents a metadata assembly returns the underlying <see cref="AssemblyMetadata"/>.
        /// 
        /// Otherwise, this returns <see langword="null"/>.
        /// </summary>
        public override AssemblyMetadata GetMetadata()
        {
            return _assembly.GetMetadata();
        }

        public override INamedTypeSymbol GetTypeByMetadataName(string fullyQualifiedMetadataName)
        {
            return _assembly.GetTypeByMetadataName(fullyQualifiedMetadataName);
        }

        public override bool GivesAccessTo(IAssemblySymbol toAssembly)
        {
            IAssemblySymbol baseAssembly = _assembly;
            return baseAssembly.GivesAccessTo(toAssembly);
        }

        public override INamedTypeSymbol ResolveForwardedType(string fullyQualifiedMetadataName)
        {
            return _assembly.ResolveForwardedType(fullyQualifiedMetadataName);
        }
    }
}
