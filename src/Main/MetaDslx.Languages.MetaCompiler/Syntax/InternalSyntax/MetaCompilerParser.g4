parser grammar MetaCompilerParser;

@header 
{
using MetaDslx.Languages.MetaCompiler.Model;
}

options
{
    tokenVocab = MetaCompilerLexer; 
	                      
}

main: namespaceDeclaration EOF;

     
name : identifier;

     
qualifiedName : qualifier;

          
qualifier : identifier (TDot identifier)*;

                      
                      
attribute : TOpenBracket qualifier TCloseBracket;

                                                                  
namespaceDeclaration: attribute* KNamespace qualifiedName namespaceBody;

      
namespaceBody : TOpenBrace declaration* TCloseBrace;

                        
declaration : compilerDeclaration | phaseDeclaration | enumDeclaration | classDeclaration | typedefDeclaration;

                    
compilerDeclaration : attribute* KCompiler name TSemicolon;

                 
phaseDeclaration : attribute*                                     KLocked? KPhase name phaseJoin? afterPhases? beforePhases? TSemicolon;
                     
phaseJoin: KJoins phaseRef;
                      
afterPhases: KAfter phaseRef (TComma phaseRef)*;
                       
beforePhases: KBefore phaseRef (TComma phaseRef)*;
phaseRef:                   qualifier;

                    
enumDeclaration : attribute* KEnum name enumBody;
      
enumBody : TOpenBrace                         enumValues (TSemicolon enumMemberDeclaration*)? TCloseBrace;
enumValues : enumValue (TComma enumValue)*;
                       
enumValue : attribute* name;
enumMemberDeclaration :                       operationDeclaration;

                 
classDeclaration : attribute*                                       KAbstract? classKind name (TColon                         classAncestors)? classBody;
classAncestors : classAncestor (TComma classAncestor)*;
classAncestor :                        qualifier;
      
classBody : TOpenBrace classMemberDeclaration* TCloseBrace;
classMemberDeclaration 
	:                       fieldDeclaration 
	|                       operationDeclaration
	;
               
classKind
	:                         KClass 
	|                          KSymbol
	|                          KBinder
	;

                    
fieldDeclaration : attribute* fieldContainment? fieldModifier?                 typeReference name defaultValue? phase? TSemicolon;
                                        
fieldContainment : KContainment;
               
fieldModifier 
	:                               KReadonly 
	|                           KLazy 
	|                              KDerived
	;
                       
defaultValue : TAssign        stringLiteral;
                
phase: KPhase                   qualifier;

                    
nameUseList : qualifier (TComma qualifier)*;

                       
typedefDeclaration : KTypeDef name typedefValue TSemicolon;
                     
typedefValue : TAssign        stringLiteral;

                    
returnType : typeReference | voidType;
                    
typeOfReference : typeReference;
                    
typeReference : genericType | simpleType;
                    
simpleType : primitiveType | objectType | nullableType | classType;

                                              
classType : qualifier;

           
objectType 
	: KObject 
	| KString
	;

           
primitiveType 
	: KInt 
	| KLong 
	| KFloat 
	| KDouble 
	| KByte 
	| KBool
	;

           
voidType 
	: KVoid
	;

                        
nullableType :                      primitiveType TQuestion;

                       
genericType :                 genericTypeName TLessThan                          typeArguments TGreaterThan;
genericTypeName :                   qualifier;
typeArguments : typeArgument (TComma typeArgument)*;
typeArgument :                   qualifier;
	
                     
operationDeclaration : attribute*                       returnType name TOpenParen                       parameterList? TCloseParen TSemicolon;

parameterList : parameter (TComma parameter)*;

                     
parameter : attribute*                 typeReference name;

// Additional rules for lexer:

// Identifiers
           
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

