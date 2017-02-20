using MetaDslx.Compiler.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public class NameQualifier
    {
        private readonly string name;
        private readonly RedNode node;

        public NameQualifier(string name, RedNode node)
        {
            this.name = name;
            this.node = node;
        }

        public string Name
        {
            get { return this.name; }
        }

        public RedNode Node
        {
            get { return this.node; }
        }
    }
}
