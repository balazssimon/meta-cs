// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public partial class SourceNamespaceSymbol
    {
        private readonly SourceModuleSymbol _module;

        public SourceNamespaceSymbol(
            SourceModuleSymbol module, 
            Symbol containingSymbol,
            MergedDeclaration declaration,
            object? modelObject,
            bool isError = false)
            : base(containingSymbol, modelObject, isError)
        {
            Debug.Assert(declaration != null);
            Debug.Assert(containingSymbol == module || modelObject != null);
            _module = module;
            _declaration = declaration;
        }

        public override AssemblySymbol ContainingAssembly => _module.ContainingAssembly;

        internal IEnumerable<Imports> GetBoundImportsMerged()
        {
            var compilation = this.DeclaringCompilation;
            foreach (var declaration in _declaration.Declarations)
            {
                if (declaration.HasImports)
                {
                    yield return compilation.GetImports(declaration);
                }
            }
        }

        public override ModuleSymbol ContainingModule => _module;

        public override NamespaceExtent Extent => new NamespaceExtent(_module);

        public override void CheckMembers(Dictionary<string, ImmutableArray<DeclaredSymbol>> result, DiagnosticBag diagnostics)
        {
            var memberOfMetadataName = new Dictionary<string, DeclaredSymbol>();
            MergedNamespaceSymbol mergedAssemblyNamespace = null;

            if (this.ContainingAssembly.Modules.Length > 1)
            {
                mergedAssemblyNamespace = this.ContainingAssembly.GetAssemblyNamespace(this) as MergedNamespaceSymbol;
            }

            foreach (var name in result.Keys)
            {
                memberOfMetadataName.Clear();
                foreach (var symbol in result[name])
                {
                    var nts = symbol as NamedTypeSymbol;
                    var metadataName = ((object)nts != null) ? nts.MetadataName : string.Empty;
                    if (metadataName == null) metadataName = string.Empty;

                    if (memberOfMetadataName.TryGetValue(metadataName, out DeclaredSymbol other))
                    {
                        if ((nts as SourceNamedTypeSymbol)?.IsPartial == true && (other as SourceNamedTypeSymbol)?.IsPartial == true)
                        {
                            diagnostics.Add(InternalErrorCode.ERR_PartialTypeKindConflict, symbol.Locations.FirstOrNone(), symbol);
                        }
                        else
                        {
                            diagnostics.Add(InternalErrorCode.ERR_DuplicateNameInNS, symbol.Locations.FirstOrNone(), name, this);
                        }
                        memberOfMetadataName[metadataName] = symbol;
                    }
                    else if ((object)mergedAssemblyNamespace != null)
                    {
                        // Check for collision with declarations from added modules.
                        foreach (NamespaceSymbol constituent in mergedAssemblyNamespace.ConstituentNamespaces)
                        {
                            if ((object)constituent != (object)this)
                            {
                                // For whatever reason native compiler only detects conflicts against types.
                                // It doesn't complain when source declares a type with the same name as 
                                // a namespace in added module, but complains when source declares a namespace 
                                // with the same name as a type in added module.
                                var types = constituent.GetTypeMembers(symbol.Name, metadataName);

                                if (types.Length > 0)
                                {
                                    other = types[0];
                                    // Since the error doesn't specify what added module this type belongs to, we can stop searching
                                    // at the first match.
                                    break;
                                }
                            }
                        }
                        memberOfMetadataName.Add(metadataName, symbol);
                    }
                    else
                    {
                        memberOfMetadataName.Add(metadataName, symbol);
                    }
                }
            }
        }

        public partial class Error
        {
            private Error(SourceModuleSymbol module, Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags, object? modelObject)
                : base(module, container, declaration, modelObject, true)
            {
                Debug.Assert(!flags.HasFlag(MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported) || errorInfo != null);
                _name = declaration.Name;
                _metadataName = declaration.MetadataName;
                _kind = kind;
                _errorInfo = errorInfo;
                _candidateSymbols = candidateSymbols;
                _flags = flags;
            }

            public Error(SourceModuleSymbol module, Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject = null)
                : this(module, container, declaration, kind, errorInfo, candidateSymbols, unreported? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Unreported : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.None, modelObject)
            {
            }

            public Error(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject = null)
                : this((SourceModuleSymbol)wrappedSymbol.ContainingModule, wrappedSymbol.ContainingSymbol, (wrappedSymbol as ISourceSymbol).MergedDeclaration, kind, errorInfo, ImmutableArray.Create<Symbol>(wrappedSymbol), unreported ? MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.UnreportedWrapped : MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags.Wrapped, modelObject is not null ? modelObject :  (wrappedSymbol as IModelSymbol)?.ModelObject)
            {
            }

            protected virtual Error Update(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, MetaDslx.CodeAnalysis.Symbols.ErrorSymbolFlags flags, object? modelObject)
            {
                return new Error((SourceModuleSymbol)this.ContainingModule, container, declaration, kind, errorInfo, candidateSymbols, flags, modelObject);
            }
        }
    }
}
