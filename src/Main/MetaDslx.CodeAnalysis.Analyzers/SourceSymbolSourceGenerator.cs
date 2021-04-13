using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetaDslx.CodeAnalysis.Symbols.CodeGeneration;
using System.IO;
using System.Diagnostics;

namespace MetaDslx.BuildTasks
{
    [Generator]
    public class SourceSymbolSourceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            try
            {
                Debug.WriteLine($"Starting SourceSymbolSourceGenerator");
                var generator = new SymbolGenerator();
                foreach (var symbol in GetNamedTypeSymbols(context.Compilation).Where(IsSourceSymbol))
                {
                    var ns = GetFullName(symbol.ContainingNamespace);
                    Debug.WriteLine($"Generating source symbol for: {ns}.{symbol.Name}");
                    var code = generator.GenerateSourceSymbol(ns, symbol.Name);
                    context.AddSource(symbol.Name + ".Generated.cs", code);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            Debug.WriteLine($"Finished SourceSymbolSourceGenerator");
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }

        private static bool IsSourceSymbol(INamedTypeSymbol namedType)
        {
            if (namedType.TypeKind != TypeKind.Class) return false;
            foreach (var intf in namedType.Interfaces)
            {
                if (intf.Name == "ISourceSymbol") return true;
            }
            return false;
        }

        private static string GetFullName(INamespaceOrTypeSymbol namedType)
        {
            return namedType.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);
        }

        private static IEnumerable<INamedTypeSymbol> GetNamedTypeSymbols(Compilation compilation)
        {
            var stack = new Stack<INamespaceSymbol>();
            stack.Push(compilation.GlobalNamespace);

            while (stack.Count > 0)
            {
                var @namespace = stack.Pop();

                foreach (var member in @namespace.GetMembers())
                {
                    if (member is INamespaceSymbol memberAsNamespace)
                    {
                        stack.Push(memberAsNamespace);
                    }
                    else if (member is INamedTypeSymbol memberAsNamedTypeSymbol)
                    {
                        yield return memberAsNamedTypeSymbol;
                    }
                }
            }
        }
    }
}
