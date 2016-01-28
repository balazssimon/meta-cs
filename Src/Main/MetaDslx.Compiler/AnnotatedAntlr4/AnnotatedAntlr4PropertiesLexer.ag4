/** A lexer grammar for ANTLR v4 annotated grammar properties */
lexer grammar AnnotatedAntlr4PropertiesLexer;

DOC_COMMENT_START
	:	'/**' -> more, mode(DOC_COMMENT_MODE), channel(HIDDEN)
	;

COMMENT_START : '/*' -> more, mode(BLOCK_COMMENT_MODE), channel(HIDDEN)
	;

LINE_COMMENT
	:	'//' ~[\r\n]*  -> channel(HIDDEN)
	;

TRUE : 'true';
FALSE : 'false';
NULL : 'null';

COLON        : ':'                    ;
COLONCOLON   : '::'                   ;
COMMA        : ','                    ;
SEMI         : ';'                    ;
LPAREN       : '('                    ;
RPAREN       : ')'                    ;
LT           : '<'                    ;
GT           : '>'                    ;
ASSIGN       : '='                    ;
QUESTION     : '?'                    ;
STAR         : '*'                    ;
PLUS         : '+'                    ;
OR           : '|'                    ;
DOLLAR       : '$'                    ;
DOT		     : '.'                    ;
AT           : '@'                    ;
POUND        : '#'                    ;
NOT          : '~'                    ;
LBRACE       : '{'                    ;
RBRACE       : '}'                    ;
LBRACKET     : '['                    ;
RBRACKET     : ']'                    ;

/** Allow unicode rule/token names */

ID	:	NameStartChar NameChar*;

fragment
NameChar
	:   NameStartChar
	|   '0'..'9'
	|   '_'
	|   '\u00B7'
	|   '\u0300'..'\u036F'
	|   '\u203F'..'\u2040'
	;

fragment
NameStartChar
	:   'A'..'Z'
	|   'a'..'z'
	|   '_'
	|   '\u00C0'..'\u00D6'
	|   '\u00D8'..'\u00F6'
	|   '\u00F8'..'\u02FF'
	|   '\u0370'..'\u037D'
	|   '\u037F'..'\u1FFF'
	|   '\u200C'..'\u200D'
	|   '\u2070'..'\u218F'
	|   '\u2C00'..'\u2FEF'
	|   '\u3001'..'\uD7FF'
	|   '\uF900'..'\uFDCF'
	|   '\uFDF0'..'\uFFFD'
	; // ignores | ['\u10000-'\uEFFFF] ;


INTEGER_LITERAL : DecimalDigits | Hexadecimal;


DECIMAL_LITERAL : DecimalDigit+ '.' DecimalDigit+;


SCIENTIFIC_LITERAL : DECIMAL_LITERAL [eE] Sign? DecimalDigit+;
fragment DecimalDigits : DecimalDigit+;
fragment DecimalDigit : [0-9];
fragment Sign : '+' | '-';
fragment Hexadecimal : ('0x'|'0X') HexDigit*;
fragment HexDigit : [0-9a-fA-F];

// ANTLR makes no distinction between a single character literal and a
// multi-character string. All literals are single quote delimited and
// may contain unicode escape sequences of the form \uxxxx, where x
// is a valid hexadecimal number (as per Java basically).

STRING_LITERAL
	:  '\'' (ESC_SEQ | ~['\r\n\\])* '\''
	;


UNTERMINATED_STRING_LITERAL
	:  '\'' (ESC_SEQ | ~['\r\n\\])*
	;

// Any kind of escaped character that we can embed within ANTLR
// literal strings.
fragment
ESC_SEQ
	:	'\\'
		(	// The standard escaped character set such as tab, newline, etc.
			[btnfr"'\\]
		|	// A Java style Unicode escape sequence
			UNICODE_ESC
		|	// Invalid escape
			.
		|	// Invalid escape at end of file
			EOF
		)
	;

fragment
UNICODE_ESC
    :   'u' (HEX_DIGIT (HEX_DIGIT (HEX_DIGIT HEX_DIGIT?)?)?)?
    ;

fragment
HEX_DIGIT : [0-9a-fA-F]	;

WS  :	[ \t\r\n\f]+ -> channel(HIDDEN)	;


// -----------------
// Illegal Character
//
// This is an illegal character trap which is always the last rule in the
// lexer specification. It matches a single character of any value and being
// the last rule in the file will match when no other rule knows what to do
// about the character. It is reported as an error but is not passed on to the
// parser. This means that the parser to deal with the gramamr file anyway
// but we will not try to analyse or code generate from a file with lexical
// errors.
//
ERRCHAR
	:	.	-> channel(HIDDEN)
	;



mode DOC_COMMENT_MODE;

	DOC_COMMENT_CRLF : '\r'? '\n' -> more, channel(HIDDEN);
	DOC_COMMENT_LINEBREAK : [\u0085\u2028\u2029] -> more, channel(HIDDEN);
	DOC_COMMENT_TEXT : ~[\*\r\n\u0085\u2028\u2029]+ -> more, channel(HIDDEN);
	
	DOC_COMMENT : '*/' -> mode(DEFAULT_MODE), channel(HIDDEN);
	DOC_COMMENT_STAR : '*' -> more, channel(HIDDEN);


mode BLOCK_COMMENT_MODE;

	BLOCK_COMMENT_CRLF : '\r'? '\n' -> more, channel(HIDDEN);
	BLOCK_COMMENT_LINEBREAK : [\u0085\u2028\u2029] -> more, channel(HIDDEN);
	BLOCK_COMMENT_TEXT : ~[\*\r\n\u0085\u2028\u2029]+ -> more, channel(HIDDEN);
	
	BLOCK_COMMENT : '*/' -> mode(DEFAULT_MODE), channel(HIDDEN);
	BLOCK_COMMENT_STAR : '*' -> more, channel(HIDDEN);

