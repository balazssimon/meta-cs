using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class MetaGlobalNamespaceSymbol : NamespaceSymbol, IMetaMetadataSymbol
    {
        private MetaModuleSymbol _module;
        private ImmutableArray<DeclaredSymbol> _lazyMembers;
        private ImmutableArray<NamedTypeSymbol> _lazyTypeMembers;
        private ImmutableArray<string> _lazyTypeNames;
        private ImmutableArray<string> _lazyNamespaceNames;

        public MetaGlobalNamespaceSymbol(MetaModuleSymbol module) 
        {
            _module = module;
        }

        public MetaSymbolMap MetaSymbolMap => _module.MetaSymbolMap;

        public override NamespaceExtent Extent => new NamespaceExtent(_module);

        public override Symbol ContainingSymbol => _module;

        public override ImmutableArray<Location> Locations => _module.Locations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public ImmutableArray<string> NamespaceNames
        {
            get
            {
                if (_lazyNamespaceNames.IsDefault)
                {
                    HashSet<string> names = new HashSet<string>();
                    try
                    {
                        foreach (var model in _module.Models)
                        {
                            foreach (var ms in model.Objects)
                            {
                                if (ms.MParent == null && ms.MId.Descriptor.IsNamespace)
                                {
                                    names.Add(ms.MName);
                                }
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
                        foreach (var model in _module.Models)
                        {
                            foreach (var ms in model.Objects)
                            {
                                if (ms.MParent == null && ms.MId.Descriptor.IsType) 
                                {
                                    names.Add(ms.MName);
                                }
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
                    foreach (var model in _module.Models)
                    {
                        foreach (var ms in model.Objects)
                        {
                            if (ms.MParent == null)
                            {
                                var symbol = (DeclaredSymbol)MetaSymbolMap.GetSymbol(ms);
                                symbols.Add(symbol);
                            }
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
                    foreach (var model in _module.Models)
                    {
                        foreach (var ms in model.Objects)
                        {
                            if (ms.MParent == null && ms.MId.Descriptor.IsNamedType)
                            {
                                var symbol = MetaSymbolMap.GetNamedTypeSymbol(ms);
                                symbols.Add(symbol);
                            }
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
