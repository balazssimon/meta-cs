using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public abstract class SourceTypeSymbol : TypeSymbol
    {
        private Symbol _containingSymbol;
        private SyntaxReference _syntaxReference;
        private IMetaSymbol _modelObject;

        public SourceTypeSymbol(SourceAssemblySymbol containingAssembly, SyntaxReference syntaxReference, IMetaSymbol modelObject)
        {
            _containingSymbol = containingAssembly;
            _syntaxReference = syntaxReference;
            _modelObject = modelObject;
            containingAssembly.SourceModule.MetaSymbolMap.RegisterSymbol(_modelObject, this);
        }

        public override IMetaSymbol ModelObject => _modelObject;

        public override ModelSymbolInfo ModelSymbolInfo => _modelObject.MId.SymbolInfo;

        public override Symbol ContainingSymbol => _containingSymbol;

        public override ImmutableArray<Location> Locations => ImmutableArray.Create(_syntaxReference.GetLocation());

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray.Create(_syntaxReference);

        public override bool IsStatic => false;

        public override void Accept(Microsoft.CodeAnalysis.SymbolVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public override TResult Accept<TResult>(Microsoft.CodeAnalysis.SymbolVisitor<TResult> visitor)
        {
            throw new NotImplementedException();
        }

        public override void Accept(SymbolVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            throw new NotImplementedException();
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<NamedTypeSymbol> GetBaseTypesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved = null)
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public override ImmutableArray<Symbol> GetMembers()
        {
            return ImmutableArray<Symbol>.Empty;
        }

        public override ImmutableArray<Symbol> GetMembers(string name)
        {
            return ImmutableArray<Symbol>.Empty;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            return false;
        }
    }
}
