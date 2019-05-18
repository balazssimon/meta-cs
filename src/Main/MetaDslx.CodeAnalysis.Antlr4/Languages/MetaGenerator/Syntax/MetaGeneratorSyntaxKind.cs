// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.MetaGenerator.Syntax
{
	public class MetaGeneratorSyntaxKind : SyntaxKind
	{
        public static readonly int __FirstAntlr4TokenValue;
        public static readonly int __LastAntlr4TokenValue;
        public static readonly int __FirstAntlr4RuleValue;
        public static readonly int __LastAntlr4RuleValue;

        // Tokens:
        public const string KNamespace = nameof(KNamespace);
        public const string KGenerator = nameof(KGenerator);
        public const string KUsing = nameof(KUsing);
        public const string KConfiguration = nameof(KConfiguration);
        public const string KProperties = nameof(KProperties);
        public const string KTemplate = nameof(KTemplate);
        public const string KFunction = nameof(KFunction);
        public const string KExtern = nameof(KExtern);
        public const string KReturn = nameof(KReturn);
        public const string KSwitch = nameof(KSwitch);
        public const string KCase = nameof(KCase);
        public const string KType = nameof(KType);
        public const string KVoid = nameof(KVoid);
        public const string KEnd = nameof(KEnd);
        public const string KFor = nameof(KFor);
        public const string KForEach = nameof(KForEach);
        public const string KIn = nameof(KIn);
        public const string KIf = nameof(KIf);
        public const string KElse = nameof(KElse);
        public const string KRepeat = nameof(KRepeat);
        public const string KUntil = nameof(KUntil);
        public const string KWhile = nameof(KWhile);
        public const string KLoop = nameof(KLoop);
        public const string KHasLoop = nameof(KHasLoop);
        public const string KWhere = nameof(KWhere);
        public const string KOrderBy = nameof(KOrderBy);
        public const string KDescending = nameof(KDescending);
        public const string KSeparator = nameof(KSeparator);
        public const string KNull = nameof(KNull);
        public const string KTrue = nameof(KTrue);
        public const string KFalse = nameof(KFalse);
        public const string KBool = nameof(KBool);
        public const string KByte = nameof(KByte);
        public const string KChar = nameof(KChar);
        public const string KDecimal = nameof(KDecimal);
        public const string KDouble = nameof(KDouble);
        public const string KFloat = nameof(KFloat);
        public const string KInt = nameof(KInt);
        public const string KLong = nameof(KLong);
        public const string KObject = nameof(KObject);
        public const string KSByte = nameof(KSByte);
        public const string KShort = nameof(KShort);
        public const string KString = nameof(KString);
        public const string KUInt = nameof(KUInt);
        public const string KULong = nameof(KULong);
        public const string KUShort = nameof(KUShort);
        public const string KThis = nameof(KThis);
        public const string KNew = nameof(KNew);
        public const string KIs = nameof(KIs);
        public const string KAs = nameof(KAs);
        public const string KTypeof = nameof(KTypeof);
        public const string KDefault = nameof(KDefault);
        public const string TSemicolon = nameof(TSemicolon);
        public const string TColon = nameof(TColon);
        public const string TDot = nameof(TDot);
        public const string TComma = nameof(TComma);
        public const string TAssign = nameof(TAssign);
        public const string TAssignPlus = nameof(TAssignPlus);
        public const string TAssignMinus = nameof(TAssignMinus);
        public const string TAssignAsterisk = nameof(TAssignAsterisk);
        public const string TAssignSlash = nameof(TAssignSlash);
        public const string TAssignPercent = nameof(TAssignPercent);
        public const string TAssignAmp = nameof(TAssignAmp);
        public const string TAssignPipe = nameof(TAssignPipe);
        public const string TAssignHat = nameof(TAssignHat);
        public const string TAssignLeftShift = nameof(TAssignLeftShift);
        public const string TAssignRightShift = nameof(TAssignRightShift);
        public const string TOpenParenthesis = nameof(TOpenParenthesis);
        public const string TCloseParenthesis = nameof(TCloseParenthesis);
        public const string TOpenBracket = nameof(TOpenBracket);
        public const string TCloseBracket = nameof(TCloseBracket);
        public const string TOpenBrace = nameof(TOpenBrace);
        public const string TCloseBrace = nameof(TCloseBrace);
        public const string TEquals = nameof(TEquals);
        public const string TNotEquals = nameof(TNotEquals);
        public const string TArrow = nameof(TArrow);
        public const string TSingleArrow = nameof(TSingleArrow);
        public const string TLessThan = nameof(TLessThan);
        public const string TGreaterThan = nameof(TGreaterThan);
        public const string TLessThanOrEquals = nameof(TLessThanOrEquals);
        public const string TGreaterThanOrEquals = nameof(TGreaterThanOrEquals);
        public const string TQuestion = nameof(TQuestion);
        public const string TPlus = nameof(TPlus);
        public const string TMinus = nameof(TMinus);
        public const string TExclamation = nameof(TExclamation);
        public const string TTilde = nameof(TTilde);
        public const string TAsterisk = nameof(TAsterisk);
        public const string TSlash = nameof(TSlash);
        public const string TPercent = nameof(TPercent);
        public const string TPlusPlus = nameof(TPlusPlus);
        public const string TMinusMinus = nameof(TMinusMinus);
        public const string TColonColon = nameof(TColonColon);
        public const string TAmp = nameof(TAmp);
        public const string THat = nameof(THat);
        public const string TPipe = nameof(TPipe);
        public const string TAnd = nameof(TAnd);
        public const string TXor = nameof(TXor);
        public const string TOr = nameof(TOr);
        public const string TQuestionQuestion = nameof(TQuestionQuestion);
        public const string IdentifierNormal = nameof(IdentifierNormal);
        public const string IntegerLiteral = nameof(IntegerLiteral);
        public const string DecimalLiteral = nameof(DecimalLiteral);
        public const string ScientificLiteral = nameof(ScientificLiteral);
        public const string DateTimeOffsetLiteral = nameof(DateTimeOffsetLiteral);
        public const string DateTimeLiteral = nameof(DateTimeLiteral);
        public const string DateLiteral = nameof(DateLiteral);
        public const string TimeLiteral = nameof(TimeLiteral);
        public const string CharLiteral = nameof(CharLiteral);
        public const string RegularStringLiteral = nameof(RegularStringLiteral);
        public const string GuidLiteral = nameof(GuidLiteral);
        public const string LUtf8Bom = nameof(LUtf8Bom);
        public const string LWhitespace = nameof(LWhitespace);
        public const string LCrLf = nameof(LCrLf);
        public const string LLineBreak = nameof(LLineBreak);
        public const string LLineComment = nameof(LLineComment);
        public const string LMultiLineComment = nameof(LMultiLineComment);
        public const string DoubleQuoteVerbatimStringLiteral = nameof(DoubleQuoteVerbatimStringLiteral);
        public const string TH_TOpenParenthesis = nameof(TH_TOpenParenthesis);
        public const string TH_TCloseParenthesis = nameof(TH_TCloseParenthesis);
        public const string KEndTemplate = nameof(KEndTemplate);
        public const string TemplateLineControl = nameof(TemplateLineControl);
        public const string TemplateOutput = nameof(TemplateOutput);
        public const string TemplateCrLf = nameof(TemplateCrLf);
        public const string TemplateLineBreak = nameof(TemplateLineBreak);
        public const string TemplateStatementStart = nameof(TemplateStatementStart);
        public const string TemplateStatementEnd = nameof(TemplateStatementEnd);
        public const string TS_TOpenBracket = nameof(TS_TOpenBracket);
        public const string TS_TCloseBracket = nameof(TS_TCloseBracket);
        public const string DoubleQuoteVerbatimStringLiteralStart = nameof(DoubleQuoteVerbatimStringLiteralStart);
        public const string COMMENT_START = nameof(COMMENT_START);

        // Rules:

        protected MetaGeneratorSyntaxKind(string name)
            : base(name)
        {
        }

        protected MetaGeneratorSyntaxKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static MetaGeneratorSyntaxKind()
        {
            EnumObject.AutoInit<MetaGeneratorSyntaxKind>();
            __FirstAntlr4TokenValue = KNamespace.As<MetaGeneratorSyntaxKind>().GetValue();
            __LastAntlr4TokenValue = COMMENT_START.As<MetaGeneratorSyntaxKind>().GetValue();
            __FirstAntlr4RuleValue = -1;
            __LastAntlr4RuleValue = -1;
        }

        public static implicit operator MetaGeneratorSyntaxKind(string name)
        {
            return FromString<MetaGeneratorSyntaxKind>(name);
        }

        public new static IEnumerable<EnumObject> EnumValues => EnumObject.EnumValues(typeof(MetaGeneratorSyntaxKind));


    }
}

