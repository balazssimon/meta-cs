/*
 * [The "BSD license"]
 *  Copyright (c) 2012-2015 Terence Parr
 *  Copyright (c) 2012-2015 Sam Harwell
 *  Copyright (c) 2015 Gerald Rosenberg
 *  All rights reserved.
 *
 *  Redistribution and use in source and binary forms, with or without
 *  modification, are permitted provided that the following conditions
 *  are met:
 *
 *  1. Redistributions of source code must retain the above copyright
 *     notice, this list of conditions and the following disclaimer.
 *  2. Redistributions in binary form must reproduce the above copyright
 *     notice, this list of conditions and the following disclaimer in the
 *     documentation and/or other materials provided with the distribution.
 *  3. The name of the author may not be used to endorse or promote products
 *     derived from this software without specific prior written permission.
 *
 *  THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
 *  IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 *  OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 *  IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
 *  INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 *  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 *  DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 *  THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 *  (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 *  THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

/**
 *	A grammar for ANTLR v4 implemented using v4 syntax
 *
 *	Modified 2015.06.16 gbr
 *	-- update for compatibility with Antlr v4.5
 */
lexer grammar Antlr4RoslynLexer;

options
{
	superClass = LexerAdaptor; 
	                        
}

import LexBasic;

// Standard set of fragments
tokens { 
	                        
	TOKEN_REF,
	                       	
	RULE_REF, 
	                     
	LEXER_CHAR_SET 
}

channels
   { OFF_CHANNEL }

// ======================================================
// Lexer specification
//
// -------------------------
// Comments

                                 
DOC_COMMENT_START
	:	'/**' -> more, pushMode(DOC_COMMENT_MODE)
	;


                           
COMMENT_START 
   : '/*' -> more, pushMode(BLOCK_COMMENT_MODE)
   ;


                           
LINE_COMMENT
   : LineComment -> channel (OFF_CHANNEL)
   ;


// -------------------------
// Integer
//

                   
INT
   : DecimalNumeral
   ;

// -------------------------
// Literal string
//
// ANTLR makes no distinction between a single character literal and a
// multi-character string. All literals are single quote delimited and
// may contain unicode escape sequences of the form \uxxxx, where x
// is a valid hexadecimal number (per Unicode standard).

                   
STRING_LITERAL
   : SQuoteLiteral
   ;


                   
UNTERMINATED_STRING_LITERAL
   : USQuoteLiteral
   ;

// -------------------------
// Arguments
//
// Certain argument lists, such as those specifying call parameters
// to a rule invocation, or input parameters to a rule specification
// are contained within square brackets.

BEGIN_ARGUMENT
   : LBrack{ handleBeginArgument(); };
   
// -------------------------
// Actions

                         
BEGIN_ACTION
   : LBrace -> pushMode (ActionMode)
   ;

// -------------------------
// Keywords
//
// Keywords may not be used as labels for rules or in any other context where
// they would be ambiguous with the keyword vs some other identifier.  OPTIONS,
// TOKENS, & CHANNELS blocks are handled idiomatically in dedicated lexical modes.

                          
OPTIONS
   : 'options' -> pushMode (Options)
   ;


                          
TOKENS
   : 'tokens' -> pushMode (Tokens)
   ;


                          
CHANNELS
   : 'channels' -> pushMode (Channels)
   ;

   
                                                     
IMPORT
   : 'import'
   ;


FRAGMENT
   : 'fragment'
   ;


LEXER
   : 'lexer'
   ;


PARSER
   : 'parser'
   ;


GRAMMAR
   : 'grammar'
   ;


PROTECTED
   : 'protected'
   ;


PUBLIC
   : 'public'
   ;


PRIVATE
   : 'private'
   ;


RETURNS
   : 'returns'
   ;


LOCALS
   : 'locals'
   ;


THROWS
   : 'throws'
   ;


CATCH
   : 'catch'
   ;


FINALLY
   : 'finally'
   ;


MODE
   : 'mode'
   ;


// -------------------------
// Boolean

TRUE : 'true';
FALSE : 'false';
   
// -------------------------
// Null

NULL : 'null';
   
// -------------------------
// Punctuation

COLON
   : Colon
   ;


COLONCOLON
   : DColon
   ;

                             
COMMA
   : Comma
   ;


SEMI
   : Semi
   ;


LPAREN
   : LParen
   ;


RPAREN
   : RParen
   ;


LBRACE
   : LBrace
   ;


RBRACE
   : RBrace
   ;


RARROW
   : RArrow
   ;


LT
   : Lt
   ;


GT
   : Gt
   ;


ASSIGN
   : Equal
   ;


QUESTION
   : Question
   ;


STAR
   : Star
   ;


PLUS_ASSIGN
   : PlusAssign
   ;


PLUS
   : Plus
   ;


OR
   : Pipe
   ;


DOLLAR
   : Dollar
   ;


RANGE
   : Range
   ;


DOT
   : Dot
   ;


AT
   : At
   ;


POUND
   : Pound
   ;


NOT
   : Tilde
   ;

// -------------------------
// Identifiers - allows unicode rule/token names

                                              
ID
   : Id
   ;

// -------------------------
// Whitespace

                                                                      
WS
   : Ws + -> channel (OFF_CHANNEL)
   ;

// -------------------------
// Illegal Characters
//
// This is an illegal character trap which is always the last rule in the
// lexer specification. It matches a single character of any value and being
// the last rule in the file will match when no other rule knows what to do
// about the character. It is reported as an error but is not passed on to the
// parser. This means that the parser to deal with the gramamr file anyway
// but we will not try to analyse or code generate from a file with lexical
// errors.
//
// Comment this rule out to allow the error to be propagated to the parser

ERRCHAR
   : . -> channel (HIDDEN)
   ;

// ======================================================
// Lexer modes
// -------------------------
// Arguments
mode Argument;
// E.g., [int x, List<String> a[]]
NESTED_ARGUMENT
   : LBrack -> type (ARGUMENT_CONTENT) , pushMode (Argument)
   ;

ARGUMENT_ESCAPE
   : EscAny -> type (ARGUMENT_CONTENT)
   ;

ARGUMENT_STRING_LITERAL
   : DQuoteLiteral -> type (ARGUMENT_CONTENT)
   ;

ARGUMENT_CHAR_LITERAL
   : SQuoteLiteral -> type (ARGUMENT_CONTENT)
   ;

END_ARGUMENT
   : RBrack{ handleEndArgument(); };
      
// added this to return non-EOF token type here. EOF does something weird
UNTERMINATED_ARGUMENT
   : EOF -> popMode
   ;

ARGUMENT_CONTENT
   : .
   ;

// -------------------------
// Actions
//
// Many language targets use {} as block delimiters and so we
// must recursively match {} delimited blocks to balance the
// braces. Additionally, we must make some assumptions about
// literal string representation in the target language. We assume
// that they are delimited by ' or " and so consume these
// in their own alts so as not to inadvertantly match {}.
                         
mode ActionMode;
NESTED_ACTION
   : LBrace -> type (ACTION_CONTENT) , pushMode (ActionMode)
   ;

ACTION_ESCAPE
   : EscAny -> type (ACTION_CONTENT)
   ;

ACTION_STRING_LITERAL
   : DQuoteLiteral -> type (ACTION_CONTENT)
   ;

ACTION_CHAR_LITERAL
   : SQuoteLiteral -> type (ACTION_CONTENT)
   ;

ACTION_DOC_COMMENT_BEGIN
	:	'/**' -> more, pushMode(ACTION_DOC_COMMENT_MODE)
   ;

ACTION_BLOCK_COMMENT_BEGIN
	:	'/*' -> more, pushMode(ACTION_BLOCK_COMMENT_MODE)
   ;

ACTION_LINE_COMMENT
   : LineComment -> type (ACTION_CONTENT)
   ;

END_ACTION
   : RBrace{ handleEndAction(); };

UNTERMINATED_ACTION
   : EOF -> popMode
   ;

ACTION_CONTENT
   : .
   ;

// -------------------------
                          
mode Options;
OPT_DOC_COMMENT
	:	'/**' -> more, pushMode(DOC_COMMENT_MODE)
   ;

OPT_BLOCK_COMMENT
	:	'/*' -> more, pushMode(BLOCK_COMMENT_MODE)
   ;

OPT_LINE_COMMENT
   : LineComment -> type (LINE_COMMENT) , channel (OFF_CHANNEL)
   ;

OPT_LBRACE
   : LBrace -> type (LBRACE)
   ;

OPT_RBRACE
   : RBrace -> type (RBRACE) , popMode
   ;

OPT_TRUE : TRUE -> type(TRUE);
OPT_FALSE : FALSE -> type(FALSE);
OPT_NULL : NULL -> type(NULL);
OPT_DOLLAR : Dollar -> type(DOLLAR);
OPT_LPAREN : LParen -> type(LPAREN);
OPT_RPAREN : RParen -> type(RPAREN);

OPT_ID
   : Id -> type (ID)
   ;

OPT_DOT
   : Dot -> type (DOT)
   ;

OPT_ASSIGN
   : Equal -> type (ASSIGN)
   ;

OPT_STRING_LITERAL
   : SQuoteLiteral -> type (STRING_LITERAL)
   ;

OPT_INT
   : Int -> type (INT)
   ;

OPT_STAR
   : Star -> type (STAR)
   ;

OPT_SEMI
   : Semi -> type (SEMI)
   ;

OPT_WS
   : Ws + -> type (WS) , channel (OFF_CHANNEL)
   ;

// -------------------------
                          
mode Tokens;
TOK_DOC_COMMENT
	:	'/**' -> more, pushMode(DOC_COMMENT_MODE)
   ;

TOK_BLOCK_COMMENT
	:	'/*' -> more, pushMode(BLOCK_COMMENT_MODE)
   ;

TOK_LINE_COMMENT
   : LineComment -> type (LINE_COMMENT) , channel (OFF_CHANNEL)
   ;

TOK_LBRACE
   : LBrace -> type (LBRACE)
   ;

TOK_RBRACE
   : RBrace -> type (RBRACE) , popMode
   ;

TOK_TRUE : TRUE -> type(TRUE);
TOK_FALSE : FALSE -> type(FALSE);
TOK_NULL : NULL -> type(NULL);
TOK_DOLLAR : Dollar -> type(DOLLAR);
TOK_LPAREN : LParen -> type(LPAREN);
TOK_RPAREN : RParen -> type(RPAREN);
TOK_ASSIGN : Equal -> type(ASSIGN);
   
TOK_ID
   : Id -> type (ID)
   ;

TOK_DOT
   : Dot -> type (DOT)
   ;

TOK_COMMA
   : Comma -> type (COMMA)
   ;

TOK_WS
   : Ws + -> type (WS) , channel (OFF_CHANNEL)
   ;

// -------------------------
                          
mode Channels;
// currently same as Tokens mode; distinguished by keyword
CHN_DOC_COMMENT
	:	'/**' -> more, pushMode(DOC_COMMENT_MODE)
   ;

CHN_BLOCK_COMMENT
	:	'/*' -> more, pushMode(BLOCK_COMMENT_MODE)
   ;

CHN_LINE_COMMENT
   : LineComment -> type (LINE_COMMENT) , channel (OFF_CHANNEL)
   ;

CHN_LBRACE
   : LBrace -> type (LBRACE)
   ;

CHN_RBRACE
   : RBrace -> type (RBRACE) , popMode
   ;

CHN_TRUE : TRUE -> type(TRUE);
CHN_FALSE : FALSE -> type(FALSE);
CHN_NULL : NULL -> type(NULL);
CHN_DOLLAR : Dollar -> type(DOLLAR);
CHN_LPAREN : LParen -> type(LPAREN);
CHN_RPAREN : RParen -> type(RPAREN);
CHN_ASSIGN : Equal -> type(ASSIGN);
   
CHN_ID
   : Id -> type (ID)
   ;

CHN_DOT
   : Dot -> type (DOT)
   ;

CHN_COMMA
   : Comma -> type (COMMA)
   ;

CHN_WS
   : Ws + -> type (WS) , channel (OFF_CHANNEL)
   ;

// -------------------------
mode LexerCharSet;
LEXER_CHAR_SET_BODY
   : (~ [\]\\] | EscAny) + -> more
   ;

LEXER_CHAR_SET
   : RBrack -> popMode
   ;

UNTERMINATED_CHAR_SET
   : EOF -> popMode
   ;

// ------------------------------------------------------------------------------
// Grammar specific Keywords, Punctuation, etc.
fragment Id
   : NameStartChar NameChar*
   ;

// ------------------------------------------------------------------------------
// Documentation comment:
   
                       
mode DOC_COMMENT_MODE;

DOC_COMMENT_CRLF : '\r'? '\n' -> more;
DOC_COMMENT_LINEBREAK : [\u0085\u2028\u2029] -> more;
DOC_COMMENT_TEXT : ~[\u002A\r\n\u0085\u2028\u2029]+ -> more;
                    
DOC_COMMENT : '*/' -> popMode, channel(OFF_CHANNEL);
DOC_COMMENT_STAR : '*' -> more;

	
// ------------------------------------------------------------------------------
// Block comment:
   
                    
mode BLOCK_COMMENT_MODE;

BLOCK_COMMENT_CRLF : '\r'? '\n' -> more;
BLOCK_COMMENT_LINEBREAK : [\u0085\u2028\u2029] -> more;
BLOCK_COMMENT_TEXT : ~[\u002A\r\n\u0085\u2028\u2029]+ -> more;
                    
BLOCK_COMMENT : '*/' -> popMode, channel(OFF_CHANNEL);
BLOCK_COMMENT_STAR : '*' -> more;

// ------------------------------------------------------------------------------
// Documentation comment in actions:
   
                       
mode ACTION_DOC_COMMENT_MODE;

ACTION_DOC_COMMENT_CRLF : '\r'? '\n' -> more;
ACTION_DOC_COMMENT_LINEBREAK : [\u0085\u2028\u2029] -> more;
ACTION_DOC_COMMENT_TEXT : ~[\u002A\r\n\u0085\u2028\u2029]+ -> more;
ACTION_DOC_COMMENT : '*/' -> popMode, type(ACTION_CONTENT), channel(OFF_CHANNEL);
ACTION_DOC_COMMENT_STAR : '*' -> more;

	
// ------------------------------------------------------------------------------
// Block comment in actions:
   
                    
mode ACTION_BLOCK_COMMENT_MODE;

ACTION_BLOCK_COMMENT_CRLF : '\r'? '\n' -> more;
ACTION_BLOCK_COMMENT_LINEBREAK : [\u0085\u2028\u2029] -> more;
ACTION_BLOCK_COMMENT_TEXT : ~[\u002A\r\n\u0085\u2028\u2029]+ -> more;
ACTION_BLOCK_COMMENT : '*/' -> popMode, type(ACTION_CONTENT), channel(OFF_CHANNEL);
ACTION_BLOCK_COMMENT_STAR : '*' -> more;

