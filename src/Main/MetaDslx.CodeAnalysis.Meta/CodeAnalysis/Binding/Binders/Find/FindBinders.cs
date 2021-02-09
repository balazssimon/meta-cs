using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Binding.Binders.Find;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class FindBinders
    {
        public static BinderPosition<SymbolDefBinder> FindSymbolDefBinder(Symbol symbol, SyntaxReference reference)
        {
            var origin = reference.ToBinderPosition(symbol.DeclaringCompilation);
            return new FindSymbolDef(origin, symbol).FindOne(includeSelf: true);
        }

        public static ImmutableArray<BinderPosition<PhaseBinder>> FindPhaseBinders(BinderPosition<SymbolDefBinder> symbolDefBinder, CompletionPart startPhase, CompletionPart finishPhase)
        {
            return new FindPhases(symbolDefBinder, startPhase, finishPhase).FindAll();
        }

        public static ImmutableArray<BinderPosition<PropertyBinder>> FindPropertyBinders(BinderPosition<SymbolDefBinder> symbolDefBinder)
        {
            return new FindProperties(symbolDefBinder).FindAll();
        }

        public static ImmutableArray<BinderPosition<ValueBinder>> FindValueBinders(BinderPosition<PropertyBinder> propertyBinder)
        {
            return new FindValues(propertyBinder).FindAll(includeSelf: true);
        }

        public static ImmutableArray<BinderPosition<IdentifierBinder>> FindIdentifierBinders(BinderPosition qualifierBinder)
        {
            return new FindIdentifiers(qualifierBinder).FindAll();
        }

    }
}
