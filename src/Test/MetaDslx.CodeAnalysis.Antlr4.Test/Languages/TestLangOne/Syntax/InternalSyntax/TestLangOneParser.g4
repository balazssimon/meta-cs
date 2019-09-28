parser grammar TestLangOneParser;

options
{
    tokenVocab = TestLangOneLexer; 
	                      
}

main: namespaceDeclaration EOF;

     
name : identifier;

     
qualifiedName : qualifier;

          
qualifier : identifier (TDot identifier)*;

                                                                    
namespaceDeclaration: KNamespace qualifiedName namespaceBody;

      
namespaceBody : TOpenBrace /*declaration**/ TCloseBrace;

// Identifiers
           
identifier 
	: IdentifierNormal 
	| IdentifierVerbatim
	| IUri
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
//$Value
//stringLiteral : LRegularString;
