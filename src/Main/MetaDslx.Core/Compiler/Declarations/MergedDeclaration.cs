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
using MetaDslx.Compiler.Symbols;
using MetaDslx.Compiler.PooledObjects;

namespace MetaDslx.Compiler.Declarations
{
    public sealed class MergedDeclaration : Declaration
    {
        private readonly ImmutableArray<SingleDeclaration> _declarations;
        private ImmutableArray<MergedDeclaration> _lazyChildren;
        private IReadOnlyDictionary<string, ImmutableArray<MergedDeclaration>> _lazyChildrenByParentProperties;

        public MergedDeclaration(ImmutableArray<SingleDeclaration> declarations)
            : base(declarations.IsEmpty ? string.Empty : declarations[0].Name,
                  declarations.IsEmpty ? false : declarations[0].CanMerge,
                  declarations.IsEmpty ? string.Empty : declarations[0].ParentPropertyToAddTo)
        {
            this._declarations = declarations;
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

        public override ModelSymbolInfo Kind
        {
            get
            {
                return this._declarations.IsEmpty ? null : this._declarations[0].Kind;
            }
        }

        public LexicalSortKey GetLexicalSortKey(Compilation compilation)
        {
            LexicalSortKey sortKey = new LexicalSortKey(Declarations[0].NameLocation, compilation);
            for (var i = 1; i < Declarations.Length; i++)
            {
                sortKey = LexicalSortKey.First(sortKey, new LexicalSortKey(Declarations[i].NameLocation, compilation));
            }

            return sortKey;
        }

        public ImmutableArray<SourceLocation> NameLocations
        {
            get
            {
                if (Declarations.Length == 1)
                {
                    return ImmutableArray.Create(Declarations[0].NameLocation);
                }
                else
                {
                    var builder = ArrayBuilder<SourceLocation>.GetInstance();
                    foreach (var decl in Declarations)
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
                var typesGrouped = nestedDeclarations.ToDictionary(t => t.Identity);
                nestedDeclarations.Free();

                foreach (var typeGroup in typesGrouped.Values)
                {
                    children.Add(new MergedDeclaration(typeGroup));
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
            return StaticCast<Declaration>.From(this.Children);
        }

        public IReadOnlyDictionary<string, ImmutableArray<MergedDeclaration>> ChildrenByParentProperties
        {
            get
            {
                if (_lazyChildrenByParentProperties == null)
                {
                    var result =
                        this.Children.GroupBy(
                            c => c.ParentPropertyToAddTo,
                            c => c,
                            (key, group) => new { Property = key, Items = group.ToImmutableArray() }
                        ).ToDictionary(kvp => kvp.Property, kvp => kvp.Items);
                    Interlocked.CompareExchange(ref _lazyChildrenByParentProperties, result, null);
                }
                return _lazyChildrenByParentProperties;
            }
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
