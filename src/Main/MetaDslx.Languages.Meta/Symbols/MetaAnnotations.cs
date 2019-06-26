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
        private static ImmutableModel _annotationModel;
        private ImmutableDictionary<string, Symbol> _annotations;

        public MetaAnnotations(Symbol container)
        {
            _container = container;
        }

        public static ImmutableModel Model
        {
            get
            {
                if (_annotationModel == null)
                {
                    Interlocked.CompareExchange(ref _annotationModel, CreateModel(), null);
                }
                return _annotationModel;
            }
        }

        public ImmutableDictionary<string, Symbol> Annotations
        {
            get
            {
                if (_annotations == null)
                {
                    var builder = ImmutableDictionary.CreateBuilder<string, Symbol>();
                    foreach (var annot in Model.Symbols)
                    {
                        var symbol = new MetaNamedTypeSymbol(annot, _container);
                        builder.Add(annot.MName, symbol);
                    }
                    Interlocked.CompareExchange(ref _annotations, builder.ToImmutable(), null);
                }
                return _annotations;
            }
        }

        private static ImmutableModel CreateModel()
        {
            MutableModel model = new MutableModel();
            MetaFactory factory = new MetaFactory(model);
            CreateAnnotation("Import", factory);
            CreateAnnotation("Type", factory);
            CreateAnnotation("Name", factory);
            CreateAnnotation("Scope", factory);
            CreateAnnotation("BaseScope", factory);
            CreateAnnotation("LocalScope", factory);
            return model.ToImmutable();
        }

        private static IMetaSymbol CreateAnnotation(string name, MetaFactory factory)
        {
            //var annot = factory.MetaAnnotation();
            var annot = factory.MetaAttribute();
            annot.Name = name;
            return annot;
        }
    }
}
