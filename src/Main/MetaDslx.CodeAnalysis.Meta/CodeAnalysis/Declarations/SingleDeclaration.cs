using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
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
        private readonly Type _modelObjectType;
        private readonly SyntaxReference _syntaxReference;
        private readonly SourceLocation _nameLocation;
        private readonly ImmutableArray<SingleDeclaration> _children;
        private ImmutableArray<string> _lazyChildNames;
        private readonly ImmutableArray<DeclarationTreeInfo.Property> _properties;

        /// <summary>
        /// Any diagnostics reported while converting the Namespace/Type syntax into the Declaration
        /// instance.  Generally, we determine and store some diagnostics here because we don't want 
        /// to have to go back to Syntax when we have our NamespaceSymbol or NamedTypeSymbol.
        /// </summary>
        public readonly ImmutableArray<Diagnostic> Diagnostics;

        public SingleDeclaration(
            string name, 
            DeclarationKind kind,
            Type modelObjectType,
            SyntaxReference syntaxReference,
            SourceLocation nameLocation,
            bool canMerge,
            ImmutableArray<SingleDeclaration> children,
            ImmutableArray<DeclarationTreeInfo.Property> properties,
            ImmutableArray<Diagnostic> diagnostics)
            : base(name, kind, canMerge)
        {
            this._modelObjectType = modelObjectType;
            this._syntaxReference = syntaxReference;
            this._nameLocation = nameLocation;
            this._children = children;
            this._properties = properties;
            this.Diagnostics = diagnostics;
        }

        public override Type ModelObjectType
        {
            get { return this._modelObjectType; }
        }

        public Location Location
        {
            get { return new SourceLocation(this.SyntaxReference); }
        }

        public SyntaxReference SyntaxReference
        {
            get { return this._syntaxReference; }
        }

        public Location NameLocation
        {
            get { return this._nameLocation; }
        }

        public ImmutableArray<DeclarationTreeInfo.Property> Properties
        {
            get { return this._properties; }
        }

        public override ImmutableArray<string> ChildNames
        {
            get
            {
                if (_lazyChildNames.IsDefault)
                {
                    var values = new HashSet<string>(_children.Select(c => c.Name)).ToImmutableArray();
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyChildNames, values);
                }
                return _lazyChildNames;
            }
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

                // cannot merge anonymous symbols
                if (thisDecl.Name == null) return false;
                if (otherDecl.Name == null) return false;

                // kind and name must match
                if ((thisDecl.Kind != otherDecl.Kind) ||
                    (thisDecl.ModelObjectType != otherDecl.ModelObjectType) ||
                    (thisDecl.Name != otherDecl.Name))
                {
                    return false;
                }

                // whether merge is allowed:
                return this._decl.Merge;
            }

            public override int GetHashCode()
            {
                var thisDecl = _decl;
                return Hash.Combine(thisDecl.Kind.GetHashCode(), Hash.Combine(thisDecl.Name?.GetHashCode() ?? 0, thisDecl.ModelObjectType?.GetHashCode() ?? 0));
            }
        }
    }
}
