lexer grammar MetaGeneratorLexer;

@lexer::members {
    public int _templateParenthesis = 0;
    public int _templateBrackets = 0;
}

// Keywords
                                                               
KNamespace : 'namespace';
KGenerator : 'generator';
KUsing : 'using';
KConfiguration : 'configuration';
KProperties : 'properties';
KTemplate : 'template' {Mode(TEMPLATE_HEADER); _templateParenthesis=0;};
KFunction : 'function';
KReturn : 'return';
KSwitch : 'switch';
KCase : 'case';
KType : 'type';
KVoid : 'void';
KEnd : 'end';
KFor : 'for';
KForEach : 'foreach';
KIn : 'in';
KIf : 'if';
KElse : 'else';
KLoop : 'loop';
KHasLoop : 'hasloop';
KWhere : 'where';
KOrderBy : 'orderby';
KDescending : 'descending';
KSeparator : 'separator';
KNull : 'null';
KTrue : 'true';
KFalse : 'false';
KBool : 'bool' | 'boolean';
KByte : 'byte';
KChar : 'char';
KDecimal : 'decimal';
KDouble : 'double';
KFloat : 'float';
KInt : 'int';
KLong : 'long';
KObject : 'object';
KSByte : 'sbyte';
KShort : 'short';
KString : 'string';
KUInt : 'uint';
KULong : 'ulong';
KUShort : 'ushort';
KThis : 'this';
KNew : 'new';
KIs : 'is';
KAs : 'as';
KTypeof : 'typeof';
KDefault : 'default';

// Tokens
                                                                           
TSemicolon : ';';
TColon : ':';
TDot : '.';
TComma : ',';
TAssign : '=';
TAssignPlus : '+=';
TAssignMinus : '-=';
TAssignAsterisk : '*=';
TAssignSlash : '/=';
TAssignPercent : '%=';
TAssignAmp : '&=';
TAssignPipe : '|=';
TAssignHat : '^=';
TAssignLeftShift : '<<=';
TAssignRightShift : '>>=';
TOpenParenthesis : '(';
TCloseParenthesis : ')';
TOpenBracket : '[';
TCloseBracket : ']';
TOpenBrace : '{';
TCloseBrace : '}';
TEquals : '==';
TNotEquals : '!=';
TArrow : '=>';
TSingleArrow : '->';
TLessThan : '<';
TGreaterThan : '>';
TLessThanOrEquals : '<=';
TGreaterThanOrEquals : '>=';
TQuestion : '?';
TPlus : '+';
TMinus : '-';
TExclamation : '!';
TTilde : '~';
TAsterisk : '*';
TSlash : '/';
TPercent : '%';
TPlusPlus : '++';
TMinusMinus : '--';
TColonColon : '::';
TAmp : '&';
THat : '^';
TPipe : '|';
TAnd : '&&';
TXor : '^^';
TOr : '||';
TQuestionQuestion : '??';


                                   
IdentifierNormal : IdentifierBegin IdentifierCharacter*;
//IdentifierGeneral : IdentifierGeneralBegin IdentifierGeneralCharacter*;
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

                               
CharLiteral : '\'' SingleQuoteTextCharacter* '\'';

                               
RegularStringLiteral
    : '"' DoubleQuoteTextCharacter* '"';
//    | '\'' SingleQuoteTextCharacter* '\'';

                               
DoubleQuoteVerbatimStringLiteralStart : '@"' -> more, mode(DOUBLEQUOTE_VERBATIM_STRING);
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

                               
mode DOUBLEQUOTE_VERBATIM_STRING;

DoubleQuoteVerbatimStringText : DoubleQuoteTextVerbatimCharacter -> more;
DoubleQuoteVerbatimStringLiteral : '"' -> mode(DEFAULT_MODE);

/*
mode SINGLEQUOTE_VERBATIM_STRING;

SingleQuoteVerbatimStringText : SingleQuoteTextVerbatimCharacter -> more;
SingleQuoteVerbatimStringLiteral : '"' -> mode(DEFAULT_MODE);

mode VERBATIM_IDENTIFIER;

IdentifierVerbatimText : IdentifierVerbatimCharacter -> more;
IdentifierVerbatim : ']' -> mode(DEFAULT_MODE);
*/


mode TEMPLATE_HEADER;

TH_CRLF : '\r'? '\n' {Type=CRLF; Channel=WHITESPACE; };
TH_LINEBREAK : [\u0085\u2028\u2029] {Type=LINEBREAK; Channel=WHITESPACE; };
TH_WHITESPACE : [\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> type(WHITESPACE), channel(WHITESPACE);

TH_KEnd : KEnd -> type(KEnd);
TH_KFor : KFor -> type(KFor);
TH_KForEach : KForEach -> type(KForEach);
TH_KIn : KIn -> type(KIn);
TH_KIf : KIf -> type(KIf);
TH_KElse : KElse -> type(KElse);
TH_KLoop : KLoop -> type(KLoop);
TH_KHasLoop : KHasLoop -> type(KHasLoop);
TH_KWhere : KWhere -> type(KWhere);
TH_KOrderBy : KOrderBy -> type(KOrderBy);
TH_KDescending : KDescending -> type(KDescending);
TH_KNull : KNull -> type(KNull);
TH_KTrue : KTrue -> type(KTrue);
TH_KFalse : KFalse -> type(KFalse);
TH_KBool : KBool -> type(KBool);
TH_KByte : KByte -> type(KByte);
TH_KChar : KChar -> type(KChar);
TH_KDecimal : KDecimal -> type(KDecimal);
TH_KDouble : KDouble -> type(KDouble);
TH_KFloat : KFloat -> type(KFloat);
TH_KInt : KInt -> type(KInt);
TH_KLong : KLong -> type(KLong);
TH_KObject : KObject -> type(KObject);
TH_KSByte : KSByte -> type(KSByte);
TH_KShort : KShort -> type(KShort);
TH_KString : KString -> type(KString);
TH_KUInt : KUInt -> type(KUInt);
TH_KULong : KULong -> type(KULong);
TH_KUShort : KUShort -> type(KUShort);
TH_KThis : KThis -> type(KThis);
TH_KNew : KNew -> type(KNew);
TH_KIs : KIs -> type(KIs);
TH_KAs : KAs -> type(KAs);
TH_KTypeof : KTypeof -> type(KTypeof);
TH_KDefault : KDefault -> type(KDefault);

TH_TSemicolon : TSemicolon -> type(TSemicolon);
TH_TColon : TColon -> type(TColon);
TH_TDot : TDot -> type(TDot);
TH_TComma : TComma -> type(TComma);
TH_TAssign : TAssign -> type(TAssign);
TH_TAssignPlus : TAssignPlus -> type(TAssignPlus);
TH_TAssignMinus : TAssignMinus -> type(TAssignMinus);
TH_TAssignAsterisk : TAssignAsterisk -> type(TAssignAsterisk);
TH_TAssignSlash : TAssignSlash -> type(TAssignSlash);
TH_TAssignPercent : TAssignPercent -> type(TAssignPercent);
TH_TAssignAmp : TAssignAmp -> type(TAssignAmp);
TH_TAssignPipe : TAssignPipe -> type(TAssignPipe);
TH_TAssignHat : TAssignHat -> type(TAssignHat);
TH_TAssignLeftShift : TAssignLeftShift -> type(TAssignLeftShift);
TH_TAssignRightShift : TAssignRightShift -> type(TAssignRightShift);
TH_TOpenParenthesis : TOpenParenthesis {Type=TOpenParenthesis; _templateParenthesis++;};
                                 
TH_TCloseParenthesis : TCloseParenthesis {Type=TCloseParenthesis; _templateParenthesis--; if(_templateParenthesis == 0) Mode(TEMPLATE_OUTPUT); };
TH_TOpenBracket : TOpenBracket -> type(TCloseParenthesis);
TH_TCloseBracket : TCloseBracket -> type(TCloseParenthesis);
TH_TOpenBrace : TOpenBrace -> type(TOpenBrace);
TH_TCloseBrace : TCloseBrace -> type(TCloseBrace);
TH_TEquals : TEquals -> type(TEquals);
TH_TNotEquals : TNotEquals -> type(TNotEquals);
TH_TArrow : TArrow -> type(TArrow);
TH_TSingleArrow : TSingleArrow -> type(TSingleArrow);
TH_TLessThan : TLessThan -> type(TLessThan);
TH_TGreaterThan : TGreaterThan -> type(TGreaterThan);
TH_TLessThanOrEquals : TLessThanOrEquals -> type(TLessThanOrEquals);
TH_TGreaterThanOrEquals : TGreaterThanOrEquals -> type(TGreaterThanOrEquals);
TH_TQuestion : TQuestion -> type(TQuestion);
TH_TPlus : TPlus -> type(TPlus);
TH_TMinus : TMinus -> type(TMinus);
TH_TExclamation : TExclamation -> type(TExclamation);
TH_TTilde : TTilde -> type(TTilde);
TH_TAsterisk : TAsterisk -> type(TAsterisk);
TH_TSlash : TSlash -> type(TSlash);
TH_TPercent : TPercent -> type(TPercent);
TH_TPlusPlus : TPlusPlus -> type(TPlusPlus);
TH_TMinusMinus : TMinusMinus -> type(TMinusMinus);
TH_TColonColon : TColonColon -> type(TColonColon);
TH_TAmp : TAmp -> type(TAmp);
TH_THat : THat -> type(THat);
TH_TPipe : TPipe -> type(TPipe);
TH_TAnd : TAnd -> type(TAnd);
TH_TXor : TXor -> type(TXor);
TH_TOr : TOr -> type(TOr);
TH_TQuestionQuestion : TQuestionQuestion -> type(TQuestionQuestion);

TH_IdentifierNormal : IdentifierNormal -> type(IdentifierNormal);
TH_IntegerLiteral : IntegerLiteral -> type(IntegerLiteral);
TH_DecimalLiteral : DecimalLiteral -> type(DecimalLiteral);
TH_ScientificLiteral : ScientificLiteral -> type(ScientificLiteral);
TH_DateTimeOffsetLiteral : DateTimeOffsetLiteral -> type(DateTimeOffsetLiteral);
TH_DateTimeLiteral : DateTimeLiteral -> type(DateTimeLiteral);
TH_DateLiteral : DateLiteral -> type(DateLiteral);
TH_TimeLiteral : TimeLiteral -> type(TimeLiteral);
TH_CharLiteral : CharLiteral -> type(CharLiteral);
TH_RegularStringLiteral : RegularStringLiteral -> type(RegularStringLiteral);
TH_GuidLiteral : GuidLiteral -> type(GuidLiteral);

                                                    
mode TEMPLATE_OUTPUT;

                                
KEndTemplate : 'end template' ('\r'? '\n' | [\u0085\u2028\u2029]) -> mode(DEFAULT_MODE);

                                                     
TemplateLineControl : ('\\' | '^') [\u0020\u0009\u000B\u000C\u00A0\u001A]* (TemplateCrLf | TemplateLineBreak);
                                                    
TemplateOutput : (~[\\\^\[\r\n\u0085\u2028\u2029]+ | '\\' | '^');
                                                    
TemplateCrLf : '\r'? '\n';
                                                    
TemplateLineBreak : [\u0085\u2028\u2029];
                                                     
TemplateStatementStart : '[' {Mode(TEMPLATE_STATEMENT); _templateBrackets=0;};

mode TEMPLATE_STATEMENT;

TemplateStatementCrLf : '\r'? '\n' -> type(CRLF), channel(WHITESPACE), mode(TEMPLATE_OUTPUT);
TemplateStatementLineBreak : [\u0085\u2028\u2029] -> type(LINEBREAK), channel(WHITESPACE), mode(TEMPLATE_OUTPUT);
                                                     
TemplateStatementEnd : {_templateBrackets == 0}? ']' -> mode(TEMPLATE_OUTPUT);
TemplateStatement_COMMENT_START : '/*' -> more, mode(TEMPLATE_STATEMENT_COMMENT), channel(COMMENT);
TemplateStatement_WHITESPACE : [\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> type(WHITESPACE), channel(WHITESPACE);

TS_KSwitch : KSwitch -> type(KSwitch);
TS_KCase : KCase -> type(KCase);
TS_KType : KType -> type(KType);
TS_KEnd : KEnd -> type(KEnd);
TS_KFor : KFor -> type(KFor);
TS_KForEach : KForEach -> type(KForEach);
TS_KIn : KIn -> type(KIn);
TS_KIf : KIf -> type(KIf);
TS_KElse : KElse -> type(KElse);
TS_KLoop : KLoop -> type(KLoop);
TS_KHasLoop : KHasLoop -> type(KHasLoop);
TS_KWhere : KWhere -> type(KWhere);
TS_KOrderBy : KOrderBy -> type(KOrderBy);
TS_KDescending : KDescending -> type(KDescending);
TS_KNull : KNull -> type(KNull);
TS_KTrue : KTrue -> type(KTrue);
TS_KFalse : KFalse -> type(KFalse);
TS_KBool : KBool -> type(KBool);
TS_KByte : KByte -> type(KByte);
TS_KChar : KChar -> type(KChar);
TS_KDecimal : KDecimal -> type(KDecimal);
TS_KDouble : KDouble -> type(KDouble);
TS_KFloat : KFloat -> type(KFloat);
TS_KInt : KInt -> type(KInt);
TS_KLong : KLong -> type(KLong);
TS_KObject : KObject -> type(KObject);
TS_KSByte : KSByte -> type(KSByte);
TS_KShort : KShort -> type(KShort);
TS_KString : KString -> type(KString);
TS_KUInt : KUInt -> type(KUInt);
TS_KULong : KULong -> type(KULong);
TS_KUShort : KUShort -> type(KUShort);
TS_KThis : KThis -> type(KThis);
TS_KNew : KNew -> type(KNew);
TS_KIs : KIs -> type(KIs);
TS_KAs : KAs -> type(KAs);
TS_KTypeof : KTypeof -> type(KTypeof);
TS_KDefault : KDefault -> type(KDefault);

TS_TSemicolon : TSemicolon -> type(TSemicolon);
TS_TColon : TColon -> type(TColon);
TS_TDot : TDot -> type(TDot);
TS_TComma : TComma -> type(TComma);
TS_TAssign : TAssign -> type(TAssign);
TS_TAssignPlus : TAssignPlus -> type(TAssignPlus);
TS_TAssignMinus : TAssignMinus -> type(TAssignMinus);
TS_TAssignAsterisk : TAssignAsterisk -> type(TAssignAsterisk);
TS_TAssignSlash : TAssignSlash -> type(TAssignSlash);
TS_TAssignPercent : TAssignPercent -> type(TAssignPercent);
TS_TAssignAmp : TAssignAmp -> type(TAssignAmp);
TS_TAssignPipe : TAssignPipe -> type(TAssignPipe);
TS_TAssignHat : TAssignHat -> type(TAssignHat);
TS_TAssignLeftShift : TAssignLeftShift -> type(TAssignLeftShift);
TS_TAssignRightShift : TAssignRightShift -> type(TAssignRightShift);
TS_TOpenParenthesis : TOpenParenthesis -> type(TOpenParenthesis);
TS_TCloseParenthesis : TCloseParenthesis -> type(TCloseParenthesis);
TS_TOpenBracket : TOpenBracket {_templateBrackets++; Type=TOpenBracket;};
TS_TCloseBracket : {_templateBrackets>0}? TCloseBracket {_templateBrackets--; Type=TCloseBracket;};
TS_TOpenBrace : TOpenBrace -> type(TOpenBrace);
TS_TCloseBrace : TCloseBrace -> type(TCloseBrace);
TS_TEquals : TEquals -> type(TEquals);
TS_TNotEquals : TNotEquals -> type(TNotEquals);
TS_TArrow : TArrow -> type(TArrow);
TS_TSingleArrow : TSingleArrow -> type(TSingleArrow);
TS_TLessThan : TLessThan -> type(TLessThan);
TS_TGreaterThan : TGreaterThan -> type(TGreaterThan);
TS_TLessThanOrEquals : TLessThanOrEquals -> type(TLessThanOrEquals);
TS_TGreaterThanOrEquals : TGreaterThanOrEquals -> type(TGreaterThanOrEquals);
TS_TQuestion : TQuestion -> type(TQuestion);
TS_TPlus : TPlus -> type(TPlus);
TS_TMinus : TMinus -> type(TMinus);
TS_TExclamation : TExclamation -> type(TExclamation);
TS_TTilde : TTilde -> type(TTilde);
TS_TAsterisk : TAsterisk -> type(TAsterisk);
TS_TSlash : TSlash -> type(TSlash);
TS_TPercent : TPercent -> type(TPercent);
TS_TPlusPlus : TPlusPlus -> type(TPlusPlus);
TS_TMinusMinus : TMinusMinus -> type(TMinusMinus);
TS_TColonColon : TColonColon -> type(TColonColon);
TS_TAmp : TAmp -> type(TAmp);
TS_THat : THat -> type(THat);
TS_TPipe : TPipe -> type(TPipe);
TS_TAnd : TAnd -> type(TAnd);
TS_TXor : TXor -> type(TXor);
TS_TOr : TOr -> type(TOr);
TS_TQuestionQuestion : TQuestionQuestion -> type(TQuestionQuestion);

TS_IdentifierNormal : IdentifierNormal -> type(IdentifierNormal);
TS_IntegerLiteral : IntegerLiteral -> type(IntegerLiteral);
TS_DecimalLiteral : DecimalLiteral -> type(DecimalLiteral);
TS_ScientificLiteral : ScientificLiteral -> type(ScientificLiteral);
TS_DateTimeOffsetLiteral : DateTimeOffsetLiteral -> type(DateTimeOffsetLiteral);
TS_DateTimeLiteral : DateTimeLiteral -> type(DateTimeLiteral);
TS_DateLiteral : DateLiteral -> type(DateLiteral);
TS_TimeLiteral : TimeLiteral -> type(TimeLiteral);
TS_CharLiteral : CharLiteral -> type(CharLiteral);
TS_RegularStringLiteral : RegularStringLiteral -> type(RegularStringLiteral);
TS_GuidLiteral : GuidLiteral -> type(GuidLiteral);

                                
mode TEMPLATE_STATEMENT_COMMENT;

TemplateStatement_COMMENT_CRLF : '\r'? '\n' -> mode(TEMPLATE_OUTPUT), channel(COMMENT), type(COMMENT);
TemplateStatement_COMMENT_LINEBREAK : [\u0085\u2028\u2029] -> mode(TEMPLATE_OUTPUT), channel(COMMENT), type(COMMENT);
TemplateStatement_COMMENT_TEXT : ~[\*\r\n\u0085\u2028\u2029]+ -> more, channel(COMMENT);

TemplateStatement_COMMENT : '*/' -> mode(TEMPLATE_STATEMENT), channel(COMMENT), type(COMMENT);
TemplateStatement_COMMENT_STAR : '*' -> more, channel(COMMENT);
