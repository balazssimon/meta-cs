using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Syntax
{
    internal static class SyntaxExtensions
    {
        /// <summary>
        /// Returns this list as a <see cref="MetaDslx.Compiler.SeparatedSyntaxList&lt;TNode&gt;"/>.
        /// </summary>
        /// <typeparam name="TOther">The type of the list elements in the separated list.</typeparam>
        /// <returns></returns>
        internal static SeparatedSyntaxList<TOther> AsSeparatedList<TOther>(this SyntaxNodeOrTokenList list) where TOther : SyntaxNode
        {
            var builder = SeparatedSyntaxListBuilder<TOther>.Create();
            foreach (var i in list)
            {
                var node = i.AsNode();
                if (node != null)
                {
                    builder.Add((TOther)node);
                }
                else
                {
                    builder.AddSeparator(i.AsToken());
                }
            }

            return builder.ToList();
        }
    }
}
