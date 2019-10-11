using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbolDef : BoundSymbols
    {
        private Type _type;
        private ImmutableArray<Symbol> _lazySymbols;

        public BoundSymbolDef(BoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, Type type, LanguageSyntaxNode syntax, bool hasErrors = false) 
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _type = type;
        }

        public override ImmutableArray<Symbol> Symbols
        {
            get
            {
                if (_lazySymbols.IsDefault)
                {
                    var boundNames = this.GetChildNames();
                    if (boundNames.Length == 0)
                    {
                        var binder = this.GetBinder<SymbolDefBinder>();
                        var containerSymbol = binder?.Next.GetParentDeclarationSymbol();
                        var symbol = containerSymbol?.GetSourceMember(this.Syntax);
                        Debug.Assert(symbol != null);
                        if (symbol != null)
                        {
                            ImmutableInterlocked.InterlockedInitialize(ref _lazySymbols, ImmutableArray.Create<Symbol>(symbol));
                        }
                        else
                        {
                            ImmutableInterlocked.InterlockedInitialize(ref _lazySymbols, ImmutableArray<Symbol>.Empty);
                        }
                    }
                    else
                    {
                        var symbols = ArrayBuilder<Symbol>.GetInstance();
                        foreach (var boundName in boundNames)
                        {
                            foreach (var qualifier in boundName.GetChildQualifiers())
                            {
                                var symbol = qualifier.Value as DeclaredSymbol;
                                Debug.Assert(symbol != null);
                                if (symbol != null)
                                {
                                    symbols.Add(symbol);
                                }
                            }
                        }
                        ImmutableInterlocked.InterlockedInitialize(ref _lazySymbols, symbols.ToImmutableAndFree());
                    }
                }
                return _lazySymbols;
            }
        }

        protected override void ForceCompleteNode(CancellationToken cancellationToken)
        {
            foreach (var symbol in this.Symbols)
            {
                this.SetPropertyValues((DeclaredSymbol)symbol, this.DiagnosticBag, cancellationToken);
            }
        }

        public override void AddProperties(ArrayBuilder<BoundProperty> properties, string property = null, CancellationToken cancellationToken = default)
        {
            foreach (var symbol in this.Symbols)
            {
                var declaration = ((DeclaredSymbol)symbol).MergedDeclaration;
                foreach (var decl in declaration.Declarations)
                {
                    if (cancellationToken.IsCancellationRequested) return;
                    if (decl.SyntaxReference.SyntaxTree == this.SyntaxTree)
                    {
                        foreach (var prop in decl.Properties)
                        {
                            if (prop.SyntaxReference != null)
                            {
                                var propNode = prop.SyntaxReference.GetSyntax();
                                var propBoundNodes = this.Compilation.GetBoundNodes(propNode);
                                foreach (var node in propBoundNodes)
                                {
                                    if (node is BoundProperty boundProperty)
                                    {
                                        if (boundProperty.Name == prop.Name && boundProperty.Owner == prop.Owner && boundProperty.OwnerType == prop.OwnerType)
                                        {
                                            properties.Add(boundProperty);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected virtual void SetPropertyValues(DeclaredSymbol symbol, DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            var properties = this.GetProperties(null, cancellationToken);
            var modelObject = (MutableObjectBase)symbol.ModelObject;
            if (modelObject == null) return;
            foreach (var boundProperty in properties)
            {
                string name = boundProperty.Name;
                var prop = modelObject.MGetProperty(name);
                if (prop == null)
                {
                    diagnostics.Add(ModelErrorCode.ERR_PropertyDoesNotExist, boundProperty.Location, modelObject, name);
                    continue;
                }
                //if (prop.IsBaseScope) continue;
                var propValues = ArrayBuilder<BoundValues>.GetInstance();
                boundProperty.AddValues(propValues, boundProperty, boundProperty, cancellationToken);
                foreach (var boundValue in propValues)
                {
                    //if (boundValue is BoundSymbolDef) continue; // TODO:MetaDslx - prevent values to be added multiple times
                    if (prop.IsCollection)
                    {
                        var values = boundValue.Values.Select(v => v is Symbol symbolValue ? symbolValue.ModelObject : v).ToArray();
                        try
                        {
                            modelObject.MAddRange(prop, values);
                        }
                        catch (ModelException me)
                        {
                            diagnostics.Add(ModelErrorCode.ERR_CannotAddValuesToProperty, this.Location, prop, modelObject, me.ToString());
                        }
                    }
                    else
                    {
                        if (boundValue.Values.Length == 1)
                        {
                            var value = boundValue.Values[0];
                            if (value is Symbol symbolValue) value = symbolValue.ModelObject;
                            try
                            {
                                modelObject.MSet(prop, value);
                            }
                            catch (ModelException me)
                            {
                                diagnostics.Add(ModelErrorCode.ERR_CannotSetValueToProperty, this.Location, prop, modelObject, me.ToString());
                            }
                        }
                        else if (boundValue.Values.Length > 1)
                        {
                            diagnostics.Add(ModelErrorCode.ERR_CannotAddMultipleValuesToNonCollectionProperty, this.Location, prop, modelObject);
                        }
                    }
                }
                propValues.Free();
            }
        }

        
    }
}
