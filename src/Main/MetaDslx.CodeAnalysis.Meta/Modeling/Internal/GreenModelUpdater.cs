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

        internal GreenModelUpdater(GreenModel model, MutableModel redModel)
        {
            this.model = model;
            this.group = null;
            this.redModel = redModel;
        }

        internal GreenModelUpdater(GreenModelGroup group, MutableModelGroup redModelGroup)
        {
            this.model = null;
            this.group = group;
            this.redModelGroup = redModelGroup;
        }

        private void MakeException(Location location, ErrorCode errorCode, params object[] args)
        {
            this.ArgsToRedMessageSerializable(args);
            throw new ModelException(location, new LanguageDiagnosticInfo(errorCode, args));
        }

        private void MakeLazyEvalException(List<GreenLazyEvalEntry> evaluationStack, Exception innerException, LazyValue lazy, ErrorCode errorCode, params object[] args)
        {
            this.ArgsToRedMessageSerializable(args);
            if (lazy != null)
            {
                if (lazy.Diagnostics != null)
                {
                    lazy.Diagnostics.Add(LanguageDiagnostic.Create(new LazyEvaluationDiagnosticInfo(evaluationStack.Select(e => new LazyEvalEntry(this.redModel?.ResolveSymbol(e.Symbol), e.Property)).ToImmutableArray(), errorCode, args)).WithLocation(lazy.Location));
                }
                else
                {
                    throw new LazyEvaluationException(lazy.Location, new LazyEvaluationDiagnosticInfo(evaluationStack.Select(e => new LazyEvalEntry(this.redModel?.ResolveSymbol(e.Symbol), e.Property)).ToImmutableArray(), errorCode, args), innerException);
                }
            }
            else
            {
                throw new LazyEvaluationException(Location.None, new LazyEvaluationDiagnosticInfo(evaluationStack.Select(e => new LazyEvalEntry(this.redModel?.ResolveSymbol(e.Symbol), e.Property)).ToImmutableArray(), errorCode, args), innerException);
            }
        }

        private void ArgsToRedMessageSerializable(object[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                SymbolId sid = args[i] as SymbolId;
                if (sid != null)
                {
                    IMetaSymbol symbol = null;
                    if (redModelGroup != null) symbol = this.redModelGroup.ResolveSymbol(sid);
                    else symbol = this.redModel.ResolveSymbol(sid);
                    if (symbol != null)
                    {
                        args[i] = symbol;
                    }
                }
                args[i] = args[i].ToString();
            }
        }

        private ImmutableArray<LazyEvalEntry> LazyEvalStackToRed(List<GreenLazyEvalEntry> evaluationStack)
        {
            if (redModelGroup != null) return evaluationStack.Select(e => new LazyEvalEntry(redModelGroup.ResolveSymbol(e.Symbol), e.Property)).ToImmutableArray();
            else return evaluationStack.Select(e => new LazyEvalEntry(redModel.ResolveSymbol(e.Symbol), e.Property)).ToImmutableArray();
        }

        internal GreenModel Model { get { return this.model; } }
        internal GreenModelGroup Group { get { return this.group; } }

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

        internal GreenModel CreateModel(ModelId mid, string name, ModelVersion version)
        {
            Debug.Assert(this.group != null);
            if (mid == null) return null;
            GreenModel result = new GreenModel(mid, name, version);
            this.group = this.group.AddModel(result);
            return result;
        }

        internal void AddModelReference(GreenModel reference)
        {
            Debug.Assert(this.group != null);
            this.group = this.group.AddReference(reference);
        }

        internal void AddModel(GreenModel model)
        {
            Debug.Assert(this.group != null);
            this.group = this.group.AddModel(model);
        }

        internal void SetName(ModelId mid, string name)
        {
            if (this.group != null)
            {
                GreenModel model = this.GetModel(mid);
                this.UpdateModel(model.Update(name, model.Version, model.Symbols, model.StrongSymbols, model.LazyProperties, model.References));
            }
            else
            {
                Debug.Assert(this.model.Id == mid);
                this.model = this.model.Update(name, this.model.Version, this.model.Symbols, this.model.StrongSymbols, this.model.LazyProperties, this.model.References);
            }
        }

        internal void SetVersion(ModelId mid, ModelVersion version)
        {
            if (this.group != null)
            {
                GreenModel model = this.GetModel(mid);
                this.UpdateModel(model.Update(model.Name, version, model.Symbols, model.StrongSymbols, model.LazyProperties, model.References));
            }
            else
            {
                Debug.Assert(this.model.Id == mid);
                this.model = this.model.Update(this.model.Name, version, this.model.Symbols, this.model.StrongSymbols, this.model.LazyProperties, this.model.References);
            }
        }

        private GreenSymbol GetSymbol(SymbolId sid, bool onlyFromModels = false)
        {
            GreenSymbol symbol = null;
            if (this.group != null)
            {
                foreach (var model in this.group.Models.Values)
                {
                    if (model.Symbols.TryGetValue(sid, out symbol))
                    {
                        return symbol;
                    }
                }
                if (!onlyFromModels)
                {
                    foreach (var model in this.group.References.Values)
                    {
                        if (model.Symbols.TryGetValue(sid, out symbol))
                        {
                            return symbol;
                        }
                    }
                }
                return null;
            }
            else
            {
                if (this.model.Symbols.TryGetValue(sid, out symbol))
                {
                    return symbol;
                }
            }
            return null;
        }

        private GreenSymbol GetSymbol(ModelId mid, SymbolId sid)
        {
            GreenModel model = this.GetModel(mid);
            GreenSymbol symbol;
            if (model != null && model.Symbols.TryGetValue(sid, out symbol))
            {
                return symbol;
            }
            return null;
        }

        private SymbolRef ResolveSymbol(SymbolId sid, bool onlyFromModels = false)
        {
            GreenSymbol symbol = null;
            if (this.group != null)
            {
                foreach (var model in this.group.Models.Values)
                {
                    if (model.Symbols.TryGetValue(sid, out symbol))
                    {
                        return new SymbolRef(model, sid, symbol, false);
                    }
                }
                if (!onlyFromModels)
                {
                    foreach (var model in this.group.References.Values)
                    {
                        if (model.Symbols.TryGetValue(sid, out symbol))
                        {
                            return new SymbolRef(model, sid, symbol, true);
                        }
                    }
                }
                return null;
            }
            else
            {
                if (this.model.Symbols.TryGetValue(sid, out symbol))
                {
                    return new SymbolRef(this.model, sid, symbol, false);
                }
            }
            return null;
        }

        private SymbolRef ResolveSymbol(ModelId mid, SymbolId sid, bool onlyFromModels = false)
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
                GreenSymbol symbol = null;
                if (model.Symbols.TryGetValue(sid, out symbol))
                {
                    return new SymbolRef(model, sid, symbol, readOnly);
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

        private GreenModel UpdateSymbol(ModelId mid, SymbolId sid, GreenSymbol symbol)
        {
            GreenModel model = this.GetModel(mid);
            Debug.Assert(model != null);
            model = model.Update(model.Name, model.Version, model.Symbols.SetItem(sid, symbol), model.StrongSymbols, model.LazyProperties, model.References);
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

        internal bool SymbolExists(SymbolId sid)
        {
            if (this.group != null)
            {
                foreach (var model in this.group.Models.Values)
                {
                    if (model.Symbols.ContainsKey(sid)) return true;
                }
                foreach (var model in this.group.References.Values)
                {
                    if (model.Symbols.ContainsKey(sid)) return true;
                }
                return false;
            }
            else
            {
                return this.model.Symbols.ContainsKey(sid);
            }
        }

        internal bool ContainsSymbol(SymbolId sid)
        {
            if (this.group != null)
            {
                foreach (var model in this.group.Models.Values)
                {
                    if (model.Symbols.ContainsKey(sid)) return true;
                }
                return false;
            }
            else
            {
                return this.model.Symbols.ContainsKey(sid);
            }
        }

        internal bool ContainsSymbol(ModelId mid, SymbolId sid)
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
            return model.Symbols.ContainsKey(sid);
        }

        internal void AddSymbol(ModelId mid, SymbolId sid, bool weak)
        {
            if (this.ContainsSymbol(sid))
            {
                if (this.group != null) this.MakeException(Location.None, ModelErrorCode.ERR_SymbolAlreadyContainedByModelGroup, sid);
                else this.MakeException(Location.None, ModelErrorCode.ERR_SymbolAlreadyContainedByModel, sid);
            }
            GreenModel model = this.GetModel(mid);
            if (model == null)
            {
                Debug.Assert(false);
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotResolveModel, mid);
            }
            if (this.group != null)
            {
                this.group = this.group.UpdateModel(model.AddSymbol(sid, weak));
            }
            else
            {
                this.model = model.AddSymbol(sid, weak);
            }
        }

        internal bool RemoveSymbol(ModelId mid, SymbolId sid)
        {
            SymbolRef symbolRef = this.ResolveSymbol(mid, sid, true);
            if (symbolRef == null) return false;
            foreach (var property in symbolRef.Symbol.Properties.Keys)
            {
                if (property.IsCollection)
                {
                    this.ClearItems(mid, sid, property, true);
                }
                else
                {
                    this.SetValue(mid, sid, property, true, null);
                }
            }
            if (this.group != null)
            {
                this.group = this.group.RemoveSymbol(sid);
            }
            else
            {
                this.model = this.model.RemoveSymbol(sid);
            }
            return true;
        }

        internal void MergeSymbols(ModelId mid, SymbolId targetSid, SymbolId partSid)
        {
            if (targetSid == partSid) return;
            SymbolRef targetSymbolRef = this.ResolveSymbol(mid, targetSid, true);
            SymbolRef partSymbolRef = this.ResolveSymbol(mid, partSid, true);
            if (targetSymbolRef == null || partSymbolRef == null) this.MakeException(Location.None, ModelErrorCode.ERR_CannotMergeSymbolsResolve, partSid, targetSid);
            GreenSymbol partSymbol = partSymbolRef.Symbol;
            foreach (var property in partSymbol.Properties.Keys)
            {
                object partValue = this.GetValue(mid, partSid, property);
                if (partValue != GreenSymbol.Unassigned)
                {
                    if (property.IsCollection)
                    {
                        GreenList partValues = partValue as GreenList;
                        if (partValues != null)
                        {
                            foreach (var item in partValues)
                            {
                                this.AddItem(mid, targetSid, property, false, false, -1, item);
                            }
                            foreach (var lazyItem in partValues.LazyItems)
                            {
                                this.AddItem(mid, targetSid, property, false, false, -1, lazyItem);
                            }
                            this.ClearItems(mid, partSid, property, true);
                        }
                    }
                    else
                    {
                        object targetValue = this.GetValue(mid, targetSid, property);
                        if (targetValue == GreenSymbol.Unassigned)
                        {
                            this.SetValue(mid, targetSid, property, false, partValue);
                        }
                        else if (targetValue != partValue)
                        {
                            this.MakeException(Location.None, ModelErrorCode.ERR_CannotMergeSymbolsProperty, partSid, targetSid, property.Name, partValue, targetValue);
                        }
                        this.SetValue(mid, partSid, property, true, null);
                    }
                }
            }
            if (this.group != null)
            {
                this.group = this.group.ReplaceSymbol(partSid, targetSid);
            }
            else
            {
                this.model = this.model.ReplaceSymbol(partSid, targetSid);
            }
        }

        internal bool AttachProperty(ModelId mid, SymbolId sid, ModelProperty property)
        {
            SymbolRef symbolRef = this.ResolveSymbol(mid, sid, true);
            Debug.Assert(symbolRef != null);
            GreenSymbol symbol = symbolRef.Symbol;
            if (symbol.Properties.ContainsKey(property)) return false;
            this.UpdateSymbol(mid, sid, symbol.Update(symbol.Parent, symbol.Children, symbol.Properties.Add(property, GreenSymbol.Unassigned)));
            return true;
        }

        internal ImmutableList<SymbolId> GetChildren(ModelId mid, SymbolId sid)
        {
            SymbolRef symbolRef = this.ResolveSymbol(mid, sid, true);
            Debug.Assert(symbolRef != null);
            if (symbolRef != null)
            {
                GreenSymbol symbol = symbolRef.Symbol;
                GreenModel model = symbolRef.Model;
                ImmutableHashSet<ModelProperty> lazyProperties;
                if (model.LazyProperties.TryGetValue(sid, out lazyProperties) && lazyProperties.Count > 0)
                {
                    foreach (var property in lazyProperties)
                    {
                        if (property.IsContainment)
                        {
                            this.GetValue(mid, sid, property, true);
                        }
                    }
                    symbolRef = this.ResolveSymbol(mid, sid, true);
                }
            }
            return symbolRef.Symbol.Children;
        }

        internal bool TryGetValue(ModelId mid, SymbolId sid, ModelProperty property, out object value)
        {
            property = this.GetRepresentingProperty(sid, property);
            if (this.TryGetValueCore(mid, sid, property, false, false, out value))
            {
                return true;
            }
            return false;
        }

        internal bool HasValue(ModelId mid, SymbolId sid, ModelProperty property)
        {
            property = this.GetRepresentingProperty(sid, property);
            object value;
            return this.TryGetValueCore(mid, sid, property, false, false, out value);
        }

        internal object GetValue(ModelId mid, SymbolId sid, ModelProperty property)
        {
            property = this.GetRepresentingProperty(sid, property);
            object value;
            if (this.TryGetValueCore(mid, sid, property, false, false, out value))
            {
                return value;
            }
            return null;
        }

        internal object GetValue(ModelId mid, SymbolId sid, ModelProperty property, bool lazyEval)
        {
            if (lazyEval)
            {
                SymbolRef symbolRef = this.ResolveSymbol(mid, sid, true);
                if (symbolRef != null)
                {
                    GreenSymbol symbol = symbolRef.Symbol;
                    GreenModel model = symbolRef.Model;
                    ImmutableHashSet<ModelProperty> lazyProperties;
                    if (model.LazyProperties.TryGetValue(sid, out lazyProperties) && lazyProperties.Count > 0)
                    {
                        ModelSymbolInfo symbolInfo = sid.SymbolInfo;
                        if (symbolInfo != null)
                        {
                            ModelPropertyInfo propertyInfo = symbolInfo.GetPropertyInfo(property);
                            if (propertyInfo != null)
                            {
                                if (propertyInfo.RepresentingProperty != null) property = propertyInfo.RepresentingProperty;
                                if (lazyProperties.Contains(property))
                                {
                                    this.LazyEvalCore(mid, sid, property);
                                }
                                foreach (var supersetProp in propertyInfo.SubsetProperties)
                                {
                                    if (lazyProperties.Contains(supersetProp))
                                    {
                                        this.LazyEvalCore(mid, sid, supersetProp);
                                    }
                                }
                            }
                            else
                            {
                                if (lazyProperties.Contains(property))
                                {
                                    this.LazyEvalCore(mid, sid, property);
                                }
                            }
                        }
                    }
                }
            }
            return this.GetValue(mid, sid, property);
        }

        internal void SetValue(ModelId mid, SymbolId sid, ModelProperty property, bool reassign, object value)
        {
            Debug.Assert(!property.IsCollection);
            if (value is SymbolId)
            {
                if (!this.SymbolExists((SymbolId)value))
                {
                    if (this.group != null) this.MakeException(Location.None, ModelErrorCode.ERR_SymbolCannotBeAssignedToPropertyModelGroup, value, property, sid);
                    else this.MakeException(Location.None, ModelErrorCode.ERR_SymbolCannotBeAssignedToPropertyModel, value, property, sid);
                }
            }
            SymbolRef symbolRef = this.ResolveSymbol(mid, sid, true);
            Debug.Assert(symbolRef != null);
            GreenSymbol symbol = symbolRef.Symbol;
            property = this.GetRepresentingProperty(sid, property);
            object oldValue;
            if (symbol.Properties.TryGetValue(property, out oldValue) && value != oldValue)
            {
                if (!sid.SymbolInfo.HasAffectedProperties(property) || value is LazyValue || value is GreenDerivedValue)
                {
                    this.SetValueCore(symbolRef, property, reassign, value);
                    this.UpdateModel(symbolRef.Model);
                }
                else
                {
                    this.SlowRemoveValueCore(mid, sid, property, true, reassign, -1, false, oldValue, null, null);
                    this.SlowAddValueCore(mid, sid, property, reassign, -1, value, null, null);
                }
            }
        }

        internal bool AddItem(ModelId mid, SymbolId sid, ModelProperty property, bool reassign, bool replace, int index, object value)
        {
            Debug.Assert(property.IsCollection);
            if (value is SymbolId)
            {
                if (!this.SymbolExists((SymbolId)value))
                {
                    if (this.group != null) this.MakeException(Location.None, ModelErrorCode.ERR_SymbolCannotBeAddedToPropertyModelGroup, value, property, sid);
                    else this.MakeException(Location.None, ModelErrorCode.ERR_SymbolCannotBeAddedToPropertyModel, value, property, sid);
                }
            }
            SymbolRef symbolRef = this.ResolveSymbol(mid, sid, true);
            Debug.Assert(symbolRef != null);
            GreenSymbol symbol = symbolRef.Symbol;
            property = this.GetRepresentingProperty(sid, property);
            bool changed = false;
            if (symbol.Properties.ContainsKey(property))
            {
                if (!sid.SymbolInfo.HasAffectedProperties(property) || value is LazyValue || value is GreenDerivedValue)
                {
                    object oldValue = null;
                    if (replace && index >= 0) changed = this.RemoveItemCore(symbolRef, property, true, reassign, index, false, ref oldValue) || changed;
                    changed = this.AddItemCore(symbolRef, property, reassign, index, value) || changed;
                    this.UpdateModel(symbolRef.Model);
                }
                else
                {
                    if (replace && index >= 0) changed = this.SlowRemoveValueCore(mid, sid, property, true, reassign, index, false, null, null, null) || changed;
                    changed = this.SlowAddValueCore(mid, sid, property, reassign, index, value, null, null) || changed;
                }
            }
            return changed;
        }

        internal bool RemoveItem(ModelId mid, SymbolId sid, ModelProperty property, bool reassign, int index, bool removeAll, object value)
        {
            Debug.Assert(property.IsCollection);
            SymbolRef symbolRef = this.ResolveSymbol(mid, sid, true);
            Debug.Assert(symbolRef != null);
            GreenSymbol symbol = symbolRef.Symbol;
            property = this.GetRepresentingProperty(sid, property);
            bool changed = false;
            if (symbol.Properties.ContainsKey(property))
            {
                if (!sid.SymbolInfo.HasAffectedProperties(property) || value is LazyValue || value is GreenDerivedValue)
                {
                    changed = this.RemoveItemCore(symbolRef, property, true, reassign, index, removeAll, ref value) || changed;
                    this.UpdateModel(symbolRef.Model);
                }
                else
                {
                    changed = this.SlowRemoveValueCore(mid, sid, property, true, reassign, index, removeAll, value, null, null) || changed;
                }
            }
            return changed;
        }

        internal bool ClearItems(ModelId mid, SymbolId sid, ModelProperty property, bool reassign)
        {
            Debug.Assert(property.IsCollection);
            property = this.GetRepresentingProperty(sid, property);
            object listValue;
            bool changed = false;
            if (this.TryGetValueCore(mid, sid, property, false, false, out listValue) && (listValue is GreenList))
            {
                GreenList list = (GreenList)listValue;
                changed = list.Count > 0 || list.HasLazyItems;
                if (property.IsSymbol || sid.SymbolInfo.HasAffectedProperties(property))
                {
                    this.ClearLazyItems(mid, sid, property, reassign);
                    foreach (var value in list)
                    {
                        this.RemoveItem(mid, sid, property, reassign, -1, true, value);
                    }
                }
                else
                {
                    SymbolRef symbolRef = this.ResolveSymbol(mid, sid, true);
                    Debug.Assert(symbolRef != null);
                    GreenModel oldModel = symbolRef.Model;
                    ImmutableHashSet<ModelProperty> oldLazyProperties;
                    bool hasLazy = oldModel.LazyProperties.TryGetValue(sid, out oldLazyProperties) && oldLazyProperties.Contains(property);
                    var newLazyModelProperties = oldModel.LazyProperties;
                    if (hasLazy)
                    {
                        var newLazyProperties = oldLazyProperties.Remove(property);
                        if (newLazyProperties.Count > 0)
                        {
                            newLazyModelProperties = newLazyModelProperties.SetItem(sid, newLazyProperties);
                        }
                        else
                        {
                            newLazyModelProperties = newLazyModelProperties.Remove(sid);
                        }
                    }
                    GreenSymbol oldSymbol = symbolRef.Symbol;
                    GreenSymbol newSymbol =
                        oldSymbol.Update(
                            oldSymbol.Parent,
                            oldSymbol.Children,
                            oldSymbol.Properties.SetItem(property, hasLazy ? list.ClearLazy().Clear() : list.Clear()));
                    GreenModel newModel =
                        oldModel.Update(
                            oldModel.Name,
                            oldModel.Version,
                            oldModel.Symbols.SetItem(sid, newSymbol),
                            oldModel.StrongSymbols,
                            newLazyModelProperties,
                            oldModel.References);
                    this.UpdateModel(newModel);
                }
            }
            return changed;
        }

        internal bool ClearLazyItems(ModelId mid, SymbolId sid, ModelProperty property, bool reassign)
        {
            Debug.Assert(property.IsCollection);
            SymbolRef symbolRef = this.ResolveSymbol(mid, sid, true);
            Debug.Assert(symbolRef != null);
            property = this.GetRepresentingProperty(sid, property);
            bool changed = this.ClearLazyItemsCore(symbolRef, property, reassign);
            this.UpdateModel(symbolRef.Model);
            return changed;
        }

        internal bool EvaluateLazyValues(ModelId mid, SymbolId sid, CancellationToken cancellationToken)
        {
            SymbolRef symbolRef = this.ResolveSymbol(mid, sid, true);
            Debug.Assert(symbolRef != null);
            GreenModel model = symbolRef.Model;
            ImmutableHashSet<ModelProperty> properties;
            int counter = 0;
            bool changed = true;
            bool evaluatedAny = true;
            while (evaluatedAny)
            {
                cancellationToken.ThrowIfCancellationRequested();
                evaluatedAny = false;
                if (model.LazyProperties.TryGetValue(sid, out properties))
                {
                    changed = properties.Count > 0;
                    var propList = symbolRef.Id.SymbolInfo.Properties;
                    foreach (var prop in propList)
                    {
                        if (properties.Contains(prop))
                        {
                            properties = properties.Remove(prop);
                            this.GetValue(mid, sid, prop, true);
                            evaluatedAny = true;
                        }
                    }
                    foreach (var prop in properties)
                    {
                        this.GetValue(mid, sid, prop, true);
                    }
                    if (evaluatedAny)
                    {
                        changed = true;
                    }
                    symbolRef = this.ResolveSymbol(mid, sid, true);
                    model = symbolRef.Model;
                    ++counter;
                    if (counter >= 100) break; // exit after 100 iterations to prevent infinite loop
                }
            }
            Debug.Assert(!model.LazyProperties.ContainsKey(sid));
            return changed;
        }

        internal bool EvaluateLazyValues(ModelId mid, CancellationToken cancellationToken)
        {
            GreenModel model = this.GetModel(mid);
            if (model == null) return false;
            if (model.LazyProperties.Count == 0) return false;
            int counter = 0;
            bool changed = true;
            bool evaluatedAny = true;
            while (evaluatedAny)
            {
                cancellationToken.ThrowIfCancellationRequested();
                evaluatedAny = false;
                foreach (var sid in model.StrongSymbols)
                {
                    if (model.LazyProperties.ContainsKey(sid))
                    {
                        evaluatedAny = this.EvaluateLazyValues(mid, sid, cancellationToken) || evaluatedAny;
                    }
                }
                model = this.GetModel(mid);
                foreach (var sid in model.LazyProperties.Keys)
                {
                    evaluatedAny = this.EvaluateLazyValues(mid, sid, cancellationToken) || evaluatedAny;
                }
                if (evaluatedAny)
                {
                    changed = true;
                }
                model = this.GetModel(mid);
                ++counter;
                if (counter >= 100) break; // exit after 100 iterations to prevent infinite loop
            }
            Debug.Assert(model.LazyProperties.Count == 0);
            return changed;
        }

        internal bool EvaluateLazyValues(CancellationToken cancellationToken)
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

        private ModelProperty GetRepresentingProperty(SymbolId symbolId, ModelProperty property)
        {
            ModelProperty result = property;
            ModelSymbolInfo symbolInfo = symbolId.SymbolInfo;
            if (symbolInfo != null)
            {
                ModelPropertyInfo propInfo = symbolInfo.GetPropertyInfo(property);
                if (propInfo != null) result = propInfo.RepresentingProperty;
                if (result == null) result = property;
            }
            return result;
        }

        private bool TryGetValueCore(SymbolRef symbolRef, ModelProperty property, bool returnUnassignedValue, bool returnLazyValue, out object value)
        {
            GreenSymbol symbol = symbolRef.Symbol;
            if (symbol.Properties.TryGetValue(property, out value))
            {
                if (value != GreenSymbol.Unassigned)
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

        private bool TryGetValueCore(ModelId mid, SymbolId sid, ModelProperty property, bool returnUnassignedValue, bool returnLazyValue, out object value)
        {
            value = null;
            SymbolRef symbolRef = this.ResolveSymbol(mid, sid, false);
            if (symbolRef == null) return false;
            GreenSymbol symbol = symbolRef.Symbol;
            if (symbol == null) return false;
            if (symbol.Properties.TryGetValue(property, out value))
            {
                if (value != GreenSymbol.Unassigned)
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

        private bool CheckOldValue(SymbolRef symbolRef, ModelProperty property, bool reassign, object oldValue)
        {
            if (!reassign)
            {
                if (property.IsDerived && oldValue != GreenSymbol.Unassigned)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotReassignDerivedProperty, property, symbolRef.Id);
                    return false;
                }
                if (property.IsReadonly && oldValue != GreenSymbol.Unassigned)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotReassignReadOnlyProperty, property, symbolRef.Id);
                    return false;
                }
                if (oldValue is LazyValue)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotReassignLazyValuedProperty, property, symbolRef.Id);
                    return false;
                }
            }
            return true;
        }

        private bool CheckNewValue(SymbolRef symbolRef, ModelProperty property, ref object value)
        {
            if (value == null && property.IsNonNull)
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignNullToProperty, property, symbolRef.Id);
                value = null;
                return false;
            }
            if (value == null || value == GreenSymbol.Unassigned || (value is LazyValue) || (value is GreenDerivedValue))
            {
                return true;
            }
            if ((value is SymbolId) && !property.MutableTypeInfo.Type.IsAssignableFrom(((SymbolId)value).SymbolInfo.MutableType))
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignValueToProperty, value, ((SymbolId)value).SymbolInfo.MutableType, property, property.MutableTypeInfo.Type, symbolRef.Id);
                value = null;
                return false;
            }
            if (!(value is SymbolId) && !property.MutableTypeInfo.Type.IsAssignableFrom(value.GetType()))
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignValueToProperty, value, value.GetType(), property, property.MutableTypeInfo.Type, symbolRef.Id);
                value = null;
                return false;
            }
            return true;
        }

        private bool CheckOldItem(SymbolRef symbolRef, ModelProperty property, bool reassign)
        {
            if (!reassign)
            {
                if (property.IsDerived)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeDerivedProperty, property, symbolRef.Id);
                    return false;
                }
                if (property.IsReadonly)
                {
                    this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeReadOnlyProperty, property, symbolRef.Id);
                    return false;
                }
            }
            return true;
        }

        private bool CheckNewItem(SymbolRef symbolRef, ModelProperty property, ref object value)
        {
            if (value == null && property.IsNonNull)
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddNullToProperty, property, symbolRef.Id);
                value = null;
                return false;
            }
            if (value == null || value == GreenSymbol.Unassigned || (value is LazyValue) || (value is GreenDerivedValue))
            {
                return true;
            }
            if ((value is SymbolId) && !property.MutableTypeInfo.Type.IsAssignableFrom(((SymbolId)value).SymbolInfo.MutableType))
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddValueToProperty, value, ((SymbolId)value).SymbolInfo.MutableType, property, property.MutableTypeInfo.Type, symbolRef.Id);
                value = null;
                return false;
            }
            if (!(value is SymbolId) && !property.MutableTypeInfo.Type.IsAssignableFrom(value.GetType()))
            {
                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddValueToProperty, value, value.GetType(), property, property.MutableTypeInfo.Type, symbolRef.Id);
                value = null;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Sets the value of a single valued property. Updates references and lazy property index. This method does not update any related properties.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="symbolRef"></param>
        /// <param name="property"></param>
        /// <param name="reassign"></param>
        /// <param name="value"></param>
        /// <param name="oldValue"></param>
        /// <returns></returns>
        private bool SetValueCore(SymbolRef symbolRef, ModelProperty property, bool reassign, object value)
        {
            Debug.Assert(symbolRef.Symbol.Properties.ContainsKey(property));
            object oldValue;
            if (!this.TryGetValueCore(symbolRef, property, true, true, out oldValue)) return false;
            if (value == oldValue) return false;
            if (!this.CheckOldValue(symbolRef, property, reassign, oldValue)) return false;
            this.CheckNewValue(symbolRef, property, ref value);
            if (oldValue != null && oldValue != GreenSymbol.Unassigned)
            {
                if (oldValue is SymbolId)
                {
                    this.RemoveReferenceCore(symbolRef, property, (SymbolId)oldValue);
                }
                else if ((oldValue is LazyValue) && !(value is LazyValue))
                {
                    this.RemoveLazyPropertyCore(symbolRef, property);
                }
            }
            if (value != null && value != GreenSymbol.Unassigned)
            {
                if (value is SymbolId)
                {
                    this.AddReferenceCore(symbolRef, property, (SymbolId)value);
                }
                else if ((value is LazyValue) && !(oldValue is LazyValue))
                {
                    this.AddLazyPropertyCore(symbolRef, property);
                }
            }
            GreenSymbol symbol = symbolRef.Symbol;
            symbol = symbol.Update(symbol.Parent, symbol.Children, symbol.Properties.SetItem(property, value));
            symbolRef.Update(symbol);
            return true;
        }

        /// <summary>
        /// Adds an item to a collection property. Updates references and lazy property index. This method does not update any related properties.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="symbolRef"></param>
        /// <param name="property"></param>
        /// <param name="reassign"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool AddItemCore(SymbolRef symbolRef, ModelProperty property, bool reassign, int index, object value)
        {
            Debug.Assert(symbolRef.Symbol.Properties.ContainsKey(property));
            if (!this.CheckOldItem(symbolRef, property, reassign)) return false;
            this.CheckNewItem(symbolRef, property, ref value);
            GreenList list;
            object listValue;
            if (!this.TryGetValueCore(symbolRef, property, false, false, out listValue) || !(listValue is GreenList))
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
                this.AddLazyPropertyCore(symbolRef, property);
            }
            else
            {
                bool newReference = value is SymbolId && !list.Contains(value);
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
                    this.AddReferenceCore(symbolRef, property, (SymbolId)value);
                }
            }
            GreenSymbol symbol = symbolRef.Symbol;
            symbol = symbol.Update(symbol.Parent, symbol.Children, symbol.Properties.SetItem(property, list));
            symbolRef.Update(symbol);
            return list != oldList;
        }

        /// <summary>
        /// Removes an item from a collection property. Updates references and lazy property index. This method does not update any related properties.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="symbolRef"></param>
        /// <param name="property"></param>
        /// <param name="forceRemove"></param>
        /// <param name="reassign"></param>
        /// <param name="index"></param>
        /// <param name="removeAll"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool RemoveItemCore(SymbolRef symbolRef, ModelProperty property, bool forceRemove, bool reassign, int index, bool removeAll, ref object value)
        {
            Debug.Assert(symbolRef.Symbol.Properties.ContainsKey(property));
            if (!this.CheckOldItem(symbolRef, property, reassign)) return false;
            GreenList list;
            object listValue;
            if (this.TryGetValueCore(symbolRef, property, false, false, out listValue))
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
                ModelSymbolInfo symbolInfo = symbolRef.Id.SymbolInfo;
                if (symbolInfo != null)
                {
                    ModelPropertyInfo propInfo = symbolInfo.GetPropertyInfo(property);
                    if (propInfo != null && propInfo.SubsettingProperties.Count > 0)
                    {
                        ImmutableDictionary<ModelProperty, object> properties = symbolRef.Symbol.Properties;
                        foreach (var subsetProp in propInfo.SubsettingProperties)
                        {
                            ModelProperty representingSubsetProp = subsetProp;
                            ModelPropertyInfo subsetPropInfo = symbolInfo.GetPropertyInfo(subsetProp);
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
            if (value is SymbolId)
            {
                if (removedAll)
                {
                    this.RemoveReferenceCore(symbolRef, property, (SymbolId)value);
                }
            }
            GreenSymbol symbol = symbolRef.Symbol;
            symbol = symbol.Update(symbol.Parent, symbol.Children, symbol.Properties.SetItem(property, list));
            symbolRef.Update(symbol);
            return oldList != list || removedAll;
        }

        /// <summary>
        /// Adds an item to a property. Updates all the related properties.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="symbolRef"></param>
        /// <param name="property"></param>
        /// <param name="reassign"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <param name="valueAddedToSelf"></param>
        /// <param name="valueAddedToOpposite"></param>
        private bool SlowAddValueCore(ModelId mid, SymbolId sid, ModelProperty property, bool reassign, int index, object value, HashSet<ModelProperty> valueAddedToSelf, HashSet<ModelProperty> valueAddedToOpposite)
        {
            if (valueAddedToSelf != null && valueAddedToSelf.Contains(property)) return false;
            ModelSymbolInfo info = sid.SymbolInfo;
            if (info == null) return false;
            ModelPropertyInfo propertyInfo = info.GetPropertyInfo(property);
            if (propertyInfo == null) return false;
            SymbolRef symbolRef = this.ResolveSymbol(sid, true);
            if (symbolRef == null) return false;
            SymbolId valueId = value as SymbolId;
            // Checking the value:
            if (!reassign)
            {
                foreach (var eqProp in propertyInfo.EquivalentProperties)
                {
                    if (eqProp.IsDerived)
                    {
                        this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeDerivedProperty, eqProp, sid);
                    }
                    if (eqProp.IsReadonly)
                    {
                        this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeReadOnlyProperty, eqProp, sid);
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
                            this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddNullToProperty, eqProp, sid);
                        }
                        else
                        {
                            this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignNullToProperty, eqProp, sid);
                        }
                    }
                }
            }
            else if (value != GreenSymbol.Unassigned)
            {
                if (valueId != null)
                {
                    foreach (var eqProp in propertyInfo.EquivalentProperties)
                    {
                        if (!eqProp.MutableTypeInfo.Type.IsAssignableFrom(valueId.SymbolInfo.MutableType))
                        {
                            if (eqProp.IsCollection)
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddValueToProperty, value, valueId.SymbolInfo.MutableType, eqProp, eqProp.MutableTypeInfo.Type, sid);
                            }
                            else
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignValueToProperty, value, valueId.SymbolInfo.MutableType, eqProp, eqProp.MutableTypeInfo.Type, sid);
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
                                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAddValueToProperty, value, valueType, eqProp, eqProp.MutableTypeInfo.Type, sid);
                            }
                            else
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_CannotAssignValueToProperty, value, valueType, eqProp, eqProp.MutableTypeInfo.Type, sid);
                            }
                        }
                    }
                }
            }
            // Setting the value:
            bool valueAdded = false;
            if (property.IsCollection)
            {
                valueAdded = this.AddItemCore(symbolRef, property, reassign, index, value);
            }
            else
            {
                valueAdded = this.SetValueCore(symbolRef, property, reassign, value);
            }
            if (valueAdded)
            {
                this.UpdateModel(symbolRef.Model);
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
                    ModelProperty subsettedRepProp = this.GetRepresentingProperty(sid, subsettedProp);
                    this.SlowAddValueCore(mid, sid, subsettedRepProp, reassign, -1, value, valueAddedToSelf, valueAddedToOpposite);
                }
            }
            // Updating opposite properties:
            if (valueId != null && propertyInfo.OppositeProperties.Count > 0)
            {
                SymbolRef valueSymbolRef = this.ResolveSymbol(valueId, true);
                if (valueSymbolRef != null)
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
                    }
                    foreach (var oppositeProp in propertyInfo.OppositeProperties)
                    {
                        ModelProperty oppositeRepProp = this.GetRepresentingProperty(valueId, oppositeProp);
                        if (!valueAddedToOpposite.Contains(oppositeProp))
                        {
                            this.SlowAddValueCore(valueSymbolRef.Model.Id, valueId, oppositeRepProp, reassign, -1, sid, valueAddedToOpposite, valueAddedToSelf);
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
        /// <param name="symbolRef"></param>
        /// <param name="property"></param>
        /// <param name="forceRemove"></param>
        /// <param name="reassign"></param>
        /// <param name="index"></param>
        /// <param name="removeAll"></param>
        /// <param name="value"></param>
        /// <param name="valueRemovedFromSelf"></param>
        /// <param name="valueRemovedFromOpposite"></param>
        private bool SlowRemoveValueCore(ModelId mid, SymbolId sid, ModelProperty property, bool forceRemove, bool reassign, int index, bool removeAll, object value, HashSet<ModelProperty> valueRemovedFromSelf, HashSet<ModelProperty> valueRemovedFromOpposite)
        {
            if (valueRemovedFromSelf != null && valueRemovedFromSelf.Contains(property)) return false;
            ModelSymbolInfo info = sid.SymbolInfo;
            if (info == null) return false;
            ModelPropertyInfo propertyInfo = info.GetPropertyInfo(property);
            if (propertyInfo == null) return false;
            SymbolRef symbolRef = this.ResolveSymbol(sid, true);
            if (symbolRef == null) return false;
            // Checking the value:
            if (!reassign)
            {
                foreach (var eqProp in propertyInfo.EquivalentProperties)
                {
                    if (eqProp.IsDerived)
                    {
                        this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeDerivedProperty, eqProp, sid);
                    }
                    if (eqProp.IsReadonly)
                    {
                        this.MakeException(Location.None, ModelErrorCode.ERR_CannotChangeReadOnlyProperty, eqProp, sid);
                    }
                }
            }
            // Setting the value:
            bool valueRemoved = false;
            if (property.IsCollection)
            {
                valueRemoved = this.RemoveItemCore(symbolRef, property, forceRemove, reassign, index, removeAll, ref value);
            }
            else
            {
                valueRemoved = this.SetValueCore(symbolRef, property, reassign, GreenSymbol.Unassigned);
            }
            if (valueRemoved)
            {
                this.UpdateModel(symbolRef.Model);
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
                    ModelProperty subsettingRepProp = this.GetRepresentingProperty(sid, subsettingProp);
                    this.SlowRemoveValueCore(mid, sid, subsettingRepProp, true, reassign, -1, removeAll, value, valueRemovedFromSelf, valueRemovedFromOpposite);
                }
                foreach (var subsettedProp in propertyInfo.DerivedUnionProperties)
                {
                    ModelProperty subsettedRepProp = this.GetRepresentingProperty(sid, subsettedProp);
                    this.SlowRemoveValueCore(mid, sid, subsettedRepProp, false, reassign, -1, removeAll, value, valueRemovedFromSelf, valueRemovedFromOpposite);
                }
            }
            // Updating opposite properties:
            if (value is SymbolId && propertyInfo.OppositeProperties.Count > 0)
            {
                SymbolId valueId = (SymbolId)value;
                SymbolRef valueSymbolRef = this.ResolveSymbol(valueId, true);
                if (valueSymbolRef != null)
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
                        this.SlowRemoveValueCore(valueSymbolRef.Model.Id, valueId, oppositeRepProp, true, reassign, -1, removeAll, sid, valueRemovedFromOpposite, valueRemovedFromSelf);
                    }
                }
            }
            return valueRemoved;
        }

        /// <summary>
        /// Adds a reference to a symbol. 
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="symbolRef"></param>
        /// <param name="property"></param>
        /// <param name="valueSid"></param>
        private void AddReferenceCore(SymbolRef symbolRef, ModelProperty property, SymbolId valueSid)
        {
            GreenModel model = symbolRef.Model;
            ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>> references;
            if (!model.References.TryGetValue(valueSid, out references))
            {
                references = ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>.Empty;
            }
            SymbolId sid = symbolRef.Id;
            ImmutableHashSet<ModelProperty> properties;
            if (!references.TryGetValue(sid, out properties))
            {
                properties = ImmutableHashSet<ModelProperty>.Empty;
            }
            if (!properties.Contains(property))
            {
                if (property.IsContainment)
                {
                    SymbolRef valueRef = this.ResolveSymbol(valueSid, true);
                    if (valueRef != null)
                    {
                        if (valueRef.Symbol.Parent != null)
                        {
                            if (valueRef.Symbol.Parent != sid)
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_InvalidContainment, valueSid, property, sid, valueRef.Symbol.Parent);
                            }
                        }
                        else
                        {
                            if (valueSid == sid)
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_InvalidSelfContainment, valueSid, property, sid);
                            }
                            if (valueRef.Model.Id != model.Id)
                            {
                                this.MakeException(Location.None, ModelErrorCode.ERR_InvalidModelContainment, valueSid, property, sid);
                            }
                            if (symbolRef.Symbol.Parent != null)
                            {
                                List<SymbolId> ids = new List<SymbolId>();
                                ids.Add(valueSid);
                                GreenSymbol currentSymbol = symbolRef.Symbol;
                                SymbolId currentId = currentSymbol.Parent;
                                while (currentId != null)
                                {
                                    if (ids.Contains(currentId))
                                    {
                                        this.MakeException(Location.None, ModelErrorCode.ERR_CircularContainment, valueSid, property, sid);
                                    }
                                    ids.Add(currentId);
                                    if (model.Symbols.TryGetValue(currentId, out currentSymbol))
                                    {
                                        currentId = currentSymbol.Parent;
                                    }
                                    else
                                    {
                                        currentId = null;
                                    }
                                }
                            }
                            GreenSymbol symbol = symbolRef.Symbol;
                            Debug.Assert(!symbol.Children.Contains(valueSid));
                            symbolRef.Update(symbol.Update(symbol.Parent, symbol.Children.Add(valueSid), symbol.Properties));
                            GreenSymbol valueSymbol;
                            if (symbolRef.Model.Symbols.TryGetValue(valueSid, out valueSymbol))
                            {
                                valueRef.Update(symbolRef.Model, valueRef.Symbol.Update(sid, valueSymbol.Children, valueSymbol.Properties), true);
                                model = valueRef.Model;
                            }
                            else
                            {
                                Debug.Assert(false);
                            }
                        }
                    }
                }
                references = references.SetItem(sid, properties.Add(property));
                model = model.Update(model.Name, model.Version, model.Symbols, model.StrongSymbols, model.LazyProperties, model.References.SetItem(valueSid, references));
                symbolRef.Update(model, symbolRef.Symbol, false);
            }
        }

        /// <summary>
        /// Removes a reference to a symbol. 
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="symbolRef"></param>
        /// <param name="property"></param>
        /// <param name="valueSid"></param>
        private void RemoveReferenceCore(SymbolRef symbolRef, ModelProperty property, SymbolId valueSid)
        {
            GreenModel model = symbolRef.Model;
            ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>> references;
            if (!model.References.TryGetValue(valueSid, out references))
            {
                return;
            }
            SymbolId sid = symbolRef.Id;
            ImmutableHashSet<ModelProperty> properties;
            if (!references.TryGetValue(sid, out properties))
            {
                return;
            }
            if (properties.Contains(property))
            {
                properties = properties.Remove(property);
                if (properties.Count == 0) references = references.Remove(sid);
                else references = references.SetItem(sid, properties.Remove(property));
                ImmutableDictionary<SymbolId, ImmutableDictionary<SymbolId, ImmutableHashSet<ModelProperty>>> modelReferences;
                if (references.Count == 0) modelReferences = model.References.Remove(valueSid);
                else modelReferences = model.References.SetItem(valueSid, references);
                ImmutableDictionary<SymbolId, GreenSymbol> modelSymbols = model.Symbols;
                GreenSymbol symbol = symbolRef.Symbol;
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
                        GreenSymbol valueSymbol;
                        if (model.Symbols.TryGetValue(valueSid, out valueSymbol))
                        {
                            symbol = symbol.Update(symbol.Parent, symbol.Children.Remove(valueSid), symbol.Properties);
                            modelSymbols = modelSymbols.
                                SetItem(valueSid, valueSymbol.Update(null, valueSymbol.Children, valueSymbol.Properties)).
                                SetItem(sid, symbol);
                        }
                        else
                        {
                            Debug.Assert(false);
                        }
                    }
                }
                model = model.Update(model.Name, model.Version, modelSymbols, model.StrongSymbols, model.LazyProperties, modelReferences);
                symbolRef.Update(model, symbol, false);
            }
        }

        /// <summary>
        /// Adds the property to the lazy property index. 
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="symbolRef"></param>
        /// <param name="property"></param>
        /// <param name="valueSid"></param>
        private void AddLazyPropertyCore(SymbolRef symbolRef, ModelProperty property)
        {
            SymbolId sid = symbolRef.Id;
            ImmutableHashSet<ModelProperty> lazyProperties;
            GreenModel model = symbolRef.Model;
            if (!model.LazyProperties.TryGetValue(sid, out lazyProperties))
            {
                lazyProperties = ImmutableHashSet<ModelProperty>.Empty;
            }
            if (!lazyProperties.Contains(property))
            {
                lazyProperties = lazyProperties.Add(property);
                model = model.Update(model.Name, model.Version, model.Symbols, model.StrongSymbols, model.LazyProperties.SetItem(sid, lazyProperties), model.References);
                symbolRef.Update(model, symbolRef.Symbol, false);
            }
        }

        /// <summary>
        /// Removes the property from the lazy property index. 
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="symbolRef"></param>
        /// <param name="property"></param>
        /// <param name="valueSid"></param>
        private void RemoveLazyPropertyCore(SymbolRef symbolRef, ModelProperty property)
        {
            SymbolId sid = symbolRef.Id;
            ImmutableHashSet<ModelProperty> lazyProperties;
            GreenModel model = symbolRef.Model;
            if (model.LazyProperties.TryGetValue(sid, out lazyProperties))
            {
                lazyProperties = lazyProperties.Remove(property);
                if (lazyProperties.Count == 0) model = model.Update(model.Name, model.Version, model.Symbols, model.StrongSymbols, model.LazyProperties.Remove(sid), model.References);
                else model = model.Update(model.Name, model.Version, model.Symbols, model.StrongSymbols, model.LazyProperties.SetItem(sid, lazyProperties), model.References);
                symbolRef.Update(model, symbolRef.Symbol, false);
            }
        }

        /// <summary>
        /// Clears the lazy values of the property.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="symbolRef"></param>
        /// <param name="property"></param>
        /// <param name="reassign"></param>
        private bool ClearLazyItemsCore(SymbolRef symbolRef, ModelProperty property, bool reassign)
        {
            Debug.Assert(property.IsCollection);
            SymbolId sid = symbolRef.Id;
            GreenModel oldModel = symbolRef.Model;
            ImmutableHashSet<ModelProperty> oldLazyProperties;
            bool changed = false;
            if (oldModel.LazyProperties.TryGetValue(sid, out oldLazyProperties) && oldLazyProperties.Contains(property))
            {
                object listValue;
                if (this.TryGetValueCore(symbolRef, property, false, false, out listValue) && (listValue is GreenList))
                {
                    GreenList list = (GreenList)listValue;
                    GreenSymbol oldSymbol = symbolRef.Symbol;
                    GreenSymbol newSymbol = oldSymbol.Update(oldSymbol.Parent, oldSymbol.Children, oldSymbol.Properties.SetItem(property, list.ClearLazy()));
                    ImmutableHashSet<ModelProperty> newLazyProperties = oldLazyProperties.Remove(property);
                    GreenModel newModel;
                    if (newLazyProperties.Count == 0)
                    {
                        newModel =
                            oldModel.Update(
                                oldModel.Name,
                                oldModel.Version,
                                oldModel.Symbols.SetItem(sid, newSymbol),
                                oldModel.StrongSymbols,
                                oldModel.LazyProperties.Remove(sid),
                                oldModel.References);
                    }
                    else
                    {
                        newModel =
                            oldModel.Update(
                                oldModel.Name,
                                oldModel.Version,
                                oldModel.Symbols.SetItem(sid, newSymbol),
                                oldModel.StrongSymbols,
                                oldModel.LazyProperties.SetItem(sid, newLazyProperties),
                                oldModel.References);
                    }
                    symbolRef.Update(newModel, newSymbol, false);
                    changed = true;
                }
            }
            return changed;
        }

        /// <summary>
        /// Evaluates the lazy values of the property.
        /// Make sure to convert the property to its representing version before calling this method.
        /// </summary>
        /// <param name="symbolRef"></param>
        /// <param name="property"></param>
        private void LazyEvalCore(ModelId mid, SymbolId sid, ModelProperty property)
        {
            object lazyValue;
            if (this.lazyEvalStack == null) this.lazyEvalStack = new List<GreenLazyEvalEntry>();
            GreenLazyEvalEntry entry = new GreenLazyEvalEntry(sid, property);
            int entryIndex = this.lazyEvalStack.IndexOf(entry);
            if (entryIndex >= 0)
            {
                this.MakeLazyEvalException(this.lazyEvalStack, null, null, ModelErrorCode.ERR_CircularLazyEvaluation);
            }
            try
            {
                this.lazyEvalStack.Add(entry);
                if (this.TryGetValueCore(mid, sid, property, false, true, out lazyValue))
                {
                    if (lazyValue is LazyValue)
                    {
                        try
                        {
                            object value = this.LazyEvalValue((LazyValue)lazyValue);
                            this.SetValue(mid, sid, property, true, value);
                        }
                        catch (Exception ex)
                        {
                            this.MakeLazyEvalException(this.lazyEvalStack, ex, (LazyValue)lazyValue, ModelErrorCode.ERR_LazyEvaluationError, ex.Message);
                            this.SetValue(mid, sid, property, true, null);
                        }
                    }
                    else if (lazyValue is MultipleLazyValues)
                    {
                        try
                        {
                            IEnumerable<object> values = this.LazyEvalValues((MultipleLazyValues)lazyValue);
                            foreach (var value in values)
                            {
                                this.AddItem(mid, sid, property, true, false, -1, value);
                            }
                        }
                        catch (Exception ex)
                        {
                            this.MakeLazyEvalException(this.lazyEvalStack, ex, (LazyValue)lazyValue, ModelErrorCode.ERR_LazyEvaluationError, ex.Message);
                        }
                    }
                    else if (lazyValue is GreenList)
                    {
                        GreenList list = (GreenList)lazyValue;
                        if (list.HasLazyItems)
                        {
                            this.ClearLazyItems(mid, sid, property, true);
                            foreach (var lazyItem in list.LazyItems)
                            {
                                if (lazyItem.IsSingleValue)
                                {
                                    try
                                    {
                                        object value = this.LazyEvalValue(lazyItem);
                                        if (value != null)
                                        {
                                            this.AddItem(mid, sid, property, true, false, -1, value);
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
                                        IEnumerable<object> values = this.LazyEvalValues((MultipleLazyValues)lazyItem);
                                        foreach (var value in values)
                                        {
                                            if (value != null)
                                            {
                                                this.AddItem(mid, sid, property, true, false, -1, value);
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
        private object LazyEvalValue(LazyValue lazyValue)
        {
            try
            {
                return lazyValue.CreateGreenValue();
            }
            catch (LazyEvaluationException lee)
            {
                throw lee;
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
        private IEnumerable<object> LazyEvalValues(MultipleLazyValues lazyValues)
        {
            try
            {
                return lazyValues.CreateGreenValues();
            }
            catch (LazyEvaluationException lee)
            {
                throw lee;
            }
            catch (Exception ex)
            {
                this.MakeLazyEvalException(this.lazyEvalStack, ex, lazyValues, ModelErrorCode.ERR_LazyEvaluationError, ex.ToString());
            }
            return SpecializedCollections.EmptyEnumerable<object>();
        }

        public void PurgeWeakSymbols()
        {
            if (this.group != null)
            {
                var strongSymbols = this.CollectStrongSymbols();
                this.group = this.group.PurgeWeakSymbols(strongSymbols);
            }
            else
            {
                if (this.model.StrongSymbols.Count < this.model.Symbols.Count)
                {
                    var strongSymbols = this.CollectStrongSymbols();
                    this.model = this.model.PurgeWeakSymbols(strongSymbols);
                }
            }
        }

        private HashSet<SymbolId> CollectStrongSymbols()
        {
            var result = new HashSet<SymbolId>();
            if (this.group != null)
            {
                foreach (var model in this.group.Models.Values)
                {
                    result.UnionWith(model.StrongSymbols);
                }
                bool repeat = true;
                while (repeat)
                {
                    repeat = false;
                    foreach (var model in this.group.Models.Values)
                    {
                        if (model.StrongSymbols.Count < model.Symbols.Count)
                        {
                            repeat = this.CollectStrongSymbols(result, model);
                        }
                    }
                }
            }
            else
            {
                result.UnionWith(this.model.StrongSymbols);
                if (this.model.StrongSymbols.Count < this.model.Symbols.Count)
                {
                    this.CollectStrongSymbols(result, this.model);
                }
            }
            return result;
        }

        private bool CollectStrongSymbols(HashSet<SymbolId> strongSymbols, GreenModel model)
        {
            Debug.Assert(model.LazyProperties.IsEmpty);
            Debug.Assert(model.StrongSymbols.Count < model.Symbols.Count);
            bool result = false;
            bool repeat = true;
            while (repeat)
            {
                repeat = false;
                foreach (var refs in model.References)
                {
                    if (strongSymbols.Contains(refs.Key)) continue;
                    foreach (var refSymbolId in refs.Value.Keys)
                    {
                        if (strongSymbols.Contains(refSymbolId))
                        {
                            repeat = true;
                            result = true;
                            strongSymbols.Add(refs.Key);
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

        private class SymbolRef
        {
            private GreenModel model;
            private SymbolId id;
            private GreenSymbol symbol;
            private bool isReadonly;

            public SymbolRef(GreenModel model, SymbolId id, GreenSymbol symbol, bool isReadonly)
            {
                this.model = model;
                this.id = id;
                this.symbol = symbol;
                this.isReadonly = isReadonly;
            }

            public GreenModel Model { get { return this.model; } }
            public SymbolId Id { get { return this.id; } }
            public GreenSymbol Symbol { get { return this.symbol; } }
            public bool IsReadonly { get { return this.isReadonly; } }

            public void Update(GreenModel model, GreenSymbol symbol, bool addSymbolToModel)
            {
                if (addSymbolToModel) this.model = model.Update(model.Name, model.Version, model.Symbols.SetItem(this.id, symbol), model.StrongSymbols, model.LazyProperties, model.References);
                else this.model = model;
                this.symbol = symbol;
            }

            public void Update(GreenSymbol symbol)
            {
                this.model = model.Update(model.Name, model.Version, model.Symbols.SetItem(this.id, symbol), model.StrongSymbols, model.LazyProperties, model.References);
                this.symbol = symbol;
            }
        }
    }

}
