using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Roslyn.Utilities
{
    // TODO: make it thread-safe
    public class FlagsObject : IEquatable<FlagsObject>, IEnumerable<FlagsObject>
    {
        private ExtensibleBitVector _flags;
        private string _name;

        private static readonly Dictionary<Type, FlagsObjectDescriptor> _descriptors = new Dictionary<Type, FlagsObjectDescriptor>();
        private static readonly object[] emptyObjectArray = new object[0];
        private static readonly FlagsObject[] emptyFlagsObjectArray = new FlagsObject[0];
        private static readonly Type[] nameConstructorSignature = new Type[] { typeof(string) };
        private static readonly Type[] bitVectorConstructorSignature = new Type[] { typeof(ExtensibleBitVector) };
        private static readonly Type[] retargetingConstructorSignature = new Type[] { typeof(FlagsObject) };
        private static readonly Type[] lazyConstructorSignature = new Type[] { typeof(Func<FlagsObject>) };

        protected FlagsObject(string name)
        {
            _name = name;
            _flags = ExtensibleBitVector.Empty;
        }

        protected FlagsObject(FlagsObject retargetedValue)
        {
            Debug.Assert(retargetedValue._name != null || !retargetedValue._flags.IsNull);
            if (retargetedValue._name == null)
            {
                var descriptor = GetDescriptor(this.GetType());
                _name = descriptor?.GetName(retargetedValue._flags);
            }
            else
            {
                _name = retargetedValue._name;
            }
            if (retargetedValue._flags.IsNull)
            {
                var descriptor = GetDescriptor(this.GetType());
                _flags = descriptor?.GetValue(retargetedValue._name)?._flags ?? default;
            }
            else
            {
                _flags = retargetedValue._flags;
            }
        }

        private FlagsObject(string name, ExtensibleBitVector flags)
        {
            _name = name;
            _flags = flags;
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
                return descriptor.GetName(_flags);
            }
        }

        public static bool TryParse<T>(string name, out T enumValue)
            where T : FlagsObject
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

        public int GetEnumValue()
        {
            return TryGetEnumValue(out int enumValue) ? enumValue : 0;
        }

        public bool TryGetEnumValue(out int enumValue)
        {
            enumValue = 0;
            ExtensibleBitVector flags;
            if (_flags != null)
            {
                flags = _flags;
            }
            else if (_name != null)
            {
                var descriptor = GetDescriptor(this.GetType());
                if (!descriptor.TryGetValue(_name, out FlagsObject flagsObject))
                {
                    return false;
                }
                flags = flagsObject._flags;
            }
            else
            {
                return false;
            }
            return flags.TryGetSingleBit(out enumValue);
        }

        public static IEnumerable<FlagsObject> GetEnumValues(Type flagsType)
        {
            var descriptor = GetDescriptor(flagsType);
            return descriptor.AllEnumValues;
        }

        public static IEnumerable<FlagsObject> GetFlagValues(Type enumType)
        {
            var descriptor = GetDescriptor(enumType);
            return descriptor.AllFlagValues;
        }

        protected static Func<T> Create<T>(params object[] flags)
            where T: FlagsObject
        {
            var descriptor = EnsureInit<T>();
            if (descriptor.IsClosed) throw new InvalidOperationException("Cannot create new flags once the static initialization of the type is finished.");
            return () => (T)descriptor.CreateValue(flags);
        }

        public static T Union<T>(params FlagsObject[] flags)
            where T : FlagsObject
        {
            var descriptor = GetDescriptor(typeof(T));
            return (T)descriptor.CreateValue(flags);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as FlagsObject);
        }

        public bool Equals(FlagsObject other)
        {
            if ((object)other == null) return false;
            if (_flags.IsNull) return other._flags.IsNull;
            if (!other.IsAssignableFrom(this.GetType())) return false;
            return other._flags == _flags;
        }

        public static bool operator ==(FlagsObject left, FlagsObject right)
        {
            if ((object)left == null) return (object)right == null;
            return left.Equals(right);
        }

        public static bool operator !=(FlagsObject left, FlagsObject right)
        {
            if ((object)left == null) return (object)right != null;
            return !left.Equals(right);
        }

        public static bool operator ==(FlagsObject left, string right)
        {
            if ((object)left == null) return (object)right == null;
            var descriptor = GetDescriptor(left.GetType());
            return descriptor.TryGetValue(right, out FlagsObject rightValue) && left._flags == rightValue._flags;
        }

        public static bool operator !=(FlagsObject left, string right)
        {
            if ((object)left == null) return (object)right != null;
            var descriptor = GetDescriptor(left.GetType());
            return !descriptor.TryGetValue(right, out FlagsObject rightValue) || left._flags != rightValue._flags;
        }

        public static bool operator ==(FlagsObject left, int right)
        {
            if ((object)left == null) return (object)right == null;
            var descriptor = GetDescriptor(left.GetType());
            return descriptor.TryGetValue(right, out FlagsObject rightValue) && left._flags == rightValue._flags;
        }

        public static bool operator !=(FlagsObject left, int right)
        {
            if ((object)left == null) return (object)right != null;
            var descriptor = GetDescriptor(left.GetType());
            return !descriptor.TryGetValue(right, out FlagsObject rightValue) || left._flags != rightValue._flags;
        }

        public static FlagsObject operator &(FlagsObject left, FlagsObject right)
        {
            return left.IntersectWith(right);
        }

        public static FlagsObject operator |(FlagsObject left, FlagsObject right)
        {
            return left.UnionWith(right);
        }

        public static implicit operator FlagsObject(string name)
        {
            if (FlagsObject.TryParse<FlagsObject>(name, out var result)) return result;
            else return null;
        }

        public static explicit operator int(FlagsObject value)
        {
            return value.GetEnumValue();
        }

        public static explicit operator string(FlagsObject value)
        {
            return value.GetName();
        }

        public override int GetHashCode()
        {
            return Hash.Combine(_name.GetHashCode(), _flags.GetHashCode());
        }

        public bool HasAnyFlags
        {
            get { return _flags.IsNonZero; }
        }

        public bool IsEnumValue
        {
            get { return _flags.HasSingleBit(); }
        }

        public bool HasNoFlags
        {
            get { return _flags.IsZero; }
        }

        public bool Includes(FlagsObject flags)
        {
            if (flags == null) return this.HasNoFlags;
            return _flags.IncludesAll(flags._flags);
        }

        public bool IncludesAll(params FlagsObject[] flags)
        {
            if (flags.Length == 0) return true;
            foreach (var flag in flags)
            {
                if (!_flags.IncludesAll(flag._flags)) return false;
            }
            return true;
        }

        public bool IncludesAny(params FlagsObject[] flags)
        {
            if (flags.Length == 0) return false;
            foreach (var flag in flags)
            {
                if (_flags.IncludesAll(flag._flags)) return true;
            }
            return false;
        }

        public int GetFlagCount()
        {
            if (_flags.IsNull || _flags.IsZero) return 0;
            return _flags.TrueBits().Count();
        }

        private Type RetargetParametersToThisType(Type minimumType, FlagsObject[] flags)
        {
            Type resultType = minimumType;
            Type thisType = this.GetType();
            if (resultType == null || resultType.IsAssignableFrom(thisType)) resultType = thisType;
            for (int i = 0; i < flags.Length; i++)
            {
                var flag = flags[i];
                Type flagType = flag.GetType();
                if (resultType != flagType && resultType.IsAssignableFrom(flagType)) resultType = flagType;
            }
            var descriptor = GetDescriptor(resultType);
            for (int i = 0; i < flags.Length; i++)
            {
                var flag = flags[i];
                if (flag._flags.IsNull) flags[i] = descriptor.GetValue(flag._name);
            }
            return resultType;
        }

        public TFlags UnionWith<TFlags>(params FlagsObject[] flags)
            where TFlags : FlagsObject
        {
            if (flags.Length == 0)
            {
                if (typeof(TFlags).IsAssignableFrom(this.GetType())) return (TFlags)this;
                else return (TFlags)CreateValue(typeof(TFlags), this._flags);
            }
            Type resultType = RetargetParametersToThisType(typeof(TFlags), flags);
            ExtensibleBitVector union = _flags.Clone();
            bool changed = false;
            foreach (var flag in flags)
            {
                changed = union.UnionWith(flag._flags) || changed;
            }
            if (changed) return (TFlags)CreateValue(resultType, union);
            else if (typeof(TFlags).IsAssignableFrom(this.GetType())) return (TFlags)this;
            else return (TFlags)CreateValue(typeof(TFlags), this._flags);
        }

        public TFlags UnionWith<TFlags>(params TFlags[] flags)
            where TFlags: FlagsObject
        {
            return this.UnionWith<TFlags>((FlagsObject[])flags);
        }

        public TFlags IntersectWith<TFlags>(params FlagsObject[] flags)
            where TFlags : FlagsObject
        {
            if (flags.Length == 0)
            {
                if (typeof(TFlags).IsAssignableFrom(this.GetType())) return (TFlags)this;
                else return (TFlags)CreateValue(typeof(TFlags), this._flags);
            }
            Type resultType = RetargetParametersToThisType(typeof(TFlags), flags);
            ExtensibleBitVector union = _flags.Clone();
            bool changed = false;
            foreach (var flag in flags)
            {
                changed = union.IntersectWith(flag._flags) || changed;
            }
            if (changed) return (TFlags)CreateValue(resultType, union);
            else if (typeof(TFlags).IsAssignableFrom(this.GetType())) return (TFlags)this;
            else return (TFlags)CreateValue(typeof(TFlags), this._flags);
        }

        public TFlags IntersectWith<TFlags>(params TFlags[] flags)
            where TFlags : FlagsObject
        {
            return this.IntersectWith<TFlags>((FlagsObject[])flags);
        }

        public TFlags UnsetWith<TFlags>(params FlagsObject[] flags)
            where TFlags : FlagsObject
        {
            if (flags.Length == 0)
            {
                if (typeof(TFlags).IsAssignableFrom(this.GetType())) return (TFlags)this;
                else return (TFlags)CreateValue(typeof(TFlags), this._flags);
            }
            Type resultType = RetargetParametersToThisType(typeof(TFlags), flags);
            ExtensibleBitVector union = _flags.Clone();
            bool changed = false;
            foreach (var flag in flags)
            {
                changed = union.UnsetWith(flag._flags) || changed;
            }
            if (changed) return (TFlags)CreateValue(resultType, union);
            else if (typeof(TFlags).IsAssignableFrom(this.GetType())) return (TFlags)this;
            else return (TFlags)CreateValue(typeof(TFlags), this._flags);
        }

        public TFlags UnsetWith<TFlags>(params TFlags[] flags)
            where TFlags : FlagsObject
        {
            return this.UnsetWith<TFlags>((FlagsObject[])flags);
        }

        public IEnumerator<FlagsObject> GetEnumerator()
        {
            var descriptor = GetDescriptor(this.GetType());
            foreach (var value in _flags.TrueBits())
            {
                yield return descriptor.GetValue(value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool IsDescendantOf(Type type)
        {
            if (_descriptors.TryGetValue(type, out FlagsObjectDescriptor otherDescriptor) &&
                _descriptors.TryGetValue(this.GetType(), out FlagsObjectDescriptor myDescriptor))
            {
                return otherDescriptor.IsDescendantOf(myDescriptor);
            }
            return false;
        }

        public bool IsAncestorOf(Type type)
        {
            if (_descriptors.TryGetValue(type, out FlagsObjectDescriptor otherDescriptor) &&
                _descriptors.TryGetValue(this.GetType(), out FlagsObjectDescriptor myDescriptor))
            {
                return myDescriptor.IsDescendantOf(otherDescriptor);
            }
            return false;
        }

        public bool IsAssignableFrom(Type type)
        {
            if (type == this.GetType()) return true;
            if (_descriptors.TryGetValue(type, out FlagsObjectDescriptor otherDescriptor) &&
                _descriptors.TryGetValue(this.GetType(), out FlagsObjectDescriptor myDescriptor))
            {
                return myDescriptor.IsDescendantOf(otherDescriptor) || otherDescriptor.IsDescendantOf(myDescriptor);
            }
            return false;
        }

        protected static void AutoInit<T>()
            where T : FlagsObject
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

        private static FlagsObjectDescriptor EnsureInit<T>()
            where T: FlagsObject
        {
            if (_descriptors.TryGetValue(typeof(T), out FlagsObjectDescriptor descriptor))
            {
                return descriptor;
            }
            else
            {
                descriptor = new FlagsObjectDescriptor(typeof(T));
                _descriptors.Add(typeof(T), descriptor);
                return descriptor;
            }
        }

        protected static void Register<T>(string name, Func<T> lazyValue)
            where T : FlagsObject
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (lazyValue == null) throw new ArgumentNullException(nameof(lazyValue));
            var descriptor = EnsureInit<T>();
            Debug.Assert(!descriptor.IsClosed);
            descriptor.RegisterLazyValue(name, lazyValue);
        }

        protected static void RegisterDefault<T>(string name)
            where T : FlagsObject
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            var descriptor = EnsureInit<T>();
            Debug.Assert(!descriptor.IsClosed);
            descriptor.RegisterDefaultValue(name);
        }

        protected static void RegisterAlias<T>(string name)
            where T : FlagsObject
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            var descriptor = EnsureInit<T>();
            Debug.Assert(!descriptor.IsClosed);
            descriptor.RegisterAlias(name);
        }

        protected static void Close<T>()
            where T : FlagsObject
        {
            var descriptor = EnsureInit<T>();
            Debug.Assert(!descriptor.IsClosed);
            descriptor.Close();
        }

        public FlagsObject Cast(Type enumType)
        {
            if (enumType.IsAssignableFrom(this.GetType())) return this;
            if (!this.IsAssignableFrom(enumType)) throw new InvalidOperationException($"{enumType} is not a descendant of {this.GetType()}.");
            var descriptor = GetDescriptor(enumType);
            if (descriptor.TryGetValue(_name, out FlagsObject result)) return result;
            else throw new InvalidOperationException($"{enumType} does not contain the enum literal '{_name}' declared in {this.GetType()}.");
        }

        public T Cast<T>()
            where T : FlagsObject
        {
            return (T)Cast(typeof(T));
        }

        public FlagsObject CastUnsafe(Type enumType)
        {
            if (enumType.IsAssignableFrom(this.GetType())) return this;
            else return FromIntUnsafe(enumType, this.GetEnumValue());
        }

        public T CastUnsafe<T>()
            where T : FlagsObject
        {
            return (T)CastUnsafe(typeof(T));
        }

        public FlagsObject As(Type enumType)
        {
            if (enumType.IsAssignableFrom(this.GetType())) return this;
            if (!this.IsAssignableFrom(enumType)) throw new InvalidOperationException($"{enumType} is not a descendant of {this.GetType()}.");
            var descriptor = GetDescriptor(this.GetType());
            if (descriptor.TryGetValue(_name, out FlagsObject result)) return result;
            else throw new InvalidOperationException($"{enumType} does not contain the enum literal '{_name}' declared in {this.GetType()}.");
        }

        public T As<T>()
            where T : FlagsObject
        {
            return (T)As(typeof(T));
        }

        public static FlagsObject ByValue(Type enumType, int value)
        {
            if (value < 1) return null;
            var descriptor = GetDescriptor(enumType);
            if (descriptor.TryGetValue(value, out FlagsObject result)) return result;
            return null;
        }

        public static T ByValue<T>(int value)
            where T : FlagsObject
        {
            return (T)ByValue(typeof(T), value);
        }

        public static FlagsObject ByName(Type enumType, string name)
        {
            if (name == null) return null;
            var descriptor = GetDescriptor(enumType);
            if (descriptor.TryGetValue(name, out FlagsObject result)) return result;
            return null;
        }

        public static T ByName<T>(string name)
            where T : FlagsObject
        {
            return (T)ByName(typeof(T), name);
        }

        public static FlagsObject FromString(Type enumType, string name)
        {
            return ByName(enumType, name) ?? throw new ArgumentException($"Enum literal '{name}' does not exist in {enumType}.", nameof(name));
        }

        public static T FromString<T>(string name)
            where T : FlagsObject
        {
            return (T)FromString(typeof(T), name);
        }

        public static FlagsObject FromInt(Type enumType, int value)
        {
            return ByValue(enumType, value) ?? throw new ArgumentException($"Enum literal of value '{value}' does not exist in {enumType}.", nameof(value));
        }

        public static T FromInt<T>(int value)
            where T : FlagsObject
        {
            return (T)FromInt(typeof(T), value);
        }

        public static FlagsObject FromIntUnsafe(Type enumType, int value)
        {
            FlagsObject result = ByValue(enumType, value);
            if ((object)result != null) return result;
            var descriptor = GetDescriptor(enumType);
            if (descriptor.TryGetValue(value, out FlagsObject stored)) return stored;
            else return descriptor.CreateValue(new FlagsObject(null, ExtensibleBitVector.Create(value)));
        }

        public static T FromIntUnsafe<T>(int value)
            where T : FlagsObject
        {
            return (T)FromIntUnsafe(typeof(T), value);
        }

        public static FlagsObject GetDefault(Type flagsType)
        {
            var descriptor = GetDescriptor(flagsType);
            return descriptor.DefaultValue ?? new FlagsObject(null, default);
        }

        public static T GetDefault<T>()
            where T : FlagsObject
        {
            return (T)GetDefault(typeof(T));
        }

        public override string ToString()
        {
            if (this.GetFlagCount() > 1) return string.Format("{0} ({1})", this.GetName(), this.GetFlagsAsString());
            else return this.GetName();
        }

        public string GetFlagsAsString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var value in this)
            {
                if (sb.Length > 0) sb.Append(", ");
                sb.Append(value);
            }
            return sb.ToString();
        }

        internal static FlagsObjectDescriptor GetDescriptor(Type type)
        {
            FlagsObjectDescriptor descriptor;
            if (_descriptors.TryGetValue(type, out descriptor))
            {
                return descriptor;
            }
            RuntimeHelpers.RunClassConstructor(type.TypeHandle);
            if (_descriptors.TryGetValue(type, out descriptor))
            {
                return descriptor;
            }
            if (type == typeof(FlagsObject))
            {
                return FlagsObjectDescriptor.Root;
            }
            throw new ArgumentException("Invalid FlagsObject type: "+type);
        }

        internal static FlagsObjectDescriptor GetDescriptor(params Type[] type)
        {
            if (type.Length == 0) return GetDescriptor(typeof(FlagsObject));
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

        private FlagsObject CreateValue(Type type, ExtensibleBitVector value)
        {
            var descriptor = GetDescriptor(type);
            return descriptor.GetValue(value);
        }

        internal class FlagsObjectDescriptor
        {
            public static readonly FlagsObjectDescriptor Root = CreateRoot();

            private Type _type;
            private List<FlagsObjectDescriptor> _baseDescriptors;
            private int _maxValue;
            private bool _closed;
            private string _defaultName;
            private FlagsObject _defaultValue;
            private HashSet<string> _aliases = new HashSet<string>();
            private List<FlagsObject> _values = new List<FlagsObject>();
            private List<LazyInfo> _lazyValues = new List<LazyInfo>();
            private FlagsObject[] _cachedByValue;
            private Dictionary<ExtensibleBitVector, FlagsObject> _cachedByBitVector;
            private Dictionary<string, FlagsObject> _cachedByName = new Dictionary<string, FlagsObject>();

            public FlagsObjectDescriptor(Type type)
            {
                _type = type;
                _baseDescriptors = new List<FlagsObjectDescriptor>();
                _maxValue = 0;
                Type baseType = type.BaseType;
                if (baseType != null && baseType != typeof(FlagsObject))
                {
                    RuntimeHelpers.RunClassConstructor(baseType.TypeHandle);
                    if (_descriptors.TryGetValue(baseType, out FlagsObjectDescriptor baseDescriptor))
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

            private FlagsObjectDescriptor()
            {
                _type = typeof(FlagsObject);
                _baseDescriptors = new List<FlagsObjectDescriptor>();
                _maxValue = 0;
                _defaultName = null;
                _cachedByValue = new FlagsObject[0];
                _cachedByBitVector = new Dictionary<ExtensibleBitVector, FlagsObject>();
                _closed = true;
            }

            private static FlagsObjectDescriptor CreateRoot()
            {
                FlagsObjectDescriptor result = new FlagsObjectDescriptor();
                _descriptors.Add(typeof(FlagsObject), result);
                return result;
            }

            public Type Type => _type;
            public int MaxValue => _maxValue;
            public bool IsClosed => _closed;
            public IReadOnlyList<FlagsObject> Values => _values;

            public void Close()
            {
                if (_defaultName != null && (object)_defaultValue == null)
                {
                    Interlocked.CompareExchange(ref _defaultValue, CreateValue(_defaultName), null);
                    _cachedByName[_defaultName] = _defaultValue;
                }
                if (_lazyValues != null)
                {
                    foreach (var lazy in _lazyValues)
                    {
                        if (lazy.IsUnique)
                        {
                            if ((object)_cachedByName[lazy.Name] == null)
                            {
                                var value = CreateValue(lazy.Name);
                                _values.Add(value);
                                _cachedByName[lazy.Name] = value;
                            }
                        }
                    }
                }
                _cachedByValue = new FlagsObject[_maxValue];
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
                if (_lazyValues != null)
                {
                    foreach (var lazy in _lazyValues)
                    {
                        if (!lazy.IsUnique)
                        {
                            var value = lazy.LazyValue();
                            value._name = lazy.Name;
                            if ((object)_cachedByName[lazy.Name] == null) _cachedByName[lazy.Name] = value;
                            else throw new InvalidOperationException($"Enum literal '{lazy.Name}' is registered multiple times in {_type}.");
                        }
                    }
                    _lazyValues = null;
                }
                _cachedByBitVector = new Dictionary<ExtensibleBitVector, FlagsObject>();
                foreach (var entry in _cachedByName)
                {
                    _cachedByBitVector.Add(entry.Value._flags, entry.Value);
                }
                _closed = true;
            }

            public bool TryGetValue(int value, out FlagsObject flagsObject)
            {
                flagsObject = null;
                if (value == 0)
                {
                    flagsObject = this.DefaultValue;
                    return (object)flagsObject != null;
                }
                if (value < 1 || value > _maxValue) return false;
                if (_closed)
                {
                    flagsObject = _cachedByValue[value - 1];
                    return true;
                }
                else
                {
                    int valuesCount = _values.Count;
                    if (value >= _maxValue - valuesCount + 1)
                    {
                        flagsObject = _values[value - 1];
                        return true;
                    }
                    else
                    {
                        flagsObject = this.BaseDescriptor?.GetValue(value);
                        return flagsObject != null;
                    }
                }
            }

            public FlagsObject DefaultValue
            {
                get
                {
                    if (_defaultName != null && (object)_defaultValue == null)
                    {
                        Interlocked.CompareExchange(ref _defaultValue, CreateValue(_defaultName), null);
                        _cachedByName[_defaultName] = _defaultValue;
                    }
                    return _defaultValue;
                }
            }

            public FlagsObject GetValue(int value)
            {
                if (TryGetValue(value, out FlagsObject result)) return result;
                else throw new ArgumentOutOfRangeException(nameof(value));
            }

            public string GetName(ExtensibleBitVector value)
            {
                if (_cachedByBitVector != null && _cachedByBitVector.TryGetValue(value, out FlagsObject flagsObject))
                {
                    return flagsObject._name;
                }
                return null;
            }

            public FlagsObject GetValue(ExtensibleBitVector value)
            {
                if (_cachedByBitVector != null && _cachedByBitVector.TryGetValue(value, out FlagsObject flagsObject))
                {
                    return flagsObject;
                }
                return CreateValue(new FlagsObject(null, value));
            }

            public bool TryGetValue(string name, out FlagsObject flagsObject)
            {
                flagsObject = null;
                if (name == null) return false;
                if (_closed)
                {
                    return _cachedByName.TryGetValue(name, out flagsObject);
                }
                else
                {
                    foreach (var value in _values)
                    {
                        if (value._name == name)
                        {
                            flagsObject = value;
                            return true;
                        }
                    }
                    flagsObject = this.BaseDescriptor?.GetValue(name);
                    return flagsObject != null;
                }
            }

            public FlagsObject GetValue(string name)
            {
                if (name == null) throw new ArgumentNullException(nameof(name));
                if (TryGetValue(name, out FlagsObject result)) return result;
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

            private FlagsObjectDescriptor BaseDescriptor => _baseDescriptors.Count == 0 ? null : _baseDescriptors[_baseDescriptors.Count - 1];

            private FlagsObject CreateValue(string name)
            {
                var nameConstructor = _type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, nameConstructorSignature, null);
                if (nameConstructor != null)
                {
                    var result = (FlagsObject)nameConstructor.Invoke(new object[] { name });
                    result._flags[++_maxValue] = true;
                    return result;
                }
                throw new InvalidOperationException(_type + " must have a string constructor.");
            }

            public FlagsObject CreateValue(FlagsObject value)
            {
                var retargetingConstructor = _type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, retargetingConstructorSignature, null);
                if (retargetingConstructor != null)
                {
                    return (FlagsObject)retargetingConstructor.Invoke(new object[] { value });
                }
                var baseDescriptor = this.BaseDescriptor;
                if (baseDescriptor != null)
                {
                    return baseDescriptor.CreateValue(value);
                }
                throw new InvalidOperationException(_type + " must have a retargeting constructor.");
            }

            public FlagsObject CreateValue(object[] values)
            {
                var retargetingConstructor = _type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, retargetingConstructorSignature, null);
                if (retargetingConstructor != null)
                {
                    var flags = ExtensibleBitVector.Empty;
                    foreach (var value in values)
                    {
                        if (value is string name) flags.UnionWith(GetValue(name)._flags);
                        else if (value is FlagsObject flagsObject) flags.UnionWith(flagsObject._flags);
                        else throw new InvalidOperationException("Invalid FlagsObject: "+value);
                    }
                    return (FlagsObject)retargetingConstructor.Invoke(new object[] { new FlagsObject(null, flags) });
                }
                throw new InvalidOperationException(_type + " must have a retargeting constructor.");
            }

            public void RegisterUniqueValue(string name)
            {
                if (!_cachedByName.ContainsKey(name))
                {
                    _lazyValues.Add(LazyInfo.Unique(name));
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

            public void RegisterLazyValue(string name, Func<FlagsObject> value)
            {
                if (_cachedByName.ContainsKey(name))
                {
                    throw new InvalidOperationException($"Duplicate enum literal '{name}' in {_type}. If you want to create an alias, use RegisterAlias() in the static initializer.");
                }
                _lazyValues.Add(LazyInfo.Lazy(name, value));
                _cachedByName.Add(name, null);
            }

            public void RegisterAlias(string name)
            {
                if (!_cachedByName.ContainsKey(name))
                {
                    throw new InvalidOperationException($"Duplicate enum literal '{name}' in {_type}. If you want to create an alias, use RegisterAlias() in the static initializer.");
                }
                _aliases.Add(name);
            }

            public bool IsAlias(string name)
            {
                return _aliases.Contains(name);
            }

            public bool IsDescendantOf(FlagsObjectDescriptor other)
            {
                return _baseDescriptors.Contains(other);
            }

            public IEnumerable<FlagsObject> AllEnumValues
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
                                yield return CreateValue(value);
                            }
                        }
                        foreach (var value in _values)
                        {
                            yield return value;
                        }
                    }
                }
            }

            public IEnumerable<FlagsObject> AllFlagValues
            {
                get
                {
                    if (_closed)
                    {
                        foreach (var entry in _cachedByName)
                        {
                            yield return entry.Value;
                        }
                    }
                    else
                    {
                        var baseDescriptor = this.BaseDescriptor;
                        if (baseDescriptor != null)
                        {
                            foreach (var value in baseDescriptor.AllFlagValues)
                            {
                                yield return CreateValue(value); 
                            }
                        }
                        foreach (var value in _values)
                        {
                            yield return value;
                        }
                    }
                }
            }

            private struct LazyInfo
            {
                public bool IsUnique;
                public string Name;
                public Func<FlagsObject> LazyValue;

                public static LazyInfo Unique(string name)
                {
                    LazyInfo result = default;
                    result.Name = name;
                    result.IsUnique = true;
                    return result;
                }

                public static LazyInfo Lazy(string name, Func<FlagsObject> value)
                {
                    LazyInfo result = default;
                    result.Name = name;
                    result.LazyValue = value;
                    return result;
                }
            }
        }
    }

    public static class FlagsObjectExtensions
    {
        public static T As<T>(this string name)
            where T : FlagsObject
        {
            return FlagsObject.ByName<T>(name);
        }

        public static T As<T>(this int value)
            where T : FlagsObject
        {
            return FlagsObject.ByValue<T>(value);
        }
    }

    /* Template:
    
    public class BindingFlags : FlagsObject
    {
        public const string None = nameof(None);
        public const string BindName = nameof(BindName);
        public const string BindNamespace = nameof(BindNamespace);
        public const string BindType = nameof(BindType);
        public const string BindNameOrType = nameof(BindNameOrType);
        public const string BindNameOrNamespaceOrType = nameof(BindNameOrNamespaceOrType);
        public const string Last = BindNameOrNamespaceOrType;

        protected BindingFlags(string name) : base(name)
        {
        }

        protected BindingFlags(FlagsObject flags) : base(flags)
        {
        }

        static BindingFlags()
        {
            Register(BindNameOrType, Create<BindingFlags>(BindName, BindType));
            Register(BindNameOrNamespaceOrType, Create<BindingFlags>(BindNamespace, BindNameOrType));
            RegisterAlias<BindingFlags>(Last);
            FlagsObject.AutoInit<BindingFlags>();
        }

        public static implicit operator BindingFlags(string name)
        {
            return FromString<BindingFlags>(name);
        }
        
        public static explicit operator BindingFlags(int value)
        {
            return FromIntUnsafe<BindingFlags>(value);
        }

        public static BindingFlags operator &(BindingFlags left, FlagsObject right)
        {
            return right?.IntersectWith(left) ?? GetDefault<BindingFlags>();
        }

        public static BindingFlags operator |(BindingFlags left, FlagsObject right)
        {
            return right?.UnionWith(left) ?? left;
        }
    }
    */
}
