using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MetaDslx.Languages.Mof.Model
{
    internal static class ModelExtensions
    {
        private static ConditionalWeakTable<Classifier, HashSet<Classifier>> baseClassifiers = new ConditionalWeakTable<Classifier, HashSet<Classifier>>();
        private static ConditionalWeakTable<Classifier, List<Classifier>> allBaseClassifiers = new ConditionalWeakTable<Classifier, List<Classifier>>();
        private static ConditionalWeakTable<Classifier, HashSet<Property>> allAttributes = new ConditionalWeakTable<Classifier, HashSet<Property>>();
        private static ConditionalWeakTable<Classifier, List<Operation>> allOperations = new ConditionalWeakTable<Classifier, List<Operation>>();

        public static IEnumerable<T> MOfType<T>(this IEnumerable<object> items)
            where T : ImmutableObject
        {
            return items.Where(item => item.MIsOfType<T>()).Cast<T>();
        }

        public static bool MIsOfType<T>(this object obj)
            where T : ImmutableObject
        {
            return obj is T tobj && tobj.MId.Descriptor.ImmutableType == typeof(T);
        }

        public static IEnumerable<Classifier> MBaseClassifiers(this Classifier cls)
        {
            if (baseClassifiers.TryGetValue(cls, out var result)) return result;
            result = new HashSet<Classifier>();
            result.UnionWith(cls.MModel.Objects.MOfType<Generalization>().Where(d => d.Specific == cls).Select(d => d.General).OfType<Classifier>());
            baseClassifiers.Add(cls, result);
            return result;
        }

        public static IEnumerable<Classifier> MAllBaseClassifiers(this Classifier cls)
        {
            if (allBaseClassifiers.TryGetValue(cls, out var result)) return result;
            result = new List<Classifier>();
            result.AddRange(cls.MBaseClassifiers());
            for (int i = 0; i < result.Count; i++)
            {
                var baseCls = result[i];
                foreach (var ancestorCls in baseCls.MBaseClassifiers())
                {
                    if (!result.Contains(ancestorCls) && ancestorCls != null) result.Add(ancestorCls);
                }
            }
            allBaseClassifiers.Add(cls, result);
            return result;
        }

        public static IEnumerable<Property> MAllAttributes(this Classifier cls)
        {
            if (allAttributes.TryGetValue(cls, out var result)) return result;
            result = new HashSet<Property>();
            if (cls is Class @class) result.UnionWith(@class.OwnedAttribute);
            var allBaseClassifiers = cls.MAllBaseClassifiers().ToList();
            foreach (var baseClassifier in allBaseClassifiers)
            {
                if (baseClassifier is Class baseCls)
                {
                    foreach (var attr in baseCls.OwnedAttribute)
                    {
                        result.Add(attr);
                    }
                }
            }
            allAttributes.Add(cls, result);
            return result;
        }

        public static IEnumerable<Operation> MAllOperations(this Classifier cls)
        {
            if (allOperations.TryGetValue(cls, out var result)) return result;
            result = new List<Operation>();
            if (cls is Class @class) result.AddRange(@class.OwnedOperation);
            var allBaseClassifiers = cls.MAllBaseClassifiers().ToList();
            foreach (var baseClassifier in allBaseClassifiers)
            {
                if (baseClassifier is Class baseCls)
                {
                    foreach (var op in baseCls.OwnedOperation)
                    {
                        if (!result.Contains(op) && op != null) result.Add(op);
                    }
                }
            }
            allOperations.Add(cls, result);
            return result;
        }

        public static string MGetSignature(this Operation operation)
        {
            if (operation == null || string.IsNullOrWhiteSpace(operation.Name)) return string.Empty;
            var sb = new StringBuilder();
            sb.Clear();
            sb.Append(operation.Name);
            sb.Append('(');
            var inputParameters = operation.OwnedParameter.Where(p => p.Direction != ParameterDirectionKind.Return).ToList();
            for (int i = 0; i < inputParameters.Count; i++)
            {
                if (i > 0) sb.Append(',');
                var param = inputParameters[i];
                sb.Append(param.Name);
                sb.Append(':');
                sb.Append(param.Type?.Name);
            }
            sb.Append(')');
            var returnParameter = operation.OwnedParameter.Where(p => p.Direction == ParameterDirectionKind.Return).FirstOrDefault();
            if (returnParameter != null)
            {
                sb.Append(':');
                sb.Append(returnParameter.Type?.Name);
            }
            return sb.ToString();
        }

        public static bool MIsDescendantOf(this Classifier cls, Classifier ancestor)
        {
            return cls.MAllBaseClassifiers().Contains(ancestor);
        }

        public static bool HasEdge(this Classifier first, Classifier second)
        {
            if (first.MModel.Objects.MOfType<Generalization>().Any(g => g.Specific == first && g.General == second || g.Specific == second && g.General == first)) return true;
            if (first.MModel.Objects.MOfType<Association>().Any(a => a.MemberEnd.Any(e => e.Type == first) && a.MemberEnd.Any(e => e.Type == second))) return true;
            return false;
        }

        public static bool HasAssociation(this Classifier first, Classifier second)
        {
            var associations = first.MModel.Objects.MOfType<Association>().Where(a => a.MemberEnd.Any(e => e.Type == first) && a.MemberEnd.Any(e => e.Type == second));
            return associations.Any();
        }

        public static bool HasInheritance(this Classifier client, Classifier supplier)
        {
            return client.MAllBaseClassifiers().Contains(supplier);
        }

        public static bool HasAncestorAssociation(this Classifier first, Classifier second)
        {
            foreach (var baseCls in first.MAllBaseClassifiers())
            {
                if (HasAssociation(baseCls, second)) return true;
            }
            return false;
        }

    }

}
