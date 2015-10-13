using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    public class ImmutableModel
    {
        internal ImmutableModel oldModel;
        internal ImmutableArray<ImmutableEntry> entries;

        public ImmutableModel()
        {
            this.oldModel = null;
            this.entries = ImmutableArray<ImmutableEntry>.Empty;
        }

        public ImmutableModel(ImmutableModel oldModel)
        {
            this.oldModel = oldModel;
            this.entries = oldModel.entries;
        }

        private ImmutableModel(ImmutableModel oldModel, ImmutableArray<ImmutableEntry> entries)
        {
            this.oldModel = oldModel;
            this.entries = entries;
        }

        internal ImmutableEntry GetEntry(int index)
        {
            ImmutableEntry entry = null;
            if (index >= 0 && index < this.entries.Length)
            {
                entry = this.entries[index];
                if (entry != null)
                {
                    return entry;
                }
                else if (this.oldModel != null)
                {
                    return this.oldModel.GetEntry(index);
                }
            }
            return null;
        }

        internal ImmutableModel WithObject(ImmutableObject obj)
        {
            if (obj == null) return this;
            if (obj.MModel != null)
            {
                throw new ArgumentException("The immutable object should not have a model yet.", nameof(obj));
            }
            ImmutableModel newModel = null;
            if (obj.index >= 0)
            {
                ImmutableEntry oldEntry = this.GetEntry(obj.index);
                newModel = this.WithEntry(new ImmutableEntry(obj, oldEntry.Associations));
            }
            else 
            {
                newModel = this.WithEntry(new ImmutableEntry(obj));
            }
            if (obj.MModel == null)
            {
                obj.MModel = newModel;
            }
            return newModel;
        }

        internal ImmutableModel WithEntry(ImmutableEntry entry)
        {
            int index = entry.Object.index;
            if (index >= 0 && index < this.entries.Length)
            {
                return new ImmutableModel(this, this.entries.SetItem(index, entry));
            }
            else if (index < 0)
            {
                entry.Object.index = this.entries.Length;
                return new ImmutableModel(this, this.entries.Add(entry));
            }
            else
            {
                throw new ArgumentException("Invalid object index in entry.", nameof(entry));
            }
        }
    }

    public class ImmutableObject
    {
        internal int index;
        public ImmutableModel MModel { get; internal set; }

        public ImmutableObject()
        {
            this.index = -1;
            this.MModel = null;
        }

        internal ImmutableObject(ImmutableModel model)
        {
            this.index = -1;
            this.MModel = model;
        }

        internal ImmutableObject(ImmutableModel model, int index)
        {
            this.index = index;
            this.MModel = model;
        }

        public ImmutableObject MWith(ModelProperty property, ImmutableObject value)
        {
            if (this.MModel != null && this.index >= 0)
            {
                ImmutableEntry oldEntry = this.MModel.GetEntry(this.index);
                if (oldEntry != null)
                {
                    // TODO: opposite properties
                    ImmutableEntry newEntry = oldEntry.With(property, new ImmutableAssociation(value.index, ImmutableArray<ModelProperty>.Empty));
                    ImmutableModel newModel = this.MModel.WithEntry(newEntry);
                    return new ImmutableObject(newModel, this.index);
                }
            }
            throw new InvalidOperationException("Cannot find object with index: " + this.index);
        }
    }

    public class ImmutableAssociation
    {
        public ImmutableAssociation(int targetObject, ImmutableArray<ModelProperty> oppositeProperties)
        {
            this.TargetObject = targetObject;
            this.OppositeProperties = oppositeProperties;
        }

        public int TargetObject { get; private set; }
        public ImmutableArray<ModelProperty> OppositeProperties { get; private set; }
    }


    internal class ImmutableEntry
    {
        public ImmutableEntry(ImmutableObject obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            this.Object = obj;
            this.Associations = ImmutableDictionary<ModelProperty, ImmutableArray<ImmutableAssociation>>.Empty;
        }

        public ImmutableEntry(ImmutableObject obj, ImmutableDictionary<ModelProperty, ImmutableArray<ImmutableAssociation>> assoc)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            this.Object = obj;
            this.Associations = assoc;
        }

        public ImmutableEntry With(ModelProperty prop, ImmutableAssociation assoc)
        {
            ImmutableArray<ImmutableAssociation> oldAssocs = ImmutableArray<ImmutableAssociation>.Empty;
            if (this.Associations.TryGetValue(prop, out oldAssocs))
            {
                if (prop.IsCollection)
                {
                    ImmutableAssociation oldAssoc = oldAssocs.FirstOrDefault(a => a.TargetObject == assoc.TargetObject);
                    if (oldAssoc == null)
                    {
                        return new ImmutableEntry(this.Object, this.Associations.SetItem(prop, oldAssocs.Add(assoc)));
                    }
                    else
                    {
                        return new ImmutableEntry(this.Object, this.Associations.SetItem(prop, oldAssocs.Replace(oldAssoc, assoc)));
                    }
                }
                else
                {
                    return new ImmutableEntry(this.Object, ImmutableDictionary<ModelProperty, ImmutableArray<ImmutableAssociation>>.Empty.SetItem(prop, ImmutableArray.Create<ImmutableAssociation>(assoc)));
                }
            }
            else
            {
                return new ImmutableEntry(this.Object, this.Associations.Add(prop, ImmutableArray.Create<ImmutableAssociation>(assoc)));
            }
        }

        public ImmutableObject Object { get; private set; }
        public ImmutableDictionary<ModelProperty, ImmutableArray<ImmutableAssociation>> Associations { get; private set; }
    }
}
