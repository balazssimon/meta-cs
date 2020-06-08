lexer grammar PilLexer;

options
{
	                      
}

channels
{
	COMMENT,
	WHITESPACE
}

// Keywords
                                                      
KTypeDef: 'TYPE';
KEnum: 'ENUM';

KFunction: 'FUNCTION';
KEndFunction: 'EFUNCTION';
KResult: 'RESULT';

KFork: 'FORK';
KEndFork: 'EFORK';
KCase: 'CASE';
KElse: 'ELSE';

KIf: 'IF';
KEndIf: 'EIF';

KQuery: 'QUERY';
KEndQuery: 'EQUERY';
KPulse: 'PULSE';
KStatic: 'STATIC';

KObject: 'OBJECT';
KEndObject: 'EOBJECT';

KTrigger: 'TRIGGER';
KInput: 'INPUT';
KOnAccepted: 'ON_ACCEPTED';
KOnRefused: 'ON_REFUSED';
KOnCancel: 'ON_CANCELLED';

KAssert: 'ASSERT';
KRequest: 'REQ';
KAccept: 'ACCEPT';
KRefuse: 'REFUSE';
KCancel: 'CANCEL';

KVar: 'VAR';
KParam: 'PARAM';

KUndo: 'UNDO';

KTrue: 'TRUE';
KFalse: 'FALSE';

KInt: 'int';
KBool: 'bool';
KString: 'string';
KObjectType: 'object';

KIn: 'in';

KNull: 'NULL';


TSemicolon : ';';
TColon : ':';
TDot : '.';
                             
TComma : ',';
TAssign : ':=';
TOpenParen : '(';
TCloseParen : ')';
TOpenBracket : '[';
TCloseBracket : ']';
TOpenBrace : '{';
TCloseBrace : '}';
TLessThan : '<';
TGreaterThan : '>';
TQuestion : '?';

TQuestionQuestion : '??';
TAmpersand : '&';
THat : '^';
TBar : '|';
TAndAlso : '&&';
TOrElse : '||';
TPlusPlus : '++';
TMinusMinus : '--';
TPlus : '+';
TMinus : '-';
TTilde : '~';
TExclamation : '!';
TSlash : '/';
TAsterisk : '*';
TPercent : '%';
TLessThanOrEqual : '<=';
TGreaterThanOrEqual : '>=';
TEqual : '=';
TNotEqual : '!=';
TAsteriskAssign : '*=';
TSlashAssign : '/=';
TPercentAssign : '%=';
TPlusAssign : '+=';
TMinusAssign : '-=';
TLeftShiftAssign : '<<=';
TRightShiftAssign : '>>=';
TAmpersandAssign : '&=';
THatAssign : '^=';
TBarAssign : '|=';


                                               
LIdentifier : IdentifierBegin IdentifierCharacter*;
fragment IdentifierBegin : [a-zA-Z_];
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
    : '"' DoubleQuoteTextCharacter* '"'
    | '\'' SingleQuoteTextCharacter* '\'';

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
LMultiLineComment : '/*' .*? '*/' -> channel(COMMENT);

