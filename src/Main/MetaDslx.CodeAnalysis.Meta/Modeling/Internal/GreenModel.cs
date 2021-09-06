using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis;
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
        private readonly ModelMetadata metadata;
        private readonly ImmutableList<ObjectId> strongObjects;
        // TODO: replace with immutable weak dictionaries:
        private readonly ImmutableDictionary<ObjectId, GreenObject> objects;
        private readonly ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>> lazyProperties;
        private readonly ImmutableDictionary<ObjectId, ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>>> references;

        internal GreenModel(ModelId id, ModelMetadata metadata)
        {
            Debug.Assert(id != null);
            Debug.Assert(metadata != null);
            this.id = id;
            this.metadata = metadata;
            this.objects = ImmutableDictionary<ObjectId, GreenObject>.Empty;
            this.strongObjects = ImmutableList<ObjectId>.Empty;
            this.lazyProperties = ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>>.Empty;
            this.references = ImmutableDictionary<ObjectId, ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>>>.Empty;
        }

        private GreenModel(
            ModelId id,
            ModelMetadata metadata,
            ImmutableDictionary<ObjectId, GreenObject> objects,
            ImmutableList<ObjectId> strongObjects,
            ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>> lazyProperties,
            ImmutableDictionary<ObjectId, ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>>> references)
        {
            Debug.Assert(id != null);
            Debug.Assert(metadata != null);
            Debug.Assert(objects != null);
            Debug.Assert(lazyProperties != null);
            Debug.Assert(references != null);
            this.id = id;
            this.metadata = metadata;
            this.objects = objects;
            this.strongObjects = strongObjects;
            this.lazyProperties = lazyProperties;
            this.references = references;
        }

        internal GreenModel Update(
            ModelMetadata metadata,
            ImmutableDictionary<ObjectId, GreenObject> objects,
            ImmutableList<ObjectId> strongObjects,
            ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>> lazyProperties,
            ImmutableDictionary<ObjectId, ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>>> references)
        {
            if (this.metadata != metadata || this.objects != objects || 
                this.strongObjects != strongObjects || 
                this.lazyProperties != lazyProperties || this.references != references)
            {
                return new GreenModel(this.id, metadata, objects, strongObjects, lazyProperties, references);
            }
            return this;
        }

        internal ModelId Id { get { return this.id; } }
        internal ModelMetadata Metadata { get { return this.metadata; } }
        internal ImmutableDictionary<ObjectId, GreenObject> Objects { get { return this.objects; } }
        internal ImmutableList<ObjectId> StrongObjects { get { return this.strongObjects; } }
        internal ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>> LazyProperties { get { return this.lazyProperties; } }
        internal ImmutableDictionary<ObjectId, ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>>> References { get { return this.references; } }

        internal GreenModel AddObject(ObjectId oid, bool weak)
        {
            Debug.Assert(!this.objects.ContainsKey(oid), "The green model already contains this object.");
            return this.Update(this.metadata, this.objects.Add(oid, oid.Descriptor.EmptyGreenObject), weak ? this.strongObjects : this.strongObjects.Add(oid), this.lazyProperties, this.references);
        }

        internal GreenModel RemoveObject(ObjectId oid)
        {
            Debug.Assert(!this.lazyProperties.ContainsKey(oid));
            ImmutableDictionary<ObjectId, GreenObject> objects = this.objects;
            ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>> refs;
            if (this.references.TryGetValue(oid, out refs))
            {
                foreach (var refEntry in refs)
                {
                    GreenObject green;
                    if (this.objects.TryGetValue(refEntry.Key, out green))
                    {
                        GreenObject oldGreen = green;
                        foreach (var slot in refEntry.Value)
                        {
                            object value;
                            if (green.Slots.TryGetValue(slot, out value))
                            {
                                if (value is GreenList)
                                {
                                    GreenList list = (GreenList)value;
                                    green = green.Update(
                                        green.Parent == oid ? null : green.Parent,
                                        green.Children.RemoveAll(item => item == oid),
                                        green.Slots.SetItem(slot, list.RemoveAll(oid)));
                                }
                                else if ((ObjectId)value == oid)
                                {
                                    green = green.Update(
                                        green.Parent == oid ? null : green.Parent,
                                        green.Children.RemoveAll(item => item == oid),
                                        green.Slots.SetItem(slot, GreenObject.Unassigned));
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
                    this.metadata,
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
            ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>> refs;
            if (this.references.TryGetValue(oid, out refs))
            {
                ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>> targetRefs;
                if (!this.references.TryGetValue(targetOid, out targetRefs))
                {
                    targetRefs = ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>>.Empty;
                }
                foreach (var refEntry in refs)
                {
                    GreenObject green;
                    if (this.objects.TryGetValue(refEntry.Key, out green))
                    {
                        GreenObject oldGreen = green;
                        ImmutableHashSet<Slot> targetSlots;
                        if (!targetRefs.TryGetValue(refEntry.Key, out targetSlots))
                        {
                            targetSlots = ImmutableHashSet<Slot>.Empty;
                        }
                        foreach (var slot in refEntry.Value)
                        {
                            object value;
                            if (green.Slots.TryGetValue(slot, out value))
                            {
                                if (value is GreenList)
                                {
                                    GreenList list = (GreenList)value;
                                    green = green.Update(
                                        green.Parent == oid ? targetOid : green.Parent,
                                        green.Children.Replace(oid, targetOid),
                                        green.Slots.SetItem(slot, list.Replace(oid, targetOid)));
                                    targetSlots = targetSlots.Add(slot);
                                }
                                else if ((ObjectId)value == oid)
                                {
                                    green = green.Update(
                                        green.Parent == oid ? targetOid : green.Parent,
                                        green.Children.Replace(oid, targetOid),
                                        green.Slots.SetItem(slot, targetOid));
                                    targetSlots = targetSlots.Add(slot);
                                }
                            }
                        }
                        if (green != oldGreen)
                        {
                            objects.SetItem(refEntry.Key, green);
                        }
                        if (targetSlots.Count > 0)
                        {
                            targetRefs = targetRefs.SetItem(refEntry.Key, targetSlots);
                        }
                    }
                }
                return this.Update(
                    this.metadata,
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
            return this.Update(this.metadata, objects, this.strongObjects, this.lazyProperties, references);
        }

        public override string ToString()
        {
            return this.Metadata.Name + " (" + this.Metadata.Version + ")";
        }

        public string ToFullString()
        {
            return this.Metadata.Name + " (" + this.Metadata.Version + ": " + this.Id.Guid + ")";
        }
    }
}
