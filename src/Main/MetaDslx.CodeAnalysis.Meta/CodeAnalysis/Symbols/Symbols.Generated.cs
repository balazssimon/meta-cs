using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
	public sealed partial class CompletionPart
	{
		public static readonly CompletionPart Attributes = new CompletionPart(nameof(Attributes));
		public static readonly CompletionPart Module = new CompletionPart(nameof(Module));
		public static readonly CompletionPart StartValidatingReferencedAssemblies = new CompletionPart(nameof(StartValidatingReferencedAssemblies));
		public static readonly CompletionPart FinishValidatingReferencedAssemblies = new CompletionPart(nameof(FinishValidatingReferencedAssemblies));
		public static readonly CompletionPart StartValidatingAddedModules = new CompletionPart(nameof(StartValidatingAddedModules));
		public static readonly CompletionPart FinishValidatingAddedModules = new CompletionPart(nameof(FinishValidatingAddedModules));
		public static readonly CompletionPart StartAttributeChecks = new CompletionPart(nameof(StartAttributeChecks));
		public static readonly CompletionPart FinishAttributeChecks = new CompletionPart(nameof(FinishAttributeChecks));
		public static readonly CompletionPart StartBaseTypes = new CompletionPart(nameof(StartBaseTypes));
		public static readonly CompletionPart FinishBaseTypes = new CompletionPart(nameof(FinishBaseTypes));
		public static readonly CompletionPart Members = new CompletionPart(nameof(Members));
		public static readonly CompletionPart TypeMembers = new CompletionPart(nameof(TypeMembers));
		public static readonly CompletionPart StartValidatingImports = new CompletionPart(nameof(StartValidatingImports));
		public static readonly CompletionPart FinishValidatingImports = new CompletionPart(nameof(FinishValidatingImports));
		public static readonly CompletionPart MembersCompleted = new CompletionPart(nameof(MembersCompleted));
		public static readonly CompletionPart AliasTarget = new CompletionPart(nameof(AliasTarget));

		public static readonly ImmutableHashSet<CompletionPart> AssemblySymbolAll = CompletionPart.Combine(Attributes);
		public static readonly ImmutableHashSet<CompletionPart> ModuleSymbolAll = CompletionPart.Combine(Attributes);
		public static readonly ImmutableHashSet<CompletionPart> DeclaredSymbolAll = CompletionPart.Combine(Attributes, Members, MembersCompleted, MembersCompleted);
		public static readonly ImmutableHashSet<CompletionPart> NamespaceOrTypeSymbolAll = CompletionPart.Combine(Attributes, Members, MembersCompleted, MembersCompleted);
		public static readonly ImmutableHashSet<CompletionPart> NamespaceSymbolAll = CompletionPart.Combine(Attributes, Members, MembersCompleted, MembersCompleted);
		public static readonly ImmutableHashSet<CompletionPart> TypeSymbolAll = CompletionPart.Combine(Attributes, Members, MembersCompleted, MembersCompleted);
		public static readonly ImmutableHashSet<CompletionPart> NamedTypeSymbolAll = CompletionPart.Combine(Attributes, Members, MembersCompleted, MembersCompleted);
		public static readonly ImmutableHashSet<CompletionPart> MemberSymbolAll = CompletionPart.Combine(Attributes, Members, MembersCompleted, MembersCompleted);
		public static readonly ImmutableHashSet<CompletionPart> FieldSymbolAll = CompletionPart.Combine(Attributes, Members, MembersCompleted, MembersCompleted);
		public static readonly ImmutableHashSet<CompletionPart> PropertySymbolAll = CompletionPart.Combine(Attributes, Members, MembersCompleted, MembersCompleted);
		public static readonly ImmutableHashSet<CompletionPart> MethodSymbolAll = CompletionPart.Combine(Attributes, Members, MembersCompleted, MembersCompleted);

		public static CompletionGraphBuilder ConstructCompletionGraph()
		{
			CompletionGraphBuilder builder = new CompletionGraphBuilder();
			builder.AddLast(Attributes);
			builder.AddLast(Module);
			builder.AddLast(StartValidatingReferencedAssemblies);
		   	builder.AddLast(FinishValidatingReferencedAssemblies);
			builder.AddLast(StartValidatingAddedModules);
		   	builder.AddLast(FinishValidatingAddedModules);
			builder.AddLast(StartAttributeChecks);
		   	builder.AddLast(FinishAttributeChecks);
			builder.AddLast(StartBaseTypes);
		   	builder.AddLast(FinishBaseTypes);
			builder.AddLast(Members);
			builder.AddLast(TypeMembers);
			builder.AddLast(StartValidatingImports);
		   	builder.AddLast(FinishValidatingImports);
			builder.AddLast(MembersCompleted);
			builder.AddLast(AliasTarget);
			builder.Precedes(StartValidatingReferencedAssemblies, FinishValidatingReferencedAssemblies);
			builder.Precedes(StartValidatingAddedModules, FinishValidatingAddedModules);
			builder.Precedes(StartAttributeChecks, FinishAttributeChecks);
			builder.Precedes(StartBaseTypes, FinishBaseTypes);
			builder.Precedes(StartValidatingImports, FinishValidatingImports);
			return builder;
		}
	}
}
namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Specifies the possible kinds of symbols.
    /// </summary>
    public class LanguageSymbolKind : EnumObject
    {
        /// <summary>
        /// Symbol is an unknown symbol.
        /// </summary>
        public const string None = nameof(None);

        /// <summary>
        /// Symbol is an Assembly.
        /// </summary>
        public const string Assembly = nameof(Assembly);

        /// <summary>
        /// Symbol is an Module.
        /// </summary>
        public const string Module = nameof(Module);

        /// <summary>
        /// Symbol is an Namespace.
        /// </summary>
        public const string Namespace = nameof(Namespace);

        /// <summary>
        /// Symbol is an NamedType.
        /// </summary>
        public const string NamedType = nameof(NamedType);

        /// <summary>
        /// Symbol is an Field.
        /// </summary>
        public const string Field = nameof(Field);

        /// <summary>
        /// Symbol is an Property.
        /// </summary>
        public const string Property = nameof(Property);

        /// <summary>
        /// Symbol is an Method.
        /// </summary>
        public const string Method = nameof(Method);

        protected LanguageSymbolKind(string name)
            : base(name)
        {
        }

        protected LanguageSymbolKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static LanguageSymbolKind()
        {
            EnumObject.RegisterDefault<LanguageSymbolKind>(None);
            EnumObject.AutoInit<LanguageSymbolKind>();
        }

        public static implicit operator LanguageSymbolKind(string name)
        {
            return FromString<LanguageSymbolKind>(name);
        }

        public static explicit operator LanguageSymbolKind(int value)
        {
            return FromIntUnsafe<LanguageSymbolKind>(value);
        }
    }
}

namespace MetaDslx
{
}
namespace MetaDslx.CodeAnalysis
{
}
namespace MetaDslx.CodeAnalysis.Symbols
{
	public abstract partial class Symbol : ISymbol
	{
	
	    public abstract LanguageSymbolKind Kind { get; }
	
		public abstract Language Language { get; }
		public virtual string Name => string.Empty;
		public virtual string MetadataName => this.Name;
		public abstract Symbol ContainingSymbol { get; }
		public abstract ImmutableArray<Location> Locations { get; }
		public virtual bool IsImplicitlyDeclared => false;
		public abstract ImmutableArray<SyntaxReference> DeclaringSyntaxReferences { get; }
		public abstract ImmutableArray<AttributeData> Attributes { get; }
	
	
	
	
	    /// <summary>
	    /// True if this Symbol should be completed by calling ForceComplete.
	    /// Intuitively, true for source entities (from any compilation).
	    /// </summary>
	    public virtual bool RequiresCompletion => false;
	
	    public virtual void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
	    {
	        // must be overridden by source symbols, no-op for other symbols
	        Debug.Assert(!this.RequiresCompletion);
	    }
	
	    public virtual bool HasComplete(CompletionPart part)
	    {
	        // must be overridden by source symbols, no-op for other symbols
	        Debug.Assert(!this.RequiresCompletion);
	        return true;
	    }
	
	    protected static void ForceCompleteChildByLocation(CompletionPart part, SourceLocation locationOpt, Symbol child, CancellationToken cancellationToken)
	    {
	        if (locationOpt == null || child.IsDefinedInSourceTree(locationOpt.SourceTree, locationOpt?.SourceSpan, cancellationToken))
	        {
	            cancellationToken.ThrowIfCancellationRequested();
	            child.ForceComplete(part, locationOpt, cancellationToken);
	        }
	    }
	
	    /// <summary>
	    /// Helper for implementing <see cref="DeclaringSyntaxReferences"/> for derived classes that store a location but not a 
	    /// <see cref="LanguageSyntaxNode"/> or <see cref="SyntaxReference"/>.
	    /// </summary>
	    protected static ImmutableArray<SyntaxReference> GetDeclaringSyntaxReferenceHelper<TNode>(ImmutableArray<Location> locations)
	        where TNode : LanguageSyntaxNode
	    {
	        if (locations.IsEmpty)
	        {
	            return ImmutableArray<SyntaxReference>.Empty;
	        }
	
	        ArrayBuilder<SyntaxReference> builder = ArrayBuilder<SyntaxReference>.GetInstance();
	        foreach (Location location in locations)
	        {
	            // Location may be null. See https://github.com/dotnet/roslyn/issues/28862.
	            if (location == null)
	            {
	                continue;
	            }
	            if (location.IsInSource)
	            {
	                SyntaxToken token = (SyntaxToken)location.SourceTree.GetRoot().FindToken(location.SourceSpan.Start);
	                if (token.GetKind() != SyntaxKind.None)
	                {
	                    LanguageSyntaxNode node = token.Parent.FirstAncestorOrSelf<TNode>();
	                    if (node != null)
	                        builder.Add(node.GetReference());
	                }
	            }
	        }
	
	        return builder.ToImmutableAndFree();
	    }
	
	    public virtual bool IsDefinedInSourceTree(SyntaxTree tree, TextSpan? definedWithinSpan, CancellationToken cancellationToken = default(CancellationToken))
	    {
	        var declaringReferences = this.DeclaringSyntaxReferences;
	        var container = this.ContainingSymbol;
	        if (this.IsImplicitlyDeclared && declaringReferences.Length == 0 && container != null)
	        {
	            return container.IsDefinedInSourceTree(tree, definedWithinSpan, cancellationToken);
	        }
	
	        foreach (var syntaxRef in declaringReferences)
	        {
	            cancellationToken.ThrowIfCancellationRequested();
	            if (syntaxRef.SyntaxTree == tree &&
	                (!definedWithinSpan.HasValue || syntaxRef.Span.IntersectsWith(definedWithinSpan.Value)))
	            {
	                return true;
	            }
	        }
	
	        return false;
	    }
	
	    public abstract void Accept(SymbolVisitor visitor);
	
	    public abstract TResult Accept<TResult>(SymbolVisitor<TResult> visitor);
	
	    public abstract TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument);
	}
	
	public abstract partial class AssemblySymbol : Symbol, IAssemblySymbol
	{
		private ImmutableArray<AttributeData> _attributesLazy;
	
	    public sealed override LanguageSymbolKind Kind => LanguageSymbolKind.Assembly;
	
		public override string Name { get; }
		internal abstract AssemblySymbol CorLibrary { get; }
		public abstract AssemblyIdentity Identity { get; }
		public abstract Version AssemblyVersionPattern { get; }
		public abstract NamespaceSymbol GlobalNamespace { get; }
		public abstract ImmutableArray<ModuleSymbol> Modules { get; }
		public abstract bool IsMissing { get; }
		public abstract bool IsLinked { get; }
		public virtual bool IsInteractive => false;
		public abstract ImmutableArray<DeclaredSymbol> DeclaredSpecialSymbols { get; }
		public abstract ICollection<string> TypeNames { get; }
		public abstract ICollection<string> NamespaceNames { get; }
		public sealed override Symbol ContainingSymbol => null;
		public sealed override AssemblySymbol ContainingAssembly => null;
		public ImmutableArray<DeclaredSymbol> SpecialSymbols => DeclaredSpecialSymbols;
		public static TypeSymbol DynamicType => DynamicTypeSymbol.Instance;
	
		internal abstract void SetCorLibrary(AssemblySymbol corLibrary);
		public abstract DeclaredSymbol GetDeclaredSpecialSymbol(object key);
	
		public ImmutableArray<AttributeData> Attributes 
		{
			get
			{
				if (_attributesLazy == default) ForceComplete(CompletionPart.Attributes);
				return _attributesLazy;
			}
		}
	
	    private CompletionState _state;
	
		public sealed override bool RequiresCompletion => true;
	
	    private CompletionState CompletionState
	    {
	        get
	        {
	            if (_state == null) Interlocked.CompareExchange(ref _state, CompletionState.Create(this.Language), null);
	            return _state;
	        }
	    }
	
	    public override void ForceComplete(CompletionPart part = null, SourceLocation locationOpt = null, CancellationToken cancellationToken = default)
	    {
	        if (part == null) part = CompletionPart.All;
	        while (true)
	        {
	            if (HasComplete(part)) goto done;
	            cancellationToken.ThrowIfCancellationRequested();
	            var incompletePart = CompletionState.NextIncompletePart;
	            if (incompletePart == CompletionPart.Attributes)
	            {
	                CompleteAttributes(cancellationToken);
	            }
	            else
	            if (incompletePart == CompletionPart.StartAttributeChecks || incompletePart == CompletionPart.FinishAttributeChecks)
	            {
	                if (CompletionState.NotePartComplete(CompletionPart.StartAttributeChecks))
	                {
	                    CompleteAttributeChecks(cancellationToken);
	                    var thisThreadCompleted = CompletionState.NotePartComplete(CompletionPart.FinishAttributeChecks);
	                    Debug.Assert(thisThreadCompleted);
	                }
	            }
	            else
	            if (incompletePart == CompletionPart.Module)
	            {
	                CompleteModule(cancellationToken);
	            }
	            else
	            if (incompletePart == CompletionPart.StartValidatingAddedModules || incompletePart == CompletionPart.FinishValidatingAddedModules)
	            {
	                if (CompletionState.NotePartComplete(CompletionPart.StartValidatingAddedModules))
	                {
	                    CompleteValidatingAddedModules(cancellationToken);
	                    var thisThreadCompleted = CompletionState.NotePartComplete(CompletionPart.FinishValidatingAddedModules);
	                    Debug.Assert(thisThreadCompleted);
	                }
	            }
	            else
	            if (incompletePart == null)
	            {
	                goto done;
	            }
	            else
	            {
	                // This assert will trigger if we forgot to handle any of the completion parts
	                Debug.Assert(!CompletionPart.AssemblySymbolAll.Contains(incompletePart));
	                // any other values are completion parts intended for other kinds of symbols
	                CompletionState.NotePartComplete(incompletePart);
	            }
	            CompletionState.SpinWaitComplete(incompletePart, cancellationToken);
	        }
	
	    done:
	        // Don't return until we've seen all of the CompletionParts. This ensures all
	        // diagnostics have been reported (not necessarily on this thread).
	        CompletionState.SpinWaitComplete(part, cancellationToken);
	    }
	
	    public override bool HasComplete(CompletionPart part)
	    {
	        return CompletionState.HasComplete(part);
	    }
	
	    protected virtual void CompleteAttributes(CancellationToken cancellationToken)
	    {
	        ComputePhaseAttributes(cancellationToken);
	        Debug.Assert(_attributesLazy != default);
	    }
	
	    protected abstract void ComputePhaseAttributes(CancellationToken cancellationToken);
	
	    protected virtual void CompleteAttributeChecks(CancellationToken cancellationToken)
	    {
	        ComputePhaseAttributeChecks(cancellationToken);
	    }
	
	    protected abstract void ComputePhaseAttributeChecks(CancellationToken cancellationToken);
	
	    protected virtual void CompleteModule(CancellationToken cancellationToken)
	    {
	        ComputePhaseModule(cancellationToken);
	    }
	
	    protected abstract void ComputePhaseModule(CancellationToken cancellationToken);
	
	    protected virtual void CompleteValidatingAddedModules(CancellationToken cancellationToken)
	    {
	        ComputePhaseValidatingAddedModules(cancellationToken);
	    }
	
	    protected abstract void ComputePhaseValidatingAddedModules(CancellationToken cancellationToken);
	
	    public override void Accept(SymbolVisitor visitor)
	    {
	        visitor.VisitAssembly(this);
	    }
	
	    public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
	    {
	        return visitor.VisitAssembly(this);
	    }
	
	    public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
	    {
	        return visitor.VisitAssembly(this, argument);
	    }
	}
	
	public partial class MetaAssemblySymbol : AssemblySymbol
	{
	}
	
	public partial class SourceAssemblySymbol : MetaAssemblySymbol
	{
	}
	
	public abstract partial class ModuleSymbol : Symbol, IModuleSymbol
	{
		private ImmutableArray<AttributeData> _attributesLazy;
	
	    public sealed override LanguageSymbolKind Kind => LanguageSymbolKind.Module;
	
		public abstract int Ordinal { get; }
		public abstract Machine Machine { get; }
		public abstract bool Bit32Required { get; }
		public abstract bool IsMissing { get; }
		public abstract ImmutableArray<AssemblyIdentity> ReferencedAssemblies { get; }
		public abstract ImmutableArray<AssemblySymbol> ReferencedAssemblySymbols { get; }
		public abstract bool HasUnifiedReferences { get; }
		public abstract ICollection<string> TypeNames { get; }
		public abstract ICollection<string> NamespaceNames { get; }
		public abstract NamespaceSymbol GlobalNamespace { get; }
		public sealed override AssemblySymbol ContainingAssembly => (AssemblySymbol)ContainingSymbol;
		public sealed override ModuleSymbol ContainingModule => null;
		public sealed override ObsoleteAttributeData ObsoleteAttributeData => null;
	
		public abstract ModuleMetadata GetMetadata();
	
		public ImmutableArray<AttributeData> Attributes 
		{
			get
			{
				if (_attributesLazy == default) ForceComplete(CompletionPart.Attributes);
				return _attributesLazy;
			}
		}
	
	    private CompletionState _state;
	
		public sealed override bool RequiresCompletion => true;
	
	    private CompletionState CompletionState
	    {
	        get
	        {
	            if (_state == null) Interlocked.CompareExchange(ref _state, CompletionState.Create(this.Language), null);
	            return _state;
	        }
	    }
	
	    public override void ForceComplete(CompletionPart part = null, SourceLocation locationOpt = null, CancellationToken cancellationToken = default)
	    {
	        if (part == null) part = CompletionPart.All;
	        while (true)
	        {
	            if (HasComplete(part)) goto done;
	            cancellationToken.ThrowIfCancellationRequested();
	            var incompletePart = CompletionState.NextIncompletePart;
	            if (incompletePart == CompletionPart.Attributes)
	            {
	                CompleteAttributes(cancellationToken);
	            }
	            else
	            if (incompletePart == CompletionPart.StartValidatingReferencedAssemblies || incompletePart == CompletionPart.FinishValidatingReferencedAssemblies)
	            {
	                if (CompletionState.NotePartComplete(CompletionPart.StartValidatingReferencedAssemblies))
	                {
	                    CompleteValidatingReferencedAssemblies(cancellationToken);
	                    var thisThreadCompleted = CompletionState.NotePartComplete(CompletionPart.FinishValidatingReferencedAssemblies);
	                    Debug.Assert(thisThreadCompleted);
	                }
	            }
	            else
	            if (incompletePart == CompletionPart.MembersCompleted)
	            {
	                CompleteMembersCompleted(cancellationToken);
	                var children = ArrayBuilder<Symbol>.GetInstance();
	                
	                bool allCompleted = true;
	                
	                if (this.DeclaringCompilation.Options.ConcurrentBuild)
	                {
	                    var po = cancellationToken.CanBeCanceled
	                        ? new ParallelOptions() { CancellationToken = cancellationToken }
	                        : LanguageCompilation.DefaultParallelOptions;
	                
	                    Parallel.For(0, children.Count, po, UICultureUtilities.WithCurrentUICulture<int>(i =>
	                    {
	                        var child = children[i];
	                        ForceCompleteChildByLocation(CompletionPart.All, locationOpt, child, cancellationToken);
	                    }));
	                
	                    foreach (var child in children)
	                    {
	                        if (!child.HasComplete(CompletionPart.All))
	                        {
	                            allCompleted = false;
	                            break;
	                        }
	                    }
	                }
	                else
	                {
	                    foreach (var child in children)
	                    {
	                        ForceCompleteChildByLocation(CompletionPart.All, locationOpt, child, cancellationToken);
	                        allCompleted = allCompleted && child.HasComplete(CompletionPart.All);
	                    }
	                }
	                
	                if (allCompleted)
	                {
	                    CompletionState.NotePartComplete(CompletionPart.MembersCompleted);
	                }
	                else
	                {
	                    // NOTE: we're going to kick out of the completion part loop after this,
	                    // so not making progress isn't a problem.
	                    goto done;
	                }
	            }
	            else
	            if (incompletePart == null)
	            {
	                goto done;
	            }
	            else
	            {
	                // This assert will trigger if we forgot to handle any of the completion parts
	                Debug.Assert(!CompletionPart.ModuleSymbolAll.Contains(incompletePart));
	                // any other values are completion parts intended for other kinds of symbols
	                CompletionState.NotePartComplete(incompletePart);
	            }
	            CompletionState.SpinWaitComplete(incompletePart, cancellationToken);
	        }
	
	    done:
	        // Don't return until we've seen all of the CompletionParts. This ensures all
	        // diagnostics have been reported (not necessarily on this thread).
	        CompletionState.SpinWaitComplete(part, cancellationToken);
	    }
	
	    public override bool HasComplete(CompletionPart part)
	    {
	        return CompletionState.HasComplete(part);
	    }
	
	    protected virtual void CompleteAttributes(CancellationToken cancellationToken)
	    {
	        ComputePhaseAttributes(cancellationToken);
	        Debug.Assert(_attributesLazy != default);
	    }
	
	    protected abstract void ComputePhaseAttributes(CancellationToken cancellationToken);
	
	    protected virtual void CompleteValidatingReferencedAssemblies(CancellationToken cancellationToken)
	    {
	        ComputePhaseValidatingReferencedAssemblies(cancellationToken);
	    }
	
	    protected abstract void ComputePhaseValidatingReferencedAssemblies(CancellationToken cancellationToken);
	
	    protected virtual void CompleteMembersCompleted(CancellationToken cancellationToken)
	    {
	        ComputePhaseMembersCompleted(cancellationToken);
	    }
	
	    protected abstract void ComputePhaseMembersCompleted(CancellationToken cancellationToken);
	
	    public override void Accept(SymbolVisitor visitor)
	    {
	        visitor.VisitModule(this);
	    }
	
	    public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
	    {
	        return visitor.VisitModule(this);
	    }
	
	    public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
	    {
	        return visitor.VisitModule(this, argument);
	    }
	}
	
	public partial class MetaModuleSymbol : ModuleSymbol
	{
	}
	
	public partial class SourceModuleSymbol : MetaModuleSymbol
	{
	}
	
	public abstract partial class DeclaredSymbol : Symbol, IDeclaredSymbol
	{
		private ImmutableArray<AttributeData> _attributesLazy;
		private ImmutableDictionary<string, ImmutableArray<DeclaredSymbol>> _membersByNameLazy;
		private ImmutableArray<DeclaredSymbol> _membersLazy;
		private ImmutableArray<NamedTypeSymbol> _typeMembersLazy;
	
	
		public abstract bool IsStatic { get; }
		public virtual bool IsVirtual => false;
		public virtual bool IsOverride => false;
		public virtual bool IsAbstract => false;
		public virtual bool IsSealed => false;
		public virtual bool IsExtern => false;
		public abstract MergedDeclaration MergedDeclaration { get; }
		public virtual DeclaredSymbol ConstructedFrom => this;
		public virtual Accessibility DeclaredAccessibility => Accessibility.Public;
	
	
		public ImmutableArray<AttributeData> Attributes 
		{
			get
			{
				if (_attributesLazy == default) ForceComplete(CompletionPart.Attributes);
				return _attributesLazy;
			}
		}
		protected ImmutableDictionary<string, ImmutableArray<DeclaredSymbol>> MembersByName 
		{
			get
			{
				if (_membersByNameLazy == default) ForceComplete(CompletionPart.Members);
				return _membersByNameLazy;
			}
		}
		public ImmutableArray<DeclaredSymbol> Members 
		{
			get
			{
				if (_membersLazy == default) ForceComplete(CompletionPart.MembersCompleted);
				return _membersLazy;
			}
		}
		public ImmutableArray<NamedTypeSymbol> TypeMembers 
		{
			get
			{
				if (_typeMembersLazy == default) ForceComplete(CompletionPart.MembersCompleted);
				return _typeMembersLazy;
			}
		}
	
	    private CompletionState _state;
	
		public sealed override bool RequiresCompletion => true;
	
	    private CompletionState CompletionState
	    {
	        get
	        {
	            if (_state == null) Interlocked.CompareExchange(ref _state, CompletionState.Create(this.Language), null);
	            return _state;
	        }
	    }
	
	    public override void ForceComplete(CompletionPart part = null, SourceLocation locationOpt = null, CancellationToken cancellationToken = default)
	    {
	        if (part == null) part = CompletionPart.All;
	        while (true)
	        {
	            if (HasComplete(part)) goto done;
	            cancellationToken.ThrowIfCancellationRequested();
	            var incompletePart = CompletionState.NextIncompletePart;
	            if (incompletePart == CompletionPart.Attributes)
	            {
	                CompleteAttributes(cancellationToken);
	            }
	            else
	            if (incompletePart == CompletionPart.Members)
	            {
	                CompleteMembers(cancellationToken);
	            }
	            else
	            if (incompletePart == CompletionPart.MembersCompleted)
	            {
	                CompleteMembersCompleted(cancellationToken);
	                var children = ArrayBuilder<Symbol>.GetInstance();
	                children.AddRange(Members);
	                children.AddRange(TypeMembers);
	                
	                bool allCompleted = true;
	                
	                if (this.DeclaringCompilation.Options.ConcurrentBuild)
	                {
	                    var po = cancellationToken.CanBeCanceled
	                        ? new ParallelOptions() { CancellationToken = cancellationToken }
	                        : LanguageCompilation.DefaultParallelOptions;
	                
	                    Parallel.For(0, children.Count, po, UICultureUtilities.WithCurrentUICulture<int>(i =>
	                    {
	                        var child = children[i];
	                        ForceCompleteChildByLocation(CompletionPart.All, locationOpt, child, cancellationToken);
	                    }));
	                
	                    foreach (var child in children)
	                    {
	                        if (!child.HasComplete(CompletionPart.All))
	                        {
	                            allCompleted = false;
	                            break;
	                        }
	                    }
	                }
	                else
	                {
	                    foreach (var child in children)
	                    {
	                        ForceCompleteChildByLocation(CompletionPart.All, locationOpt, child, cancellationToken);
	                        allCompleted = allCompleted && child.HasComplete(CompletionPart.All);
	                    }
	                }
	                
	                if (allCompleted)
	                {
	                    CompletionState.NotePartComplete(CompletionPart.MembersCompleted);
	                }
	                else
	                {
	                    // NOTE: we're going to kick out of the completion part loop after this,
	                    // so not making progress isn't a problem.
	                    goto done;
	                }
	            }
	            else
	            if (incompletePart == null)
	            {
	                goto done;
	            }
	            else
	            {
	                // This assert will trigger if we forgot to handle any of the completion parts
	                Debug.Assert(!CompletionPart.DeclaredSymbolAll.Contains(incompletePart));
	                // any other values are completion parts intended for other kinds of symbols
	                CompletionState.NotePartComplete(incompletePart);
	            }
	            CompletionState.SpinWaitComplete(incompletePart, cancellationToken);
	        }
	
	    done:
	        // Don't return until we've seen all of the CompletionParts. This ensures all
	        // diagnostics have been reported (not necessarily on this thread).
	        CompletionState.SpinWaitComplete(part, cancellationToken);
	    }
	
	    public override bool HasComplete(CompletionPart part)
	    {
	        return CompletionState.HasComplete(part);
	    }
	
	    protected virtual void CompleteAttributes(CancellationToken cancellationToken)
	    {
	        ComputePhaseAttributes(cancellationToken);
	        Debug.Assert(_attributesLazy != default);
	    }
	
	    protected abstract void ComputePhaseAttributes(CancellationToken cancellationToken);
	
	    protected virtual void CompleteMembers(CancellationToken cancellationToken)
	    {
	        ComputePhaseMembers(cancellationToken);
	        Debug.Assert(_membersByNameLazy != default);
	    }
	
	    protected abstract void ComputePhaseMembers(CancellationToken cancellationToken);
	
	    protected virtual void CompleteMembersCompleted(CancellationToken cancellationToken)
	    {
	        ComputePhaseMembersCompleted(cancellationToken);
	        Debug.Assert(_membersLazy != default);
	        Debug.Assert(_typeMembersLazy != default);
	    }
	
	    protected abstract void ComputePhaseMembersCompleted(CancellationToken cancellationToken);
	}
	
	public abstract partial class NamespaceOrTypeSymbol : DeclaredSymbol, INamespaceOrTypeSymbol
	{
	
	
	
	
	
	}
	
	public abstract partial class NamespaceSymbol : NamespaceOrTypeSymbol, INamespaceSymbol
	{
	
	    public sealed override LanguageSymbolKind Kind => LanguageSymbolKind.Namespace;
	
		public abstract NamespaceExtent Extent { get; }
		public override bool IsImplicitlyDeclared => this.IsGlobalNamespace;
		public override Accessibility DeclaredAccessibility => Accessibility.Public;
		public override bool IsStatic => true;
	
	
	
	
	    public override void Accept(SymbolVisitor visitor)
	    {
	        visitor.VisitNamespace(this);
	    }
	
	    public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamespace(this);
	    }
	
	    public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
	    {
	        return visitor.VisitNamespace(this, argument);
	    }
	}
	
	public abstract partial class TypeSymbol : NamespaceOrTypeSymbol, ITypeSymbol
	{
	
	
		public virtual bool IsReferenceType => false;
		public virtual bool IsValueType => false;
		public virtual bool IsAnonymousType => false;
		public virtual bool IsTupleType => false;
		public virtual bool IsRefLikeType => false;
		public virtual bool IsUnmanagedType => false;
		public virtual bool IsReadOnly => false;
		public new TypeSymbol OriginalDefinition => OriginalTypeSymbolDefinition;
		protected virtual TypeSymbol OriginalTypeSymbolDefinition => this;
		protected sealed override DeclaredSymbol OriginalSymbolDefinition => OriginalTypeSymbolDefinition;
	
	
	
	}
	
	public abstract partial class NamedTypeSymbol : NamespaceOrTypeSymbol, INamedTypeSymbol
	{
	
	    public sealed override LanguageSymbolKind Kind => LanguageSymbolKind.NamedType;
	
		public virtual int Arity => 0;
		public abstract IEnumerable<string> MemberNames { get; }
	
		public abstract ImmutableArray<NamedTypeSymbol> GetDeclaredBaseTypes(ConsList<TypeSymbol> basesBeingResolved);
		public override abstract ImmutableArray<DeclaredSymbol> GetMembers();
		public override abstract ImmutableArray<DeclaredSymbol> GetMembers(string name);
		public override abstract ImmutableArray<DeclaredSymbol> GetMembers(string name, string metadataName);
		public override abstract ImmutableArray<NamedTypeSymbol> GetTypeMembers();
		public override abstract ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name);
		public override abstract ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName);
	
	
	    private CompletionState _state;
	
		public sealed override bool RequiresCompletion => true;
	
	    private CompletionState CompletionState
	    {
	        get
	        {
	            if (_state == null) Interlocked.CompareExchange(ref _state, CompletionState.Create(this.Language), null);
	            return _state;
	        }
	    }
	
	    public override void ForceComplete(CompletionPart part = null, SourceLocation locationOpt = null, CancellationToken cancellationToken = default)
	    {
	        if (part == null) part = CompletionPart.All;
	        while (true)
	        {
	            if (HasComplete(part)) goto done;
	            cancellationToken.ThrowIfCancellationRequested();
	            var incompletePart = CompletionState.NextIncompletePart;
	            if (incompletePart == CompletionPart.Attributes)
	            {
	                CompleteAttributes(cancellationToken);
	            }
	            else
	            if (incompletePart == CompletionPart.Members)
	            {
	                CompleteMembers(cancellationToken);
	            }
	            else
	            if (incompletePart == CompletionPart.MembersCompleted)
	            {
	                CompleteMembersCompleted(cancellationToken);
	                var children = ArrayBuilder<Symbol>.GetInstance();
	                children.AddRange(Members);
	                children.AddRange(TypeMembers);
	                
	                bool allCompleted = true;
	                
	                if (this.DeclaringCompilation.Options.ConcurrentBuild)
	                {
	                    var po = cancellationToken.CanBeCanceled
	                        ? new ParallelOptions() { CancellationToken = cancellationToken }
	                        : LanguageCompilation.DefaultParallelOptions;
	                
	                    Parallel.For(0, children.Count, po, UICultureUtilities.WithCurrentUICulture<int>(i =>
	                    {
	                        var child = children[i];
	                        ForceCompleteChildByLocation(CompletionPart.All, locationOpt, child, cancellationToken);
	                    }));
	                
	                    foreach (var child in children)
	                    {
	                        if (!child.HasComplete(CompletionPart.All))
	                        {
	                            allCompleted = false;
	                            break;
	                        }
	                    }
	                }
	                else
	                {
	                    foreach (var child in children)
	                    {
	                        ForceCompleteChildByLocation(CompletionPart.All, locationOpt, child, cancellationToken);
	                        allCompleted = allCompleted && child.HasComplete(CompletionPart.All);
	                    }
	                }
	                
	                if (allCompleted)
	                {
	                    CompletionState.NotePartComplete(CompletionPart.MembersCompleted);
	                }
	                else
	                {
	                    // NOTE: we're going to kick out of the completion part loop after this,
	                    // so not making progress isn't a problem.
	                    goto done;
	                }
	            }
	            else
	            if (incompletePart == CompletionPart.StartBaseTypes || incompletePart == CompletionPart.FinishBaseTypes)
	            {
	                if (CompletionState.NotePartComplete(CompletionPart.StartBaseTypes))
	                {
	                    CompleteBaseTypes(cancellationToken);
	                    var thisThreadCompleted = CompletionState.NotePartComplete(CompletionPart.FinishBaseTypes);
	                    Debug.Assert(thisThreadCompleted);
	                }
	            }
	            else
	            if (incompletePart == null)
	            {
	                goto done;
	            }
	            else
	            {
	                // This assert will trigger if we forgot to handle any of the completion parts
	                Debug.Assert(!CompletionPart.NamedTypeSymbolAll.Contains(incompletePart));
	                // any other values are completion parts intended for other kinds of symbols
	                CompletionState.NotePartComplete(incompletePart);
	            }
	            CompletionState.SpinWaitComplete(incompletePart, cancellationToken);
	        }
	
	    done:
	        // Don't return until we've seen all of the CompletionParts. This ensures all
	        // diagnostics have been reported (not necessarily on this thread).
	        CompletionState.SpinWaitComplete(part, cancellationToken);
	    }
	
	    public override bool HasComplete(CompletionPart part)
	    {
	        return CompletionState.HasComplete(part);
	    }
	
	    protected virtual void CompleteBaseTypes(CancellationToken cancellationToken)
	    {
	        ComputePhaseBaseTypes(cancellationToken);
	    }
	
	    protected abstract void ComputePhaseBaseTypes(CancellationToken cancellationToken);
	
	    public override void Accept(SymbolVisitor visitor)
	    {
	        visitor.VisitNamedType(this);
	    }
	
	    public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
	    {
	        return visitor.VisitNamedType(this);
	    }
	
	    public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
	    {
	        return visitor.VisitNamedType(this, argument);
	    }
	}
	
	public abstract partial class MemberSymbol : DeclaredSymbol, IMemberSymbol
	{
	
	
	
	
	
	}
	
	public abstract partial class FieldSymbol : MemberSymbol, IFieldSymbol
	{
	
	    public sealed override LanguageSymbolKind Kind => LanguageSymbolKind.Field;
	
	
	
	
	
	    public override void Accept(SymbolVisitor visitor)
	    {
	        visitor.VisitField(this);
	    }
	
	    public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
	    {
	        return visitor.VisitField(this);
	    }
	
	    public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
	    {
	        return visitor.VisitField(this, argument);
	    }
	}
	
	public partial class MetaFieldSymbol : FieldSymbol
	{
	}
	
	public partial class SourceFieldSymbol : MetaFieldSymbol
	{
	}
	
	public abstract partial class PropertySymbol : MemberSymbol, IPropertySymbol
	{
	
	    public sealed override LanguageSymbolKind Kind => LanguageSymbolKind.Property;
	
	
	
	
	
	    public override void Accept(SymbolVisitor visitor)
	    {
	        visitor.VisitProperty(this);
	    }
	
	    public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
	    {
	        return visitor.VisitProperty(this);
	    }
	
	    public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
	    {
	        return visitor.VisitProperty(this, argument);
	    }
	}
	
	public partial class MetaPropertySymbol : PropertySymbol
	{
	}
	
	public partial class SourcePropertySymbol : MetaPropertySymbol
	{
	}
	
	public abstract partial class MethodSymbol : MemberSymbol, IMethodSymbol
	{
	
	    public sealed override LanguageSymbolKind Kind => LanguageSymbolKind.Method;
	
	
	
	
	
	    public override void Accept(SymbolVisitor visitor)
	    {
	        visitor.VisitMethod(this);
	    }
	
	    public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
	    {
	        return visitor.VisitMethod(this);
	    }
	
	    public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
	    {
	        return visitor.VisitMethod(this, argument);
	    }
	}
	
	public partial class MetaMethodSymbol : MethodSymbol
	{
	}
	
	public partial class SourceMethodSymbol : MetaMethodSymbol
	{
	}
	
}

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Virtual dispatch based on a symbol's particular class. 
    /// </summary>
    public class SymbolVisitor
    {
        /// <summary>
        /// Call the correct VisitXXX method in this class based on the particular type of symbol that is passed in.
        /// </summary>
        public virtual void Visit(Symbol symbol)
        {
            if ((object)symbol != null)
            {
                symbol.Accept(this);
            }
        }

        /// <summary>
        /// The default Visit method called when visiting any <see cref="Symbol" /> and 
        /// if visiting specific symbol method VisitXXX is not overridden
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        public virtual void DefaultVisit(Symbol symbol)
        {
        }

        /// <summary>
        /// Called when visiting an <see cref="AssemblySymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        public virtual void VisitAssembly(AssemblySymbol symbol)
        {
            DefaultVisit(symbol);
        }

        /// <summary>
        /// Called when visiting an <see cref="ModuleSymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        public virtual void VisitModule(ModuleSymbol symbol)
        {
            DefaultVisit(symbol);
        }

        /// <summary>
        /// Called when visiting an <see cref="NamespaceSymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        public virtual void VisitNamespace(NamespaceSymbol symbol)
        {
            DefaultVisit(symbol);
        }

        /// <summary>
        /// Called when visiting an <see cref="NamedTypeSymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        public virtual void VisitNamedType(NamedTypeSymbol symbol)
        {
            DefaultVisit(symbol);
        }

        /// <summary>
        /// Called when visiting an <see cref="FieldSymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        public virtual void VisitField(FieldSymbol symbol)
        {
            DefaultVisit(symbol);
        }

        /// <summary>
        /// Called when visiting an <see cref="PropertySymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        public virtual void VisitProperty(PropertySymbol symbol)
        {
            DefaultVisit(symbol);
        }

        /// <summary>
        /// Called when visiting an <see cref="MethodSymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        public virtual void VisitMethod(MethodSymbol symbol)
        {
            DefaultVisit(symbol);
        }
    }

    /// <summary>
    /// Virtual dispatch based on a symbol's particular class. 
    /// </summary>
    /// <typeparam name="TResult">Result type</typeparam>
    public class SymbolVisitor<TResult>
    {
        /// <summary>
        /// Call the correct VisitXXX method in this class based on the particular type of symbol that is passed in.
        /// Return default(TResult) if symbol is null
        /// </summary>
        public virtual TResult Visit(Symbol symbol)
        {
            return (object)symbol == null
                ? default(TResult)
                : symbol.Accept(this);
        }

        /// <summary>
        /// The default Visit method called when visiting any <see cref="Symbol" /> and 
        /// if visiting specific symbol method VisitXXX is not overridden
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <returns></returns>
        public virtual TResult DefaultVisit(Symbol symbol)
        {
            return default(TResult);
        }

        /// <summary>
        /// Called when visiting an <see cref="AssemblySymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <returns></returns>
        public virtual TResult VisitAssembly(AssemblySymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        /// <summary>
        /// Called when visiting an <see cref="ModuleSymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <returns></returns>
        public virtual TResult VisitModule(ModuleSymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        /// <summary>
        /// Called when visiting an <see cref="NamespaceSymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <returns></returns>
        public virtual TResult VisitNamespace(NamespaceSymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        /// <summary>
        /// Called when visiting an <see cref="NamedTypeSymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <returns></returns>
        public virtual TResult VisitNamedType(NamedTypeSymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        /// <summary>
        /// Called when visiting an <see cref="FieldSymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <returns></returns>
        public virtual TResult VisitField(FieldSymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        /// <summary>
        /// Called when visiting an <see cref="PropertySymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <returns></returns>
        public virtual TResult VisitProperty(PropertySymbol symbol)
        {
            return DefaultVisit(symbol);
        }

        /// <summary>
        /// Called when visiting an <see cref="MethodSymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <returns></returns>
        public virtual TResult VisitMethod(MethodSymbol symbol)
        {
            return DefaultVisit(symbol);
        }
    }

    /// <summary>
    /// Virtual dispatch based on a symbol's particular class. 
    /// </summary>
    /// <typeparam name="TArgument">Additional argument type</typeparam>
    /// <typeparam name="TResult">Result type</typeparam>
    public class SymbolVisitor<TArgument, TResult>
    {
        /// <summary>
        /// Call the correct VisitXXX method in this class based on the particular type of symbol that is passed in.
        /// Return default(TResult) if symbol is null
        /// </summary>
        public virtual TResult Visit(Symbol symbol, TArgument argument = default(TArgument))
        {
            if ((object)symbol == null)
            {
                return default(TResult);
            }
            return symbol.Accept(this, argument);
        }

        /// <summary>
        /// The default Visit method called when visiting any <see cref="Symbol" /> and 
        /// if visiting specific symbol method VisitXXX is not overridden
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <param name="argument">Additional argument</param>
        /// <returns></returns>
        public virtual TResult DefaultVisit(Symbol symbol, TArgument argument)
        {
            return default(TResult);
        }


        /// <summary>
        /// Called when visiting an <see cref="AssemblySymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <param name="argument">Additional argument</param>
        /// <returns></returns>
        public virtual TResult VisitAssembly(AssemblySymbol symbol, TArgument argument)
        {
            return DefaultVisit(symbol, argument);
        }

        /// <summary>
        /// Called when visiting an <see cref="ModuleSymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <param name="argument">Additional argument</param>
        /// <returns></returns>
        public virtual TResult VisitModule(ModuleSymbol symbol, TArgument argument)
        {
            return DefaultVisit(symbol, argument);
        }

        /// <summary>
        /// Called when visiting an <see cref="NamespaceSymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <param name="argument">Additional argument</param>
        /// <returns></returns>
        public virtual TResult VisitNamespace(NamespaceSymbol symbol, TArgument argument)
        {
            return DefaultVisit(symbol, argument);
        }

        /// <summary>
        /// Called when visiting an <see cref="NamedTypeSymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <param name="argument">Additional argument</param>
        /// <returns></returns>
        public virtual TResult VisitNamedType(NamedTypeSymbol symbol, TArgument argument)
        {
            return DefaultVisit(symbol, argument);
        }

        /// <summary>
        /// Called when visiting an <see cref="FieldSymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <param name="argument">Additional argument</param>
        /// <returns></returns>
        public virtual TResult VisitField(FieldSymbol symbol, TArgument argument)
        {
            return DefaultVisit(symbol, argument);
        }

        /// <summary>
        /// Called when visiting an <see cref="PropertySymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <param name="argument">Additional argument</param>
        /// <returns></returns>
        public virtual TResult VisitProperty(PropertySymbol symbol, TArgument argument)
        {
            return DefaultVisit(symbol, argument);
        }

        /// <summary>
        /// Called when visiting an <see cref="MethodSymbol" />; Override this method with
        /// specific implementation; Calling default <see cref="DefaultVisit" /> if it's not
        /// overridden 
        /// </summary>
        /// <param name="symbol">The visited symbol</param>
        /// <param name="argument">Additional argument</param>
        /// <returns></returns>
        public virtual TResult VisitMethod(MethodSymbol symbol, TArgument argument)
        {
            return DefaultVisit(symbol, argument);
        }
    }
}
