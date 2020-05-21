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
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.InternalSyntax
{
    public class TestIncrementalCompilationSyntaxParser : Antlr4SyntaxParser
    {
        private readonly Antlr4ToRoslynVisitor _visitor;
        public TestIncrementalCompilationSyntaxParser(
            SourceText text,
            TestIncrementalCompilationParseOptions options,
            TestIncrementalCompilationSyntaxNode oldTree, 
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default)
            : base(TestIncrementalCompilationLanguage.Instance, text, options, oldTree, changes, cancellationToken)
        {
            _visitor = new Antlr4ToRoslynVisitor(this);
        }
        protected TestIncrementalCompilationParser Antlr4Parser => (TestIncrementalCompilationParser)this.Parser;
		public override LanguageSyntaxNode Parse()
		{
			BeginRoot();
            ParserState state = null;
			var green = this.ParseMain(ref state);
			EndRoot(ref green);
			var red = (TestIncrementalCompilationSyntaxNode)green.CreateRed();
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
		
		internal TestIncrementalCompilationParser.MainContext _Antlr4ParseMain()
		{
			BeginNode();
		    TestIncrementalCompilationParser.MainContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseMain(CurrentNode as MainSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.MainContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseMain();
		            ((ITokenStream)this).Consume(); // Consume EOF, since ANTLR4 does not do that.
					green = _visitor.Visit(context);
				}
		    }
		    finally
		    {
		        EndNode(ref green);
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
		
		internal TestIncrementalCompilationParser.NameContext _Antlr4ParseName()
		{
			BeginNode();
		    TestIncrementalCompilationParser.NameContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseName(CurrentNode as NameSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.NameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.QualifiedNameContext _Antlr4ParseQualifiedName()
		{
			BeginNode();
		    TestIncrementalCompilationParser.QualifiedNameContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQualifiedName(CurrentNode as QualifiedNameSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.QualifiedNameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.QualifierContext _Antlr4ParseQualifier()
		{
			BeginNode();
		    TestIncrementalCompilationParser.QualifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQualifier(CurrentNode as QualifierSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.QualifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.AttributeContext _Antlr4ParseAttribute()
		{
			BeginNode();
		    TestIncrementalCompilationParser.AttributeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseAttribute(CurrentNode as AttributeSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.AttributeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.NamespaceDeclarationContext _Antlr4ParseNamespaceDeclaration()
		{
			BeginNode();
		    TestIncrementalCompilationParser.NamespaceDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceDeclaration(CurrentNode as NamespaceDeclarationSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.NamespaceDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.NamespaceBodyContext _Antlr4ParseNamespaceBody()
		{
			BeginNode();
		    TestIncrementalCompilationParser.NamespaceBodyContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceBody(CurrentNode as NamespaceBodySyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.NamespaceBodyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.MetamodelDeclarationContext _Antlr4ParseMetamodelDeclaration()
		{
			BeginNode();
		    TestIncrementalCompilationParser.MetamodelDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseMetamodelDeclaration(CurrentNode as MetamodelDeclarationSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.MetamodelDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.MetamodelPropertyListContext _Antlr4ParseMetamodelPropertyList()
		{
			BeginNode();
		    TestIncrementalCompilationParser.MetamodelPropertyListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseMetamodelPropertyList(CurrentNode as MetamodelPropertyListSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.MetamodelPropertyListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.MetamodelPropertyContext _Antlr4ParseMetamodelProperty()
		{
			BeginNode();
		    TestIncrementalCompilationParser.MetamodelPropertyContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseMetamodelProperty(CurrentNode as MetamodelPropertySyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.MetamodelPropertyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.MetamodelUriPropertyContext _Antlr4ParseMetamodelUriProperty()
		{
			BeginNode();
		    TestIncrementalCompilationParser.MetamodelUriPropertyContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseMetamodelUriProperty(CurrentNode as MetamodelUriPropertySyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.MetamodelUriPropertyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.MetamodelPrefixPropertyContext _Antlr4ParseMetamodelPrefixProperty()
		{
			BeginNode();
		    TestIncrementalCompilationParser.MetamodelPrefixPropertyContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseMetamodelPrefixProperty(CurrentNode as MetamodelPrefixPropertySyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.MetamodelPrefixPropertyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.DeclarationContext _Antlr4ParseDeclaration()
		{
			BeginNode();
		    TestIncrementalCompilationParser.DeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDeclaration(CurrentNode as DeclarationSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.DeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.EnumDeclarationContext _Antlr4ParseEnumDeclaration()
		{
			BeginNode();
		    TestIncrementalCompilationParser.EnumDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseEnumDeclaration(CurrentNode as EnumDeclarationSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.EnumDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.EnumBodyContext _Antlr4ParseEnumBody()
		{
			BeginNode();
		    TestIncrementalCompilationParser.EnumBodyContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseEnumBody(CurrentNode as EnumBodySyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.EnumBodyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.EnumValuesContext _Antlr4ParseEnumValues()
		{
			BeginNode();
		    TestIncrementalCompilationParser.EnumValuesContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseEnumValues(CurrentNode as EnumValuesSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.EnumValuesContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.EnumValueContext _Antlr4ParseEnumValue()
		{
			BeginNode();
		    TestIncrementalCompilationParser.EnumValueContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseEnumValue(CurrentNode as EnumValueSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.EnumValueContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.EnumMemberDeclarationContext _Antlr4ParseEnumMemberDeclaration()
		{
			BeginNode();
		    TestIncrementalCompilationParser.EnumMemberDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseEnumMemberDeclaration(CurrentNode as EnumMemberDeclarationSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.EnumMemberDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.ClassDeclarationContext _Antlr4ParseClassDeclaration()
		{
			BeginNode();
		    TestIncrementalCompilationParser.ClassDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseClassDeclaration(CurrentNode as ClassDeclarationSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.ClassDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.ClassBodyContext _Antlr4ParseClassBody()
		{
			BeginNode();
		    TestIncrementalCompilationParser.ClassBodyContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseClassBody(CurrentNode as ClassBodySyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.ClassBodyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.ClassAncestorsContext _Antlr4ParseClassAncestors()
		{
			BeginNode();
		    TestIncrementalCompilationParser.ClassAncestorsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseClassAncestors(CurrentNode as ClassAncestorsSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.ClassAncestorsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.ClassAncestorContext _Antlr4ParseClassAncestor()
		{
			BeginNode();
		    TestIncrementalCompilationParser.ClassAncestorContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseClassAncestor(CurrentNode as ClassAncestorSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.ClassAncestorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.ClassMemberDeclarationContext _Antlr4ParseClassMemberDeclaration()
		{
			BeginNode();
		    TestIncrementalCompilationParser.ClassMemberDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseClassMemberDeclaration(CurrentNode as ClassMemberDeclarationSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.ClassMemberDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.FieldDeclarationContext _Antlr4ParseFieldDeclaration()
		{
			BeginNode();
		    TestIncrementalCompilationParser.FieldDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseFieldDeclaration(CurrentNode as FieldDeclarationSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.FieldDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.FieldContainmentContext _Antlr4ParseFieldContainment()
		{
			BeginNode();
		    TestIncrementalCompilationParser.FieldContainmentContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseFieldContainment(CurrentNode as FieldContainmentSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.FieldContainmentContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.FieldModifierContext _Antlr4ParseFieldModifier()
		{
			BeginNode();
		    TestIncrementalCompilationParser.FieldModifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseFieldModifier(CurrentNode as FieldModifierSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.FieldModifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.DefaultValueContext _Antlr4ParseDefaultValue()
		{
			BeginNode();
		    TestIncrementalCompilationParser.DefaultValueContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDefaultValue(CurrentNode as DefaultValueSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.DefaultValueContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.RedefinitionsOrSubsettingsContext _Antlr4ParseRedefinitionsOrSubsettings()
		{
			BeginNode();
		    TestIncrementalCompilationParser.RedefinitionsOrSubsettingsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseRedefinitionsOrSubsettings(CurrentNode as RedefinitionsOrSubsettingsSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.RedefinitionsOrSubsettingsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.RedefinitionsContext _Antlr4ParseRedefinitions()
		{
			BeginNode();
		    TestIncrementalCompilationParser.RedefinitionsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseRedefinitions(CurrentNode as RedefinitionsSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.RedefinitionsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.SubsettingsContext _Antlr4ParseSubsettings()
		{
			BeginNode();
		    TestIncrementalCompilationParser.SubsettingsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSubsettings(CurrentNode as SubsettingsSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.SubsettingsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.NameUseListContext _Antlr4ParseNameUseList()
		{
			BeginNode();
		    TestIncrementalCompilationParser.NameUseListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNameUseList(CurrentNode as NameUseListSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.NameUseListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.ConstDeclarationContext _Antlr4ParseConstDeclaration()
		{
			BeginNode();
		    TestIncrementalCompilationParser.ConstDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseConstDeclaration(CurrentNode as ConstDeclarationSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.ConstDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.ConstValueContext _Antlr4ParseConstValue()
		{
			BeginNode();
		    TestIncrementalCompilationParser.ConstValueContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseConstValue(CurrentNode as ConstValueSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.ConstValueContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.ReturnTypeContext _Antlr4ParseReturnType()
		{
			BeginNode();
		    TestIncrementalCompilationParser.ReturnTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseReturnType(CurrentNode as ReturnTypeSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.ReturnTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.TypeOfReferenceContext _Antlr4ParseTypeOfReference()
		{
			BeginNode();
		    TestIncrementalCompilationParser.TypeOfReferenceContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTypeOfReference(CurrentNode as TypeOfReferenceSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.TypeOfReferenceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.TypeReferenceContext _Antlr4ParseTypeReference()
		{
			BeginNode();
		    TestIncrementalCompilationParser.TypeReferenceContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTypeReference(CurrentNode as TypeReferenceSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.TypeReferenceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.SimpleTypeContext _Antlr4ParseSimpleType()
		{
			BeginNode();
		    TestIncrementalCompilationParser.SimpleTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSimpleType(CurrentNode as SimpleTypeSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.SimpleTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.ClassTypeContext _Antlr4ParseClassType()
		{
			BeginNode();
		    TestIncrementalCompilationParser.ClassTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseClassType(CurrentNode as ClassTypeSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.ClassTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.ObjectTypeContext _Antlr4ParseObjectType()
		{
			BeginNode();
		    TestIncrementalCompilationParser.ObjectTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseObjectType(CurrentNode as ObjectTypeSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.ObjectTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.PrimitiveTypeContext _Antlr4ParsePrimitiveType()
		{
			BeginNode();
		    TestIncrementalCompilationParser.PrimitiveTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReusePrimitiveType(CurrentNode as PrimitiveTypeSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.PrimitiveTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.VoidTypeContext _Antlr4ParseVoidType()
		{
			BeginNode();
		    TestIncrementalCompilationParser.VoidTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVoidType(CurrentNode as VoidTypeSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.VoidTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.NullableTypeContext _Antlr4ParseNullableType()
		{
			BeginNode();
		    TestIncrementalCompilationParser.NullableTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNullableType(CurrentNode as NullableTypeSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.NullableTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.CollectionTypeContext _Antlr4ParseCollectionType()
		{
			BeginNode();
		    TestIncrementalCompilationParser.CollectionTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseCollectionType(CurrentNode as CollectionTypeSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.CollectionTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.CollectionKindContext _Antlr4ParseCollectionKind()
		{
			BeginNode();
		    TestIncrementalCompilationParser.CollectionKindContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseCollectionKind(CurrentNode as CollectionKindSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.CollectionKindContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.OperationDeclarationContext _Antlr4ParseOperationDeclaration()
		{
			BeginNode();
		    TestIncrementalCompilationParser.OperationDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseOperationDeclaration(CurrentNode as OperationDeclarationSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.OperationDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.OperationModifierContext _Antlr4ParseOperationModifier()
		{
			BeginNode();
		    TestIncrementalCompilationParser.OperationModifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseOperationModifier(CurrentNode as OperationModifierSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.OperationModifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.OperationModifierBuilderContext _Antlr4ParseOperationModifierBuilder()
		{
			BeginNode();
		    TestIncrementalCompilationParser.OperationModifierBuilderContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseOperationModifierBuilder(CurrentNode as OperationModifierBuilderSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.OperationModifierBuilderContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.OperationModifierReadonlyContext _Antlr4ParseOperationModifierReadonly()
		{
			BeginNode();
		    TestIncrementalCompilationParser.OperationModifierReadonlyContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseOperationModifierReadonly(CurrentNode as OperationModifierReadonlySyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.OperationModifierReadonlyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.ParameterListContext _Antlr4ParseParameterList()
		{
			BeginNode();
		    TestIncrementalCompilationParser.ParameterListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseParameterList(CurrentNode as ParameterListSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.ParameterListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.ParameterContext _Antlr4ParseParameter()
		{
			BeginNode();
		    TestIncrementalCompilationParser.ParameterContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseParameter(CurrentNode as ParameterSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.ParameterContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.AssociationDeclarationContext _Antlr4ParseAssociationDeclaration()
		{
			BeginNode();
		    TestIncrementalCompilationParser.AssociationDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseAssociationDeclaration(CurrentNode as AssociationDeclarationSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.AssociationDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.IdentifierContext _Antlr4ParseIdentifier()
		{
			BeginNode();
		    TestIncrementalCompilationParser.IdentifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIdentifier(CurrentNode as IdentifierSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.IdentifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.LiteralContext _Antlr4ParseLiteral()
		{
			BeginNode();
		    TestIncrementalCompilationParser.LiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseLiteral(CurrentNode as LiteralSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.LiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.NullLiteralContext _Antlr4ParseNullLiteral()
		{
			BeginNode();
		    TestIncrementalCompilationParser.NullLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNullLiteral(CurrentNode as NullLiteralSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.NullLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.BooleanLiteralContext _Antlr4ParseBooleanLiteral()
		{
			BeginNode();
		    TestIncrementalCompilationParser.BooleanLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseBooleanLiteral(CurrentNode as BooleanLiteralSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.BooleanLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.IntegerLiteralContext _Antlr4ParseIntegerLiteral()
		{
			BeginNode();
		    TestIncrementalCompilationParser.IntegerLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIntegerLiteral(CurrentNode as IntegerLiteralSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.IntegerLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.DecimalLiteralContext _Antlr4ParseDecimalLiteral()
		{
			BeginNode();
		    TestIncrementalCompilationParser.DecimalLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDecimalLiteral(CurrentNode as DecimalLiteralSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.DecimalLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.ScientificLiteralContext _Antlr4ParseScientificLiteral()
		{
			BeginNode();
		    TestIncrementalCompilationParser.ScientificLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseScientificLiteral(CurrentNode as ScientificLiteralSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.ScientificLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		
		internal TestIncrementalCompilationParser.StringLiteralContext _Antlr4ParseStringLiteral()
		{
			BeginNode();
		    TestIncrementalCompilationParser.StringLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseStringLiteral(CurrentNode as StringLiteralSyntax))
				{
					green = EatNode();
					context = new TestIncrementalCompilationParser.StringLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
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
		        CacheGreenNode(context, green);
		    }
		    return context;
		}
		
        private class Antlr4ToRoslynVisitor : TestIncrementalCompilationParserBaseVisitor<GreenNode>
        {
			// list pools - allocators for lists that are used to build sequences of nodes. The lists
			// can be reused (hence pooled) since the syntax factory methods don't keep references to
			// them
			private readonly SyntaxListPool _pool = new SyntaxListPool(); // Don't need to reset this.
			private readonly TestIncrementalCompilationInternalSyntaxFactory _factory;
            private readonly TestIncrementalCompilationSyntaxParser _syntaxParser;
            public Antlr4ToRoslynVisitor(TestIncrementalCompilationSyntaxParser syntaxParser)
            {
				_factory = (TestIncrementalCompilationInternalSyntaxFactory)syntaxParser.Language.InternalSyntaxFactory;
                _syntaxParser = syntaxParser;
            }
            private GreenNode VisitTerminal(IToken token, TestIncrementalCompilationSyntaxKind kind)
            {
				if (token == null || (token.Type == TokenConstants.Eof && kind != SyntaxKind.Eof))
				{
					if (kind != null) return _factory.MissingToken(kind);
					else return null;
				}
                var green = ((IncrementalToken)token).GreenToken;
				Debug.Assert(kind == null || green.Kind == kind);
				return green;
            }
            public GreenNode VisitTerminal(IToken token)
            {
				return VisitTerminal(token, null);
            }
            private GreenNode VisitTerminal(ITerminalNode node, TestIncrementalCompilationSyntaxKind kind)
            {
                if (node == null || node.Symbol == null || (node.Symbol.Type == TokenConstants.Eof && kind != SyntaxKind.Eof))
				{
					if (kind != null) return _factory.MissingToken(kind);
					else return null;
				}
				var green = ((IncrementalToken)node.Symbol).GreenToken;
				Debug.Assert(kind == null || green?.Kind == kind);
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
			
			public override GreenNode VisitMain(TestIncrementalCompilationParser.MainContext context)
			{
				if (context == null) return MainGreen.__Missing;
				TestIncrementalCompilationParser.NamespaceDeclarationContext namespaceDeclarationContext = context.namespaceDeclaration();
				NamespaceDeclarationGreen namespaceDeclaration = null;
				if (namespaceDeclarationContext != null) namespaceDeclaration = (NamespaceDeclarationGreen)this.Visit(namespaceDeclarationContext);
				if (namespaceDeclaration == null) namespaceDeclaration = NamespaceDeclarationGreen.__Missing;
				InternalSyntaxToken eOF = (InternalSyntaxToken)this.VisitTerminal(context.Eof(), TestIncrementalCompilationSyntaxKind.Eof);
				return _factory.Main(namespaceDeclaration, eOF);
			}
			
			public override GreenNode VisitName(TestIncrementalCompilationParser.NameContext context)
			{
				if (context == null) return NameGreen.__Missing;
				TestIncrementalCompilationParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				return _factory.Name(identifier);
			}
			
			public override GreenNode VisitQualifiedName(TestIncrementalCompilationParser.QualifiedNameContext context)
			{
				if (context == null) return QualifiedNameGreen.__Missing;
				TestIncrementalCompilationParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.QualifiedName(qualifier);
			}
			
			public override GreenNode VisitQualifier(TestIncrementalCompilationParser.QualifierContext context)
			{
				if (context == null) return QualifierGreen.__Missing;
			    TestIncrementalCompilationParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tDotContext = context.TDot();
			    var identifierBuilder = _pool.AllocateSeparated<IdentifierGreen>();
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tDotContext.Length)
			        {
			            identifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tDotContext[i], TestIncrementalCompilationSyntaxKind.TDot));
			        }
			    }
				var identifier = identifierBuilder.ToList();
				_pool.Free(identifierBuilder);
				return _factory.Qualifier(identifier);
			}
			
			public override GreenNode VisitAttribute(TestIncrementalCompilationParser.AttributeContext context)
			{
				if (context == null) return AttributeGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), TestIncrementalCompilationSyntaxKind.TOpenBracket);
				TestIncrementalCompilationParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), TestIncrementalCompilationSyntaxKind.TCloseBracket);
				return _factory.Attribute(tOpenBracket, qualifier, tCloseBracket);
			}
			
			public override GreenNode VisitNamespaceDeclaration(TestIncrementalCompilationParser.NamespaceDeclarationContext context)
			{
				if (context == null) return NamespaceDeclarationGreen.__Missing;
			    TestIncrementalCompilationParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestIncrementalCompilationSyntaxKind.KNamespace);
				TestIncrementalCompilationParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null) qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				if (qualifiedName == null) qualifiedName = QualifiedNameGreen.__Missing;
				TestIncrementalCompilationParser.NamespaceBodyContext namespaceBodyContext = context.namespaceBody();
				NamespaceBodyGreen namespaceBody = null;
				if (namespaceBodyContext != null) namespaceBody = (NamespaceBodyGreen)this.Visit(namespaceBodyContext);
				if (namespaceBody == null) namespaceBody = NamespaceBodyGreen.__Missing;
				return _factory.NamespaceDeclaration(attribute, kNamespace, qualifiedName, namespaceBody);
			}
			
			public override GreenNode VisitNamespaceBody(TestIncrementalCompilationParser.NamespaceBodyContext context)
			{
				if (context == null) return NamespaceBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestIncrementalCompilationSyntaxKind.TOpenBrace);
				TestIncrementalCompilationParser.MetamodelDeclarationContext metamodelDeclarationContext = context.metamodelDeclaration();
				MetamodelDeclarationGreen metamodelDeclaration = null;
				if (metamodelDeclarationContext != null) metamodelDeclaration = (MetamodelDeclarationGreen)this.Visit(metamodelDeclarationContext);
				if (metamodelDeclaration == null) metamodelDeclaration = MetamodelDeclarationGreen.__Missing;
			    TestIncrementalCompilationParser.DeclarationContext[] declarationContext = context.declaration();
			    var declarationBuilder = _pool.Allocate<DeclarationGreen>();
			    for (int i = 0; i < declarationContext.Length; i++)
			    {
			        declarationBuilder.Add((DeclarationGreen)this.Visit(declarationContext[i]));
			    }
				var declaration = declarationBuilder.ToList();
				_pool.Free(declarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestIncrementalCompilationSyntaxKind.TCloseBrace);
				return _factory.NamespaceBody(tOpenBrace, metamodelDeclaration, declaration, tCloseBrace);
			}
			
			public override GreenNode VisitMetamodelDeclaration(TestIncrementalCompilationParser.MetamodelDeclarationContext context)
			{
				if (context == null) return MetamodelDeclarationGreen.__Missing;
			    TestIncrementalCompilationParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kMetamodel = (InternalSyntaxToken)this.VisitTerminal(context.KMetamodel(), TestIncrementalCompilationSyntaxKind.KMetamodel);
				TestIncrementalCompilationParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen());
				TestIncrementalCompilationParser.MetamodelPropertyListContext metamodelPropertyListContext = context.metamodelPropertyList();
				MetamodelPropertyListGreen metamodelPropertyList = null;
				if (metamodelPropertyListContext != null) metamodelPropertyList = (MetamodelPropertyListGreen)this.Visit(metamodelPropertyListContext);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen());
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestIncrementalCompilationSyntaxKind.TSemicolon);
				return _factory.MetamodelDeclaration(attribute, kMetamodel, name, tOpenParen, metamodelPropertyList, tCloseParen, tSemicolon);
			}
			
			public override GreenNode VisitMetamodelPropertyList(TestIncrementalCompilationParser.MetamodelPropertyListContext context)
			{
				if (context == null) return MetamodelPropertyListGreen.__Missing;
			    TestIncrementalCompilationParser.MetamodelPropertyContext[] metamodelPropertyContext = context.metamodelProperty();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var metamodelPropertyBuilder = _pool.AllocateSeparated<MetamodelPropertyGreen>();
			    for (int i = 0; i < metamodelPropertyContext.Length; i++)
			    {
			        metamodelPropertyBuilder.Add((MetamodelPropertyGreen)this.Visit(metamodelPropertyContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            metamodelPropertyBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], TestIncrementalCompilationSyntaxKind.TComma));
			        }
			    }
				var metamodelProperty = metamodelPropertyBuilder.ToList();
				_pool.Free(metamodelPropertyBuilder);
				return _factory.MetamodelPropertyList(metamodelProperty);
			}
			
			public override GreenNode VisitMetamodelProperty(TestIncrementalCompilationParser.MetamodelPropertyContext context)
			{
				if (context == null) return MetamodelPropertyGreen.__Missing;
				TestIncrementalCompilationParser.MetamodelUriPropertyContext metamodelUriPropertyContext = context.metamodelUriProperty();
				if (metamodelUriPropertyContext != null) 
				{
					return _factory.MetamodelProperty((MetamodelUriPropertyGreen)this.Visit(metamodelUriPropertyContext));
				}
				TestIncrementalCompilationParser.MetamodelPrefixPropertyContext metamodelPrefixPropertyContext = context.metamodelPrefixProperty();
				if (metamodelPrefixPropertyContext != null) 
				{
					return _factory.MetamodelProperty((MetamodelPrefixPropertyGreen)this.Visit(metamodelPrefixPropertyContext));
				}
				return MetamodelPropertyGreen.__Missing;
			}
			
			public override GreenNode VisitMetamodelUriProperty(TestIncrementalCompilationParser.MetamodelUriPropertyContext context)
			{
				if (context == null) return MetamodelUriPropertyGreen.__Missing;
				InternalSyntaxToken iUri = (InternalSyntaxToken)this.VisitTerminal(context.IUri(), TestIncrementalCompilationSyntaxKind.IUri);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), TestIncrementalCompilationSyntaxKind.TAssign);
				TestIncrementalCompilationParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null) stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				if (stringLiteral == null) stringLiteral = StringLiteralGreen.__Missing;
				return _factory.MetamodelUriProperty(iUri, tAssign, stringLiteral);
			}
			
			public override GreenNode VisitMetamodelPrefixProperty(TestIncrementalCompilationParser.MetamodelPrefixPropertyContext context)
			{
				if (context == null) return MetamodelPrefixPropertyGreen.__Missing;
				InternalSyntaxToken iPrefix = (InternalSyntaxToken)this.VisitTerminal(context.IPrefix(), TestIncrementalCompilationSyntaxKind.IPrefix);
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), TestIncrementalCompilationSyntaxKind.TAssign);
				TestIncrementalCompilationParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null) stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				if (stringLiteral == null) stringLiteral = StringLiteralGreen.__Missing;
				return _factory.MetamodelPrefixProperty(iPrefix, tAssign, stringLiteral);
			}
			
			public override GreenNode VisitDeclaration(TestIncrementalCompilationParser.DeclarationContext context)
			{
				if (context == null) return DeclarationGreen.__Missing;
				TestIncrementalCompilationParser.EnumDeclarationContext enumDeclarationContext = context.enumDeclaration();
				if (enumDeclarationContext != null) 
				{
					return _factory.Declaration((EnumDeclarationGreen)this.Visit(enumDeclarationContext));
				}
				TestIncrementalCompilationParser.ClassDeclarationContext classDeclarationContext = context.classDeclaration();
				if (classDeclarationContext != null) 
				{
					return _factory.Declaration((ClassDeclarationGreen)this.Visit(classDeclarationContext));
				}
				TestIncrementalCompilationParser.AssociationDeclarationContext associationDeclarationContext = context.associationDeclaration();
				if (associationDeclarationContext != null) 
				{
					return _factory.Declaration((AssociationDeclarationGreen)this.Visit(associationDeclarationContext));
				}
				TestIncrementalCompilationParser.ConstDeclarationContext constDeclarationContext = context.constDeclaration();
				if (constDeclarationContext != null) 
				{
					return _factory.Declaration((ConstDeclarationGreen)this.Visit(constDeclarationContext));
				}
				return DeclarationGreen.__Missing;
			}
			
			public override GreenNode VisitEnumDeclaration(TestIncrementalCompilationParser.EnumDeclarationContext context)
			{
				if (context == null) return EnumDeclarationGreen.__Missing;
			    TestIncrementalCompilationParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kEnum = (InternalSyntaxToken)this.VisitTerminal(context.KEnum(), TestIncrementalCompilationSyntaxKind.KEnum);
				TestIncrementalCompilationParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				TestIncrementalCompilationParser.EnumBodyContext enumBodyContext = context.enumBody();
				EnumBodyGreen enumBody = null;
				if (enumBodyContext != null) enumBody = (EnumBodyGreen)this.Visit(enumBodyContext);
				if (enumBody == null) enumBody = EnumBodyGreen.__Missing;
				return _factory.EnumDeclaration(attribute, kEnum, name, enumBody);
			}
			
			public override GreenNode VisitEnumBody(TestIncrementalCompilationParser.EnumBodyContext context)
			{
				if (context == null) return EnumBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestIncrementalCompilationSyntaxKind.TOpenBrace);
				TestIncrementalCompilationParser.EnumValuesContext enumValuesContext = context.enumValues();
				EnumValuesGreen enumValues = null;
				if (enumValuesContext != null) enumValues = (EnumValuesGreen)this.Visit(enumValuesContext);
				if (enumValues == null) enumValues = EnumValuesGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
			    TestIncrementalCompilationParser.EnumMemberDeclarationContext[] enumMemberDeclarationContext = context.enumMemberDeclaration();
			    var enumMemberDeclarationBuilder = _pool.Allocate<EnumMemberDeclarationGreen>();
			    for (int i = 0; i < enumMemberDeclarationContext.Length; i++)
			    {
			        enumMemberDeclarationBuilder.Add((EnumMemberDeclarationGreen)this.Visit(enumMemberDeclarationContext[i]));
			    }
				var enumMemberDeclaration = enumMemberDeclarationBuilder.ToList();
				_pool.Free(enumMemberDeclarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestIncrementalCompilationSyntaxKind.TCloseBrace);
				return _factory.EnumBody(tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration, tCloseBrace);
			}
			
			public override GreenNode VisitEnumValues(TestIncrementalCompilationParser.EnumValuesContext context)
			{
				if (context == null) return EnumValuesGreen.__Missing;
			    TestIncrementalCompilationParser.EnumValueContext[] enumValueContext = context.enumValue();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var enumValueBuilder = _pool.AllocateSeparated<EnumValueGreen>();
			    for (int i = 0; i < enumValueContext.Length; i++)
			    {
			        enumValueBuilder.Add((EnumValueGreen)this.Visit(enumValueContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            enumValueBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], TestIncrementalCompilationSyntaxKind.TComma));
			        }
			    }
				var enumValue = enumValueBuilder.ToList();
				_pool.Free(enumValueBuilder);
				return _factory.EnumValues(enumValue);
			}
			
			public override GreenNode VisitEnumValue(TestIncrementalCompilationParser.EnumValueContext context)
			{
				if (context == null) return EnumValueGreen.__Missing;
			    TestIncrementalCompilationParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				TestIncrementalCompilationParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				return _factory.EnumValue(attribute, name);
			}
			
			public override GreenNode VisitEnumMemberDeclaration(TestIncrementalCompilationParser.EnumMemberDeclarationContext context)
			{
				if (context == null) return EnumMemberDeclarationGreen.__Missing;
				TestIncrementalCompilationParser.OperationDeclarationContext operationDeclarationContext = context.operationDeclaration();
				OperationDeclarationGreen operationDeclaration = null;
				if (operationDeclarationContext != null) operationDeclaration = (OperationDeclarationGreen)this.Visit(operationDeclarationContext);
				if (operationDeclaration == null) operationDeclaration = OperationDeclarationGreen.__Missing;
				return _factory.EnumMemberDeclaration(operationDeclaration);
			}
			
			public override GreenNode VisitClassDeclaration(TestIncrementalCompilationParser.ClassDeclarationContext context)
			{
				if (context == null) return ClassDeclarationGreen.__Missing;
			    TestIncrementalCompilationParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kAbstract = (InternalSyntaxToken)this.VisitTerminal(context.KAbstract());
				InternalSyntaxToken kClass = (InternalSyntaxToken)this.VisitTerminal(context.KClass(), TestIncrementalCompilationSyntaxKind.KClass);
				TestIncrementalCompilationParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				TestIncrementalCompilationParser.ClassAncestorsContext classAncestorsContext = context.classAncestors();
				ClassAncestorsGreen classAncestors = null;
				if (classAncestorsContext != null) classAncestors = (ClassAncestorsGreen)this.Visit(classAncestorsContext);
				TestIncrementalCompilationParser.ClassBodyContext classBodyContext = context.classBody();
				ClassBodyGreen classBody = null;
				if (classBodyContext != null) classBody = (ClassBodyGreen)this.Visit(classBodyContext);
				if (classBody == null) classBody = ClassBodyGreen.__Missing;
				return _factory.ClassDeclaration(attribute, kAbstract, kClass, name, tColon, classAncestors, classBody);
			}
			
			public override GreenNode VisitClassBody(TestIncrementalCompilationParser.ClassBodyContext context)
			{
				if (context == null) return ClassBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestIncrementalCompilationSyntaxKind.TOpenBrace);
			    TestIncrementalCompilationParser.ClassMemberDeclarationContext[] classMemberDeclarationContext = context.classMemberDeclaration();
			    var classMemberDeclarationBuilder = _pool.Allocate<ClassMemberDeclarationGreen>();
			    for (int i = 0; i < classMemberDeclarationContext.Length; i++)
			    {
			        classMemberDeclarationBuilder.Add((ClassMemberDeclarationGreen)this.Visit(classMemberDeclarationContext[i]));
			    }
				var classMemberDeclaration = classMemberDeclarationBuilder.ToList();
				_pool.Free(classMemberDeclarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestIncrementalCompilationSyntaxKind.TCloseBrace);
				return _factory.ClassBody(tOpenBrace, classMemberDeclaration, tCloseBrace);
			}
			
			public override GreenNode VisitClassAncestors(TestIncrementalCompilationParser.ClassAncestorsContext context)
			{
				if (context == null) return ClassAncestorsGreen.__Missing;
			    TestIncrementalCompilationParser.ClassAncestorContext[] classAncestorContext = context.classAncestor();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var classAncestorBuilder = _pool.AllocateSeparated<ClassAncestorGreen>();
			    for (int i = 0; i < classAncestorContext.Length; i++)
			    {
			        classAncestorBuilder.Add((ClassAncestorGreen)this.Visit(classAncestorContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            classAncestorBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], TestIncrementalCompilationSyntaxKind.TComma));
			        }
			    }
				var classAncestor = classAncestorBuilder.ToList();
				_pool.Free(classAncestorBuilder);
				return _factory.ClassAncestors(classAncestor);
			}
			
			public override GreenNode VisitClassAncestor(TestIncrementalCompilationParser.ClassAncestorContext context)
			{
				if (context == null) return ClassAncestorGreen.__Missing;
				TestIncrementalCompilationParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.ClassAncestor(qualifier);
			}
			
			public override GreenNode VisitClassMemberDeclaration(TestIncrementalCompilationParser.ClassMemberDeclarationContext context)
			{
				if (context == null) return ClassMemberDeclarationGreen.__Missing;
				TestIncrementalCompilationParser.FieldDeclarationContext fieldDeclarationContext = context.fieldDeclaration();
				if (fieldDeclarationContext != null) 
				{
					return _factory.ClassMemberDeclaration((FieldDeclarationGreen)this.Visit(fieldDeclarationContext));
				}
				TestIncrementalCompilationParser.OperationDeclarationContext operationDeclarationContext = context.operationDeclaration();
				if (operationDeclarationContext != null) 
				{
					return _factory.ClassMemberDeclaration((OperationDeclarationGreen)this.Visit(operationDeclarationContext));
				}
				return ClassMemberDeclarationGreen.__Missing;
			}
			
			public override GreenNode VisitFieldDeclaration(TestIncrementalCompilationParser.FieldDeclarationContext context)
			{
				if (context == null) return FieldDeclarationGreen.__Missing;
			    TestIncrementalCompilationParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				TestIncrementalCompilationParser.FieldContainmentContext fieldContainmentContext = context.fieldContainment();
				FieldContainmentGreen fieldContainment = null;
				if (fieldContainmentContext != null) fieldContainment = (FieldContainmentGreen)this.Visit(fieldContainmentContext);
				TestIncrementalCompilationParser.FieldModifierContext fieldModifierContext = context.fieldModifier();
				FieldModifierGreen fieldModifier = null;
				if (fieldModifierContext != null) fieldModifier = (FieldModifierGreen)this.Visit(fieldModifierContext);
				TestIncrementalCompilationParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				TestIncrementalCompilationParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				TestIncrementalCompilationParser.DefaultValueContext defaultValueContext = context.defaultValue();
				DefaultValueGreen defaultValue = null;
				if (defaultValueContext != null) defaultValue = (DefaultValueGreen)this.Visit(defaultValueContext);
			    TestIncrementalCompilationParser.RedefinitionsOrSubsettingsContext[] redefinitionsOrSubsettingsContext = context.redefinitionsOrSubsettings();
			    var redefinitionsOrSubsettingsBuilder = _pool.Allocate<RedefinitionsOrSubsettingsGreen>();
			    for (int i = 0; i < redefinitionsOrSubsettingsContext.Length; i++)
			    {
			        redefinitionsOrSubsettingsBuilder.Add((RedefinitionsOrSubsettingsGreen)this.Visit(redefinitionsOrSubsettingsContext[i]));
			    }
				var redefinitionsOrSubsettings = redefinitionsOrSubsettingsBuilder.ToList();
				_pool.Free(redefinitionsOrSubsettingsBuilder);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestIncrementalCompilationSyntaxKind.TSemicolon);
				return _factory.FieldDeclaration(attribute, fieldContainment, fieldModifier, typeReference, name, defaultValue, redefinitionsOrSubsettings, tSemicolon);
			}
			
			public override GreenNode VisitFieldContainment(TestIncrementalCompilationParser.FieldContainmentContext context)
			{
				if (context == null) return FieldContainmentGreen.__Missing;
				InternalSyntaxToken kContainment = (InternalSyntaxToken)this.VisitTerminal(context.KContainment(), TestIncrementalCompilationSyntaxKind.KContainment);
				return _factory.FieldContainment(kContainment);
			}
			
			public override GreenNode VisitFieldModifier(TestIncrementalCompilationParser.FieldModifierContext context)
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
			
			public override GreenNode VisitDefaultValue(TestIncrementalCompilationParser.DefaultValueContext context)
			{
				if (context == null) return DefaultValueGreen.__Missing;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), TestIncrementalCompilationSyntaxKind.TAssign);
				TestIncrementalCompilationParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null) stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				if (stringLiteral == null) stringLiteral = StringLiteralGreen.__Missing;
				return _factory.DefaultValue(tAssign, stringLiteral);
			}
			
			public override GreenNode VisitRedefinitionsOrSubsettings(TestIncrementalCompilationParser.RedefinitionsOrSubsettingsContext context)
			{
				if (context == null) return RedefinitionsOrSubsettingsGreen.__Missing;
				TestIncrementalCompilationParser.RedefinitionsContext redefinitionsContext = context.redefinitions();
				if (redefinitionsContext != null) 
				{
					return _factory.RedefinitionsOrSubsettings((RedefinitionsGreen)this.Visit(redefinitionsContext));
				}
				TestIncrementalCompilationParser.SubsettingsContext subsettingsContext = context.subsettings();
				if (subsettingsContext != null) 
				{
					return _factory.RedefinitionsOrSubsettings((SubsettingsGreen)this.Visit(subsettingsContext));
				}
				return RedefinitionsOrSubsettingsGreen.__Missing;
			}
			
			public override GreenNode VisitRedefinitions(TestIncrementalCompilationParser.RedefinitionsContext context)
			{
				if (context == null) return RedefinitionsGreen.__Missing;
				InternalSyntaxToken kRedefines = (InternalSyntaxToken)this.VisitTerminal(context.KRedefines(), TestIncrementalCompilationSyntaxKind.KRedefines);
				TestIncrementalCompilationParser.NameUseListContext nameUseListContext = context.nameUseList();
				NameUseListGreen nameUseList = null;
				if (nameUseListContext != null) nameUseList = (NameUseListGreen)this.Visit(nameUseListContext);
				return _factory.Redefinitions(kRedefines, nameUseList);
			}
			
			public override GreenNode VisitSubsettings(TestIncrementalCompilationParser.SubsettingsContext context)
			{
				if (context == null) return SubsettingsGreen.__Missing;
				InternalSyntaxToken kSubsets = (InternalSyntaxToken)this.VisitTerminal(context.KSubsets(), TestIncrementalCompilationSyntaxKind.KSubsets);
				TestIncrementalCompilationParser.NameUseListContext nameUseListContext = context.nameUseList();
				NameUseListGreen nameUseList = null;
				if (nameUseListContext != null) nameUseList = (NameUseListGreen)this.Visit(nameUseListContext);
				return _factory.Subsettings(kSubsets, nameUseList);
			}
			
			public override GreenNode VisitNameUseList(TestIncrementalCompilationParser.NameUseListContext context)
			{
				if (context == null) return NameUseListGreen.__Missing;
			    TestIncrementalCompilationParser.QualifierContext[] qualifierContext = context.qualifier();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var qualifierBuilder = _pool.AllocateSeparated<QualifierGreen>();
			    for (int i = 0; i < qualifierContext.Length; i++)
			    {
			        qualifierBuilder.Add((QualifierGreen)this.Visit(qualifierContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            qualifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], TestIncrementalCompilationSyntaxKind.TComma));
			        }
			    }
				var qualifier = qualifierBuilder.ToList();
				_pool.Free(qualifierBuilder);
				return _factory.NameUseList(qualifier);
			}
			
			public override GreenNode VisitConstDeclaration(TestIncrementalCompilationParser.ConstDeclarationContext context)
			{
				if (context == null) return ConstDeclarationGreen.__Missing;
				InternalSyntaxToken kConst = (InternalSyntaxToken)this.VisitTerminal(context.KConst(), TestIncrementalCompilationSyntaxKind.KConst);
				TestIncrementalCompilationParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				TestIncrementalCompilationParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				TestIncrementalCompilationParser.ConstValueContext constValueContext = context.constValue();
				ConstValueGreen constValue = null;
				if (constValueContext != null) constValue = (ConstValueGreen)this.Visit(constValueContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestIncrementalCompilationSyntaxKind.TSemicolon);
				return _factory.ConstDeclaration(kConst, typeReference, name, constValue, tSemicolon);
			}
			
			public override GreenNode VisitConstValue(TestIncrementalCompilationParser.ConstValueContext context)
			{
				if (context == null) return ConstValueGreen.__Missing;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), TestIncrementalCompilationSyntaxKind.TAssign);
				TestIncrementalCompilationParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null) stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				if (stringLiteral == null) stringLiteral = StringLiteralGreen.__Missing;
				return _factory.ConstValue(tAssign, stringLiteral);
			}
			
			public override GreenNode VisitReturnType(TestIncrementalCompilationParser.ReturnTypeContext context)
			{
				if (context == null) return ReturnTypeGreen.__Missing;
				TestIncrementalCompilationParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				if (typeReferenceContext != null) 
				{
					return _factory.ReturnType((TypeReferenceGreen)this.Visit(typeReferenceContext));
				}
				TestIncrementalCompilationParser.VoidTypeContext voidTypeContext = context.voidType();
				if (voidTypeContext != null) 
				{
					return _factory.ReturnType((VoidTypeGreen)this.Visit(voidTypeContext));
				}
				return ReturnTypeGreen.__Missing;
			}
			
			public override GreenNode VisitTypeOfReference(TestIncrementalCompilationParser.TypeOfReferenceContext context)
			{
				if (context == null) return TypeOfReferenceGreen.__Missing;
				TestIncrementalCompilationParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				return _factory.TypeOfReference(typeReference);
			}
			
			public override GreenNode VisitTypeReference(TestIncrementalCompilationParser.TypeReferenceContext context)
			{
				if (context == null) return TypeReferenceGreen.__Missing;
				TestIncrementalCompilationParser.CollectionTypeContext collectionTypeContext = context.collectionType();
				if (collectionTypeContext != null) 
				{
					return _factory.TypeReference((CollectionTypeGreen)this.Visit(collectionTypeContext));
				}
				TestIncrementalCompilationParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				if (simpleTypeContext != null) 
				{
					return _factory.TypeReference((SimpleTypeGreen)this.Visit(simpleTypeContext));
				}
				return TypeReferenceGreen.__Missing;
			}
			
			public override GreenNode VisitSimpleType(TestIncrementalCompilationParser.SimpleTypeContext context)
			{
				if (context == null) return SimpleTypeGreen.__Missing;
				TestIncrementalCompilationParser.PrimitiveTypeContext primitiveTypeContext = context.primitiveType();
				if (primitiveTypeContext != null) 
				{
					return _factory.SimpleType((PrimitiveTypeGreen)this.Visit(primitiveTypeContext));
				}
				TestIncrementalCompilationParser.ObjectTypeContext objectTypeContext = context.objectType();
				if (objectTypeContext != null) 
				{
					return _factory.SimpleType((ObjectTypeGreen)this.Visit(objectTypeContext));
				}
				TestIncrementalCompilationParser.NullableTypeContext nullableTypeContext = context.nullableType();
				if (nullableTypeContext != null) 
				{
					return _factory.SimpleType((NullableTypeGreen)this.Visit(nullableTypeContext));
				}
				TestIncrementalCompilationParser.ClassTypeContext classTypeContext = context.classType();
				if (classTypeContext != null) 
				{
					return _factory.SimpleType((ClassTypeGreen)this.Visit(classTypeContext));
				}
				return SimpleTypeGreen.__Missing;
			}
			
			public override GreenNode VisitClassType(TestIncrementalCompilationParser.ClassTypeContext context)
			{
				if (context == null) return ClassTypeGreen.__Missing;
				TestIncrementalCompilationParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.ClassType(qualifier);
			}
			
			public override GreenNode VisitObjectType(TestIncrementalCompilationParser.ObjectTypeContext context)
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
			
			public override GreenNode VisitPrimitiveType(TestIncrementalCompilationParser.PrimitiveTypeContext context)
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
			
			public override GreenNode VisitVoidType(TestIncrementalCompilationParser.VoidTypeContext context)
			{
				if (context == null) return VoidTypeGreen.__Missing;
				InternalSyntaxToken kVoid = (InternalSyntaxToken)this.VisitTerminal(context.KVoid(), TestIncrementalCompilationSyntaxKind.KVoid);
				return _factory.VoidType(kVoid);
			}
			
			public override GreenNode VisitNullableType(TestIncrementalCompilationParser.NullableTypeContext context)
			{
				if (context == null) return NullableTypeGreen.__Missing;
				TestIncrementalCompilationParser.PrimitiveTypeContext primitiveTypeContext = context.primitiveType();
				PrimitiveTypeGreen primitiveType = null;
				if (primitiveTypeContext != null) primitiveType = (PrimitiveTypeGreen)this.Visit(primitiveTypeContext);
				if (primitiveType == null) primitiveType = PrimitiveTypeGreen.__Missing;
				InternalSyntaxToken tQuestion = (InternalSyntaxToken)this.VisitTerminal(context.TQuestion(), TestIncrementalCompilationSyntaxKind.TQuestion);
				return _factory.NullableType(primitiveType, tQuestion);
			}
			
			public override GreenNode VisitCollectionType(TestIncrementalCompilationParser.CollectionTypeContext context)
			{
				if (context == null) return CollectionTypeGreen.__Missing;
				TestIncrementalCompilationParser.CollectionKindContext collectionKindContext = context.collectionKind();
				CollectionKindGreen collectionKind = null;
				if (collectionKindContext != null) collectionKind = (CollectionKindGreen)this.Visit(collectionKindContext);
				if (collectionKind == null) collectionKind = CollectionKindGreen.__Missing;
				InternalSyntaxToken tLessThan = (InternalSyntaxToken)this.VisitTerminal(context.TLessThan(), TestIncrementalCompilationSyntaxKind.TLessThan);
				TestIncrementalCompilationParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				SimpleTypeGreen simpleType = null;
				if (simpleTypeContext != null) simpleType = (SimpleTypeGreen)this.Visit(simpleTypeContext);
				if (simpleType == null) simpleType = SimpleTypeGreen.__Missing;
				InternalSyntaxToken tGreaterThan = (InternalSyntaxToken)this.VisitTerminal(context.TGreaterThan(), TestIncrementalCompilationSyntaxKind.TGreaterThan);
				return _factory.CollectionType(collectionKind, tLessThan, simpleType, tGreaterThan);
			}
			
			public override GreenNode VisitCollectionKind(TestIncrementalCompilationParser.CollectionKindContext context)
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
			
			public override GreenNode VisitOperationDeclaration(TestIncrementalCompilationParser.OperationDeclarationContext context)
			{
				if (context == null) return OperationDeclarationGreen.__Missing;
			    TestIncrementalCompilationParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
			    TestIncrementalCompilationParser.OperationModifierContext[] operationModifierContext = context.operationModifier();
			    var operationModifierBuilder = _pool.Allocate<OperationModifierGreen>();
			    for (int i = 0; i < operationModifierContext.Length; i++)
			    {
			        operationModifierBuilder.Add((OperationModifierGreen)this.Visit(operationModifierContext[i]));
			    }
				var operationModifier = operationModifierBuilder.ToList();
				_pool.Free(operationModifierBuilder);
				TestIncrementalCompilationParser.ReturnTypeContext returnTypeContext = context.returnType();
				ReturnTypeGreen returnType = null;
				if (returnTypeContext != null) returnType = (ReturnTypeGreen)this.Visit(returnTypeContext);
				if (returnType == null) returnType = ReturnTypeGreen.__Missing;
				TestIncrementalCompilationParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), TestIncrementalCompilationSyntaxKind.TOpenParen);
				TestIncrementalCompilationParser.ParameterListContext parameterListContext = context.parameterList();
				ParameterListGreen parameterList = null;
				if (parameterListContext != null) parameterList = (ParameterListGreen)this.Visit(parameterListContext);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), TestIncrementalCompilationSyntaxKind.TCloseParen);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestIncrementalCompilationSyntaxKind.TSemicolon);
				return _factory.OperationDeclaration(attribute, operationModifier, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
			}
			
			public override GreenNode VisitOperationModifier(TestIncrementalCompilationParser.OperationModifierContext context)
			{
				if (context == null) return OperationModifierGreen.__Missing;
				TestIncrementalCompilationParser.OperationModifierBuilderContext operationModifierBuilderContext = context.operationModifierBuilder();
				if (operationModifierBuilderContext != null) 
				{
					return _factory.OperationModifier((OperationModifierBuilderGreen)this.Visit(operationModifierBuilderContext));
				}
				TestIncrementalCompilationParser.OperationModifierReadonlyContext operationModifierReadonlyContext = context.operationModifierReadonly();
				if (operationModifierReadonlyContext != null) 
				{
					return _factory.OperationModifier((OperationModifierReadonlyGreen)this.Visit(operationModifierReadonlyContext));
				}
				return OperationModifierGreen.__Missing;
			}
			
			public override GreenNode VisitOperationModifierBuilder(TestIncrementalCompilationParser.OperationModifierBuilderContext context)
			{
				if (context == null) return OperationModifierBuilderGreen.__Missing;
				InternalSyntaxToken kBuilder = (InternalSyntaxToken)this.VisitTerminal(context.KBuilder(), TestIncrementalCompilationSyntaxKind.KBuilder);
				return _factory.OperationModifierBuilder(kBuilder);
			}
			
			public override GreenNode VisitOperationModifierReadonly(TestIncrementalCompilationParser.OperationModifierReadonlyContext context)
			{
				if (context == null) return OperationModifierReadonlyGreen.__Missing;
				InternalSyntaxToken kReadonly = (InternalSyntaxToken)this.VisitTerminal(context.KReadonly(), TestIncrementalCompilationSyntaxKind.KReadonly);
				return _factory.OperationModifierReadonly(kReadonly);
			}
			
			public override GreenNode VisitParameterList(TestIncrementalCompilationParser.ParameterListContext context)
			{
				if (context == null) return ParameterListGreen.__Missing;
			    TestIncrementalCompilationParser.ParameterContext[] parameterContext = context.parameter();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var parameterBuilder = _pool.AllocateSeparated<ParameterGreen>();
			    for (int i = 0; i < parameterContext.Length; i++)
			    {
			        parameterBuilder.Add((ParameterGreen)this.Visit(parameterContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            parameterBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], TestIncrementalCompilationSyntaxKind.TComma));
			        }
			    }
				var parameter = parameterBuilder.ToList();
				_pool.Free(parameterBuilder);
				return _factory.ParameterList(parameter);
			}
			
			public override GreenNode VisitParameter(TestIncrementalCompilationParser.ParameterContext context)
			{
				if (context == null) return ParameterGreen.__Missing;
			    TestIncrementalCompilationParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				TestIncrementalCompilationParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				TestIncrementalCompilationParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				return _factory.Parameter(attribute, typeReference, name);
			}
			
			public override GreenNode VisitAssociationDeclaration(TestIncrementalCompilationParser.AssociationDeclarationContext context)
			{
				if (context == null) return AssociationDeclarationGreen.__Missing;
			    TestIncrementalCompilationParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kAssociation = (InternalSyntaxToken)this.VisitTerminal(context.KAssociation(), TestIncrementalCompilationSyntaxKind.KAssociation);
				TestIncrementalCompilationParser.QualifierContext sourceContext = context.source;
				QualifierGreen source = null;
				if (sourceContext != null) source = (QualifierGreen)this.Visit(sourceContext);
				if (source == null) source = QualifierGreen.__Missing;
				InternalSyntaxToken kWith = (InternalSyntaxToken)this.VisitTerminal(context.KWith(), TestIncrementalCompilationSyntaxKind.KWith);
				TestIncrementalCompilationParser.QualifierContext targetContext = context.target;
				QualifierGreen target = null;
				if (targetContext != null) target = (QualifierGreen)this.Visit(targetContext);
				if (target == null) target = QualifierGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestIncrementalCompilationSyntaxKind.TSemicolon);
				return _factory.AssociationDeclaration(attribute, kAssociation, source, kWith, target, tSemicolon);
			}
			
			public override GreenNode VisitIdentifier(TestIncrementalCompilationParser.IdentifierContext context)
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
				else
				{
					identifier = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.Identifier(identifier);
			}
			
			public override GreenNode VisitLiteral(TestIncrementalCompilationParser.LiteralContext context)
			{
				if (context == null) return LiteralGreen.__Missing;
				TestIncrementalCompilationParser.NullLiteralContext nullLiteralContext = context.nullLiteral();
				if (nullLiteralContext != null) 
				{
					return _factory.Literal((NullLiteralGreen)this.Visit(nullLiteralContext));
				}
				TestIncrementalCompilationParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				if (booleanLiteralContext != null) 
				{
					return _factory.Literal((BooleanLiteralGreen)this.Visit(booleanLiteralContext));
				}
				TestIncrementalCompilationParser.IntegerLiteralContext integerLiteralContext = context.integerLiteral();
				if (integerLiteralContext != null) 
				{
					return _factory.Literal((IntegerLiteralGreen)this.Visit(integerLiteralContext));
				}
				TestIncrementalCompilationParser.DecimalLiteralContext decimalLiteralContext = context.decimalLiteral();
				if (decimalLiteralContext != null) 
				{
					return _factory.Literal((DecimalLiteralGreen)this.Visit(decimalLiteralContext));
				}
				TestIncrementalCompilationParser.ScientificLiteralContext scientificLiteralContext = context.scientificLiteral();
				if (scientificLiteralContext != null) 
				{
					return _factory.Literal((ScientificLiteralGreen)this.Visit(scientificLiteralContext));
				}
				TestIncrementalCompilationParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				if (stringLiteralContext != null) 
				{
					return _factory.Literal((StringLiteralGreen)this.Visit(stringLiteralContext));
				}
				return LiteralGreen.__Missing;
			}
			
			public override GreenNode VisitNullLiteral(TestIncrementalCompilationParser.NullLiteralContext context)
			{
				if (context == null) return NullLiteralGreen.__Missing;
				InternalSyntaxToken kNull = (InternalSyntaxToken)this.VisitTerminal(context.KNull(), TestIncrementalCompilationSyntaxKind.KNull);
				return _factory.NullLiteral(kNull);
			}
			
			public override GreenNode VisitBooleanLiteral(TestIncrementalCompilationParser.BooleanLiteralContext context)
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
			
			public override GreenNode VisitIntegerLiteral(TestIncrementalCompilationParser.IntegerLiteralContext context)
			{
				if (context == null) return IntegerLiteralGreen.__Missing;
				InternalSyntaxToken lInteger = (InternalSyntaxToken)this.VisitTerminal(context.LInteger(), TestIncrementalCompilationSyntaxKind.LInteger);
				return _factory.IntegerLiteral(lInteger);
			}
			
			public override GreenNode VisitDecimalLiteral(TestIncrementalCompilationParser.DecimalLiteralContext context)
			{
				if (context == null) return DecimalLiteralGreen.__Missing;
				InternalSyntaxToken lDecimal = (InternalSyntaxToken)this.VisitTerminal(context.LDecimal(), TestIncrementalCompilationSyntaxKind.LDecimal);
				return _factory.DecimalLiteral(lDecimal);
			}
			
			public override GreenNode VisitScientificLiteral(TestIncrementalCompilationParser.ScientificLiteralContext context)
			{
				if (context == null) return ScientificLiteralGreen.__Missing;
				InternalSyntaxToken lScientific = (InternalSyntaxToken)this.VisitTerminal(context.LScientific(), TestIncrementalCompilationSyntaxKind.LScientific);
				return _factory.ScientificLiteral(lScientific);
			}
			
			public override GreenNode VisitStringLiteral(TestIncrementalCompilationParser.StringLiteralContext context)
			{
				if (context == null) return StringLiteralGreen.__Missing;
				InternalSyntaxToken lRegularString = (InternalSyntaxToken)this.VisitTerminal(context.LRegularString(), TestIncrementalCompilationSyntaxKind.LRegularString);
				return _factory.StringLiteral(lRegularString);
			}
        }
    }
    public partial class TestIncrementalCompilationParser
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

