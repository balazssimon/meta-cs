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
            var diagnostic = LanguageDiagnostic.Create(new LazyEvaluationDiagnosticInfo(LazyEvalStackToRed(evaluationStack), errorCode, args)).WithLocation(lazy.Location);
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

        public GreenModel CreateModel(ModelId mid, string name, ModelVersion version)
        {
            Debug.Assert(this.group != null);
            if (mid == null) return null;
            GreenModel result = new GreenModel(mid, name, version);
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
                this.UpdateModel(model.Update(name, model.Version, model.Objects, model.StrongObjects, model.LazyProperties, model.References));
            }
            else
            {
                Debug.Assert(this.model.Id == mid);
                this.model = this.model.Update(name, this.model.Version, this.model.Objects, this.model.StrongObjects, this.model.LazyProperties, this.model.References);
            }
        }

        public void SetVersion(ModelId mid, ModelVersion version)
        {
            if (this.group != null)
            {
                GreenModel model = this.GetModel(mid);
                this.UpdateModel(model.Update(model.Name, version, model.Objects, model.StrongObjects, model.LazyProperties, model.References));
            }
            else
            {
                Debug.Assert(this.model.Id == mid);
                this.model = this.model.Update(this.model.Name, version, this.model.Objects, this.model.StrongObjects, this.model.LazyProperties, this.model.References);
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
            model = model.Update(model.Name, model.Version, model.Objects.SetItem(oid, green), model.StrongObjects, model.LazyProperties, model.References);
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
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotResolveModel, mid);
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
            foreach (var property in objectRef.Object.Properties.Keys)
            {
                if (property.IsCollection)
                {
                    this.ClearItems(mid, oid, property, true);
                }
                else
                {
                    this.SetValue(mid, oid, property, true, null);
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
            foreach (var property in partObject.Properties.Keys)
            {
                object partValue = this.GetValue(mid, partOid, property);
                if (partValue != GreenObject.Unassigned)
                {
                    if (property.IsCollection)
                    {
                        GreenList partValues = partValue as GreenList;
                        if (partValues != null)
                        {
                            foreach (var item in partValues)
                            {
                                this.AddItem(mid, targetOid, property, false, false, -1, item);
                            }
                            foreach (var lazyItem in partValues.LazyItems)
                            {
                                this.AddItem(mid, targetOid, property, false, false, -1, lazyItem);
                            }
                            this.ClearItems(mid, partOid, property, true);
                        }
                    }
                    else
                    {
                        object targetValue = this.GetValue(mid, targetOid, property);
                        if (targetValue == GreenObject.Unassigned)
                        {
                            this.SetValue(mid, targetOid, property, false, partValue);
                        }
                        else if (targetValue != partValue)
                        {
                            this.MakeException(Location.None, ModelErrorCode.ERR_CannotMergeObjectsProperty, partOid, targetOid, property.Name, partValue, targetValue);
                        }
                        this.SetValue(mid, partOid, property, true, null);
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
            if (green.Properties.ContainsKey(property)) return false;
            this.UpdateObject(mid, oid, green.Update(green.Parent, green.Children, green.Properties.Add(property, GreenObject.Unassigned)));
            return true;
        }

        public ImmutableList<ObjectId> GetChildren(ModelId mid, ObjectId oid)
        {
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
            Debug.Assert(objectRef != null);
            if (objectRef != null)
            {
                GreenModel model = objectRef.Model;
                ImmutableHashSet<ModelProperty> lazyProperties;
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

        public bool TryGetValue(ModelId mid, ObjectId oid, ModelProperty property, out object value)
        {
            property = this.GetRepresentingProperty(oid, property);
            if (this.TryGetValueCore(mid, oid, property, false, false, out value))
            {
                return true;
            }
            return false;
        }

        public bool HasValue(ModelId mid, ObjectId oid, ModelProperty property)
        {
            property = this.GetRepresentingProperty(oid, property);
            object value;
            return this.TryGetValueCore(mid, oid, property, false, false, out value);
        }

        public object GetValue(ModelId mid, ObjectId oid, ModelProperty property)
        {
            property = this.GetRepresentingProperty(oid, property);
            object value;
            if (this.TryGetValueCore(mid, oid, property, false, false, out value))
            {
                return value;
            }
            return null;
        }

        public object GetValue(ModelId mid, ObjectId oid, ModelProperty property, bool lazyEval)
        {
            if (lazyEval)
            {
                ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
                if (objectRef != null)
                {
                    GreenModel model = objectRef.Model;
                    ImmutableHashSet<ModelProperty> lazyProperties;
                    if (model.LazyProperties.TryGetValue(oid, out lazyProperties) && lazyProperties.Count > 0)
                    {
                        ModelObjectDescriptor objectInfo = oid.Descriptor;
                        if (objectInfo != null)
                        {
                            ModelPropertyInfo propertyInfo = objectInfo.GetPropertyInfo(property);
                            if (propertyInfo != null)
                            {
                                if (propertyInfo.RepresentingProperty != null) property = propertyInfo.RepresentingProperty;
                                if (lazyProperties.Contains(property))
                                {
                                    this.LazyEvalCore(mid, oid, property);
                                }
                                foreach (var supersetProp in propertyInfo.SubsetProperties)
                                {
                                    if (lazyProperties.Contains(supersetProp))
                                    {
                                        this.LazyEvalCore(mid, oid, supersetProp);
                                    }
                                }
                            }
                            else
                            {
                                if (lazyProperties.Contains(property))
                                {
                                    this.LazyEvalCore(mid, oid, property);
                                }
                            }
                        }
                    }
                }
            }
            return this.GetValue(mid, oid, property);
        }

        public void SetValue(ModelId mid, ObjectId oid, ModelProperty property, bool reassign, object value)
        {
            Debug.Assert(!property.IsCollection);
            if (value is ObjectId)
            {
                if (!this.ObjectExists((ObjectId)value))
                {
                    if (this.group != null) this.MakeException(Location.None, ModelErrorCode.ERR_ObjectCannotBeAssignedToPropertyModelGroup, value, property, oid);
                    else this.MakeException(Location.None, ModelErrorCode.ERR_ObjectCannotBeAssignedToPropertyModel, value, property, oid);
                }
            }
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
            Debug.Assert(objectRef != null);
            GreenObject green = objectRef.Object;
            property = this.GetRepresentingProperty(oid, property);
            object oldValue;
            if (green.Properties.TryGetValue(property, out oldValue) && value != oldValue)
            {
                if (!oid.Descriptor.HasAffectedProperties(property) || value is LazyValue || value is GreenDerivedValue)
                {
                    this.SetValueCore(objectRef, property, reassign, value);
                    this.UpdateModel(objectRef.Model);
                }
                else
                {
                    this.SlowRemoveValueCore(mid, oid, property, true, reassign, -1, false, oldValue, null, null);
                    this.SlowAddValueCore(mid, oid, property, reassign, -1, value, null, null);
                }
            }
        }

        public bool AddItem(ModelId mid, ObjectId oid, ModelProperty property, bool reassign, bool replace, int index, object value)
        {
            Debug.Assert(property.IsCollection);
            if (value is ObjectId)
            {
                if (!this.ObjectExists((ObjectId)value))
                {
                    if (this.group != null) this.MakeException(Location.None, ModelErrorCode.ERR_ObjectCannotBeAddedToPropertyModelGroup, value, property, oid);
                    else this.MakeException(Location.None, ModelErrorCode.ERR_ObjectCannotBeAddedToPropertyModel, value, property, oid);
                }
            }
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
            Debug.Assert(objectRef != null);
            GreenObject green = objectRef.Object;
            property = this.GetRepresentingProperty(oid, property);
            bool changed = false;
            if (green.Properties.ContainsKey(property))
            {
                if (!oid.Descriptor.HasAffectedProperties(property) || value is LazyValue || value is GreenDerivedValue)
                {
                    object oldValue = null;
                    if (replace && index >= 0) changed = this.RemoveItemCore(objectRef, property, true, reassign, index, false, ref oldValue) || changed;
                    changed = this.AddItemCore(objectRef, property, reassign, index, value) || changed;
                    this.UpdateModel(objectRef.Model);
                }
                else
                {
                    if (replace && index >= 0) changed = this.SlowRemoveValueCore(mid, oid, property, true, reassign, index, false, null, null, null) || changed;
                    changed = this.SlowAddValueCore(mid, oid, property, reassign, index, value, null, null) || changed;
                }
            }
            return changed;
        }

        public bool RemoveItem(ModelId mid, ObjectId oid, ModelProperty property, bool reassign, int index, bool removeAll, object value)
        {
            Debug.Assert(property.IsCollection);
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
            Debug.Assert(objectRef != null);
            GreenObject green = objectRef.Object;
            property = this.GetRepresentingProperty(oid, property);
            bool changed = false;
            if (green.Properties.ContainsKey(property))
            {
                if (!oid.Descriptor.HasAffectedProperties(property) || value is LazyValue || value is GreenDerivedValue)
                {
                    changed = this.RemoveItemCore(objectRef, property, true, reassign, index, removeAll, ref value) || changed;
                    this.UpdateModel(objectRef.Model);
                }
                else
                {
                    changed = this.SlowRemoveValueCore(mid, oid, property, true, reassign, index, removeAll, value, null, null) || changed;
                }
            }
            return changed;
        }

        public bool ClearItems(ModelId mid, ObjectId oid, ModelProperty property, bool reassign)
        {
            Debug.Assert(property.IsCollection);
            property = this.GetRepresentingProperty(oid, property);
            object listValue;
            bool changed = false;
            if (this.TryGetValueCore(mid, oid, property, false, false, out listValue) && (listValue is GreenList))
            {
                GreenList list = (GreenList)listValue;
                changed = list.Count > 0 || list.HasLazyItems;
                if (property.IsModelObject || oid.Descriptor.HasAffectedProperties(property))
                {
                    this.ClearLazyItems(mid, oid, property, reassign);
                    foreach (var value in list)
                    {
                        this.RemoveItem(mid, oid, property, reassign, -1, true, value);
                    }
                }
                else
                {
                    ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
                    Debug.Assert(objectRef != null);
                    GreenModel oldModel = objectRef.Model;
                    ImmutableHashSet<ModelProperty> oldLazyProperties;
                    bool hasLazy = oldModel.LazyProperties.TryGetValue(oid, out oldLazyProperties) && oldLazyProperties.Contains(property);
                    var newLazyModelProperties = oldModel.LazyProperties;
                    if (hasLazy)
                    {
                        var newLazyProperties = oldLazyProperties.Remove(property);
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
                            oldGreen.Properties.SetItem(property, hasLazy ? list.ClearLazy().Clear() : list.Clear()));
                    GreenModel newModel =
                        oldModel.Update(
                            oldModel.Name,
                            oldModel.Version,
                            oldModel.Objects.SetItem(oid, newGreen),
                            oldModel.StrongObjects,
                            newLazyModelProperties,
                            oldModel.References);
                    this.UpdateModel(newModel);
                }
            }
            return changed;
        }

        public bool ClearLazyItems(ModelId mid, ObjectId oid, ModelProperty property, bool reassign)
        {
            Debug.Assert(property.IsCollection);
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
            Debug.Assert(objectRef != null);
            property = this.GetRepresentingProperty(oid, property);
            bool changed = this.ClearLazyItemsCore(objectRef, property, reassign);
            this.UpdateModel(objectRef.Model);
            return changed;
        }

        public bool EvaluateLazyValues(ModelId mid, ObjectId oid, CancellationToken cancellationToken)
        {
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, true);
            Debug.Assert(objectRef != null);
            GreenModel model = objectRef.Model;
            ImmutableHashSet<ModelProperty> properties;
            int counter = 0;
            bool changed = false;
            bool evaluatedAny = true;
            while (evaluatedAny)
            {
                cancellationToken.ThrowIfCancellationRequested();
                evaluatedAny = false;
                if (model.LazyProperties.TryGetValue(oid, out properties))
                {
                    var propList = objectRef.Id.Descriptor.Properties;
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

        private ModelProperty GetRepresentingProperty(ObjectId oid, ModelProperty property)
        {
            ModelProperty result = property;
            ModelObjectDescriptor objectInfo = oid.Descriptor;
            if (objectInfo != null)
            {
                ModelPropertyInfo propInfo = objectInfo.GetPropertyInfo(property);
                if (propInfo != null) result = propInfo.RepresentingProperty;
                if (result == null) result = property;
            }
            return result;
        }

        private bool TryGetValueCore(ObjectRef objectRef, ModelProperty property, bool returnUnassignedValue, bool returnLazyValue, out object value)
        {
            GreenObject green = objectRef.Object;
            if (green.Properties.TryGetValue(property, out value))
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
                        value = null;
                        return false;
                    }
                    return true;
                }
            }
            value = null;
            return false;
        }

        private bool TryGetValueCore(ModelId mid, ObjectId oid, ModelProperty property, bool returnUnassignedValue, bool returnLazyValue, out object value)
        {
            value = null;
            ObjectRef objectRef = this.ResolveObjectRef(mid, oid, false);
            if (objectRef == null) return false;
            GreenObject green = objectRef.Object;
            if (green == null) return false;
            if (green.Properties.TryGetValue(property, out value))
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
                        value = null;
                    }
                }
            }
            return false;
        }

        private bool CheckOldValue(ObjectRef objectRef, ModelProperty property, bool reassign, object oldValue)
        {
            if (!reassign)
            {
                if (property.IsDerived && oldValue != GreenObject.Unassigned)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotReassignDerivedProperty, property, objectRef.Id);
                    return false;
                }
                if (property.IsReadonly && oldValue != GreenObject.Unassigned)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotReassignReadOnlyProperty, property, objectRef.Id);
                    return false;
                }
                if (oldValue is LazyValue)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotReassignLazyValuedProperty, property, objectRef.Id);
                    return false;
                }
            }
            return true;
        }

        private bool CheckNewValue(ObjectRef objectRef, ModelProperty property, ref object value)
        {
            if (value == null && property.IsNonNull)
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignNullToProperty, property, objectRef.Id);
                value = null;
                return false;
            }
            if (value == null || value == GreenObject.Unassigned || (value is LazyValue) || (value is GreenDerivedValue))
            {
                return true;
            }
            if ((value is ObjectId) && !property.MutableTypeInfo.Type.IsAssignableFrom(((ObjectId)value).Descriptor.MutableType))
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignValueToProperty, value, ((ObjectId)value).Descriptor.MutableType, property, property.MutableTypeInfo.Type, objectRef.Id);
                value = null;
                return false;
            }
            if (!(value is ObjectId) && !property.MutableTypeInfo.Type.IsAssignableFrom(value.GetType()))
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignValueToProperty, value, value.GetType(), property, property.MutableTypeInfo.Type, objectRef.Id);
                value = null;
                return false;
            }
            return true;
        }

        private bool CheckOldItem(ObjectRef objectRef, ModelProperty property, bool reassign)
        {
            if (!reassign)
            {
                if (property.IsDerived)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeDerivedProperty, property, objectRef.Id);
                    return false;
                }
                if (property.IsReadonly)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeReadOnlyProperty, property, objectRef.Id);
                    return false;
                }
            }
            return true;
        }

        private bool CheckNewItem(ObjectRef objectRef, ModelProperty property, ref object value)
        {
            if (value == null && property.IsNonNull)
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddNullToProperty, property, objectRef.Id);
                value = null;
                return false;
            }
            if (value == null || value == GreenObject.Unassigned || (value is LazyValue) || (value is GreenDerivedValue))
            {
                return true;
            }
            if ((value is ObjectId) && !property.MutableTypeInfo.Type.IsAssignableFrom(((ObjectId)value).Descriptor.MutableType))
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddValueToProperty, value, ((ObjectId)value).Descriptor.MutableType, property, property.MutableTypeInfo.Type, objectRef.Id);
                value = null;
                return false;
            }
            if (!(value is ObjectId) && !property.MutableTypeInfo.Type.IsAssignableFrom(value.GetType()))
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddValueToProperty, value, value.GetType(), property, property.MutableTypeInfo.Type, objectRef.Id);
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
        /// <param name="property"></param>
        /// <param name="reassign"></param>
        /// <param name="value"></param>
        /// <param name="oldValue"></param>
        /// <returns></returns>
        private bool SetValueCore(ObjectRef objectRef, ModelProperty property, bool reassign, object value)
        {
            Debug.Assert(objectRef.Object.Properties.ContainsKey(property));
            object oldValue;
            if (!this.TryGetValueCore(objectRef, property, true, true, out oldValue)) return false;
            if (value == oldValue) return false;
            if (!this.CheckOldValue(objectRef, property, reassign, oldValue)) return false;
            this.CheckNewValue(objectRef, property, ref value);
            if (oldValue != null && oldValue != GreenObject.Unassigned)
            {
                if (oldValue is ObjectId)
                {
                    this.RemoveReferenceCore(objectRef, property, (ObjectId)oldValue);
                }
                else if ((oldValue is LazyValue) && !(value is LazyValue))
                {
                    this.RemoveLazyPropertyCore(objectRef, property);
                }
            }
            if (value != null && value != GreenObject.Unassigned)
            {
                if (value is ObjectId)
                {
                    this.AddReferenceCore(objectRef, property, (ObjectId)value);
                }
                else if ((value is LazyValue) && !(oldValue is LazyValue))
                {
                    this.AddLazyPropertyCore(objectRef, property);
                }
            }
            GreenObject green = objectRef.Object;
            green = green.Update(green.Parent, green.Children, green.Properties.SetItem(property, value));
            objectRef.Update(green);
            return true;
        }

        /// <summary>
        /// Adds an item to a collection property. Updates references and lazy property index. This method does not update any related properties.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="property"></param>
        /// <param name="reassign"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool AddItemCore(ObjectRef objectRef, ModelProperty property, bool reassign, int index, object value)
        {
            Debug.Assert(objectRef.Object.Properties.ContainsKey(property));
            if (!this.CheckOldItem(objectRef, property, reassign)) return false;
            this.CheckNewItem(objectRef, property, ref value);
            GreenList list;
            object listValue;
            if (!this.TryGetValueCore(objectRef, property, false, false, out listValue) || !(listValue is GreenList))
            {
                list = property.IsUnique ? GreenList.EmptyUnique : GreenList.EmptyNonUnique;
            }
            else
            {
                list = (GreenList)listValue;
            }
            GreenList oldList = list;
            if (value is LazyValue)
            {
                list = list.AddLazy((LazyValue)value);
                this.AddLazyPropertyCore(objectRef, property);
            }
            else
            {
                bool newReference = value is ObjectId && !list.Contains(value);
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
                    this.AddReferenceCore(objectRef, property, (ObjectId)value);
                }
            }
            GreenObject green = objectRef.Object;
            green = green.Update(green.Parent, green.Children, green.Properties.SetItem(property, list));
            objectRef.Update(green);
            return list != oldList;
        }

        /// <summary>
        /// Removes an item from a collection property. Updates references and lazy property index. This method does not update any related properties.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="property"></param>
        /// <param name="forceRemove"></param>
        /// <param name="reassign"></param>
        /// <param name="index"></param>
        /// <param name="removeAll"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool RemoveItemCore(ObjectRef objectRef, ModelProperty property, bool forceRemove, bool reassign, int index, bool removeAll, ref object value)
        {
            Debug.Assert(objectRef.Object.Properties.ContainsKey(property));
            if (!this.CheckOldItem(objectRef, property, reassign)) return false;
            GreenList list;
            object listValue;
            if (this.TryGetValueCore(objectRef, property, false, false, out listValue))
            {
                if (listValue == null) return false;
                Debug.Assert(listValue is GreenList);
                list = (GreenList)listValue;
            }
            else
            {
                return false;
            }
            if (!forceRemove && property.IsDerivedUnion)
            {
                if (index >= 0)
                {
                    if (index < list.Count) value = list[index];
                }
                ModelObjectDescriptor objectInfo = objectRef.Id.Descriptor;
                if (objectInfo != null)
                {
                    ModelPropertyInfo propInfo = objectInfo.GetPropertyInfo(property);
                    if (propInfo != null && propInfo.SubsettingProperties.Count > 0)
                    {
                        ImmutableDictionary<ModelProperty, object> properties = objectRef.Object.Properties;
                        foreach (var subsetProp in propInfo.SubsettingProperties)
                        {
                            ModelProperty representingSubsetProp = subsetProp;
                            ModelPropertyInfo subsetPropInfo = objectInfo.GetPropertyInfo(subsetProp);
                            if (subsetPropInfo != null && subsetPropInfo.RepresentingProperty != null) representingSubsetProp = subsetPropInfo.RepresentingProperty;
                            object representingSubsetValue;
                            if (properties.TryGetValue(representingSubsetProp, out representingSubsetValue))
                            {
                                if (representingSubsetValue is GreenList)
                                {
                                    GreenList subsetList = (GreenList)representingSubsetValue;
                                    if (subsetList.Contains(value))
                                    {
                                        return false;
                                    }
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
            if (value is ObjectId)
            {
                if (removedAll)
                {
                    this.RemoveReferenceCore(objectRef, property, (ObjectId)value);
                }
            }
            GreenObject green = objectRef.Object;
            green = green.Update(green.Parent, green.Children, green.Properties.SetItem(property, list));
            objectRef.Update(green);
            return oldList != list || removedAll;
        }

        /// <summary>
        /// Adds an item to a property. Updates all the related properties.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="property"></param>
        /// <param name="reassign"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <param name="valueAddedToSelf"></param>
        /// <param name="valueAddedToOpposite"></param>
        private bool SlowAddValueCore(ModelId mid, ObjectId oid, ModelProperty property, bool reassign, int index, object value, HashSet<ModelProperty> valueAddedToSelf, HashSet<ModelProperty> valueAddedToOpposite)
        {
            if (valueAddedToSelf != null && valueAddedToSelf.Contains(property)) return false;
            ModelObjectDescriptor info = oid.Descriptor;
            if (info == null) return false;
            ModelPropertyInfo propertyInfo = info.GetPropertyInfo(property);
            if (propertyInfo == null) return false;
            ObjectRef objectRef = this.ResolveObjectRef(oid, true);
            if (objectRef == null) return false;
            ObjectId valueId = value as ObjectId;
            // Checking the value:
            if (!reassign)
            {
                foreach (var eqProp in propertyInfo.EquivalentProperties)
                {
                    if (eqProp.IsDerived)
                    {
                        this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeDerivedProperty, eqProp, oid);
                    }
                    if (eqProp.IsReadonly)
                    {
                        this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeReadOnlyProperty, eqProp, oid);
                    }
                }
            }
            if (value == null)
            {
                foreach (var eqProp in propertyInfo.EquivalentProperties)
                {
                    if (eqProp.IsNonNull)
                    {
                        if (eqProp.IsCollection)
                        {
                            this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddNullToProperty, eqProp, oid);
                        }
                        else
                        {
                            this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignNullToProperty, eqProp, oid);
                        }
                    }
                }
            }
            else if (value != GreenObject.Unassigned)
            {
                if (valueId != null)
                {
                    foreach (var eqProp in propertyInfo.EquivalentProperties)
                    {
                        if (!eqProp.MutableTypeInfo.Type.IsAssignableFrom(valueId.Descriptor.MutableType))
                        {
                            if (eqProp.IsCollection)
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddValueToProperty, value, valueId.Descriptor.MutableType, eqProp, eqProp.MutableTypeInfo.Type, oid);
                            }
                            else
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignValueToProperty, value, valueId.Descriptor.MutableType, eqProp, eqProp.MutableTypeInfo.Type, oid);
                            }
                        }
                    }
                }
                else
                {
                    Type valueType = value.GetType();
                    foreach (var eqProp in propertyInfo.EquivalentProperties)
                    {
                        if (!eqProp.MutableTypeInfo.Type.IsAssignableFrom(valueType))
                        {
                            if (eqProp.IsCollection)
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddValueToProperty, value, valueType, eqProp, eqProp.MutableTypeInfo.Type, oid);
                            }
                            else
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignValueToProperty, value, valueType, eqProp, eqProp.MutableTypeInfo.Type, oid);
                            }
                        }
                    }
                }
            }
            // Setting the value:
            bool valueAdded = false;
            if (property.IsCollection)
            {
                valueAdded = this.AddItemCore(objectRef, property, reassign, index, value);
            }
            else
            {
                valueAdded = this.SetValueCore(objectRef, property, reassign, value);
            }
            if (valueAdded)
            {
                this.UpdateModel(objectRef.Model);
            }
            else
            {
                if (valueAddedToSelf != null)
                {
                    valueAddedToSelf.UnionWith(propertyInfo.EquivalentProperties);
                    valueAddedToSelf.Add(property);
                }
                return false;
            }
            // Updating subsetted properties:
            bool initValueAdded = true;
            if (propertyInfo.SubsettedProperties.Count > 0)
            {
                initValueAdded = false;
                if (valueAddedToSelf == null) valueAddedToSelf = new HashSet<ModelProperty>(propertyInfo.EquivalentProperties);
                else valueAddedToSelf.UnionWith(propertyInfo.EquivalentProperties);
                valueAddedToSelf.Add(property);
                foreach (var subsettedProp in propertyInfo.SubsettedProperties)
                {
                    ModelProperty subsettedRepProp = this.GetRepresentingProperty(oid, subsettedProp);
                    this.SlowAddValueCore(mid, oid, subsettedRepProp, reassign, -1, value, valueAddedToSelf, valueAddedToOpposite);
                }
            }
            // Updating opposite properties:
            if (valueId != null && propertyInfo.OppositeProperties.Count > 0)
            {
                ObjectRef valueObjectRef = this.ResolveObjectRef(valueId, true);
                if (valueObjectRef != null)
                {
                    if (initValueAdded)
                    {
                        if (valueAddedToSelf == null) valueAddedToSelf = new HashSet<ModelProperty>(propertyInfo.EquivalentProperties);
                        else valueAddedToSelf.UnionWith(propertyInfo.EquivalentProperties);
                        valueAddedToSelf.Add(property);
                    }
                    if (valueAddedToOpposite == null)
                    {
                        valueAddedToOpposite = new HashSet<ModelProperty>();

                        foreach (var oppositeProp in propertyInfo.OppositeProperties)
                        {
                            ModelProperty oppositeRepProp = this.GetRepresentingProperty(valueId, oppositeProp);
                            if (!valueAddedToOpposite.Contains(oppositeProp))
                            {
                                this.SlowAddValueCore(valueObjectRef.Model.Id, valueId, oppositeRepProp, reassign, -1, oid, valueAddedToOpposite, valueAddedToSelf);
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
        /// <param name="property"></param>
        /// <param name="forceRemove"></param>
        /// <param name="reassign"></param>
        /// <param name="index"></param>
        /// <param name="removeAll"></param>
        /// <param name="value"></param>
        /// <param name="valueRemovedFromSelf"></param>
        /// <param name="valueRemovedFromOpposite"></param>
        private bool SlowRemoveValueCore(ModelId mid, ObjectId oid, ModelProperty property, bool forceRemove, bool reassign, int index, bool removeAll, object value, HashSet<ModelProperty> valueRemovedFromSelf, HashSet<ModelProperty> valueRemovedFromOpposite)
        {
            if (valueRemovedFromSelf != null && valueRemovedFromSelf.Contains(property)) return false;
            ModelObjectDescriptor info = oid.Descriptor;
            if (info == null) return false;
            ModelPropertyInfo propertyInfo = info.GetPropertyInfo(property);
            if (propertyInfo == null) return false;
            ObjectRef objectRef = this.ResolveObjectRef(oid, true);
            if (objectRef == null) return false;
            // Checking the value:
            if (!reassign)
            {
                foreach (var eqProp in propertyInfo.EquivalentProperties)
                {
                    if (eqProp.IsDerived)
                    {
                        this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeDerivedProperty, eqProp, oid);
                    }
                    if (eqProp.IsReadonly)
                    {
                        this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeReadOnlyProperty, eqProp, oid);
                    }
                }
            }
            // Setting the value:
            bool valueRemoved = false;
            if (property.IsCollection)
            {
                valueRemoved = this.RemoveItemCore(objectRef, property, forceRemove, reassign, index, removeAll, ref value);
            }
            else
            {
                valueRemoved = this.SetValueCore(objectRef, property, reassign, GreenObject.Unassigned);
            }
            if (valueRemoved)
            {
                this.UpdateModel(objectRef.Model);
            }
            else
            {
                if (forceRemove || !property.IsDerivedUnion)
                {
                    if (valueRemovedFromSelf != null)
                    {
                        valueRemovedFromSelf.UnionWith(propertyInfo.EquivalentProperties);
                        valueRemovedFromSelf.Add(property);
                    }
                }
                return false;
            }
            // Updating subsetting properties:
            bool initValueRemoved = true;
            if (propertyInfo.SubsettingProperties.Count > 0 || propertyInfo.DerivedUnionProperties.Count > 0)
            {
                if (valueRemovedFromSelf == null) valueRemovedFromSelf = new HashSet<ModelProperty>(propertyInfo.EquivalentProperties);
                else valueRemovedFromSelf.UnionWith(propertyInfo.EquivalentProperties);
                valueRemovedFromSelf.Add(property);
                initValueRemoved = false;
                foreach (var subsettingProp in propertyInfo.SubsettingProperties)
                {
                    ModelProperty subsettingRepProp = this.GetRepresentingProperty(oid, subsettingProp);
                    this.SlowRemoveValueCore(mid, oid, subsettingRepProp, true, reassign, -1, removeAll, value, valueRemovedFromSelf, valueRemovedFromOpposite);
                }
                foreach (var subsettedProp in propertyInfo.DerivedUnionProperties)
                {
                    ModelProperty subsettedRepProp = this.GetRepresentingProperty(oid, subsettedProp);
                    this.SlowRemoveValueCore(mid, oid, subsettedRepProp, false, reassign, -1, removeAll, value, valueRemovedFromSelf, valueRemovedFromOpposite);
                }
            }
            // Updating opposite properties:
            if (value is ObjectId && propertyInfo.OppositeProperties.Count > 0)
            {
                ObjectId valueId = (ObjectId)value;
                ObjectRef valueObjectRef = this.ResolveObjectRef(valueId, true);
                if (valueObjectRef != null)
                {
                    if (initValueRemoved)
                    {
                        if (valueRemovedFromSelf == null) valueRemovedFromSelf = new HashSet<ModelProperty>(propertyInfo.EquivalentProperties);
                        else valueRemovedFromSelf.UnionWith(propertyInfo.EquivalentProperties);
                        valueRemovedFromSelf.Add(property);
                    }
                    foreach (var oppositeProp in propertyInfo.OppositeProperties)
                    {
                        ModelProperty oppositeRepProp = this.GetRepresentingProperty(valueId, oppositeProp);
                        this.SlowRemoveValueCore(valueObjectRef.Model.Id, valueId, oppositeRepProp, true, reassign, -1, removeAll, oid, valueRemovedFromOpposite, valueRemovedFromSelf);
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
        /// <param name="property"></param>
        /// <param name="valueOid"></param>
        private void AddReferenceCore(ObjectRef objectRef, ModelProperty property, ObjectId valueOid)
        {
            GreenModel model = objectRef.Model;
            ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>> references;
            if (!model.References.TryGetValue(valueOid, out references))
            {
                references = ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>>.Empty;
            }
            ObjectId oid = objectRef.Id;
            ImmutableHashSet<ModelProperty> properties;
            if (!references.TryGetValue(oid, out properties))
            {
                properties = ImmutableHashSet<ModelProperty>.Empty;
            }
            if (!properties.Contains(property))
            {
                if (property.IsContainment)
                {
                    ObjectRef valueRef = this.ResolveObjectRef(valueOid, true);
                    if (valueRef != null)
                    {
                        if (valueRef.Object.Parent != null)
                        {
                            if (valueRef.Object.Parent != oid)
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_InvalidContainment, valueOid, property, oid, valueRef.Object.Parent);
                            }
                        }
                        else
                        {
                            if (valueOid == oid)
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_InvalidSelfContainment, valueOid, property, oid);
                            }
                            if (valueRef.Model.Id != model.Id)
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_InvalidModelContainment, valueOid, property, oid);
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
                                        this.MakeException(Location.None, ModelErrorCode.ERR_CircularContainment, valueOid, property, oid);
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
                            objectRef.Update(green.Update(green.Parent, green.Children.Add(valueOid), green.Properties));
                            GreenObject valueObject;
                            if (objectRef.Model.Objects.TryGetValue(valueOid, out valueObject))
                            {
                                valueRef.Update(objectRef.Model, valueRef.Object.Update(oid, valueObject.Children, valueObject.Properties), true);
                                model = valueRef.Model;
                            }
                            else
                            {
                                Debug.Assert(false);
                            }
                        }
                    }
                }
                references = references.SetItem(oid, properties.Add(property));
                model = model.Update(model.Name, model.Version, model.Objects, model.StrongObjects, model.LazyProperties, model.References.SetItem(valueOid, references));
                objectRef.Update(model, objectRef.Object, false);
            }
        }

        /// <summary>
        /// Removes a reference to an object. 
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="property"></param>
        /// <param name="valueOid"></param>
        private void RemoveReferenceCore(ObjectRef objectRef, ModelProperty property, ObjectId valueOid)
        {
            GreenModel model = objectRef.Model;
            ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>> references;
            if (!model.References.TryGetValue(valueOid, out references))
            {
                return;
            }
            ObjectId oid = objectRef.Id;
            ImmutableHashSet<ModelProperty> properties;
            if (!references.TryGetValue(oid, out properties))
            {
                return;
            }
            if (properties.Contains(property))
            {
                properties = properties.Remove(property);
                if (properties.Count == 0) references = references.Remove(oid);
                else references = references.SetItem(oid, properties.Remove(property));
                ImmutableDictionary<ObjectId, ImmutableDictionary<ObjectId, ImmutableHashSet<ModelProperty>>> modelReferences;
                if (references.Count == 0) modelReferences = model.References.Remove(valueOid);
                else modelReferences = model.References.SetItem(valueOid, references);
                ImmutableDictionary<ObjectId, GreenObject> modelObjects = model.Objects;
                GreenObject green = objectRef.Object;
                if (property.IsContainment)
                {
                    bool lostParent = true;
                    foreach (var prop in properties)
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
                            green = green.Update(green.Parent, green.Children.Remove(valueOid), green.Properties);
                            modelObjects = modelObjects.
                                SetItem(valueOid, valueObject.Update(null, valueObject.Children, valueObject.Properties)).
                                SetItem(oid, green);
                        }
                        else
                        {
                            Debug.Assert(false);
                        }
                    }
                }
                model = model.Update(model.Name, model.Version, modelObjects, model.StrongObjects, model.LazyProperties, modelReferences);
                objectRef.Update(model, green, false);
            }
        }

        /// <summary>
        /// Adds the property to the lazy property index. 
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="property"></param>
        private void AddLazyPropertyCore(ObjectRef objectRef, ModelProperty property)
        {
            ObjectId oid = objectRef.Id;
            ImmutableHashSet<ModelProperty> lazyProperties;
            GreenModel model = objectRef.Model;
            if (!model.LazyProperties.TryGetValue(oid, out lazyProperties))
            {
                lazyProperties = ImmutableHashSet<ModelProperty>.Empty;
            }
            if (!lazyProperties.Contains(property))
            {
                lazyProperties = lazyProperties.Add(property);
                model = model.Update(model.Name, model.Version, model.Objects, model.StrongObjects, model.LazyProperties.SetItem(oid, lazyProperties), model.References);
                objectRef.Update(model, objectRef.Object, false);
            }
        }

        /// <summary>
        /// Removes the property from the lazy property index. 
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="property"></param>
        private void RemoveLazyPropertyCore(ObjectRef objectRef, ModelProperty property)
        {
            ObjectId oid = objectRef.Id;
            ImmutableHashSet<ModelProperty> lazyProperties;
            GreenModel model = objectRef.Model;
            if (model.LazyProperties.TryGetValue(oid, out lazyProperties))
            {
                lazyProperties = lazyProperties.Remove(property);
                if (lazyProperties.Count == 0) model = model.Update(model.Name, model.Version, model.Objects, model.StrongObjects, model.LazyProperties.Remove(oid), model.References);
                else model = model.Update(model.Name, model.Version, model.Objects, model.StrongObjects, model.LazyProperties.SetItem(oid, lazyProperties), model.References);
                objectRef.Update(model, objectRef.Object, false);
            }
        }

        /// <summary>
        /// Clears the lazy values of the property.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="objectRef"></param>
        /// <param name="property"></param>
        /// <param name="reassign"></param>
        private bool ClearLazyItemsCore(ObjectRef objectRef, ModelProperty property, bool reassign)
        {
            Debug.Assert(property.IsCollection);
            ObjectId oid = objectRef.Id;
            GreenModel oldModel = objectRef.Model;
            ImmutableHashSet<ModelProperty> oldLazyProperties;
            bool changed = false;
            if (oldModel.LazyProperties.TryGetValue(oid, out oldLazyProperties) && oldLazyProperties.Contains(property))
            {
                object listValue;
                if (this.TryGetValueCore(objectRef, property, false, false, out listValue) && (listValue is GreenList))
                {
                    GreenList list = (GreenList)listValue;
                    GreenObject oldGreen = objectRef.Object;
                    GreenObject newGreen = oldGreen.Update(oldGreen.Parent, oldGreen.Children, oldGreen.Properties.SetItem(property, list.ClearLazy()));
                    ImmutableHashSet<ModelProperty> newLazyProperties = oldLazyProperties.Remove(property);
                    GreenModel newModel;
                    if (newLazyProperties.Count == 0)
                    {
                        newModel =
                            oldModel.Update(
                                oldModel.Name,
                                oldModel.Version,
                                oldModel.Objects.SetItem(oid, newGreen),
                                oldModel.StrongObjects,
                                oldModel.LazyProperties.Remove(oid),
                                oldModel.References);
                    }
                    else
                    {
                        newModel =
                            oldModel.Update(
                                oldModel.Name,
                                oldModel.Version,
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
        /// <param name="property"></param>
        private void LazyEvalCore(ModelId mid, ObjectId oid, ModelProperty property)
        {
            object greenValue;
            if (this.lazyEvalStack == null) this.lazyEvalStack = new List<GreenLazyEvalEntry>();
            GreenLazyEvalEntry entry = new GreenLazyEvalEntry(oid, property);
            int entryIndex = this.lazyEvalStack.IndexOf(entry);
            if (entryIndex >= 0)
            {
                this.MakeLazyEvalException(this.lazyEvalStack, null, null, ModelErrorCode.ERR_CircularLazyEvaluation);
            }
            try
            {
                var redModel = this.redModel ?? this.redModelGroup.GetModel(mid);
                this.lazyEvalStack.Add(entry);
                if (this.TryGetValueCore(mid, oid, property, false, true, out greenValue))
                {
                    if (greenValue is LazyValue lazyValue)
                    {
                        try
                        {
                            if (lazyValue.IsSingleValue)
                            {
                                object value = this.LazyEvalValue(lazyValue, redModel, oid);
                                this.SetValue(mid, oid, property, true, value);
                            }
                            else
                            {
                                IEnumerable<object> values = this.LazyEvalValues(lazyValue, redModel, oid);
                                foreach (var value in values)
                                {
                                    this.AddItem(mid, oid, property, true, false, -1, value);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            this.MakeLazyEvalException(this.lazyEvalStack, ex, (LazyValue)greenValue, ModelErrorCode.ERR_LazyEvaluationError, ex.Message);
                            this.SetValue(mid, oid, property, true, null);
                        }
                    }
                    else if (greenValue is GreenList)
                    {
                        GreenList list = (GreenList)greenValue;
                        if (list.HasLazyItems)
                        {
                            this.ClearLazyItems(mid, oid, property, true);
                            foreach (var lazyItem in list.LazyItems)
                            {
                                if (lazyItem.IsSingleValue)
                                {
                                    try
                                    {
                                        object value = this.LazyEvalValue(lazyItem, redModel, oid);
                                        if (value != null)
                                        {
                                            this.AddItem(mid, oid, property, true, false, -1, value);
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
                                                this.AddItem(mid, oid, property, true, false, -1, value);
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
                if (addObjectToModel) this.model = model.Update(model.Name, model.Version, model.Objects.SetItem(this.id, green), model.StrongObjects, model.LazyProperties, model.References);
                else this.model = model;
                this.green = green;
            }

            public void Update(GreenObject green)
            {
                this.model = model.Update(model.Name, model.Version, model.Objects.SetItem(this.id, green), model.StrongObjects, model.LazyProperties, model.References);
                this.green = green;
            }
        }
    }

}
