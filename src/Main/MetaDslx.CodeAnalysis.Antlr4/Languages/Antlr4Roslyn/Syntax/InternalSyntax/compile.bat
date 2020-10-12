java -jar antlr-4.8-complete.jar LexBasic.g4 -Dlanguage=CSharp -package MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax -listener -visitor -encoding utf8
java -jar antlr-4.8-complete.jar Antlr4RoslynLexer.g4 -Dlanguage=CSharp -package MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax -listener -visitor -encoding utf8
java -jar antlr-4.8-complete.jar Antlr4RoslynParser.g4 -Dlanguage=CSharp -package MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax -listener -visitor -encoding utf8
