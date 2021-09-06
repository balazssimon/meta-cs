parser grammar MetaParser;

@header 
{
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Meta.Model;
}

options
{
    tokenVocab = MetaLexer; 
	                      
}

main: usingNamespaceOrMetamodel* namespaceDeclaration EOF;

     
name : identifier;

     
qualifiedName : qualifier;

          
qualifier : identifier (TDot identifier)*;

                     
                   
attribute : TOpenBracket qualifier TCloseBracket;

usingNamespaceOrMetamodel: usingNamespace | usingMetamodel;

       
usingNamespace: KUsing (name TAssign)? qualifier TSemicolon;

                
usingMetamodel: KUsing KMetamodel (name TAssign)? usingMetamodelReference TSemicolon;
usingMetamodelReference: qualifier |        stringLiteral;

                                                                   
namespaceDeclaration: attribute* KNamespace qualifiedName namespaceBody;

      
namespaceBody : TOpenBrace usingNamespaceOrMetamodel* metamodelDeclaration declaration* TCloseBrace;

                           
                  
                        
              
metamodelDeclaration: attribute* KMetamodel name (TOpenParen metamodelPropertyList? TCloseParen)? TSemicolon;

metamodelPropertyList : metamodelProperty (TComma metamodelProperty)*;

metamodelProperty : metamodelUriProperty | metamodelPrefixProperty | metamodelVersionProperty;

              
metamodelUriProperty : IUri TAssign        stringLiteral;
                 
metamodelPrefixProperty : IPrefix TAssign        stringLiteral;
metamodelVersionProperty : IVersion TAssign                                major=integerLiteral TDot                                minor=integerLiteral;

declaration : enumDeclaration | classDeclaration | associationDeclaration | constDeclaration;

                       
                 
                        
              
enumDeclaration : attribute* KEnum name enumBody;
      
enumBody : TOpenBrace                         enumValues (TSemicolon enumMemberDeclaration*)? TCloseBrace;
enumValues : enumValue (TComma enumValue)*;
                        
                        
              
enumValue : attribute* name;
enumMemberDeclaration :                       operationDeclaration;

                       
                  
                        
              
classDeclaration : attribute* symbolAttribute?                                       KAbstract? KClass name (TColon                         classAncestors)? classBody;
                     
symbolAttribute : symbolSymbolAttribute | expressionSymbolAttribute | statementSymbolTypeAttribute | typeSymbolTypeAttribute;

             
symbolSymbolAttribute : TOpenBracket KSymbol TColon qualifier TCloseBracket;
                 
expressionSymbolAttribute : TOpenBracket KExpression TColon qualifier TCloseBracket;
                
statementSymbolTypeAttribute : TOpenBracket KStatement TColon qualifier TCloseBracket;
           
typeSymbolTypeAttribute : TOpenBracket KType TColon qualifier TCloseBracket;

      
classBody : TOpenBrace classMemberDeclaration* TCloseBrace;
classAncestors : classAncestor (TComma classAncestor)*;
classAncestor :                      qualifier;
classMemberDeclaration 
	:                       fieldDeclaration 
	|                       operationDeclaration
	;

                     
                        
              
fieldDeclaration : attribute* fieldSymbolPropertyAttribute? fieldContainment? fieldModifier?                 typeReference name defaultValue? redefinitionsOrSubsettings* TSemicolon;
                         
fieldSymbolPropertyAttribute : TOpenBracket KProperty TColon                 identifier TCloseBracket;
                                        
fieldContainment : KContainment;
               
fieldModifier 
	:                                   KReadonly 
	|                               KLazy 
	|                                  KDerived
	|                                       KUnion
	;
                       
defaultValue : TAssign        stringLiteral;

redefinitionsOrSubsettings : redefinitions | subsettings;
redefinitions : KRedefines                                nameUseList?;
subsettings : KSubsets                                nameUseList?;

                  
nameUseList : qualifier (TComma qualifier)*;

                       
                     
constDeclaration : KConst                 typeReference name constValue? TSemicolon;
                     
constValue : TAssign        stringLiteral;

              
returnType : typeReference | voidType;
              
typeOfReference : typeReference;
              
typeReference : collectionType | simpleType;
              
simpleType : primitiveType | objectType | nullableType | classType;

                                             
classType : qualifier;

objectType 
	:                             KObject 
	|                                  KSymbol
	|                             KString
	;

primitiveType 
	:                          KInt 
	|                           KLong 
	|                            KFloat 
	|                             KDouble 
	|                           KByte 
	|                           KBool
	;

voidType 
	:                           KVoid
	;

                         
nullableType :                      primitiveType TQuestion;

                           
collectionType :                 collectionKind TLessThan                      simpleType TGreaterThan;
collectionKind 
	:                                KSet 
	|                                 KList
	|                                     KMultiSet 
	|                                      KMultiList
	;
	
                      
                        
              
operationDeclaration : attribute* operationModifier*                       returnType name TOpenParen                       parameterList? TCloseParen TSemicolon;

operationModifier : operationModifierBuilder | operationModifierReadonly;
                                     
operationModifierBuilder : KBuilder;
                                     
operationModifierReadonly : KReadonly;

parameterList : parameter (TComma parameter)*;

                      
parameter : attribute*                 typeReference name;

                          
associationDeclaration : attribute* KAssociation                                    source=qualifier KWith                                     target=qualifier TSemicolon;


// Additional rules for lexer:

// Identifiers
           
identifier 
	: IdentifierNormal 
	| IdentifierVerbatim
	| IUri
	| IPrefix
	| IVersion
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

