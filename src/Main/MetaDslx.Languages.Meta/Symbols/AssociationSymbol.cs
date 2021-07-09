using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Languages.Meta.Syntax;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using SymbolKind = MetaDslx.CodeAnalysis.Symbols.SymbolKind;

namespace MetaDslx.Languages.Meta.Symbols
{
    public class AssociationSymbol : Symbol, ISourceSymbol
    {
        private readonly Symbol _containingSymbol;
        private readonly MergedDeclaration _declaration;
        private readonly CompletionState _state;
        private DiagnosticBag _diagnostics;

        public AssociationSymbol(Symbol containingSymbol, MergedDeclaration declaration) 
            : base()
        {
            Debug.Assert(declaration != null);
            _containingSymbol = containingSymbol;
            _declaration = declaration;
            _state = CompletionState.Create(Language);
        }

        public override SymbolKind Kind => SymbolKind.ConstructedType;

        public override Symbol ContainingSymbol => _containingSymbol;

        public override ImmutableArray<Symbol> ChildSymbols => ImmutableArray<Symbol>.Empty;

        public MergedDeclaration MergedDeclaration => _declaration;

        public override ImmutableArray<Location> Locations => _declaration.NameLocations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;

        public ImmutableArray<Diagnostic> Diagnostics => _diagnostics != null ? _diagnostics.ToReadOnly() : ImmutableArray<Diagnostic>.Empty;

        public override bool RequiresCompletion => true;

        public SymbolFactory SymbolFactory => ((ISourceSymbol)_containingSymbol).SymbolFactory;

    public override void ForceComplete(CompletionPart completionPart, SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            if (completionPart != null && _state.HasComplete(completionPart)) return;
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var incompletePart = _state.NextIncompletePart;
                if (!CompletePart(incompletePart, locationOpt, cancellationToken)) goto done;
                if (completionPart != null && _state.HasComplete(completionPart)) return;
                _state.SpinWaitComplete(incompletePart, cancellationToken);
            }

        done:
            // Don't return until we've seen all of the CompletionParts. This ensures all
            // diagnostics have been reported (not necessarily on this thread).
            var allParts = completionPart == null ? ImmutableArray.Create(CompletionGraph.All) : ImmutableArray.Create(completionPart);
            _state.SpinWaitComplete(allParts, cancellationToken);
        }

        public override bool HasComplete(CompletionPart part)
        {
            return _state.HasComplete(part);
        }

        protected virtual ImmutableHashSet<CompletionPart> GetAllCompletionParts(SourceLocation locationOpt)
        {
            return (locationOpt == null) ? CompletionGraph.MemberSymbolAll : CompletionGraph.MemberSymbolWithLocationAll;
        }

        protected virtual bool CompletePart(CompletionPart incompletePart, SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            if (incompletePart == null)
            {
                return false;
            }
            else if (incompletePart == MetaCompletionGraph.StartAssociation || incompletePart == MetaCompletionGraph.FinishAssociation)
            {
                if (_state.NotePartComplete(MetaCompletionGraph.StartAssociation))
                {
                    CompleteAssociation(cancellationToken);
                    _state.NotePartComplete(MetaCompletionGraph.FinishAssociation);
                }
            }
            else
            {
                // This assert will trigger if we forgot to handle any of the completion parts
                //Debug.Assert(!CompletionGraph.MemberSymbolAll.Contains(incompletePart));
                // any other values are completion parts intended for other kinds of symbols
                _state.NotePartComplete(incompletePart);
            }
            return true;
        }

        protected virtual void CompleteAssociation(CancellationToken cancellationToken)
        {
            var assoc = this.DeclaringSyntaxReferences[0].GetSyntax() as AssociationDeclarationSyntax;
            var compilation = this.DeclaringCompilation;
            var sourceBinder = compilation.GetBinder(assoc.Source);
            var targetBinder = compilation.GetBinder(assoc.Target);
            var diagnostics = DiagnosticBag.GetInstance();
            var source = (BoundSymbol)sourceBinder.Bind(diagnostics, cancellationToken);
            var target = (BoundSymbol)targetBinder.Bind(diagnostics, cancellationToken);
            AddSymbolDiagnostics(diagnostics);
            if (!diagnostics.HasAnyErrors())
            {
                var sourceProp = (MetaPropertyBuilder)(source.Symbols[0] as IModelSymbol).ModelObject;
                var targetProp = (MetaPropertyBuilder)(target.Symbols[0] as IModelSymbol).ModelObject;
                sourceProp.OppositeProperties.Add(targetProp);
            }
            diagnostics.Free();
        }

        private void AddSymbolDiagnostics(DiagnosticBag diagnostics)
        {
            if (!diagnostics.IsEmptyWithoutResolution)
            {
                LanguageCompilation compilation = this.DeclaringCompilation;
                Debug.Assert(compilation != null);
                if (_diagnostics == null) _diagnostics = new DiagnosticBag();
                _diagnostics.AddRange(diagnostics);
            }
        }

        public override void Accept(CodeAnalysis.Symbols.SymbolVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public override TResult Accept<TResult>(CodeAnalysis.Symbols.SymbolVisitor<TResult> visitor)
        {
            throw new NotImplementedException();
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            throw new NotImplementedException();
        }

        protected override ISymbol CreateISymbol()
        {
            throw new NotImplementedException();
        }

        public CodeAnalysis.Binding.BinderPosition<SymbolBinder> GetBinder(SyntaxReference syntax)
        {
            throw new NotImplementedException();
        }

        public Symbol GetChildSymbol(SyntaxReference syntax)
        {
            throw new NotImplementedException();
        }
    }
}
