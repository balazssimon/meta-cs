using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Meta.Symbols
{
    public class MetaAnnotations
    {
        private Symbol _container;
        private ImmutableDictionary<string, Symbol> _annotations;

        public MetaAnnotations(Symbol container)
        {
            _container = container;
        }

        public ImmutableDictionary<string, Symbol> Annotations
        {
            get
            {
                if (_annotations == null)
                {
                    Interlocked.CompareExchange(ref _annotations, this.CreateAnnotations(), null);
                }
                return _annotations;
            }
        }

        private ImmutableDictionary<string, Symbol> CreateAnnotations()
        {
            var builder = ImmutableDictionary.CreateBuilder<string, Symbol>();
            MutableModel model = new MutableModel();
            MetaFactory factory = new MetaFactory(model);
            this.CreateAnnotation("Import", factory, builder);
            this.CreateAnnotation("Type", factory, builder);
            this.CreateAnnotation("Scope", factory, builder);
            this.CreateAnnotation("BaseScope", factory, builder);
            this.CreateAnnotation("LocalScope", factory, builder);
            return builder.ToImmutable();
        }

        private Symbol CreateAnnotation(string name, MetaFactory factory, ImmutableDictionary<string, Symbol>.Builder annotations)
        {
            var annot = factory.MetaClass();
            annot.Name = name;
            var symbol = new MetaNamedTypeSymbol(annot, _container);
            annotations.Add(name, symbol);
            return symbol;
        }
    }
}
