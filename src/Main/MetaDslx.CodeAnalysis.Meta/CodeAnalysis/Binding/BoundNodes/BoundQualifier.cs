﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundQualifier : BoundValues
    {
        private ImmutableArray<BoundIdentifier> _lazyIdentifiers;
        private int _isInitialized;
        private object _lazyValue;

        public BoundQualifier(BoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        public override ImmutableArray<object> Values => ImmutableArray.Create(this.Value);

        public object Value
        {
            get
            {
                if (!this.IsInitialized())
                {
                    var binder = this.GetBinder();
                    binder.InitializeQualifierSymbol(this);
                    if (this.Identifiers.Length == 0 && !this.IsInitialized())
                    {
                        if (Interlocked.CompareExchange(ref _isInitialized, 1, 0) == 0)
                        {
                            _lazyValue = null;
                            Interlocked.CompareExchange(ref _isInitialized, 2, 1);
                        }
                    }
                    // Debug.Assert(this.IsInitialized()); // TODO:MetaDslx
                    if (!this.IsInitialized())
                    {
                        if (Interlocked.CompareExchange(ref _isInitialized, 1, 0) == 0)
                        {
                            _lazyValue = this.Compilation.CreateErrorTypeSymbol(this.Compilation.GlobalNamespace, this.Syntax.ToString(), 0);
                            Interlocked.CompareExchange(ref _isInitialized, 2, 1);
                        }
                        else
                        {
                            SpinWait.SpinUntil(() => _isInitialized == 2);
                        }
                    }
                }
                return _lazyValue;
            }
        }

        public virtual ImmutableArray<BoundIdentifier> Identifiers
        {
            get
            {
                if (_lazyIdentifiers.IsDefault)
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _lazyIdentifiers, this.GetChildIdentifiers());
                }
                return _lazyIdentifiers;
            }
        }

        public override void AddQualifiers(ArrayBuilder<BoundQualifier> qualifiers, CancellationToken cancellationToken = default)
        {
            qualifiers.Add(this);
        }

        internal void InitializeValues(ImmutableArray<BoundIdentifier> identifiers, ImmutableArray<object> values)
        {
            Debug.Assert(identifiers.Length == values.Length);
            for (int i = 0; i < identifiers.Length; i++)
            {
                identifiers[i].InitializeValue(values[i]);
            }
            this.InitializeValue(values[values.Length - 1]);
        }

        internal bool IsInitialized()
        {
            return _isInitialized == 2;
        }

        protected void InitializeValue(object value)
        {
            if (this.IsInitialized())
            {
                if (value == null) Debug.Assert(_lazyValue == null);
                else Debug.Assert(value.Equals(_lazyValue));
                return;
            }
            if (Interlocked.CompareExchange(ref _isInitialized, 1, 0) == 0)
            {
                _lazyValue = value;
                Interlocked.CompareExchange(ref _isInitialized, 2, 1);
            }
            else
            {
                SpinWait.SpinUntil(() => _isInitialized == 2);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var values = this.Identifiers;
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0) sb.Append(".");
                sb.Append(values[i].MetadataName);
            }
            sb.Append(" = ");
            sb.Append(this.Value);
            return sb.ToString();
        }

    }

}
