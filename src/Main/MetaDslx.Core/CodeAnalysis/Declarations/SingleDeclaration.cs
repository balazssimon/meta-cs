using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.CodeAnalysis.Declarations
{
    public interface IDeclarationIdentity : IEquatable<IDeclarationIdentity>
    {

    }

    public class SingleDeclaration : Declaration
    {
        private readonly ModelSymbolInfo _kind;
        private readonly SyntaxReference _syntaxReference;
        private readonly SourceLocation _nameLocation;
        private readonly ImmutableArray<SingleDeclaration> _children;

        /// <summary>
        /// Any diagnostics reported while converting the Namespace/Type syntax into the Declaration
        /// instance.  Generally, we determine and store some diagnostics here because we don't want 
        /// to have to go back to Syntax when we have our NamespaceSymbol or NamedTypeSymbol.
        /// </summary>
        public readonly ImmutableArray<Diagnostic> Diagnostics;

        public SingleDeclaration(
            string name, 
            ModelSymbolInfo kind,
            SyntaxReference syntaxReference,
            SourceLocation nameLocation,
            bool canMerge,
            string parentPropertyToAddTo,
            ImmutableArray<SingleDeclaration> children,
            ImmutableArray<Diagnostic> diagnostics)
            : base(name, canMerge, parentPropertyToAddTo)
        {
            this._kind = kind;
            this._syntaxReference = syntaxReference;
            this._nameLocation = nameLocation;
            this._children = children;
            this.Diagnostics = diagnostics;
        }

        public override ModelSymbolInfo Kind
        {
            get { return this._kind; }
        }

        public SourceLocation Location
        {
            get { return new SourceLocation(this.SyntaxReference); }
        }

        public SyntaxReference SyntaxReference
        {
            get { return this._syntaxReference; }
        }

        public SourceLocation NameLocation
        {
            get { return this._nameLocation; }
        }

        protected override ImmutableArray<Declaration> GetDeclarationChildren()
        {
            return StaticCast<Declaration>.From(this._children);
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
