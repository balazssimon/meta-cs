// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Bootstrap.Meta.Syntax
{
	public class MetaSyntaxKind : SyntaxKind
	{
        public static readonly MetaSyntaxKind __FirstToken;
        public static readonly int __FirstTokenValue;
        public static readonly MetaSyntaxKind __LastToken;
        public static readonly int __LastTokenValue;
        public static readonly MetaSyntaxKind __FirstFixedToken;
        public static readonly int __FirstFixedTokenValue;
        public static readonly MetaSyntaxKind __LastFixedToken;
        public static readonly int __LastFixedTokenValue;
        public static readonly MetaSyntaxKind __FirstRule;
        public static readonly int __FirstRuleValue;
        public static readonly MetaSyntaxKind __LastRule;
        public static readonly int __LastRuleValue;

		// Tokens:
		public const string KNamespace = nameof(KNamespace); // 1
		public const string KUsing = nameof(KUsing); // 2
		public const string KMetamodel = nameof(KMetamodel); // 3
		public const string KExtern = nameof(KExtern); // 4
		public const string KTypeDef = nameof(KTypeDef); // 5
		public const string KAbstract = nameof(KAbstract); // 6
		public const string KClass = nameof(KClass); // 7
		public const string KStruct = nameof(KStruct); // 8
		public const string KEnum = nameof(KEnum); // 9
		public const string KAssociation = nameof(KAssociation); // 10
		public const string KContainment = nameof(KContainment); // 11
		public const string KWith = nameof(KWith); // 12
		public const string KNew = nameof(KNew); // 13
		public const string KNull = nameof(KNull); // 14
		public const string KTrue = nameof(KTrue); // 15
		public const string KFalse = nameof(KFalse); // 16
		public const string KVoid = nameof(KVoid); // 17
		public const string KObject = nameof(KObject); // 18
		public const string KSymbol = nameof(KSymbol); // 19
		public const string KString = nameof(KString); // 20
		public const string KInt = nameof(KInt); // 21
		public const string KLong = nameof(KLong); // 22
		public const string KFloat = nameof(KFloat); // 23
		public const string KDouble = nameof(KDouble); // 24
		public const string KByte = nameof(KByte); // 25
		public const string KBool = nameof(KBool); // 26
		public const string KList = nameof(KList); // 27
		public const string KAny = nameof(KAny); // 28
		public const string KNone = nameof(KNone); // 29
		public const string KError = nameof(KError); // 30
		public const string KSet = nameof(KSet); // 31
		public const string KMultiList = nameof(KMultiList); // 32
		public const string KMultiSet = nameof(KMultiSet); // 33
		public const string KThis = nameof(KThis); // 34
		public const string KTypeof = nameof(KTypeof); // 35
		public const string KAs = nameof(KAs); // 36
		public const string KIs = nameof(KIs); // 37
		public const string KBase = nameof(KBase); // 38
		public const string KConst = nameof(KConst); // 39
		public const string KRedefines = nameof(KRedefines); // 40
		public const string KSubsets = nameof(KSubsets); // 41
		public const string KReadonly = nameof(KReadonly); // 42
		public const string KLazy = nameof(KLazy); // 43
		public const string KSynthetized = nameof(KSynthetized); // 44
		public const string KInherited = nameof(KInherited); // 45
		public const string KDerived = nameof(KDerived); // 46
		public const string KStatic = nameof(KStatic); // 47
		public const string TSemicolon = nameof(TSemicolon); // 48
		public const string TColon = nameof(TColon); // 49
		public const string TDot = nameof(TDot); // 50
		public const string TComma = nameof(TComma); // 51
		public const string TAssign = nameof(TAssign); // 52
		public const string TOpenParen = nameof(TOpenParen); // 53
		public const string TCloseParen = nameof(TCloseParen); // 54
		public const string TOpenBracket = nameof(TOpenBracket); // 55
		public const string TCloseBracket = nameof(TCloseBracket); // 56
		public const string TOpenBrace = nameof(TOpenBrace); // 57
		public const string TCloseBrace = nameof(TCloseBrace); // 58
		public const string TLessThan = nameof(TLessThan); // 59
		public const string TGreaterThan = nameof(TGreaterThan); // 60
		public const string TQuestion = nameof(TQuestion); // 61
		public const string TQuestionQuestion = nameof(TQuestionQuestion); // 62
		public const string TAmpersand = nameof(TAmpersand); // 63
		public const string THat = nameof(THat); // 64
		public const string TBar = nameof(TBar); // 65
		public const string TAndAlso = nameof(TAndAlso); // 66
		public const string TOrElse = nameof(TOrElse); // 67
		public const string TPlusPlus = nameof(TPlusPlus); // 68
		public const string TMinusMinus = nameof(TMinusMinus); // 69
		public const string TPlus = nameof(TPlus); // 70
		public const string TMinus = nameof(TMinus); // 71
		public const string TTilde = nameof(TTilde); // 72
		public const string TExclamation = nameof(TExclamation); // 73
		public const string TSlash = nameof(TSlash); // 74
		public const string TAsterisk = nameof(TAsterisk); // 75
		public const string TPercent = nameof(TPercent); // 76
		public const string TLessThanOrEqual = nameof(TLessThanOrEqual); // 77
		public const string TGreaterThanOrEqual = nameof(TGreaterThanOrEqual); // 78
		public const string TEqual = nameof(TEqual); // 79
		public const string TNotEqual = nameof(TNotEqual); // 80
		public const string TAsteriskAssign = nameof(TAsteriskAssign); // 81
		public const string TSlashAssign = nameof(TSlashAssign); // 82
		public const string TPercentAssign = nameof(TPercentAssign); // 83
		public const string TPlusAssign = nameof(TPlusAssign); // 84
		public const string TMinusAssign = nameof(TMinusAssign); // 85
		public const string TLeftShiftAssign = nameof(TLeftShiftAssign); // 86
		public const string TRightShiftAssign = nameof(TRightShiftAssign); // 87
		public const string TAmpersandAssign = nameof(TAmpersandAssign); // 88
		public const string THatAssign = nameof(THatAssign); // 89
		public const string TBarAssign = nameof(TBarAssign); // 90
		public const string IUri = nameof(IUri); // 91
		public const string IdentifierNormal = nameof(IdentifierNormal); // 92
		public const string IdentifierVerbatim = nameof(IdentifierVerbatim); // 93
		public const string LInteger = nameof(LInteger); // 94
		public const string LDecimal = nameof(LDecimal); // 95
		public const string LScientific = nameof(LScientific); // 96
		public const string LDateTimeOffset = nameof(LDateTimeOffset); // 97
		public const string LDateTime = nameof(LDateTime); // 98
		public const string LDate = nameof(LDate); // 99
		public const string LTime = nameof(LTime); // 100
		public const string LRegularString = nameof(LRegularString); // 101
		public const string LGuid = nameof(LGuid); // 102
		public const string LUtf8Bom = nameof(LUtf8Bom); // 103
		public const string LWhiteSpace = nameof(LWhiteSpace); // 104
		public const string LCrLf = nameof(LCrLf); // 105
		public const string LLineEnd = nameof(LLineEnd); // 106
		public const string LSingleLineComment = nameof(LSingleLineComment); // 107
		public const string LComment = nameof(LComment); // 108
		public const string LDoubleQuoteVerbatimString = nameof(LDoubleQuoteVerbatimString); // 109
		public const string LSingleQuoteVerbatimString = nameof(LSingleQuoteVerbatimString); // 110
		public const string DoubleQuoteVerbatimStringLiteralStart = nameof(DoubleQuoteVerbatimStringLiteralStart); // 111
		public const string SingleQuoteVerbatimStringLiteralStart = nameof(SingleQuoteVerbatimStringLiteralStart); // 112
		public const string LCommentStart = nameof(LCommentStart); // 113

		// Rules:
		public const string Main = nameof(Main);
		public const string Name = nameof(Name);
		public const string QualifiedName = nameof(QualifiedName);
		public const string Qualifier = nameof(Qualifier);
		public const string Annotation = nameof(Annotation);
		public const string NamespaceDeclaration = nameof(NamespaceDeclaration);
		public const string NamespaceBody = nameof(NamespaceBody);
		public const string MetamodelDeclaration = nameof(MetamodelDeclaration);
		public const string MetamodelPropertyList = nameof(MetamodelPropertyList);
		public const string MetamodelProperty = nameof(MetamodelProperty);
		public const string MetamodelUriProperty = nameof(MetamodelUriProperty);
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
		public const string FieldModifier = nameof(FieldModifier);
		public const string RedefinitionsOrSubsettings = nameof(RedefinitionsOrSubsettings);
		public const string Redefinitions = nameof(Redefinitions);
		public const string Subsettings = nameof(Subsettings);
		public const string NameUseList = nameof(NameUseList);
		public const string ConstDeclaration = nameof(ConstDeclaration);
		public const string ExternTypeDeclaration = nameof(ExternTypeDeclaration);
		public const string ExternClassTypeDeclaration = nameof(ExternClassTypeDeclaration);
		public const string ExternStructTypeDeclaration = nameof(ExternStructTypeDeclaration);
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

		protected MetaSyntaxKind(string name)
            : base(name)
        {
        }

        protected MetaSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static MetaSyntaxKind()
        {
            EnumObject.AutoInit<MetaSyntaxKind>();
            __FirstToken = KNamespace;
			__FirstTokenValue = (int)__FirstToken;
            __LastToken = LCommentStart;
			__LastTokenValue = (int)__LastToken;
            __FirstFixedToken = KNamespace;
			__FirstFixedTokenValue = (int)__FirstFixedToken;
            __LastFixedToken = LCommentStart;
			__LastFixedTokenValue = (int)__LastFixedToken;
            __FirstRule = Main;
			__FirstRuleValue = (int)__FirstRule;
            __LastRule = StringLiteral;
			__LastRuleValue = (int)__LastRule;
        }

        public static implicit operator MetaSyntaxKind(string name)
        {
            return FromString<MetaSyntaxKind>(name);
        }

        public static explicit operator MetaSyntaxKind(int value)
        {
            return FromIntUnsafe<MetaSyntaxKind>(value);
        }

	}
}
