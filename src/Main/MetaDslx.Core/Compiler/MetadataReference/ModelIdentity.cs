using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public sealed partial class ModelIdentity : IEquatable<ModelIdentity>
    {
        // not null, not empty:
        private readonly string _name;

        // no version: 0.0.0.0
        private readonly ModelVersion _version;

        // cached display name
        private string _lazyDisplayName;

        // cached hash code
        private int _lazyHashCode;

        public ModelIdentity(string name, ModelVersion version = default)
        {
            if (!IsValidName(name))
            {
                throw new ArgumentException(string.Format(CompilerResources.InvalidModelName, name), nameof(name));
            }
            // Version allows more values then can be encoded in metadata:
            if (!IsValid(version))
            {
                throw new ArgumentOutOfRangeException(nameof(version));
            }
            _name = name;
            _version = version;
        }

        private ModelIdentity(ModelIdentity other, ModelVersion version)
        {
            Debug.Assert((object)other != null);
            Debug.Assert((object)version != null);
            _name = other._name;
            _version = version;
        }

        public string Name { get { return _name; } }
        public ModelVersion Version { get { return _version; } }

        public ModelIdentity WithVersion(ModelVersion version) => (version == _version) ? this : new ModelIdentity(this, version);

        private static bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name) && name.IndexOf('\0') < 0;
        }

        public readonly static ModelVersion NullVersion = new ModelVersion(0, 0, 0, 0);

        private static bool IsValid(ModelVersion value)
        {
            return value == null
                || value.Major >= 0
                && value.Minor >= 0
                && value.Build >= 0
                && value.Revision >= 0
                && value.Major <= ushort.MaxValue
                && value.Minor <= ushort.MaxValue
                && value.Build <= ushort.MaxValue
                && value.Revision <= ushort.MaxValue;
        }

        /// <summary>
        /// Determines whether the specified instance is equal to the current instance.
        /// </summary>
        /// <param name="obj">The object to be compared with the current instance.</param>
        public bool Equals(ModelIdentity obj)
        {
            return !ReferenceEquals(obj, null)
                && (_lazyHashCode == 0 || obj._lazyHashCode == 0 || _lazyHashCode == obj._lazyHashCode)
                && MemberwiseEqual(this, obj) == true;
        }

        /// <summary>
        /// Returns true (false) if specified model identities are (not) equal. 
        /// </summary>
        internal static bool? MemberwiseEqual(ModelIdentity x, ModelIdentity y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x._name != y._name)
            {
                return false;
            }

            if (x._version == y._version)
            {
                return true;
            }

            return null;
        }

        /// <summary>
        /// Determines whether the specified instance is equal to the current instance.
        /// </summary>
        /// <param name="obj">The object to be compared with the current instance.</param>
        public override bool Equals(object obj)
        {
            return Equals(obj as ModelIdentity);
        }

        internal static bool IsFullName(ModelIdentityParts parts)
        {
            const ModelIdentityParts nvc = ModelIdentityParts.Name | ModelIdentityParts.Version;
            return (parts & nvc) == nvc;
        }

        /// <summary>
        /// Returns the hash code for the current instance.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (_lazyHashCode == 0)
            {
                _lazyHashCode = Hash.Combine(_name, _version.GetHashCode());
            }

            return _lazyHashCode;
        }

        /// <summary>
        /// Retrieves model definition identity from given runtime model.
        /// </summary>
        /// <param name="model">The runtime model.</param>
        /// <returns>Assembly definition identity.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="model"/> is null.</exception>
        public static ModelIdentity FromModel(ImmutableModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new ModelIdentity(model.Name, model.Version);
        }
    }
}