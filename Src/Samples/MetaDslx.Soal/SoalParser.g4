parser grammar SoalParser;

options {
	tokenVocab=SoalLexer;
	                      
	                          
}

main : namespaceDeclaration*;

              
qualifiedName : identifier (TDot identifier)*;
identifierList : identifier (TComma identifier)*;
qualifiedNameList : qualifiedName (TComma qualifiedName)*;

                                                                      
namespaceDeclaration: KNamespace qualifiedName TOpenBrace declaration* TCloseBrace;

                       
declaration : structDeclaration | exceptionDeclaration | databaseDeclaration | interfaceDeclaration | componentDeclaration | compositeDeclaration | bindingDeclaration | endpointDeclaration;


// Structs and exceptions

                
structDeclaration : KStruct identifier (TColon                                      qualifiedName)? TOpenBrace propertyDeclaration* TCloseBrace;

                   
exceptionDeclaration : KException identifier (TColon                                         qualifiedName)? TOpenBrace propertyDeclaration* TCloseBrace;

                     
                  
propertyDeclaration :                 typeReference identifier TSemicolon;


// Database

                  
databaseDeclaration : KDatabase identifier TOpenBrace entityDeclaration* TCloseBrace;

                   
entityDeclaration : KEntity                  qualifiedName TSemicolon;


// Interface

                   
interfaceDeclaration : KInterface identifier TOpenBrace operationDeclaration* TCloseBrace;

                     
                   
operationDeclaration : (returnType|onewayType) identifier TOpenParen parameterList? TCloseParen (KThrows                                           qualifiedNameList)? TSemicolon;

parameterList : parameter (',' parameter)*;

                     
                   
parameter :                 typeReference identifier;


// Component

                   
componentDeclaration :                                       KAbstract? KComponent identifier (TColon                                              qualifiedName)? TOpenBrace componentElements? TCloseBrace;

componentElements : componentElement+;

componentElement
	: componentService
	| componentReference
	| componentProperty
	| componentImplementation
	;

                   
                
componentService : KService                                                     qualifiedName                                identifier? componentServiceOrReferenceBody;
                     
                  
componentReference : KReference                                                     qualifiedName                                identifier? componentServiceOrReferenceBody;

componentServiceOrReferenceBody 
	: TSemicolon
	| TOpenBrace componentServiceOrReferenceElement* TCloseBrace;

componentServiceOrReferenceElement
	: KBinding                                      qualifiedName TSemicolon;

                     
                  
componentProperty : typeReference identifier TSemicolon;

                         
                        
componentImplementation : KImplementation identifier TSemicolon;


                   
compositeDeclaration : KComposite identifier (TColon                                              qualifiedName)? TOpenBrace compositeElements? TCloseBrace;

compositeElements : compositeElement+;

compositeElement
	: componentService
	| componentReference
	| componentProperty
	| compositeComponent
	| compositeWire
	;

compositeComponent : KComponent                                           qualifiedName TSemicolon;

                
             
compositeWire : KWire wireService KTo wireReference TSemicolon;

wireService :                                      qualifiedName;
wireReference :                                          qualifiedName;

// Binding

                 
bindingDeclaration : KBinding identifier TOpenBrace bindingLayers? TCloseBrace;

bindingLayers : transportLayer encodingLayer+ protocolLayer*;

                    
       
transportLayer : KTransport transportLayerKind TSemicolon;

transportLayerKind :
	                                                                
	                                                                
	                                                                          
	identifier;

                    
       
encodingLayer : KEncoding encodingLayerKind TSemicolon;

encodingLayerKind : 
	                                                               
	                                                             
	                                                               
	identifier;

                    
       
protocolLayer : KProtocol protocolLayerKind TSemicolon;

protocolLayerKind : 
	                                                                       
	identifier;

// Endpoint:

                  
endpointDeclaration : KEndpoint identifier TColon                                          qualifiedName TOpenBrace endpointProperties? TCloseBrace;

endpointProperties : endpointProperty+;

endpointProperty
	: endpointBindingProperty
	| endpointAddressProperty
	;

endpointBindingProperty : KBinding                                      qualifiedName TSemicolon;
endpointAddressProperty : KAddress                           stringLiteral TSemicolon;

// Types

                     
        
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
                                   
                                                  
onewayType
	: KOneway
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
