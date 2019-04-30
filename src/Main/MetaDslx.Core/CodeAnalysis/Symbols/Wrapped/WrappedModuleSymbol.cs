using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    using System.Collections.Immutable;
    using System.Reflection.PortableExecutable;
    using System.Runtime.InteropServices;
    using CSharpModuleSymbol = Microsoft.CodeAnalysis.CSharp.Symbols.ModuleSymbol;

    public abstract class WrappedModuleSymbol : NonMissingModuleSymbol
    {
        private AssemblySymbol _assembly;
        private IModuleSymbol _module;
        private int _ordinal;

        protected WrappedModuleSymbol(AssemblySymbol assembly, IModuleSymbol module, int ordinal)
        {
            _assembly = assembly;
            _module = module;
            _ordinal = ordinal;
        }

        public IModuleSymbol WrappedModule => _module;

        public override Symbol ContainingSymbol => _assembly;

        internal override int Ordinal => _ordinal;

        public override ImmutableArray<Location> Locations => _module.Locations;

        public override ModuleMetadata GetMetadata()
        {
            return _module.GetMetadata();
        }
    }

    public class WrappedCSharpModuleSymbol : WrappedModuleSymbol
    {
        private WrappedCSharpModuleSymbol(AssemblySymbol assembly, CSharpModuleSymbol module, int ordinal)
            : base(assembly, module, ordinal)
        {

        }

        internal static ModuleSymbol Create(AssemblySymbol assembly, CSharpModuleSymbol module, int ordinal)
        {
            return new WrappedCSharpModuleSymbol(assembly, module, ordinal);
        }

        internal CSharpModuleSymbol CSharpModule => (CSharpModuleSymbol)this.WrappedModule;

        public override NamespaceSymbol GlobalNamespace => throw new NotImplementedException();

        internal override Machine Machine => CSharpModule.Machine;

        internal override bool Bit32Required => CSharpModule.Bit32Required;

        internal override ICollection<string> TypeNames => CSharpModule.TypeNames;

        internal override ICollection<string> NamespaceNames => CSharpModule.NamespaceNames;

        internal override bool HasAssemblyCompilationRelaxationsAttribute => CSharpModule.HasAssemblyCompilationRelaxationsAttribute;

        internal override bool HasAssemblyRuntimeCompatibilityAttribute => CSharpModule.HasAssemblyRuntimeCompatibilityAttribute;

        internal override CharSet? DefaultMarshallingCharSet => CSharpModule.DefaultMarshallingCharSet;

    }
}
