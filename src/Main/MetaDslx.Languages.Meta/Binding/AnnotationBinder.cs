using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Symbols;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace MetaDslx.Languages.Meta.Binding
{
    public class AnnotationBinder : Binder
    {
        private static ConditionalWeakTable<Compilation, MetaAnnotations> _metaAnnotations = new ConditionalWeakTable<Compilation, MetaAnnotations>();

        public AnnotationBinder(Binder next, LanguageSyntaxNode syntax) 
            : base(next)
        {
        }

        public override void LookupSymbolsInSingleBinder(
            LookupResult result, string name, string metadataName, ConsList<TypeSymbol> basesBeingResolved, LookupOptions options, Binder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            Debug.Assert(result.IsClear);

            if (Annotations.TryGetValue(metadataName, out Symbol specialSymbol))
            {
                result.SetFrom(LookupResult.Good(specialSymbol));
            }
        }

        protected override void AddLookupSymbolsInfoInSingleBinder(LookupSymbolsInfo result, LookupOptions options, Binder originalBinder)
        {
            foreach (var symbol in Annotations.Values)
            {
                result.AddSymbol(symbol, symbol.Name, symbol.MetadataName);
            }
        }

        private ImmutableDictionary<string, Symbol> Annotations
        {
            get
            {
                if (!_metaAnnotations.TryGetValue(this.Compilation, out MetaAnnotations result))
                {
                    result = new MetaAnnotations((Symbol)this.Compilation.Assembly);
                    _metaAnnotations.Add(this.Compilation, result);
                }
                return result.Annotations;
            }
        }

    }
}
