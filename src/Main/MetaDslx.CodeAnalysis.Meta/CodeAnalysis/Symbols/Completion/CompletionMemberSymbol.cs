using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Completion
{
    public partial class CompletionMemberSymbol
    {
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
