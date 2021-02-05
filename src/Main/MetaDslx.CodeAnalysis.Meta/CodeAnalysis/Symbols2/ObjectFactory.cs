using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class ObjectFactory
    {
        private LanguageCompilation _compilation;
        private object _model;
        private ImmutableArray<object> _referencedModels;

        public ObjectFactory(LanguageCompilation compilation)
        {
            _compilation = compilation;
        }

        public LanguageCompilation Compilation => _compilation;
        public Language Language => _compilation.Language;

        public object Model
        {
            get
            {
                if (_model == null)
                {
                    Interlocked.CompareExchange(ref _model, this.CreateModel(), null);
                }
                return _model;
            }
        }

        public ImmutableArray<object> ReferencedModels
        {
            get
            {
                if (_referencedModels.IsDefault)
                {
                    var models = ArrayBuilder<object>.GetInstance();
                    foreach (var module in _compilation.SourceAssembly.Modules)
                    {
                        if (module.Ordinal > 0 && module is ModelModuleSymbol mms && mms.Model != null)
                        {
                            if (!models.Contains(mms.Model))
                            {
                                models.Add(mms.Model);
                            }
                        }
                    }
                    ImmutableInterlocked.InterlockedInitialize(ref _referencedModels, models.ToImmutableAndFree());
                }
                return _referencedModels;
            }
        }

        public abstract object CreateModel();
        public abstract object CreateObject(Type type);

    }
}
