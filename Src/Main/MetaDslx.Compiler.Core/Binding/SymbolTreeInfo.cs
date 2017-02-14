using MetaDslx.Compiler.Declarations;
using MetaDslx.Compiler.References;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public class SymbolTreeInfo
    {
        private int collectNameStack;
        private int qualifierStack;
        private ArrayBuilder<RedNode> currentName;

        public SymbolTreeInfo(SymbolTreeInfo parent, IMetaSymbol symbol, SyntaxNode node)
        {
            this.Parent = parent;
            this.Symbol = symbol;
            this.Names = new ArrayBuilder<ArrayBuilder<RedNode>>();
            this.PropertyStack = new Stack<string>();
        }

        public SymbolTreeInfo Parent { get; private set; }
        public SyntaxNode Node { get; private set; }
        public IMetaSymbol Symbol { get; private set; }
        public ArrayBuilder<ArrayBuilder<RedNode>> Names { get; private set; }
        public Stack<string> PropertyStack { get; private set; }

        public string CurrentProperty
        {
            get { return this.PropertyStack.Count > 0 ? this.PropertyStack.Peek() : null; }
        }

        public ArrayBuilder<RedNode> CurrentName
        {
            get { return this.Names.Count > 0 ? this.Names[this.Names.Count - 1] : null; }
        }

        public void BeginName()
        {
            Debug.Assert(this.collectNameStack >= 0);
            Debug.Assert(this.qualifierStack == 0);
            ++this.collectNameStack;
        }

        public void EndName()
        {
            --this.collectNameStack;
            Debug.Assert(this.collectNameStack >= 0);
            Debug.Assert(this.qualifierStack == 0);
            if (this.collectNameStack <= 0)
            {
                this.currentName = null;
            }
        }

        public void BeginQualifier()
        {
            Debug.Assert(this.qualifierStack >= 0);
            ++this.qualifierStack;
            this.currentName = new ArrayBuilder<RedNode>();
            this.Names.Add(this.currentName);
        }

        public void EndQualifier()
        {
            --this.qualifierStack;
            Debug.Assert(this.qualifierStack >= 0);
            if (this.qualifierStack <= 0)
            {
                this.currentName = null;
            }
        }

        public void RegisterIdentifier(RedNode identifier)
        {
            if (this.currentName != null)
            {
                this.currentName.Add(identifier);
            }
            else
            {
                var singleName = new ArrayBuilder<RedNode>();
                singleName.Add(identifier);
                this.Names.Add(singleName);
            }
        }

        public void BeginProperty(string name)
        {
            this.PropertyStack.Push(name);
        }

        public void EndProperty()
        {
            this.PropertyStack.Pop();
        }

    }

}
