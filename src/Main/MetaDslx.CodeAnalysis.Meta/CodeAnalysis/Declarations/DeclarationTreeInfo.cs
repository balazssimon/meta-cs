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
        private int nonDeclarationStack;
        private int collectNameStack;
        private int qualifierStack;
        private ArrayBuilder<Identifier> currentName;

        public DeclarationTreeInfo(DeclarationTreeInfo parentScope, DeclarationTreeInfo parentDeclaration, DeclarationTreeInfo parent, string parentPropertyToAddTo, Type type, LanguageSyntaxNode node)
        {
            this.ParentScope = parentScope;
            this.ParentDeclaration = parentDeclaration;
            this.Parent = parent;
            this.Parent = parent;
            this.ParentPropertyToAddTo = parentPropertyToAddTo;
            this.Type = type;
            this.Node = node;
            this.Names = new ArrayBuilder<ArrayBuilder<Identifier>>();
            this.Members = new ArrayBuilder<SingleDeclaration>();
            this.ReferenceDirectives = new ArrayBuilder<ReferenceDirective>();
            this.Properties = new ArrayBuilder<Property>();
        }

        public DeclarationTreeInfo ParentScope { get; private set; }
        public DeclarationTreeInfo ParentDeclaration { get; private set; }
        public DeclarationTreeInfo Parent { get; private set; }
        public LanguageSyntaxNode Node { get; private set; }
        public Type Type { get; private set; }
        public ModelSymbolInfo Kind
        {
            get { return ModelSymbolInfo.GetSymbolInfo(this.Type); }
        }
        public bool Merge { get; private set; }
        public bool Detached { get; private set; }
        public string NestingProperty { get; private set; }
        public string ParentPropertyToAddTo { get; private set; }
        public ArrayBuilder<ArrayBuilder<Identifier>> Names { get; private set; }
        public ArrayBuilder<SingleDeclaration> Members { get; private set; }
        public ArrayBuilder<ReferenceDirective> ReferenceDirectives { get; private set; }
        public ArrayBuilder<Property> Properties { get; private set; }

        public ArrayBuilder<Identifier> CurrentName
        {
            get { return this.Names.Count > 0 ? this.Names[this.Names.Count - 1] : null; }
        }

        public bool IsNonDeclaration => nonDeclarationStack > 0;

        public void BeginNoDeclaration()
        {
            Debug.Assert(this.nonDeclarationStack >= 0);
            ++this.nonDeclarationStack;
        }

        public void EndNoDeclaration()
        {
            --this.nonDeclarationStack;
            Debug.Assert(this.nonDeclarationStack >= 0);
        }

        public void BeginName()
        {
            Debug.Assert(this.collectNameStack >= 0);
            Debug.Assert(this.qualifierStack == 0);
            ++this.collectNameStack;
            if (this.collectNameStack == 1)
            {
                this.currentName = new ArrayBuilder<Identifier>();
                this.Names.Add(this.currentName);
            }
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
        }

        public void EndQualifier()
        {
            --this.qualifierStack;
            Debug.Assert(this.qualifierStack >= 0);
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
        }

        public void RegisterReferenceDirective(ReferenceDirective directive)
        {
            this.ReferenceDirectives.Add(directive);
        }

        public void RegisterNestingProperty(string name)
        {
            this.NestingProperty = name;
        }

        public void RegisterMerge(bool canMerge)
        {
            this.Merge = canMerge;
        }

        public void RegisterProperty(Property property)
        {
            this.Properties.Add(property);
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

            public override string ToString()
            {
                return Text;
            }
        }

        public struct Property
        {
            public readonly SyntaxReference SyntaxReference;
            public readonly string Name;
            public readonly SymbolPropertyOwner Owner;
            public readonly Type OwnerType;

            public Property(LanguageSyntaxNode node, string name, SymbolPropertyOwner owner, Type ownerType)
            {
                SyntaxReference = node?.GetReference();
                Name = name;
                Owner = owner;
                OwnerType = ownerType;
            }

            public DeclarationTreeInfo GetOwnerDeclaration(DeclarationTreeInfo current)
            {
                if (current == null) return null;
                switch (this.Owner)
                {
                    case SymbolPropertyOwner.CurrentSymbol:
                        return current;
                    case SymbolPropertyOwner.CurrentScope:
                        return current.ParentScope;
                    case SymbolPropertyOwner.AncestorSymbol:
                        var ancestorSymbol = current.ParentDeclaration;
                        while (ancestorSymbol != null)
                        {
                            if (OwnerType == null || OwnerType.IsAssignableFrom(ancestorSymbol.Type)) return ancestorSymbol;
                            ancestorSymbol = ancestorSymbol.ParentDeclaration;
                        }
                        return null;
                    case SymbolPropertyOwner.AncestorScope:
                        var ancestorScope = current.Parent;
                        while (ancestorScope != null)
                        {
                            if (OwnerType == null || OwnerType.IsAssignableFrom(ancestorScope.Type)) return ancestorScope;
                            ancestorScope = ancestorScope.ParentScope;
                        }
                        return null;
                    default:
                        throw new NotImplementedException();
                }
            }

            public void RegisterToOwner(DeclarationTreeInfo current)
            {
                var owner = this.GetOwnerDeclaration(current);
                owner.RegisterProperty(this);
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public class PropertyDepthInfo
        {
            public readonly int CurrentScope;
            public readonly int AncestorSymbol;
            public readonly int AncestorScope;

            public PropertyDepthInfo(int currentScope, int ancestorSymbol, int ancestorScope)
            {
                this.CurrentScope = currentScope;
                this.AncestorSymbol = ancestorSymbol;
                this.AncestorScope = ancestorScope;
            }
        }
    }


}
