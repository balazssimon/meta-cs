using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbolUse : BoundValues
    {
        private ImmutableArray<Type> _symbolTypes;
        private ImmutableArray<Type> _nestingSymbolTypes;
        private ImmutableArray<Symbol> _lazySymbols;

        public BoundSymbolUse(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, ImmutableArray<Type> symbolTypes, ImmutableArray<Type> nestingSymbolTypes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _symbolTypes = symbolTypes;
            _nestingSymbolTypes = nestingSymbolTypes;
        }

        public ImmutableArray<Symbol> Symbols
        {
            get
            {
                if (_lazySymbols == null)
                {
                    HashSet<DiagnosticInfo> useSiteDiagnostics = null;
                    var binder = this.GetBinder();
                    var qualifiers = this.GetChildQualifiers();
                    ArrayBuilder<Symbol> symbols = ArrayBuilder<Symbol>.GetInstance();
                    foreach (var qualifier in qualifiers)
                    {
                        NamespaceOrTypeSymbol qualifierOpt = null;
                        Symbol symbol = null;
                        foreach (var identifier in qualifier.Identifiers)
                        {
                            LookupResult lookupResult = LookupResult.GetInstance();
                            binder.LookupSymbolsSimpleName(lookupResult, qualifierOpt, identifier.Name, identifier.MetadataName, null, LookupOptions.Default, true, ref useSiteDiagnostics);
                            //this.BoundTree.DiagnosticBag.AddRange(useSiteDiagnostics);
                            symbol = binder.ResultSymbol(lookupResult, identifier.Name, identifier.MetadataName, identifier.Syntax, this.BoundTree.DiagnosticBag, false, out bool wasError, qualifierOpt, LookupOptions.Default);
                            qualifierOpt = symbol as NamespaceOrTypeSymbol;
                            lookupResult.Free();
                        }
                        if (symbol != null)
                        {
                            symbols.Add(symbol);
                        }
                    }
                    ImmutableArray<object> values = this.GetChildValues();
                    if (values.Length > 0)
                    {
                        var modelObjects = values.OfType<IMetaSymbol>().ToImmutableArray();
                        symbols.AddRange(modelObjects.Select(mo => Language.CompilationFactory.ModelObjectToSourceSymbol(Compilation, this.Syntax.GetReference(), mo)));
                        var valueSymbols = values.OfType<Symbol>().ToImmutableArray();
                        symbols.AddRange(valueSymbols);
                    }
                    ImmutableInterlocked.InterlockedInitialize(ref _lazySymbols, symbols.ToImmutableAndFree());
                }
                return _lazySymbols;
            }
        }

        public override ImmutableArray<object> Values => StaticCast<object>.From(this.Symbols);
    }
}
