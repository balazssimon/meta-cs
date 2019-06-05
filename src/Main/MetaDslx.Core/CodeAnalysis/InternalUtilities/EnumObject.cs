using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Roslyn.Utilities
{
    // TODO: make it thread-safe
    public class EnumObject : IEquatable<EnumObject>
    {
        private int _value;
        private string _name;

        private static readonly Dictionary<Type, EnumObjectDescriptor> _descriptors = new Dictionary<Type, EnumObjectDescriptor>();
        private static readonly object[] emptyObjectArray = new object[0];
        private static readonly EnumObject[] emptyEnumObjectArray = new EnumObject[0];
        private static readonly Type[] nameConstructorSignature = new Type[] { typeof(string) };
        private static readonly Type[] retargetingConstructorSignature = new Type[] { typeof(EnumObject) };

        protected EnumObject(string name)
        {
            _name = name;
        }

        protected EnumObject(EnumObject retargetedValue)
        {
            if ((object)retargetedValue == null) return;
            Debug.Assert(retargetedValue._name != null || retargetedValue._value != 0);
            if (retargetedValue._name == null)
            {
                var descriptor = GetDescriptor(this.GetType());
                _name = descriptor?.GetName(retargetedValue._value);
            }
            else
            {
                _name = retargetedValue._name;
            }
            if (retargetedValue._value == 0)
            {
                var descriptor = GetDescriptor(this.GetType());
                _value = descriptor?.GetValue(retargetedValue._name)?._value ?? default;
            }
            else
            {
                _value = retargetedValue._value;
            }
        }

        private EnumObject(string name, int value)
        {
            _name = name;
            _value = value;
        }

        public string Switch()
        {
            return this.GetName();
        }

        public string GetName()
        {
            if (_name != null)
            {
                return _name;
            }
            else
            {
                var descriptor = GetDescriptor(this.GetType());
                return descriptor.GetName(_value);
            }
        }

        public static bool TryParse<T>(string name, out T enumValue)
            where T : EnumObject
        {
            var descriptor = GetDescriptor(typeof(T));
            if (descriptor.TryGetValue(name, out var result))
            {
                enumValue = (T)result;
                return true;
            }
            else
            {
                enumValue = null;
                return false;
            }
        }

        public int GetValue()
        {
            if (_value != 0)
            {
                return _value;
            }
            else
            {
                var descriptor = GetDescriptor(this.GetType());
                if (ReferenceEquals(this, descriptor.DefaultValue)) return 0;
                return descriptor.GetValue(_name)?._value ?? 0;
            }
        }

        public static bool TryGetValue<T>(int value, out T enumValue)
            where T : EnumObject
        {
            var descriptor = GetDescriptor(typeof(T));
            if (descriptor.TryGetValue(value, out var result))
            {
                enumValue = (T)result;
                return true;
            }
            else
            {
                enumValue = null;
                return false;
            }
        }

        public static IEnumerable<EnumObject> GetEnumValues(Type enumType)
        {
            var descriptor = GetDescriptor(enumType);
            return descriptor.AllEnumValues;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as EnumObject);
        }

        public bool Equals(EnumObject other)
        {
            if ((object)other == null) return false;
            if (_value == 0) return other._value == 0;
            if (!other.IsAssignableFrom(this.GetType())) return false;
            return _name == other._name;
        }
        
        public static bool operator ==(EnumObject left, EnumObject right)
        {
            if ((object)left == null) return (object)right == null;
            return left.Equals(right);
        }

        public static bool operator !=(EnumObject left, EnumObject right)
        {
            if ((object)left == null) return (object)right != null;
            return !left.Equals(right);
        }

        public static bool operator <(EnumObject left, EnumObject right)
        {
            if ((object)left == null || (object)right == null) return false;
            return left.GetValue() < right.GetValue();
        }

        public static bool operator >(EnumObject left, EnumObject right)
        {
            if ((object)left == null || (object)right == null) return false;
            if (left._value == 0 || right._value == 0) return false;
            return left.GetValue() > right.GetValue();
        }

        public static bool operator <=(EnumObject left, EnumObject right)
        {
            if ((object)left == null) return (object)right == null;
            if ((object)right == null) return false;
            return left.GetValue() <= right.GetValue();
        }

        public static bool operator >=(EnumObject left, EnumObject right)
        {
            if ((object)left == null) return (object)right == null;
            if ((object)right == null) return false;
            return left.GetValue() >= right.GetValue();
        }

        public static EnumObject operator++(EnumObject enumObj)
        {
            if (enumObj == null) return null;
            return enumObj.CreateValue(enumObj.GetType(), enumObj.GetValue()+1);
        }

        public static EnumObject operator --(EnumObject enumObj)
        {
            if (enumObj == null) return null;
            return enumObj.CreateValue(enumObj.GetType(), enumObj.GetValue()-1);
        }

        public static EnumObject operator +(EnumObject left, EnumObject right)
        {
            if ((object)left == null || (object)right == null) return null;
            return EnumObject.GetDescriptor(left.GetType(), right.GetType()).GetValue(left.GetValue() + right.GetValue());
        }

        public static EnumObject operator -(EnumObject left, EnumObject right)
        {
            if ((object)left == null || (object)right == null) return null;
            return EnumObject.GetDescriptor(left.GetType(), right.GetType()).GetValue(left.GetValue() - right.GetValue());
        }

        public static bool operator ==(EnumObject left, string right)
        {
            if ((object)left == null) return (object)right == null;
            var descriptor = GetDescriptor(left.GetType());
            return descriptor.TryGetValue(right, out EnumObject rightValue) && left._value == rightValue._value;
        }

        public static bool operator !=(EnumObject left, string right)
        {
            if ((object)left == null) return (object)right != null;
            var descriptor = GetDescriptor(left.GetType());
            return !descriptor.TryGetValue(right, out EnumObject rightValue) || left._value != rightValue._value;
        }

        public static bool operator ==(EnumObject left, int right)
        {
            if ((object)left == null) return (object)right == null;
            var descriptor = GetDescriptor(left.GetType());
            return descriptor.TryGetValue(right, out EnumObject rightValue) && left._value == rightValue._value;
        }

        public static bool operator !=(EnumObject left, int right)
        {
            if ((object)left == null) return (object)right != null;
            var descriptor = GetDescriptor(left.GetType());
            return !descriptor.TryGetValue(right, out EnumObject rightValue) || left._value != rightValue._value;
        }

        public static implicit operator EnumObject(string name)
        {
            if (EnumObject.TryParse<EnumObject>(name, out var result)) return result;
            else return null;
        }

        public static explicit operator int(EnumObject value)
        {
            return value.GetValue();
        }

        public static explicit operator string(EnumObject value)
        {
            return value.GetName();
        }

        public override int GetHashCode()
        {
            return Hash.Combine(_name.GetHashCode(), _value.GetHashCode());
        }

        public bool IsDescendantOf(Type type)
        {
            if (_descriptors.TryGetValue(type, out EnumObjectDescriptor otherDescriptor) &&
                _descriptors.TryGetValue(this.GetType(), out EnumObjectDescriptor myDescriptor))
            {
                return otherDescriptor.IsDescendantOf(myDescriptor);
            }
            return false;
        }

        public bool IsAncestorOf(Type type)
        {
            if (_descriptors.TryGetValue(type, out EnumObjectDescriptor otherDescriptor) &&
                _descriptors.TryGetValue(this.GetType(), out EnumObjectDescriptor myDescriptor))
            {
                return myDescriptor.IsDescendantOf(otherDescriptor);
            }
            return false;
        }

        public bool IsAssignableFrom(Type type)
        {
            if (type == this.GetType()) return true;
            if (_descriptors.TryGetValue(type, out EnumObjectDescriptor otherDescriptor) &&
                _descriptors.TryGetValue(this.GetType(), out EnumObjectDescriptor myDescriptor))
            {
                return myDescriptor.IsDescendantOf(otherDescriptor) || otherDescriptor.IsDescendantOf(myDescriptor);
            }
            return false;
        }

        protected static void AutoInit<T>()
            where T : EnumObject
        {
            var descriptor = EnsureInit<T>();
            Debug.Assert(!descriptor.IsClosed);
            Type type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            HashSet<string> autoNames = new HashSet<string>();
            foreach (var field in fields)
            {
                if (field.FieldType == typeof(string) && field.IsLiteral)
                {
                    var name = (string)field.GetValue(null);
                    if (name != field.Name)
                    {
                        if (!descriptor.IsAlias(name)) throw new InvalidOperationException($"Name of the field {type}.{field.Name} is different than it's value '{name}'. If you want to create an alias, use RegisterAlias() in the static initializer.");
                        else continue;
                    }
                    if (autoNames.Contains(name))
                    {
                        throw new InvalidOperationException($"Duplicate enum literal '{name}' in {type} registered by the field {type}.{field.Name}. If you want to create an alias, use RegisterAlias() in the static initializer.");
                    }
                    descriptor.RegisterUniqueValue(name);
                    autoNames.Add(name);
                }
            }
            Close<T>();
        }

        private static EnumObjectDescriptor EnsureInit<T>()
            where T : EnumObject
        {
            if (_descriptors.TryGetValue(typeof(T), out EnumObjectDescriptor descriptor))
            {
                return descriptor;
            }
            else
            {
                descriptor = new EnumObjectDescriptor(typeof(T));
                _descriptors.Add(typeof(T), descriptor);
                return descriptor;
            }
        }

        protected static void RegisterDefault<T>(string name)
            where T : EnumObject
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            var descriptor = EnsureInit<T>();
            Debug.Assert(!descriptor.IsClosed);
            descriptor.RegisterDefaultValue(name);
        }

        protected static void RegisterAlias<T>(string name)
            where T : EnumObject
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            var descriptor = EnsureInit<T>();
            Debug.Assert(!descriptor.IsClosed);
            descriptor.RegisterAlias(name);
        }

        protected static void Close<T>()
            where T : EnumObject
        {
            var descriptor = EnsureInit<T>();
            Debug.Assert(!descriptor.IsClosed);
            descriptor.Close();
        }

        public EnumObject Cast(Type enumType)
        {
            if (enumType.IsAssignableFrom(this.GetType())) return this;
            if (!this.IsAssignableFrom(enumType)) throw new InvalidOperationException($"{enumType} is not a descendant of {this.GetType()}.");
            var descriptor = GetDescriptor(enumType);
            if (descriptor.TryGetValue(_name, out EnumObject result)) return result;
            else throw new InvalidOperationException($"{enumType} does not contain the enum literal '{_name}' declared in {this.GetType()}.");
        }

        public T Cast<T>()
            where T : EnumObject
        {
            return (T)Cast(typeof(T));
        }

        public EnumObject CastUnsafe(Type enumType)
        {
            if (enumType.IsAssignableFrom(this.GetType())) return this;
            else return FromIntUnsafe(enumType, this.GetValue());
        }

        public T CastUnsafe<T>()
            where T : EnumObject
        {
            return (T)CastUnsafe(typeof(T));
        }

        public EnumObject As(Type enumType)
        {
            if (enumType.IsAssignableFrom(this.GetType())) return this;
            if (!this.IsAssignableFrom(enumType)) throw new InvalidOperationException($"{enumType} is not a descendant of {this.GetType()}.");
            var descriptor = GetDescriptor(this.GetType());
            if (descriptor.TryGetValue(_name, out EnumObject result)) return result;
            else throw new InvalidOperationException($"{enumType} does not contain the enum literal '{_name}' declared in {this.GetType()}.");
        }

        public T As<T>()
            where T : EnumObject
        {
            return (T)As(typeof(T));
        }

        public static EnumObject ByValue(Type enumType, int value)
        {
            if (value < 0) return null;
            var descriptor = GetDescriptor(enumType);
            if (descriptor.TryGetValue(value, out EnumObject result)) return result;
            return null;
        }

        public static T ByValue<T>(int value)
            where T : EnumObject
        {
            return (T)ByValue(typeof(T), value);
        }

        public static EnumObject ByName(Type enumType, string name)
        {
            if (name == null) return null;
            var descriptor = GetDescriptor(enumType);
            if (descriptor.TryGetValue(name, out EnumObject result)) return result;
            return null;
        }

        public static T ByName<T>(string name)
            where T : EnumObject
        {
            return (T)ByName(typeof(T), name);
        }

        public static EnumObject FromString(Type enumType, string name)
        {
            return ByName(enumType, name) ?? throw new ArgumentException($"Enum literal '{name}' does not exist in {enumType}.", nameof(name));
        }

        public static T FromString<T>(string name)
            where T : EnumObject
        {
            return (T)FromString(typeof(T), name);
        }

        public static EnumObject FromInt(Type enumType, int value)
        {
            return ByValue(enumType, value) ?? throw new ArgumentException($"Enum literal of value '{value}' does not exist in {enumType}.", nameof(value));
        }

        public static T FromInt<T>(int value)
            where T : EnumObject
        {
            return (T)FromInt(typeof(T), value);
        }

        public static EnumObject FromIntUnsafe(Type enumType, int value)
        {
            EnumObject result = ByValue(enumType, value);
            if ((object)result != null) return result;
            var descriptor = GetDescriptor(enumType);
            if (descriptor.TryGetValue(value, out EnumObject stored)) return stored;
            else return descriptor.CreateValue(new EnumObject(null, value));
        }

        public static T FromIntUnsafe<T>(int value)
            where T : EnumObject
        {
            return (T)FromIntUnsafe(typeof(T), value);
        }

        internal static EnumObjectDescriptor GetDescriptor(Type type)
        {
            EnumObjectDescriptor descriptor;
            if (_descriptors.TryGetValue(type, out descriptor))
            {
                return descriptor;
            }
            RuntimeHelpers.RunClassConstructor(type.TypeHandle);
            if (_descriptors.TryGetValue(type, out descriptor))
            {
                return descriptor;
            }
            throw new ArgumentException("Invalid EnumObject type: " + type);
        }

        internal static EnumObjectDescriptor GetDescriptor(params Type[] type)
        {
            if (type.Length == 0) return GetDescriptor(typeof(EnumObject));
            if (type.Length == 1) return GetDescriptor(type[0]);
            if (type.Length == 2)
            {
                if (type[0] == type[1]) return GetDescriptor(type[0]);
                if (type[0].IsAssignableFrom(type[1])) GetDescriptor(type[1]);
                if (type[1].IsAssignableFrom(type[0])) GetDescriptor(type[0]);
            }
            Type resultType = type[0];
            for (int i = 1; i < type.Length; i++)
            {
                var current = type[i];
                Type currentType = current.GetType();
                if (resultType != currentType && resultType.IsAssignableFrom(currentType)) resultType = currentType;
            }
            return GetDescriptor(resultType);
        }

        private EnumObject CreateValue(Type type, int value)
        {
            var descriptor = GetDescriptor(type);
            return descriptor.GetValue(value);
        }

        public override string ToString()
        {
            return this.GetName();
        }

        internal class EnumObjectDescriptor
        {
            public static readonly EnumObjectDescriptor Root = CreateRoot();

            private Type _type;
            private List<EnumObjectDescriptor> _baseDescriptors;
            private int _maxValue;
            private bool _closed;
            private string _defaultName;
            private EnumObject _defaultValue;
            private HashSet<string> _aliases = new HashSet<string>();
            private List<EnumObject> _values = new List<EnumObject>();
            private List<string> _lazyValues = new List<string>();
            private EnumObject[] _cachedByValue;
            private Dictionary<string, EnumObject> _cachedByName = new Dictionary<string, EnumObject>();

            public EnumObjectDescriptor(Type type)
            {
                _type = type;
                _baseDescriptors = new List<EnumObjectDescriptor>();
                _maxValue = 0;
                Type baseType = type.BaseType;
                if (baseType != null && baseType != typeof(EnumObject))
                {
                    RuntimeHelpers.RunClassConstructor(baseType.TypeHandle);
                    if (_descriptors.TryGetValue(baseType, out EnumObjectDescriptor baseDescriptor))
                    {
                        Debug.Assert(baseDescriptor._closed, baseType + " is not closed.");
                        _baseDescriptors.AddRange(baseDescriptor._baseDescriptors);
                        _baseDescriptors.Add(baseDescriptor);
                        _maxValue = baseDescriptor._maxValue;
                        _defaultName = baseDescriptor._defaultName;
                    }
                    else
                    {
                        Debug.Assert(false, baseType + " is not initialized.");
                    }
                }
            }

            private EnumObjectDescriptor()
            {
                _type = typeof(EnumObject);
                _baseDescriptors = new List<EnumObjectDescriptor>();
                _maxValue = 0;
                _defaultName = null;
                _cachedByValue = new EnumObject[0];
                _closed = true;
            }

            private static EnumObjectDescriptor CreateRoot()
            {
                EnumObjectDescriptor result = new EnumObjectDescriptor();
                _descriptors.Add(typeof(EnumObject), result);
                return result;
            }

            public Type Type => _type;
            public int MaxValue => _maxValue;
            public bool IsClosed => _closed;
            public IReadOnlyList<EnumObject> Values => _values;

            public void Close()
            {
                if (_defaultName != null && (object)_defaultValue == null)
                {
                    Interlocked.CompareExchange(ref _defaultValue, CreateValue(new EnumObject(_defaultName, 0)), null);
                    _cachedByName[_defaultName] = _defaultValue;
                }
                if (_lazyValues != null)
                {
                    foreach (var lazy in _lazyValues)
                    {
                        if ((object)_cachedByName[lazy] == null)
                        {
                            var value = CreateValue(lazy);
                            _values.Add(value);
                            _cachedByName[lazy] = value;
                        }
                    }
                }
                _cachedByValue = new EnumObject[_maxValue];
                int valuesCount = _values.Count;
                for (int i = valuesCount - 1; i >= 0; i--)
                {
                    _cachedByValue[_maxValue - valuesCount + i] = _values[i];
                }
                var baseDescriptor = this.BaseDescriptor;
                if (baseDescriptor != null)
                {
                    var baseValuesByName = baseDescriptor._cachedByName;
                    foreach (var entry in baseValuesByName)
                    {
                        var name = entry.Key;
                        var value = CreateValue(entry.Value);
                        if (!_cachedByName.ContainsKey(name)) _cachedByName.Add(name, value);
                        else throw new InvalidOperationException($"Enum literal '{name}' is registered multiple times in {_type}.");
                    }
                    var baseValues = baseDescriptor._cachedByValue;
                    for (int i = 0; i < baseValues.Length; i++)
                    {
                        _cachedByValue[i] = _cachedByName[baseValues[i]._name];
                    }
                }
                _closed = true;
            }

            public bool TryGetValue(int value, out EnumObject enumObject)
            {
                enumObject = null;
                if (value == 0)
                {
                    enumObject = this.DefaultValue;
                    return (object)enumObject != null;
                }
                if (value < 1 || value > _maxValue) return false;
                if (_closed)
                {
                    enumObject = _cachedByValue[value - 1];
                    return true;
                }
                else
                {
                    int valuesCount = _values.Count;
                    if (value >= _maxValue - valuesCount + 1)
                    {
                        enumObject = _values[value - 1];
                        return true;
                    }
                    else
                    {
                        enumObject = this.BaseDescriptor?.GetValue(value);
                        return enumObject != null;
                    }
                }
            }

            public EnumObject DefaultValue
            {
                get
                {
                    if (_defaultName != null && (object)_defaultValue == null)
                    {
                        Interlocked.CompareExchange(ref _defaultValue, CreateValue(new EnumObject(_defaultName, 0)), null);
                        _cachedByName[_defaultName] = _defaultValue;
                    }
                    return _defaultValue;
                }
            }

            public EnumObject GetValue(int value)
            {
                if (TryGetValue(value, out EnumObject result)) return result;
                else throw new ArgumentOutOfRangeException(nameof(value));
            }

            public bool TryGetValue(string name, out EnumObject enumObject)
            {
                enumObject = null;
                if (name == null) return false;
                if (_closed)
                {
                    return _cachedByName.TryGetValue(name, out enumObject);
                }
                else
                {
                    foreach (var value in _values)
                    {
                        if (value._name == name)
                        {
                            enumObject = value;
                            return true;
                        }
                    }
                    enumObject = this.BaseDescriptor?.GetValue(name);
                    return enumObject != null;
                }
            }

            public EnumObject GetValue(string name)
            {
                if (name == null) throw new ArgumentNullException(nameof(name));
                if (TryGetValue(name, out EnumObject result)) return result;
                else throw new ArgumentException($"Enum literal '{name}' does not exist in {_type}.", nameof(name));
            }

            public bool TryGetName(int value, out string name)
            {
                name = null;
                if (value == 0)
                {
                    name = _defaultName;
                    return _defaultName != null;
                }
                if (value < 1 || value > _maxValue) return false;
                if (_closed)
                {
                    name = _cachedByValue[value - 1]._name;
                    return true;
                }
                else
                {
                    int valuesCount = _values.Count;
                    if (value >= _maxValue - valuesCount + 1)
                    {
                        name = _values[value - 1]._name;
                        return true;
                    }
                    else
                    {
                        name = this.BaseDescriptor?.GetName(value);
                        return name != null;
                    }
                }
            }

            public string GetName(int value)
            {
                if (TryGetName(value, out string result)) return result;
                else throw new ArgumentOutOfRangeException(nameof(value));
            }

            private EnumObjectDescriptor BaseDescriptor => _baseDescriptors.Count == 0 ? null : _baseDescriptors[_baseDescriptors.Count - 1];

            private EnumObject CreateValue(string name)
            {
                var nameConstructor = _type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, nameConstructorSignature, null);
                if (nameConstructor != null)
                {
                    var result = (EnumObject)nameConstructor.Invoke(new object[] { name });
                    result._value = ++_maxValue;
                    return result;
                }
                throw new InvalidOperationException(_type + " must have a string constructor.");
            }

            public EnumObject CreateValue(EnumObject value)
            {
                var retargetingConstructor = _type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, retargetingConstructorSignature, null);
                if (retargetingConstructor != null)
                {
                    return (EnumObject)retargetingConstructor.Invoke(new object[] { value });
                }
                var baseDescriptor = this.BaseDescriptor;
                if (baseDescriptor != null)
                {
                    return baseDescriptor.CreateValue(value);
                }
                throw new InvalidOperationException(_type + " must have a retargeting constructor.");
            }

            public void RegisterUniqueValue(string name)
            {
                if (!_cachedByName.ContainsKey(name))
                {
                    _lazyValues.Add(name);
                    _cachedByName.Add(name, null);
                }
            }

            public void RegisterDefaultValue(string name)
            {
                if (_cachedByName.ContainsKey(name))
                {
                    throw new InvalidOperationException($"Duplicate enum literal '{name}' in {_type}. If you want to create an alias, use RegisterAlias() in the static initializer.");
                }
                else if (_defaultName != null)
                {
                    throw new InvalidOperationException($"Duplicate default enum literal '{name}' in {_type}. If you want to create an alias, use RegisterAlias() in the static initializer.");
                }
                else
                {
                    _defaultName = name;
                    _cachedByName.Add(name, null);
                }
            }

            public void RegisterAlias(string name)
            {
                if (_cachedByName.ContainsKey(name))
                {
                    throw new InvalidOperationException($"Duplicate enum literal '{name}' in {_type}. If you want to create an alias, use RegisterAlias() in the static initializer.");
                }
                _aliases.Add(name);
            }

            public bool IsAlias(string name)
            {
                return _aliases.Contains(name);
            }

            public bool IsDescendantOf(EnumObjectDescriptor other)
            {
                return _baseDescriptors.Contains(other);
            }

            public IEnumerable<EnumObject> AllEnumValues
            {
                get
                {
                    if (_closed)
                    {
                        foreach (var value in _cachedByValue)
                        {
                            yield return value;
                        }
                    }
                    else
                    {
                        foreach (var baseDescriptor in _baseDescriptors)
                        {
                            foreach (var value in baseDescriptor.Values)
                            {
                                yield return value;
                            }
                        }
                        foreach (var value in _values)
                        {
                            yield return value;
                        }
                    }
                }
            }
        }
    }

    public static class EnumObjectExtensions
    {
        public static T AsEnum<T>(this string name)
            where T : EnumObject
        {
            return EnumObject.ByName<T>(name);
        }

        public static T AsEnum<T>(this string name, Type enumType)
            where T : EnumObject
        {
            return (T)EnumObject.ByName(enumType, name);
        }

        public static T AsEnum<T>(this int value)
            where T : EnumObject
        {
            return EnumObject.ByValue<T>(value);
        }

        public static T AsEnum<T>(this int value, Type enumType)
            where T : EnumObject
        {
            return (T)EnumObject.ByValue(enumType, value);
        }
    }


    /* Template:
    
    public class LanguageVersion : EnumObject
    {
        public const string Default = nameof(Default);
        public const string Latest = nameof(Latest);

        protected LanguageVersion(string name)
            : base(name)
        {
        }

        protected LanguageVersion(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static LanguageVersion()
        {
            EnumObject.AutoInit<LanguageVersion>();
        }

        public static implicit operator LanguageVersion(string name)
        {
            return FromString<LanguageVersion>(name);
        }

        public static explicit operator LanguageVersion(int value)
        {
            return FromIntUnsafe<LanguageVersion>(value);
        }

    }
    */

}
