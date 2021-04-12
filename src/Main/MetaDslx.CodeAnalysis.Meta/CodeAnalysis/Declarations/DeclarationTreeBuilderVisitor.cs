using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MetaDslx.Modeling;
using MetaDslx.CodeAnalysis.Symbols;

namespace MetaDslx.CodeAnalysis.Declarations
{
    using Property = DeclarationTreeInfo.Property;
    using Identifier = DeclarationTreeInfo.Identifier;

    public class DeclarationTreeBuilderVisitor : SyntaxVisitor
    {
        private readonly LanguageSyntaxTree _syntaxTree;
        private readonly SymbolFacts _symbolFacts;
        private readonly string _scriptClassName;
        private readonly bool _isSubmission;
        private DeclarationTreeInfo _rootDeclarationInfo;
        private DeclarationTreeInfo _currentDeclarationInfo;
        private DeclarationTreeInfo _currentScopeDeclarationInfo;

        protected DeclarationTreeBuilderVisitor(LanguageSyntaxTree syntaxTree, SymbolFacts symbolFacts, string scriptClassName, bool isSubmission)
        {
            if (syntaxTree == null) throw new ArgumentNullException(nameof(syntaxTree));
            if (symbolFacts == null) throw new ArgumentNullException(nameof(symbolFacts));
            _syntaxTree = syntaxTree;
            _symbolFacts = symbolFacts;
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

        public virtual void Visit(SyntaxToken token)
        {
        }

        protected RootSingleDeclaration CreateRoot(LanguageSyntaxNode syntax, Type type)
        {
            if (_syntaxTree.Options.Kind != SourceCodeKind.Regular)
            {
                return this.CreateScriptRootDeclaration(syntax, type);
            }
            else
            {
                return this.CreateRegularRootDeclaration(syntax, type);
            }
        }

        protected RootSingleDeclaration CreateRootDeclaration(LanguageSyntaxNode syntax, Type type)
        {
            RootSingleDeclaration result = null;
            _rootDeclarationInfo = this.BeginDefine(syntax, type);
            try
            {
                this.BeginScope(syntax);
                try
                {
                    syntax.Accept(this);
                }
                finally
                {
                    this.EndScope(syntax);
                }
            }
            finally
            {
                result = (RootSingleDeclaration)this.EndDefine(syntax, type);
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

        protected virtual DeclarationTreeInfo CreateDeclarationInfo(DeclarationTreeInfo parentScope, DeclarationTreeInfo parentDeclaration, DeclarationTreeInfo parent, Property parentProperty, Type symbolType, Type modelObjectType, SyntaxNodeOrToken node)
        {
            return new DeclarationTreeInfo(parentScope, parentDeclaration, parent, parentProperty.Name, symbolType, modelObjectType, node);
        }

        //***
        protected DeclarationTreeInfo BeginDefine(SyntaxNodeOrToken syntax, Type type, string nestingProperty = null, bool merge = false)
        {
            DeclarationTreeInfo ownerSymbol = this.CurrentProperty.GetOwnerDeclaration(_currentDeclarationInfo);
            _currentDeclarationInfo = this.CreateDeclarationInfo(_currentScopeDeclarationInfo, _currentDeclarationInfo, ownerSymbol, this.CurrentProperty, _symbolFacts.GetSymbolType(type), type, syntax);
            if (nestingProperty != null) _currentDeclarationInfo.RegisterNestingProperty(nestingProperty);
            if (merge) _currentDeclarationInfo.RegisterMerge(merge);
            return _currentDeclarationInfo;
        }

        protected SingleDeclaration EndDefine(SyntaxNodeOrToken syntax, Type type, string nestingProperty = null, bool merge = false)
        {
            if (_currentDeclarationInfo == null) throw new InvalidOperationException("No declaration is open.");
            SingleDeclaration result = this.CreateDeclaration(_currentDeclarationInfo);
            _currentDeclarationInfo = _currentDeclarationInfo.ParentDeclaration;
            return result;
        }

        protected DeclarationTreeInfo BeginSymbol(SyntaxNodeOrToken syntax, Type type, string nestingProperty = null, bool merge = false)
        {
            DeclarationTreeInfo ownerSymbol = this.CurrentProperty.GetOwnerDeclaration(_currentDeclarationInfo);
            _currentDeclarationInfo = this.CreateDeclarationInfo(_currentScopeDeclarationInfo, _currentDeclarationInfo, ownerSymbol, this.CurrentProperty, type, null, syntax);
            if (nestingProperty != null) _currentDeclarationInfo.RegisterNestingProperty(nestingProperty);
            if (merge) _currentDeclarationInfo.RegisterMerge(merge);
            return _currentDeclarationInfo;
        }

        protected SingleDeclaration EndSymbol(SyntaxNodeOrToken syntax, Type type, string nestingProperty = null, bool merge = false)
        {
            if (_currentDeclarationInfo == null) throw new InvalidOperationException("No declaration is open.");
            SingleDeclaration result = this.CreateDeclaration(_currentDeclarationInfo);
            _currentDeclarationInfo = _currentDeclarationInfo.ParentDeclaration;
            return result;
        }

        protected void BeginImport(SyntaxNodeOrToken syntax)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.BeginImport(syntax);
        }

        protected void EndImport(SyntaxNodeOrToken syntax)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.EndImport();
        }

        protected void BeginUse(SyntaxNodeOrToken syntax, ImmutableArray<Type> types)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.BeginNoDeclaration();
        }

        protected void EndUse(SyntaxNodeOrToken syntax, ImmutableArray<Type> types)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.EndNoDeclaration();
        }

        protected void BeginProperty(SyntaxNodeOrToken syntax, string name, object value = null, SymbolPropertyOwner owner = SymbolPropertyOwner.CurrentSymbol, Type ownerType = null)
        {
            this.PropertyStack.Push(new Property(syntax, name, owner, ownerType));
        }

        protected void EndProperty(SyntaxNodeOrToken syntax, string name, object value = null, SymbolPropertyOwner owner = SymbolPropertyOwner.CurrentSymbol, Type ownerType = null)
        {
            var property = this.PropertyStack.Pop();
            property.RegisterToOwner(_currentDeclarationInfo);
        }

        protected void BeginName(SyntaxNodeOrToken syntax)
        {
            if (_currentDeclarationInfo == null)
            {
                Debug.Assert(false, "BeginName can only be used inside a declaration.");
                return;
            }
            _currentDeclarationInfo.BeginName();
        }

        protected void EndName(SyntaxNodeOrToken syntax)
        {
            if (_currentDeclarationInfo == null)
            {
                Debug.Assert(false, "EndName can only be used inside a declaration.");
                return;
            }
            _currentDeclarationInfo.EndName();
        }

        protected void BeginScope(SyntaxNodeOrToken syntax, bool local = false)
        {
            _currentScopeDeclarationInfo = _currentDeclarationInfo;
        }

        protected void EndScope(SyntaxNodeOrToken syntax, bool local = false)
        {
            if (_currentScopeDeclarationInfo == null) throw new InvalidOperationException("No scope declaration is open.");
            _currentScopeDeclarationInfo = _currentScopeDeclarationInfo.ParentScope;
        }

        protected void BeginQualifier(SyntaxNodeOrToken syntax)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.BeginQualifier();
        }

        protected void EndQualifier(SyntaxNodeOrToken syntax)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.EndQualifier();
        }

        protected void BeginIdentifier(SyntaxNodeOrToken syntax)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.RegisterIdentifier(syntax);
        }

        protected void EndIdentifier(SyntaxNodeOrToken syntax)
        {
        }

        protected void BeginValue(SyntaxNodeOrToken syntax, object value = null)
        {
        }

        protected void EndValue(SyntaxNodeOrToken syntax, object value = null)
        {
        }

        protected void BeginDocumentation(SyntaxNodeOrToken syntax)
        {
        }

        protected void EndDocumentation(SyntaxNodeOrToken syntax)
        {
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
                var rootDeclaration = new RootSingleDeclaration(declaration.SymbolType, declaration.ModelObjectType, declaration.Syntax.GetReference(), declaration.Members.ToImmutable(), declaration.ReferenceDirectives.ToImmutable(), diagnostics);
                return rootDeclaration;
            }
            var parentProp = Language.SymbolFacts.GetProperty(parent.ModelObjectType, declaration.ParentProperty);
            if (parent.ModelObjectType == null && declaration.ParentProperty == null || parentProp != null)
            {
                var isContainment = parentProp == null || Language.SymbolFacts.IsContainmentProperty(parentProp);
                if (declaration.Names.Count == 0)
                {
                    SingleDeclaration anonymousDeclaration = new SingleDeclaration(null, kind, declaration.SymbolType, declaration.ModelObjectType, declaration.Syntax.GetReference(), new SourceLocation(declaration.Syntax), false, declaration.HasImports, false, declaration.ParentProperty, declaration.Members.ToImmutable(), declaration.Properties.ToImmutable(), diagnostics);
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
                        var decl = new SingleDeclaration(identifier.Text, kind, declaration.SymbolType, declaration.ModelObjectType, declaration.Syntax.GetReference(), new SourceLocation(identifier.Syntax), isContainment && declaration.Merge, declaration.HasImports, false, parentProperty, declaration.Members.ToImmutable(), declaration.Properties.ToImmutable(), diagnostics);
                        var deepestDecl = decl;
                        for (int i = count - 2; i >= 0; i--)
                        {
                            parentProperty = i == 0 ? declaration.ParentProperty : declaration.NestingProperty;
                            identifier = qualifier[i];
                            decl = new SingleDeclaration(identifier.Text, kind, declaration.SymbolType, declaration.ModelObjectType, declaration.Syntax.GetReference(), new SourceLocation(identifier.Syntax), isContainment && declaration.Merge, false, true, parentProperty, ImmutableArray.Create(decl), ImmutableArray<DeclarationTreeInfo.Property>.Empty, ImmutableArray<Diagnostic>.Empty);
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
