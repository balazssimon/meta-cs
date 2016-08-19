parser grammar MetaModelParser;

options
{
    tokenVocab = MetaModelLexer; 
	                          
}

@header {
using MetaDslx.Core.Immutable;
}

main: namespaceDeclaration;

              
qualifiedName : identifier (TDot identifier)*;
identifierList : identifier (TComma identifier)*;
qualifiedNameList : qualifiedName (TComma qualifiedName)*;

                      
                       
annotation : TOpenBracket                        identifier /*annotationParams?*/ TCloseBracket;

/*
annotationParams : TOpenParen annotationParamList? TCloseParen;
annotationParamList : annotationParam (TComma annotationParam)*;

$Property(Properties)
$Symbol(MetaAnnotationProperty)
annotationParam : $Property(Name) $Value identifier;
*/

                                                                        
                      
namespaceDeclaration: annotation* KNamespace qualifiedName TOpenBrace metamodelDeclaration declaration* TCloseBrace;

                    
                   
                      
metamodelDeclaration: annotation* KMetamodel identifier (TOpenParen metamodelPropertyList? TCloseParen)? TSemicolon;

metamodelPropertyList : metamodelProperty (TComma metamodelProperty)*;

         
metamodelProperty : identifier TAssign        stringLiteral;

declaration : enumDeclaration | classDeclaration | associationDeclaration | constDeclaration;

                        
                  
                      
enumDeclaration : annotation* KEnum identifier TOpenBrace                         enumValues (TSemicolon enumMemberDeclaration*)? TCloseBrace;
enumValues : enumValue (TComma enumValue)*;
                         
                      
enumValue : annotation* identifier;
enumMemberDeclaration :                       operationDeclaration;

                        
                   
                      
classDeclaration : annotation*                                       KAbstract? KClass identifier (TColon                         classAncestors)? TOpenBrace classMemberDeclaration* TCloseBrace;
classAncestors : classAncestor (TComma classAncestor)*;
classAncestor :                                                                   qualifiedName;
classMemberDeclaration 
	:                       fieldDeclaration 
	|                       operationDeclaration
	;

                      
                      
fieldDeclaration : annotation*                 fieldModifier?                 typeReference identifier (redefinitions | subsettings)? TSemicolon;
fieldModifier 
	:                                      KContainment 
	|                                   KReadonly 
	|                               KLazy 
	|                                  KDerived
	;

redefinitions : KRedefines                                nameUseList?;
subsettings : KSubsets                                nameUseList?;

nameUseList :                        qualifiedName (TComma qualifiedName)*;

                        
                      
                      
constDeclaration : KConst                 typeReference identifier TSemicolon;

        
returnType : typeReference | voidType;
        
typeOfReference : typeReference;
        
typeReference : collectionType | simpleType;
        
simpleType : primitiveType | objectType | nullableType | qualifiedName;
                   
classType : qualifiedName;

     
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

                       
                      
operationDeclaration : annotation* KStatic?                       returnType identifier TOpenParen                       parameterList? TCloseParen TSemicolon;
parameterList : parameter (TComma parameter)*;

                       
                      
parameter : annotation*                 typeReference identifier /*(TAssign expression)? { expression.ExpectedType = typeReference; }*/;


associationDeclaration : annotation* KAssociation                        source=qualifiedName KWith                        target=qualifiedName TSemicolon 
	                                          
	;


// Additional rules for lexer:

// Identifiers
     
           
identifier : IdentifierNormal | IdentifierVerbatim;
//identifier : IdentifierGeneral | IdentifierVerbatim;

// Literals
literal 
    :        nullLiteral
	|        booleanLiteral
	|        integerLiteral
	|        decimalLiteral
	|        scientificLiteral
    |        stringLiteral
	;

// Null literal
nullLiteral : KNull;

// Boolean literals
booleanLiteral : KTrue | KFalse;

// Number literals
integerLiteral : IntegerLiteral;
decimalLiteral : DecimalLiteral;
scientificLiteral : ScientificLiteral;

// String literals
stringLiteral : RegularStringLiteral;


