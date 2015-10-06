parser grammar SoalParser;

options {
	tokenVocab=SoalLexer;
	                      
	                           
}

main : namespace*;

namespace : KNamespace;
