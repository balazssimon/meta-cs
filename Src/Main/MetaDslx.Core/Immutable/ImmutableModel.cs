using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    public class ImmutableModel
    {
        internal static object StaticModelLock = new object();
        internal object ModelLock = new object();
        internal static int ModelCounter;
        internal int modelNumber;

        internal ImmutableModel oldModel;
        internal ImmutableArray<ImmutableEntry> entries;
        internal ImmutableDictionary<int, ImmutableModel> models;

        public ImmutableModel()
        {
            this.oldModel = null;
            this.entries = ImmutableArray<ImmutableEntry>.Empty;
            this.models = ImmutableDictionary<int, ImmutableModel>.Empty;
            lock (ImmutableModel.StaticModelLock)
            {
                ++ImmutableModel.ModelCounter;
                this.modelNumber = ImmutableModel.ModelCounter;
            }
        }

        public ImmutableModel(ImmutableModel oldModel)
        {
            this.oldModel = oldModel;
            this.modelNumber = this.oldModel.modelNumber;
            this.entries = oldModel.entries;
            this.models = oldModel.models;
        }

        private ImmutableModel(ImmutableModel oldModel, ImmutableArray<ImmutableEntry> entries)
        {
            this.oldModel = oldModel;
            this.modelNumber = this.oldModel.modelNumber;
            this.entries = entries;
            this.models = oldModel.models;
        }

        private ImmutableModel(ImmutableModel oldModel, ImmutableDictionary<int, ImmutableModel> models)
        {
            this.oldModel = oldModel;
            this.modelNumber = this.oldModel.modelNumber;
            this.entries = oldModel.entries;
            this.models = models;
        }

        public ImmutableModel With(ImmutableModel model)
        {
            if (model == null) return this;
            ImmutableModel oldModel = null;
            if (model.modelNumber == this.modelNumber)
            {
                return this;
            }
            else if (this.models.TryGetValue(model.modelNumber, out oldModel) && object.ReferenceEquals(oldModel, model))
            {
                return this;
            }
            else
            {
                return new ImmutableModel(this, this.models.SetItem(model.modelNumber, model));
            }
        }

        public ImmutableModel With(ImmutableObject originalObject, ModelProperty property, object value)
        {
            if (originalObject == null || originalObject.model == null) return this;
            if (property == null) return this;
            ImmutableModel newModel = this;
            if (originalObject.model.Add(originalObject, property, value, true, ref newModel))
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
            if (originalObject == null || originalObject.model == null) return this;
            if (property == null) return this;
            ImmutableModel newModel = this;
            if (originalObject.model.Remove(originalObject, property, value, true, ref newModel))
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
            if (obj.model != null && obj.index >= 0)
            {
                ImmutableEntry oldEntry = obj.model.GetEntry(obj.index);
                if (oldEntry != null)
                {
                    object value = null;
                    if (oldEntry.PropertyValues.TryGetValue(property, out value))
                    {
                        if (object.ReferenceEquals(obj.model, this))
                        {
                            ImmutableModelCollection coll = value as ImmutableModelCollection;
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
            if (obj.model != null && obj.index >= 0)
            {
                ImmutableEntry oldEntry = obj.model.GetEntry(obj.index);
                if (oldEntry != null)
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
            if (entry != null)
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
            if (obj.model != null && obj.index >= 0)
            {
                ImmutableEntry oldEntry = obj.model.GetEntry(obj.index);
                if (oldEntry != null)
                {
                    ImmutableEntry newEntry = new ImmutableEntry(oldEntry.Object, oldEntry.PropertyValues.SetItem(property, value));
                    newModel = newModel.WithEntry(newEntry);
                    return true;
                }
            }
            return false;
        }

        internal bool SetOriginalValue(ImmutableEntry entry, ModelProperty property, object value, ref ImmutableModel newModel)
        {
            if (entry != null)
            {
                ImmutableEntry newEntry = new ImmutableEntry(entry.Object, entry.PropertyValues.SetItem(property, value));
                newModel = newModel.WithEntry(newEntry);
                return true;
            }
            return false;
        }

        private bool Add(ImmutableObject obj, ModelProperty property, object value, bool firstCall, ref ImmutableModel newModel)
        {
            if (obj.model == null || obj.index < 0) return false;
            bool result = false;
            bool added = false;
            ImmutableEntry oldEntry = this.GetEntry(obj.index);
            object oldValue = this.GetOriginalValue(oldEntry, property);
            ImmutableModelCollection oldCollection = oldValue as ImmutableModelCollection;
            if (oldCollection != null)
            {
                ImmutableModelCollection newCollection = oldCollection.Add(value);
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
            if (obj.model == null || obj.index < 0) return false;
            bool result = false;
            bool removed = false;
            ImmutableEntry oldEntry = this.GetEntry(obj.index);
            object oldValue = this.GetOriginalValue(oldEntry, property);
            ImmutableModelCollection oldCollection = oldValue as ImmutableModelCollection;
            if (oldCollection != null)
            {
                ImmutableModelCollection newCollection = oldCollection.Remove(value);
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
            if (obj.model != null)
            {
                throw new ArgumentException("The immutable object should not have a model yet.", nameof(obj));
            }
            ImmutableModel newModel = null;
            if (obj.index >= 0)
            {
                ImmutableEntry oldEntry = this.GetEntry(obj.index);
                newModel = this.WithEntry(new ImmutableEntry(obj, oldEntry.PropertyValues));
            }
            else 
            {
                newModel = this.WithEntry(new ImmutableEntry(obj));
            }
            lock(obj)
            {
                if (obj.model == null)
                {
                    obj.model = newModel;
                }
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


    public abstract class ImmutableObject
    {
        internal int index;
        internal ImmutableModel model;

        public ImmutableObject()
        {
            this.index = -1;
            this.model = null;
        }

        internal ImmutableObject(ImmutableModel model)
        {
            this.index = -1;
            this.model = model;
        }

        internal ImmutableObject(ImmutableModel model, int index)
        {
            this.index = index;
            this.model = model;
        }

        public abstract IEnumerable<ModelProperty> MGetAllProperties();
    }

    public interface ImmutableModelCollection
    {
        int Count { get; }
        ImmutableModelCollection Add(object value);
        ImmutableModelCollection Remove(object value);
        ImmutableModelArray ToArray(ImmutableModel model);
    }

    public class ImmutableModelList<T> : ImmutableModelCollection, IImmutableList<T>
        where T : class
    {
        internal ImmutableList<T> items;

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

        public ImmutableModelCollection Add(object value)
        {
            if (this.items.Contains(value))
            {
                return this;
            }
            else
            {
                return new ImmutableModelList<T>(this.items.Add((T)value));
            }
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

        public ImmutableModelCollection Remove(object value)
        {
            if (!this.items.Contains(value))
            {
                return this;
            }
            else
            {
                return new ImmutableModelList<T>(this.items.Remove((T)value));
            }
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

        public ImmutableModelArray ToArray(ImmutableModel model)
        {
            return new ImmutableModelArray<T>(model, this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public interface ImmutableModelArray 
    {
        int Count { get; }
    }

    public struct ImmutableModelArray<T> : ImmutableModelArray, IReadOnlyList<T>
        where T : class
    {
        internal ImmutableModel model;
        internal ImmutableModelList<T> list;

        public ImmutableModelArray(ImmutableModel model, ImmutableModelList<T> list)
        {
            this.model = model;
            this.list = list;
        }

        public int Count
        {
            get { return this.list.Count; }
        }

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < this.list.Count)
                {
                    ImmutableObject item = this.list.items[index] as ImmutableObject;
                    ImmutableModel model = item.model;
                    if (model.modelNumber == this.model.modelNumber)
                    {
                        model = this.model;
                    }
                    else if (this.model.models != ImmutableDictionary<int, ImmutableModel>.Empty)
                    {
                        ImmutableModel newModel = null;
                        if (this.model.models.TryGetValue(item.model.modelNumber, out newModel))
                        {
                            model = newModel;
                        }
                    }
                    return model.GetEntry(item.index).Object as T;
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
            return this.position < this.array.list.Count;
        }

        public void Reset()
        {
            this.position = 0;
        }
    }

    internal class ImmutableEntry
    {
        public ImmutableEntry(ImmutableObject obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            this.Object = obj;
            this.PropertyValues = ImmutableDictionary<ModelProperty, object>.Empty;
        }

        public ImmutableEntry(ImmutableObject obj, ImmutableDictionary<ModelProperty, object> propertyValues)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            this.Object = obj;
            this.PropertyValues = propertyValues;
        }

        public ImmutableObject Object { get; private set; }
        public ImmutableDictionary<ModelProperty, object> PropertyValues { get; private set; }
    }
}
