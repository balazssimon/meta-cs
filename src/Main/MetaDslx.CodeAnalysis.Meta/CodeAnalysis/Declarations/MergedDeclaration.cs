using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis.PooledObjects;
using MetaDslx.CodeAnalysis.Symbols;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Symbols.Source;

namespace MetaDslx.CodeAnalysis.Declarations
{
    public sealed class MergedDeclaration : Declaration
    {
        private readonly ImmutableArray<SingleDeclaration> _declarations;
        private ImmutableArray<MergedDeclaration> _lazyChildren;
        private ImmutableArray<string> _lazyChildNames;
        private Symbol _symbol;

        public MergedDeclaration(ImmutableArray<SingleDeclaration> declarations)
            : base(declarations.IsEmpty ? null : declarations[0].Name,
                  declarations.IsEmpty ? DeclarationKind.None : declarations[0].Kind,
                  declarations.IsEmpty ? false : declarations[0].Merge,
                  false)
        {
            this._declarations = declarations;
        }

        public bool HasDiagnostics
        {
            get
            {
                foreach (var decl in _declarations)
                {
                    if (!decl.Diagnostics.IsEmpty) return true;
                }
                return false;
            }
        }

        public ImmutableArray<SingleDeclaration> Declarations
        {
            get
            {
                return _declarations;
            }
        }

        public ImmutableArray<SyntaxReference> SyntaxReferences
        {
            get
            {
                return _declarations.SelectAsArray(r => r.SyntaxReference);
            }
        }

        public ImmutableArray<SyntaxReference> Imports
        {
            get
            {
                if (Declarations.Length == 1)
                {
                    return Declarations[0].Imports;
                }
                else
                {
                    var builder = ArrayBuilder<SyntaxReference>.GetInstance();
                    foreach (var decl in Declarations)
                    {
                        var imports = decl.Imports;
                        builder.AddRange(imports);
                    }
                    return builder.ToImmutableAndFree();
                }
            }
        }

        public override Type ModelObjectType
        {
            get
            {
                return this._declarations.IsEmpty ? null : this._declarations[0].ModelObjectType;
            }
        }

        public Symbol Symbol => _symbol;

        public Symbol CreateSymbol(Symbol container, SymbolFactory symbolFactory)
        {
            if (_symbol != null)
            {
                Debug.Assert(_symbol.ContainingSymbol == container);
                return _symbol;
            }
            var symbol = symbolFactory.MakeSourceSymbol(container, ModelObjectType, this);
            var mobj = (symbol as IModelSourceSymbol)?.ModelObject;
            Debug.Assert(mobj != null);
            if (Interlocked.CompareExchange(ref _symbol, symbol, null) != null)
            {
                symbolFactory.RemoveSymbol(symbol);
            }
            return _symbol;
        }

        /// <summary>
        /// Used by the Symbol API to set the symbol corresponding to this merged declaration.
        /// Do not call this method from anywhere else.
        /// </summary>
        /// <param name="symbol"></param>
        internal void DangerousSetSymbol(Symbol symbol)
        {
            Debug.Assert(_symbol == null);
            Debug.Assert(symbol != null);
            Interlocked.CompareExchange(ref _symbol, symbol, null);
        }

        public LexicalSortKey GetLexicalSortKey(LanguageCompilation compilation)
        {
            LexicalSortKey sortKey = new LexicalSortKey(Declarations[0].NameLocation, compilation);
            for (var i = 1; i < Declarations.Length; i++)
            {
                sortKey = LexicalSortKey.First(sortKey, new LexicalSortKey(Declarations[i].NameLocation, compilation));
            }

            return sortKey;
        }

        public ImmutableArray<Location> NameLocations
        {
            get
            {
                if (Declarations.Length == 1)
                {
                    return ImmutableArray.Create(Declarations[0].NameLocation);
                }
                else
                {
                    var builder = ArrayBuilder<Location>.GetInstance();
                    foreach (var decl in Declarations)
                    {
                        Location loc = decl.NameLocation;
                        if (loc != null)
                            builder.Add(loc);
                    }
                    return builder.ToImmutableAndFree();
                }
            }
        }

        private void MakeChildren()
        {
            ArrayBuilder<SingleDeclaration> nestedDeclarations = null;

            foreach (var decl in this.Declarations)
            {
                foreach (var child in decl.Children)
                {
                    var asSingle = child as SingleDeclaration;
                    if (asSingle != null)
                    {
                        if (nestedDeclarations == null)
                        {
                            nestedDeclarations = ArrayBuilder<SingleDeclaration>.GetInstance();
                        }
                        nestedDeclarations.Add(asSingle);
                    }
                }
            }

            var members = ArrayBuilder<MergedDeclaration>.GetInstance();
            var memberNames = ArrayBuilder<string>.GetInstance();

            if (nestedDeclarations != null)
            {
                var membersGrouped = nestedDeclarations.ToDictionary(m => m.Identity);
                nestedDeclarations.Free();

                foreach (var memberGroup in membersGrouped.Values)
                {
                    var merged = new MergedDeclaration(memberGroup);
                    members.Add(merged);
                    if (merged.Name != null) memberNames.Add(merged.Name);
                }
            }

            ImmutableInterlocked.InterlockedInitialize(ref _lazyChildren, members.ToImmutableAndFree());
            ImmutableInterlocked.InterlockedInitialize(ref _lazyChildNames, memberNames.ToImmutableAndFree());
        }

        public new ImmutableArray<MergedDeclaration> Children
        {
            get
            {
                if (_lazyChildren.IsDefault) MakeChildren();
                return _lazyChildren;
            }
        }

        public override ImmutableArray<string> ChildNames
        {
            get
            {
                if (_lazyChildNames.IsDefault) MakeChildren();
                return _lazyChildNames;
            }
        }
        
        protected override ImmutableArray<Declaration> GetDeclarationChildren()
        {
            return StaticCast<Declaration>.From(this.Children);
        }

        public SingleDeclaration GetSingleDeclaration(SyntaxNodeOrToken childSyntax)
        {
            if (childSyntax == null) return null;
            foreach (var decl in _declarations)
            {
                if (decl.SyntaxReference.SyntaxTree == childSyntax.SyntaxTree && decl.SyntaxReference.Span == childSyntax.Span) return decl;
            }
            return null;
        }

        public SingleDeclaration GetSingleDeclaration(SyntaxReference childSyntaxReference)
        {
            if (childSyntaxReference == null) return null;
            foreach (var decl in _declarations)
            {
                if (decl.SyntaxReference.SyntaxTree == childSyntaxReference.SyntaxTree && decl.SyntaxReference.Span == childSyntaxReference.Span) return decl;
            }
            return null;
        }

        public static MergedDeclaration Create(ImmutableArray<SingleDeclaration> declarations)
        {
            return new MergedDeclaration(declarations);
        }

        public static MergedDeclaration Create(SingleDeclaration declaration)
        {
            return new MergedDeclaration(ImmutableArray.Create(declaration));
        }

        public static MergedDeclaration Create(
            MergedDeclaration mergedDeclaration,
            SingleDeclaration declaration)
        {
            return new MergedDeclaration(mergedDeclaration._declarations.Add(declaration));
        }

    }
}
