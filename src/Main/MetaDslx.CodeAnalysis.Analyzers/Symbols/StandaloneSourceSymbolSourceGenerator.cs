using MetaDslx.CodeAnalysis.Analyzers.CodeGeneration;
using MetaDslx.CodeAnalysis.Symbols.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Analyzers.Symbols
{
    using Microsoft.CodeAnalysis;

    public class StandaloneSourceSymbolSourceGenerator : IStandaloneSourceGenerator
    {
        private Dictionary<INamedTypeSymbol, SymbolGenerationInfo> _info = new Dictionary<INamedTypeSymbol, SymbolGenerationInfo>();

        public void Execute(StandaloneGeneratorExecutionContext context)
        {
            var generator = new SymbolGenerator();
            foreach (var symbol in GeneratorUtils.GetNamedTypeSymbols(context.Compilation).Where(s => s.DeclaringSyntaxReferences.Length>0))
            {
                var info = GetSymbolGenerationInfo(symbol);
                if (info != null)
                {
                    Debug.WriteLine($"Generating source symbol for: {info.NamespaceName}.{info.Name}");
                    var code = generator.GenerateSymbol(info);
                    context.AddSource(symbol.Name + ".Generated.cs", code);
                }
            }
            /*foreach (var symbol in GeneratorUtils.GetNamedTypeSymbols(context.Compilation).Where(GeneratorUtils.IsSourceSymbol))
            {
                var ns = GeneratorUtils.GetFullName(symbol.ContainingNamespace);
                Debug.WriteLine($"Generating source symbol for: {ns}.{symbol.Name}");
                var code = generator.GenerateSourceSymbol(ns, symbol.Name);
                context.AddSource(symbol.Name + ".Generated.cs", code);
            }*/
        }

        private SymbolGenerationInfo GetSymbolGenerationInfo(INamedTypeSymbol symbol)
        {
            if (_info.TryGetValue(symbol, out var info)) return info;
            if (!GeneratorUtils.IsSymbol(symbol, out var symbolAttribute)) return null;
            var ns = GeneratorUtils.GetFullName(symbol.ContainingNamespace);
            var hasSubSymbolKind = false;
            foreach (var arg in symbolAttribute.NamedArguments)
            {
                if (arg.Key == "HasSubSymbolKinds")
                {
                    hasSubSymbolKind = (bool)arg.Value.Value;
                }
            }
            var baseSymbol = symbol.BaseType;
            SymbolGenerationInfo parentInfo = null;
            while (baseSymbol != null)
            {
                parentInfo = GetSymbolGenerationInfo(baseSymbol);
                if (parentInfo != null) break;
                baseSymbol = baseSymbol.BaseType;
            }
            return new SymbolGenerationInfo(symbol.Name, ns, hasSubSymbolKind, parentInfo);
        }
    }
}
