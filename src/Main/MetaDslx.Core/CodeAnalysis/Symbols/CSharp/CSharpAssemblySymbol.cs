using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    using Roslyn.Utilities;
    using CSharpSymbols = Microsoft.CodeAnalysis.CSharp.Symbols;

    public class CSharpAssemblySymbol : MetadataOrSourceAssemblySymbol
    {
        private CSharpSymbols.AssemblySymbol _csharpAssembly;
        private ImmutableArray<ModuleSymbol> _lazyModules;

        private CSharpAssemblySymbol(CSharpSymbols.AssemblySymbol csharpAssembly)
        {
            _csharpAssembly = csharpAssembly;
        }

        internal static CSharpAssemblySymbol FromCSharp(CSharpSymbols.AssemblySymbol csharpAssembly)
        {
            return new CSharpAssemblySymbol(csharpAssembly);
        }

        internal CSharpSymbols.AssemblySymbol CSharpAssembly => _csharpAssembly;

        public override AssemblySymbol ContainingAssembly => null;

        public override ModuleSymbol ContainingModule => null;

        public override Symbol ContainingSymbol => null;

        public override NamespaceSymbol ContainingNamespace => null;

        public override NamedTypeSymbol ContainingType => null;

        public override ImmutableArray<ModuleSymbol> Modules
        {
            get
            {
                if (_lazyModules.IsDefault)
                {
                    var modules = CSharpSymbolMap.GetModuleSymbols(_csharpAssembly.Modules);
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyModules, modules);
                }
                return _lazyModules;
            }
        }

        public override bool IsInteractive => _csharpAssembly.IsInteractive;

        public override bool IsLinked => _csharpAssembly.IsLinked; 

        public override AssemblyIdentity Identity => _csharpAssembly.Identity;

        public override ICollection<string> TypeNames => _csharpAssembly.TypeNames;

        public override ICollection<string> NamespaceNames => _csharpAssembly.NamespaceNames;

        public override bool MightContainExtensionMethods => _csharpAssembly.MightContainExtensionMethods;

        public override AssemblyMetadata GetMetadata()
        {
            return _csharpAssembly.GetMetadata();
        }

        public override bool GivesAccessTo(IAssemblySymbol toAssembly)
        {
            if (toAssembly is CSharpAssemblySymbol assembly) return ((IAssemblySymbol)_csharpAssembly).GivesAccessTo(assembly._csharpAssembly);
            else return ((IAssemblySymbol)_csharpAssembly).GivesAccessTo(toAssembly);
        }

        public override bool IsStatic => false;

        public override ImmutableArray<Location> Locations => _csharpAssembly.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _csharpAssembly.DeclaringSyntaxReferences;

        /// <summary>
        /// Continue looking for declaration of predefined CorLib type in this Assembly
        /// while symbols for new type declarations are constructed.
        /// </summary>
        public override bool KeepLookingForDeclaredSpecialTypes => _csharpAssembly.KeepLookingForDeclaredSpecialTypes;

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitAssembly(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitAssembly(this);
        }

        internal override NamedTypeSymbol TryLookupForwardedMetadataTypeWithCycleDetection(ref MetadataTypeName emittedName, ConsList<AssemblySymbol> visitedAssemblies)
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }

        public override ImmutableArray<AssemblySymbol> GetNoPiaResolutionAssemblies()
        {
            throw new NotImplementedException();
        }

        internal override void SetNoPiaResolutionAssemblies(ImmutableArray<AssemblySymbol> assemblies)
        {
            throw new NotImplementedException();
        }

        internal override void SetLinkedReferencedAssemblies(ImmutableArray<AssemblySymbol> assemblies)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<AssemblySymbol> GetLinkedReferencedAssemblies()
        {
            throw new NotImplementedException();
        }

        public override bool AreInternalsVisibleToThisAssembly(AssemblySymbol potentialGiverOfAccess)
        {
            CSharpAssemblySymbol csAssembly = potentialGiverOfAccess as CSharpAssemblySymbol;
            if (csAssembly != null) return _csharpAssembly.AreInternalsVisibleToThisAssembly(csAssembly.CSharpAssembly);
            else return false;
        }

        public override IEnumerable<ImmutableArray<byte>> GetInternalsVisibleToPublicKeys(string simpleName)
        {
            return _csharpAssembly.GetInternalsVisibleToPublicKeys(simpleName);
        }
    }
}
