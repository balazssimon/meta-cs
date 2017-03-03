using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core; //4:1
using MetaDslx.Languages.Meta.Symbols; //5:1
using System.Collections.Immutable; //6:1

namespace MetaDslx.Languages.Meta.Generator //1:1
{
    using __Hidden_ImmutableMetaModelGenerator_659346519;
    namespace __Hidden_ImmutableMetaModelGenerator_659346519
    {
        internal static class __Extensions
        {
            internal static IEnumerator<T> GetEnumerator<T>(this T item)
            {
                if (item == null) return new List<T>().GetEnumerator();
                else return new List<T> { item }.GetEnumerator();
            }
        }
    }


    internal interface IImmutableMetaModelGeneratorExtensions
    {
        string ToCamelCase(string identifier); //28:8
        string ToPascalCase(string identifier); //29:8
        string EscapeText(string text); //30:8
        bool IsMetaMetaModel(MetaModel mmodel); //31:8
        string GetEnumValueOf(Enum menum); //32:8
        string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false); //33:8
        string CSharpName(MetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false); //34:8
        string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false); //35:8
        string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false); //36:8
        string CSharpName(MetaConstant mconst, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false); //37:8
        ImmutableList<ImmutableSymbol> GetSymbolInstances(MetaModel mmodel); //38:8
        ImmutableDictionary<ImmutableSymbol,string> GetSymbolInstanceNames(MetaModel mmodel); //39:8
        string GetFieldName(MetaProperty mproperty, MetaClass mclass); //40:8
        bool IsReferenceType(MetaType mtype); //41:8
    }

    public class ImmutableMetaModelGenerator //2:1
    {
        // If you see an error at this line, create a class called ImmutableMetaModelGeneratorExtensions
        // which implements the interface IImmutableMetaModelGeneratorExtensions
        private IImmutableMetaModelGeneratorExtensions extensionFunctions = new ImmutableMetaModelGeneratorExtensions();
        private IEnumerable<ImmutableSymbol> Instances; //2:1

        public ImmutableMetaModelGenerator() //2:1
        {
            this.Properties = new __Properties();
        }

        public ImmutableMetaModelGenerator(IEnumerable<ImmutableSymbol> instances) : this() //2:1
        {
            this.Instances = instances;
        }

        private Stream __ToStream(string text)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private static IEnumerable<T> __Enumerate<T>(IEnumerator<T> items)
        {
            while (items.MoveNext())
            {
                yield return items.Current;
            }
        }

        private int counter = 0;
        private int NextCounter()
        {
            return ++counter;
        }

        public __Properties Properties { get; private set; } //8:1

        public class __Properties //8:1
        {
            internal __Properties()
            {
                this.CoreNs = "global::MetaDslx.Core"; //9:18
                this.MetaNs = "global::MetaDslx.Languages.Meta.Symbols"; //10:18
            }
            public string CoreNs { get; set; } //9:2
            public string MetaNs { get; set; } //10:2
        }

        public string Generate() //13:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //22:1
            return __out.ToString();
        }

        internal string ToCamelCase(string identifier) //28:8
        {
            return this.extensionFunctions.ToCamelCase(identifier); //28:8
        }

        internal string ToPascalCase(string identifier) //29:8
        {
            return this.extensionFunctions.ToPascalCase(identifier); //29:8
        }

        internal string EscapeText(string text) //30:8
        {
            return this.extensionFunctions.EscapeText(text); //30:8
        }

        internal bool IsMetaMetaModel(MetaModel mmodel) //31:8
        {
            return this.extensionFunctions.IsMetaMetaModel(mmodel); //31:8
        }

        internal string GetEnumValueOf(Enum menum) //32:8
        {
            return this.extensionFunctions.GetEnumValueOf(menum); //32:8
        }

        internal string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false) //33:8
        {
            return this.extensionFunctions.CSharpName(mnamespace, kind, fullName); //33:8
        }

        internal string CSharpName(MetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false) //34:8
        {
            return this.extensionFunctions.CSharpName(mmodel, kind, fullName); //34:8
        }

        internal string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false) //35:8
        {
            return this.extensionFunctions.CSharpName(mtype, mmodel, kind, fullName); //35:8
        }

        internal string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false) //36:8
        {
            return this.extensionFunctions.CSharpName(mproperty, mmodel, kind, fullName); //36:8
        }

        internal string CSharpName(MetaConstant mconst, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false) //37:8
        {
            return this.extensionFunctions.CSharpName(mconst, mmodel, kind, fullName); //37:8
        }

        internal ImmutableList<ImmutableSymbol> GetSymbolInstances(MetaModel mmodel) //38:8
        {
            return this.extensionFunctions.GetSymbolInstances(mmodel); //38:8
        }

        internal ImmutableDictionary<ImmutableSymbol,string> GetSymbolInstanceNames(MetaModel mmodel) //39:8
        {
            return this.extensionFunctions.GetSymbolInstanceNames(mmodel); //39:8
        }

        internal string GetFieldName(MetaProperty mproperty, MetaClass mclass) //40:8
        {
            return this.extensionFunctions.GetFieldName(mproperty, mclass); //40:8
        }

        internal bool IsReferenceType(MetaType mtype) //41:8
        {
            return this.extensionFunctions.IsReferenceType(mtype); //41:8
        }

        public string GenerateDocumentation(MetaDocumentedElement elem) //43:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateAnnotations(MetaAnnotatedElement elem) //56:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateMetamodel(MetaModel model) //62:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //66:1
            __out.AppendLine(true); //68:1
            __out.AppendLine(true); //70:1
            __out.AppendLine(true); //77:1
            __out.AppendLine(true); //80:1
            __out.AppendLine(true); //86:1
            __out.AppendLine(true); //88:1
            __out.AppendLine(true); //90:1
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //95:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //101:1
            __out.AppendLine(true); //106:1
            __out.AppendLine(true); //113:1
            __out.AppendLine(true); //122:1
            __out.AppendLine(true); //131:1
            __out.AppendLine(true); //144:1
            __out.AppendLine(true); //152:1
            __out.AppendLine(true); //159:1
            return __out.ToString();
        }

        public string GenerateMetaModelBuilderInstance(MetaModel model) //165:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //173:1
            __out.AppendLine(true); //185:1
            __out.AppendLine(true); //194:1
            __out.AppendLine(true); //198:1
            __out.AppendLine(true); //209:1
            __out.AppendLine(true); //224:1
            __out.AppendLine(true); //230:1
            __out.AppendLine(true); //234:1
            __out.AppendLine(true); //238:1
            __out.AppendLine(true); //242:1
            return __out.ToString();
        }

        public string GenerateSymbolInstanceDeclaration(MetaModel model, bool metaMetaModel, ImmutableSymbol symbol, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //251:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateSymbolInstance(MetaModel model, bool metaMetaModel, ImmutableSymbol symbol, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //270:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateSymbolInstanceProperties(MetaModel model, bool metaMetaModel, ImmutableSymbol symbol, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //284:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateSymbolInstancePropertyValue(MetaModel model, bool metaMetaModel, ImmutableSymbol symbol, ModelProperty prop, object value, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //293:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateSymbolInstancePropertyCollectionValue(MetaModel model, bool metaMetaModel, ImmutableSymbol symbol, ModelProperty prop, object value, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //333:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //369:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //380:1
            __out.AppendLine(true); //396:1
            __out.AppendLine(true); //408:1
            return __out.ToString();
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //411:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //417:1
            __out.AppendLine(true); //428:1
            __out.AppendLine(true); //432:1
            __out.AppendLine(true); //435:1
            return __out.ToString();
        }

        public string GenerateDescriptorClass(MetaModel model, MetaClass cls) //441:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //448:1
            __out.AppendLine(true); //453:1
            __out.AppendLine(true); //457:1
            __out.AppendLine(true); //462:1
            return __out.ToString();
        }

        public string GetDescriptorAncestors(MetaModel model, MetaClass cls) //477:1
        {
            string result = ""; //478:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //479:7
                from super in __Enumerate((__loop25_var1.SuperClasses).GetEnumerator()) //479:12
                select new { __loop25_var1 = __loop25_var1, super = super}
                ).ToList(); //479:2
            for (int __loop25_iteration = 0; __loop25_iteration < __loop25_results.Count; ++__loop25_iteration)
            {
                string delim; //479:30
                if (__loop25_iteration+1 < __loop25_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop25_results[__loop25_iteration];
                var __loop25_var1 = __tmp1.__loop25_var1;
                var super = __tmp1.super;
                result += "typeof(" + CSharpName(super, model, ClassKind.Descriptor, true) + ")" + delim; //480:3
            }
            if (result.Length > 0) //482:2
            {
                result = ", BaseSymbolDescriptors = new global::System.Type[] { " + result + " }"; //483:3
            }
            return result; //485:2
        }

        public string GenerateDescriptorProperty(MetaModel model, MetaClass cls, MetaProperty prop) //488:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //489:1
            return __out.ToString();
        }

        public string GenerateDescriptorPropertyAnnotations(MetaModel model, MetaClass cls, MetaProperty prop) //506:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //532:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //538:1
            return __out.ToString();
        }

        public string GenerateImplementationBase(MetaModel model) //546:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //561:1
            __out.AppendLine(true); //607:1
            __out.AppendLine(true); //622:2
            __out.AppendLine(true); //631:2
            __out.AppendLine(true); //635:2
            __out.AppendLine(true); //644:2
            return __out.ToString();
        }

        public string GetImplParameters(MetaModel model, MetaClass cls, MetaOperation op) //649:1
        {
            string result = CSharpName(cls, model, ClassKind.Immutable) + " _this"; //650:2
            string delim = ", "; //651:2
            var __loop43_results = 
                (from __loop43_var1 in __Enumerate((op).GetEnumerator()) //652:7
                from param in __Enumerate((__loop43_var1.Parameters).GetEnumerator()) //652:11
                select new { __loop43_var1 = __loop43_var1, param = param}
                ).ToList(); //652:2
            for (int __loop43_iteration = 0; __loop43_iteration < __loop43_results.Count; ++__loop43_iteration)
            {
                var __tmp1 = __loop43_results[__loop43_iteration];
                var __loop43_var1 = __tmp1.__loop43_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, ClassKind.Immutable, true) + " " + param.Name; //653:3
            }
            return result; //655:2
        }

        public string GetImplParameters(MetaModel model, MetaEnum enm, MetaOperation op) //658:1
        {
            string result = CSharpName(enm, model, ClassKind.Immutable) + " _this"; //659:2
            string delim = ", "; //660:2
            var __loop44_results = 
                (from __loop44_var1 in __Enumerate((op).GetEnumerator()) //661:7
                from param in __Enumerate((__loop44_var1.Parameters).GetEnumerator()) //661:11
                select new { __loop44_var1 = __loop44_var1, param = param}
                ).ToList(); //661:2
            for (int __loop44_iteration = 0; __loop44_iteration < __loop44_results.Count; ++__loop44_iteration)
            {
                var __tmp1 = __loop44_results[__loop44_iteration];
                var __loop44_var1 = __tmp1.__loop44_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, ClassKind.Immutable, true) + " " + param.Name; //662:3
            }
            return result; //664:2
        }

        public string GenerateEnum(MetaModel model, MetaEnum enm) //668:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //669:1
            __out.AppendLine(true); //678:1
            return __out.ToString();
        }

        public string GetEnumImplParameters(MetaModel model, MetaEnum enm, MetaOperation op) //690:1
        {
            string result = "this " + CSharpName(enm, model, ClassKind.Immutable) + " _this"; //691:2
            string delim = ", "; //692:2
            var __loop47_results = 
                (from __loop47_var1 in __Enumerate((op).GetEnumerator()) //693:7
                from param in __Enumerate((__loop47_var1.Parameters).GetEnumerator()) //693:11
                select new { __loop47_var1 = __loop47_var1, param = param}
                ).ToList(); //693:2
            for (int __loop47_iteration = 0; __loop47_iteration < __loop47_results.Count; ++__loop47_iteration)
            {
                var __tmp1 = __loop47_results[__loop47_iteration];
                var __loop47_var1 = __tmp1.__loop47_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, ClassKind.Immutable) + " " + param.Name; //694:3
            }
            return result; //696:2
        }

        public string GetEnumImplCallParameterNames(MetaModel model, MetaOperation op) //699:1
        {
            string result = "_this"; //700:2
            string delim = ", "; //701:2
            var __loop48_results = 
                (from __loop48_var1 in __Enumerate((op).GetEnumerator()) //702:7
                from param in __Enumerate((__loop48_var1.Parameters).GetEnumerator()) //702:11
                select new { __loop48_var1 = __loop48_var1, param = param}
                ).ToList(); //702:2
            for (int __loop48_iteration = 0; __loop48_iteration < __loop48_results.Count; ++__loop48_iteration)
            {
                var __tmp1 = __loop48_results[__loop48_iteration];
                var __loop48_var1 = __tmp1.__loop48_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //703:3
            }
            return result; //705:2
        }

        public string GetClassParameters(MetaModel model, MetaClass cls, MetaOperation op) //708:1
        {
            string result = ""; //709:2
            var __loop49_results = 
                (from __loop49_var1 in __Enumerate((op).GetEnumerator()) //710:7
                from param in __Enumerate((__loop49_var1.Parameters).GetEnumerator()) //710:11
                select new { __loop49_var1 = __loop49_var1, param = param}
                ).ToList(); //710:2
            for (int __loop49_iteration = 0; __loop49_iteration < __loop49_results.Count; ++__loop49_iteration)
            {
                string delim; //710:27
                if (__loop49_iteration+1 < __loop49_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop49_results[__loop49_iteration];
                var __loop49_var1 = __tmp1.__loop49_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, ClassKind.Immutable) + " " + param.Name + delim; //711:3
            }
            return result; //713:2
        }

        public string GetClassImplParameters(MetaModel model, MetaClass cls, MetaOperation op) //716:1
        {
            string result = CSharpName(cls, model, ClassKind.Immutable) + " _this"; //717:2
            string delim = ", "; //718:2
            var __loop50_results = 
                (from __loop50_var1 in __Enumerate((op).GetEnumerator()) //719:7
                from param in __Enumerate((__loop50_var1.Parameters).GetEnumerator()) //719:11
                select new { __loop50_var1 = __loop50_var1, param = param}
                ).ToList(); //719:2
            for (int __loop50_iteration = 0; __loop50_iteration < __loop50_results.Count; ++__loop50_iteration)
            {
                var __tmp1 = __loop50_results[__loop50_iteration];
                var __loop50_var1 = __tmp1.__loop50_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, ClassKind.Immutable) + " " + param.Name; //720:3
            }
            return result; //722:2
        }

        public string GetClassImplCallParameterNames(MetaModel model, MetaOperation op) //725:1
        {
            string result = "this"; //726:2
            string delim = ", "; //727:2
            var __loop51_results = 
                (from __loop51_var1 in __Enumerate((op).GetEnumerator()) //728:7
                from param in __Enumerate((__loop51_var1.Parameters).GetEnumerator()) //728:11
                select new { __loop51_var1 = __loop51_var1, param = param}
                ).ToList(); //728:2
            for (int __loop51_iteration = 0; __loop51_iteration < __loop51_results.Count; ++__loop51_iteration)
            {
                var __tmp1 = __loop51_results[__loop51_iteration];
                var __loop51_var1 = __tmp1.__loop51_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //729:3
            }
            return result; //731:2
        }

        public string GetReturn(MetaModel model, MetaOperation op) //734:1
        {
            if (CSharpName(op.ReturnType, model, ClassKind.Immutable) == "void") //735:5
            {
                return ""; //736:3
            }
            else //737:2
            {
                return "return "; //738:3
            }
        }

        public string GenerateClass(MetaModel model, MetaClass cls) //742:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //743:1
            __out.AppendLine(true); //745:1
            return __out.ToString();
        }

        public string GenerateClassInternal(MetaModel model, MetaClass cls) //749:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //750:1
            __out.AppendLine(true); //752:1
            __out.AppendLine(true); //754:1
            return __out.ToString();
        }

        public string GenerateIdClass(MetaModel model, MetaClass cls) //758:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //762:1
            __out.AppendLine(true); //767:1
            return __out.ToString();
        }

        public string GenerateImmutableClass(MetaModel model, MetaClass cls) //775:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //782:1
            __out.AppendLine(true); //786:1
            return __out.ToString();
        }

        public string GenerateImmutableProperty(MetaModel model, MetaProperty prop) //792:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateImmutableOperation(MetaModel model, MetaOperation op) //799:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GetImmutableOperationParameters(MetaModel model, MetaOperation op) //803:1
        {
            string result = ""; //804:2
            var __loop54_results = 
                (from __loop54_var1 in __Enumerate((op).GetEnumerator()) //805:7
                from param in __Enumerate((__loop54_var1.Parameters).GetEnumerator()) //805:11
                select new { __loop54_var1 = __loop54_var1, param = param}
                ).ToList(); //805:2
            for (int __loop54_iteration = 0; __loop54_iteration < __loop54_results.Count; ++__loop54_iteration)
            {
                string delim; //805:27
                if (__loop54_iteration+1 < __loop54_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop54_results[__loop54_iteration];
                var __loop54_var1 = __tmp1.__loop54_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, ClassKind.Immutable, true) + " " + param.Name + delim; //806:3
            }
            return result; //808:2
        }

        public string GetImmutableAncestors(MetaModel model, MetaClass cls) //811:1
        {
            string result = ""; //812:2
            var __loop55_results = 
                (from __loop55_var1 in __Enumerate((cls).GetEnumerator()) //813:7
                from super in __Enumerate((__loop55_var1.SuperClasses).GetEnumerator()) //813:12
                select new { __loop55_var1 = __loop55_var1, super = super}
                ).ToList(); //813:2
            for (int __loop55_iteration = 0; __loop55_iteration < __loop55_results.Count; ++__loop55_iteration)
            {
                string delim; //813:30
                if (__loop55_iteration+1 < __loop55_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop55_results[__loop55_iteration];
                var __loop55_var1 = __tmp1.__loop55_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Immutable, true) + delim; //814:3
            }
            if (result == "") //816:2
            {
                result = Properties.CoreNs + ".ImmutableSymbol"; //817:3
            }
            result = " : " + result; //819:2
            return result; //820:2
        }

        public string GenerateBuilderClass(MetaModel model, MetaClass cls) //823:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //830:1
            return __out.ToString();
        }

        public string GenerateBuilderProperty(MetaModel model, MetaProperty prop) //836:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GetBuilderAncestors(MetaModel model, MetaClass cls) //853:1
        {
            string result = ""; //854:2
            var __loop57_results = 
                (from __loop57_var1 in __Enumerate((cls).GetEnumerator()) //855:7
                from super in __Enumerate((__loop57_var1.SuperClasses).GetEnumerator()) //855:12
                select new { __loop57_var1 = __loop57_var1, super = super}
                ).ToList(); //855:2
            for (int __loop57_iteration = 0; __loop57_iteration < __loop57_results.Count; ++__loop57_iteration)
            {
                string delim; //855:30
                if (__loop57_iteration+1 < __loop57_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop57_results[__loop57_iteration];
                var __loop57_var1 = __tmp1.__loop57_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Builder, true) + delim; //856:3
            }
            if (result == "") //858:2
            {
                result = Properties.CoreNs + ".MutableSymbol"; //859:3
            }
            result = " : " + result; //861:2
            return result; //862:2
        }

        public string GenerateImmutableImplClass(MetaModel model, MetaClass cls) //865:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //872:2
            __out.AppendLine(true); //877:2
            __out.AppendLine(true); //886:2
            __out.AppendLine(true); //891:2
            __out.AppendLine(true); //896:2
            __out.AppendLine(true); //902:2
            __out.AppendLine(true); //907:2
            __out.AppendLine(true); //914:2
            __out.AppendLine(true); //918:2
            return __out.ToString();
        }

        public string GenerateImmutableField(MetaModel model, MetaClass cls, MetaProperty prop) //924:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //929:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //930:1
            return __out.ToString();
        }

        public string GenerateImmutableOperationImpl(MetaModel model, MetaClass cls, MetaOperation op) //952:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //953:1
            return __out.ToString();
        }

        public string GenerateBuilderImplClass(MetaModel model, MetaClass cls) //960:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //967:2
            __out.AppendLine(true); //972:2
            __out.AppendLine(true); //977:2
            __out.AppendLine(true); //986:2
            __out.AppendLine(true); //991:2
            __out.AppendLine(true); //996:2
            __out.AppendLine(true); //1002:2
            __out.AppendLine(true); //1007:2
            __out.AppendLine(true); //1014:2
            return __out.ToString();
        }

        public string GenerateBuilderField(MetaModel model, MetaClass cls, MetaProperty prop) //1020:1
        {
            StringBuilder __out = new StringBuilder();
            return __out.ToString();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //1024:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1025:1
            __out.AppendLine(true); //1053:1
            return __out.ToString();
        }

        private class StringBuilder
        {
            private bool newLine;
            private System.Text.StringBuilder builder = new System.Text.StringBuilder();
            
            public StringBuilder()
            {
                this.newLine = true;
            }
            
            public void Append(string str)
            {
                if (str == null) return;
                if (!string.IsNullOrEmpty(str))
                {
                    this.newLine = false;
                }
                builder.Append(str);
            }
            
            public void Append(object obj)
            {
                if (obj == null) return;
                string text = obj.ToString();
                this.Append(text);
            }
            
            public void AppendLine(bool force = false)
            {
                if (force || !this.newLine)
                {
                    builder.AppendLine();
                    this.newLine = true;
                }
            }
            
            public override string ToString()
            {
                return builder.ToString();
            }
        }
    }
}
