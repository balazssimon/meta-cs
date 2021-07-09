using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Model
{
    public partial class ModelMemberSymbol
    {
        private ImmutableArray<DeclaredSymbol> _lazyMembers;
        private ImmutableArray<NamedTypeSymbol> _lazyTypeMembers;

        public override bool IsStatic => false;

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            if (_lazyMembers.IsDefault)
            {
                ImmutableInterlocked.InterlockedInitialize(ref _lazyMembers, SymbolFactory.GetChildDeclaredSymbols(ModelObject));
            }
            return _lazyMembers;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            if (_lazyTypeMembers.IsDefault)
            {
                ImmutableInterlocked.InterlockedInitialize(ref _lazyTypeMembers, GetMembers().OfType<NamedTypeSymbol>().ToImmutableArray());
            }
            return _lazyTypeMembers;
        }

        public override bool CanOverrideOrHide(MemberSymbol other)
        {
            var otherMember = other as IModelSymbol;
            if ((object)otherMember == null) return false;
            return this.Kind == other.Kind;
        }

        protected override bool MatchesOverride(DeclaredSymbol otherMember)
        {
            var other = otherMember as IModelSymbol;
            if ((object)other == null) return false;
            return this.Kind == otherMember.Kind && this.Name == otherMember.Name;
        }

    }
}
