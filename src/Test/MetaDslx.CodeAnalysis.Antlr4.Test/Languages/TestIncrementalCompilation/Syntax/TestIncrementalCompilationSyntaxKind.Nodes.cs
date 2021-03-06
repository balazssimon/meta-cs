// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax
{
	public class TestIncrementalCompilationSyntaxKind : TestIncrementalCompilationTokensSyntaxKind
	{
        public static new readonly TestIncrementalCompilationSyntaxKind __FirstToken;
        public static new readonly TestIncrementalCompilationSyntaxKind __LastToken;
        public static new readonly TestIncrementalCompilationSyntaxKind __FirstFixedToken;
        public static new readonly TestIncrementalCompilationSyntaxKind __LastFixedToken;
        public static readonly TestIncrementalCompilationSyntaxKind __FirstRule;
        public static readonly int __FirstRuleValue;
        public static readonly TestIncrementalCompilationSyntaxKind __LastRule;
        public static readonly int __LastRuleValue;

		// Rules:
		public const string Main = nameof(Main);
		public const string Name = nameof(Name);
		public const string QualifiedName = nameof(QualifiedName);
		public const string Qualifier = nameof(Qualifier);
		public const string Attribute = nameof(Attribute);
		public const string NamespaceDeclaration = nameof(NamespaceDeclaration);
		public const string NamespaceBody = nameof(NamespaceBody);
		public const string MetamodelDeclaration = nameof(MetamodelDeclaration);
		public const string MetamodelPropertyList = nameof(MetamodelPropertyList);
		public const string MetamodelProperty = nameof(MetamodelProperty);
		public const string MetamodelUriProperty = nameof(MetamodelUriProperty);
		public const string MetamodelPrefixProperty = nameof(MetamodelPrefixProperty);
		public const string Declaration = nameof(Declaration);
		public const string EnumDeclaration = nameof(EnumDeclaration);
		public const string EnumBody = nameof(EnumBody);
		public const string EnumValues = nameof(EnumValues);
		public const string EnumValue = nameof(EnumValue);
		public const string EnumMemberDeclaration = nameof(EnumMemberDeclaration);
		public const string ClassDeclaration = nameof(ClassDeclaration);
		public const string ClassBody = nameof(ClassBody);
		public const string ClassAncestors = nameof(ClassAncestors);
		public const string ClassAncestor = nameof(ClassAncestor);
		public const string ClassMemberDeclaration = nameof(ClassMemberDeclaration);
		public const string FieldDeclaration = nameof(FieldDeclaration);
		public const string FieldContainment = nameof(FieldContainment);
		public const string FieldModifier = nameof(FieldModifier);
		public const string DefaultValue = nameof(DefaultValue);
		public const string RedefinitionsOrSubsettings = nameof(RedefinitionsOrSubsettings);
		public const string Redefinitions = nameof(Redefinitions);
		public const string Subsettings = nameof(Subsettings);
		public const string NameUseList = nameof(NameUseList);
		public const string ConstDeclaration = nameof(ConstDeclaration);
		public const string ConstValue = nameof(ConstValue);
		public const string ReturnType = nameof(ReturnType);
		public const string TypeOfReference = nameof(TypeOfReference);
		public const string TypeReference = nameof(TypeReference);
		public const string SimpleType = nameof(SimpleType);
		public const string ClassType = nameof(ClassType);
		public const string ObjectType = nameof(ObjectType);
		public const string PrimitiveType = nameof(PrimitiveType);
		public const string VoidType = nameof(VoidType);
		public const string NullableType = nameof(NullableType);
		public const string CollectionType = nameof(CollectionType);
		public const string CollectionKind = nameof(CollectionKind);
		public const string OperationDeclaration = nameof(OperationDeclaration);
		public const string OperationModifier = nameof(OperationModifier);
		public const string OperationModifierBuilder = nameof(OperationModifierBuilder);
		public const string OperationModifierReadonly = nameof(OperationModifierReadonly);
		public const string ParameterList = nameof(ParameterList);
		public const string Parameter = nameof(Parameter);
		public const string AssociationDeclaration = nameof(AssociationDeclaration);
		public const string Identifier = nameof(Identifier);
		public const string Literal = nameof(Literal);
		public const string NullLiteral = nameof(NullLiteral);
		public const string BooleanLiteral = nameof(BooleanLiteral);
		public const string IntegerLiteral = nameof(IntegerLiteral);
		public const string DecimalLiteral = nameof(DecimalLiteral);
		public const string ScientificLiteral = nameof(ScientificLiteral);
		public const string StringLiteral = nameof(StringLiteral);

		protected TestIncrementalCompilationSyntaxKind(string name)
            : base(name)
        {
        }

        protected TestIncrementalCompilationSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static TestIncrementalCompilationSyntaxKind()
        {
            EnumObject.AutoInit<TestIncrementalCompilationSyntaxKind>();
            __FirstToken = KNamespace;
            __LastToken = LCommentStart;
            __FirstFixedToken = KNamespace;
            __LastFixedToken = LCommentStart;
            __FirstRule = Main;
			__FirstRuleValue = (int)__FirstRule;
            __LastRule = StringLiteral;
			__LastRuleValue = (int)__LastRule;
        }

        public static implicit operator TestIncrementalCompilationSyntaxKind(string name)
        {
            return FromString<TestIncrementalCompilationSyntaxKind>(name);
        }

        public static explicit operator TestIncrementalCompilationSyntaxKind(int value)
        {
            return FromIntUnsafe<TestIncrementalCompilationSyntaxKind>(value);
        }

	}
}

