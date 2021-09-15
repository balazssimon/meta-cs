lexer grammar CoreLexer;

options
{
	                      
}

channels
{
	COMMENT,
	WHITESPACE
}

@lexer::members {
    public int _brackets = 0;
}

// Keywords
                                                          
KNamespace : 'namespace';
KUsing : 'using';
KExtern : 'extern';
KAbstract : 'abstract';
KInterface : 'interface';
KClass : 'class';
KStruct : 'struct';
KEnum : 'enum';
KNew : 'new';
KNull : 'null';
KTrue : 'true';
KFalse : 'false';
KDynamic : 'dynamic';
KObject : 'object';
KVoid : 'void';
KBool : 'bool';
KChar : 'char';
KSByte : 'sbyte';
KByte : 'byte';
KShort : 'short';
KUShort : 'ushort';
KInt : 'int';
KUInt : 'uint';
KLong : 'long';
KULong : 'ulong';
KDecimal : 'decimal';
KFloat : 'float';
KDouble : 'double';
KString : 'string';
KTypeof : 'typeof';
KNameof : 'nameof';
KSizeof : 'sizeof';
KDefault : 'default';
KChecked : 'checked';
KUnchecked : 'unchecked';
KAs : 'as';
KIs : 'is';
KNot : 'not';
KThis : 'this';
KBase : 'base';
KAsync : 'async';
KAwait : 'await';
KConst : 'const';
KReadonly : 'readonly';
KDiscard : '_';
KFor : 'for';
KTo : 'to';
KForEach : 'foreach';
KIn : 'in';
KWhile : 'while';
KDo : 'do';
KRepeat : 'repeat';
KUntil : 'until';
KIf : 'if';
KElse : 'else';
KSwitch : 'switch';
KCase : 'case';
KTry : 'try';
KThrow : 'throw';
KCatch : 'catch';
KFinally : 'finally';
KBreak : 'break';
KContinue : 'continue';
KReturn : 'return';
KLock : 'lock';
KStatic : 'static';

// Tokens
TQuestionDot : '?.';
TQuestionOpenBracket : '?[';
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
TArrow : '=>';
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
TDotDot : '..';

TSemicolon : ';';
TColon : ':';
TDot : '.';
                             
TComma : ',';
TAssign : '=';
TOpenParen : '(';
TCloseParen : ')';
TOpenBracket : '[' { _brackets++; };
TCloseBracket : ']' { _brackets--; };
TOpenBrace : '{';
TCloseBrace : '}';
TLessThan : '<';
TGreaterThan : '>';
TQuestion : '?';

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

                   
LInteger : DecimalDigits | Hexadecimal;
                   
LDecimal : DecimalDigit+ '.' DecimalDigit+;
                   
LScientific : LDecimal [eE] Sign? DecimalDigit+;
fragment DecimalDigits : DecimalDigit+;
fragment DecimalDigit : [0-9];
fragment Sign : '+' | '-';
fragment Hexadecimal : ('0x'|'0X') HexDigit*;
fragment HexDigit : [0-9a-fA-F];

                   
LDateTimeOffset : LDate 'T' LTime TimeZone;
                   
LDateTime : LDate 'T' LTime;
                   
LDate : Sign? DateYear '-' DateMonth '-' DateDay;
                   
LTime : TimeHourMinute ':' TimeSecond;

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
fragment TimeMinute: [0-5] DecimalDigit;
fragment TimeSecond: [0-5] DecimalDigit TimeSecondDecimalPart?;
fragment TimeSecondDecimalPart: '.' DecimalDigits;

                   
LRegularString
    : '"' DoubleQuoteTextCharacter* '"'
    | '\'' SingleQuoteTextCharacter* '\'';

DoubleQuoteVerbatimStringLiteralStart : '@"' -> more, mode(DOUBLEQUOTE_VERBATIM_STRING);
SingleQuoteVerbatimStringLiteralStart : '@\'' -> more, mode(SINGLEQUOTE_VERBATIM_STRING);
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

                   
LGuid : '#[' HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit
                   HexDigit '-' HexDigit HexDigit HexDigit HexDigit '-'
                   HexDigit HexDigit HexDigit HexDigit '-'
                   HexDigit HexDigit HexDigit HexDigit '-'
                   HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit HexDigit
                   HexDigit HexDigit HexDigit HexDigit HexDigit ']';

// Whitespace and comments
                       
LUtf8Bom : [\u00EF][\u00BB][\u00BF] -> channel(WHITESPACE);
                                               
LWhiteSpace : [\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> channel(WHITESPACE);
                                                              
LCrLf : '\r'? '\n' -> channel(WHITESPACE);
                                       
LLineEnd : [\u0085\u2028\u2029] -> channel(WHITESPACE);

                           
LSingleLineComment : '//' ~[\r\n]* -> channel(COMMENT);
LCommentStart : '/*' -> more, mode(LMultilineComment);

                           
mode LMultilineComment;

LComment_CrLf : '\r'? '\n' -> more;
LComment_LineBreak : [\u0085\u2028\u2029] -> more;
LComment_Text : ~[\u002A\r\n\u0085\u2028\u2029]+ -> more;
                           
LComment : '*/' -> mode(DEFAULT_MODE), channel(COMMENT);
LComment_Star : '*' -> more;

                   
mode DOUBLEQUOTE_VERBATIM_STRING;

DoubleQuoteVerbatimStringText : DoubleQuoteTextVerbatimCharacter -> more;
                   
LDoubleQuoteVerbatimString : '"' -> mode(DEFAULT_MODE);

                   
mode SINGLEQUOTE_VERBATIM_STRING;

SingleQuoteVerbatimStringText : SingleQuoteTextVerbatimCharacter -> more;
                   
LSingleQuoteVerbatimString : '\'' -> mode(DEFAULT_MODE);

