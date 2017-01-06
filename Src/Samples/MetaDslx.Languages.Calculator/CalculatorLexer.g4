lexer grammar CalculatorLexer;

TSemicolon : ';';
TOpenParen : '(';
TCloseParen : ')';
TComma : ',';
TAssign : '=';
TAdd : '+';
TSub : '-';
TMul : '*';
TDiv : '/';

                                    
KPrint : 'print';

STRING : '"' (' '..'~')* '"';
ID     : ('a'..'z'|'A'..'Z'|'_')+;
INT    : ('0'..'9')+;

           
UTF8BOM : [\u00EF][\u00BB][\u00BF] -> channel(WHITESPACE);

           
WHITESPACE : [\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> channel(WHITESPACE);

                     
ENDL   : '\r'? '\n' -> channel(WHITESPACE);

        
COMMENT : '//' ~[\r\n]* -> channel(COMMENT);

