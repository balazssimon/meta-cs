parser grammar TestLangOneParser;

@header
{
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Model;
}

options
{
    tokenVocab = TestLangOneLexer; 
	                      
}

main: test* EOF;

test: test01 | test02 | test03 | test04 | test05 | test06 | test07 | test08 | test09 | test10 | test11;

// ===== Test01 =====

test01: KTest01 namespaceDeclaration01;

                                                             
namespaceDeclaration01: KNamespace qualifiedName namespaceBody01;

      
                       
namespaceBody01 : TOpenBrace declaration01* TCloseBrace;

declaration01 : vertex01 | arrow01;

                  
vertex01 : KVertex name TSemicolon;

                 
arrow01 : KArrow                                      source=qualifier TArrow                                      target=qualifier TSemicolon;

// ===== Test02 =====

test02: KTest02 namespaceDeclaration02;

                                                             
namespaceDeclaration02: KNamespace qualifiedName namespaceBody02;

      
namespaceBody02 : TOpenBrace declaration02* TCloseBrace;

declaration02 : vertex02 | arrow02;

                       
                  
vertex02 : KVertex name TSemicolon;

                       
                 
arrow02 : KArrow source02 TArrow target02 TSemicolon;

                 
                  
source02 : qualifier;

                 
                  
target02 : qualifier;

// ===== Test03 =====

test03: KTest03 namespaceDeclaration03;

                                                             
namespaceDeclaration03: KNamespace qualifiedName namespaceBody03;

      
namespaceBody03 : TOpenBrace declaration03* TCloseBrace;

declaration03 : vertex03 | arrow03;

vertex03 : KVertex                                            name TSemicolon;

                       
                 
arrow03 : KArrow source03 TArrow target03 TSemicolon;

source03 :                                      qualifier;

target03 :                                      qualifier;

// ===== Test04 =====

test04: KTest04 namespaceDeclaration04;

                                                             
namespaceDeclaration04: KNamespace qualifiedName namespaceBody04;

      
namespaceBody04 : TOpenBrace declaration04* TCloseBrace;

                       
declaration04 : vertex04 | arrow04;

                  
vertex04 : KVertex name TSemicolon;

                 
arrow04 : KArrow                                      source=qualifier TArrow                                      target=qualifier TSemicolon;

// ===== Test05 =====

test05: KTest05 namespaceDeclaration05;

                                                             
namespaceDeclaration05: KNamespace qualifiedName                                namespaceBody05;

namespaceBody05 : TOpenBrace declaration05* TCloseBrace;

declaration05 : vertex05 | arrow05;

                  
vertex05 : KVertex name TSemicolon;

                 
arrow05 : KArrow                                      source=qualifier TArrow                                      target=qualifier TSemicolon;

// ===== Test06 =====

test06: KTest06 namespaceDeclaration06;

                                                             
namespaceDeclaration06: KNamespace qualifiedName namespaceBody06;

      
                       
namespaceBody06 : TOpenBrace declaration06* TCloseBrace;

declaration06 : vertex06 | arrow06;

                                  
vertex06 : KVertex name TSemicolon;

                 
arrow06 : KArrow                                                                                                      source=name TArrow                                                                                                      target=name TSemicolon;

// ===== Test07 =====

test07: KTest07 namespaceDeclaration07;

                                                             
namespaceDeclaration07: KNamespace qualifiedName namespaceBody07;

      
namespaceBody07 : TOpenBrace declaration07* TCloseBrace;

declaration07 : vertex07 | arrow07;

                       
                                  
vertex07 : KVertex name TSemicolon;

                       
                 
arrow07 : KArrow source07 TArrow target07 TSemicolon;

                 
                                                
                                  
source07 : name;

                 
                                                
                                  
target07 : name;

// ===== Test08 =====

test08: KTest08 namespaceDeclaration08;

                                                             
namespaceDeclaration08: KNamespace qualifiedName namespaceBody08;

      
namespaceBody08 : TOpenBrace declaration08* TCloseBrace;

declaration08 : vertex08 | arrow08;

vertex08 : KVertex                                                            name TSemicolon;

                       
                 
arrow08 : KArrow source08 TArrow target08 TSemicolon;

source08 :                                                                                                      name;

target08 :                                                                                                      name;

// ===== Test09 =====

test09: KTest09 namespaceDeclaration09;

                                                             
namespaceDeclaration09: KNamespace qualifiedName namespaceBody09;

      
namespaceBody09 : TOpenBrace declaration09* TCloseBrace;

                       
declaration09 : vertex09 | arrow09;

                                  
vertex09 : KVertex name TSemicolon;

                 
arrow09 : KArrow                                                                                                      source=name TArrow                                                                                                      target=name TSemicolon;

// ===== Test10 =====

test10: KTest10 namespaceDeclaration10;

                                                             
namespaceDeclaration10: KNamespace qualifiedName                                namespaceBody10;

namespaceBody10 : TOpenBrace declaration10* TCloseBrace;

declaration10 : vertex10 | arrow10;

                                  
vertex10 : KVertex name TSemicolon;

                 
arrow10 : KArrow                                                                                                      source=name TArrow                                                                                                      target=name TSemicolon;

// ===== Test11 =====

test11: KTest11 namespaceDeclaration11*;

                                                             
namespaceDeclaration11: KNamespace qualifiedName namespaceBody11;

      
                       
namespaceBody11 : TOpenBrace declaration11* TCloseBrace;

declaration11 : vertex11 | arrow11;

                  
vertex11 : KVertex name TSemicolon;

                 
arrow11 : KArrow                                      source=qualifiedName TArrow                                      target=qualifiedName TSemicolon;


// ===== General =====

     
name : identifier;

     
qualifiedName : qualifier;

          
qualifier : identifier (TDot identifier)*;

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
      
stringLiteral : LRegularString;
