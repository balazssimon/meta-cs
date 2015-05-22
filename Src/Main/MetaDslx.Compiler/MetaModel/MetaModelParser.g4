parser grammar MetaModelParser;

options
{
    tokenVocab = MetaModelLexer; 
}

main: namespaceDeclaration*;


qualifiedName : identifier (TDot identifier)*;
identifierList : identifier (TComma identifier)*;
qualifiedNameList : qualifiedName (TComma qualifiedName)*;


 
namespaceDeclaration: KNamespace   qualifiedName TEquals  stringLiteral TOpenBrace metamodelDeclaration* TCloseBrace;




metamodelDeclaration: KMetamodel   identifier TOpenBrace declaration* TCloseBrace;

declaration : enumDeclaration | classDeclaration | associationDeclaration | constDeclaration;




enumDeclaration : KEnum   identifier TOpenBrace enumValues (TSemicolon enumMemberDeclaration*)? TCloseBrace;
enumValues : enumValue (TComma enumValue)*;
enumValue :   identifier;
enumMemberDeclaration : operationDeclaration;




classDeclaration :  KAbstract? KClass   identifier (TColon classAncestors)? TOpenBrace classMemberDeclaration* TCloseBrace;
classAncestors : classAncestor (TComma classAncestor)*;

classAncestor :  qualifiedName;
classMemberDeclaration : fieldDeclaration | operationDeclaration;



fieldDeclaration : fieldModifier?  typeReference   identifier TSemicolon;
fieldModifier :  KContainment |  KReadonly |  KLazy |  KDerived;

constDeclaration : KConst typeReference  identifier (TEquals expression)? TSemicolon;


typeReference : collectionType | simpleType;
simpleType : objectType | nullableType | qualifiedName;

nullableType : primitiveType TQuestion?;
objectType : KObject | KString;
primitiveType : KInt | KLong | KFloat | KDouble | KByte | KBool;

collectionType : (KSet | KList) TLessThan simpleType TGreaterThan;
voidType : KVoid;

returnType : typeReference | voidType;





operationDeclaration : KStatic?  returnType   identifier TOpenBracket parameterList? TCloseBracket TSemicolon;
parameterList : parameter (TComma parameter)*;


parameter :  typeReference   identifier (TEquals expression)?;

expression : literal | qualifiedName;

associationDeclaration : KAssociation   source=qualifiedName KWith   target=qualifiedName TSemicolon;


// Additional rules for lexer:

// Identifiers

identifier : IdentifierNormal /*| IdentifierVerbatim*/;
//identifier : IdentifierGeneral | IdentifierVerbatim;

// Literals
literal 
    : nullLiteral | booleanLiteral | numberLiteral | dateOrTimeLiteral  
    | stringLiteral | guidLiteral;

// Null literal
nullLiteral : KNull;

// Boolean literals
booleanLiteral : KTrue | KFalse;

// Number literals
numberLiteral : integerLiteral | decimalLiteral | scientificLiteral;
integerLiteral : IntegerLiteral;
decimalLiteral : DecimalLiteral;
scientificLiteral : ScientificLiteral;

// Date and time literals  
dateOrTimeLiteral 
    : dateTimeLiteral | dateTimeOffsetLiteral | dateLiteral | timeLiteral;
dateTimeOffsetLiteral : DateTimeOffsetLiteral;
dateTimeLiteral : DateTimeLiteral;
dateLiteral : DateLiteral;
timeLiteral : TimeLiteral;

// String literals
stringLiteral : RegularStringLiteral /*| DoubleQuoteVerbatimStringLiteral | SingleQuoteVerbatimStringLiteral*/;

// Guid literal
guidLiteral : GuidLiteral;


