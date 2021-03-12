using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Declarations
{
    using Property = DeclarationTreeInfo.Property;
    using Identifier = DeclarationTreeInfo.Identifier;

    public class DeclarationTreeBuilderVisitor : SyntaxVisitor
    {
        private readonly LanguageSyntaxTree _syntaxTree;
        private readonly string _scriptClassName;
        private readonly bool _isSubmission;
        private DeclarationTreeInfo _rootDeclarationInfo;
        private DeclarationTreeInfo _currentDeclarationInfo;
        private DeclarationTreeInfo _currentScopeDeclarationInfo;

        protected DeclarationTreeBuilderVisitor(LanguageSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
        {
            _syntaxTree = syntaxTree;
            _scriptClassName = scriptClassName;
            _isSubmission = isSubmission;
            this.PropertyStack = new Stack<Property>();
        }

        public Language Language
        {
            get { return _syntaxTree.Language; }
        }

        protected DeclarationTreeInfo RootDeclarationInfo
        {
            get { return _rootDeclarationInfo; }
        }

        protected DeclarationTreeInfo CurrentDeclarationInfo
        {
            get { return _currentDeclarationInfo; }
        }

        protected DeclarationTreeInfo CurrentScopeDeclarationInfo
        {
            get { return _currentScopeDeclarationInfo; }
        }

        public Stack<Property> PropertyStack { get; private set; }

        public Property CurrentProperty
        {
            get { return this.PropertyStack.Count > 0 ? this.PropertyStack.Peek() : default; }
        }

        protected RootSingleDeclaration CreateRoot(LanguageSyntaxNode node, Type type)
        {
            if (_syntaxTree.Options.Kind != SourceCodeKind.Regular)
            {
                return this.CreateScriptRootDeclaration(node, type);
            }
            else
            {
                return this.CreateRegularRootDeclaration(node, type);
            }
        }

        protected RootSingleDeclaration CreateRootDeclaration(LanguageSyntaxNode node, Type type)
        {
            RootSingleDeclaration result = null;
            _rootDeclarationInfo = this.BeginDeclaration(type, node);
            try
            {
                this.BeginScope(node);
                try
                {
                    node.Accept(this);
                }
                finally
                {
                    this.EndScope();
                }
            }
            finally
            {
                result = (RootSingleDeclaration)this.EndDeclaration();
            }
            return result;
        }

        protected virtual RootSingleDeclaration CreateRegularRootDeclaration(LanguageSyntaxNode node, Type type)
        {
            return this.CreateRootDeclaration(node, type);
        }

        protected virtual RootSingleDeclaration CreateScriptRootDeclaration(LanguageSyntaxNode node, Type type)
        {
            return this.CreateRootDeclaration(node, type);
        }

        protected virtual DeclarationTreeInfo CreateDeclarationInfo(DeclarationTreeInfo parentScope, DeclarationTreeInfo parentDeclaration, DeclarationTreeInfo parent, Property parentProperty, Type type, LanguageSyntaxNode node)
        {
            return new DeclarationTreeInfo(parentScope, parentDeclaration, parent, parentProperty.Name, type, node);
        }

        //***
        protected DeclarationTreeInfo BeginSymbolDef(LanguageSyntaxNode node, Type type, string nestingProperty = null, bool merge = false)
        {
            var result = this.BeginDeclaration(type, node);
            if (nestingProperty != null) result.RegisterNestingProperty(nestingProperty);
            if (merge) result.RegisterMerge(merge);
            return result;
        }

        protected SingleDeclaration EndSymbolDef()
        {
            return this.EndDeclaration();
        }

        protected void BeginProperty(LanguageSyntaxNode node, string name, object value = null, SymbolPropertyOwner owner = SymbolPropertyOwner.CurrentSymbol, Type ownerType = null)
        {
            this.PropertyStack.Push(new Property(node, name, owner, ownerType));
        }

        protected void EndProperty()
        {
            var property = this.PropertyStack.Pop();
            property.RegisterToOwner(_currentDeclarationInfo);
        }

        protected void BeginName(LanguageSyntaxNode node)
        {
            this.BeginName();
        }

        protected void BeginScope(LanguageSyntaxNode node, bool local = false)
        {
            _currentScopeDeclarationInfo = _currentDeclarationInfo;
        }

        protected void EndScope()
        {
            if (_currentScopeDeclarationInfo == null) throw new InvalidOperationException("No scope declaration is open.");
            _currentScopeDeclarationInfo = _currentScopeDeclarationInfo.ParentScope;
        }

        protected void BeginQualifier(LanguageSyntaxNode node)
        {
            this.BeginQualifier();
        }

        protected void BeginSymbolUse(LanguageSyntaxNode node, ImmutableArray<Type> types)
        {
            this.BeginNoDeclaration(null, node);
        }

        protected void EndSymbolUse()
        {
            this.EndNoDeclaration();
        }
        //***

        protected DeclarationTreeInfo BeginDeclaration(Type type, LanguageSyntaxNode node)
        {
            DeclarationTreeInfo ownerSymbol = this.CurrentProperty.GetOwnerDeclaration(_currentDeclarationInfo);
            _currentDeclarationInfo = this.CreateDeclarationInfo(_currentScopeDeclarationInfo, _currentDeclarationInfo, ownerSymbol, this.CurrentProperty, type, node);
            return _currentDeclarationInfo;
        }

        protected SingleDeclaration EndDeclaration()
        {
            if (_currentDeclarationInfo == null) throw new InvalidOperationException("No declaration is open.");
            SingleDeclaration result = this.CreateDeclaration(_currentDeclarationInfo);
            _currentDeclarationInfo = _currentDeclarationInfo.ParentDeclaration;
            return result;
        }

        protected void BeginNoDeclaration(Type type, LanguageSyntaxNode node)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.BeginNoDeclaration();
        }

        protected void EndNoDeclaration()
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.EndNoDeclaration();
        }

        protected void BeginName()
        {
            if (_currentDeclarationInfo == null)
            {
                Debug.Assert(false, "BeginName can only be used inside a declaration.");
                return;
            }
            _currentDeclarationInfo.BeginName();
        }

        protected void EndName()
        {
            if (_currentDeclarationInfo == null)
            {
                Debug.Assert(false, "EndName can only be used inside a declaration.");
                return;
            }
            _currentDeclarationInfo.EndName();
        }

        protected void BeginQualifier()
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.BeginQualifier();
        }

        protected void EndQualifier()
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.EndQualifier();
        }

        protected void BeginImport(SyntaxNodeOrToken syntax)
        {
            if (_currentDeclarationInfo == null) return;
            this.BeginNoDeclaration(null, (LanguageSyntaxNode)syntax.NodeOrParent);
            _currentDeclarationInfo.BeginImport(syntax);
        }

        protected void EndImport()
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.EndImport();
            this.EndNoDeclaration();
        }

        protected void RegisterIdentifier(SyntaxNodeOrToken syntax)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.RegisterIdentifier(syntax);
        }

        protected void RegisterNestingProperty(string name)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.RegisterNestingProperty(name);
        }

        protected void RegisterCanMerge(bool canMerge)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.RegisterMerge(canMerge);
        }

        protected virtual SingleDeclaration CreateDeclaration(DeclarationTreeInfo declaration)
        {
            DeclarationTreeInfo parent = declaration.Parent;
            ImmutableArray<Diagnostic> diagnostics;
            var symbolFacts = Language.SymbolFacts;
            var kind = symbolFacts.ToDeclarationKind(symbolFacts.GetSymbolType(declaration.ModelObjectType));
            diagnostics = ImmutableArray<Diagnostic>.Empty;
            if (parent == null)
            {
                var rootDeclaration = new RootSingleDeclaration(declaration.ModelObjectType, declaration.Node.GetReference(), declaration.Members.ToImmutable(), declaration.ReferenceDirectives.ToImmutable(), diagnostics);
                return rootDeclaration;
            }
            var parentProp = Language.SymbolFacts.GetProperty(parent.ModelObjectType, declaration.ParentProperty);
            if (parent.ModelObjectType == null && declaration.ParentProperty == null || parentProp != null)
            {
                var isContainment = parentProp == null || Language.SymbolFacts.IsContainmentProperty(parentProp);
                if (declaration.Names.Count == 0)
                {
                    SingleDeclaration anonymousDeclaration = new SingleDeclaration(null, kind, declaration.ModelObjectType, declaration.Node.GetReference(), new SourceLocation(declaration.Node), false, declaration.HasImports, false, declaration.ParentProperty, declaration.Members.ToImmutable(), declaration.Properties.ToImmutable(), diagnostics);
                    parent.Members.Add(anonymousDeclaration);
                    return anonymousDeclaration;
                }
                foreach (var qualifier in declaration.Names)
                {
                    int count = qualifier.Count;
                    if (count > 0)
                    {
                        var identifier = qualifier[count - 1];
                        var parentProperty = count == 1 ? declaration.ParentProperty : declaration.NestingProperty;
                        var decl = new SingleDeclaration(identifier.Text, kind, declaration.ModelObjectType, declaration.Node.GetReference(), new SourceLocation(identifier.Syntax), isContainment && declaration.Merge, declaration.HasImports, false, parentProperty, declaration.Members.ToImmutable(), declaration.Properties.ToImmutable(), diagnostics);
                        var deepestDecl = decl;
                        for (int i = count - 2; i >= 0; i--)
                        {
                            parentProperty = i == 0 ? declaration.ParentProperty : declaration.NestingProperty;
                            identifier = qualifier[i];
                            decl = new SingleDeclaration(identifier.Text, kind, declaration.ModelObjectType, declaration.Node.GetReference(), new SourceLocation(identifier.Syntax), isContainment && declaration.Merge, false, true, parentProperty, ImmutableArray.Create(decl), ImmutableArray<DeclarationTreeInfo.Property>.Empty, ImmutableArray<Diagnostic>.Empty);
                        }
                        parent.Members.Add(decl);
                        return deepestDecl;
                    }
                }
            }
            Debug.Assert(false);
            return null;
        }
        
    }
}
