using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

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
            _name = retargetedValue._name;
            _value = retargetedValue._value;
        }

        public string Name => _name;

        public int Value => _value;

        public static IEnumerable<EnumObject> EnumValues(Type enumType)
        {
            if (_descriptors.TryGetValue(enumType, out EnumObjectDescriptor descriptor))
            {
                return descriptor.AllValues;
            }
            return emptyEnumObjectArray;
        }

        public static bool TryParse<T>(string name, out T enumValue)
            where T: EnumObject
        {
            Type enumType = typeof(T);
            if (_descriptors.TryGetValue(enumType, out EnumObjectDescriptor descriptor))
            {
                EnumObject result = descriptor.AllValues.FirstOrDefault(v => v._name == name);
                if ((object)result != null)
                {
                    enumValue = (T)result;
                    return true;
                }
            }
            enumValue = null;
            return false;
        }

        public static bool TryGetValue<T>(int value, out T enumValue)
            where T : EnumObject
        {
            Type enumType = typeof(T);
            if (_descriptors.TryGetValue(enumType, out EnumObjectDescriptor descriptor))
            {
                EnumObject result = descriptor.AllValues.FirstOrDefault(v => v._value == value);
                if ((object)result != null)
                {
                    enumValue = (T)result;
                    return true;
                }
            }
            enumValue = null;
            return false;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as EnumObject);
        }

        public bool Equals(EnumObject other)
        {
            if ((object)other == null) return false;
            if (!other.IsAssignableFrom(this.GetType())) return false;
            return other._value == _value;
        }
        /*
        public static bool operator==(EnumObject left, EnumObject right)
        {
            if ((object)left == null) return (object)right == null;
            return left.Equals(right);
        }

        public static bool operator !=(EnumObject left, EnumObject right)
        {
            if ((object)left == null) return (object)right != null;
            return !left.Equals(right);
        }
        */
        public static bool operator ==(EnumObject left, string right)
        {
            if ((object)left == null) return (object)right == null;
            return left.Name == right;
        }

        public static bool operator !=(EnumObject left, string right)
        {
            if ((object)left == null) return (object)right != null;
            return left.Name != right;
        }

        public static bool operator ==(EnumObject left, int right)
        {
            if ((object)left == null) return (object)right == null;
            return left.Value == right;
        }

        public static bool operator !=(EnumObject left, int right)
        {
            if ((object)left == null) return (object)right != null;
            return left.Value != right;
        }
        
        public static implicit operator EnumObject(string name)
        {
            if (EnumObject.TryParse<EnumObject>(name, out var result)) return result;
            else return null;
        }

        public static implicit operator string(EnumObject value)
        {
            return value.Name;
        }
        
        public override int GetHashCode()
        {
            return _value.GetHashCode();
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

        protected static void Init<T>()
            where T : EnumObject
        {
            _descriptors.Add(typeof(T), new EnumObjectDescriptor(typeof(T)));
        }

        protected static void Register<T>(string name)
            where T: EnumObject
        {
            if (_descriptors.TryGetValue(typeof(T), out EnumObjectDescriptor descriptor))
            {
                descriptor.RegisterValue(name);
                return;
            }
            Debug.Assert(false, "EnumObject was not initialized.");
        }

        protected static void Close<T>()
            where T : EnumObject
        {
            if (_descriptors.TryGetValue(typeof(T), out EnumObjectDescriptor descriptor))
            {
                descriptor.Close();
                return;
            }
            Debug.Assert(false, "EnumObject was not initialized.");
        }

        public T As<T>()
            where T: EnumObject
        {
            if (!this.IsAssignableFrom(typeof(T))) throw new InvalidOperationException(typeof(T) + " is not assignable from "+ this.GetType() + ".");
            if (_descriptors.TryGetValue(typeof(T), out EnumObjectDescriptor descriptor))
            {
                return (T)descriptor.GetValue(_value);
            }
            throw new InvalidOperationException(typeof(T) + " does not define a retargeting constructor.");
        }

        public T Cast<T>()
            where T : EnumObject
        {
            if (!this.IsAssignableFrom(typeof(T))) throw new InvalidOperationException(typeof(T) + " is not assignable from " + this.GetType() + ".");
            if (_descriptors.TryGetValue(this.GetType(), out EnumObjectDescriptor descriptor))
            {
                return (T)descriptor.GetValue(_value);
            }
            throw new InvalidOperationException(typeof(T) + " does not define a retargeting constructor.");
        }

        public static T ByValue<T>(int intValue)
            where T: EnumObject
        {
            foreach (var value in EnumValues(typeof(T)))
            {
                if (value.Value == intValue) return value.As<T>();
            }
            return null;
        }

        public static T ByName<T>(string name)
            where T : EnumObject
        {
            foreach (var value in EnumValues(typeof(T)))
            {
                if (value.Name == name) return value.As<T>();
            }
            return null;
        }

        public override string ToString()
        {
            return _name;
        }

        private class EnumObjectDescriptor
        {
            private Type _type;
            private List<EnumObjectDescriptor> _baseDescriptors;
            private int _maxValue;
            private bool _closed;
            private List<EnumObject> _values = new List<EnumObject>();
            private EnumObject[] _cachedValues;

            public EnumObjectDescriptor(Type type)
            {
                _type = type;
                _baseDescriptors = new List<EnumObjectDescriptor>();
                _maxValue = 0;
                Type baseType = type.BaseType;
                if (baseType != null && baseType != typeof(EnumObject))
                {
                    if (_descriptors.TryGetValue(baseType, out EnumObjectDescriptor baseDescriptor))
                    {
                        Debug.Assert(baseDescriptor._closed, baseType + " is not closed.");
                        _baseDescriptors.AddRange(baseDescriptor._baseDescriptors);
                        _baseDescriptors.Add(baseDescriptor);
                        _maxValue = baseDescriptor._maxValue;
                    }
                    else
                    {
                        Debug.Assert(false, baseType + " is not initialized.");
                    }
                }
            }

            public EnumObjectDescriptor(Type type, int value, EnumObjectDescriptor directBaseDescriptor = null, IEnumerable<EnumObjectDescriptor> indirectBaseDescriptors = null)
            {
                _type = type;
                _baseDescriptors = indirectBaseDescriptors == null ? new List<EnumObjectDescriptor>() : new List<EnumObjectDescriptor>(indirectBaseDescriptors);
                if (directBaseDescriptor != null) _baseDescriptors.Add(directBaseDescriptor);
                _maxValue = value;
            }

            public Type Type => _type;
            public int MaxValue => _maxValue;
            public bool IsClosed => _closed;
            public IReadOnlyList<EnumObject> Values => _values;

            public void Close()
            {
                _closed = true;
                _cachedValues = new EnumObject[_maxValue];
                int valuesCount = _values.Count;
                for (int i = valuesCount - 1; i >= 0; i--)
                {
                    _cachedValues[_maxValue - valuesCount + i] = _values[i];
                }
                for (int i = 0; i < _maxValue - valuesCount; i++)
                {
                    _cachedValues[i] = CreateValue(this.BaseDescriptor.GetValue(i + 1));
                }
            }

            public EnumObject GetValue(int value)
            {
                if (value < 1 || value > _maxValue) throw new ArgumentOutOfRangeException(nameof(value));
                if (_closed)
                {
                    return _cachedValues[value - 1];
                }
                else
                {
                    int valuesCount = _values.Count;
                    if (value >= _maxValue - valuesCount + 1) return _values[value - 1];
                    else return this.BaseDescriptor?.GetValue(value);
                }
            }

            private EnumObjectDescriptor BaseDescriptor => _baseDescriptors.Count == 0 ? null : _baseDescriptors[_baseDescriptors.Count - 1];

            private EnumObject CreateValue(EnumObject value)
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
                return null;
            }

            private EnumObject CreateValue(string name)
            {
                var nameConstructor = _type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, nameConstructorSignature, null);
                if (nameConstructor != null)
                {
                    var result = (EnumObject)nameConstructor.Invoke(new object[] { name });
                    result._value = ++_maxValue;
                    return result;
                }
                throw new InvalidOperationException(_type+" must have a string constructor.");
            }

            public void RegisterValue(string name)
            {
                _values.Add(CreateValue(name));
            }

            public bool IsDescendantOf(EnumObjectDescriptor other)
            {
                return _baseDescriptors.Contains(other);
            }

            public IEnumerable<EnumObject> AllValues
            {
                get
                {
                    if (_closed)
                    {
                        foreach (var value in _cachedValues)
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
        public static T As<T>(this string name)
            where T : EnumObject
        {
            return EnumObject.ByName<T>(name);
        }

        public static T As<T>(this int value)
            where T : EnumObject
        {
            return EnumObject.ByValue<T>(value);
        }
    }

	
	/*
	    public class LanguageVersion : EnumObject
    {
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
            EnumObject.Init<LanguageVersion>();
            EnumObject.Register<LanguageVersion>(Default);
            EnumObject.Register<LanguageVersion>(Latest);
            EnumObject.Close<LanguageVersion>();
        }

        public const string Default = nameof(Default);
        public const string Latest = nameof(Latest);

        public static explicit operator LanguageVersion(int value)
        {
            if (EnumObject.TryGetValue<LanguageVersion>(value, out var result)) return result;
            else return null;
        }

        public static explicit operator int(LanguageVersion value)
        {
            return value.Value;
        }

        public static implicit operator LanguageVersion(string name)
        {
            if (EnumObject.TryParse<LanguageVersion>(name, out var result)) return result;
            else return null;
        }

        public static implicit operator string(LanguageVersion value)
        {
            return value.Name;
        }

        public new static IEnumerable<EnumObject> EnumValues => EnumObject.EnumValues(typeof(LanguageVersion));
    }
	*/
}
