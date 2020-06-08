// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using PilV2;
using PilV2.Syntax;
using PilV2.Symbols;

namespace PilV2.Binding
{
	public class PilDeclarationTreeBuilderVisitor : DeclarationTreeBuilderVisitor, IPilSyntaxVisitor
	{
        protected PilDeclarationTreeBuilderVisitor(PilSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
            : base(syntaxTree, scriptClassName, isSubmission)
        {
        }

        public static RootSingleDeclaration ForTree(
            PilSyntaxTree syntaxTree,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new PilDeclarationTreeBuilderVisitor(syntaxTree, scriptClassName, isSubmission);
            return builder.CreateRoot(syntaxTree.GetRoot(), null);
        }

		public virtual void VisitSkippedTokensTrivia(PilSkippedTokensTriviaSyntax node)
		{
		}
		
		public virtual void VisitMain(MainSyntax node)
		{
			if (node.Declaration != null)
			{
				foreach (var child in node.Declaration)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
			this.Visit(node.TypeDefDeclaration);
			this.Visit(node.ExternalParameterDeclaration);
			this.Visit(node.EnumDeclaration);
			this.Visit(node.ObjectDeclaration);
			this.Visit(node.FunctionDeclaration);
			this.Visit(node.QueryDeclaration);
		}
		
		public virtual void VisitTypeDefDeclaration(TypeDefDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(TypeAlias));
			try
			{
				this.Visit(node.Name);
				this.BeginProperty(node.TypeReference, name: "TargetType");
				try
				{
					this.Visit(node.TypeReference);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitExternalParameterDeclaration(ExternalParameterDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(ExternalParameter));
			try
			{
				this.Visit(node.Name);
				this.BeginProperty(node.TypeReference, name: "Type");
				try
				{
					this.Visit(node.TypeReference);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Expression, name: "DefaultValue");
				try
				{
					this.Visit(node.Expression);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(PilEnum));
			try
			{
				this.Visit(node.Name);
				this.Visit(node.EnumLiterals);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitEnumLiterals(EnumLiteralsSyntax node)
		{
			this.BeginProperty(node, name: "Literals");
			try
			{
				if (node.EnumLiteral != null)
				{
					foreach (var child in node.EnumLiteral)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitEnumLiteral(EnumLiteralSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(EnumLiteral));
			try
			{
				this.Visit(node.Name);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitObjectDeclaration(ObjectDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(PilObject));
			try
			{
				this.Visit(node.ObjectHeader);
				this.Visit(node.ObjectExternalParameters);
				this.Visit(node.ObjectFields);
				this.Visit(node.ObjectFunctions);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitObjectHeader(ObjectHeaderSyntax node)
		{
			this.Visit(node.Name);
			this.Visit(node.Ports);
		}
		
		public virtual void VisitPorts(PortsSyntax node)
		{
			if (node.Port != null)
			{
				foreach (var child in node.Port)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitPort(PortSyntax node)
		{
			this.BeginProperty(node, name: "Ports");
			try
			{
				this.BeginSymbolDef(node, type: typeof(Port));
				try
				{
					this.Visit(node.Name);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitObjectExternalParameters(ObjectExternalParametersSyntax node)
		{
			this.BeginProperty(node, name: "ExternalParameters");
			try
			{
				if (node.ExternalParameterDeclaration != null)
				{
					foreach (var child in node.ExternalParameterDeclaration)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitObjectFields(ObjectFieldsSyntax node)
		{
			this.BeginProperty(node, name: "Fields");
			try
			{
				if (node.VariableDeclaration != null)
				{
					foreach (var child in node.VariableDeclaration)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitObjectFunctions(ObjectFunctionsSyntax node)
		{
			this.BeginProperty(node, name: "Functions");
			try
			{
				if (node.FunctionDeclaration != null)
				{
					foreach (var child in node.FunctionDeclaration)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitFunctionDeclaration(FunctionDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Function));
			try
			{
				this.Visit(node.FunctionHeader);
				this.Visit(node.Comment);
				this.Visit(node.Statements);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitFunctionHeader(FunctionHeaderSyntax node)
		{
			this.Visit(node.Name);
			this.Visit(node.FunctionParams);
			this.BeginProperty(node.TypeReference, name: "ReturnType");
			try
			{
				this.Visit(node.TypeReference);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitFunctionParams(FunctionParamsSyntax node)
		{
			this.BeginProperty(node, name: "Parameters");
			try
			{
				if (node.Param != null)
				{
					foreach (var child in node.Param)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitParam(ParamSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Variable));
			try
			{
				this.Visit(node.Name);
				this.BeginProperty(node.TypeReference, name: "Type");
				try
				{
					this.Visit(node.TypeReference);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitQueryDeclaration(QueryDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Query));
			try
			{
				this.Visit(node.QueryHeader);
				this.Visit(node.Comment);
				if (node.QueryExternalParameters != null)
				{
					foreach (var child in node.QueryExternalParameters)
					{
				        this.Visit(child);
					}
				}
				if (node.QueryField != null)
				{
					foreach (var child in node.QueryField)
					{
				        this.Visit(child);
					}
				}
				if (node.FunctionDeclaration != null)
				{
					foreach (var child in node.FunctionDeclaration)
					{
				        this.Visit(child);
					}
				}
				if (node.QueryObject != null)
				{
					foreach (var child in node.QueryObject)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.EndName);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitQueryHeader(QueryHeaderSyntax node)
		{
			this.Visit(node.Name);
			this.Visit(node.QueryRequestParams);
		}
		
		public virtual void VisitQueryRequestParams(QueryRequestParamsSyntax node)
		{
			this.BeginProperty(node, name: "RequestParameters");
			try
			{
				if (node.Param != null)
				{
					foreach (var child in node.Param)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitQueryAcceptParams(QueryAcceptParamsSyntax node)
		{
			this.BeginProperty(node, name: "AcceptParameters");
			try
			{
				if (node.Param != null)
				{
					foreach (var child in node.Param)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitQueryRefuseParams(QueryRefuseParamsSyntax node)
		{
			this.BeginProperty(node, name: "RefuseParameters");
			try
			{
				if (node.Param != null)
				{
					foreach (var child in node.Param)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitQueryCancelParams(QueryCancelParamsSyntax node)
		{
			this.BeginProperty(node, name: "CancelParameters");
			try
			{
				if (node.Param != null)
				{
					foreach (var child in node.Param)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitQueryExternalParameters(QueryExternalParametersSyntax node)
		{
			this.BeginProperty(node, name: "ExternalParameters");
			try
			{
				this.Visit(node.ExternalParameterDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitQueryField(QueryFieldSyntax node)
		{
			this.BeginProperty(node, name: "Fields");
			try
			{
				this.Visit(node.VariableDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitQueryFunction(QueryFunctionSyntax node)
		{
			this.BeginProperty(node, name: "Functions");
			try
			{
				this.Visit(node.FunctionDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitQueryObject(QueryObjectSyntax node)
		{
			this.BeginProperty(node, name: "Objects");
			try
			{
				this.BeginSymbolDef(node, type: typeof(QueryObject));
				try
				{
					this.Visit(node.Name);
					this.Visit(node.Comment);
					if (node.QueryObjectField != null)
					{
						foreach (var child in node.QueryObjectField)
						{
					        this.Visit(child);
						}
					}
					if (node.QueryObjectFunction != null)
					{
						foreach (var child in node.QueryObjectFunction)
						{
					        this.Visit(child);
						}
					}
					if (node.QueryObjectEvent != null)
					{
						foreach (var child in node.QueryObjectEvent)
						{
					        this.Visit(child);
						}
					}
					this.Visit(node.EndName);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitQueryObjectField(QueryObjectFieldSyntax node)
		{
			this.BeginProperty(node, name: "Fields");
			try
			{
				this.Visit(node.VariableDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitQueryObjectFunction(QueryObjectFunctionSyntax node)
		{
			this.BeginProperty(node, name: "Functions");
			try
			{
				this.Visit(node.FunctionDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitQueryObjectEvent(QueryObjectEventSyntax node)
		{
			this.BeginProperty(node, name: "Events");
			try
			{
				this.Visit(node.Input);
				this.Visit(node.Trigger);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitInput(InputSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(InputEvent));
			try
			{
				this.Visit(node.InputPortList);
				this.Visit(node.Comment);
				this.Visit(node.Statements);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitInputPortList(InputPortListSyntax node)
		{
			if (node.InputPort != null)
			{
				foreach (var child in node.InputPort)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitInputPort(InputPortSyntax node)
		{
			this.BeginProperty(node, name: "Ports");
			try
			{
				this.BeginSymbolDef(node, type: typeof(RequestPort));
				try
				{
					this.BeginProperty(node.PortName, name: "PortName");
					try
					{
						this.Visit(node.PortName);
					}
					finally
					{
						this.EndProperty();
					}
					this.BeginProperty(node.QueryName, name: "QueryName");
					try
					{
						this.Visit(node.QueryName);
					}
					finally
					{
						this.EndProperty();
					}
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitTrigger(TriggerSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Trigger));
			try
			{
				this.Visit(node.TriggerVarList);
				this.Visit(node.Comment);
				this.Visit(node.Statements);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitTriggerVarList(TriggerVarListSyntax node)
		{
			if (node.TriggerVar != null)
			{
				foreach (var child in node.TriggerVar)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitTriggerVar(TriggerVarSyntax node)
		{
			this.BeginProperty(node.Identifier, name: "TriggerVariables");
			try
			{
				this.Visit(node.Identifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitStatements(StatementsSyntax node)
		{
			this.BeginProperty(node, name: "Statements");
			try
			{
				if (node.Statement != null)
				{
					foreach (var child in node.Statement)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitStatement(StatementSyntax node)
		{
			this.Visit(node.VariableDeclarationStatement);
			this.Visit(node.RequestStatement);
			this.Visit(node.ForkStatement);
			this.Visit(node.ForkRequestStatement);
			this.Visit(node.IfStatement);
			this.Visit(node.ResponseStatement);
			this.Visit(node.CancelStatement);
			this.Visit(node.AssignmentStatement);
		}
		
		public virtual void VisitForkStatement(ForkStatementSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(ForkStatement));
			try
			{
				this.BeginProperty(node.Expression, name: "SwitchValue");
				try
				{
					this.Visit(node.Expression);
				}
				finally
				{
					this.EndProperty();
				}
				if (node.CaseBranch != null)
				{
					foreach (var child in node.CaseBranch)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.ElseBranch);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitCaseBranch(CaseBranchSyntax node)
		{
			this.BeginProperty(node, name: "Branches");
			try
			{
				this.BeginSymbolDef(node, type: typeof(Branch));
				try
				{
					this.BeginProperty(node.Condition, name: "Value");
					try
					{
						this.Visit(node.Condition);
					}
					finally
					{
						this.EndProperty();
					}
					this.Visit(node.Comment);
					this.Visit(node.Statements);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitElseBranch(ElseBranchSyntax node)
		{
			this.BeginProperty(node, name: "Branches");
			try
			{
				this.BeginSymbolDef(node, type: typeof(Branch));
				try
				{
					this.Visit(node.Comment);
					this.Visit(node.Statements);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitIfStatement(IfStatementSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(ForkStatement));
			try
			{
				this.Visit(node.IfBranch);
				if (node.ElseIfBranch != null)
				{
					foreach (var child in node.ElseIfBranch)
					{
				        this.Visit(child);
					}
				}
				if (node.ElseBranch != null)
				{
					foreach (var child in node.ElseBranch)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitIfBranch(IfBranchSyntax node)
		{
			this.BeginProperty(node, name: "Branches");
			try
			{
				this.BeginSymbolDef(node, type: typeof(Branch));
				try
				{
					this.BeginProperty(node.ConditionalExpression, name: "Value");
					try
					{
						this.Visit(node.ConditionalExpression);
					}
					finally
					{
						this.EndProperty();
					}
					this.Visit(node.Comment);
					this.Visit(node.Statements);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitElseIfBranch(ElseIfBranchSyntax node)
		{
			this.Visit(node.IfBranch);
		}
		
		public virtual void VisitRequestStatement(RequestStatementSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(RequestStatement));
			try
			{
				this.BeginProperty(node.LeftSide, name: "RequestVariable");
				try
				{
					this.Visit(node.LeftSide);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.CallRequest);
				this.BeginProperty(node.Assertion, name: "Assertion");
				try
				{
					this.Visit(node.Assertion);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitCallRequest(CallRequestSyntax node)
		{
			this.BeginProperty(node.PortName, name: "PortName");
			try
			{
				this.Visit(node.PortName);
			}
			finally
			{
				this.EndProperty();
			}
			this.BeginProperty(node.QueryName, name: "QueryName");
			try
			{
				this.Visit(node.QueryName);
			}
			finally
			{
				this.EndProperty();
			}
			this.Visit(node.RequestArguments);
		}
		
		public virtual void VisitRequestArguments(RequestArgumentsSyntax node)
		{
			this.BeginProperty(node, name: "Arguments");
			try
			{
				this.Visit(node.ExpressionList);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitResponseStatement(ResponseStatementSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(ResponseStatement));
			try
			{
				this.Visit(node.ResponseStatementKind);
				this.BeginProperty(node.Assertion, name: "Assertion");
				try
				{
					this.Visit(node.Assertion);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitCancelStatement(CancelStatementSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(ResponseStatement));
			try
			{
				this.Visit(node.CancelStatementKind);
				this.BeginProperty(node.PortName, name: "PortName");
				try
				{
					this.Visit(node.PortName);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Assertion, name: "Assertion");
				try
				{
					this.Visit(node.Assertion);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitAssertion(AssertionSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(AssertStatement));
			try
			{
				this.BeginProperty(node, name: "Condition");
				try
				{
					this.Visit(node.Expression);
					this.Visit(node.Comment);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitResponseStatementKind(ResponseStatementKindSyntax node)
		{
			this.BeginProperty(node, name: "Kind");
			try
			{
				switch (node.ResponseStatementKind.GetKind().Switch())
				{
					case PilSyntaxKind.KAccept:
						break;
					case PilSyntaxKind.KRefuse:
						break;
					default:
						break;
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitCancelStatementKind(CancelStatementKindSyntax node)
		{
			this.BeginProperty(node, name: "Kind");
			try
			{
				switch (node.KCancel.GetKind().Switch())
				{
					default:
						break;
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitForkRequestStatement(ForkRequestStatementSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(ForkRequestStatement));
			try
			{
				this.Visit(node.ForkRequestVariable);
				this.Visit(node.AcceptBranch);
				this.Visit(node.RefuseBranch);
				this.Visit(node.CancelBranch);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitForkRequestVariable(ForkRequestVariableSyntax node)
		{
			this.BeginProperty(node.ForkRequestIdentifier, name: "SwitchVariable");
			try
			{
				this.Visit(node.ForkRequestIdentifier);
			}
			finally
			{
				this.EndProperty();
			}
			this.BeginProperty(node.RequestStatement, name: "SwitchRequest");
			try
			{
				this.Visit(node.RequestStatement);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitForkRequestIdentifier(ForkRequestIdentifierSyntax node)
		{
			this.Visit(node.Identifier);
		}
		
		public virtual void VisitAcceptBranch(AcceptBranchSyntax node)
		{
			this.BeginProperty(node, name: "Branches");
			try
			{
				this.BeginSymbolDef(node, type: typeof(ForkRequestBranch));
				try
				{
					switch (node.KAccept.GetKind().Switch())
					{
						default:
							break;
					}
					this.BeginProperty(node.Condition, name: "Condition");
					try
					{
						this.Visit(node.Condition);
					}
					finally
					{
						this.EndProperty();
					}
					this.Visit(node.Comment);
					this.Visit(node.Statements);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitRefuseBranch(RefuseBranchSyntax node)
		{
			this.BeginProperty(node, name: "Branches");
			try
			{
				this.BeginSymbolDef(node, type: typeof(ForkRequestBranch));
				try
				{
					switch (node.KRefuse.GetKind().Switch())
					{
						default:
							break;
					}
					this.BeginProperty(node.Condition, name: "Condition");
					try
					{
						this.Visit(node.Condition);
					}
					finally
					{
						this.EndProperty();
					}
					this.Visit(node.Comment);
					this.Visit(node.Statements);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitCancelBranch(CancelBranchSyntax node)
		{
			this.BeginProperty(node, name: "Branches");
			try
			{
				this.BeginSymbolDef(node, type: typeof(ForkRequestBranch));
				try
				{
					switch (node.KCancel.GetKind().Switch())
					{
						default:
							break;
					}
					this.BeginProperty(node.Condition, name: "Condition");
					try
					{
						this.Visit(node.Condition);
					}
					finally
					{
						this.EndProperty();
					}
					this.Visit(node.Comment);
					this.Visit(node.Statements);
				}
				finally
				{
					this.EndSymbolDef();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitVariableDeclarationStatement(VariableDeclarationStatementSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(VariableDeclarationStatement));
			try
			{
				this.BeginProperty(node.VariableDeclaration, name: "Variable");
				try
				{
					this.Visit(node.VariableDeclaration);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitVariableDeclaration(VariableDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Variable));
			try
			{
				this.Visit(node.Name);
				this.BeginProperty(node.TypeReference, name: "Type");
				try
				{
					this.Visit(node.TypeReference);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Expression, name: "DefaultValue");
				try
				{
					this.Visit(node.Expression);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitAssignmentStatement(AssignmentStatementSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(AssignmentStatement));
			try
			{
				this.BeginProperty(node.LeftSide, name: "LeftSide");
				try
				{
					this.Visit(node.LeftSide);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Value, name: "Value");
				try
				{
					this.Visit(node.Value);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitLeftSide(LeftSideSyntax node)
		{
			this.Visit(node.Identifier);
		}
		
		public virtual void VisitExpressionList(ExpressionListSyntax node)
		{
			if (node.Expression != null)
			{
				foreach (var child in node.Expression)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitExpression(ExpressionSyntax node)
		{
			this.Visit(node.ArithmeticExpression);
			this.Visit(node.ConditionalExpression);
		}
		
		public virtual void VisitMulDivExpression(MulDivExpressionSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(BinaryExpression));
			try
			{
				this.BeginProperty(node.Left, name: "Left");
				try
				{
					this.Visit(node.Left);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.OpMulDiv, name: "Operator");
				try
				{
					this.Visit(node.OpMulDiv);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Right, name: "Right");
				try
				{
					this.Visit(node.Right);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitPlusMinusExpression(PlusMinusExpressionSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(BinaryExpression));
			try
			{
				this.BeginProperty(node.Left, name: "Left");
				try
				{
					this.Visit(node.Left);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.OpAddSub, name: "Operator");
				try
				{
					this.Visit(node.OpAddSub);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Right, name: "Right");
				try
				{
					this.Visit(node.Right);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitNegateExpression(NegateExpressionSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(UnaryExpression));
			try
			{
				this.BeginProperty(node.OpMinus, name: "Operator");
				try
				{
					this.Visit(node.OpMinus);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.ArithmeticExpressionTerminator, name: "Inner");
				try
				{
					this.Visit(node.ArithmeticExpressionTerminator);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitSimpleArithmeticExpression(SimpleArithmeticExpressionSyntax node)
		{
			this.Visit(node.ArithmeticExpressionTerminator);
		}
		
		public virtual void VisitOpMulDiv(OpMulDivSyntax node)
		{
			switch (node.OpMulDiv.GetKind().Switch())
			{
				case PilSyntaxKind.TAsterisk:
					break;
				case PilSyntaxKind.TSlash:
					break;
				default:
					break;
			}
		}
		
		public virtual void VisitOpAddSub(OpAddSubSyntax node)
		{
			switch (node.OpAddSub.GetKind().Switch())
			{
				case PilSyntaxKind.TPlus:
					break;
				case PilSyntaxKind.TMinus:
					break;
				default:
					break;
			}
		}
		
		public virtual void VisitParenArithmeticExpression(ParenArithmeticExpressionSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(ParenthesizedExpression));
			try
			{
				this.BeginProperty(node.ArithmeticExpression, name: "Inner");
				try
				{
					this.Visit(node.ArithmeticExpression);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitTerminalArithmeticExpression(TerminalArithmeticExpressionSyntax node)
		{
			this.Visit(node.TerminalExpression);
		}
		
		public virtual void VisitOpMinus(OpMinusSyntax node)
		{
		}
		
		public virtual void VisitAndExpression(AndExpressionSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(BinaryExpression));
			try
			{
				this.BeginProperty(node.Left, name: "Left");
				try
				{
					this.Visit(node.Left);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.AndAlsoOp, name: "Operator");
				try
				{
					this.Visit(node.AndAlsoOp);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Right, name: "Right");
				try
				{
					this.Visit(node.Right);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitOrExpression(OrExpressionSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(BinaryExpression));
			try
			{
				this.BeginProperty(node.Left, name: "Left");
				try
				{
					this.Visit(node.Left);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.OrElseOp, name: "Operator");
				try
				{
					this.Visit(node.OrElseOp);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Right, name: "Right");
				try
				{
					this.Visit(node.Right);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitNotExpression(NotExpressionSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(UnaryExpression));
			try
			{
				this.BeginProperty(node.OpExcl, name: "Operator");
				try
				{
					this.Visit(node.OpExcl);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.ConditionalExpressionTerminator, name: "Inner");
				try
				{
					this.Visit(node.ConditionalExpressionTerminator);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitSimpleConditionalExpression(SimpleConditionalExpressionSyntax node)
		{
			this.Visit(node.ConditionalExpressionTerminator);
		}
		
		public virtual void VisitAndAlsoOp(AndAlsoOpSyntax node)
		{
		}
		
		public virtual void VisitOrElseOp(OrElseOpSyntax node)
		{
		}
		
		public virtual void VisitOpExcl(OpExclSyntax node)
		{
		}
		
		public virtual void VisitParenConditionalExpression(ParenConditionalExpressionSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(ParenthesizedExpression));
			try
			{
				this.BeginProperty(node.ConditionalExpression, name: "Inner");
				try
				{
					this.Visit(node.ConditionalExpression);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitElementOfConditionalExpression(ElementOfConditionalExpressionSyntax node)
		{
			this.Visit(node.ElementOfExpression);
		}
		
		public virtual void VisitComparisonConditionalExpression(ComparisonConditionalExpressionSyntax node)
		{
			this.Visit(node.ComparisonExpression);
		}
		
		public virtual void VisitTerminalComparisonExpression(TerminalComparisonExpressionSyntax node)
		{
			this.Visit(node.TerminalExpression);
		}
		
		public virtual void VisitComparisonExpression(ComparisonExpressionSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(BinaryExpression));
			try
			{
				this.BeginProperty(node.Left, name: "Left");
				try
				{
					this.Visit(node.Left);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Op, name: "Operator");
				try
				{
					this.Visit(node.Op);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Right, name: "Right");
				try
				{
					this.Visit(node.Right);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitComparisonOperator(ComparisonOperatorSyntax node)
		{
			switch (node.ComparisonOperator.GetKind().Switch())
			{
				case PilSyntaxKind.TEqual:
					break;
				case PilSyntaxKind.TNotEqual:
					break;
				case PilSyntaxKind.TLessThan:
					break;
				case PilSyntaxKind.TGreaterThan:
					break;
				case PilSyntaxKind.TLessThanOrEqual:
					break;
				case PilSyntaxKind.TGreaterThanOrEqual:
					break;
				default:
					break;
			}
		}
		
		public virtual void VisitElementOfExpression(ElementOfExpressionSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(ElementOfExpression));
			try
			{
				this.BeginProperty(node.TerminalExpression, name: "Value");
				try
				{
					this.Visit(node.TerminalExpression);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.ElementOfValueList);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitElementOfValueList(ElementOfValueListSyntax node)
		{
			if (node.ElementOfValue != null)
			{
				foreach (var child in node.ElementOfValue)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitElementOfValue(ElementOfValueSyntax node)
		{
			this.BeginProperty(node, name: "Set");
			try
			{
				this.Visit(node.Identifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitTerminalExpression(TerminalExpressionSyntax node)
		{
			this.Visit(node.VariableReference);
			this.Visit(node.FunctionCallExpression);
			this.Visit(node.Literal);
		}
		
		public virtual void VisitFunctionCallExpression(FunctionCallExpressionSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(FunctionCallExpression));
			try
			{
				this.BeginProperty(node.Identifier, name: "Name");
				try
				{
					this.Visit(node.Identifier);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.ExpressionList, name: "Arguments");
				try
				{
					this.Visit(node.ExpressionList);
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitVariableReference(VariableReferenceSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(ReferenceExpression));
			try
			{
				if (node.VariableReferenceIdentifier != null)
				{
					foreach (var child in node.VariableReferenceIdentifier)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitVariableReferenceIdentifier(VariableReferenceIdentifierSyntax node)
		{
			this.BeginProperty(node, name: "Qualifier");
			try
			{
				this.Visit(node.Identifier);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitComment(CommentSyntax node)
		{
			this.BeginProperty(node, name: "Comment");
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitLiteral(LiteralSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(LiteralExpression));
			try
			{
				this.BeginProperty(node, name: "Value");
				try
				{
				}
				finally
				{
					this.EndProperty();
				}
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitTypeReference(TypeReferenceSyntax node)
		{
			this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(NamedType)));
			try
			{
				this.Visit(node.BuiltInType);
				this.Visit(node.Identifier);
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitBuiltInType(BuiltInTypeSyntax node)
		{
			if (node != null) this.RegisterIdentifier(node);
		}
		
		public virtual void VisitQualifierList(QualifierListSyntax node)
		{
			if (node.Qualifier != null)
			{
				foreach (var child in node.Qualifier)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitQualifier(QualifierSyntax node)
		{
			this.BeginQualifier(node);
			try
			{
				if (node.Identifier != null)
				{
					foreach (var child in node.Identifier)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndQualifier();
			}
		}
		
		public virtual void VisitName(NameSyntax node)
		{
			this.BeginName(node);
			try
			{
				this.Visit(node.Identifier);
			}
			finally
			{
				this.EndName();
			}
		}
		
		public virtual void VisitIdentifierList(IdentifierListSyntax node)
		{
			if (node.Identifier != null)
			{
				foreach (var child in node.Identifier)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
			if (node != null) this.RegisterIdentifier(node);
		}
		
		public virtual void VisitResultIdentifier(ResultIdentifierSyntax node)
		{
		}
	}
}

