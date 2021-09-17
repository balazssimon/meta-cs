using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class ArrayTypeSymbol : TypeSymbol
    {
        private TypeWithAnnotations? _elementTypeWithAnnotations;

        public override bool IsStatic => false;

        [SymbolProperty]
        public virtual int LowerBound { get; }
        [SymbolProperty]
        public virtual int Size { get; }
        [SymbolProperty]
        public virtual TypeSymbol ElementType { get; }

        public TypeWithAnnotations ElementTypeWithAnnotations
        {
            get
            {
                if (_elementTypeWithAnnotations is null)
                {
                    var typeWithAnnot = TypeWithAnnotations.Create(this.ElementType);
                    Interlocked.CompareExchange(ref _elementTypeWithAnnotations, typeWithAnnot, null);
                }
                return _elementTypeWithAnnotations;
            }
        }

        public override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            throw new NotImplementedException();
        }

        public virtual bool HasSameShapeAs(ArrayTypeSymbol other)
        {
            return true;
        }
    }
}
