using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.References
{
    public sealed class ModelIdentity : IEquatable<ModelIdentity>
    {
        // not null, not empty:
        private readonly string _name;

        private readonly ModelId _id;

        // no version: 0
        private readonly int _version;

        // cached display name
        private string _lazyDisplayName;

        // cached hash code
        private int _lazyHashCode;

        public ModelIdentity(string name, ModelId id, int version = 0)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            _name = name;
            _id = id;
            _version = version;
        }

        private ModelIdentity(ModelIdentity other, int version)
        {
            _name = other._name;
            _id = other._id;
            _version = version;
        }

        public string Name { get { return _name; } }
        public ModelId Id { get { return _id; } }
        public int Version { get { return _version; } }

        internal ModelIdentity WithVersion(int version) => (version == _version) ? this : new ModelIdentity(this, version);

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

            if (!ReferenceEquals(x._id, y._id))
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

        /// <summary>
        /// Returns the hash code for the current instance.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (_lazyHashCode == 0)
            {
                _lazyHashCode =
                    Hash.Combine(_name,
                    Hash.Combine(_id.GetHashCode(),
                    Hash.Combine(_version.GetHashCode(), GetHashCodeIgnoringNameAndVersion())));
            }

            return _lazyHashCode;
        }

        internal int GetHashCodeIgnoringNameAndVersion()
        {
            return _id.GetHashCode();
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

            return new ModelIdentity(model.Name, model.Id);
        }
    }
}