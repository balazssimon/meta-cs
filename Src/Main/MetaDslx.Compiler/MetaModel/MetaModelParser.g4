parser grammar MetaModelParser;

options
{
    tokenVocab = MetaModelLexer; 
}

@header {
using MetaDslx.Core;
}

main: namespaceDeclaration*;


qualifiedName : identifier (TDot identifier)*;
identifierList : identifier (TComma identifier)*;
qualifiedNameList : qualifiedName (TComma qualifiedName)*;


namespaceDeclaration: KNamespace /*$Property(Name)*/ qualifiedName TAssign   stringLiteral TOpenBrace  metamodelDeclaration* TCloseBrace;


metamodelDeclaration: KMetamodel identifier TOpenBrace  declaration* TCloseBrace;

declaration : enumDeclaration | classDeclaration | associationDeclaration | constDeclaration;


enumDeclaration : KEnum identifier TOpenBrace  enumValues (TSemicolon enumMemberDeclaration*)? TCloseBrace;
enumValues : enumValue (TComma enumValue)*;

enumValue : identifier;
enumMemberDeclaration :  operationDeclaration;


classDeclaration :  KAbstract? KClass identifier (TColon  classAncestors)? TOpenBrace classMemberDeclaration* TCloseBrace;
classAncestors : classAncestor (TComma classAncestor)*;
classAncestor :  qualifiedName;
classMemberDeclaration :  fieldDeclaration |  operationDeclaration;


fieldDeclaration :  fieldModifier? typeReference identifier TSemicolon;
fieldModifier :  KContainment |  KReadonly |  KLazy |  KDerived;

//$NameDef(MetaConstant)
constDeclaration : KConst typeReference /*$NameDef*/ identifier /*(TAssign expression)?*/ TSemicolon;


returnType : typeReference | voidType;

typeReference : collectionType | simpleType;

simpleType : primitiveType | objectType | nullableType | qualifiedName;


objectType 
	:  KObject 
	|  KString
	;

primitiveType 
	:  KInt 
	|  KLong 
	|  KFloat 
	|  KDouble 
	|  KByte 
	|  KBool
	;

voidType :  KVoid;


nullableType :  primitiveType TQuestion;


collectionType :  collectionKind TLessThan  simpleType TGreaterThan;
collectionKind :  KSet |  KList;



operationDeclaration : KStatic?  returnType identifier TOpenParen  parameterList? TCloseParen TSemicolon;
parameterList : parameter (TComma parameter)*;


parameter : typeReference identifier /*(TAssign expression)? { expression.ExpectedType = typeReference; }*/;



argumentList 
	:  expression (',' expression)* 
		
	;



expression 
	: TOpenParen typeReference TCloseParen expression #castExpression  
    | KTypeof TOpenParen typeReference TCloseParen #typeofExpression 
	| TOpenParen expression TCloseParen #bracketExpression 
	| literal #constantExpression 
	| identifier #identifierExpression  
    | expression TOpenBracket argumentList TCloseBracket #indexerExpression 
    | expression TOpenParen argumentList? TCloseParen #functionCallExpression 
    | expression TDot identifier #memberAccessExpression 
    | expression operator=postOperator #postExpression  
    | operator=preOperator expression #preExpression  
    | operator=unaryOperator expression #unaryExpression  
    | expression KAs typeReference #typeConversionExpression  
    | expression KIs typeReference #typeCheckExpression  
    | left=expression operator=multiplicativeOperator right=expression #multiplicativeExpression  
    | left=expression operator=additiveOperator right=expression #additiveExpression  
    | left=expression operator=shiftOperator right=expression #shiftExpression  
    | left=expression operator=comparisonOperator right=expression #comparisonExpression  
    | left=expression operator=equalityOperator right=expression #equalityExpression  
    | left=expression TAmpersand right=expression #bitwiseAndExpression  
    | left=expression THat right=expression #bitwiseXorExpression  
    | left=expression TBar right=expression #bitwiseOrExpression  
    | left=expression TAndAlso right=expression #logicalAndExpression  
    | left=expression TOrElse right=expression #logicalOrExpression  
    //| left=expression '??' right=expression #nullCoalescingExpression $Symbol(BinaryExpression) -> { Operator = global::MetaOperatorKind.Coalesce; }
    | condition=expression TQuestion then=expression TColon else=expression #conditionalExpression  
    //| expression operator=assignmentOperator value=expression #assignmentExpression $Symbol(AssignmentExpression) 	
	;

postOperator
	:  TPlusPlus
	|  TMinusMinus
	;

preOperator
	:  TPlusPlus
	|  TMinusMinus
	;

unaryOperator
	:  TPlus
	|  TMinus
	|  TTilde
	|  TExclamation
	;

multiplicativeOperator
	:  TAsterisk
	|  TSlash
	|  TPercent
	;

additiveOperator
	:  TPlus
	|  TMinus
	;

shiftOperator
	:  TLessThan TLessThan
	|  TGreaterThan TGreaterThan
	;

comparisonOperator
	:  TLessThan
	|  TGreaterThan
	|  TLessThanOrEqual
	|  TGreaterThanOrEqual
	;

equalityOperator
	:  TEqual
	|  TNotEqual
	;

assignmentOperator
	:  TAssign  
	|  TAsteriskAssign 
	|  TSlashAssign
	|  TPercentAssign
	|  TPlusAssign
	|  TMinusAssign
	|  TLeftShiftAssign
	|  TRightShiftAssign
	|  TAmpersandAssign
	|  THatAssign
	|  TBarAssign
	;




associationDeclaration : KAssociation  source=qualifiedName KWith  target=qualifiedName TSemicolon 
	
	;


// Additional rules for lexer:

// Identifiers


identifier : IdentifierNormal /*| IdentifierVerbatim*/;
//identifier : IdentifierGeneral | IdentifierVerbatim;

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
nullLiteral : KNull ;

// Boolean literals
booleanLiteral : KTrue | KFalse ;

// Number literals
integerLiteral : IntegerLiteral ;
decimalLiteral : DecimalLiteral ;
scientificLiteral : ScientificLiteral ;

// String literals
stringLiteral : RegularStringLiteral ;


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

