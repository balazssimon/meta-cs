using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public partial class SourceMemberSymbol 
    {
        private SourceDeclaration _sourceDeclaration;
        private ImmutableArray<(CompletionPart start, CompletionPart finish)> _phaseBinders;

        public override AssemblySymbol ContainingAssembly => ContainingSymbol.ContainingAssembly;

        public override bool IsStatic => false;

        public override ModuleSymbol ContainingModule => ContainingSymbol.ContainingModule;

        protected SourceDeclaration SourceDeclaration
        {
            get
            {
                if (_sourceDeclaration == null)
                {
                    Interlocked.CompareExchange(ref _sourceDeclaration, new SourceDeclaration(this, _declaration), null);
                }
                return _sourceDeclaration;
            }
        }

        public override LexicalSortKey GetLexicalSortKey()
        {
            return this.SourceDeclaration.GetLexicalSortKey();
        }

        /*
        public T GetChildObject<T>(SyntaxReference syntax)
            where T : MutableObject
        {
            var symbol = _source.GetChildSymbol(syntax);
            if (symbol is IModelSymbol modelSymbol && modelSymbol.ModelObject is T mobj) return mobj;
            else return default;
        }

        public T GetChildObject<T>(SyntaxNode syntax)
            where T: MutableObject
        {
            var symbol = _source.GetChildSymbol(syntax);
            if (symbol is IModelSymbol modelSymbol && modelSymbol.ModelObject is T mobj) return mobj;
            else return default;
        }

        public T GetChildObject<T>(SyntaxToken syntax)
            where T : MutableObject
        {
            var symbol = _source.GetChildSymbol(syntax);
            if (symbol is IModelSymbol modelSymbol && modelSymbol.ModelObject is T mobj) return mobj;
            else return default;
        }
        */
    }
}
