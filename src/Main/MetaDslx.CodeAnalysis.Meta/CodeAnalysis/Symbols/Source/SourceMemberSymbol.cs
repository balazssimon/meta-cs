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

        public override ImmutableArray<Location> Locations => _declaration.NameLocations;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => _declaration.SyntaxReferences;

        public virtual ImmutableArray<DeclaredSymbol> GetDeclaredChildren()
        {
            return GetMembers();
        }

        internal override ImmutableArray<DeclaredSymbol> GetMembersUnordered()
        {
            return this.SourceDeclaration.GetMembersUnordered();
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            return this.SourceDeclaration.GetMembers();
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers(string name)
        {
            return this.SourceDeclaration.GetMembers(name);
        }

        internal override ImmutableArray<NamedTypeSymbol> GetTypeMembersUnordered()
        {
            return this.SourceDeclaration.GetTypeMembersUnordered();
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return this.SourceDeclaration.GetTypeMembers();
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return this.SourceDeclaration.GetTypeMembers(name);
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            return this.SourceDeclaration.GetTypeMembers(name, metadataName);
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
