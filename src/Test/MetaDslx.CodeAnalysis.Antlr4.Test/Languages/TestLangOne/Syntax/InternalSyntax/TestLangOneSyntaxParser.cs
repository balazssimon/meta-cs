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
namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Syntax.InternalSyntax
{
    public class TestLangOneSyntaxParser : Antlr4SyntaxParser
    {
        private readonly Antlr4ToRoslynVisitor _visitor;
        public TestLangOneSyntaxParser(
            SourceText text,
            TestLangOneParseOptions options,
            TestLangOneSyntaxNode oldTree, 
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default)
            : base(TestLangOneLanguage.Instance, text, options, oldTree, changes, cancellationToken)
        {
            _visitor = new Antlr4ToRoslynVisitor(this);
        }
        protected TestLangOneParser Antlr4Parser => (TestLangOneParser)this.Parser;
		public override LanguageSyntaxNode Parse()
		{
			BeginRoot();
            ParserState state = null;
			var green = this.ParseMain(ref state);
			EndRoot(ref green);
			var red = (TestLangOneSyntaxNode)green.CreateRed();
			return red;
		}
		public GreenNode ParseMain(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.main();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
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
		
		internal TestLangOneParser.MainContext _Antlr4ParseMain()
		{
			BeginNode();
		    TestLangOneParser.MainContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseMain(CurrentNode as MainSyntax))
				{
					green = EatNode();
					context = new TestLangOneParser.MainContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		public GreenNode ParseTest(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.test();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTest(TestSyntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.TestContext _Antlr4ParseTest()
		{
			BeginNode();
		    TestLangOneParser.TestContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTest(CurrentNode as TestSyntax))
				{
					green = EatNode();
					context = new TestLangOneParser.TestContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTest();
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
		
		public GreenNode ParseTest01(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.test01();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTest01(Test01Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Test01Context _Antlr4ParseTest01()
		{
			BeginNode();
		    TestLangOneParser.Test01Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTest01(CurrentNode as Test01Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Test01Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTest01();
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
		
		public GreenNode ParseNamespaceDeclaration01(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceDeclaration01();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceDeclaration01(NamespaceDeclaration01Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceDeclaration01Context _Antlr4ParseNamespaceDeclaration01()
		{
			BeginNode();
		    TestLangOneParser.NamespaceDeclaration01Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceDeclaration01(CurrentNode as NamespaceDeclaration01Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceDeclaration01Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceDeclaration01();
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
		
		public GreenNode ParseNamespaceBody01(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceBody01();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceBody01(NamespaceBody01Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceBody01Context _Antlr4ParseNamespaceBody01()
		{
			BeginNode();
		    TestLangOneParser.NamespaceBody01Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceBody01(CurrentNode as NamespaceBody01Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceBody01Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceBody01();
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
		
		public GreenNode ParseDeclaration01(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.declaration01();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDeclaration01(Declaration01Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Declaration01Context _Antlr4ParseDeclaration01()
		{
			BeginNode();
		    TestLangOneParser.Declaration01Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDeclaration01(CurrentNode as Declaration01Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Declaration01Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDeclaration01();
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
		
		public GreenNode ParseVertex01(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.vertex01();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVertex01(Vertex01Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Vertex01Context _Antlr4ParseVertex01()
		{
			BeginNode();
		    TestLangOneParser.Vertex01Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVertex01(CurrentNode as Vertex01Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Vertex01Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVertex01();
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
		
		public GreenNode ParseArrow01(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.arrow01();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArrow01(Arrow01Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Arrow01Context _Antlr4ParseArrow01()
		{
			BeginNode();
		    TestLangOneParser.Arrow01Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseArrow01(CurrentNode as Arrow01Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Arrow01Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseArrow01();
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
		
		public GreenNode ParseTest02(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.test02();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTest02(Test02Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Test02Context _Antlr4ParseTest02()
		{
			BeginNode();
		    TestLangOneParser.Test02Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTest02(CurrentNode as Test02Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Test02Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTest02();
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
		
		public GreenNode ParseNamespaceDeclaration02(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceDeclaration02();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceDeclaration02(NamespaceDeclaration02Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceDeclaration02Context _Antlr4ParseNamespaceDeclaration02()
		{
			BeginNode();
		    TestLangOneParser.NamespaceDeclaration02Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceDeclaration02(CurrentNode as NamespaceDeclaration02Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceDeclaration02Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceDeclaration02();
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
		
		public GreenNode ParseNamespaceBody02(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceBody02();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceBody02(NamespaceBody02Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceBody02Context _Antlr4ParseNamespaceBody02()
		{
			BeginNode();
		    TestLangOneParser.NamespaceBody02Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceBody02(CurrentNode as NamespaceBody02Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceBody02Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceBody02();
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
		
		public GreenNode ParseDeclaration02(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.declaration02();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDeclaration02(Declaration02Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Declaration02Context _Antlr4ParseDeclaration02()
		{
			BeginNode();
		    TestLangOneParser.Declaration02Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDeclaration02(CurrentNode as Declaration02Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Declaration02Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDeclaration02();
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
		
		public GreenNode ParseVertex02(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.vertex02();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVertex02(Vertex02Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Vertex02Context _Antlr4ParseVertex02()
		{
			BeginNode();
		    TestLangOneParser.Vertex02Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVertex02(CurrentNode as Vertex02Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Vertex02Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVertex02();
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
		
		public GreenNode ParseArrow02(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.arrow02();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArrow02(Arrow02Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Arrow02Context _Antlr4ParseArrow02()
		{
			BeginNode();
		    TestLangOneParser.Arrow02Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseArrow02(CurrentNode as Arrow02Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Arrow02Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseArrow02();
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
		
		public GreenNode ParseSource02(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.source02();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSource02(Source02Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Source02Context _Antlr4ParseSource02()
		{
			BeginNode();
		    TestLangOneParser.Source02Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSource02(CurrentNode as Source02Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Source02Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSource02();
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
		
		public GreenNode ParseTarget02(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.target02();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTarget02(Target02Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Target02Context _Antlr4ParseTarget02()
		{
			BeginNode();
		    TestLangOneParser.Target02Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTarget02(CurrentNode as Target02Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Target02Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTarget02();
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
		
		public GreenNode ParseTest03(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.test03();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTest03(Test03Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Test03Context _Antlr4ParseTest03()
		{
			BeginNode();
		    TestLangOneParser.Test03Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTest03(CurrentNode as Test03Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Test03Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTest03();
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
		
		public GreenNode ParseNamespaceDeclaration03(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceDeclaration03();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceDeclaration03(NamespaceDeclaration03Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceDeclaration03Context _Antlr4ParseNamespaceDeclaration03()
		{
			BeginNode();
		    TestLangOneParser.NamespaceDeclaration03Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceDeclaration03(CurrentNode as NamespaceDeclaration03Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceDeclaration03Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceDeclaration03();
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
		
		public GreenNode ParseNamespaceBody03(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceBody03();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceBody03(NamespaceBody03Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceBody03Context _Antlr4ParseNamespaceBody03()
		{
			BeginNode();
		    TestLangOneParser.NamespaceBody03Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceBody03(CurrentNode as NamespaceBody03Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceBody03Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceBody03();
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
		
		public GreenNode ParseDeclaration03(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.declaration03();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDeclaration03(Declaration03Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Declaration03Context _Antlr4ParseDeclaration03()
		{
			BeginNode();
		    TestLangOneParser.Declaration03Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDeclaration03(CurrentNode as Declaration03Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Declaration03Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDeclaration03();
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
		
		public GreenNode ParseVertex03(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.vertex03();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVertex03(Vertex03Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Vertex03Context _Antlr4ParseVertex03()
		{
			BeginNode();
		    TestLangOneParser.Vertex03Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVertex03(CurrentNode as Vertex03Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Vertex03Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVertex03();
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
		
		public GreenNode ParseArrow03(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.arrow03();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArrow03(Arrow03Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Arrow03Context _Antlr4ParseArrow03()
		{
			BeginNode();
		    TestLangOneParser.Arrow03Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseArrow03(CurrentNode as Arrow03Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Arrow03Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseArrow03();
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
		
		public GreenNode ParseSource03(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.source03();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSource03(Source03Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Source03Context _Antlr4ParseSource03()
		{
			BeginNode();
		    TestLangOneParser.Source03Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSource03(CurrentNode as Source03Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Source03Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSource03();
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
		
		public GreenNode ParseTarget03(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.target03();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTarget03(Target03Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Target03Context _Antlr4ParseTarget03()
		{
			BeginNode();
		    TestLangOneParser.Target03Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTarget03(CurrentNode as Target03Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Target03Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTarget03();
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
		
		public GreenNode ParseTest04(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.test04();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTest04(Test04Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Test04Context _Antlr4ParseTest04()
		{
			BeginNode();
		    TestLangOneParser.Test04Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTest04(CurrentNode as Test04Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Test04Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTest04();
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
		
		public GreenNode ParseNamespaceDeclaration04(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceDeclaration04();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceDeclaration04(NamespaceDeclaration04Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceDeclaration04Context _Antlr4ParseNamespaceDeclaration04()
		{
			BeginNode();
		    TestLangOneParser.NamespaceDeclaration04Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceDeclaration04(CurrentNode as NamespaceDeclaration04Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceDeclaration04Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceDeclaration04();
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
		
		public GreenNode ParseNamespaceBody04(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceBody04();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceBody04(NamespaceBody04Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceBody04Context _Antlr4ParseNamespaceBody04()
		{
			BeginNode();
		    TestLangOneParser.NamespaceBody04Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceBody04(CurrentNode as NamespaceBody04Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceBody04Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceBody04();
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
		
		public GreenNode ParseDeclaration04(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.declaration04();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDeclaration04(Declaration04Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Declaration04Context _Antlr4ParseDeclaration04()
		{
			BeginNode();
		    TestLangOneParser.Declaration04Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDeclaration04(CurrentNode as Declaration04Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Declaration04Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDeclaration04();
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
		
		public GreenNode ParseVertex04(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.vertex04();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVertex04(Vertex04Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Vertex04Context _Antlr4ParseVertex04()
		{
			BeginNode();
		    TestLangOneParser.Vertex04Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVertex04(CurrentNode as Vertex04Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Vertex04Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVertex04();
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
		
		public GreenNode ParseArrow04(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.arrow04();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArrow04(Arrow04Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Arrow04Context _Antlr4ParseArrow04()
		{
			BeginNode();
		    TestLangOneParser.Arrow04Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseArrow04(CurrentNode as Arrow04Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Arrow04Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseArrow04();
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
		
		public GreenNode ParseTest05(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.test05();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTest05(Test05Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Test05Context _Antlr4ParseTest05()
		{
			BeginNode();
		    TestLangOneParser.Test05Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTest05(CurrentNode as Test05Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Test05Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTest05();
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
		
		public GreenNode ParseNamespaceDeclaration05(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceDeclaration05();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceDeclaration05(NamespaceDeclaration05Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceDeclaration05Context _Antlr4ParseNamespaceDeclaration05()
		{
			BeginNode();
		    TestLangOneParser.NamespaceDeclaration05Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceDeclaration05(CurrentNode as NamespaceDeclaration05Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceDeclaration05Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceDeclaration05();
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
		
		public GreenNode ParseNamespaceBody05(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceBody05();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceBody05(NamespaceBody05Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceBody05Context _Antlr4ParseNamespaceBody05()
		{
			BeginNode();
		    TestLangOneParser.NamespaceBody05Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceBody05(CurrentNode as NamespaceBody05Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceBody05Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceBody05();
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
		
		public GreenNode ParseDeclaration05(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.declaration05();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDeclaration05(Declaration05Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Declaration05Context _Antlr4ParseDeclaration05()
		{
			BeginNode();
		    TestLangOneParser.Declaration05Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDeclaration05(CurrentNode as Declaration05Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Declaration05Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDeclaration05();
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
		
		public GreenNode ParseVertex05(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.vertex05();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVertex05(Vertex05Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Vertex05Context _Antlr4ParseVertex05()
		{
			BeginNode();
		    TestLangOneParser.Vertex05Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVertex05(CurrentNode as Vertex05Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Vertex05Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVertex05();
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
		
		public GreenNode ParseArrow05(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.arrow05();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArrow05(Arrow05Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Arrow05Context _Antlr4ParseArrow05()
		{
			BeginNode();
		    TestLangOneParser.Arrow05Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseArrow05(CurrentNode as Arrow05Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Arrow05Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseArrow05();
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
		
		public GreenNode ParseTest06(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.test06();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTest06(Test06Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Test06Context _Antlr4ParseTest06()
		{
			BeginNode();
		    TestLangOneParser.Test06Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTest06(CurrentNode as Test06Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Test06Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTest06();
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
		
		public GreenNode ParseNamespaceDeclaration06(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceDeclaration06();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceDeclaration06(NamespaceDeclaration06Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceDeclaration06Context _Antlr4ParseNamespaceDeclaration06()
		{
			BeginNode();
		    TestLangOneParser.NamespaceDeclaration06Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceDeclaration06(CurrentNode as NamespaceDeclaration06Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceDeclaration06Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceDeclaration06();
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
		
		public GreenNode ParseNamespaceBody06(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceBody06();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceBody06(NamespaceBody06Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceBody06Context _Antlr4ParseNamespaceBody06()
		{
			BeginNode();
		    TestLangOneParser.NamespaceBody06Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceBody06(CurrentNode as NamespaceBody06Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceBody06Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceBody06();
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
		
		public GreenNode ParseDeclaration06(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.declaration06();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDeclaration06(Declaration06Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Declaration06Context _Antlr4ParseDeclaration06()
		{
			BeginNode();
		    TestLangOneParser.Declaration06Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDeclaration06(CurrentNode as Declaration06Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Declaration06Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDeclaration06();
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
		
		public GreenNode ParseVertex06(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.vertex06();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVertex06(Vertex06Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Vertex06Context _Antlr4ParseVertex06()
		{
			BeginNode();
		    TestLangOneParser.Vertex06Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVertex06(CurrentNode as Vertex06Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Vertex06Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVertex06();
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
		
		public GreenNode ParseArrow06(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.arrow06();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArrow06(Arrow06Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Arrow06Context _Antlr4ParseArrow06()
		{
			BeginNode();
		    TestLangOneParser.Arrow06Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseArrow06(CurrentNode as Arrow06Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Arrow06Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseArrow06();
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
		
		public GreenNode ParseTest07(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.test07();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTest07(Test07Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Test07Context _Antlr4ParseTest07()
		{
			BeginNode();
		    TestLangOneParser.Test07Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTest07(CurrentNode as Test07Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Test07Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTest07();
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
		
		public GreenNode ParseNamespaceDeclaration07(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceDeclaration07();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceDeclaration07(NamespaceDeclaration07Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceDeclaration07Context _Antlr4ParseNamespaceDeclaration07()
		{
			BeginNode();
		    TestLangOneParser.NamespaceDeclaration07Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceDeclaration07(CurrentNode as NamespaceDeclaration07Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceDeclaration07Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceDeclaration07();
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
		
		public GreenNode ParseNamespaceBody07(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceBody07();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceBody07(NamespaceBody07Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceBody07Context _Antlr4ParseNamespaceBody07()
		{
			BeginNode();
		    TestLangOneParser.NamespaceBody07Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceBody07(CurrentNode as NamespaceBody07Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceBody07Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceBody07();
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
		
		public GreenNode ParseDeclaration07(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.declaration07();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDeclaration07(Declaration07Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Declaration07Context _Antlr4ParseDeclaration07()
		{
			BeginNode();
		    TestLangOneParser.Declaration07Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDeclaration07(CurrentNode as Declaration07Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Declaration07Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDeclaration07();
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
		
		public GreenNode ParseVertex07(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.vertex07();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVertex07(Vertex07Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Vertex07Context _Antlr4ParseVertex07()
		{
			BeginNode();
		    TestLangOneParser.Vertex07Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVertex07(CurrentNode as Vertex07Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Vertex07Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVertex07();
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
		
		public GreenNode ParseArrow07(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.arrow07();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArrow07(Arrow07Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Arrow07Context _Antlr4ParseArrow07()
		{
			BeginNode();
		    TestLangOneParser.Arrow07Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseArrow07(CurrentNode as Arrow07Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Arrow07Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseArrow07();
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
		
		public GreenNode ParseSource07(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.source07();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSource07(Source07Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Source07Context _Antlr4ParseSource07()
		{
			BeginNode();
		    TestLangOneParser.Source07Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSource07(CurrentNode as Source07Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Source07Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSource07();
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
		
		public GreenNode ParseTarget07(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.target07();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTarget07(Target07Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Target07Context _Antlr4ParseTarget07()
		{
			BeginNode();
		    TestLangOneParser.Target07Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTarget07(CurrentNode as Target07Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Target07Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTarget07();
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
		
		public GreenNode ParseTest08(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.test08();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTest08(Test08Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Test08Context _Antlr4ParseTest08()
		{
			BeginNode();
		    TestLangOneParser.Test08Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTest08(CurrentNode as Test08Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Test08Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTest08();
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
		
		public GreenNode ParseNamespaceDeclaration08(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceDeclaration08();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceDeclaration08(NamespaceDeclaration08Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceDeclaration08Context _Antlr4ParseNamespaceDeclaration08()
		{
			BeginNode();
		    TestLangOneParser.NamespaceDeclaration08Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceDeclaration08(CurrentNode as NamespaceDeclaration08Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceDeclaration08Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceDeclaration08();
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
		
		public GreenNode ParseNamespaceBody08(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceBody08();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceBody08(NamespaceBody08Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceBody08Context _Antlr4ParseNamespaceBody08()
		{
			BeginNode();
		    TestLangOneParser.NamespaceBody08Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceBody08(CurrentNode as NamespaceBody08Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceBody08Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceBody08();
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
		
		public GreenNode ParseDeclaration08(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.declaration08();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDeclaration08(Declaration08Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Declaration08Context _Antlr4ParseDeclaration08()
		{
			BeginNode();
		    TestLangOneParser.Declaration08Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDeclaration08(CurrentNode as Declaration08Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Declaration08Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDeclaration08();
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
		
		public GreenNode ParseVertex08(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.vertex08();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVertex08(Vertex08Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Vertex08Context _Antlr4ParseVertex08()
		{
			BeginNode();
		    TestLangOneParser.Vertex08Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVertex08(CurrentNode as Vertex08Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Vertex08Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVertex08();
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
		
		public GreenNode ParseArrow08(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.arrow08();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArrow08(Arrow08Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Arrow08Context _Antlr4ParseArrow08()
		{
			BeginNode();
		    TestLangOneParser.Arrow08Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseArrow08(CurrentNode as Arrow08Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Arrow08Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseArrow08();
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
		
		public GreenNode ParseSource08(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.source08();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseSource08(Source08Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Source08Context _Antlr4ParseSource08()
		{
			BeginNode();
		    TestLangOneParser.Source08Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseSource08(CurrentNode as Source08Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Source08Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseSource08();
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
		
		public GreenNode ParseTarget08(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.target08();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTarget08(Target08Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Target08Context _Antlr4ParseTarget08()
		{
			BeginNode();
		    TestLangOneParser.Target08Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTarget08(CurrentNode as Target08Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Target08Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTarget08();
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
		
		public GreenNode ParseTest09(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.test09();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTest09(Test09Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Test09Context _Antlr4ParseTest09()
		{
			BeginNode();
		    TestLangOneParser.Test09Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTest09(CurrentNode as Test09Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Test09Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTest09();
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
		
		public GreenNode ParseNamespaceDeclaration09(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceDeclaration09();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceDeclaration09(NamespaceDeclaration09Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceDeclaration09Context _Antlr4ParseNamespaceDeclaration09()
		{
			BeginNode();
		    TestLangOneParser.NamespaceDeclaration09Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceDeclaration09(CurrentNode as NamespaceDeclaration09Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceDeclaration09Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceDeclaration09();
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
		
		public GreenNode ParseNamespaceBody09(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceBody09();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceBody09(NamespaceBody09Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceBody09Context _Antlr4ParseNamespaceBody09()
		{
			BeginNode();
		    TestLangOneParser.NamespaceBody09Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceBody09(CurrentNode as NamespaceBody09Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceBody09Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceBody09();
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
		
		public GreenNode ParseDeclaration09(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.declaration09();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDeclaration09(Declaration09Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Declaration09Context _Antlr4ParseDeclaration09()
		{
			BeginNode();
		    TestLangOneParser.Declaration09Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDeclaration09(CurrentNode as Declaration09Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Declaration09Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDeclaration09();
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
		
		public GreenNode ParseVertex09(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.vertex09();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVertex09(Vertex09Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Vertex09Context _Antlr4ParseVertex09()
		{
			BeginNode();
		    TestLangOneParser.Vertex09Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVertex09(CurrentNode as Vertex09Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Vertex09Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVertex09();
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
		
		public GreenNode ParseArrow09(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.arrow09();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArrow09(Arrow09Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Arrow09Context _Antlr4ParseArrow09()
		{
			BeginNode();
		    TestLangOneParser.Arrow09Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseArrow09(CurrentNode as Arrow09Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Arrow09Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseArrow09();
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
		
		public GreenNode ParseTest10(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.test10();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTest10(Test10Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Test10Context _Antlr4ParseTest10()
		{
			BeginNode();
		    TestLangOneParser.Test10Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTest10(CurrentNode as Test10Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Test10Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTest10();
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
		
		public GreenNode ParseNamespaceDeclaration10(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceDeclaration10();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceDeclaration10(NamespaceDeclaration10Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceDeclaration10Context _Antlr4ParseNamespaceDeclaration10()
		{
			BeginNode();
		    TestLangOneParser.NamespaceDeclaration10Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceDeclaration10(CurrentNode as NamespaceDeclaration10Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceDeclaration10Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceDeclaration10();
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
		
		public GreenNode ParseNamespaceBody10(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceBody10();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceBody10(NamespaceBody10Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceBody10Context _Antlr4ParseNamespaceBody10()
		{
			BeginNode();
		    TestLangOneParser.NamespaceBody10Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceBody10(CurrentNode as NamespaceBody10Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceBody10Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceBody10();
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
		
		public GreenNode ParseDeclaration10(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.declaration10();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDeclaration10(Declaration10Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Declaration10Context _Antlr4ParseDeclaration10()
		{
			BeginNode();
		    TestLangOneParser.Declaration10Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDeclaration10(CurrentNode as Declaration10Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Declaration10Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDeclaration10();
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
		
		public GreenNode ParseVertex10(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.vertex10();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVertex10(Vertex10Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Vertex10Context _Antlr4ParseVertex10()
		{
			BeginNode();
		    TestLangOneParser.Vertex10Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVertex10(CurrentNode as Vertex10Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Vertex10Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVertex10();
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
		
		public GreenNode ParseArrow10(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.arrow10();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArrow10(Arrow10Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Arrow10Context _Antlr4ParseArrow10()
		{
			BeginNode();
		    TestLangOneParser.Arrow10Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseArrow10(CurrentNode as Arrow10Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Arrow10Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseArrow10();
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
		
		public GreenNode ParseTest11(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.test11();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseTest11(Test11Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Test11Context _Antlr4ParseTest11()
		{
			BeginNode();
		    TestLangOneParser.Test11Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseTest11(CurrentNode as Test11Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Test11Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseTest11();
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
		
		public GreenNode ParseNamespaceDeclaration11(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceDeclaration11();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceDeclaration11(NamespaceDeclaration11Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceDeclaration11Context _Antlr4ParseNamespaceDeclaration11()
		{
			BeginNode();
		    TestLangOneParser.NamespaceDeclaration11Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceDeclaration11(CurrentNode as NamespaceDeclaration11Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceDeclaration11Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceDeclaration11();
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
		
		public GreenNode ParseNamespaceBody11(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.namespaceBody11();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseNamespaceBody11(NamespaceBody11Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.NamespaceBody11Context _Antlr4ParseNamespaceBody11()
		{
			BeginNode();
		    TestLangOneParser.NamespaceBody11Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNamespaceBody11(CurrentNode as NamespaceBody11Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NamespaceBody11Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseNamespaceBody11();
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
		
		public GreenNode ParseDeclaration11(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.declaration11();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseDeclaration11(Declaration11Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Declaration11Context _Antlr4ParseDeclaration11()
		{
			BeginNode();
		    TestLangOneParser.Declaration11Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDeclaration11(CurrentNode as Declaration11Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Declaration11Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseDeclaration11();
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
		
		public GreenNode ParseVertex11(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.vertex11();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseVertex11(Vertex11Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Vertex11Context _Antlr4ParseVertex11()
		{
			BeginNode();
		    TestLangOneParser.Vertex11Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseVertex11(CurrentNode as Vertex11Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Vertex11Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseVertex11();
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
		
		public GreenNode ParseArrow11(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.arrow11();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
			}
			finally
			{
				state = this.State;
			}
		}
		
		protected virtual bool CanReuseArrow11(Arrow11Syntax node)
		{
			return node != null;
		}
		
		internal TestLangOneParser.Arrow11Context _Antlr4ParseArrow11()
		{
			BeginNode();
		    TestLangOneParser.Arrow11Context context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseArrow11(CurrentNode as Arrow11Syntax))
				{
					green = EatNode();
					context = new TestLangOneParser.Arrow11Context_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
					this.Antlr4Parser.Context.AddChild(context);
				}
				else
				{
					context = this.Antlr4Parser._DoParseArrow11();
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
		        else return null;
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
		
		internal TestLangOneParser.NameContext _Antlr4ParseName()
		{
			BeginNode();
		    TestLangOneParser.NameContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseName(CurrentNode as NameSyntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		        else return null;
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
		
		internal TestLangOneParser.QualifiedNameContext _Antlr4ParseQualifiedName()
		{
			BeginNode();
		    TestLangOneParser.QualifiedNameContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQualifiedName(CurrentNode as QualifiedNameSyntax))
				{
					green = EatNode();
					context = new TestLangOneParser.QualifiedNameContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		        else return null;
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
		
		internal TestLangOneParser.QualifierContext _Antlr4ParseQualifier()
		{
			BeginNode();
		    TestLangOneParser.QualifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseQualifier(CurrentNode as QualifierSyntax))
				{
					green = EatNode();
					context = new TestLangOneParser.QualifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
		public GreenNode ParseIdentifier(ref ParserState state)
		{
		    RestoreParserState(state);
			try
			{
				var context = this.Antlr4Parser.identifier();
		        if (TryGetGreenNode(context, out var green)) return green;
		        else return null;
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
		
		internal TestLangOneParser.IdentifierContext _Antlr4ParseIdentifier()
		{
			BeginNode();
		    TestLangOneParser.IdentifierContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIdentifier(CurrentNode as IdentifierSyntax))
				{
					green = EatNode();
					context = new TestLangOneParser.IdentifierContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		        else return null;
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
		
		internal TestLangOneParser.LiteralContext _Antlr4ParseLiteral()
		{
			BeginNode();
		    TestLangOneParser.LiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseLiteral(CurrentNode as LiteralSyntax))
				{
					green = EatNode();
					context = new TestLangOneParser.LiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		        else return null;
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
		
		internal TestLangOneParser.NullLiteralContext _Antlr4ParseNullLiteral()
		{
			BeginNode();
		    TestLangOneParser.NullLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseNullLiteral(CurrentNode as NullLiteralSyntax))
				{
					green = EatNode();
					context = new TestLangOneParser.NullLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		        else return null;
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
		
		internal TestLangOneParser.BooleanLiteralContext _Antlr4ParseBooleanLiteral()
		{
			BeginNode();
		    TestLangOneParser.BooleanLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseBooleanLiteral(CurrentNode as BooleanLiteralSyntax))
				{
					green = EatNode();
					context = new TestLangOneParser.BooleanLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		        else return null;
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
		
		internal TestLangOneParser.IntegerLiteralContext _Antlr4ParseIntegerLiteral()
		{
			BeginNode();
		    TestLangOneParser.IntegerLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseIntegerLiteral(CurrentNode as IntegerLiteralSyntax))
				{
					green = EatNode();
					context = new TestLangOneParser.IntegerLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		        else return null;
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
		
		internal TestLangOneParser.DecimalLiteralContext _Antlr4ParseDecimalLiteral()
		{
			BeginNode();
		    TestLangOneParser.DecimalLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseDecimalLiteral(CurrentNode as DecimalLiteralSyntax))
				{
					green = EatNode();
					context = new TestLangOneParser.DecimalLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		        else return null;
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
		
		internal TestLangOneParser.ScientificLiteralContext _Antlr4ParseScientificLiteral()
		{
			BeginNode();
		    TestLangOneParser.ScientificLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseScientificLiteral(CurrentNode as ScientificLiteralSyntax))
				{
					green = EatNode();
					context = new TestLangOneParser.ScientificLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		        else return null;
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
		
		internal TestLangOneParser.StringLiteralContext _Antlr4ParseStringLiteral()
		{
			BeginNode();
		    TestLangOneParser.StringLiteralContext context = null;
		    GreenNode green = null;
		    try
		    {
				if (IsIncremental && CanReuseStringLiteral(CurrentNode as StringLiteralSyntax))
				{
					green = EatNode();
					context = new TestLangOneParser.StringLiteralContext_Cached(this.Antlr4Parser.Context, this.Antlr4Parser.State, green);
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
		
        private class Antlr4ToRoslynVisitor : TestLangOneParserBaseVisitor<GreenNode>
        {
			// list pools - allocators for lists that are used to build sequences of nodes. The lists
			// can be reused (hence pooled) since the syntax factory methods don't keep references to
			// them
			private readonly SyntaxListPool _pool = new SyntaxListPool(); // Don't need to reset this.
			private readonly TestLangOneInternalSyntaxFactory _factory;
            private readonly TestLangOneSyntaxParser _syntaxParser;
            public Antlr4ToRoslynVisitor(TestLangOneSyntaxParser syntaxParser)
            {
				_factory = (TestLangOneInternalSyntaxFactory)syntaxParser.Language.InternalSyntaxFactory;
                _syntaxParser = syntaxParser;
            }
            private GreenNode VisitTerminal(IToken token, TestLangOneSyntaxKind kind)
            {
				if (token == null)
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
            private GreenNode VisitTerminal(ITerminalNode node, TestLangOneSyntaxKind kind)
            {
                if (node == null || node.Symbol == null)
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
			
			public override GreenNode VisitMain(TestLangOneParser.MainContext context)
			{
				if (context == null) return MainGreen.__Missing;
			    TestLangOneParser.TestContext[] testContext = context.test();
			    var testBuilder = _pool.Allocate<TestGreen>();
			    for (int i = 0; i < testContext.Length; i++)
			    {
			        testBuilder.Add((TestGreen)this.Visit(testContext[i]));
			    }
				var test = testBuilder.ToList();
				_pool.Free(testBuilder);
				InternalSyntaxToken eOF = (InternalSyntaxToken)this.VisitTerminal(context.Eof(), TestLangOneSyntaxKind.Eof);
				return _factory.Main(test, eOF);
			}
			
			public override GreenNode VisitTest(TestLangOneParser.TestContext context)
			{
				if (context == null) return TestGreen.__Missing;
				TestLangOneParser.Test01Context test01Context = context.test01();
				if (test01Context != null) 
				{
					return _factory.Test((Test01Green)this.Visit(test01Context));
				}
				TestLangOneParser.Test02Context test02Context = context.test02();
				if (test02Context != null) 
				{
					return _factory.Test((Test02Green)this.Visit(test02Context));
				}
				TestLangOneParser.Test03Context test03Context = context.test03();
				if (test03Context != null) 
				{
					return _factory.Test((Test03Green)this.Visit(test03Context));
				}
				TestLangOneParser.Test04Context test04Context = context.test04();
				if (test04Context != null) 
				{
					return _factory.Test((Test04Green)this.Visit(test04Context));
				}
				TestLangOneParser.Test05Context test05Context = context.test05();
				if (test05Context != null) 
				{
					return _factory.Test((Test05Green)this.Visit(test05Context));
				}
				TestLangOneParser.Test06Context test06Context = context.test06();
				if (test06Context != null) 
				{
					return _factory.Test((Test06Green)this.Visit(test06Context));
				}
				TestLangOneParser.Test07Context test07Context = context.test07();
				if (test07Context != null) 
				{
					return _factory.Test((Test07Green)this.Visit(test07Context));
				}
				TestLangOneParser.Test08Context test08Context = context.test08();
				if (test08Context != null) 
				{
					return _factory.Test((Test08Green)this.Visit(test08Context));
				}
				TestLangOneParser.Test09Context test09Context = context.test09();
				if (test09Context != null) 
				{
					return _factory.Test((Test09Green)this.Visit(test09Context));
				}
				TestLangOneParser.Test10Context test10Context = context.test10();
				if (test10Context != null) 
				{
					return _factory.Test((Test10Green)this.Visit(test10Context));
				}
				TestLangOneParser.Test11Context test11Context = context.test11();
				if (test11Context != null) 
				{
					return _factory.Test((Test11Green)this.Visit(test11Context));
				}
				return TestGreen.__Missing;
			}
			
			public override GreenNode VisitTest01(TestLangOneParser.Test01Context context)
			{
				if (context == null) return Test01Green.__Missing;
				InternalSyntaxToken kTest01 = (InternalSyntaxToken)this.VisitTerminal(context.KTest01(), TestLangOneSyntaxKind.KTest01);
				TestLangOneParser.NamespaceDeclaration01Context namespaceDeclaration01Context = context.namespaceDeclaration01();
				NamespaceDeclaration01Green namespaceDeclaration01 = null;
				if (namespaceDeclaration01Context != null)
				{
					namespaceDeclaration01 = (NamespaceDeclaration01Green)this.Visit(namespaceDeclaration01Context);
				}
				else
				{
					namespaceDeclaration01 = NamespaceDeclaration01Green.__Missing;
				}
				return _factory.Test01(kTest01, namespaceDeclaration01);
			}
			
			public override GreenNode VisitNamespaceDeclaration01(TestLangOneParser.NamespaceDeclaration01Context context)
			{
				if (context == null) return NamespaceDeclaration01Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody01Context namespaceBody01Context = context.namespaceBody01();
				NamespaceBody01Green namespaceBody01 = null;
				if (namespaceBody01Context != null)
				{
					namespaceBody01 = (NamespaceBody01Green)this.Visit(namespaceBody01Context);
				}
				else
				{
					namespaceBody01 = NamespaceBody01Green.__Missing;
				}
				return _factory.NamespaceDeclaration01(kNamespace, qualifiedName, namespaceBody01);
			}
			
			public override GreenNode VisitNamespaceBody01(TestLangOneParser.NamespaceBody01Context context)
			{
				if (context == null) return NamespaceBody01Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration01Context[] declaration01Context = context.declaration01();
			    var declaration01Builder = _pool.Allocate<Declaration01Green>();
			    for (int i = 0; i < declaration01Context.Length; i++)
			    {
			        declaration01Builder.Add((Declaration01Green)this.Visit(declaration01Context[i]));
			    }
				var declaration01 = declaration01Builder.ToList();
				_pool.Free(declaration01Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return _factory.NamespaceBody01(tOpenBrace, declaration01, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration01(TestLangOneParser.Declaration01Context context)
			{
				if (context == null) return Declaration01Green.__Missing;
				TestLangOneParser.Vertex01Context vertex01Context = context.vertex01();
				if (vertex01Context != null) 
				{
					return _factory.Declaration01((Vertex01Green)this.Visit(vertex01Context));
				}
				TestLangOneParser.Arrow01Context arrow01Context = context.arrow01();
				if (arrow01Context != null) 
				{
					return _factory.Declaration01((Arrow01Green)this.Visit(arrow01Context));
				}
				return Declaration01Green.__Missing;
			}
			
			public override GreenNode VisitVertex01(TestLangOneParser.Vertex01Context context)
			{
				if (context == null) return Vertex01Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Vertex01(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow01(TestLangOneParser.Arrow01Context context)
			{
				if (context == null) return Arrow01Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.QualifierContext sourceContext = context.source;
				QualifierGreen source = null;
				if (sourceContext != null)
				{
					source = (QualifierGreen)this.Visit(sourceContext);
				}
				else
				{
					source = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.QualifierContext targetContext = context.target;
				QualifierGreen target = null;
				if (targetContext != null)
				{
					target = (QualifierGreen)this.Visit(targetContext);
				}
				else
				{
					target = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Arrow01(kArrow, source, tArrow, target, tSemicolon);
			}
			
			public override GreenNode VisitTest02(TestLangOneParser.Test02Context context)
			{
				if (context == null) return Test02Green.__Missing;
				InternalSyntaxToken kTest02 = (InternalSyntaxToken)this.VisitTerminal(context.KTest02(), TestLangOneSyntaxKind.KTest02);
				TestLangOneParser.NamespaceDeclaration02Context namespaceDeclaration02Context = context.namespaceDeclaration02();
				NamespaceDeclaration02Green namespaceDeclaration02 = null;
				if (namespaceDeclaration02Context != null)
				{
					namespaceDeclaration02 = (NamespaceDeclaration02Green)this.Visit(namespaceDeclaration02Context);
				}
				else
				{
					namespaceDeclaration02 = NamespaceDeclaration02Green.__Missing;
				}
				return _factory.Test02(kTest02, namespaceDeclaration02);
			}
			
			public override GreenNode VisitNamespaceDeclaration02(TestLangOneParser.NamespaceDeclaration02Context context)
			{
				if (context == null) return NamespaceDeclaration02Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody02Context namespaceBody02Context = context.namespaceBody02();
				NamespaceBody02Green namespaceBody02 = null;
				if (namespaceBody02Context != null)
				{
					namespaceBody02 = (NamespaceBody02Green)this.Visit(namespaceBody02Context);
				}
				else
				{
					namespaceBody02 = NamespaceBody02Green.__Missing;
				}
				return _factory.NamespaceDeclaration02(kNamespace, qualifiedName, namespaceBody02);
			}
			
			public override GreenNode VisitNamespaceBody02(TestLangOneParser.NamespaceBody02Context context)
			{
				if (context == null) return NamespaceBody02Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration02Context[] declaration02Context = context.declaration02();
			    var declaration02Builder = _pool.Allocate<Declaration02Green>();
			    for (int i = 0; i < declaration02Context.Length; i++)
			    {
			        declaration02Builder.Add((Declaration02Green)this.Visit(declaration02Context[i]));
			    }
				var declaration02 = declaration02Builder.ToList();
				_pool.Free(declaration02Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return _factory.NamespaceBody02(tOpenBrace, declaration02, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration02(TestLangOneParser.Declaration02Context context)
			{
				if (context == null) return Declaration02Green.__Missing;
				TestLangOneParser.Vertex02Context vertex02Context = context.vertex02();
				if (vertex02Context != null) 
				{
					return _factory.Declaration02((Vertex02Green)this.Visit(vertex02Context));
				}
				TestLangOneParser.Arrow02Context arrow02Context = context.arrow02();
				if (arrow02Context != null) 
				{
					return _factory.Declaration02((Arrow02Green)this.Visit(arrow02Context));
				}
				return Declaration02Green.__Missing;
			}
			
			public override GreenNode VisitVertex02(TestLangOneParser.Vertex02Context context)
			{
				if (context == null) return Vertex02Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Vertex02(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow02(TestLangOneParser.Arrow02Context context)
			{
				if (context == null) return Arrow02Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.Source02Context source02Context = context.source02();
				Source02Green source02 = null;
				if (source02Context != null)
				{
					source02 = (Source02Green)this.Visit(source02Context);
				}
				else
				{
					source02 = Source02Green.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.Target02Context target02Context = context.target02();
				Target02Green target02 = null;
				if (target02Context != null)
				{
					target02 = (Target02Green)this.Visit(target02Context);
				}
				else
				{
					target02 = Target02Green.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Arrow02(kArrow, source02, tArrow, target02, tSemicolon);
			}
			
			public override GreenNode VisitSource02(TestLangOneParser.Source02Context context)
			{
				if (context == null) return Source02Green.__Missing;
				TestLangOneParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				return _factory.Source02(qualifier);
			}
			
			public override GreenNode VisitTarget02(TestLangOneParser.Target02Context context)
			{
				if (context == null) return Target02Green.__Missing;
				TestLangOneParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				return _factory.Target02(qualifier);
			}
			
			public override GreenNode VisitTest03(TestLangOneParser.Test03Context context)
			{
				if (context == null) return Test03Green.__Missing;
				InternalSyntaxToken kTest03 = (InternalSyntaxToken)this.VisitTerminal(context.KTest03(), TestLangOneSyntaxKind.KTest03);
				TestLangOneParser.NamespaceDeclaration03Context namespaceDeclaration03Context = context.namespaceDeclaration03();
				NamespaceDeclaration03Green namespaceDeclaration03 = null;
				if (namespaceDeclaration03Context != null)
				{
					namespaceDeclaration03 = (NamespaceDeclaration03Green)this.Visit(namespaceDeclaration03Context);
				}
				else
				{
					namespaceDeclaration03 = NamespaceDeclaration03Green.__Missing;
				}
				return _factory.Test03(kTest03, namespaceDeclaration03);
			}
			
			public override GreenNode VisitNamespaceDeclaration03(TestLangOneParser.NamespaceDeclaration03Context context)
			{
				if (context == null) return NamespaceDeclaration03Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody03Context namespaceBody03Context = context.namespaceBody03();
				NamespaceBody03Green namespaceBody03 = null;
				if (namespaceBody03Context != null)
				{
					namespaceBody03 = (NamespaceBody03Green)this.Visit(namespaceBody03Context);
				}
				else
				{
					namespaceBody03 = NamespaceBody03Green.__Missing;
				}
				return _factory.NamespaceDeclaration03(kNamespace, qualifiedName, namespaceBody03);
			}
			
			public override GreenNode VisitNamespaceBody03(TestLangOneParser.NamespaceBody03Context context)
			{
				if (context == null) return NamespaceBody03Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration03Context[] declaration03Context = context.declaration03();
			    var declaration03Builder = _pool.Allocate<Declaration03Green>();
			    for (int i = 0; i < declaration03Context.Length; i++)
			    {
			        declaration03Builder.Add((Declaration03Green)this.Visit(declaration03Context[i]));
			    }
				var declaration03 = declaration03Builder.ToList();
				_pool.Free(declaration03Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return _factory.NamespaceBody03(tOpenBrace, declaration03, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration03(TestLangOneParser.Declaration03Context context)
			{
				if (context == null) return Declaration03Green.__Missing;
				TestLangOneParser.Vertex03Context vertex03Context = context.vertex03();
				if (vertex03Context != null) 
				{
					return _factory.Declaration03((Vertex03Green)this.Visit(vertex03Context));
				}
				TestLangOneParser.Arrow03Context arrow03Context = context.arrow03();
				if (arrow03Context != null) 
				{
					return _factory.Declaration03((Arrow03Green)this.Visit(arrow03Context));
				}
				return Declaration03Green.__Missing;
			}
			
			public override GreenNode VisitVertex03(TestLangOneParser.Vertex03Context context)
			{
				if (context == null) return Vertex03Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Vertex03(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow03(TestLangOneParser.Arrow03Context context)
			{
				if (context == null) return Arrow03Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.Source03Context source03Context = context.source03();
				Source03Green source03 = null;
				if (source03Context != null)
				{
					source03 = (Source03Green)this.Visit(source03Context);
				}
				else
				{
					source03 = Source03Green.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.Target03Context target03Context = context.target03();
				Target03Green target03 = null;
				if (target03Context != null)
				{
					target03 = (Target03Green)this.Visit(target03Context);
				}
				else
				{
					target03 = Target03Green.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Arrow03(kArrow, source03, tArrow, target03, tSemicolon);
			}
			
			public override GreenNode VisitSource03(TestLangOneParser.Source03Context context)
			{
				if (context == null) return Source03Green.__Missing;
				TestLangOneParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				return _factory.Source03(qualifier);
			}
			
			public override GreenNode VisitTarget03(TestLangOneParser.Target03Context context)
			{
				if (context == null) return Target03Green.__Missing;
				TestLangOneParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				return _factory.Target03(qualifier);
			}
			
			public override GreenNode VisitTest04(TestLangOneParser.Test04Context context)
			{
				if (context == null) return Test04Green.__Missing;
				InternalSyntaxToken kTest04 = (InternalSyntaxToken)this.VisitTerminal(context.KTest04(), TestLangOneSyntaxKind.KTest04);
				TestLangOneParser.NamespaceDeclaration04Context namespaceDeclaration04Context = context.namespaceDeclaration04();
				NamespaceDeclaration04Green namespaceDeclaration04 = null;
				if (namespaceDeclaration04Context != null)
				{
					namespaceDeclaration04 = (NamespaceDeclaration04Green)this.Visit(namespaceDeclaration04Context);
				}
				else
				{
					namespaceDeclaration04 = NamespaceDeclaration04Green.__Missing;
				}
				return _factory.Test04(kTest04, namespaceDeclaration04);
			}
			
			public override GreenNode VisitNamespaceDeclaration04(TestLangOneParser.NamespaceDeclaration04Context context)
			{
				if (context == null) return NamespaceDeclaration04Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody04Context namespaceBody04Context = context.namespaceBody04();
				NamespaceBody04Green namespaceBody04 = null;
				if (namespaceBody04Context != null)
				{
					namespaceBody04 = (NamespaceBody04Green)this.Visit(namespaceBody04Context);
				}
				else
				{
					namespaceBody04 = NamespaceBody04Green.__Missing;
				}
				return _factory.NamespaceDeclaration04(kNamespace, qualifiedName, namespaceBody04);
			}
			
			public override GreenNode VisitNamespaceBody04(TestLangOneParser.NamespaceBody04Context context)
			{
				if (context == null) return NamespaceBody04Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration04Context[] declaration04Context = context.declaration04();
			    var declaration04Builder = _pool.Allocate<Declaration04Green>();
			    for (int i = 0; i < declaration04Context.Length; i++)
			    {
			        declaration04Builder.Add((Declaration04Green)this.Visit(declaration04Context[i]));
			    }
				var declaration04 = declaration04Builder.ToList();
				_pool.Free(declaration04Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return _factory.NamespaceBody04(tOpenBrace, declaration04, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration04(TestLangOneParser.Declaration04Context context)
			{
				if (context == null) return Declaration04Green.__Missing;
				TestLangOneParser.Vertex04Context vertex04Context = context.vertex04();
				if (vertex04Context != null) 
				{
					return _factory.Declaration04((Vertex04Green)this.Visit(vertex04Context));
				}
				TestLangOneParser.Arrow04Context arrow04Context = context.arrow04();
				if (arrow04Context != null) 
				{
					return _factory.Declaration04((Arrow04Green)this.Visit(arrow04Context));
				}
				return Declaration04Green.__Missing;
			}
			
			public override GreenNode VisitVertex04(TestLangOneParser.Vertex04Context context)
			{
				if (context == null) return Vertex04Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Vertex04(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow04(TestLangOneParser.Arrow04Context context)
			{
				if (context == null) return Arrow04Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.QualifierContext sourceContext = context.source;
				QualifierGreen source = null;
				if (sourceContext != null)
				{
					source = (QualifierGreen)this.Visit(sourceContext);
				}
				else
				{
					source = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.QualifierContext targetContext = context.target;
				QualifierGreen target = null;
				if (targetContext != null)
				{
					target = (QualifierGreen)this.Visit(targetContext);
				}
				else
				{
					target = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Arrow04(kArrow, source, tArrow, target, tSemicolon);
			}
			
			public override GreenNode VisitTest05(TestLangOneParser.Test05Context context)
			{
				if (context == null) return Test05Green.__Missing;
				InternalSyntaxToken kTest05 = (InternalSyntaxToken)this.VisitTerminal(context.KTest05(), TestLangOneSyntaxKind.KTest05);
				TestLangOneParser.NamespaceDeclaration05Context namespaceDeclaration05Context = context.namespaceDeclaration05();
				NamespaceDeclaration05Green namespaceDeclaration05 = null;
				if (namespaceDeclaration05Context != null)
				{
					namespaceDeclaration05 = (NamespaceDeclaration05Green)this.Visit(namespaceDeclaration05Context);
				}
				else
				{
					namespaceDeclaration05 = NamespaceDeclaration05Green.__Missing;
				}
				return _factory.Test05(kTest05, namespaceDeclaration05);
			}
			
			public override GreenNode VisitNamespaceDeclaration05(TestLangOneParser.NamespaceDeclaration05Context context)
			{
				if (context == null) return NamespaceDeclaration05Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody05Context namespaceBody05Context = context.namespaceBody05();
				NamespaceBody05Green namespaceBody05 = null;
				if (namespaceBody05Context != null)
				{
					namespaceBody05 = (NamespaceBody05Green)this.Visit(namespaceBody05Context);
				}
				else
				{
					namespaceBody05 = NamespaceBody05Green.__Missing;
				}
				return _factory.NamespaceDeclaration05(kNamespace, qualifiedName, namespaceBody05);
			}
			
			public override GreenNode VisitNamespaceBody05(TestLangOneParser.NamespaceBody05Context context)
			{
				if (context == null) return NamespaceBody05Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration05Context[] declaration05Context = context.declaration05();
			    var declaration05Builder = _pool.Allocate<Declaration05Green>();
			    for (int i = 0; i < declaration05Context.Length; i++)
			    {
			        declaration05Builder.Add((Declaration05Green)this.Visit(declaration05Context[i]));
			    }
				var declaration05 = declaration05Builder.ToList();
				_pool.Free(declaration05Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return _factory.NamespaceBody05(tOpenBrace, declaration05, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration05(TestLangOneParser.Declaration05Context context)
			{
				if (context == null) return Declaration05Green.__Missing;
				TestLangOneParser.Vertex05Context vertex05Context = context.vertex05();
				if (vertex05Context != null) 
				{
					return _factory.Declaration05((Vertex05Green)this.Visit(vertex05Context));
				}
				TestLangOneParser.Arrow05Context arrow05Context = context.arrow05();
				if (arrow05Context != null) 
				{
					return _factory.Declaration05((Arrow05Green)this.Visit(arrow05Context));
				}
				return Declaration05Green.__Missing;
			}
			
			public override GreenNode VisitVertex05(TestLangOneParser.Vertex05Context context)
			{
				if (context == null) return Vertex05Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Vertex05(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow05(TestLangOneParser.Arrow05Context context)
			{
				if (context == null) return Arrow05Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.QualifierContext sourceContext = context.source;
				QualifierGreen source = null;
				if (sourceContext != null)
				{
					source = (QualifierGreen)this.Visit(sourceContext);
				}
				else
				{
					source = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.QualifierContext targetContext = context.target;
				QualifierGreen target = null;
				if (targetContext != null)
				{
					target = (QualifierGreen)this.Visit(targetContext);
				}
				else
				{
					target = QualifierGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Arrow05(kArrow, source, tArrow, target, tSemicolon);
			}
			
			public override GreenNode VisitTest06(TestLangOneParser.Test06Context context)
			{
				if (context == null) return Test06Green.__Missing;
				InternalSyntaxToken kTest06 = (InternalSyntaxToken)this.VisitTerminal(context.KTest06(), TestLangOneSyntaxKind.KTest06);
				TestLangOneParser.NamespaceDeclaration06Context namespaceDeclaration06Context = context.namespaceDeclaration06();
				NamespaceDeclaration06Green namespaceDeclaration06 = null;
				if (namespaceDeclaration06Context != null)
				{
					namespaceDeclaration06 = (NamespaceDeclaration06Green)this.Visit(namespaceDeclaration06Context);
				}
				else
				{
					namespaceDeclaration06 = NamespaceDeclaration06Green.__Missing;
				}
				return _factory.Test06(kTest06, namespaceDeclaration06);
			}
			
			public override GreenNode VisitNamespaceDeclaration06(TestLangOneParser.NamespaceDeclaration06Context context)
			{
				if (context == null) return NamespaceDeclaration06Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody06Context namespaceBody06Context = context.namespaceBody06();
				NamespaceBody06Green namespaceBody06 = null;
				if (namespaceBody06Context != null)
				{
					namespaceBody06 = (NamespaceBody06Green)this.Visit(namespaceBody06Context);
				}
				else
				{
					namespaceBody06 = NamespaceBody06Green.__Missing;
				}
				return _factory.NamespaceDeclaration06(kNamespace, qualifiedName, namespaceBody06);
			}
			
			public override GreenNode VisitNamespaceBody06(TestLangOneParser.NamespaceBody06Context context)
			{
				if (context == null) return NamespaceBody06Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration06Context[] declaration06Context = context.declaration06();
			    var declaration06Builder = _pool.Allocate<Declaration06Green>();
			    for (int i = 0; i < declaration06Context.Length; i++)
			    {
			        declaration06Builder.Add((Declaration06Green)this.Visit(declaration06Context[i]));
			    }
				var declaration06 = declaration06Builder.ToList();
				_pool.Free(declaration06Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return _factory.NamespaceBody06(tOpenBrace, declaration06, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration06(TestLangOneParser.Declaration06Context context)
			{
				if (context == null) return Declaration06Green.__Missing;
				TestLangOneParser.Vertex06Context vertex06Context = context.vertex06();
				if (vertex06Context != null) 
				{
					return _factory.Declaration06((Vertex06Green)this.Visit(vertex06Context));
				}
				TestLangOneParser.Arrow06Context arrow06Context = context.arrow06();
				if (arrow06Context != null) 
				{
					return _factory.Declaration06((Arrow06Green)this.Visit(arrow06Context));
				}
				return Declaration06Green.__Missing;
			}
			
			public override GreenNode VisitVertex06(TestLangOneParser.Vertex06Context context)
			{
				if (context == null) return Vertex06Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Vertex06(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow06(TestLangOneParser.Arrow06Context context)
			{
				if (context == null) return Arrow06Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.NameContext sourceContext = context.source;
				NameGreen source = null;
				if (sourceContext != null)
				{
					source = (NameGreen)this.Visit(sourceContext);
				}
				else
				{
					source = NameGreen.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.NameContext targetContext = context.target;
				NameGreen target = null;
				if (targetContext != null)
				{
					target = (NameGreen)this.Visit(targetContext);
				}
				else
				{
					target = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Arrow06(kArrow, source, tArrow, target, tSemicolon);
			}
			
			public override GreenNode VisitTest07(TestLangOneParser.Test07Context context)
			{
				if (context == null) return Test07Green.__Missing;
				InternalSyntaxToken kTest07 = (InternalSyntaxToken)this.VisitTerminal(context.KTest07(), TestLangOneSyntaxKind.KTest07);
				TestLangOneParser.NamespaceDeclaration07Context namespaceDeclaration07Context = context.namespaceDeclaration07();
				NamespaceDeclaration07Green namespaceDeclaration07 = null;
				if (namespaceDeclaration07Context != null)
				{
					namespaceDeclaration07 = (NamespaceDeclaration07Green)this.Visit(namespaceDeclaration07Context);
				}
				else
				{
					namespaceDeclaration07 = NamespaceDeclaration07Green.__Missing;
				}
				return _factory.Test07(kTest07, namespaceDeclaration07);
			}
			
			public override GreenNode VisitNamespaceDeclaration07(TestLangOneParser.NamespaceDeclaration07Context context)
			{
				if (context == null) return NamespaceDeclaration07Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody07Context namespaceBody07Context = context.namespaceBody07();
				NamespaceBody07Green namespaceBody07 = null;
				if (namespaceBody07Context != null)
				{
					namespaceBody07 = (NamespaceBody07Green)this.Visit(namespaceBody07Context);
				}
				else
				{
					namespaceBody07 = NamespaceBody07Green.__Missing;
				}
				return _factory.NamespaceDeclaration07(kNamespace, qualifiedName, namespaceBody07);
			}
			
			public override GreenNode VisitNamespaceBody07(TestLangOneParser.NamespaceBody07Context context)
			{
				if (context == null) return NamespaceBody07Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration07Context[] declaration07Context = context.declaration07();
			    var declaration07Builder = _pool.Allocate<Declaration07Green>();
			    for (int i = 0; i < declaration07Context.Length; i++)
			    {
			        declaration07Builder.Add((Declaration07Green)this.Visit(declaration07Context[i]));
			    }
				var declaration07 = declaration07Builder.ToList();
				_pool.Free(declaration07Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return _factory.NamespaceBody07(tOpenBrace, declaration07, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration07(TestLangOneParser.Declaration07Context context)
			{
				if (context == null) return Declaration07Green.__Missing;
				TestLangOneParser.Vertex07Context vertex07Context = context.vertex07();
				if (vertex07Context != null) 
				{
					return _factory.Declaration07((Vertex07Green)this.Visit(vertex07Context));
				}
				TestLangOneParser.Arrow07Context arrow07Context = context.arrow07();
				if (arrow07Context != null) 
				{
					return _factory.Declaration07((Arrow07Green)this.Visit(arrow07Context));
				}
				return Declaration07Green.__Missing;
			}
			
			public override GreenNode VisitVertex07(TestLangOneParser.Vertex07Context context)
			{
				if (context == null) return Vertex07Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Vertex07(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow07(TestLangOneParser.Arrow07Context context)
			{
				if (context == null) return Arrow07Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.Source07Context source07Context = context.source07();
				Source07Green source07 = null;
				if (source07Context != null)
				{
					source07 = (Source07Green)this.Visit(source07Context);
				}
				else
				{
					source07 = Source07Green.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.Target07Context target07Context = context.target07();
				Target07Green target07 = null;
				if (target07Context != null)
				{
					target07 = (Target07Green)this.Visit(target07Context);
				}
				else
				{
					target07 = Target07Green.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Arrow07(kArrow, source07, tArrow, target07, tSemicolon);
			}
			
			public override GreenNode VisitSource07(TestLangOneParser.Source07Context context)
			{
				if (context == null) return Source07Green.__Missing;
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				return _factory.Source07(name);
			}
			
			public override GreenNode VisitTarget07(TestLangOneParser.Target07Context context)
			{
				if (context == null) return Target07Green.__Missing;
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				return _factory.Target07(name);
			}
			
			public override GreenNode VisitTest08(TestLangOneParser.Test08Context context)
			{
				if (context == null) return Test08Green.__Missing;
				InternalSyntaxToken kTest08 = (InternalSyntaxToken)this.VisitTerminal(context.KTest08(), TestLangOneSyntaxKind.KTest08);
				TestLangOneParser.NamespaceDeclaration08Context namespaceDeclaration08Context = context.namespaceDeclaration08();
				NamespaceDeclaration08Green namespaceDeclaration08 = null;
				if (namespaceDeclaration08Context != null)
				{
					namespaceDeclaration08 = (NamespaceDeclaration08Green)this.Visit(namespaceDeclaration08Context);
				}
				else
				{
					namespaceDeclaration08 = NamespaceDeclaration08Green.__Missing;
				}
				return _factory.Test08(kTest08, namespaceDeclaration08);
			}
			
			public override GreenNode VisitNamespaceDeclaration08(TestLangOneParser.NamespaceDeclaration08Context context)
			{
				if (context == null) return NamespaceDeclaration08Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody08Context namespaceBody08Context = context.namespaceBody08();
				NamespaceBody08Green namespaceBody08 = null;
				if (namespaceBody08Context != null)
				{
					namespaceBody08 = (NamespaceBody08Green)this.Visit(namespaceBody08Context);
				}
				else
				{
					namespaceBody08 = NamespaceBody08Green.__Missing;
				}
				return _factory.NamespaceDeclaration08(kNamespace, qualifiedName, namespaceBody08);
			}
			
			public override GreenNode VisitNamespaceBody08(TestLangOneParser.NamespaceBody08Context context)
			{
				if (context == null) return NamespaceBody08Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration08Context[] declaration08Context = context.declaration08();
			    var declaration08Builder = _pool.Allocate<Declaration08Green>();
			    for (int i = 0; i < declaration08Context.Length; i++)
			    {
			        declaration08Builder.Add((Declaration08Green)this.Visit(declaration08Context[i]));
			    }
				var declaration08 = declaration08Builder.ToList();
				_pool.Free(declaration08Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return _factory.NamespaceBody08(tOpenBrace, declaration08, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration08(TestLangOneParser.Declaration08Context context)
			{
				if (context == null) return Declaration08Green.__Missing;
				TestLangOneParser.Vertex08Context vertex08Context = context.vertex08();
				if (vertex08Context != null) 
				{
					return _factory.Declaration08((Vertex08Green)this.Visit(vertex08Context));
				}
				TestLangOneParser.Arrow08Context arrow08Context = context.arrow08();
				if (arrow08Context != null) 
				{
					return _factory.Declaration08((Arrow08Green)this.Visit(arrow08Context));
				}
				return Declaration08Green.__Missing;
			}
			
			public override GreenNode VisitVertex08(TestLangOneParser.Vertex08Context context)
			{
				if (context == null) return Vertex08Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Vertex08(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow08(TestLangOneParser.Arrow08Context context)
			{
				if (context == null) return Arrow08Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.Source08Context source08Context = context.source08();
				Source08Green source08 = null;
				if (source08Context != null)
				{
					source08 = (Source08Green)this.Visit(source08Context);
				}
				else
				{
					source08 = Source08Green.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.Target08Context target08Context = context.target08();
				Target08Green target08 = null;
				if (target08Context != null)
				{
					target08 = (Target08Green)this.Visit(target08Context);
				}
				else
				{
					target08 = Target08Green.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Arrow08(kArrow, source08, tArrow, target08, tSemicolon);
			}
			
			public override GreenNode VisitSource08(TestLangOneParser.Source08Context context)
			{
				if (context == null) return Source08Green.__Missing;
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				return _factory.Source08(name);
			}
			
			public override GreenNode VisitTarget08(TestLangOneParser.Target08Context context)
			{
				if (context == null) return Target08Green.__Missing;
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				return _factory.Target08(name);
			}
			
			public override GreenNode VisitTest09(TestLangOneParser.Test09Context context)
			{
				if (context == null) return Test09Green.__Missing;
				InternalSyntaxToken kTest09 = (InternalSyntaxToken)this.VisitTerminal(context.KTest09(), TestLangOneSyntaxKind.KTest09);
				TestLangOneParser.NamespaceDeclaration09Context namespaceDeclaration09Context = context.namespaceDeclaration09();
				NamespaceDeclaration09Green namespaceDeclaration09 = null;
				if (namespaceDeclaration09Context != null)
				{
					namespaceDeclaration09 = (NamespaceDeclaration09Green)this.Visit(namespaceDeclaration09Context);
				}
				else
				{
					namespaceDeclaration09 = NamespaceDeclaration09Green.__Missing;
				}
				return _factory.Test09(kTest09, namespaceDeclaration09);
			}
			
			public override GreenNode VisitNamespaceDeclaration09(TestLangOneParser.NamespaceDeclaration09Context context)
			{
				if (context == null) return NamespaceDeclaration09Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody09Context namespaceBody09Context = context.namespaceBody09();
				NamespaceBody09Green namespaceBody09 = null;
				if (namespaceBody09Context != null)
				{
					namespaceBody09 = (NamespaceBody09Green)this.Visit(namespaceBody09Context);
				}
				else
				{
					namespaceBody09 = NamespaceBody09Green.__Missing;
				}
				return _factory.NamespaceDeclaration09(kNamespace, qualifiedName, namespaceBody09);
			}
			
			public override GreenNode VisitNamespaceBody09(TestLangOneParser.NamespaceBody09Context context)
			{
				if (context == null) return NamespaceBody09Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration09Context[] declaration09Context = context.declaration09();
			    var declaration09Builder = _pool.Allocate<Declaration09Green>();
			    for (int i = 0; i < declaration09Context.Length; i++)
			    {
			        declaration09Builder.Add((Declaration09Green)this.Visit(declaration09Context[i]));
			    }
				var declaration09 = declaration09Builder.ToList();
				_pool.Free(declaration09Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return _factory.NamespaceBody09(tOpenBrace, declaration09, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration09(TestLangOneParser.Declaration09Context context)
			{
				if (context == null) return Declaration09Green.__Missing;
				TestLangOneParser.Vertex09Context vertex09Context = context.vertex09();
				if (vertex09Context != null) 
				{
					return _factory.Declaration09((Vertex09Green)this.Visit(vertex09Context));
				}
				TestLangOneParser.Arrow09Context arrow09Context = context.arrow09();
				if (arrow09Context != null) 
				{
					return _factory.Declaration09((Arrow09Green)this.Visit(arrow09Context));
				}
				return Declaration09Green.__Missing;
			}
			
			public override GreenNode VisitVertex09(TestLangOneParser.Vertex09Context context)
			{
				if (context == null) return Vertex09Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Vertex09(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow09(TestLangOneParser.Arrow09Context context)
			{
				if (context == null) return Arrow09Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.NameContext sourceContext = context.source;
				NameGreen source = null;
				if (sourceContext != null)
				{
					source = (NameGreen)this.Visit(sourceContext);
				}
				else
				{
					source = NameGreen.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.NameContext targetContext = context.target;
				NameGreen target = null;
				if (targetContext != null)
				{
					target = (NameGreen)this.Visit(targetContext);
				}
				else
				{
					target = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Arrow09(kArrow, source, tArrow, target, tSemicolon);
			}
			
			public override GreenNode VisitTest10(TestLangOneParser.Test10Context context)
			{
				if (context == null) return Test10Green.__Missing;
				InternalSyntaxToken kTest10 = (InternalSyntaxToken)this.VisitTerminal(context.KTest10(), TestLangOneSyntaxKind.KTest10);
				TestLangOneParser.NamespaceDeclaration10Context namespaceDeclaration10Context = context.namespaceDeclaration10();
				NamespaceDeclaration10Green namespaceDeclaration10 = null;
				if (namespaceDeclaration10Context != null)
				{
					namespaceDeclaration10 = (NamespaceDeclaration10Green)this.Visit(namespaceDeclaration10Context);
				}
				else
				{
					namespaceDeclaration10 = NamespaceDeclaration10Green.__Missing;
				}
				return _factory.Test10(kTest10, namespaceDeclaration10);
			}
			
			public override GreenNode VisitNamespaceDeclaration10(TestLangOneParser.NamespaceDeclaration10Context context)
			{
				if (context == null) return NamespaceDeclaration10Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody10Context namespaceBody10Context = context.namespaceBody10();
				NamespaceBody10Green namespaceBody10 = null;
				if (namespaceBody10Context != null)
				{
					namespaceBody10 = (NamespaceBody10Green)this.Visit(namespaceBody10Context);
				}
				else
				{
					namespaceBody10 = NamespaceBody10Green.__Missing;
				}
				return _factory.NamespaceDeclaration10(kNamespace, qualifiedName, namespaceBody10);
			}
			
			public override GreenNode VisitNamespaceBody10(TestLangOneParser.NamespaceBody10Context context)
			{
				if (context == null) return NamespaceBody10Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration10Context[] declaration10Context = context.declaration10();
			    var declaration10Builder = _pool.Allocate<Declaration10Green>();
			    for (int i = 0; i < declaration10Context.Length; i++)
			    {
			        declaration10Builder.Add((Declaration10Green)this.Visit(declaration10Context[i]));
			    }
				var declaration10 = declaration10Builder.ToList();
				_pool.Free(declaration10Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return _factory.NamespaceBody10(tOpenBrace, declaration10, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration10(TestLangOneParser.Declaration10Context context)
			{
				if (context == null) return Declaration10Green.__Missing;
				TestLangOneParser.Vertex10Context vertex10Context = context.vertex10();
				if (vertex10Context != null) 
				{
					return _factory.Declaration10((Vertex10Green)this.Visit(vertex10Context));
				}
				TestLangOneParser.Arrow10Context arrow10Context = context.arrow10();
				if (arrow10Context != null) 
				{
					return _factory.Declaration10((Arrow10Green)this.Visit(arrow10Context));
				}
				return Declaration10Green.__Missing;
			}
			
			public override GreenNode VisitVertex10(TestLangOneParser.Vertex10Context context)
			{
				if (context == null) return Vertex10Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Vertex10(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow10(TestLangOneParser.Arrow10Context context)
			{
				if (context == null) return Arrow10Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.NameContext sourceContext = context.source;
				NameGreen source = null;
				if (sourceContext != null)
				{
					source = (NameGreen)this.Visit(sourceContext);
				}
				else
				{
					source = NameGreen.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.NameContext targetContext = context.target;
				NameGreen target = null;
				if (targetContext != null)
				{
					target = (NameGreen)this.Visit(targetContext);
				}
				else
				{
					target = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Arrow10(kArrow, source, tArrow, target, tSemicolon);
			}
			
			public override GreenNode VisitTest11(TestLangOneParser.Test11Context context)
			{
				if (context == null) return Test11Green.__Missing;
				InternalSyntaxToken kTest11 = (InternalSyntaxToken)this.VisitTerminal(context.KTest11(), TestLangOneSyntaxKind.KTest11);
			    TestLangOneParser.NamespaceDeclaration11Context[] namespaceDeclaration11Context = context.namespaceDeclaration11();
			    var namespaceDeclaration11Builder = _pool.Allocate<NamespaceDeclaration11Green>();
			    for (int i = 0; i < namespaceDeclaration11Context.Length; i++)
			    {
			        namespaceDeclaration11Builder.Add((NamespaceDeclaration11Green)this.Visit(namespaceDeclaration11Context[i]));
			    }
				var namespaceDeclaration11 = namespaceDeclaration11Builder.ToList();
				_pool.Free(namespaceDeclaration11Builder);
				return _factory.Test11(kTest11, namespaceDeclaration11);
			}
			
			public override GreenNode VisitNamespaceDeclaration11(TestLangOneParser.NamespaceDeclaration11Context context)
			{
				if (context == null) return NamespaceDeclaration11Green.__Missing;
				InternalSyntaxToken kNamespace = (InternalSyntaxToken)this.VisitTerminal(context.KNamespace(), TestLangOneSyntaxKind.KNamespace);
				TestLangOneParser.QualifiedNameContext qualifiedNameContext = context.qualifiedName();
				QualifiedNameGreen qualifiedName = null;
				if (qualifiedNameContext != null)
				{
					qualifiedName = (QualifiedNameGreen)this.Visit(qualifiedNameContext);
				}
				else
				{
					qualifiedName = QualifiedNameGreen.__Missing;
				}
				TestLangOneParser.NamespaceBody11Context namespaceBody11Context = context.namespaceBody11();
				NamespaceBody11Green namespaceBody11 = null;
				if (namespaceBody11Context != null)
				{
					namespaceBody11 = (NamespaceBody11Green)this.Visit(namespaceBody11Context);
				}
				else
				{
					namespaceBody11 = NamespaceBody11Green.__Missing;
				}
				return _factory.NamespaceDeclaration11(kNamespace, qualifiedName, namespaceBody11);
			}
			
			public override GreenNode VisitNamespaceBody11(TestLangOneParser.NamespaceBody11Context context)
			{
				if (context == null) return NamespaceBody11Green.__Missing;
				InternalSyntaxToken tOpenBrace = (InternalSyntaxToken)this.VisitTerminal(context.TOpenBrace(), TestLangOneSyntaxKind.TOpenBrace);
			    TestLangOneParser.Declaration11Context[] declaration11Context = context.declaration11();
			    var declaration11Builder = _pool.Allocate<Declaration11Green>();
			    for (int i = 0; i < declaration11Context.Length; i++)
			    {
			        declaration11Builder.Add((Declaration11Green)this.Visit(declaration11Context[i]));
			    }
				var declaration11 = declaration11Builder.ToList();
				_pool.Free(declaration11Builder);
				InternalSyntaxToken tCloseBrace = (InternalSyntaxToken)this.VisitTerminal(context.TCloseBrace(), TestLangOneSyntaxKind.TCloseBrace);
				return _factory.NamespaceBody11(tOpenBrace, declaration11, tCloseBrace);
			}
			
			public override GreenNode VisitDeclaration11(TestLangOneParser.Declaration11Context context)
			{
				if (context == null) return Declaration11Green.__Missing;
				TestLangOneParser.Vertex11Context vertex11Context = context.vertex11();
				if (vertex11Context != null) 
				{
					return _factory.Declaration11((Vertex11Green)this.Visit(vertex11Context));
				}
				TestLangOneParser.Arrow11Context arrow11Context = context.arrow11();
				if (arrow11Context != null) 
				{
					return _factory.Declaration11((Arrow11Green)this.Visit(arrow11Context));
				}
				return Declaration11Green.__Missing;
			}
			
			public override GreenNode VisitVertex11(TestLangOneParser.Vertex11Context context)
			{
				if (context == null) return Vertex11Green.__Missing;
				InternalSyntaxToken kVertex = (InternalSyntaxToken)this.VisitTerminal(context.KVertex(), TestLangOneSyntaxKind.KVertex);
				TestLangOneParser.NameContext nameContext = context.name();
				NameGreen name = null;
				if (nameContext != null)
				{
					name = (NameGreen)this.Visit(nameContext);
				}
				else
				{
					name = NameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Vertex11(kVertex, name, tSemicolon);
			}
			
			public override GreenNode VisitArrow11(TestLangOneParser.Arrow11Context context)
			{
				if (context == null) return Arrow11Green.__Missing;
				InternalSyntaxToken kArrow = (InternalSyntaxToken)this.VisitTerminal(context.KArrow(), TestLangOneSyntaxKind.KArrow);
				TestLangOneParser.QualifiedNameContext sourceContext = context.source;
				QualifiedNameGreen source = null;
				if (sourceContext != null)
				{
					source = (QualifiedNameGreen)this.Visit(sourceContext);
				}
				else
				{
					source = QualifiedNameGreen.__Missing;
				}
				InternalSyntaxToken tArrow = (InternalSyntaxToken)this.VisitTerminal(context.TArrow(), TestLangOneSyntaxKind.TArrow);
				TestLangOneParser.QualifiedNameContext targetContext = context.target;
				QualifiedNameGreen target = null;
				if (targetContext != null)
				{
					target = (QualifiedNameGreen)this.Visit(targetContext);
				}
				else
				{
					target = QualifiedNameGreen.__Missing;
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon(), TestLangOneSyntaxKind.TSemicolon);
				return _factory.Arrow11(kArrow, source, tArrow, target, tSemicolon);
			}
			
			public override GreenNode VisitName(TestLangOneParser.NameContext context)
			{
				if (context == null) return NameGreen.__Missing;
				TestLangOneParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				else
				{
					identifier = IdentifierGreen.__Missing;
				}
				return _factory.Name(identifier);
			}
			
			public override GreenNode VisitQualifiedName(TestLangOneParser.QualifiedNameContext context)
			{
				if (context == null) return QualifiedNameGreen.__Missing;
				TestLangOneParser.QualifierContext qualifierContext = context.qualifier();
				QualifierGreen qualifier = null;
				if (qualifierContext != null)
				{
					qualifier = (QualifierGreen)this.Visit(qualifierContext);
				}
				else
				{
					qualifier = QualifierGreen.__Missing;
				}
				return _factory.QualifiedName(qualifier);
			}
			
			public override GreenNode VisitQualifier(TestLangOneParser.QualifierContext context)
			{
				if (context == null) return QualifierGreen.__Missing;
			    TestLangOneParser.IdentifierContext[] identifierContext = context.identifier();
			    ITerminalNode[] tDotContext = context.TDot();
			    var identifierBuilder = _pool.AllocateSeparated<IdentifierGreen>();
			    for (int i = 0; i < identifierContext.Length; i++)
			    {
			        identifierBuilder.Add((IdentifierGreen)this.Visit(identifierContext[i]));
			        if (i < tDotContext.Length)
			        {
			            identifierBuilder.AddSeparator((InternalSyntaxToken)this.VisitTerminal(tDotContext[i], TestLangOneSyntaxKind.TDot));
			        }
			    }
				var identifier = identifierBuilder.ToList();
				_pool.Free(identifierBuilder);
				return _factory.Qualifier(identifier);
			}
			
			public override GreenNode VisitIdentifier(TestLangOneParser.IdentifierContext context)
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
				else
				{
					identifier = _factory.MissingToken(SyntaxKind.MissingToken);
				}
				return _factory.Identifier(identifier);
			}
			
			public override GreenNode VisitLiteral(TestLangOneParser.LiteralContext context)
			{
				if (context == null) return LiteralGreen.__Missing;
				TestLangOneParser.NullLiteralContext nullLiteralContext = context.nullLiteral();
				if (nullLiteralContext != null) 
				{
					return _factory.Literal((NullLiteralGreen)this.Visit(nullLiteralContext));
				}
				TestLangOneParser.BooleanLiteralContext booleanLiteralContext = context.booleanLiteral();
				if (booleanLiteralContext != null) 
				{
					return _factory.Literal((BooleanLiteralGreen)this.Visit(booleanLiteralContext));
				}
				TestLangOneParser.IntegerLiteralContext integerLiteralContext = context.integerLiteral();
				if (integerLiteralContext != null) 
				{
					return _factory.Literal((IntegerLiteralGreen)this.Visit(integerLiteralContext));
				}
				TestLangOneParser.DecimalLiteralContext decimalLiteralContext = context.decimalLiteral();
				if (decimalLiteralContext != null) 
				{
					return _factory.Literal((DecimalLiteralGreen)this.Visit(decimalLiteralContext));
				}
				TestLangOneParser.ScientificLiteralContext scientificLiteralContext = context.scientificLiteral();
				if (scientificLiteralContext != null) 
				{
					return _factory.Literal((ScientificLiteralGreen)this.Visit(scientificLiteralContext));
				}
				TestLangOneParser.StringLiteralContext stringLiteralContext = context.stringLiteral();
				if (stringLiteralContext != null) 
				{
					return _factory.Literal((StringLiteralGreen)this.Visit(stringLiteralContext));
				}
				return LiteralGreen.__Missing;
			}
			
			public override GreenNode VisitNullLiteral(TestLangOneParser.NullLiteralContext context)
			{
				if (context == null) return NullLiteralGreen.__Missing;
				InternalSyntaxToken kNull = (InternalSyntaxToken)this.VisitTerminal(context.KNull(), TestLangOneSyntaxKind.KNull);
				return _factory.NullLiteral(kNull);
			}
			
			public override GreenNode VisitBooleanLiteral(TestLangOneParser.BooleanLiteralContext context)
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
			
			public override GreenNode VisitIntegerLiteral(TestLangOneParser.IntegerLiteralContext context)
			{
				if (context == null) return IntegerLiteralGreen.__Missing;
				InternalSyntaxToken lInteger = (InternalSyntaxToken)this.VisitTerminal(context.LInteger(), TestLangOneSyntaxKind.LInteger);
				return _factory.IntegerLiteral(lInteger);
			}
			
			public override GreenNode VisitDecimalLiteral(TestLangOneParser.DecimalLiteralContext context)
			{
				if (context == null) return DecimalLiteralGreen.__Missing;
				InternalSyntaxToken lDecimal = (InternalSyntaxToken)this.VisitTerminal(context.LDecimal(), TestLangOneSyntaxKind.LDecimal);
				return _factory.DecimalLiteral(lDecimal);
			}
			
			public override GreenNode VisitScientificLiteral(TestLangOneParser.ScientificLiteralContext context)
			{
				if (context == null) return ScientificLiteralGreen.__Missing;
				InternalSyntaxToken lScientific = (InternalSyntaxToken)this.VisitTerminal(context.LScientific(), TestLangOneSyntaxKind.LScientific);
				return _factory.ScientificLiteral(lScientific);
			}
			
			public override GreenNode VisitStringLiteral(TestLangOneParser.StringLiteralContext context)
			{
				if (context == null) return StringLiteralGreen.__Missing;
				InternalSyntaxToken lRegularString = (InternalSyntaxToken)this.VisitTerminal(context.LRegularString(), TestLangOneSyntaxKind.LRegularString);
				return _factory.StringLiteral(lRegularString);
			}
        }
    }
    public partial class TestLangOneParser
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
		
		internal class TestContext_Cached : TestContext, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public TestContext_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Test01Context_Cached : Test01Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Test01Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceDeclaration01Context_Cached : NamespaceDeclaration01Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceDeclaration01Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceBody01Context_Cached : NamespaceBody01Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceBody01Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Declaration01Context_Cached : Declaration01Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Declaration01Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Vertex01Context_Cached : Vertex01Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Vertex01Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Arrow01Context_Cached : Arrow01Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Arrow01Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Test02Context_Cached : Test02Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Test02Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceDeclaration02Context_Cached : NamespaceDeclaration02Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceDeclaration02Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceBody02Context_Cached : NamespaceBody02Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceBody02Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Declaration02Context_Cached : Declaration02Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Declaration02Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Vertex02Context_Cached : Vertex02Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Vertex02Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Arrow02Context_Cached : Arrow02Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Arrow02Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Source02Context_Cached : Source02Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Source02Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Target02Context_Cached : Target02Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Target02Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Test03Context_Cached : Test03Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Test03Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceDeclaration03Context_Cached : NamespaceDeclaration03Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceDeclaration03Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceBody03Context_Cached : NamespaceBody03Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceBody03Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Declaration03Context_Cached : Declaration03Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Declaration03Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Vertex03Context_Cached : Vertex03Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Vertex03Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Arrow03Context_Cached : Arrow03Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Arrow03Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Source03Context_Cached : Source03Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Source03Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Target03Context_Cached : Target03Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Target03Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Test04Context_Cached : Test04Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Test04Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceDeclaration04Context_Cached : NamespaceDeclaration04Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceDeclaration04Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceBody04Context_Cached : NamespaceBody04Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceBody04Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Declaration04Context_Cached : Declaration04Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Declaration04Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Vertex04Context_Cached : Vertex04Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Vertex04Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Arrow04Context_Cached : Arrow04Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Arrow04Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Test05Context_Cached : Test05Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Test05Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceDeclaration05Context_Cached : NamespaceDeclaration05Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceDeclaration05Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceBody05Context_Cached : NamespaceBody05Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceBody05Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Declaration05Context_Cached : Declaration05Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Declaration05Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Vertex05Context_Cached : Vertex05Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Vertex05Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Arrow05Context_Cached : Arrow05Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Arrow05Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Test06Context_Cached : Test06Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Test06Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceDeclaration06Context_Cached : NamespaceDeclaration06Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceDeclaration06Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceBody06Context_Cached : NamespaceBody06Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceBody06Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Declaration06Context_Cached : Declaration06Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Declaration06Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Vertex06Context_Cached : Vertex06Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Vertex06Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Arrow06Context_Cached : Arrow06Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Arrow06Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Test07Context_Cached : Test07Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Test07Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceDeclaration07Context_Cached : NamespaceDeclaration07Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceDeclaration07Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceBody07Context_Cached : NamespaceBody07Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceBody07Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Declaration07Context_Cached : Declaration07Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Declaration07Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Vertex07Context_Cached : Vertex07Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Vertex07Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Arrow07Context_Cached : Arrow07Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Arrow07Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Source07Context_Cached : Source07Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Source07Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Target07Context_Cached : Target07Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Target07Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Test08Context_Cached : Test08Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Test08Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceDeclaration08Context_Cached : NamespaceDeclaration08Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceDeclaration08Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceBody08Context_Cached : NamespaceBody08Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceBody08Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Declaration08Context_Cached : Declaration08Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Declaration08Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Vertex08Context_Cached : Vertex08Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Vertex08Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Arrow08Context_Cached : Arrow08Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Arrow08Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Source08Context_Cached : Source08Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Source08Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Target08Context_Cached : Target08Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Target08Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Test09Context_Cached : Test09Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Test09Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceDeclaration09Context_Cached : NamespaceDeclaration09Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceDeclaration09Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceBody09Context_Cached : NamespaceBody09Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceBody09Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Declaration09Context_Cached : Declaration09Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Declaration09Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Vertex09Context_Cached : Vertex09Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Vertex09Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Arrow09Context_Cached : Arrow09Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Arrow09Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Test10Context_Cached : Test10Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Test10Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceDeclaration10Context_Cached : NamespaceDeclaration10Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceDeclaration10Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceBody10Context_Cached : NamespaceBody10Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceBody10Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Declaration10Context_Cached : Declaration10Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Declaration10Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Vertex10Context_Cached : Vertex10Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Vertex10Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Arrow10Context_Cached : Arrow10Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Arrow10Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Test11Context_Cached : Test11Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Test11Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceDeclaration11Context_Cached : NamespaceDeclaration11Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceDeclaration11Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class NamespaceBody11Context_Cached : NamespaceBody11Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public NamespaceBody11Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Declaration11Context_Cached : Declaration11Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Declaration11Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Vertex11Context_Cached : Vertex11Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Vertex11Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
				: base(parent, invokingState)
		    {
		        _cachedNode = cachedNode;
		    }
		    public GreenNode CachedNode => _cachedNode;
		}
		
		internal class Arrow11Context_Cached : Arrow11Context, ICachedRuleContext
		{
		    private GreenNode _cachedNode;
		    public Arrow11Context_Cached(ParserRuleContext parent, int invokingState, GreenNode cachedNode)
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

