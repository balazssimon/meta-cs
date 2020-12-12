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

namespace MetaDslx.Languages.MetaCompiler.Syntax
{
	public class MetaCompilerSyntaxKind : MetaCompilerTokensSyntaxKind
	{
        public static new readonly MetaCompilerSyntaxKind __FirstToken;
        public static new readonly MetaCompilerSyntaxKind __LastToken;
        public static new readonly MetaCompilerSyntaxKind __FirstFixedToken;
        public static new readonly MetaCompilerSyntaxKind __LastFixedToken;
        public static readonly MetaCompilerSyntaxKind __FirstRule;
        public static readonly int __FirstRuleValue;
        public static readonly MetaCompilerSyntaxKind __LastRule;
        public static readonly int __LastRuleValue;

		// Rules:
		public const string Main = nameof(Main);
		public const string Name = nameof(Name);
		public const string QualifiedName = nameof(QualifiedName);
		public const string Qualifier = nameof(Qualifier);
		public const string Attribute = nameof(Attribute);
		public const string NamespaceDeclaration = nameof(NamespaceDeclaration);
		public const string NamespaceBody = nameof(NamespaceBody);
		public const string Declaration = nameof(Declaration);
		public const string CompilerDeclaration = nameof(CompilerDeclaration);
		public const string PhaseDeclaration = nameof(PhaseDeclaration);
		public const string PhaseJoin = nameof(PhaseJoin);
		public const string AfterPhases = nameof(AfterPhases);
		public const string BeforePhases = nameof(BeforePhases);
		public const string PhaseRef = nameof(PhaseRef);
		public const string EnumDeclaration = nameof(EnumDeclaration);
		public const string EnumBody = nameof(EnumBody);
		public const string EnumValues = nameof(EnumValues);
		public const string EnumValue = nameof(EnumValue);
		public const string EnumMemberDeclaration = nameof(EnumMemberDeclaration);
		public const string ClassDeclaration = nameof(ClassDeclaration);
		public const string ClassAncestors = nameof(ClassAncestors);
		public const string ClassAncestor = nameof(ClassAncestor);
		public const string ClassBody = nameof(ClassBody);
		public const string ClassMemberDeclaration = nameof(ClassMemberDeclaration);
		public const string ClassKind = nameof(ClassKind);
		public const string FieldDeclaration = nameof(FieldDeclaration);
		public const string FieldContainment = nameof(FieldContainment);
		public const string FieldModifier = nameof(FieldModifier);
		public const string DefaultValue = nameof(DefaultValue);
		public const string Phase = nameof(Phase);
		public const string NameUseList = nameof(NameUseList);
		public const string TypedefDeclaration = nameof(TypedefDeclaration);
		public const string TypedefValue = nameof(TypedefValue);
		public const string ReturnType = nameof(ReturnType);
		public const string TypeOfReference = nameof(TypeOfReference);
		public const string TypeReference = nameof(TypeReference);
		public const string SimpleType = nameof(SimpleType);
		public const string ClassType = nameof(ClassType);
		public const string ObjectType = nameof(ObjectType);
		public const string PrimitiveType = nameof(PrimitiveType);
		public const string VoidType = nameof(VoidType);
		public const string NullableType = nameof(NullableType);
		public const string GenericType = nameof(GenericType);
		public const string GenericTypeName = nameof(GenericTypeName);
		public const string TypeArguments = nameof(TypeArguments);
		public const string TypeArgument = nameof(TypeArgument);
		public const string OperationDeclaration = nameof(OperationDeclaration);
		public const string ParameterList = nameof(ParameterList);
		public const string Parameter = nameof(Parameter);
		public const string Identifier = nameof(Identifier);
		public const string Literal = nameof(Literal);
		public const string NullLiteral = nameof(NullLiteral);
		public const string BooleanLiteral = nameof(BooleanLiteral);
		public const string IntegerLiteral = nameof(IntegerLiteral);
		public const string DecimalLiteral = nameof(DecimalLiteral);
		public const string ScientificLiteral = nameof(ScientificLiteral);
		public const string StringLiteral = nameof(StringLiteral);

		protected MetaCompilerSyntaxKind(string name)
            : base(name)
        {
        }

        protected MetaCompilerSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static MetaCompilerSyntaxKind()
        {
            EnumObject.AutoInit<MetaCompilerSyntaxKind>();
            __FirstToken = KNamespace;
            __LastToken = LCommentStart;
            __FirstFixedToken = KNamespace;
            __LastFixedToken = LCommentStart;
            __FirstRule = Main;
			__FirstRuleValue = (int)__FirstRule;
            __LastRule = StringLiteral;
			__LastRuleValue = (int)__LastRule;
        }

        public static implicit operator MetaCompilerSyntaxKind(string name)
        {
            return FromString<MetaCompilerSyntaxKind>(name);
        }

        public static explicit operator MetaCompilerSyntaxKind(int value)
        {
            return FromIntUnsafe<MetaCompilerSyntaxKind>(value);
        }

	}
}

