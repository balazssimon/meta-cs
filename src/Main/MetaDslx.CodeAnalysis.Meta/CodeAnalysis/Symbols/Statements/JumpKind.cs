using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Kind of the branch for a <see cref="JumpStatementSymbol"/>
    /// </summary>
    public class JumpKind
    {
        public static readonly JumpKind Continue = new JumpKind(nameof(Continue), 0);
        public static readonly JumpKind Break = new JumpKind(nameof(Break), 1);
        public static readonly JumpKind GoTo = new JumpKind(nameof(GoTo), 2);

        private readonly string _name;
        private readonly int _index;

        public JumpKind(string name)
        {
            _name = name;
            _index = -1;
        }

        private JumpKind(string name, int index)
        {
            _name = name;
            _index = index;
        }

        public int StandardIndex => _index;

        public override string ToString()
        {
            return _name;
        }
    }
}
