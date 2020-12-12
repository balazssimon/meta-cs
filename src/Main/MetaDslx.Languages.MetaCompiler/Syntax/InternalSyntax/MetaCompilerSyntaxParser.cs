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
namespace MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax
{
    public class MetaCompilerSyntaxParser : Antlr4SyntaxParser
    {
        private readonly Antlr4ToRoslynVisitor _visitor;
        public MetaCompilerSyntaxParser(
            SourceText text,
            MetaCompilerParseOptions options,
            MetaCompilerSyntaxNode oldTree, 
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default)
            : base(MetaCompilerLanguage.Instance, text, options, oldTree, changes, cancellationToken)
        {
            _visitor = new Antlr4ToRoslynVisitor(this);
        }
        protected MetaCompilerParser Antlr4Parser => (MetaCompilerParser)this.Parser;
		public override LanguageSyntaxNode Parse()
		{
			BeginRoot();
            ParserState state = null;
			var green = this.ParseMain(ref state);
			EndRoot(ref green);
			var red = (MetaCompilerSyntaxNode)green.CreateRed();
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
		
		internal MetaCompilerParser.MainContext _Antlr4ParseMain()
		{
			BeginNode();
		    MetaCompilerParser.MainContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseMain(CurrentNode as MainSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.MainContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.NameContext _Antlr4ParseName()
		{
			BeginNode();
		    MetaCompilerParser.NameContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseName(CurrentNode as NameSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.NameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.QualifiedNameContext _Antlr4ParseQualifiedName()
		{
			BeginNode();
		    MetaCompilerParser.QualifiedNameContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQualifiedName(CurrentNode as QualifiedNameSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.QualifiedNameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.QualifierContext _Antlr4ParseQualifier()
		{
			BeginNode();
		    MetaCompilerParser.QualifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQualifier(CurrentNode as QualifierSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.QualifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.AttributeContext _Antlr4ParseAttribute()
		{
			BeginNode();
		    MetaCompilerParser.AttributeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseAttribute(CurrentNode as AttributeSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.AttributeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.NamespaceDeclarationContext _Antlr4ParseNamespaceDeclaration()
		{
			BeginNode();
		    MetaCompilerParser.NamespaceDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceDeclaration(CurrentNode as NamespaceDeclarationSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.NamespaceDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.NamespaceBodyContext _Antlr4ParseNamespaceBody()
		{
			BeginNode();
		    MetaCompilerParser.NamespaceBodyContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceBody(CurrentNode as NamespaceBodySyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.NamespaceBodyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.DeclarationContext _Antlr4ParseDeclaration()
		{
			BeginNode();
		    MetaCompilerParser.DeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDeclaration(CurrentNode as DeclarationSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.DeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		public GreenNode ParseCompilerDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.compilerDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseCompilerDeclaration(CompilerDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal MetaCompilerParser.CompilerDeclarationContext _Antlr4ParseCompilerDeclaration()
		{
			BeginNode();
		    MetaCompilerParser.CompilerDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseCompilerDeclaration(CurrentNode as CompilerDeclarationSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.CompilerDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseCompilerDeclaration();
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
		
		public GreenNode ParsePhaseDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.phaseDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReusePhaseDeclaration(PhaseDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal MetaCompilerParser.PhaseDeclarationContext _Antlr4ParsePhaseDeclaration()
		{
			BeginNode();
		    MetaCompilerParser.PhaseDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReusePhaseDeclaration(CurrentNode as PhaseDeclarationSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.PhaseDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParsePhaseDeclaration();
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
		
		public GreenNode ParsePhaseJoin(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.phaseJoin();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReusePhaseJoin(PhaseJoinSyntax node)
		{
			return node != null;
		}
		
		internal MetaCompilerParser.PhaseJoinContext _Antlr4ParsePhaseJoin()
		{
			BeginNode();
		    MetaCompilerParser.PhaseJoinContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReusePhaseJoin(CurrentNode as PhaseJoinSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.PhaseJoinContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParsePhaseJoin();
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
		
		public GreenNode ParseAfterPhases(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.afterPhases();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseAfterPhases(AfterPhasesSyntax node)
		{
			return node != null;
		}
		
		internal MetaCompilerParser.AfterPhasesContext _Antlr4ParseAfterPhases()
		{
			BeginNode();
		    MetaCompilerParser.AfterPhasesContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseAfterPhases(CurrentNode as AfterPhasesSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.AfterPhasesContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseAfterPhases();
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
		
		public GreenNode ParseBeforePhases(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.beforePhases();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseBeforePhases(BeforePhasesSyntax node)
		{
			return node != null;
		}
		
		internal MetaCompilerParser.BeforePhasesContext _Antlr4ParseBeforePhases()
		{
			BeginNode();
		    MetaCompilerParser.BeforePhasesContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseBeforePhases(CurrentNode as BeforePhasesSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.BeforePhasesContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseBeforePhases();
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
		
		public GreenNode ParsePhaseRef(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.phaseRef();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReusePhaseRef(PhaseRefSyntax node)
		{
			return node != null;
		}
		
		internal MetaCompilerParser.PhaseRefContext _Antlr4ParsePhaseRef()
		{
			BeginNode();
		    MetaCompilerParser.PhaseRefContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReusePhaseRef(CurrentNode as PhaseRefSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.PhaseRefContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParsePhaseRef();
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
		
		internal MetaCompilerParser.EnumDeclarationContext _Antlr4ParseEnumDeclaration()
		{
			BeginNode();
		    MetaCompilerParser.EnumDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseEnumDeclaration(CurrentNode as EnumDeclarationSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.EnumDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.EnumBodyContext _Antlr4ParseEnumBody()
		{
			BeginNode();
		    MetaCompilerParser.EnumBodyContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseEnumBody(CurrentNode as EnumBodySyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.EnumBodyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.EnumValuesContext _Antlr4ParseEnumValues()
		{
			BeginNode();
		    MetaCompilerParser.EnumValuesContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseEnumValues(CurrentNode as EnumValuesSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.EnumValuesContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.EnumValueContext _Antlr4ParseEnumValue()
		{
			BeginNode();
		    MetaCompilerParser.EnumValueContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseEnumValue(CurrentNode as EnumValueSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.EnumValueContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.EnumMemberDeclarationContext _Antlr4ParseEnumMemberDeclaration()
		{
			BeginNode();
		    MetaCompilerParser.EnumMemberDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseEnumMemberDeclaration(CurrentNode as EnumMemberDeclarationSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.EnumMemberDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.ClassDeclarationContext _Antlr4ParseClassDeclaration()
		{
			BeginNode();
		    MetaCompilerParser.ClassDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseClassDeclaration(CurrentNode as ClassDeclarationSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.ClassDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.ClassAncestorsContext _Antlr4ParseClassAncestors()
		{
			BeginNode();
		    MetaCompilerParser.ClassAncestorsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseClassAncestors(CurrentNode as ClassAncestorsSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.ClassAncestorsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.ClassAncestorContext _Antlr4ParseClassAncestor()
		{
			BeginNode();
		    MetaCompilerParser.ClassAncestorContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseClassAncestor(CurrentNode as ClassAncestorSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.ClassAncestorContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.ClassBodyContext _Antlr4ParseClassBody()
		{
			BeginNode();
		    MetaCompilerParser.ClassBodyContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseClassBody(CurrentNode as ClassBodySyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.ClassBodyContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.ClassMemberDeclarationContext _Antlr4ParseClassMemberDeclaration()
		{
			BeginNode();
		    MetaCompilerParser.ClassMemberDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseClassMemberDeclaration(CurrentNode as ClassMemberDeclarationSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.ClassMemberDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		public GreenNode ParseClassKind(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.classKind();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseClassKind(ClassKindSyntax node)
		{
			return node != null;
		}
		
		internal MetaCompilerParser.ClassKindContext _Antlr4ParseClassKind()
		{
			BeginNode();
		    MetaCompilerParser.ClassKindContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseClassKind(CurrentNode as ClassKindSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.ClassKindContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseClassKind();
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
		
		internal MetaCompilerParser.FieldDeclarationContext _Antlr4ParseFieldDeclaration()
		{
			BeginNode();
		    MetaCompilerParser.FieldDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseFieldDeclaration(CurrentNode as FieldDeclarationSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.FieldDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.FieldContainmentContext _Antlr4ParseFieldContainment()
		{
			BeginNode();
		    MetaCompilerParser.FieldContainmentContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseFieldContainment(CurrentNode as FieldContainmentSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.FieldContainmentContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.FieldModifierContext _Antlr4ParseFieldModifier()
		{
			BeginNode();
		    MetaCompilerParser.FieldModifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseFieldModifier(CurrentNode as FieldModifierSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.FieldModifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.DefaultValueContext _Antlr4ParseDefaultValue()
		{
			BeginNode();
		    MetaCompilerParser.DefaultValueContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDefaultValue(CurrentNode as DefaultValueSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.DefaultValueContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		public GreenNode ParsePhase(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.phase();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReusePhase(PhaseSyntax node)
		{
			return node != null;
		}
		
		internal MetaCompilerParser.PhaseContext _Antlr4ParsePhase()
		{
			BeginNode();
		    MetaCompilerParser.PhaseContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReusePhase(CurrentNode as PhaseSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.PhaseContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParsePhase();
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
		
		internal MetaCompilerParser.NameUseListContext _Antlr4ParseNameUseList()
		{
			BeginNode();
		    MetaCompilerParser.NameUseListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNameUseList(CurrentNode as NameUseListSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.NameUseListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		public GreenNode ParseTypedefDeclaration(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.typedefDeclaration();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTypedefDeclaration(TypedefDeclarationSyntax node)
		{
			return node != null;
		}
		
		internal MetaCompilerParser.TypedefDeclarationContext _Antlr4ParseTypedefDeclaration()
		{
			BeginNode();
		    MetaCompilerParser.TypedefDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTypedefDeclaration(CurrentNode as TypedefDeclarationSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.TypedefDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTypedefDeclaration();
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
		
		public GreenNode ParseTypedefValue(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.typedefValue();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTypedefValue(TypedefValueSyntax node)
		{
			return node != null;
		}
		
		internal MetaCompilerParser.TypedefValueContext _Antlr4ParseTypedefValue()
		{
			BeginNode();
		    MetaCompilerParser.TypedefValueContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTypedefValue(CurrentNode as TypedefValueSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.TypedefValueContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTypedefValue();
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
		
		internal MetaCompilerParser.ReturnTypeContext _Antlr4ParseReturnType()
		{
			BeginNode();
		    MetaCompilerParser.ReturnTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseReturnType(CurrentNode as ReturnTypeSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.ReturnTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.TypeOfReferenceContext _Antlr4ParseTypeOfReference()
		{
			BeginNode();
		    MetaCompilerParser.TypeOfReferenceContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTypeOfReference(CurrentNode as TypeOfReferenceSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.TypeOfReferenceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.TypeReferenceContext _Antlr4ParseTypeReference()
		{
			BeginNode();
		    MetaCompilerParser.TypeReferenceContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTypeReference(CurrentNode as TypeReferenceSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.TypeReferenceContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.SimpleTypeContext _Antlr4ParseSimpleType()
		{
			BeginNode();
		    MetaCompilerParser.SimpleTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSimpleType(CurrentNode as SimpleTypeSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.SimpleTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.ClassTypeContext _Antlr4ParseClassType()
		{
			BeginNode();
		    MetaCompilerParser.ClassTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseClassType(CurrentNode as ClassTypeSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.ClassTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.ObjectTypeContext _Antlr4ParseObjectType()
		{
			BeginNode();
		    MetaCompilerParser.ObjectTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseObjectType(CurrentNode as ObjectTypeSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.ObjectTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.PrimitiveTypeContext _Antlr4ParsePrimitiveType()
		{
			BeginNode();
		    MetaCompilerParser.PrimitiveTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReusePrimitiveType(CurrentNode as PrimitiveTypeSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.PrimitiveTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.VoidTypeContext _Antlr4ParseVoidType()
		{
			BeginNode();
		    MetaCompilerParser.VoidTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVoidType(CurrentNode as VoidTypeSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.VoidTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.NullableTypeContext _Antlr4ParseNullableType()
		{
			BeginNode();
		    MetaCompilerParser.NullableTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNullableType(CurrentNode as NullableTypeSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.NullableTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		public GreenNode ParseGenericType(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.genericType();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseGenericType(GenericTypeSyntax node)
		{
			return node != null;
		}
		
		internal MetaCompilerParser.GenericTypeContext _Antlr4ParseGenericType()
		{
			BeginNode();
		    MetaCompilerParser.GenericTypeContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseGenericType(CurrentNode as GenericTypeSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.GenericTypeContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseGenericType();
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
		
		public GreenNode ParseGenericTypeName(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.genericTypeName();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseGenericTypeName(GenericTypeNameSyntax node)
		{
			return node != null;
		}
		
		internal MetaCompilerParser.GenericTypeNameContext _Antlr4ParseGenericTypeName()
		{
			BeginNode();
		    MetaCompilerParser.GenericTypeNameContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseGenericTypeName(CurrentNode as GenericTypeNameSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.GenericTypeNameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseGenericTypeName();
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
		
		public GreenNode ParseTypeArguments(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.typeArguments();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTypeArguments(TypeArgumentsSyntax node)
		{
			return node != null;
		}
		
		internal MetaCompilerParser.TypeArgumentsContext _Antlr4ParseTypeArguments()
		{
			BeginNode();
		    MetaCompilerParser.TypeArgumentsContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTypeArguments(CurrentNode as TypeArgumentsSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.TypeArgumentsContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTypeArguments();
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
		
		public GreenNode ParseTypeArgument(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.typeArgument();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return _visitor.Visit(context);
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTypeArgument(TypeArgumentSyntax node)
		{
			return node != null;
		}
		
		internal MetaCompilerParser.TypeArgumentContext _Antlr4ParseTypeArgument()
		{
			BeginNode();
		    MetaCompilerParser.TypeArgumentContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTypeArgument(CurrentNode as TypeArgumentSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.TypeArgumentContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTypeArgument();
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
		
		internal MetaCompilerParser.OperationDeclarationContext _Antlr4ParseOperationDeclaration()
		{
			BeginNode();
		    MetaCompilerParser.OperationDeclarationContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseOperationDeclaration(CurrentNode as OperationDeclarationSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.OperationDeclarationContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.ParameterListContext _Antlr4ParseParameterList()
		{
			BeginNode();
		    MetaCompilerParser.ParameterListContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseParameterList(CurrentNode as ParameterListSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.ParameterListContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.ParameterContext _Antlr4ParseParameter()
		{
			BeginNode();
		    MetaCompilerParser.ParameterContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseParameter(CurrentNode as ParameterSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.ParameterContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.IdentifierContext _Antlr4ParseIdentifier()
		{
			BeginNode();
		    MetaCompilerParser.IdentifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIdentifier(CurrentNode as IdentifierSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.IdentifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.LiteralContext _Antlr4ParseLiteral()
		{
			BeginNode();
		    MetaCompilerParser.LiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseLiteral(CurrentNode as LiteralSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.LiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.NullLiteralContext _Antlr4ParseNullLiteral()
		{
			BeginNode();
		    MetaCompilerParser.NullLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNullLiteral(CurrentNode as NullLiteralSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.NullLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.BooleanLiteralContext _Antlr4ParseBooleanLiteral()
		{
			BeginNode();
		    MetaCompilerParser.BooleanLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseBooleanLiteral(CurrentNode as BooleanLiteralSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.BooleanLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.IntegerLiteralContext _Antlr4ParseIntegerLiteral()
		{
			BeginNode();
		    MetaCompilerParser.IntegerLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIntegerLiteral(CurrentNode as IntegerLiteralSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.IntegerLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.DecimalLiteralContext _Antlr4ParseDecimalLiteral()
		{
			BeginNode();
		    MetaCompilerParser.DecimalLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDecimalLiteral(CurrentNode as DecimalLiteralSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.DecimalLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.ScientificLiteralContext _Antlr4ParseScientificLiteral()
		{
			BeginNode();
		    MetaCompilerParser.ScientificLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseScientificLiteral(CurrentNode as ScientificLiteralSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.ScientificLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		internal MetaCompilerParser.StringLiteralContext _Antlr4ParseStringLiteral()
		{
			BeginNode();
		    MetaCompilerParser.StringLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseStringLiteral(CurrentNode as StringLiteralSyntax))
				{
					green = EatNode();
					context = new MetaCompilerParser.StringLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
        private class Antlr4ToRoslynVisitor : MetaCompilerParserBaseVisitor<GreenNode>
        {
			// list pools - allocators for lists that are used to build sequences of nodes. The lists
			// can be reused (hence pooled) since the syntax factory methods don't keep references to
			// them
			private readonly SyntaxListPool _pool = new SyntaxListPool(); // Don't need to reset this.
			private readonly MetaCompilerInternalSyntaxFactory _factory;
            private readonly MetaCompilerSyntaxParser _syntaxParser;
            public Antlr4ToRoslynVisitor(MetaCompilerSyntaxParser syntaxParser)
            {
				_factory = (MetaCompilerInternalSyntaxFactory)syntaxParser.Language.InternalSyntaxFactory;
                _syntaxParser = syntaxParser;
            }
            private GreenNode VisitTerminal(IToken token, MetaCompilerSyntaxKind kind)
            {
				if (token == null || (token.Type == TokenConstants.EOF && kind != SyntaxKind.Eof))
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
            private GreenNode VisitTerminal(ITerminalNode node, MetaCompilerSyntaxKind kind)
            {
                if (node == null || node.Symbol == null || (node.Symbol.Type == TokenConstants.EOF && kind != SyntaxKind.Eof))
				{
					if (kind != null) return _factory.MissingToken(kind);
					else return null;
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
			
			public override GreenNode VisitMain(MetaCompilerParser.MainContext context)
			{
				if (context == null) return MainGreen.__Missing;
				MetaCompilerParser.NamespaceDeclarationContext namespaceDeclarationContext = context.namespaceDeclaration();
				NamespaceDeclarationGreen namespaceDeclaration = null;
				if (namespaceDeclarationContext != null) namespaceDeclaration = (NamespaceDeclarationGreen)this.Visit(namespaceDeclarationContext);
				if (namespaceDeclaration == null) namespaceDeclaration = NamespaceDeclarationGreen.__Missing;
				InternalSyntaxToken eOF = (InternalSyntaxToken)this.VisitTerminal(context.Eof(), MetaCompilerSyntaxKind.Eof);
				return _factory.Main(namespaceDeclaration, eOF);
			}
			
			public override GreenNode VisitName(MetaCompilerParser.NameContext context)
			{
				if (context == null) return NameGreen.__Missing;
				MetaCompilerParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null) identifier = (IdentifierGreen)this.Visit(identifierContext);
				if (identifier == null) identifier = IdentifierGreen.__Missing;
				return _factory.Name(identifier);
			}
			
			public override GreenNode VisitQualifiedName(MetaCompilerParser.QualifiedNameContext context)
			{
				if (context == null) return QualifiedNameGreen.__Missing;
				MetaCompilerParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.QualifiedName(qualifier);
			}
			
			public override GreenNode VisitQualifier(MetaCompilerParser.QualifierContext context)
			{
				if (context == null) return QualifierGreen.__Missing;
			    MetaCompilerParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tDotContext = context.TDot();
			    var identifierBuilder = _pool.AllocateSeparated<IdentifierGreen>();
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tDotContext.Length)
			        {
			            identifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tDotContext[i], MetaCompilerSyntaxKind.TDot));
			        }
			    }
				var identifier = identifierBuilder.ToList();
				_pool.Free(identifierBuilder);
				return _factory.Qualifier(identifier);
			}
			
			public override GreenNode VisitAttribute(MetaCompilerParser.AttributeContext context)
			{
				if (context == null) return AttributeGreen.__Missing;
				InternalSyntaxToken tOpenBracket = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBracket(), MetaCompilerSyntaxKind.TOpenBracket);
				MetaCompilerParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				InternalSyntaxToken tCloseBracket = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBracket(), MetaCompilerSyntaxKind.TCloseBracket);
				return _factory.Attribute(tOpenBracket, qualifier, tCloseBracket);
			}
			
			public override GreenNode VisitNamespaceDeclaration(MetaCompilerParser.NamespaceDeclarationContext context)
			{
				if (context == null) return NamespaceDeclarationGreen.__Missing;
			    MetaCompilerParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), MetaCompilerSyntaxKind.KNamespace);
				MetaCompilerParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null) qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				if (qualifiedName == null) qualifiedName = QualifiedNameGreen.__Missing;
				MetaCompilerParser.NamespaceBodyContext namespaceBodyContext = context.namespaceBody();
				NamespaceBodyGreen namespaceBody = null;
				if (namespaceBodyContext != null) namespaceBody = (NamespaceBodyGreen)this.Visit(namespaceBodyContext);
				if (namespaceBody == null) namespaceBody = NamespaceBodyGreen.__Missing;
				return _factory.NamespaceDeclaration(attribute, kNamespace, qualifiedName, namespaceBody);
			}
			
			public override GreenNode VisitNamespaceBody(MetaCompilerParser.NamespaceBodyContext context)
			{
				if (context == null) return NamespaceBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), MetaCompilerSyntaxKind.TOpenBrace);
			    MetaCompilerParser.DeclarationContext[] declarationContext = context.declaration();
			    var declarationBuilder = _pool.Allocate<DeclarationGreen>();
			    for (int i = 0; i < declarationContext.Length; i++)
			    {
			        declarationBuilder.Add((DeclarationGreen)this.Visit(declarationContext[i]));
			    }
				var declaration = declarationBuilder.ToList();
				_pool.Free(declarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), MetaCompilerSyntaxKind.TCloseBrace);
				return _factory.NamespaceBody(tOpenBrace, declaration, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration(MetaCompilerParser.DeclarationContext context)
			{
				if (context == null) return DeclarationGreen.__Missing;
				MetaCompilerParser.CompilerDeclarationContext compilerDeclarationContext = context.compilerDeclaration();
				if (compilerDeclarationContext != null) 
				{
					return _factory.Declaration((CompilerDeclarationGreen)this.Visit(compilerDeclarationContext));
				}
				MetaCompilerParser.PhaseDeclarationContext phaseDeclarationContext = context.phaseDeclaration();
				if (phaseDeclarationContext != null) 
				{
					return _factory.Declaration((PhaseDeclarationGreen)this.Visit(phaseDeclarationContext));
				}
				MetaCompilerParser.EnumDeclarationContext enumDeclarationContext = context.enumDeclaration();
				if (enumDeclarationContext != null) 
				{
					return _factory.Declaration((EnumDeclarationGreen)this.Visit(enumDeclarationContext));
				}
				MetaCompilerParser.ClassDeclarationContext classDeclarationContext = context.classDeclaration();
				if (classDeclarationContext != null) 
				{
					return _factory.Declaration((ClassDeclarationGreen)this.Visit(classDeclarationContext));
				}
				MetaCompilerParser.TypedefDeclarationContext typedefDeclarationContext = context.typedefDeclaration();
				if (typedefDeclarationContext != null) 
				{
					return _factory.Declaration((TypedefDeclarationGreen)this.Visit(typedefDeclarationContext));
				}
				return DeclarationGreen.__Missing;
			}
			
			public override GreenNode VisitCompilerDeclaration(MetaCompilerParser.CompilerDeclarationContext context)
			{
				if (context == null) return CompilerDeclarationGreen.__Missing;
			    MetaCompilerParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kCompiler = (InternalSyntaxToken)this.VisitTerminal(context.KCompiler(), MetaCompilerSyntaxKind.KCompiler);
				MetaCompilerParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaCompilerSyntaxKind.TSemicolon);
				return _factory.CompilerDeclaration(attribute, kCompiler, name, tSemicolon);
			}
			
			public override GreenNode VisitPhaseDeclaration(MetaCompilerParser.PhaseDeclarationContext context)
			{
				if (context == null) return PhaseDeclarationGreen.__Missing;
			    MetaCompilerParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kLocked = (InternalSyntaxToken)this.VisitTerminal(context.KLocked());
				InternalSyntaxToken kPhase = (InternalSyntaxToken)this.VisitTerminal(context.KPhase(), MetaCompilerSyntaxKind.KPhase);
				MetaCompilerParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				MetaCompilerParser.PhaseJoinContext phaseJoinContext = context.phaseJoin();
				PhaseJoinGreen phaseJoin = null;
				if (phaseJoinContext != null) phaseJoin = (PhaseJoinGreen)this.Visit(phaseJoinContext);
				MetaCompilerParser.AfterPhasesContext afterPhasesContext = context.afterPhases();
				AfterPhasesGreen afterPhases = null;
				if (afterPhasesContext != null) afterPhases = (AfterPhasesGreen)this.Visit(afterPhasesContext);
				MetaCompilerParser.BeforePhasesContext beforePhasesContext = context.beforePhases();
				BeforePhasesGreen beforePhases = null;
				if (beforePhasesContext != null) beforePhases = (BeforePhasesGreen)this.Visit(beforePhasesContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaCompilerSyntaxKind.TSemicolon);
				return _factory.PhaseDeclaration(attribute, kLocked, kPhase, name, phaseJoin, afterPhases, beforePhases, tSemicolon);
			}
			
			public override GreenNode VisitPhaseJoin(MetaCompilerParser.PhaseJoinContext context)
			{
				if (context == null) return PhaseJoinGreen.__Missing;
				InternalSyntaxToken kJoins = (InternalSyntaxToken)this.VisitTerminal(context.KJoins(), MetaCompilerSyntaxKind.KJoins);
				MetaCompilerParser.PhaseRefContext phaseRefContext = context.phaseRef();
				PhaseRefGreen phaseRef = null;
				if (phaseRefContext != null) phaseRef = (PhaseRefGreen)this.Visit(phaseRefContext);
				if (phaseRef == null) phaseRef = PhaseRefGreen.__Missing;
				return _factory.PhaseJoin(kJoins, phaseRef);
			}
			
			public override GreenNode VisitAfterPhases(MetaCompilerParser.AfterPhasesContext context)
			{
				if (context == null) return AfterPhasesGreen.__Missing;
				InternalSyntaxToken kAfter = (InternalSyntaxToken)this.VisitTerminal(context.KAfter(), MetaCompilerSyntaxKind.KAfter);
			    MetaCompilerParser.PhaseRefContext[] phaseRefContext = context.phaseRef();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var phaseRefBuilder = _pool.AllocateSeparated<PhaseRefGreen>();
			    for (int i = 0; i < phaseRefContext.Length; i++)
			    {
			        phaseRefBuilder.Add((PhaseRefGreen)this.Visit(phaseRefContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            phaseRefBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaCompilerSyntaxKind.TComma));
			        }
			    }
				var phaseRef = phaseRefBuilder.ToList();
				_pool.Free(phaseRefBuilder);
				return _factory.AfterPhases(kAfter, phaseRef);
			}
			
			public override GreenNode VisitBeforePhases(MetaCompilerParser.BeforePhasesContext context)
			{
				if (context == null) return BeforePhasesGreen.__Missing;
				InternalSyntaxToken kBefore = (InternalSyntaxToken)this.VisitTerminal(context.KBefore(), MetaCompilerSyntaxKind.KBefore);
			    MetaCompilerParser.PhaseRefContext[] phaseRefContext = context.phaseRef();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var phaseRefBuilder = _pool.AllocateSeparated<PhaseRefGreen>();
			    for (int i = 0; i < phaseRefContext.Length; i++)
			    {
			        phaseRefBuilder.Add((PhaseRefGreen)this.Visit(phaseRefContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            phaseRefBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaCompilerSyntaxKind.TComma));
			        }
			    }
				var phaseRef = phaseRefBuilder.ToList();
				_pool.Free(phaseRefBuilder);
				return _factory.BeforePhases(kBefore, phaseRef);
			}
			
			public override GreenNode VisitPhaseRef(MetaCompilerParser.PhaseRefContext context)
			{
				if (context == null) return PhaseRefGreen.__Missing;
				MetaCompilerParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.PhaseRef(qualifier);
			}
			
			public override GreenNode VisitEnumDeclaration(MetaCompilerParser.EnumDeclarationContext context)
			{
				if (context == null) return EnumDeclarationGreen.__Missing;
			    MetaCompilerParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kEnum = (InternalSyntaxToken)this.VisitTerminal(context.KEnum(), MetaCompilerSyntaxKind.KEnum);
				MetaCompilerParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				MetaCompilerParser.EnumBodyContext enumBodyContext = context.enumBody();
				EnumBodyGreen enumBody = null;
				if (enumBodyContext != null) enumBody = (EnumBodyGreen)this.Visit(enumBodyContext);
				if (enumBody == null) enumBody = EnumBodyGreen.__Missing;
				return _factory.EnumDeclaration(attribute, kEnum, name, enumBody);
			}
			
			public override GreenNode VisitEnumBody(MetaCompilerParser.EnumBodyContext context)
			{
				if (context == null) return EnumBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), MetaCompilerSyntaxKind.TOpenBrace);
				MetaCompilerParser.EnumValuesContext enumValuesContext = context.enumValues();
				EnumValuesGreen enumValues = null;
				if (enumValuesContext != null) enumValues = (EnumValuesGreen)this.Visit(enumValuesContext);
				if (enumValues == null) enumValues = EnumValuesGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
			    MetaCompilerParser.EnumMemberDeclarationContext[] enumMemberDeclarationContext = context.enumMemberDeclaration();
			    var enumMemberDeclarationBuilder = _pool.Allocate<EnumMemberDeclarationGreen>();
			    for (int i = 0; i < enumMemberDeclarationContext.Length; i++)
			    {
			        enumMemberDeclarationBuilder.Add((EnumMemberDeclarationGreen)this.Visit(enumMemberDeclarationContext[i]));
			    }
				var enumMemberDeclaration = enumMemberDeclarationBuilder.ToList();
				_pool.Free(enumMemberDeclarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), MetaCompilerSyntaxKind.TCloseBrace);
				return _factory.EnumBody(tOpenBrace, enumValues, tSemicolon, enumMemberDeclaration, tCloseBrace);
			}
			
			public override GreenNode VisitEnumValues(MetaCompilerParser.EnumValuesContext context)
			{
				if (context == null) return EnumValuesGreen.__Missing;
			    MetaCompilerParser.EnumValueContext[] enumValueContext = context.enumValue();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var enumValueBuilder = _pool.AllocateSeparated<EnumValueGreen>();
			    for (int i = 0; i < enumValueContext.Length; i++)
			    {
			        enumValueBuilder.Add((EnumValueGreen)this.Visit(enumValueContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            enumValueBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaCompilerSyntaxKind.TComma));
			        }
			    }
				var enumValue = enumValueBuilder.ToList();
				_pool.Free(enumValueBuilder);
				return _factory.EnumValues(enumValue);
			}
			
			public override GreenNode VisitEnumValue(MetaCompilerParser.EnumValueContext context)
			{
				if (context == null) return EnumValueGreen.__Missing;
			    MetaCompilerParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				MetaCompilerParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				return _factory.EnumValue(attribute, name);
			}
			
			public override GreenNode VisitEnumMemberDeclaration(MetaCompilerParser.EnumMemberDeclarationContext context)
			{
				if (context == null) return EnumMemberDeclarationGreen.__Missing;
				MetaCompilerParser.OperationDeclarationContext operationDeclarationContext = context.operationDeclaration();
				OperationDeclarationGreen operationDeclaration = null;
				if (operationDeclarationContext != null) operationDeclaration = (OperationDeclarationGreen)this.Visit(operationDeclarationContext);
				if (operationDeclaration == null) operationDeclaration = OperationDeclarationGreen.__Missing;
				return _factory.EnumMemberDeclaration(operationDeclaration);
			}
			
			public override GreenNode VisitClassDeclaration(MetaCompilerParser.ClassDeclarationContext context)
			{
				if (context == null) return ClassDeclarationGreen.__Missing;
			    MetaCompilerParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				InternalSyntaxToken kAbstract = (InternalSyntaxToken)this.VisitTerminal(context.KAbstract());
				MetaCompilerParser.ClassKindContext classKindContext = context.classKind();
				ClassKindGreen classKind = null;
				if (classKindContext != null) classKind = (ClassKindGreen)this.Visit(classKindContext);
				if (classKind == null) classKind = ClassKindGreen.__Missing;
				MetaCompilerParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tColon = (InternalSyntaxToken)this.VisitTerminal(context.TColon());
				MetaCompilerParser.ClassAncestorsContext classAncestorsContext = context.classAncestors();
				ClassAncestorsGreen classAncestors = null;
				if (classAncestorsContext != null) classAncestors = (ClassAncestorsGreen)this.Visit(classAncestorsContext);
				MetaCompilerParser.ClassBodyContext classBodyContext = context.classBody();
				ClassBodyGreen classBody = null;
				if (classBodyContext != null) classBody = (ClassBodyGreen)this.Visit(classBodyContext);
				if (classBody == null) classBody = ClassBodyGreen.__Missing;
				return _factory.ClassDeclaration(attribute, kAbstract, classKind, name, tColon, classAncestors, classBody);
			}
			
			public override GreenNode VisitClassAncestors(MetaCompilerParser.ClassAncestorsContext context)
			{
				if (context == null) return ClassAncestorsGreen.__Missing;
			    MetaCompilerParser.ClassAncestorContext[] classAncestorContext = context.classAncestor();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var classAncestorBuilder = _pool.AllocateSeparated<ClassAncestorGreen>();
			    for (int i = 0; i < classAncestorContext.Length; i++)
			    {
			        classAncestorBuilder.Add((ClassAncestorGreen)this.Visit(classAncestorContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            classAncestorBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaCompilerSyntaxKind.TComma));
			        }
			    }
				var classAncestor = classAncestorBuilder.ToList();
				_pool.Free(classAncestorBuilder);
				return _factory.ClassAncestors(classAncestor);
			}
			
			public override GreenNode VisitClassAncestor(MetaCompilerParser.ClassAncestorContext context)
			{
				if (context == null) return ClassAncestorGreen.__Missing;
				MetaCompilerParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.ClassAncestor(qualifier);
			}
			
			public override GreenNode VisitClassBody(MetaCompilerParser.ClassBodyContext context)
			{
				if (context == null) return ClassBodyGreen.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), MetaCompilerSyntaxKind.TOpenBrace);
			    MetaCompilerParser.ClassMemberDeclarationContext[] classMemberDeclarationContext = context.classMemberDeclaration();
			    var classMemberDeclarationBuilder = _pool.Allocate<ClassMemberDeclarationGreen>();
			    for (int i = 0; i < classMemberDeclarationContext.Length; i++)
			    {
			        classMemberDeclarationBuilder.Add((ClassMemberDeclarationGreen)this.Visit(classMemberDeclarationContext[i]));
			    }
				var classMemberDeclaration = classMemberDeclarationBuilder.ToList();
				_pool.Free(classMemberDeclarationBuilder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), MetaCompilerSyntaxKind.TCloseBrace);
				return _factory.ClassBody(tOpenBrace, classMemberDeclaration, tCloseBrace);
			}
			
			public override GreenNode VisitClassMemberDeclaration(MetaCompilerParser.ClassMemberDeclarationContext context)
			{
				if (context == null) return ClassMemberDeclarationGreen.__Missing;
				MetaCompilerParser.FieldDeclarationContext fieldDeclarationContext = context.fieldDeclaration();
				if (fieldDeclarationContext != null) 
				{
					return _factory.ClassMemberDeclaration((FieldDeclarationGreen)this.Visit(fieldDeclarationContext));
				}
				MetaCompilerParser.OperationDeclarationContext operationDeclarationContext = context.operationDeclaration();
				if (operationDeclarationContext != null) 
				{
					return _factory.ClassMemberDeclaration((OperationDeclarationGreen)this.Visit(operationDeclarationContext));
				}
				return ClassMemberDeclarationGreen.__Missing;
			}
			
			public override GreenNode VisitClassKind(MetaCompilerParser.ClassKindContext context)
			{
				if (context == null) return ClassKindGreen.__Missing;
				InternalSyntaxToken classKind = null;
				if (context.KClass() != null)
				{
					classKind = (InternalSyntaxToken)this.VisitTerminal(context.KClass());
				}
				else 	if (context.KSymbol() != null)
				{
					classKind = (InternalSyntaxToken)this.VisitTerminal(context.KSymbol());
				}
				else 	if (context.KBinder() != null)
				{
					classKind = (InternalSyntaxToken)this.VisitTerminal(context.KBinder());
				}
				else
				{
					classKind = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.ClassKind(classKind);
			}
			
			public override GreenNode VisitFieldDeclaration(MetaCompilerParser.FieldDeclarationContext context)
			{
				if (context == null) return FieldDeclarationGreen.__Missing;
			    MetaCompilerParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				MetaCompilerParser.FieldContainmentContext fieldContainmentContext = context.fieldContainment();
				FieldContainmentGreen fieldContainment = null;
				if (fieldContainmentContext != null) fieldContainment = (FieldContainmentGreen)this.Visit(fieldContainmentContext);
				MetaCompilerParser.FieldModifierContext fieldModifierContext = context.fieldModifier();
				FieldModifierGreen fieldModifier = null;
				if (fieldModifierContext != null) fieldModifier = (FieldModifierGreen)this.Visit(fieldModifierContext);
				MetaCompilerParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				MetaCompilerParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				MetaCompilerParser.DefaultValueContext defaultValueContext = context.defaultValue();
				DefaultValueGreen defaultValue = null;
				if (defaultValueContext != null) defaultValue = (DefaultValueGreen)this.Visit(defaultValueContext);
				MetaCompilerParser.PhaseContext phaseContext = context.phase();
				PhaseGreen phase = null;
				if (phaseContext != null) phase = (PhaseGreen)this.Visit(phaseContext);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaCompilerSyntaxKind.TSemicolon);
				return _factory.FieldDeclaration(attribute, fieldContainment, fieldModifier, typeReference, name, defaultValue, phase, tSemicolon);
			}
			
			public override GreenNode VisitFieldContainment(MetaCompilerParser.FieldContainmentContext context)
			{
				if (context == null) return FieldContainmentGreen.__Missing;
				InternalSyntaxToken kContainment = (InternalSyntaxToken)this.VisitTerminal(context.KContainment(), MetaCompilerSyntaxKind.KContainment);
				return _factory.FieldContainment(kContainment);
			}
			
			public override GreenNode VisitFieldModifier(MetaCompilerParser.FieldModifierContext context)
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
				else
				{
					fieldModifier = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.FieldModifier(fieldModifier);
			}
			
			public override GreenNode VisitDefaultValue(MetaCompilerParser.DefaultValueContext context)
			{
				if (context == null) return DefaultValueGreen.__Missing;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), MetaCompilerSyntaxKind.TAssign);
				MetaCompilerParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null) stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				if (stringLiteral == null) stringLiteral = StringLiteralGreen.__Missing;
				return _factory.DefaultValue(tAssign, stringLiteral);
			}
			
			public override GreenNode VisitPhase(MetaCompilerParser.PhaseContext context)
			{
				if (context == null) return PhaseGreen.__Missing;
				InternalSyntaxToken kPhase = (InternalSyntaxToken)this.VisitTerminal(context.KPhase(), MetaCompilerSyntaxKind.KPhase);
				MetaCompilerParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.Phase(kPhase, qualifier);
			}
			
			public override GreenNode VisitNameUseList(MetaCompilerParser.NameUseListContext context)
			{
				if (context == null) return NameUseListGreen.__Missing;
			    MetaCompilerParser.QualifierContext[] qualifierContext = context.qualifier();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var qualifierBuilder = _pool.AllocateSeparated<QualifierGreen>();
			    for (int i = 0; i < qualifierContext.Length; i++)
			    {
			        qualifierBuilder.Add((QualifierGreen)this.Visit(qualifierContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            qualifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaCompilerSyntaxKind.TComma));
			        }
			    }
				var qualifier = qualifierBuilder.ToList();
				_pool.Free(qualifierBuilder);
				return _factory.NameUseList(qualifier);
			}
			
			public override GreenNode VisitTypedefDeclaration(MetaCompilerParser.TypedefDeclarationContext context)
			{
				if (context == null) return TypedefDeclarationGreen.__Missing;
				InternalSyntaxToken kTypeDef = (InternalSyntaxToken)this.VisitTerminal(context.KTypeDef(), MetaCompilerSyntaxKind.KTypeDef);
				MetaCompilerParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				MetaCompilerParser.TypedefValueContext typedefValueContext = context.typedefValue();
				TypedefValueGreen typedefValue = null;
				if (typedefValueContext != null) typedefValue = (TypedefValueGreen)this.Visit(typedefValueContext);
				if (typedefValue == null) typedefValue = TypedefValueGreen.__Missing;
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaCompilerSyntaxKind.TSemicolon);
				return _factory.TypedefDeclaration(kTypeDef, name, typedefValue, tSemicolon);
			}
			
			public override GreenNode VisitTypedefValue(MetaCompilerParser.TypedefValueContext context)
			{
				if (context == null) return TypedefValueGreen.__Missing;
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign(), MetaCompilerSyntaxKind.TAssign);
				MetaCompilerParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				StringLiteralGreen stringLiteral = null;
				if (stringLiteralContext != null) stringLiteral = (StringLiteralGreen)this.Visit(stringLiteralContext);
				if (stringLiteral == null) stringLiteral = StringLiteralGreen.__Missing;
				return _factory.TypedefValue(tAssign, stringLiteral);
			}
			
			public override GreenNode VisitReturnType(MetaCompilerParser.ReturnTypeContext context)
			{
				if (context == null) return ReturnTypeGreen.__Missing;
				MetaCompilerParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				if (typeReferenceContext != null) 
				{
					return _factory.ReturnType((TypeReferenceGreen)this.Visit(typeReferenceContext));
				}
				MetaCompilerParser.VoidTypeContext voidTypeContext = context.voidType();
				if (voidTypeContext != null) 
				{
					return _factory.ReturnType((VoidTypeGreen)this.Visit(voidTypeContext));
				}
				return ReturnTypeGreen.__Missing;
			}
			
			public override GreenNode VisitTypeOfReference(MetaCompilerParser.TypeOfReferenceContext context)
			{
				if (context == null) return TypeOfReferenceGreen.__Missing;
				MetaCompilerParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				return _factory.TypeOfReference(typeReference);
			}
			
			public override GreenNode VisitTypeReference(MetaCompilerParser.TypeReferenceContext context)
			{
				if (context == null) return TypeReferenceGreen.__Missing;
				MetaCompilerParser.GenericTypeContext genericTypeContext = context.genericType();
				if (genericTypeContext != null) 
				{
					return _factory.TypeReference((GenericTypeGreen)this.Visit(genericTypeContext));
				}
				MetaCompilerParser.SimpleTypeContext simpleTypeContext = context.simpleType();
				if (simpleTypeContext != null) 
				{
					return _factory.TypeReference((SimpleTypeGreen)this.Visit(simpleTypeContext));
				}
				return TypeReferenceGreen.__Missing;
			}
			
			public override GreenNode VisitSimpleType(MetaCompilerParser.SimpleTypeContext context)
			{
				if (context == null) return SimpleTypeGreen.__Missing;
				MetaCompilerParser.PrimitiveTypeContext primitiveTypeContext = context.primitiveType();
				if (primitiveTypeContext != null) 
				{
					return _factory.SimpleType((PrimitiveTypeGreen)this.Visit(primitiveTypeContext));
				}
				MetaCompilerParser.ObjectTypeContext objectTypeContext = context.objectType();
				if (objectTypeContext != null) 
				{
					return _factory.SimpleType((ObjectTypeGreen)this.Visit(objectTypeContext));
				}
				MetaCompilerParser.NullableTypeContext nullableTypeContext = context.nullableType();
				if (nullableTypeContext != null) 
				{
					return _factory.SimpleType((NullableTypeGreen)this.Visit(nullableTypeContext));
				}
				MetaCompilerParser.ClassTypeContext classTypeContext = context.classType();
				if (classTypeContext != null) 
				{
					return _factory.SimpleType((ClassTypeGreen)this.Visit(classTypeContext));
				}
				return SimpleTypeGreen.__Missing;
			}
			
			public override GreenNode VisitClassType(MetaCompilerParser.ClassTypeContext context)
			{
				if (context == null) return ClassTypeGreen.__Missing;
				MetaCompilerParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.ClassType(qualifier);
			}
			
			public override GreenNode VisitObjectType(MetaCompilerParser.ObjectTypeContext context)
			{
				if (context == null) return ObjectTypeGreen.__Missing;
				InternalSyntaxToken objectType = null;
				if (context.KObject() != null)
				{
					objectType = (InternalSyntaxToken)this.VisitTerminal(context.KObject());
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
			
			public override GreenNode VisitPrimitiveType(MetaCompilerParser.PrimitiveTypeContext context)
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
			
			public override GreenNode VisitVoidType(MetaCompilerParser.VoidTypeContext context)
			{
				if (context == null) return VoidTypeGreen.__Missing;
				InternalSyntaxToken kVoid = (InternalSyntaxToken)this.VisitTerminal(context.KVoid(), MetaCompilerSyntaxKind.KVoid);
				return _factory.VoidType(kVoid);
			}
			
			public override GreenNode VisitNullableType(MetaCompilerParser.NullableTypeContext context)
			{
				if (context == null) return NullableTypeGreen.__Missing;
				MetaCompilerParser.PrimitiveTypeContext primitiveTypeContext = context.primitiveType();
				PrimitiveTypeGreen primitiveType = null;
				if (primitiveTypeContext != null) primitiveType = (PrimitiveTypeGreen)this.Visit(primitiveTypeContext);
				if (primitiveType == null) primitiveType = PrimitiveTypeGreen.__Missing;
				InternalSyntaxToken tQuestion = (InternalSyntaxToken)this.VisitTerminal(context.TQuestion(), MetaCompilerSyntaxKind.TQuestion);
				return _factory.NullableType(primitiveType, tQuestion);
			}
			
			public override GreenNode VisitGenericType(MetaCompilerParser.GenericTypeContext context)
			{
				if (context == null) return GenericTypeGreen.__Missing;
				MetaCompilerParser.GenericTypeNameContext genericTypeNameContext = context.genericTypeName();
				GenericTypeNameGreen genericTypeName = null;
				if (genericTypeNameContext != null) genericTypeName = (GenericTypeNameGreen)this.Visit(genericTypeNameContext);
				if (genericTypeName == null) genericTypeName = GenericTypeNameGreen.__Missing;
				InternalSyntaxToken tLessThan = (InternalSyntaxToken)this.VisitTerminal(context.TLessThan(), MetaCompilerSyntaxKind.TLessThan);
				MetaCompilerParser.TypeArgumentsContext typeArgumentsContext = context.typeArguments();
				TypeArgumentsGreen typeArguments = null;
				if (typeArgumentsContext != null) typeArguments = (TypeArgumentsGreen)this.Visit(typeArgumentsContext);
				if (typeArguments == null) typeArguments = TypeArgumentsGreen.__Missing;
				InternalSyntaxToken tGreaterThan = (InternalSyntaxToken)this.VisitTerminal(context.TGreaterThan(), MetaCompilerSyntaxKind.TGreaterThan);
				return _factory.GenericType(genericTypeName, tLessThan, typeArguments, tGreaterThan);
			}
			
			public override GreenNode VisitGenericTypeName(MetaCompilerParser.GenericTypeNameContext context)
			{
				if (context == null) return GenericTypeNameGreen.__Missing;
				MetaCompilerParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.GenericTypeName(qualifier);
			}
			
			public override GreenNode VisitTypeArguments(MetaCompilerParser.TypeArgumentsContext context)
			{
				if (context == null) return TypeArgumentsGreen.__Missing;
			    MetaCompilerParser.TypeArgumentContext[] typeArgumentContext = context.typeArgument();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var typeArgumentBuilder = _pool.AllocateSeparated<TypeArgumentGreen>();
			    for (int i = 0; i < typeArgumentContext.Length; i++)
			    {
			        typeArgumentBuilder.Add((TypeArgumentGreen)this.Visit(typeArgumentContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            typeArgumentBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaCompilerSyntaxKind.TComma));
			        }
			    }
				var typeArgument = typeArgumentBuilder.ToList();
				_pool.Free(typeArgumentBuilder);
				return _factory.TypeArguments(typeArgument);
			}
			
			public override GreenNode VisitTypeArgument(MetaCompilerParser.TypeArgumentContext context)
			{
				if (context == null) return TypeArgumentGreen.__Missing;
				MetaCompilerParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null) qualifier = (QualifierGreen)this.Visit(qualifierContext);
				if (qualifier == null) qualifier = QualifierGreen.__Missing;
				return _factory.TypeArgument(qualifier);
			}
			
			public override GreenNode VisitOperationDeclaration(MetaCompilerParser.OperationDeclarationContext context)
			{
				if (context == null) return OperationDeclarationGreen.__Missing;
			    MetaCompilerParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				MetaCompilerParser.ReturnTypeContext returnTypeContext = context.returnType();
				ReturnTypeGreen returnType = null;
				if (returnTypeContext != null) returnType = (ReturnTypeGreen)this.Visit(returnTypeContext);
				if (returnType == null) returnType = ReturnTypeGreen.__Missing;
				MetaCompilerParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen(), MetaCompilerSyntaxKind.TOpenParen);
				MetaCompilerParser.ParameterListContext parameterListContext = context.parameterList();
				ParameterListGreen parameterList = null;
				if (parameterListContext != null) parameterList = (ParameterListGreen)this.Visit(parameterListContext);
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen(), MetaCompilerSyntaxKind.TCloseParen);
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), MetaCompilerSyntaxKind.TSemicolon);
				return _factory.OperationDeclaration(attribute, returnType, name, tOpenParen, parameterList, tCloseParen, tSemicolon);
			}
			
			public override GreenNode VisitParameterList(MetaCompilerParser.ParameterListContext context)
			{
				if (context == null) return ParameterListGreen.__Missing;
			    MetaCompilerParser.ParameterContext[] parameterContext = context.parameter();
			    ITerminalNode[] tCommaContext = context.TComma();
			    var parameterBuilder = _pool.AllocateSeparated<ParameterGreen>();
			    for (int i = 0; i < parameterContext.Length; i++)
			    {
			        parameterBuilder.Add((ParameterGreen)this.Visit(parameterContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            parameterBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i], MetaCompilerSyntaxKind.TComma));
			        }
			    }
				var parameter = parameterBuilder.ToList();
				_pool.Free(parameterBuilder);
				return _factory.ParameterList(parameter);
			}
			
			public override GreenNode VisitParameter(MetaCompilerParser.ParameterContext context)
			{
				if (context == null) return ParameterGreen.__Missing;
			    MetaCompilerParser.AttributeContext[] attributeContext = context.attribute();
			    var attributeBuilder = _pool.Allocate<AttributeGreen>();
			    for (int i = 0; i < attributeContext.Length; i++)
			    {
			        attributeBuilder.Add((AttributeGreen)this.Visit(attributeContext[i]));
			    }
				var attribute = attributeBuilder.ToList();
				_pool.Free(attributeBuilder);
				MetaCompilerParser.TypeReferenceContext typeReferenceContext = context.typeReference();
				TypeReferenceGreen typeReference = null;
				if (typeReferenceContext != null) typeReference = (TypeReferenceGreen)this.Visit(typeReferenceContext);
				if (typeReference == null) typeReference = TypeReferenceGreen.__Missing;
				MetaCompilerParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null) name = (NameGreen)this.Visit(nameContext);
				if (name == null) name = NameGreen.__Missing;
				return _factory.Parameter(attribute, typeReference, name);
			}
			
			public override GreenNode VisitIdentifier(MetaCompilerParser.IdentifierContext context)
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
				else
				{
					identifier = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.Identifier(identifier);
			}
			
			public override GreenNode VisitLiteral(MetaCompilerParser.LiteralContext context)
			{
				if (context == null) return LiteralGreen.__Missing;
				MetaCompilerParser.NullLiteralContext nullLiteralContext = context.nullLiteral();
				if (nullLiteralContext != null) 
				{
					return _factory.Literal((NullLiteralGreen)this.Visit(nullLiteralContext));
				}
				MetaCompilerParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				if (booleanLiteralContext != null) 
				{
					return _factory.Literal((BooleanLiteralGreen)this.Visit(booleanLiteralContext));
				}
				MetaCompilerParser.IntegerLiteralContext integerLiteralContext = context.integerLiteral();
				if (integerLiteralContext != null) 
				{
					return _factory.Literal((IntegerLiteralGreen)this.Visit(integerLiteralContext));
				}
				MetaCompilerParser.DecimalLiteralContext decimalLiteralContext = context.decimalLiteral();
				if (decimalLiteralContext != null) 
				{
					return _factory.Literal((DecimalLiteralGreen)this.Visit(decimalLiteralContext));
				}
				MetaCompilerParser.ScientificLiteralContext scientificLiteralContext = context.scientificLiteral();
				if (scientificLiteralContext != null) 
				{
					return _factory.Literal((ScientificLiteralGreen)this.Visit(scientificLiteralContext));
				}
				MetaCompilerParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				if (stringLiteralContext != null) 
				{
					return _factory.Literal((StringLiteralGreen)this.Visit(stringLiteralContext));
				}
				return LiteralGreen.__Missing;
			}
			
			public override GreenNode VisitNullLiteral(MetaCompilerParser.NullLiteralContext context)
			{
				if (context == null) return NullLiteralGreen.__Missing;
				InternalSyntaxToken kNull = (InternalSyntaxToken)this.VisitTerminal(context.KNull(), MetaCompilerSyntaxKind.KNull);
				return _factory.NullLiteral(kNull);
			}
			
			public override GreenNode VisitBooleanLiteral(MetaCompilerParser.BooleanLiteralContext context)
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
			
			public override GreenNode VisitIntegerLiteral(MetaCompilerParser.IntegerLiteralContext context)
			{
				if (context == null) return IntegerLiteralGreen.__Missing;
				InternalSyntaxToken lInteger = (InternalSyntaxToken)this.VisitTerminal(context.LInteger(), MetaCompilerSyntaxKind.LInteger);
				return _factory.IntegerLiteral(lInteger);
			}
			
			public override GreenNode VisitDecimalLiteral(MetaCompilerParser.DecimalLiteralContext context)
			{
				if (context == null) return DecimalLiteralGreen.__Missing;
				InternalSyntaxToken lDecimal = (InternalSyntaxToken)this.VisitTerminal(context.LDecimal(), MetaCompilerSyntaxKind.LDecimal);
				return _factory.DecimalLiteral(lDecimal);
			}
			
			public override GreenNode VisitScientificLiteral(MetaCompilerParser.ScientificLiteralContext context)
			{
				if (context == null) return ScientificLiteralGreen.__Missing;
				InternalSyntaxToken lScientific = (InternalSyntaxToken)this.VisitTerminal(context.LScientific(), MetaCompilerSyntaxKind.LScientific);
				return _factory.ScientificLiteral(lScientific);
			}
			
			public override GreenNode VisitStringLiteral(MetaCompilerParser.StringLiteralContext context)
			{
				if (context == null) return StringLiteralGreen.__Missing;
				InternalSyntaxToken lRegularString = (InternalSyntaxToken)this.VisitTerminal(context.LRegularString(), MetaCompilerSyntaxKind.LRegularString);
				return _factory.StringLiteral(lRegularString);
			}
        }
    }
    public partial class MetaCompilerParser
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
		
		internal class CompilerDeclarationContext_Cached : CompilerDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public CompilerDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class PhaseDeclarationContext_Cached : PhaseDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public PhaseDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class PhaseJoinContext_Cached : PhaseJoinContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public PhaseJoinContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class AfterPhasesContext_Cached : AfterPhasesContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public AfterPhasesContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class BeforePhasesContext_Cached : BeforePhasesContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public BeforePhasesContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class PhaseRefContext_Cached : PhaseRefContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public PhaseRefContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class ClassKindContext_Cached : ClassKindContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public ClassKindContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class PhaseContext_Cached : PhaseContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public PhaseContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class TypedefDeclarationContext_Cached : TypedefDeclarationContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TypedefDeclarationContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TypedefValueContext_Cached : TypedefValueContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TypedefValueContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
		
		internal class GenericTypeContext_Cached : GenericTypeContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public GenericTypeContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class GenericTypeNameContext_Cached : GenericTypeNameContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public GenericTypeNameContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TypeArgumentsContext_Cached : TypeArgumentsContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TypeArgumentsContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class TypeArgumentContext_Cached : TypeArgumentContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TypeArgumentContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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
