parser grammar MetaModelParser;

options
{
    tokenVocab = MetaModelLexer; 
	                          
}

@header {
using MetaDslx.Core;
}

main: namespaceDeclaration;

              
qualifiedName : identifier (TDot identifier)*;
identifierList : identifier (TComma identifier)*;
qualifiedNameList : qualifiedName (TComma qualifiedName)*;

                      
                       
annotation : TOpenBracket                        identifier annotationParams? TCloseBracket;
annotationParams : TOpenParen annotationParamList? TCloseParen;
annotationParamList : annotationParam (TComma annotationParam)*;

                     
                               
annotationParam :                        identifier TAssign                  expression;


                                                                        
                      
namespaceDeclaration: annotation* KNamespace qualifiedName TOpenBrace metamodelDeclaration declaration* TCloseBrace;

                    
                   
                      
metamodelDeclaration: annotation* KMetamodel identifier (TOpenParen metamodelPropertyList? TCloseParen)? TSemicolon;

metamodelPropertyList : metamodelProperty (TComma metamodelProperty)*;

         
metamodelProperty : identifier TAssign        stringLiteral;

declaration : enumDeclaration | classDeclaration | associationDeclaration | constDeclaration | functionDeclaration;

                        
                  
                      
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
	|                        constructorDeclaration
	;

                      
                      
fieldDeclaration : annotation*                 fieldModifier?                 typeReference identifier (redefinitions | subsettings)? TSemicolon;
fieldModifier 
	:                                      KContainment 
	|                                   KReadonly 
	|                               KLazy 
	|                                  KDerived
	|                                      KSynthetized
	|                                    KInherited
	;

redefinitions : KRedefines                                nameUseList?;
subsettings : KSubsets                                nameUseList?;

nameUseList :                        qualifiedName (TComma qualifiedName)*;

                        
                      
                      
constDeclaration : KConst                 typeReference identifier (TAssign                  expressionOrNewExpression)? TSemicolon;

                        
                                                     
                      
functionDeclaration : annotation* KExtern                       returnType identifier TOpenParen                       parameterList? TCloseParen TSemicolon;

        
returnType : typeReference | voidType;
        
typeOfReference : invisibleType | typeReference;
        
typeReference : collectionType | simpleType;
        
simpleType : primitiveType | objectType | nullableType | qualifiedName;
                   
classType : qualifiedName;

     
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

invisibleType
	:                                 KAny
	|                                  KNone
	|                                   KError
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

                         
                      
constructorDeclaration : annotation* identifier TOpenParen TCloseParen TOpenBrace                         initializerDeclaration* TCloseBrace;

initializerDeclaration 
	: synthetizedPropertyInitializer
	| inheritedPropertyInitializer
	;

                                           
synthetizedPropertyInitializer
	: (KThis TDot)? (TOpenBracket                                                qualifiedName TCloseBracket)?                                property=identifier TAssign                  expression TSemicolon;

                                         
inheritedPropertyInitializer
	: (KThis TDot)?                              object=identifier TDot (TOpenBracket                                                qualifiedName TCloseBracket)?                                property=identifier TAssign                  expression TSemicolon;

expressionList : expression (',' expression)*;

expressionOrNewExpressionList : expressionOrNewExpression (',' expressionOrNewExpression)*;
expressionOrNewExpression : expression | newExpression;

       
             
           
expression 
	: TOpenParen typeReference TCloseParen expression #castExpression                                    
    | KTypeof TOpenParen                          typeOfReference TCloseParen #typeofExpression                                  
	| TOpenParen expression TCloseParen #bracketExpression                                   
	| KThis #thisExpression                                
	| value=literalExpression #constantExpression                                    
	|        name=identifier #identifierExpression                                      
    | expression TOpenBracket                      expressionList TCloseBracket #indexerExpression                                   
    | expression TOpenParen                      expressionList? TCloseParen #functionCallExpression                                        
    | expression TDot        name=identifier #memberAccessExpression                                        
    | expression kind=postOperator #postExpression 
    | kind=preOperator expression #preExpression 
    | kind=unaryOperator expression #unaryExpression 
    | expression KAs typeReference #typeConversionExpression                                  
    | expression KIs typeReference #typeCheckExpression                                     
    | left=expression kind=multiplicativeOperator right=expression #multiplicativeExpression
    | left=expression kind=additiveOperator right=expression #additiveExpression
    | left=expression kind=shiftOperator right=expression #shiftExpression
    | left=expression kind=comparisonOperator right=expression #comparisonExpression
    | left=expression kind=equalityOperator right=expression #equalityExpression
    | left=expression TAmpersand right=expression #bitwiseAndExpression                               
    | left=expression THat right=expression #bitwiseXorExpression                                       
    | left=expression TBar right=expression #bitwiseOrExpression                              
    | left=expression TAndAlso right=expression #logicalAndExpression                                   
    | left=expression TOrElse right=expression #logicalOrExpression                                  
    | left=expression TQuestionQuestion right=expression #nullCoalescingExpression                                          
    | condition=expression TQuestion then=expression TColon else=expression #conditionalExpression                                       
    | left=expression operator=assignmentOperator right=expression #assignmentExpression 
	;

literalExpression 
    :                             nullLiteral
	|        booleanLiteral
	|        integerLiteral
	|        decimalLiteral
	|        scientificLiteral
    |        stringLiteral
	;

       
             
           
newExpression 
	: KNew                          classType TOpenParen TCloseParen (TOpenBrace newPropertyInitList? TCloseBrace)? #newObjectExpression                               
	| KNew                          collectionType TOpenParen TCloseParen (TOpenBrace                   expressionOrNewExpression? TCloseBrace)? #newCollectionExpression                                         
	;

newPropertyInitList : newPropertyInit (TComma newPropertyInit)* TComma?;

                               
                                   
newPropertyInit :                                identifier TAssign                  expressionOrNewExpression;

postOperator
	:                                                TPlusPlus
	|                                                TMinusMinus
	;

preOperator
	:                                               TPlusPlus
	|                                               TMinusMinus
	;

unaryOperator
	:                                      TPlus
	|                                   TMinus
	|                                           TTilde
	|                                TExclamation
	;

multiplicativeOperator
	:                                     TAsterisk
	|                                   TSlash
	|                                   TPercent
	;

additiveOperator
	:                                TPlus
	|                                     TMinus
	;

shiftOperator
	:                                      TLessThan TLessThan
	|                                       TGreaterThan TGreaterThan
	;

comparisonOperator
	:                                     TLessThan
	|                                        TGreaterThan
	|                                            TLessThanOrEqual
	|                                               TGreaterThanOrEqual
	;

equalityOperator
	:                                  TEqual
	|                                     TNotEqual
	;

assignmentOperator
	:                                   TAssign  
	|                                           TAsteriskAssign 
	|                                         TSlashAssign
	|                                         TPercentAssign
	|                                      TPlusAssign
	|                                           TMinusAssign
	|                                            TLeftShiftAssign
	|                                             TRightShiftAssign
	|                                      TAmpersandAssign
	|                                              THatAssign
	|                                     TBarAssign
	;

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


/*

 | DoubleQuoteVerbatimStringLiteral | SingleQuoteVerbatimStringLiteral

// Date and time literals  
dateOrTimeLiteral 
    : dateTimeLiteral | dateTimeOffsetLiteral | dateLiteral | timeLiteral;
dateTimeOffsetLiteral : DateTimeOffsetLiteral;
dateTimeLiteral : DateTimeLiteral;
dateLiteral : DateLiteral;
timeLiteral : TimeLiteral;

// Guid literal
guidLiteral : GuidLiteral;

$Symbol(MetaClass)
$TypeDef
classDeclaration : $Property(IsAbstract) $Value(true) KAbstract? KClass $NameDef identifier $Property(TypeParams) genericTypeParams? (TColon $Property(SuperClasses) classAncestors)? TOpenBrace classMemberDeclaration* TCloseBrace;

genericTypeParams : LT genericTypeParam (COMMA genericTypeParam)* GT;

$Symbol(MetaTypeParam)
$TypeParam
genericTypeParam : identifier;

*/
