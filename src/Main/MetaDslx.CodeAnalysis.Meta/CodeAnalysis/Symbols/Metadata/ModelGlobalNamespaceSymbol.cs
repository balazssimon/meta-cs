using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Symbols.Model
{
    public class ModelGlobalNamespaceSymbol : MetaDslx.CodeAnalysis.Symbols.Metadata.MetaNamespaceSymbol
    {
        private ModelModuleSymbol _module;
        private ImmutableArray<DeclaredSymbol> _lazyMembers;
        private ImmutableArray<NamedTypeSymbol> _lazyTypeMembers;
        private ImmutableArray<string> _lazyTypeNames;
        private ImmutableArray<string> _lazyNamespaceNames;

        public ModelGlobalNamespaceSymbol(ModelModuleSymbol module)
            : base(module, null)
        {
            _module = module;
        }

        public override NamespaceExtent Extent => new NamespaceExtent(_module);

        public override ImmutableArray<Location> Locations => _module.Locations;

        public ImmutableArray<string> NamespaceNames
        {
            get
            {
                if (_lazyNamespaceNames.IsDefault)
                {
                    HashSet<string> names = new HashSet<string>();
                    try
                    {
                        var symbolFacts = Language.SymbolFacts;
                        foreach (var ms in symbolFacts.GetRootObjects(_module.Model))
                        {
                            if (symbolFacts.ToDeclarationKind(symbolFacts.GetSymbolType(ms)) == DeclarationKind.Namespace)
                            {
                                names.Add(symbolFacts.GetName(ms));
                            }
                        }
                    }
                    finally
                    {
                        ImmutableInterlocked.InterlockedInitialize(ref _lazyNamespaceNames, names.ToImmutableArray());
                    }
                }
                return _lazyNamespaceNames;
            }
        }

        public ImmutableArray<string> TypeNames
        {
            get
            {
                if (_lazyTypeNames.IsDefault)
                {
                    HashSet<string> names = new HashSet<string>();
                    try
                    {
                        var symbolFacts = Language.SymbolFacts;
                        foreach (var ms in symbolFacts.GetRootObjects(_module.Model))
                        {
                            if (symbolFacts.ToDeclarationKind(symbolFacts.GetSymbolType(ms)) == DeclarationKind.Type)
                            {
                                var name = symbolFacts.GetName(ms);
                                if (!string.IsNullOrEmpty(name)) names.Add(symbolFacts.GetName(ms));
                            }
                        }
                    }
                    finally
                    {
                        ImmutableInterlocked.InterlockedInitialize(ref _lazyTypeNames, names.ToImmutableArray());
                    }
                }
                return _lazyTypeNames;
            }
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            if (_lazyMembers.IsDefault)
            {
                HashSet<DeclaredSymbol> symbols = new HashSet<DeclaredSymbol>();
                try
                {
                    var symbolFacts = Language.SymbolFacts;
                    var symbolFactory = _module.SymbolFactory;
                    foreach (var ms in symbolFacts.GetRootObjects(_module.Model))
                    {
                        if (symbolFacts.GetParent(ms) == null)
                        {
                            var symbol = symbolFactory.GetSymbol(ms);
                            if (symbol is DeclaredSymbol ds) symbols.Add(ds);
                        }
                    }
                }
                finally
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyMembers, symbols.ToImmutableArray());
                }  
            }
            return _lazyMembers;
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers(string name)
        {
            return GetMembers().WhereAsArray(m => m.Name == name);
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers(string name, string metadataName)
        {
            return GetMembers().WhereAsArray(m => m.Name == name && m.MetadataName == metadataName);
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            if (_lazyTypeMembers.IsDefault)
            {
                HashSet<NamedTypeSymbol> symbols = new HashSet<NamedTypeSymbol>();
                try
                {
                    var symbolFacts = Language.SymbolFacts;
                    var symbolFactory = _module.SymbolFactory;
                    foreach (var ms in symbolFacts.GetRootObjects(_module.Model))
                    {
                        if (symbolFacts.ToDeclarationKind(symbolFacts.GetSymbolType(ms)) == DeclarationKind.Type)
                        {
                            var symbol = symbolFactory.GetSymbol(ms);
                            if (symbol is NamedTypeSymbol nts) symbols.Add(nts);
                        }
                    }
                }
                finally
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyTypeMembers, symbols.ToImmutableArray());
                }
            }
            return _lazyTypeMembers;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return GetTypeMembers().WhereAsArray(m => m.Name == name);
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            return GetTypeMembers().WhereAsArray(m => m.Name == name && m.MetadataName == metadataName);
        }


    }
}
