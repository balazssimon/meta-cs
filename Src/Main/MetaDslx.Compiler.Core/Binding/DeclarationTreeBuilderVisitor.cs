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
using System.Diagnostics;
using MetaDslx.Compiler.Declarations;

namespace MetaDslx.Compiler.Binding
{
    public class DeclarationTreeBuilderVisitor : DetailedSyntaxVisitor
    {
        private readonly SyntaxTree _syntaxTree;
        private readonly string _scriptClassName;
        private readonly bool _isSubmission;
        private DeclarationTreeInfo _rootDeclarationInfo;
        private DeclarationTreeInfo _currentDeclarationInfo;

        protected DeclarationTreeBuilderVisitor(SyntaxTree syntaxTree, string scriptClassName, bool isSubmission, bool visitIntoStructuredToken = false, bool visitIntoStructuredTrivia = false)
            : base(visitIntoStructuredToken, visitIntoStructuredTrivia)
        {
            _syntaxTree = syntaxTree;
            _scriptClassName = scriptClassName;
            _isSubmission = isSubmission;
        }

        protected DeclarationTreeInfo RootDeclarationInfo
        {
            get { return _rootDeclarationInfo; }
        }

        protected DeclarationTreeInfo CurrentDeclarationInfo
        {
            get { return _currentDeclarationInfo; }
        }

        private RootSingleDeclaration CreateRoot(SyntaxNode node, ModelSymbolInfo kind)
        {
            return this.CreateRoot(node, kind.ImmutableType);
        }

        protected RootSingleDeclaration CreateRoot(SyntaxNode node, Type type)
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

        protected RootSingleDeclaration CreateRootDeclaration(SyntaxNode node, Type type)
        {
            RootSingleDeclaration result = null;
            _rootDeclarationInfo = this.BeginDeclaration(type, node);
            try
            {
                this.Visit(node);
            }
            finally
            {
                result = (RootSingleDeclaration)this.EndDeclaration();
            }
            return result;
        }

        protected virtual RootSingleDeclaration CreateRegularRootDeclaration(SyntaxNode node, Type type)
        {
            return this.CreateRootDeclaration(node, type);
        }

        protected virtual RootSingleDeclaration CreateScriptRootDeclaration(SyntaxNode node, Type type)
        {
            return this.CreateRootDeclaration(node, type);
        }

        protected virtual DeclarationTreeInfo CreateDeclarationInfo(DeclarationTreeInfo parent, Type type, SyntaxNode node)
        {
            return new DeclarationTreeInfo(parent, type, node);
        }

        protected DeclarationTreeInfo BeginDeclaration(Type type, SyntaxNode node)
        {
            _currentDeclarationInfo = this.CreateDeclarationInfo(_currentDeclarationInfo, type, node);
            return _currentDeclarationInfo;
        }

        protected SingleDeclaration EndDeclaration()
        {
            if (_currentDeclarationInfo == null) throw new InvalidOperationException("No declaration is open.");
            SingleDeclaration result = this.CreateDeclaration(_currentDeclarationInfo);
            _currentDeclarationInfo = _currentDeclarationInfo.Parent;
            return result;
        }

        protected void BeginName()
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.BeginName();
        }

        protected void EndName()
        {
            if (_currentDeclarationInfo == null) return;
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

        protected void RegisterIdentifier(RedNode node)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.RegisterIdentifier(node);
        }

        protected void RegisterDeclarationType(Type type)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.RegisterDeclarationType(type);
        }

        protected void RegisterNestingProperty(string name)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.RegisterNestingProperty(name);
        }

        protected void RegisterCanMerge(bool canMerge)
        {
            if (_currentDeclarationInfo == null) return;
            _currentDeclarationInfo.RegisterCanMerge(canMerge);
        }

        protected virtual string GetNameFromNode(RedNode node)
        {
            return node.ToString();
        }

        protected virtual SingleDeclaration CreateDeclaration(DeclarationTreeInfo declaration)
        {
            DeclarationTreeInfo parent = declaration.Parent;
            if (parent == null)
            {
                return new RootSingleDeclaration(declaration.Kind, _syntaxTree.GetReference(declaration.Node), declaration.Members.ToImmutable(), declaration.ReferenceDirectives.ToImmutable());
            }
            if (declaration.Names.Count == 0)
            {
                SingleDeclaration anonymousDeclaration = new SingleDeclaration(null, declaration.Kind, _syntaxTree.GetReference(declaration.Node), null, declaration.CanMerge, declaration.ParentPropertyToAddTo, declaration.Members.ToImmutable());
                parent.Members.Add(anonymousDeclaration);
                return anonymousDeclaration;
            }
            foreach (var name in declaration.Names)
            {
                int count = name.Count;
                if (count > 0)
                {
                    var nameTexts = name.Select(n => this.GetNameFromNode(n)).ToArray();
                    var decl = new SingleDeclaration(nameTexts[count - 1], declaration.Kind, _syntaxTree.GetReference(declaration.Node), new SourceLocation(name[count - 1]), declaration.CanMerge, declaration.ParentPropertyToAddTo, declaration.Members.ToImmutable());
                    for (int i = count - 2; i >= 0; i--)
                    {
                        decl = new SingleDeclaration(nameTexts[i], declaration.Kind, _syntaxTree.GetReference(declaration.Node), new SourceLocation(name[i]), declaration.CanMerge, declaration.ParentPropertyToAddTo, ImmutableArray.Create(decl));
                    }
                    parent.Members.Add(decl);
                }
            }
            return null;
        }
        
    }
}
