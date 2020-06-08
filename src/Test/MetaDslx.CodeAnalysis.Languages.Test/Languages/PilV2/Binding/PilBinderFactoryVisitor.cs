// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
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
using PilV2;
using PilV2.Syntax;
using PilV2.Symbols;

namespace PilV2.Binding
{
    public class PilBinderFactoryVisitor : BinderFactoryVisitor, IPilSyntaxVisitor<Binder>
    {
		public static object UseTypeReference = new object();
		public static object UseExpression = new object();
		public static object UsePortName = new object();
		public static object UseQueryName = new object();
		public static object UseIdentifier = new object();
		public static object UseCondition = new object();
		public static object UseConditionalExpression = new object();
		public static object UseLeftSide = new object();
		public static object UseAssertion = new object();
		public static object UseKAccept = new object();
		public static object UseKRefuse = new object();
		public static object UseKCancel = new object();
		public static object UseForkRequestIdentifier = new object();
		public static object UseRequestStatement = new object();
		public static object UseVariableDeclaration = new object();
		public static object UseValue = new object();
		public static object UseLeft = new object();
		public static object UseOpMulDiv = new object();
		public static object UseRight = new object();
		public static object UseOpAddSub = new object();
		public static object UseOpMinus = new object();
		public static object UseArithmeticExpressionTerminator = new object();
		public static object UseTAsterisk = new object();
		public static object UseTSlash = new object();
		public static object UseTPlus = new object();
		public static object UseTMinus = new object();
		public static object UseArithmeticExpression = new object();
		public static object UseAndAlsoOp = new object();
		public static object UseOrElseOp = new object();
		public static object UseOpExcl = new object();
		public static object UseConditionalExpressionTerminator = new object();
		public static object UseOp = new object();
		public static object UseTEqual = new object();
		public static object UseTNotEqual = new object();
		public static object UseTLessThan = new object();
		public static object UseTGreaterThan = new object();
		public static object UseTLessThanOrEqual = new object();
		public static object UseTGreaterThanOrEqual = new object();
		public static object UseTerminalExpression = new object();
		public static object UseExpressionList = new object();
		public static object UseTypeDefDeclaration = new object();
		public static object UseExternalParameterDeclaration = new object();
		public static object UseEnumDeclaration = new object();
		public static object UseObjectDeclaration = new object();
		public static object UseFunctionDeclaration = new object();
		public static object UseQueryDeclaration = new object();
		public static object UseName = new object();
		public static object Use = new object();
		public static object UseEnumLiterals = new object();
		public static object UseEnumLiteral = new object();
		public static object UseObjectExternalParameters = new object();
		public static object UseObjectFields = new object();
		public static object UseObjectFunctions = new object();
		public static object UsePort = new object();
		public static object UseComment = new object();
		public static object UseStatements = new object();
		public static object UseFunctionParams = new object();
		public static object UseParam = new object();
		public static object UseQueryExternalParameters = new object();
		public static object UseQueryField = new object();
		public static object UseQueryObject = new object();
		public static object UseEndName = new object();
		public static object UseQueryRequestParams = new object();
		public static object UseQueryObjectField = new object();
		public static object UseQueryObjectFunction = new object();
		public static object UseQueryObjectEvent = new object();
		public static object UseInput = new object();
		public static object UseTrigger = new object();
		public static object UseInputPort = new object();
		public static object UseVariableDeclarationStatement = new object();
		public static object UseForkStatement = new object();
		public static object UseForkRequestStatement = new object();
		public static object UseIfStatement = new object();
		public static object UseResponseStatement = new object();
		public static object UseCancelStatement = new object();
		public static object UseAssignmentStatement = new object();
		public static object UseCaseBranch = new object();
		public static object UseElseBranch = new object();
		public static object UseIfBranch = new object();
		public static object UseRequestArguments = new object();
		public static object UseResponseStatementKind = new object();
		public static object UseCancelStatementKind = new object();
		public static object UseAcceptBranch = new object();
		public static object UseRefuseBranch = new object();
		public static object UseCancelBranch = new object();
		public static object UseElementOfExpression = new object();
		public static object UseComparisonExpression = new object();
		public static object UseComparisonOperator = new object();
		public static object UseElementOfValue = new object();
		public static object UseVariableReference = new object();
		public static object UseFunctionCallExpression = new object();
		public static object UseLiteral = new object();
		public static object UseVariableReferenceIdentifier = new object();
		public static object UseBuiltInType = new object();
		public static object UseQualifier = new object();
		public static object UseDeclaration = new object();
		public static object UseObjectHeader = new object();
		public static object UsePorts = new object();
		public static object UseFunctionHeader = new object();
		public static object UseQueryHeader = new object();
		public static object UseInputPortList = new object();
		public static object UseTriggerVar = new object();
		public static object UseStatement = new object();
		public static object UseElseIfBranch = new object();
		public static object UseCallRequest = new object();
		public static object UseForkRequestVariable = new object();
		public static object UseElementOfValueList = new object();
		public static object UseTriggerVarList = new object();

        public PilBinderFactoryVisitor(BinderFactory symbolBuilder)
			: base(symbolBuilder)
        {

        }

        /// <summary>
        /// Returns binder that binds usings and aliases 
        /// </summary>
        /// <param name="unit">
        /// Specify <see cref="LanguageSyntaxNode"/> imports in the corresponding syntax node, or
        /// <see cref="CompilationUnitSyntax"/> for top-level imports.
        /// </param>
        /// <param name="inUsing">True if the binder will be used to bind a using directive.</param>
        public override Binder GetImportsBinder(LanguageSyntaxNode unit, bool inUsing)
        {
            if (unit.Kind == PilSyntaxKind.Main)
            {
                return this.GetCompilationUnitBinder(unit, inUsing: inUsing, inScript: InScript);
            }
            else
            {
                // TODO:MetaDslx - non-compilation-unit imports
                return null;
            }
        }

        public Binder VisitSkippedTokensTrivia(PilSkippedTokensTriviaSyntax parent)
        {
            return null;
        }

		
		public Binder VisitMain(MainSyntax parent)
		{
			return this.GetCompilationUnitBinder(parent, inUsing: IsInUsing(parent), inScript: InScript);
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
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitTypeDefDeclaration(TypeDefDeclarationSyntax parent)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(TypeAlias));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "TargetType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitExternalParameterDeclaration(ExternalParameterDeclarationSyntax parent)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(ExternalParameter));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "Type");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseExpression)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Expression, name: "DefaultValue");
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(PilEnum));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitEnumLiterals(EnumLiteralsSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Literals");
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(EnumLiteral));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitObjectDeclaration(ObjectDeclarationSyntax parent)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(PilObject));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitObjectHeader(ObjectHeaderSyntax parent)
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
		
		public Binder VisitPorts(PortsSyntax parent)
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
		
		public Binder VisitPort(PortSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Ports");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(Port));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitObjectExternalParameters(ObjectExternalParametersSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "ExternalParameters");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitObjectFields(ObjectFieldsSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Fields");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitObjectFunctions(ObjectFunctionsSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Functions");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
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
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(Function));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitFunctionHeader(FunctionHeaderSyntax parent)
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
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "ReturnType");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitFunctionParams(FunctionParamsSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Parameters");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitParam(ParamSyntax parent)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(Variable));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "Type");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitQueryDeclaration(QueryDeclarationSyntax parent)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(Query));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQueryHeader(QueryHeaderSyntax parent)
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
		
		public Binder VisitQueryRequestParams(QueryRequestParamsSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "RequestParameters");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQueryAcceptParams(QueryAcceptParamsSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "AcceptParameters");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQueryRefuseParams(QueryRefuseParamsSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "RefuseParameters");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQueryCancelParams(QueryCancelParamsSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "CancelParameters");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQueryExternalParameters(QueryExternalParametersSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "ExternalParameters");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQueryField(QueryFieldSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Fields");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQueryFunction(QueryFunctionSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Functions");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQueryObject(QueryObjectSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Objects");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(QueryObject));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQueryObjectField(QueryObjectFieldSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Fields");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQueryObjectFunction(QueryObjectFunctionSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Functions");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQueryObjectEvent(QueryObjectEventSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Events");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitInput(InputSyntax parent)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(InputEvent));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitInputPortList(InputPortListSyntax parent)
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
		
		public Binder VisitInputPort(InputPortSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.PortName)) use = UsePortName;
				if (LookupPosition.IsInNode(this.Position, parent.QueryName)) use = UseQueryName;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Ports");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(RequestPort));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UsePortName)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.PortName, name: "PortName");
					resultBinder = this.CreateValueBinder(resultBinder, parent.PortName);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseQueryName)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.QueryName, name: "QueryName");
					resultBinder = this.CreateValueBinder(resultBinder, parent.QueryName);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitTrigger(TriggerSyntax parent)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(Trigger));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitTriggerVarList(TriggerVarListSyntax parent)
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
		
		public Binder VisitTriggerVar(TriggerVarSyntax parent)
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
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseIdentifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Identifier, name: "TriggerVariables");
					resultBinder = this.CreateValueBinder(resultBinder, parent.Identifier);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitStatements(StatementsSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Statements");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitStatement(StatementSyntax parent)
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
		
		public Binder VisitForkStatement(ForkStatementSyntax parent)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(ForkStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseExpression)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Expression, name: "SwitchValue");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCaseBranch(CaseBranchSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Condition)) use = UseCondition;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Branches");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(Branch));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseCondition)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Condition, name: "Value");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitElseBranch(ElseBranchSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Branches");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(Branch));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitIfStatement(IfStatementSyntax parent)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(ForkStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitIfBranch(IfBranchSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.ConditionalExpression)) use = UseConditionalExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Branches");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(Branch));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseConditionalExpression)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.ConditionalExpression, name: "Value");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitElseIfBranch(ElseIfBranchSyntax parent)
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
		
		public Binder VisitRequestStatement(RequestStatementSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.LeftSide)) use = UseLeftSide;
				if (LookupPosition.IsInNode(this.Position, parent.Assertion)) use = UseAssertion;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(RequestStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeftSide)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.LeftSide, name: "RequestVariable");
					resultBinder = this.CreateValueBinder(resultBinder, parent.LeftSide);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseAssertion)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Assertion, name: "Assertion");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCallRequest(CallRequestSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.PortName)) use = UsePortName;
				if (LookupPosition.IsInNode(this.Position, parent.QueryName)) use = UseQueryName;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UsePortName)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.PortName, name: "PortName");
					resultBinder = this.CreateValueBinder(resultBinder, parent.PortName);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseQueryName)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.QueryName, name: "QueryName");
					resultBinder = this.CreateValueBinder(resultBinder, parent.QueryName);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitRequestArguments(RequestArgumentsSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Arguments");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitResponseStatement(ResponseStatementSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Assertion)) use = UseAssertion;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(ResponseStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseAssertion)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Assertion, name: "Assertion");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCancelStatement(CancelStatementSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.PortName)) use = UsePortName;
				if (LookupPosition.IsInNode(this.Position, parent.Assertion)) use = UseAssertion;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(ResponseStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UsePortName)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.PortName, name: "PortName");
					resultBinder = this.CreateValueBinder(resultBinder, parent.PortName);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseAssertion)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Assertion, name: "Assertion");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitAssertion(AssertionSyntax parent)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(AssertStatement));
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Condition");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitResponseStatementKind(ResponseStatementKindSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Kind");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitCancelStatementKind(CancelStatementKindSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.KCancel)) use = UseKCancel;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Kind");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseKCancel)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.KCancel, name: "Kind");
					resultBinder = this.CreateValueBinder(resultBinder, parent.KCancel, value: ResponseKind.Cancel);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitForkRequestStatement(ForkRequestStatementSyntax parent)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(ForkRequestStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitForkRequestVariable(ForkRequestVariableSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.ForkRequestIdentifier)) use = UseForkRequestIdentifier;
				if (LookupPosition.IsInNode(this.Position, parent.RequestStatement)) use = UseRequestStatement;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseForkRequestIdentifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.ForkRequestIdentifier, name: "SwitchVariable");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRequestStatement)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.RequestStatement, name: "SwitchRequest");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitForkRequestIdentifier(ForkRequestIdentifierSyntax parent)
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
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseIdentifier)
				{
					resultBinder = this.CreateValueBinder(resultBinder, parent.Identifier);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitAcceptBranch(AcceptBranchSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.KAccept)) use = UseKAccept;
				if (LookupPosition.IsInNode(this.Position, parent.Condition)) use = UseCondition;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Branches");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(ForkRequestBranch));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseKAccept)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.KAccept, name: "Kind", value: ResponseKind.Accept);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseCondition)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Condition, name: "Condition");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitRefuseBranch(RefuseBranchSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.KRefuse)) use = UseKRefuse;
				if (LookupPosition.IsInNode(this.Position, parent.Condition)) use = UseCondition;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Branches");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(ForkRequestBranch));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseKRefuse)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.KRefuse, name: "Kind", value: ResponseKind.Refuse);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseCondition)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Condition, name: "Condition");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitCancelBranch(CancelBranchSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.KCancel)) use = UseKCancel;
				if (LookupPosition.IsInNode(this.Position, parent.Condition)) use = UseCondition;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Branches");
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(ForkRequestBranch));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseKCancel)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.KCancel, name: "Kind", value: ResponseKind.Cancel);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseCondition)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Condition, name: "Condition");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.VariableDeclaration)) use = UseVariableDeclaration;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(VariableDeclarationStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseVariableDeclaration)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.VariableDeclaration, name: "Variable");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitVariableDeclaration(VariableDeclarationSyntax parent)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(Variable));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTypeReference)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.TypeReference, name: "Type");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseExpression)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Expression, name: "DefaultValue");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitAssignmentStatement(AssignmentStatementSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.LeftSide)) use = UseLeftSide;
				if (LookupPosition.IsInNode(this.Position, parent.Value)) use = UseValue;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(AssignmentStatement));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeftSide)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.LeftSide, name: "LeftSide");
					resultBinder = this.CreateValueBinder(resultBinder, parent.LeftSide);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseValue)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Value, name: "Value");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitLeftSide(LeftSideSyntax parent)
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
		
		public Binder VisitExpression(ExpressionSyntax parent)
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
		
		public Binder VisitMulDivExpression(MulDivExpressionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.OpMulDiv)) use = UseOpMulDiv;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Left, name: "Left");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseOpMulDiv)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.OpMulDiv, name: "Operator");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Right, name: "Right");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitPlusMinusExpression(PlusMinusExpressionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.OpAddSub)) use = UseOpAddSub;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Left, name: "Left");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseOpAddSub)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.OpAddSub, name: "Operator");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Right, name: "Right");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNegateExpression(NegateExpressionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.OpMinus)) use = UseOpMinus;
				if (LookupPosition.IsInNode(this.Position, parent.ArithmeticExpressionTerminator)) use = UseArithmeticExpressionTerminator;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(UnaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseOpMinus)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.OpMinus, name: "Operator");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseArithmeticExpressionTerminator)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.ArithmeticExpressionTerminator, name: "Inner");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitSimpleArithmeticExpression(SimpleArithmeticExpressionSyntax parent)
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
		
		public Binder VisitOpMulDiv(OpMulDivSyntax parent)
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
		
		public Binder VisitOpAddSub(OpAddSubSyntax parent)
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
		
		public Binder VisitParenArithmeticExpression(ParenArithmeticExpressionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.ArithmeticExpression)) use = UseArithmeticExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(ParenthesizedExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseArithmeticExpression)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.ArithmeticExpression, name: "Inner");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitTerminalArithmeticExpression(TerminalArithmeticExpressionSyntax parent)
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
		
		public Binder VisitOpMinus(OpMinusSyntax parent)
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
				resultBinder = this.CreateValueBinder(resultBinder, parent, value: UnaryOperator.Minus);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitAndExpression(AndExpressionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.AndAlsoOp)) use = UseAndAlsoOp;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Left, name: "Left");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseAndAlsoOp)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.AndAlsoOp, name: "Operator");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Right, name: "Right");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitOrExpression(OrExpressionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.OrElseOp)) use = UseOrElseOp;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Left, name: "Left");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseOrElseOp)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.OrElseOp, name: "Operator");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Right, name: "Right");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitNotExpression(NotExpressionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.OpExcl)) use = UseOpExcl;
				if (LookupPosition.IsInNode(this.Position, parent.ConditionalExpressionTerminator)) use = UseConditionalExpressionTerminator;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(UnaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseOpExcl)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.OpExcl, name: "Operator");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseConditionalExpressionTerminator)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.ConditionalExpressionTerminator, name: "Inner");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitSimpleConditionalExpression(SimpleConditionalExpressionSyntax parent)
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
		
		public Binder VisitAndAlsoOp(AndAlsoOpSyntax parent)
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
				resultBinder = this.CreateValueBinder(resultBinder, parent, value: BinaryOperator.AndAlso);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitOrElseOp(OrElseOpSyntax parent)
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
				resultBinder = this.CreateValueBinder(resultBinder, parent, value: BinaryOperator.OrElse);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitOpExcl(OpExclSyntax parent)
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
				resultBinder = this.CreateValueBinder(resultBinder, parent, value: UnaryOperator.Negate);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitParenConditionalExpression(ParenConditionalExpressionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.ConditionalExpression)) use = UseConditionalExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(ParenthesizedExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseConditionalExpression)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.ConditionalExpression, name: "Inner");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitElementOfConditionalExpression(ElementOfConditionalExpressionSyntax parent)
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
		
		public Binder VisitComparisonConditionalExpression(ComparisonConditionalExpressionSyntax parent)
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
		
		public Binder VisitTerminalComparisonExpression(TerminalComparisonExpressionSyntax parent)
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
		
		public Binder VisitComparisonExpression(ComparisonExpressionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Left)) use = UseLeft;
				if (LookupPosition.IsInNode(this.Position, parent.Op)) use = UseOp;
				if (LookupPosition.IsInNode(this.Position, parent.Right)) use = UseRight;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(BinaryExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseLeft)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Left, name: "Left");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseOp)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Op, name: "Operator");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseRight)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Right, name: "Right");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitComparisonOperator(ComparisonOperatorSyntax parent)
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
		
		public Binder VisitElementOfExpression(ElementOfExpressionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.TerminalExpression)) use = UseTerminalExpression;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(ElementOfExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseTerminalExpression)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.TerminalExpression, name: "Value");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitElementOfValueList(ElementOfValueListSyntax parent)
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
		
		public Binder VisitElementOfValue(ElementOfValueSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Set");
				resultBinder = this.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitTerminalExpression(TerminalExpressionSyntax parent)
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
		
		public Binder VisitFunctionCallExpression(FunctionCallExpressionSyntax parent)
		{
		    if (!parent.FullSpan.Contains(this.Position))
		    {
		        return VisitParent(parent);
		    }
			object use = null;
			if (this.ForChild)
			{
				if (LookupPosition.IsInNode(this.Position, parent.Identifier)) use = UseIdentifier;
				if (LookupPosition.IsInNode(this.Position, parent.ExpressionList)) use = UseExpressionList;
			}
			Binder resultBinder = null;
			if (!this.BinderFactory.TryGetBinder(parent, use, out resultBinder))
			{
				resultBinder = VisitParent(parent);
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(FunctionCallExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseIdentifier)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.Identifier, name: "Name");
					resultBinder = this.CreateValueBinder(resultBinder, parent.Identifier);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
				if (use == UseExpressionList)
				{
					resultBinder = this.CreatePropertyBinder(resultBinder, parent.ExpressionList, name: "Arguments");
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitVariableReference(VariableReferenceSyntax parent)
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(ReferenceExpression));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitVariableReferenceIdentifier(VariableReferenceIdentifierSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Qualifier");
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
				if (use == UseIdentifier)
				{
					resultBinder = this.CreateValueBinder(resultBinder, parent.Identifier);
					this.BinderFactory.TryAddBinder(parent, use, ref resultBinder);
				}
			}
			return resultBinder;
		}
		
		public Binder VisitComment(CommentSyntax parent)
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
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Comment");
				resultBinder = this.CreateValueBinder(resultBinder, parent);
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
				resultBinder = this.CreateSymbolDefBinder(resultBinder, parent, type: typeof(LiteralExpression));
				resultBinder = this.CreatePropertyBinder(resultBinder, parent, name: "Value");
				resultBinder = this.CreateValueBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitTypeReference(TypeReferenceSyntax parent)
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
				resultBinder = this.CreateSymbolUseBinder(resultBinder, parent, types: ImmutableArray.Create(typeof(NamedType)));
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitBuiltInType(BuiltInTypeSyntax parent)
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
				resultBinder = this.CreateIdentifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitQualifierList(QualifierListSyntax parent)
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
				resultBinder = this.CreateQualifierBinder(resultBinder, parent);
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
				resultBinder = this.CreateNameBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitIdentifierList(IdentifierListSyntax parent)
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
				resultBinder = this.CreateIdentifierBinder(resultBinder, parent);
				this.BinderFactory.TryAddBinder(parent, null, ref resultBinder);
			}
			return resultBinder;
		}
		
		public Binder VisitResultIdentifier(ResultIdentifierSyntax parent)
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
    }
}

