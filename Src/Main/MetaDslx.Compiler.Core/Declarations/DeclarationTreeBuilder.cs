using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.References;

namespace MetaDslx.Compiler.Declarations
{
    public class DeclarationTreeBuilder : DetailedSyntaxVisitor
    {
        private readonly SyntaxTree _syntaxTree;
        private readonly string _scriptClassName;
        private readonly bool _isSubmission;
        private List<DeclarationInfo> _declarationInfoStack;
        private DeclarationInfo _currentDeclarationInfo;
        private ArrayBuilder<SingleDeclaration> _currentChildren;
        private ArrayBuilder<ImmutableArray<RedNode>> _currentNames;
        private ArrayBuilder<RedNode> _currentName;
        private List<string> _rootPropertyStack;
        private List<string> _currentPropertyStack;
        private string _currentProperty;

        protected DeclarationTreeBuilder(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission, bool visitIntoStructuredToken = false, bool visitIntoStructuredTrivia = false)
            : base(visitIntoStructuredToken, visitIntoStructuredTrivia)
        {
            _syntaxTree = syntaxTree;
            _scriptClassName = scriptClassName;
            _isSubmission = isSubmission;
        }

        protected RootSingleDeclaration CreateRoot(SyntaxNode node, Type type)
        {
            var kind = ModelSymbolInfo.GetSymbolInfo(type);
            return this.CreateRoot(node, kind);
        }

        private RootSingleDeclaration CreateRoot(SyntaxNode node, ModelSymbolInfo kind)
        {
            try
            {
                _declarationInfoStack = new List<DeclarationInfo>();
                _rootPropertyStack = new List<string>();
                if (_syntaxTree.Options.Kind != SourceCodeKind.Regular)
                {
                    return this.CreateScriptRootDeclaration(node, kind);
                }
                else
                {
                    return this.CreateRootDeclaration(node, kind);
                }
            }
            finally
            {
                _declarationInfoStack = null;
                _rootPropertyStack = null;
                _currentChildren = null;
                _currentNames = null;
                _currentName = null;
                _currentPropertyStack = null;
                _currentProperty = null;
            }
        }

        protected virtual RootSingleDeclaration CreateRootDeclaration(SyntaxNode node, ModelSymbolInfo kind)
        {
            DeclarationInfo decl = null;
            this.BeginDeclaration(kind?.ImmutableType);
            try
            {
                this.Visit(node);
            }
            finally
            {
                decl = this.EndDeclaration();
            }
            return new RootSingleDeclaration(kind, _syntaxTree.GetReference(node), decl.Children, GetReferenceDirectives(node));
        }

        protected virtual ImmutableArray<ReferenceDirective> GetReferenceDirectives(SyntaxNode node)
        {
            return ImmutableArray<ReferenceDirective>.Empty;
        }

        protected virtual RootSingleDeclaration CreateScriptRootDeclaration(SyntaxNode node, ModelSymbolInfo kind)
        {
            return this.CreateRootDeclaration(node, kind);
        }


        protected class DeclarationInfo
        {
            public Type Type { get; set; }
            public ModelSymbolInfo Kind { get; set; }
            public string NestingProperty { get; set; }
            public string ParentPropertyToAddTo { get; set; }
            public ArrayBuilder<ImmutableArray<RedNode>> NamesBuilder { get; set; }
            public ImmutableArray<ImmutableArray<RedNode>> Names { get; set; }
            public List<string> PropertyStack { get; set; }
            public ArrayBuilder<SingleDeclaration> ChildrenBuilder { get; set; }
            public ImmutableArray<SingleDeclaration> Children { get; set; }
        }

        protected void BeginDeclaration(Type type)
        {
            _currentDeclarationInfo = new DeclarationInfo();
            _currentDeclarationInfo.Type = type;
            _declarationInfoStack.Add(_currentDeclarationInfo);
            _currentChildren = ArrayBuilder<SingleDeclaration>.GetInstance();
            _currentDeclarationInfo.ChildrenBuilder = _currentChildren;
            _currentNames = null;
            _currentName = null;
            _currentPropertyStack = null;
            _currentProperty = null;
        }

        protected DeclarationInfo EndDeclaration()
        {
            if (_currentDeclarationInfo == null) throw new InvalidOperationException("No declaration is open.");
            var result = _currentDeclarationInfo;
            if (result.ChildrenBuilder != null)
            {
                result.Children = result.ChildrenBuilder.ToImmutableAndFree();
                result.ChildrenBuilder = null;
            }
            else
            {
                result.Children = ImmutableArray<SingleDeclaration>.Empty;
            }
            if (result.NamesBuilder != null)
            {
                result.Names = result.NamesBuilder.ToImmutableAndFree();
                result.NamesBuilder = null;
            }
            else
            {
                result.Names = ImmutableArray<ImmutableArray<RedNode>>.Empty;
            }
            result.Kind = ModelSymbolInfo.GetSymbolInfo(result.Type);
            if (_declarationInfoStack.Count > 0) _declarationInfoStack.RemoveAt(_declarationInfoStack.Count - 1);
            if (_declarationInfoStack.Count > 0) _currentDeclarationInfo = _declarationInfoStack[_declarationInfoStack.Count - 1];
            else _currentDeclarationInfo = null;
            this.RestoreParentSymbol();
            result.ParentPropertyToAddTo = _currentProperty;
            return result;
        }

        private void RestoreParentSymbol()
        {
            if (_currentDeclarationInfo != null)
            {
                _currentChildren = _currentDeclarationInfo.ChildrenBuilder;
                _currentNames = null;
            }
            this.RestorePropertyStack();
        }

        private void RestorePropertyStack()
        {
            if (_currentDeclarationInfo != null)
            {
                _currentPropertyStack = _currentDeclarationInfo.PropertyStack;
            }
            else if (_declarationInfoStack.Count == 0)
            {
                _currentPropertyStack = _rootPropertyStack;
            }
            else
            {
                _currentPropertyStack = null;
            }
            if (_currentPropertyStack != null && _currentPropertyStack.Count > 0) _currentProperty = _currentPropertyStack[_currentPropertyStack.Count - 1];
            else _currentProperty = null;
        }

        protected void BeginSymbol()
        {
            _currentDeclarationInfo = null;
            _declarationInfoStack.Add(_currentDeclarationInfo);
            _currentChildren = null;
            _currentNames = null;
            _currentPropertyStack = null;
            _currentProperty = null;
        }

        protected void EndSymbol()
        {
            if (_declarationInfoStack.Count > 0) _declarationInfoStack.RemoveAt(_declarationInfoStack.Count - 1);
            if (_declarationInfoStack.Count > 0) _currentDeclarationInfo = _declarationInfoStack[_declarationInfoStack.Count - 1];
            else _currentDeclarationInfo = null;
            this.RestoreParentSymbol();
        }

        protected void BeginName()
        {
            if (_currentDeclarationInfo == null) return;
            _currentNames = _currentDeclarationInfo.NamesBuilder;
            if (_currentNames == null)
            {
                _currentNames = ArrayBuilder<ImmutableArray<RedNode>>.GetInstance();
                _currentDeclarationInfo.NamesBuilder = _currentNames;
                _currentPropertyStack = null;
                _currentProperty = null;
            }
        }

        protected void EndName()
        {
            _currentNames = null;
            this.RestorePropertyStack();
        }

        protected void BeginQualifiedName()
        {
            if (_currentNames == null) return;
            if (_currentName != null) throw new InvalidOperationException("Qualified names cannot be nested.");
            _currentName = ArrayBuilder<RedNode>.GetInstance();
            _currentPropertyStack = null;
            _currentProperty = null;
        }

        protected void EndQualifiedName()
        {
            if (_currentNames == null) return;
            _currentNames.Add(_currentName.ToImmutableAndFree());
            _currentName = null;
            this.RestorePropertyStack();
        }

        protected void BeginProperty(string name)
        {
            if (_currentDeclarationInfo == null) return;
            if (_currentPropertyStack == null)
            {
                _currentPropertyStack = new List<string>();
                _currentDeclarationInfo.PropertyStack = _currentPropertyStack;
            }
            _currentProperty = name;
            _currentPropertyStack.Add(_currentProperty);
        }

        protected void EndProperty()
        {
            _currentName = null;
            _currentProperty = null;
            this.RestorePropertyStack();
        }

        protected void RegisterIdentifier(RedNode node)
        {
            if (_currentNames == null) return;
            if (_currentName != null)
            {
                _currentName.Add(node);
            }
            else
            {
                ImmutableArray<RedNode> singleName = ImmutableArray.Create(node);
                _currentNames.Add(singleName);
            }
        }

        protected void RegisterDeclarationType(Type type)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.Type = type;
        }

        protected void RegisterNestingProperty(string name)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.NestingProperty = name;
        }

        protected void CreateDeclaration(SyntaxNode node, ModelSymbolInfo kind, ImmutableArray<ImmutableArray<RedNode>> names, string parentPropertyToAddTo, ImmutableArray<SingleDeclaration> children)
        {
            if (_currentChildren == null) return;
            if (names == null || names.Length == 0)
            {
                _currentChildren.Add(new SingleDeclaration(null, kind, _syntaxTree.GetReference(node), null, parentPropertyToAddTo, ImmutableArray<SingleDeclaration>.Empty));
                return;
            }
            foreach (var name in names)
            {
                int count = name.Length;
                if (count > 0)
                {
                    var nameTexts = name.Select(n => n.ToString()).ToArray();
                    var decl = new SingleDeclaration(nameTexts[count - 1], kind, _syntaxTree.GetReference(node), new SourceLocation(name[count - 1]), parentPropertyToAddTo, children);
                    for (int i = count - 2; i >= 0; i--)
                    {
                        decl = new SingleDeclaration(nameTexts[i], kind, _syntaxTree.GetReference(node), new SourceLocation(name[i]), parentPropertyToAddTo, ImmutableArray.Create(decl));
                    }
                    _currentChildren.Add(decl);
                }
            }
        }


    }
}
