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

        private RootSingleDeclaration CreateRoot(LanguageSyntaxNode node, ModelSymbolInfo kind)
        {
            return this.CreateRoot(node, kind.ImmutableType);
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

        protected virtual DeclarationTreeInfo CreateDeclarationInfo(DeclarationTreeInfo scope, DeclarationTreeInfo parent, Type type, LanguageSyntaxNode node)
        {
            return new DeclarationTreeInfo(scope, parent, type, node);
        }

        //***
        protected DeclarationTreeInfo BeginSymbolDef(LanguageSyntaxNode node, Type symbolType, string nestingProperty = null, bool merge = false)
        {
            var result = this.BeginDeclaration(symbolType, node);
            if (nestingProperty != null) result.RegisterNestingProperty(nestingProperty);
            if (merge) result.RegisterMerge(merge);
            return result;
        }

        protected SingleDeclaration EndSymbolDef()
        {
            return this.EndDeclaration();
        }

        protected void BeginProperty(LanguageSyntaxNode node, string name, SymbolPropertyOwner owner = SymbolPropertyOwner.Current, Type ownerSymbolType = null)
        {
            if (_currentDeclarationInfo == null) return;
            switch (owner)
            {
                case SymbolPropertyOwner.Current:
                    _currentDeclarationInfo.BeginProperty(name);
                    break;
                case SymbolPropertyOwner.ParentSymbolDef:
                    break;
                case SymbolPropertyOwner.ParentScope:
                    _currentScopeDeclarationInfo.BeginProperty(name);
                    break;
                case SymbolPropertyOwner.AncestorSymbolDef:
                    break;
                case SymbolPropertyOwner.AncestorScope:
                    break;
                default:
                    break;
            }
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
            _currentScopeDeclarationInfo = _currentScopeDeclarationInfo.Scope;
        }

        protected void BeginQualifier(LanguageSyntaxNode node)
        {
            this.BeginQualifier();
        }

        protected void BeginSymbolUse(LanguageSyntaxNode node, ImmutableArray<Type> symbolTypes)
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
            _currentDeclarationInfo = this.CreateDeclarationInfo(_currentScopeDeclarationInfo, _currentDeclarationInfo, type, node);
            return _currentDeclarationInfo;
        }

        protected SingleDeclaration EndDeclaration()
        {
            if (_currentDeclarationInfo == null) throw new InvalidOperationException("No declaration is open.");
            SingleDeclaration result = this.CreateDeclaration(_currentDeclarationInfo);
            _currentDeclarationInfo = _currentDeclarationInfo.Parent;
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

        protected void BeginProperty(string name)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.BeginProperty(name);
        }

        protected void EndProperty()
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.EndProperty();
        }

        protected void RegisterIdentifier(LanguageSyntaxNode node)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.RegisterIdentifier(node);
        }

        protected void RegisterIdentifier(SyntaxToken token)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.RegisterIdentifier(token);
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
            DeclarationTreeInfo scope = declaration.Scope;
            if (scope == null)
            {
                return new RootSingleDeclaration(declaration.Kind, _syntaxTree.GetReference(declaration.Node), declaration.Members.ToImmutable(), declaration.ReferenceDirectives.ToImmutable());
            }
            if (declaration.Names.Count == 0)
            {
                //var diagnostics = ImmutableArray.Create<Diagnostic>(new LanguageDiagnostic(new LanguageDiagnosticInfo(ModelErrorCode.ERR_DeclarationHasNoName), declaration.Node.Location));
                SingleDeclaration anonymousDeclaration = new SingleDeclaration(null, declaration.Kind, _syntaxTree.GetReference(declaration.Node), new SourceLocation(declaration.Node), false, declaration.ParentPropertyToAddTo, declaration.Members.ToImmutable(), ImmutableArray<Diagnostic>.Empty);
                scope.Members.Add(anonymousDeclaration);
                return anonymousDeclaration;
            }
            foreach (var qualifier in declaration.Names)
            {
                int count = qualifier.Count;
                if (count > 0)
                {
                    var parentProperty = count == 1 ? declaration.ParentPropertyToAddTo : declaration.NestingProperty;
                    var identifier = qualifier[count - 1];
                    var decl = new SingleDeclaration(identifier.Text, declaration.Kind, _syntaxTree.GetReference(declaration.Node), new SourceLocation(identifier.Syntax), declaration.Merge, parentProperty, declaration.Members.ToImmutable(), ImmutableArray<Diagnostic>.Empty);
                    var deepestDecl = decl;
                    for (int i = count - 2; i >= 0; i--)
                    {
                        parentProperty = i == 0 ? declaration.ParentPropertyToAddTo : declaration.NestingProperty;
                        identifier = qualifier[i];
                        decl = new SingleDeclaration(identifier.Text, declaration.Kind, _syntaxTree.GetReference(declaration.Node), new SourceLocation(identifier.Syntax), declaration.Merge, parentProperty, ImmutableArray.Create(decl), ImmutableArray<Diagnostic>.Empty);
                    }
                    scope.Members.Add(decl);
                    return deepestDecl;
                }
            }
            return null;
        }
        
    }
}
