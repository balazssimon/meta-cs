using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
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
    public class AnnotationBinder : SymbolUseBinder
    {
        private static ConditionalWeakTable<Compilation, MetaAnnotations> _metaAnnotations = new ConditionalWeakTable<Compilation, MetaAnnotations>();

        public AnnotationBinder(Binder next, LanguageSyntaxNode syntax) 
            : base(next, syntax, ImmutableArray<Type>.Empty, ImmutableArray<Type>.Empty)
        {
        }

        public override void LookupSymbolsInSingleBinder(LookupResult result, LookupConstraints constraints)
        {
            Debug.Assert(result.IsClear);

            if (Annotations.TryGetValue(constraints.MetadataName, out Symbol specialSymbol))
            {
                result.SetFrom(LookupResult.Good(specialSymbol));
            }
        }

        protected override void AddLookupSymbolsInfoInSingleBinder(LookupSymbolsInfo result, LookupConstraints constraints)
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
                lock (_metaAnnotations)
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
}
