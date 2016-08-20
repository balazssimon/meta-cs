﻿lexer grammar SoalLexer;

                                                              
KNamespace : 'namespace';
KEnum : 'enum';
KException : 'exception';
KStruct : 'struct';
KInterface : 'interface';
KThrows : 'throws';
KOneway : 'oneway';
KReturn : 'return';
KBinding : 'binding';
KTransport : 'transport';
KEncoding : 'encoding';
KProtocol : 'protocol';
KEndpoint : 'endpoint';
KAddress : 'address';
KDatabase : 'database';
KEntity : 'entity';
KAbstract : 'abstract';
KComponent : 'component';
KComposite : 'composite';
KReference : 'reference';
KService : 'service';
KWire : 'wire';
KTo : 'to';
KImplementation : 'implementation';
KLanguage : 'language';
KAssembly : 'assembly';
KDeployment : 'deployment';
KEnvironment : 'environment';
KRuntime : 'runtime';

KNull : 'null';
KTrue : 'true';
KFalse : 'false';

KObject : 'object';
KString : 'string';
KInt : 'int';
KLong : 'long';
KFloat : 'float';
KDouble : 'double';
KByte : 'byte';
KBool : 'bool';
KAny : 'any';
KVoid : 'void';
KTypeof : 'typeof';


TSemicolon : ';';
TColon : ':';
TDot : '.';
TComma : ',';
TAssign : '=';
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
TEqual : '==';
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

IDate : 'Date';
ITime : 'Time';
IDateTime : 'DateTime';
ITimeSpan : 'TimeSpan';
IVersion : 'Version';
IStyle : 'Style';
IMTOM : 'MTOM';
ISSL : 'SSL';
IHTTP : 'HTTP';
IREST : 'REST';
IWebSocket : 'WebSocket';
ISOAP : 'SOAP';
IXML : 'XML';
IJSON : 'JSON';
IClientAuthentication : 'ClientAuthentication';

                                   
IdentifierNormal : IdentifierBegin IdentifierCharacter*;
                                   
IdentifierVerbatim : '@' IdentifierBegin IdentifierCharacter*;
fragment IdentifierBegin : [a-zA-Z_];
fragment IdentifierCharacter : [a-zA-Z0-9_];
fragment IdentifierVerbatimCharacter : ~[\]] | IdentifierVerbatimEscape;
fragment IdentifierVerbatimEscape : '\\\\' | '\\]';
fragment IdentifierGeneralBegin : [a-zA-Z_];
fragment IdentifierGeneralCharacter : [a-zA-Z0-9_];

                               
IntegerLiteral : DecimalDigits | Hexadecimal;
                               
DecimalLiteral : DecimalDigit+ '.' DecimalDigit+;
                               
ScientificLiteral : DecimalLiteral [eE] Sign? DecimalDigit+;
fragment DecimalDigits : DecimalDigit+;
fragment DecimalDigit : [0-9];
fragment Sign : '+' | '-';
fragment Hexadecimal : ('0x'|'0X') HexDigit*;
fragment HexDigit : [0-9a-fA-F];

                               
DateTimeOffsetLiteral : DateLiteral 'T' TimeLiteral TimeZone;
                               
DateTimeLiteral : DateLiteral 'T' TimeLiteral;
                               
DateLiteral : Sign? DateYear '-' DateMonth '-' DateDay;
                               
TimeLiteral : TimeHourMinute ':' TimeSecond;
fragment DateDay
    : '01' | '02' | '03' | '04' | '05' | '06' | '07' | '08' | '09' | '10'
    | '11' | '12' | '13' | '14' | '15'
    | '16' | '17' | '18' | '19' | '20' | '21' | '22' | '23' | '24' | '25'
    | '26' | '27' | '28' | '29' | '30'
    | '31';
fragment DateMonth 
    : '01' | '02' | '03' | '04' | '05' | '06' | '07' | '08' | '09' | '10' 
    | '11' | '12';
fragment DateYear : DecimalDigit DecimalDigit DecimalDigit DecimalDigit;
fragment TimeZone: Sign OffsetTimeHourMinute | 'Z';
fragment OffsetTimeHour
    : '00' | '01' | '02' | '03' | '04' | '05' | '06' | '07' | '08' | '09'
    | '10' | '11' | '12' | '13' | '14';
fragment OffsetTimeHourMinute: OffsetTimeHour ':' TimeMinute;
fragment TimeHour
    : '00' | '01' | '02' | '03' | '04' | '05' | '06' | '07' | '08' | '09'
    | '10' | '11'
    | '12' | '13' | '14' | '15' | '16' | '17' | '18' | '19' | '20' | '21'
    | '22' | '23';
fragment TimeHourMinute: TimeHour ':' TimeMinute;
fragment TimeMinute: ['0'-'5'] DecimalDigit;
fragment TimeSecond: ['0'-'5'] DecimalDigit TimeSecondDecimalPart?;
fragment TimeSecondDecimalPart: '.' DecimalDigits;

                               
RegularStringLiteral
    : '"' DoubleQuoteTextCharacter* '"'
    | '\'' SingleQuoteTextCharacter* '\'';

DoubleQuoteVerbatimStringLiteralStart : '@"' -> more, mode(DOUBLEQUOTE_VERBATIM_STRING);
SingleQuoteVerbatimStringLiteralStart : '@''' -> more, mode(SINGLEQUOTE_VERBATIM_STRING);
fragment SingleQuoteTextCharacter 
    : SingleQuoteTextSimple | CharacterEscapeSimple | CharacterEscapeUnicode;
fragment SingleQuoteTextSimple 
    : ~('\'' | '\\' | '\u000A' | '\u000D' | '\u0085' | '\u2028' | '\u2029');
fragment SingleQuoteTextVerbatimCharacter 
    : ~['\''] | SingleQuoteTextVerbatimCharacterEscape;
fragment SingleQuoteTextVerbatimCharacterEscape : '\'' '\'';
fragment SingleQuoteTextVerbatimCharacters : SingleQuoteTextVerbatimCharacter+;
fragment DoubleQuoteTextCharacter 
    : DoubleQuoteTextSimple | CharacterEscapeSimple | CharacterEscapeUnicode;
fragment DoubleQuoteTextSimple 
    : ~('"' | '\\' | '\u000A' | '\u000D' | '\u0085' | '\u2028' | '\u2029');
fragment DoubleQuoteTextVerbatimCharacter 
    : ~['"'] | DoubleQuoteTextVerbatimCharacterEscape;
fragment DoubleQuoteTextVerbatimCharacterEscape : '"' '"';
fragment DoubleQuoteTextVerbatimCharacters : DoubleQuoteTextVerbatimCharacter+;
fragment CharacterEscapeSimple : '\\' CharacterEscapeSimpleCharacter;
fragment CharacterEscapeSimpleCharacter 
    : '\'' | '"' | '\\' | '0' | 'a' | 'b' | 'f' | 'n' | 'r' | 't' | 'v'; 
fragment CharacterEscapeUnicode
    : '\\u' HexDigit HexDigit HexDigit HexDigit
    | '\\U' HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit;

                               
GuidLiteral : '#[' HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit
                   HexDigit '-' HexDigit HexDigit HexDigit HexDigit '-'
                   HexDigit HexDigit HexDigit HexDigit '-'
                   HexDigit HexDigit HexDigit HexDigit '-'
                   HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit
                   HexDigit HexDigit HexDigit HexDigit HexDigit ']';

// Whitespace and comments
UTF8BOM : [\u00EF][\u00BB][\u00BF] -> channel(WHITESPACE);
WHITESPACE : [\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> channel(WHITESPACE);
CRLF : '\r'? '\n' -> channel(WHITESPACE);
LINEBREAK : [\u0085\u2028\u2029] -> channel(WHITESPACE);

                                
LINE_COMMENT : '//' ~[\r\n]* -> channel(COMMENT);
COMMENT_START : '/*' -> more, mode(MULTILINE_COMMENT), channel(COMMENT);

                                
mode MULTILINE_COMMENT;

COMMENT_CRLF : '\r'? '\n' -> more, channel(COMMENT);
COMMENT_LINEBREAK : [\u0085\u2028\u2029] -> more, channel(COMMENT);
COMMENT_TEXT : ~[\*\r\n\u0085\u2028\u2029]+ -> more, channel(COMMENT);
                                
COMMENT : '*/' -> mode(DEFAULT_MODE), channel(COMMENT);
COMMENT_STAR : '*' -> more, channel(COMMENT);

                               
mode DOUBLEQUOTE_VERBATIM_STRING;

DoubleQuoteVerbatimStringText : DoubleQuoteTextVerbatimCharacter -> more;
                               
DoubleQuoteVerbatimStringLiteral : '"' -> mode(DEFAULT_MODE);

                               
mode SINGLEQUOTE_VERBATIM_STRING;

SingleQuoteVerbatimStringText : SingleQuoteTextVerbatimCharacter -> more;
                               
SingleQuoteVerbatimStringLiteral : '"' -> mode(DEFAULT_MODE);
