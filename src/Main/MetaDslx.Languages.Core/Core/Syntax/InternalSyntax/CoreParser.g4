parser grammar CoreParser;

@header 
{
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Core.Model;
}

options
{
    tokenVocab = CoreLexer; 
	                      
}

main: usingNamespace* statement* EOF;

       
usingNamespace: KUsing (name TAssign)? qualifier TSemicolon;

// Statements

                            
statement:                       expression TSemicolon;

                       
blockStatement: TOpenBrace                       statement* TCloseBrace;

// Expressions

expression
	: TOpenParen                    expression TCloseParen #parenthesizedExpr                                 
	| TOpenParen tupleArguments TCloseParen #tupleExpr                         
	| KDiscard #discardExpr                           
	| KDefault #defaultExpr                                
	| KThis #thisExpr                                     
	| KBase #baseExpr                                     
	|                  literal #literalExpr                           
	|                                               identifier genericTypeArguments? #identifierExpr                             
	|                      expression dotOperator                                               identifier genericTypeArguments? #qualifierExpr                             
	|                     expression indexerOperator argumentList TCloseBracket #indexerExpr                                 
	| expression TOpenParen argumentList? TCloseParen #invocationExpr                              
	| KTypeof TOpenParen                        typeReference TCloseParen #typeofExpr                          
	| KNameof TOpenParen                     expression TCloseParen #nameofExpr                          
	| KSizeof TOpenParen                        typeReference TCloseParen #sizeofExpr                          
	| KChecked TOpenParen expression TCloseParen #checkedExpr
	| KUnchecked TOpenParen expression TCloseParen #uncheckedExpr
	| KNew                       typeReference TOpenParen argumentList? TCloseParen initializerExpression? #newExpr                                  
	|                    expression                         postfixOperator #postfixUnaryExpr                         
	|                    expression TExclamation #nullForgivingExpr                                 
	|                         unaryOperator                    expression #unaryExpr                         
	| TOpenParen                       typeReference TCloseParen                    expression #typeCastExpr                              
	| KAwait                      expression #awaitExpr                         
	|                        left=expression                                                          TDotDot                         right=expression #rangeExpr                          
	|                        left=expression                         multiplicativeOperator                         right=expression #multExpr                          
	|                        left=expression                         additiveOperator                         right=expression #addExpr                          
	|                        left=expression                         shiftOperator                         right=expression #shiftExpr                          
	|                        left=expression                         relationalOperator                         right=expression #relExpr                          
	|                         expression KIs                                      KNot?                        typeReference #typeIsExpr                          
	|                    expression KAs                       typeReference #typeAsExpr                                                                   
	|                        left=expression                         equalityOperator                         right=expression #eqExpr                          
	|                        left=expression                                                               TAmpersand                         right=expression #andExpr                          
	|                        left=expression                                                               THat                         right=expression #xorExpr                          
	|                        left=expression                                                              TBar                         right=expression #orExpr                          
	|                        left=expression                                                               TAndAlso                         right=expression #andAlsoExpr                          
	|                        left=expression                                                              TOrElse                         right=expression #orElseExpr                          
	| KThrow                      expression #throwExpr                         
	|                  value=expression TQuestionQuestion                     whenNull=expression #coalExpr                            
	|                      condition=expression TQuestion                     whenTrue=expression TColon                      whenFalse=expression #condExpr                               
	|                   target=expression TAssign                  value=expression #assignExpr                              
	|                   target=expression                         compoundAssignmentOperator                  value=expression #compAssignExpr                                      
	| lambdaSignature TArrow lambdaBody #lambdaExpr                          
	;

                    
tupleArguments : argumentExpression TComma argumentList;
                    
argumentList: argumentExpression (TComma argumentExpression)*;
                 
argumentExpression: (name TColon)?                  expression;

initializerExpression
	: fieldInitializerExpressions
	| collectionInitializerExpressions
	| dictionaryInitializerExpressions
	;

fieldInitializerExpressions: fieldInitializerExpression (TComma fieldInitializerExpression)*;
                             
fieldInitializerExpression:                                         identifier TAssign                  expression;
collectionInitializerExpressions: expression (TComma expression)*;
dictionaryInitializerExpressions: dictionaryInitializerExpression (TComma dictionaryInitializerExpression)*;
dictionaryInitializerExpression: TOpenBracket identifier TCloseBracket TAssign expression;

lambdaSignature: implicitLambdaSignature | explicitLambdaSignature;
implicitLambdaSignature : implicitParameter | implicitParameterList;
                     
implicitParameterList : TOpenParen implicitParameter (TComma implicitParameter)* TCloseParen;
                     
                  
implicitParameter : name;

explicitLambdaSignature : explicitParameterList;
                     
explicitParameterList : TOpenParen explicitParameter (TComma explicitParameter)* TCloseParen;
                     
                  
explicitParameter :                 typeReference name;

               
lambdaBody:                                                    expression | blockStatement;

dotOperator
	: TDot
	|                                              TQuestionDot
	;

indexerOperator
	: TOpenBracket
	|                                              TQuestionOpenBracket
	;

postfixOperator
	:                                            TPlusPlus
	|                                            TMinusMinus
	;

unaryOperator
	:                                     TPlus
	|                                      TMinus
	|                                           TExclamation
	|                                             TTilde
	|                                           TPlusPlus
	|                                           TMinusMinus
	|                                        THat
	;

multiplicativeOperator
	:                                           TAsterisk
	|                                     TSlash
	|                                      TPercent
	;

                       
additiveOperator
	:                                     TPlus
	|                                        TMinus
	;

shiftOperator
	: leftShiftOperator
	| rightShiftOperator
	;
                                    
leftShiftOperator: first=TLessThan second=TLessThan;
                                     
rightShiftOperator: first=TLessThan second=TLessThan;

relationalOperator
	:                                     TLessThan
	|                                        TGreaterThan
	|                                            TLessThanOrEqual
	|                                               TGreaterThanOrEqual
	;

equalityOperator
	:                                  TEqual
	|                                     TNotEqual
	;

compoundAssignmentOperator
	:                                     TPlusAssign
	|                                        TMinusAssign
	|                                           TAsteriskAssign
	|                                     TSlashAssign
	|                                      TPercentAssign
	|                                       TAmpersandAssign
	|                                       THatAssign
	|                                      TBarAssign
	|                                      TLeftShiftAssign
	|                                       TRightShiftAssign
	;


// Type references

returnType : typeReference | voidType;

              
typeReference 
	: primitiveType #primitiveTypeRef
	|                           namedType genericTypeArguments #genericTypeRef                              
	| qualifier #namedTypeRef                                                   
	|                        typeReference TOpenBracket TCloseBracket #arrayTypeRef                   
	|                      typeReference TQuestion #nullableTypeRef;

                                                  
namedType : qualifier;

                        
genericTypeArguments : TLessThan genericTypeArgument (TComma genericTypeArgument)* TGreaterThan;
genericTypeArgument : typeReference;

primitiveType
	:                             KObject 
	|                              KBool
	|                           KChar
	|                            KSByte
	|                           KByte
	|                            KShort
	|                             KUShort
	|                            KInt
	|                             KUInt
	|                            KLong
	|                             KULong 
	|                              KDecimal
	|                             KFloat
	|                             KDouble 
	|                             KString
	;

                          
voidType : KVoid;



// Additional rules for lexer:

// Identifiers
     
name : identifier;

     
qualifiedName : qualifier;

          
qualifier : identifier (TDot identifier)*;

           
identifier 
	: IdentifierNormal 
	| IdentifierVerbatim
	;

// Literals
literal 
    : nullLiteral
	| booleanLiteral
	| integerLiteral
	| decimalLiteral
	| scientificLiteral
    | stringLiteral
	;

// Null literal
      
nullLiteral : KNull;

// Boolean literals
                                               
      
booleanLiteral : KTrue | KFalse;

// Number literals
                                             
      
integerLiteral : LInteger;
                                               
      
decimalLiteral : LDecimal;
                                              
      
scientificLiteral : LScientific;

// String literals
                                              
      
stringLiteral : LRegularString;

