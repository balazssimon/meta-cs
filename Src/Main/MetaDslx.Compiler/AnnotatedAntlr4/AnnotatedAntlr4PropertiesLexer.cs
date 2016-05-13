//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.5.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\balaz\AppData\Local\Temp\ogbtjdm0.b2q\AnnotatedAntlr4PropertiesLexer.g4 by ANTLR 4.5.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

namespace MetaDslx.Compiler {
using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.5.1")]
[System.CLSCompliant(false)]
public partial class AnnotatedAntlr4PropertiesLexer : Lexer {
	public const int
		LINE_COMMENT=1, TRUE=2, FALSE=3, NULL=4, COLON=5, COLONCOLON=6, COMMA=7, 
		SEMI=8, LPAREN=9, RPAREN=10, LT=11, GT=12, ASSIGN=13, QUESTION=14, STAR=15, 
		PLUS=16, OR=17, DOLLAR=18, DOT=19, AT=20, POUND=21, NOT=22, LBRACE=23, 
		RBRACE=24, LBRACKET=25, RBRACKET=26, ID=27, INTEGER_LITERAL=28, DECIMAL_LITERAL=29, 
		SCIENTIFIC_LITERAL=30, STRING_LITERAL=31, UNTERMINATED_STRING_LITERAL=32, 
		WS=33, ERRCHAR=34, DOC_COMMENT=35, BLOCK_COMMENT=36;
	public const int DOC_COMMENT_MODE = 1;
	public const int BLOCK_COMMENT_MODE = 2;
	public static string[] modeNames = {
		"DEFAULT_MODE", "DOC_COMMENT_MODE", "BLOCK_COMMENT_MODE"
	};

	public static readonly string[] ruleNames = {
		"DOC_COMMENT_START", "COMMENT_START", "LINE_COMMENT", "TRUE", "FALSE", 
		"NULL", "COLON", "COLONCOLON", "COMMA", "SEMI", "LPAREN", "RPAREN", "LT", 
		"GT", "ASSIGN", "QUESTION", "STAR", "PLUS", "OR", "DOLLAR", "DOT", "AT", 
		"POUND", "NOT", "LBRACE", "RBRACE", "LBRACKET", "RBRACKET", "ID", "NameChar", 
		"NameStartChar", "INTEGER_LITERAL", "DECIMAL_LITERAL", "SCIENTIFIC_LITERAL", 
		"DecimalDigits", "DecimalDigit", "Sign", "Hexadecimal", "HexDigit", "STRING_LITERAL", 
		"UNTERMINATED_STRING_LITERAL", "ESC_SEQ", "UNICODE_ESC", "HEX_DIGIT", 
		"WS", "ERRCHAR", "DOC_COMMENT_CRLF", "DOC_COMMENT_LINEBREAK", "DOC_COMMENT_TEXT", 
		"DOC_COMMENT", "DOC_COMMENT_STAR", "BLOCK_COMMENT_CRLF", "BLOCK_COMMENT_LINEBREAK", 
		"BLOCK_COMMENT_TEXT", "BLOCK_COMMENT", "BLOCK_COMMENT_STAR"
	};


	public AnnotatedAntlr4PropertiesLexer(ICharStream input)
		: base(input)
	{
		Interpreter = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, null, "'true'", "'false'", "'null'", "':'", "'::'", "','", "';'", 
		"'('", "')'", "'<'", "'>'", "'='", "'?'", null, "'+'", "'|'", "'$'", "'.'", 
		"'@'", "'#'", "'~'", "'{'", "'}'", "'['", "']'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "LINE_COMMENT", "TRUE", "FALSE", "NULL", "COLON", "COLONCOLON", 
		"COMMA", "SEMI", "LPAREN", "RPAREN", "LT", "GT", "ASSIGN", "QUESTION", 
		"STAR", "PLUS", "OR", "DOLLAR", "DOT", "AT", "POUND", "NOT", "LBRACE", 
		"RBRACE", "LBRACKET", "RBRACKET", "ID", "INTEGER_LITERAL", "DECIMAL_LITERAL", 
		"SCIENTIFIC_LITERAL", "STRING_LITERAL", "UNTERMINATED_STRING_LITERAL", 
		"WS", "ERRCHAR", "DOC_COMMENT", "BLOCK_COMMENT"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "AnnotatedAntlr4PropertiesLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\x430\xD6D1\x8206\xAD2D\x4417\xAEF1\x8D80\xAADD\x2&\x17C\b\x1\b\x1"+
		"\b\x1\x4\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a"+
		"\x4\b\t\b\x4\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF"+
		"\t\xF\x4\x10\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14"+
		"\x4\x15\t\x15\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19\x4\x1A"+
		"\t\x1A\x4\x1B\t\x1B\x4\x1C\t\x1C\x4\x1D\t\x1D\x4\x1E\t\x1E\x4\x1F\t\x1F"+
		"\x4 \t \x4!\t!\x4\"\t\"\x4#\t#\x4$\t$\x4%\t%\x4&\t&\x4\'\t\'\x4(\t(\x4"+
		")\t)\x4*\t*\x4+\t+\x4,\t,\x4-\t-\x4.\t.\x4/\t/\x4\x30\t\x30\x4\x31\t\x31"+
		"\x4\x32\t\x32\x4\x33\t\x33\x4\x34\t\x34\x4\x35\t\x35\x4\x36\t\x36\x4\x37"+
		"\t\x37\x4\x38\t\x38\x4\x39\t\x39\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3"+
		"\x2\x3\x2\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x4\x3\x4\x3\x4"+
		"\x3\x4\a\x4\x89\n\x4\f\x4\xE\x4\x8C\v\x4\x3\x4\x3\x4\x3\x5\x3\x5\x3\x5"+
		"\x3\x5\x3\x5\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\a\x3\a\x3\a\x3\a\x3"+
		"\a\x3\b\x3\b\x3\t\x3\t\x3\t\x3\n\x3\n\x3\v\x3\v\x3\f\x3\f\x3\r\x3\r\x3"+
		"\xE\x3\xE\x3\xF\x3\xF\x3\x10\x3\x10\x3\x11\x3\x11\x3\x12\x3\x12\x3\x13"+
		"\x3\x13\x3\x14\x3\x14\x3\x15\x3\x15\x3\x16\x3\x16\x3\x17\x3\x17\x3\x18"+
		"\x3\x18\x3\x19\x3\x19\x3\x1A\x3\x1A\x3\x1B\x3\x1B\x3\x1C\x3\x1C\x3\x1D"+
		"\x3\x1D\x3\x1E\x3\x1E\a\x1E\xCF\n\x1E\f\x1E\xE\x1E\xD2\v\x1E\x3\x1F\x3"+
		"\x1F\x5\x1F\xD6\n\x1F\x3 \x3 \x3!\x3!\x5!\xDC\n!\x3\"\x6\"\xDF\n\"\r\""+
		"\xE\"\xE0\x3\"\x3\"\x6\"\xE5\n\"\r\"\xE\"\xE6\x3#\x3#\x3#\x5#\xEC\n#\x3"+
		"#\x6#\xEF\n#\r#\xE#\xF0\x3$\x6$\xF4\n$\r$\xE$\xF5\x3%\x3%\x3&\x3&\x3\'"+
		"\x3\'\x3\'\x3\'\x5\'\x100\n\'\x3\'\a\'\x103\n\'\f\'\xE\'\x106\v\'\x3("+
		"\x3(\x3)\x3)\x3)\a)\x10D\n)\f)\xE)\x110\v)\x3)\x3)\x3*\x3*\x3*\a*\x117"+
		"\n*\f*\xE*\x11A\v*\x3+\x3+\x3+\x3+\x3+\x5+\x121\n+\x3,\x3,\x3,\x3,\x3"+
		",\x5,\x128\n,\x5,\x12A\n,\x5,\x12C\n,\x5,\x12E\n,\x3-\x3-\x3.\x6.\x133"+
		"\n.\r.\xE.\x134\x3.\x3.\x3/\x3/\x3/\x3/\x3\x30\x5\x30\x13E\n\x30\x3\x30"+
		"\x3\x30\x3\x30\x3\x30\x3\x30\x3\x31\x3\x31\x3\x31\x3\x31\x3\x31\x3\x32"+
		"\x6\x32\x14B\n\x32\r\x32\xE\x32\x14C\x3\x32\x3\x32\x3\x32\x3\x33\x3\x33"+
		"\x3\x33\x3\x33\x3\x33\x3\x33\x3\x34\x3\x34\x3\x34\x3\x34\x3\x34\x3\x35"+
		"\x5\x35\x15E\n\x35\x3\x35\x3\x35\x3\x35\x3\x35\x3\x35\x3\x36\x3\x36\x3"+
		"\x36\x3\x36\x3\x36\x3\x37\x6\x37\x16B\n\x37\r\x37\xE\x37\x16C\x3\x37\x3"+
		"\x37\x3\x37\x3\x38\x3\x38\x3\x38\x3\x38\x3\x38\x3\x38\x3\x39\x3\x39\x3"+
		"\x39\x3\x39\x3\x39\x2\x2:\x5\x2\a\x2\t\x3\v\x4\r\x5\xF\x6\x11\a\x13\b"+
		"\x15\t\x17\n\x19\v\x1B\f\x1D\r\x1F\xE!\xF#\x10%\x11\'\x12)\x13+\x14-\x15"+
		"/\x16\x31\x17\x33\x18\x35\x19\x37\x1A\x39\x1B;\x1C=\x1D?\x2\x41\x2\x43"+
		"\x1E\x45\x1FG I\x2K\x2M\x2O\x2Q\x2S!U\"W\x2Y\x2[\x2]#_$\x61\x2\x63\x2"+
		"\x65\x2g%i\x2k\x2m\x2o\x2q&s\x2\x5\x2\x3\x4\xE\x4\x2\f\f\xF\xF\a\x2\x32"+
		";\x61\x61\xB9\xB9\x302\x371\x2041\x2042\x10\x2\x43\\\x61\x61\x63|\xC2"+
		"\xD8\xDA\xF8\xFA\x301\x372\x37F\x381\x2001\x200E\x200F\x2072\x2191\x2C02"+
		"\x2FF1\x3003\xD801\xF902\xFDD1\xFDF2\xFFFF\x4\x2GGgg\x3\x2\x32;\x4\x2"+
		"--//\x5\x2\x32;\x43H\x63h\x6\x2\f\f\xF\xF))^^\n\x2$$))^^\x64\x64hhppt"+
		"tvv\x5\x2\v\f\xE\xF\"\"\x4\x2\x87\x87\x202A\x202B\b\x2\f\f\xF\xF,,^^\x87"+
		"\x87\x202A\x202B\x18A\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2"+
		"\x2\x2\v\x3\x2\x2\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2"+
		"\x2\x2\x13\x3\x2\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3"+
		"\x2\x2\x2\x2\x1B\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x2"+
		"!\x3\x2\x2\x2\x2#\x3\x2\x2\x2\x2%\x3\x2\x2\x2\x2\'\x3\x2\x2\x2\x2)\x3"+
		"\x2\x2\x2\x2+\x3\x2\x2\x2\x2-\x3\x2\x2\x2\x2/\x3\x2\x2\x2\x2\x31\x3\x2"+
		"\x2\x2\x2\x33\x3\x2\x2\x2\x2\x35\x3\x2\x2\x2\x2\x37\x3\x2\x2\x2\x2\x39"+
		"\x3\x2\x2\x2\x2;\x3\x2\x2\x2\x2=\x3\x2\x2\x2\x2\x43\x3\x2\x2\x2\x2\x45"+
		"\x3\x2\x2\x2\x2G\x3\x2\x2\x2\x2S\x3\x2\x2\x2\x2U\x3\x2\x2\x2\x2]\x3\x2"+
		"\x2\x2\x2_\x3\x2\x2\x2\x3\x61\x3\x2\x2\x2\x3\x63\x3\x2\x2\x2\x3\x65\x3"+
		"\x2\x2\x2\x3g\x3\x2\x2\x2\x3i\x3\x2\x2\x2\x4k\x3\x2\x2\x2\x4m\x3\x2\x2"+
		"\x2\x4o\x3\x2\x2\x2\x4q\x3\x2\x2\x2\x4s\x3\x2\x2\x2\x5u\x3\x2\x2\x2\a"+
		"}\x3\x2\x2\x2\t\x84\x3\x2\x2\x2\v\x8F\x3\x2\x2\x2\r\x94\x3\x2\x2\x2\xF"+
		"\x9A\x3\x2\x2\x2\x11\x9F\x3\x2\x2\x2\x13\xA1\x3\x2\x2\x2\x15\xA4\x3\x2"+
		"\x2\x2\x17\xA6\x3\x2\x2\x2\x19\xA8\x3\x2\x2\x2\x1B\xAA\x3\x2\x2\x2\x1D"+
		"\xAC\x3\x2\x2\x2\x1F\xAE\x3\x2\x2\x2!\xB0\x3\x2\x2\x2#\xB2\x3\x2\x2\x2"+
		"%\xB4\x3\x2\x2\x2\'\xB6\x3\x2\x2\x2)\xB8\x3\x2\x2\x2+\xBA\x3\x2\x2\x2"+
		"-\xBC\x3\x2\x2\x2/\xBE\x3\x2\x2\x2\x31\xC0\x3\x2\x2\x2\x33\xC2\x3\x2\x2"+
		"\x2\x35\xC4\x3\x2\x2\x2\x37\xC6\x3\x2\x2\x2\x39\xC8\x3\x2\x2\x2;\xCA\x3"+
		"\x2\x2\x2=\xCC\x3\x2\x2\x2?\xD5\x3\x2\x2\x2\x41\xD7\x3\x2\x2\x2\x43\xDB"+
		"\x3\x2\x2\x2\x45\xDE\x3\x2\x2\x2G\xE8\x3\x2\x2\x2I\xF3\x3\x2\x2\x2K\xF7"+
		"\x3\x2\x2\x2M\xF9\x3\x2\x2\x2O\xFF\x3\x2\x2\x2Q\x107\x3\x2\x2\x2S\x109"+
		"\x3\x2\x2\x2U\x113\x3\x2\x2\x2W\x11B\x3\x2\x2\x2Y\x122\x3\x2\x2\x2[\x12F"+
		"\x3\x2\x2\x2]\x132\x3\x2\x2\x2_\x138\x3\x2\x2\x2\x61\x13D\x3\x2\x2\x2"+
		"\x63\x144\x3\x2\x2\x2\x65\x14A\x3\x2\x2\x2g\x151\x3\x2\x2\x2i\x157\x3"+
		"\x2\x2\x2k\x15D\x3\x2\x2\x2m\x164\x3\x2\x2\x2o\x16A\x3\x2\x2\x2q\x171"+
		"\x3\x2\x2\x2s\x177\x3\x2\x2\x2uv\a\x31\x2\x2vw\a,\x2\x2wx\a,\x2\x2xy\x3"+
		"\x2\x2\x2yz\b\x2\x2\x2z{\b\x2\x3\x2{|\b\x2\x4\x2|\x6\x3\x2\x2\x2}~\a\x31"+
		"\x2\x2~\x7F\a,\x2\x2\x7F\x80\x3\x2\x2\x2\x80\x81\b\x3\x2\x2\x81\x82\b"+
		"\x3\x5\x2\x82\x83\b\x3\x4\x2\x83\b\x3\x2\x2\x2\x84\x85\a\x31\x2\x2\x85"+
		"\x86\a\x31\x2\x2\x86\x8A\x3\x2\x2\x2\x87\x89\n\x2\x2\x2\x88\x87\x3\x2"+
		"\x2\x2\x89\x8C\x3\x2\x2\x2\x8A\x88\x3\x2\x2\x2\x8A\x8B\x3\x2\x2\x2\x8B"+
		"\x8D\x3\x2\x2\x2\x8C\x8A\x3\x2\x2\x2\x8D\x8E\b\x4\x4\x2\x8E\n\x3\x2\x2"+
		"\x2\x8F\x90\av\x2\x2\x90\x91\at\x2\x2\x91\x92\aw\x2\x2\x92\x93\ag\x2\x2"+
		"\x93\f\x3\x2\x2\x2\x94\x95\ah\x2\x2\x95\x96\a\x63\x2\x2\x96\x97\an\x2"+
		"\x2\x97\x98\au\x2\x2\x98\x99\ag\x2\x2\x99\xE\x3\x2\x2\x2\x9A\x9B\ap\x2"+
		"\x2\x9B\x9C\aw\x2\x2\x9C\x9D\an\x2\x2\x9D\x9E\an\x2\x2\x9E\x10\x3\x2\x2"+
		"\x2\x9F\xA0\a<\x2\x2\xA0\x12\x3\x2\x2\x2\xA1\xA2\a<\x2\x2\xA2\xA3\a<\x2"+
		"\x2\xA3\x14\x3\x2\x2\x2\xA4\xA5\a.\x2\x2\xA5\x16\x3\x2\x2\x2\xA6\xA7\a"+
		"=\x2\x2\xA7\x18\x3\x2\x2\x2\xA8\xA9\a*\x2\x2\xA9\x1A\x3\x2\x2\x2\xAA\xAB"+
		"\a+\x2\x2\xAB\x1C\x3\x2\x2\x2\xAC\xAD\a>\x2\x2\xAD\x1E\x3\x2\x2\x2\xAE"+
		"\xAF\a@\x2\x2\xAF \x3\x2\x2\x2\xB0\xB1\a?\x2\x2\xB1\"\x3\x2\x2\x2\xB2"+
		"\xB3\a\x41\x2\x2\xB3$\x3\x2\x2\x2\xB4\xB5\a,\x2\x2\xB5&\x3\x2\x2\x2\xB6"+
		"\xB7\a-\x2\x2\xB7(\x3\x2\x2\x2\xB8\xB9\a~\x2\x2\xB9*\x3\x2\x2\x2\xBA\xBB"+
		"\a&\x2\x2\xBB,\x3\x2\x2\x2\xBC\xBD\a\x30\x2\x2\xBD.\x3\x2\x2\x2\xBE\xBF"+
		"\a\x42\x2\x2\xBF\x30\x3\x2\x2\x2\xC0\xC1\a%\x2\x2\xC1\x32\x3\x2\x2\x2"+
		"\xC2\xC3\a\x80\x2\x2\xC3\x34\x3\x2\x2\x2\xC4\xC5\a}\x2\x2\xC5\x36\x3\x2"+
		"\x2\x2\xC6\xC7\a\x7F\x2\x2\xC7\x38\x3\x2\x2\x2\xC8\xC9\a]\x2\x2\xC9:\x3"+
		"\x2\x2\x2\xCA\xCB\a_\x2\x2\xCB<\x3\x2\x2\x2\xCC\xD0\x5\x41 \x2\xCD\xCF"+
		"\x5?\x1F\x2\xCE\xCD\x3\x2\x2\x2\xCF\xD2\x3\x2\x2\x2\xD0\xCE\x3\x2\x2\x2"+
		"\xD0\xD1\x3\x2\x2\x2\xD1>\x3\x2\x2\x2\xD2\xD0\x3\x2\x2\x2\xD3\xD6\x5\x41"+
		" \x2\xD4\xD6\t\x3\x2\x2\xD5\xD3\x3\x2\x2\x2\xD5\xD4\x3\x2\x2\x2\xD6@\x3"+
		"\x2\x2\x2\xD7\xD8\t\x4\x2\x2\xD8\x42\x3\x2\x2\x2\xD9\xDC\x5I$\x2\xDA\xDC"+
		"\x5O\'\x2\xDB\xD9\x3\x2\x2\x2\xDB\xDA\x3\x2\x2\x2\xDC\x44\x3\x2\x2\x2"+
		"\xDD\xDF\x5K%\x2\xDE\xDD\x3\x2\x2\x2\xDF\xE0\x3\x2\x2\x2\xE0\xDE\x3\x2"+
		"\x2\x2\xE0\xE1\x3\x2\x2\x2\xE1\xE2\x3\x2\x2\x2\xE2\xE4\a\x30\x2\x2\xE3"+
		"\xE5\x5K%\x2\xE4\xE3\x3\x2\x2\x2\xE5\xE6\x3\x2\x2\x2\xE6\xE4\x3\x2\x2"+
		"\x2\xE6\xE7\x3\x2\x2\x2\xE7\x46\x3\x2\x2\x2\xE8\xE9\x5\x45\"\x2\xE9\xEB"+
		"\t\x5\x2\x2\xEA\xEC\x5M&\x2\xEB\xEA\x3\x2\x2\x2\xEB\xEC\x3\x2\x2\x2\xEC"+
		"\xEE\x3\x2\x2\x2\xED\xEF\x5K%\x2\xEE\xED\x3\x2\x2\x2\xEF\xF0\x3\x2\x2"+
		"\x2\xF0\xEE\x3\x2\x2\x2\xF0\xF1\x3\x2\x2\x2\xF1H\x3\x2\x2\x2\xF2\xF4\x5"+
		"K%\x2\xF3\xF2\x3\x2\x2\x2\xF4\xF5\x3\x2\x2\x2\xF5\xF3\x3\x2\x2\x2\xF5"+
		"\xF6\x3\x2\x2\x2\xF6J\x3\x2\x2\x2\xF7\xF8\t\x6\x2\x2\xF8L\x3\x2\x2\x2"+
		"\xF9\xFA\t\a\x2\x2\xFAN\x3\x2\x2\x2\xFB\xFC\a\x32\x2\x2\xFC\x100\az\x2"+
		"\x2\xFD\xFE\a\x32\x2\x2\xFE\x100\aZ\x2\x2\xFF\xFB\x3\x2\x2\x2\xFF\xFD"+
		"\x3\x2\x2\x2\x100\x104\x3\x2\x2\x2\x101\x103\x5Q(\x2\x102\x101\x3\x2\x2"+
		"\x2\x103\x106\x3\x2\x2\x2\x104\x102\x3\x2\x2\x2\x104\x105\x3\x2\x2\x2"+
		"\x105P\x3\x2\x2\x2\x106\x104\x3\x2\x2\x2\x107\x108\t\b\x2\x2\x108R\x3"+
		"\x2\x2\x2\x109\x10E\a)\x2\x2\x10A\x10D\x5W+\x2\x10B\x10D\n\t\x2\x2\x10C"+
		"\x10A\x3\x2\x2\x2\x10C\x10B\x3\x2\x2\x2\x10D\x110\x3\x2\x2\x2\x10E\x10C"+
		"\x3\x2\x2\x2\x10E\x10F\x3\x2\x2\x2\x10F\x111\x3\x2\x2\x2\x110\x10E\x3"+
		"\x2\x2\x2\x111\x112\a)\x2\x2\x112T\x3\x2\x2\x2\x113\x118\a)\x2\x2\x114"+
		"\x117\x5W+\x2\x115\x117\n\t\x2\x2\x116\x114\x3\x2\x2\x2\x116\x115\x3\x2"+
		"\x2\x2\x117\x11A\x3\x2\x2\x2\x118\x116\x3\x2\x2\x2\x118\x119\x3\x2\x2"+
		"\x2\x119V\x3\x2\x2\x2\x11A\x118\x3\x2\x2\x2\x11B\x120\a^\x2\x2\x11C\x121"+
		"\t\n\x2\x2\x11D\x121\x5Y,\x2\x11E\x121\v\x2\x2\x2\x11F\x121\a\x2\x2\x3"+
		"\x120\x11C\x3\x2\x2\x2\x120\x11D\x3\x2\x2\x2\x120\x11E\x3\x2\x2\x2\x120"+
		"\x11F\x3\x2\x2\x2\x121X\x3\x2\x2\x2\x122\x12D\aw\x2\x2\x123\x12B\x5[-"+
		"\x2\x124\x129\x5[-\x2\x125\x127\x5[-\x2\x126\x128\x5[-\x2\x127\x126\x3"+
		"\x2\x2\x2\x127\x128\x3\x2\x2\x2\x128\x12A\x3\x2\x2\x2\x129\x125\x3\x2"+
		"\x2\x2\x129\x12A\x3\x2\x2\x2\x12A\x12C\x3\x2\x2\x2\x12B\x124\x3\x2\x2"+
		"\x2\x12B\x12C\x3\x2\x2\x2\x12C\x12E\x3\x2\x2\x2\x12D\x123\x3\x2\x2\x2"+
		"\x12D\x12E\x3\x2\x2\x2\x12EZ\x3\x2\x2\x2\x12F\x130\t\b\x2\x2\x130\\\x3"+
		"\x2\x2\x2\x131\x133\t\v\x2\x2\x132\x131\x3\x2\x2\x2\x133\x134\x3\x2\x2"+
		"\x2\x134\x132\x3\x2\x2\x2\x134\x135\x3\x2\x2\x2\x135\x136\x3\x2\x2\x2"+
		"\x136\x137\b.\x4\x2\x137^\x3\x2\x2\x2\x138\x139\v\x2\x2\x2\x139\x13A\x3"+
		"\x2\x2\x2\x13A\x13B\b/\x4\x2\x13B`\x3\x2\x2\x2\x13C\x13E\a\xF\x2\x2\x13D"+
		"\x13C\x3\x2\x2\x2\x13D\x13E\x3\x2\x2\x2\x13E\x13F\x3\x2\x2\x2\x13F\x140"+
		"\a\f\x2\x2\x140\x141\x3\x2\x2\x2\x141\x142\b\x30\x2\x2\x142\x143\b\x30"+
		"\x4\x2\x143\x62\x3\x2\x2\x2\x144\x145\t\f\x2\x2\x145\x146\x3\x2\x2\x2"+
		"\x146\x147\b\x31\x2\x2\x147\x148\b\x31\x4\x2\x148\x64\x3\x2\x2\x2\x149"+
		"\x14B\n\r\x2\x2\x14A\x149\x3\x2\x2\x2\x14B\x14C\x3\x2\x2\x2\x14C\x14A"+
		"\x3\x2\x2\x2\x14C\x14D\x3\x2\x2\x2\x14D\x14E\x3\x2\x2\x2\x14E\x14F\b\x32"+
		"\x2\x2\x14F\x150\b\x32\x4\x2\x150\x66\x3\x2\x2\x2\x151\x152\a,\x2\x2\x152"+
		"\x153\a\x31\x2\x2\x153\x154\x3\x2\x2\x2\x154\x155\b\x33\x6\x2\x155\x156"+
		"\b\x33\x4\x2\x156h\x3\x2\x2\x2\x157\x158\a,\x2\x2\x158\x159\x3\x2\x2\x2"+
		"\x159\x15A\b\x34\x2\x2\x15A\x15B\b\x34\x4\x2\x15Bj\x3\x2\x2\x2\x15C\x15E"+
		"\a\xF\x2\x2\x15D\x15C\x3\x2\x2\x2\x15D\x15E\x3\x2\x2\x2\x15E\x15F\x3\x2"+
		"\x2\x2\x15F\x160\a\f\x2\x2\x160\x161\x3\x2\x2\x2\x161\x162\b\x35\x2\x2"+
		"\x162\x163\b\x35\x4\x2\x163l\x3\x2\x2\x2\x164\x165\t\f\x2\x2\x165\x166"+
		"\x3\x2\x2\x2\x166\x167\b\x36\x2\x2\x167\x168\b\x36\x4\x2\x168n\x3\x2\x2"+
		"\x2\x169\x16B\n\r\x2\x2\x16A\x169\x3\x2\x2\x2\x16B\x16C\x3\x2\x2\x2\x16C"+
		"\x16A\x3\x2\x2\x2\x16C\x16D\x3\x2\x2\x2\x16D\x16E\x3\x2\x2\x2\x16E\x16F"+
		"\b\x37\x2\x2\x16F\x170\b\x37\x4\x2\x170p\x3\x2\x2\x2\x171\x172\a,\x2\x2"+
		"\x172\x173\a\x31\x2\x2\x173\x174\x3\x2\x2\x2\x174\x175\b\x38\x6\x2\x175"+
		"\x176\b\x38\x4\x2\x176r\x3\x2\x2\x2\x177\x178\a,\x2\x2\x178\x179\x3\x2"+
		"\x2\x2\x179\x17A\b\x39\x2\x2\x17A\x17B\b\x39\x4\x2\x17Bt\x3\x2\x2\x2\x1E"+
		"\x2\x3\x4\x8A\xD0\xD5\xDB\xE0\xE6\xEB\xF0\xF5\xFF\x104\x10C\x10E\x116"+
		"\x118\x120\x127\x129\x12B\x12D\x134\x13D\x14C\x15D\x16C\a\x5\x2\x2\x4"+
		"\x3\x2\x2\x3\x2\x4\x4\x2\x4\x2\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace MetaDslx.Compiler
