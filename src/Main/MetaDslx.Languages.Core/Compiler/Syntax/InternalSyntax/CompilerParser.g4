parser grammar CompilerParser;

@header 
{
//using MetaDslx.Languages.Core.Model;
using MetaDslx.Languages.Compiler.Model;
}

options
{
    tokenVocab = CompilerLexer; 
	                      
}

main: grammarDeclaration EOF;

//$Define(type=Namespace,nestingProperty=Members,merge=true)
//namespaceDeclaration: KNamespace qualifiedName TSemicolon /*$Scope*/ grammarDeclaration;

//$Property(Members) 
                
grammarDeclaration: KGrammar name TSemicolon        ruleDeclarations;

ruleDeclarations: ruleDeclaration*;

                 
ruleDeclaration: parserRuleDeclaration | lexerRuleDeclaration;

                   
parserRuleDeclaration: parserRuleName TColon parserRuleAlternative (TBar parserRuleAlternative)* TSemicolon;

                       
                        
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

                  
lexerRuleDeclaration: lexerRuleName TColon lexerRuleAlternative (TBar lexerRuleAlternative)* TSemicolon;

                       
                        
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


