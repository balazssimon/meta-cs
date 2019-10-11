using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Modeling.Internal
{
    internal class GreenModel
    {
        private readonly ModelId id;
        private readonly string name;
        private readonly ModelVersion version;
        private readonly ImmutableList<ObjectId> strongObjects;
        // TODO: replace with immutable weak dictionaries:
        private readonly ImmutableDictionary<ObjectId, GreenObject> objects;
        private readonly ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>> lazyProperties;
        private readonly ImmutableDictionary<ObjectId, ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>>> references;

        internal GreenModel(ModelId id, string name, ModelVersion version)
        {
            this.id = id;
            this.name = name;
            this.version = version;
            this.objects = ImmutableDictionary<ObjectId, GreenObject>.Empty;
            this.strongObjects = ImmutableList<ObjectId>.Empty;
            this.lazyProperties = ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>>.Empty;
            this.references = ImmutableDictionary<ObjectId, ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>>>.Empty;
        }

        private GreenModel(ModelId id,
            string name,
            ModelVersion version,
            ImmutableDictionary<ObjectId, GreenObject> objects,
            ImmutableList<ObjectId> strongObjects,
            ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>> lazyProperties,
            ImmutableDictionary<ObjectId, ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>>> references)
        {
            Debug.Assert(objects != null);
            Debug.Assert(lazyProperties != null);
            Debug.Assert(references != null);
            this.id = id;
            this.name = name;
            this.version = version;
            this.objects = objects;
            this.strongObjects = strongObjects;
            this.lazyProperties = lazyProperties;
            this.references = references;
        }

        internal GreenModel Update(
            string name,
            ModelVersion version,
            ImmutableDictionary<ObjectId, GreenObject> objects,
            ImmutableList<ObjectId> strongObjects,
            ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>> lazyProperties,
            ImmutableDictionary<ObjectId, ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>>> references)
        {
            if (this.name != name || this.version != version || this.objects != objects || 
                this.strongObjects != strongObjects || 
                this.lazyProperties != lazyProperties || this.references != references)
            {
                return new GreenModel(this.id, name, version, objects, strongObjects, lazyProperties, references);
            }
            return this;
        }

        internal ModelId Id { get { return this.id; } }
        internal string Name { get { return this.name; } }
        internal ModelVersion Version { get { return this.version; } }
        internal ImmutableDictionary<ObjectId, GreenObject> Objects { get { return this.objects; } }
        internal ImmutableList<ObjectId> StrongObjects { get { return this.strongObjects; } }
        internal ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>> LazyProperties { get { return this.lazyProperties; } }
        internal ImmutableDictionary<ObjectId, ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>>> References { get { return this.references; } }

        internal GreenModel AddObject(ObjectId oid, bool weak)
        {
            Debug.Assert(!this.objects.ContainsKey(oid), "The green model already contains this object.");
            return this.Update(this.name, this.version, this.objects.Add(oid, oid.Descriptor.EmptyGreenObject), weak ? this.strongObjects : this.strongObjects.Add(oid), this.lazyProperties, this.references);
        }

        internal GreenModel RemoveObject(ObjectId oid)
        {
            Debug.Assert(!this.lazyProperties.ContainsKey(oid));
            ImmutableDictionary<ObjectId, GreenObject> objects = this.objects;
            ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>> refs;
            if (this.references.TryGetValue(oid, out refs))
            {
                foreach (var refEntry in refs)
                {
                    GreenObject green;
                    if (this.objects.TryGetValue(refEntry.Key, out green))
                    {
                        GreenObject oldGreen = green;
                        foreach (var prop in refEntry.Value)
                        {
                            object value;
                            if (green.Properties.TryGetValue(prop, out value))
                            {
                                if (value is GreenList)
                                {
                                    GreenList list = (GreenList)value;
                                    green = green.Update(
                                        green.Parent == oid ? null : green.Parent,
                                        green.Children.RemoveAll(item => item == oid),
                                        green.Properties.SetItem(prop, list.RemoveAll(oid)));
                                }
                                else if ((ObjectId)value == oid)
                                {
                                    green = green.Update(
                                        green.Parent == oid ? null : green.Parent,
                                        green.Children.RemoveAll(item => item == oid),
                                        green.Properties.SetItem(prop, GreenObject.Unassigned));
                                }
                            }
                        }
                        if (green != oldGreen)
                        {
                            objects.SetItem(refEntry.Key, green);
                        }
                    }
                }
                return this.Update(
                    this.name,
                    this.version,
                    objects.Remove(oid),
                    this.strongObjects.Remove(oid),
                    this.lazyProperties.Remove(oid),
                    this.references.Remove(oid));
            }
            return this;
        }

        internal GreenModel ReplaceObject(ObjectId oid, ObjectId targetOid)
        {
            Debug.Assert(!this.lazyProperties.ContainsKey(oid));
            ImmutableDictionary<ObjectId, GreenObject> objects = this.objects;
            ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>> refs;
            if (this.references.TryGetValue(oid, out refs))
            {
                ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>> targetRefs;
                if (!this.references.TryGetValue(targetOid, out targetRefs))
                {
                    targetRefs = ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>>.Empty;
                }
                foreach (var refEntry in refs)
                {
                    GreenObject green;
                    if (this.objects.TryGetValue(refEntry.Key, out green))
                    {
                        GreenObject oldGreen = green;
                        ImmutableHashSet<ModelProperty> targetProps;
                        if (!targetRefs.TryGetValue(refEntry.Key, out targetProps))
                        {
                            targetProps = ImmutableHashSet<ModelProperty>.Empty;
                        }
                        foreach (var prop in refEntry.Value)
                        {
                            object value;
                            if (green.Properties.TryGetValue(prop, out value))
                            {
                                if (value is GreenList)
                                {
                                    GreenList list = (GreenList)value;
                                    green = green.Update(
                                        green.Parent == oid ? targetOid : green.Parent,
                                        green.Children.Replace(oid, targetOid),
                                        green.Properties.SetItem(prop, list.Replace(oid, targetOid)));
                                    targetProps = targetProps.Add(prop);
                                }
                                else if ((ObjectId)value == oid)
                                {
                                    green = green.Update(
                                        green.Parent == oid ? targetOid : green.Parent,
                                        green.Children.Replace(oid, targetOid),
                                        green.Properties.SetItem(prop, targetOid));
                                    targetProps = targetProps.Add(prop);
                                }
                            }
                        }
                        if (green != oldGreen)
                        {
                            objects.SetItem(refEntry.Key, green);
                        }
                        if (targetProps.Count > 0)
                        {
                            targetRefs = targetRefs.SetItem(refEntry.Key, targetProps);
                        }
                    }
                }
                return this.Update(
                    this.name,
                    this.version,
                    objects.Remove(oid),
                    this.strongObjects.Remove(oid), 
                    this.lazyProperties.Remove(oid), 
                    targetRefs.Count > 0 ? this.references.Remove(oid).SetItem(targetOid, targetRefs) : this.references.Remove(oid));
            }
            return this;
        }

        internal GreenModel PurgeWeakObjects(HashSet<ObjectId> strongObjects)
        {
            var objects = this.objects;
            var references = this.references;
            foreach (var id in this.objects.Keys)
            {
                if (!strongObjects.Contains(id))
                {
                    objects = objects.Remove(id);
                    references = references.Remove(id);
                }
            }
            return this.Update(this.name, this.version, objects, this.strongObjects, this.lazyProperties, references);
        }

        public override string ToString()
        {
            return this.Name + " (" + this.Version + ")";
        }

        public string ToFullString()
        {
            return this.Name + " (" + this.Version + ": " + this.Id.Guid + ")";
        }
    }
}
