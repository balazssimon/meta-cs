using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    public sealed class ImmutableModel
    {
        private static object StaticModelLock = new object();
        private static int ModelCounter;
        internal int ModelNumber { get; private set; }

        private ImmutableModel oldModel;
        internal ImmutableArray<ImmutableEntry> Entries { get; private set; }
        internal ImmutableDictionary<int, ImmutableModel> Models { get; private set; }

        private ImmutableModel()
        {
            this.oldModel = null;
            this.Entries = ImmutableArray<ImmutableEntry>.Empty;
            this.Models = ImmutableDictionary<int, ImmutableModel>.Empty;
            lock (ImmutableModel.StaticModelLock)
            {
                ++ImmutableModel.ModelCounter;
                this.ModelNumber = ImmutableModel.ModelCounter;
            }
        }

        private ImmutableModel(ImmutableModel oldModel)
        {
            this.oldModel = oldModel;
            this.ModelNumber = this.oldModel.ModelNumber;
            this.Entries = oldModel.Entries;
            this.Models = oldModel.Models;
        }

        private ImmutableModel(ImmutableModel oldModel, ImmutableArray<ImmutableEntry> entries)
        {
            this.oldModel = oldModel;
            this.ModelNumber = this.oldModel.ModelNumber;
            this.Entries = entries;
            this.Models = oldModel.Models;
        }

        private ImmutableModel(ImmutableModel oldModel, ImmutableDictionary<int, ImmutableModel> models)
        {
            this.oldModel = oldModel;
            this.ModelNumber = this.oldModel.ModelNumber;
            this.Entries = oldModel.Entries;
            this.Models = models;
        }

        public int ObjectCount
        {
            get { return this.Entries.Length; }
        }

        public ImmutableObject GetObject(ImmutableObject.Builder builder)
        {
            if (builder == null || builder.MObject == null) return null;
            if (builder.MObject.MModel.ModelNumber != this.ModelNumber)
            {
                return this.GetModel(builder.MObject.MModel).GetObject(builder);
            }
            else
            {
                return this.GetEntry(builder.MObject.Index).Object;
            }
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
                    result = this.SetOriginalValue(oldEntry, property, null, ref newModel);
                    removed = value != null;
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
                else if (this.oldModel != null)
                {
                    return this.oldModel.GetEntry(index);
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
            public ImmutableModel Model { get; private set; }
            private List<ImmutableEntry.Builder> changedEntries;
            private Dictionary<int, ImmutableModel.Builder> changedModels;

            internal Builder(ImmutableModel model)
            {
                this.Model = model;
            }

            public int ObjectCount
            {
                get { return this.changedEntries == null ? this.Model.Entries.Length : this.changedEntries.Count; }
            }

            private void RequireChangedEntries()
            {
                if (this.changedEntries == null)
                {
                    this.changedEntries = new List<ImmutableEntry.Builder>(Model.Entries.Length);
                    for (int i = 0; i < Model.Entries.Length; i++)
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
                    this.changedEntries[index] = this.Model.Entries[index].ToBuilder(this);
                }
                return this.changedEntries[index];
            }

            public ImmutableModel.Builder GetModel(ImmutableModel model)
            {
                if (model == null) return null;
                if (model.ModelNumber == this.Model.ModelNumber) return this;
                this.RequireChangedModels();
                ImmutableModel.Builder modelBuilder = null;
                if (!this.changedModels.TryGetValue(model.ModelNumber, out modelBuilder))
                {
                    modelBuilder = model.ToBuilder();
                    this.changedModels.Add(model.ModelNumber, modelBuilder);
                }
                return modelBuilder;
            }

            public ImmutableObject.Builder GetObject(ImmutableObject obj)
            {
                if (obj.MModel.ModelNumber == this.Model.ModelNumber)
                {
                    return this.GetEntry(obj.Index).Object;
                }
                else
                {
                    return this.GetModel(obj.MModel).GetObject(obj);
                }
            }

            internal ImmutableModel WithNewObject(ImmutableObject obj)
            {
                if (obj == null) return this.Model;
                if (obj.MModel != this.Model)
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
                return this.Model;
            }

            public ImmutableModel.Builder With(ImmutableModel model)
            {
                if (model == null) return null;
                if (model.ModelNumber == this.Model.ModelNumber) return this;
                this.RequireChangedModels();
                ImmutableModel.Builder modelBuilder = null;
                if (this.changedModels.TryGetValue(model.ModelNumber, out modelBuilder))
                {
                    if (!object.ReferenceEquals(modelBuilder.Model, model))
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

            public void With(ImmutableObject.Builder builder, ModelProperty property, object value)
            {
                if (builder == null || builder.MObject == null) return;
                if (property == null) return;
                if (builder.MModelBuilder != this)
                {
                    throw new ArgumentException("The object should be changed through it's own model builder.", nameof(Model));
                }
                this.Add(builder, property, value, true);
            }

            public void Without(ImmutableObject.Builder builder, ModelProperty property, object value)
            {
                if (builder == null || builder.MObject == null) return;
                if (property == null) return;
                if (builder.MModelBuilder != this)
                {
                    throw new ArgumentException("The object should be changed through it's own model builder.", nameof(Model));
                }
                this.Remove(builder, property, value, true);
            }

            public object Get(ImmutableObject.Builder builder, ModelProperty property)
            {
                if (builder == null || builder.MObject == null || builder.MModelBuilder == null) return null;
                if (builder.MModelBuilder != this)
                {
                    return builder.MModelBuilder.Get(builder, property);
                }
                object valueBuilder = null;
                int index = builder.MObject.Index;
                var entryBuilder = this.GetEntry(index);
                if (entryBuilder.ChangedPropertyValues.TryGetValue(property, out valueBuilder))
                {
                    return valueBuilder;
                }
                else if (index >= 0 && index < this.Model.Entries.Length)
                {
                    object value = null;
                    ImmutableEntry oldEntry = this.Model.Entries[index];
                    if (oldEntry.PropertyValues.TryGetValue(property, out value))
                    {
                        if (value == null) return null;
                        ImmutableObject obj = value as ImmutableObject;
                        if (obj != null)
                        {
                            valueBuilder = obj.ToBuilder(this.GetModel(obj.MModel));
                            entryBuilder.ChangedPropertyValues.Add(property, valueBuilder);
                            return valueBuilder;
                        }
                        IImmutableModelCollection coll = value as IImmutableModelCollection;
                        if (coll != null)
                        {
                            valueBuilder = coll.ToBuilder(entryBuilder, property);
                            entryBuilder.ChangedPropertyValues.Add(property, valueBuilder);
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

            public void Set(ImmutableObject.Builder builder, ModelProperty property, object value)
            {

            }

            internal void Add(ImmutableObject.Builder builder, ModelProperty property, object value, bool firstCall)
            {

            }

            internal void Remove(ImmutableObject.Builder builder, ModelProperty property, object value, bool firstCall)
            {

            }

            public ImmutableModel ToImmutable()
            {
                return this.Model;
            }
        }
    }


    public abstract class ImmutableObject
    {
        protected ImmutableObject(ref ImmutableModel model)
        {
            this.MetaID = Guid.NewGuid().ToString();
            this.Index = model.ObjectCount;
            this.model = model;
            this.model = model.WithNewObject(this);
        }

        protected ImmutableObject(ImmutableModel.Builder modelBuilder)
        {
            this.MetaID = Guid.NewGuid().ToString();
            this.Index = modelBuilder.ObjectCount;
            this.model = modelBuilder.Model;
            this.model = modelBuilder.WithNewObject(this);
        }

        private ImmutableModel model;

        public string MetaID { get; private set; }
        internal int Index { get; private set; }
        public ImmutableModel MModel
        {
            get
            {
                return this.model;
            }
        }
        
        public IEnumerable<ModelProperty> MGetAllProperties()
        {
            return new ModelProperty[0];
        }
        internal Builder ToBuilder(ImmutableModel.Builder modelBuilder)
        {
            return this.CreateBuilder(modelBuilder);
        }
        protected abstract Builder CreateBuilder(ImmutableModel.Builder modelBuilder);

        public class Builder
        {
            internal ImmutableModel.Builder MModelBuilder { get; private set; }
            internal ImmutableObject MObject { get; private set; }

            public Builder(ImmutableModel.Builder modelBuilder, ImmutableObject obj)
            {
                this.MModelBuilder = modelBuilder;
                this.MObject = obj;
            }

            public void MAdd(ModelProperty property, object value)
            {
                this.MModelBuilder.Add(this, property, value, true);
            }

            public void MRemove(ModelProperty property, object value)
            {
                this.MModelBuilder.Remove(this, property, value, true);
            }

            public object MGet(ModelProperty property)
            {
                return this.MModelBuilder.Get(this, property);
            }

            public void MSet(ModelProperty property, object value)
            {
                this.MModelBuilder.Set(this, property, value);
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
        void Add(object value);
        void Remove(object value);
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

            public void Add(object value)
            {
                ImmutableObject.Builder obj = this.EntryBuilder.Object;
                obj.MModelBuilder.Add(obj, this.Property, value, true);
            }

            public void Remove(object value)
            {
                ImmutableObject.Builder obj = this.EntryBuilder.Object;
                obj.MModelBuilder.Remove(obj, this.Property, value, true);
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
                    ImmutableModel model = item.MModel;
                    if (model.ModelNumber == this.Model.ModelNumber)
                    {
                        model = this.Model;
                    }
                    else if (this.Model.Models != ImmutableDictionary<int, ImmutableModel>.Empty)
                    {
                        ImmutableModel newModel = null;
                        if (this.Model.Models.TryGetValue(item.MModel.ModelNumber, out newModel))
                        {
                            model = newModel;
                        }
                    }
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
            internal ImmutableObject.Builder Object { get; set; }
            internal ImmutableDictionary<ModelProperty, object>.Builder ChangedPropertyValues { get; set; }

            internal Builder(ImmutableModel.Builder modelBuilder, ImmutableEntry entry)
            {
                this.Object = entry.Object.ToBuilder(modelBuilder);
                this.ChangedPropertyValues = entry.PropertyValues.ToBuilder();
            }
        }
    }
}
