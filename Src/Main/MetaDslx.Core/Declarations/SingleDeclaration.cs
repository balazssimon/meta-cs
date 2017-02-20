using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Declarations
{
    public interface IDeclarationIdentity : IEquatable<IDeclarationIdentity>
    {

    }

    public class SingleDeclaration : Declaration
    {
        private readonly ModelSymbolInfo kind;
        private readonly SyntaxReference syntaxReference;
        private readonly SourceLocation nameLocation;
        private readonly ImmutableArray<SingleDeclaration> children;

        public SingleDeclaration(
            string name, 
            ModelSymbolInfo kind,
            SyntaxReference syntaxReference,
            SourceLocation nameLocation,
            bool canMerge,
            string parentPropertyToAddTo,
            ImmutableArray<SingleDeclaration> children)
            : base(name, canMerge, parentPropertyToAddTo)
        {
            this.kind = kind;
            this.syntaxReference = syntaxReference;
            this.nameLocation = nameLocation;
            this.children = children;
        }

        public override ModelSymbolInfo Kind
        {
            get { return this.kind; }
        }

        public SyntaxReference SyntaxReference
        {
            get { return this.syntaxReference; }
        }

        public SourceLocation NameLocation
        {
            get { return this.nameLocation; }
        }

        protected override ImmutableArray<Declaration> GetDeclarationChildren()
        {
            return ImmutableArray<Declaration>.CastUp(this.children);
        }


        public virtual IDeclarationIdentity Identity
        {
            get
            {
                return NameAndKindIdentity(this);
            }
        }

        /// <summary>
        /// Identity based on name and kind. Two declarations can be merged if their names and kinds are the same.
        /// </summary>
        /// <param name="declaration">The declaration for which to create the identity.</param>
        /// <returns>The identity for the declaration.</returns>
        public static IDeclarationIdentity NameAndKindIdentity(SingleDeclaration declaration)
        {
            return new DeclarationNameAndKindIdentity(declaration);
        }

        // identity that is used when collecting all declarations 
        // of same type across multiple containers
        private class DeclarationNameAndKindIdentity : IDeclarationIdentity
        {
            private readonly SingleDeclaration _decl;

            internal DeclarationNameAndKindIdentity(SingleDeclaration decl)
            {
                _decl = decl;
            }

            public override bool Equals(object obj)
            {
                return obj is DeclarationNameAndKindIdentity && Equals((DeclarationNameAndKindIdentity)obj);
            }

            public bool Equals(IDeclarationIdentity obj)
            {
                return obj is DeclarationNameAndKindIdentity && Equals((DeclarationNameAndKindIdentity)obj);
            }

            public bool Equals(DeclarationNameAndKindIdentity other)
            {
                var thisDecl = _decl;
                var otherDecl = other._decl;

                // same as itself
                if ((object)thisDecl == otherDecl)
                {
                    return true;
                }

                // kind and name must match
                if ((thisDecl.Kind != otherDecl.Kind) ||
                    (thisDecl.Name != otherDecl.Name))
                {
                    return false;
                }

                // whether merge is allowed:
                return this._decl.CanMerge;
            }

            public override int GetHashCode()
            {
                var thisDecl = _decl;
                return Hash.Combine(thisDecl.Name?.GetHashCode() ?? 0, thisDecl.Kind?.GetHashCode() ?? 0);
            }
        }
    }
}
