using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class CompletionPart
    {
        public static readonly CompletionPart None = new CompletionPart();
        public static readonly CompletionPart All = new CompletionPart();
        public static readonly CompletionPart Attributes = new CompletionPart();
        public static readonly CompletionPart AliasTarget = new CompletionPart();
        public static readonly CompletionPart NameToMembersMap = new CompletionPart();
        public static readonly CompletionPart MembersCompleted = new CompletionPart();
        public static readonly CompletionPart NamespaceSymbolAll = new CompletionPart();
        public static readonly CompletionPart TypeArguments = new CompletionPart();
        public static readonly CompletionPart TypeMembers = new CompletionPart();
        public static readonly CompletionPart Members = new CompletionPart();

        public static explicit operator int(CompletionPart completionPart)
        {
            return 0;
        }

        public static explicit operator CompletionPart(int value)
        {
            return CompletionPart.None;
        }
    }
}
