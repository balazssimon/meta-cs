using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public interface ICachedRuleContext
    {
        GreenNode CachedNode { get; }
    }
}
