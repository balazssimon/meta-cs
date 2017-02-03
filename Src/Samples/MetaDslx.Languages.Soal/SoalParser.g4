parser grammar SoalParser;

options {
	tokenVocab=SoalLexer;
	                      
	                          
}

main : namespaceDeclaration* EOF;

              
qualifiedName : identifier (TDot identifier)*;
identifierList : identifier (TComma identifier)*;
qualifiedNameList : qualifiedName (TComma qualifiedName)*;

annotationList : annotation+;

returnAnnotationList : returnAnnotation+;

                      
                   
annotation : TOpenBracket annotationBody TCloseBracket;

                      
                   
returnAnnotation : TOpenBracket KReturn TColon annotationBody TCloseBracket;

annotationBody :                        nameDef annotationProperties?;

annotationProperties : TOpenParen annotationPropertyList? TCloseParen;

annotationPropertyList : annotationProperty (TComma annotationProperty)*;

                     
                           
annotationProperty :                        nameDef TAssign                  annotationPropertyValue;

annotationPropertyValue
	: constantValue
	| typeofValue
	;

                                                                      
namespaceDeclaration: annotationList? KNamespace qualifiedNameDef TAssign (                         identifier TColon)?                       stringLiteral TOpenBrace declaration* TCloseBrace;

                       
declaration : enumDeclaration | structDeclaration | databaseDeclaration | interfaceDeclaration | componentDeclaration | compositeDeclaration | assemblyDeclaration | bindingDeclaration | endpointDeclaration | deploymentDeclaration;

// Enums

              
enumDeclaration : annotationList? KEnum nameDef (TColon                                                                                  qualifiedName)? TOpenBrace enumLiterals? TCloseBrace;

enumLiterals : enumLiteral (TComma enumLiteral)* TComma?;

                       
                     
enumLiteral : annotationList? nameDef;

// Structs and exceptions

                
structDeclaration : annotationList? KStruct nameDef (TColon                                                                                    qualifiedName)? TOpenBrace propertyDeclaration* TCloseBrace;

                     
                  
propertyDeclaration : annotationList?                          typeReference nameDef TSemicolon;


// Database

                  
databaseDeclaration : annotationList? KDatabase nameDef TOpenBrace entityReference* operationDeclaration* TCloseBrace;

                   
entityReference : KEntity                  qualifiedName TSemicolon;


// Interface

                   
interfaceDeclaration : annotationList? KInterface nameDef TOpenBrace operationDeclaration* TCloseBrace;

                     
                   
operationDeclaration : annotationList? operationResult nameDef TOpenParen parameterList? TCloseParen (KThrows                                        qualifiedNameList)? TSemicolon;

parameterList : parameter (TComma parameter)*;

                     
                        
parameter : annotationList?                          typeReference nameDef;

                 
                        
operationResult : returnAnnotationList? operationReturnType;

// Component

                   
componentDeclaration :                                       KAbstract? KComponent nameDef (TColon                                                                                            qualifiedName)? TOpenBrace componentElements? TCloseBrace;

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
	: TSemicolon #componentServiceOrReferenceEmptyBody
	| TOpenBrace componentServiceOrReferenceElement* TCloseBrace #componentServiceOrReferenceNonEmptyBody;

componentServiceOrReferenceElement
	: KBinding                                      qualifiedName TSemicolon;

                     
                  
componentProperty :          typeReference nameDef TSemicolon;

                         
                        
componentImplementation : KImplementation nameDef TSemicolon;

                   
                  
componentLanguage : KLanguage nameDef TSemicolon;

                   
compositeDeclaration : KComposite nameDef (TColon                                                                                                         qualifiedName)? TOpenBrace compositeElements? TCloseBrace;

                  
assemblyDeclaration : KAssembly nameDef (TColon                                                                                                         qualifiedName)? TOpenBrace compositeElements? TCloseBrace;

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

                    
deploymentDeclaration : KDeployment nameDef TOpenBrace deploymentElements? TCloseBrace;

deploymentElements : deploymentElement+;

deploymentElement
	: environmentDeclaration
	| compositeWire
	;

                       
                     
environmentDeclaration : KEnvironment nameDef TOpenBrace runtimeDeclaration runtimeReference* TCloseBrace;

                  
                 
runtimeDeclaration : KRuntime nameDef TSemicolon;

runtimeReference
	: assemblyReference
	| databaseReference
	;

                     
assemblyReference : KAssembly                    qualifiedName TSemicolon;

                    
databaseReference : KDatabase                    qualifiedName TSemicolon;

// Binding

                 
bindingDeclaration : KBinding nameDef TOpenBrace bindingLayers? TCloseBrace;

bindingLayers : transportLayer encodingLayer+ protocolLayer*;


                    
transportLayer 
	: httpTransportLayer 
	| restTransportLayer 
	| webSocketTransportLayer
	;

                                     
httpTransportLayer : KTransport IHTTP httpTransportLayerBody;

httpTransportLayerBody
	: TSemicolon #httpTransportLayerEmptyBody
	| TOpenBrace httpTransportLayerProperties* TCloseBrace #httpTransportLayerNonEmptyBody;

                                     
restTransportLayer : KTransport IREST restTransportLayerBody;

restTransportLayerBody
	: TSemicolon #restTransportLayerEmptyBody
	| TOpenBrace TCloseBrace #restTransportLayerNonEmptyBody;

                                          
webSocketTransportLayer : KTransport IWebSocket webSocketTransportLayerBody;

webSocketTransportLayerBody
	: TSemicolon #webSocketTransportLayerEmptyBody
	| TOpenBrace TCloseBrace #webSocketTransportLayerNonEmptyBody;


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

                                    
soapEncodingLayer : KEncoding ISOAP soapEncodingLayerBody;

soapEncodingLayerBody
	: TSemicolon #soapEncodingLayerEmptyBody
	| TOpenBrace soapEncodingProperties* TCloseBrace #soapEncodingLayerNonEmptyBody;

                                   
xmlEncodingLayer : KEncoding IXML xmlEncodingLayerBody;

xmlEncodingLayerBody
	: TSemicolon #xmlEncodingLayerEmptyBody
	| TOpenBrace TCloseBrace #xmlEncodingLayerNonEmptyBody;

                                    
jsonEncodingLayer : KEncoding IJSON jsonEncodingLayerBody;

jsonEncodingLayerBody
	: TSemicolon #jsonEncodingLayerEmptyBody
	| TOpenBrace TCloseBrace #jsonEncodingLayerNonEmptyBody;

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

                  
endpointDeclaration : KEndpoint nameDef TColon                                          qualifiedName TOpenBrace endpointProperties? TCloseBrace;

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

operationReturnType
	:                          returnType
	|                                                                                  onewayType
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

     
nameDef : identifier;

     
qualifiedNameDef : qualifiedName;

// Identifiers
           
identifier 
	: identifiers
	| contextualKeywords;

identifiers
	: IdentifierNormal 
	| IdentifierVerbatim
	;

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
integerLiteral : LInteger;
decimalLiteral : LDecimal;
scientificLiteral : LScientific;

// String literals
stringLiteral 
	: LRegularString
	| LSingleQuoteVerbatimString 
	| LDoubleQuoteVerbatimString;

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
