using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class SourceMemberSymbol : MemberSymbol
    {
        private readonly NamespaceOrTypeSymbol _containingSymbol;
        protected readonly MergedDeclaration _declaration;
        private LexicalSortKey _lazyLexicalSortKey = LexicalSortKey.NotInitialized;

        private MutableSymbolBase _modelObject;

        public SourceMemberSymbol(NamespaceOrTypeSymbol containingSymbol, MergedDeclaration declaration, DiagnosticBag diagnostics)
        {
            _containingSymbol = containingSymbol;
            _declaration = declaration;

            _modelObject = declaration.Kind.CreateMutable(containingSymbol.ModelBuilder);
            Debug.Assert(_modelObject != null);
            if (_modelObject != null)
            {
                _modelObject.MName = declaration.Name;
                var parentObject = containingSymbol?.ModelObject;
                if (parentObject != null && !string.IsNullOrEmpty(declaration.ParentPropertyToAddTo))
                {
                    var property = parentObject.MGetProperty(declaration.ParentPropertyToAddTo);
                    parentObject.MAdd(property, _modelObject);
                }
            }
        }

        internal protected override MutableModel ModelBuilder => this.ContainingModule.ModelBuilder;

        internal protected override MutableSymbolBase ModelObject => _modelObject;

        public override LanguageSymbolKind Kind => LanguageSymbolKind.Name;

        public override ModelSymbolInfo ModelSymbolInfo => _declaration.Kind;

        public sealed override NamedTypeSymbol ContainingType => _containingSymbol as NamedTypeSymbol;

        public override Symbol ContainingSymbol => _containingSymbol;

        #region Syntax

        public override string MetadataName => _declaration.MetadataName;

        public override string Name => _declaration.Name;

        public override LexicalSortKey GetLexicalSortKey()
        {
            if (!_lazyLexicalSortKey.IsInitialized)
            {
                _lazyLexicalSortKey.SetFrom(_declaration.GetLexicalSortKey(this.DeclaringCompilation));
            }
            return _lazyLexicalSortKey;
        }

        public override ImmutableArray<Location> Locations => _declaration.NameLocations;

        public ImmutableArray<SyntaxReference> SyntaxReferences => _declaration.SyntaxReferences;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => SyntaxReferences;

        // This method behaves the same was as the base class, but avoids allocations associated with DeclaringSyntaxReferences
        public override bool IsDefinedInSourceTree(SyntaxTree tree, TextSpan? definedWithinSpan, CancellationToken cancellationToken)
        {
            var declarations = _declaration.Declarations;
            if (IsImplicitlyDeclared && declarations.IsEmpty)
            {
                return ContainingSymbol.IsDefinedInSourceTree(tree, definedWithinSpan, cancellationToken);
            }

            foreach (var declaration in declarations)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var syntaxRef = declaration.SyntaxReference;
                if (syntaxRef.SyntaxTree == tree &&
                    (!definedWithinSpan.HasValue || syntaxRef.Span.IntersectsWith(definedWithinSpan.Value)))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        public override bool IsStatic => false;

        public override void Accept(SymbolVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            throw new NotImplementedException();
        }
    }
}
