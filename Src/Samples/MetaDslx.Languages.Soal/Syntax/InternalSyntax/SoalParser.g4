parser grammar SoalParser;

options {
	tokenVocab=SoalLexer;
	                      
}

                
main :                         namespaceDeclaration* EOF;

     
name : identifier;

     
qualifiedName : qualifier;

          
qualifier : identifier (TDot identifier)*;
identifierList : identifier (TComma identifier)*;
qualifierList : qualifier (TComma qualifier)*;

annotationList : annotation+;

returnAnnotationList : returnAnnotation+;

                      
                      
annotation : TOpenBracket annotationHead TCloseBracket;

                      
                      
returnAnnotation : TOpenBracket KReturn TColon annotationHead TCloseBracket;

annotationHead : name annotationBody?;

     
annotationBody : TOpenParen annotationPropertyList? TCloseParen;

annotationPropertyList : annotationProperty (TComma annotationProperty)*;

                     
                              
annotationProperty : name TAssign                  annotationPropertyValue;

annotationPropertyValue
	: constantValue
	| typeofValue
	;

                                                                        
namespaceDeclaration : annotationList? KNamespace qualifiedName TAssign (                         identifier TColon)?                       stringLiteral namespaceBody;

      
namespaceBody : TOpenBrace declaration* TCloseBrace;

                       
declaration : enumDeclaration | structDeclaration | databaseDeclaration | interfaceDeclaration | componentDeclaration | compositeDeclaration | assemblyDeclaration | bindingDeclaration | endpointDeclaration | deploymentDeclaration;

// Enums

                
enumDeclaration : annotationList? KEnum name (TColon                                      qualifier)? enumBody;

     
enumBody: TOpenBrace enumLiterals? TCloseBrace;
enumLiterals : enumLiteral (TComma enumLiteral)* TComma?;

                       
                       
enumLiteral : annotationList? name;

// Structs and exceptions

                  
structDeclaration : annotationList? KStruct name (TColon                                        qualifier)? structBody;

     
structBody : TOpenBrace propertyDeclaration* TCloseBrace;

                     
                    
propertyDeclaration : annotationList?                 typeReference name TSemicolon;


// Database

                    
databaseDeclaration : annotationList? KDatabase name databaseBody;

     
databaseBody : TOpenBrace entityReference* operationDeclaration* TCloseBrace;

                   
entityReference : KEntity                    qualifier TSemicolon;


// Interface

                     
interfaceDeclaration : annotationList? KInterface name interfaceBody;

     
interfaceBody : TOpenBrace operationDeclaration* TCloseBrace;

                     
                     
operationDeclaration : operationHead TSemicolon;

operationHead : annotationList? operationResult name TOpenParen parameterList? TCloseParen (KThrows                                          qualifierList)?;

parameterList : parameter (TComma parameter)*;

                     
                          
parameter : annotationList?                 typeReference name;

                 
                           
operationResult : returnAnnotationList? operationReturnType;

// Component

                     
componentDeclaration :                                       KAbstract? KComponent name (TColon                                                qualifier)? componentBody;

     
componentBody : TOpenBrace componentElements? TCloseBrace;

componentElements : componentElement+;

componentElement
	: componentService
	| componentReference
	| componentProperty
	| componentImplementation
	| componentLanguage
	;

                   
                   
componentService : KService                                            qualifier name? componentServiceOrReferenceBody;
                     
                     
componentReference : KReference                                            qualifier name? componentServiceOrReferenceBody;

     
componentServiceOrReferenceBody 
	: TSemicolon #componentServiceOrReferenceEmptyBody
	| TOpenBrace componentServiceOrReferenceElement* TCloseBrace #componentServiceOrReferenceNonEmptyBody;

componentServiceOrReferenceElement
	: KBinding                                        qualifier TSemicolon;

                     
                    
componentProperty :                 typeReference name TSemicolon;

                         
                          
componentImplementation : KImplementation name TSemicolon;

                   
                    
componentLanguage : KLanguage name TSemicolon;

                     
compositeDeclaration : KComposite name (TColon                                                qualifier)? compositeBody;

     
compositeBody : TOpenBrace compositeElements? TCloseBrace;

                    
assemblyDeclaration : KAssembly name (TColon                                                qualifier)? compositeBody;

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

                     
compositeComponent : KComponent                       qualifier TSemicolon;

                
                
compositeWire : KWire wireSource KTo wireTarget TSemicolon;

wireSource :                                    qualifier;
wireTarget :                                    qualifier;

                      
deploymentDeclaration : KDeployment name deploymentBody;

     
deploymentBody : TOpenBrace deploymentElements? TCloseBrace;

deploymentElements : deploymentElement+;

deploymentElement
	: environmentDeclaration
	| compositeWire
	;

                       
                       
environmentDeclaration : KEnvironment name environmentBody;

     
environmentBody : TOpenBrace runtimeDeclaration runtimeReference* TCloseBrace;

                  
                   
runtimeDeclaration : KRuntime name TSemicolon;

runtimeReference
	: assemblyReference
	| databaseReference
	;

                     
assemblyReference : KAssembly                      qualifier TSemicolon;

                    
databaseReference : KDatabase                      qualifier TSemicolon;

// Binding

                   
bindingDeclaration : KBinding name bindingBody;

     
bindingBody : TOpenBrace bindingLayers? TCloseBrace;

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

              
httpSslProperty : ISSL TAssign booleanLiteral TSemicolon;
                               
httpClientAuthenticationProperty : IClientAuthentication TAssign booleanLiteral TSemicolon;

                    
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

               
soapMtomProperty : IMTOM TAssign booleanLiteral TSemicolon;

                
soapStyleProperty : IStyle TAssign                               identifier TSemicolon;

                    
protocolLayer : KProtocol protocolLayerKind TSemicolon;

protocolLayerKind 
	: wsAddressing
	;

                                       
wsAddressing : IWsAddressing;

// Endpoint:

                    
endpointDeclaration : KEndpoint name TColon                                            qualifier endpointBody;

     
endpointBody : TOpenBrace endpointProperties? TCloseBrace;

endpointProperties : endpointProperty+;

endpointProperty
	: endpointBindingProperty
	| endpointAddressProperty
	;

endpointBindingProperty : KBinding                                        qualifier TSemicolon;
endpointAddressProperty : KAddress                    stringLiteral TSemicolon;

// Types

          
returnType 
	: voidType
	| typeReference
	;

          
typeReference 
	: nonNullableArrayType
	| arrayType
	| simpleType
	| nulledType
	;

          
simpleType : valueType | objectType | qualifier;

          
nulledType : nullableType | nonNullableType;

          
referenceType : objectType | qualifier;

          
objectType 
	:                             KObject 
	|                             KString
	;

          
valueType 
	:                          KInt 
	|                           KLong 
	|                            KFloat 
	|                             KDouble 
	|                           KByte 
	|                           KBool
	|                           IDate
	|                           ITime
	|                               IDateTime
	|                               ITimeSpan
	;

                         
voidType 
	: KVoid
	;

                         
onewayType
	: KOneway
	;

               
operationReturnType
	:                                     onewayType
	| voidType
	| typeReference
	;

                        
nullableType :                      valueType TQuestion;

                           
nonNullableType :                      referenceType TExclamation;

                           
nonNullableArrayType :                      arrayType TExclamation;

arrayType
	: simpleArrayType
	| nulledArrayType
	;

                     
simpleArrayType :                      simpleType TOpenBracket TCloseBracket;

                     
nulledArrayType :                      nulledType TOpenBracket TCloseBracket;

constantValue
	: literal
	| identifier
	;

typeofValue : KTypeof TOpenParen returnType TCloseParen;

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
