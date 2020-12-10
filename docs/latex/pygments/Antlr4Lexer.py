from pygments.lexer import RegexLexer
from pygments.token import Text, Comment, Operator, Keyword, Name, String, Number, Error, Other, Punctuation
from pygments.style import Style

class Antlr4Lexer(RegexLexer):
    name = 'Antlr4'
    aliases = ['antlr4']
    filenames = ['*.g4','*.ag4']

    tokens = {
       'root': [
            (r'\s+', Text),
            (r'//.*?\n', Comment.Single),
            (r'/\*', Comment.Multiline, 'multiline-comments'),
            (r'\[', Operator, 'character-set'),
            (r'(grammar|lexer|parser|import|more|pushMode|popMode|channel|type|mode|true|false|options|tokens|channels|fragment|skip)\b', Keyword),
            (r'([0-9]*\.[0-9]*|[0-9]+)(e[+-]?[0-9]+)?', Number.Float),
            (r'[0-9]+', Number.Integer),
            (r'\$[a-zA-Z][a-zA-Z0-9_]*(\(.*?\))?', Name.Annotation),
            (r'\#[a-z][a-zA-Z0-9_]*', Name.Rule),
            (r'[a-z][a-zA-Z0-9_]*', Name.Rule),
            (r'[A-Z][a-zA-Z0-9_]*', Name.Token),
            (r'\{.*?\}', Name.Annotation),
            (r'\\u[0-9a-fA-F]+|\\r|\\n|\\t', String.Single),
            (r'"(\\\\|\\"|[^"])*"', String.Double),
            (r"'(\\\\|\\'|[^'])*'", String.Single),
            (r'\||\:|\(|\)|\?|\+|\*|=|\+=|\?=|\[|\]|;|\{|\}|->|,|\~', Operator),
            (r'.+', Text),            
       ],
       'multiline-comments': [
            (r'/\*', Comment.Multiline, 'multiline-comments'),
            (r'\*/', Comment.Multiline, '#pop'),
            (r'[^/\*]+', Comment.Multiline),
            (r'[/*]', Comment.Multiline)
        ],
       'character-set': [
            (r'\]', Operator, '#pop'),
            (r'\\u[0-9a-fA-F]+|\\r|\\n|\\t', String.Single),
            (r'[^\]]', Text),            
        ],
   }

class Antlr4Style(Style):
    default_style = ""
    styles = {
        Comment:                'italic #888',
        Keyword:                'bold #005',
        Name.Rule:              '#055',
        Name.Token:             '#008',
        Name.Annotation:        '#888',
        String:                 '#880'
    }