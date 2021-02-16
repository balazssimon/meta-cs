using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class LanguageSymbolModel
    {
        private ImmutableModel _model;

        private LanguageSymbolModel()
        {
            var model = new MutableModel();
            var factory = new MetaFactory(model);
            var metaDslx = factory.MetaNamespace();
            metaDslx.Name = "MetaDslx";
            var codeAnalysis = factory.MetaNamespace();
            codeAnalysis.Name = "CodeAnalysis";
            codeAnalysis.Namespace = metaDslx;
            var symbols = factory.MetaNamespace();
            symbols.Name = "Symbols";
            symbols.Namespace = codeAnalysis;
            var namespaceSymbol = factory.MetaAttribute();
            namespaceSymbol.Name = "NamespaceSymbolAttribute";
            namespaceSymbol.Namespace = symbols;
            var namedTypeSymbol = factory.MetaAttribute();
            namedTypeSymbol.Name = "NamedTypeSymbolAttribute";
            namedTypeSymbol.Namespace = symbols;
            var memberSymbol = factory.MetaAttribute();
            memberSymbol.Name = "MemberSymbolAttribute";
            memberSymbol.Namespace = symbols;
            _model = model.ToImmutable();
        }

        public ImmutableModel Model => _model;

        private static LanguageSymbolModel _instance;

        public static LanguageSymbolModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    Interlocked.CompareExchange(ref _instance, new LanguageSymbolModel(), null);
                }
                return _instance;
            }
        }

    }
}
