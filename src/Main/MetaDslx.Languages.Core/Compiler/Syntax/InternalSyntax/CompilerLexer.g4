lexer grammar CompilerLexer;

options
{
	                      
}

channels
{
	COMMENT,
	WHITESPACE
}

// Keywords
                                                       
KNamespace : 'namespace';
KGrammar : 'grammar';
KOptions : 'options';
KFragment : 'fragment';
KHidden : 'hidden';
KTrue : 'true';
KFalse : 'false';
KNull : 'null';
KEof : 'EOF';

// Tokens
TSemicolon : ';';
TArrow : '->';
TDot : '.';
TNonGreedyZeroOrOne : '??';
TNonGreedyZeroOrMore : '*?';
TNonGreedyOneOrMore : '+?';
TZeroOrOne : '?';
TZeroOrMore : '*';
TOneOrMore : '+';
TNegate : '~';
TAssign : '=';
TQuestionAssign : '?=';
TNegatedAssign : '!=';
TPlusAssign : '+=';
TBar : '|';
TAmpersand : '&';
TColon : ':';
                             
TComma : ',';
TOpenParen : '(';
TCloseParen : ')';
TOpenBracket : '[';
TCloseBracket : ']';
TOpenBrace : '{';
TCloseBrace : '}';
TLessThan : '<';
TGreaterThan : '>';

                                               
LexerIdentifier : '@'? LexerIdentifierBegin IdentifierCharacter*;
                       
ParserIdentifier : '@'? ParserIdentifierBegin IdentifierCharacter*;
fragment LexerIdentifierBegin : [a-z];
fragment ParserIdentifierBegin : [A-Z];
fragment IdentifierCharacter : [a-zA-Z0-9_];

                   
LInteger : DecimalDigits | Hexadecimal;
                   
LDecimal : DecimalDigit+ '.' DecimalDigit+;
                   
LScientific : LDecimal [eE] Sign? DecimalDigit+;
fragment DecimalDigits : DecimalDigit+;
fragment DecimalDigit : [0-9];
fragment Sign : '+' | '-';
fragment Hexadecimal : ('0x'|'0X') HexDigit*;
fragment HexDigit : [0-9a-fA-F];

                   
LString
    : DoubleQuoteString
    | SingleQuoteString
    | DoubleQuoteVerbatimString
    | SingleQuoteVerbatimString;

fragment DoubleQuoteString : '"' DoubleQuoteTextCharacter* '"';
fragment SingleQuoteString : '\'' SingleQuoteTextCharacter* '\'';
fragment DoubleQuoteVerbatimString : '@"' DoubleQuoteTextVerbatimCharacter* '"';
fragment SingleQuoteVerbatimString : '@\'' SingleQuoteTextVerbatimCharacter* '\'';
fragment SingleQuoteTextCharacter 
    : SingleQuoteTextSimple | CharacterEscapeSimple | CharacterEscapeUnicode;
fragment SingleQuoteTextSimple 
    : ~('\'' | '\\' | '\u000A' | '\u000D' | '\u0085' | '\u2028' | '\u2029');
fragment SingleQuoteTextVerbatimCharacter 
    : ~'\'' | SingleQuoteTextVerbatimCharacterEscape;
fragment SingleQuoteTextVerbatimCharacterEscape : '\'' '\'';
fragment SingleQuoteTextVerbatimCharacters : SingleQuoteTextVerbatimCharacter+;
fragment DoubleQuoteTextCharacter 
    : DoubleQuoteTextSimple | CharacterEscapeSimple | CharacterEscapeUnicode;
fragment DoubleQuoteTextSimple 
    : ~('"' | '\\' | '\u000A' | '\u000D' | '\u0085' | '\u2028' | '\u2029');
fragment DoubleQuoteTextVerbatimCharacter 
    : ~'"' | DoubleQuoteTextVerbatimCharacterEscape;
fragment DoubleQuoteTextVerbatimCharacterEscape : '"' '"';
fragment DoubleQuoteTextVerbatimCharacters : DoubleQuoteTextVerbatimCharacter+;
fragment CharacterEscapeSimple : '\\' CharacterEscapeSimpleCharacter;
fragment CharacterEscapeSimpleCharacter 
    : '\'' | '"' | '\\' | '0' | 'a' | 'b' | 'f' | 'n' | 'r' | 't' | 'v'; 
fragment CharacterEscapeUnicode
    : '\\u' HexDigit HexDigit HexDigit HexDigit
    | '\\U' HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit;

// Whitespace and comments
                       
LUtf8Bom : [\u00EF][\u00BB][\u00BF] -> channel(WHITESPACE);
                                               
LWhiteSpace : [\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> channel(WHITESPACE);
                                                              
LCrLf : '\r'? '\n' -> channel(WHITESPACE);
                                       
LLineEnd : [\u0085\u2028\u2029] -> channel(WHITESPACE);

                           
LSingleLineComment : '//' ~[\r\n]* -> channel(COMMENT);
                           
LMultilineComment : '/*' .*? '*/' -> channel(COMMENT);

