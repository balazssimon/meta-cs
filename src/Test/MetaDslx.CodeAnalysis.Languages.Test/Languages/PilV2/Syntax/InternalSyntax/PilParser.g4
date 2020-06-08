parser grammar PilParser;

options
{
    tokenVocab = PilLexer; 
	                      
}

main: declaration* EOF;

declaration: typeDefDeclaration | externalParameterDeclaration | enumDeclaration | objectDeclaration | functionDeclaration | queryDeclaration;

                     
typeDefDeclaration: KTypeDef name TColon                       typeReference TSemicolon;

                             
externalParameterDeclaration: KParam name TColon                 typeReference (TAssign                         expression)? TSemicolon;

                   
enumDeclaration: KEnum name TOpenBracket enumLiterals TCloseBracket TSemicolon;
                   
enumLiterals: enumLiteral (TComma enumLiteral)*;
                       
enumLiteral: name;

                     
objectDeclaration: KObject objectHeader TSemicolon objectExternalParameters objectFields objectFunctions KEndObject;
objectHeader: name TOpenParen ports? TCloseParen;
ports: port (TComma port)*;
                
                
port: name;
                             
objectExternalParameters: externalParameterDeclaration*;
                 
objectFields: variableDeclaration*;
                    
objectFunctions: functionDeclaration*;

                    
functionDeclaration: KFunction functionHeader comment? TSemicolon statements? KEndFunction;
functionHeader: name TOpenParen functionParams? TCloseParen TColon                       typeReference;
                     
functionParams: param (TComma param)*;
                    
param: name TColon                 typeReference;

// TODO:MetaDslx
//queryDeclaration: KQuery queryHeader comment? startQuerySemicolon=TSemicolon $Property(Fields) variableDeclaration* $Property(Functions) functionDeclaration* $Property(Objects) queryObject* KEndQuery endName=identifier? endQuerySemicolon=TSemicolon;


                 
queryDeclaration: KQuery queryHeader comment? startQuerySemicolon=TSemicolon queryExternalParameters* queryField* functionDeclaration* queryObject* KEndQuery endName=identifier? endQuerySemicolon=TSemicolon;
queryHeader: name TOpenParen queryRequestParams? TCloseParen;
                            
queryRequestParams: KRequest? param (TComma param)* TSemicolon?;
                           
queryAcceptParams: KAccept param (TComma param)* TSemicolon?;
                           
queryRefuseParams: KRefuse param (TComma param)* TSemicolon?;
                           
queryCancelParams: KCancel param (TComma param)* TSemicolon?;
                             
queryExternalParameters: externalParameterDeclaration;
                 
queryField: variableDeclaration;
                    
queryFunction: functionDeclaration;
                  
                       
queryObject: KObject name comment? startObjectSemicolon=TSemicolon queryObjectField* queryObjectFunction* queryObjectEvent* KEndObject endName=identifier? endObjectSemicolon=TSemicolon;
                 
queryObjectField: variableDeclaration;
                    
queryObjectFunction: functionDeclaration;
                 
queryObjectEvent: input | trigger;
                      
input: KInput inputPortList comment? TSemicolon statements?;
inputPortList: inputPort (TComma inputPort)*;
                
                       
inputPort:                            portName=identifier (TDot                             queryName=identifier)?;
                   
trigger: KTrigger triggerVarList comment? TSemicolon statements?;
triggerVarList: triggerVar (TComma triggerVar)*;
triggerVar:                                    identifier;

                     
statements: statement*;
statement: variableDeclarationStatement | requestStatement | forkStatement | forkRequestStatement | ifStatement | responseStatement | cancelStatement | assignmentStatement;

                         
forkStatement: KFork                        expression? caseBranch* elseBranch? KEndFork;
                   
                  
caseBranch: KCase                  condition=expression comment? TSemicolon statements?;
                   
                  
elseBranch: KElse comment? statements?;

                         
ifStatement: KIf ifBranch elseIfBranch* elseBranch* KEndIf;
                   
                  
ifBranch:                  conditionalExpression comment? TSemicolon statements?;
elseIfBranch: KElse KIf ifBranch;

                            
requestStatement: (                                  leftSide TAssign)? callRequest                      assertion? TSemicolon;
callRequest: KRequest                            portName=identifier (TDot                             queryName=identifier)? requestArguments?;
                    
requestArguments: TOpenParen expressionList? TCloseParen;

                             
responseStatement: responseStatementKind                      assertion? TSemicolon;

                             
cancelStatement: cancelStatementKind                            portName=identifier?                      assertion? TSemicolon;

                           
                    
assertion: TColon expression? comment?;

               
responseStatementKind
	:                             KAccept 
	|                             KRefuse
	;

               
cancelStatementKind
	:                                             KCancel
	;

// $SymbolDef(RequestStatement)
// assertStatement: KAssert condition=expression comment? TSemicolon;
// 
// $SymbolDef(RequestStatement)
// requestStatement: ($Property(RequestVariable) $Value leftSide TAssign)? callRequest TSemicolon;
// callRequest: KRequest $Property(PortName) $Value portName=identifier (TDot $Property(QueryName) $Value queryName=identifier)? requestArguments?;
// $Property(Arguments)
// requestArguments: TOpenParen expressionList? TCloseParen;
// 
// $SymbolDef(ResponseStatement)
// responseStatement: responseStatementKind TSemicolon;


                                
forkRequestStatement: KFork forkRequestVariable acceptBranch? refuseBranch? cancelBranch? KEndFork;
forkRequestVariable:                           forkRequestIdentifier |                          requestStatement;
forkRequestIdentifier:        identifier TSemicolon;
                   
                             
acceptBranch: KCase                                                KAccept                      condition=expression? comment? TSemicolon statements?;
                   
                             
refuseBranch: KCase                                                KRefuse                      condition=expression? comment? TSemicolon statements?;
                   
                             
cancelBranch: KCase                                                KCancel                      condition=expression? comment? TSemicolon statements?;

                                        
variableDeclarationStatement:                     variableDeclaration;
                    
variableDeclaration: KVar name TColon                 typeReference (TAssign                         expression)? TSemicolon;

                               
assignmentStatement:                            leftSide TAssign                  value=expression TSemicolon;

leftSide : identifier | resultIdentifier;

expressionList: expression (TComma expression)*;
expression : arithmeticExpression | conditionalExpression;

arithmeticExpression
	:                 left=arithmeticExpression                     opMulDiv                  right=arithmeticExpression  #mulDivExpression                             
	|                 left=arithmeticExpression                     opAddSub                  right=arithmeticExpression  #plusMinusExpression                             
	|                     opMinus                  arithmeticExpressionTerminator    #negateExpression                            
	| arithmeticExpressionTerminator                                                 #simpleArithmeticExpression
	;
opMulDiv
	:                                 TAsterisk
	|                               TSlash
	;
opAddSub
	:                            TPlus
	|                                 TMinus
	;

arithmeticExpressionTerminator
	: TOpenParen                  arithmeticExpression TCloseParen                        #parenArithmeticExpression                                    
	| terminalExpression                                                 #terminalArithmeticExpression
	;

                           
opMinus: TMinus;

conditionalExpression
	:                 left=conditionalExpression                     andAlsoOp                  right=conditionalExpression     #andExpression                             
	|                 left=conditionalExpression                     orElseOp                  right=conditionalExpression      #orExpression                             
	|                     opExcl                  conditionalExpressionTerminator     #notExpression                            
	| conditionalExpressionTerminator                                                 #simpleConditionalExpression
	;

                              
andAlsoOp: TAndAlso;
                             
orElseOp: TOrElse;
                            
opExcl: TExclamation;

conditionalExpressionTerminator
	: TOpenParen                  conditionalExpression TCloseParen             #parenConditionalExpression                                    
	| elementOfExpression                                      #elementOfConditionalExpression
	| comparisonExpression                                     #comparisonConditionalExpression
	| terminalExpression   #terminalComparisonExpression
	;

                            
comparisonExpression
	:                 left=arithmeticExpression                     op=comparisonOperator                  right=arithmeticExpression 
	;

comparisonOperator
	:                              TEqual 
	|                                 TNotEqual 
	|                                 TLessThan 
	|                                    TGreaterThan 
	|                                        TLessThanOrEqual 
	|                                           TGreaterThanOrEqual
	;

                               
elementOfExpression :                  terminalExpression KIn TOpenBracket elementOfValueList? TCloseBracket;
elementOfValueList: elementOfValue (TComma elementOfValue)*;
              
      
elementOfValue: identifier;

terminalExpression : variableReference | functionCallExpression | literal;

                                  
functionCallExpression
	:                        identifier TOpenParen                      expressionList? TCloseParen;

                               
variableReference: variableReferenceIdentifier (TDot variableReferenceIdentifier)*;
                    
variableReferenceIdentifier:        identifier;

                  
      
comment: LString;

                             
                
      
literal: LInteger | KTrue | KFalse | KNull;

                     
typeReference: builtInType | identifier;

           
builtInType
	: KBool 
	| KInt 
	| KString 
	| KObjectType;

qualifierList: qualifier (TComma qualifier)*;

          
qualifier: identifier (TDot identifier)*;

     
name: identifier;

identifierList: identifier (TComma identifier)*;

           
identifier: LIdentifier;

resultIdentifier: KResult;
