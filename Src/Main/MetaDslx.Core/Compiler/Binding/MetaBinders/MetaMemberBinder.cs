using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.Compiler.Binding.Binders;
using MetaDslx.Compiler.Syntax;

namespace MetaDslx.Compiler.Binding.MetaBinders
{
    public class MetaMemberBinder : MetaBinder
    {
        private MemberBinderPart<MetaBinder> _part;

        public MetaMemberBinder(MetaBinder next, RedNode node) : base(next, node)
        {
        }
    }
}
