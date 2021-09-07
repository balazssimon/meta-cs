using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.Modeling.Internal
{
    /// <summary>
    /// This class is responsible for updating a green model. The class is not thread-safe,
    /// and it should be used only from a single thread.
    /// </summary>
    /// If multiple threads can update the model, create a different updater for each thread, 
    /// and merge the results using the following pattern:
    ///     do
    ///     {
    ///         oldState = someObject.State;
    ///         newState = oldState.WithSomeChanges(); // this is where to call the updater of the current thread
    ///     } while (Interlocked.CompareExchange(ref someObject.State, newState, oldState) != oldState;
    internal class GreenModelUpdater
    {
        private MutableModel redModel;
        private MutableModelGroup redModelGroup;
        private GreenModel model;
        private GreenModelGroup group;
        private List<GreenLazyEvalEntry> lazyEvalStack;

        public GreenModelUpdater(GreenModel model, MutableModel redModel)
        {
            this.model = model;
            this.group = null;
            this.redModel = redModel;
        }

        public GreenModelUpdater(GreenModelGroup group, MutableModelGroup redModelGroup)
        {
            this.model = null;
            this.group = group;
            this.redModelGroup = redModelGroup;
        }

        public void MakeException(Location location, ErrorCode errorCode, params object[] args)
        {
            this.ArgsToRedMessageSerializable(args);
            throw new ModelException(LanguageDiagnostic.Create(errorCode, location, args));
        }

        public void MakeException(Exception innerException, Location location, ErrorCode errorCode, params object[] args)
        {
            this.ArgsToRedMessageSerializable(args);
            throw new ModelException(LanguageDiagnostic.Create(errorCode, location, args), innerException);
        }

        public void MakeLazyEvalException(List<GreenLazyEvalEntry> evaluationStack, Exception innerException, LazyValue lazy, ErrorCode errorCode, params object[] args)
        {
            this.ArgsToRedMessageSerializable(args);
            var diagnostic = LanguageDiagnostic.Create(new LazyEvaluationDiagnosticInfo(LazyEvalStackToRed(evaluationStack), errorCode, args)).WithLocation(lazy.GetLocation());
            throw new LazyEvaluationException(diagnostic);
        }

        private void ArgsToRedMessageSerializable(object[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                ObjectId oid = args[i] as ObjectId;
                if (oid != null)
                {
                    IModelObject mobj = null;
                    mobj = this.ResolveObject(oid);
                    if (mobj != null)
                    {
                        args[i] = mobj;
                    }
                }
                args[i] = args[i].ToString();
            }
        }

        private ImmutableArray<LazyEvalEntry> LazyEvalStackToRed(List<GreenLazyEvalEntry> evaluationStack)
        {
            return evaluationStack.Select(e => new LazyEvalEntry(this.ResolveObject(e.ObjectId), e.Property)).ToImmutableArray();
        }

        private IModelObject ResolveObject(ObjectId oid)
        {
            if (redModelGroup != null) return this.redModelGroup.ResolveObject(oid);
            else return this.redModel.ResolveObject(oid);
        }

        public GreenModel Model { get { return this.model; } }
        public GreenModelGroup Group { get { return this.group; } }

        private GreenModel GetModel(ModelId mid)
        {
            if (this.group != null)
            {
                GreenModel model;
                if (this.group.Models.TryGetValue(mid, out model))
                {
                    return model;
                }
                return null;
            }
            else
            {
                if (this.model.Id == mid)
                {
                    return this.model;
                }
                return null;
            }
        }

        private ModelRef ResolveModel(ModelId mid)
        {
            if (this.group != null)
            {
                GreenModel model;
                if (this.group.Models.TryGetValue(mid, out model))
                {
                    return new ModelRef(model, false);
                }
                if (this.group.References.TryGetValue(mid, out model))
                {
                    return new ModelRef(model, true);
                }
                return null;
            }
            else
            {
                if (this.model.Id == mid)
                {
                    return new ModelRef(this.model, false);
                }
                return null;
            }
        }

        public GreenModel CreateModel(ModelId mid, GreenMetadata metadata)
        {
            Debug.Assert(this.group != null);
            if (mid == null) return null;
            GreenModel result = new GreenModel(mid, metadata);
            this.group = this.group.AddModel(result);
            return result;
        }

        public void AddModelReference(GreenModel reference)
        {
            Debug.Assert(this.group != null);
            this.group = this.group.AddReference(reference);
        }

        public void AddModel(GreenModel model)
        {
            Debug.Assert(this.group != null);
            this.group = this.group.AddModel(model);
        }

        public void SetName(ModelId mid, string name)
        {
            if (this.group != null)
            {
                GreenModel model = this.GetModel(mid);
                this.UpdateModel(model.Update(model.Metadata.WithName(name), model.Objects, model.StrongObjects, model.LazyProperties, model.References));
            }
            else
            {
                Debug.Assert(this.model.Id == mid);
                this.model = this.model.Update(model.Metadata.WithName(name), this.model.Objects, this.model.StrongObjects, this.model.LazyProperties, this.model.References);
            }
        }

        public void SetVersion(ModelId mid, ModelVersion version)
        {
            if (this.group != null)
            {
                GreenModel model = this.GetModel(mid);
                this.UpdateModel(model.Update(model.Metadata.WithVersion(version), model.Objects, model.StrongObjects, model.LazyProperties, model.References));
            }
            else
            {
                Debug.Assert(this.model.Id == mid);
                this.model = this.model.Update(model.Metadata.WithVersion(version), this.model.Objects, this.model.StrongObjects, this.model.LazyProperties, this.model.References);
            }
        }

        private ObjectRef ResolveObjectRef(ObjectId oid, bool onlyFromModels = false)
        {
            GreenObject green = null;
            if (this.group != null)
            {
                foreach (var model in this.group.Models.Values)
                {
                    if (model.Objects.TryGetValue(oid, out green))
                    {
                        return new ObjectRef(model, oid, green, false);
                    }
                }
                if (!onlyFromModels)
                {
                    foreach (var model in this.group.References.Values)
                    {
                        if (model.Objects.TryGetValue(oid, out green))
                        {
                            return new ObjectRef(model, oid, green, true);
                        }
                    }
                }
                return null;
            }
            else
            {
                if (this.model.Objects.TryGetValue(oid, out green))
                {
                    return new ObjectRef(this.model, oid, green, false);
                }
            }
            return null;
        }

        private ObjectRef ResolveObjectRef(ModelId mid, ObjectId oid, bool onlyFromModels = false)
        {
            GreenModel model = null;
            bool readOnly = false;
            if (this.group != null)
            {
                if (this.group.Models.TryGetValue(mid, out model))
                {
                    readOnly = false;
                }
                else if (!onlyFromModels && this.group.References.TryGetValue(mid, out model))
                {
                    readOnly = true;
                }
            }
            else
            {
                if (this.model.Id == mid)
                {
                    model = this.model;
                }
            }
            if (model != null)
            {
                GreenObject green = null;
                if (model.Objects.TryGetValue(oid, out green))
                {
                    return new ObjectRef(model, oid, green, readOnly);
                }
            }
            return null;
        }

        private void UpdateModel(GreenModel model)
        {
            if (this.group != null)
            {
                this.group = this.group.Update(this.group.Models.SetItem(model.Id, model), this.group.References);
            }
            else
            {
                this.model = model;
            }
        }

        private GreenModel UpdateObject(ModelId mid, ObjectId oid, GreenObject green)
        {
            GreenModel model = this.GetModel(mid);
            Debug.Assert(model != null);
            model = model.Update(model.Metadata, model.Objects.SetItem(oid, green), model.StrongObjects, model.LazyProperties, model.References);
            if (this.group != null)
            {
                this.group = this.group.Update(this.group.Models.SetItem(model.Id, model), this.group.References);
            }
            else
            {
                this.model = model;
            }
            return model;
        }

        public bool ObjectExists(ObjectId oid)
        {
            if (this.group != null)
            {
                foreach (var model in this.group.Models.Values)
                {
                    if (model.Objects.ContainsKey(oid)) return true;
                }
                foreach (var model in this.group.References.Values)
                {
                    if (model.Objects.ContainsKey(oid)) return true;
                }
                return false;
            }
            else
            {
                return this.model.Objects.ContainsKey(oid);
            }
        }

        public bool ContainsObject(ObjectId oid)
        {
            if (this.group != null)
            {
                foreach (var model in this.group.Models.Values)
                {
                    if (model.Objects.ContainsKey(oid)) return true;
                }
                return false;
            }
            else
            {
                return this.model.Objects.ContainsKey(oid);
            }
        }

        public bool ContainsObject(ModelId mid, ObjectId oid)
        {
            GreenModel model;
            if (this.group != null)
            {
                if (!this.group.Models.TryGetValue(mid, out model))
                {
                    return false;
                }
            }
            else
            {
                Debug.Assert(this.model.Id == mid);
                model = this.model;
            }
            return model.Objects.ContainsKey(oid);
        }

        public void AddObject(ModelId mid, ObjectId oid, bool weak)
        {
            if (this.ContainsObject(oid))
            {
                if (this.group != null) this.MakeException(Location.None, ModelErrorCode.ERR_ObjectAlreadyContainedByModelGroup, oid);
                else this.MakeException(Location.None, ModelErrorCode.ERR_ObjectAlreadyContainedByModel, oid);
            }
            GreenModel model = this.GetModel(mid);
            if (model == null)
            {
                Debug.Assert(false);
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotResolveModelById, mid);
            }
            if (this.group != null)
            {
                this.group = this.group.UpdateModel(model.AddObject(oid, weak));
            }
            else
            {
                this.model = model.AddObject(oid, weak);
            }
        }

        public bool RemoveObject(ModelId mid, ObjectId oid)
        {
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
            if (objectRef == null) return false;
            foreach (var slot in objectRef.Object.Slots.Keys)
            {
                if (slot.IsCollection)
                {
                    this.ClearItems(mid, oid, slot, true);
                }
                else
                {
                    this.SetValue(mid, oid, slot, true, null);
                }
            }
            if (this.group != null)
            {
                this.group = this.group.RemoveObject(oid);
            }
            else
            {
                this.model = this.model.RemoveObject(oid);
            }
            return true;
        }

        public void MergeObjects(ModelId mid, ObjectId targetOid, ObjectId partOid)
        {
            if (targetOid == partOid) return;
            ObjectRef targetObjectRef = this.ResolveObjectRef(mid, targetOid, true);
            ObjectRef partObjectRef = this.ResolveObjectRef(mid, partOid, true);
            if (targetObjectRef == null || partObjectRef == null) this.MakeException(Location.None, ModelErrorCode.ERR_CannotMergeObjectsResolve, partOid, targetOid);
            GreenObject partObject = partObjectRef.Object;
            foreach (var slot in partObject.Slots.Keys)
            {
                object partValue = this.GetValue(mid, partOid, slot);
                if (partValue != GreenObject.Unassigned)
                {
                    if (slot.IsCollection)
                    {
                        GreenList partValues = partValue as GreenList;
                        if (partValues != null)
                        {
                            foreach (var item in partValues)
                            {
                                this.AddItem(mid, targetOid, slot, false, false, -1, item);
                            }
                            foreach (var lazyItem in partValues.LazyItems)
                            {
                                this.AddItem(mid, targetOid, slot, false, false, -1, lazyItem);
                            }
                            this.ClearItems(mid, partOid, slot, true);
                        }
                    }
                    else
                    {
                        object targetValue = this.GetValue(mid, targetOid, slot);
                        if (targetValue == GreenObject.Unassigned)
                        {
                            this.SetValue(mid, targetOid, slot, false, partValue);
                        }
                        else if (!GreenObject.Equals(targetValue, partValue))
                        {
                            this.MakeException(Location.None, ModelErrorCode.ERR_CannotMergeObjectsProperty, partOid, targetOid, slot.Name, partValue, targetValue);
                        }
                        this.SetValue(mid, partOid, slot, true, null);
                    }
                }
            }
            if (this.group != null)
            {
                this.group = this.group.ReplaceObject(partOid, targetOid);
            }
            else
            {
                this.model = this.model.ReplaceObject(partOid, targetOid);
            }
        }

        public bool AttachProperty(ModelId mid, ObjectId oid, ModelProperty property)
        {
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
            Debug.Assert(objectRef != null);
            GreenObject green = objectRef.Object;
            if (green.Slots.ContainsKey(property)) return false;
            this.UpdateObject(mid, oid, green.Update(green.Parent, green.Children, green.Slots.Add(property, GreenObject.Unassigned)));
            return true;
        }

        public ImmutableList<ObjectId> GetChildren(ModelId mid, ObjectId oid)
        {
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
            Debug.Assert(objectRef != null);
            if (objectRef != null)
            {
                GreenModel model = objectRef.Model;
                ImmutableHashSet<Slot> lazyProperties;
                if (model.LazyProperties.TryGetValue(oid, out lazyProperties) && lazyProperties.Count > 0)
                {
                    foreach (var property in lazyProperties)
                    {
                        if (property.IsContainment)
                        {
                            this.GetValue(mid, oid, property, true);
                        }
                    }
                    objectRef = this.ResolveObjectRef(mid, oid, true);
                }
            }
            return objectRef.Object.Children;
        }

        public bool TryGetValue(ModelId mid, ObjectId oid, Slot slot, out object value)
        {
            if (this.TryGetValueCore(mid, oid, slot, false, false, out value))
            {
                return true;
            }
            return false;
        }

        public bool HasValue(ModelId mid, ObjectId oid, Slot slot)
        {
            object value;
            return this.TryGetValueCore(mid, oid, slot, false, false, out value);
        }

        public object GetValue(ModelId mid, ObjectId oid, Slot slot)
        {
            object value;
            if (this.TryGetValueCore(mid, oid, slot, false, false, out value))
            {
                return value;
            }
            return null;
        }

        public object GetValue(ModelId mid, ObjectId oid, Slot slot, bool lazyEval)
        {
            if (lazyEval)
            {
                ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
                if (objectRef != null)
                {
                    GreenModel model = objectRef.Model;
                    ImmutableHashSet<Slot> lazyProperties;
                    if (model.LazyProperties.TryGetValue(oid, out lazyProperties) && lazyProperties.Count > 0)
                    {
                        ModelObjectDescriptor objectInfo = oid.Descriptor;
                        if (objectInfo != null)
                        {
                            if (lazyProperties.Contains(slot))
                            {
                                this.LazyEvalCore(mid, oid, slot);
                            }
                            foreach (var supersetSlot in slot.SubsetSlots)
                            {
                                if (lazyProperties.Contains(supersetSlot))
                                {
                                    this.LazyEvalCore(mid, oid, supersetSlot);
                                }
                            }
                        }
                    }
                }
            }
            return this.GetValue(mid, oid, slot);
        }

        public bool SetValue(ModelId mid, ObjectId oid, Slot slot, bool reassign, object value)
        {
            Debug.Assert(!slot.IsCollection);
            var plainValue = GreenObject.ExtractValue(value);
            if (plainValue is ObjectId)
            {
                if (!this.ObjectExists((ObjectId)plainValue))
                {
                    if (this.group != null) this.MakeException(Location.None, ModelErrorCode.ERR_ObjectCannotBeAssignedToPropertyModelGroup, value, slot, oid);
                    else this.MakeException(Location.None, ModelErrorCode.ERR_ObjectCannotBeAssignedToPropertyModel, value, slot, oid);
                }
            }
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
            Debug.Assert(objectRef != null);
            GreenObject green = objectRef.Object;
            object oldValue;
            if (green.Slots.TryGetValue(slot, out oldValue) && !GreenObject.EqualsWithTag(oldValue, value))
            {
                bool result;
                if (slot.IsSimpleSlot || value is LazyValue || value is GreenDerivedValue)
                {
                    result = this.SetValueCore(objectRef, slot, reassign, value);
                    this.UpdateModel(objectRef.Model);
                }
                else
                {
                    result = this.SlowRemoveValueCore(mid, oid, slot, true, reassign, -1, false, oldValue, null, null);
                    result = this.SlowAddValueCore(mid, oid, slot, reassign, -1, value, null, null) || result;
                }
                return result;
            }
            return false;
        }

        public bool AddItem(ModelId mid, ObjectId oid, Slot slot, bool reassign, bool replace, int index, object value)
        {
            Debug.Assert(slot.IsCollection);
            var plainValue = GreenObject.ExtractValue(value);
            if (plainValue is ObjectId)
            {
                if (!this.ObjectExists((ObjectId)plainValue))
                {
                    if (this.group != null) this.MakeException(Location.None, ModelErrorCode.ERR_ObjectCannotBeAddedToPropertyModelGroup, value, slot, oid);
                    else this.MakeException(Location.None, ModelErrorCode.ERR_ObjectCannotBeAddedToPropertyModel, value, slot, oid);
                }
            }
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
            Debug.Assert(objectRef != null);
            GreenObject green = objectRef.Object;
            bool changed = false;
            if (green.Slots.ContainsKey(slot))
            {
                if (slot.IsSimpleSlot || value is LazyValue || value is GreenDerivedValue)
                {
                    object oldValue = null;
                    bool removedValue = false;
                    bool removedAllValues = false;
                    bool valueAdded;
                    bool newValueAdded;
                    if (replace && index >= 0) (removedValue, removedAllValues) = this.RemoveItemCore(objectRef, slot, true, reassign, index, false, ref oldValue);
                    (valueAdded, newValueAdded) = this.AddItemCore(objectRef, slot, reassign, index, value);
                    if (removedValue || valueAdded) changed = true;
                    this.UpdateModel(objectRef.Model);
                }
                else
                {
                    if (replace && index >= 0) changed = this.SlowRemoveValueCore(mid, oid, slot, true, reassign, index, false, null, null, null) || changed;
                    changed = this.SlowAddValueCore(mid, oid, slot, reassign, index, value, null, null) || changed;
                }
            }
            return changed;
        }

        public bool RemoveItem(ModelId mid, ObjectId oid, Slot slot, bool reassign, int index, bool removeAll, object value)
        {
            Debug.Assert(slot.IsCollection);
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
            Debug.Assert(objectRef != null);
            GreenObject green = objectRef.Object;
            bool changed = false;
            if (green.Slots.ContainsKey(slot))
            {
                if (slot.IsSimpleSlot || value is LazyValue || value is GreenDerivedValue)
                {
                    bool removedValue = false;
                    bool removedAllValues = false;
                    (removedValue, removedAllValues) = this.RemoveItemCore(objectRef, slot, true, reassign, index, removeAll, ref value);
                    if (removedValue) changed = true;
                    this.UpdateModel(objectRef.Model);
                }
                else
                {
                    changed = this.SlowRemoveValueCore(mid, oid, slot, true, reassign, index, removeAll, value, null, null) || changed;
                }
            }
            return changed;
        }

        public bool ClearItems(ModelId mid, ObjectId oid, Slot slot, bool reassign)
        {
            Debug.Assert(slot.IsCollection);
            object listValue;
            bool changed = false;
            if (this.TryGetValueCore(mid, oid, slot, false, false, out listValue) && (listValue is GreenList))
            {
                GreenList list = (GreenList)listValue;
                changed = list.Count > 0 || list.HasLazyItems;
                if (slot.IsModelObject || !slot.IsSimpleSlot)
                {
                    this.ClearLazyItems(mid, oid, slot, reassign);
                    foreach (var value in list)
                    {
                        this.RemoveItem(mid, oid, slot, reassign, -1, true, value);
                    }
                }
                else
                {
                    ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
                    Debug.Assert(objectRef != null);
                    GreenModel oldModel = objectRef.Model;
                    ImmutableHashSet<Slot> oldLazyProperties;
                    bool hasLazy = oldModel.LazyProperties.TryGetValue(oid, out oldLazyProperties) && oldLazyProperties.Contains(slot);
                    var newLazyModelProperties = oldModel.LazyProperties;
                    if (hasLazy)
                    {
                        var newLazyProperties = oldLazyProperties.Remove(slot);
                        if (newLazyProperties.Count > 0)
                        {
                            newLazyModelProperties = newLazyModelProperties.SetItem(oid, newLazyProperties);
                        }
                        else
                        {
                            newLazyModelProperties = newLazyModelProperties.Remove(oid);
                        }
                    }
                    GreenObject oldGreen = objectRef.Object;
                    GreenObject newGreen =
                        oldGreen.Update(
                            oldGreen.Parent,
                            oldGreen.Children,
                            oldGreen.Slots.SetItem(slot, hasLazy ? list.ClearLazy().Clear() : list.Clear()));
                    GreenModel newModel =
                        oldModel.Update(
                            oldModel.Metadata,
                            oldModel.Objects.SetItem(oid, newGreen),
                            oldModel.StrongObjects,
                            newLazyModelProperties,
                            oldModel.References);
                    this.UpdateModel(newModel);
                }
            }
            return changed;
        }

        public bool ClearLazyItems(ModelId mid, ObjectId oid, Slot slot, bool reassign)
        {
            Debug.Assert(slot.IsCollection);
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
            Debug.Assert(objectRef != null);
            bool changed = this.ClearLazyItemsCore(objectRef, slot, reassign);
            this.UpdateModel(objectRef.Model);
            return changed;
        }

        public bool EvaluateLazyValues(ModelId mid, ObjectId oid, CancellationToken cancellationToken)
        {
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
            Debug.Assert(objectRef != null);
            GreenModel model = objectRef.Model;
            ImmutableHashSet<Slot> properties;
            int counter = 0;
            bool changed = false;
            bool evaluatedAny = true;
            while (evaluatedAny)
            {
                cancellationToken.ThrowIfCancellationRequested();
                evaluatedAny = false;
                if (model.LazyProperties.TryGetValue(oid, out properties))
                {
                    var propList = objectRef.Id.Descriptor.Slots;
                    foreach (var prop in propList)
                    {
                        if (properties.Contains(prop) && !prop.IsDerived)
                        {
                            properties = properties.Remove(prop);
                            this.GetValue(mid, oid, prop, true);
                            evaluatedAny = true;
                        }
                    }
                    foreach (var prop in properties)
                    {
                        if (!prop.IsDerived)
                        {
                            this.GetValue(mid, oid, prop, true);
                            evaluatedAny = true;
                        }
                    }
                    if (evaluatedAny)
                    {
                        changed = true;
                    }
                    objectRef = this.ResolveObjectRef(mid, oid, true);
                    model = objectRef.Model;
                    ++counter;
                    if (counter >= 100) break; // exit after 100 iterations to prevent infinite loop
                }
            }
            Debug.Assert(!model.LazyProperties.ContainsKey(oid) || model.LazyProperties[oid].All(p => p.IsDerived));
            return changed;
        }

        public bool EvaluateLazyValues(ModelId mid, CancellationToken cancellationToken)
        {
            GreenModel model = this.GetModel(mid);
            if (model == null) return false;
            if (model.LazyProperties.Count == 0) return false;
            int counter = 0;
            bool changed = false;
            bool evaluatedAny = true;
            while (evaluatedAny)
            {
                cancellationToken.ThrowIfCancellationRequested();
                evaluatedAny = false;
                foreach (var oid in model.StrongObjects)
                {
                    if (model.LazyProperties.ContainsKey(oid))
                    {
                        evaluatedAny = this.EvaluateLazyValues(mid, oid, cancellationToken) || evaluatedAny;
                    }
                }
                model = this.GetModel(mid);
                foreach (var oid in model.LazyProperties.Keys)
                {
                    evaluatedAny = this.EvaluateLazyValues(mid, oid, cancellationToken) || evaluatedAny;
                }
                if (evaluatedAny)
                {
                    changed = true;
                }
                model = this.GetModel(mid);
                ++counter;
                if (counter >= 100) break; // exit after 100 iterations to prevent infinite loop
            }
            Debug.Assert(model.LazyProperties.Values.All(props => props.All(p => p.IsDerived)));
            return changed;
        }

        public bool EvaluateLazyValues(CancellationToken cancellationToken)
        {
            if (this.group != null)
            {
                bool changed = false;
                foreach (var mid in this.group.Models.Keys)
                {
                    changed = this.EvaluateLazyValues(mid, cancellationToken) || changed;
                }
                return changed;
            }
            else
            {
                return this.EvaluateLazyValues(this.model.Id, cancellationToken);
            }
        }

        private bool TryGetValueCore(ObjectRef objectRef, Slot slot, bool returnUnassignedValue, bool returnLazyValue, out object value)
        {
            GreenObject green = objectRef.Object;
            if (green.Slots.TryGetValue(slot, out value))
            {
                if (value != GreenObject.Unassigned)
                {
                    if (!returnLazyValue && value is LazyValue)
                    {
                        value = null;
                        return false;
                    }
                    return true;
                }
                else
                {
                    if (!returnUnassignedValue)
                    {
                        value = slot.DefaultValue;
                    }
                    return true;
                }
            }
            value = null;
            return false;
        }

        private bool TryGetValueCore(ModelId mid, ObjectId oid, Slot slot, bool returnUnassignedValue, bool returnLazyValue, out object value)
        {
            value = null;
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, false);
            if (objectRef == null) return false;
            return this.TryGetValueCore(objectRef, slot, returnUnassignedValue, returnLazyValue, out value);
        }

        private bool CheckOldValue(ObjectRef objectRef, Slot slot, bool reassign, object oldValue)
        {
            if (!reassign)
            {
                if (slot.IsDerived && oldValue != GreenObject.Unassigned)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotReassignDerivedProperty, slot, objectRef.Id);
                    return false;
                }
                if (slot.IsReadonly && oldValue != GreenObject.Unassigned)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotReassignReadOnlyProperty, slot, objectRef.Id);
                    return false;
                }
            }
            return true;
        }

        private bool CheckNewValue(ObjectRef objectRef, Slot slot, ref object value)
        {
            var plainValue = GreenObject.ExtractValue(value);
            if (plainValue == null && slot.IsNonNull)
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignNullToProperty, slot, objectRef.Id);
                value = null;
                return false;
            }
            if (plainValue == null || value == GreenObject.Unassigned || (value is LazyValue) || (value is GreenDerivedValue))
            {
                return true;
            }
            if ((plainValue is ObjectId) && !slot.IsAssignableFrom(((ObjectId)plainValue).Descriptor.MutableType, out var unassignableProperty))
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignValueToProperty, plainValue, ((ObjectId)plainValue).Descriptor.MutableType, unassignableProperty, unassignableProperty.MutableType, objectRef.Id);
                value = null;
                return false;
            }
            if (!(plainValue is ObjectId) && !slot.IsAssignableFrom(plainValue.GetType(), out unassignableProperty))
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignValueToProperty, plainValue, plainValue.GetType(), unassignableProperty, unassignableProperty.MutableType, objectRef.Id);
                value = null;
                return false;
            }
            return true;
        }

        private bool CheckOldItem(ObjectRef objectRef, Slot slot, bool reassign)
        {
            if (!reassign)
            {
                if (slot.IsDerived)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeDerivedProperty, slot, objectRef.Id);
                    return false;
                }
                if (slot.IsReadonly)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeReadOnlyProperty, slot, objectRef.Id);
                    return false;
                }
            }
            return true;
        }

        private bool CheckNewItem(ObjectRef objectRef, Slot slot, ref object value)
        {
            var plainValue = GreenObject.ExtractValue(value);
            if (plainValue == null && slot.IsNonNull)
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddNullToProperty, slot, objectRef.Id);
                value = null;
                return false;
            }
            if (plainValue == null || value == GreenObject.Unassigned || (value is LazyValue) || (value is GreenDerivedValue))
            {
                return true;
            }
            if ((plainValue is ObjectId) && !slot.IsAssignableFrom(((ObjectId)plainValue).Descriptor.MutableType, out var unassignableProperty))
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddValueToProperty, plainValue, ((ObjectId)plainValue).Descriptor.MutableType, unassignableProperty, unassignableProperty.MutableType, objectRef.Id);
                value = null;
                return false;
            }
            if (!(plainValue is ObjectId) && !slot.IsAssignableFrom(plainValue.GetType(), out unassignableProperty))
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddValueToProperty, plainValue, plainValue.GetType(), unassignableProperty, unassignableProperty.MutableType, objectRef.Id);
                value = null;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Sets the value of a single valued property. Updates references and lazy property index. This method does not update any related properties.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="slot"></param>
        /// <param name="reassign"></param>
        /// <param name="value"></param>
        /// <param name="oldValue"></param>
        /// <returns></returns>
        private bool SetValueCore(ObjectRef objectRef, Slot slot, bool reassign, object value)
        {
            Debug.Assert(objectRef.Object.Slots.ContainsKey(slot));
            object oldValue;
            if (!this.TryGetValueCore(objectRef, slot, true, true, out oldValue)) return false;
            if (GreenObject.EqualsWithTag(value, oldValue)) return false;
            if (!this.CheckOldValue(objectRef, slot, reassign, oldValue)) return false;
            this.CheckNewValue(objectRef, slot, ref value);
            var plainOldValue = GreenObject.ExtractValue(oldValue);
            var plainValue = GreenObject.ExtractValue(value);
            if (plainOldValue != null && plainOldValue != GreenObject.Unassigned)
            {
                if (plainOldValue is ObjectId)
                {
                    this.RemoveReferenceCore(objectRef, slot, (ObjectId)plainOldValue);
                }
                else if ((plainOldValue is LazyValue) && !(plainValue is LazyValue))
                {
                    this.RemoveLazyPropertyCore(objectRef, slot);
                }
            }
            if (plainValue != null && plainValue != GreenObject.Unassigned)
            {
                if (plainValue is ObjectId)
                {
                    this.AddReferenceCore(objectRef, slot, (ObjectId)plainValue);
                }
                else if ((plainValue is LazyValue) && !(plainOldValue is LazyValue))
                {
                    this.AddLazyPropertyCore(objectRef, slot);
                }
            }
            GreenObject green = objectRef.Object;
            if (object.Equals(plainValue, slot.DefaultValue)) green = green.Update(green.Parent, green.Children, green.Slots.SetItem(slot, GreenObject.Unassigned));
            else green = green.Update(green.Parent, green.Children, green.Slots.SetItem(slot, value));
            objectRef.Update(green);
            return true;
        }

        /// <summary>
        /// Adds an item to a collection property. Updates references and lazy property index. This method does not update any related properties.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="slot"></param>
        /// <param name="reassign"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private (bool valueAdded, bool newValueAdded) AddItemCore(ObjectRef objectRef, Slot slot, bool reassign, int index, object value)
        {
            Debug.Assert(objectRef.Object.Slots.ContainsKey(slot));
            if (!this.CheckOldItem(objectRef, slot, reassign)) return (false, false);
            this.CheckNewItem(objectRef, slot, ref value);
            GreenList list;
            object listValue;
            if (!this.TryGetValueCore(objectRef, slot, false, false, out listValue) || !(listValue is GreenList))
            {
                list = slot.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique;
            }
            else
            {
                list = (GreenList)listValue;
            }
            bool newReference = false;
            GreenList oldList = list;
            if (value is LazyValue)
            {
                list = list.AddLazy((LazyValue)value);
                this.AddLazyPropertyCore(objectRef, slot);
            }
            else
            {
                var plainValue = GreenObject.ExtractValue(value);
                newReference = plainValue is ObjectId && !list.Contains(value);
                if (index >= 0 && index <= list.Count)
                {
                    list = list.Insert(index, value);
                }
                else
                {
                    list = list.Add(value);
                }
                if (newReference)
                {
                    this.AddReferenceCore(objectRef, slot, (ObjectId)plainValue);
                }
            }
            GreenObject green = objectRef.Object;
            green = green.Update(green.Parent, green.Children, green.Slots.SetItem(slot, list));
            objectRef.Update(green);
            return (list != oldList, newReference);
        }

        /// <summary>
        /// Removes an item from a collection property. Updates references and lazy property index. This method does not update any related properties.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="slot"></param>
        /// <param name="forceRemove"></param>
        /// <param name="reassign"></param>
        /// <param name="index"></param>
        /// <param name="removeAll"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private (bool valueRemoved, bool allValuesRemoved) RemoveItemCore(ObjectRef objectRef, Slot slot, bool forceRemove, bool reassign, int index, bool removeAll, ref object value)
        {
            Debug.Assert(objectRef.Object.Slots.ContainsKey(slot));
            if (!this.CheckOldItem(objectRef, slot, reassign)) return (false, false);
            GreenList list;
            object listValue;
            if (this.TryGetValueCore(objectRef, slot, false, false, out listValue))
            {
                if (listValue == null) return (false, false);
                Debug.Assert(listValue is GreenList);
                list = (GreenList)listValue;
            }
            else
            {
                return (false, false);
            }
            if (!forceRemove && slot.IsDerivedUnion)
            {
                if (index >= 0)
                {
                    if (index < list.Count) value = list[index];
                }
                if (slot.SubsettingSlots.Length > 0)
                {
                    ImmutableDictionary<Slot, object> properties = objectRef.Object.Slots;
                    foreach (var subsetSlot in slot.SubsettingSlots)
                    {
                        if (properties.TryGetValue(subsetSlot, out var representingSubsetValue))
                        {
                            if (representingSubsetValue is GreenList)
                            {
                                GreenList subsetList = (GreenList)representingSubsetValue;
                                if (subsetList.Contains(value))
                                {
                                    return (false, false);
                                }
                            }
                        }
                    }
                }
            }
            GreenList oldList = list;
            if (index >= 0)
            {
                if (index < list.Count)
                {
                    list = list.RemoveAt(index);
                }
            }
            else if (removeAll)
            {
                list = list.RemoveAll(value);
            }
            else
            {
                list = list.Remove(value);
            }
            bool removedAll = !list.Contains(value);
            var plainValue = GreenObject.ExtractValue(value);
            if (plainValue is ObjectId)
            {
                if (removedAll)
                {
                    this.RemoveReferenceCore(objectRef, slot, (ObjectId)plainValue);
                }
            }
            GreenObject green = objectRef.Object;
            green = green.Update(green.Parent, green.Children, green.Slots.SetItem(slot, list));
            objectRef.Update(green);
            return (oldList != list || removedAll, removedAll);
        }

        /// <summary>
        /// Adds an item to a property. Updates all the related properties.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="slot"></param>
        /// <param name="reassign"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <param name="valueAddedToSelf"></param>
        /// <param name="valueAddedToOpposite"></param>
        private bool SlowAddValueCore(ModelId mid, ObjectId oid, Slot slot, bool reassign, int index, object value, HashSet<Slot> valueAddedToSelf, HashSet<Slot> valueAddedToOpposite)
        {
            if (valueAddedToSelf != null && valueAddedToSelf.Contains(slot)) return false;
            ObjectRef objectRef = this.ResolveObjectRef(oid, true);
            if (objectRef == null) return false;
            var plainValue = GreenObject.ExtractValue(value);
            ObjectId valueId = plainValue as ObjectId;
            // Checking the value:
            if (!reassign)
            {
                if (slot.IsDerived)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeDerivedProperty, slot, oid);
                }
                if (slot.IsReadonly)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeReadOnlyProperty, slot, oid);
                }
            }
            if (plainValue == null)
            {
                if (slot.IsNonNull)
                {
                    if (slot.IsCollection)
                    {
                        this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddNullToProperty, slot, oid);
                    }
                    else
                    {
                        this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignNullToProperty, slot, oid);
                    }
                }
            }
            else if (plainValue != GreenObject.Unassigned)
            {
                var valueType = valueId != null ? valueId.Descriptor.MutableType : plainValue.GetType();
                if (!slot.IsAssignableFrom(valueType, out var unassignableProperty))
                {
                    if (slot.IsCollection)
                    {
                        this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddValueToProperty, plainValue, valueId.Descriptor.MutableType.Name, unassignableProperty, unassignableProperty.MutableType.Name, oid);
                    }
                    else
                    {
                        this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignValueToProperty, plainValue, valueId.Descriptor.MutableType.Name, unassignableProperty, unassignableProperty.MutableType.Name, oid);
                    }
                }
            }
            // Setting the value:
            bool valueAdded = false;
            bool newValueAdded = false;
            if (slot.IsCollection)
            {
                (valueAdded, newValueAdded) = this.AddItemCore(objectRef, slot, reassign, index, value);
            }
            else
            {
                valueAdded = this.SetValueCore(objectRef, slot, reassign, value);
                newValueAdded = valueAdded;
            }
            if (valueAdded)
            {
                this.UpdateModel(objectRef.Model);
            }
            else
            {
                if (valueAddedToSelf != null)
                {
                    valueAddedToSelf.Add(slot);
                }
                return false;
            }
            // Updating subsetted properties:
            bool initValueAdded = true;
            if (slot.SubsettedSlots.Length > 0)
            {
                initValueAdded = false;
                if (valueAddedToSelf == null) valueAddedToSelf = new HashSet<Slot>();
                valueAddedToSelf.Add(slot);
                foreach (var subsettedSlot in slot.SubsettedSlots)
                {
                    if (!subsettedSlot.IsDerived)
                    {
                        this.SlowAddValueCore(mid, oid, subsettedSlot, reassign || subsettedSlot.IsDerivedUnion, -1, value, valueAddedToSelf, valueAddedToOpposite);
                    }
                }
            }
            // Updating opposite properties:
            if (newValueAdded && valueId != null && slot.OppositeProperties.Length > 0)
            {
                ObjectRef valueObjectRef = this.ResolveObjectRef(valueId, true);
                if (valueObjectRef != null)
                {
                    if (initValueAdded)
                    {
                        if (valueAddedToSelf == null) valueAddedToSelf = new HashSet<Slot>();
                        valueAddedToSelf.Add(slot);
                    }
                    if (valueAddedToOpposite == null)
                    {
                        valueAddedToOpposite = new HashSet<Slot>();
                        foreach (var oppositeProp in slot.OppositeProperties)
                        {
                            var oppositeSlot = valueId.Descriptor.GetSlot(oppositeProp);
                            if (oppositeSlot != null && !oppositeSlot.IsDerived && !valueAddedToOpposite.Contains(oppositeSlot))
                            {
                                this.SlowAddValueCore(valueObjectRef.Model.Id, valueId, oppositeSlot, reassign, -1, oid, valueAddedToOpposite, valueAddedToSelf);
                            }
                        }
                    }
                }
            }
            return valueAdded;
        }

        /// <summary>
        /// Removes an item from a property. Updates all the related properties.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="slot"></param>
        /// <param name="forceRemove"></param>
        /// <param name="reassign"></param>
        /// <param name="index"></param>
        /// <param name="removeAll"></param>
        /// <param name="value"></param>
        /// <param name="valueRemovedFromSelf"></param>
        /// <param name="valueRemovedFromOpposite"></param>
        private bool SlowRemoveValueCore(ModelId mid, ObjectId oid, Slot slot, bool forceRemove, bool reassign, int index, bool removeAll, object value, HashSet<Slot> valueRemovedFromSelf, HashSet<Slot> valueRemovedFromOpposite)
        {
            if (valueRemovedFromSelf != null && valueRemovedFromSelf.Contains(slot)) return false;
            ObjectRef objectRef = this.ResolveObjectRef(oid, true);
            if (objectRef == null) return false;
            // Checking the value:
            if (!reassign)
            {
                if (slot.IsDerived)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeDerivedProperty, slot, oid);
                }
                if (slot.IsReadonly)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeReadOnlyProperty, slot, oid);
                }
            }
            // Setting the value:
            bool valueRemoved = false;
            bool allValuesRemoved = false;
            if (slot.IsCollection)
            {
                (valueRemoved, allValuesRemoved) = this.RemoveItemCore(objectRef, slot, forceRemove, reassign, index, removeAll, ref value);
            }
            else
            {
                valueRemoved = this.SetValueCore(objectRef, slot, reassign, GreenObject.Unassigned);
                allValuesRemoved = valueRemoved;
            }
            if (valueRemoved)
            {
                this.UpdateModel(objectRef.Model);
            }
            else
            {
                if (forceRemove || !slot.IsDerivedUnion)
                {
                    if (valueRemovedFromSelf != null)
                    {
                        valueRemovedFromSelf.Add(slot);
                    }
                }
                return false;
            }
            // Updating subsetting properties:
            bool initValueRemoved = true;
            if (slot.SubsettingSlots.Length > 0 || slot.DerivedUnionSlots.Length > 0)
            {
                if (valueRemovedFromSelf == null) valueRemovedFromSelf = new HashSet<Slot>();
                valueRemovedFromSelf.Add(slot);
                initValueRemoved = false;
                foreach (var subsettingSlot in slot.SubsettingSlots)
                {
                    if (!subsettingSlot.IsDerived)
                    {
                        this.SlowRemoveValueCore(mid, oid, subsettingSlot, true, reassign || subsettingSlot.IsDerivedUnion, -1, removeAll, value, valueRemovedFromSelf, valueRemovedFromOpposite);
                    }
                }
                foreach (var subsettedSlot in slot.DerivedUnionSlots)
                {
                    this.SlowRemoveValueCore(mid, oid, subsettedSlot, false, true, -1, removeAll, value, valueRemovedFromSelf, valueRemovedFromOpposite);
                }
            }
            // Updating opposite properties:
            var plainValue = GreenObject.ExtractValue(value);
            if (allValuesRemoved && plainValue is ObjectId && slot.OppositeProperties.Length > 0)
            {
                ObjectId valueId = (ObjectId)plainValue;
                ObjectRef valueObjectRef = this.ResolveObjectRef(valueId, true);
                if (valueObjectRef != null)
                {
                    if (initValueRemoved)
                    {
                        if (valueRemovedFromSelf == null) valueRemovedFromSelf = new HashSet<Slot>();
                        valueRemovedFromSelf.Add(slot);
                    }
                    if (valueRemovedFromOpposite == null)
                    {
                        valueRemovedFromOpposite = new HashSet<Slot>();
                        foreach (var oppositeProp in slot.OppositeProperties)
                        {
                            var oppositeSlot = valueId.Descriptor.GetSlot(oppositeProp);
                            if (oppositeSlot != null && !oppositeSlot.IsDerived && !valueRemovedFromOpposite.Contains(oppositeSlot))
                            {
                                this.SlowRemoveValueCore(valueObjectRef.Model.Id, valueId, oppositeSlot, true, reassign, -1, true, oid, valueRemovedFromOpposite, valueRemovedFromSelf);
                            }
                        }
                    }
                }
            }
            return valueRemoved;
        }

        /// <summary>
        /// Adds a reference to an object. 
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="slot"></param>
        /// <param name="valueOid"></param>
        private void AddReferenceCore(ObjectRef objectRef, Slot slot, ObjectId valueOid)
        {
            GreenModel model = objectRef.Model;
            ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>> references;
            if (!model.References.TryGetValue(valueOid, out references))
            {
                references = ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>>.Empty;
            }
            ObjectId oid = objectRef.Id;
            ImmutableHashSet<Slot> slots;
            if (!references.TryGetValue(oid, out slots))
            {
                slots = ImmutableHashSet<Slot>.Empty;
            }
            if (!slots.Contains(slot))
            {
                if (slot.IsContainment)
                {
                    ObjectRef valueRef = this.ResolveObjectRef(valueOid, true);
                    if (valueRef != null)
                    {
                        if (valueRef.Object.Parent != null)
                        {
                            if (valueRef.Object.Parent != oid)
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_InvalidContainment, valueOid, slot, oid, valueRef.Object.Parent);
                            }
                        }
                        else
                        {
                            if (valueOid == oid)
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_InvalidSelfContainment, valueOid, slot, oid);
                            }
                            if (valueRef.Model.Id != model.Id)
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_InvalidModelContainment, valueOid, slot, oid);
                            }
                            if (objectRef.Object.Parent != null)
                            {
                                List<ObjectId> ids = new List<ObjectId>();
                                ids.Add(valueOid);
                                GreenObject currentGreen = objectRef.Object;
                                ObjectId currentId = currentGreen.Parent;
                                while (currentId != null)
                                {
                                    if (ids.Contains(currentId))
                                    {
                                        this.MakeException(Location.None, ModelErrorCode.ERR_CircularContainment, valueOid, slot, oid);
                                    }
                                    ids.Add(currentId);
                                    if (model.Objects.TryGetValue(currentId, out currentGreen))
                                    {
                                        currentId = currentGreen.Parent;
                                    }
                                    else
                                    {
                                        currentId = null;
                                    }
                                }
                            }
                            GreenObject green = objectRef.Object;
                            Debug.Assert(!green.Children.Contains(valueOid));
                            objectRef.Update(green.Update(green.Parent, green.Children.Add(valueOid), green.Slots));
                            GreenObject valueObject;
                            if (objectRef.Model.Objects.TryGetValue(valueOid, out valueObject))
                            {
                                valueRef.Update(objectRef.Model, valueRef.Object.Update(oid, valueObject.Children, valueObject.Slots), true);
                                model = valueRef.Model;
                            }
                            else
                            {
                                Debug.Assert(false);
                            }
                        }
                    }
                }
                references = references.SetItem(oid, slots.Add(slot));
                model = model.Update(model.Metadata, model.Objects, model.StrongObjects, model.LazyProperties, model.References.SetItem(valueOid, references));
                objectRef.Update(model, objectRef.Object, false);
            }
        }

        /// <summary>
        /// Removes a reference to an object. 
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="slot"></param>
        /// <param name="valueOid"></param>
        private void RemoveReferenceCore(ObjectRef objectRef, Slot slot, ObjectId valueOid)
        {
            GreenModel model = objectRef.Model;
            ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>> references;
            if (!model.References.TryGetValue(valueOid, out references))
            {
                return;
            }
            ObjectId oid = objectRef.Id;
            ImmutableHashSet<Slot> slots;
            if (!references.TryGetValue(oid, out slots))
            {
                return;
            }
            if (slots.Contains(slot))
            {
                slots = slots.Remove(slot);
                if (slots.Count == 0) references = references.Remove(oid);
                else references = references.SetItem(oid, slots.Remove(slot));
                ImmutableDictionary<ObjectId, ImmutableDictionary<ObjectId, ImmutableHashSet<Slot>>> modelReferences;
                if (references.Count == 0) modelReferences = model.References.Remove(valueOid);
                else modelReferences = model.References.SetItem(valueOid, references);
                ImmutableDictionary<ObjectId, GreenObject> modelObjects = model.Objects;
                GreenObject green = objectRef.Object;
                if (slot.IsContainment)
                {
                    bool lostParent = true;
                    foreach (var prop in slots)
                    {
                        if (prop.IsContainment)
                        {
                            lostParent = false;
                            break;
                        }
                    }
                    if (lostParent)
                    {
                        GreenObject valueObject;
                        if (model.Objects.TryGetValue(valueOid, out valueObject))
                        {
                            green = green.Update(green.Parent, green.Children.Remove(valueOid), green.Slots);
                            modelObjects = modelObjects.
                                SetItem(valueOid, valueObject.Update(null, valueObject.Children, valueObject.Slots)).
                                SetItem(oid, green);
                        }
                        else
                        {
                            Debug.Assert(false);
                        }
                    }
                }
                model = model.Update(model.Metadata, modelObjects, model.StrongObjects, model.LazyProperties, modelReferences);
                objectRef.Update(model, green, false);
            }
        }

        /// <summary>
        /// Adds the property to the lazy property index. 
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="slot"></param>
        private void AddLazyPropertyCore(ObjectRef objectRef, Slot slot)
        {
            ObjectId oid = objectRef.Id;
            ImmutableHashSet<Slot> lazyProperties;
            GreenModel model = objectRef.Model;
            if (!model.LazyProperties.TryGetValue(oid, out lazyProperties))
            {
                lazyProperties = ImmutableHashSet<Slot>.Empty;
            }
            if (!lazyProperties.Contains(slot))
            {
                lazyProperties = lazyProperties.Add(slot);
                model = model.Update(model.Metadata, model.Objects, model.StrongObjects, model.LazyProperties.SetItem(oid, lazyProperties), model.References);
                objectRef.Update(model, objectRef.Object, false);
            }
        }

        /// <summary>
        /// Removes the property from the lazy property index. 
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="slot"></param>
        private void RemoveLazyPropertyCore(ObjectRef objectRef, Slot slot)
        {
            ObjectId oid = objectRef.Id;
            ImmutableHashSet<Slot> lazyProperties;
            GreenModel model = objectRef.Model;
            if (model.LazyProperties.TryGetValue(oid, out lazyProperties))
            {
                lazyProperties = lazyProperties.Remove(slot);
                if (lazyProperties.Count == 0) model = model.Update(model.Metadata, model.Objects, model.StrongObjects, model.LazyProperties.Remove(oid), model.References);
                else model = model.Update(model.Metadata, model.Objects, model.StrongObjects, model.LazyProperties.SetItem(oid, lazyProperties), model.References);
                objectRef.Update(model, objectRef.Object, false);
            }
        }

        /// <summary>
        /// Clears the lazy values of the property.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="slot"></param>
        /// <param name="reassign"></param>
        private bool ClearLazyItemsCore(ObjectRef objectRef, Slot slot, bool reassign)
        {
            Debug.Assert(slot.IsCollection);
            ObjectId oid = objectRef.Id;
            GreenModel oldModel = objectRef.Model;
            ImmutableHashSet<Slot> oldLazyProperties;
            bool changed = false;
            if (oldModel.LazyProperties.TryGetValue(oid, out oldLazyProperties) && oldLazyProperties.Contains(slot))
            {
                object listValue;
                if (this.TryGetValueCore(objectRef, slot, false, false, out listValue) && (listValue is GreenList))
                {
                    GreenList list = (GreenList)listValue;
                    GreenObject oldGreen = objectRef.Object;
                    GreenObject newGreen = oldGreen.Update(oldGreen.Parent, oldGreen.Children, oldGreen.Slots.SetItem(slot, list.ClearLazy()));
                    ImmutableHashSet<Slot> newLazyProperties = oldLazyProperties.Remove(slot);
                    GreenModel newModel;
                    if (newLazyProperties.Count == 0)
                    {
                        newModel =
                            oldModel.Update(
                                oldModel.Metadata,
                                oldModel.Objects.SetItem(oid, newGreen),
                                oldModel.StrongObjects,
                                oldModel.LazyProperties.Remove(oid),
                                oldModel.References);
                    }
                    else
                    {
                        newModel =
                            oldModel.Update(
                                oldModel.Metadata,
                                oldModel.Objects.SetItem(oid, newGreen),
                                oldModel.StrongObjects,
                                oldModel.LazyProperties.SetItem(oid, newLazyProperties),
                                oldModel.References);
                    }
                    objectRef.Update(newModel, newGreen, false);
                    changed = true;
                }
            }
            return changed;
        }

        /// <summary>
        /// Evaluates the lazy values of the property.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="slot"></param>
        private void LazyEvalCore(ModelId mid, ObjectId oid, Slot slot)
        {
            object greenValue;
            if (this.lazyEvalStack == null) this.lazyEvalStack = new List<GreenLazyEvalEntry>();
            GreenLazyEvalEntry entry = new GreenLazyEvalEntry(oid, slot.EffectiveProperty);
            int entryIndex = this.lazyEvalStack.IndexOf(entry);
            if (entryIndex >= 0)
            {
                this.MakeLazyEvalException(this.lazyEvalStack, null, null, ModelErrorCode.ERR_CircularLazyEvaluation);
            }
            try
            {
                var redModel = this.redModel ?? this.redModelGroup.GetModel(mid);
                this.lazyEvalStack.Add(entry);
                if (this.TryGetValueCore(mid, oid, slot, false, true, out greenValue))
                {
                    if (greenValue is LazyValue lazyValue)
                    {
                        try
                        {
                            if (lazyValue.IsSingleValue)
                            {
                                object value = this.LazyEvalValue(lazyValue, redModel, oid);
                                this.SetValue(mid, oid, slot, true, value);
                            }
                            else
                            {
                                IEnumerable<object> values = this.LazyEvalValues(lazyValue, redModel, oid);
                                foreach (var value in values)
                                {
                                    this.AddItem(mid, oid, slot, true, false, -1, value);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            this.MakeLazyEvalException(this.lazyEvalStack, ex, (LazyValue)greenValue, ModelErrorCode.ERR_LazyEvaluationError, ex.Message);
                            this.SetValue(mid, oid, slot, true, null);
                        }
                    }
                    else if (greenValue is GreenList)
                    {
                        GreenList list = (GreenList)greenValue;
                        if (list.HasLazyItems)
                        {
                            this.ClearLazyItems(mid, oid, slot, true);
                            foreach (var lazyItem in list.LazyItems)
                            {
                                if (lazyItem.IsSingleValue)
                                {
                                    try
                                    {
                                        object value = this.LazyEvalValue(lazyItem, redModel, oid);
                                        if (value != null)
                                        {
                                            this.AddItem(mid, oid, slot, true, false, -1, value);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        this.MakeLazyEvalException(this.lazyEvalStack, ex, lazyItem, ModelErrorCode.ERR_LazyEvaluationError, ex.Message);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        IEnumerable<object> values = this.LazyEvalValues(lazyItem, redModel, oid);
                                        foreach (var value in values)
                                        {
                                            if (value != null)
                                            {
                                                this.AddItem(mid, oid, slot, true, false, -1, value);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        this.MakeLazyEvalException(this.lazyEvalStack, ex, lazyItem, ModelErrorCode.ERR_LazyEvaluationError, ex.Message);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                lazyEvalStack.RemoveAt(lazyEvalStack.Count - 1);
            }
        }

        /// <summary>
        /// Evaluates the given lazy value.
        /// </summary>
        /// <param name="lazyValue"></param>
        /// <returns></returns>
        private object LazyEvalValue(LazyValue lazyValue, IModel redModel, ObjectId context)
        {
            try
            {
                return lazyValue.CreateGreenValue(redModel, context);
            }
            catch (LazyEvaluationException)
            {
                throw;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                this.MakeLazyEvalException(this.lazyEvalStack, ex, lazyValue, ModelErrorCode.ERR_LazyEvaluationError, ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Evaluates the given lazy value.
        /// </summary>
        /// <param name="lazyValue"></param>
        /// <returns></returns>
        private IEnumerable<object> LazyEvalValues(LazyValue lazyValues, IModel redModel, ObjectId context)
        {
            try
            {
                return lazyValues.CreateGreenValues(redModel, context);
            }
            catch (LazyEvaluationException)
            {
                throw;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                this.MakeLazyEvalException(this.lazyEvalStack, ex, lazyValues, ModelErrorCode.ERR_LazyEvaluationError, ex.ToString());
            }
            return SpecializedCollections.EmptyEnumerable<object>();
        }

        public void PurgeWeakObjects()
        {
            if (this.group != null)
            {
                var strongObjects = this.CollectStrongObjects();
                this.group = this.group.PurgeWeakObjects(strongObjects);
            }
            else
            {
                if (this.model.StrongObjects.Count < this.model.Objects.Count)
                {
                    var strongObjects = this.CollectStrongObjects();
                    this.model = this.model.PurgeWeakObjects(strongObjects);
                }
            }
        }

        private HashSet<ObjectId> CollectStrongObjects()
        {
            var result = new HashSet<ObjectId>();
            if (this.group != null)
            {
                foreach (var model in this.group.Models.Values)
                {
                    result.UnionWith(model.StrongObjects);
                }
                bool repeat = true;
                while (repeat)
                {
                    repeat = false;
                    foreach (var model in this.group.Models.Values)
                    {
                        if (model.StrongObjects.Count < model.Objects.Count)
                        {
                            repeat = this.CollectStrongObjects(result, model);
                        }
                    }
                }
            }
            else
            {
                result.UnionWith(this.model.StrongObjects);
                if (this.model.StrongObjects.Count < this.model.Objects.Count)
                {
                    this.CollectStrongObjects(result, this.model);
                }
            }
            return result;
        }

        private bool CollectStrongObjects(HashSet<ObjectId> strongObjects, GreenModel model)
        {
            Debug.Assert(model.LazyProperties.IsEmpty);
            Debug.Assert(model.StrongObjects.Count < model.Objects.Count);
            bool result = false;
            bool repeat = true;
            while (repeat)
            {
                repeat = false;
                foreach (var refs in model.References)
                {
                    if (strongObjects.Contains(refs.Key)) continue;
                    foreach (var refObjectId in refs.Value.Keys)
                    {
                        if (strongObjects.Contains(refObjectId))
                        {
                            repeat = true;
                            result = true;
                            strongObjects.Add(refs.Key);
                            break;
                        }
                    }
                }
            }
            return result;
        }


        private class ModelRef
        {
            private GreenModel model;
            private bool isReadonly;

            public ModelRef(GreenModel model, bool isReadonly)
            {
                this.model = model;
                this.isReadonly = isReadonly;
            }

            public GreenModel Model { get { return this.model; } }
            public bool IsReadonly { get { return this.isReadonly; } }
        }

        private class ObjectRef
        {
            private GreenModel model;
            private ObjectId id;
            private GreenObject green;
            private bool isReadonly;

            public ObjectRef(GreenModel model, ObjectId id, GreenObject green, bool isReadonly)
            {
                this.model = model;
                this.id = id;
                this.green = green;
                this.isReadonly = isReadonly;
            }

            public GreenModel Model { get { return this.model; } }
            public ObjectId Id { get { return this.id; } }
            public GreenObject Object { get { return this.green; } }
            public bool IsReadonly { get { return this.isReadonly; } }

            public void Update(GreenModel model, GreenObject green, bool addObjectToModel)
            {
                if (addObjectToModel) this.model = model.Update(model.Metadata, model.Objects.SetItem(this.id, green), model.StrongObjects, model.LazyProperties, model.References);
                else this.model = model;
                this.green = green;
            }

            public void Update(GreenObject green)
            {
                this.model = model.Update(model.Metadata, model.Objects.SetItem(this.id, green), model.StrongObjects, model.LazyProperties, model.References);
                this.green = green;
            }
        }
    }

}
