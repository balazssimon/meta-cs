using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Utilities;
using System.Threading;

namespace MetaDslx.Compiler.Declarations
{
    public sealed class MergedDeclaration : Declaration
    {
        private readonly ImmutableArray<SingleDeclaration> _declarations;
        private ImmutableArray<MergedDeclaration> _lazyChildren;

        public MergedDeclaration(ImmutableArray<SingleDeclaration> declarations)
            : base(declarations[0].Name)
        {
            this._declarations = declarations;
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

        public override ModelSymbolInfo Kind
        {
            get
            {
                return this._declarations[0].Kind;
            }
        }

        public ImmutableArray<SingleDeclaration> Declarations
        {
            get
            {
                return this._declarations;
            }
        }

        public ImmutableArray<SyntaxReference> SyntaxReferences
        {
            get
            {
                if (_declarations.Length == 1)
                {
                    return ImmutableArray.Create<SyntaxReference>(_declarations[0].SyntaxReference);
                }
                else
                {
                    var builder = ArrayBuilder<SyntaxReference>.GetInstance();
                    foreach (var decl in _declarations)
                    {
                        SyntaxReference sref = decl.SyntaxReference;
                        if (sref != null)
                            builder.Add(sref);
                    }
                    return builder.ToImmutableAndFree();
                }
            }
        }

        public ImmutableArray<Location> NameLocations
        {
            get
            {
                if (_declarations.Length == 1)
                {
                    return ImmutableArray.Create<Location>(_declarations[0].NameLocation);
                }
                else
                {
                    var builder = ArrayBuilder<Location>.GetInstance();
                    foreach (var decl in _declarations)
                    {
                        SourceLocation loc = decl.NameLocation;
                        if (loc != null)
                            builder.Add(loc);
                    }
                    return builder.ToImmutableAndFree();
                }
            }
        }

        private ImmutableArray<MergedDeclaration> MakeChildren()
        {
            ArrayBuilder<SingleDeclaration> nestedDeclarations = null;

            foreach (var decl in this.Declarations)
            {
                foreach (var child in decl.Children)
                {
                    var asType = child as SingleDeclaration;
                    if (asType != null)
                    {
                        if (nestedDeclarations == null)
                        {
                            nestedDeclarations = ArrayBuilder<SingleDeclaration>.GetInstance();
                        }
                        nestedDeclarations.Add(asType);
                    }
                }
            }

            var children = ArrayBuilder<MergedDeclaration>.GetInstance();

            if (nestedDeclarations != null)
            {
                var nestedGrouped = nestedDeclarations.ToDictionary(n => n.Identity);
                nestedDeclarations.Free();

                foreach (var nestedGroup in nestedGrouped.Values)
                {
                    children.Add(new MergedDeclaration(nestedGroup));
                }
            }

            return children.ToImmutableAndFree();
        }

        public new ImmutableArray<MergedDeclaration> Children
        {
            get
            {
                if (_lazyChildren.IsDefault)
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyChildren, MakeChildren());
                }

                return _lazyChildren;
            }
        }

        protected override ImmutableArray<Declaration> GetDeclarationChildren()
        {
            return ImmutableArray<Declaration>.CastUp(this.Children);
        }

        /*
        public LexicalSortKey GetLexicalSortKey(Compilation compilation)
        {
            LexicalSortKey sortKey = new LexicalSortKey(_declarations[0].NameLocation, compilation);
            for (var i = 1; i < _declarations.Length; i++)
            {
                sortKey = LexicalSortKey.First(sortKey, new LexicalSortKey(_declarations[i].NameLocation, compilation));
            }

            return sortKey;
        }
        */
    }
}
