using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable2
{
    public class GreenObject
    {
        private long hashCode;

        public GreenObject(long id, long modelId)
        {
            this.modelId = modelId;
            this.id = id;
        }

        public long ModelId { get { return this.modelId; } }
        public long Id { get { return this.id; } }
    }

    public class GreenList : IEnumerable<GreenObject>
    {
        private List<GreenObject> items = new List<GreenObject>();

        public int Count
        {
            get { return this.items.Count; }
        }

        public bool Add(long item)
        {
            if (this.items.Contains(item)) return false;
            this.items.Add(item);
            return true;
        }

        public bool Remove(long item)
        {
            if (!this.items.Contains(item)) return false;
            this.items.Remove(item);
            return true;
        }

        public IEnumerator<long> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class GreenMultiList : IEnumerable<long>
    {
        private List<long> items = new List<long>();

        public int Count
        {
            get { return this.items.Count; }
        }

        public bool Add(long item)
        {
            this.items.Add(item);
            return true;
        }

        public bool Remove(long item)
        {
            if (!this.items.Contains(item)) return false;
            this.items.Remove(item);
            return true;
        }

        public bool RemoveAll(long item)
        {
            return this.items.RemoveAll(i => i == item) > 0;
        }

        public IEnumerator<long> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class RedObject
    {
        private RedModel model;
        private GreenObject green;

        public RedObject(GreenObject green, RedModel model)
        {
            this.green = green;
            this.model = model;
        }

        public RedModel Model { get { return this.model; } }
        public GreenObject Green { get { return this.green; } }
    }

    public class GreenModel
    {
        private static long idCounter = 0;
        private long id;
        private Dictionary<long, Dictionary<ModelProperty, object>> objects = new Dictionary<long, Dictionary<ModelProperty, object>>();

        public GreenModel()
        {
            this.id = Interlocked.Increment(ref idCounter);
        }

        public long Id { get { return this.id; } }
        internal Dictionary<long, Dictionary<ModelProperty, object>> Objects { get { return this.objects; } }

        public RedModel CreateRed(RedModelGroup group = null)
        {
            return new RedModel(this, group);
        }
    }

    public class RedModel
    {
        private RedModelGroup group;
        private GreenModel green;

        public RedModel(GreenModel green, RedModelGroup group = null)
        {
            this.group = group;
            this.green = green;
        }

        public long Id { get { return this.green.Id; } }
        public RedModelGroup Group { get { return this.group; } }
        public GreenModel Green { get { return this.green; } }

        public ModelBuilder Builder()
        {
            return this.Group != null ? this.group.Builder() : new ModelBuilder(new GreenModelGroup(this.green));
        }
    }

    public class GreenModelGroup
    {
        internal Dictionary<long, GreenModel> models = new Dictionary<long, GreenModel>();

        internal GreenModelGroup(GreenModel model)
        {
            this.models.Add(model.Id, model);
        }

        internal GreenModelGroup(GreenModelGroup oldGroup, GreenModel model)
        {
            this.models = oldGroup.models.ToDictionary(entry => entry.Key, entry => entry.Value);
            this.models[model.Id] = model;
        }

        internal GreenModelGroup(GreenModelGroup oldGroup, IEnumerable<GreenModel> models)
        {
            this.models = oldGroup.models.ToDictionary(entry => entry.Key, entry => entry.Value);
            foreach (var model in models)
            {
                this.models[model.Id] = model;
            }
        }

        public GreenModelGroup WithModel(GreenModel model)
        {
            GreenModel oldModel = null;
            if (this.models.TryGetValue(model.Id, out oldModel))
            {
                if (model == oldModel) return this;
            }
            return new GreenModelGroup(this, model);
        }

        public GreenModelGroup WithModels(IEnumerable<GreenModel> models)
        {
            List<GreenModel> changedModels = new List<GreenModel>();
            foreach (var model in models)
            {
                GreenModel oldModel = null;
                if (this.models.TryGetValue(model.Id, out oldModel))
                {
                    if (model != oldModel)
                    {
                        changedModels.Add(model);
                    }
                }
            }
            if (changedModels.Count == 0) return this;
            else return new GreenModelGroup(this, changedModels);
        }

        public IEnumerable<GreenModel> Models
        {
            get { return this.models.Values; }
        }
    }

    public class RedModelGroup
    {
        private GreenModelGroup green;
        private List<RedModel> models = new List<RedModel>();

        public RedModelGroup(GreenModelGroup green)
        {
            this.green = green;
            foreach (var gm in this.green.Models)
            {
                this.models.Add(gm.CreateRed(this));
            }
        }

        public GreenModelGroup Green
        {
            get { return this.green; }
        }

        public IReadOnlyList<RedModel> Models
        {
            get { return this.models; }
        }

        public ModelBuilder Builder()
        {
            return new ModelBuilder(this.Green);
        }
    }

    public class ObjectBuilder
    {
        private GreenObject target;
        private ModelBuilder model;

        public ObjectBuilder(GreenObject target, ModelBuilder model)
        {
            this.target = target;
            this.model = model;
        }

        public void Add(ModelProperty property, object value)
        {
            this.model.AddValue(this.target, property, value);
        }

        public void Remove(ModelProperty property, object value)
        {
            this.model.RemoveValue(this.target, property, value);
        }
    }

    public class ModelBuilder
    {
        private GreenModelGroup group;
        private ModelTransactionCommand transaction;

        internal protected ModelBuilder(GreenModelGroup group)
        {
            this.group = group;
        }

        internal ModelTransactionCommand Transaction
        {
            get
            {
                if (this.transaction == null)
                {
                    Interlocked.CompareExchange(ref this.transaction, new ModelTransactionCommand(this.group), null);
                }
                return this.transaction;
            }
        }

        public void BeginTransaction()
        {
            Interlocked.Exchange(ref this.transaction, this.Transaction.BeginTransaction());
        }

        public void CommitTransaction()
        {
            Interlocked.Exchange(ref this.transaction, this.Transaction.CommitTransaction());
        }

        public void RollbackTransaction()
        {
            Interlocked.Exchange(ref this.transaction, this.Transaction.RollbackTransaction());
        }

        public void AddModel(GreenModel model)
        {
            this.Transaction.AddModel(model);
        }

        public void AddModels(IEnumerable<GreenModel> models)
        {
            this.Transaction.AddModels(models);
        }

        public void RemoveModel(GreenModel model)
        {
            this.Transaction.RemoveModel(model);
        }

        public void AddObject(GreenModel model, GreenObject obj)
        {
            this.Transaction.AddObject(model, obj);
        }

        public void RemoveObject(GreenModel model, GreenObject obj)
        {
            this.Transaction.RemoveObject(model, obj);
        }

        public void AddValue(GreenObject target, ModelProperty property, object value)
        {
            this.Transaction.AddValue(target, property, value);
        }

        public void RemoveValue(GreenObject target, ModelProperty property, object value)
        {
            this.Transaction.RemoveValue(target, property, value);
        }
    }



    public class ModelBuildCommand
    {
    }

    public class ModelTransactionCommand : ModelBuildCommand
    {
        private GreenModelGroup group;
        private ModelTransactionCommand parent;
        private Dictionary<long, Dictionary<long, Dictionary<ModelProperty, object>>> objects;
        private List<ModelBuildCommand> commands;

        public ModelTransactionCommand(GreenModelGroup group)
        {
            this.group = group;
        }

        public ModelTransactionCommand(ModelTransactionCommand parent)
        {
            this.parent = parent;
        }

        public GreenModelGroup Group
        {
            get { return this.group ?? this.parent?.Group; }
        }

        public List<ModelBuildCommand> Commands
        {
            get
            {
                if (this.commands == null)
                {
                    Interlocked.CompareExchange(ref this.commands, new List<ModelBuildCommand>(), null);
                }
                return this.commands;
            }
        }

        public Dictionary<long, Dictionary<long, Dictionary<ModelProperty, object>>> Objects
        {
            get
            {
                if (this.objects == null)
                {
                    Interlocked.CompareExchange(ref this.objects, new Dictionary<long, Dictionary<long, Dictionary<ModelProperty, object>>>(), null);
                }
                return this.objects;
            }
        }

        public ModelTransactionCommand BeginTransaction()
        {
            lock(this.Commands)
            {
                ModelTransactionCommand result = new ModelTransactionCommand(this);
                this.Commands.Add(result);
                return result;
            }
        }

        public ModelTransactionCommand CommitTransaction()
        {
            if (this.parent == null) return this;
            lock (this.parent.Commands)
            {
                this.parent.Commands.Remove(this);
                this.parent.Merge(this);
                return this.parent;
            }
        }

        public ModelTransactionCommand RollbackTransaction()
        {
            if (this.parent == null) return new ModelTransactionCommand(this.group);
            lock (this.parent.Commands)
            {
                this.parent.Commands.Remove(this);
                return this.parent;
            }
        }

        private void Merge(ModelTransactionCommand child)
        {
            // TODO
        }

        public void AddModel(GreenModel model)
        {
            Interlocked.Exchange(ref this.group, this.Group.WithModel(model));
        }

        public void AddModels(IEnumerable<GreenModel> models)
        {
            Interlocked.Exchange(ref this.group, this.Group.WithModels(models));
        }

        public void RemoveModel(GreenModel model)
        {
            // TODO
        }

        public void AddObject(GreenModel model, GreenObject obj)
        {
            // TODO
        }

        public void RemoveObject(GreenModel model, GreenObject obj)
        {
            // TODO
        }

        public void AddValue(GreenObject target, ModelProperty property, object value)
        {
            // TODO
        }

        public void RemoveValue(GreenObject target, ModelProperty property, object value)
        {
            // TODO
        }

        private Dictionary<ModelProperty, object> GetObject(long modelId, long objectId, bool clone = true)
        {
            Dictionary<long, Dictionary<ModelProperty, object>> model = null;
            lock (this.Objects)
            {
                if (!this.objects.TryGetValue(modelId, out model))
                {
                    model = new Dictionary<long, Dictionary<ModelProperty, object>>();
                    this.objects.Add(modelId, model);
                }
            }
            Dictionary<ModelProperty, object> result = null;
            result = this.FindObject(modelId, objectId, FindObjectFlags.This);
            if (result != null) return result;
            result = this.FindObject(modelId, objectId, FindObjectFlags.Ancestors | FindObjectFlags.Default);
            if (clone)
            {
                Dictionary<ModelProperty, object> clonedResult = null;
                lock (result)
                {
                    clonedResult = result.ToDictionary(entry => entry.Key, entry => entry.Value);
                }
                result = clonedResult;
                lock(model)
                {
                    model.Add(objectId, result);
                }
            }
            return result;
        }

        [Flags]
        private enum FindObjectFlags
        {
            This = 1,
            Ancestors = 2,
            Default = 4,
            All = This | Ancestors | Default
        }

        private Dictionary<ModelProperty, object> FindObject(long modelId, long objectId, FindObjectFlags flags = FindObjectFlags.All)
        {
            Dictionary<ModelProperty, object> result = null;
            ModelTransactionCommand cmd = this;
            if (!flags.HasFlag(FindObjectFlags.This))
            {
                cmd = cmd.parent;
            }
            while (result == null && cmd != null)
            {
                Dictionary<long, Dictionary<ModelProperty, object>> model = null;
                lock (cmd.Objects)
                {
                    if (cmd.objects.TryGetValue(modelId, out model))
                    {
                        if (model.TryGetValue(objectId, out result))
                        {
                            return result;
                        }
                    }
                }
                if (!flags.HasFlag(FindObjectFlags.Ancestors)) break;
                cmd = cmd.parent;
            }
            if (!flags.HasFlag(FindObjectFlags.Default))
            {
                return null;
            }
            else 
            {
                return this.FindDefaultObject(modelId, objectId);
            }
        }

        private Dictionary<ModelProperty, object> FindDefaultObject(long modelId, long objectId, FindObjectFlags flags = FindObjectFlags.All)
        {
            Dictionary<ModelProperty, object> result = null;
            ModelTransactionCommand cmd = this;
            if (!flags.HasFlag(FindObjectFlags.This))
            {
                cmd = cmd.parent;
            }
            while (result == null && cmd != null)
            {
                lock (cmd.Group)
                {
                    GreenModel model = null;
                    if (cmd.group.models.TryGetValue(modelId, out model))
                    {
                        if (model.Objects.TryGetValue(objectId, out result))
                        {
                            return result;
                        }
                    }
                }
                if (!flags.HasFlag(FindObjectFlags.Ancestors)) break;
                cmd = cmd.parent;
            }
            return null;
        }

        private Dictionary<long, Dictionary<ModelProperty, object>> GetObjects(long modelId)
        {
            lock(this.Objects)
            {
                Dictionary<long, Dictionary<ModelProperty, object>> result = null;
                if (this.objects.TryGetValue(modelId, out result))
                {
                    return result;
                }
            }
            return this.GetObjectsFromParent(modelId);
        }

        private Dictionary<long, Dictionary<ModelProperty, object>> GetObjectsFromParent(long modelId)
        {
            Dictionary<long, Dictionary<ModelProperty, object>> result = null;
            if (this.parent != null)
            {
                result = this.parent.GetObjects(modelId);
            }
            else if (this.group != null)
            {
                lock (this.Group)
                {
                    result = this.group.Models.FirstOrDefault(m => m.Id == modelId)?.Objects;
                }
            }
            return result;
        }
    }

    public class ModelValueCommand : ModelBuildCommand
    {
        public GreenObject Target { get; private set; }
        public ModelProperty Property { get; private set; }
        public object Value { get; private set; }

        public ModelValueCommand(GreenObject target, ModelProperty property, object value)
        {
            this.Target = target;
            this.Property = property;
            this.Value = value;
        }
    }

    public class ModelAddValueCommand : ModelValueCommand
    {
        public ModelAddValueCommand(GreenObject target, ModelProperty property, object value)
            : base(target, property, value)
        {
        }
    }

    public class ModelRemoveValueCommand : ModelValueCommand
    {
        public ModelRemoveValueCommand(GreenObject target, ModelProperty property, object value)
            : base(target, property, value)
        {
        }
    }
}
