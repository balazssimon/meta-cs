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


namespaceDeclaration: KNamespace /*$Property(Name)*/ qualifiedName TAssign  stringLiteral TOpenBrace  metamodelDeclaration* TCloseBrace;


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


fieldDeclaration :  fieldModifier?  typeReference identifier (redefinitions | subsettings)? TSemicolon;
fieldModifier :  KContainment |  KReadonly |  KLazy |  KDerived;


redefinitions : KRedefines  nameUseList?;

subsettings : KSubsets  nameUseList?;

nameUseList :  qualifiedName (TComma qualifiedName)*;

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


parameter :  typeReference identifier /*(TAssign expression)? { expression.ExpectedType = typeReference; }*/;

/*
$Symbol(ArgumentList)
argumentList 
	: $Property(Arguments) expression (',' expression)*
	;

$AutoSymbol
$Expression
expression 
	: TOpenParen typeReference TCloseParen expression #castExpression $Symbol(TypeConversionExpression) -> { Operator = global::MetaOperatorKind.TypeCast; Type = typeReference; }
    | KTypeof TOpenParen typeReference TCloseParen #typeofExpression -> { Type = typeof(global::MetaType); }
	| TOpenParen expression TCloseParen #bracketExpression -> { Type = expression.Type; expression.ExpectedType = ExpectedType; }
	| literal #constantExpression -> { literal.ExpectedType = ExpectedType; }
	| identifier #identifierExpression $NameUse -> { identifier.ExpectedType = ExpectedType; Type = identifier.Type; }
    | expression TOpenBracket argumentList TCloseBracket #indexerExpression -> { Definition = bind(expression,argumentList); Type = Definition.ReturnType; argumentList.ExpectedTypes = Definition.ExpectedTypes; }
    | expression TOpenParen argumentList? TCloseParen #functionCallExpression -> { Definition = bind(expression,argumentList); Type = Definition.ReturnType; argumentList.ExpectedTypes = Definition.ExpectedTypes; }
    | expression TDot identifier #memberAccessExpression -> { Definition = bind(expression,identifier); Type = Definition.Type; }
    | expression operator=postOperator #postExpression $Symbol(UnaryExpression) -> { Type = expression.Type; expression.ExpectedType = ExpectedType; }
    | operator=preOperator expression #preExpression $Symbol(UnaryExpression) -> { Type = expression.Type; expression.ExpectedType = ExpectedType; }
    | operator=unaryOperator expression #unaryExpression $Symbol(UnaryExpression) -> { Type = expression.Type; expression.ExpectedType = ExpectedType; }
    | expression KAs typeReference #typeConversionExpression $Symbol(TypeConversionExpression) -> { Operator = global::MetaOperatorKind.TypeAs; Type = typeReference; }
    | expression KIs typeReference #typeCheckExpression $Symbol(TypeConversionExpression) -> { Operator = global::MetaOperatorKind.TypeIs; Type = global::MetaBuiltInType.Bool; }
    | left=expression operator=multiplicativeOperator right=expression #multiplicativeExpression $Symbol(BinaryExpression) -> { BalancedType=balance(left,right); Type=BalancedType; left.ExpectedType = ExpectedType; right.ExpectedType = ExpectedType; }
    | left=expression operator=additiveOperator right=expression #additiveExpression $Symbol(BinaryExpression) -> { BalancedType=balance(left,right); Type=BalancedType; left.ExpectedType = ExpectedType; right.ExpectedType = ExpectedType; }
    | left=expression operator=shiftOperator right=expression #shiftExpression $Symbol(BinaryExpression) -> { BalancedType=balance(left,right); Type=BalancedType; left.ExpectedType = ExpectedType; right.ExpectedType = ExpectedType; }
    | left=expression operator=comparisonOperator right=expression #comparisonExpression $Symbol(BinaryExpression) -> { BalancedType=balance(left,right); Type=global::MetaBuiltInType.Bool; left.ExpectedType=BalancedType; right.ExpectedType=BalancedType; }
    | left=expression operator=equalityOperator right=expression #equalityExpression $Symbol(BinaryExpression) -> { BalancedType=balance(left,right); Type=global::MetaBuiltInType.Bool; left.ExpectedType=BalancedType; right.ExpectedType=BalancedType; }
    | left=expression TAmpersand right=expression #bitwiseAndExpression $Symbol(BinaryExpression) -> { Operator = global::MetaOperatorKind.And; BalancedType=balance(left,right); Type=BalancedType; left.ExpectedType = ExpectedType; right.ExpectedType = ExpectedType; }
    | left=expression THat right=expression #bitwiseXorExpression $Symbol(BinaryExpression) -> { Operator = global::MetaOperatorKind.ExclusiveOr; BalancedType=balance(left,right); Type=BalancedType; left.ExpectedType = ExpectedType; right.ExpectedType = ExpectedType; }
    | left=expression TBar right=expression #bitwiseOrExpression $Symbol(BinaryExpression) -> { Operator = global::MetaOperatorKind.Or; BalancedType=balance(left,right); Type=BalancedType; left.ExpectedType = ExpectedType; right.ExpectedType = ExpectedType; }
    | left=expression TAndAlso right=expression #logicalAndExpression $Symbol(BinaryExpression) -> { Operator = global::MetaOperatorKind.AndAlso; Type=global::MetaBuiltInType.Bool; left.ExpectedType=global::MetaBuiltInType.Bool; right.ExpectedType=global::MetaBuiltInType.Bool; }
    | left=expression TOrElse right=expression #logicalOrExpression $Symbol(BinaryExpression) -> { Operator = global::MetaOperatorKind.OrElse; Type=global::MetaBuiltInType.Bool; left.ExpectedType=global::MetaBuiltInType.Bool; right.ExpectedType=global::MetaBuiltInType.Bool; }
    //| left=expression '??' right=expression #nullCoalescingExpression $Symbol(BinaryExpression) -> { Operator = global::MetaOperatorKind.Coalesce; }
    | condition=expression TQuestion then=expression TColon else=expression #conditionalExpression $Symbol(ConditionalExpression) -> { Type = balance(then,else); condition.ExpectedType = global::MetaBuiltInType.Bool; then.ExpectedType = ExpectedType; else.ExpectedType = ExpectedType; }
    //| expression operator=assignmentOperator value=expression #assignmentExpression $Symbol(BinaryExpression) 	
	;

postOperator
	: $Value(MetaOperatorKind.PostIncrementAssign) TPlusPlus
	| $Value(MetaOperatorKind.PostDecrementAssign) TMinusMinus
	;

preOperator
	: $Value(MetaOperatorKind.PreIncrementAssign) TPlusPlus
	| $Value(MetaOperatorKind.PreDecrementAssign) TMinusMinus
	;

unaryOperator
	: $Value(MetaOperatorKind.UnaryPlus) TPlus
	| $Value(MetaOperatorKind.Negate) TMinus
	| $Value(MetaOperatorKind.OnesComplement) TTilde
	| $Value(MetaOperatorKind.Not) TExclamation
	;

multiplicativeOperator
	: $Value(MetaOperatorKind.Multiply) TAsterisk
	| $Value(MetaOperatorKind.Divide) TSlash
	| $Value(MetaOperatorKind.Modulo) TPercent
	;

additiveOperator
	: $Value(MetaOperatorKind.Add) TPlus
	| $Value(MetaOperatorKind.Subtract) TMinus
	;

shiftOperator
	: $Value(MetaOperatorKind.LeftShift) TLessThan TLessThan
	| $Value(MetaOperatorKind.RightShift) TGreaterThan TGreaterThan
	;

comparisonOperator
	: $Value(MetaOperatorKind.LessThan) TLessThan
	| $Value(MetaOperatorKind.GreaterThan) TGreaterThan
	| $Value(MetaOperatorKind.LessThanOrEqual) TLessThanOrEqual
	| $Value(MetaOperatorKind.GreaterThanOrEqual) TGreaterThanOrEqual
	;

equalityOperator
	: $Value(MetaOperatorKind.Equal) TEqual
	| $Value(MetaOperatorKind.NotEqual) TNotEqual
	;

assignmentOperator
	: $Value(MetaOperatorKind.Assign) TAssign  
	| $Value(MetaOperatorKind.MultiplyAssign) TAsteriskAssign 
	| $Value(MetaOperatorKind.DivideAssign) TSlashAssign
	| $Value(MetaOperatorKind.ModuloAssign) TPercentAssign
	| $Value(MetaOperatorKind.AddAssign) TPlusAssign
	| $Value(MetaOperatorKind.SubtractAssign) TMinusAssign
	| $Value(MetaOperatorKind.LeftShiftAssign) TLeftShiftAssign
	| $Value(MetaOperatorKind.RightShiftAssign) TRightShiftAssign
	| $Value(MetaOperatorKind.AndAssign) TAmpersandAssign
	| $Value(MetaOperatorKind.ExclusiveOrAssign) THatAssign
	| $Value(MetaOperatorKind.OrAssign) TBarAssign
	;
*/



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

