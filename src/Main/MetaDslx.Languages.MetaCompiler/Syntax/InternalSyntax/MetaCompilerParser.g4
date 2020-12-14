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

                 
phaseDeclaration : attribute* locked? KPhase name phaseJoin? afterPhases? beforePhases? TSemicolon;
                                   
locked: KLocked;
                     
phaseJoin: KJoins phaseRef;
                      
afterPhases: KAfter phaseRef (TComma phaseRef)*;
                       
beforePhases: KBefore phaseRef (TComma phaseRef)*;
phaseRef:                   qualifier;

                    
enumDeclaration : attribute* KEnum name enumBody;
      
enumBody : TOpenBrace                         enumValues (TSemicolon enumMemberDeclaration*)? TCloseBrace;
enumValues : enumValue (TComma enumValue)*;
                       
enumValue : attribute* name;
enumMemberDeclaration :                       operationDeclaration;

                     
visibility 
	:                                KPrivate 
	|                                  KProtected
	|                               KPublic
	|                                 KInternal
	;

                 
classDeclaration : attribute* visibility? classModifier* classKind name (TColon                         classAncestors)? classBody;
classModifier : abstract_ | sealed_ | fixed_ | partial_ | static_;
classAncestors : classAncestor (TComma classAncestor)*;
classAncestor :                        qualifier;
      
classBody : TOpenBrace classPhases? classMemberDeclaration* TCloseBrace;
                 
classPhases: KPhase phaseRef (TComma phaseRef)* TSemicolon;
classMemberDeclaration 
	:                       fieldDeclaration 
	|                       operationDeclaration
	;
               
classKind
	:                         KClass 
	|                          KSymbol
	|                          KBinder
	;

                    
fieldDeclaration : attribute* visibility? memberModifier* fieldContainment? fieldKind?                 typeReference name defaultValue? phase? TSemicolon;
                                        
fieldContainment : KContainment;
               
fieldKind
	:                               KReadonly 
	|                           KLazy 
	|                              KDerived
	;
memberModifier : partial_ | static_ | virtual_ | abstract_ | sealed_ | new_ | override_;
                       
defaultValue : TAssign        stringLiteral;
                
phase: KPhase phaseRef;

                    
nameUseList : qualifier (TComma qualifier)*;

                       
typedefDeclaration : KTypeDef name typedefValue TSemicolon;
                     
typedefValue : TAssign        stringLiteral;

                    
returnType : typeReference | voidType;
                    
typeOfReference : typeReference;
                    
typeReference : simpleOrDictionaryType;
simpleOrDictionaryType : simpleOrArrayType | dictionaryType;
simpleOrArrayType : simpleOrGenericType | arrayType;
simpleOrGenericType: simpleType | genericType;
                    
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

                       
genericType :                 classType TLessThan typeArguments TGreaterThan;
                        
typeArguments : typeReference (TComma typeReference)*;
	
                     
arrayType :                      simpleOrGenericType TOpenBracket TCloseBracket;

                          
dictionaryType :                    key=simpleOrArrayType TRightArrow                      value=simpleOrArrayType;

                     
operationDeclaration : attribute* visibility? memberModifier*                       returnType name TOpenParen                       parameterList? TCloseParen TSemicolon;

parameterList : parameter (TComma parameter)*;

                     
parameter : attribute*                 typeReference name defaultValue?;

                                   
static_ : KStatic;
                                  
fixed_ : KFixed;
                                    
partial_ : KPartial;
                                     
abstract_ : KAbstract;
                                    
virtual_ : KVirtual;
                                   
sealed_ : KSealed;
                                     
override_ : KOverride;
                                
new_ : KNew;

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

