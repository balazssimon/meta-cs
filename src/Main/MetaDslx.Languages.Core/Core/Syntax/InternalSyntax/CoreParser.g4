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

statement
	: TSemicolon #emptyStmt                        
	| blockStatement #blockStmt 
	|                       expression TSemicolon #exprStmt                             
	| KForEach TOpenParen                                variable=expression TColon                       collection=expression TCloseParen                 statement #foreachStmt                              
	| KFor TOpenParen                   before=expressionList? semicolonBefore=TSemicolon                      condition=expression semicolonAfter=TSemicolon                         atLoopBottom=expressionList? TCloseParen                 statement #forStmt                          
	| KIf TOpenParen                      condition=expression TCloseParen                   ifTrue=statement (KElse                    ifFalse=statement) #ifStmt                     
	|                                               KBreak TSemicolon #breakStmt                       
	|                                                  KContinue TSemicolon #continueStmt                       
	|                                              KGoto                               identifier TSemicolon #gotoStmt                       
	|                                 name TColon                      statement #labeledStmt                          
	| KLock TOpenParen                        lockedValue=expression TCloseParen                 body=statement #lockStmt                       
	| KReturn                          returnedValue=expression TSemicolon #returnStmt                         
	| KSwitch TOpenParen                  value=expression TCloseParen TOpenBrace switchCase* TCloseBrace #switchStmt                         
	| KTry                 body=blockStatement catchClause*                    finallyClause? #tryStmt
	| usingHeader+                 body=statement #usingStmt                        
	| KWhile TOpenParen                                                                condition=expression TCloseParen                 body=statement #whileStmt                            
	| KDo                 body=statement KWhile TOpenParen                                                                 condition=expression TCloseParen TSemicolon #doWhileStmt                            
	;

                       
                      
blockStatement : TOpenBrace statement* TCloseBrace;
                       
                      
bareBlockStatement : statement+;

                
                   
switchCase: caseClause+                 bareBlockStatement;
                   
caseClause: singleValueCaseClause | defaultCaseClause; 
                              
singleValueCaseClause: KCase                  value=expression TColon;
                          
defaultCaseClause: KDefault TColon;

                  
                    
catchClause: KCatch (TOpenParen                                             value=expression TCloseParen catchFilter?)?                    handler=blockStatement;
catchFilter: KWhen                   filter=expression;
finallyClause: KFinally handler=blockStatement;

usingHeader: KUsing TOpenParen                      resource=expression TCloseParen;

expressionList: expression (TComma expression)*;

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
	|                         expression KIs                                      KNot?                        typeReference (                                      name)? #typeIsExpr                          
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
	|                                    KConst?                 variableType                      variableDefList #varDefExpr                                       
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

variableDefList: variableDef (TComma variableDef)*;
                 
variableDef: name (TAssign                        initializer=expression);

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

variableType : typeReference | varType;

              
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

varType : KVar;

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

