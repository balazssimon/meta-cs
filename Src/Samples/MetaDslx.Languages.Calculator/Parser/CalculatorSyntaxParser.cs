// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MetaDslx.Languages.Antlr4Roslyn.Parser;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.MetaModel;
using MetaDslx.Compiler.Utilities;
namespace MetaDslx.Languages.Calculator.Syntax.InternalSyntax
{
    public class CalculatorSyntaxParser : Antlr4SyntaxParser<CalculatorLexer, CalculatorParser>
    {
        public CalculatorSyntaxParser(
            SourceText text,
            CalculatorParseOptions options,
            SyntaxNode oldTree, 
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default(CancellationToken))
            : base(text, CalculatorLanguage.Instance, options, oldTree, changes, cancellationToken)
        {
        }
        public override DirectiveStack Directives
        {
            get
            {
                return DirectiveStack.Empty;
            }
        }
        protected override CalculatorLexer CreateLexer(AntlrInputStream inputStream)
        {
            return new CalculatorLexer(inputStream);
        }
        protected override CalculatorParser CreateParser(CommonTokenStream tokenStream)
        {
            return new CalculatorParser(tokenStream);
        }
        public override GreenNode Parse()
        {
            return this.ParseMain();
        }
        internal MainGreen ParseMain()
        {
            Antlr4ToRoslynVisitor visitor = new Antlr4ToRoslynVisitor(this);
            var tree = this.Parser.main();
            return (MainGreen)visitor.Visit(tree);
        }
        private class Antlr4ToRoslynVisitor : CalculatorParserBaseVisitor<GreenNode>
        {
            private CalculatorLanguage language;
			private CalculatorGreenFactory factory;
            private CalculatorSyntaxParser syntaxParser;
			private IList<IToken> tokens;
            private IToken lastToken;
            public Antlr4ToRoslynVisitor(CalculatorSyntaxParser syntaxParser)
            {
                this.language = CalculatorLanguage.Instance;
				this.factory = language.InternalSyntaxFactory;
                this.syntaxParser = syntaxParser;
				this.tokens = this.syntaxParser.CommonTokenStream.GetTokens();
                this.lastToken = null;
            }
            public override GreenNode VisitTerminal(ITerminalNode node)
            {
                GreenNode result = this.syntaxParser.VisitTerminal(node, this.lastToken);
                if (result != null && !result.IsMissing)
                {
                    this.lastToken = node.Symbol;
                }
                return result;
            }
			
			public override GreenNode VisitMain(CalculatorParser.MainContext context)
			{
				if (context == null) return null;
			    CalculatorParser.StatementLineContext[] statementLineContext = context.statementLine();
			    ArrayBuilder<StatementLineGreen> statementLineBuilder = ArrayBuilder<StatementLineGreen>.GetInstance(statementLineContext.Length);
			    for (int i = 0; i < statementLineContext.Length; i++)
			    {
			        statementLineBuilder.Add((StatementLineGreen)this.Visit(statementLineContext[i]));
			    }
				InternalSyntaxNodeList statementLine = InternalSyntaxNodeList.Create(statementLineBuilder.ToArrayAndFree());
				InternalSyntaxToken eof = (InternalSyntaxToken)this.VisitTerminal(context.Eof());
				return this.factory.Main(statementLine, eof, true);
			}
			
			public override GreenNode VisitStatementLine(CalculatorParser.StatementLineContext context)
			{
				if (context == null) return null;
				CalculatorParser.StatementContext statementContext = context.statement();
				StatementGreen statement = null;
				if (statementContext != null)
				{
					statement = (StatementGreen)this.Visit(statementContext);
				}
				InternalSyntaxToken tSemicolon = (InternalSyntaxToken)this.VisitTerminal(context.TSemicolon());
				return this.factory.StatementLine(statement, tSemicolon, true);
			}
			
			public override GreenNode VisitStatement(CalculatorParser.StatementContext context)
			{
				if (context == null) return null;
				CalculatorParser.AssignmentContext assignmentContext = context.assignment();
				if (assignmentContext != null) 
				{
					return this.factory.Statement((AssignmentGreen)this.Visit(assignmentContext), true);
				}
				CalculatorParser.ExpressionContext expressionContext = context.expression();
				if (expressionContext != null) 
				{
					return this.factory.Statement((ExpressionGreen)this.Visit(expressionContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitAssignment(CalculatorParser.AssignmentContext context)
			{
				if (context == null) return null;
				CalculatorParser.IdentifierContext identifierContext = context.identifier();
				IdentifierGreen identifier = null;
				if (identifierContext != null)
				{
					identifier = (IdentifierGreen)this.Visit(identifierContext);
				}
				InternalSyntaxToken tAssign = (InternalSyntaxToken)this.VisitTerminal(context.TAssign());
				CalculatorParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null)
				{
					expression = (ExpressionGreen)this.Visit(expressionContext);
				}
				return this.factory.Assignment(identifier, tAssign, expression, true);
			}
			
			public override GreenNode VisitParenExpression(CalculatorParser.ParenExpressionContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken tOpenParen = (InternalSyntaxToken)this.VisitTerminal(context.TOpenParen());
				CalculatorParser.ExpressionContext expressionContext = context.expression();
				ExpressionGreen expression = null;
				if (expressionContext != null)
				{
					expression = (ExpressionGreen)this.Visit(expressionContext);
				}
				InternalSyntaxToken tCloseParen = (InternalSyntaxToken)this.VisitTerminal(context.TCloseParen());
				return this.factory.ParenExpression(tOpenParen, expression, tCloseParen, true);
			}
			
			public override GreenNode VisitMulOrDivExpression(CalculatorParser.MulOrDivExpressionContext context)
			{
				if (context == null) return null;
				CalculatorParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null)
				{
					left = (ExpressionGreen)this.Visit(leftContext);
				}
				InternalSyntaxToken _operator = null;
				if (context.TMul() != null)
				{
					_operator = (InternalSyntaxToken)this.VisitTerminal(context.TMul());
				}
				else 	if (context.TDiv() != null)
				{
					_operator = (InternalSyntaxToken)this.VisitTerminal(context.TDiv());
				}
				CalculatorParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null)
				{
					right = (ExpressionGreen)this.Visit(rightContext);
				}
				return this.factory.MulOrDivExpression(left, _operator, right, true);
			}
			
			public override GreenNode VisitAddOrSubExpression(CalculatorParser.AddOrSubExpressionContext context)
			{
				if (context == null) return null;
				CalculatorParser.ExpressionContext leftContext = context.left;
				ExpressionGreen left = null;
				if (leftContext != null)
				{
					left = (ExpressionGreen)this.Visit(leftContext);
				}
				InternalSyntaxToken _operator = null;
				if (context.TAdd() != null)
				{
					_operator = (InternalSyntaxToken)this.VisitTerminal(context.TAdd());
				}
				else 	if (context.TSub() != null)
				{
					_operator = (InternalSyntaxToken)this.VisitTerminal(context.TSub());
				}
				CalculatorParser.ExpressionContext rightContext = context.right;
				ExpressionGreen right = null;
				if (rightContext != null)
				{
					right = (ExpressionGreen)this.Visit(rightContext);
				}
				return this.factory.AddOrSubExpression(left, _operator, right, true);
			}
			
			public override GreenNode VisitPrintExpression(CalculatorParser.PrintExpressionContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken kPrint = (InternalSyntaxToken)this.VisitTerminal(context.KPrint());
				CalculatorParser.ArgsContext argsContext = context.args();
				ArgsGreen args = null;
				if (argsContext != null)
				{
					args = (ArgsGreen)this.Visit(argsContext);
				}
				return this.factory.PrintExpression(kPrint, args, true);
			}
			
			public override GreenNode VisitValueExpression(CalculatorParser.ValueExpressionContext context)
			{
				if (context == null) return null;
				CalculatorParser.ValueContext valueContext = context.value();
				ValueGreen value = null;
				if (valueContext != null)
				{
					value = (ValueGreen)this.Visit(valueContext);
				}
				return this.factory.ValueExpression(value, true);
			}
			
			public override GreenNode VisitArgs(CalculatorParser.ArgsContext context)
			{
				if (context == null) return null;
			    CalculatorParser.ArgContext[] argContext = context.arg();
			    ITerminalNode[] tCommaContext = context.TComma();
			    ArrayBuilder<GreenNode> argBuilder = ArrayBuilder<GreenNode>.GetInstance(argContext.Length+tCommaContext.Length);
			    for (int i = 0; i < argContext.Length; i++)
			    {
			        argBuilder.Add((ArgGreen)this.Visit(argContext[i]));
			        if (i < tCommaContext.Length)
			        {
			            argBuilder.Add((InternalSyntaxToken)this.VisitTerminal(tCommaContext[i]));
			        }
			    }
				InternalSeparatedSyntaxNodeList arg = InternalSeparatedSyntaxNodeList.Create(argBuilder.ToArrayAndFree());
				return this.factory.Args(arg, true);
			}
			
			public override GreenNode VisitValue(CalculatorParser.ValueContext context)
			{
				if (context == null) return null;
				CalculatorParser.IdentifierContext identifierContext = context.identifier();
				if (identifierContext != null) 
				{
					return this.factory.Value((IdentifierGreen)this.Visit(identifierContext), true);
				}
				CalculatorParser.StringContext _stringContext = context.@string();
				if (_stringContext != null) 
				{
					return this.factory.Value((StringGreen)this.Visit(_stringContext), true);
				}
				CalculatorParser.IntegerContext integerContext = context.integer();
				if (integerContext != null) 
				{
					return this.factory.Value((IntegerGreen)this.Visit(integerContext), true);
				}
				return null;
			}
			
			public override GreenNode VisitIdentifier(CalculatorParser.IdentifierContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken id = (InternalSyntaxToken)this.VisitTerminal(context.ID());
				return this.factory.Identifier(id, true);
			}
			
			public override GreenNode VisitString(CalculatorParser.StringContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken _string = (InternalSyntaxToken)this.VisitTerminal(context.STRING());
				return this.factory.String(_string, true);
			}
			
			public override GreenNode VisitInteger(CalculatorParser.IntegerContext context)
			{
				if (context == null) return null;
				InternalSyntaxToken _int = (InternalSyntaxToken)this.VisitTerminal(context.INT());
				return this.factory.Integer(_int, true);
			}
			
			public override GreenNode VisitArg(CalculatorParser.ArgContext context)
			{
				if (context == null) return null;
				CalculatorParser.ValueContext valueContext = context.value();
				ValueGreen value = null;
				if (valueContext != null)
				{
					value = (ValueGreen)this.Visit(valueContext);
				}
				return this.factory.Arg(value, true);
			}
        }
    }
}

