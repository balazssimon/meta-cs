parser grammar MetaParser;

@header 
{
using MetaDslx.Languages.Meta.Model;
}

options
{
    tokenVocab = MetaLexer; 
	                      
}

main: namespaceDeclaration EOF;

     
name : identifier;

     
qualifiedName : qualifier;

          
qualifier : identifier (TDot identifier)*;

                     
                         
attribute : TOpenBracket qualifier TCloseBracket;

                                                                      
namespaceDeclaration: attribute* KNamespace qualifiedName namespaceBody;

      
namespaceBody : TOpenBrace metamodelDeclaration declaration* TCloseBrace;

                           
                     
metamodelDeclaration: attribute* KMetamodel name (TOpenParen metamodelPropertyList? TCloseParen)? TSemicolon;

metamodelPropertyList : metamodelProperty (TComma metamodelProperty)*;

metamodelProperty : metamodelUriProperty;

              
metamodelUriProperty : IUri TAssign        stringLiteral;

                        
declaration : enumDeclaration | classDeclaration | associationDeclaration | constDeclaration;

                    
enumDeclaration : attribute* KEnum name enumBody;
      
enumBody : TOpenBrace                         enumValues (TSemicolon enumMemberDeclaration*)? TCloseBrace;
enumValues : enumValue (TComma enumValue)*;
                           
enumValue : attribute* name;
enumMemberDeclaration :                       operationDeclaration;

                     
classDeclaration : attribute*                                       KAbstract? KClass name (TColon                         classAncestors)? classBody;
      
classBody : TOpenBrace classMemberDeclaration* TCloseBrace;
classAncestors : classAncestor (TComma classAncestor)*;
classAncestor :                            qualifier;
classMemberDeclaration 
	:                       fieldDeclaration 
	|                       operationDeclaration
	;

                        
fieldDeclaration : attribute*                 fieldModifier?                 typeReference name redefinitionsOrSubsettings? TSemicolon;
fieldModifier 
	:                                      KContainment 
	|                                   KReadonly 
	|                               KLazy 
	|                                  KDerived
	;

redefinitionsOrSubsettings : redefinitions | subsettings;
redefinitions : KRedefines                                nameUseList?;
subsettings : KSubsets                                nameUseList?;

                        
nameUseList : qualifier (TComma qualifier)*;

                        
constDeclaration : KConst                 typeReference name TSemicolon;

                    
returnType : typeReference | voidType;
                    
typeOfReference : typeReference;
                    
typeReference : collectionType | simpleType;
                    
simpleType : primitiveType | objectType | nullableType | classType;

                                      
classType : qualifier;

           
objectType 
	: KObject 
	| KSymbol
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

                              
collectionType :                 collectionKind TLessThan                      simpleType TGreaterThan;
collectionKind 
	:                                KSet 
	|                                 KList
	|                                     KMultiSet 
	|                                      KMultiList
	;
	
                         
operationDeclaration : attribute* KStatic?                       returnType name TOpenParen                       parameterList? TCloseParen TSemicolon;

parameterList : parameter (TComma parameter)*;

                         
parameter : attribute*                 typeReference name;

         
associationDeclaration : attribute* KAssociation                          source=qualifier KWith                          target=qualifier TSemicolon;


// Additional rules for lexer:

// Identifiers
           
identifier 
	: IdentifierNormal 
	| IdentifierVerbatim
	| IUri
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
