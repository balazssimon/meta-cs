using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal class ComplexSlotBuilder
    {
        private ModelProperty effectiveProperty;
        private ModelPropertyFlags flags;
        private Dictionary<ModelProperty, ComplexSlotBuilder> map;
        private ArrayBuilder<ModelProperty> equivalentProperties;
        private ArrayBuilder<ComplexSlotBuilder> supersetSlots;
        private ArrayBuilder<ComplexSlotBuilder> subsetSlots;
        private ArrayBuilder<ModelProperty> subsettedProperties;
        private ArrayBuilder<ModelProperty> subsettingProperties;
        private ArrayBuilder<ModelProperty> derivedUnionProperties;
        private ArrayBuilder<ModelProperty> oppositeProperties;

        public static ImmutableDictionary<ModelProperty, Slot> Build(ImmutableArray<ModelProperty> properties)
        {
            var effectiveProperties = ArrayBuilder<ModelProperty>.GetInstance();
            foreach (var prop in properties)
            {
                int nameIndex = effectiveProperties.FindIndex(p => p.Name == prop.Name);
                if (nameIndex >= 0) effectiveProperties.RemoveAt(nameIndex);
                foreach (var redefProp in prop.RedefinedProperties)
                {
                    int index = effectiveProperties.IndexOf(redefProp);
                    if (index >= 0) effectiveProperties.RemoveAt(index);
                }
                effectiveProperties.Add(prop);
            }
            var eqMap = new Dictionary<ModelProperty, ComplexSlotBuilder>();
            foreach (var prop in properties)
            {
                if (prop.RedefinedProperties.Length > 0)
                {
                    var slot = CreateComplexSlot(eqMap, prop);
                    slot.AddRedefinedProperty(prop, true);
                    foreach (var redefinedProp in prop.RedefinedProperties)
                    {
                        slot.AddRedefinedProperty(redefinedProp, true);
                    }
                }
            }
            var map = new Dictionary<ModelProperty, ComplexSlotBuilder>();
            foreach (var entry in eqMap)
            {
                var slot = GetComplexSlot(map, entry.Key);
                if (slot == null)
                {
                    slot = entry.Value;
                    slot.effectiveProperty = null;
                    foreach (var eqProp in entry.Value.equivalentProperties)
                    {
                        map.Add(eqProp, slot);
                        slot.flags = AddFlag(ModelPropertyFlags.ModelObject, slot.flags, eqProp.Flags);
                        slot.flags = RemoveFlag(ModelPropertyFlags.Collection, slot.flags, eqProp.Flags);
                        slot.flags = AddFlag(ModelPropertyFlags.Readonly, slot.flags, eqProp.Flags);
                        slot.flags = AddFlag(ModelPropertyFlags.Derived, slot.flags, eqProp.Flags);
                        slot.flags = AddFlag(ModelPropertyFlags.DerivedUnion, slot.flags, eqProp.Flags);
                        slot.flags = RemoveFlag(ModelPropertyFlags.NonUnique, slot.flags, eqProp.Flags);
                        slot.flags = AddFlag(ModelPropertyFlags.Ordered, slot.flags, eqProp.Flags);
                        slot.flags = AddFlag(ModelPropertyFlags.NonNull, slot.flags, eqProp.Flags);
                        slot.flags = AddFlag(ModelPropertyFlags.Containment, slot.flags, eqProp.Flags);
                        if (!slot.flags.HasFlag(ModelPropertyFlags.Collection)) slot.flags = slot.flags & ~ModelPropertyFlags.NonUnique;
                        if (effectiveProperties.Contains(eqProp))
                        {
                            Debug.Assert(slot.effectiveProperty == null);
                            slot.effectiveProperty = eqProp;
                        }
                    }
                    Debug.Assert(slot.effectiveProperty != null);
                }
            }
            effectiveProperties.Free();
            foreach (var prop in properties)
            {
                if (prop.SubsettedProperties.Length > 0)
                {
                    var slot = CreateComplexSlot(map, prop);
                    foreach (var subsettedProp in prop.SubsettedProperties)
                    {
                        var subsettedSlot = CreateComplexSlot(map, subsettedProp);
                        slot.AddSubsettedProperty(subsettedProp, true);
                        subsettedSlot.AddSubsettingProperty(prop, true);
                        if (subsettedProp.IsDerivedUnion)
                        {
                            slot.AddDerivedUnionProperty(subsettedProp, true);
                        }
                    }
                }
                if (prop.OppositeProperties.Length > 0)
                {
                    var slot = CreateComplexSlot(map, prop);
                    foreach (var oppositeProp in prop.OppositeProperties)
                    {
                        slot.AddOppositeProperty(oppositeProp, true);
                    }
                }
            }
            foreach (var prop in properties)
            {
                var slot = GetComplexSlot(map, prop);
                if (slot != null && slot.subsettedProperties.Count > 0)
                {
                    var visited = slot.supersetSlots;
                    visited.Add(slot);
                    int i = 0;
                    while (i < visited.Count)
                    {
                        var currentSlot = visited[i];
                        foreach (var subsettedProp in currentSlot.subsettedProperties)
                        {
                            var subsettedSlot = GetComplexSlot(map, subsettedProp);
                            if (subsettedSlot != null)
                            {
                                if (!visited.Contains(subsettedSlot))
                                {
                                    visited.Add(subsettedSlot);
                                    slot.flags = AddFlag(ModelPropertyFlags.ModelObject, slot.flags, subsettedSlot.flags);
                                    slot.flags = RemoveFlag(ModelPropertyFlags.Collection, slot.flags, subsettedSlot.flags);
                                    slot.flags = RemoveFlag(ModelPropertyFlags.NonUnique, slot.flags, subsettedSlot.flags);
                                    slot.flags = AddFlag(ModelPropertyFlags.Ordered, slot.flags, subsettedSlot.flags);
                                    slot.flags = AddFlag(ModelPropertyFlags.NonNull, slot.flags, subsettedSlot.flags);
                                    slot.flags = AddFlag(ModelPropertyFlags.Containment, slot.flags, subsettedSlot.flags);
                                    if (!slot.flags.HasFlag(ModelPropertyFlags.Collection)) slot.flags = slot.flags & ~ModelPropertyFlags.NonUnique;
                                }
                            }
                        }
                        ++i;
                    }
                    visited.RemoveAt(0);
                }
                if (slot != null && slot.subsettingProperties.Count > 0)
                {
                    var visited = slot.subsetSlots;
                    visited.Add(slot);
                    int i = 0;
                    while (i < visited.Count)
                    {
                        var currentSlot = visited[i];
                        foreach (var subsettingProp in currentSlot.subsettingProperties)
                        {
                            var subsettingSlot = GetComplexSlot(map, subsettingProp);
                            if (subsettingSlot != null)
                            {
                                if (!visited.Contains(subsettingSlot))
                                {
                                    visited.Add(subsettingSlot);
                                }
                            }
                        }
                        ++i;
                    }
                    visited.RemoveAt(0);
                }
            }
            var imap = new Dictionary<ComplexSlotBuilder, ComplexSlot>();
            var result = ImmutableDictionary.CreateBuilder<ModelProperty, Slot>();
            foreach (var slotBuilder in map.Values.Distinct())
            {
                imap.Add(slotBuilder, new ComplexSlot(slotBuilder.flags, slotBuilder.effectiveProperty));
            }
            foreach (var entry in map)
            {
                result.Add(entry.Key, entry.Value.ToImmutable(map, imap));
            }
            foreach (var slot in eqMap.Values)
            {
                slot.Free();
            }
            foreach (var prop in properties)
            {
                if (!result.ContainsKey(prop))
                {
                    result.Add(prop, prop);
                }
            }
            return result.ToImmutable();
        }

        private ComplexSlotBuilder(Dictionary<ModelProperty, ComplexSlotBuilder> map)
        {
            this.map = map;
            this.equivalentProperties = ArrayBuilder<ModelProperty>.GetInstance();
            this.supersetSlots = ArrayBuilder<ComplexSlotBuilder>.GetInstance();
            this.subsetSlots = ArrayBuilder<ComplexSlotBuilder>.GetInstance();
            this.subsettedProperties = ArrayBuilder<ModelProperty>.GetInstance();
            this.subsettingProperties = ArrayBuilder<ModelProperty>.GetInstance();
            this.derivedUnionProperties = ArrayBuilder<ModelProperty>.GetInstance();
            this.oppositeProperties = ArrayBuilder<ModelProperty>.GetInstance();
        }

        private ComplexSlot ToImmutable(Dictionary<ModelProperty, ComplexSlotBuilder> map, Dictionary<ComplexSlotBuilder, ComplexSlot> imap)
        {
            var equivalentProperties = this.equivalentProperties.ToImmutable();
            var supersetSlots = this.supersetSlots.Select(s => (Slot)imap[s]).ToImmutableArray();
            var subsetSlots = this.subsetSlots.Select(s => (Slot)imap[s]).ToImmutableArray();
            var subsettedSlots = this.subsettedProperties.Select(p => GetSlot(p, map, imap)).ToImmutableArray();
            var subsettingSlots = this.subsettingProperties.Select(p => GetSlot(p, map, imap)).ToImmutableArray();
            var derivedUnionSlots = this.derivedUnionProperties.Select(p => GetSlot(p, map, imap)).ToImmutableArray();
            var oppositeProperties = this.oppositeProperties.ToImmutable();
            var result = imap[this];
            result.UpdateSlots(equivalentProperties, supersetSlots, subsetSlots, subsettedSlots, subsettingSlots, derivedUnionSlots, oppositeProperties);
            return result;
        }

        private Slot GetSlot(ModelProperty property, Dictionary<ModelProperty, ComplexSlotBuilder> map, Dictionary<ComplexSlotBuilder, ComplexSlot> imap)
        {
            if (map.TryGetValue(property, out var slotBuilder))
            {
                if (imap.TryGetValue(slotBuilder, out var slot))
                {
                    return slot;
                }
                else
                {
                    Debug.Assert(false);
                    return property;
                }
            }
            else
            {
                return property;
            }
        }

        private void Free()
        {
            this.equivalentProperties.Free();
            this.supersetSlots.Free();
            this.subsetSlots.Free();
            this.subsettedProperties.Free();
            this.subsettingProperties.Free();
            this.derivedUnionProperties.Free();
        }

        private static ComplexSlotBuilder CreateComplexSlot(Dictionary<ModelProperty, ComplexSlotBuilder> map, ModelProperty property)
        {
            ComplexSlotBuilder result;
            if (!map.TryGetValue(property, out result))
            {
                result = new ComplexSlotBuilder(map);
                map.Add(property, result);
                result.effectiveProperty = property;
                result.flags = property.Flags;
            }
            return result;
        }

        private static ComplexSlotBuilder GetComplexSlot(Dictionary<ModelProperty, ComplexSlotBuilder> map, ModelProperty property)
        {
            map.TryGetValue(property, out var result);
            return result;
        }

        private static ModelPropertyFlags AddFlag(ModelPropertyFlags flag, ModelPropertyFlags accumulatedFlags, ModelPropertyFlags propertyFlags)
        {
            if (propertyFlags.HasFlag(flag)) return accumulatedFlags | flag;
            else return accumulatedFlags;
        }

        private static ModelPropertyFlags RemoveFlag(ModelPropertyFlags flag, ModelPropertyFlags accumulatedFlags, ModelPropertyFlags propertyFlags)
        {
            if (!propertyFlags.HasFlag(flag)) return accumulatedFlags & ~flag;
            else return accumulatedFlags;
        }

        private void AddRedefinedProperty(ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (!this.equivalentProperties.Contains(property))
            {
                this.equivalentProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        var eqSlot = CreateComplexSlot(map, eqProp);
                        eqSlot.AddRedefinedProperty(property, false);
                    }
                }
            }
        }

        private void AddSubsettedProperty(ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (this.equivalentProperties.Contains(property)) return;
            if (!this.subsettedProperties.Contains(property))
            {
                this.subsettedProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        var eqSlot = CreateComplexSlot(map, eqProp);
                        eqSlot.AddSubsettedProperty(property, false);
                    }
                }
            }
        }

        private void AddSubsettingProperty(ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (this.equivalentProperties.Contains(property)) return;
            if (!this.subsettingProperties.Contains(property))
            {
                this.subsettingProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        var eqSlot = CreateComplexSlot(map, eqProp);
                        eqSlot.AddSubsettingProperty(property, false);
                    }
                }
            }
        }

        private void AddDerivedUnionProperty(ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (this.equivalentProperties.Contains(property)) return;
            if (!this.derivedUnionProperties.Contains(property))
            {
                this.derivedUnionProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        var eqSlot = CreateComplexSlot(map, eqProp);
                        eqSlot.AddDerivedUnionProperty(property, false);
                    }
                }
            }
        }

        private void AddOppositeProperty(ModelProperty property, bool firstCall)
        {
            if (property == null) return;
            if (this.equivalentProperties.Contains(property)) return;
            if (!this.oppositeProperties.Contains(property))
            {
                this.oppositeProperties.Add(property);
                if (firstCall)
                {
                    foreach (var eqProp in this.equivalentProperties)
                    {
                        var eqSlot = CreateComplexSlot(map, eqProp);
                        eqSlot.AddOppositeProperty(property, false);
                    }
                }
            }
        }

    }

}
