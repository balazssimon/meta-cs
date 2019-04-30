using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using CSharpAssemblySymbol = Microsoft.CodeAnalysis.CSharp.Symbols.AssemblySymbol;

    public abstract class WrappedAssemblySymbol : NonMissingAssemblySymbol
    {
        private IAssemblySymbol _assembly;

        protected WrappedAssemblySymbol(IAssemblySymbol assembly)
        {
            _assembly = assembly;
        }

        public IAssemblySymbol WrappedAssembly => _assembly;

        public override AssemblyIdentity Identity => _assembly.Identity;

        public override ICollection<string> TypeNames => _assembly.TypeNames;

        public override ICollection<string> NamespaceNames => _assembly.NamespaceNames;

        public override bool MightContainExtensionMethods => _assembly.MightContainExtensionMethods;

        public override ImmutableArray<Location> Locations => _assembly.Locations;

    }

    public class WrappedCSharpAssemblySymbol : WrappedAssemblySymbol
    {
        private WrappedCSharpAssemblySymbol(CSharpAssemblySymbol assembly)
            :base (assembly)
        {

        }

        internal AssemblySymbol Create(CSharpAssemblySymbol assembly)
        {
            return new WrappedCSharpAssemblySymbol(assembly);
        }

        internal CSharpAssemblySymbol CSharpAssembly => (CSharpAssemblySymbol)this.WrappedAssembly;

        public override Version AssemblyVersionPattern => CSharpAssembly.AssemblyVersionPattern;

        public override ImmutableArray<ModuleSymbol> Modules => throw new NotImplementedException();

        internal override bool IsLinked => CSharpAssembly.IsLinked;

        internal override ImmutableArray<byte> PublicKey => CSharpAssembly.PublicKey;

        public override AssemblyMetadata GetMetadata()
        {
            return CSharpAssembly.GetMetadata();
        }

        internal override bool AreInternalsVisibleToThisAssembly(AssemblySymbol other)
        {
            throw new NotImplementedException();
        }

        internal override NamedTypeSymbol GetDeclaredSpecialType(SpecialType type)
        {
            throw new NotImplementedException();
        }

        internal override IEnumerable<ImmutableArray<byte>> GetInternalsVisibleToPublicKeys(string simpleName)
        {
            return CSharpAssembly.GetInternalsVisibleToPublicKeys(simpleName);
        }

        internal override ImmutableArray<AssemblySymbol> GetLinkedReferencedAssemblies()
        {
            throw new NotImplementedException();
        }

        internal override ImmutableArray<AssemblySymbol> GetNoPiaResolutionAssemblies()
        {
            throw new NotImplementedException();
        }

        internal override void SetLinkedReferencedAssemblies(ImmutableArray<AssemblySymbol> assemblies)
        {
            throw new NotImplementedException();
        }

        internal override void SetNoPiaResolutionAssemblies(ImmutableArray<AssemblySymbol> assemblies)
        {
            throw new NotImplementedException();
        }

        internal override NamedTypeSymbol TryLookupForwardedMetadataTypeWithCycleDetection(ref MetadataTypeName emittedName, ConsList<AssemblySymbol> visitedAssemblies)
        {
            throw new NotImplementedException();
        }
    }
}
