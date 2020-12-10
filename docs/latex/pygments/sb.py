# Copy this to <Python installation directory>\Lib\site-packages\pygments\styles

from pygments.token import Text, Comment, Operator, Keyword, Name, String, Number, Error, Other, Punctuation
from pygments.style import Style

class SbStyle(Style):
    default_style = ""
    styles = {
        Comment:                '#080',
        Keyword:                'bold #00f',
        Operator:               '#000',
        Operator.Control:       '#080',
        Name:                   '#000',
        Name.Function:          '#000',
        Name.Class:             '#055',
        Name.Token:             '#008',
        Name.Rule:              '#088',
        Name.Annotation:        '#888',
        Text.Output:            '#888',
        String:                 '#800'
    }