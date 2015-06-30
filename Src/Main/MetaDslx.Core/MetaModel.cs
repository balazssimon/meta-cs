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
    }
    
    public interface MetaNamespace
    {
        string Name { get; set; }
        string Uri { get; set; }
        MetaNamespace Parent { get; }
        ICollection<MetaNamespace> Namespaces { get; }
        ICollection<MetaModel> Models { get; }
    
    }
    
    internal class MetaNamespaceImpl : ModelObject, MetaNamespace
    {
    
    	public static void TriggerStaticInitialization()
    	{
    	}
    
        public MetaNamespaceImpl()
        {
            this.MSetValue(MetaNamespaceImpl.ModelsProperty, new ModelSet<MetaModel>(this, MetaNamespaceImpl.ModelsProperty));
            MetaImplementationProvider.Implementation.MetaNamespace_MetaNamespace(this);
        }
        
        internal static readonly ModelProperty NameProperty =
            ModelProperty.Register("Name", typeof(string), typeof(MetaNamespaceImpl));
        public string Name
        {
            get { return (string)this.MGetValue(MetaNamespaceImpl.NameProperty); }
            set { this.MSetValue(MetaNamespaceImpl.NameProperty, value); }
        }
        
        internal static readonly ModelProperty UriProperty =
            ModelProperty.Register("Uri", typeof(string), typeof(MetaNamespaceImpl));
        public string Uri
        {
            get { return (string)this.MGetValue(MetaNamespaceImpl.UriProperty); }
            set { this.MSetValue(MetaNamespaceImpl.UriProperty, value); }
        }

        [OppositeAttribute(typeof(MetaModelImpl), "Namespaces")]
        internal static readonly ModelProperty ParentProperty =
            ModelProperty.Register("Parent", typeof(MetaNamespace), typeof(MetaNamespaceImpl));
        public MetaNamespace Parent
        {
            get { return (MetaNamespace)this.MGetValue(MetaNamespaceImpl.ParentProperty); }
            set { this.MSetValue(MetaNamespaceImpl.ParentProperty, value); }
        }

        [ContainmentAttribute]
        [OppositeAttribute(typeof(MetaModelImpl), "Namespace")]
        internal static readonly ModelProperty ModelsProperty =
            ModelProperty.Register("Models", typeof(ICollection<MetaModel>), typeof(MetaNamespaceImpl));
        public ICollection<MetaModel> Models
        {
            get { return (ICollection<MetaModel>)this.MGetValue(MetaNamespaceImpl.ModelsProperty); }
        }
        
        [ContainmentAttribute]
        [OppositeAttribute(typeof(MetaModelImpl), "Parent")]
        internal static readonly ModelProperty NamespacesProperty =
            ModelProperty.Register("Namespaces", typeof(ICollection<MetaNamespace>), typeof(MetaNamespaceImpl));
        public ICollection<MetaNamespace> Namespaces
        {
            get { return (ICollection<MetaNamespace>)this.MGetValue(MetaNamespaceImpl.NamespacesProperty); }
        }
    }
    
    public interface MetaModel
    {
        string Name { get; set; }
        MetaNamespace Namespace { get; set; }
        ICollection<MetaType> Types { get; }
    
    }
    
    internal class MetaModelImpl : ModelObject, MetaModel
    {
    
    	public static void TriggerStaticInitialization()
    	{
    	}
    
        public MetaModelImpl()
        {
            this.MSetValue(MetaModelImpl.TypesProperty, new ModelSet<MetaType>(this, MetaModelImpl.TypesProperty));
            MetaImplementationProvider.Implementation.MetaModel_MetaModel(this);
        }
        
        internal static readonly ModelProperty NameProperty =
            ModelProperty.Register("Name", typeof(string), typeof(MetaModelImpl));
        public string Name
        {
            get { return (string)this.MGetValue(MetaModelImpl.NameProperty); }
            set { this.MSetValue(MetaModelImpl.NameProperty, value); }
        }
        
        [OppositeAttribute(typeof(MetaNamespaceImpl), "Models")]
        internal static readonly ModelProperty NamespaceProperty =
            ModelProperty.Register("Namespace", typeof(MetaNamespace), typeof(MetaModelImpl));
        public MetaNamespace Namespace
        {
            get { return (MetaNamespace)this.MGetValue(MetaModelImpl.NamespaceProperty); }
            set { this.MSetValue(MetaModelImpl.NamespaceProperty, value); }
        }
        
        [ContainmentAttribute]
        [OppositeAttribute(typeof(MetaTypeImpl), "Model")]
        internal static readonly ModelProperty TypesProperty =
            ModelProperty.Register("Types", typeof(ICollection<MetaType>), typeof(MetaModelImpl));
        public ICollection<MetaType> Types
        {
            get { return (ICollection<MetaType>)this.MGetValue(MetaModelImpl.TypesProperty); }
        }
    }
    
    public interface MetaType
    {
        string Name { get; set; }
        MetaModel Model { get; set; }
        MetaNamespace Namespace { get; }
    
    }
    
    internal class MetaTypeImpl : ModelObject, MetaType
    {
    
    	public static void TriggerStaticInitialization()
    	{
    	}
    
        public MetaTypeImpl()
        {
            MetaImplementationProvider.Implementation.MetaType_MetaType(this);
        }
        
        internal static readonly ModelProperty NameProperty =
            ModelProperty.Register("Name", typeof(string), typeof(MetaTypeImpl));
        public string Name
        {
            get { return (string)this.MGetValue(MetaTypeImpl.NameProperty); }
            set { this.MSetValue(MetaTypeImpl.NameProperty, value); }
        }
        
        [OppositeAttribute(typeof(MetaModelImpl), "Types")]
        internal static readonly ModelProperty ModelProperty =
            ModelProperty.Register("Model", typeof(MetaModel), typeof(MetaTypeImpl));
        public MetaModel Model
        {
            get { return (MetaModel)this.MGetValue(MetaTypeImpl.ModelProperty); }
            set { this.MSetValue(MetaTypeImpl.ModelProperty, value); }
        }
        
        [ReadonlyAttribute]
        internal static readonly ModelProperty NamespaceProperty =
            ModelProperty.Register("Namespace", typeof(MetaNamespace), typeof(MetaTypeImpl));
        public MetaNamespace Namespace
        {
            get { return MetaImplementationProvider.Implementation.MetaType_Namespace(this); }
        }
    }
    
    public interface MetaCollectionType : MetaType
    {
        MetaCollectionKind Kind { get; set; }
        MetaType InnerType { get; set; }
    
    }
    
    internal class MetaCollectionTypeImpl : ModelObject, MetaCollectionType
    {
        static MetaCollectionTypeImpl()
        {
    		MetaTypeImpl.TriggerStaticInitialization();
    		ModelProperty.RegisterAncestor(typeof(MetaCollectionTypeImpl), typeof(MetaTypeImpl));
        }
    
    	public static void TriggerStaticInitialization()
    	{
    	}
    
        public MetaCollectionTypeImpl()
        {
            MetaImplementationProvider.Implementation.MetaCollectionType_MetaCollectionType(this);
        }
        
        internal static readonly ModelProperty KindProperty =
            ModelProperty.Register("Kind", typeof(MetaCollectionKind), typeof(MetaCollectionTypeImpl));
        public MetaCollectionKind Kind
        {
            get { return (MetaCollectionKind)this.MGetValue(MetaCollectionTypeImpl.KindProperty); }
            set { this.MSetValue(MetaCollectionTypeImpl.KindProperty, value); }
        }
        
        internal static readonly ModelProperty InnerTypeProperty =
            ModelProperty.Register("InnerType", typeof(MetaType), typeof(MetaCollectionTypeImpl));
        public MetaType InnerType
        {
            get { return (MetaType)this.MGetValue(MetaCollectionTypeImpl.InnerTypeProperty); }
            set { this.MSetValue(MetaCollectionTypeImpl.InnerTypeProperty, value); }
        }
        
        public string Name
        {
            get { return (string)this.MGetValue(MetaTypeImpl.NameProperty); }
            set { this.MSetValue(MetaTypeImpl.NameProperty, value); }
        }
        
        public MetaModel Model
        {
            get { return (MetaModel)this.MGetValue(MetaTypeImpl.ModelProperty); }
            set { this.MSetValue(MetaTypeImpl.ModelProperty, value); }
        }
        
        public MetaNamespace Namespace
        {
            get { return MetaImplementationProvider.Implementation.MetaType_Namespace(this); }
        }

        public override bool Equals(object obj)
        {
            MetaCollectionType rhs = obj as MetaCollectionType;
            if (rhs == null) return false;
            return this.Kind == rhs.Kind && this.InnerType == rhs.InnerType;
        }
    }
    
    public interface MetaNullableType : MetaType
    {
        MetaType InnerType { get; set; }
    
    }
    
    internal class MetaNullableTypeImpl : ModelObject, MetaNullableType
    {
        static MetaNullableTypeImpl()
        {
    		MetaTypeImpl.TriggerStaticInitialization();
    		ModelProperty.RegisterAncestor(typeof(MetaNullableTypeImpl), typeof(MetaTypeImpl));
        }
    
    	public static void TriggerStaticInitialization()
    	{
    	}
    
        public MetaNullableTypeImpl()
        {
            MetaImplementationProvider.Implementation.MetaNullableType_MetaNullableType(this);
        }
        
        internal static readonly ModelProperty InnerTypeProperty =
            ModelProperty.Register("InnerType", typeof(MetaType), typeof(MetaNullableTypeImpl));
        public MetaType InnerType
        {
            get { return (MetaType)this.MGetValue(MetaNullableTypeImpl.InnerTypeProperty); }
            set { this.MSetValue(MetaNullableTypeImpl.InnerTypeProperty, value); }
        }
        
        public string Name
        {
            get { return (string)this.MGetValue(MetaTypeImpl.NameProperty); }
            set { this.MSetValue(MetaTypeImpl.NameProperty, value); }
        }
        
        public MetaModel Model
        {
            get { return (MetaModel)this.MGetValue(MetaTypeImpl.ModelProperty); }
            set { this.MSetValue(MetaTypeImpl.ModelProperty, value); }
        }
        
        public MetaNamespace Namespace
        {
            get { return MetaImplementationProvider.Implementation.MetaType_Namespace(this); }
        }

        public override bool Equals(object obj)
        {
            MetaNullableType rhs = obj as MetaNullableType;
            if (rhs == null) return false;
            return this.InnerType == rhs.InnerType;
        }
    }
    
    public interface MetaPrimitiveType : MetaType
    {
    
    }
    
    internal class MetaPrimitiveTypeImpl : ModelObject, MetaPrimitiveType
    {
        static MetaPrimitiveTypeImpl()
        {
    		MetaTypeImpl.TriggerStaticInitialization();
    		ModelProperty.RegisterAncestor(typeof(MetaPrimitiveTypeImpl), typeof(MetaTypeImpl));
        }
    
    	public static void TriggerStaticInitialization()
    	{
    	}
    
        public MetaPrimitiveTypeImpl()
        {
            MetaImplementationProvider.Implementation.MetaPrimitiveType_MetaPrimitiveType(this);
        }
        
        public string Name
        {
            get { return (string)this.MGetValue(MetaTypeImpl.NameProperty); }
            set { this.MSetValue(MetaTypeImpl.NameProperty, value); }
        }
        
        public MetaModel Model
        {
            get { return (MetaModel)this.MGetValue(MetaTypeImpl.ModelProperty); }
            set { this.MSetValue(MetaTypeImpl.ModelProperty, value); }
        }
        
        public MetaNamespace Namespace
        {
            get { return MetaImplementationProvider.Implementation.MetaType_Namespace(this); }
        }

        public override bool Equals(object obj)
        {
            MetaPrimitiveType rhs = obj as MetaPrimitiveType;
            if (rhs == null) return false;
            return this.Name == rhs.Name;
        }
    }
    
    public interface MetaEnum : MetaType
    {
        IList<MetaEnumLiteral> EnumLiterals { get; }
        ICollection<MetaOperation> Operations { get; }
    
    }
    
    internal class MetaEnumImpl : ModelObject, MetaEnum
    {
        static MetaEnumImpl()
        {
    		MetaTypeImpl.TriggerStaticInitialization();
    		ModelProperty.RegisterAncestor(typeof(MetaEnumImpl), typeof(MetaTypeImpl));
        }
    
    	public static void TriggerStaticInitialization()
    	{
    	}
    
        public MetaEnumImpl()
        {
            this.MSetValue(MetaEnumImpl.EnumLiteralsProperty, new ModelList<MetaEnumLiteral>(this, MetaEnumImpl.EnumLiteralsProperty));
            this.MSetValue(MetaEnumImpl.OperationsProperty, new ModelSet<MetaOperation>(this, MetaEnumImpl.OperationsProperty));
            MetaImplementationProvider.Implementation.MetaEnum_MetaEnum(this);
        }
        
        [ContainmentAttribute]
        internal static readonly ModelProperty EnumLiteralsProperty =
            ModelProperty.Register("EnumLiterals", typeof(IList<MetaEnumLiteral>), typeof(MetaEnumImpl));
        public IList<MetaEnumLiteral> EnumLiterals
        {
            get { return (IList<MetaEnumLiteral>)this.MGetValue(MetaEnumImpl.EnumLiteralsProperty); }
        }
        
        [ContainmentAttribute]
        [OppositeAttribute(typeof(MetaOperationImpl), "Enum")]
        internal static readonly ModelProperty OperationsProperty =
            ModelProperty.Register("Operations", typeof(ICollection<MetaOperation>), typeof(MetaEnumImpl));
        public ICollection<MetaOperation> Operations
        {
            get { return (ICollection<MetaOperation>)this.MGetValue(MetaEnumImpl.OperationsProperty); }
        }
        
        public string Name
        {
            get { return (string)this.MGetValue(MetaTypeImpl.NameProperty); }
            set { this.MSetValue(MetaTypeImpl.NameProperty, value); }
        }
        
        public MetaModel Model
        {
            get { return (MetaModel)this.MGetValue(MetaTypeImpl.ModelProperty); }
            set { this.MSetValue(MetaTypeImpl.ModelProperty, value); }
        }
        
        public MetaNamespace Namespace
        {
            get { return MetaImplementationProvider.Implementation.MetaType_Namespace(this); }
        }
    }
    
    public interface MetaEnumLiteral
    {
        string Name { get; set; }
    
    }
    
    internal class MetaEnumLiteralImpl : ModelObject, MetaEnumLiteral
    {
    
    	public static void TriggerStaticInitialization()
    	{
    	}
    
        public MetaEnumLiteralImpl()
        {
            MetaImplementationProvider.Implementation.MetaEnumLiteral_MetaEnumLiteral(this);
        }
        
        internal static readonly ModelProperty NameProperty =
            ModelProperty.Register("Name", typeof(string), typeof(MetaEnumLiteralImpl));
        public string Name
        {
            get { return (string)this.MGetValue(MetaEnumLiteralImpl.NameProperty); }
            set { this.MSetValue(MetaEnumLiteralImpl.NameProperty, value); }
        }
    }
    
    public interface MetaClass : MetaType
    {
        IList<MetaClass> SuperClasses { get; }
        ICollection<MetaProperty> Properties { get; }
        ICollection<MetaOperation> Operations { get; }
    
        ICollection<MetaClass> GetAllSuperClasses();
        ICollection<MetaProperty> GetAllProperties();
        ICollection<MetaOperation> GetAllOperations();
    }
    
    internal class MetaClassImpl : ModelObject, MetaClass
    {
        static MetaClassImpl()
        {
    		MetaTypeImpl.TriggerStaticInitialization();
    		ModelProperty.RegisterAncestor(typeof(MetaClassImpl), typeof(MetaTypeImpl));
        }
    
    	public static void TriggerStaticInitialization()
    	{
    	}
    
        public MetaClassImpl()
        {
            this.MSetValue(MetaClassImpl.SuperClassesProperty, new ModelList<MetaClass>(this, MetaClassImpl.SuperClassesProperty));
            this.MSetValue(MetaClassImpl.PropertiesProperty, new ModelSet<MetaProperty>(this, MetaClassImpl.PropertiesProperty));
            this.MSetValue(MetaClassImpl.OperationsProperty, new ModelSet<MetaOperation>(this, MetaClassImpl.OperationsProperty));
            MetaImplementationProvider.Implementation.MetaClass_MetaClass(this);
        }
        
        internal static readonly ModelProperty SuperClassesProperty =
            ModelProperty.Register("SuperClasses", typeof(IList<MetaClass>), typeof(MetaClassImpl));
        public IList<MetaClass> SuperClasses
        {
            get { return (IList<MetaClass>)this.MGetValue(MetaClassImpl.SuperClassesProperty); }
        }
        
        [ContainmentAttribute]
        [OppositeAttribute(typeof(MetaPropertyImpl), "Class")]
        internal static readonly ModelProperty PropertiesProperty =
            ModelProperty.Register("Properties", typeof(ICollection<MetaProperty>), typeof(MetaClassImpl));
        public ICollection<MetaProperty> Properties
        {
            get { return (ICollection<MetaProperty>)this.MGetValue(MetaClassImpl.PropertiesProperty); }
        }
        
        [ContainmentAttribute]
        [OppositeAttribute(typeof(MetaOperationImpl), "Class")]
        internal static readonly ModelProperty OperationsProperty =
            ModelProperty.Register("Operations", typeof(ICollection<MetaOperation>), typeof(MetaClassImpl));
        public ICollection<MetaOperation> Operations
        {
            get { return (ICollection<MetaOperation>)this.MGetValue(MetaClassImpl.OperationsProperty); }
        }
        
        public string Name
        {
            get { return (string)this.MGetValue(MetaTypeImpl.NameProperty); }
            set { this.MSetValue(MetaTypeImpl.NameProperty, value); }
        }
        
        public MetaModel Model
        {
            get { return (MetaModel)this.MGetValue(MetaTypeImpl.ModelProperty); }
            set { this.MSetValue(MetaTypeImpl.ModelProperty, value); }
        }
        
        public MetaNamespace Namespace
        {
            get { return MetaImplementationProvider.Implementation.MetaType_Namespace(this); }
        }
        
        public ICollection<MetaClass> GetAllSuperClasses()
        {
            return MetaImplementationProvider.Implementation.MetaClass_GetAllSuperClasses(this);
        }
        
        public ICollection<MetaProperty> GetAllProperties()
        {
            return MetaImplementationProvider.Implementation.MetaClass_GetAllProperties(this);
        }
        
        public ICollection<MetaOperation> GetAllOperations()
        {
            return MetaImplementationProvider.Implementation.MetaClass_GetAllOperations(this);
        }
    }
    
    public interface MetaOperation
    {
        string Name { get; set; }
        IList<MetaParameter> Parameters { get; }
        MetaType ReturnType { get; set; }
        MetaClass Class { get; set; }
        MetaEnum Enum { get; set; }
    
    }
    
    internal class MetaOperationImpl : ModelObject, MetaOperation
    {
    
    	public static void TriggerStaticInitialization()
    	{
    	}
    
        public MetaOperationImpl()
        {
            this.MSetValue(MetaOperationImpl.ParametersProperty, new ModelList<MetaParameter>(this, MetaOperationImpl.ParametersProperty));
            MetaImplementationProvider.Implementation.MetaOperation_MetaOperation(this);
        }
        
        internal static readonly ModelProperty NameProperty =
            ModelProperty.Register("Name", typeof(string), typeof(MetaOperationImpl));
        public string Name
        {
            get { return (string)this.MGetValue(MetaOperationImpl.NameProperty); }
            set { this.MSetValue(MetaOperationImpl.NameProperty, value); }
        }
        
        [ContainmentAttribute]
        [OppositeAttribute(typeof(MetaParameterImpl), "Operation")]
        internal static readonly ModelProperty ParametersProperty =
            ModelProperty.Register("Parameters", typeof(IList<MetaParameter>), typeof(MetaOperationImpl));
        public IList<MetaParameter> Parameters
        {
            get { return (IList<MetaParameter>)this.MGetValue(MetaOperationImpl.ParametersProperty); }
        }
        
        internal static readonly ModelProperty ReturnTypeProperty =
            ModelProperty.Register("ReturnType", typeof(MetaType), typeof(MetaOperationImpl));
        public MetaType ReturnType
        {
            get { return (MetaType)this.MGetValue(MetaOperationImpl.ReturnTypeProperty); }
            set { this.MSetValue(MetaOperationImpl.ReturnTypeProperty, value); }
        }
        
        [OppositeAttribute(typeof(MetaClassImpl), "Operations")]
        internal static readonly ModelProperty ClassProperty =
            ModelProperty.Register("Class", typeof(MetaClass), typeof(MetaOperationImpl));
        public MetaClass Class
        {
            get { return (MetaClass)this.MGetValue(MetaOperationImpl.ClassProperty); }
            set { this.MSetValue(MetaOperationImpl.ClassProperty, value); }
        }
        
        [OppositeAttribute(typeof(MetaEnumImpl), "Operations")]
        internal static readonly ModelProperty EnumProperty =
            ModelProperty.Register("Enum", typeof(MetaEnum), typeof(MetaOperationImpl));
        public MetaEnum Enum
        {
            get { return (MetaEnum)this.MGetValue(MetaOperationImpl.EnumProperty); }
            set { this.MSetValue(MetaOperationImpl.EnumProperty, value); }
        }
    }
    
    public interface MetaParameter
    {
        string Name { get; set; }
        MetaType Type { get; set; }
        MetaOperation Operation { get; set; }
        object DefaultValue { get; set; }
    
    }
    
    internal class MetaParameterImpl : ModelObject, MetaParameter
    {
    
    	public static void TriggerStaticInitialization()
    	{
    	}
    
        public MetaParameterImpl()
        {
            MetaImplementationProvider.Implementation.MetaParameter_MetaParameter(this);
        }
        
        internal static readonly ModelProperty NameProperty =
            ModelProperty.Register("Name", typeof(string), typeof(MetaParameterImpl));
        public string Name
        {
            get { return (string)this.MGetValue(MetaParameterImpl.NameProperty); }
            set { this.MSetValue(MetaParameterImpl.NameProperty, value); }
        }
        
        internal static readonly ModelProperty TypeProperty =
            ModelProperty.Register("Type", typeof(MetaType), typeof(MetaParameterImpl));
        public MetaType Type
        {
            get { return (MetaType)this.MGetValue(MetaParameterImpl.TypeProperty); }
            set { this.MSetValue(MetaParameterImpl.TypeProperty, value); }
        }
        
        [OppositeAttribute(typeof(MetaOperationImpl), "Parameters")]
        internal static readonly ModelProperty OperationProperty =
            ModelProperty.Register("Operation", typeof(MetaOperation), typeof(MetaParameterImpl));
        public MetaOperation Operation
        {
            get { return (MetaOperation)this.MGetValue(MetaParameterImpl.OperationProperty); }
            set { this.MSetValue(MetaParameterImpl.OperationProperty, value); }
        }
        
        internal static readonly ModelProperty DefaultValueProperty =
            ModelProperty.Register("DefaultValue", typeof(object), typeof(MetaParameterImpl));
        public object DefaultValue
        {
            get { return (object)this.MGetValue(MetaParameterImpl.DefaultValueProperty); }
            set { this.MSetValue(MetaParameterImpl.DefaultValueProperty, value); }
        }
    }
    
    public interface MetaProperty
    {
        string Name { get; set; }
        MetaPropertyKind Kind { get; set; }
        MetaType Type { get; set; }
        MetaClass Class { get; set; }
        ICollection<MetaProperty> Opposites { get; }
    
    }
    
    internal class MetaPropertyImpl : ModelObject, MetaProperty
    {
    
    	public static void TriggerStaticInitialization()
    	{
    	}
    
        public MetaPropertyImpl()
        {
            this.MSetValue(MetaPropertyImpl.OppositesProperty, new ModelSet<MetaProperty>(this, MetaPropertyImpl.OppositesProperty));
            MetaImplementationProvider.Implementation.MetaProperty_MetaProperty(this);
        }
        
        internal static readonly ModelProperty NameProperty =
            ModelProperty.Register("Name", typeof(string), typeof(MetaPropertyImpl));
        public string Name
        {
            get { return (string)this.MGetValue(MetaPropertyImpl.NameProperty); }
            set { this.MSetValue(MetaPropertyImpl.NameProperty, value); }
        }
        
        internal static readonly ModelProperty KindProperty =
            ModelProperty.Register("Kind", typeof(MetaPropertyKind), typeof(MetaPropertyImpl));
        public MetaPropertyKind Kind
        {
            get { return (MetaPropertyKind)this.MGetValue(MetaPropertyImpl.KindProperty); }
            set { this.MSetValue(MetaPropertyImpl.KindProperty, value); }
        }
        
        internal static readonly ModelProperty TypeProperty =
            ModelProperty.Register("Type", typeof(MetaType), typeof(MetaPropertyImpl));
        public MetaType Type
        {
            get { return (MetaType)this.MGetValue(MetaPropertyImpl.TypeProperty); }
            set { this.MSetValue(MetaPropertyImpl.TypeProperty, value); }
        }
        
        [OppositeAttribute(typeof(MetaClassImpl), "Properties")]
        internal static readonly ModelProperty ClassProperty =
            ModelProperty.Register("Class", typeof(MetaClass), typeof(MetaPropertyImpl));
        public MetaClass Class
        {
            get { return (MetaClass)this.MGetValue(MetaPropertyImpl.ClassProperty); }
            set { this.MSetValue(MetaPropertyImpl.ClassProperty, value); }
        }
        
        [OppositeAttribute(typeof(MetaPropertyImpl), "Opposites")]
        internal static readonly ModelProperty OppositesProperty =
            ModelProperty.Register("Opposites", typeof(ICollection<MetaProperty>), typeof(MetaPropertyImpl));
        public ICollection<MetaProperty> Opposites
        {
            get { return (ICollection<MetaProperty>)this.MGetValue(MetaPropertyImpl.OppositesProperty); }
        }
    }
    
    /// <summary>
    /// Factory class for creating instances of model elements.
    /// </summary>
    public class MetaFactory : ModelFactory
    {
        private static MetaFactory instance = new MetaFactory();
    
    	private MetaFactory()
    	{
    	}
    
        /// <summary>
        /// The singleton instance of the factory.
        /// </summary>
        public static MetaFactory Instance
        {
            get { return MetaFactory.instance; }
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
        /// Creates a new instance of MetaType.
        /// </summary>
        public MetaType CreateMetaType()
    	{
    		MetaType result = new MetaTypeImpl();
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
    
    }
    
    internal static class MetaImplementationProvider
    {
        // If there is a compile error at this line, create a new class called MetaImplementation
    	// which is a subclass of MetaImplementationBase:
        private static MetaImplementation implementation = new MetaImplementation();
    
        public static MetaImplementation Implementation
        {
            get { return MetaImplementationProvider.implementation; }
        }
    }
    
    public static class MetaMetaCollectionKindExtensions
    {
    }
    
    public static class MetaMetaPropertyKindExtensions
    {
    }
    
    /// <summary>
    /// Base class for implementing the behavior of the model elements.
    /// This class has to be be overriden in MetaImplementation to provide custom
    /// implementation for the constructors, operations and property values.
    /// </summary>
    internal abstract class MetaImplementationBase
    {
        /// <summary>
    	/// Implements the constructor: MetaNamespace()
        /// </summary>
        public virtual void MetaNamespace_MetaNamespace(MetaNamespace @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaModel()
        /// </summary>
        public virtual void MetaModel_MetaModel(MetaModel @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaType()
        /// </summary>
        public virtual void MetaType_MetaType(MetaType @this)
        {
        }
    
        /// <summary>
        /// Returns the value of the derived property: MetaType.Namespace
        /// </summary>
        public virtual MetaNamespace MetaType_Namespace(MetaType @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
    	/// Implements the constructor: MetaCollectionType()
    	/// Direct superclasses: MetaType
    	/// All superclasses: MetaType
        /// </summary>
        public virtual void MetaCollectionType_MetaCollectionType(MetaCollectionType @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaNullableType()
    	/// Direct superclasses: MetaType
    	/// All superclasses: MetaType
        /// </summary>
        public virtual void MetaNullableType_MetaNullableType(MetaNullableType @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaPrimitiveType()
    	/// Direct superclasses: MetaType
    	/// All superclasses: MetaType
        /// </summary>
        public virtual void MetaPrimitiveType_MetaPrimitiveType(MetaPrimitiveType @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaEnum()
    	/// Direct superclasses: MetaType
    	/// All superclasses: MetaType
        /// </summary>
        public virtual void MetaEnum_MetaEnum(MetaEnum @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaEnumLiteral()
        /// </summary>
        public virtual void MetaEnumLiteral_MetaEnumLiteral(MetaEnumLiteral @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaClass()
    	/// Direct superclasses: MetaType
    	/// All superclasses: MetaType
        /// </summary>
        public virtual void MetaClass_MetaClass(MetaClass @this)
        {
        }
    
        /// <summary>
        /// Implements the operation: MetaClass.GetAllSuperClasses()
        /// </summary>
        public virtual ICollection<MetaClass> MetaClass_GetAllSuperClasses(MetaClass @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Implements the operation: MetaClass.GetAllProperties()
        /// </summary>
        public virtual ICollection<MetaProperty> MetaClass_GetAllProperties(MetaClass @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
        /// Implements the operation: MetaClass.GetAllOperations()
        /// </summary>
        public virtual ICollection<MetaOperation> MetaClass_GetAllOperations(MetaClass @this)
        {
            throw new NotImplementedException();
        }
    
        /// <summary>
    	/// Implements the constructor: MetaOperation()
        /// </summary>
        public virtual void MetaOperation_MetaOperation(MetaOperation @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaParameter()
        /// </summary>
        public virtual void MetaParameter_MetaParameter(MetaParameter @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: MetaProperty()
        /// </summary>
        public virtual void MetaProperty_MetaProperty(MetaProperty @this)
        {
        }
    
    
    
    }
    
}

