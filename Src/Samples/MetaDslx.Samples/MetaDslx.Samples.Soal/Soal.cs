using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;

namespace MetaDslx.Samples.Soal
{
    public static class SoalDescriptor
    {
        static SoalDescriptor()
        {
            Class.StaticInit();
            Operation.StaticInit();
        }
    
        internal static void StaticInit()
        {
        }
    
    	public const string Uri = "http://MetaDslx.Samples.Soal/1.0";
    
        
        public static class Class
        {
            internal static void StaticInit()
            {
            }
        
            static Class()
            {
                global::MetaDslx.Samples.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Samples.Soal.SoalInstance.Class; }
            }
        
            
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(string), typeof(global::MetaDslx.Samples.Soal.Class), typeof(global::MetaDslx.Samples.Soal.SoalDescriptor.Class), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Samples.Soal.SoalInstance.Class_NameProperty));
            
            
            public static readonly ModelProperty OperationsProperty =
                ModelProperty.Register("Operations", typeof(global::System.Collections.Generic.IList<global::MetaDslx.Samples.Soal.Operation>), typeof(global::MetaDslx.Samples.Soal.Class), typeof(global::MetaDslx.Samples.Soal.SoalDescriptor.Class), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Samples.Soal.SoalInstance.Class_OperationsProperty));
            
        }
        
        public static class Operation
        {
            internal static void StaticInit()
            {
            }
        
            static Operation()
            {
                global::MetaDslx.Samples.Soal.SoalDescriptor.StaticInit();
            }
        
            public static global::MetaDslx.Core.MetaClass MetaClass
            {
                get { return global::MetaDslx.Samples.Soal.SoalInstance.Operation; }
            }
        
            
            public static readonly ModelProperty NameProperty =
                ModelProperty.Register("Name", typeof(string), typeof(global::MetaDslx.Samples.Soal.Operation), typeof(global::MetaDslx.Samples.Soal.SoalDescriptor.Operation), new Lazy<global::MetaDslx.Core.MetaProperty>(() => global::MetaDslx.Samples.Soal.SoalInstance.Operation_NameProperty));
            
        }
    }
    
	public static class SoalInstance
	{
	    private static global::MetaDslx.Core.Model model;
	
	    public static global::MetaDslx.Core.Model Model
	    {
	        get { return SoalInstance.model; }
	    }
	
	    public static readonly global::MetaDslx.Core.MetaModel Meta;
	
	
		
		public static readonly global::MetaDslx.Core.MetaClass Class;
		
		
		public static readonly global::MetaDslx.Core.MetaClass Operation;
		
	
		public static readonly global::MetaDslx.Core.MetaProperty Class_NameProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Class_OperationsProperty;
		public static readonly global::MetaDslx.Core.MetaProperty Operation_NameProperty;
	
	    static SoalInstance()
	    {
			SoalDescriptor.StaticInit();
			SoalInstance.model = new global::MetaDslx.Core.Model();
	   		using (new ModelContextScope(SoalInstance.model))
			{
	
				global::MetaDslx.Core.MetaNamespace tmp1 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNamespace();
				global::MetaDslx.Core.MetaNamespace tmp2 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNamespace();
				global::MetaDslx.Core.MetaNamespace tmp3 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaNamespace();
				global::MetaDslx.Core.MetaModel tmp4 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaModel();
				Meta = tmp4;
				Class = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				Class_NameProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				Class_OperationsProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
				global::MetaDslx.Core.MetaCollectionType tmp5 = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaCollectionType();
				Operation = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaClass();
				Operation_NameProperty = global::MetaDslx.Core.MetaFactory.Instance.CreateMetaProperty();
	
				
				
				((ModelObject)tmp1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.NamespacesProperty, new Lazy<object>(() => tmp2));
				
				((ModelObject)tmp1).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "MetaDslx"));
				((ModelObject)tmp1).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty);
				((ModelObject)tmp1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty, new Lazy<object>(() => null));
				((ModelObject)tmp1).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty);
				((ModelObject)tmp1).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty, new Lazy<object>(() => null));
				
				
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.NamespacesProperty, new Lazy<object>(() => tmp3));
				
				((ModelObject)tmp2).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Samples"));
				((ModelObject)tmp2).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty);
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty, new Lazy<object>(() => tmp1));
				((ModelObject)tmp2).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty);
				((ModelObject)tmp2).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty, new Lazy<object>(() => null));
				
				
				
				((ModelObject)tmp3).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => Class));
				((ModelObject)tmp3).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.DeclarationsProperty, new Lazy<object>(() => Operation));
				((ModelObject)tmp3).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp3).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Soal"));
				((ModelObject)tmp3).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty);
				((ModelObject)tmp3).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.ParentProperty, new Lazy<object>(() => tmp2));
				((ModelObject)tmp3).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty);
				((ModelObject)tmp3).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamespace.MetaModelProperty, new Lazy<object>(() => tmp4));
				
				((ModelObject)tmp4).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)tmp4).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Soal"));
				((ModelObject)tmp4).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaModel.NamespaceProperty);
				((ModelObject)tmp4).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaModel.NamespaceProperty, new Lazy<object>(() => tmp3));
				((ModelObject)tmp4).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaModel.UriProperty);
				((ModelObject)tmp4).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaModel.UriProperty, new Lazy<object>(() => "http://MetaDslx.Samples.Soal/1.0"));
				
				
				((ModelObject)Class).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Class_NameProperty));
				((ModelObject)Class).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Class_OperationsProperty));
				
				((ModelObject)Class).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Class).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Class"));
				((ModelObject)Class).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)Class).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp3));
				((ModelObject)Class).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)Class).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)Class).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)Class).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)Class_NameProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Class_NameProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Name"));
				((ModelObject)Class_NameProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Class_NameProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Class));
				((ModelObject)Class_NameProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Class_NameProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)Class_NameProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Class_NameProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)Class_OperationsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Class_OperationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Operations"));
				((ModelObject)Class_OperationsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Class_OperationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Class));
				((ModelObject)Class_OperationsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Class_OperationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => tmp5));
				((ModelObject)Class_OperationsProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Class_OperationsProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
				((ModelObject)tmp5).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty);
				((ModelObject)tmp5).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.KindProperty, new Lazy<object>(() => global::MetaDslx.Core.MetaCollectionKind.List));
				((ModelObject)tmp5).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty);
				((ModelObject)tmp5).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaCollectionType.InnerTypeProperty, new Lazy<object>(() => Operation));
				
				
				((ModelObject)Operation).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.PropertiesProperty, new Lazy<object>(() => Operation_NameProperty));
				
				((ModelObject)Operation).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Operation).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Operation"));
				((ModelObject)Operation).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty);
				((ModelObject)Operation).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaDeclaration.NamespaceProperty, new Lazy<object>(() => tmp3));
				((ModelObject)Operation).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty);
				((ModelObject)Operation).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.IsAbstractProperty, new Lazy<object>(() => null));
				((ModelObject)Operation).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty);
				((ModelObject)Operation).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaClass.ConstructorProperty, new Lazy<object>(() => null));
				
				
				
				
				
				
				((ModelObject)Operation_NameProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty);
				((ModelObject)Operation_NameProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaNamedElement.NameProperty, new Lazy<object>(() => "Name"));
				((ModelObject)Operation_NameProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty);
				((ModelObject)Operation_NameProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.ClassProperty, new Lazy<object>(() => Operation));
				((ModelObject)Operation_NameProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty);
				((ModelObject)Operation_NameProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaTypedElement.TypeProperty, new Lazy<object>(() => 	MetaInstance.String	));
				((ModelObject)Operation_NameProperty).MUnSet(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty);
				((ModelObject)Operation_NameProperty).MLazyAdd(global::MetaDslx.Core.MetaDescriptor.MetaProperty.KindProperty, new Lazy<object>(() => null));
	
	            foreach (var mo in ModelContext.Current.Model.Instances)
	            {
	                mo.MEvalLazyValues();
	            }
			}
	    }
	}
    
    public interface Class
    {
        string Name { get; set; }
        global::System.Collections.Generic.IList<global::MetaDslx.Samples.Soal.Operation> Operations { get; }
    
    }
    
    internal class ClassImpl : ModelObject, global::MetaDslx.Samples.Soal.Class
    {
        static ClassImpl()
        {
            global::MetaDslx.Samples.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Samples.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Samples.Soal.SoalInstance.Class; }
        }
    
        public ClassImpl() 
        {
            this.MSet(global::MetaDslx.Samples.Soal.SoalDescriptor.Class.OperationsProperty, new global::MetaDslx.Core.ModelList<Operation>(this, global::MetaDslx.Samples.Soal.SoalDescriptor.Class.OperationsProperty));
            global::MetaDslx.Samples.Soal.SoalImplementationProvider.Implementation.Class_Class(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Samples.Soal.Class.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Samples.Soal.SoalDescriptor.Class.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Samples.Soal.SoalDescriptor.Class.NameProperty, value); }
        }
        
        global::System.Collections.Generic.IList<global::MetaDslx.Samples.Soal.Operation> global::MetaDslx.Samples.Soal.Class.Operations
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Samples.Soal.SoalDescriptor.Class.OperationsProperty); 
                if (result != null) return (global::System.Collections.Generic.IList<global::MetaDslx.Samples.Soal.Operation>)result;
                else return default(global::System.Collections.Generic.IList<global::MetaDslx.Samples.Soal.Operation>);
            }
        }
    }
    
    
    public interface Operation
    {
        string Name { get; set; }
    
    }
    
    internal class OperationImpl : ModelObject, global::MetaDslx.Samples.Soal.Operation
    {
        static OperationImpl()
        {
            global::MetaDslx.Samples.Soal.SoalDescriptor.StaticInit();
        }
    
        public override global::MetaDslx.Core.MetaModel MMetaModel
        {
            get { return global::MetaDslx.Samples.Soal.SoalInstance.Meta; }
        }
    
        public override global::MetaDslx.Core.MetaClass MMetaClass
        {
            get { return global::MetaDslx.Samples.Soal.SoalInstance.Operation; }
        }
    
        public OperationImpl() 
        {
            global::MetaDslx.Samples.Soal.SoalImplementationProvider.Implementation.Operation_Operation(this);
            this.MMakeDefault();
        }
        
        string global::MetaDslx.Samples.Soal.Operation.Name
        {
            get 
            {
                object result = this.MGet(global::MetaDslx.Samples.Soal.SoalDescriptor.Operation.NameProperty); 
                if (result != null) return (string)result;
                else return default(string);
            }
            set { this.MSet(global::MetaDslx.Samples.Soal.SoalDescriptor.Operation.NameProperty, value); }
        }
    }
    
    /// <summary>
    /// Factory class for creating instances of model elements.
    /// </summary>
    public class SoalFactory : ModelFactory
    {
        private static SoalFactory instance = new SoalFactory();
    
    	private SoalFactory()
    	{
    	}
    
        /// <summary>
        /// The singleton instance of the factory.
        /// </summary>
        public static SoalFactory Instance
        {
            get { return SoalFactory.instance; }
        }
    
        /// <summary>
        /// Creates a new instance of Class.
        /// </summary>
        public Class CreateClass(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		Class result = new global::MetaDslx.Samples.Soal.ClassImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    
        /// <summary>
        /// Creates a new instance of Operation.
        /// </summary>
        public Operation CreateOperation(IEnumerable<ModelPropertyInitializer> initializers = null)
    	{
    		Operation result = new global::MetaDslx.Samples.Soal.OperationImpl();
    		if (initializers != null)
    		{
    			this.Init((ModelObject)result, initializers);
    		}
    		return result;
    	}
    }
    
    internal static class SoalImplementationProvider
    {
        // If there is a compile error at this line, create a new class called SoalImplementation
    	// which is a subclass of SoalImplementationBase:
        private static SoalImplementation implementation = new SoalImplementation();
    
        public static SoalImplementation Implementation
        {
            get { return SoalImplementationProvider.implementation; }
        }
    }
    
    /// <summary>
    /// Base class for implementing the behavior of the model elements.
    /// This class has to be be overriden in SoalImplementation to provide custom
    /// implementation for the constructors, operations and property values.
    /// </summary>
    internal abstract class SoalImplementationBase
    {
        /// <summary>
    	/// Implements the constructor: Class()
        /// </summary>
        public virtual void Class_Class(Class @this)
        {
        }
    
        /// <summary>
    	/// Implements the constructor: Operation()
        /// </summary>
        public virtual void Operation_Operation(Operation @this)
        {
        }
    
    }
    
}
