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
        public static BinderPosition<Binder> FindCompilationUnitRootBinder(BinderPosition origin)
        {
            if (origin.Syntax.IsMissing) return default;
            return new FindCompilationUnitRoot(origin).FindOne(includeSelf: true);
        }

        public static BinderPosition<SymbolBinder> FindSymbolBinder(Symbol symbol, SyntaxReference reference)
        {
            var origin = reference.ToBinderPosition(symbol.DeclaringCompilation);
            if (origin.Syntax.IsMissing) return default;
            return new FindSymbol(origin, symbol).FindOne(includeSelf: true);
        }

        public static BinderPosition<SymbolBinder> FindFirstOrDefaultSymbolBinder(Symbol symbol, SyntaxReference reference)
        {
            var origin = reference.ToBinderPosition(symbol.DeclaringCompilation);
            if (origin.Syntax.IsMissing) return default;
            var result = new FindSymbol(origin, symbol).FindAll(includeSelf: true);
            if (result.Length == 0) return default;
            else return result[0];
        }

        public static ImmutableArray<BinderPosition<ImportBinder>> FindImportBinders(BinderPosition symbolBinder)
        {
            return new FindImports(symbolBinder).FindAll();
        }

        public static ImmutableArray<BinderPosition<PhaseBinder>> FindPhaseBinders(BinderPosition<SymbolBinder> symbolBinder, CompletionPart startPhase, CompletionPart finishPhase)
        {
            return new FindPhases(symbolBinder, startPhase, finishPhase).FindAll();
        }

        public static ImmutableArray<BinderPosition<PropertyBinder>> FindPropertyBinders(BinderPosition<SymbolBinder> symbolBinder)
        {
            return new FindProperties(symbolBinder).FindAll();
        }

        public static ImmutableArray<BinderPosition<ValueBinder>> FindPropertyValueBinders(BinderPosition<PropertyBinder> propertyBinder)
        {
            return new FindValues(propertyBinder).FindAll(includeSelf: true);
        }

        public static ImmutableArray<BinderPosition<NameBinder>> FindNameBinders(BinderPosition symbolBinder)
        {
            return new FindNames(symbolBinder).FindAll();
        }

        public static ImmutableArray<BinderPosition<ValueBinder>> FindValueBinders(BinderPosition originBinder)
        {
            return new FindValues(originBinder).FindAll();
        }

        public static ImmutableArray<BinderPosition<IdentifierBinder>> FindIdentifierBinders(BinderPosition qualifierBinder)
        {
            return new FindIdentifiers(qualifierBinder).FindAll();
        }

    }
}
