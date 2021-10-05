parser grammar CompilerParser;

@header 
{
using MetaDslx.Languages.Compiler.Model;
}

options
{
    tokenVocab = CompilerLexer; 
	                      
}

main: namespaceDeclaration EOF;

                       
                   
annotation: TOpenBracket name TCloseBracket;

                                                          
namespaceDeclaration: KNamespace qualifiedName TSemicolon namespaceBody;

      
namespaceBody: usingDeclaration* grammarDeclaration;

                   
                
grammarDeclaration: annotation* KGrammar name TSemicolon        ruleDeclarations;

       
usingDeclaration: KUsing (name TAssign)? qualifier TSemicolon;

ruleDeclarations: ruleDeclaration*;

                 
ruleDeclaration: parserRuleDeclaration | lexerRuleDeclaration;

parserRuleDeclaration: parserRuleAlt | parserRuleSimple;

                      
parserRuleAlt: annotation* parserRuleName (KDefines                                                 qualifier)? TColon parserRuleAltRef (TBar parserRuleAltRef)* TSemicolon;

                       
parserRuleAltRef:                  parserRuleIdentifier;

                         
parserRuleSimple: annotation* parserRuleName (KDefines                                                 qualifier)? TColon parserRuleNamedElement+ eofElement? TSemicolon;

                   
                               
                  
                             
eofElement: KEof;

                   
                               
parserRuleNamedElement: annotation* (elementName assign)? parserNegatedElement multiplicity?;

                             
assign
	:                                   TAssign 
	|                                           TQuestionAssign 
	|                                          TNegatedAssign 
	|                                       TPlusAssign
	;
                       
multiplicity
	:                                         TNonGreedyZeroOrOne 
	|                                          TNonGreedyZeroOrMore 
	|                                         TNonGreedyOneOrMore 
	|                                TZeroOrOne 
	|                                 TZeroOrMore 
	|                                TOneOrMore
	;

parserNegatedElement:                                      TNegate? parserRuleElement;

                  
parserRuleElement: parserRuleFixedElement | parserRuleReference | parserRuleWildcardElement | parserRuleBlockElement;

                               
parserRuleFixedElement: annotation*                  stringLiteral;

                                  
parserRuleWildcardElement: annotation* TDot;

                                   
parserRuleReference: annotation*                            identifier;

                               
parserRuleBlockElement: annotation* TOpenParen parserRuleNamedElement+ TCloseParen;

                  
lexerRuleDeclaration: annotation* modifier=(                                    KHidden |                                       KFragment)? lexerRuleName (KReturns                                        qualifier)? TColon lexerRuleAlternative (TBar lexerRuleAlternative)* TSemicolon;

                       
                             
lexerRuleAlternative: lexerRuleAlternativeElement+;

                   
                                    
lexerRuleAlternativeElement:                                      TNegate? lexerRuleElement multiplicity?;

                  
lexerRuleElement: lexerRuleReferenceElement | lexerRuleFixedStringElement | lexerRuleFixedCharElement | lexerRuleWildcardElement | lexerRuleBlockElement | lexerRuleRangeElement;

                                  
lexerRuleReferenceElement:                                 lexerRuleIdentifier;

                                 
lexerRuleWildcardElement: TDot;

                                    
lexerRuleFixedStringElement:                         LString;

                                  
lexerRuleFixedCharElement:                         LCharacter;

                              
lexerRuleBlockElement: TOpenParen lexerRuleAlternative (TBar lexerRuleAlternative)* TCloseParen;

                              
lexerRuleRangeElement:                  start=lexerRuleFixedCharElement TDotDot                end=lexerRuleFixedCharElement;

// Identifiers
     
name : identifier;

     
qualifiedName : qualifier;

          
qualifier : identifier (TDot identifier)*;

           
identifier : LexerIdentifier | ParserIdentifier;

           
lexerRuleIdentifier : LexerIdentifier;

           
parserRuleIdentifier : ParserIdentifier;

     
           
lexerRuleName : LexerIdentifier;

     
           
parserRuleName : ParserIdentifier;

     
           
elementName : ParserIdentifier | IgnoredIdentifier;

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
      
stringLiteral : LString;

      
charLiteral : LCharacter;


