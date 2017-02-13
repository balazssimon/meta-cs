using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public class BindVisitor : DetailedSyntaxVisitor<IMetaSymbol>
    {
        private Binder _binder;
        private DiagnosticBag _diagnostics;
        private bool _findBindableParent;
        private BindingOptions _options;
        private ArrayBuilder<RedNode> _qualifier;
        private ArrayBuilder<Type> _symbolTypes;

        private Binder _currentBinder;

        protected BindVisitor(Binder binder) 
            : base(false, false)
        {
            _binder = binder;
            this.Reset(null, false);
        }

        public virtual void Reset(DiagnosticBag diagnostics, bool findBindableParent = false)
        {
            _diagnostics = diagnostics;
            _findBindableParent = findBindableParent;
            _qualifier = ArrayBuilder<RedNode>.GetInstance();
            _symbolTypes = ArrayBuilder<Type>.GetInstance();
            _options = null;
        }

        public virtual void Free()
        {
            _diagnostics = null;
            _qualifier.Free();
            _symbolTypes.Free();
        }

        protected ImmutableArray<RedNode> Qualifier
        {
            get { return _qualifier.ToImmutable(); }
        }

        protected ImmutableArray<Type> SymbolTypes
        {
            get { return _symbolTypes.ToImmutable(); }
        }

        protected BindingOptions Options
        {
            get { return _options; }
        }

        protected DiagnosticBag Diagnostics
        {
            get { return _diagnostics; }
        }

        protected void BeginQualifier()
        {
            _qualifier.Clear();
        }

        protected void EndQualifier()
        {

            _qualifier.Clear();
        }

        protected void RegisterIdentifier(RedNode name)
        {
            _qualifier.Add(name);
        }

        protected void RegisterSymbolType(Type type)
        {
            _symbolTypes.Add(type);
        }

        protected void RegisterOptions(BindingOptions options)
        {
            _options = options;
        }
    }
}
