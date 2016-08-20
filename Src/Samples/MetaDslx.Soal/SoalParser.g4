parser grammar SoalParser;

options {
	tokenVocab=SoalLexer;
	                      
	                          
}

main : namespaceDeclaration*;

              
qualifiedName : identifier (TDot identifier)*;
identifierList : identifier (TComma identifier)*;
qualifiedNameList : qualifiedName (TComma qualifiedName)*;

annotationList : annotation+;

returnAnnotationList : returnAnnotation+;

                      
                   
annotation : TOpenBracket annotationBody TCloseBracket;

                      
                   
returnAnnotation : TOpenBracket KReturn TColon annotationBody TCloseBracket;

annotationBody :                        identifier annotationProperties?;

annotationProperties : TOpenParen annotationPropertyList? TCloseParen;

annotationPropertyList : annotationProperty (TComma annotationProperty)*;

                     
                           
annotationProperty :                        identifier TAssign                  annotationPropertyValue;

annotationPropertyValue
	: constantValue
	| typeofValue
	;

                                                                      
namespaceDeclaration: annotationList? KNamespace qualifiedName TAssign (                         identifier TColon)?                       stringLiteral TOpenBrace declaration* TCloseBrace;

                       
declaration : enumDeclaration | structDeclaration | databaseDeclaration | interfaceDeclaration | componentDeclaration | compositeDeclaration | assemblyDeclaration | bindingDeclaration | endpointDeclaration | deploymentDeclaration;

// Enums

              
enumDeclaration : annotationList? KEnum identifier (TColon                                                                                  qualifiedName)? TOpenBrace enumLiterals? TCloseBrace;

enumLiterals : enumLiteral (TComma enumLiteral)* TComma?;

                       
                     
enumLiteral : annotationList? identifier;

// Structs and exceptions

                
structDeclaration : annotationList? KStruct identifier (TColon                                                                                    qualifiedName)? TOpenBrace propertyDeclaration* TCloseBrace;

                     
                  
propertyDeclaration : annotationList?                          typeReference identifier TSemicolon;


// Database

                  
databaseDeclaration : annotationList? KDatabase identifier TOpenBrace entityReference* operationDeclaration* TCloseBrace;

                   
entityReference : KEntity                  qualifiedName TSemicolon;


// Interface

                   
interfaceDeclaration : annotationList? KInterface identifier TOpenBrace operationDeclaration* TCloseBrace;

                     
                   
operationDeclaration : annotationList? operationResult identifier TOpenParen parameterList? TCloseParen (KThrows                                        qualifiedNameList)? TSemicolon;

parameterList : parameter (',' parameter)*;

                     
                        
parameter : annotationList?                          typeReference identifier;

                 
                        
operationResult : returnAnnotationList? (                         returnType| onewayType);

// Component

                   
componentDeclaration :                                       KAbstract? KComponent identifier (TColon                                                                                            qualifiedName)? TOpenBrace componentElements? TCloseBrace;

componentElements : componentElement+;

componentElement
	: componentService
	| componentReference
	| componentProperty
	| componentImplementation
	| componentLanguage
	;

                   
                
componentService : KService                                          qualifiedName                                identifier? componentServiceOrReferenceBody;
                     
                  
componentReference : KReference                                          qualifiedName                                identifier? componentServiceOrReferenceBody;

componentServiceOrReferenceBody 
	: TSemicolon
	| TOpenBrace componentServiceOrReferenceElement* TCloseBrace;

componentServiceOrReferenceElement
	: KBinding                                      qualifiedName TSemicolon;

                     
                  
componentProperty :          typeReference identifier TSemicolon;

                         
                        
componentImplementation : KImplementation identifier TSemicolon;

                   
                  
componentLanguage : KLanguage identifier TSemicolon;

                   
compositeDeclaration : KComposite identifier (TColon                                                                                                         qualifiedName)? TOpenBrace compositeElements? TCloseBrace;

                  
assemblyDeclaration : KAssembly identifier (TColon                                                                                                         qualifiedName)? TOpenBrace compositeElements? TCloseBrace;

compositeElements : compositeElement+;

compositeElement
	: componentService
	| componentReference
	| componentProperty
	| componentImplementation
	| componentLanguage
	| compositeComponent
	| compositeWire
	;

                     
compositeComponent : KComponent                     qualifiedName TSemicolon;

                
             
compositeWire : KWire wireSource KTo wireTarget TSemicolon;

wireSource :                                  qualifiedName;
wireTarget :                                  qualifiedName;

                    
deploymentDeclaration : KDeployment identifier TOpenBrace deploymentElements? TCloseBrace;

deploymentElements : deploymentElement+;

deploymentElement
	: environmentDeclaration
	| compositeWire
	;

                       
                     
environmentDeclaration : KEnvironment identifier TOpenBrace runtimeDeclaration runtimeReference* TCloseBrace;

                  
                 
runtimeDeclaration : KRuntime identifier TSemicolon;

runtimeReference
	: assemblyReference
	| databaseReference
	;

                     
assemblyReference : KAssembly                    qualifiedName TSemicolon;

                    
databaseReference : KDatabase                    qualifiedName TSemicolon;

// Binding

                 
bindingDeclaration : KBinding identifier TOpenBrace bindingLayers? TCloseBrace;

bindingLayers : transportLayer encodingLayer+ protocolLayer*;


                    
transportLayer 
	: httpTransportLayer 
	| restTransportLayer 
	| webSocketTransportLayer
	;

                                     
httpTransportLayer : KTransport IHTTP (TSemicolon | TOpenBrace httpTransportLayerProperties* TCloseBrace);
                                     
restTransportLayer : KTransport IREST (TSemicolon | TOpenBrace TCloseBrace);
                                          
webSocketTransportLayer : KTransport IWebSocket (TSemicolon | TOpenBrace TCloseBrace);

httpTransportLayerProperties
	: httpSslProperty
	| httpClientAuthenticationProperty
	;

              
httpSslProperty : ISSL TAssign        booleanLiteral TSemicolon;
                               
httpClientAuthenticationProperty : IClientAuthentication TAssign        booleanLiteral TSemicolon;

                    
encodingLayer 
	: soapEncodingLayer
	| xmlEncodingLayer
	| jsonEncodingLayer
	;

                                    
soapEncodingLayer : KEncoding ISOAP (TSemicolon | TOpenBrace soapEncodingProperties* TCloseBrace);
                                   
xmlEncodingLayer : KEncoding IXML (TSemicolon | TOpenBrace TCloseBrace);
                                    
jsonEncodingLayer : KEncoding IJSON (TSemicolon | TOpenBrace TCloseBrace);

soapEncodingProperties
	: soapVersionProperty
	| soapMtomProperty
	| soapStyleProperty
	;

                  
soapVersionProperty : IVersion TAssign                         identifier TSemicolon;

               
soapMtomProperty : IMTOM TAssign        booleanLiteral TSemicolon;

                
soapStyleProperty : IStyle TAssign                               identifier TSemicolon;

                    
       
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

returnType 
	: typeReference
	| voidType
	;

typeReference 
	: nonNullableArrayType
	| arrayType
	| simpleType
	| nulledType
	;

simpleType : valueType | objectType | qualifiedName;

nulledType : nullableType | nonNullableType;

referenceType : objectType | qualifiedName;

     
objectType 
	: KObject 
	| KString
	;
     
valueType 
	: KInt 
	| KLong 
	| KFloat 
	| KDouble 
	| KByte 
	| KBool
	| IDate
	| ITime
	| IDateTime
	| ITimeSpan
	;
     
voidType 
	: KVoid
	;
                                   
                                            
onewayType
	: KOneway
	;

                      
nullableType :                               valueType TQuestion;

                         
nonNullableType :                               referenceType TExclamation;

                         
nonNullableArrayType :                               arrayType TExclamation;

arrayType
	: simpleArrayType
	| nulledArrayType
	;

                   
simpleArrayType :                               simpleType TOpenBracket TCloseBracket;

                   
nulledArrayType :                               nulledType TOpenBracket TCloseBracket;


constantValue
	: literal
	| identifier
	;

typeofValue : KTypeof TOpenParen          returnType TCloseParen;

// Identifiers
     
           
identifier 
	: IdentifierNormal 
	| IdentifierVerbatim
	| contextualKeywords;

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

contextualKeywords
	: IDate
	| ITime
	| IDateTime
	| ITimeSpan
	| IVersion
	| IStyle
	| IMTOM
	| ISSL
	| IHTTP
	| IREST
	| IWebSocket
	| ISOAP
	| IXML
	| IJSON
	| IClientAuthentication
	;
