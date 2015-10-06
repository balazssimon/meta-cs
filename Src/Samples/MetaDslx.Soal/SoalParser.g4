parser grammar SoalParser;

options {
	tokenVocab=SoalLexer;
	                      
	                           
}

main : namespaceDeclaration*;

              
qualifiedName : identifier (TDot identifier)*;
identifierList : identifier (TComma identifier)*;
qualifiedNameList : qualifiedName (TComma qualifiedName)*;

                                                                      
namespaceDeclaration: KNamespace qualifiedName TOpenBrace declaration* TCloseBrace;

                       
declaration : structDeclaration | exceptionDeclaration;

                
structDeclaration : KStruct identifier TOpenBrace propertyDeclaration* TCloseBrace;

                   
exceptionDeclaration : KException identifier TOpenBrace propertyDeclaration* TCloseBrace;

                     
                  
propertyDeclaration :                 typeReference identifier TSemicolon;


        
returnType : typeReference | voidType;

        
typeReference 
	: arrayType
	| simpleType
	;

        
simpleType : primitiveType | objectType | nullableType | qualifiedName;

     
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

                   
arrayType :                      simpleType TOpenBracket TCloseBracket;


// Identifiers
     
           
identifier 
	: IdentifierNormal 
	| IdentifierVerbatim;

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
stringLiteral 
	: RegularStringLiteral 
	| SingleQuoteVerbatimStringLiteral 
	| DoubleQuoteVerbatimStringLiteral;
