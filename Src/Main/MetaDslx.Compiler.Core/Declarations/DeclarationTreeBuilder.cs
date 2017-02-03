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
        private List<List<RedNode>> _currentNames;
        private List<RedNode> _currentName;

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

        protected RootSingleDeclaration CreateRoot(SyntaxNode node, ModelSymbolInfo kind)
        {
            try
            {
                _declarationInfoStack = new List<DeclarationInfo>();
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
                _currentChildren = null;
                _currentNames = null;
                _currentName = null;
            }
        }

        protected virtual RootSingleDeclaration CreateRootDeclaration(SyntaxNode node, ModelSymbolInfo kind)
        {
            DeclarationInfo decl = null;
            this.BeginDeclaration(kind.ImmutableType);
            try
            {
                this.Visit(node);
            }
            finally
            {
                decl = this.EndDeclaration();
            }
            return new RootSingleDeclaration(kind, _syntaxTree.GetReference(node), decl.Children);
        }

        protected virtual RootSingleDeclaration CreateScriptRootDeclaration(SyntaxNode node, ModelSymbolInfo kind)
        {
            return this.CreateRootDeclaration(node, kind);
        }


        protected class DeclarationInfo
        {
            public Type Type { get; set; }
            public ModelSymbolInfo Kind { get; set; }
            public List<List<RedNode>> Names { get; set; }
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
        }

        protected DeclarationInfo EndDeclaration()
        {
            if (_currentDeclarationInfo == null) throw new InvalidOperationException("No declaration is open.");
            var result = _currentDeclarationInfo;
            result.Children = result.ChildrenBuilder.ToImmutableAndFree();
            result.ChildrenBuilder = null;
            result.Kind = ModelSymbolInfo.GetSymbolInfo(result.Type);
            if (_declarationInfoStack.Count > 0) _declarationInfoStack.RemoveAt(_declarationInfoStack.Count - 1);
            if (_declarationInfoStack.Count > 0) _currentDeclarationInfo = _declarationInfoStack[_declarationInfoStack.Count - 1];
            else _currentDeclarationInfo = null;
            if (_currentDeclarationInfo != null)
            {
                _currentChildren = _currentDeclarationInfo.ChildrenBuilder;
            }
            return result;
        }

        protected void BeginSymbol()
        {
            _currentDeclarationInfo = null;
            _declarationInfoStack.Add(_currentDeclarationInfo);
            _currentChildren = null;
            _currentNames = null;
        }

        protected void EndSymbol()
        {

        }

        protected void BeginName()
        {
            if (_currentDeclarationInfo == null) return;
            _currentNames = _currentDeclarationInfo.Names;
            if (_currentNames == null)
            {
                _currentNames = new List<List<RedNode>>();
                _currentDeclarationInfo.Names = _currentNames;
            }
        }

        protected void EndName()
        {
            _currentNames = null;
        }

        protected void BeginQualifiedName()
        {
            if (_currentNames == null) return;
            if (_currentName != null) throw new InvalidOperationException("Qualified names cannot be nested.");
            _currentName = new List<RedNode>();
            _currentNames.Add(_currentName);
        }

        protected void EndQualifiedName()
        {
            _currentName = null;
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
                List<RedNode> singleName = new List<RedNode>();
                singleName.Add(node);
                _currentNames.Add(singleName);
            }
        }

        protected void RegisterDeclarationType(Type type)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.Type = type;
        }

        protected void CreateDeclaration(SyntaxNode node, ModelSymbolInfo kind, List<List<RedNode>> names, ImmutableArray<SingleDeclaration> children)
        {
            foreach (var name in names)
            {
                int count = name.Count;
                if (count > 0)
                {
                    var nameTexts = name.Select(n => n.ToString()).ToArray();
                    var decl = new SingleDeclaration(nameTexts[count - 1], kind, _syntaxTree.GetReference(node), new SourceLocation(name[count - 1]), children);
                    for (int i = count - 2; i >= 0; i--)
                    {
                        decl = new SingleDeclaration(nameTexts[i], kind, _syntaxTree.GetReference(node), new SourceLocation(name[i]), ImmutableArray.Create(decl));
                    }
                    _currentChildren.Add(decl);
                }
            }
        }


    }
}
