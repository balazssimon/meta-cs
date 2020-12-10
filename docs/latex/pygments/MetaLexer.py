from pygments.lexers.dotnet import CSharpLexer
from pygments.token import Name, Keyword

class MetaLexer(CSharpLexer):
    name = 'MetaModel'
    aliases = ['mm']
    filenames = ['*.mm'] # just to have one if you whant to use

    EXTRA_KEYWORDS = ['metamodel', 'association', 'with', 'containment', 'list', 'set', 'multi_list', 'multi_set', 'redefines', 'subsets', 'entity', 'derived', 'union']

    def get_tokens_unprocessed(self, text):
        for index, token, value in CSharpLexer.get_tokens_unprocessed(self, text):
            if token is Name and value in self.EXTRA_KEYWORDS:
                yield index, Keyword, value
            else:
                yield index, token, value
