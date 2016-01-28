lexer grammar MetaModelLexer;

// Keywords
                                                              
KNamespace : 'namespace';
KUsing : 'using';
KMetamodel : 'metamodel';
KExtern : 'extern';
KTypeDef : 'typedef';
KAbstract : 'abstract';
KClass : 'class';
KEnum : 'enum';
KAssociation : 'association';
KContainment : 'containment';
KWith : 'with';
KNew : 'new';
KNull : 'null';
KTrue : 'true';
KFalse : 'false';
KVoid : 'void';
KObject : 'object';
KString : 'string';
KInt : 'int';
KLong : 'long';
KFloat : 'float';
KDouble : 'double';
KByte : 'byte';
KBool : 'bool';
KList : 'list';
KAny : 'any';
KNone : 'none';
KError : 'error';
KSet : 'set';
KMultiList : 'multi_list';
KMultiSet : 'multi_set';
KThis : 'this';
KTypeof : 'typeof';
KAs : 'as';
KIs : 'is';
KBase : 'base';
KConst : 'const';
KRedefines : 'redefines';
KSubsets : 'subsets';
KReadonly : 'readonly';
KLazy : 'lazy';
KSynthetized : 'synthetized';
KInherited : 'inherited';
KDerived : 'derived';
KStatic : 'static';

// Tokens
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

//IdentifierGeneral : IdentifierGeneralBegin IdentifierGeneralCharacter*;
                                   
IdentifierNormal : IdentifierBegin IdentifierCharacter*;
IdentifierVerbatim : '@' IdentifierBegin IdentifierCharacter*;
//IdentifierVerbatimStart : '@[' -> more, mode(VERBATIM_IDENTIFIER);
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

//DoubleQuoteVerbatimStringLiteralStart : '@"' -> more, mode(DOUBLEQUOTE_VERBATIM_STRING);
//SingleQuoteVerbatimStringLiteralStart : '@''' -> more, mode(SINGLEQUOTE_VERBATIM_STRING);
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

/*
mode DOUBLEQUOTE_VERBATIM_STRING;

DoubleQuoteVerbatimStringText : DoubleQuoteTextVerbatimCharacter -> more;
DoubleQuoteVerbatimStringLiteral : '"' -> mode(DEFAULT_MODE);

mode SINGLEQUOTE_VERBATIM_STRING;

SingleQuoteVerbatimStringText : SingleQuoteTextVerbatimCharacter -> more;
SingleQuoteVerbatimStringLiteral : '"' -> mode(DEFAULT_MODE);

mode VERBATIM_IDENTIFIER;

IdentifierVerbatimText : IdentifierVerbatimCharacter -> more;
IdentifierVerbatim : ']' -> mode(DEFAULT_MODE);
*/
