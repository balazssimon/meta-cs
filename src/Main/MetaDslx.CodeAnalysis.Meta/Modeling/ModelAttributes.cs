using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class ModelObjectDescriptorAttribute : Attribute
    {
        private static Type[] EmptyTypeArray = new Type[0];

        public ModelObjectDescriptorAttribute()
        {
            this.BaseDescriptors = EmptyTypeArray;
        }

        public ModelObjectDescriptorAttribute(Type idType, Type immutableType, Type mutableType)
        {
            this.IdType = idType;
            this.ImmutableType = immutableType;
            this.MutableType = mutableType;
            this.BaseDescriptors = EmptyTypeArray;
        }

        public Type[] BaseDescriptors { get; set; }
        public Type IdType { get; }
        public Type ImmutableType { get; }
        public Type MutableType { get; }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public sealed class OppositeAttribute : Attribute
    {
        public OppositeAttribute(Type declaringType, string propertyName)
        {
            this.DeclaringType = declaringType;
            this.PropertyName = propertyName;
        }

        public Type DeclaringType { get; private set; }
        public string PropertyName { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public sealed class SubsetsAttribute : Attribute
    {
        public SubsetsAttribute(Type declaringType, string propertyName)
        {
            this.DeclaringType = declaringType;
            this.PropertyName = propertyName;
        }

        public Type DeclaringType { get; private set; }
        public string PropertyName { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public sealed class RedefinesAttribute : Attribute
    {
        public RedefinesAttribute(Type declaringType, string propertyName)
        {
            this.DeclaringType = declaringType;
            this.PropertyName = propertyName;
        }

        public Type DeclaringType { get; private set; }
        public string PropertyName { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class ReadonlyAttribute : Attribute
    {
        public ReadonlyAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class DerivedAttribute : Attribute
    {
        public DerivedAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class DerivedUnionAttribute : Attribute
    {
        public DerivedUnionAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class NonUniqueAttribute : Attribute
    {
        public NonUniqueAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class NonNullAttribute : Attribute
    {
        public NonNullAttribute()
        {
        }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class ContainmentAttribute : Attribute
    {
        public ContainmentAttribute()
        {
        }
    }



    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class NameAttribute : Attribute
    {

    }

    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class LocalNameAttribute : Attribute
    {

    }

    [System.AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class LocalAttribute : Attribute
    {

    }

    [System.AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class TypeAttribute : Attribute
    {

    }

    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class MemberAttribute : Attribute
    {
    }

    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class StaticMemberAttribute : Attribute
    {
    }

    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class NonMemberAttribute : Attribute
    {
    }

    [System.AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class ScopeAttribute : Attribute
    {
    }

    [System.AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class LocalScopeAttribute : Attribute
    {
    }

    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class ImportAttribute : Attribute
    {
    }

    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class BaseScopeAttribute : Attribute
    {
    }



}
