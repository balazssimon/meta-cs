parser grammar MetaModelParser;

options
{
    tokenVocab = MetaModelLexer; 
}

main: namespaceDeclaration*;


qualifiedName : identifier (TDot identifier)*;
identifierList : identifier (TComma identifier)*;
qualifiedNameList : qualifiedName (TComma qualifiedName)*;


namespaceDeclaration: KNamespace /*@Property(Name)*/ qualifiedName TEquals   stringLiteral TOpenBrace  metamodelDeclaration* TCloseBrace;



metamodelDeclaration: KMetamodel identifier TOpenBrace declaration* TCloseBrace;


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

//@NameDef(MetaConstant)
constDeclaration : KConst typeReference /*@NameDef*/ identifier /*(TEquals expression)?*/ TSemicolon;


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



operationDeclaration : KStatic?  returnType identifier TOpenBracket  parameterList? TCloseBracket TSemicolon;
parameterList : parameter (TComma parameter)*;


parameter : typeReference identifier /*(TEquals expression)? { expression.ExpectedType = typeReference; }*/;

/*
expressionList : expression (',' expression)*; 

@Expression
expression 
	: '(' typeReference ')' expression #castExpression @Symbol(TypeConversionExpression) { Type = typeReference; }
    | 'typeof' '(' typeReference ')' #typeofExpression @Symbol(TypeOfExpression) { Type = typeof(MetaType); }
	| '(' expression ')' #bracketExpression @Symbol(BracketExpression) { Type = expression.Type; expression.ExpectedType = ExpectedType; }
	| literal #constantExpression @Symbol(ConstantExpression) { literal.ExpectedType = ExpectedType; }
	| identifier #identifierExpression @Symbol(IdentifierExpression) { identifier.ExpectedType = ExpectedType; Definition = bind; Type = Definition.Type; }
    | expression '[' expressionList ']' #indexerExpression @Symbol(IndexerExpression) { Definition = bind; Type = Definition.ReturnType; }
    | expression '(' expressionList? ')' #functionCallExpression @Symbol(FunctionCallExpression) { Definition = bind; Type = Definition.ReturnType; }
    | expression '.' identifier #memberAccessExpression @Symbol(MemberAccessExpression) { Definition = bind; Type = Definition.Type; }
    | expression operator=postOperator #postExpression @Symbol(UnaryExpression) { Type = expression.Type; expression.ExpectedType = ExpectedType; }
    | operator=preOperator expression #preExpression @Symbol(UnaryExpression) { Type = expression.Type; expression.ExpectedType = ExpectedType; }
    | operator=unaryOperator expression #unaryExpression @Symbol(UnaryExpression) { Type = expression.Type; expression.ExpectedType = ExpectedType; }
    | expression 'as' typeReference #typeConversionExpression @Symbol(TypeConversionExpression) { Operator = OperatorKind.TypeAs; Type = typeReference; }
    | expression 'is' typeReference #typeConversionExpression @Symbol(TypeConversionExpression) { Operator = OperatorKind.TypeIs; Type = BuiltInType.Bool; }
    | left=expression operator=multiplicativeOperator right=expression #multiplicativeExpression @Symbol(BinaryExpression)
    | left=expression operator=additiveOperator right=expression #additiveExpression @Symbol(BinaryExpression)
    | left=expression operator=shiftOperator right=expression #shiftExpression @Symbol(BinaryExpression)
    | left=expression operator=comparisonOperator right=expression #comparisonExpression @Symbol(BinaryExpression)
    | left=expression operator=equalityOperator right=expression #equalityExpression @Symbol(BinaryExpression)
    | left=expression '&' right=expression #bitwiseAndExpression @Symbol(BinaryExpression) { Operator = OperatorKind.And; }
    | left=expression '^' right=expression #bitwiseXorExpression @Symbol(BinaryExpression) { Operator = OperatorKind.ExclusiveOr; }
    | left=expression '|' right=expression #bitwiseOrExpression @Symbol(BinaryExpression) { Operator = OperatorKind.Or; }
    | left=expression '&&' right=expression #logicalAndExpression @Symbol(BinaryExpression) { Operator = OperatorKind.AndAlso; }
    | left=expression '||' right=expression #logicalOrExpression @Symbol(BinaryExpression) { Operator = OperatorKind.OrElse; }
    | left=expression '??' right=expression #nullCoalescingExpression @Symbol(BinaryExpression) { Operator = OperatorKind.Coalesce; }
    | expression '?' then=expression ':' else=expression #conditionalExpression @Symbol(ConditionalExpression)
    | expression operator=assignmentOperator value=expression #assignmentExpression @Symbol(AssignmentExpression) 	
	;

postOperator
	: @Value(OperatorKind.PostIncrementAssign) '++'
	| @Value(OperatorKind.PostDecrementAssign) '--'
	;

preOperator
	: @Value(OperatorKind.PreIncrementAssign) '++'
	| @Value(OperatorKind.PreDecrementAssign) '--'
	;

unaryOperator
	: @Value(OperatorKind.UnaryPlus) '+'
	| @Value(OperatorKind.Negate) '-'
	| @Value(OperatorKind.OnesComplement) '~'
	| @Value(OperatorKind.Not) '!'
	;

multiplicativeOperator
	: @Value(OperatorKind.Multiply) '*'
	| @Value(OperatorKind.Divide) '/'
	| @Value(OperatorKind.Modulo) '%'
	;

additiveOperator
	: @Value(OperatorKind.Add) '+'
	| @Value(OperatorKind.Subtract) '-'
	;

shiftOperator
	: @Value(OperatorKind.LeftShift) '<<'
	| @Value(OperatorKind.RightShift) '>>'
	;

comparisonOperator
	: @Value(OperatorKind.LessThan) '<'
	| @Value(OperatorKind.GreaterThan) '>'
	| @Value(OperatorKind.LessThanOrEqual) '<='
	| @Value(OperatorKind.GreaterThanOrEqual) '>='
	;

equalityOperator
	: @Value(OperatorKind.Equal) '=='
	| @Value(OperatorKind.NotEqual) '!='
	;

assignmentOperator
	: @Value(OperatorKind.Assign) '='  
	| @Value(OperatorKind.MultiplyAssign) '*=' 
	| @Value(OperatorKind.DivideAssign) '/=' 
	| @Value(OperatorKind.ModuloAssign) '%=' 
	| @Value(OperatorKind.AddAssign) '+=' 
	| @Value(OperatorKind.SubtractAssign) '-=' 
	| @Value(OperatorKind.LeftShiftAssign) '<<='
	| @Value(OperatorKind.RightShiftAssign) '>>='
	| @Value(OperatorKind.AndAssign) '&=' 
	| @Value(OperatorKind.ExclusiveOrAssign) '^=' 
	| @Value(OperatorKind.OrAssign) '|=' 
	;
*/


associationDeclaration : KAssociation  source=qualifiedName KWith  target=qualifiedName TSemicolon
{
	source.Opposites = target;
};


// Additional rules for lexer:

// Identifiers


identifier : IdentifierNormal /*| IdentifierVerbatim*/;
//identifier : IdentifierGeneral | IdentifierVerbatim;

// Literals
literal 
    : nullLiteral { Type = BuiltInType.Null; Value = null; }
	| booleanLiteral { Type = BuiltInType.Bool; Value = valueof(booleanLiteral); }
	| integerLiteral { Type = BuiltInType.Int; Value = valueof(integerLiteral); }
	| decimalLiteral { Type = BuiltInType.Double; Value = valueof(decimalLiteral); }
	| scientificLiteral { Type = BuiltInType.Double; Value = valueof(scientificLiteral); }
    | stringLiteral { Type = BuiltInType.String; Value = valueof(stringLiteral); }
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

@Symbol(MetaClass)
@TypeDef
classDeclaration : @Property(IsAbstract) @Value(true) KAbstract? KClass @NameDef identifier @Property(TypeParams) genericTypeParams? (TColon @Property(SuperClasses) classAncestors)? TOpenBrace classMemberDeclaration* TCloseBrace;

genericTypeParams : LT genericTypeParam (COMMA genericTypeParam)* GT;

@Symbol(MetaTypeParam)
@TypeParam
genericTypeParam : identifier;

*/

