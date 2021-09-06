// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
namespace MetaDslx.Languages.Meta.Syntax.InternalSyntax
{
    public class MetaSyntaxParser : Antlr4SyntaxParser
    {
        private readonly Antlr4ToRoslynVisitor _visitor;
        public MetaSyntaxParser(
            SourceText text,
            MetaParseOptions options,
            MetaSyntaxNode oldTree, 
			ParseData oldParseData,
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default)
            : base(MetaLanguage.Instance, text, options, oldTree, oldParseData, changes, cancellationToken)
        {
            _visitor = new Antlr4ToRoslynVisitor(this);
        }
        protected new MetaParser Antlr4Parser => (MetaParser)base.Antlr4Parser;
		public override LanguageSyntaxNode Parse()
		{
			BeginRoot();
            ParserState state = null;
			var green = this.ParseMain(ref state);
			EndRoot(ref green);
			var red = (MetaSyntaxNode)green.CreateRed();
			return red;
		}
		public GreenNode ParseMain(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
		        var context = this.IsIncremental ? this.Antlr4Parser.main() : _Antlr4ParseMain();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseMain(MainSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.MainContext _Antlr4ParseMain()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.MainContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseMain(CurrentNode as MainSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseMain();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.MainContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseName(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.name();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseName(NameSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.NameContext _Antlr4ParseName()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.NameContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseName(CurrentNode as NameSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseName();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.NameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseQualifiedName(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.qualifiedName();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQualifiedName(QualifiedNameSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.QualifiedNameContext _Antlr4ParseQualifiedName()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.QualifiedNameContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseQualifiedName(CurrentNode as QualifiedNameSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseQualifiedName();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.QualifiedNameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseQualifier(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.qualifier();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseQualifier(QualifierSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.QualifierContext _Antlr4ParseQualifier()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.QualifierContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseQualifier(CurrentNode as QualifierSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseQualifier();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.QualifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseAttribute(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.attribute();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseAttribute(AttributeSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.AttributeContext _Antlr4ParseAttribute()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.AttributeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseAttribute(CurrentNode as AttributeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseAttribute();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.AttributeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseUsingNamespaceOrMetamodel(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.usingNamespaceOrMetamodel();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseUsingNamespaceOrMetamodel(UsingNamespaceOrMetamodelSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.UsingNamespaceOrMetamodelContext _Antlr4ParseUsingNamespaceOrMetamodel()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.UsingNamespaceOrMetamodelContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseUsingNamespaceOrMetamodel(CurrentNode as UsingNamespaceOrMetamodelSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseUsingNamespaceOrMetamodel();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.UsingNamespaceOrMetamodelContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseUsingNamespace(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.usingNamespace();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseUsingNamespace(UsingNamespaceSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.UsingNamespaceContext _Antlr4ParseUsingNamespace()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.UsingNamespaceContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseUsingNamespace(CurrentNode as UsingNamespaceSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseUsingNamespace();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.UsingNamespaceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseUsingMetamodel(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.usingMetamodel();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseUsingMetamodel(UsingMetamodelSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.UsingMetamodelContext _Antlr4ParseUsingMetamodel()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.UsingMetamodelContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseUsingMetamodel(CurrentNode as UsingMetamodelSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseUsingMetamodel();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.UsingMetamodelContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseUsingMetamodelReference(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.usingMetamodelReference();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseUsingMetamodelReference(UsingMetamodelReferenceSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.UsingMetamodelReferenceContext _Antlr4ParseUsingMetamodelReference()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.UsingMetamodelReferenceContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseUsingMetamodelReference(CurrentNode as UsingMetamodelReferenceSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseUsingMetamodelReference();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.UsingMetamodelReferenceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseNamespaceDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.NamespaceDeclarationContext _Antlr4ParseNamespaceDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.NamespaceDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseNamespaceDeclaration(CurrentNode as NamespaceDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.NamespaceDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseNamespaceBody(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceBody();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceBody(NamespaceBodySyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.NamespaceBodyContext _Antlr4ParseNamespaceBody()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.NamespaceBodyContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseNamespaceBody(CurrentNode as NamespaceBodySyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceBody();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.NamespaceBodyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseMetamodelDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.metamodelDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseMetamodelDeclaration(MetamodelDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.MetamodelDeclarationContext _Antlr4ParseMetamodelDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.MetamodelDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseMetamodelDeclaration(CurrentNode as MetamodelDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseMetamodelDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.MetamodelDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseMetamodelPropertyList(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.metamodelPropertyList();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseMetamodelPropertyList(MetamodelPropertyListSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.MetamodelPropertyListContext _Antlr4ParseMetamodelPropertyList()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.MetamodelPropertyListContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseMetamodelPropertyList(CurrentNode as MetamodelPropertyListSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseMetamodelPropertyList();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.MetamodelPropertyListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseMetamodelProperty(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.metamodelProperty();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseMetamodelProperty(MetamodelPropertySyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.MetamodelPropertyContext _Antlr4ParseMetamodelProperty()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.MetamodelPropertyContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseMetamodelProperty(CurrentNode as MetamodelPropertySyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseMetamodelProperty();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.MetamodelPropertyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseMetamodelUriProperty(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.metamodelUriProperty();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseMetamodelUriProperty(MetamodelUriPropertySyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.MetamodelUriPropertyContext _Antlr4ParseMetamodelUriProperty()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.MetamodelUriPropertyContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseMetamodelUriProperty(CurrentNode as MetamodelUriPropertySyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseMetamodelUriProperty();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.MetamodelUriPropertyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseMetamodelPrefixProperty(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.metamodelPrefixProperty();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseMetamodelPrefixProperty(MetamodelPrefixPropertySyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.MetamodelPrefixPropertyContext _Antlr4ParseMetamodelPrefixProperty()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.MetamodelPrefixPropertyContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseMetamodelPrefixProperty(CurrentNode as MetamodelPrefixPropertySyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseMetamodelPrefixProperty();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.MetamodelPrefixPropertyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseMetamodelVersionProperty(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.metamodelVersionProperty();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseMetamodelVersionProperty(MetamodelVersionPropertySyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.MetamodelVersionPropertyContext _Antlr4ParseMetamodelVersionProperty()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.MetamodelVersionPropertyContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseMetamodelVersionProperty(CurrentNode as MetamodelVersionPropertySyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseMetamodelVersionProperty();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.MetamodelVersionPropertyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.declaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDeclaration(DeclarationSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.DeclarationContext _Antlr4ParseDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.DeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseDeclaration(CurrentNode as DeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.DeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseEnumDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.enumDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseEnumDeclaration(EnumDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.EnumDeclarationContext _Antlr4ParseEnumDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.EnumDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseEnumDeclaration(CurrentNode as EnumDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseEnumDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.EnumDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseEnumBody(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.enumBody();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseEnumBody(EnumBodySyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.EnumBodyContext _Antlr4ParseEnumBody()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.EnumBodyContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseEnumBody(CurrentNode as EnumBodySyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseEnumBody();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.EnumBodyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseEnumValues(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.enumValues();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseEnumValues(EnumValuesSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.EnumValuesContext _Antlr4ParseEnumValues()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.EnumValuesContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseEnumValues(CurrentNode as EnumValuesSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseEnumValues();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.EnumValuesContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseEnumValue(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.enumValue();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseEnumValue(EnumValueSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.EnumValueContext _Antlr4ParseEnumValue()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.EnumValueContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseEnumValue(CurrentNode as EnumValueSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseEnumValue();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.EnumValueContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseEnumMemberDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.enumMemberDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.EnumMemberDeclarationContext _Antlr4ParseEnumMemberDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.EnumMemberDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseEnumMemberDeclaration(CurrentNode as EnumMemberDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseEnumMemberDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.EnumMemberDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseClassDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.classDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseClassDeclaration(ClassDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.ClassDeclarationContext _Antlr4ParseClassDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.ClassDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseClassDeclaration(CurrentNode as ClassDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseClassDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.ClassDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseSymbolAttribute(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.symbolAttribute();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSymbolAttribute(SymbolAttributeSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.SymbolAttributeContext _Antlr4ParseSymbolAttribute()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.SymbolAttributeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseSymbolAttribute(CurrentNode as SymbolAttributeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseSymbolAttribute();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.SymbolAttributeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseSymbolSymbolAttribute(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.symbolSymbolAttribute();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSymbolSymbolAttribute(SymbolSymbolAttributeSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.SymbolSymbolAttributeContext _Antlr4ParseSymbolSymbolAttribute()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.SymbolSymbolAttributeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseSymbolSymbolAttribute(CurrentNode as SymbolSymbolAttributeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseSymbolSymbolAttribute();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.SymbolSymbolAttributeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseExpressionSymbolAttribute(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.expressionSymbolAttribute();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseExpressionSymbolAttribute(ExpressionSymbolAttributeSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.ExpressionSymbolAttributeContext _Antlr4ParseExpressionSymbolAttribute()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.ExpressionSymbolAttributeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseExpressionSymbolAttribute(CurrentNode as ExpressionSymbolAttributeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseExpressionSymbolAttribute();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.ExpressionSymbolAttributeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseStatementSymbolTypeAttribute(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.statementSymbolTypeAttribute();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseStatementSymbolTypeAttribute(StatementSymbolTypeAttributeSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.StatementSymbolTypeAttributeContext _Antlr4ParseStatementSymbolTypeAttribute()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.StatementSymbolTypeAttributeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseStatementSymbolTypeAttribute(CurrentNode as StatementSymbolTypeAttributeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseStatementSymbolTypeAttribute();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.StatementSymbolTypeAttributeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseTypeSymbolTypeAttribute(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.typeSymbolTypeAttribute();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTypeSymbolTypeAttribute(TypeSymbolTypeAttributeSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.TypeSymbolTypeAttributeContext _Antlr4ParseTypeSymbolTypeAttribute()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.TypeSymbolTypeAttributeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseTypeSymbolTypeAttribute(CurrentNode as TypeSymbolTypeAttributeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseTypeSymbolTypeAttribute();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.TypeSymbolTypeAttributeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseClassBody(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.classBody();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseClassBody(ClassBodySyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.ClassBodyContext _Antlr4ParseClassBody()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.ClassBodyContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseClassBody(CurrentNode as ClassBodySyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseClassBody();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.ClassBodyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseClassAncestors(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.classAncestors();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseClassAncestors(ClassAncestorsSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.ClassAncestorsContext _Antlr4ParseClassAncestors()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.ClassAncestorsContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseClassAncestors(CurrentNode as ClassAncestorsSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseClassAncestors();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.ClassAncestorsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseClassAncestor(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.classAncestor();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseClassAncestor(ClassAncestorSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.ClassAncestorContext _Antlr4ParseClassAncestor()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.ClassAncestorContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseClassAncestor(CurrentNode as ClassAncestorSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseClassAncestor();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.ClassAncestorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseClassMemberDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.classMemberDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.ClassMemberDeclarationContext _Antlr4ParseClassMemberDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.ClassMemberDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseClassMemberDeclaration(CurrentNode as ClassMemberDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseClassMemberDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.ClassMemberDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseFieldDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.fieldDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseFieldDeclaration(FieldDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.FieldDeclarationContext _Antlr4ParseFieldDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.FieldDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseFieldDeclaration(CurrentNode as FieldDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseFieldDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.FieldDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseFieldSymbolPropertyAttribute(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.fieldSymbolPropertyAttribute();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseFieldSymbolPropertyAttribute(FieldSymbolPropertyAttributeSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.FieldSymbolPropertyAttributeContext _Antlr4ParseFieldSymbolPropertyAttribute()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.FieldSymbolPropertyAttributeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseFieldSymbolPropertyAttribute(CurrentNode as FieldSymbolPropertyAttributeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseFieldSymbolPropertyAttribute();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.FieldSymbolPropertyAttributeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseFieldContainment(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.fieldContainment();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseFieldContainment(FieldContainmentSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.FieldContainmentContext _Antlr4ParseFieldContainment()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.FieldContainmentContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseFieldContainment(CurrentNode as FieldContainmentSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseFieldContainment();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.FieldContainmentContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseFieldModifier(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.fieldModifier();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseFieldModifier(FieldModifierSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.FieldModifierContext _Antlr4ParseFieldModifier()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.FieldModifierContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseFieldModifier(CurrentNode as FieldModifierSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseFieldModifier();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.FieldModifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseDefaultValue(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.defaultValue();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDefaultValue(DefaultValueSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.DefaultValueContext _Antlr4ParseDefaultValue()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.DefaultValueContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseDefaultValue(CurrentNode as DefaultValueSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseDefaultValue();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.DefaultValueContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseRedefinitionsOrSubsettings(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.redefinitionsOrSubsettings();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseRedefinitionsOrSubsettings(RedefinitionsOrSubsettingsSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.RedefinitionsOrSubsettingsContext _Antlr4ParseRedefinitionsOrSubsettings()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.RedefinitionsOrSubsettingsContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseRedefinitionsOrSubsettings(CurrentNode as RedefinitionsOrSubsettingsSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseRedefinitionsOrSubsettings();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.RedefinitionsOrSubsettingsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseRedefinitions(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.redefinitions();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseRedefinitions(RedefinitionsSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.RedefinitionsContext _Antlr4ParseRedefinitions()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.RedefinitionsContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseRedefinitions(CurrentNode as RedefinitionsSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseRedefinitions();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.RedefinitionsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseSubsettings(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.subsettings();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSubsettings(SubsettingsSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.SubsettingsContext _Antlr4ParseSubsettings()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.SubsettingsContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseSubsettings(CurrentNode as SubsettingsSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseSubsettings();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.SubsettingsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseNameUseList(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.nameUseList();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNameUseList(NameUseListSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.NameUseListContext _Antlr4ParseNameUseList()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.NameUseListContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseNameUseList(CurrentNode as NameUseListSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseNameUseList();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.NameUseListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseConstDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.constDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseConstDeclaration(ConstDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.ConstDeclarationContext _Antlr4ParseConstDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.ConstDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseConstDeclaration(CurrentNode as ConstDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseConstDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.ConstDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseConstValue(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.constValue();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseConstValue(ConstValueSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.ConstValueContext _Antlr4ParseConstValue()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.ConstValueContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseConstValue(CurrentNode as ConstValueSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseConstValue();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.ConstValueContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseReturnType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.returnType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseReturnType(ReturnTypeSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.ReturnTypeContext _Antlr4ParseReturnType()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.ReturnTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseReturnType(CurrentNode as ReturnTypeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseReturnType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.ReturnTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseTypeOfReference(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.typeOfReference();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTypeOfReference(TypeOfReferenceSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.TypeOfReferenceContext _Antlr4ParseTypeOfReference()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.TypeOfReferenceContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseTypeOfReference(CurrentNode as TypeOfReferenceSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseTypeOfReference();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.TypeOfReferenceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseTypeReference(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.typeReference();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTypeReference(TypeReferenceSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.TypeReferenceContext _Antlr4ParseTypeReference()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.TypeReferenceContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseTypeReference(CurrentNode as TypeReferenceSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseTypeReference();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.TypeReferenceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseSimpleType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.simpleType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSimpleType(SimpleTypeSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.SimpleTypeContext _Antlr4ParseSimpleType()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.SimpleTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseSimpleType(CurrentNode as SimpleTypeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseSimpleType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.SimpleTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseClassType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.classType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseClassType(ClassTypeSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.ClassTypeContext _Antlr4ParseClassType()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.ClassTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseClassType(CurrentNode as ClassTypeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseClassType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.ClassTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseObjectType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.objectType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseObjectType(ObjectTypeSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.ObjectTypeContext _Antlr4ParseObjectType()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.ObjectTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseObjectType(CurrentNode as ObjectTypeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseObjectType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.ObjectTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParsePrimitiveType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.primitiveType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReusePrimitiveType(PrimitiveTypeSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.PrimitiveTypeContext _Antlr4ParsePrimitiveType()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.PrimitiveTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReusePrimitiveType(CurrentNode as PrimitiveTypeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParsePrimitiveType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.PrimitiveTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseVoidType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.voidType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVoidType(VoidTypeSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.VoidTypeContext _Antlr4ParseVoidType()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.VoidTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseVoidType(CurrentNode as VoidTypeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseVoidType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.VoidTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseNullableType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.nullableType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNullableType(NullableTypeSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.NullableTypeContext _Antlr4ParseNullableType()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.NullableTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseNullableType(CurrentNode as NullableTypeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseNullableType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.NullableTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseCollectionType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.collectionType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseCollectionType(CollectionTypeSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.CollectionTypeContext _Antlr4ParseCollectionType()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.CollectionTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseCollectionType(CurrentNode as CollectionTypeSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseCollectionType();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.CollectionTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseCollectionKind(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.collectionKind();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseCollectionKind(CollectionKindSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.CollectionKindContext _Antlr4ParseCollectionKind()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.CollectionKindContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseCollectionKind(CurrentNode as CollectionKindSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseCollectionKind();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.CollectionKindContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseOperationDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.operationDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseOperationDeclaration(OperationDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.OperationDeclarationContext _Antlr4ParseOperationDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.OperationDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseOperationDeclaration(CurrentNode as OperationDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseOperationDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.OperationDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseOperationModifier(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.operationModifier();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseOperationModifier(OperationModifierSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.OperationModifierContext _Antlr4ParseOperationModifier()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.OperationModifierContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseOperationModifier(CurrentNode as OperationModifierSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseOperationModifier();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.OperationModifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseOperationModifierBuilder(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.operationModifierBuilder();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseOperationModifierBuilder(OperationModifierBuilderSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.OperationModifierBuilderContext _Antlr4ParseOperationModifierBuilder()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.OperationModifierBuilderContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseOperationModifierBuilder(CurrentNode as OperationModifierBuilderSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseOperationModifierBuilder();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.OperationModifierBuilderContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseOperationModifierReadonly(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.operationModifierReadonly();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseOperationModifierReadonly(OperationModifierReadonlySyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.OperationModifierReadonlyContext _Antlr4ParseOperationModifierReadonly()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.OperationModifierReadonlyContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseOperationModifierReadonly(CurrentNode as OperationModifierReadonlySyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseOperationModifierReadonly();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.OperationModifierReadonlyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseParameterList(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parameterList();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParameterList(ParameterListSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.ParameterListContext _Antlr4ParseParameterList()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.ParameterListContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParameterList(CurrentNode as ParameterListSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParameterList();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.ParameterListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseParameter(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.parameter();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseParameter(ParameterSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.ParameterContext _Antlr4ParseParameter()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.ParameterContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseParameter(CurrentNode as ParameterSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseParameter();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.ParameterContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseAssociationDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.associationDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseAssociationDeclaration(AssociationDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.AssociationDeclarationContext _Antlr4ParseAssociationDeclaration()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.AssociationDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseAssociationDeclaration(CurrentNode as AssociationDeclarationSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseAssociationDeclaration();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.AssociationDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseIdentifier(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.identifier();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseIdentifier(IdentifierSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.IdentifierContext _Antlr4ParseIdentifier()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.IdentifierContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseIdentifier(CurrentNode as IdentifierSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseIdentifier();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.IdentifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.literal();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseLiteral(LiteralSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.LiteralContext _Antlr4ParseLiteral()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.LiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseLiteral(CurrentNode as LiteralSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.LiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseNullLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.nullLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNullLiteral(NullLiteralSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.NullLiteralContext _Antlr4ParseNullLiteral()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.NullLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseNullLiteral(CurrentNode as NullLiteralSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseNullLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.NullLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseBooleanLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.booleanLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseBooleanLiteral(BooleanLiteralSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.BooleanLiteralContext _Antlr4ParseBooleanLiteral()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.BooleanLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseBooleanLiteral(CurrentNode as BooleanLiteralSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseBooleanLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.BooleanLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseIntegerLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.integerLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseIntegerLiteral(IntegerLiteralSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.IntegerLiteralContext _Antlr4ParseIntegerLiteral()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.IntegerLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseIntegerLiteral(CurrentNode as IntegerLiteralSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseIntegerLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.IntegerLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseDecimalLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.decimalLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDecimalLiteral(DecimalLiteralSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.DecimalLiteralContext _Antlr4ParseDecimalLiteral()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.DecimalLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseDecimalLiteral(CurrentNode as DecimalLiteralSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseDecimalLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.DecimalLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseScientificLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.scientificLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseScientificLiteral(ScientificLiteralSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.ScientificLiteralContext _Antlr4ParseScientificLiteral()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.ScientificLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseScientificLiteral(CurrentNode as ScientificLiteralSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseScientificLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.ScientificLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		public GreenNode ParseStringLiteral(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.stringLiteral();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseStringLiteral(StringLiteralSyntax node)
		{
			return node != null;
		}
		
		internal MetaParser.StringLiteralContext _Antlr4ParseStringLiteral()
		{
			BeginNode();
		    bool cached = false;
		    MetaParser.StringLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
		        cached = IsIncremental && CanReuseStringLiteral(CurrentNode as StringLiteralSyntax);
				if (cached)
				{
					green = EatNode();
				}
				else
				{
					context = this.Antlr4Parser._DoParseStringLiteral();
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
		        if (cached)
		        {
					context = new MetaParser.StringLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
		        }
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
        private class Antlr4ToRoslynVisitor : MetaParserBaseVisitor<GreenNode>
        {
			// list pools - allocators for lists that are used to build sequences of nodes. The lists
			// can be reused (hence pooled) since the syntax factory methods don't keep references to
			// them
			private readonly SyntaxListPool _pool = new SyntaxListPool(); // Don't need to reset this.
			private readonly MetaInternalSyntaxFactory _factory;
            private readonly MetaSyntaxParser _syntaxParser;
            public Antlr4ToRoslynVisitor(MetaSyntaxParser syntaxParser)
            {
				_factory = (MetaInternalSyntaxFactory)syntaxParser.Language.InternalSyntaxFactory;
                _syntaxParser = syntaxParser;
            }
            private GreenNode VisitTerminal(IToken token, MetaSyntaxKind kind)
            {
				if (kind == SyntaxKind.Eof)
				{
					return _syntaxParser.EatToken();
				}
				if (token == null)
				{
					if (kind != null)
					{
						return _factory.MissingToken(kind);
					}
					else
					{
						return null;
					}
				}
                var green = ((IncrementalToken)token).GreenToken;
				Debug.Assert(kind == null || green.Kind == kind);
				return green;
            }
            public GreenNode VisitTerminal(IToken token)
            {
				return VisitTerminal(token, null);
            }
            private GreenNode VisitTerminal(ITerminalNode node, MetaSyntaxKind kind)
            {
				if (kind == SyntaxKind.Eof)
				{
					return _syntaxParser.EatToken();
				}
                if (node == null || node.Symbol == null)
				{
					if (kind != null)
					{
						return _factory.MissingToken(kind);
					}
					else
					{
						return null;
					}
				}
				var green = ((IncrementalToken)node.Symbol).GreenToken;
				Debug.Assert(kind == null || green.Kind == kind);
				return green;
			}
            public override GreenNode VisitTerminal(ITerminalNode node)
            {
                return VisitTerminal(node, null);
            }
			public override GreenNode Visit(IParseTree tree)
			{
                if (tree is ICachedRuleContext cached)
                {
                    return cached.CachedNode;
                }
				else if (tree is ParserRuleContext context)
                {
                    if (_syntaxParser.TryGetGreenNode(context, out var existingGreenNode)) return existingGreenNode;
    				return base.Visit(tree);
                }
                else
                {
                    return base.Visit(tree);
                }
			}
			
			public override GreenNode VisitMain(MetaParser.MainContext context)
			{
				if (context == null) return MainGreen.__Missing;
			    MetaParser.UsingNamespaceOrMetamodelContext[] usingNamespaceOrMetamodelContext = context.usingNamespaceOrMetamodel();
			    var usingNamespaceOrMetamodelBuilder = _pool.Allocate<UsingNamespaceOrMetamodelGreen>();
			    for (int i = 0; i < usingNamespaceOrMetamodelContext.Length; i++)
			    {
			        usingNamespaceOrMetamodelBuilder.Add((UsingNamespaceOrMetamodelGreen)this.Visit(usingNamespaceOrMetamodelContext[i]));
			    }
				var usingNamespaceOrMetamodel = usingNamespaceOrMetamodelBuilder.ToList();
				_pool.Free(usingNamespaceOrMetamodelBuilder);
				MetaParser.NamespaceDeclarationContext namespaceDeclarationContext = context.namespaceDeclaration();
				NamespaceDeclarationGreen namespaceDeclaration = null;
				if (namespaceDeclarationContext != null) namespaceDeclaration = (NamespaceDeclarationGreen)this.Visit(namespaceDeclarationContext);
				if (namespaceDeclaration == null) namespaceDeclaration = NamespaceDeclarationGreen.__Missing;
				InternalSyntaxToken eOF = (InternalSyntaxToken)this.VisitTerminal(context.Eof(), MetaSyntaxKind.Eof);
				return _factory.Main(usingNamespaceOrMetamodel, namespaceDeclaration, eOF);
			}
			
			public override GreenNode VisitName(MetaParser.NameContext context)
			{
				if (context == null) return NameGreen.__Missing;
				MetaParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				return _factory.Name(identifier);
			}
			
			public override GreenNode VisitQualifiedName(MetaParser.QualifiedNameContext context)
			{
				if (context == null) return QualifiedNameGreen.__Missing;
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.QualifiedName(qualifier);
			}
			
			public override GreenNode VisitQualifier(MetaParser.QualifierContext context)
			{
				if (context == null) return QualifierGreen.__Missing;
			    MetaParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tDotContext = context.TDot();
			    var identifierBuilder = _pool.AllocateSeparated<IdentifierGreen>();
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tDotContext.Length)
			        {
			            identifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tDotContext[i], MetaSyntaxKind.TDot));
			        }
			    }
				var identifier = identifierBuilder.ToList();
				_pool.Free(identifierBuilder);
				return _factory.Qualifier(identifier);
			}
			
			public override GreenNode VisitAttribute(MetaParser.AttributeContext context)
			{
				if (context == null) return AttributeGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), MetaSyntaxKind.TOpenBracket);
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), MetaSyntaxKind.TCloseBracket);
				return _factory.Attribute(tOpenBracket, qualifier, tCloseBracket);
			}
			
			public override GreenNode VisitUsingNamespaceOrMetamodel(MetaParser.UsingNamespaceOrMetamodelContext context)
			{
				if (context == null) return UsingNamespaceOrMetamodelGreen.__Missing;
				MetaParser.UsingNamespaceContext usingNamespaceContext = context.usingNamespace();
				if (usingNamespaceContext != null) 
				{
					return _factory.UsingNamespaceOrMetamodel((UsingNamespaceGreen)this.Visit(usingNamespaceContext));
				}
				MetaParser.UsingMetamodelContext usingMetamodelContext = context.usingMetamodel();
				if (usingMetamodelContext != null) 
				{
					return _factory.UsingNamespaceOrMetamodel((UsingMetamodelGreen)this.Visit(usingMetamodelContext));
				}
				return UsingNamespaceOrMetamodelGreen.__Missing;
			}
			
			public override GreenNode VisitUsingNamespace(MetaParser.UsingNamespaceContext context)
			{
				if (context == null) return UsingNamespaceGreen.__Missing;
				InternalSyntaxToken kUsing = (InternalSyntaxToken)this.VisitTerminal(context.KUsing(), MetaSyntaxKind.KUsing);
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaSyntaxKind.TSemicolon);
				return _factory.UsingNamespace(kUsing, name, tAssign, qualifier, tSemicolon);
			}
			
			public override GreenNode VisitUsingMetamodel(MetaParser.UsingMetamodelContext context)
			{
				if (context == null) return UsingMetamodelGreen.__Missing;
				InternalSyntaxToken kUsing = (InternalSyntaxToken)this.VisitTerminal(context.KUsing(), MetaSyntaxKind.KUsing);
				InternalSyntaxToken kMetamodel = (InternalSyntaxToken)this.VisitTerminal(context.KMetamodel(), MetaSyntaxKind.KMetamodel);
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				MetaParser.UsingMetamodelReferenceContext usingMetamodelReferenceContext = context.usingMetamodelReference();
				UsingMetamodelReferenceGreen usingMetamodelReference = null;
				if (usingMetamodelReferenceContext != null) usingMetamodelReference = (UsingMetamodelReferenceGreen)this.Visit(usingMetamodelReferenceContext);
				if (usingMetamodelReference == null) usingMetamodelReference = UsingMetamodelReferenceGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaSyntaxKind.TSemicolon);
				return _factory.UsingMetamodel(kUsing, kMetamodel, name, tAssign, usingMetamodelReference, tSemicolon);
			}
			
			public override GreenNode VisitUsingMetamodelReference(MetaParser.UsingMetamodelReferenceContext context)
			{
				if (context == null) return UsingMetamodelReferenceGreen.__Missing;
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				if (qualifierContext != null) 
				{
					return _factory.UsingMetamodelReference((QualifierGreen)this.Visit(qualifierContext));
				}
				MetaParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				if (stringLiteralContext != null) 
				{
					return _factory.UsingMetamodelReference((StringLiteralGreen)this.Visit(stringLiteralContext));
				}
				return UsingMetamodelReferenceGreen.__Missing;
			}
			
			public override GreenNode VisitNamespaceDeclaration(MetaParser.NamespaceDeclarationContext context)
			{
				if (context == null) return NamespaceDeclarationGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), MetaSyntaxKind.KNamespace);
				MetaParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null) qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				if (qualifiedName == null) qualifiedName = QualifiedNameGreen.__Missing;
				MetaParser.NamespaceBodyContext namespaceBodyContext = context.namespaceBody();
				NamespaceBodyGreen namespaceBody = null;
				if (namespaceBodyContext != null) namespaceBody = (NamespaceBodyGreen)this.Visit(namespaceBodyContext);
				if (namespaceBody == null) namespaceBody = NamespaceBodyGreen.__Missing;
				return _factory.NamespaceDeclaration(attribute, kNamespace, qualifiedName, namespaceBody);
			}
			
			public override GreenNode VisitNamespaceBody(MetaParser.NamespaceBodyContext context)
			{
				if (context == null) return NamespaceBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), MetaSyntaxKind.TOpenBrace);
			    MetaParser.UsingNamespaceOrMetamodelContext[] usingNamespaceOrMetamodelContext = context.usingNamespaceOrMetamodel();
			    var usingNamespaceOrMetamodelBuilder = _pool.Allocate<UsingNamespaceOrMetamodelGreen>();
			    for (int i = 0; i < usingNamespaceOrMetamodelContext.Length; i++)
			    {
			        usingNamespaceOrMetamodelBuilder.Add((UsingNamespaceOrMetamodelGreen)this.Visit(usingNamespaceOrMetamodelContext[i]));
			    }
				var usingNamespaceOrMetamodel = usingNamespaceOrMetamodelBuilder.ToList();
				_pool.Free(usingNamespaceOrMetamodelBuilder);
				MetaParser.MetamodelDeclarationContext metamodelDeclarationContext = context.metamodelDeclaration();
				MetamodelDeclarationGreen metamodelDeclaration = null;
				if (metamodelDeclarationContext != null) metamodelDeclaration = (MetamodelDeclarationGreen)this.Visit(metamodelDeclarationContext);
				if (metamodelDeclaration == null) metamodelDeclaration = MetamodelDeclarationGreen.__Missing;
			    MetaParser.DeclarationContext[] declarationContext = context.declaration();
			    var declarationBuilder = _pool.Allocate<DeclarationGreen>();
			    for (int i = 0; i < declarationContext.Length; i++)
			    {
			        declarationBuilder.Add((DeclarationGreen)this.Visit(declarationContext[i]));
			    }
				var declaration = declarationBuilder.ToList();
				_pool.Free(declarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), MetaSyntaxKind.TCloseBrace);
				return _factory.NamespaceBody(tOpenBrace, usingNamespaceOrMetamodel, metamodelDeclaration, declaration, tCloseBrace);
			}
			
			public override GreenNode VisitMetamodelDeclaration(MetaParser.MetamodelDeclarationContext context)
			{
				if (context == null) return MetamodelDeclarationGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kMetamodel = (InternalSyntaxToken)this.VisitTerminal(context.KMetamodel(), MetaSyntaxKind.KMetamodel);
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen());
				MetaParser.MetamodelPropertyListContext metamodelPropertyListContext = context.metamodelPropertyList();
				MetamodelPropertyListGreen metamodelPropertyList = null;
				if (metamodelPropertyListContext != null) metamodelPropertyList = (MetamodelPropertyListGreen)this.Visit(metamodelPropertyListContext);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen());
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaSyntaxKind.TSemicolon);
				return _factory.MetamodelDeclaration(attribute, kMetamodel, name, tOpenParen, metamodelPropertyList, tCloseParen, tSemicolon);
			}
			
			public override GreenNode VisitMetamodelPropertyList(MetaParser.MetamodelPropertyListContext context)
			{
				if (context == null) return MetamodelPropertyListGreen.__Missing;
			    MetaParser.MetamodelPropertyContext[] metamodelPropertyContext = context.metamodelProperty();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var metamodelPropertyBuilder = _pool.AllocateSeparated<MetamodelPropertyGreen>();
			    for (int i = 0; i < metamodelPropertyContext.Length; i++)
			    {
			        metamodelPropertyBuilder.Add((MetamodelPropertyGreen)this.Visit(metamodelPropertyContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            metamodelPropertyBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaSyntaxKind.TComma));
			        }
			    }
				var metamodelProperty = metamodelPropertyBuilder.ToList();
				_pool.Free(metamodelPropertyBuilder);
				return _factory.MetamodelPropertyList(metamodelProperty);
			}
			
			public override GreenNode VisitMetamodelProperty(MetaParser.MetamodelPropertyContext context)
			{
				if (context == null) return MetamodelPropertyGreen.__Missing;
				MetaParser.MetamodelUriPropertyContext metamodelUriPropertyContext = context.metamodelUriProperty();
				if (metamodelUriPropertyContext != null) 
				{
					return _factory.MetamodelProperty((MetamodelUriPropertyGreen)this.Visit(metamodelUriPropertyContext));
				}
				MetaParser.MetamodelPrefixPropertyContext metamodelPrefixPropertyContext = context.metamodelPrefixProperty();
				if (metamodelPrefixPropertyContext != null) 
				{
					return _factory.MetamodelProperty((MetamodelPrefixPropertyGreen)this.Visit(metamodelPrefixPropertyContext));
				}
				MetaParser.MetamodelVersionPropertyContext metamodelVersionPropertyContext = context.metamodelVersionProperty();
				if (metamodelVersionPropertyContext != null) 
				{
					return _factory.MetamodelProperty((MetamodelVersionPropertyGreen)this.Visit(metamodelVersionPropertyContext));
				}
				return MetamodelPropertyGreen.__Missing;
			}
			
			public override GreenNode VisitMetamodelUriProperty(MetaParser.MetamodelUriPropertyContext context)
			{
				if (context == null) return MetamodelUriPropertyGreen.__Missing;
				InternalSyntaxToken iUri = (InternalSyntaxToken)this.VisitTerminal(context.IUri(), MetaSyntaxKind.IUri);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), MetaSyntaxKind.TAssign);
				MetaParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null) stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				if (stringLiteral == null) stringLiteral = StringLiteralGreen.__Missing;
				return _factory.MetamodelUriProperty(iUri, tAssign, stringLiteral);
			}
			
			public override GreenNode VisitMetamodelPrefixProperty(MetaParser.MetamodelPrefixPropertyContext context)
			{
				if (context == null) return MetamodelPrefixPropertyGreen.__Missing;
				InternalSyntaxToken iPrefix = (InternalSyntaxToken)this.VisitTerminal(context.IPrefix(), MetaSyntaxKind.IPrefix);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), MetaSyntaxKind.TAssign);
				MetaParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null) stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				if (stringLiteral == null) stringLiteral = StringLiteralGreen.__Missing;
				return _factory.MetamodelPrefixProperty(iPrefix, tAssign, stringLiteral);
			}
			
			public override GreenNode VisitMetamodelVersionProperty(MetaParser.MetamodelVersionPropertyContext context)
			{
				if (context == null) return MetamodelVersionPropertyGreen.__Missing;
				InternalSyntaxToken iVersion = (InternalSyntaxToken)this.VisitTerminal(context.IVersion(), MetaSyntaxKind.IVersion);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), MetaSyntaxKind.TAssign);
				MetaParser.IntegerLiteralContext majorContext = context.major;
				IntegerLiteralGreen major = null;
				if (majorContext != null) major = (IntegerLiteralGreen)this.Visit(majorContext);
				if (major == null) major = IntegerLiteralGreen.__Missing;
				InternalSyntaxToken tDot = (InternalSyntaxToken)this.VisitTerminal(context.TDot(), MetaSyntaxKind.TDot);
				MetaParser.IntegerLiteralContext minorContext = context.minor;
				IntegerLiteralGreen minor = null;
				if (minorContext != null) minor = (IntegerLiteralGreen)this.Visit(minorContext);
				if (minor == null) minor = IntegerLiteralGreen.__Missing;
				return _factory.MetamodelVersionProperty(iVersion, tAssign, major, tDot, minor);
			}
			
			public override GreenNode VisitDeclaration(MetaParser.DeclarationContext context)
			{
				if (context == null) return DeclarationGreen.__Missing;
				MetaParser.EnumDeclarationContext enumDeclarationContext = context.enumDeclaration();
				if (enumDeclarationContext != null) 
				{
					return _factory.Declaration((EnumDeclarationGreen)this.Visit(enumDeclarationContext));
				}
				MetaParser.ClassDeclarationContext classDeclarationContext = context.classDeclaration();
				if (classDeclarationContext != null) 
				{
					return _factory.Declaration((ClassDeclarationGreen)this.Visit(classDeclarationContext));
				}
				MetaParser.AssociationDeclarationContext associationDeclarationContext = context.associationDeclaration();
				if (associationDeclarationContext != null) 
				{
					return _factory.Declaration((AssociationDeclarationGreen)this.Visit(associationDeclarationContext));
				}
				MetaParser.ConstDeclarationContext constDeclarationContext = context.constDeclaration();
				if (constDeclarationContext != null) 
				{
					return _factory.Declaration((ConstDeclarationGreen)this.Visit(constDeclarationContext));
				}
				return DeclarationGreen.__Missing;
			}
			
			public override GreenNode VisitEnumDeclaration(MetaParser.EnumDeclarationContext context)
			{
				if (context == null) return EnumDeclarationGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kEnum = (InternalSyntaxToken)this.VisitTerminal(context.KEnum(), MetaSyntaxKind.KEnum);
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				MetaParser.EnumBodyContext enumBodyContext = context.enumBody();
				EnumBodyGreen enumBody = null;
				if (enumBodyContext != null) enumBody = (EnumBodyGreen)this.Visit(enumBodyContext);
				if (enumBody == null) enumBody = EnumBodyGreen.__Missing;
				return _factory.EnumDeclaration(attribute, kEnum, name, enumBody);
			}
			
			public override GreenNode VisitEnumBody(MetaParser.EnumBodyContext context)
			{
				if (context == null) return EnumBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), MetaSyntaxKind.TOpenBrace);
				MetaParser.EnumValuesContext enumValuesContext = context.enumValues();
				EnumValuesGreen enumValues = null;
				if (enumValuesContext != null) enumValues = (EnumValuesGreen)this.Visit(enumValuesContext);
				if (enumValues == null) enumValues = EnumValuesGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
			    MetaParser.EnumMemberDeclarationContext[] enumMemberDeclarationContext = context.enumMemberDeclaration();
			    var enumMemberDeclarationBuilder = _pool.Allocate<EnumMemberDeclarationGreen>();
			    for (int i = 0; i < enumMemberDeclarationContext.Length; i++)
			    {
			        enumMemberDeclarationBuilder.Add((EnumMemberDeclarationGreen)this.Visit(enumMemberDeclarationContext[i]));
			    }
				var enumMemberDeclaration = enumMemberDeclarationBuilder.ToList();
				_pool.Free(enumMemberDeclarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), MetaSyntaxKind.TCloseBrace);
				return _factory.EnumBody(tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration, tCloseBrace);
			}
			
			public override GreenNode VisitEnumValues(MetaParser.EnumValuesContext context)
			{
				if (context == null) return EnumValuesGreen.__Missing;
			    MetaParser.EnumValueContext[] enumValueContext = context.enumValue();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var enumValueBuilder = _pool.AllocateSeparated<EnumValueGreen>();
			    for (int i = 0; i < enumValueContext.Length; i++)
			    {
			        enumValueBuilder.Add((EnumValueGreen)this.Visit(enumValueContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            enumValueBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaSyntaxKind.TComma));
			        }
			    }
				var enumValue = enumValueBuilder.ToList();
				_pool.Free(enumValueBuilder);
				return _factory.EnumValues(enumValue);
			}
			
			public override GreenNode VisitEnumValue(MetaParser.EnumValueContext context)
			{
				if (context == null) return EnumValueGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				return _factory.EnumValue(attribute, name);
			}
			
			public override GreenNode VisitEnumMemberDeclaration(MetaParser.EnumMemberDeclarationContext context)
			{
				if (context == null) return EnumMemberDeclarationGreen.__Missing;
				MetaParser.OperationDeclarationContext operationDeclarationContext = context.operationDeclaration();
				OperationDeclarationGreen operationDeclaration = null;
				if (operationDeclarationContext != null) operationDeclaration = (OperationDeclarationGreen)this.Visit(operationDeclarationContext);
				if (operationDeclaration == null) operationDeclaration = OperationDeclarationGreen.__Missing;
				return _factory.EnumMemberDeclaration(operationDeclaration);
			}
			
			public override GreenNode VisitClassDeclaration(MetaParser.ClassDeclarationContext context)
			{
				if (context == null) return ClassDeclarationGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				MetaParser.SymbolAttributeContext symbolAttributeContext = context.symbolAttribute();
				SymbolAttributeGreen symbolAttribute = null;
				if (symbolAttributeContext != null) symbolAttribute = (SymbolAttributeGreen)this.Visit(symbolAttributeContext);
				InternalSyntaxToken kAbstract = (InternalSyntaxToken)this.VisitTerminal(context.KAbstract());
				InternalSyntaxToken kClass = (InternalSyntaxToken)this.VisitTerminal(context.KClass(), MetaSyntaxKind.KClass);
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				MetaParser.ClassAncestorsContext classAncestorsContext = context.classAncestors();
				ClassAncestorsGreen classAncestors = null;
				if (classAncestorsContext != null) classAncestors = (ClassAncestorsGreen)this.Visit(classAncestorsContext);
				MetaParser.ClassBodyContext classBodyContext = context.classBody();
				ClassBodyGreen classBody = null;
				if (classBodyContext != null) classBody = (ClassBodyGreen)this.Visit(classBodyContext);
				if (classBody == null) classBody = ClassBodyGreen.__Missing;
				return _factory.ClassDeclaration(attribute, symbolAttribute, kAbstract, kClass, name, tColon, classAncestors, classBody);
			}
			
			public override GreenNode VisitSymbolAttribute(MetaParser.SymbolAttributeContext context)
			{
				if (context == null) return SymbolAttributeGreen.__Missing;
				MetaParser.SymbolSymbolAttributeContext symbolSymbolAttributeContext = context.symbolSymbolAttribute();
				if (symbolSymbolAttributeContext != null) 
				{
					return _factory.SymbolAttribute((SymbolSymbolAttributeGreen)this.Visit(symbolSymbolAttributeContext));
				}
				MetaParser.ExpressionSymbolAttributeContext expressionSymbolAttributeContext = context.expressionSymbolAttribute();
				if (expressionSymbolAttributeContext != null) 
				{
					return _factory.SymbolAttribute((ExpressionSymbolAttributeGreen)this.Visit(expressionSymbolAttributeContext));
				}
				MetaParser.StatementSymbolTypeAttributeContext statementSymbolTypeAttributeContext = context.statementSymbolTypeAttribute();
				if (statementSymbolTypeAttributeContext != null) 
				{
					return _factory.SymbolAttribute((StatementSymbolTypeAttributeGreen)this.Visit(statementSymbolTypeAttributeContext));
				}
				MetaParser.TypeSymbolTypeAttributeContext typeSymbolTypeAttributeContext = context.typeSymbolTypeAttribute();
				if (typeSymbolTypeAttributeContext != null) 
				{
					return _factory.SymbolAttribute((TypeSymbolTypeAttributeGreen)this.Visit(typeSymbolTypeAttributeContext));
				}
				return SymbolAttributeGreen.__Missing;
			}
			
			public override GreenNode VisitSymbolSymbolAttribute(MetaParser.SymbolSymbolAttributeContext context)
			{
				if (context == null) return SymbolSymbolAttributeGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), MetaSyntaxKind.TOpenBracket);
				InternalSyntaxToken kSymbol = (InternalSyntaxToken)this.VisitTerminal(context.KSymbol(), MetaSyntaxKind.KSymbol);
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), MetaSyntaxKind.TColon);
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), MetaSyntaxKind.TCloseBracket);
				return _factory.SymbolSymbolAttribute(tOpenBracket, kSymbol, tColon, qualifier, tCloseBracket);
			}
			
			public override GreenNode VisitExpressionSymbolAttribute(MetaParser.ExpressionSymbolAttributeContext context)
			{
				if (context == null) return ExpressionSymbolAttributeGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), MetaSyntaxKind.TOpenBracket);
				InternalSyntaxToken kExpression = (InternalSyntaxToken)this.VisitTerminal(context.KExpression(), MetaSyntaxKind.KExpression);
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), MetaSyntaxKind.TColon);
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), MetaSyntaxKind.TCloseBracket);
				return _factory.ExpressionSymbolAttribute(tOpenBracket, kExpression, tColon, qualifier, tCloseBracket);
			}
			
			public override GreenNode VisitStatementSymbolTypeAttribute(MetaParser.StatementSymbolTypeAttributeContext context)
			{
				if (context == null) return StatementSymbolTypeAttributeGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), MetaSyntaxKind.TOpenBracket);
				InternalSyntaxToken kStatement = (InternalSyntaxToken)this.VisitTerminal(context.KStatement(), MetaSyntaxKind.KStatement);
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), MetaSyntaxKind.TColon);
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), MetaSyntaxKind.TCloseBracket);
				return _factory.StatementSymbolTypeAttribute(tOpenBracket, kStatement, tColon, qualifier, tCloseBracket);
			}
			
			public override GreenNode VisitTypeSymbolTypeAttribute(MetaParser.TypeSymbolTypeAttributeContext context)
			{
				if (context == null) return TypeSymbolTypeAttributeGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), MetaSyntaxKind.TOpenBracket);
				InternalSyntaxToken kType = (InternalSyntaxToken)this.VisitTerminal(context.KType(), MetaSyntaxKind.KType);
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), MetaSyntaxKind.TColon);
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), MetaSyntaxKind.TCloseBracket);
				return _factory.TypeSymbolTypeAttribute(tOpenBracket, kType, tColon, qualifier, tCloseBracket);
			}
			
			public override GreenNode VisitClassBody(MetaParser.ClassBodyContext context)
			{
				if (context == null) return ClassBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), MetaSyntaxKind.TOpenBrace);
			    MetaParser.ClassMemberDeclarationContext[] classMemberDeclarationContext = context.classMemberDeclaration();
			    var classMemberDeclarationBuilder = _pool.Allocate<ClassMemberDeclarationGreen>();
			    for (int i = 0; i < classMemberDeclarationContext.Length; i++)
			    {
			        classMemberDeclarationBuilder.Add((ClassMemberDeclarationGreen)this.Visit(classMemberDeclarationContext[i]));
			    }
				var classMemberDeclaration = classMemberDeclarationBuilder.ToList();
				_pool.Free(classMemberDeclarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), MetaSyntaxKind.TCloseBrace);
				return _factory.ClassBody(tOpenBrace, classMemberDeclaration, tCloseBrace);
			}
			
			public override GreenNode VisitClassAncestors(MetaParser.ClassAncestorsContext context)
			{
				if (context == null) return ClassAncestorsGreen.__Missing;
			    MetaParser.ClassAncestorContext[] classAncestorContext = context.classAncestor();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var classAncestorBuilder = _pool.AllocateSeparated<ClassAncestorGreen>();
			    for (int i = 0; i < classAncestorContext.Length; i++)
			    {
			        classAncestorBuilder.Add((ClassAncestorGreen)this.Visit(classAncestorContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            classAncestorBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaSyntaxKind.TComma));
			        }
			    }
				var classAncestor = classAncestorBuilder.ToList();
				_pool.Free(classAncestorBuilder);
				return _factory.ClassAncestors(classAncestor);
			}
			
			public override GreenNode VisitClassAncestor(MetaParser.ClassAncestorContext context)
			{
				if (context == null) return ClassAncestorGreen.__Missing;
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.ClassAncestor(qualifier);
			}
			
			public override GreenNode VisitClassMemberDeclaration(MetaParser.ClassMemberDeclarationContext context)
			{
				if (context == null) return ClassMemberDeclarationGreen.__Missing;
				MetaParser.FieldDeclarationContext fieldDeclarationContext = context.fieldDeclaration();
				if (fieldDeclarationContext != null) 
				{
					return _factory.ClassMemberDeclaration((FieldDeclarationGreen)this.Visit(fieldDeclarationContext));
				}
				MetaParser.OperationDeclarationContext operationDeclarationContext = context.operationDeclaration();
				if (operationDeclarationContext != null) 
				{
					return _factory.ClassMemberDeclaration((OperationDeclarationGreen)this.Visit(operationDeclarationContext));
				}
				return ClassMemberDeclarationGreen.__Missing;
			}
			
			public override GreenNode VisitFieldDeclaration(MetaParser.FieldDeclarationContext context)
			{
				if (context == null) return FieldDeclarationGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				MetaParser.FieldSymbolPropertyAttributeContext fieldSymbolPropertyAttributeContext = context.fieldSymbolPropertyAttribute();
				FieldSymbolPropertyAttributeGreen fieldSymbolPropertyAttribute = null;
				if (fieldSymbolPropertyAttributeContext != null) fieldSymbolPropertyAttribute = (FieldSymbolPropertyAttributeGreen)this.Visit(fieldSymbolPropertyAttributeContext);
				MetaParser.FieldContainmentContext fieldContainmentContext = context.fieldContainment();
				FieldContainmentGreen fieldContainment = null;
				if (fieldContainmentContext != null) fieldContainment = (FieldContainmentGreen)this.Visit(fieldContainmentContext);
				MetaParser.FieldModifierContext fieldModifierContext = context.fieldModifier();
				FieldModifierGreen fieldModifier = null;
				if (fieldModifierContext != null) fieldModifier = (FieldModifierGreen)this.Visit(fieldModifierContext);
				MetaParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				MetaParser.DefaultValueContext defaultValueContext = context.defaultValue();
				DefaultValueGreen defaultValue = null;
				if (defaultValueContext != null) defaultValue = (DefaultValueGreen)this.Visit(defaultValueContext);
			    MetaParser.RedefinitionsOrSubsettingsContext[] redefinitionsOrSubsettingsContext = context.redefinitionsOrSubsettings();
			    var redefinitionsOrSubsettingsBuilder = _pool.Allocate<RedefinitionsOrSubsettingsGreen>();
			    for (int i = 0; i < redefinitionsOrSubsettingsContext.Length; i++)
			    {
			        redefinitionsOrSubsettingsBuilder.Add((RedefinitionsOrSubsettingsGreen)this.Visit(redefinitionsOrSubsettingsContext[i]));
			    }
				var redefinitionsOrSubsettings = redefinitionsOrSubsettingsBuilder.ToList();
				_pool.Free(redefinitionsOrSubsettingsBuilder);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaSyntaxKind.TSemicolon);
				return _factory.FieldDeclaration(attribute, fieldSymbolPropertyAttribute, fieldContainment, fieldModifier, typeReference, name, defaultValue, redefinitionsOrSubsettings, tSemicolon);
			}
			
			public override GreenNode VisitFieldSymbolPropertyAttribute(MetaParser.FieldSymbolPropertyAttributeContext context)
			{
				if (context == null) return FieldSymbolPropertyAttributeGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), MetaSyntaxKind.TOpenBracket);
				InternalSyntaxToken kProperty = (InternalSyntaxToken)this.VisitTerminal(context.KProperty(), MetaSyntaxKind.KProperty);
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon(), MetaSyntaxKind.TColon);
				MetaParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), MetaSyntaxKind.TCloseBracket);
				return _factory.FieldSymbolPropertyAttribute(tOpenBracket, kProperty, tColon, identifier, tCloseBracket);
			}
			
			public override GreenNode VisitFieldContainment(MetaParser.FieldContainmentContext context)
			{
				if (context == null) return FieldContainmentGreen.__Missing;
				InternalSyntaxToken kContainment = (InternalSyntaxToken)this.VisitTerminal(context.KContainment(), MetaSyntaxKind.KContainment);
				return _factory.FieldContainment(kContainment);
			}
			
			public override GreenNode VisitFieldModifier(MetaParser.FieldModifierContext context)
			{
				if (context == null) return FieldModifierGreen.__Missing;
				InternalSyntaxToken fieldModifier = null;
				if (context.KReadonly() != null)
				{
					fieldModifier = (InternalSyntaxToken)this.VisitTerminal(context.KReadonly());
				}
				else 	if (context.KLazy() != null)
				{
					fieldModifier = (InternalSyntaxToken)this.VisitTerminal(context.KLazy());
				}
				else 	if (context.KDerived() != null)
				{
					fieldModifier = (InternalSyntaxToken)this.VisitTerminal(context.KDerived());
				}
				else 	if (context.KUnion() != null)
				{
					fieldModifier = (InternalSyntaxToken)this.VisitTerminal(context.KUnion());
				}
				else
				{
					fieldModifier = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.FieldModifier(fieldModifier);
			}
			
			public override GreenNode VisitDefaultValue(MetaParser.DefaultValueContext context)
			{
				if (context == null) return DefaultValueGreen.__Missing;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), MetaSyntaxKind.TAssign);
				MetaParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null) stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				if (stringLiteral == null) stringLiteral = StringLiteralGreen.__Missing;
				return _factory.DefaultValue(tAssign, stringLiteral);
			}
			
			public override GreenNode VisitRedefinitionsOrSubsettings(MetaParser.RedefinitionsOrSubsettingsContext context)
			{
				if (context == null) return RedefinitionsOrSubsettingsGreen.__Missing;
				MetaParser.RedefinitionsContext redefinitionsContext = context.redefinitions();
				if (redefinitionsContext != null) 
				{
					return _factory.RedefinitionsOrSubsettings((RedefinitionsGreen)this.Visit(redefinitionsContext));
				}
				MetaParser.SubsettingsContext subsettingsContext = context.subsettings();
				if (subsettingsContext != null) 
				{
					return _factory.RedefinitionsOrSubsettings((SubsettingsGreen)this.Visit(subsettingsContext));
				}
				return RedefinitionsOrSubsettingsGreen.__Missing;
			}
			
			public override GreenNode VisitRedefinitions(MetaParser.RedefinitionsContext context)
			{
				if (context == null) return RedefinitionsGreen.__Missing;
				InternalSyntaxToken kRedefines = (InternalSyntaxToken)this.VisitTerminal(context.KRedefines(), MetaSyntaxKind.KRedefines);
				MetaParser.NameUseListContext nameUseListContext = context.nameUseList();
				NameUseListGreen nameUseList = null;
				if (nameUseListContext != null) nameUseList = (NameUseListGreen)this.Visit(nameUseListContext);
				return _factory.Redefinitions(kRedefines, nameUseList);
			}
			
			public override GreenNode VisitSubsettings(MetaParser.SubsettingsContext context)
			{
				if (context == null) return SubsettingsGreen.__Missing;
				InternalSyntaxToken kSubsets = (InternalSyntaxToken)this.VisitTerminal(context.KSubsets(), MetaSyntaxKind.KSubsets);
				MetaParser.NameUseListContext nameUseListContext = context.nameUseList();
				NameUseListGreen nameUseList = null;
				if (nameUseListContext != null) nameUseList = (NameUseListGreen)this.Visit(nameUseListContext);
				return _factory.Subsettings(kSubsets, nameUseList);
			}
			
			public override GreenNode VisitNameUseList(MetaParser.NameUseListContext context)
			{
				if (context == null) return NameUseListGreen.__Missing;
			    MetaParser.QualifierContext[] qualifierContext = context.qualifier();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var qualifierBuilder = _pool.AllocateSeparated<QualifierGreen>();
			    for (int i = 0; i < qualifierContext.Length; i++)
			    {
			        qualifierBuilder.Add((QualifierGreen)this.Visit(qualifierContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            qualifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaSyntaxKind.TComma));
			        }
			    }
				var qualifier = qualifierBuilder.ToList();
				_pool.Free(qualifierBuilder);
				return _factory.NameUseList(qualifier);
			}
			
			public override GreenNode VisitConstDeclaration(MetaParser.ConstDeclarationContext context)
			{
				if (context == null) return ConstDeclarationGreen.__Missing;
				InternalSyntaxToken kConst = (InternalSyntaxToken)this.VisitTerminal(context.KConst(), MetaSyntaxKind.KConst);
				MetaParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				MetaParser.ConstValueContext constValueContext = context.constValue();
				ConstValueGreen constValue = null;
				if (constValueContext != null) constValue = (ConstValueGreen)this.Visit(constValueContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaSyntaxKind.TSemicolon);
				return _factory.ConstDeclaration(kConst, typeReference, name, constValue, tSemicolon);
			}
			
			public override GreenNode VisitConstValue(MetaParser.ConstValueContext context)
			{
				if (context == null) return ConstValueGreen.__Missing;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), MetaSyntaxKind.TAssign);
				MetaParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null) stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				if (stringLiteral == null) stringLiteral = StringLiteralGreen.__Missing;
				return _factory.ConstValue(tAssign, stringLiteral);
			}
			
			public override GreenNode VisitReturnType(MetaParser.ReturnTypeContext context)
			{
				if (context == null) return ReturnTypeGreen.__Missing;
				MetaParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				if (typeReferenceContext != null) 
				{
					return _factory.ReturnType((TypeReferenceGreen)this.Visit(typeReferenceContext));
				}
				MetaParser.VoidTypeContext voidTypeContext = context.voidType();
				if (voidTypeContext != null) 
				{
					return _factory.ReturnType((VoidTypeGreen)this.Visit(voidTypeContext));
				}
				return ReturnTypeGreen.__Missing;
			}
			
			public override GreenNode VisitTypeOfReference(MetaParser.TypeOfReferenceContext context)
			{
				if (context == null) return TypeOfReferenceGreen.__Missing;
				MetaParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				return _factory.TypeOfReference(typeReference);
			}
			
			public override GreenNode VisitTypeReference(MetaParser.TypeReferenceContext context)
			{
				if (context == null) return TypeReferenceGreen.__Missing;
				MetaParser.CollectionTypeContext collectionTypeContext = context.collectionType();
				if (collectionTypeContext != null) 
				{
					return _factory.TypeReference((CollectionTypeGreen)this.Visit(collectionTypeContext));
				}
				MetaParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				if (simpleTypeContext != null) 
				{
					return _factory.TypeReference((SimpleTypeGreen)this.Visit(simpleTypeContext));
				}
				return TypeReferenceGreen.__Missing;
			}
			
			public override GreenNode VisitSimpleType(MetaParser.SimpleTypeContext context)
			{
				if (context == null) return SimpleTypeGreen.__Missing;
				MetaParser.PrimitiveTypeContext primitiveTypeContext = context.primitiveType();
				if (primitiveTypeContext != null) 
				{
					return _factory.SimpleType((PrimitiveTypeGreen)this.Visit(primitiveTypeContext));
				}
				MetaParser.ObjectTypeContext objectTypeContext = context.objectType();
				if (objectTypeContext != null) 
				{
					return _factory.SimpleType((ObjectTypeGreen)this.Visit(objectTypeContext));
				}
				MetaParser.NullableTypeContext nullableTypeContext = context.nullableType();
				if (nullableTypeContext != null) 
				{
					return _factory.SimpleType((NullableTypeGreen)this.Visit(nullableTypeContext));
				}
				MetaParser.ClassTypeContext classTypeContext = context.classType();
				if (classTypeContext != null) 
				{
					return _factory.SimpleType((ClassTypeGreen)this.Visit(classTypeContext));
				}
				return SimpleTypeGreen.__Missing;
			}
			
			public override GreenNode VisitClassType(MetaParser.ClassTypeContext context)
			{
				if (context == null) return ClassTypeGreen.__Missing;
				MetaParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.ClassType(qualifier);
			}
			
			public override GreenNode VisitObjectType(MetaParser.ObjectTypeContext context)
			{
				if (context == null) return ObjectTypeGreen.__Missing;
				InternalSyntaxToken objectType = null;
				if (context.KObject() != null)
				{
					objectType = (InternalSyntaxToken)this.VisitTerminal(context.KObject());
				}
				else 	if (context.KSymbol() != null)
				{
					objectType = (InternalSyntaxToken)this.VisitTerminal(context.KSymbol());
				}
				else 	if (context.KString() != null)
				{
					objectType = (InternalSyntaxToken)this.VisitTerminal(context.KString());
				}
				else
				{
					objectType = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.ObjectType(objectType);
			}
			
			public override GreenNode VisitPrimitiveType(MetaParser.PrimitiveTypeContext context)
			{
				if (context == null) return PrimitiveTypeGreen.__Missing;
				InternalSyntaxToken primitiveType = null;
				if (context.KInt() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KInt());
				}
				else 	if (context.KLong() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KLong());
				}
				else 	if (context.KFloat() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KFloat());
				}
				else 	if (context.KDouble() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KDouble());
				}
				else 	if (context.KByte() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KByte());
				}
				else 	if (context.KBool() != null)
				{
					primitiveType = (InternalSyntaxToken)this.VisitTerminal(context.KBool());
				}
				else
				{
					primitiveType = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.PrimitiveType(primitiveType);
			}
			
			public override GreenNode VisitVoidType(MetaParser.VoidTypeContext context)
			{
				if (context == null) return VoidTypeGreen.__Missing;
				InternalSyntaxToken kVoid = (InternalSyntaxToken)this.VisitTerminal(context.KVoid(), MetaSyntaxKind.KVoid);
				return _factory.VoidType(kVoid);
			}
			
			public override GreenNode VisitNullableType(MetaParser.NullableTypeContext context)
			{
				if (context == null) return NullableTypeGreen.__Missing;
				MetaParser.PrimitiveTypeContext primitiveTypeContext = context.primitiveType();
				PrimitiveTypeGreen primitiveType = null;
				if (primitiveTypeContext != null) primitiveType = (PrimitiveTypeGreen)this.Visit(primitiveTypeContext);
				if (primitiveType == null) primitiveType = PrimitiveTypeGreen.__Missing;
				InternalSyntaxToken tQuestion = (InternalSyntaxToken)this.VisitTerminal(context.TQuestion(), MetaSyntaxKind.TQuestion);
				return _factory.NullableType(primitiveType, tQuestion);
			}
			
			public override GreenNode VisitCollectionType(MetaParser.CollectionTypeContext context)
			{
				if (context == null) return CollectionTypeGreen.__Missing;
				MetaParser.CollectionKindContext collectionKindContext = context.collectionKind();
				CollectionKindGreen collectionKind = null;
				if (collectionKindContext != null) collectionKind = (CollectionKindGreen)this.Visit(collectionKindContext);
				if (collectionKind == null) collectionKind = CollectionKindGreen.__Missing;
				InternalSyntaxToken tLessThan = (InternalSyntaxToken)this.VisitTerminal(context.TLessThan(), MetaSyntaxKind.TLessThan);
				MetaParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				SimpleTypeGreen simpleType = null;
				if (simpleTypeContext != null) simpleType = (SimpleTypeGreen)this.Visit(simpleTypeContext);
				if (simpleType == null) simpleType = SimpleTypeGreen.__Missing;
				InternalSyntaxToken tGreaterThan = (InternalSyntaxToken)this.VisitTerminal(context.TGreaterThan(), MetaSyntaxKind.TGreaterThan);
				return _factory.CollectionType(collectionKind, tLessThan, simpleType, tGreaterThan);
			}
			
			public override GreenNode VisitCollectionKind(MetaParser.CollectionKindContext context)
			{
				if (context == null) return CollectionKindGreen.__Missing;
				InternalSyntaxToken collectionKind = null;
				if (context.KSet() != null)
				{
					collectionKind = (InternalSyntaxToken)this.VisitTerminal(context.KSet());
				}
				else 	if (context.KList() != null)
				{
					collectionKind = (InternalSyntaxToken)this.VisitTerminal(context.KList());
				}
				else 	if (context.KMultiSet() != null)
				{
					collectionKind = (InternalSyntaxToken)this.VisitTerminal(context.KMultiSet());
				}
				else 	if (context.KMultiList() != null)
				{
					collectionKind = (InternalSyntaxToken)this.VisitTerminal(context.KMultiList());
				}
				else
				{
					collectionKind = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.CollectionKind(collectionKind);
			}
			
			public override GreenNode VisitOperationDeclaration(MetaParser.OperationDeclarationContext context)
			{
				if (context == null) return OperationDeclarationGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
			    MetaParser.OperationModifierContext[] operationModifierContext = context.operationModifier();
			    var operationModifierBuilder = _pool.Allocate<OperationModifierGreen>();
			    for (int i = 0; i < operationModifierContext.Length; i++)
			    {
			        operationModifierBuilder.Add((OperationModifierGreen)this.Visit(operationModifierContext[i]));
			    }
				var operationModifier = operationModifierBuilder.ToList();
				_pool.Free(operationModifierBuilder);
				MetaParser.ReturnTypeContext returnTypeContext = context.returnType();
				ReturnTypeGreen returnType = null;
				if (returnTypeContext != null) returnType = (ReturnTypeGreen)this.Visit(returnTypeContext);
				if (returnType == null) returnType = ReturnTypeGreen.__Missing;
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), MetaSyntaxKind.TOpenParen);
				MetaParser.ParameterListContext parameterListContext = context.parameterList();
				ParameterListGreen parameterList = null;
				if (parameterListContext != null) parameterList = (ParameterListGreen)this.Visit(parameterListContext);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), MetaSyntaxKind.TCloseParen);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaSyntaxKind.TSemicolon);
				return _factory.OperationDeclaration(attribute, operationModifier, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
			}
			
			public override GreenNode VisitOperationModifier(MetaParser.OperationModifierContext context)
			{
				if (context == null) return OperationModifierGreen.__Missing;
				MetaParser.OperationModifierBuilderContext operationModifierBuilderContext = context.operationModifierBuilder();
				if (operationModifierBuilderContext != null) 
				{
					return _factory.OperationModifier((OperationModifierBuilderGreen)this.Visit(operationModifierBuilderContext));
				}
				MetaParser.OperationModifierReadonlyContext operationModifierReadonlyContext = context.operationModifierReadonly();
				if (operationModifierReadonlyContext != null) 
				{
					return _factory.OperationModifier((OperationModifierReadonlyGreen)this.Visit(operationModifierReadonlyContext));
				}
				return OperationModifierGreen.__Missing;
			}
			
			public override GreenNode VisitOperationModifierBuilder(MetaParser.OperationModifierBuilderContext context)
			{
				if (context == null) return OperationModifierBuilderGreen.__Missing;
				InternalSyntaxToken kBuilder = (InternalSyntaxToken)this.VisitTerminal(context.KBuilder(), MetaSyntaxKind.KBuilder);
				return _factory.OperationModifierBuilder(kBuilder);
			}
			
			public override GreenNode VisitOperationModifierReadonly(MetaParser.OperationModifierReadonlyContext context)
			{
				if (context == null) return OperationModifierReadonlyGreen.__Missing;
				InternalSyntaxToken kReadonly = (InternalSyntaxToken)this.VisitTerminal(context.KReadonly(), MetaSyntaxKind.KReadonly);
				return _factory.OperationModifierReadonly(kReadonly);
			}
			
			public override GreenNode VisitParameterList(MetaParser.ParameterListContext context)
			{
				if (context == null) return ParameterListGreen.__Missing;
			    MetaParser.ParameterContext[] parameterContext = context.parameter();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var parameterBuilder = _pool.AllocateSeparated<ParameterGreen>();
			    for (int i = 0; i < parameterContext.Length; i++)
			    {
			        parameterBuilder.Add((ParameterGreen)this.Visit(parameterContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            parameterBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaSyntaxKind.TComma));
			        }
			    }
				var parameter = parameterBuilder.ToList();
				_pool.Free(parameterBuilder);
				return _factory.ParameterList(parameter);
			}
			
			public override GreenNode VisitParameter(MetaParser.ParameterContext context)
			{
				if (context == null) return ParameterGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				MetaParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				MetaParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				return _factory.Parameter(attribute, typeReference, name);
			}
			
			public override GreenNode VisitAssociationDeclaration(MetaParser.AssociationDeclarationContext context)
			{
				if (context == null) return AssociationDeclarationGreen.__Missing;
			    MetaParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kAssociation = (InternalSyntaxToken)this.VisitTerminal(context.KAssociation(), MetaSyntaxKind.KAssociation);
				MetaParser.QualifierContext sourceContext = context.source;
				QualifierGreen source = null;
				if (sourceContext != null) source = (QualifierGreen)this.Visit(sourceContext);
				if (source == null) source = QualifierGreen.__Missing;
				InternalSyntaxToken kWith = (InternalSyntaxToken)this.VisitTerminal(context.KWith(), MetaSyntaxKind.KWith);
				MetaParser.QualifierContext targetContext = context.target;
				QualifierGreen target = null;
				if (targetContext != null) target = (QualifierGreen)this.Visit(targetContext);
				if (target == null) target = QualifierGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaSyntaxKind.TSemicolon);
				return _factory.AssociationDeclaration(attribute, kAssociation, source, kWith, target, tSemicolon);
			}
			
			public override GreenNode VisitIdentifier(MetaParser.IdentifierContext context)
			{
				if (context == null) return IdentifierGreen.__Missing;
				InternalSyntaxToken identifier = null;
				if (context.IdentifierNormal() != null)
				{
					identifier = (InternalSyntaxToken)this.VisitTerminal(context.IdentifierNormal());
				}
				else 	if (context.IdentifierVerbatim() != null)
				{
					identifier = (InternalSyntaxToken)this.VisitTerminal(context.IdentifierVerbatim());
				}
				else 	if (context.IUri() != null)
				{
					identifier = (InternalSyntaxToken)this.VisitTerminal(context.IUri());
				}
				else 	if (context.IPrefix() != null)
				{
					identifier = (InternalSyntaxToken)this.VisitTerminal(context.IPrefix());
				}
				else 	if (context.IVersion() != null)
				{
					identifier = (InternalSyntaxToken)this.VisitTerminal(context.IVersion());
				}
				else
				{
					identifier = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.Identifier(identifier);
			}
			
			public override GreenNode VisitLiteral(MetaParser.LiteralContext context)
			{
				if (context == null) return LiteralGreen.__Missing;
				MetaParser.NullLiteralContext nullLiteralContext = context.nullLiteral();
				if (nullLiteralContext != null) 
				{
					return _factory.Literal((NullLiteralGreen)this.Visit(nullLiteralContext));
				}
				MetaParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				if (booleanLiteralContext != null) 
				{
					return _factory.Literal((BooleanLiteralGreen)this.Visit(booleanLiteralContext));
				}
				MetaParser.IntegerLiteralContext integerLiteralContext = context.integerLiteral();
				if (integerLiteralContext != null) 
				{
					return _factory.Literal((IntegerLiteralGreen)this.Visit(integerLiteralContext));
				}
				MetaParser.DecimalLiteralContext decimalLiteralContext = context.decimalLiteral();
				if (decimalLiteralContext != null) 
				{
					return _factory.Literal((DecimalLiteralGreen)this.Visit(decimalLiteralContext));
				}
				MetaParser.ScientificLiteralContext scientificLiteralContext = context.scientificLiteral();
				if (scientificLiteralContext != null) 
				{
					return _factory.Literal((ScientificLiteralGreen)this.Visit(scientificLiteralContext));
				}
				MetaParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				if (stringLiteralContext != null) 
				{
					return _factory.Literal((StringLiteralGreen)this.Visit(stringLiteralContext));
				}
				return LiteralGreen.__Missing;
			}
			
			public override GreenNode VisitNullLiteral(MetaParser.NullLiteralContext context)
			{
				if (context == null) return NullLiteralGreen.__Missing;
				InternalSyntaxToken kNull = (InternalSyntaxToken)this.VisitTerminal(context.KNull(), MetaSyntaxKind.KNull);
				return _factory.NullLiteral(kNull);
			}
			
			public override GreenNode VisitBooleanLiteral(MetaParser.BooleanLiteralContext context)
			{
				if (context == null) return BooleanLiteralGreen.__Missing;
				InternalSyntaxToken booleanLiteral = null;
				if (context.KTrue() != null)
				{
					booleanLiteral = (InternalSyntaxToken)this.VisitTerminal(context.KTrue());
				}
				else 	if (context.KFalse() != null)
				{
					booleanLiteral = (InternalSyntaxToken)this.VisitTerminal(context.KFalse());
				}
				else
				{
					booleanLiteral = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.BooleanLiteral(booleanLiteral);
			}
			
			public override GreenNode VisitIntegerLiteral(MetaParser.IntegerLiteralContext context)
			{
				if (context == null) return IntegerLiteralGreen.__Missing;
				InternalSyntaxToken lInteger = (InternalSyntaxToken)this.VisitTerminal(context.LInteger(), MetaSyntaxKind.LInteger);
				return _factory.IntegerLiteral(lInteger);
			}
			
			public override GreenNode VisitDecimalLiteral(MetaParser.DecimalLiteralContext context)
			{
				if (context == null) return DecimalLiteralGreen.__Missing;
				InternalSyntaxToken lDecimal = (InternalSyntaxToken)this.VisitTerminal(context.LDecimal(), MetaSyntaxKind.LDecimal);
				return _factory.DecimalLiteral(lDecimal);
			}
			
			public override GreenNode VisitScientificLiteral(MetaParser.ScientificLiteralContext context)
			{
				if (context == null) return ScientificLiteralGreen.__Missing;
				InternalSyntaxToken lScientific = (InternalSyntaxToken)this.VisitTerminal(context.LScientific(), MetaSyntaxKind.LScientific);
				return _factory.ScientificLiteral(lScientific);
			}
			
			public override GreenNode VisitStringLiteral(MetaParser.StringLiteralContext context)
			{
				if (context == null) return StringLiteralGreen.__Missing;
				InternalSyntaxToken lRegularString = (InternalSyntaxToken)this.VisitTerminal(context.LRegularString(), MetaSyntaxKind.LRegularString);
				return _factory.StringLiteral(lRegularString);
			}
        }
    }
    public partial class MetaParser
    {
		
		internal class MainContext_Cached : MainContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public MainContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NameContext_Cached : NameContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NameContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QualifiedNameContext_Cached : QualifiedNameContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QualifiedNameContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class QualifierContext_Cached : QualifierContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public QualifierContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class AttributeContext_Cached : AttributeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public AttributeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class UsingNamespaceOrMetamodelContext_Cached : UsingNamespaceOrMetamodelContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public UsingNamespaceOrMetamodelContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class UsingNamespaceContext_Cached : UsingNamespaceContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public UsingNamespaceContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class UsingMetamodelContext_Cached : UsingMetamodelContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public UsingMetamodelContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class UsingMetamodelReferenceContext_Cached : UsingMetamodelReferenceContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public UsingMetamodelReferenceContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceDeclarationContext_Cached : NamespaceDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceBodyContext_Cached : NamespaceBodyContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceBodyContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class MetamodelDeclarationContext_Cached : MetamodelDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public MetamodelDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class MetamodelPropertyListContext_Cached : MetamodelPropertyListContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public MetamodelPropertyListContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class MetamodelPropertyContext_Cached : MetamodelPropertyContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public MetamodelPropertyContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class MetamodelUriPropertyContext_Cached : MetamodelUriPropertyContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public MetamodelUriPropertyContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class MetamodelPrefixPropertyContext_Cached : MetamodelPrefixPropertyContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public MetamodelPrefixPropertyContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class MetamodelVersionPropertyContext_Cached : MetamodelVersionPropertyContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public MetamodelVersionPropertyContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class DeclarationContext_Cached : DeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public DeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class EnumDeclarationContext_Cached : EnumDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public EnumDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class EnumBodyContext_Cached : EnumBodyContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public EnumBodyContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class EnumValuesContext_Cached : EnumValuesContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public EnumValuesContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class EnumValueContext_Cached : EnumValueContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public EnumValueContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class EnumMemberDeclarationContext_Cached : EnumMemberDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public EnumMemberDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ClassDeclarationContext_Cached : ClassDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ClassDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SymbolAttributeContext_Cached : SymbolAttributeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SymbolAttributeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SymbolSymbolAttributeContext_Cached : SymbolSymbolAttributeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SymbolSymbolAttributeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ExpressionSymbolAttributeContext_Cached : ExpressionSymbolAttributeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ExpressionSymbolAttributeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class StatementSymbolTypeAttributeContext_Cached : StatementSymbolTypeAttributeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public StatementSymbolTypeAttributeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TypeSymbolTypeAttributeContext_Cached : TypeSymbolTypeAttributeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TypeSymbolTypeAttributeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ClassBodyContext_Cached : ClassBodyContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ClassBodyContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ClassAncestorsContext_Cached : ClassAncestorsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ClassAncestorsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ClassAncestorContext_Cached : ClassAncestorContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ClassAncestorContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ClassMemberDeclarationContext_Cached : ClassMemberDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ClassMemberDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class FieldDeclarationContext_Cached : FieldDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public FieldDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class FieldSymbolPropertyAttributeContext_Cached : FieldSymbolPropertyAttributeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public FieldSymbolPropertyAttributeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class FieldContainmentContext_Cached : FieldContainmentContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public FieldContainmentContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class FieldModifierContext_Cached : FieldModifierContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public FieldModifierContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class DefaultValueContext_Cached : DefaultValueContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public DefaultValueContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class RedefinitionsOrSubsettingsContext_Cached : RedefinitionsOrSubsettingsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public RedefinitionsOrSubsettingsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class RedefinitionsContext_Cached : RedefinitionsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public RedefinitionsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SubsettingsContext_Cached : SubsettingsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SubsettingsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NameUseListContext_Cached : NameUseListContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NameUseListContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ConstDeclarationContext_Cached : ConstDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ConstDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ConstValueContext_Cached : ConstValueContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ConstValueContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ReturnTypeContext_Cached : ReturnTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ReturnTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TypeOfReferenceContext_Cached : TypeOfReferenceContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TypeOfReferenceContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TypeReferenceContext_Cached : TypeReferenceContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TypeReferenceContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class SimpleTypeContext_Cached : SimpleTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public SimpleTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ClassTypeContext_Cached : ClassTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ClassTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ObjectTypeContext_Cached : ObjectTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ObjectTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class PrimitiveTypeContext_Cached : PrimitiveTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public PrimitiveTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class VoidTypeContext_Cached : VoidTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public VoidTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NullableTypeContext_Cached : NullableTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NullableTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class CollectionTypeContext_Cached : CollectionTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public CollectionTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class CollectionKindContext_Cached : CollectionKindContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public CollectionKindContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class OperationDeclarationContext_Cached : OperationDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public OperationDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class OperationModifierContext_Cached : OperationModifierContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public OperationModifierContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class OperationModifierBuilderContext_Cached : OperationModifierBuilderContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public OperationModifierBuilderContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class OperationModifierReadonlyContext_Cached : OperationModifierReadonlyContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public OperationModifierReadonlyContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParameterListContext_Cached : ParameterListContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParameterListContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ParameterContext_Cached : ParameterContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ParameterContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class AssociationDeclarationContext_Cached : AssociationDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public AssociationDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class IdentifierContext_Cached : IdentifierContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public IdentifierContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class LiteralContext_Cached : LiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public LiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NullLiteralContext_Cached : NullLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NullLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class BooleanLiteralContext_Cached : BooleanLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public BooleanLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class IntegerLiteralContext_Cached : IntegerLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public IntegerLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class DecimalLiteralContext_Cached : DecimalLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public DecimalLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class ScientificLiteralContext_Cached : ScientificLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ScientificLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class StringLiteralContext_Cached : StringLiteralContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public StringLiteralContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
    }
}

