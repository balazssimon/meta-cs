from pygments.lexer import RegexLexer
from pygments.token import Text, Comment, Operator, Keyword, Name, String, Number, Other, Punctuation

class XTextLexer(RegexLexer):

    name = 'XText'
    aliases = ['xtext']
    filenames = '*.xtext'

    tokens = {
       'root': [
            (r'\s+', Text),
            (r'//.*?\n', Comment.Single),
            (r'/\*', Comment.Multiline, 'multiline-comments'),
            (r'(grammar|generate|import|with|as|terminal|returns)\b', Keyword),
            (r'([0-9]*\.[0-9]*|[0-9]+)(e[+-]?[0-9]+)?', Number.Float),
            (r'[0-9]+', Number.Integer),
            (r'[a-zA-Z_][a-zA-Z0-9_]*', Name),
            (r'"(\\\\|\\"|[^"])*"', String.Double),
            (r"'(\\\\|\\'|[^'])*'", String.Single),
            (r'\||\:|\(|\)|\{|\}|\?|\+|\*|=|\+=|\?=|\[|\]|;', Operator),
            (r'.+', Text),            
       ],
       'multiline-comments': [
            (r'/\*', Comment.Multiline, 'multiline-comments'),
            (r'\*/', Comment.Multiline, '#pop'),
            (r'[^/\*]+', Comment.Multiline),
            (r'[/*]', Comment.Multiline)
        ],
   }
