using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
    public enum MetaCollectionKind
    {
        Set,
        List,
    }
    
    public enum MetaPropertyKind
    {
        Normal,
        Readonly,
        Lazy,
        Derived,
        Containment,
        Synthetized,
        Inherited,
    }
    
    public enum MetaExpressionKind
    {
        None,
        Identifier,
        Literal,
        Bracket,
        TypeOf,
        TypeCast,
        MemberAccess,
        FunctionCall,
        Indexer,
        TypeIs,
        TypeAs,
        And,
        Or,
        ExclusiveOr,
        AndAlso,
        OrElse,
        Coalesce,
        Conditional,
        PostIncrementAssign,
        PostDecrementAssign,
        PreIncrementAssign,
        PreDecrementAssign,
        UnaryPlus,
        Negate,
        OnesComplement,
        Not,
        Multiply,
        Divide,
        Modulo,
        Add,
        Subtract,
        LeftShift,
        RightShift,
        LessThan,
        GreaterThan,
        LessThanOrEqual,
        GreaterThanOrEqual,
        Equal,
        NotEqual,
        Assign,
        MultiplyAssign,
        DivideAssign,
        ModuloAssign,
        AddAssign,
        SubtractAssign,
        LeftShiftAssign,
        RightShiftAssign,
        AndAssign,
        ExclusiveOrAssign,
        OrAssign,
    }
    
    public interface MetaScopeEntry
    {
        MetaScope Parent { get; set; }
    
    }
    
    internal class MetaScopeEntryImpl : ModelObject, MetaDslx.Core.MetaScopeEntry
    {
        public MetaScopeEntryImpl()
        {
            MetaModelImplementationProvider.Implementation.MetaScopeEntry_MetaScopeEntry(this);
            this.MMakeDefault();
        }
        
        [OppositeAttribute(typeof(MetaScopeImpl), "Entries")]
        internal static readonly ModelProperty ParentProperty =
            ModelProperty.Register("Parent", typeof(MetaScope), typeof(MetaScopeEntryImpl));
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
    }
    
    public interface MetaNamedElement : MetaDslx.Core.MetaScopeEntry
    {
        string Name { get; set; }
    
    }
    
    internal class MetaNamedElementImpl : ModelObject, MetaDslx.Core.MetaNamedElement
    {
        static MetaNamedElementImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaNamedElementImpl), typeof(MetaScopeEntryImpl));
        }
    
        public MetaNamedElementImpl()
        {
            MetaModelImplementationProvider.Implementation.MetaNamedElement_MetaNamedElement(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        internal static readonly ModelProperty NameProperty =
            ModelProperty.Register("Name", typeof(string), typeof(MetaNamedElementImpl));
        string MetaNamedElement.Name
        {
            get { return (string)this.MGetValue(MetaNamedElementImpl.NameProperty); }
            set { this.MSetValue(MetaNamedElementImpl.NameProperty, value); }
        }
    }
    
    public interface MetaTypedElement : MetaDslx.Core.MetaScopeEntry
    {
        MetaType Type { get; set; }
    
    }
    
    internal class MetaTypedElementImpl : ModelObject, MetaDslx.Core.MetaTypedElement
    {
        static MetaTypedElementImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaTypedElementImpl), typeof(MetaScopeEntryImpl));
        }
    
        public MetaTypedElementImpl()
        {
            MetaModelImplementationProvider.Implementation.MetaTypedElement_MetaTypedElement(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        internal static readonly ModelProperty TypeProperty =
            ModelProperty.Register("Type", typeof(MetaType), typeof(MetaTypedElementImpl));
        MetaType MetaTypedElement.Type
        {
            get { return (MetaType)this.MGetValue(MetaTypedElementImpl.TypeProperty); }
            set { this.MSetValue(MetaTypedElementImpl.TypeProperty, value); }
        }
    }
    
    public interface MetaType : MetaDslx.Core.MetaScopeEntry
    {
    
        bool IsAssignableFrom(MetaType valueType);
        bool Equals(MetaType otherType);
    }
    
    internal class MetaTypeImpl : ModelObject, MetaDslx.Core.MetaType
    {
        static MetaTypeImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaTypeImpl), typeof(MetaScopeEntryImpl));
        }
    
        public MetaTypeImpl()
        {
            MetaModelImplementationProvider.Implementation.MetaType_MetaType(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        bool MetaType.IsAssignableFrom(MetaType valueType)
        {
            return MetaModelImplementationProvider.Implementation.MetaType_IsAssignableFrom(this, valueType);
        }
        
        bool MetaType.Equals(MetaType otherType)
        {
            return MetaModelImplementationProvider.Implementation.MetaType_Equals(this, otherType);
        }
    }
    
    public interface MetaScope : MetaDslx.Core.MetaScopeEntry
    {
        IList<MetaScopeEntry> Entries { get; }
        IList<MetaScope> ImportedScopes { get; }
        IList<MetaScope> InheritedScopes { get; }
        IList<MetaScopeEntry> ImportedEntries { get; }
    
        IList<MetaScopeEntry> ResolveEntries(string name);
        IList<MetaScopeEntry> GetEntries(string name);
    }
    
    internal class MetaScopeImpl : ModelObject, MetaDslx.Core.MetaScope
    {
        static MetaScopeImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaScopeImpl), typeof(MetaScopeEntryImpl));
        }
    
        public MetaScopeImpl()
        {
            this.MSetValue(MetaScopeImpl.EntriesProperty, new ModelList<MetaScopeEntry>(this, MetaScopeImpl.EntriesProperty));
            this.MSetValue(MetaScopeImpl.ImportedScopesProperty, new ModelList<MetaScope>(this, MetaScopeImpl.ImportedScopesProperty));
            this.MSetValue(MetaScopeImpl.InheritedScopesProperty, new ModelList<MetaScope>(this, MetaScopeImpl.InheritedScopesProperty));
            this.MSetValue(MetaScopeImpl.ImportedEntriesProperty, new ModelList<MetaScopeEntry>(this, MetaScopeImpl.ImportedEntriesProperty));
            MetaModelImplementationProvider.Implementation.MetaScope_MetaScope(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        [ContainmentAttribute]
        [OppositeAttribute(typeof(MetaScopeEntryImpl), "Parent")]
        internal static readonly ModelProperty EntriesProperty =
            ModelProperty.Register("Entries", typeof(IList<MetaScopeEntry>), typeof(MetaScopeImpl));
        IList<MetaScopeEntry> MetaScope.Entries
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaScopeImpl.EntriesProperty); }
        }
        
        internal static readonly ModelProperty ImportedScopesProperty =
            ModelProperty.Register("ImportedScopes", typeof(IList<MetaScope>), typeof(MetaScopeImpl));
        IList<MetaScope> MetaScope.ImportedScopes
        {
            get { return (IList<MetaScope>)this.MGetValue(MetaScopeImpl.ImportedScopesProperty); }
        }
        
        internal static readonly ModelProperty InheritedScopesProperty =
            ModelProperty.Register("InheritedScopes", typeof(IList<MetaScope>), typeof(MetaScopeImpl));
        IList<MetaScope> MetaScope.InheritedScopes
        {
            get { return (IList<MetaScope>)this.MGetValue(MetaScopeImpl.InheritedScopesProperty); }
        }
        
        internal static readonly ModelProperty ImportedEntriesProperty =
            ModelProperty.Register("ImportedEntries", typeof(IList<MetaScopeEntry>), typeof(MetaScopeImpl));
        IList<MetaScopeEntry> MetaScope.ImportedEntries
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaScopeImpl.ImportedEntriesProperty); }
        }
        
        IList<MetaScopeEntry> MetaScope.ResolveEntries(string name)
        {
            return MetaModelImplementationProvider.Implementation.MetaScope_ResolveEntries(this, name);
        }
        
        IList<MetaScopeEntry> MetaScope.GetEntries(string name)
        {
            return MetaModelImplementationProvider.Implementation.MetaScope_GetEntries(this, name);
        }
    }
    
    public interface MetaNamespace : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaScope
    {
        new MetaNamespace Parent { get; set; }
        IList<MetaNamespace> Usings { get; }
        IList<MetaNamespace> Namespaces { get; }
        IList<MetaModel> Models { get; }
    
    }
    
    internal class MetaNamespaceImpl : ModelObject, MetaDslx.Core.MetaNamespace
    {
        static MetaNamespaceImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaNamespaceImpl), typeof(MetaScopeEntryImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaNamespaceImpl), typeof(MetaNamedElementImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaNamespaceImpl), typeof(MetaScopeImpl));
        }
    
        public MetaNamespaceImpl()
        {
            this.MSetValue(MetaScopeImpl.EntriesProperty, new ModelList<MetaScopeEntry>(this, MetaScopeImpl.EntriesProperty));
            this.MSetValue(MetaScopeImpl.ImportedScopesProperty, new ModelList<MetaScope>(this, MetaScopeImpl.ImportedScopesProperty));
            this.MSetValue(MetaScopeImpl.InheritedScopesProperty, new ModelList<MetaScope>(this, MetaScopeImpl.InheritedScopesProperty));
            this.MSetValue(MetaScopeImpl.ImportedEntriesProperty, new ModelList<MetaScopeEntry>(this, MetaScopeImpl.ImportedEntriesProperty));
            this.MSetValue(MetaNamespaceImpl.UsingsProperty, new ModelList<MetaNamespace>(this, MetaNamespaceImpl.UsingsProperty));
            this.MSetValue(MetaNamespaceImpl.NamespacesProperty, new ModelList<MetaNamespace>(this, MetaNamespaceImpl.NamespacesProperty));
            this.MSetValue(MetaNamespaceImpl.ModelsProperty, new ModelList<MetaModel>(this, MetaNamespaceImpl.ModelsProperty));
            MetaModelImplementationProvider.Implementation.MetaNamespace_MetaNamespace(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        string MetaNamedElement.Name
        {
            get { return (string)this.MGetValue(MetaNamedElementImpl.NameProperty); }
            set { this.MSetValue(MetaNamedElementImpl.NameProperty, value); }
        }
        
        IList<MetaScopeEntry> MetaScope.Entries
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaScopeImpl.EntriesProperty); }
        }
        
        IList<MetaScope> MetaScope.ImportedScopes
        {
            get { return (IList<MetaScope>)this.MGetValue(MetaScopeImpl.ImportedScopesProperty); }
        }
        
        IList<MetaScope> MetaScope.InheritedScopes
        {
            get { return (IList<MetaScope>)this.MGetValue(MetaScopeImpl.InheritedScopesProperty); }
        }
        
        IList<MetaScopeEntry> MetaScope.ImportedEntries
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaScopeImpl.ImportedEntriesProperty); }
        }
        
        [OppositeAttribute(typeof(MetaNamespaceImpl), "Namespaces")]
        [RedefinesAttribute(typeof(MetaScopeEntryImpl), "Parent")]
        internal static readonly ModelProperty ParentProperty =
            ModelProperty.Register("Parent", typeof(MetaNamespace), typeof(MetaNamespaceImpl));
        MetaNamespace MetaNamespace.Parent
        {
            get { return (MetaNamespace)this.MGetValue(MetaNamespaceImpl.ParentProperty); }
            set { this.MSetValue(MetaNamespaceImpl.ParentProperty, value); }
        }
        
        [RedefinesAttribute(typeof(MetaScopeImpl), "ImportedScopes")]
        internal static readonly ModelProperty UsingsProperty =
            ModelProperty.Register("Usings", typeof(IList<MetaNamespace>), typeof(MetaNamespaceImpl));
        IList<MetaNamespace> MetaNamespace.Usings
        {
            get { return (IList<MetaNamespace>)this.MGetValue(MetaNamespaceImpl.UsingsProperty); }
        }
        
        [OppositeAttribute(typeof(MetaNamespaceImpl), "Parent")]
        [SubsetsAttribute(typeof(MetaScopeImpl), "Entries")]
        internal static readonly ModelProperty NamespacesProperty =
            ModelProperty.Register("Namespaces", typeof(IList<MetaNamespace>), typeof(MetaNamespaceImpl));
        IList<MetaNamespace> MetaNamespace.Namespaces
        {
            get { return (IList<MetaNamespace>)this.MGetValue(MetaNamespaceImpl.NamespacesProperty); }
        }
        
        [OppositeAttribute(typeof(MetaModelImpl), "Namespace")]
        [SubsetsAttribute(typeof(MetaScopeImpl), "Entries")]
        internal static readonly ModelProperty ModelsProperty =
            ModelProperty.Register("Models", typeof(IList<MetaModel>), typeof(MetaNamespaceImpl));
        IList<MetaModel> MetaNamespace.Models
        {
            get { return (IList<MetaModel>)this.MGetValue(MetaNamespaceImpl.ModelsProperty); }
        }
        
        IList<MetaScopeEntry> MetaScope.ResolveEntries(string name)
        {
            return MetaModelImplementationProvider.Implementation.MetaScope_ResolveEntries(this, name);
        }
        
        IList<MetaScopeEntry> MetaScope.GetEntries(string name)
        {
            return MetaModelImplementationProvider.Implementation.MetaScope_GetEntries(this, name);
        }
    }
    
    public interface MetaModel : MetaDslx.Core.MetaType, MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaScope
    {
        string Uri { get; set; }
        string Prefix { get; set; }
        MetaNamespace Namespace { get; set; }
        IList<MetaType> Types { get; }
        IList<MetaProperty> Properties { get; }
        IList<MetaOperation> Operations { get; }
    
    }
    
    internal class MetaModelImpl : ModelObject, MetaDslx.Core.MetaModel
    {
        static MetaModelImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaModelImpl), typeof(MetaScopeEntryImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaModelImpl), typeof(MetaTypeImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaModelImpl), typeof(MetaNamedElementImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaModelImpl), typeof(MetaScopeImpl));
        }
    
        public MetaModelImpl()
        {
            this.MSetValue(MetaScopeImpl.EntriesProperty, new ModelList<MetaScopeEntry>(this, MetaScopeImpl.EntriesProperty));
            this.MSetValue(MetaScopeImpl.ImportedScopesProperty, new ModelList<MetaScope>(this, MetaScopeImpl.ImportedScopesProperty));
            this.MSetValue(MetaScopeImpl.InheritedScopesProperty, new ModelList<MetaScope>(this, MetaScopeImpl.InheritedScopesProperty));
            this.MSetValue(MetaScopeImpl.ImportedEntriesProperty, new ModelList<MetaScopeEntry>(this, MetaScopeImpl.ImportedEntriesProperty));
            this.MSetValue(MetaModelImpl.TypesProperty, new ModelList<MetaType>(this, MetaModelImpl.TypesProperty));
            this.MSetValue(MetaModelImpl.PropertiesProperty, new ModelList<MetaProperty>(this, MetaModelImpl.PropertiesProperty));
            this.MSetValue(MetaModelImpl.OperationsProperty, new ModelList<MetaOperation>(this, MetaModelImpl.OperationsProperty));
            MetaModelImplementationProvider.Implementation.MetaModel_MetaModel(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        string MetaNamedElement.Name
        {
            get { return (string)this.MGetValue(MetaNamedElementImpl.NameProperty); }
            set { this.MSetValue(MetaNamedElementImpl.NameProperty, value); }
        }
        
        IList<MetaScopeEntry> MetaScope.Entries
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaScopeImpl.EntriesProperty); }
        }
        
        IList<MetaScope> MetaScope.ImportedScopes
        {
            get { return (IList<MetaScope>)this.MGetValue(MetaScopeImpl.ImportedScopesProperty); }
        }
        
        IList<MetaScope> MetaScope.InheritedScopes
        {
            get { return (IList<MetaScope>)this.MGetValue(MetaScopeImpl.InheritedScopesProperty); }
        }
        
        IList<MetaScopeEntry> MetaScope.ImportedEntries
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaScopeImpl.ImportedEntriesProperty); }
        }
        
        internal static readonly ModelProperty UriProperty =
            ModelProperty.Register("Uri", typeof(string), typeof(MetaModelImpl));
        string MetaModel.Uri
        {
            get { return (string)this.MGetValue(MetaModelImpl.UriProperty); }
            set { this.MSetValue(MetaModelImpl.UriProperty, value); }
        }
        
        internal static readonly ModelProperty PrefixProperty =
            ModelProperty.Register("Prefix", typeof(string), typeof(MetaModelImpl));
        string MetaModel.Prefix
        {
            get { return (string)this.MGetValue(MetaModelImpl.PrefixProperty); }
            set { this.MSetValue(MetaModelImpl.PrefixProperty, value); }
        }
        
        [OppositeAttribute(typeof(MetaNamespaceImpl), "Models")]
        [RedefinesAttribute(typeof(MetaScopeEntryImpl), "Parent")]
        internal static readonly ModelProperty NamespaceProperty =
            ModelProperty.Register("Namespace", typeof(MetaNamespace), typeof(MetaModelImpl));
        MetaNamespace MetaModel.Namespace
        {
            get { return (MetaNamespace)this.MGetValue(MetaModelImpl.NamespaceProperty); }
            set { this.MSetValue(MetaModelImpl.NamespaceProperty, value); }
        }
        
        [OppositeAttribute(typeof(MetaDeclarationImpl), "Model")]
        [SubsetsAttribute(typeof(MetaScopeImpl), "Entries")]
        internal static readonly ModelProperty TypesProperty =
            ModelProperty.Register("Types", typeof(IList<MetaType>), typeof(MetaModelImpl));
        IList<MetaType> MetaModel.Types
        {
            get { return (IList<MetaType>)this.MGetValue(MetaModelImpl.TypesProperty); }
        }
        
        [SubsetsAttribute(typeof(MetaScopeImpl), "Entries")]
        internal static readonly ModelProperty PropertiesProperty =
            ModelProperty.Register("Properties", typeof(IList<MetaProperty>), typeof(MetaModelImpl));
        IList<MetaProperty> MetaModel.Properties
        {
            get { return (IList<MetaProperty>)this.MGetValue(MetaModelImpl.PropertiesProperty); }
        }
        
        [SubsetsAttribute(typeof(MetaScopeImpl), "Entries")]
        internal static readonly ModelProperty OperationsProperty =
            ModelProperty.Register("Operations", typeof(IList<MetaOperation>), typeof(MetaModelImpl));
        IList<MetaOperation> MetaModel.Operations
        {
            get { return (IList<MetaOperation>)this.MGetValue(MetaModelImpl.OperationsProperty); }
        }
        
        bool MetaType.IsAssignableFrom(MetaType valueType)
        {
            return MetaModelImplementationProvider.Implementation.MetaType_IsAssignableFrom(this, valueType);
        }
        
        bool MetaType.Equals(MetaType otherType)
        {
            return MetaModelImplementationProvider.Implementation.MetaType_Equals(this, otherType);
        }
        
        IList<MetaScopeEntry> MetaScope.ResolveEntries(string name)
        {
            return MetaModelImplementationProvider.Implementation.MetaScope_ResolveEntries(this, name);
        }
        
        IList<MetaScopeEntry> MetaScope.GetEntries(string name)
        {
            return MetaModelImplementationProvider.Implementation.MetaScope_GetEntries(this, name);
        }
    }
    
    public interface MetaDeclaration : MetaDslx.Core.MetaScopeEntry
    {
        MetaModel Model { get; set; }
        MetaNamespace Namespace { get; }
    
    }
    
    internal class MetaDeclarationImpl : ModelObject, MetaDslx.Core.MetaDeclaration
    {
        static MetaDeclarationImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaDeclarationImpl), typeof(MetaScopeEntryImpl));
        }
    
        public MetaDeclarationImpl()
        {
            MetaModelImplementationProvider.Implementation.MetaDeclaration_MetaDeclaration(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        [OppositeAttribute(typeof(MetaModelImpl), "Types")]
        [RedefinesAttribute(typeof(MetaScopeEntryImpl), "Parent")]
        internal static readonly ModelProperty ModelProperty =
            ModelProperty.Register("Model", typeof(MetaModel), typeof(MetaDeclarationImpl));
        MetaModel MetaDeclaration.Model
        {
            get { return (MetaModel)this.MGetValue(MetaDeclarationImpl.ModelProperty); }
            set { this.MSetValue(MetaDeclarationImpl.ModelProperty, value); }
        }
        
        [ReadonlyAttribute]
        internal static readonly ModelProperty NamespaceProperty =
            ModelProperty.Register("Namespace", typeof(MetaNamespace), typeof(MetaDeclarationImpl));
        MetaNamespace MetaDeclaration.Namespace
        {
            get { return MetaModelImplementationProvider.Implementation.MetaDeclaration_Namespace(this); }
        }
    }
    
    public interface MetaCollectionType : MetaDslx.Core.MetaType
    {
        MetaCollectionKind Kind { get; set; }
        MetaType InnerType { get; set; }
    
    }
    
    internal class MetaCollectionTypeImpl : ModelObject, MetaDslx.Core.MetaCollectionType
    {
        static MetaCollectionTypeImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaCollectionTypeImpl), typeof(MetaScopeEntryImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaCollectionTypeImpl), typeof(MetaTypeImpl));
        }
    
        public MetaCollectionTypeImpl()
        {
            MetaModelImplementationProvider.Implementation.MetaCollectionType_MetaCollectionType(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        internal static readonly ModelProperty KindProperty =
            ModelProperty.Register("Kind", typeof(MetaCollectionKind), typeof(MetaCollectionTypeImpl));
        MetaCollectionKind MetaCollectionType.Kind
        {
            get { return (MetaCollectionKind)this.MGetValue(MetaCollectionTypeImpl.KindProperty); }
            set { this.MSetValue(MetaCollectionTypeImpl.KindProperty, value); }
        }
        
        internal static readonly ModelProperty InnerTypeProperty =
            ModelProperty.Register("InnerType", typeof(MetaType), typeof(MetaCollectionTypeImpl));
        MetaType MetaCollectionType.InnerType
        {
            get { return (MetaType)this.MGetValue(MetaCollectionTypeImpl.InnerTypeProperty); }
            set { this.MSetValue(MetaCollectionTypeImpl.InnerTypeProperty, value); }
        }
        
        bool MetaType.IsAssignableFrom(MetaType valueType)
        {
            return MetaModelImplementationProvider.Implementation.MetaType_IsAssignableFrom(this, valueType);
        }
        
        bool MetaType.Equals(MetaType otherType)
        {
            return MetaModelImplementationProvider.Implementation.MetaType_Equals(this, otherType);
        }
    }
    
    public interface MetaNullableType : MetaDslx.Core.MetaType
    {
        MetaType InnerType { get; set; }
    
    }
    
    internal class MetaNullableTypeImpl : ModelObject, MetaDslx.Core.MetaNullableType
    {
        static MetaNullableTypeImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaNullableTypeImpl), typeof(MetaScopeEntryImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaNullableTypeImpl), typeof(MetaTypeImpl));
        }
    
        public MetaNullableTypeImpl()
        {
            MetaModelImplementationProvider.Implementation.MetaNullableType_MetaNullableType(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        internal static readonly ModelProperty InnerTypeProperty =
            ModelProperty.Register("InnerType", typeof(MetaType), typeof(MetaNullableTypeImpl));
        MetaType MetaNullableType.InnerType
        {
            get { return (MetaType)this.MGetValue(MetaNullableTypeImpl.InnerTypeProperty); }
            set { this.MSetValue(MetaNullableTypeImpl.InnerTypeProperty, value); }
        }
        
        bool MetaType.IsAssignableFrom(MetaType valueType)
        {
            return MetaModelImplementationProvider.Implementation.MetaType_IsAssignableFrom(this, valueType);
        }
        
        bool MetaType.Equals(MetaType otherType)
        {
            return MetaModelImplementationProvider.Implementation.MetaType_Equals(this, otherType);
        }
    }
    
    public interface MetaPrimitiveType : MetaDslx.Core.MetaType, MetaDslx.Core.MetaNamedElement
    {
    
    }
    
    internal class MetaPrimitiveTypeImpl : ModelObject, MetaDslx.Core.MetaPrimitiveType
    {
        static MetaPrimitiveTypeImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaPrimitiveTypeImpl), typeof(MetaScopeEntryImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaPrimitiveTypeImpl), typeof(MetaTypeImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaPrimitiveTypeImpl), typeof(MetaNamedElementImpl));
        }
    
        public MetaPrimitiveTypeImpl()
        {
            MetaModelImplementationProvider.Implementation.MetaPrimitiveType_MetaPrimitiveType(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        string MetaNamedElement.Name
        {
            get { return (string)this.MGetValue(MetaNamedElementImpl.NameProperty); }
            set { this.MSetValue(MetaNamedElementImpl.NameProperty, value); }
        }
        
        bool MetaType.IsAssignableFrom(MetaType valueType)
        {
            return MetaModelImplementationProvider.Implementation.MetaType_IsAssignableFrom(this, valueType);
        }
        
        bool MetaType.Equals(MetaType otherType)
        {
            return MetaModelImplementationProvider.Implementation.MetaType_Equals(this, otherType);
        }
    }
    
    public interface MetaEnum : MetaDslx.Core.MetaType, MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaScope, MetaDslx.Core.MetaDeclaration
    {
        IList<MetaEnumLiteral> EnumLiterals { get; }
        IList<MetaOperation> Operations { get; }
    
    }
    
    internal class MetaEnumImpl : ModelObject, MetaDslx.Core.MetaEnum
    {
        static MetaEnumImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaEnumImpl), typeof(MetaScopeEntryImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaEnumImpl), typeof(MetaTypeImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaEnumImpl), typeof(MetaNamedElementImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaEnumImpl), typeof(MetaScopeImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaEnumImpl), typeof(MetaDeclarationImpl));
        }
    
        public MetaEnumImpl()
        {
            this.MSetValue(MetaScopeImpl.EntriesProperty, new ModelList<MetaScopeEntry>(this, MetaScopeImpl.EntriesProperty));
            this.MSetValue(MetaScopeImpl.ImportedScopesProperty, new ModelList<MetaScope>(this, MetaScopeImpl.ImportedScopesProperty));
            this.MSetValue(MetaScopeImpl.InheritedScopesProperty, new ModelList<MetaScope>(this, MetaScopeImpl.InheritedScopesProperty));
            this.MSetValue(MetaScopeImpl.ImportedEntriesProperty, new ModelList<MetaScopeEntry>(this, MetaScopeImpl.ImportedEntriesProperty));
            this.MSetValue(MetaEnumImpl.EnumLiteralsProperty, new ModelList<MetaEnumLiteral>(this, MetaEnumImpl.EnumLiteralsProperty));
            this.MSetValue(MetaEnumImpl.OperationsProperty, new ModelList<MetaOperation>(this, MetaEnumImpl.OperationsProperty));
            MetaModelImplementationProvider.Implementation.MetaEnum_MetaEnum(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        string MetaNamedElement.Name
        {
            get { return (string)this.MGetValue(MetaNamedElementImpl.NameProperty); }
            set { this.MSetValue(MetaNamedElementImpl.NameProperty, value); }
        }
        
        IList<MetaScopeEntry> MetaScope.Entries
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaScopeImpl.EntriesProperty); }
        }
        
        IList<MetaScope> MetaScope.ImportedScopes
        {
            get { return (IList<MetaScope>)this.MGetValue(MetaScopeImpl.ImportedScopesProperty); }
        }
        
        IList<MetaScope> MetaScope.InheritedScopes
        {
            get { return (IList<MetaScope>)this.MGetValue(MetaScopeImpl.InheritedScopesProperty); }
        }
        
        IList<MetaScopeEntry> MetaScope.ImportedEntries
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaScopeImpl.ImportedEntriesProperty); }
        }
        
        MetaModel MetaDeclaration.Model
        {
            get { return (MetaModel)this.MGetValue(MetaDeclarationImpl.ModelProperty); }
            set { this.MSetValue(MetaDeclarationImpl.ModelProperty, value); }
        }
        
        MetaNamespace MetaDeclaration.Namespace
        {
            get { return MetaModelImplementationProvider.Implementation.MetaDeclaration_Namespace(this); }
        }
        
        [OppositeAttribute(typeof(MetaEnumLiteralImpl), "Enum")]
        [SubsetsAttribute(typeof(MetaScopeImpl), "Entries")]
        internal static readonly ModelProperty EnumLiteralsProperty =
            ModelProperty.Register("EnumLiterals", typeof(IList<MetaEnumLiteral>), typeof(MetaEnumImpl));
        IList<MetaEnumLiteral> MetaEnum.EnumLiterals
        {
            get { return (IList<MetaEnumLiteral>)this.MGetValue(MetaEnumImpl.EnumLiteralsProperty); }
        }
        
        [SubsetsAttribute(typeof(MetaScopeImpl), "Entries")]
        internal static readonly ModelProperty OperationsProperty =
            ModelProperty.Register("Operations", typeof(IList<MetaOperation>), typeof(MetaEnumImpl));
        IList<MetaOperation> MetaEnum.Operations
        {
            get { return (IList<MetaOperation>)this.MGetValue(MetaEnumImpl.OperationsProperty); }
        }
        
        bool MetaType.IsAssignableFrom(MetaType valueType)
        {
            return MetaModelImplementationProvider.Implementation.MetaType_IsAssignableFrom(this, valueType);
        }
        
        bool MetaType.Equals(MetaType otherType)
        {
            return MetaModelImplementationProvider.Implementation.MetaType_Equals(this, otherType);
        }
        
        IList<MetaScopeEntry> MetaScope.ResolveEntries(string name)
        {
            return MetaModelImplementationProvider.Implementation.MetaScope_ResolveEntries(this, name);
        }
        
        IList<MetaScopeEntry> MetaScope.GetEntries(string name)
        {
            return MetaModelImplementationProvider.Implementation.MetaScope_GetEntries(this, name);
        }
    }
    
    public interface MetaEnumLiteral : MetaDslx.Core.MetaNamedElement
    {
        MetaEnum Enum { get; set; }
    
    }
    
    internal class MetaEnumLiteralImpl : ModelObject, MetaDslx.Core.MetaEnumLiteral
    {
        static MetaEnumLiteralImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaEnumLiteralImpl), typeof(MetaScopeEntryImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaEnumLiteralImpl), typeof(MetaNamedElementImpl));
        }
    
        public MetaEnumLiteralImpl()
        {
            MetaModelImplementationProvider.Implementation.MetaEnumLiteral_MetaEnumLiteral(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        string MetaNamedElement.Name
        {
            get { return (string)this.MGetValue(MetaNamedElementImpl.NameProperty); }
            set { this.MSetValue(MetaNamedElementImpl.NameProperty, value); }
        }
        
        [OppositeAttribute(typeof(MetaEnumImpl), "EnumLiterals")]
        [RedefinesAttribute(typeof(MetaScopeEntryImpl), "Parent")]
        internal static readonly ModelProperty EnumProperty =
            ModelProperty.Register("Enum", typeof(MetaEnum), typeof(MetaEnumLiteralImpl));
        MetaEnum MetaEnumLiteral.Enum
        {
            get { return (MetaEnum)this.MGetValue(MetaEnumLiteralImpl.EnumProperty); }
            set { this.MSetValue(MetaEnumLiteralImpl.EnumProperty, value); }
        }
    }
    
    public interface MetaClass : MetaDslx.Core.MetaType, MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaScope, MetaDslx.Core.MetaDeclaration
    {
        bool IsAbstract { get; set; }
        IList<MetaClass> SuperClasses { get; }
        IList<MetaProperty> Properties { get; }
        IList<MetaOperation> Operations { get; }
        IList<MetaPropertyInitializer> Initializers { get; }
    
        IList<MetaClass> GetAllSuperClasses();
        IList<MetaProperty> GetAllProperties();
        IList<MetaOperation> GetAllOperations();
    }
    
    internal class MetaClassImpl : ModelObject, MetaDslx.Core.MetaClass
    {
        static MetaClassImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaClassImpl), typeof(MetaScopeEntryImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaClassImpl), typeof(MetaTypeImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaClassImpl), typeof(MetaNamedElementImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaClassImpl), typeof(MetaScopeImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaClassImpl), typeof(MetaDeclarationImpl));
        }
    
        public MetaClassImpl()
        {
            this.MSetValue(MetaScopeImpl.EntriesProperty, new ModelList<MetaScopeEntry>(this, MetaScopeImpl.EntriesProperty));
            this.MSetValue(MetaScopeImpl.ImportedScopesProperty, new ModelList<MetaScope>(this, MetaScopeImpl.ImportedScopesProperty));
            this.MSetValue(MetaScopeImpl.InheritedScopesProperty, new ModelList<MetaScope>(this, MetaScopeImpl.InheritedScopesProperty));
            this.MSetValue(MetaScopeImpl.ImportedEntriesProperty, new ModelList<MetaScopeEntry>(this, MetaScopeImpl.ImportedEntriesProperty));
            this.MSetValue(MetaClassImpl.SuperClassesProperty, new ModelList<MetaClass>(this, MetaClassImpl.SuperClassesProperty));
            this.MSetValue(MetaClassImpl.PropertiesProperty, new ModelList<MetaProperty>(this, MetaClassImpl.PropertiesProperty));
            this.MSetValue(MetaClassImpl.OperationsProperty, new ModelList<MetaOperation>(this, MetaClassImpl.OperationsProperty));
            this.MSetValue(MetaClassImpl.InitializersProperty, new ModelList<MetaPropertyInitializer>(this, MetaClassImpl.InitializersProperty));
            MetaModelImplementationProvider.Implementation.MetaClass_MetaClass(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        string MetaNamedElement.Name
        {
            get { return (string)this.MGetValue(MetaNamedElementImpl.NameProperty); }
            set { this.MSetValue(MetaNamedElementImpl.NameProperty, value); }
        }
        
        IList<MetaScopeEntry> MetaScope.Entries
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaScopeImpl.EntriesProperty); }
        }
        
        IList<MetaScope> MetaScope.ImportedScopes
        {
            get { return (IList<MetaScope>)this.MGetValue(MetaScopeImpl.ImportedScopesProperty); }
        }
        
        IList<MetaScope> MetaScope.InheritedScopes
        {
            get { return (IList<MetaScope>)this.MGetValue(MetaScopeImpl.InheritedScopesProperty); }
        }
        
        IList<MetaScopeEntry> MetaScope.ImportedEntries
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaScopeImpl.ImportedEntriesProperty); }
        }
        
        MetaModel MetaDeclaration.Model
        {
            get { return (MetaModel)this.MGetValue(MetaDeclarationImpl.ModelProperty); }
            set { this.MSetValue(MetaDeclarationImpl.ModelProperty, value); }
        }
        
        MetaNamespace MetaDeclaration.Namespace
        {
            get { return MetaModelImplementationProvider.Implementation.MetaDeclaration_Namespace(this); }
        }
        
        internal static readonly ModelProperty IsAbstractProperty =
            ModelProperty.Register("IsAbstract", typeof(bool), typeof(MetaClassImpl));
        bool MetaClass.IsAbstract
        {
            get { return (bool)this.MGetValue(MetaClassImpl.IsAbstractProperty); }
            set { this.MSetValue(MetaClassImpl.IsAbstractProperty, value); }
        }
        
        [RedefinesAttribute(typeof(MetaScopeImpl), "InheritedScopes")]
        internal static readonly ModelProperty SuperClassesProperty =
            ModelProperty.Register("SuperClasses", typeof(IList<MetaClass>), typeof(MetaClassImpl));
        IList<MetaClass> MetaClass.SuperClasses
        {
            get { return (IList<MetaClass>)this.MGetValue(MetaClassImpl.SuperClassesProperty); }
        }
        
        [OppositeAttribute(typeof(MetaPropertyImpl), "Class")]
        [SubsetsAttribute(typeof(MetaScopeImpl), "Entries")]
        internal static readonly ModelProperty PropertiesProperty =
            ModelProperty.Register("Properties", typeof(IList<MetaProperty>), typeof(MetaClassImpl));
        IList<MetaProperty> MetaClass.Properties
        {
            get { return (IList<MetaProperty>)this.MGetValue(MetaClassImpl.PropertiesProperty); }
        }
        
        [SubsetsAttribute(typeof(MetaScopeImpl), "Entries")]
        internal static readonly ModelProperty OperationsProperty =
            ModelProperty.Register("Operations", typeof(IList<MetaOperation>), typeof(MetaClassImpl));
        IList<MetaOperation> MetaClass.Operations
        {
            get { return (IList<MetaOperation>)this.MGetValue(MetaClassImpl.OperationsProperty); }
        }
        
        internal static readonly ModelProperty InitializersProperty =
            ModelProperty.Register("Initializers", typeof(IList<MetaPropertyInitializer>), typeof(MetaClassImpl));
        IList<MetaPropertyInitializer> MetaClass.Initializers
        {
            get { return (IList<MetaPropertyInitializer>)this.MGetValue(MetaClassImpl.InitializersProperty); }
        }
        
        bool MetaType.IsAssignableFrom(MetaType valueType)
        {
            return MetaModelImplementationProvider.Implementation.MetaType_IsAssignableFrom(this, valueType);
        }
        
        bool MetaType.Equals(MetaType otherType)
        {
            return MetaModelImplementationProvider.Implementation.MetaType_Equals(this, otherType);
        }
        
        IList<MetaScopeEntry> MetaScope.ResolveEntries(string name)
        {
            return MetaModelImplementationProvider.Implementation.MetaScope_ResolveEntries(this, name);
        }
        
        IList<MetaScopeEntry> MetaScope.GetEntries(string name)
        {
            return MetaModelImplementationProvider.Implementation.MetaScope_GetEntries(this, name);
        }
        
        IList<MetaClass> MetaClass.GetAllSuperClasses()
        {
            return MetaModelImplementationProvider.Implementation.MetaClass_GetAllSuperClasses(this);
        }
        
        IList<MetaProperty> MetaClass.GetAllProperties()
        {
            return MetaModelImplementationProvider.Implementation.MetaClass_GetAllProperties(this);
        }
        
        IList<MetaOperation> MetaClass.GetAllOperations()
        {
            return MetaModelImplementationProvider.Implementation.MetaClass_GetAllOperations(this);
        }
    }
    
    public interface MetaOperation : MetaDslx.Core.MetaNamedElement
    {
        IList<MetaParameter> Parameters { get; }
        MetaType ReturnType { get; set; }
    
    }
    
    internal class MetaOperationImpl : ModelObject, MetaDslx.Core.MetaOperation
    {
        static MetaOperationImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaOperationImpl), typeof(MetaScopeEntryImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaOperationImpl), typeof(MetaNamedElementImpl));
        }
    
        public MetaOperationImpl()
        {
            this.MSetValue(MetaOperationImpl.ParametersProperty, new ModelList<MetaParameter>(this, MetaOperationImpl.ParametersProperty));
            MetaModelImplementationProvider.Implementation.MetaOperation_MetaOperation(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        string MetaNamedElement.Name
        {
            get { return (string)this.MGetValue(MetaNamedElementImpl.NameProperty); }
            set { this.MSetValue(MetaNamedElementImpl.NameProperty, value); }
        }
        
        [ContainmentAttribute]
        [OppositeAttribute(typeof(MetaParameterImpl), "Operation")]
        internal static readonly ModelProperty ParametersProperty =
            ModelProperty.Register("Parameters", typeof(IList<MetaParameter>), typeof(MetaOperationImpl));
        IList<MetaParameter> MetaOperation.Parameters
        {
            get { return (IList<MetaParameter>)this.MGetValue(MetaOperationImpl.ParametersProperty); }
        }
        
        internal static readonly ModelProperty ReturnTypeProperty =
            ModelProperty.Register("ReturnType", typeof(MetaType), typeof(MetaOperationImpl));
        MetaType MetaOperation.ReturnType
        {
            get { return (MetaType)this.MGetValue(MetaOperationImpl.ReturnTypeProperty); }
            set { this.MSetValue(MetaOperationImpl.ReturnTypeProperty, value); }
        }
    }
    
    public interface MetaParameter : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaTypedElement
    {
        MetaOperation Operation { get; set; }
    
    }
    
    internal class MetaParameterImpl : ModelObject, MetaDslx.Core.MetaParameter
    {
        static MetaParameterImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaParameterImpl), typeof(MetaScopeEntryImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaParameterImpl), typeof(MetaNamedElementImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaParameterImpl), typeof(MetaTypedElementImpl));
        }
    
        public MetaParameterImpl()
        {
            MetaModelImplementationProvider.Implementation.MetaParameter_MetaParameter(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        string MetaNamedElement.Name
        {
            get { return (string)this.MGetValue(MetaNamedElementImpl.NameProperty); }
            set { this.MSetValue(MetaNamedElementImpl.NameProperty, value); }
        }
        
        MetaType MetaTypedElement.Type
        {
            get { return (MetaType)this.MGetValue(MetaTypedElementImpl.TypeProperty); }
            set { this.MSetValue(MetaTypedElementImpl.TypeProperty, value); }
        }
        
        [OppositeAttribute(typeof(MetaOperationImpl), "Parameters")]
        internal static readonly ModelProperty OperationProperty =
            ModelProperty.Register("Operation", typeof(MetaOperation), typeof(MetaParameterImpl));
        MetaOperation MetaParameter.Operation
        {
            get { return (MetaOperation)this.MGetValue(MetaParameterImpl.OperationProperty); }
            set { this.MSetValue(MetaParameterImpl.OperationProperty, value); }
        }
    }
    
    public interface MetaProperty : MetaDslx.Core.MetaNamedElement, MetaDslx.Core.MetaTypedElement
    {
        MetaPropertyKind Kind { get; set; }
        MetaClass Class { get; set; }
        IList<MetaProperty> OppositeProperties { get; }
        IList<MetaProperty> SubsettedProperties { get; }
        IList<MetaProperty> SubsettingProperties { get; }
        IList<MetaProperty> RedefinedProperties { get; }
        IList<MetaProperty> RedefiningProperties { get; }
    
    }
    
    internal class MetaPropertyImpl : ModelObject, MetaDslx.Core.MetaProperty
    {
        static MetaPropertyImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaPropertyImpl), typeof(MetaScopeEntryImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaPropertyImpl), typeof(MetaNamedElementImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaPropertyImpl), typeof(MetaTypedElementImpl));
        }
    
        public MetaPropertyImpl()
        {
            this.MSetValue(MetaPropertyImpl.OppositePropertiesProperty, new ModelList<MetaProperty>(this, MetaPropertyImpl.OppositePropertiesProperty));
            this.MSetValue(MetaPropertyImpl.SubsettedPropertiesProperty, new ModelList<MetaProperty>(this, MetaPropertyImpl.SubsettedPropertiesProperty));
            this.MSetValue(MetaPropertyImpl.SubsettingPropertiesProperty, new ModelList<MetaProperty>(this, MetaPropertyImpl.SubsettingPropertiesProperty));
            this.MSetValue(MetaPropertyImpl.RedefinedPropertiesProperty, new ModelList<MetaProperty>(this, MetaPropertyImpl.RedefinedPropertiesProperty));
            this.MSetValue(MetaPropertyImpl.RedefiningPropertiesProperty, new ModelList<MetaProperty>(this, MetaPropertyImpl.RedefiningPropertiesProperty));
            MetaModelImplementationProvider.Implementation.MetaProperty_MetaProperty(this);
            this.MMakeDefault();
        }
        
        MetaScope MetaScopeEntry.Parent
        {
            get { return (MetaScope)this.MGetValue(MetaScopeEntryImpl.ParentProperty); }
            set { this.MSetValue(MetaScopeEntryImpl.ParentProperty, value); }
        }
        
        string MetaNamedElement.Name
        {
            get { return (string)this.MGetValue(MetaNamedElementImpl.NameProperty); }
            set { this.MSetValue(MetaNamedElementImpl.NameProperty, value); }
        }
        
        MetaType MetaTypedElement.Type
        {
            get { return (MetaType)this.MGetValue(MetaTypedElementImpl.TypeProperty); }
            set { this.MSetValue(MetaTypedElementImpl.TypeProperty, value); }
        }
        
        internal static readonly ModelProperty KindProperty =
            ModelProperty.Register("Kind", typeof(MetaPropertyKind), typeof(MetaPropertyImpl));
        MetaPropertyKind MetaProperty.Kind
        {
            get { return (MetaPropertyKind)this.MGetValue(MetaPropertyImpl.KindProperty); }
            set { this.MSetValue(MetaPropertyImpl.KindProperty, value); }
        }
        
        [OppositeAttribute(typeof(MetaClassImpl), "Properties")]
        [RedefinesAttribute(typeof(MetaScopeEntryImpl), "Parent")]
        internal static readonly ModelProperty ClassProperty =
            ModelProperty.Register("Class", typeof(MetaClass), typeof(MetaPropertyImpl));
        MetaClass MetaProperty.Class
        {
            get { return (MetaClass)this.MGetValue(MetaPropertyImpl.ClassProperty); }
            set { this.MSetValue(MetaPropertyImpl.ClassProperty, value); }
        }
        
        [OppositeAttribute(typeof(MetaPropertyImpl), "OppositeProperties")]
        internal static readonly ModelProperty OppositePropertiesProperty =
            ModelProperty.Register("OppositeProperties", typeof(IList<MetaProperty>), typeof(MetaPropertyImpl));
        IList<MetaProperty> MetaProperty.OppositeProperties
        {
            get { return (IList<MetaProperty>)this.MGetValue(MetaPropertyImpl.OppositePropertiesProperty); }
        }
        
        [OppositeAttribute(typeof(MetaPropertyImpl), "SubsettingProperties")]
        internal static readonly ModelProperty SubsettedPropertiesProperty =
            ModelProperty.Register("SubsettedProperties", typeof(IList<MetaProperty>), typeof(MetaPropertyImpl));
        IList<MetaProperty> MetaProperty.SubsettedProperties
        {
            get { return (IList<MetaProperty>)this.MGetValue(MetaPropertyImpl.SubsettedPropertiesProperty); }
        }
        
        [OppositeAttribute(typeof(MetaPropertyImpl), "SubsettedProperties")]
        internal static readonly ModelProperty SubsettingPropertiesProperty =
            ModelProperty.Register("SubsettingProperties", typeof(IList<MetaProperty>), typeof(MetaPropertyImpl));
        IList<MetaProperty> MetaProperty.SubsettingProperties
        {
            get { return (IList<MetaProperty>)this.MGetValue(MetaPropertyImpl.SubsettingPropertiesProperty); }
        }
        
        [OppositeAttribute(typeof(MetaPropertyImpl), "RedefiningProperties")]
        internal static readonly ModelProperty RedefinedPropertiesProperty =
            ModelProperty.Register("RedefinedProperties", typeof(IList<MetaProperty>), typeof(MetaPropertyImpl));
        IList<MetaProperty> MetaProperty.RedefinedProperties
        {
            get { return (IList<MetaProperty>)this.MGetValue(MetaPropertyImpl.RedefinedPropertiesProperty); }
        }
        
        [OppositeAttribute(typeof(MetaPropertyImpl), "RedefinedProperties")]
        internal static readonly ModelProperty RedefiningPropertiesProperty =
            ModelProperty.Register("RedefiningProperties", typeof(IList<MetaProperty>), typeof(MetaPropertyImpl));
        IList<MetaProperty> MetaProperty.RedefiningProperties
        {
            get { return (IList<MetaProperty>)this.MGetValue(MetaPropertyImpl.RedefiningPropertiesProperty); }
        }
    }
    
    public interface MetaPropertyInitializer
    {
        MetaProperty Property { get; set; }
        MetaExpression Value { get; set; }
    
    }
    
    internal class MetaPropertyInitializerImpl : ModelObject, MetaDslx.Core.MetaPropertyInitializer
    {
        public MetaPropertyInitializerImpl()
        {
            MetaModelImplementationProvider.Implementation.MetaPropertyInitializer_MetaPropertyInitializer(this);
            this.MMakeDefault();
        }
        
        internal static readonly ModelProperty PropertyProperty =
            ModelProperty.Register("Property", typeof(MetaProperty), typeof(MetaPropertyInitializerImpl));
        MetaProperty MetaPropertyInitializer.Property
        {
            get { return (MetaProperty)this.MGetValue(MetaPropertyInitializerImpl.PropertyProperty); }
            set { this.MSetValue(MetaPropertyInitializerImpl.PropertyProperty, value); }
        }
        
        internal static readonly ModelProperty ValueProperty =
            ModelProperty.Register("Value", typeof(MetaExpression), typeof(MetaPropertyInitializerImpl));
        MetaExpression MetaPropertyInitializer.Value
        {
            get { return (MetaExpression)this.MGetValue(MetaPropertyInitializerImpl.ValueProperty); }
            set { this.MSetValue(MetaPropertyInitializerImpl.ValueProperty, value); }
        }
    }
    
    public interface MetaSynthetizedPropertyInitializer : MetaDslx.Core.MetaPropertyInitializer
    {
    
    }
    
    internal class MetaSynthetizedPropertyInitializerImpl : ModelObject, MetaDslx.Core.MetaSynthetizedPropertyInitializer
    {
        static MetaSynthetizedPropertyInitializerImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaSynthetizedPropertyInitializerImpl), typeof(MetaPropertyInitializerImpl));
        }
    
        public MetaSynthetizedPropertyInitializerImpl()
        {
            MetaModelImplementationProvider.Implementation.MetaSynthetizedPropertyInitializer_MetaSynthetizedPropertyInitializer(this);
            this.MMakeDefault();
        }
        
        MetaProperty MetaPropertyInitializer.Property
        {
            get { return (MetaProperty)this.MGetValue(MetaPropertyInitializerImpl.PropertyProperty); }
            set { this.MSetValue(MetaPropertyInitializerImpl.PropertyProperty, value); }
        }
        
        MetaExpression MetaPropertyInitializer.Value
        {
            get { return (MetaExpression)this.MGetValue(MetaPropertyInitializerImpl.ValueProperty); }
            set { this.MSetValue(MetaPropertyInitializerImpl.ValueProperty, value); }
        }
    }
    
    public interface MetaInheritedPropertyInitializer : MetaDslx.Core.MetaPropertyInitializer
    {
        MetaProperty Object { get; set; }
    
    }
    
    internal class MetaInheritedPropertyInitializerImpl : ModelObject, MetaDslx.Core.MetaInheritedPropertyInitializer
    {
        static MetaInheritedPropertyInitializerImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaInheritedPropertyInitializerImpl), typeof(MetaPropertyInitializerImpl));
        }
    
        public MetaInheritedPropertyInitializerImpl()
        {
            MetaModelImplementationProvider.Implementation.MetaInheritedPropertyInitializer_MetaInheritedPropertyInitializer(this);
            this.MMakeDefault();
        }
        
        MetaProperty MetaPropertyInitializer.Property
        {
            get { return (MetaProperty)this.MGetValue(MetaPropertyInitializerImpl.PropertyProperty); }
            set { this.MSetValue(MetaPropertyInitializerImpl.PropertyProperty, value); }
        }
        
        MetaExpression MetaPropertyInitializer.Value
        {
            get { return (MetaExpression)this.MGetValue(MetaPropertyInitializerImpl.ValueProperty); }
            set { this.MSetValue(MetaPropertyInitializerImpl.ValueProperty, value); }
        }
        
        internal static readonly ModelProperty ObjectProperty =
            ModelProperty.Register("Object", typeof(MetaProperty), typeof(MetaInheritedPropertyInitializerImpl));
        MetaProperty MetaInheritedPropertyInitializer.Object
        {
            get { return (MetaProperty)this.MGetValue(MetaInheritedPropertyInitializerImpl.ObjectProperty); }
            set { this.MSetValue(MetaInheritedPropertyInitializerImpl.ObjectProperty, value); }
        }
    }
    
    public interface MetaExpression
    {
        MetaExpressionKind Kind { get; set; }
        MetaType Type { get; }
        MetaType ExpectedType { get; }
        IList<MetaScopeEntry> Definitions { get; }
        MetaScopeEntry Definition { get; }
    
    }
    
    internal class MetaExpressionImpl : ModelObject, MetaDslx.Core.MetaExpression
    {
        public MetaExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            MetaModelImplementationProvider.Implementation.MetaExpression_MetaExpression(this);
            this.MMakeDefault();
        }
        
        internal static readonly ModelProperty KindProperty =
            ModelProperty.Register("Kind", typeof(MetaExpressionKind), typeof(MetaExpressionImpl));
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        [ReadonlyAttribute]
        internal static readonly ModelProperty TypeProperty =
            ModelProperty.Register("Type", typeof(MetaType), typeof(MetaExpressionImpl));
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        [ReadonlyAttribute]
        internal static readonly ModelProperty ExpectedTypeProperty =
            ModelProperty.Register("ExpectedType", typeof(MetaType), typeof(MetaExpressionImpl));
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        internal static readonly ModelProperty DefinitionsProperty =
            ModelProperty.Register("Definitions", typeof(IList<MetaScopeEntry>), typeof(MetaExpressionImpl));
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        [ReadonlyAttribute]
        internal static readonly ModelProperty DefinitionProperty =
            ModelProperty.Register("Definition", typeof(MetaScopeEntry), typeof(MetaExpressionImpl));
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
    }
    
    public interface MetaUnaryExpression : MetaDslx.Core.MetaExpression
    {
        MetaExpression Expression { get; set; }
    
    }
    
    internal class MetaUnaryExpressionImpl : ModelObject, MetaDslx.Core.MetaUnaryExpression
    {
        static MetaUnaryExpressionImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaUnaryExpressionImpl), typeof(MetaExpressionImpl));
        }
    
        public MetaUnaryExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            MetaModelImplementationProvider.Implementation.MetaUnaryExpression_MetaUnaryExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty ExpressionProperty =
            ModelProperty.Register("Expression", typeof(MetaExpression), typeof(MetaUnaryExpressionImpl));
        MetaExpression MetaUnaryExpression.Expression
        {
            get { return (MetaExpression)this.MGetValue(MetaUnaryExpressionImpl.ExpressionProperty); }
            set { this.MSetValue(MetaUnaryExpressionImpl.ExpressionProperty, value); }
        }
    }
    
    public interface MetaBinaryExpression : MetaDslx.Core.MetaExpression
    {
        MetaExpression Left { get; set; }
        MetaExpression Right { get; set; }
    
    }
    
    internal class MetaBinaryExpressionImpl : ModelObject, MetaDslx.Core.MetaBinaryExpression
    {
        static MetaBinaryExpressionImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaBinaryExpressionImpl), typeof(MetaExpressionImpl));
        }
    
        public MetaBinaryExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            MetaModelImplementationProvider.Implementation.MetaBinaryExpression_MetaBinaryExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty LeftProperty =
            ModelProperty.Register("Left", typeof(MetaExpression), typeof(MetaBinaryExpressionImpl));
        MetaExpression MetaBinaryExpression.Left
        {
            get { return (MetaExpression)this.MGetValue(MetaBinaryExpressionImpl.LeftProperty); }
            set { this.MSetValue(MetaBinaryExpressionImpl.LeftProperty, value); }
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty RightProperty =
            ModelProperty.Register("Right", typeof(MetaExpression), typeof(MetaBinaryExpressionImpl));
        MetaExpression MetaBinaryExpression.Right
        {
            get { return (MetaExpression)this.MGetValue(MetaBinaryExpressionImpl.RightProperty); }
            set { this.MSetValue(MetaBinaryExpressionImpl.RightProperty, value); }
        }
    }
    
    public interface MetaBinaryArithmeticExpression : MetaDslx.Core.MetaBinaryExpression
    {
    
    }
    
    internal class MetaBinaryArithmeticExpressionImpl : ModelObject, MetaDslx.Core.MetaBinaryArithmeticExpression
    {
        static MetaBinaryArithmeticExpressionImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaBinaryArithmeticExpressionImpl), typeof(MetaExpressionImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaBinaryArithmeticExpressionImpl), typeof(MetaBinaryExpressionImpl));
        }
    
        public MetaBinaryArithmeticExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            MetaModelImplementationProvider.Implementation.MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get { return (MetaExpression)this.MGetValue(MetaBinaryExpressionImpl.LeftProperty); }
            set { this.MSetValue(MetaBinaryExpressionImpl.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get { return (MetaExpression)this.MGetValue(MetaBinaryExpressionImpl.RightProperty); }
            set { this.MSetValue(MetaBinaryExpressionImpl.RightProperty, value); }
        }
    }
    
    public interface MetaBinaryComparisonExpression : MetaDslx.Core.MetaBinaryExpression
    {
        MetaType BalancedType { get; }
    
    }
    
    internal class MetaBinaryComparisonExpressionImpl : ModelObject, MetaDslx.Core.MetaBinaryComparisonExpression
    {
        static MetaBinaryComparisonExpressionImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaBinaryComparisonExpressionImpl), typeof(MetaExpressionImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaBinaryComparisonExpressionImpl), typeof(MetaBinaryExpressionImpl));
        }
    
        public MetaBinaryComparisonExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            this.MInitValue(MetaBinaryComparisonExpressionImpl.BalancedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaBinaryComparisonExpression_BalancedType(this)));
            MetaModelImplementationProvider.Implementation.MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get { return (MetaExpression)this.MGetValue(MetaBinaryExpressionImpl.LeftProperty); }
            set { this.MSetValue(MetaBinaryExpressionImpl.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get { return (MetaExpression)this.MGetValue(MetaBinaryExpressionImpl.RightProperty); }
            set { this.MSetValue(MetaBinaryExpressionImpl.RightProperty, value); }
        }
        
        [ReadonlyAttribute]
        internal static readonly ModelProperty BalancedTypeProperty =
            ModelProperty.Register("BalancedType", typeof(MetaType), typeof(MetaBinaryComparisonExpressionImpl));
        MetaType MetaBinaryComparisonExpression.BalancedType
        {
            get { return (MetaType)this.MGetValue(MetaBinaryComparisonExpressionImpl.BalancedTypeProperty); }
        }
    }
    
    public interface MetaBinaryLogicalExpression : MetaDslx.Core.MetaBinaryExpression
    {
    
    }
    
    internal class MetaBinaryLogicalExpressionImpl : ModelObject, MetaDslx.Core.MetaBinaryLogicalExpression
    {
        static MetaBinaryLogicalExpressionImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaBinaryLogicalExpressionImpl), typeof(MetaExpressionImpl));
    		ModelProperty.RegisterAncestor(typeof(MetaBinaryLogicalExpressionImpl), typeof(MetaBinaryExpressionImpl));
        }
    
        public MetaBinaryLogicalExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            MetaModelImplementationProvider.Implementation.MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
        
        MetaExpression MetaBinaryExpression.Left
        {
            get { return (MetaExpression)this.MGetValue(MetaBinaryExpressionImpl.LeftProperty); }
            set { this.MSetValue(MetaBinaryExpressionImpl.LeftProperty, value); }
        }
        
        MetaExpression MetaBinaryExpression.Right
        {
            get { return (MetaExpression)this.MGetValue(MetaBinaryExpressionImpl.RightProperty); }
            set { this.MSetValue(MetaBinaryExpressionImpl.RightProperty, value); }
        }
    }
    
    public interface MetaAssignmentExpression : MetaDslx.Core.MetaExpression
    {
        MetaExpression Target { get; set; }
        MetaExpression Value { get; set; }
    
    }
    
    internal class MetaAssignmentExpressionImpl : ModelObject, MetaDslx.Core.MetaAssignmentExpression
    {
        static MetaAssignmentExpressionImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaAssignmentExpressionImpl), typeof(MetaExpressionImpl));
        }
    
        public MetaAssignmentExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            MetaModelImplementationProvider.Implementation.MetaAssignmentExpression_MetaAssignmentExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty TargetProperty =
            ModelProperty.Register("Target", typeof(MetaExpression), typeof(MetaAssignmentExpressionImpl));
        MetaExpression MetaAssignmentExpression.Target
        {
            get { return (MetaExpression)this.MGetValue(MetaAssignmentExpressionImpl.TargetProperty); }
            set { this.MSetValue(MetaAssignmentExpressionImpl.TargetProperty, value); }
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty ValueProperty =
            ModelProperty.Register("Value", typeof(MetaExpression), typeof(MetaAssignmentExpressionImpl));
        MetaExpression MetaAssignmentExpression.Value
        {
            get { return (MetaExpression)this.MGetValue(MetaAssignmentExpressionImpl.ValueProperty); }
            set { this.MSetValue(MetaAssignmentExpressionImpl.ValueProperty, value); }
        }
    }
    
    public interface MetaTypeConversionExpression : MetaDslx.Core.MetaExpression
    {
        MetaType TypeReference { get; set; }
        MetaExpression Expression { get; set; }
    
    }
    
    internal class MetaTypeConversionExpressionImpl : ModelObject, MetaDslx.Core.MetaTypeConversionExpression
    {
        static MetaTypeConversionExpressionImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaTypeConversionExpressionImpl), typeof(MetaExpressionImpl));
        }
    
        public MetaTypeConversionExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            MetaModelImplementationProvider.Implementation.MetaTypeConversionExpression_MetaTypeConversionExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
        
        internal static readonly ModelProperty TypeReferenceProperty =
            ModelProperty.Register("TypeReference", typeof(MetaType), typeof(MetaTypeConversionExpressionImpl));
        MetaType MetaTypeConversionExpression.TypeReference
        {
            get { return (MetaType)this.MGetValue(MetaTypeConversionExpressionImpl.TypeReferenceProperty); }
            set { this.MSetValue(MetaTypeConversionExpressionImpl.TypeReferenceProperty, value); }
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty ExpressionProperty =
            ModelProperty.Register("Expression", typeof(MetaExpression), typeof(MetaTypeConversionExpressionImpl));
        MetaExpression MetaTypeConversionExpression.Expression
        {
            get { return (MetaExpression)this.MGetValue(MetaTypeConversionExpressionImpl.ExpressionProperty); }
            set { this.MSetValue(MetaTypeConversionExpressionImpl.ExpressionProperty, value); }
        }
    }
    
    public interface MetaTypeCheckExpression : MetaDslx.Core.MetaExpression
    {
        MetaType TypeReference { get; set; }
        MetaExpression Expression { get; set; }
    
    }
    
    internal class MetaTypeCheckExpressionImpl : ModelObject, MetaDslx.Core.MetaTypeCheckExpression
    {
        static MetaTypeCheckExpressionImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaTypeCheckExpressionImpl), typeof(MetaExpressionImpl));
        }
    
        public MetaTypeCheckExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            MetaModelImplementationProvider.Implementation.MetaTypeCheckExpression_MetaTypeCheckExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
        
        internal static readonly ModelProperty TypeReferenceProperty =
            ModelProperty.Register("TypeReference", typeof(MetaType), typeof(MetaTypeCheckExpressionImpl));
        MetaType MetaTypeCheckExpression.TypeReference
        {
            get { return (MetaType)this.MGetValue(MetaTypeCheckExpressionImpl.TypeReferenceProperty); }
            set { this.MSetValue(MetaTypeCheckExpressionImpl.TypeReferenceProperty, value); }
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty ExpressionProperty =
            ModelProperty.Register("Expression", typeof(MetaExpression), typeof(MetaTypeCheckExpressionImpl));
        MetaExpression MetaTypeCheckExpression.Expression
        {
            get { return (MetaExpression)this.MGetValue(MetaTypeCheckExpressionImpl.ExpressionProperty); }
            set { this.MSetValue(MetaTypeCheckExpressionImpl.ExpressionProperty, value); }
        }
    }
    
    public interface MetaTypeOfExpression : MetaDslx.Core.MetaExpression
    {
        MetaType TypeReference { get; set; }
    
    }
    
    internal class MetaTypeOfExpressionImpl : ModelObject, MetaDslx.Core.MetaTypeOfExpression
    {
        static MetaTypeOfExpressionImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaTypeOfExpressionImpl), typeof(MetaExpressionImpl));
        }
    
        public MetaTypeOfExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            MetaModelImplementationProvider.Implementation.MetaTypeOfExpression_MetaTypeOfExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
        
        internal static readonly ModelProperty TypeReferenceProperty =
            ModelProperty.Register("TypeReference", typeof(MetaType), typeof(MetaTypeOfExpressionImpl));
        MetaType MetaTypeOfExpression.TypeReference
        {
            get { return (MetaType)this.MGetValue(MetaTypeOfExpressionImpl.TypeReferenceProperty); }
            set { this.MSetValue(MetaTypeOfExpressionImpl.TypeReferenceProperty, value); }
        }
    }
    
    public interface MetaConstantExpression : MetaDslx.Core.MetaExpression
    {
        object Value { get; set; }
    
    }
    
    internal class MetaConstantExpressionImpl : ModelObject, MetaDslx.Core.MetaConstantExpression
    {
        static MetaConstantExpressionImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaConstantExpressionImpl), typeof(MetaExpressionImpl));
        }
    
        public MetaConstantExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            MetaModelImplementationProvider.Implementation.MetaConstantExpression_MetaConstantExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
        
        internal static readonly ModelProperty ValueProperty =
            ModelProperty.Register("Value", typeof(object), typeof(MetaConstantExpressionImpl));
        object MetaConstantExpression.Value
        {
            get { return (object)this.MGetValue(MetaConstantExpressionImpl.ValueProperty); }
            set { this.MSetValue(MetaConstantExpressionImpl.ValueProperty, value); }
        }
    }
    
    public interface MetaIdentifierExpression : MetaDslx.Core.MetaExpression
    {
        string Name { get; set; }
    
    }
    
    internal class MetaIdentifierExpressionImpl : ModelObject, MetaDslx.Core.MetaIdentifierExpression
    {
        static MetaIdentifierExpressionImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaIdentifierExpressionImpl), typeof(MetaExpressionImpl));
        }
    
        public MetaIdentifierExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            MetaModelImplementationProvider.Implementation.MetaIdentifierExpression_MetaIdentifierExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
        
        internal static readonly ModelProperty NameProperty =
            ModelProperty.Register("Name", typeof(string), typeof(MetaIdentifierExpressionImpl));
        string MetaIdentifierExpression.Name
        {
            get { return (string)this.MGetValue(MetaIdentifierExpressionImpl.NameProperty); }
            set { this.MSetValue(MetaIdentifierExpressionImpl.NameProperty, value); }
        }
    }
    
    public interface MetaMemberAccessExpression : MetaDslx.Core.MetaExpression
    {
        MetaExpression Expression { get; set; }
        string Name { get; set; }
    
    }
    
    internal class MetaMemberAccessExpressionImpl : ModelObject, MetaDslx.Core.MetaMemberAccessExpression
    {
        static MetaMemberAccessExpressionImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaMemberAccessExpressionImpl), typeof(MetaExpressionImpl));
        }
    
        public MetaMemberAccessExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            MetaModelImplementationProvider.Implementation.MetaMemberAccessExpression_MetaMemberAccessExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty ExpressionProperty =
            ModelProperty.Register("Expression", typeof(MetaExpression), typeof(MetaMemberAccessExpressionImpl));
        MetaExpression MetaMemberAccessExpression.Expression
        {
            get { return (MetaExpression)this.MGetValue(MetaMemberAccessExpressionImpl.ExpressionProperty); }
            set { this.MSetValue(MetaMemberAccessExpressionImpl.ExpressionProperty, value); }
        }
        
        internal static readonly ModelProperty NameProperty =
            ModelProperty.Register("Name", typeof(string), typeof(MetaMemberAccessExpressionImpl));
        string MetaMemberAccessExpression.Name
        {
            get { return (string)this.MGetValue(MetaMemberAccessExpressionImpl.NameProperty); }
            set { this.MSetValue(MetaMemberAccessExpressionImpl.NameProperty, value); }
        }
    }
    
    public interface MetaFunctionCallExpression : MetaDslx.Core.MetaExpression
    {
        MetaExpression Expression { get; set; }
        IList<MetaExpression> Arguments { get; }
    
    }
    
    internal class MetaFunctionCallExpressionImpl : ModelObject, MetaDslx.Core.MetaFunctionCallExpression
    {
        static MetaFunctionCallExpressionImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaFunctionCallExpressionImpl), typeof(MetaExpressionImpl));
        }
    
        public MetaFunctionCallExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            this.MSetValue(MetaFunctionCallExpressionImpl.ArgumentsProperty, new ModelList<MetaExpression>(this, MetaFunctionCallExpressionImpl.ArgumentsProperty));
            MetaModelImplementationProvider.Implementation.MetaFunctionCallExpression_MetaFunctionCallExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty ExpressionProperty =
            ModelProperty.Register("Expression", typeof(MetaExpression), typeof(MetaFunctionCallExpressionImpl));
        MetaExpression MetaFunctionCallExpression.Expression
        {
            get { return (MetaExpression)this.MGetValue(MetaFunctionCallExpressionImpl.ExpressionProperty); }
            set { this.MSetValue(MetaFunctionCallExpressionImpl.ExpressionProperty, value); }
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty ArgumentsProperty =
            ModelProperty.Register("Arguments", typeof(IList<MetaExpression>), typeof(MetaFunctionCallExpressionImpl));
        IList<MetaExpression> MetaFunctionCallExpression.Arguments
        {
            get { return (IList<MetaExpression>)this.MGetValue(MetaFunctionCallExpressionImpl.ArgumentsProperty); }
        }
    }
    
    public interface MetaIndexerExpression : MetaDslx.Core.MetaExpression
    {
        MetaExpression Expression { get; set; }
        IList<MetaExpression> Arguments { get; }
    
    }
    
    internal class MetaIndexerExpressionImpl : ModelObject, MetaDslx.Core.MetaIndexerExpression
    {
        static MetaIndexerExpressionImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaIndexerExpressionImpl), typeof(MetaExpressionImpl));
        }
    
        public MetaIndexerExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            this.MSetValue(MetaIndexerExpressionImpl.ArgumentsProperty, new ModelList<MetaExpression>(this, MetaIndexerExpressionImpl.ArgumentsProperty));
            MetaModelImplementationProvider.Implementation.MetaIndexerExpression_MetaIndexerExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty ExpressionProperty =
            ModelProperty.Register("Expression", typeof(MetaExpression), typeof(MetaIndexerExpressionImpl));
        MetaExpression MetaIndexerExpression.Expression
        {
            get { return (MetaExpression)this.MGetValue(MetaIndexerExpressionImpl.ExpressionProperty); }
            set { this.MSetValue(MetaIndexerExpressionImpl.ExpressionProperty, value); }
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty ArgumentsProperty =
            ModelProperty.Register("Arguments", typeof(IList<MetaExpression>), typeof(MetaIndexerExpressionImpl));
        IList<MetaExpression> MetaIndexerExpression.Arguments
        {
            get { return (IList<MetaExpression>)this.MGetValue(MetaIndexerExpressionImpl.ArgumentsProperty); }
        }
    }
    
    public interface MetaConditionalExpression : MetaDslx.Core.MetaExpression
    {
        MetaExpression Condition { get; set; }
        MetaType BalancedType { get; set; }
        MetaExpression Then { get; set; }
        MetaExpression Else { get; set; }
    
    }
    
    internal class MetaConditionalExpressionImpl : ModelObject, MetaDslx.Core.MetaConditionalExpression
    {
        static MetaConditionalExpressionImpl()
        {
    		ModelProperty.RegisterAncestor(typeof(MetaConditionalExpressionImpl), typeof(MetaExpressionImpl));
        }
    
        public MetaConditionalExpressionImpl()
        {
            this.MInitValue(MetaExpressionImpl.TypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Type(this)));
            this.MInitValue(MetaExpressionImpl.ExpectedTypeProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_ExpectedType(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionsProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definitions(this)));
            this.MInitValue(MetaExpressionImpl.DefinitionProperty, new Lazy<object>(() => MetaModelImplementationProvider.Implementation.MetaExpression_Definition(this)));
            MetaModelImplementationProvider.Implementation.MetaConditionalExpression_MetaConditionalExpression(this);
            this.MMakeDefault();
        }
        
        MetaExpressionKind MetaExpression.Kind
        {
            get { return (MetaExpressionKind)this.MGetValue(MetaExpressionImpl.KindProperty); }
            set { this.MSetValue(MetaExpressionImpl.KindProperty, value); }
        }
        
        MetaType MetaExpression.Type
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.TypeProperty); }
        }
        
        MetaType MetaExpression.ExpectedType
        {
            get { return (MetaType)this.MGetValue(MetaExpressionImpl.ExpectedTypeProperty); }
        }
        
        IList<MetaScopeEntry> MetaExpression.Definitions
        {
            get { return (IList<MetaScopeEntry>)this.MGetValue(MetaExpressionImpl.DefinitionsProperty); }
        }
        
        MetaScopeEntry MetaExpression.Definition
        {
            get { return (MetaScopeEntry)this.MGetValue(MetaExpressionImpl.DefinitionProperty); }
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty ConditionProperty =
            ModelProperty.Register("Condition", typeof(MetaExpression), typeof(MetaConditionalExpressionImpl));
        MetaExpression MetaConditionalExpression.Condition
        {
            get { return (MetaExpression)this.MGetValue(MetaConditionalExpressionImpl.ConditionProperty); }
            set { this.MSetValue(MetaConditionalExpressionImpl.ConditionProperty, value); }
        }
        
        internal static readonly ModelProperty BalancedTypeProperty =
            ModelProperty.Register("BalancedType", typeof(MetaType), typeof(MetaConditionalExpressionImpl));
        MetaType MetaConditionalExpression.BalancedType
        {
            get { return (MetaType)this.MGetValue(MetaConditionalExpressionImpl.BalancedTypeProperty); }
            set { this.MSetValue(MetaConditionalExpressionImpl.BalancedTypeProperty, value); }
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty ThenProperty =
            ModelProperty.Register("Then", typeof(MetaExpression), typeof(MetaConditionalExpressionImpl));
        MetaExpression MetaConditionalExpression.Then
        {
            get { return (MetaExpression)this.MGetValue(MetaConditionalExpressionImpl.ThenProperty); }
            set { this.MSetValue(MetaConditionalExpressionImpl.ThenProperty, value); }
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty ElseProperty =
            ModelProperty.Register("Else", typeof(MetaExpression), typeof(MetaConditionalExpressionImpl));
        MetaExpression MetaConditionalExpression.Else
        {
            get { return (MetaExpression)this.MGetValue(MetaConditionalExpressionImpl.ElseProperty); }
            set { this.MSetValue(MetaConditionalExpressionImpl.ElseProperty, value); }
        }
    }
    
    /// <summary>
    /// Factory class for creating instances of model elements.
    /// </summary>
    public class MetaModelFactory : ModelFactory
    {
        private static MetaModelFactory instance = new MetaModelFactory();
    
    	private MetaModelFactory()
    	{
    	}
    
        /// <summary>
        /// The singleton instance of the factory.
        /// </summary>
        public static MetaModelFactory Instance
        {
            get { return MetaModelFactory.instance; }
        }
    
        /// <summary>
        /// Creates a new instance of MetaScopeEntry.
        /// </summary>
        public MetaScopeEntry CreateMetaScopeEntry()
    	{
    		MetaScopeEntry result = new MetaScopeEntryImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaNamedElement.
        /// </summary>
        public MetaNamedElement CreateMetaNamedElement()
    	{
    		MetaNamedElement result = new MetaNamedElementImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaTypedElement.
        /// </summary>
        public MetaTypedElement CreateMetaTypedElement()
    	{
    		MetaTypedElement result = new MetaTypedElementImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaType.
        /// </summary>
        public MetaType CreateMetaType()
    	{
    		MetaType result = new MetaTypeImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaScope.
        /// </summary>
        public MetaScope CreateMetaScope()
    	{
    		MetaScope result = new MetaScopeImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaNamespace.
        /// </summary>
        public MetaNamespace CreateMetaNamespace()
    	{
    		MetaNamespace result = new MetaNamespaceImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaModel.
        /// </summary>
        public MetaModel CreateMetaModel()
    	{
    		MetaModel result = new MetaModelImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaDeclaration.
        /// </summary>
        public MetaDeclaration CreateMetaDeclaration()
    	{
    		MetaDeclaration result = new MetaDeclarationImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaCollectionType.
        /// </summary>
        public MetaCollectionType CreateMetaCollectionType()
    	{
    		MetaCollectionType result = new MetaCollectionTypeImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaNullableType.
        /// </summary>
        public MetaNullableType CreateMetaNullableType()
    	{
    		MetaNullableType result = new MetaNullableTypeImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaPrimitiveType.
        /// </summary>
        public MetaPrimitiveType CreateMetaPrimitiveType()
    	{
    		MetaPrimitiveType result = new MetaPrimitiveTypeImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaEnum.
        /// </summary>
        public MetaEnum CreateMetaEnum()
    	{
    		MetaEnum result = new MetaEnumImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaEnumLiteral.
        /// </summary>
        public MetaEnumLiteral CreateMetaEnumLiteral()
    	{
    		MetaEnumLiteral result = new MetaEnumLiteralImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaClass.
        /// </summary>
        public MetaClass CreateMetaClass()
    	{
    		MetaClass result = new MetaClassImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaOperation.
        /// </summary>
        public MetaOperation CreateMetaOperation()
    	{
    		MetaOperation result = new MetaOperationImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaParameter.
        /// </summary>
        public MetaParameter CreateMetaParameter()
    	{
    		MetaParameter result = new MetaParameterImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaProperty.
        /// </summary>
        public MetaProperty CreateMetaProperty()
    	{
    		MetaProperty result = new MetaPropertyImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaPropertyInitializer.
        /// </summary>
        public MetaPropertyInitializer CreateMetaPropertyInitializer()
    	{
    		MetaPropertyInitializer result = new MetaPropertyInitializerImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaSynthetizedPropertyInitializer.
        /// </summary>
        public MetaSynthetizedPropertyInitializer CreateMetaSynthetizedPropertyInitializer()
    	{
    		MetaSynthetizedPropertyInitializer result = new MetaSynthetizedPropertyInitializerImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaInheritedPropertyInitializer.
        /// </summary>
        public MetaInheritedPropertyInitializer CreateMetaInheritedPropertyInitializer()
    	{
    		MetaInheritedPropertyInitializer result = new MetaInheritedPropertyInitializerImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaExpression.
        /// </summary>
        public MetaExpression CreateMetaExpression()
    	{
    		MetaExpression result = new MetaExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaUnaryExpression.
        /// </summary>
        public MetaUnaryExpression CreateMetaUnaryExpression()
    	{
    		MetaUnaryExpression result = new MetaUnaryExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaBinaryExpression.
        /// </summary>
        public MetaBinaryExpression CreateMetaBinaryExpression()
    	{
    		MetaBinaryExpression result = new MetaBinaryExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaBinaryArithmeticExpression.
        /// </summary>
        public MetaBinaryArithmeticExpression CreateMetaBinaryArithmeticExpression()
    	{
    		MetaBinaryArithmeticExpression result = new MetaBinaryArithmeticExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaBinaryComparisonExpression.
        /// </summary>
        public MetaBinaryComparisonExpression CreateMetaBinaryComparisonExpression()
    	{
    		MetaBinaryComparisonExpression result = new MetaBinaryComparisonExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaBinaryLogicalExpression.
        /// </summary>
        public MetaBinaryLogicalExpression CreateMetaBinaryLogicalExpression()
    	{
    		MetaBinaryLogicalExpression result = new MetaBinaryLogicalExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaAssignmentExpression.
        /// </summary>
        public MetaAssignmentExpression CreateMetaAssignmentExpression()
    	{
    		MetaAssignmentExpression result = new MetaAssignmentExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaTypeConversionExpression.
        /// </summary>
        public MetaTypeConversionExpression CreateMetaTypeConversionExpression()
    	{
    		MetaTypeConversionExpression result = new MetaTypeConversionExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaTypeCheckExpression.
        /// </summary>
        public MetaTypeCheckExpression CreateMetaTypeCheckExpression()
    	{
    		MetaTypeCheckExpression result = new MetaTypeCheckExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaTypeOfExpression.
        /// </summary>
        public MetaTypeOfExpression CreateMetaTypeOfExpression()
    	{
    		MetaTypeOfExpression result = new MetaTypeOfExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaConstantExpression.
        /// </summary>
        public MetaConstantExpression CreateMetaConstantExpression()
    	{
    		MetaConstantExpression result = new MetaConstantExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaIdentifierExpression.
        /// </summary>
        public MetaIdentifierExpression CreateMetaIdentifierExpression()
    	{
    		MetaIdentifierExpression result = new MetaIdentifierExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaMemberAccessExpression.
        /// </summary>
        public MetaMemberAccessExpression CreateMetaMemberAccessExpression()
    	{
    		MetaMemberAccessExpression result = new MetaMemberAccessExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaFunctionCallExpression.
        /// </summary>
        public MetaFunctionCallExpression CreateMetaFunctionCallExpression()
    	{
    		MetaFunctionCallExpression result = new MetaFunctionCallExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaIndexerExpression.
        /// </summary>
        public MetaIndexerExpression CreateMetaIndexerExpression()
    	{
    		MetaIndexerExpression result = new MetaIndexerExpressionImpl();
    		return result;
    	}
    
    
        /// <summary>
        /// Creates a new instance of MetaConditionalExpression.
        /// </summary>
        public MetaConditionalExpression CreateMetaConditionalExpression()
    	{
    		MetaConditionalExpression result = new MetaConditionalExpressionImpl();
    		return result;
    	}
    
    }
    
    internal static class MetaModelImplementationProvider
    {
        // If there is a compile error at this line, create a new class called MetaModelImplementation
    	// which is a subclass of MetaModelImplementationBase:
        private static MetaModelImplementation implementation = new MetaModelImplementation();
    
        public static MetaModelImplementation Implementation
        {
            get { return MetaModelImplementationProvider.implementation; }
        }
    }
    
    public static class MetaModelCollectionKindExtensions
    {
    }
    
    public static class MetaModelPropertyKindExtensions
    {
    }
    
    public static class MetaModelExpressionKindExtensions
    {
    }
    
    /// <summary>
    /// Base class for implementing the behavior of the model elements.
    /// This class has to be be overriden in MetaModelImplementation to provide custom
    /// implementation for the constructors, operations and property values.
    /// </summary>
    internal abstract class MetaModelImplementationBase
    {
        /// <summary>
    	/// Implements the constructor: MetaScopeEntry()
        /// </summary>
        public virtual void MetaScopeEntry_MetaScopeEntry(MetaScopeEntry @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNamedElement()
    	/// Direct superclasses: MetaScopeEntry
    	/// All superclasses: MetaScopeEntry
        /// </summary>
        public virtual void MetaNamedElement_MetaNamedElement(MetaNamedElement @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypedElement()
    	/// Direct superclasses: MetaScopeEntry
    	/// All superclasses: MetaScopeEntry
        /// </summary>
        public virtual void MetaTypedElement_MetaTypedElement(MetaTypedElement @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaType()
    	/// Direct superclasses: MetaScopeEntry
    	/// All superclasses: MetaScopeEntry
        /// </summary>
        public virtual void MetaType_MetaType(MetaType @this)
        {
        }
    
        /// <summary>
        /// Implements the operation: MetaType.IsAssignableFrom()
        /// </summary>
        public virtual bool MetaType_IsAssignableFrom(MetaType @this, MetaType valueType)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Implements the operation: MetaType.Equals()
        /// </summary>
        public virtual bool MetaType_Equals(MetaType @this, MetaType otherType)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
    	/// Implements the constructor: MetaScope()
    	/// Direct superclasses: MetaScopeEntry
    	/// All superclasses: MetaScopeEntry
        /// </summary>
        public virtual void MetaScope_MetaScope(MetaScope @this)
        {
        }
    
        /// <summary>
        /// Implements the operation: MetaScope.ResolveEntries()
        /// </summary>
        public virtual IList<MetaScopeEntry> MetaScope_ResolveEntries(MetaScope @this, string name)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Implements the operation: MetaScope.GetEntries()
        /// </summary>
        public virtual IList<MetaScopeEntry> MetaScope_GetEntries(MetaScope @this, string name)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNamespace()
    	/// Direct superclasses: MetaNamedElement, MetaScope
    	/// All superclasses: MetaScopeEntry, MetaNamedElement, MetaScope
        /// </summary>
        public virtual void MetaNamespace_MetaNamespace(MetaNamespace @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaModel()
    	/// Direct superclasses: MetaType, MetaNamedElement, MetaScope
    	/// All superclasses: MetaScopeEntry, MetaType, MetaNamedElement, MetaScope
        /// </summary>
        public virtual void MetaModel_MetaModel(MetaModel @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaDeclaration()
    	/// Direct superclasses: MetaScopeEntry
    	/// All superclasses: MetaScopeEntry
        /// </summary>
        public virtual void MetaDeclaration_MetaDeclaration(MetaDeclaration @this)
        {
        }
    
        /// <summary>
        /// Returns the value of the derived property: MetaDeclaration.Namespace
        /// </summary>
        public virtual MetaNamespace MetaDeclaration_Namespace(MetaDeclaration @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
    	/// Implements the constructor: MetaCollectionType()
    	/// Direct superclasses: MetaType
    	/// All superclasses: MetaScopeEntry, MetaType
        /// </summary>
        public virtual void MetaCollectionType_MetaCollectionType(MetaCollectionType @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNullableType()
    	/// Direct superclasses: MetaType
    	/// All superclasses: MetaScopeEntry, MetaType
        /// </summary>
        public virtual void MetaNullableType_MetaNullableType(MetaNullableType @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaPrimitiveType()
    	/// Direct superclasses: MetaType, MetaNamedElement
    	/// All superclasses: MetaScopeEntry, MetaType, MetaNamedElement
        /// </summary>
        public virtual void MetaPrimitiveType_MetaPrimitiveType(MetaPrimitiveType @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaEnum()
    	/// Direct superclasses: MetaType, MetaNamedElement, MetaScope, MetaDeclaration
    	/// All superclasses: MetaScopeEntry, MetaType, MetaNamedElement, MetaScope, MetaDeclaration
        /// </summary>
        public virtual void MetaEnum_MetaEnum(MetaEnum @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaEnumLiteral()
    	/// Direct superclasses: MetaNamedElement
    	/// All superclasses: MetaScopeEntry, MetaNamedElement
        /// </summary>
        public virtual void MetaEnumLiteral_MetaEnumLiteral(MetaEnumLiteral @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaClass()
    	/// Direct superclasses: MetaType, MetaNamedElement, MetaScope, MetaDeclaration
    	/// All superclasses: MetaScopeEntry, MetaType, MetaNamedElement, MetaScope, MetaDeclaration
        /// </summary>
        public virtual void MetaClass_MetaClass(MetaClass @this)
        {
        }
    
        /// <summary>
        /// Implements the operation: MetaClass.GetAllSuperClasses()
        /// </summary>
        public virtual IList<MetaClass> MetaClass_GetAllSuperClasses(MetaClass @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Implements the operation: MetaClass.GetAllProperties()
        /// </summary>
        public virtual IList<MetaProperty> MetaClass_GetAllProperties(MetaClass @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Implements the operation: MetaClass.GetAllOperations()
        /// </summary>
        public virtual IList<MetaOperation> MetaClass_GetAllOperations(MetaClass @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOperation()
    	/// Direct superclasses: MetaNamedElement
    	/// All superclasses: MetaScopeEntry, MetaNamedElement
        /// </summary>
        public virtual void MetaOperation_MetaOperation(MetaOperation @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaParameter()
    	/// Direct superclasses: MetaNamedElement, MetaTypedElement
    	/// All superclasses: MetaScopeEntry, MetaNamedElement, MetaTypedElement
        /// </summary>
        public virtual void MetaParameter_MetaParameter(MetaParameter @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaProperty()
    	/// Direct superclasses: MetaNamedElement, MetaTypedElement
    	/// All superclasses: MetaScopeEntry, MetaNamedElement, MetaTypedElement
        /// </summary>
        public virtual void MetaProperty_MetaProperty(MetaProperty @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaPropertyInitializer()
        /// </summary>
        public virtual void MetaPropertyInitializer_MetaPropertyInitializer(MetaPropertyInitializer @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaSynthetizedPropertyInitializer()
    	/// Direct superclasses: MetaPropertyInitializer
    	/// All superclasses: MetaPropertyInitializer
        /// </summary>
        public virtual void MetaSynthetizedPropertyInitializer_MetaSynthetizedPropertyInitializer(MetaSynthetizedPropertyInitializer @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaInheritedPropertyInitializer()
    	/// Direct superclasses: MetaPropertyInitializer
    	/// All superclasses: MetaPropertyInitializer
        /// </summary>
        public virtual void MetaInheritedPropertyInitializer_MetaInheritedPropertyInitializer(MetaInheritedPropertyInitializer @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaExpression()
        /// </summary>
        public virtual void MetaExpression_MetaExpression(MetaExpression @this)
        {
        }
    
        /// <summary>
        /// Returns the value of the lazy property: MetaExpression.Type
        /// </summary>
        public virtual MetaType MetaExpression_Type(MetaExpression @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Returns the value of the lazy property: MetaExpression.ExpectedType
        /// </summary>
        public virtual MetaType MetaExpression_ExpectedType(MetaExpression @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Returns the value of the lazy property: MetaExpression.Definitions
        /// </summary>
        public virtual IList<MetaScopeEntry> MetaExpression_Definitions(MetaExpression @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Returns the value of the lazy property: MetaExpression.Definition
        /// </summary>
        public virtual MetaScopeEntry MetaExpression_Definition(MetaExpression @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
    	/// Implements the constructor: MetaUnaryExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaUnaryExpression_MetaUnaryExpression(MetaUnaryExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaBinaryExpression_MetaBinaryExpression(MetaBinaryExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryArithmeticExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaExpression, MetaBinaryExpression
        /// </summary>
        public virtual void MetaBinaryArithmeticExpression_MetaBinaryArithmeticExpression(MetaBinaryArithmeticExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryComparisonExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaExpression, MetaBinaryExpression
        /// </summary>
        public virtual void MetaBinaryComparisonExpression_MetaBinaryComparisonExpression(MetaBinaryComparisonExpression @this)
        {
        }
    
        /// <summary>
        /// Returns the value of the lazy property: MetaBinaryComparisonExpression.BalancedType
        /// </summary>
        public virtual MetaType MetaBinaryComparisonExpression_BalancedType(MetaBinaryComparisonExpression @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
    	/// Implements the constructor: MetaBinaryLogicalExpression()
    	/// Direct superclasses: MetaBinaryExpression
    	/// All superclasses: MetaExpression, MetaBinaryExpression
        /// </summary>
        public virtual void MetaBinaryLogicalExpression_MetaBinaryLogicalExpression(MetaBinaryLogicalExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaAssignmentExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaAssignmentExpression_MetaAssignmentExpression(MetaAssignmentExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeConversionExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaTypeConversionExpression_MetaTypeConversionExpression(MetaTypeConversionExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeCheckExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaTypeCheckExpression_MetaTypeCheckExpression(MetaTypeCheckExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaTypeOfExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaTypeOfExpression_MetaTypeOfExpression(MetaTypeOfExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaConstantExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaConstantExpression_MetaConstantExpression(MetaConstantExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaIdentifierExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaIdentifierExpression_MetaIdentifierExpression(MetaIdentifierExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaMemberAccessExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaMemberAccessExpression_MetaMemberAccessExpression(MetaMemberAccessExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaFunctionCallExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaFunctionCallExpression_MetaFunctionCallExpression(MetaFunctionCallExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaIndexerExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaIndexerExpression_MetaIndexerExpression(MetaIndexerExpression @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaConditionalExpression()
    	/// Direct superclasses: MetaExpression
    	/// All superclasses: MetaExpression
        /// </summary>
        public virtual void MetaConditionalExpression_MetaConditionalExpression(MetaConditionalExpression @this)
        {
        }
    
    
    
    
    }
    
}

