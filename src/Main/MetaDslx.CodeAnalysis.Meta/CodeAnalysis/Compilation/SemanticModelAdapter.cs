using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis
{
    public abstract class SemanticModelAdapter : SemanticModel
    {
        public override string Language => LanguageCore.Name;

        protected abstract Language LanguageCore { get; }

        public sealed override ImmutableArray<Diagnostic> GetMethodBodyDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default)
        {
            return this.GetSymbolDiagnostics(span, cancellationToken);
        }

        public abstract ImmutableArray<Diagnostic> GetSymbolDiagnostics(TextSpan? span = null, CancellationToken cancellationToken = default);

        protected sealed override IAliasSymbol? GetAliasInfoCore(SyntaxNode nameSyntax, CancellationToken cancellationToken = default)
        {
            return this.GetAliasInfo(nameSyntax, cancellationToken).GetPublicSymbol();
        }

        public abstract new AliasSymbol? GetAliasInfo(SyntaxNodeOrToken syntax, CancellationToken cancellationToken = default);

        protected sealed override Optional<object?> GetConstantValueCore(SyntaxNode node, CancellationToken cancellationToken = default)
        {
            return this.GetConstantValue(node, cancellationToken);
        }

        public abstract new Optional<object?> GetConstantValue(SyntaxNodeOrToken syntax, CancellationToken cancellationToken = default);

        protected sealed override ISymbol? GetDeclaredSymbolCore(SyntaxNode declaration, CancellationToken cancellationToken = default)
        {
            return this.GetDeclaredSymbol(declaration, cancellationToken).GetPublicSymbol();
        }

        public abstract new DeclaredSymbol? GetDeclaredSymbol(SyntaxNodeOrToken syntax, CancellationToken cancellationToken = default);

        protected sealed override ImmutableArray<ISymbol> GetDeclaredSymbolsCore(SyntaxNode declaration, CancellationToken cancellationToken = default)
        {
            return this.GetDeclaredSymbols(declaration, cancellationToken).GetPublicSymbols();
        }

        public abstract new ImmutableArray<DeclaredSymbol> GetDeclaredSymbols(SyntaxNodeOrToken syntax, CancellationToken cancellationToken = default);

        protected sealed override ISymbol? GetEnclosingSymbolCore(int position, CancellationToken cancellationToken = default)
        {
            return this.GetEnclosingSymbol(position, cancellationToken).GetPublicSymbol();
        }

        public abstract new Symbol? GetEnclosingSymbol(int position, CancellationToken cancellationToken = default);

        protected sealed override ImmutableArray<ISymbol> GetMemberGroupCore(SyntaxNode node, CancellationToken cancellationToken = default)
        {
            return this.GetMemberGroup(node, cancellationToken).GetPublicSymbols();
        }

        public abstract new ImmutableArray<Symbol> GetMemberGroup(SyntaxNodeOrToken syntax, CancellationToken cancellationToken = default);

        protected sealed override IOperation? GetOperationCore(SyntaxNode node, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected sealed override PreprocessingSymbolInfo GetPreprocessingSymbolInfoCore(SyntaxNode nameSyntax)
        {
            throw new NotImplementedException();
        }

        protected sealed override IAliasSymbol? GetSpeculativeAliasInfoCore(int position, SyntaxNode nameSyntax, SpeculativeBindingOption bindingOption)
        {
            return this.GetSpeculativeAliasInfo(position, nameSyntax, bindingOption).GetPublicSymbol();
        }

        public abstract new AliasSymbol? GetSpeculativeAliasInfo(int position, SyntaxNodeOrToken syntax, SpeculativeBindingOption bindingOption);

        protected sealed override SymbolInfo GetSpeculativeSymbolInfoCore(int position, SyntaxNode expression, SpeculativeBindingOption bindingOption)
        {
            throw new NotImplementedException();
        }

        protected sealed override TypeInfo GetSpeculativeTypeInfoCore(int position, SyntaxNode expression, SpeculativeBindingOption bindingOption)
        {
            throw new NotImplementedException();
        }

        protected sealed override SymbolInfo GetSymbolInfoCore(SyntaxNode node, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected sealed override TypeInfo GetTypeInfoCore(SyntaxNode node, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected sealed override bool IsAccessibleCore(int position, ISymbol symbol)
        {
            return this.IsAccessible(position, symbol.EnsureLanguageSymbolOrNull(nameof(symbol)));
        }

        public abstract new bool IsAccessible(int position, Symbol symbol);

        protected sealed override bool IsEventUsableAsFieldCore(int position, IEventSymbol eventSymbol)
        {
            throw new NotImplementedException();
        }

        protected sealed override ImmutableArray<ISymbol> LookupBaseMembersCore(int position, string? name)
        {
            return this.LookupBaseMembers(position, name).GetPublicSymbols();
        }

        public abstract new ImmutableArray<DeclaredSymbol> LookupBaseMembers(int position, string? name);
        

        protected sealed override ImmutableArray<ISymbol> LookupLabelsCore(int position, string? name)
        {
            return (ImmutableArray<ISymbol>)this.LookupLabels(position, name).GetPublicSymbols();
        }

        public abstract new ImmutableArray<LabelSymbol> LookupLabels(int position, string? name);

        protected sealed override ImmutableArray<ISymbol> LookupNamespacesAndTypesCore(int position, INamespaceOrTypeSymbol? container, string? name)
        {
            return this.LookupNamespacesAndTypes(position, container.EnsureLanguageSymbolOrNull(nameof(container)), name).GetPublicSymbols();
        }

        public abstract new ImmutableArray<DeclaredSymbol> LookupNamespacesAndTypes(int position, DeclaredSymbol? container, string? name);

        protected sealed override ImmutableArray<ISymbol> LookupStaticMembersCore(int position, INamespaceOrTypeSymbol? container, string? name)
        {
            return this.LookupStaticMembers(position, container.EnsureLanguageSymbolOrNull(nameof(container)), name).GetPublicSymbols();
        }

        public abstract new ImmutableArray<DeclaredSymbol> LookupStaticMembers(int position, DeclaredSymbol? container, string? name);

        protected sealed override ImmutableArray<ISymbol> LookupSymbolsCore(int position, INamespaceOrTypeSymbol? container, string? name, bool includeReducedExtensionMethods)
        {
            return this.LookupSymbols(position, container.EnsureLanguageSymbolOrNull(nameof(container)), name, includeReducedExtensionMethods).GetPublicSymbols();
        }

        public abstract new ImmutableArray<DeclaredSymbol> LookupSymbols(int position, DeclaredSymbol? container, string? name, bool includeReducedExtensionMethods);

    }
}
