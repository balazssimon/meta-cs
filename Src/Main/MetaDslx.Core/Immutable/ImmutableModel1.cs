using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable1
{
    public sealed class ImmutableModel
    {
        private static object StaticModelLock = new object();
        private static int ModelCounter;

        internal int ModelNumber { get; private set; }
        internal ImmutableModel OldModel { get; private set; }
        internal ImmutableArray<ImmutableEntry> Entries { get; set; }
        internal ImmutableDictionary<int, ImmutableModel> Models { get; set; }

        internal ImmutableModel()
        {
            this.OldModel = null;
            this.Entries = ImmutableArray<ImmutableEntry>.Empty;
            this.Models = ImmutableDictionary<int, ImmutableModel>.Empty;
            lock (ImmutableModel.StaticModelLock)
            {
                ++ImmutableModel.ModelCounter;
                this.ModelNumber = ImmutableModel.ModelCounter;
            }
        }

        internal ImmutableModel(ImmutableModel oldModel)
        {
            this.OldModel = oldModel;
            this.ModelNumber = this.OldModel.ModelNumber;
            this.Entries = oldModel.Entries;
            this.Models = oldModel.Models;
        }

        internal ImmutableModel GetModel(ImmutableModel model)
        {
            if (model == null) return null;
            int number = model.ModelNumber;
            if (model.ModelNumber == this.ModelNumber) return this;
            ImmutableModel newModel = null;
            if (this.Models.TryGetValue(number, out newModel))
            {
                return newModel;
            }
            else
            {
                return model;
            }
        }

        internal ImmutableEntry GetEntry(int index)
        {
            ImmutableEntry entry = ImmutableEntry.Empty;
            if (index >= 0 && index < this.Entries.Length)
            {
                entry = this.Entries[index];
                if (entry.Object != null)
                {
                    return entry;
                }
                else if (this.OldModel != null)
                {
                    return this.OldModel.GetEntry(index);
                }
                throw new InvalidOperationException("Invalid entry.");
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid entry index.");
            }
        }

        public ImmutableObject GetObject(IImmutableObjectBuilder builder)
        {
            if (builder == null || builder.MObject == null) return null;
            if (builder.MObject.Model.ModelNumber != this.ModelNumber)
            {
                return this.GetModel(builder.MObject.Model).GetObject(builder);
            }
            else
            {
                return this.GetEntry(builder.MObject.Index).Object;
            }
        }

        public object Get(ImmutableObject obj, ModelProperty property)
        {
            if (obj.Model != null && obj.Index >= 0)
            {
                ImmutableModel model = this.GetModel(obj.Model);
                ImmutableEntry entry = model.GetEntry(obj.Index);
                if (entry.Object != null)
                {
                    object value = null;
                    if (entry.PropertyValues.TryGetValue(property, out value))
                    {
                        IImmutableModelCollection coll = value as IImmutableModelCollection;
                        if (coll != null)
                        {
                            return coll.ToArray(model);
                        }
                        return value;
                    }
                }
                return null;
            }
            return null;
        }

        /*
        internal ImmutableModel(ImmutableModel oldModel, ImmutableArray<ImmutableEntry> entries)
        {
            this.OldModel = oldModel;
            this.ModelNumber = this.OldModel.ModelNumber;
            this.Entries = entries;
            this.Models = oldModel.Models;
        }

        internal ImmutableModel(ImmutableModel oldModel, ImmutableDictionary<int, ImmutableModel> models)
        {
            this.OldModel = oldModel;
            this.ModelNumber = this.OldModel.ModelNumber;
            this.Entries = oldModel.Entries;
            this.Models = models;
        }

        public int ObjectCount
        {
            get { return this.Entries.Length; }
        }

        public ImmutableModel With(ImmutableModel model)
        {
            if (model == null) return this;
            ImmutableModel oldModel = null;
            if (model.ModelNumber == this.ModelNumber)
            {
                return this;
            }
            else if (this.Models.TryGetValue(model.ModelNumber, out oldModel) && object.ReferenceEquals(oldModel, model))
            {
                return this;
            }
            else
            {
                return new ImmutableModel(this, this.Models.SetItem(model.ModelNumber, model));
            }
        }

        public ImmutableModel With(ImmutableObject originalObject, ModelProperty property, object value)
        {
            if (originalObject == null || originalObject.MModel == null) return this;
            if (property == null) return this;
            ImmutableModel newModel = this;
            if (originalObject.MModel.Add(originalObject, property, value, true, ref newModel))
            {
                return newModel;
            }
            else
            {
                return this;
            }
        }

        public ImmutableModel Without(ImmutableObject originalObject, ModelProperty property, object value)
        {
            if (originalObject == null || originalObject.MModel == null) return this;
            if (property == null) return this;
            ImmutableModel newModel = this;
            if (originalObject.MModel.Remove(originalObject, property, value, true, ref newModel))
            {
                return newModel;
            }
            else
            {
                return this;
            }
        }

        public object Get(ImmutableObject obj, ModelProperty property)
        {
            if (obj.MModel != null && obj.Index >= 0)
            {
                ImmutableEntry entry = obj.MModel.GetEntry(obj.Index);
                if (entry.Object != null)
                {
                    object value = null;
                    if (entry.PropertyValues.TryGetValue(property, out value))
                    {
                        if (object.ReferenceEquals(obj.MModel, this))
                        {
                            IImmutableModelCollection coll = value as IImmutableModelCollection;
                            if (coll != null)
                            {
                                return coll.ToArray(this);
                            }
                        }
                        return value;
                    }
                }
                return null;
            }
            return null;
        }

        internal object GetOriginalValue(ImmutableObject obj, ModelProperty property)
        {
            if (obj.MModel != null && obj.Index >= 0)
            {
                ImmutableEntry oldEntry = obj.MModel.GetEntry(obj.Index);
                if (oldEntry.Object != null)
                {
                    object value = null;
                    if (oldEntry.PropertyValues.TryGetValue(property, out value))
                    {
                        return value;
                    }
                }
                return null;
            }
            return null;
        }

        internal object GetOriginalValue(ImmutableEntry entry, ModelProperty property)
        {
            if (entry.Object != null)
            {
                object value = null;
                if (entry.PropertyValues.TryGetValue(property, out value))
                {
                    return value;
                }
            }
            return null;
        }

        internal bool SetOriginalValue(ImmutableObject obj, ModelProperty property, object value, ref ImmutableModel newModel)
        {
            if (obj.MModel != null && obj.Index >= 0 && obj.MModel.ModelNumber == this.ModelNumber)
            {
                ImmutableEntry oldEntry = obj.MModel.GetEntry(obj.Index);
                if (oldEntry.Object != null)
                {
                    ImmutableEntry newEntry = new ImmutableEntry(oldEntry.Object, oldEntry.PropertyValues.SetItem(property, value));
                    newModel = newModel.WithEntry(newEntry);
                    return true;
                }
                return false;
            }
            else
            {
                throw new NotImplementedException("Change the object through it's own model.");
            }
        }

        internal bool SetOriginalValue(ImmutableEntry entry, ModelProperty property, object value, ref ImmutableModel newModel)
        {
            if (entry.Object != null && entry.Object.MModel.ModelNumber == this.ModelNumber)
            {
                ImmutableEntry newEntry = new ImmutableEntry(entry.Object, entry.PropertyValues.SetItem(property, value));
                newModel = newModel.WithEntry(newEntry);
                return true;
            }
            else
            {
                throw new NotImplementedException("Change the object through it's own model.");
            }
        }

        private bool Add(ImmutableObject obj, ModelProperty property, object value, bool firstCall, ref ImmutableModel newModel)
        {
            bool result = false;
            bool added = false;
            ImmutableEntry oldEntry = this.GetEntry(obj.Index);
            object oldValue = this.GetOriginalValue(oldEntry, property);
            IImmutableModelCollection oldCollection = oldValue as IImmutableModelCollection;
            if (oldCollection != null)
            {
                IImmutableModelCollection newCollection = oldCollection.Add(value);
                if (value != null && !object.ReferenceEquals(newCollection, oldCollection))
                {
                    added = true;
                    result = this.SetOriginalValue(oldEntry, property, newCollection, ref newModel);
                }
                else if (value != null && firstCall)
                {
                    added = true;
                }
            }
            else
            {
                if (value != oldValue)
                {
                    if (oldValue != null)
                    {
                        this.Remove(obj, property, oldValue, false, ref newModel);
                    }
                    result = this.SetOriginalValue(oldEntry, property, value, ref newModel);
                    added = value != null;
                }
                else
                {
                    added = value != null && firstCall;
                }
            }
            if (added)
            {
                List<ModelProperty> cachedOppositeProperties = property.OppositeProperties.ToList();
                if (cachedOppositeProperties.Count > 0)
                {
                    ImmutableObject oppositeObject = value as ImmutableObject;
                    if (oppositeObject != null)
                    {
                        List<ModelProperty> allOppositeProperies = oppositeObject.MGetAllProperties().ToList();
                        foreach (ModelProperty oppositeProperty in cachedOppositeProperties)
                        {
                            if (allOppositeProperies.Contains(oppositeProperty))
                            {
                                result |= this.Add(oppositeObject, oppositeProperty, this, false, ref newModel);
                            }
                        }
                    }
                    else
                    {
                        throw new ModelException("Error adding the current object " + this.GetType().Name + "." + property.Name + " to the opposite object. The current object must be a descendant of " + typeof(ImmutableObject) + ".");
                    }
                }
            }
            return result;
        }

        private bool Remove(ImmutableObject obj, ModelProperty property, object value, bool firstCall, ref ImmutableModel newModel)
        {
            bool result = false;
            bool removed = false;
            ImmutableEntry oldEntry = this.GetEntry(obj.Index);
            object oldValue = this.GetOriginalValue(oldEntry, property);
            IImmutableModelCollection oldCollection = oldValue as IImmutableModelCollection;
            if (oldCollection != null)
            {
                IImmutableModelCollection newCollection = oldCollection.Remove(value);
                if (value != null && !object.ReferenceEquals(newCollection, oldCollection))
                {
                    removed = true;
                    result = this.SetOriginalValue(oldEntry, property, newCollection, ref newModel);
                }
                else if (value != null && firstCall)
                {
                    removed = true;
                }
            }
            else
            {
                if (value == oldValue)
                {
                    if (oldValue != null)
                    {
                        result = this.SetOriginalValue(oldEntry, property, null, ref newModel);
                        removed = value != null;
                    }
                }
            }
            if (removed)
            {
                List<ModelProperty> cachedOppositeProperties = property.OppositeProperties.ToList();
                if (cachedOppositeProperties.Count > 0)
                {
                    ImmutableObject oppositeObject = value as ImmutableObject;
                    if (oppositeObject != null)
                    {
                        List<ModelProperty> allOppositeProperies = oppositeObject.MGetAllProperties().ToList();
                        foreach (ModelProperty oppositeProperty in cachedOppositeProperties)
                        {
                            if (allOppositeProperies.Contains(oppositeProperty))
                            {
                                result |= this.Remove(oppositeObject, oppositeProperty, this, false, ref newModel);
                            }
                        }
                    }
                    else
                    {
                        throw new ModelException("Error removing the current object " + this.GetType().Name + "." + property.Name + " to the opposite object. The current object must be a descendant of " + typeof(ImmutableObject) + ".");
                    }
                }
            }
            return result;
        }

        internal ImmutableEntry GetEntry(int index)
        {
            ImmutableEntry entry = ImmutableEntry.Empty;
            if (index >= 0 && index < this.Entries.Length)
            {
                entry = this.Entries[index];
                if (entry.Object != null)
                {
                    return entry;
                }
                else if (this.OldModel != null)
                {
                    return this.OldModel.GetEntry(index);
                }
                throw new InvalidOperationException("Invalid entry.");
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid entry index.");
            }
        }

        public ImmutableModel GetModel(ImmutableModel.Builder modelBuilder)
        {
            if (modelBuilder == null || modelBuilder.Model == null) return null;
            int number = modelBuilder.Model.ModelNumber;
            if (modelBuilder.Model.ModelNumber == this.ModelNumber) return this;
            ImmutableModel model = null;
            if (this.Models.TryGetValue(number, out model))
            {
                return model;
            }
            else
            {
                return modelBuilder.Model;
            }
        }

        public ImmutableModel GetModel(ImmutableModel model)
        {
            if (model == null) return null;
            int number = model.ModelNumber;
            if (model.ModelNumber == this.ModelNumber) return this;
            ImmutableModel newModel = null;
            if (this.Models.TryGetValue(number, out newModel))
            {
                return newModel;
            }
            else
            {
                return model;
            }
        }

        internal ImmutableModel WithNewObject(ImmutableObject obj)
        {
            if (obj == null) return this;
            if (obj.MModel != this)
            {
                throw new ArgumentException("The new object has the wrong model.", nameof(obj));
            }
            if (obj.Index == this.Entries.Length)
            {
                return new ImmutableModel(this, this.Entries.Add(new ImmutableEntry(obj)));
            }
            else if (obj.Index >= 0 && obj.Index < this.Entries.Length)
            {
                throw new ArgumentException("The new object collides with an existing object.", nameof(obj));
            }
            else
            {
                throw new ArgumentException("The new object has the wrong index.", nameof(obj));
            }
        }

        internal ImmutableModel WithEntry(ImmutableEntry entry)
        {
            int index = entry.Object.Index;
            if (index >= 0 && index < this.Entries.Length)
            {
                return new ImmutableModel(this, this.Entries.SetItem(index, entry));
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid entry index.");
            }
        }
        */
        public Builder ToBuilder()
        {
            return new Builder(this);
        }

        public static Builder CreateBuilder()
        {
            return new Builder(new ImmutableModel());
        }

        public sealed class Builder
        {
            internal ImmutableModel OldModel { get; private set; }
            internal ImmutableModel NewModel { get; private set; }
            private List<ImmutableEntry.Builder> changedEntries;
            private Dictionary<int, ImmutableModel.Builder> changedModels;

            internal Builder(ImmutableModel model)
            {
                this.OldModel = model;
                this.NewModel = new ImmutableModel(this.OldModel);
            }

            public int ObjectCount
            {
                get { return this.changedEntries == null ? this.OldModel.Entries.Length : this.changedEntries.Count; }
            }

            private void RequireChangedEntries()
            {
                if (this.changedEntries == null)
                {
                    this.changedEntries = new List<ImmutableEntry.Builder>(OldModel.Entries.Length);
                    for (int i = 0; i < OldModel.Entries.Length; i++)
                    {
                        this.changedEntries.Add(null);
                    }
                }
            }

            private void RequireChangedModels()
            {
                if (this.changedModels == null)
                {
                    this.changedModels = new Dictionary<int, Builder>();
                }
            }

            private ImmutableEntry.Builder GetEntry(int index)
            {
                this.RequireChangedEntries();
                if (this.changedEntries[index] == null)
                {
                    this.changedEntries[index] = this.OldModel.Entries[index].ToBuilder(this);
                }
                return this.changedEntries[index];
            }

            public ImmutableModel.Builder GetModelBuilder(ImmutableModel model)
            {
                if (model == null) return null;
                if (model.ModelNumber == this.OldModel.ModelNumber) return this;
                this.RequireChangedModels();
                ImmutableModel.Builder modelBuilder = null;
                if (!this.changedModels.TryGetValue(model.ModelNumber, out modelBuilder))
                {
                    modelBuilder = model.ToBuilder();
                    this.changedModels.Add(model.ModelNumber, modelBuilder);
                }
                return modelBuilder;
            }

            public ImmutableModel GetNewModel(ImmutableModel model)
            {
                if (model == null) return null;
                if (model.ModelNumber == this.OldModel.ModelNumber) return this.NewModel;
                this.RequireChangedModels();
                ImmutableModel.Builder modelBuilder = null;
                if (!this.changedModels.TryGetValue(model.ModelNumber, out modelBuilder))
                {
                    modelBuilder = model.ToBuilder();
                    this.changedModels.Add(model.ModelNumber, modelBuilder);
                }
                return modelBuilder.NewModel;
            }

            private IImmutableObjectBuilder GetObject(int index)
            {
                return this.GetEntry(index).Object;
            }

            public IImmutableObjectBuilder GetObject(ImmutableObject obj)
            {
                if (obj.Model.ModelNumber == this.OldModel.ModelNumber)
                {
                    return this.GetObject(obj.Index);
                }
                else
                {
                    return this.GetModelBuilder(obj.Model).GetObject(obj);
                }
            }

            internal ImmutableModel WithNewObject(ImmutableObject obj)
            {
                if (obj == null) return this.NewModel;
                if (obj.Model != this.NewModel)
                {
                    throw new ArgumentException("The new object has the wrong model.", nameof(obj));
                }
                if (obj.Index == this.ObjectCount)
                {
                    this.RequireChangedEntries();
                    this.changedEntries.Add(new ImmutableEntry(obj).ToBuilder(this));
                }
                else if (obj.Index >= 0 && obj.Index < this.ObjectCount)
                {
                    throw new ArgumentException("The new object collides with an existing object.", nameof(obj));
                }
                else
                {
                    throw new ArgumentException("The new object has the wrong index.", nameof(obj));
                }
                return this.NewModel;
            }

            public ImmutableModel.Builder With(ImmutableModel model)
            {
                if (model == null) return null;
                if (model.ModelNumber == this.OldModel.ModelNumber) return this;
                this.RequireChangedModels();
                ImmutableModel.Builder modelBuilder = null;
                if (this.changedModels.TryGetValue(model.ModelNumber, out modelBuilder))
                {
                    if (!object.ReferenceEquals(modelBuilder.OldModel, model))
                    {
                        throw new ArgumentException("The builder already contains a builder for another version of the model.", nameof(model));
                    }
                }
                else
                {
                    modelBuilder = model.ToBuilder();
                    this.changedModels.Add(model.ModelNumber, modelBuilder);
                }
                return modelBuilder;
            }

            public object Get(IImmutableObjectBuilder builder, ModelProperty property)
            {
                if (builder == null || builder.MObject == null || builder.MModelBuilder == null) return null;
                if (builder.MModelBuilder != this)
                {
                    return builder.MModelBuilder.Get(builder, property);
                }
                int index = builder.MObject.Index;
                return this.Get(index, property);
            }

            public object Get(int index, ModelProperty property)
            {
                object valueBuilder = null;
                var entryBuilder = this.GetEntry(index);
                if (entryBuilder.PropertyValues.TryGetValue(property, out valueBuilder))
                {
                    return valueBuilder;
                }
                else if (index >= 0 && index < this.OldModel.Entries.Length)
                {
                    object value = null;
                    ImmutableEntry oldEntry = this.OldModel.Entries[index];
                    if (oldEntry.PropertyValues.TryGetValue(property, out value))
                    {
                        if (value == null) return null;
                        ImmutableObject obj = value as ImmutableObject;
                        if (obj != null)
                        {
                            valueBuilder = obj.ToBuilder(this.GetModelBuilder(obj.Model));
                            entryBuilder.PropertyValues.Add(property, valueBuilder);
                            return valueBuilder;
                        }
                        IImmutableModelCollection coll = value as IImmutableModelCollection;
                        if (coll != null)
                        {
                            valueBuilder = coll.ToBuilder(entryBuilder, property);
                            entryBuilder.PropertyValues.Add(property, valueBuilder);
                            return valueBuilder;
                        }
                        return value;
                    }
                }
                else
                {
                    // TODO: initializers
                }
                return null;
            }

            public void Set(IImmutableObjectBuilder builder, ModelProperty property, object newValue)
            {
                if (builder == null || builder.MObject == null || builder.MModelBuilder == null) return;
                if (builder.MModelBuilder != this)
                {
                    builder.MModelBuilder.Set(builder, property, newValue);
                    return;
                }
                int index = builder.MObject.Index;
                this.Set(index, property, newValue);
            }

            public void Set(int index, ModelProperty property, object newValue)
            {
                object oldValue = null;
                var entryBuilder = this.GetEntry(index);
                if (entryBuilder.PropertyValues.TryGetValue(property, out oldValue))
                {
                    if (newValue == oldValue) return;
                    if (oldValue is IImmutableModelCollectionBuilder || newValue is IImmutableModelCollectionBuilder)
                    {
                        throw new ModelException("Error in '" + this.ToString() + "'. Cannot reassign a collection property '" + property.ToString() + "'. Consider adding the items instead.");
                    }
                    else if (property.IsReadonly)
                    {
                        throw new ModelException("Error in '" + this.ToString() + "'. Cannot reassign a readonly property '" + property.ToString() + "'.");
                    }
                }
                if (newValue is IImmutableModelCollectionBuilder)
                {
                    entryBuilder.PropertyValues[property] = newValue;
                }
                else
                {
                    this.Add(index, property, newValue, true);
                }
            }

            private bool SetOriginalValue(int index, ModelProperty property, object value)
            {
                object oldValue = null;
                var entryBuilder = this.GetEntry(index);
                if (entryBuilder.PropertyValues.TryGetValue(property, out oldValue))
                {
                    if (value == oldValue) return false;
                }
                entryBuilder.PropertyValues[property] = value;
                return true;
            }

            internal bool Add(IImmutableObjectBuilder builder, ModelProperty property, object value, bool firstCall = true)
            {
                if (builder == null || builder.MObject == null || builder.MModelBuilder == null) return false;
                if (builder.MModelBuilder != this)
                {
                    return builder.MModelBuilder.Add(builder, property, value);
                }
                return this.Add(builder.MObject.Index, property, value, firstCall);
            }

            private bool Add(int index, ModelProperty property, object value, bool firstCall)
            {
                bool result = false;
                bool added = false;
                object oldValue = this.Get(index, property);
                IImmutableModelCollectionBuilder collection = oldValue as IImmutableModelCollectionBuilder;
                if (collection != null)
                {
                    IImmutableObjectBuilder valueBuilder = value as IImmutableObjectBuilder;
                    object itemValue = valueBuilder != null ? valueBuilder.MObject : value;
                    if (value != null && collection.Add(itemValue, false))
                    {
                        added = true;
                    }
                    else if (value != null && firstCall)
                    {
                        added = true;
                    }
                }
                else
                {
                    if (value != oldValue)
                    {
                        if (oldValue != null)
                        {
                            this.Remove(index, property, oldValue, false);
                        }
                        result = this.SetOriginalValue(index, property, value);
                        added = value != null;
                    }
                    else
                    {
                        added = value != null && firstCall;
                    }
                }
                if (added)
                {
                    List<ModelProperty> cachedOppositeProperties = property.OppositeProperties.ToList();
                    if (cachedOppositeProperties.Count > 0)
                    {
                        IImmutableObjectBuilder oppositeObject = value as IImmutableObjectBuilder;
                        if (oppositeObject != null)
                        {
                            object thisObject = this.GetObject(index);
                            List<ModelProperty> allOppositeProperies = oppositeObject.MObject.MGetAllProperties().ToList();
                            foreach (ModelProperty oppositeProperty in cachedOppositeProperties)
                            {
                                if (allOppositeProperies.Contains(oppositeProperty))
                                {
                                    result |= this.Add(oppositeObject, oppositeProperty, thisObject, false);
                                }
                            }
                        }
                        else
                        {
                            throw new ModelException("Error adding the current object " + this.GetType().Name + "." + property.Name + " to the opposite object. The current object must be a descendant of " + typeof(IImmutableObjectBuilder) + ".");
                        }
                    }
                }
                return result;
            }

            internal bool Remove(IImmutableObjectBuilder builder, ModelProperty property, object value, bool firstCall = true)
            {
                if (builder == null || builder.MObject == null || builder.MModelBuilder == null) return false;
                if (builder.MModelBuilder != this)
                {
                    return builder.MModelBuilder.Add(builder, property, value);
                }
                return this.Remove(builder.MObject.Index, property, value, firstCall);
            }

            private bool Remove(int index, ModelProperty property, object value, bool firstCall)
            {
                bool result = false;
                bool removed = false;
                object oldValue = this.Get(index, property);
                IImmutableModelCollectionBuilder collection = oldValue as IImmutableModelCollectionBuilder;
                if (collection != null)
                {
                    IImmutableObjectBuilder valueBuilder = value as IImmutableObjectBuilder;
                    object itemValue = valueBuilder != null ? valueBuilder.MObject : value;
                    if (value != null && collection.Remove(itemValue, false))
                    {
                        removed = true;
                    }
                    else if (value != null && firstCall)
                    {
                        removed = true;
                    }
                }
                else
                {
                    if (value == oldValue)
                    {
                        if (oldValue != null)
                        {
                            result = this.SetOriginalValue(index, property, null);
                            removed = value != null;
                        }
                    }
                }
                if (removed)
                {
                    List<ModelProperty> cachedOppositeProperties = property.OppositeProperties.ToList();
                    if (cachedOppositeProperties.Count > 0)
                    {
                        IImmutableObjectBuilder oppositeObject = value as IImmutableObjectBuilder;
                        if (oppositeObject != null)
                        {
                            object thisObject = this.GetObject(index);
                            List<ModelProperty> allOppositeProperies = oppositeObject.MObject.MGetAllProperties().ToList();
                            foreach (ModelProperty oppositeProperty in cachedOppositeProperties)
                            {
                                if (allOppositeProperies.Contains(oppositeProperty))
                                {
                                    result |= this.Remove(oppositeObject, oppositeProperty, thisObject, false);
                                }
                            }
                        }
                        else
                        {
                            throw new ModelException("Error adding the current object " + this.GetType().Name + "." + property.Name + " to the opposite object. The current object must be a descendant of " + typeof(IImmutableObjectBuilder) + ".");
                        }
                    }
                }
                return result;
            }

            public ImmutableModel ToImmutable()
            {
                ImmutableModel result = this.NewModel;
                ImmutableList<ImmutableEntry>.Builder entriesBuilder = ImmutableList<ImmutableEntry>.Empty.ToBuilder();
                ImmutableDictionary<int, ImmutableModel>.Builder modelsBuilder = this.OldModel.Models.ToBuilder();
                for (int i = 0; i < this.changedEntries.Count; i++)
                {
                    ImmutableEntry.Builder entryBuilder = this.changedEntries[i];
                    if (entryBuilder != null)
                    {
                        ImmutableObject obj = entryBuilder.Object.ToImmutable();
                        ImmutableDictionary<ModelProperty, object>.Builder propertyValues = ImmutableDictionary<ModelProperty, object>.Empty.ToBuilder(); 
                        if (i < this.OldModel.Entries.Length)
                        {
                            propertyValues = this.OldModel.Entries[i].PropertyValues.ToBuilder();
                        }
                        foreach (var propValue in entryBuilder.PropertyValues)
                        {
                            object value = propValue.Value;
                            IImmutableObjectBuilder objBuilder = value as IImmutableObjectBuilder;
                            if (objBuilder != null)
                            {
                                value = objBuilder.ToImmutable();
                            }
                            else
                            {
                                IImmutableModelCollectionBuilder collBuilder = value as IImmutableModelCollectionBuilder;
                                if (collBuilder != null)
                                {
                                    value = collBuilder.ToImmutable();
                                }
                            }
                            propertyValues[propValue.Key] = value;
                        }
                        ImmutableEntry entry = new ImmutableEntry(obj, propertyValues.ToImmutable());
                        entriesBuilder.Add(entry);
                    }
                    else
                    {
                        ImmutableObject obj = this.OldModel.Entries[i].Object.MWithModel(result);
                        ImmutableEntry entry = new ImmutableEntry(obj, this.OldModel.Entries[i].PropertyValues);
                        entriesBuilder.Add(entry);
                    }
                }
                result.Entries = entriesBuilder.ToImmutableArray();
                // TODO:
                /*
                foreach (var modelIndex in this.changedModels.Keys)
                {
                    modelsBuilder[modelIndex] = this.changedModels[modelIndex].ToImmutable();
                }
                */
                return result;
            }
        }
    }

    public interface IImmutableObjectBuilder
    {
        ImmutableModel.Builder MModelBuilder { get; }
        ImmutableObject MObject { get; }
        ImmutableObject ToImmutable();
    }

    public abstract class ImmutableObject
    {
        protected ImmutableObject(ImmutableModel model, ImmutableObject oldObject)
        {
            this.Index = oldObject.Index;
            this.model = model;
        }

        protected ImmutableObject(ref ImmutableModel model)
        {
            ImmutableModel newModel = new ImmutableModel(model);
            newModel.Entries = model.Entries.Add(new ImmutableEntry(this));
            model = newModel;
        }

        protected ImmutableObject(ImmutableModel.Builder modelBuilder)
        {
            this.Index = modelBuilder.ObjectCount;
            this.model = modelBuilder.NewModel;
            this.model = modelBuilder.WithNewObject(this);
        }

        private ImmutableModel model;
        internal int Index { get; private set; }

        internal ImmutableModel Model
        {
            get
            {
                return this.model;
            }
        }

        public ImmutableModel MModel
        {
            get
            {
                return this.model.GetModel(this.model);
            }
        }
        
        public IEnumerable<ModelProperty> MGetAllProperties()
        {
            return ModelProperty.GetAllPropertiesForType(this.GetType());
        }

        public abstract ImmutableObject MWithModel(ImmutableModel model);

        internal IImmutableObjectBuilder ToBuilder(ImmutableModel.Builder modelBuilder)
        {
            return this.CreateBuilder(modelBuilder);
        }

        protected abstract IImmutableObjectBuilder CreateBuilder(ImmutableModel.Builder modelBuilder);

        public override bool Equals(object obj)
        {
            ImmutableObject rhs = obj as ImmutableObject;
            if (rhs == null) return false;
            return this.Model.ModelNumber == rhs.Model.ModelNumber && this.Index == rhs.Index;
        }

        public override int GetHashCode()
        {
            return this.Model.ModelNumber ^ this.Index;
        }

        public abstract class Builder : IImmutableObjectBuilder
        {
            public ImmutableModel.Builder MModelBuilder { get; private set; }
            public ImmutableObject MObject { get; private set; }

            public Builder(ImmutableModel.Builder modelBuilder, ImmutableObject obj)
            {
                this.MModelBuilder = modelBuilder;
                this.MObject = obj;
            }

            public void MAdd(ModelProperty property, object value)
            {
                this.MModelBuilder.Add(this, property, value);
            }

            public void MRemove(ModelProperty property, object value)
            {
                this.MModelBuilder.Remove(this, property, value);
            }

            public object MGet(ModelProperty property)
            {
                return this.MModelBuilder.Get(this, property);
            }

            public void MSet(ModelProperty property, object value)
            {
                this.MModelBuilder.Set(this, property, value);
            }

            public abstract ImmutableObject ToImmutable();

            public override bool Equals(object obj)
            {
                ImmutableObject io = obj as ImmutableObject;
                if (io != null) return io.Equals(this.MObject);
                Builder builder = obj as Builder;
                if (builder != null) return this.MObject.Equals(builder.MObject);
                return false;
            }

            public override int GetHashCode()
            {
                return this.MObject.GetHashCode();
            }
        }
    }

    internal interface IImmutableModelCollection
    {
        IImmutableModelCollection Add(object value);
        IImmutableModelCollection Remove(object value);
        IImmutableModelArray ToArray(ImmutableModel model);
        IImmutableModelCollectionBuilder ToBuilder(ImmutableEntry.Builder entryBuilder, ModelProperty property);
    }

    internal interface IImmutableModelCollectionBuilder
    {
        bool Add(object value, bool firstCall);
        bool Remove(object value, bool firstCall);
        IImmutableModelCollection ToImmutable();
    }

    public sealed class ImmutableModelList<T> : IImmutableModelCollection, IImmutableList<T>
        where T : class
    {
        private ImmutableList<T> items;

        public ImmutableModelList()
        {
            this.items = ImmutableList<T>.Empty;
        }

        public ImmutableModelList(ImmutableList<T> items)
        {
            this.items = items;
        }

        public ImmutableModelList(ImmutableModelList<T> list)
        {
            this.items = list.items;
        }

        public T this[int index]
        {
            get { return this.items[index]; }
        }

        public int Count
        {
            get { return this.items.Count; }
        }

        public IImmutableList<T> Add(T value)
        {
            if (this.items.Contains(value))
            {
                return this;
            }
            else
            {
                return new ImmutableModelList<T>(this.items.Add(value));
            }
        }

        public IImmutableList<T> AddRange(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public IImmutableList<T> Clear()
        {
            return new ImmutableModelList<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        public int IndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer)
        {
            return this.items.IndexOf(item, index, count, equalityComparer);
        }

        public IImmutableList<T> Insert(int index, T element)
        {
            throw new NotImplementedException();
        }

        public IImmutableList<T> InsertRange(int index, IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public int LastIndexOf(T item, int index, int count, IEqualityComparer<T> equalityComparer)
        {
            return this.items.LastIndexOf(item, index, count, equalityComparer);
        }

        public IImmutableList<T> Remove(T value, IEqualityComparer<T> equalityComparer)
        {
            if (!this.items.Contains(value, equalityComparer))
            {
                return this;
            }
            else
            {
                return new ImmutableModelList<T>(this.items.Remove(value, equalityComparer));
            }
        }

        public IImmutableList<T> RemoveAll(Predicate<T> match)
        {
            throw new NotImplementedException();
        }

        public IImmutableList<T> RemoveAt(int index)
        {
            return new ImmutableModelList<T>(this.items.RemoveAt(index));
        }

        public IImmutableList<T> RemoveRange(int index, int count)
        {
            throw new NotImplementedException();
        }

        public IImmutableList<T> RemoveRange(IEnumerable<T> items, IEqualityComparer<T> equalityComparer)
        {
            throw new NotImplementedException();
        }

        public IImmutableList<T> Replace(T oldValue, T newValue, IEqualityComparer<T> equalityComparer)
        {
            throw new NotImplementedException();
        }

        public IImmutableList<T> SetItem(int index, T value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IImmutableModelCollection IImmutableModelCollection.Add(object value)
        {
            return (IImmutableModelCollection)this.Add((T)value);
        }

        IImmutableModelCollection IImmutableModelCollection.Remove(object value)
        {
            return (IImmutableModelCollection)this.Remove((T)value);
        }

        IImmutableModelArray IImmutableModelCollection.ToArray(ImmutableModel model)
        {
            return new ImmutableModelArray<T>(model, this);
        }

        IImmutableModelCollectionBuilder IImmutableModelCollection.ToBuilder(ImmutableEntry.Builder entryBuilder, ModelProperty property)
        {
            return new Builder(entryBuilder, property, this);
        }

        public sealed class Builder : IImmutableModelCollectionBuilder
        {
            private ImmutableList<T>.Builder items;
            internal ImmutableEntry.Builder EntryBuilder { get; private set; }
            internal ModelProperty Property { get; private set; }

            internal Builder(ImmutableEntry.Builder entryBuilder, ModelProperty property, ImmutableModelList<T> list)
            {
                this.EntryBuilder = entryBuilder;
                this.Property = property;
                this.items = list.items.ToBuilder();
            }

            public int Count
            {
                get { return this.items.Count; }
            }

            public void Add(T value)
            {
                ((IImmutableModelCollectionBuilder)this).Add(value, true);
            }

            public void Remove(T value)
            {
                ((IImmutableModelCollectionBuilder)this).Remove(value, true);
            }

            bool IImmutableModelCollectionBuilder.Add(object value, bool firstCall)
            {
                IImmutableObjectBuilder builder = value as IImmutableObjectBuilder;
                if (builder != null)
                {
                    value = builder.MObject;
                }
                if (!this.items.Contains(value))
                {
                    this.items.Add((T)value);
                    if (firstCall)
                    {
                        IImmutableObjectBuilder obj = this.EntryBuilder.Object;
                        obj.MModelBuilder.Add(obj, this.Property, value);
                    }
                    return true;
                }
                return false;
            }

            bool IImmutableModelCollectionBuilder.Remove(object value, bool firstCall)
            {
                if (this.items.Remove((T)value))
                {
                    if (firstCall)
                    {
                        IImmutableObjectBuilder obj = this.EntryBuilder.Object;
                        obj.MModelBuilder.Remove(obj, this.Property, value);
                    }
                    return true;
                }
                return false;
            }

            IImmutableModelCollection IImmutableModelCollectionBuilder.ToImmutable()
            {
                return new ImmutableModelList<T>(this.items.ToImmutable());
            }

        }
    }

    public interface IImmutableModelArray 
    {
        int Length { get; }
    }

    public struct ImmutableModelArray<T> : IImmutableModelArray, IEnumerable
        where T : class
    {
        internal ImmutableModel Model { get; private set; }
        internal ImmutableModelList<T> List { get; private set; }

        public ImmutableModelArray(ImmutableModel model, ImmutableModelList<T> list)
        {
            this.Model = model;
            this.List = list;
        }

        public int Length
        {
            get { return this.List.Count; }
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < this.List.Count)
                {
                    ImmutableObject item = this.List[index] as ImmutableObject;
                    ImmutableModel model = this.Model.GetModel(item.Model);
                    return model.GetEntry(item.Index).Object as T;
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ImmutableEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    internal struct ImmutableEnumerator<T> : IEnumerator<T>
        where T : class
    {
        private int position;
        private ImmutableModelArray<T> array;

        public ImmutableEnumerator(ImmutableModelArray<T> array)
        {
            this.array = array;
            this.position = 0;
        }

        public T Current
        {
            get { return this.array[this.position]; }
        }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            ++this.position;
            return this.position < this.array.List.Count;
        }

        public void Reset()
        {
            this.position = 0;
        }
    }

    internal struct ImmutableEntry
    {
        public static ImmutableEntry Empty = new ImmutableEntry(null);

        public ImmutableEntry(ImmutableObject obj)
        {
            this.Object = obj;
            this.PropertyValues = ImmutableDictionary<ModelProperty, object>.Empty;
        }

        public ImmutableEntry(ImmutableObject obj, ImmutableDictionary<ModelProperty, object> propertyValues)
        {
            this.Object = obj;
            this.PropertyValues = propertyValues;
        }

        public ImmutableObject Object { get; private set; }
        public ImmutableDictionary<ModelProperty, object> PropertyValues { get; private set; }

        public Builder ToBuilder(ImmutableModel.Builder modelBuilder)
        {
            return new Builder(modelBuilder, this);
        }

        public sealed class Builder
        {
            internal IImmutableObjectBuilder Object { get; set; }
            internal ImmutableDictionary<ModelProperty, object>.Builder PropertyValues { get; set; }

            internal Builder(ImmutableModel.Builder modelBuilder, ImmutableEntry entry)
            {
                this.Object = entry.Object.ToBuilder(modelBuilder);
                this.PropertyValues = ImmutableDictionary<ModelProperty, object>.Empty.ToBuilder();
            }
        }
    }
}
