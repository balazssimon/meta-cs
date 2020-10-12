java -jar antlr-4.8-complete.jar MetaGeneratorLexer.g4 -package MetaDslx.Languages.MetaGenerator.Syntax.InternalSyntax -Dlanguage=CSharp -listener -visitor -encoding utf8
java -jar antlr-4.8-complete.jar MetaGeneratorParser.g4 -package MetaDslx.Languages.MetaGenerator.Syntax.InternalSyntax -Dlanguage=CSharp -listener -visitor -encoding utf8
