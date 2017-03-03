parser grammar CalculatorParser;

options {
	tokenVocab=CalculatorLexer;
	                      
}


main : statementLine+ EOF;

statementLine : statement TSemicolon;

statement 
	: assignment
	| expression;
	
assignment : identifier TAssign expression;
 
expression
    : TOpenParen expression TCloseParen     # parenExpression
    | left=expression operator=(TMul|TDiv) right=expression		# mulOrDivExpression
    | left=expression operator=(TAdd|TSub) right=expression     # addOrSubExpression
    | KPrint args				            # printExpression
	| value									# valueExpression
	;

args : arg (TComma arg)*;

value : identifier | string | integer;

identifier : ID;
string : STRING;
integer : INT;

arg : value;
