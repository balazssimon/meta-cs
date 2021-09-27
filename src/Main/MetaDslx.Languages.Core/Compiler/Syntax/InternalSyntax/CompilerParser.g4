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

                                                          
namespaceDeclaration: KNamespace qualifiedName TSemicolon namespaceBody;

      
namespaceBody: usingDeclaration* grammarDeclaration;

                   
                
grammarDeclaration: KGrammar name TSemicolon        ruleDeclarations;

       
usingDeclaration: KUsing (name TAssign)? qualifier TSemicolon;

ruleDeclarations: ruleDeclaration*;

                 
ruleDeclaration: parserRuleDeclaration | lexerRuleDeclaration;

                   
parserRuleDeclaration: parserRuleName (KDefines                                                 qualifier)? TColon parserRuleAlternative (TBar parserRuleAlternative)* TSemicolon;

                       
                        
parserRuleAlternative: parserRuleAlternativeElement+ eofElement?;

                   
                    
                  
                   
eofElement: KEof;

                   
                    
parserRuleAlternativeElement: parserMultiElement | parserNegatedElement;

parserMultiElement: (elementName assign)? parserRuleElement multiplicity?;

                             
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

                                    
parserNegatedElement: TNegate parserRuleElement;

                  
parserRuleElement: fixedElement | parserRuleReference | parserRuleBlock;

                     
fixedElement:                  stringLiteral;

                      
parserRuleReference:                            identifier;

                  
parserRuleBlock: TOpenParen parserRuleAlternative (TBar parserRuleAlternative)* TCloseParen;

                  
lexerRuleDeclaration: modifier=(                                    KHidden |                                       KFragment)? lexerRuleName TColon lexerRuleAlternative (TBar lexerRuleAlternative)* TSemicolon;

                       
                        
lexerRuleAlternative: lexerRuleAlternativeElement+;

                   
                    
lexerRuleAlternativeElement: lexerMultiElement | lexerNegatedElement | lexerRangeElement;

lexerMultiElement: lexerRuleElement multiplicity?;

                                    
lexerNegatedElement: TNegate lexerRuleElement;

                     
lexerRangeElement:                  start=fixedElement TArrow                end=fixedElement;

lexerRuleElement: fixedElement | wildcardElement | lexerRuleReference | lexerRuleBlock;

                        
wildcardElement: TDot;

                      
lexerRuleReference:                                 identifier;

                  
lexerRuleBlock: TOpenParen lexerRuleAlternative (TBar lexerRuleAlternative)* TCloseParen;

// Identifiers
     
name : identifier;

     
qualifiedName : qualifier;

          
qualifier : identifier (TDot identifier)*;

           
identifier : LexerIdentifier | ParserIdentifier;

     
           
lexerRuleName : LexerIdentifier;

     
           
parserRuleName : ParserIdentifier;

     
           
elementName : LexerIdentifier;

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


