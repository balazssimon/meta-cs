using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    [DebuggerDisplay("{ToString(), nq}")]
    public struct BinderPosition
    {
        public readonly Binder Binder;
        public readonly Binder LowestBinderInSyntax;
        public readonly SyntaxNodeOrToken Syntax;

        public BinderPosition(Binder binder, Binder lowestBinder, SyntaxNodeOrToken syntax)
        {
            Binder = binder;
            LowestBinderInSyntax = lowestBinder;
            Syntax = syntax;
        }

        public override string ToString()
        {
            return $"{Syntax.GetKind()} {Binder.ToString()}";
        }
    }

    [DebuggerDisplay("{ToString(), nq}")]
    public struct BinderPosition<T>
        where T : Binder
    {
        public readonly T Binder;
        public readonly Binder LowestBinderInSyntax;
        public readonly SyntaxNodeOrToken Syntax;

        public BinderPosition(T binder, Binder lowestBinder, SyntaxNodeOrToken syntax)
        {
            Binder = binder;
            LowestBinderInSyntax = lowestBinder;
            Syntax = syntax;
        }

        public static implicit operator BinderPosition(BinderPosition<T> node)
        {
            return new BinderPosition(node.Binder, node.LowestBinderInSyntax, node.Syntax);
        }

        public override string ToString()
        {
            return $"{Syntax.GetKind()} {Binder.ToString()}";
        }
    }
}
