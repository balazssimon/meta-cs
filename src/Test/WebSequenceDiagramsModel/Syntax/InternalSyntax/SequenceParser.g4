parser grammar SequenceParser;

options {
	tokenVocab=SequenceLexer;
	                      
}

main : interaction EOF;

                       
interaction : line*;

line 
	: title LCrLf #titleLine
	| declaration? LCrLf #declarationLine;

      
declaration
	: destroy
	| arrow
	| alt
	| opt
	| loop
	| ref
	| note
	;

title: KTitle name?;

                       
                   
arrow:                   source=lifeLineName                 type=arrowType                   target=lifeLineName TColon                        text?;

                       
                   
destroy: KDestroy                     lifeLineName?;

                       
                         
alt: altFragment elseFragment* end;

                    
                    
                                            
altFragment: KAlt                        condition=text? LCrLf fragmentBody;

                    
                    
                                             
elseFragment: KElse                        condition=text? LCrLf fragmentBody;

                       
                    
                                             
loop: loopFragment end;
loopFragment: KLoop                        condition=text? LCrLf fragmentBody;

                       
                    
                                            
opt: optFragment end;
optFragment: KOpt                        condition=text? LCrLf fragmentBody;

                       
                       
                                            
ref: simpleRefFragment | messageRefFragment;

simpleRefFragment: KRef (over=text TColon)?                        refText=text? LCrLf simpleBody KEndRef;
messageRefFragment: refInput simpleBody refOutput;

                
                   
refInput :                   source=lifeLineName                 sourceType=arrowType KRef (over=text TColon)?                        message=text? LCrLf;
                 
                   
refOutput: KEndRef ignored=text?                 targetType=arrowType                   target=lifeLineName TColon                        message=text?;

fragmentBody: line*;
end: KEnd text?;

note
	: singleLineNote
	| multiLineNote
	;

singleLineNote : KNote position=text TColon noteText=text;
multiLineNote : KNote simpleBody KEndNote;

simpleBody: simpleLine*;
simpleLine: text LCrLf;

arrowType :                          TSync |                           TAsync |                            TReturn |                            TCreate;

                                           
lifeLineName : name;

     
name : identifier;

           
identifier : text;

text : identifierPart+;

identifierPart: LIdentifier;


