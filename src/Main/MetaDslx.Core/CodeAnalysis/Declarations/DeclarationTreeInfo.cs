using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferenceDirective = MetaDslx.CodeAnalysis.Syntax.ReferenceDirective;

namespace MetaDslx.CodeAnalysis.Declarations
{
    public class DeclarationTreeInfo
    {
        private int collectNameStack;
        private int qualifierStack;
        private ArrayBuilder<Identifier> currentName;

        public DeclarationTreeInfo(DeclarationTreeInfo parent, Type type, LanguageSyntaxNode node)
        {
            this.Parent = parent;
            if (parent != null)
            {
                this.ParentPropertyToAddTo = parent.CurrentProperty;
            }
            this.Type = type;
            this.Node = node;
            this.Names = new ArrayBuilder<ArrayBuilder<Identifier>>();
            this.Members = new ArrayBuilder<SingleDeclaration>();
            this.ReferenceDirectives = new ArrayBuilder<ReferenceDirective>();
            this.PropertyStack = new Stack<string>();
        }

        public DeclarationTreeInfo Parent { get; private set; }
        public LanguageSyntaxNode Node { get; private set; }
        public Type Type { get; private set; }
        public ModelSymbolInfo Kind
        {
            get { return ModelSymbolInfo.GetSymbolInfo(this.Type); }
        }
        public bool CanMerge { get; private set; }
        public string NestingProperty { get; private set; }
        public string ParentPropertyToAddTo { get; private set; }
        public ArrayBuilder<ArrayBuilder<Identifier>> Names { get; private set; }
        public ArrayBuilder<SingleDeclaration> Members { get; private set; }
        public ArrayBuilder<ReferenceDirective> ReferenceDirectives { get; private set; }
        public Stack<string> PropertyStack { get; private set; }

        public string CurrentProperty
        {
            get { return this.PropertyStack.Count > 0 ? this.PropertyStack.Peek() : null; }
        }

        public ArrayBuilder<Identifier> CurrentName
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
            this.currentName = new ArrayBuilder<Identifier>();
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

        public void RegisterIdentifier(SyntaxToken token)
        {
            this.RegisterIdentifier(new Identifier(token.Text, token));
        }

        public void RegisterIdentifier(LanguageSyntaxNode node)
        {
            this.RegisterIdentifier(new Identifier(node.Language.SyntaxFacts.ExtractName(node), node));
        }

        private void RegisterIdentifier(in Identifier identifier)
        {
            if (this.currentName != null)
            {
                this.currentName.Add(identifier);
            }
            else
            {
                var singleName = new ArrayBuilder<Identifier>();
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

        public void RegisterReferenceDirective(ReferenceDirective directive)
        {
            this.ReferenceDirectives.Add(directive);
        }

        public void RegisterNestingProperty(string name)
        {
            this.NestingProperty = name;
        }

        public void RegisterCanMerge(bool canMerge)
        {
            this.CanMerge = canMerge;
        }

        public struct Identifier
        {
            public readonly string Text;
            public readonly SyntaxNodeOrToken Syntax;

            public Identifier(string text, SyntaxNodeOrToken syntax)
            {
                Text = text;
                Syntax = syntax;
            }
        }
    }


}
