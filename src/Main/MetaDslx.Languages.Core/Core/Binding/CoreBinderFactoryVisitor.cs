// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.Core;
using MetaDslx.Languages.Core.Syntax;
using MetaDslx.Languages.Core.Symbols;

using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Core.Model;

namespace MetaDslx.Languages.Core.Binding
{
    public class CoreBinderFactoryVisitor : BinderFactoryVisitor, ICoreSyntaxVisitor<Binder>
    {
		public static object UseQualifier = new object();
		public static object UseTypeReference = new object();
		public static object UseExpression = new object();
		public static object UseBlockStatement = new object();
		public static object UseReturnType = new object();
		public static object UseVariable = new object();
		public static object UseCollection = new object();
		public static object UseStatement = new object();
		public static object UseBefore = new object();
		public static object UseCondition = new object();
		public static object UseAtLoopBottom = new object();
		public static object UseIfTrue = new object();
		public static object UseIfFalse = new object();
		public static object UseKBreak = new object();
		public static object UseKContinue = new object();
		public static object UseKGoto = new object();
		public static object UseIdentifier = new object();
		public static object UseName = new object();
		public static object UseLockedValue = new object();
		public static object UseBody = new object();
		public static object UseReturnedValue = new object();
		public static object UseValue = new object();
		public static object UseFinallyClause = new object();
		public static object UseBareBlockStatement = new object();
		public static object UseHandler = new object();
		public static object UseFilter = new object();
		public static object UseResource = new object();
		public static object UseLiteral = new object();
		public static object UsePostfixIncOrDecOperator = new object();
		public static object UsePrefixIncOrDecOperator = new object();
		public static object UseUnaryOperator = new object();
		public static object UseLeft = new object();
		public static object UseTDotDot = new object();
		public static object UseRight = new object();
		public static object UseMultiplicativeOperator = new object();
		public static object UseAdditiveOperator = new object();
		public static object UseShiftOperator = new object();
		public static object UseRelationalOperator = new object();
		public static object UseKNot = new object();
		public static object UseEqualityOperator = new object();
		public static object UseTAmpersand = new object();
		public static object UseTHat = new object();
		public static object UseTBar = new object();
		public static object UseTAndAlso = new object();
		public static object UseTOrElse = new object();
		public static object UseWhenNull = new object();
		public static object UseWhenTrue = new object();
		public static object UseWhenFalse = new object();
		public static object UseTarget = new object();
		public static object UseCompoundAssignmentOperator = new object();
		public static object UseKConst = new object();
		public static object UseVariableType = new object();
		public static object UseInitializer = new object();
		public static object UseTQuestionDot = new object();
		public static object UseTQuestionOpenBracket = new object();
		public static object UseTPlusPlus = new object();
		public static object UseTMinusMinus = new object();
		public static object UseTPlus = new object();
		public static object UseTMinus = new object();
		public static object UseTExclamation = new object();
		public static object UseTTilde = new object();
		public static object UseTAsterisk = new object();
		public static object UseTSlash = new object();
		public static object UseTPercent = new object();
		public static object UseTLessThan = new object();
		public static object UseTGreaterThan = new object();
		public static object UseTLessThanOrEqual = new object();
		public static object UseTGreaterThanOrEqual = new object();
		public static object UseTEqual = new object();
		public static object UseTNotEqual = new object();
		public static object UseTPlusAssign = new object();
		public static object UseTMinusAssign = new object();
		public static object UseTAsteriskAssign = new object();
		public static object UseTSlashAssign = new object();
		public static object UseTPercentAssign = new object();
		public static object UseTAmpersandAssign = new object();
		public static object UseTHatAssign = new object();
		public static object UseTBarAssign = new object();
		public static object UseTLeftShiftAssign = new object();
		public static object UseTRightShiftAssign = new object();
		public static object UseNamedType = new object();
		public static object UseKObject = new object();
		public static object UseKBool = new object();
		public static object UseKChar = new object();
		public static object UseKSByte = new object();
		public static object UseKByte = new object();
		public static object UseKShort = new object();
		public static object UseKUShort = new object();
		public static object UseKInt = new object();
		public static object UseKUInt = new object();
		public static object UseKLong = new object();
		public static object UseKULong = new object();
		public static object UseKDecimal = new object();
		public static object UseKFloat = new object();
		public static object UseKDouble = new object();
		public static object UseKString = new object();
		public static object UseUsingNamespace = new object();
		public static object UseDeclaration = new object();
		public static object UseMainBlock = new object();
		public static object Use = new object();
		public static object UseAliasDeclaration = new object();
		public static object UseEnumDeclaration = new object();
		public static object UseStructDeclaration = new object();
		public static object UseFunctionDeclaration = new object();
		public static object UseEnumLiteral = new object();
		public static object UseStructField = new object();
		public static object UseFunctionResult = new object();
		public static object UseFunctionParameterList = new object();
		public static object UseFunctionParameter = new object();
		public static object UseSwitchCase = new object();
		public static object UseCatchClause = new object();
		public static object UseCaseClause = new object();
		public static object UseSingleValueCaseClause = new object();
		public static object UseDefaultCaseClause = new object();
		public static object UseTupleArguments = new object();
		public static object UseGenericTypeArguments = new object();
		public static object UseArgumentList = new object();
		public static object UseLambdaBody = new object();
		public static object UseArgumentExpression = new object();
		public static object UseFieldInitializerExpression = new object();
		public static object UseImplicitParameter = new object();
		public static object UseImplicitParameterList = new object();
		public static object UseExplicitParameterList = new object();
		public static object UseExplicitParameter = new object();
		public static object UseVariableDef = new object();
		public static object UseDotOperator = new object();
		public static object UseIndexerOperator = new object();
		public static object UseLeftShiftOperator = new object();
		public static object UseRightShiftOperator = new object();
		public static object UseVoidType = new object();
		public static object UseVarType = new object();
		public static object UsePrimitiveType = new object();
		public static object UseNullLiteral = new object();
		public static object UseBooleanLiteral = new object();
		public static object UseIntegerLiteral = new object();
		public static object UseDecimalLiteral = new object();
		public static object UseScientificLiteral = new object();
		public static object UseStringLiteral = new object();
		public static object UseEnumLiteralList = new object();
		public static object UseUsingHeader = new object();
		public static object UseCatchFilter = new object();
		public static object UseVariableDefList = new object();
		public static object UseFieldInitializerExpressions = new object();
		public static object UseCollectionInitializerExpressions = new object();
		public static object UseDictionaryInitializerExpression = new object();
		public static object UseImplicitLambdaSignature = new object();
		public static object UseExplicitLambdaSignature = new object();
		public static object UseGenericTypeArgument = new object();
		public static object UseInitializerExpression = new object();
		public static object UseLambdaSignature = new object();
		public static object UseDictionaryInitializerExpressions = new object();

        public CoreBinderFactoryVisitor(CoreBinderFactory binderFactory)
			: base(binderFactory)
        {

        }

		public new CoreBinderFactory BinderFactory => (CoreBinderFactory)base.BinderFactory;

        public Binder VisitSkippedTokensTrivia(CoreSkippedTokensTriviaSyntax parent)
        {
            return null;
        }

		
		public Binder VisitMain(MainSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
			    return this.GetCompilationUnitBinder(parent, inUsing: IsInUsing(parent), inScript: InScript);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
			    resultBinder = this.GetCompilationUnitBinder(parent, inUsing: IsInUsing(parent), inScript: InScript);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Members");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(Namespace));
				resultBinder = this.BinderFactory.CreateScopeBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitMainBlock(MainBlockSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(BlockStatement));
				resultBinder = this.BinderFactory.CreateLocalScopeBinder(resultBinder, parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Statements");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitUsingNamespace(UsingNamespaceSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateImportBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitDeclaration(DeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Members");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitAliasDeclaration(AliasDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Qualifier)) use = UseQualifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(Alias));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseQualifier)
				{
					resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent.Qualifier, types: ImmutableArray.Create(typeof(Declaration)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitEnumDeclaration(EnumDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(EnumType));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumLiteralList(EnumLiteralListSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumLiteral(EnumLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Members");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(EnumLiteral));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitStructDeclaration(StructDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(StructType));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitStructField(StructFieldSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Members");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(Field));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "Type");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "DeclaredInitializer");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitFunctionDeclaration(FunctionDeclarationSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.BlockStatement)) use = UseBlockStatement;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(Function));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseBlockStatement)
				{
					resultBinder = this.BinderFactory.CreateLocalScopeBinder(resultBinder, parent.BlockStatement);
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.BlockStatement, name: "Body");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitFunctionParameterList(FunctionParameterListSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Parameters");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitFunctionParameter(FunctionParameterSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Parameters");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(Parameter));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "DeclaredType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "DeclaredInitializer");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitFunctionResult(FunctionResultSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.ReturnType)) use = UseReturnType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Result");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(Parameter));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseReturnType)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.ReturnType, name: "DeclaredType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitEmptyStmt(EmptyStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(EmptyStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitBlockStmt(BlockStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitExprStmt(ExprStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ExpressionStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Expression");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitForeachStmt(ForeachStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Variable)) use = UseVariable;
				if (LookupPosition.IsInNode(this.Position, parent.Collection)) use = UseCollection;
				if (LookupPosition.IsInNode(this.Position, parent.Statement)) use = UseStatement;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ForEachLoopStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseVariable)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Variable, name: "LoopControlVariable");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseCollection)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Collection, name: "Collection");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseStatement)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Statement, name: "Body");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitForStmt(ForStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Before)) use = UseBefore;
				if (LookupPosition.IsInNode(this.Position, parent.Condition)) use = UseCondition;
				if (LookupPosition.IsInNode(this.Position, parent.AtLoopBottom)) use = UseAtLoopBottom;
				if (LookupPosition.IsInNode(this.Position, parent.Statement)) use = UseStatement;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ForLoopStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseBefore)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Before, name: "Before");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseCondition)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Condition, name: "Condition");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseAtLoopBottom)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.AtLoopBottom, name: "AtLoopBottom");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseStatement)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Statement, name: "Body");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitIfStmt(IfStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Condition)) use = UseCondition;
				if (LookupPosition.IsInNode(this.Position, parent.IfTrue)) use = UseIfTrue;
				if (LookupPosition.IsInNode(this.Position, parent.IfFalse)) use = UseIfFalse;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(IfStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseCondition)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Condition, name: "Condition");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseIfTrue)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.IfTrue, name: "IfTrue");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseIfFalse)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.IfFalse, name: "IfFalse");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitBreakStmt(BreakStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.KBreak)) use = UseKBreak;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(JumpStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseKBreak)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.KBreak, name: "JumpKind", value: JumpKind.Break);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitContinueStmt(ContinueStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.KContinue)) use = UseKContinue;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(JumpStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseKContinue)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.KContinue, name: "JumpKind", value: JumpKind.Continue);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitGotoStmt(GotoStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.KGoto)) use = UseKGoto;
				if (LookupPosition.IsInNode(this.Position, parent.Identifier)) use = UseIdentifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(JumpStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseKGoto)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.KGoto, name: "JumpKind", value: JumpKind.GoTo);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseIdentifier)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Identifier, name: "Target");
					resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent.Identifier, types: ImmutableArray.Create(typeof(Label)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitLabeledStmt(LabeledStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Name)) use = UseName;
				if (LookupPosition.IsInNode(this.Position, parent.Statement)) use = UseStatement;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(LabeledStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseName)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Name, name: "Label");
					resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent.Name, type: typeof(Label));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseStatement)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Statement, name: "Statement");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitLockStmt(LockStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.LockedValue)) use = UseLockedValue;
				if (LookupPosition.IsInNode(this.Position, parent.Body)) use = UseBody;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(LockStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLockedValue)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.LockedValue, name: "LockedValue");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseBody)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Body, name: "Body");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitReturnStmt(ReturnStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.ReturnedValue)) use = UseReturnedValue;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ReturnStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseReturnedValue)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.ReturnedValue, name: "ReturnedValue");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitSwitchStmt(SwitchStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Value)) use = UseValue;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(SwitchStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseValue)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Value, name: "Value");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitTryStmt(TryStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Body)) use = UseBody;
				if (LookupPosition.IsInNode(this.Position, parent.FinallyClause)) use = UseFinallyClause;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseBody)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Body, name: "Body");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseFinallyClause)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.FinallyClause, name: "Finally");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitUsingStmt(UsingStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Body)) use = UseBody;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(UsingStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseBody)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Body, name: "Body");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitWhileStmt(WhileStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Condition)) use = UseCondition;
				if (LookupPosition.IsInNode(this.Position, parent.Body)) use = UseBody;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(WhileLoopStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseCondition)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Condition, name: "ConditionIsTop", value: true);
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Condition, name: "Condition");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseBody)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Body, name: "Body");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitDoWhileStmt(DoWhileStmtSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Body)) use = UseBody;
				if (LookupPosition.IsInNode(this.Position, parent.Condition)) use = UseCondition;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(WhileLoopStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseBody)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Body, name: "Body");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseCondition)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Condition, name: "ConditionIsTop", value: false);
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Condition, name: "Condition");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitBlockStatement(BlockStatementSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(BlockStatement));
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Statements");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitBareBlockStatement(BareBlockStatementSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(BlockStatement));
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Statements");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitSwitchCase(SwitchCaseSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.BareBlockStatement)) use = UseBareBlockStatement;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Cases");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(SwitchCase));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseBareBlockStatement)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.BareBlockStatement, name: "Body");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCaseClause(CaseClauseSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Clauses");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitSingleValueCaseClause(SingleValueCaseClauseSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Value)) use = UseValue;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(SingleValueCaseClause));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseValue)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Value, name: "Value");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitDefaultCaseClause(DefaultCaseClauseSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(DefaultCaseClause));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitCatchClause(CatchClauseSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Value)) use = UseValue;
				if (LookupPosition.IsInNode(this.Position, parent.Handler)) use = UseHandler;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Catches");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(CatchClause));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseValue)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Value, name: "ExceptionDeclarationOrExpression");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseHandler)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Handler, name: "Handler");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCatchFilter(CatchFilterSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Filter)) use = UseFilter;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseFilter)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Filter, name: "Filter");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitFinallyClause(FinallyClauseSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitUsingHeader(UsingHeaderSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Resource)) use = UseResource;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseResource)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Resource, name: "Resources");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitExpressionList(ExpressionListSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitParenthesizedExpr(ParenthesizedExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ParenthesizedExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Operand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitTupleExpr(TupleExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(TupleExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitDiscardExpr(DiscardExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(DiscardExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitDefaultExpr(DefaultExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(DefaultValueExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitThisExpr(ThisExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(InstanceReferenceExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitBaseExpr(BaseExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(InstanceReferenceExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLiteralExpr(LiteralExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Literal)) use = UseLiteral;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(LiteralExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLiteral)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Literal, name: "Value");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitIdentifierExpr(IdentifierExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Identifier)) use = UseIdentifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ReferenceExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseIdentifier)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Identifier, name: "ReferencedName");
					resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.Identifier);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitQualifierExpr(QualifierExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
				if (LookupPosition.IsInNode(this.Position, parent.Identifier)) use = UseIdentifier;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ReferenceExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Qualifier");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseIdentifier)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Identifier, name: "ReferencedName");
					resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.Identifier);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitIndexerExpr(IndexerExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(IndexerAccessExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Receiver");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitInvocationExpr(InvocationExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(InvocationExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Receiver");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitTypeofExpr(TypeofExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(TypeOfExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "TypeOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNameofExpr(NameofExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(NameOfExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Argument");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitSizeofExpr(SizeofExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(SizeOfExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "TypeOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCheckedExpr(CheckedExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitUncheckedExpr(UncheckedExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitNewExpr(NewExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ObjectCreationExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "ObjectType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNullForgivingExpr(NullForgivingExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(NullForgivingExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Operand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitPostfixIncOrDecExpr(PostfixIncOrDecExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
				if (LookupPosition.IsInNode(this.Position, parent.PostfixIncOrDecOperator)) use = UsePostfixIncOrDecOperator;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(UnaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Operand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UsePostfixIncOrDecOperator)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.PostfixIncOrDecOperator, name: "OperatorKind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitPrefixIncOrDecExpr(PrefixIncOrDecExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.PrefixIncOrDecOperator)) use = UsePrefixIncOrDecOperator;
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(UnaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UsePrefixIncOrDecOperator)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.PrefixIncOrDecOperator, name: "OperatorKind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Operand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitUnaryExpr(UnaryExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.UnaryOperator)) use = UseUnaryOperator;
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(UnaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseUnaryOperator)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.UnaryOperator, name: "OperatorKind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Operand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitTypeCastExpr(TypeCastExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ConversionExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "TargetType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Operand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitAwaitExpr(AwaitExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(AwaitExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Operation");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitRangeExpr(RangeExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.TDotDot)) use = UseTDotDot;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Left, name: "LeftOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseTDotDot)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TDotDot, name: "OperatorKind");
					resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.TDotDot, value: BinaryOperatorKind.Range);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Right, name: "RightOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitMultExpr(MultExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.MultiplicativeOperator)) use = UseMultiplicativeOperator;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Left, name: "LeftOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseMultiplicativeOperator)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.MultiplicativeOperator, name: "OperatorKind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Right, name: "RightOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitAddExpr(AddExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.AdditiveOperator)) use = UseAdditiveOperator;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Left, name: "LeftOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseAdditiveOperator)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.AdditiveOperator, name: "OperatorKind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Right, name: "RightOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitShiftExpr(ShiftExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.ShiftOperator)) use = UseShiftOperator;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Left, name: "LeftOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseShiftOperator)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.ShiftOperator, name: "OperatorKind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Right, name: "RightOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitRelExpr(RelExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.RelationalOperator)) use = UseRelationalOperator;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Left, name: "LeftOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRelationalOperator)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.RelationalOperator, name: "OperatorKind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Right, name: "RightOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitTypeIsExpr(TypeIsExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
				if (LookupPosition.IsInNode(this.Position, parent.KNot)) use = UseKNot;
				if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
				if (LookupPosition.IsInNode(this.Position, parent.Name)) use = UseName;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(IsTypeExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "ValueOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseKNot)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.KNot, name: "IsNegated", value: true);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseTypeReference)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "TypeOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseName)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Name, name: "DeclaredVariable");
					resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent.Name, type: typeof(Variable));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitTypeAsExpr(TypeAsExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
				if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ConversionExpression));
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "IsTryCast", value: true);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Operand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseTypeReference)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "TargetType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitEqExpr(EqExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.EqualityOperator)) use = UseEqualityOperator;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Left, name: "LeftOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseEqualityOperator)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.EqualityOperator, name: "OperatorKind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Right, name: "RightOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitAndExpr(AndExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.TAmpersand)) use = UseTAmpersand;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Left, name: "LeftOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseTAmpersand)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TAmpersand, name: "OperatorKind");
					resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.TAmpersand, value: BinaryOperatorKind.BitwiseAnd);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Right, name: "RightOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitXorExpr(XorExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.THat)) use = UseTHat;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Left, name: "LeftOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseTHat)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.THat, name: "OperatorKind");
					resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.THat, value: BinaryOperatorKind.BitwiseXor);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Right, name: "RightOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitOrExpr(OrExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.TBar)) use = UseTBar;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Left, name: "LeftOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseTBar)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TBar, name: "OperatorKind");
					resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.TBar, value: BinaryOperatorKind.BitwiseOr);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Right, name: "RightOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitAndAlsoExpr(AndAlsoExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.TAndAlso)) use = UseTAndAlso;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Left, name: "LeftOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseTAndAlso)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TAndAlso, name: "OperatorKind");
					resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.TAndAlso, value: BinaryOperatorKind.LogicalAnd);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Right, name: "RightOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitOrElseExpr(OrElseExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.TOrElse)) use = UseTOrElse;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Left, name: "LeftOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseTOrElse)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TOrElse, name: "OperatorKind");
					resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.TOrElse, value: BinaryOperatorKind.LogicalOr);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Right, name: "RightOperand");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitThrowExpr(ThrowExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ThrowExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Exception");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCoalExpr(CoalExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Value)) use = UseValue;
				if (LookupPosition.IsInNode(this.Position, parent.WhenNull)) use = UseWhenNull;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(CoalesceExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseValue)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Value, name: "Value");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseWhenNull)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.WhenNull, name: "WhenNull");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCondExpr(CondExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Condition)) use = UseCondition;
				if (LookupPosition.IsInNode(this.Position, parent.WhenTrue)) use = UseWhenTrue;
				if (LookupPosition.IsInNode(this.Position, parent.WhenFalse)) use = UseWhenFalse;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ConditionalExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseCondition)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Condition, name: "Condition");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseWhenTrue)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.WhenTrue, name: "WhenTrue");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseWhenFalse)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.WhenFalse, name: "WhenFalse");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitAssignExpr(AssignExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Target)) use = UseTarget;
				if (LookupPosition.IsInNode(this.Position, parent.Value)) use = UseValue;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(AssignmentExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTarget)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Target, name: "Target");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseValue)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Value, name: "Value");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCompAssignExpr(CompAssignExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Target)) use = UseTarget;
				if (LookupPosition.IsInNode(this.Position, parent.CompoundAssignmentOperator)) use = UseCompoundAssignmentOperator;
				if (LookupPosition.IsInNode(this.Position, parent.Value)) use = UseValue;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(CompoundAssignmentExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTarget)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Target, name: "Target");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseCompoundAssignmentOperator)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.CompoundAssignmentOperator, name: "OperatorKind");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseValue)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Value, name: "Value");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitLambdaExpr(LambdaExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(LambdaExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitVarDefExpr(VarDefExprSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.KConst)) use = UseKConst;
				if (LookupPosition.IsInNode(this.Position, parent.VariableType)) use = UseVariableType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(VariableDeclarationExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseKConst)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.KConst, name: "IsConst", value: true);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseVariableType)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.VariableType, name: "DeclaredType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitTupleArguments(TupleArgumentsSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Arguments");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitArgumentList(ArgumentListSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Arguments");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitArgumentExpression(ArgumentExpressionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(Argument));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Value");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitInitializerExpression(InitializerExpressionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitFieldInitializerExpressions(FieldInitializerExpressionsSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitFieldInitializerExpression(FieldInitializerExpressionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Identifier)) use = UseIdentifier;
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(AssignmentExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseIdentifier)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Identifier, name: "Target");
					resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent.Identifier, types: ImmutableArray.Create(typeof(FieldLikeMember)));
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Value");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCollectionInitializerExpressions(CollectionInitializerExpressionsSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitDictionaryInitializerExpressions(DictionaryInitializerExpressionsSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitDictionaryInitializerExpression(DictionaryInitializerExpressionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLambdaSignature(LambdaSignatureSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitImplicitLambdaSignature(ImplicitLambdaSignatureSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitImplicitParameterList(ImplicitParameterListSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Parameters");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitImplicitParameter(ImplicitParameterSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Parameters");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(Parameter));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitExplicitLambdaSignature(ExplicitLambdaSignatureSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitExplicitParameterList(ExplicitParameterListSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Parameters");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitExplicitParameter(ExplicitParameterSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Parameters");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(Parameter));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "Type");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitLambdaBody(LambdaBodySyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Expression)) use = UseExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Body");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseExpression)
				{
					resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent.Expression, type: typeof(ExpressionStatement));
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Expression, name: "Expression");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitVariableDefList(VariableDefListSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitVariableDef(VariableDefSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Initializer)) use = UseInitializer;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Variables");
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(Variable));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseInitializer)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.Initializer, name: "DeclaredInitializer");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitDotOperator(DotOperatorSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.DotOperator)) use = UseDotOperator;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseDotOperator)
				{
					switch (parent.DotOperator.GetKind().Switch())
					{
						case CoreSyntaxKind.TDot:
							break;
						case CoreSyntaxKind.TQuestionDot:
							resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.DotOperator, name: "IsNullConditional", value: true);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitIndexerOperator(IndexerOperatorSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.IndexerOperator)) use = UseIndexerOperator;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseIndexerOperator)
				{
					switch (parent.IndexerOperator.GetKind().Switch())
					{
						case CoreSyntaxKind.TOpenBracket:
							break;
						case CoreSyntaxKind.TQuestionOpenBracket:
							resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.IndexerOperator, name: "IsNullConditional", value: true);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitPostfixIncOrDecOperator(PostfixIncOrDecOperatorSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.PostfixIncOrDecOperator)) use = UsePostfixIncOrDecOperator;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UsePostfixIncOrDecOperator)
				{
					switch (parent.PostfixIncOrDecOperator.GetKind().Switch())
					{
						case CoreSyntaxKind.TPlusPlus:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PostfixIncOrDecOperator, value: UnaryOperatorKind.PostfixIncrement);
							break;
						case CoreSyntaxKind.TMinusMinus:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PostfixIncOrDecOperator, value: UnaryOperatorKind.PostfixDecrement);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitPrefixIncOrDecOperator(PrefixIncOrDecOperatorSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.PrefixIncOrDecOperator)) use = UsePrefixIncOrDecOperator;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UsePrefixIncOrDecOperator)
				{
					switch (parent.PrefixIncOrDecOperator.GetKind().Switch())
					{
						case CoreSyntaxKind.TPlusPlus:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrefixIncOrDecOperator, value: UnaryOperatorKind.PrefixIncrement);
							break;
						case CoreSyntaxKind.TMinusMinus:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrefixIncOrDecOperator, value: UnaryOperatorKind.PrefixDecrement);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitUnaryOperator(UnaryOperatorSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.UnaryOperator)) use = UseUnaryOperator;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseUnaryOperator)
				{
					switch (parent.UnaryOperator.GetKind().Switch())
					{
						case CoreSyntaxKind.TPlus:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.UnaryOperator, value: UnaryOperatorKind.UnaryPlus);
							break;
						case CoreSyntaxKind.TMinus:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.UnaryOperator, value: UnaryOperatorKind.UnaryMinus);
							break;
						case CoreSyntaxKind.TExclamation:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.UnaryOperator, value: UnaryOperatorKind.LogicalNegation);
							break;
						case CoreSyntaxKind.TTilde:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.UnaryOperator, value: UnaryOperatorKind.BitwiseComplement);
							break;
						case CoreSyntaxKind.THat:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.UnaryOperator, value: UnaryOperatorKind.IndexFromEnd);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitMultiplicativeOperator(MultiplicativeOperatorSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.MultiplicativeOperator)) use = UseMultiplicativeOperator;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseMultiplicativeOperator)
				{
					switch (parent.MultiplicativeOperator.GetKind().Switch())
					{
						case CoreSyntaxKind.TAsterisk:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.MultiplicativeOperator, value: BinaryOperatorKind.Multiplication);
							break;
						case CoreSyntaxKind.TSlash:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.MultiplicativeOperator, value: BinaryOperatorKind.Division);
							break;
						case CoreSyntaxKind.TPercent:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.MultiplicativeOperator, value: BinaryOperatorKind.Remainder);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitAdditiveOperator(AdditiveOperatorSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.AdditiveOperator)) use = UseAdditiveOperator;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "OperatorKind");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseAdditiveOperator)
				{
					switch (parent.AdditiveOperator.GetKind().Switch())
					{
						case CoreSyntaxKind.TPlus:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.AdditiveOperator, value: BinaryOperatorKind.Addition);
							break;
						case CoreSyntaxKind.TMinus:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.AdditiveOperator, value: BinaryOperatorKind.Subtraction);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitShiftOperator(ShiftOperatorSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLeftShiftOperator(LeftShiftOperatorSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent, value: BinaryOperatorKind.LeftShift);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitRightShiftOperator(RightShiftOperatorSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent, value: BinaryOperatorKind.RightShift);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitRelationalOperator(RelationalOperatorSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.RelationalOperator)) use = UseRelationalOperator;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseRelationalOperator)
				{
					switch (parent.RelationalOperator.GetKind().Switch())
					{
						case CoreSyntaxKind.TLessThan:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.RelationalOperator, value: BinaryOperatorKind.LessThan);
							break;
						case CoreSyntaxKind.TGreaterThan:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.RelationalOperator, value: BinaryOperatorKind.GreaterThan);
							break;
						case CoreSyntaxKind.TLessThanOrEqual:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.RelationalOperator, value: BinaryOperatorKind.LessThanOrEqual);
							break;
						case CoreSyntaxKind.TGreaterThanOrEqual:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.RelationalOperator, value: BinaryOperatorKind.GreaterThanOrEqual);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitEqualityOperator(EqualityOperatorSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.EqualityOperator)) use = UseEqualityOperator;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseEqualityOperator)
				{
					switch (parent.EqualityOperator.GetKind().Switch())
					{
						case CoreSyntaxKind.TEqual:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.EqualityOperator, value: BinaryOperatorKind.Equal);
							break;
						case CoreSyntaxKind.TNotEqual:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.EqualityOperator, value: BinaryOperatorKind.NotEqual);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCompoundAssignmentOperator(CompoundAssignmentOperatorSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.CompoundAssignmentOperator)) use = UseCompoundAssignmentOperator;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseCompoundAssignmentOperator)
				{
					switch (parent.CompoundAssignmentOperator.GetKind().Switch())
					{
						case CoreSyntaxKind.TPlusAssign:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.CompoundAssignmentOperator, value: BinaryOperatorKind.Addition);
							break;
						case CoreSyntaxKind.TMinusAssign:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.CompoundAssignmentOperator, value: BinaryOperatorKind.Subtraction);
							break;
						case CoreSyntaxKind.TAsteriskAssign:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.CompoundAssignmentOperator, value: BinaryOperatorKind.Multiplication);
							break;
						case CoreSyntaxKind.TSlashAssign:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.CompoundAssignmentOperator, value: BinaryOperatorKind.Division);
							break;
						case CoreSyntaxKind.TPercentAssign:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.CompoundAssignmentOperator, value: BinaryOperatorKind.Remainder);
							break;
						case CoreSyntaxKind.TAmpersandAssign:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.CompoundAssignmentOperator, value: BinaryOperatorKind.LogicalAnd);
							break;
						case CoreSyntaxKind.THatAssign:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.CompoundAssignmentOperator, value: BinaryOperatorKind.LogicalXor);
							break;
						case CoreSyntaxKind.TBarAssign:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.CompoundAssignmentOperator, value: BinaryOperatorKind.LogicalOr);
							break;
						case CoreSyntaxKind.TLeftShiftAssign:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.CompoundAssignmentOperator, value: BinaryOperatorKind.LeftShift);
							break;
						case CoreSyntaxKind.TRightShiftAssign:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.CompoundAssignmentOperator, value: BinaryOperatorKind.RightShift);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitReturnType(ReturnTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitVariableType(VariableTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitPrimitiveTypeRef(PrimitiveTypeRefSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(DataType)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitGenericTypeRef(GenericTypeRefSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.NamedType)) use = UseNamedType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(DataType)));
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(GenericTypeReference));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseNamedType)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.NamedType, name: "ReferencedType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNamedTypeRef(NamedTypeRefSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(DataType)));
				resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(ClassifierType), typeof(EnumType), typeof(DelegateType)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitArrayTypeRef(ArrayTypeRefSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(DataType)));
				resultBinder = this.BinderFactory.CreateDefineBinder(resultBinder, parent, type: typeof(ArrayType));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "ElementType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNullableTypeRef(NullableTypeRefSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TypeReference)) use = UseTypeReference;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(DataType)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "InnerType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNamedType(NamedTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(ClassifierType), typeof(EnumType), typeof(DelegateType)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitGenericTypeArguments(GenericTypeArgumentsSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "TypeArguments");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitGenericTypeArgument(GenericTypeArgumentSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitPrimitiveType(PrimitiveTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.PrimitiveType)) use = UsePrimitiveType;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UsePrimitiveType)
				{
					switch (parent.PrimitiveType.GetKind().Switch())
					{
						case CoreSyntaxKind.KObject:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: CoreInstance.Object);
							break;
						case CoreSyntaxKind.KBool:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: CoreInstance.Boolean);
							break;
						case CoreSyntaxKind.KChar:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: CoreInstance.Char);
							break;
						case CoreSyntaxKind.KSByte:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: CoreInstance.SByte);
							break;
						case CoreSyntaxKind.KByte:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: CoreInstance.Byte);
							break;
						case CoreSyntaxKind.KShort:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: CoreInstance.Int16);
							break;
						case CoreSyntaxKind.KUShort:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: CoreInstance.UInt16);
							break;
						case CoreSyntaxKind.KInt:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: CoreInstance.Int32);
							break;
						case CoreSyntaxKind.KUInt:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: CoreInstance.UInt32);
							break;
						case CoreSyntaxKind.KLong:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: CoreInstance.Int64);
							break;
						case CoreSyntaxKind.KULong:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: CoreInstance.UInt64);
							break;
						case CoreSyntaxKind.KDecimal:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: CoreInstance.Decimal);
							break;
						case CoreSyntaxKind.KFloat:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: CoreInstance.Single);
							break;
						case CoreSyntaxKind.KDouble:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: CoreInstance.Double);
							break;
						case CoreSyntaxKind.KString:
							resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent.PrimitiveType, value: CoreInstance.String);
							break;
						default:
							break;
					}
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitVoidType(VoidTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent, value: CoreInstance.Void);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitVarType(VarTypeSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent, value: CoreInstance.VarType);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitName(NameSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateNameBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQualifiedName(QualifiedNameSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateNameBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQualifier(QualifierSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateQualifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitIdentifier(IdentifierSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateIdentifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitLiteral(LiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitNullLiteral(NullLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitBooleanLiteral(BooleanLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Type", value: CoreInstance.Boolean);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitIntegerLiteral(IntegerLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Type", value: CoreInstance.Int32);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitDecimalLiteral(DecimalLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Type", value: CoreInstance.Decimal);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitScientificLiteral(ScientificLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Type", value: CoreInstance.Double);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitStringLiteral(StringLiteralSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.BinderFactory.CreatePropertyBinder(resultBinder, parent, name: "Type", value: CoreInstance.String);
				resultBinder = this.BinderFactory.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
    }
}

