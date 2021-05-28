parser grammar MetaGeneratorParser;

options 
{ 
    tokenVocab = MetaGeneratorLexer;
	                         
}

main : namespaceDeclaration generatorDeclaration usingDeclaration* configDeclaration? methodDeclaration* EOF;

namespaceDeclaration : KNamespace qualifiedName TSemicolon;

generatorDeclaration : KStandalone? KGenerator identifier (TColon qualifiedName)? (KFor typeReference)? TSemicolon;

usingDeclaration
    : KUsing qualifiedName TSemicolon								#usingNamespaceDeclaration
    | KUsing KGenerator qualifiedName identifier? TSemicolon		#usingGeneratorDeclaration
	;

configDeclaration : startProperties=KProperties identifier? configProperty* KEnd endProperties=KProperties;
configProperty
    : typeReference identifier (TAssign expression)? TSemicolon #configPropertyDeclaration
    | startProperties=KProperties identifier configProperty* KEnd endProperties=KProperties  #configPropertyGroupDeclaration;

methodDeclaration : functionDeclaration | templateDeclaration | externFunctionDeclaration;

externFunctionDeclaration : KExtern functionSignature;
functionDeclaration : functionSignature body KEnd KFunction;
functionSignature : KFunction returnType identifier typeArgumentList? TOpenParenthesis paramList? TCloseParenthesis;
paramList : parameter (TComma parameter)*;
parameter : typeReference identifier (TAssign expression)?;

body : statement*;
statement 
    : singleStatementSemicolon
    | ifStatement
	| forStatement
    | whileStatement
    | repeatStatement
    | loopStatement
	| switchStatement;

singleStatement 
	: variableDeclarationStatement
    | returnStatement
    | expressionStatement
	;

singleStatementSemicolon : singleStatement TSemicolon;

variableDeclarationStatement : variableDeclarationExpression;
variableDeclarationExpression : typeReference variableDeclarationItem (TComma variableDeclarationItem)*;
variableDeclarationItem : identifier (TAssign expression)?;

voidStatement : KVoid expression;

returnStatement : KReturn expression;
expressionStatement : expression;

ifStatement : ifStatementBegin body elseIfStatementBody* ifStatementElseBody? ifStatementEnd;
elseIfStatementBody : elseIfStatement body;
ifStatementElseBody : ifStatementElse body;

ifStatementBegin : KIf TOpenParenthesis expression TCloseParenthesis;
elseIfStatement : KElse KIf TOpenParenthesis expression TCloseParenthesis;
ifStatementElse : KElse;
ifStatementEnd : KEnd KIf;


forStatement : forStatementBegin body forStatementEnd;

forStatementBegin : KFor TOpenParenthesis forInitStatement? semi1=TSemicolon endExpression=expressionList? semi2=TSemicolon stepExpression=expressionList? /*whileRunExpression?*/ TCloseParenthesis;
forStatementEnd : KEnd KFor;
forInitStatement : variableDeclarationExpression | expressionList;

whileStatement : whileStatementBegin body whileStatementEnd;

whileStatementBegin : KWhile TOpenParenthesis expression /*whileRunExpression?*/ TCloseParenthesis;
whileStatementEnd : KEnd KWhile;
whileRunExpression : separatorStatement;


repeatStatement : repeatStatementBegin body repeatStatementEnd;

repeatStatementBegin : KRepeat;
repeatStatementEnd : KUntil TOpenParenthesis expression /*repeatRunExpression?*/ TCloseParenthesis;
repeatRunExpression : separatorStatement;


loopStatement : loopStatementBegin body loopStatementEnd;
loopStatementBegin : KLoop TOpenParenthesis loopChain loopWhereExpression? /*loopOrderByExpression?*/ loopRunExpression? TCloseParenthesis;
loopStatementEnd : KEnd KLoop;
loopChain : loopChainItem (TSingleArrow loopChainItem)*;
loopChainItem : (typeReference? identifier TColon)? loopChainExpression;
loopChainExpression 
    : KTypeof TOpenParenthesis typeReference TCloseParenthesis	#loopChainTypeofExpression
    | identifier typeArgumentList?								#loopChainIdentifierExpression
    | loopChainExpression dot=(TDot | TQuestionDot) identifier typeArgumentList?		#loopChainMemberAccessExpression
    | loopChainExpression TOpenParenthesis expressionList? TCloseParenthesis #loopChainMethodCallExpression;
loopWhereExpression : KWhere expression;
//loopOrderByExpression : KOrderBy expression KDescending?;
//loopRunExpression : (TSemicolon loopRunList)+;
//loopRunList : loopRun (TComma loopRun)*;
//loopRun : separatorStatement | variableDeclarationStatement | expressionStatement;
loopRunExpression : separatorStatement;
separatorStatement : TSemicolon KSeparator identifier TAssign stringLiteral;


switchStatement : switchStatementBegin switchBranchStatement* switchDefaultStatement? switchStatementEnd;
switchStatementBegin : KSwitch TOpenParenthesis expression TCloseParenthesis;
switchStatementEnd : KEnd KSwitch;
switchBranchStatement : switchBranchHeadStatement body;
switchBranchHeadStatement : switchCaseOrTypeIsHeadStatements | switchTypeAsHeadStatement;
switchCaseOrTypeIsHeadStatements : switchCaseOrTypeIsHeadStatement+;
switchCaseOrTypeIsHeadStatement : switchCaseHeadStatement | switchTypeIsHeadStatement;
switchCaseHeadStatement : KCase expressionList TColon;
switchTypeIsHeadStatement : KType KIs typeReferenceList TColon;
switchTypeAsHeadStatement : KType KAs typeReference TColon;
switchDefaultStatement : switchDefaultHeadStatement body;
switchDefaultHeadStatement : KDefault TColon;

templateDeclaration : templateSignature templateBody KEndTemplate;
templateSignature : KTemplate identifier TOpenParenthesis paramList? TCloseParenthesis;
templateBody : templateContentLine*;
templateContentLine : templateContent* templateLineEnd;
templateContent : templateOutput | templateStatementStartEnd;
templateOutput : LTemplateOutput;
templateLineEnd : LTemplateCrLf | LTemplateLineBreak | LTemplateLineControl;
templateStatementStartEnd : TTemplateStatementStart templateStatement? TTemplateStatementEnd;

templateStatement 
    : voidStatement
    | variableDeclarationStatement
	| expressionStatement
    | ifStatementBegin
    | elseIfStatement
    | ifStatementElse
    | ifStatementEnd
	| forStatementBegin
	| forStatementEnd
    | whileStatementBegin
    | whileStatementEnd
    | repeatStatementBegin
    | repeatStatementEnd
    | loopStatementBegin
    | loopStatementEnd
	| switchStatementBegin
	| switchStatementEnd
	| switchBranchHeadStatement
	| switchDefaultHeadStatement;

//*** Expressions

typeArgumentList : TLessThan typeReferenceList TGreaterThan;

predefinedType 
    : KBool | KByte | KChar | KDecimal | KDouble | KFloat | KInt | KLong 
    | KObject | KSByte | KShort | KString | KUInt | KULong | KUShort;

typeReferenceList : typeReference (TComma typeReference)*;
typeReference : arrayType | nullableType | genericType | simpleType;
arrayType : arrayItemType rankSpecifiers;
arrayItemType : nullableType | genericType | simpleType;
nullableType : nullableItemType TQuestion;
nullableItemType : genericType | simpleType;
genericType : qualifiedName typeArgumentList;
simpleType : qualifiedName | predefinedType;
voidType : KVoid;
returnType : typeReference | voidType;

expressionList : expression (TComma expression)*;

variableReference : expression;
rankSpecifiers : rankSpecifier+;
rankSpecifier : TOpenBracket TComma* TCloseBracket;

unboundTypeName : genericDimensionItem (TDot genericDimensionItem)*;
genericDimensionItem : identifier genericDimensionSpecifier?;
genericDimensionSpecifier : TLessThan TComma* TGreaterThan;

anonymousFunctionSignature
    : TOpenParenthesis (explicitParameter (TComma explicitParameter)*)? TCloseParenthesis #explicitAnonymousFunctionSignature
    | TOpenParenthesis (implicitParameter (TComma implicitParameter)*)? TCloseParenthesis #implicitAnonymousFunctionSignature
    | implicitParameter #singleParamAnonymousFunctionSignature;
explicitParameter : typeReference identifier;
implicitParameter : identifier;

expression
    : KThis #thisExpression
    | literal #literalExpression
    | KTypeof TOpenParenthesis KVoid TCloseParenthesis #typeofVoidExpression
    | KTypeof TOpenParenthesis unboundTypeName TCloseParenthesis #typeofUnboundTypeExpression
    | KTypeof TOpenParenthesis typeReference TCloseParenthesis #typeofTypeExpression
    | KDefault TOpenParenthesis typeReference TCloseParenthesis #defaultValueExpression
    //| KNew typeReference objectOrCollectionInitializer? #newObjectOrCollectionExpression
    | KNew typeReference TOpenParenthesis expressionList? TCloseParenthesis /*objectOrCollectionInitializer?*/ #newObjectOrCollectionWithConstructorExpression
    | identifier typeArgumentList? #identifierExpression
    | KHasLoop TOpenParenthesis loopChain loopWhereExpression? TCloseParenthesis #hasLoopExpression
    | TOpenParenthesis expression TCloseParenthesis #parenthesizedExpression
    | expression TOpenBracket expressionList TCloseBracket #elementAccessExpression
    | expression TOpenParenthesis expressionList? TCloseParenthesis #functionCallExpression
    | predefinedType TDot identifier typeArgumentList? #predefinedTypeMemberAccessExpression
    | expression dot=(TDot | TQuestionDot) identifier typeArgumentList? #memberAccessExpression
    | TOpenParenthesis typeReference TCloseParenthesis expression #typecastExpression
    | op=(TPlus | TMinus | TExclamation | TTilde | TPlusPlus | TMinusMinus) expression #unaryExpression
    | expression op=(TPlusPlus | TMinusMinus) #postExpression
    | left=expression op=(TAsterisk | TSlash | TPercent) right=expression #multiplicationExpression
    | left=expression op=(TPlus | TMinus) right=expression #additionExpression
    | left=expression op=(TLessThan | TGreaterThan | TLessThanOrEquals | TGreaterThanOrEquals) right=expression #relationalExpression
    | left=expression op=(KIs | KAs) typeReference #typecheckExpression
    | left=expression op=(TEquals | TNotEquals) right=expression #equalityExpression
    | left=expression TAmp right=expression #bitwiseAndExpression
    | left=expression THat right=expression #bitwiseXorExpression
    | left=expression TPipe right=expression #bitwiseOrExpression
    | left=expression TAnd right=expression #logicalAndExpression
    | left=expression TXor right=expression #logicalXorExpression
    | left=expression TOr right=expression #logicalOrExpression
    | condition=expression TQuestion thenBranch=expression TColon elseBranch=expression #conditionalExpression
    | left=expression op=(TAssign | TAssignPlus | TAssignMinus | TAssignAsterisk | 
                  TAssignSlash | TAssignPercent | TAssignAmp | TAssignPipe |
                  TAssignHat | TAssignLeftShift | TAssignRightShift) right=expression #assignmentExpression
    | anonymousFunctionSignature TArrow expression #lambdaExpression;

//*** Common rules:

qualifiedName : identifier (TDot identifier)*;
identifierList : identifier (TComma identifier)*;

//*** Additional rules for lexer:

// Identifiers
identifier : IdentifierNormal;
//identifier : IdentifierNormal | IdentifierGeneral | IdentifierVerbatim;

// Literals
literal 
    : nullLiteral | booleanLiteral | numberLiteral | dateOrTimeLiteral  
    | charLiteral | stringLiteral | guidLiteral;

// Null literal
nullLiteral : KNull;

// Boolean literals
booleanLiteral : KTrue | KFalse;
 
// Number literals
numberLiteral : integerLiteral | decimalLiteral | scientificLiteral;
integerLiteral : LInteger;
decimalLiteral : LDecimal;
scientificLiteral : LScientific;

// Date and time literals  
dateOrTimeLiteral 
    : dateTimeLiteral | dateTimeOffsetLiteral | dateLiteral | timeLiteral;
dateTimeOffsetLiteral : LDateTimeOffset;
dateTimeLiteral : LDateTime;
dateLiteral : LDate;
timeLiteral : LTime;

// Char literals
charLiteral : LChar;

// String literals
stringLiteral : LRegularString | LDoubleQuoteVerbatimString;

// Guid literal
guidLiteral : LGuid;



