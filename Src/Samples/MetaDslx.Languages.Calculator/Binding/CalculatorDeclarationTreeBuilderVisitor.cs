// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Binding;
using MetaDslx.Compiler.Declarations;
using MetaDslx.Languages.Calculator.Syntax;

namespace MetaDslx.Languages.Calculator.Binding
{
	public class CalculatorDeclarationTreeBuilderVisitor : DeclarationTreeBuilderVisitor, ICalculatorSyntaxVisitor
	{
        protected CalculatorDeclarationTreeBuilderVisitor(CalculatorSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
            : base(syntaxTree, scriptClassName, isSubmission)
        {
        }

        public static RootSingleDeclaration ForTree(
            CalculatorSyntaxTree syntaxTree,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new CalculatorDeclarationTreeBuilderVisitor(syntaxTree, scriptClassName, isSubmission);
            return builder.CreateRoot(syntaxTree.GetRoot(), null);
        }
		
		public virtual void VisitMain(MainSyntax node)
		{
		}
		
		public virtual void VisitStatementLine(StatementLineSyntax node)
		{
		}
		
		public virtual void VisitStatement(StatementSyntax node)
		{
		}
		
		public virtual void VisitAssignment(AssignmentSyntax node)
		{
		}
		
		public virtual void VisitParenExpression(ParenExpressionSyntax node)
		{
		}
		
		public virtual void VisitMulOrDivExpression(MulOrDivExpressionSyntax node)
		{
		}
		
		public virtual void VisitAddOrSubExpression(AddOrSubExpressionSyntax node)
		{
		}
		
		public virtual void VisitPrintExpression(PrintExpressionSyntax node)
		{
		}
		
		public virtual void VisitValueExpression(ValueExpressionSyntax node)
		{
		}
		
		public virtual void VisitArgs(ArgsSyntax node)
		{
		}
		
		public virtual void VisitValue(ValueSyntax node)
		{
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
		}
		
		public virtual void VisitString(StringSyntax node)
		{
		}
		
		public virtual void VisitInteger(IntegerSyntax node)
		{
		}
		
		public virtual void VisitArg(ArgSyntax node)
		{
		}
	}
}

