// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.Languages.MetaCompiler;
using MetaDslx.Languages.MetaCompiler.Syntax;
using MetaDslx.Languages.MetaCompiler.Symbols;

using MetaDslx.Languages.MetaCompiler.Model;

namespace MetaDslx.Languages.MetaCompiler.Binding
{
	public class MetaCompilerDeclarationTreeBuilderVisitor : DeclarationTreeBuilderVisitor, IMetaCompilerSyntaxVisitor
	{
        protected MetaCompilerDeclarationTreeBuilderVisitor(MetaCompilerSyntaxTree syntaxTree, string scriptClassName, bool isSubmission)
            : base(syntaxTree, scriptClassName, isSubmission)
        {
        }

        public static RootSingleDeclaration ForTree(
            MetaCompilerSyntaxTree syntaxTree,
            string scriptClassName,
            bool isSubmission)
        {
            var builder = new MetaCompilerDeclarationTreeBuilderVisitor(syntaxTree, scriptClassName, isSubmission);
            return builder.CreateRoot(syntaxTree.GetRoot(), null);
        }

		public virtual void VisitSkippedTokensTrivia(MetaCompilerSkippedTokensTriviaSyntax node)
		{
		}
		
		public virtual void VisitMain(MainSyntax node)
		{
			this.Visit(node.NamespaceDeclaration);
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
		
		public virtual void VisitQualifiedName(QualifiedNameSyntax node)
		{
			this.BeginName(node);
			try
			{
				this.Visit(node.Qualifier);
			}
			finally
			{
				this.EndName();
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
		
		public virtual void VisitAttribute(AttributeSyntax node)
		{
			this.BeginProperty(node, name: "Annotations");
			try
			{
				this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(Annotation)));
				try
				{
					this.Visit(node.Qualifier);
				}
				finally
				{
					this.EndSymbolUse();
				}
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Namespace), nestingProperty: "Declarations", merge: true);
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.QualifiedName);
				this.Visit(node.NamespaceBody);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitNamespaceBody(NamespaceBodySyntax node)
		{
			this.BeginScope(node);
			try
			{
				if (node.Declaration != null)
				{
					foreach (var child in node.Declaration)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndScope();
			}
		}
		
		public virtual void VisitDeclaration(DeclarationSyntax node)
		{
			this.BeginProperty(node, name: "Declarations");
			try
			{
				this.Visit(node.TypedefDeclaration);
				this.Visit(node.CompilerDeclaration);
				this.Visit(node.PhaseDeclaration);
				this.Visit(node.EnumDeclaration);
				this.Visit(node.ClassDeclaration);
				this.Visit(node.SymbolDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitCompilerDeclaration(CompilerDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(EnumType));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.Name);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitPhaseDeclaration(PhaseDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Phase));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.Locked);
				this.Visit(node.Name);
				this.Visit(node.PhaseJoin);
				this.Visit(node.AfterPhases);
				this.Visit(node.BeforePhases);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitLocked(LockedSyntax node)
		{
			this.BeginProperty(node, name: "IsLocked", value: true);
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitPhaseJoin(PhaseJoinSyntax node)
		{
			this.BeginProperty(node, name: "JoinsPhase");
			try
			{
				this.Visit(node.PhaseRef);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitAfterPhases(AfterPhasesSyntax node)
		{
			this.BeginProperty(node, name: "AfterPhases");
			try
			{
				if (node.PhaseRef != null)
				{
					foreach (var child in node.PhaseRef)
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
		
		public virtual void VisitBeforePhases(BeforePhasesSyntax node)
		{
			this.BeginProperty(node, name: "BeforePhases");
			try
			{
				if (node.PhaseRef != null)
				{
					foreach (var child in node.PhaseRef)
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
		
		public virtual void VisitPhaseRef(PhaseRefSyntax node)
		{
			this.BeginSymbolUse(node.Qualifier, types: ImmutableArray.Create(typeof(Phase)));
			try
			{
				this.Visit(node.Qualifier);
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitEnumDeclaration(EnumDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(EnumType));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.Name);
				this.Visit(node.EnumBody);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitEnumBody(EnumBodySyntax node)
		{
			this.BeginScope(node);
			try
			{
				this.BeginProperty(node.EnumValues, name: "EnumLiterals");
				try
				{
					this.Visit(node.EnumValues);
				}
				finally
				{
					this.EndProperty();
				}
				if (node.EnumMemberDeclaration != null)
				{
					foreach (var child in node.EnumMemberDeclaration)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndScope();
			}
		}
		
		public virtual void VisitEnumValues(EnumValuesSyntax node)
		{
			if (node.EnumValue != null)
			{
				foreach (var child in node.EnumValue)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitEnumValue(EnumValueSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(EnumLiteral));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.Name);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
		{
			this.BeginProperty(node.OperationDeclaration, name: "Operations");
			try
			{
				this.Visit(node.OperationDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitVisibility(VisibilitySyntax node)
		{
			this.BeginProperty(node, name: "Visibility");
			try
			{
				switch (node.Visibility.GetKind().Switch())
				{
					case MetaCompilerSyntaxKind.KPrivate:
						break;
					case MetaCompilerSyntaxKind.KProtected:
						break;
					case MetaCompilerSyntaxKind.KPublic:
						break;
					case MetaCompilerSyntaxKind.KInternal:
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
		
		public virtual void VisitClassDeclaration(ClassDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Class));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.Visibility);
				if (node.ClassModifier != null)
				{
					foreach (var child in node.ClassModifier)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.Class_);
				this.Visit(node.Name);
				this.BeginProperty(node.ClassAncestors, name: "SuperClasses");
				try
				{
					this.Visit(node.ClassAncestors);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.ClassBody);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitClassModifier(ClassModifierSyntax node)
		{
			this.Visit(node.Abstract_);
			this.Visit(node.Sealed_);
			this.Visit(node.Partial_);
			this.Visit(node.Static_);
		}
		
		public virtual void VisitClassAncestors(ClassAncestorsSyntax node)
		{
			if (node.ClassAncestor != null)
			{
				foreach (var child in node.ClassAncestor)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitClassAncestor(ClassAncestorSyntax node)
		{
			this.BeginSymbolUse(node.Qualifier, types: ImmutableArray.Create(typeof(Class)));
			try
			{
				this.Visit(node.Qualifier);
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitClassBody(ClassBodySyntax node)
		{
			this.BeginScope(node);
			try
			{
				this.Visit(node.ClassPhases);
				if (node.ClassMemberDeclaration != null)
				{
					foreach (var child in node.ClassMemberDeclaration)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndScope();
			}
		}
		
		public virtual void VisitClassPhases(ClassPhasesSyntax node)
		{
			this.BeginProperty(node, name: "Phases");
			try
			{
				if (node.PhaseRef != null)
				{
					foreach (var child in node.PhaseRef)
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
		
		public virtual void VisitClassMemberDeclaration(ClassMemberDeclarationSyntax node)
		{
			this.BeginProperty(node.FieldDeclaration, name: "Properties");
			try
			{
				this.Visit(node.FieldDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
			this.BeginProperty(node.OperationDeclaration, name: "Operations");
			try
			{
				this.Visit(node.OperationDeclaration);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitClass_(Class_Syntax node)
		{
			this.BeginProperty(node, name: "Kind");
			try
			{
				switch (node.KClass.GetKind().Switch())
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
		
		public virtual void VisitSymbolDeclaration(SymbolDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Symbol));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.Visibility);
				this.Visit(node.Visit_);
				if (node.ClassModifier != null)
				{
					foreach (var child in node.ClassModifier)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.Symbol_);
				this.Visit(node.Name);
				this.BeginProperty(node.ClassAncestors, name: "SuperClasses");
				try
				{
					this.Visit(node.ClassAncestors);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.ClassBody);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitSymbol_(Symbol_Syntax node)
		{
			this.BeginProperty(node, name: "Kind");
			try
			{
				switch (node.KSymbol.GetKind().Switch())
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
		
		public virtual void VisitFieldDeclaration(FieldDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Property));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.Visibility);
				if (node.MemberModifier != null)
				{
					foreach (var child in node.MemberModifier)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.FieldContainment);
				this.Visit(node.FieldKind);
				this.BeginProperty(node.TypeReference, name: "Type");
				try
				{
					this.Visit(node.TypeReference);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.Name);
				this.Visit(node.DefaultValue);
				this.Visit(node.Phase);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitFieldContainment(FieldContainmentSyntax node)
		{
			this.BeginProperty(node, name: "IsContainment", value: true);
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitFieldKind(FieldKindSyntax node)
		{
			this.BeginProperty(node, name: "Kind");
			try
			{
				switch (node.FieldKind.GetKind().Switch())
				{
					case MetaCompilerSyntaxKind.KReadonly:
						break;
					case MetaCompilerSyntaxKind.KLazy:
						break;
					case MetaCompilerSyntaxKind.KDerived:
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
		
		public virtual void VisitMemberModifier(MemberModifierSyntax node)
		{
			this.Visit(node.Partial_);
			this.Visit(node.Static_);
			this.Visit(node.Virtual_);
			this.Visit(node.Abstract_);
			this.Visit(node.Sealed_);
			this.Visit(node.New_);
			this.Visit(node.Override_);
		}
		
		public virtual void VisitDefaultValue(DefaultValueSyntax node)
		{
			this.BeginProperty(node, name: "DefaultValue");
			try
			{
				this.Visit(node.StringLiteral);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitPhase(PhaseSyntax node)
		{
			this.BeginProperty(node, name: "Phase");
			try
			{
				this.Visit(node.PhaseRef);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitNameUseList(NameUseListSyntax node)
		{
			this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(Property)));
			try
			{
				if (node.Qualifier != null)
				{
					foreach (var child in node.Qualifier)
					{
				        this.Visit(child);
					}
				}
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitTypedefDeclaration(TypedefDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(TypeDefType));
			try
			{
				this.Visit(node.Name);
				this.Visit(node.TypedefValue);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitTypedefValue(TypedefValueSyntax node)
		{
			this.BeginProperty(node, name: "DotNetType");
			try
			{
				this.Visit(node.StringLiteral);
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitReturnType(ReturnTypeSyntax node)
		{
			this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(DataType)));
			try
			{
				this.Visit(node.TypeReference);
				this.Visit(node.VoidType);
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitTypeOfReference(TypeOfReferenceSyntax node)
		{
			this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(DataType)));
			try
			{
				this.Visit(node.TypeReference);
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitTypeReference(TypeReferenceSyntax node)
		{
			this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(DataType)));
			try
			{
				this.Visit(node.SimpleOrDictionaryType);
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitSimpleOrDictionaryType(SimpleOrDictionaryTypeSyntax node)
		{
			this.Visit(node.SimpleOrArrayType);
			this.Visit(node.DictionaryType);
		}
		
		public virtual void VisitSimpleOrArrayType(SimpleOrArrayTypeSyntax node)
		{
			this.Visit(node.SimpleOrGenericType);
			this.Visit(node.ArrayType);
		}
		
		public virtual void VisitSimpleOrGenericType(SimpleOrGenericTypeSyntax node)
		{
			this.Visit(node.SimpleType);
			this.Visit(node.GenericType);
		}
		
		public virtual void VisitSimpleType(SimpleTypeSyntax node)
		{
			this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(DataType)));
			try
			{
				this.Visit(node.PrimitiveType);
				this.Visit(node.ObjectType);
				this.Visit(node.NullableType);
				this.Visit(node.ClassType);
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitClassType(ClassTypeSyntax node)
		{
			this.BeginSymbolUse(node, types: ImmutableArray.Create(typeof(Class), typeof(EnumType), typeof(TypeDefType)));
			try
			{
				this.Visit(node.Qualifier);
			}
			finally
			{
				this.EndSymbolUse();
			}
		}
		
		public virtual void VisitObjectType(ObjectTypeSyntax node)
		{
			if (node != null) this.RegisterIdentifier(node);
		}
		
		public virtual void VisitPrimitiveType(PrimitiveTypeSyntax node)
		{
			if (node != null) this.RegisterIdentifier(node);
		}
		
		public virtual void VisitVoidType(VoidTypeSyntax node)
		{
			if (node != null) this.RegisterIdentifier(node);
		}
		
		public virtual void VisitNullableType(NullableTypeSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(NullableType));
			try
			{
				this.BeginProperty(node.PrimitiveType, name: "InnerType");
				try
				{
					this.Visit(node.PrimitiveType);
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
		
		public virtual void VisitGenericType(GenericTypeSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(GenericType));
			try
			{
				this.BeginProperty(node.ClassType, name: "Type");
				try
				{
					this.Visit(node.ClassType);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.TypeArguments);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitTypeArguments(TypeArgumentsSyntax node)
		{
			this.BeginProperty(node, name: "TypeArguments");
			try
			{
				if (node.TypeReference != null)
				{
					foreach (var child in node.TypeReference)
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
		
		public virtual void VisitArrayType(ArrayTypeSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(ArrayType));
			try
			{
				this.BeginProperty(node.SimpleOrGenericType, name: "InnerType");
				try
				{
					this.Visit(node.SimpleOrGenericType);
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
		
		public virtual void VisitDictionaryType(DictionaryTypeSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(DictionaryType));
			try
			{
				this.BeginProperty(node.Key, name: "KeyType");
				try
				{
					this.Visit(node.Key);
				}
				finally
				{
					this.EndProperty();
				}
				this.BeginProperty(node.Value, name: "ValueType");
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
		
		public virtual void VisitOperationDeclaration(OperationDeclarationSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Operation));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.Visit(node.Visibility);
				if (node.MemberModifier != null)
				{
					foreach (var child in node.MemberModifier)
					{
				        this.Visit(child);
					}
				}
				this.BeginProperty(node.ReturnType, name: "ReturnType");
				try
				{
					this.Visit(node.ReturnType);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.Name);
				this.BeginProperty(node.ParameterList, name: "Parameters");
				try
				{
					this.Visit(node.ParameterList);
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
		
		public virtual void VisitParameterList(ParameterListSyntax node)
		{
			if (node.Parameter != null)
			{
				foreach (var child in node.Parameter)
				{
			        this.Visit(child);
				}
			}
		}
		
		public virtual void VisitParameter(ParameterSyntax node)
		{
			this.BeginSymbolDef(node, type: typeof(Parameter));
			try
			{
				if (node.Attribute != null)
				{
					foreach (var child in node.Attribute)
					{
				        this.Visit(child);
					}
				}
				this.BeginProperty(node.TypeReference, name: "Type");
				try
				{
					this.Visit(node.TypeReference);
				}
				finally
				{
					this.EndProperty();
				}
				this.Visit(node.Name);
				this.Visit(node.DefaultValue);
			}
			finally
			{
				this.EndSymbolDef();
			}
		}
		
		public virtual void VisitStatic_(Static_Syntax node)
		{
			this.BeginProperty(node, name: "IsStatic", value: true);
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitBase_(Base_Syntax node)
		{
			this.BeginProperty(node, name: "SymbolModifier");
			try
			{
				switch (node.KBase.GetKind().Switch())
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
		
		public virtual void VisitMeta_(Meta_Syntax node)
		{
			this.BeginProperty(node, name: "SymbolModifier");
			try
			{
				switch (node.KMeta.GetKind().Switch())
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
		
		public virtual void VisitSource_(Source_Syntax node)
		{
			this.BeginProperty(node, name: "SymbolModifier");
			try
			{
				switch (node.KSource.GetKind().Switch())
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
		
		public virtual void VisitVisit_(Visit_Syntax node)
		{
			this.BeginProperty(node, name: "IsVisit", value: true);
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitPartial_(Partial_Syntax node)
		{
			this.BeginProperty(node, name: "IsPartial", value: true);
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitAbstract_(Abstract_Syntax node)
		{
			this.BeginProperty(node, name: "IsAbstract", value: true);
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitVirtual_(Virtual_Syntax node)
		{
			this.BeginProperty(node, name: "IsVirtual", value: true);
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitSealed_(Sealed_Syntax node)
		{
			this.BeginProperty(node, name: "IsSealed", value: true);
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitOverride_(Override_Syntax node)
		{
			this.BeginProperty(node, name: "IsOverride", value: true);
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitNew_(New_Syntax node)
		{
			this.BeginProperty(node, name: "IsNew", value: true);
			try
			{
			}
			finally
			{
				this.EndProperty();
			}
		}
		
		public virtual void VisitIdentifier(IdentifierSyntax node)
		{
			if (node != null) this.RegisterIdentifier(node);
		}
		
		public virtual void VisitLiteral(LiteralSyntax node)
		{
			this.Visit(node.NullLiteral);
			this.Visit(node.BooleanLiteral);
			this.Visit(node.IntegerLiteral);
			this.Visit(node.DecimalLiteral);
			this.Visit(node.ScientificLiteral);
			this.Visit(node.StringLiteral);
		}
		
		public virtual void VisitNullLiteral(NullLiteralSyntax node)
		{
		}
		
		public virtual void VisitBooleanLiteral(BooleanLiteralSyntax node)
		{
		}
		
		public virtual void VisitIntegerLiteral(IntegerLiteralSyntax node)
		{
		}
		
		public virtual void VisitDecimalLiteral(DecimalLiteralSyntax node)
		{
		}
		
		public virtual void VisitScientificLiteral(ScientificLiteralSyntax node)
		{
		}
		
		public virtual void VisitStringLiteral(StringLiteralSyntax node)
		{
		}
	}
}

