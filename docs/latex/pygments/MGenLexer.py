from pygments.lexer import RegexLexer
from pygments.token import Text, Comment, Operator, Keyword, Name, String, Number, Other, Punctuation
from pygments.style import Style

class MetaGeneratorLexer(RegexLexer):

    name = 'MetaGenerator'
    aliases = ['mgen']
    filenames = ['*.mgen'] # just to have one if you whant to use

    tokens = {
       'root': [
            (r'\s+', Text),
            (r'//.*?\n', Comment.Single),
            (r'/\*', Comment.Multiline, 'multiline-comments'),
            (r'template', Keyword, 'template-name'),
            (r'(namespace|generator|for|extern|function|end|void|int|double|string|object|interface|separator|'
            r'if|else|for|while|repeat|until|switch|case|default|type|as|loop|hasloop|return|true|false|null|'
            r'using|properties)\b', Keyword),
            (r'([0-9]*\.[0-9]*|[0-9]+)(e[+-]?[0-9]+)?', Number.Float),
            (r'[0-9]+', Number.Integer),
            (r'[a-zA-Z_][a-zA-Z0-9_]*', Name),
            (r'"(\\\\|\\"|[^"])*"', String.Double),
            (r"'(\\\\|\\'|[^'])*'", String.Single),
            (r'->|=|/|\(|\)|\[|\]', Operator),
            (r'\{|\}|:|;|,', Text),
            (r'.+', Text)          
       ],
       'multiline-comments': [
            (r'/\*', Comment.Multiline, 'multiline-comments'),
            (r'\*/', Comment.Multiline, '#pop'),
            (r'[^/\*]+', Comment.Multiline),
            (r'[/*]', Comment.Multiline)
        ],
       'template-name': [
            (r'\s+', Text),
            (r'//.*?\n', Comment.Single),
            (r'/\*', Comment.Multiline, 'multiline-comments'),
            (r'[a-zA-Z_][a-zA-Z0-9_]*', Name),
            (r'(for|end|void|int|double|string|object|separator|'
            r'if|else|for|while|repeat|until|switch|case|default|type|as|loop|hasloop|return|true|false|null)\b', Keyword),
            (r'\(', Operator, ('#pop', 'template-header'))
        ],
       'template-header': [
            (r'\s+', Text),
            (r'//.*?\n', Comment.Single),
            (r'/\*', Comment.Multiline, 'multiline-comments'),
            (r'(for|end|void|int|double|string|object|separator|'
            r'if|else|for|while|repeat|until|switch|case|default|type|as|loop|hasloop|return|true|false|null)\b', Keyword),
            (r'([0-9]*\.[0-9]*|[0-9]+)(e[+-]?[0-9]+)?', Number.Float),
            (r'[0-9]+', Number.Integer),
            (r'[a-zA-Z_][a-zA-Z0-9_]*', Name),
            (r'"(\\\\|\\"|[^"])*"', String.Double),
            (r"'(\\\\|\\'|[^'])*'", String.Single),
            (r'=|\[|\]', Operator),
            (r'\)', Operator, ('#pop', 'template-output'))
        ],
       'template-output': [
            (r'end template\n$', Keyword, '#pop'),
            (r'\s+', Text.Output),
            (r'\n', Text.Output),
            (r'\\|\^', Operator.Control),
            (r'[^\[\\\^\n]+', Text.Output),
            (r'\[', Operator.Control, 'template-control')
        ],
       'template-control': [
            (r'\s+', Text),
            (r'//.*?\n', Comment.Single),
            (r'/\*', Comment.Multiline, 'multiline-comments'),
            (r'(for|end|void|int|double|string|object|separator|'
            r'if|else|for|while|repeat|until|switch|case|default|type|as|loop|hasloop|return|true|false|null)\b', Keyword),
            (r'([0-9]*\.[0-9]*|[0-9]+)(e[+-]?[0-9]+)?', Number.Float),
            (r'[0-9]+', Number.Integer),
            (r'[a-zA-Z_][a-zA-Z0-9_]*', Name),
            (r'"(\\\\|\\"|[^"])*"', String.Double),
            (r"'(\\\\|\\'|[^'])*'", String.Single),
            (r'->|=|/|\(|\)', Operator),
            (r'\{|\}|:|;|,|\.', Text),
            (r'\]', Operator.Control, '#pop'),
            (r'\[', Operator.Control, '#push')
        ]
   }

class MetaGeneratorStyle(Style):
    default_style = ""
    styles = {
        Operator.Control:   '#080',
        Text.Output:        '#888'
    }
 