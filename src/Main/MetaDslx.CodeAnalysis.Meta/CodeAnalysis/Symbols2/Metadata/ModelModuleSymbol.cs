using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols.CSharp;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class ModelModuleSymbol : NonMissingModuleSymbol, IModelSymbol
    {
        private ModelGlobalNamespaceSymbol _globalNamespace;
        private AssemblySymbol _owningAssembly;
        private ObjectFactory _objectFactory;
        private SymbolFactory _symbolFactory;
        private object _model;
        private readonly int _ordinal;

        public ModelModuleSymbol(AssemblySymbol owningAssembly, object model, int ordinal)
        {
            _owningAssembly = owningAssembly;
            _model = model;
            _objectFactory = Language.CompilationFactory.CreateObjectFactory(this);
            _ordinal = ordinal;
        }

        public object Model => _model;

        public object ModelObject => null;

        public ObjectFactory ObjectFactory => _objectFactory;

        public SymbolFactory SymbolFactory
        {
            get
            {
                if (_symbolFactory == null)
                {
                    Interlocked.CompareExchange(ref _symbolFactory, Language.CompilationFactory.CreateSymbolFactory(_objectFactory), null);
                }
                return _symbolFactory;
            }
        }

        public override int Ordinal => _ordinal;

        public override bool HasUnifiedReferences => false;

        public override NamespaceSymbol GlobalNamespace
        {
            get
            {
                if (_globalNamespace == null)
                {
                    Interlocked.CompareExchange(ref _globalNamespace, new ModelGlobalNamespaceSymbol(this), null);
                }
                return _globalNamespace;
            }
        }

        public override ICollection<string> TypeNames => _globalNamespace.TypeNames;

        public override ICollection<string> NamespaceNames => _globalNamespace.NamespaceNames;

        public override ImmutableArray<Location> Locations => ImmutableArray<Location>.Empty;

        public override Machine Machine => Machine.Unknown;

        public override bool Bit32Required => false;

        internal override bool HasAssemblyCompilationRelaxationsAttribute => false;

        internal override bool HasAssemblyRuntimeCompatibilityAttribute => false;

        internal override CharSet? DefaultMarshallingCharSet => null;

        public override Symbol ContainingSymbol => _owningAssembly;

        public override ModuleMetadata GetMetadata()
        {
            return null;
        }

    }
}
