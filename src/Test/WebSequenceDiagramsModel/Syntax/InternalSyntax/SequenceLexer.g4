lexer grammar SequenceLexer;

options {
	                      
	                              
}

channels {
	COMMENT,
	WHITESPACE
}

                                                      
KTitle : 'title' -> mode(LineEndText);
KNote : 'note' -> mode(NoteId);
KDestroy : 'destroy' -> mode(LineEndText);
KAlt : 'alt' -> mode(LineEndText);
KElse : 'else' -> mode(LineEndText);
KEnd : 'end' -> mode(LineEndText);
KOpt : 'opt' -> mode(LineEndText);
KLoop : 'loop' -> mode(LineEndText);
KRef : 'ref' -> mode(RefId);

                           
LSingleLineComment : '//' ~[\r\n]* -> channel(COMMENT);
                           
LCommentStart : '/*' .*? '*/' -> channel(COMMENT);

TCreate : ('->' | '->>' | '-->>' | '-->') WhiteSpaceChar* '*' -> mode(ArrowEndText);
TSync: '->' -> mode(ArrowEndText);
TAsync: '->>' -> mode(ArrowEndText);
TReturn: ('-->>' | '-->') -> mode(ArrowEndText);
TMinus : '-' -> type(LIdentifier);

                       
LUtf8Bom : [\u00EF][\u00BB][\u00BF] -> channel(WHITESPACE);
                                                                      
LWhiteSpace : WhiteSpaceChar+ -> channel(WHITESPACE);
                                                              
LCrLf : '\r'? '\n';// -> channel(WHITESPACE);
                                       
LLineEnd : [\u0085\u2028\u2029] -> channel(WHITESPACE);

                              
LIdentifier : ~[\-\r\ntndaeolr\u0020\u0009\u000B\u000C\u00A0\u001A]+;
LKeywordStart : [tndaeolr] -> type(LIdentifier);

fragment WhiteSpaceChar : [\u0020\u0009\u000B\u000C\u00A0\u001A];

mode NoteId;

NoteWhiteSpace : WhiteSpaceChar+ -> channel(WHITESPACE);
NoteIdText : ~[:\r\n\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> type(LIdentifier);
NoteIdColon : ':' -> type(TColon), mode(LineEndText);
NoteIdCrLf : '\r'? '\n' -> type(LCrLf), mode(NoteLines);

mode NoteLines;

NoteLinesWhiteSpace : WhiteSpaceChar+ -> channel(WHITESPACE);
NoteLinesCrLf : '\r'? '\n' -> type(LCrLf);
KEndNote : 'end note' -> mode(DEFAULT_MODE);
NoteLinesText : ~[\r\n\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> type(LIdentifier);

mode RefId;

RefWhiteSpace : WhiteSpaceChar+ -> channel(WHITESPACE);
RefIdText : ~[:\r\n\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> type(LIdentifier);
RefIdColon : ':' -> type(TColon), mode(RefLines);
RefIdCrLf : '\r'? '\n' -> type(LCrLf), mode(RefLines);

mode RefLines;

RefLinesWhiteSpace : WhiteSpaceChar+ -> channel(WHITESPACE);
RefLinesCrLf : '\r'? '\n' -> type(LCrLf);
KEndRef : 'end ref' -> mode(RefEnd);
RefLinesText : ~[e\r\n\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> type(LIdentifier);
RefLinesE : [e] -> type(LIdentifier);

mode RefEnd;

RefEndWhiteSpace : WhiteSpaceChar+ -> channel(WHITESPACE);
RefEndCrLf : '\r'? '\n' -> type(LCrLf), mode(DEFAULT_MODE);
RefEndTCreate : ('->' | '->>' | '-->>' | '-->') WhiteSpaceChar* '*' -> type(TCreate), mode(ArrowEndText);
RefEndTSync: '->' -> type(TSync), mode(ArrowEndText);
RefEndTAsync: '->>' -> type(TAsync), mode(ArrowEndText);
RefEndTReturn: ('-->>' | '-->') -> type(TReturn), mode(ArrowEndText);
RefEndTMinus : '-' -> type(LIdentifier);
RefEndText : ~[\-\r\n\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> type(LIdentifier);

mode LineEndText;

LineEndWhiteSpace : WhiteSpaceChar+ -> channel(WHITESPACE);
LineEndText : ~[\r\n\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> type(LIdentifier);
LineEndCrLf : '\r'? '\n' -> type(LCrLf), mode(DEFAULT_MODE);

mode ArrowEndText;

ArrowEndWhiteSpace : WhiteSpaceChar+ -> channel(WHITESPACE);
ArrowEndTRef : 'ref' -> type(KRef), mode(RefId);
ArrowEndText : ~[r:\r\n\u0020\u0009\u000B\u000C\u00A0\u001A]+ -> type(LIdentifier);
TColon : ':' -> mode(LineEndText);
ArrowEndR : 'r' -> type(LIdentifier);
ArrowEndCrLf : '\r'? '\n' -> type(LCrLf), mode(DEFAULT_MODE);
