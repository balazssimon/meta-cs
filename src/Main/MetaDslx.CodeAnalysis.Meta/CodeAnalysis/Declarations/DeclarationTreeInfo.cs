using Microsoft.CodeAnalysis.Syntax;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.CodeAnalysis.Declarations
{
    public class DeclarationTreeInfo
    {
        private int nonDeclarationStack;
        private int collectNameStack;
        private int qualifierStack;
        private int importCount;
        private ArrayBuilder<Identifier> currentName;

        public DeclarationTreeInfo(DeclarationTreeInfo parentScope, DeclarationTreeInfo parentDeclaration, DeclarationTreeInfo parent, string parentProperty, Type symbolType, Type modelObjectType, SyntaxNodeOrToken syntax)
        {
            this.ParentScope = parentScope;
            this.ParentDeclaration = parentDeclaration;
            this.Parent = parent;
            this.Parent = parent;
            this.ParentProperty = parentProperty;
            this.SymbolType = symbolType;
            this.ModelObjectType = modelObjectType;
            this.Syntax = syntax;
            this.Names = new ArrayBuilder<ArrayBuilder<Identifier>>();
            this.Members = new ArrayBuilder<SingleDeclaration>();
            this.Imports = new ArrayBuilder<SyntaxReference>();
            this.ReferenceDirectives = new ArrayBuilder<Syntax.ReferenceDirective>();
            this.Properties = new ArrayBuilder<Property>();
        }

        public DeclarationTreeInfo ParentScope { get; private set; }
        public DeclarationTreeInfo ParentDeclaration { get; private set; }
        public DeclarationTreeInfo Parent { get; private set; }
        public SyntaxNodeOrToken Syntax { get; private set; }
        public Type SymbolType { get; private set; }
        public Type ModelObjectType { get; private set; }
        public bool Merge { get; private set; }
        public bool Detached { get; private set; }
        public string NestingProperty { get; private set; }
        public string ParentProperty { get; private set; }
        public ArrayBuilder<SyntaxReference> Imports { get; private set; }
        public ArrayBuilder<ArrayBuilder<Identifier>> Names { get; private set; }
        public ArrayBuilder<SingleDeclaration> Members { get; private set; }
        public ArrayBuilder<Syntax.ReferenceDirective> ReferenceDirectives { get; private set; }
        public ArrayBuilder<Property> Properties { get; private set; }

        public ArrayBuilder<Identifier> CurrentName
        {
            get { return this.Names.Count > 0 ? this.Names[this.Names.Count - 1] : null; }
        }

        public bool IsNonDeclaration => nonDeclarationStack > 0;
        public bool HasImports => importCount > 0;


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
            Debug.Assert(this.nonDeclarationStack == 0);
            ++this.collectNameStack;
            if (this.collectNameStack == 1 && this.nonDeclarationStack == 0)
            {
                this.currentName = new ArrayBuilder<Identifier>();
                this.Names.Add(this.currentName);
            }
        }

        public void EndName()
        {
            --this.collectNameStack;
            Debug.Assert(this.collectNameStack >= 0);
            Debug.Assert(this.nonDeclarationStack == 0);
            if (this.collectNameStack <= 0)
            {
                this.currentName = null;
            }
        }

        public void BeginImport(SyntaxNodeOrToken syntax)
        {
            ++this.importCount;
            this.BeginNoDeclaration();
        }

        public void EndImport()
        {
            this.EndNoDeclaration();
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

        public void RegisterIdentifier(SyntaxNodeOrToken syntax)
        {
            var node = syntax.GetNodeOrParent();
            this.RegisterIdentifier(new Identifier(node.Language.SyntaxFacts.ExtractName(syntax), node.Language.SyntaxFacts.ExtractMetadataName(syntax), syntax));
        }

        private void RegisterIdentifier(in Identifier identifier)
        {
            if (this.currentName != null)
            {
                this.currentName.Add(identifier);
            }
        }

        public void RegisterReferenceDirective(Syntax.ReferenceDirective directive)
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
            public readonly string Name;
            public readonly string MetadataName;
            public readonly SyntaxNodeOrToken Syntax;

            public Identifier(string name, string metadataName, SyntaxNodeOrToken syntax)
            {
                Name = name;
                MetadataName = metadataName;
                Syntax = syntax;
            }

            public override string ToString()
            {
                return MetadataName;
            }
        }

        public struct Property
        {
            public readonly SyntaxReference SyntaxReference;
            public readonly string Name;
            public readonly SymbolPropertyOwner Owner;
            public readonly Type OwnerType;

            public Property(SyntaxNodeOrToken syntax, string name, SymbolPropertyOwner owner, Type ownerType)
            {
                SyntaxReference = syntax.GetReference();
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
                            if (OwnerType == null || OwnerType.IsAssignableFrom(ancestorSymbol.ModelObjectType)) return ancestorSymbol;
                            ancestorSymbol = ancestorSymbol.ParentDeclaration;
                        }
                        return null;
                    case SymbolPropertyOwner.AncestorScope:
                        var ancestorScope = current.Parent;
                        while (ancestorScope != null)
                        {
                            if (OwnerType == null || OwnerType.IsAssignableFrom(ancestorScope.ModelObjectType)) return ancestorScope;
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
