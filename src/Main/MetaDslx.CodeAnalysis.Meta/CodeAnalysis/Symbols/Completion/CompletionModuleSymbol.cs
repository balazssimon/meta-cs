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
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Completion
{
    public partial class CompletionModuleSymbol : NonMissingModuleSymbol
    {
        private AssemblySymbol _owningAssembly;
        private CompletionGlobalNamespaceSymbol _globalNamespace;
        private object _model;
        private readonly int _ordinal;

        public CompletionModuleSymbol(AssemblySymbol owningAssembly, object model, int ordinal)
        {
            _owningAssembly = owningAssembly;
            _state = CompletionParts.CompletionGraph.CreateState();
            _model = model;
            _ordinal = ordinal;
        }

        public override AssemblySymbol ContainingAssembly => _owningAssembly;

        public override Symbol ContainingSymbol => _owningAssembly;

        public virtual object Model => _model;

        public virtual ObjectFactory ObjectFactory => null;

        public override int Ordinal => _ordinal;

        public override bool HasUnifiedReferences => false;

        public override NamespaceSymbol GlobalNamespace
        {
            get
            {
                if (_globalNamespace == null)
                {
                    Interlocked.CompareExchange(ref _globalNamespace, new CompletionGlobalNamespaceSymbol(this), null);
                }
                return _globalNamespace;
            }
        }

        public override ICollection<string> TypeNames => _globalNamespace.TypeNames;

        public override ICollection<string> NamespaceNames => _globalNamespace.NamespaceNames;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public override Machine Machine => Machine.Unknown;

        public override bool Bit32Required => false;

        internal override bool HasAssemblyCompilationRelaxationsAttribute => false;

        internal override bool HasAssemblyRuntimeCompatibilityAttribute => false;

        internal override CharSet? DefaultMarshallingCharSet => null;

        public override ModuleMetadata GetMetadata()
        {
            return null;
        }

        internal protected override Symbol? GetDeclaredModelSymbol(object modelObject)
        {
            if (this.SymbolFactory.TryGetSymbol(modelObject, out var result)) return result;
            if (this.Language.SymbolFacts.ContainsObject(this.Model, modelObject)) return this.SymbolFactory.GetSymbol(modelObject);
            return null;
        }
    }
}
