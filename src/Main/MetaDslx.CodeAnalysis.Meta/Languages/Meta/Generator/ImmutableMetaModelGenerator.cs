using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Modeling; //4:1
using MetaDslx.Languages.Meta.Model; //5:1
using System.Collections.Immutable; //6:1

namespace MetaDslx.Languages.Meta.Generator //1:1
{
    using __Hidden_ImmutableMetaModelGenerator;
    namespace __Hidden_ImmutableMetaModelGenerator
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
        string GetEnumValueOf(MetaModel mmodel, Enum menum); //32:8
        string GetAttributeValueOf(MetaModel mmodel, MetaAttribute mattr); //33:8
        string GetAttributeName(MetaAttribute mattr); //34:8
        string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false); //35:8
        string CSharpName(IMetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false); //36:8
        string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false); //37:8
        string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false); //38:8
        string CSharpName(MetaConstant mconst, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false); //39:8
        ImmutableList<ImmutableObject> GetInstances(MetaModel mmodel); //40:8
        ImmutableDictionary<ImmutableObject,string> GetInstanceNames(MetaModel mmodel); //41:8
        string GetFieldName(MetaProperty mproperty, MetaClass mclass); //42:8
        bool IsReferenceType(MetaType mtype); //43:8
        string GetImmBldCallParameterNames(MetaModel mmodel, MetaOperation operation, ClassKind kind); //44:8
        string GetImmBldReturn(MetaModel mmodel, MetaOperation operation, ClassKind kind); //45:8
        MetaOperation GetFinalOperation(MetaClass cls, MetaOperation operation); //46:8
    }

    public class ImmutableMetaModelGenerator //2:1
    {
        // If you see an error at this line, create a class called ImmutableMetaModelGeneratorExtensions
        // which implements the interface IImmutableMetaModelGeneratorExtensions
        private IImmutableMetaModelGeneratorExtensions extensionFunctions;
        public readonly IEnumerable<ImmutableObject> Instances; //2:1

        public ImmutableMetaModelGenerator() //2:1
        {
            this.Properties = new __Properties();
            this.extensionFunctions = new ImmutableMetaModelGeneratorExtensions(this);
        }

        public ImmutableMetaModelGenerator(IEnumerable<ImmutableObject> instances) : this() //2:1
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

        public __Properties Properties { get; private set; } //8:1

        public class __Properties //8:1
        {
            internal __Properties()
            {
                this.CoreNs = "global::MetaDslx.Modeling"; //9:18
                this.MetaNs = "global::MetaDslx.Languages.Meta.Model"; //10:18
            }
            public string CoreNs { get; set; } //9:2
            public string MetaNs { get; set; } //10:2
        }

        public string Generate() //13:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("using System;"); //14:1
            __out.AppendLine(false); //14:14
            __out.Append("using System.Collections.Generic;"); //15:1
            __out.AppendLine(false); //15:34
            __out.Append("using System.IO;"); //16:1
            __out.AppendLine(false); //16:17
            __out.Append("using System.Linq;"); //17:1
            __out.AppendLine(false); //17:19
            __out.Append("using System.Text;"); //18:1
            __out.AppendLine(false); //18:19
            __out.Append("using System.Threading;"); //19:1
            __out.AppendLine(false); //19:24
            __out.Append("using System.Threading.Tasks;"); //20:1
            __out.AppendLine(false); //20:30
            __out.Append("using System.Diagnostics;"); //21:1
            __out.AppendLine(false); //21:26
            __out.AppendLine(true); //22:1
            var __loop1_results = 
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //23:8
                from mm in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaModel>() //23:19
                select new { __loop1_var1 = __loop1_var1, mm = mm}
                ).ToList(); //23:3
            for (int __loop1_iteration = 0; __loop1_iteration < __loop1_results.Count; ++__loop1_iteration)
            {
                var __tmp1 = __loop1_results[__loop1_iteration];
                var __loop1_var1 = __tmp1.__loop1_var1;
                var mm = __tmp1.mm;
                bool __tmp3_outputWritten = false;
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(GenerateMetamodel(mm));
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(!__tmp4_last)
                    {
                        string __tmp4_line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                        {
                            __out.Append(__tmp4_line);
                            __tmp3_outputWritten = true;
                        }
                        if (!__tmp4_last || __tmp3_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp3_outputWritten)
                {
                    __out.AppendLine(false); //24:24
                }
            }
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

        internal string GetEnumValueOf(MetaModel mmodel, Enum menum) //32:8
        {
            return this.extensionFunctions.GetEnumValueOf(mmodel, menum); //32:8
        }

        internal string GetAttributeValueOf(MetaModel mmodel, MetaAttribute mattr) //33:8
        {
            return this.extensionFunctions.GetAttributeValueOf(mmodel, mattr); //33:8
        }

        internal string GetAttributeName(MetaAttribute mattr) //34:8
        {
            return this.extensionFunctions.GetAttributeName(mattr); //34:8
        }

        internal string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false) //35:8
        {
            return this.extensionFunctions.CSharpName(mnamespace, kind, fullName); //35:8
        }

        internal string CSharpName(IMetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false) //36:8
        {
            return this.extensionFunctions.CSharpName(mmodel, kind, fullName); //36:8
        }

        internal string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false) //37:8
        {
            return this.extensionFunctions.CSharpName(mtype, mmodel, kind, fullName); //37:8
        }

        internal string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false) //38:8
        {
            return this.extensionFunctions.CSharpName(mproperty, mmodel, kind, fullName); //38:8
        }

        internal string CSharpName(MetaConstant mconst, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false) //39:8
        {
            return this.extensionFunctions.CSharpName(mconst, mmodel, kind, fullName); //39:8
        }

        internal ImmutableList<ImmutableObject> GetInstances(MetaModel mmodel) //40:8
        {
            return this.extensionFunctions.GetInstances(mmodel); //40:8
        }

        internal ImmutableDictionary<ImmutableObject,string> GetInstanceNames(MetaModel mmodel) //41:8
        {
            return this.extensionFunctions.GetInstanceNames(mmodel); //41:8
        }

        internal string GetFieldName(MetaProperty mproperty, MetaClass mclass) //42:8
        {
            return this.extensionFunctions.GetFieldName(mproperty, mclass); //42:8
        }

        internal bool IsReferenceType(MetaType mtype) //43:8
        {
            return this.extensionFunctions.IsReferenceType(mtype); //43:8
        }

        internal string GetImmBldCallParameterNames(MetaModel mmodel, MetaOperation operation, ClassKind kind) //44:8
        {
            return this.extensionFunctions.GetImmBldCallParameterNames(mmodel, operation, kind); //44:8
        }

        internal string GetImmBldReturn(MetaModel mmodel, MetaOperation operation, ClassKind kind) //45:8
        {
            return this.extensionFunctions.GetImmBldReturn(mmodel, operation, kind); //45:8
        }

        internal MetaOperation GetFinalOperation(MetaClass cls, MetaOperation operation) //46:8
        {
            return this.extensionFunctions.GetFinalOperation(cls, operation); //46:8
        }

        public string GenerateDocumentation(MetaDocumentedElement elem) //48:1
        {
            StringBuilder __out = new StringBuilder();
            var lines = elem.GetDocumentationLines(); //49:2
            if (lines.Count > 0) //50:2
            {
                var __loop2_results = 
                    (from line in __Enumerate((lines).GetEnumerator()) //51:8
                    select new { line = line}
                    ).ToList(); //51:3
                for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
                {
                    var __tmp1 = __loop2_results[__loop2_iteration];
                    var line = __tmp1.line;
                    bool __tmp3_outputWritten = false;
                    string __tmp4_line = "///"; //52:1
                    if (!string.IsNullOrEmpty(__tmp4_line))
                    {
                        __out.Append(__tmp4_line);
                        __tmp3_outputWritten = true;
                    }
                    StringBuilder __tmp5 = new StringBuilder();
                    __tmp5.Append(line);
                    using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                    {
                        bool __tmp5_last = __tmp5Reader.EndOfStream;
                        while(!__tmp5_last)
                        {
                            string __tmp5_line = __tmp5Reader.ReadLine();
                            __tmp5_last = __tmp5Reader.EndOfStream;
                            if ((__tmp5_last && !string.IsNullOrEmpty(__tmp5_line)) || (!__tmp5_last && __tmp5_line != null))
                            {
                                __out.Append(__tmp5_line);
                                __tmp3_outputWritten = true;
                            }
                            if (!__tmp5_last || __tmp3_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp3_outputWritten)
                    {
                        __out.AppendLine(false); //52:10
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateAttributes(MetaElement elem) //57:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop3_results = 
                (from __loop3_var1 in __Enumerate((elem).GetEnumerator()) //58:7
                from attr in __Enumerate((__loop3_var1.Attributes).GetEnumerator()) //58:13
                select new { __loop3_var1 = __loop3_var1, attr = attr}
                ).ToList(); //58:2
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                var __tmp1 = __loop3_results[__loop3_iteration];
                var __loop3_var1 = __tmp1.__loop3_var1;
                var attr = __tmp1.attr;
                bool __tmp3_outputWritten = false;
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append("[");
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(!__tmp4_last)
                    {
                        string __tmp4_line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                        {
                            __out.Append(__tmp4_line);
                            __tmp3_outputWritten = true;
                        }
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(Properties.CoreNs);
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(!__tmp5_last)
                    {
                        string __tmp5_line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if ((__tmp5_last && !string.IsNullOrEmpty(__tmp5_line)) || (!__tmp5_last && __tmp5_line != null))
                        {
                            __out.Append(__tmp5_line);
                            __tmp3_outputWritten = true;
                        }
                        if (!__tmp5_last) __out.AppendLine(true);
                    }
                }
                string __tmp6_line = "."; //59:25
                if (!string.IsNullOrEmpty(__tmp6_line))
                {
                    __out.Append(__tmp6_line);
                    __tmp3_outputWritten = true;
                }
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(GetAttributeName(attr));
                using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
                {
                    bool __tmp7_last = __tmp7Reader.EndOfStream;
                    while(!__tmp7_last)
                    {
                        string __tmp7_line = __tmp7Reader.ReadLine();
                        __tmp7_last = __tmp7Reader.EndOfStream;
                        if ((__tmp7_last && !string.IsNullOrEmpty(__tmp7_line)) || (!__tmp7_last && __tmp7_line != null))
                        {
                            __out.Append(__tmp7_line);
                            __tmp3_outputWritten = true;
                        }
                        if (!__tmp7_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append("]");
                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                {
                    bool __tmp8_last = __tmp8Reader.EndOfStream;
                    while(!__tmp8_last)
                    {
                        string __tmp8_line = __tmp8Reader.ReadLine();
                        __tmp8_last = __tmp8Reader.EndOfStream;
                        if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                        {
                            __out.Append(__tmp8_line);
                            __tmp3_outputWritten = true;
                        }
                        if (!__tmp8_last || __tmp3_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp3_outputWritten)
                {
                    __out.AppendLine(false); //59:55
                }
            }
            return __out.ToString();
        }

        public string GenerateMetamodel(MetaModel model) //63:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //64:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(CSharpName(model.Namespace, NamespaceKind.Public, true));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //64:67
            }
            __out.Append("{"); //65:1
            __out.AppendLine(false); //65:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	using global::"; //66:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(CSharpName(model.Namespace, NamespaceKind.Internal, true));
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp6_outputWritten = true;
                    }
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9_line = ";"; //66:74
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //66:75
            }
            __out.AppendLine(true); //67:1
            bool __tmp11_outputWritten = false;
            string __tmp10Prefix = "	"; //68:1
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(GenerateMetaModel(model));
            using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
            {
                bool __tmp12_last = __tmp12Reader.EndOfStream;
                while(!__tmp12_last)
                {
                    string __tmp12_line = __tmp12Reader.ReadLine();
                    __tmp12_last = __tmp12Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp10Prefix))
                    {
                        __out.Append(__tmp10Prefix);
                        __tmp11_outputWritten = true;
                    }
                    if ((__tmp12_last && !string.IsNullOrEmpty(__tmp12_line)) || (!__tmp12_last && __tmp12_line != null))
                    {
                        __out.Append(__tmp12_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp12_last || __tmp11_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //68:28
            }
            __out.AppendLine(true); //69:1
            bool __tmp14_outputWritten = false;
            string __tmp13Prefix = "	"; //70:1
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(GenerateMetaModelInstance(model));
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_last = __tmp15Reader.EndOfStream;
                while(!__tmp15_last)
                {
                    string __tmp15_line = __tmp15Reader.ReadLine();
                    __tmp15_last = __tmp15Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp13Prefix))
                    {
                        __out.Append(__tmp13Prefix);
                        __tmp14_outputWritten = true;
                    }
                    if ((__tmp15_last && !string.IsNullOrEmpty(__tmp15_line)) || (!__tmp15_last && __tmp15_line != null))
                    {
                        __out.Append(__tmp15_line);
                        __tmp14_outputWritten = true;
                    }
                    if (!__tmp15_last || __tmp14_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //70:36
            }
            __out.AppendLine(true); //71:1
            bool __tmp17_outputWritten = false;
            string __tmp16Prefix = "	"; //72:1
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(GenerateFactory(model));
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    string __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp16Prefix))
                    {
                        __out.Append(__tmp16Prefix);
                        __tmp17_outputWritten = true;
                    }
                    if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                    {
                        __out.Append(__tmp18_line);
                        __tmp17_outputWritten = true;
                    }
                    if (!__tmp18_last || __tmp17_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp17_outputWritten)
            {
                __out.AppendLine(false); //72:26
            }
            __out.AppendLine(true); //73:1
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //74:8
                from enm in __Enumerate((__loop4_var1).GetEnumerator()).OfType<MetaEnum>() //74:38
                select new { __loop4_var1 = __loop4_var1, enm = enm}
                ).ToList(); //74:3
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp19 = __loop4_results[__loop4_iteration];
                var __loop4_var1 = __tmp19.__loop4_var1;
                var enm = __tmp19.enm;
                bool __tmp21_outputWritten = false;
                string __tmp20Prefix = "	"; //75:1
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(GenerateEnum(model, enm));
                using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                {
                    bool __tmp22_last = __tmp22Reader.EndOfStream;
                    while(!__tmp22_last)
                    {
                        string __tmp22_line = __tmp22Reader.ReadLine();
                        __tmp22_last = __tmp22Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp20Prefix))
                        {
                            __out.Append(__tmp20Prefix);
                            __tmp21_outputWritten = true;
                        }
                        if ((__tmp22_last && !string.IsNullOrEmpty(__tmp22_line)) || (!__tmp22_last && __tmp22_line != null))
                        {
                            __out.Append(__tmp22_line);
                            __tmp21_outputWritten = true;
                        }
                        if (!__tmp22_last || __tmp21_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp21_outputWritten)
                {
                    __out.AppendLine(false); //75:28
                }
            }
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //77:8
                from cls in __Enumerate((__loop5_var1).GetEnumerator()).OfType<MetaClass>() //77:38
                select new { __loop5_var1 = __loop5_var1, cls = cls}
                ).ToList(); //77:3
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp23 = __loop5_results[__loop5_iteration];
                var __loop5_var1 = __tmp23.__loop5_var1;
                var cls = __tmp23.cls;
                bool __tmp25_outputWritten = false;
                string __tmp24Prefix = "	"; //78:1
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(GenerateClass(model, cls));
                using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
                {
                    bool __tmp26_last = __tmp26Reader.EndOfStream;
                    while(!__tmp26_last)
                    {
                        string __tmp26_line = __tmp26Reader.ReadLine();
                        __tmp26_last = __tmp26Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp24Prefix))
                        {
                            __out.Append(__tmp24Prefix);
                            __tmp25_outputWritten = true;
                        }
                        if ((__tmp26_last && !string.IsNullOrEmpty(__tmp26_line)) || (!__tmp26_last && __tmp26_line != null))
                        {
                            __out.Append(__tmp26_line);
                            __tmp25_outputWritten = true;
                        }
                        if (!__tmp26_last || __tmp25_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp25_outputWritten)
                {
                    __out.AppendLine(false); //78:29
                }
            }
            __out.AppendLine(true); //80:1
            bool __tmp28_outputWritten = false;
            string __tmp27Prefix = "	"; //81:1
            StringBuilder __tmp29 = new StringBuilder();
            __tmp29.Append(GenerateMetaModelDescriptor(model));
            using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
            {
                bool __tmp29_last = __tmp29Reader.EndOfStream;
                while(!__tmp29_last)
                {
                    string __tmp29_line = __tmp29Reader.ReadLine();
                    __tmp29_last = __tmp29Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp27Prefix))
                    {
                        __out.Append(__tmp27Prefix);
                        __tmp28_outputWritten = true;
                    }
                    if ((__tmp29_last && !string.IsNullOrEmpty(__tmp29_line)) || (!__tmp29_last && __tmp29_line != null))
                    {
                        __out.Append(__tmp29_line);
                        __tmp28_outputWritten = true;
                    }
                    if (!__tmp29_last || __tmp28_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //81:38
            }
            __out.Append("}"); //82:1
            __out.AppendLine(false); //82:2
            __out.AppendLine(true); //83:1
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "namespace "; //84:1
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Append(__tmp32_line);
                __tmp31_outputWritten = true;
            }
            StringBuilder __tmp33 = new StringBuilder();
            __tmp33.Append(CSharpName(model.Namespace, NamespaceKind.Internal, true));
            using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
            {
                bool __tmp33_last = __tmp33Reader.EndOfStream;
                while(!__tmp33_last)
                {
                    string __tmp33_line = __tmp33Reader.ReadLine();
                    __tmp33_last = __tmp33Reader.EndOfStream;
                    if ((__tmp33_last && !string.IsNullOrEmpty(__tmp33_line)) || (!__tmp33_last && __tmp33_line != null))
                    {
                        __out.Append(__tmp33_line);
                        __tmp31_outputWritten = true;
                    }
                    if (!__tmp33_last || __tmp31_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //84:69
            }
            __out.Append("{"); //85:1
            __out.AppendLine(false); //85:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //86:8
                from cls in __Enumerate((__loop6_var1).GetEnumerator()).OfType<MetaClass>() //86:38
                select new { __loop6_var1 = __loop6_var1, cls = cls}
                ).ToList(); //86:3
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp34 = __loop6_results[__loop6_iteration];
                var __loop6_var1 = __tmp34.__loop6_var1;
                var cls = __tmp34.cls;
                bool __tmp36_outputWritten = false;
                string __tmp35Prefix = "	"; //87:1
                StringBuilder __tmp37 = new StringBuilder();
                __tmp37.Append(GenerateClassInternal(model, cls));
                using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
                {
                    bool __tmp37_last = __tmp37Reader.EndOfStream;
                    while(!__tmp37_last)
                    {
                        string __tmp37_line = __tmp37Reader.ReadLine();
                        __tmp37_last = __tmp37Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp35Prefix))
                        {
                            __out.Append(__tmp35Prefix);
                            __tmp36_outputWritten = true;
                        }
                        if ((__tmp37_last && !string.IsNullOrEmpty(__tmp37_line)) || (!__tmp37_last && __tmp37_line != null))
                        {
                            __out.Append(__tmp37_line);
                            __tmp36_outputWritten = true;
                        }
                        if (!__tmp37_last || __tmp36_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //87:37
                }
            }
            __out.AppendLine(true); //89:1
            bool __tmp39_outputWritten = false;
            string __tmp38Prefix = "	"; //90:1
            StringBuilder __tmp40 = new StringBuilder();
            __tmp40.Append(GenerateMetaModelBuilderInstance(model));
            using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
            {
                bool __tmp40_last = __tmp40Reader.EndOfStream;
                while(!__tmp40_last)
                {
                    string __tmp40_line = __tmp40Reader.ReadLine();
                    __tmp40_last = __tmp40Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp38Prefix))
                    {
                        __out.Append(__tmp38Prefix);
                        __tmp39_outputWritten = true;
                    }
                    if ((__tmp40_last && !string.IsNullOrEmpty(__tmp40_line)) || (!__tmp40_last && __tmp40_line != null))
                    {
                        __out.Append(__tmp40_line);
                        __tmp39_outputWritten = true;
                    }
                    if (!__tmp40_last || __tmp39_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp39_outputWritten)
            {
                __out.AppendLine(false); //90:43
            }
            __out.AppendLine(true); //91:1
            bool __tmp42_outputWritten = false;
            string __tmp41Prefix = "	"; //92:1
            StringBuilder __tmp43 = new StringBuilder();
            __tmp43.Append(GenerateImplementationBase(model));
            using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
            {
                bool __tmp43_last = __tmp43Reader.EndOfStream;
                while(!__tmp43_last)
                {
                    string __tmp43_line = __tmp43Reader.ReadLine();
                    __tmp43_last = __tmp43Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp41Prefix))
                    {
                        __out.Append(__tmp41Prefix);
                        __tmp42_outputWritten = true;
                    }
                    if ((__tmp43_last && !string.IsNullOrEmpty(__tmp43_line)) || (!__tmp43_last && __tmp43_line != null))
                    {
                        __out.Append(__tmp43_line);
                        __tmp42_outputWritten = true;
                    }
                    if (!__tmp43_last || __tmp42_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp42_outputWritten)
            {
                __out.AppendLine(false); //92:37
            }
            __out.AppendLine(true); //93:1
            bool __tmp45_outputWritten = false;
            string __tmp44Prefix = "	"; //94:1
            StringBuilder __tmp46 = new StringBuilder();
            __tmp46.Append(GenerateImplementationProvider(model));
            using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
            {
                bool __tmp46_last = __tmp46Reader.EndOfStream;
                while(!__tmp46_last)
                {
                    string __tmp46_line = __tmp46Reader.ReadLine();
                    __tmp46_last = __tmp46Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp44Prefix))
                    {
                        __out.Append(__tmp44Prefix);
                        __tmp45_outputWritten = true;
                    }
                    if ((__tmp46_last && !string.IsNullOrEmpty(__tmp46_line)) || (!__tmp46_last && __tmp46_line != null))
                    {
                        __out.Append(__tmp46_line);
                        __tmp45_outputWritten = true;
                    }
                    if (!__tmp46_last || __tmp45_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp45_outputWritten)
            {
                __out.AppendLine(false); //94:41
            }
            __out.Append("}"); //95:1
            __out.AppendLine(false); //95:2
            return __out.ToString();
        }

        public string GenerateMetaModel(MetaModel model) //98:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //99:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //100:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(CSharpName(model, ModelKind.MetaModel));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5_line = " : "; //100:55
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Append(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(Properties.CoreNs);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7_line = ".IMetaModel"; //100:77
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //100:88
            }
            __out.Append("{"); //101:1
            __out.AppendLine(false); //101:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	internal "; //102:1
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp9_outputWritten = true;
            }
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(CSharpName(model, ModelKind.MetaModel));
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(!__tmp11_last)
                {
                    string __tmp11_line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    if ((__tmp11_last && !string.IsNullOrEmpty(__tmp11_line)) || (!__tmp11_last && __tmp11_line != null))
                    {
                        __out.Append(__tmp11_line);
                        __tmp9_outputWritten = true;
                    }
                    if (!__tmp11_last) __out.AppendLine(true);
                }
            }
            string __tmp12_line = "()"; //102:50
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Append(__tmp12_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //102:52
            }
            __out.Append("	{"); //103:1
            __out.AppendLine(false); //103:3
            __out.Append("	}"); //104:1
            __out.AppendLine(false); //104:3
            __out.AppendLine(true); //105:1
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	public "; //106:1
            if (!string.IsNullOrEmpty(__tmp15_line))
            {
                __out.Append(__tmp15_line);
                __tmp14_outputWritten = true;
            }
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(Properties.CoreNs);
            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
            {
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    string __tmp16_line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if ((__tmp16_last && !string.IsNullOrEmpty(__tmp16_line)) || (!__tmp16_last && __tmp16_line != null))
                    {
                        __out.Append(__tmp16_line);
                        __tmp14_outputWritten = true;
                    }
                    if (!__tmp16_last) __out.AppendLine(true);
                }
            }
            string __tmp17_line = ".ModelId Id => "; //106:28
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp14_outputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(CSharpName(model, ModelKind.ImmutableInstance));
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    string __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                    {
                        __out.Append(__tmp18_line);
                        __tmp14_outputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19_line = ".MModel.Id;"; //106:90
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //106:101
            }
            bool __tmp21_outputWritten = false;
            string __tmp22_line = "	public string Name => \""; //107:1
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Append(__tmp22_line);
                __tmp21_outputWritten = true;
            }
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(model.Name);
            using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
            {
                bool __tmp23_last = __tmp23Reader.EndOfStream;
                while(!__tmp23_last)
                {
                    string __tmp23_line = __tmp23Reader.ReadLine();
                    __tmp23_last = __tmp23Reader.EndOfStream;
                    if ((__tmp23_last && !string.IsNullOrEmpty(__tmp23_line)) || (!__tmp23_last && __tmp23_line != null))
                    {
                        __out.Append(__tmp23_line);
                        __tmp21_outputWritten = true;
                    }
                    if (!__tmp23_last) __out.AppendLine(true);
                }
            }
            string __tmp24_line = "\";"; //107:37
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp21_outputWritten = true;
            }
            if (__tmp21_outputWritten) __out.AppendLine(true);
            if (__tmp21_outputWritten)
            {
                __out.AppendLine(false); //107:39
            }
            bool __tmp26_outputWritten = false;
            string __tmp27_line = "	public "; //108:1
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Append(__tmp27_line);
                __tmp26_outputWritten = true;
            }
            StringBuilder __tmp28 = new StringBuilder();
            __tmp28.Append(Properties.CoreNs);
            using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
            {
                bool __tmp28_last = __tmp28Reader.EndOfStream;
                while(!__tmp28_last)
                {
                    string __tmp28_line = __tmp28Reader.ReadLine();
                    __tmp28_last = __tmp28Reader.EndOfStream;
                    if ((__tmp28_last && !string.IsNullOrEmpty(__tmp28_line)) || (!__tmp28_last && __tmp28_line != null))
                    {
                        __out.Append(__tmp28_line);
                        __tmp26_outputWritten = true;
                    }
                    if (!__tmp28_last) __out.AppendLine(true);
                }
            }
            string __tmp29_line = ".ModelVersion Version => "; //108:28
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Append(__tmp29_line);
                __tmp26_outputWritten = true;
            }
            StringBuilder __tmp30 = new StringBuilder();
            __tmp30.Append(CSharpName(model, ModelKind.ImmutableInstance));
            using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
            {
                bool __tmp30_last = __tmp30Reader.EndOfStream;
                while(!__tmp30_last)
                {
                    string __tmp30_line = __tmp30Reader.ReadLine();
                    __tmp30_last = __tmp30Reader.EndOfStream;
                    if ((__tmp30_last && !string.IsNullOrEmpty(__tmp30_line)) || (!__tmp30_last && __tmp30_line != null))
                    {
                        __out.Append(__tmp30_line);
                        __tmp26_outputWritten = true;
                    }
                    if (!__tmp30_last) __out.AppendLine(true);
                }
            }
            string __tmp31_line = ".MModel.Version;"; //108:100
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Append(__tmp31_line);
                __tmp26_outputWritten = true;
            }
            if (__tmp26_outputWritten) __out.AppendLine(true);
            if (__tmp26_outputWritten)
            {
                __out.AppendLine(false); //108:116
            }
            bool __tmp33_outputWritten = false;
            string __tmp34_line = "	public global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> Objects => "; //109:1
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Append(__tmp34_line);
                __tmp33_outputWritten = true;
            }
            StringBuilder __tmp35 = new StringBuilder();
            __tmp35.Append(CSharpName(model, ModelKind.ImmutableInstance));
            using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
            {
                bool __tmp35_last = __tmp35Reader.EndOfStream;
                while(!__tmp35_last)
                {
                    string __tmp35_line = __tmp35Reader.ReadLine();
                    __tmp35_last = __tmp35Reader.EndOfStream;
                    if ((__tmp35_last && !string.IsNullOrEmpty(__tmp35_line)) || (!__tmp35_last && __tmp35_line != null))
                    {
                        __out.Append(__tmp35_line);
                        __tmp33_outputWritten = true;
                    }
                    if (!__tmp35_last) __out.AppendLine(true);
                }
            }
            string __tmp36_line = ".MModel.Objects;"; //109:154
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Append(__tmp36_line);
                __tmp33_outputWritten = true;
            }
            if (__tmp33_outputWritten) __out.AppendLine(true);
            if (__tmp33_outputWritten)
            {
                __out.AppendLine(false); //109:170
            }
            bool __tmp38_outputWritten = false;
            string __tmp39_line = "	public string Uri => \""; //110:1
            if (!string.IsNullOrEmpty(__tmp39_line))
            {
                __out.Append(__tmp39_line);
                __tmp38_outputWritten = true;
            }
            StringBuilder __tmp40 = new StringBuilder();
            __tmp40.Append(model.Uri);
            using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
            {
                bool __tmp40_last = __tmp40Reader.EndOfStream;
                while(!__tmp40_last)
                {
                    string __tmp40_line = __tmp40Reader.ReadLine();
                    __tmp40_last = __tmp40Reader.EndOfStream;
                    if ((__tmp40_last && !string.IsNullOrEmpty(__tmp40_line)) || (!__tmp40_last && __tmp40_line != null))
                    {
                        __out.Append(__tmp40_line);
                        __tmp38_outputWritten = true;
                    }
                    if (!__tmp40_last) __out.AppendLine(true);
                }
            }
            string __tmp41_line = "\";"; //110:35
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Append(__tmp41_line);
                __tmp38_outputWritten = true;
            }
            if (__tmp38_outputWritten) __out.AppendLine(true);
            if (__tmp38_outputWritten)
            {
                __out.AppendLine(false); //110:37
            }
            bool __tmp43_outputWritten = false;
            string __tmp44_line = "	public string Prefix => \""; //111:1
            if (!string.IsNullOrEmpty(__tmp44_line))
            {
                __out.Append(__tmp44_line);
                __tmp43_outputWritten = true;
            }
            StringBuilder __tmp45 = new StringBuilder();
            __tmp45.Append(model.Prefix);
            using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
            {
                bool __tmp45_last = __tmp45Reader.EndOfStream;
                while(!__tmp45_last)
                {
                    string __tmp45_line = __tmp45Reader.ReadLine();
                    __tmp45_last = __tmp45Reader.EndOfStream;
                    if ((__tmp45_last && !string.IsNullOrEmpty(__tmp45_line)) || (!__tmp45_last && __tmp45_line != null))
                    {
                        __out.Append(__tmp45_line);
                        __tmp43_outputWritten = true;
                    }
                    if (!__tmp45_last) __out.AppendLine(true);
                }
            }
            string __tmp46_line = "\";"; //111:41
            if (!string.IsNullOrEmpty(__tmp46_line))
            {
                __out.Append(__tmp46_line);
                __tmp43_outputWritten = true;
            }
            if (__tmp43_outputWritten) __out.AppendLine(true);
            if (__tmp43_outputWritten)
            {
                __out.AppendLine(false); //111:43
            }
            bool __tmp48_outputWritten = false;
            string __tmp49_line = "	public "; //112:1
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Append(__tmp49_line);
                __tmp48_outputWritten = true;
            }
            StringBuilder __tmp50 = new StringBuilder();
            __tmp50.Append(Properties.CoreNs);
            using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
            {
                bool __tmp50_last = __tmp50Reader.EndOfStream;
                while(!__tmp50_last)
                {
                    string __tmp50_line = __tmp50Reader.ReadLine();
                    __tmp50_last = __tmp50Reader.EndOfStream;
                    if ((__tmp50_last && !string.IsNullOrEmpty(__tmp50_line)) || (!__tmp50_last && __tmp50_line != null))
                    {
                        __out.Append(__tmp50_line);
                        __tmp48_outputWritten = true;
                    }
                    if (!__tmp50_last) __out.AppendLine(true);
                }
            }
            string __tmp51_line = ".IModelGroup ModelGroup => "; //112:28
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Append(__tmp51_line);
                __tmp48_outputWritten = true;
            }
            StringBuilder __tmp52 = new StringBuilder();
            __tmp52.Append(CSharpName(model, ModelKind.ImmutableInstance));
            using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
            {
                bool __tmp52_last = __tmp52Reader.EndOfStream;
                while(!__tmp52_last)
                {
                    string __tmp52_line = __tmp52Reader.ReadLine();
                    __tmp52_last = __tmp52Reader.EndOfStream;
                    if ((__tmp52_last && !string.IsNullOrEmpty(__tmp52_line)) || (!__tmp52_last && __tmp52_line != null))
                    {
                        __out.Append(__tmp52_line);
                        __tmp48_outputWritten = true;
                    }
                    if (!__tmp52_last) __out.AppendLine(true);
                }
            }
            string __tmp53_line = ".MModel.ModelGroup;"; //112:102
            if (!string.IsNullOrEmpty(__tmp53_line))
            {
                __out.Append(__tmp53_line);
                __tmp48_outputWritten = true;
            }
            if (__tmp48_outputWritten) __out.AppendLine(true);
            if (__tmp48_outputWritten)
            {
                __out.AppendLine(false); //112:121
            }
            bool __tmp55_outputWritten = false;
            string __tmp56_line = "	public string Namespace => \""; //113:1
            if (!string.IsNullOrEmpty(__tmp56_line))
            {
                __out.Append(__tmp56_line);
                __tmp55_outputWritten = true;
            }
            StringBuilder __tmp57 = new StringBuilder();
            __tmp57.Append(CSharpName(model.Namespace, NamespaceKind.Public, true));
            using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
            {
                bool __tmp57_last = __tmp57Reader.EndOfStream;
                while(!__tmp57_last)
                {
                    string __tmp57_line = __tmp57Reader.ReadLine();
                    __tmp57_last = __tmp57Reader.EndOfStream;
                    if ((__tmp57_last && !string.IsNullOrEmpty(__tmp57_line)) || (!__tmp57_last && __tmp57_line != null))
                    {
                        __out.Append(__tmp57_line);
                        __tmp55_outputWritten = true;
                    }
                    if (!__tmp57_last) __out.AppendLine(true);
                }
            }
            string __tmp58_line = "\";"; //113:86
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Append(__tmp58_line);
                __tmp55_outputWritten = true;
            }
            if (__tmp55_outputWritten) __out.AppendLine(true);
            if (__tmp55_outputWritten)
            {
                __out.AppendLine(false); //113:88
            }
            __out.AppendLine(true); //114:1
            bool __tmp60_outputWritten = false;
            string __tmp61_line = "	public "; //115:1
            if (!string.IsNullOrEmpty(__tmp61_line))
            {
                __out.Append(__tmp61_line);
                __tmp60_outputWritten = true;
            }
            StringBuilder __tmp62 = new StringBuilder();
            __tmp62.Append(Properties.CoreNs);
            using(StreamReader __tmp62Reader = new StreamReader(this.__ToStream(__tmp62.ToString())))
            {
                bool __tmp62_last = __tmp62Reader.EndOfStream;
                while(!__tmp62_last)
                {
                    string __tmp62_line = __tmp62Reader.ReadLine();
                    __tmp62_last = __tmp62Reader.EndOfStream;
                    if ((__tmp62_last && !string.IsNullOrEmpty(__tmp62_line)) || (!__tmp62_last && __tmp62_line != null))
                    {
                        __out.Append(__tmp62_line);
                        __tmp60_outputWritten = true;
                    }
                    if (!__tmp62_last) __out.AppendLine(true);
                }
            }
            string __tmp63_line = ".IModelFactory CreateFactory("; //115:28
            if (!string.IsNullOrEmpty(__tmp63_line))
            {
                __out.Append(__tmp63_line);
                __tmp60_outputWritten = true;
            }
            StringBuilder __tmp64 = new StringBuilder();
            __tmp64.Append(Properties.CoreNs);
            using(StreamReader __tmp64Reader = new StreamReader(this.__ToStream(__tmp64.ToString())))
            {
                bool __tmp64_last = __tmp64Reader.EndOfStream;
                while(!__tmp64_last)
                {
                    string __tmp64_line = __tmp64Reader.ReadLine();
                    __tmp64_last = __tmp64Reader.EndOfStream;
                    if ((__tmp64_last && !string.IsNullOrEmpty(__tmp64_line)) || (!__tmp64_last && __tmp64_line != null))
                    {
                        __out.Append(__tmp64_line);
                        __tmp60_outputWritten = true;
                    }
                    if (!__tmp64_last) __out.AppendLine(true);
                }
            }
            string __tmp65_line = ".MutableModel model, "; //115:76
            if (!string.IsNullOrEmpty(__tmp65_line))
            {
                __out.Append(__tmp65_line);
                __tmp60_outputWritten = true;
            }
            StringBuilder __tmp66 = new StringBuilder();
            __tmp66.Append(Properties.CoreNs);
            using(StreamReader __tmp66Reader = new StreamReader(this.__ToStream(__tmp66.ToString())))
            {
                bool __tmp66_last = __tmp66Reader.EndOfStream;
                while(!__tmp66_last)
                {
                    string __tmp66_line = __tmp66Reader.ReadLine();
                    __tmp66_last = __tmp66Reader.EndOfStream;
                    if ((__tmp66_last && !string.IsNullOrEmpty(__tmp66_line)) || (!__tmp66_last && __tmp66_line != null))
                    {
                        __out.Append(__tmp66_line);
                        __tmp60_outputWritten = true;
                    }
                    if (!__tmp66_last) __out.AppendLine(true);
                }
            }
            string __tmp67_line = ".ModelFactoryFlags flags = "; //115:116
            if (!string.IsNullOrEmpty(__tmp67_line))
            {
                __out.Append(__tmp67_line);
                __tmp60_outputWritten = true;
            }
            StringBuilder __tmp68 = new StringBuilder();
            __tmp68.Append(Properties.CoreNs);
            using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
            {
                bool __tmp68_last = __tmp68Reader.EndOfStream;
                while(!__tmp68_last)
                {
                    string __tmp68_line = __tmp68Reader.ReadLine();
                    __tmp68_last = __tmp68Reader.EndOfStream;
                    if ((__tmp68_last && !string.IsNullOrEmpty(__tmp68_line)) || (!__tmp68_last && __tmp68_line != null))
                    {
                        __out.Append(__tmp68_line);
                        __tmp60_outputWritten = true;
                    }
                    if (!__tmp68_last) __out.AppendLine(true);
                }
            }
            string __tmp69_line = ".ModelFactoryFlags.None)"; //115:162
            if (!string.IsNullOrEmpty(__tmp69_line))
            {
                __out.Append(__tmp69_line);
                __tmp60_outputWritten = true;
            }
            if (__tmp60_outputWritten) __out.AppendLine(true);
            if (__tmp60_outputWritten)
            {
                __out.AppendLine(false); //115:186
            }
            __out.Append("	{"); //116:1
            __out.AppendLine(false); //116:3
            bool __tmp71_outputWritten = false;
            string __tmp72_line = "		return new "; //117:1
            if (!string.IsNullOrEmpty(__tmp72_line))
            {
                __out.Append(__tmp72_line);
                __tmp71_outputWritten = true;
            }
            StringBuilder __tmp73 = new StringBuilder();
            __tmp73.Append(CSharpName(model, ModelKind.Factory));
            using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
            {
                bool __tmp73_last = __tmp73Reader.EndOfStream;
                while(!__tmp73_last)
                {
                    string __tmp73_line = __tmp73Reader.ReadLine();
                    __tmp73_last = __tmp73Reader.EndOfStream;
                    if ((__tmp73_last && !string.IsNullOrEmpty(__tmp73_line)) || (!__tmp73_last && __tmp73_line != null))
                    {
                        __out.Append(__tmp73_line);
                        __tmp71_outputWritten = true;
                    }
                    if (!__tmp73_last) __out.AppendLine(true);
                }
            }
            string __tmp74_line = "(model, flags);"; //117:51
            if (!string.IsNullOrEmpty(__tmp74_line))
            {
                __out.Append(__tmp74_line);
                __tmp71_outputWritten = true;
            }
            if (__tmp71_outputWritten) __out.AppendLine(true);
            if (__tmp71_outputWritten)
            {
                __out.AppendLine(false); //117:66
            }
            __out.Append("	}"); //118:1
            __out.AppendLine(false); //118:3
            __out.AppendLine(true); //119:1
            __out.Append("    public override string ToString()"); //120:1
            __out.AppendLine(false); //120:38
            __out.Append("    {"); //121:1
            __out.AppendLine(false); //121:6
            __out.Append("        return $\"{Name} ({Version})\";"); //122:1
            __out.AppendLine(false); //122:38
            __out.Append("    }"); //123:1
            __out.AppendLine(false); //123:6
            __out.Append("}"); //124:1
            __out.AppendLine(false); //124:2
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //127:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //128:2
            bool metaMetaModel = IsMetaMetaModel(model); //129:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //130:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(CSharpName(model, ModelKind.ImmutableInstance));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //130:61
            }
            __out.Append("{"); //131:1
            __out.AppendLine(false); //131:2
            __out.Append("	private static bool initialized;"); //132:1
            __out.AppendLine(false); //132:34
            __out.AppendLine(true); //133:1
            __out.Append("	public static bool IsInitialized"); //134:1
            __out.AppendLine(false); //134:34
            __out.Append("	{"); //135:1
            __out.AppendLine(false); //135:3
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "		get { return "; //136:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(CSharpName(model, ModelKind.ImmutableInstance));
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp6_outputWritten = true;
                    }
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9_line = ".initialized; }"; //136:63
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //136:78
            }
            __out.Append("	}"); //137:1
            __out.AppendLine(false); //137:3
            __out.AppendLine(true); //138:1
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	public static readonly "; //139:1
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Append(__tmp12_line);
                __tmp11_outputWritten = true;
            }
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(Properties.CoreNs);
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13_line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if ((__tmp13_last && !string.IsNullOrEmpty(__tmp13_line)) || (!__tmp13_last && __tmp13_line != null))
                    {
                        __out.Append(__tmp13_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14_line = ".IMetaModel MMetaModel;"; //139:44
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //139:67
            }
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	public static readonly "; //140:1
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp16_outputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(Properties.CoreNs);
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    string __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                    {
                        __out.Append(__tmp18_line);
                        __tmp16_outputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19_line = ".ImmutableModel MModel;"; //140:44
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //140:67
            }
            __out.AppendLine(true); //141:1
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //142:8
                from cst in __Enumerate((__loop7_var1).GetEnumerator()).OfType<MetaConstant>() //142:38
                select new { __loop7_var1 = __loop7_var1, cst = cst}
                ).ToList(); //142:3
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp20 = __loop7_results[__loop7_iteration];
                var __loop7_var1 = __tmp20.__loop7_var1;
                var cst = __tmp20.cst;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "	"; //143:1
                StringBuilder __tmp23 = new StringBuilder();
                __tmp23.Append(GenerateDocumentation(cst));
                using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
                {
                    bool __tmp23_last = __tmp23Reader.EndOfStream;
                    while(!__tmp23_last)
                    {
                        string __tmp23_line = __tmp23Reader.ReadLine();
                        __tmp23_last = __tmp23Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp21Prefix))
                        {
                            __out.Append(__tmp21Prefix);
                            __tmp22_outputWritten = true;
                        }
                        if ((__tmp23_last && !string.IsNullOrEmpty(__tmp23_line)) || (!__tmp23_last && __tmp23_line != null))
                        {
                            __out.Append(__tmp23_line);
                            __tmp22_outputWritten = true;
                        }
                        if (!__tmp23_last || __tmp22_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp22_outputWritten)
                {
                    __out.AppendLine(false); //143:30
                }
                if (metaMetaModel) //144:4
                {
                    bool __tmp25_outputWritten = false;
                    string __tmp26_line = "	public static readonly "; //145:1
                    if (!string.IsNullOrEmpty(__tmp26_line))
                    {
                        __out.Append(__tmp26_line);
                        __tmp25_outputWritten = true;
                    }
                    StringBuilder __tmp27 = new StringBuilder();
                    __tmp27.Append(CSharpName(cst.Type, model, ClassKind.Immutable));
                    using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                    {
                        bool __tmp27_last = __tmp27Reader.EndOfStream;
                        while(!__tmp27_last)
                        {
                            string __tmp27_line = __tmp27Reader.ReadLine();
                            __tmp27_last = __tmp27Reader.EndOfStream;
                            if ((__tmp27_last && !string.IsNullOrEmpty(__tmp27_line)) || (!__tmp27_last && __tmp27_line != null))
                            {
                                __out.Append(__tmp27_line);
                                __tmp25_outputWritten = true;
                            }
                            if (!__tmp27_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp28_line = " "; //145:74
                    if (!string.IsNullOrEmpty(__tmp28_line))
                    {
                        __out.Append(__tmp28_line);
                        __tmp25_outputWritten = true;
                    }
                    StringBuilder __tmp29 = new StringBuilder();
                    __tmp29.Append(CSharpName(cst, model, ClassKind.ImmutableInstance));
                    using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                    {
                        bool __tmp29_last = __tmp29Reader.EndOfStream;
                        while(!__tmp29_last)
                        {
                            string __tmp29_line = __tmp29Reader.ReadLine();
                            __tmp29_last = __tmp29Reader.EndOfStream;
                            if ((__tmp29_last && !string.IsNullOrEmpty(__tmp29_line)) || (!__tmp29_last && __tmp29_line != null))
                            {
                                __out.Append(__tmp29_line);
                                __tmp25_outputWritten = true;
                            }
                            if (!__tmp29_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp30_line = ";"; //145:127
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Append(__tmp30_line);
                        __tmp25_outputWritten = true;
                    }
                    if (__tmp25_outputWritten) __out.AppendLine(true);
                    if (__tmp25_outputWritten)
                    {
                        __out.AppendLine(false); //145:128
                    }
                }
                else //146:4
                {
                    bool __tmp32_outputWritten = false;
                    string __tmp33_line = "	public static readonly "; //147:1
                    if (!string.IsNullOrEmpty(__tmp33_line))
                    {
                        __out.Append(__tmp33_line);
                        __tmp32_outputWritten = true;
                    }
                    StringBuilder __tmp34 = new StringBuilder();
                    __tmp34.Append(CSharpName(cst.Type, model, ClassKind.Immutable, true));
                    using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                    {
                        bool __tmp34_last = __tmp34Reader.EndOfStream;
                        while(!__tmp34_last)
                        {
                            string __tmp34_line = __tmp34Reader.ReadLine();
                            __tmp34_last = __tmp34Reader.EndOfStream;
                            if ((__tmp34_last && !string.IsNullOrEmpty(__tmp34_line)) || (!__tmp34_last && __tmp34_line != null))
                            {
                                __out.Append(__tmp34_line);
                                __tmp32_outputWritten = true;
                            }
                            if (!__tmp34_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp35_line = " "; //147:80
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Append(__tmp35_line);
                        __tmp32_outputWritten = true;
                    }
                    StringBuilder __tmp36 = new StringBuilder();
                    __tmp36.Append(CSharpName(cst, model, ClassKind.ImmutableInstance));
                    using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                    {
                        bool __tmp36_last = __tmp36Reader.EndOfStream;
                        while(!__tmp36_last)
                        {
                            string __tmp36_line = __tmp36Reader.ReadLine();
                            __tmp36_last = __tmp36Reader.EndOfStream;
                            if ((__tmp36_last && !string.IsNullOrEmpty(__tmp36_line)) || (!__tmp36_last && __tmp36_line != null))
                            {
                                __out.Append(__tmp36_line);
                                __tmp32_outputWritten = true;
                            }
                            if (!__tmp36_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp37_line = ";"; //147:133
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Append(__tmp37_line);
                        __tmp32_outputWritten = true;
                    }
                    if (__tmp32_outputWritten) __out.AppendLine(true);
                    if (__tmp32_outputWritten)
                    {
                        __out.AppendLine(false); //147:134
                    }
                }
            }
            __out.AppendLine(true); //150:1
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //151:8
                from cls in __Enumerate((__loop8_var1).GetEnumerator()).OfType<MetaClass>() //151:38
                select new { __loop8_var1 = __loop8_var1, cls = cls}
                ).ToList(); //151:3
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp38 = __loop8_results[__loop8_iteration];
                var __loop8_var1 = __tmp38.__loop8_var1;
                var cls = __tmp38.cls;
                bool __tmp40_outputWritten = false;
                string __tmp39Prefix = "	"; //152:1
                StringBuilder __tmp41 = new StringBuilder();
                __tmp41.Append(GenerateDocumentation(cls));
                using(StreamReader __tmp41Reader = new StreamReader(this.__ToStream(__tmp41.ToString())))
                {
                    bool __tmp41_last = __tmp41Reader.EndOfStream;
                    while(!__tmp41_last)
                    {
                        string __tmp41_line = __tmp41Reader.ReadLine();
                        __tmp41_last = __tmp41Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp39Prefix))
                        {
                            __out.Append(__tmp39Prefix);
                            __tmp40_outputWritten = true;
                        }
                        if ((__tmp41_last && !string.IsNullOrEmpty(__tmp41_line)) || (!__tmp41_last && __tmp41_line != null))
                        {
                            __out.Append(__tmp41_line);
                            __tmp40_outputWritten = true;
                        }
                        if (!__tmp41_last || __tmp40_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp40_outputWritten)
                {
                    __out.AppendLine(false); //152:30
                }
                bool __tmp43_outputWritten = false;
                string __tmp44_line = "	public static readonly "; //153:1
                if (!string.IsNullOrEmpty(__tmp44_line))
                {
                    __out.Append(__tmp44_line);
                    __tmp43_outputWritten = true;
                }
                StringBuilder __tmp45 = new StringBuilder();
                __tmp45.Append(metaNs);
                using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
                {
                    bool __tmp45_last = __tmp45Reader.EndOfStream;
                    while(!__tmp45_last)
                    {
                        string __tmp45_line = __tmp45Reader.ReadLine();
                        __tmp45_last = __tmp45Reader.EndOfStream;
                        if ((__tmp45_last && !string.IsNullOrEmpty(__tmp45_line)) || (!__tmp45_last && __tmp45_line != null))
                        {
                            __out.Append(__tmp45_line);
                            __tmp43_outputWritten = true;
                        }
                        if (!__tmp45_last) __out.AppendLine(true);
                    }
                }
                string __tmp46_line = "MetaClass "; //153:33
                if (!string.IsNullOrEmpty(__tmp46_line))
                {
                    __out.Append(__tmp46_line);
                    __tmp43_outputWritten = true;
                }
                StringBuilder __tmp47 = new StringBuilder();
                __tmp47.Append(CSharpName(cls, model, ClassKind.ImmutableInstance));
                using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
                {
                    bool __tmp47_last = __tmp47Reader.EndOfStream;
                    while(!__tmp47_last)
                    {
                        string __tmp47_line = __tmp47Reader.ReadLine();
                        __tmp47_last = __tmp47Reader.EndOfStream;
                        if ((__tmp47_last && !string.IsNullOrEmpty(__tmp47_line)) || (!__tmp47_last && __tmp47_line != null))
                        {
                            __out.Append(__tmp47_line);
                            __tmp43_outputWritten = true;
                        }
                        if (!__tmp47_last) __out.AppendLine(true);
                    }
                }
                string __tmp48_line = ";"; //153:95
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Append(__tmp48_line);
                    __tmp43_outputWritten = true;
                }
                if (__tmp43_outputWritten) __out.AppendLine(true);
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //153:96
                }
                var __loop9_results = 
                    (from __loop9_var1 in __Enumerate((cls).GetEnumerator()) //154:9
                    from prop in __Enumerate((__loop9_var1.Properties).GetEnumerator()) //154:14
                    select new { __loop9_var1 = __loop9_var1, prop = prop}
                    ).ToList(); //154:4
                for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
                {
                    var __tmp49 = __loop9_results[__loop9_iteration];
                    var __loop9_var1 = __tmp49.__loop9_var1;
                    var prop = __tmp49.prop;
                    bool __tmp51_outputWritten = false;
                    string __tmp50Prefix = "	"; //155:1
                    StringBuilder __tmp52 = new StringBuilder();
                    __tmp52.Append(GenerateDocumentation(prop));
                    using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                    {
                        bool __tmp52_last = __tmp52Reader.EndOfStream;
                        while(!__tmp52_last)
                        {
                            string __tmp52_line = __tmp52Reader.ReadLine();
                            __tmp52_last = __tmp52Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp50Prefix))
                            {
                                __out.Append(__tmp50Prefix);
                                __tmp51_outputWritten = true;
                            }
                            if ((__tmp52_last && !string.IsNullOrEmpty(__tmp52_line)) || (!__tmp52_last && __tmp52_line != null))
                            {
                                __out.Append(__tmp52_line);
                                __tmp51_outputWritten = true;
                            }
                            if (!__tmp52_last || __tmp51_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp51_outputWritten)
                    {
                        __out.AppendLine(false); //155:31
                    }
                    bool __tmp54_outputWritten = false;
                    string __tmp55_line = "	public static readonly "; //156:1
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Append(__tmp55_line);
                        __tmp54_outputWritten = true;
                    }
                    StringBuilder __tmp56 = new StringBuilder();
                    __tmp56.Append(metaNs);
                    using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
                    {
                        bool __tmp56_last = __tmp56Reader.EndOfStream;
                        while(!__tmp56_last)
                        {
                            string __tmp56_line = __tmp56Reader.ReadLine();
                            __tmp56_last = __tmp56Reader.EndOfStream;
                            if ((__tmp56_last && !string.IsNullOrEmpty(__tmp56_line)) || (!__tmp56_last && __tmp56_line != null))
                            {
                                __out.Append(__tmp56_line);
                                __tmp54_outputWritten = true;
                            }
                            if (!__tmp56_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp57_line = "MetaProperty "; //156:33
                    if (!string.IsNullOrEmpty(__tmp57_line))
                    {
                        __out.Append(__tmp57_line);
                        __tmp54_outputWritten = true;
                    }
                    StringBuilder __tmp58 = new StringBuilder();
                    __tmp58.Append(CSharpName(prop, model, PropertyKind.ImmutableInstance));
                    using(StreamReader __tmp58Reader = new StreamReader(this.__ToStream(__tmp58.ToString())))
                    {
                        bool __tmp58_last = __tmp58Reader.EndOfStream;
                        while(!__tmp58_last)
                        {
                            string __tmp58_line = __tmp58Reader.ReadLine();
                            __tmp58_last = __tmp58Reader.EndOfStream;
                            if ((__tmp58_last && !string.IsNullOrEmpty(__tmp58_line)) || (!__tmp58_last && __tmp58_line != null))
                            {
                                __out.Append(__tmp58_line);
                                __tmp54_outputWritten = true;
                            }
                            if (!__tmp58_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp59_line = ";"; //156:102
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Append(__tmp59_line);
                        __tmp54_outputWritten = true;
                    }
                    if (__tmp54_outputWritten) __out.AppendLine(true);
                    if (__tmp54_outputWritten)
                    {
                        __out.AppendLine(false); //156:103
                    }
                }
            }
            __out.AppendLine(true); //159:1
            bool __tmp61_outputWritten = false;
            string __tmp62_line = "	static "; //160:1
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Append(__tmp62_line);
                __tmp61_outputWritten = true;
            }
            StringBuilder __tmp63 = new StringBuilder();
            __tmp63.Append(CSharpName(model, ModelKind.ImmutableInstance));
            using(StreamReader __tmp63Reader = new StreamReader(this.__ToStream(__tmp63.ToString())))
            {
                bool __tmp63_last = __tmp63Reader.EndOfStream;
                while(!__tmp63_last)
                {
                    string __tmp63_line = __tmp63Reader.ReadLine();
                    __tmp63_last = __tmp63Reader.EndOfStream;
                    if ((__tmp63_last && !string.IsNullOrEmpty(__tmp63_line)) || (!__tmp63_last && __tmp63_line != null))
                    {
                        __out.Append(__tmp63_line);
                        __tmp61_outputWritten = true;
                    }
                    if (!__tmp63_last) __out.AppendLine(true);
                }
            }
            string __tmp64_line = "()"; //160:56
            if (!string.IsNullOrEmpty(__tmp64_line))
            {
                __out.Append(__tmp64_line);
                __tmp61_outputWritten = true;
            }
            if (__tmp61_outputWritten) __out.AppendLine(true);
            if (__tmp61_outputWritten)
            {
                __out.AppendLine(false); //160:58
            }
            __out.Append("	{"); //161:1
            __out.AppendLine(false); //161:3
            bool __tmp66_outputWritten = false;
            string __tmp65Prefix = "		"; //162:1
            StringBuilder __tmp67 = new StringBuilder();
            __tmp67.Append(CSharpName(model, ModelKind.BuilderInstance));
            using(StreamReader __tmp67Reader = new StreamReader(this.__ToStream(__tmp67.ToString())))
            {
                bool __tmp67_last = __tmp67Reader.EndOfStream;
                while(!__tmp67_last)
                {
                    string __tmp67_line = __tmp67Reader.ReadLine();
                    __tmp67_last = __tmp67Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp65Prefix))
                    {
                        __out.Append(__tmp65Prefix);
                        __tmp66_outputWritten = true;
                    }
                    if ((__tmp67_last && !string.IsNullOrEmpty(__tmp67_line)) || (!__tmp67_last && __tmp67_line != null))
                    {
                        __out.Append(__tmp67_line);
                        __tmp66_outputWritten = true;
                    }
                    if (!__tmp67_last) __out.AppendLine(true);
                }
            }
            string __tmp68_line = ".instance.Create();"; //162:48
            if (!string.IsNullOrEmpty(__tmp68_line))
            {
                __out.Append(__tmp68_line);
                __tmp66_outputWritten = true;
            }
            if (__tmp66_outputWritten) __out.AppendLine(true);
            if (__tmp66_outputWritten)
            {
                __out.AppendLine(false); //162:67
            }
            bool __tmp70_outputWritten = false;
            string __tmp69Prefix = "		"; //163:1
            StringBuilder __tmp71 = new StringBuilder();
            __tmp71.Append(CSharpName(model, ModelKind.BuilderInstance));
            using(StreamReader __tmp71Reader = new StreamReader(this.__ToStream(__tmp71.ToString())))
            {
                bool __tmp71_last = __tmp71Reader.EndOfStream;
                while(!__tmp71_last)
                {
                    string __tmp71_line = __tmp71Reader.ReadLine();
                    __tmp71_last = __tmp71Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp69Prefix))
                    {
                        __out.Append(__tmp69Prefix);
                        __tmp70_outputWritten = true;
                    }
                    if ((__tmp71_last && !string.IsNullOrEmpty(__tmp71_line)) || (!__tmp71_last && __tmp71_line != null))
                    {
                        __out.Append(__tmp71_line);
                        __tmp70_outputWritten = true;
                    }
                    if (!__tmp71_last) __out.AppendLine(true);
                }
            }
            string __tmp72_line = ".instance.EvaluateLazyValues();"; //163:48
            if (!string.IsNullOrEmpty(__tmp72_line))
            {
                __out.Append(__tmp72_line);
                __tmp70_outputWritten = true;
            }
            if (__tmp70_outputWritten) __out.AppendLine(true);
            if (__tmp70_outputWritten)
            {
                __out.AppendLine(false); //163:79
            }
            bool __tmp74_outputWritten = false;
            string __tmp75_line = "		MMetaModel = new "; //164:1
            if (!string.IsNullOrEmpty(__tmp75_line))
            {
                __out.Append(__tmp75_line);
                __tmp74_outputWritten = true;
            }
            StringBuilder __tmp76 = new StringBuilder();
            __tmp76.Append(CSharpName(model, ModelKind.MetaModel));
            using(StreamReader __tmp76Reader = new StreamReader(this.__ToStream(__tmp76.ToString())))
            {
                bool __tmp76_last = __tmp76Reader.EndOfStream;
                while(!__tmp76_last)
                {
                    string __tmp76_line = __tmp76Reader.ReadLine();
                    __tmp76_last = __tmp76Reader.EndOfStream;
                    if ((__tmp76_last && !string.IsNullOrEmpty(__tmp76_line)) || (!__tmp76_last && __tmp76_line != null))
                    {
                        __out.Append(__tmp76_line);
                        __tmp74_outputWritten = true;
                    }
                    if (!__tmp76_last) __out.AppendLine(true);
                }
            }
            string __tmp77_line = "();"; //164:59
            if (!string.IsNullOrEmpty(__tmp77_line))
            {
                __out.Append(__tmp77_line);
                __tmp74_outputWritten = true;
            }
            if (__tmp74_outputWritten) __out.AppendLine(true);
            if (__tmp74_outputWritten)
            {
                __out.AppendLine(false); //164:62
            }
            bool __tmp79_outputWritten = false;
            string __tmp80_line = "		MModel = "; //165:1
            if (!string.IsNullOrEmpty(__tmp80_line))
            {
                __out.Append(__tmp80_line);
                __tmp79_outputWritten = true;
            }
            StringBuilder __tmp81 = new StringBuilder();
            __tmp81.Append(CSharpName(model, ModelKind.BuilderInstance));
            using(StreamReader __tmp81Reader = new StreamReader(this.__ToStream(__tmp81.ToString())))
            {
                bool __tmp81_last = __tmp81Reader.EndOfStream;
                while(!__tmp81_last)
                {
                    string __tmp81_line = __tmp81Reader.ReadLine();
                    __tmp81_last = __tmp81Reader.EndOfStream;
                    if ((__tmp81_last && !string.IsNullOrEmpty(__tmp81_line)) || (!__tmp81_last && __tmp81_line != null))
                    {
                        __out.Append(__tmp81_line);
                        __tmp79_outputWritten = true;
                    }
                    if (!__tmp81_last) __out.AppendLine(true);
                }
            }
            string __tmp82_line = ".instance.MModel.ToImmutable();"; //165:57
            if (!string.IsNullOrEmpty(__tmp82_line))
            {
                __out.Append(__tmp82_line);
                __tmp79_outputWritten = true;
            }
            if (__tmp79_outputWritten) __out.AppendLine(true);
            if (__tmp79_outputWritten)
            {
                __out.AppendLine(false); //165:88
            }
            __out.AppendLine(true); //166:1
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //167:9
                from cst in __Enumerate((__loop10_var1).GetEnumerator()).OfType<MetaConstant>() //167:39
                select new { __loop10_var1 = __loop10_var1, cst = cst}
                ).ToList(); //167:4
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp83 = __loop10_results[__loop10_iteration];
                var __loop10_var1 = __tmp83.__loop10_var1;
                var cst = __tmp83.cst;
                if (metaMetaModel) //168:5
                {
                    bool __tmp85_outputWritten = false;
                    string __tmp84Prefix = "		"; //169:1
                    StringBuilder __tmp86 = new StringBuilder();
                    __tmp86.Append(CSharpName(cst, model, ClassKind.ImmutableInstance));
                    using(StreamReader __tmp86Reader = new StreamReader(this.__ToStream(__tmp86.ToString())))
                    {
                        bool __tmp86_last = __tmp86Reader.EndOfStream;
                        while(!__tmp86_last)
                        {
                            string __tmp86_line = __tmp86Reader.ReadLine();
                            __tmp86_last = __tmp86Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp84Prefix))
                            {
                                __out.Append(__tmp84Prefix);
                                __tmp85_outputWritten = true;
                            }
                            if ((__tmp86_last && !string.IsNullOrEmpty(__tmp86_line)) || (!__tmp86_last && __tmp86_line != null))
                            {
                                __out.Append(__tmp86_line);
                                __tmp85_outputWritten = true;
                            }
                            if (!__tmp86_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp87_line = " = "; //169:55
                    if (!string.IsNullOrEmpty(__tmp87_line))
                    {
                        __out.Append(__tmp87_line);
                        __tmp85_outputWritten = true;
                    }
                    StringBuilder __tmp88 = new StringBuilder();
                    __tmp88.Append(CSharpName(cst, model, ClassKind.BuilderInstance, true));
                    using(StreamReader __tmp88Reader = new StreamReader(this.__ToStream(__tmp88.ToString())))
                    {
                        bool __tmp88_last = __tmp88Reader.EndOfStream;
                        while(!__tmp88_last)
                        {
                            string __tmp88_line = __tmp88Reader.ReadLine();
                            __tmp88_last = __tmp88Reader.EndOfStream;
                            if ((__tmp88_last && !string.IsNullOrEmpty(__tmp88_line)) || (!__tmp88_last && __tmp88_line != null))
                            {
                                __out.Append(__tmp88_line);
                                __tmp85_outputWritten = true;
                            }
                            if (!__tmp88_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp89_line = ".ToImmutable(MModel);"; //169:114
                    if (!string.IsNullOrEmpty(__tmp89_line))
                    {
                        __out.Append(__tmp89_line);
                        __tmp85_outputWritten = true;
                    }
                    if (__tmp85_outputWritten) __out.AppendLine(true);
                    if (__tmp85_outputWritten)
                    {
                        __out.AppendLine(false); //169:135
                    }
                }
                else //170:5
                {
                    bool __tmp91_outputWritten = false;
                    string __tmp90Prefix = "		"; //171:1
                    StringBuilder __tmp92 = new StringBuilder();
                    __tmp92.Append(CSharpName(cst, model, ClassKind.ImmutableInstance));
                    using(StreamReader __tmp92Reader = new StreamReader(this.__ToStream(__tmp92.ToString())))
                    {
                        bool __tmp92_last = __tmp92Reader.EndOfStream;
                        while(!__tmp92_last)
                        {
                            string __tmp92_line = __tmp92Reader.ReadLine();
                            __tmp92_last = __tmp92Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp90Prefix))
                            {
                                __out.Append(__tmp90Prefix);
                                __tmp91_outputWritten = true;
                            }
                            if ((__tmp92_last && !string.IsNullOrEmpty(__tmp92_line)) || (!__tmp92_last && __tmp92_line != null))
                            {
                                __out.Append(__tmp92_line);
                                __tmp91_outputWritten = true;
                            }
                            if (!__tmp92_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp93_line = " = "; //171:55
                    if (!string.IsNullOrEmpty(__tmp93_line))
                    {
                        __out.Append(__tmp93_line);
                        __tmp91_outputWritten = true;
                    }
                    StringBuilder __tmp94 = new StringBuilder();
                    __tmp94.Append(CSharpName(cst, model, ClassKind.BuilderInstance, true));
                    using(StreamReader __tmp94Reader = new StreamReader(this.__ToStream(__tmp94.ToString())))
                    {
                        bool __tmp94_last = __tmp94Reader.EndOfStream;
                        while(!__tmp94_last)
                        {
                            string __tmp94_line = __tmp94Reader.ReadLine();
                            __tmp94_last = __tmp94Reader.EndOfStream;
                            if ((__tmp94_last && !string.IsNullOrEmpty(__tmp94_line)) || (!__tmp94_last && __tmp94_line != null))
                            {
                                __out.Append(__tmp94_line);
                                __tmp91_outputWritten = true;
                            }
                            if (!__tmp94_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp95_line = ".ToImmutable(MModel);"; //171:114
                    if (!string.IsNullOrEmpty(__tmp95_line))
                    {
                        __out.Append(__tmp95_line);
                        __tmp91_outputWritten = true;
                    }
                    if (__tmp91_outputWritten) __out.AppendLine(true);
                    if (__tmp91_outputWritten)
                    {
                        __out.AppendLine(false); //171:135
                    }
                }
            }
            __out.AppendLine(true); //174:1
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //175:9
                from cls in __Enumerate((__loop11_var1).GetEnumerator()).OfType<MetaClass>() //175:39
                select new { __loop11_var1 = __loop11_var1, cls = cls}
                ).ToList(); //175:4
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp96 = __loop11_results[__loop11_iteration];
                var __loop11_var1 = __tmp96.__loop11_var1;
                var cls = __tmp96.cls;
                bool __tmp98_outputWritten = false;
                string __tmp97Prefix = "		"; //176:1
                StringBuilder __tmp99 = new StringBuilder();
                __tmp99.Append(CSharpName(cls, model, ClassKind.ImmutableInstance));
                using(StreamReader __tmp99Reader = new StreamReader(this.__ToStream(__tmp99.ToString())))
                {
                    bool __tmp99_last = __tmp99Reader.EndOfStream;
                    while(!__tmp99_last)
                    {
                        string __tmp99_line = __tmp99Reader.ReadLine();
                        __tmp99_last = __tmp99Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp97Prefix))
                        {
                            __out.Append(__tmp97Prefix);
                            __tmp98_outputWritten = true;
                        }
                        if ((__tmp99_last && !string.IsNullOrEmpty(__tmp99_line)) || (!__tmp99_last && __tmp99_line != null))
                        {
                            __out.Append(__tmp99_line);
                            __tmp98_outputWritten = true;
                        }
                        if (!__tmp99_last) __out.AppendLine(true);
                    }
                }
                string __tmp100_line = " = "; //176:55
                if (!string.IsNullOrEmpty(__tmp100_line))
                {
                    __out.Append(__tmp100_line);
                    __tmp98_outputWritten = true;
                }
                StringBuilder __tmp101 = new StringBuilder();
                __tmp101.Append(CSharpName(cls, model, ClassKind.BuilderInstance, true));
                using(StreamReader __tmp101Reader = new StreamReader(this.__ToStream(__tmp101.ToString())))
                {
                    bool __tmp101_last = __tmp101Reader.EndOfStream;
                    while(!__tmp101_last)
                    {
                        string __tmp101_line = __tmp101Reader.ReadLine();
                        __tmp101_last = __tmp101Reader.EndOfStream;
                        if ((__tmp101_last && !string.IsNullOrEmpty(__tmp101_line)) || (!__tmp101_last && __tmp101_line != null))
                        {
                            __out.Append(__tmp101_line);
                            __tmp98_outputWritten = true;
                        }
                        if (!__tmp101_last) __out.AppendLine(true);
                    }
                }
                string __tmp102_line = ".ToImmutable(MModel);"; //176:114
                if (!string.IsNullOrEmpty(__tmp102_line))
                {
                    __out.Append(__tmp102_line);
                    __tmp98_outputWritten = true;
                }
                if (__tmp98_outputWritten) __out.AppendLine(true);
                if (__tmp98_outputWritten)
                {
                    __out.AppendLine(false); //176:135
                }
                var __loop12_results = 
                    (from __loop12_var1 in __Enumerate((cls).GetEnumerator()) //177:10
                    from prop in __Enumerate((__loop12_var1.Properties).GetEnumerator()) //177:15
                    select new { __loop12_var1 = __loop12_var1, prop = prop}
                    ).ToList(); //177:5
                for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
                {
                    var __tmp103 = __loop12_results[__loop12_iteration];
                    var __loop12_var1 = __tmp103.__loop12_var1;
                    var prop = __tmp103.prop;
                    bool __tmp105_outputWritten = false;
                    string __tmp104Prefix = "		"; //178:1
                    StringBuilder __tmp106 = new StringBuilder();
                    __tmp106.Append(CSharpName(prop, model, PropertyKind.ImmutableInstance));
                    using(StreamReader __tmp106Reader = new StreamReader(this.__ToStream(__tmp106.ToString())))
                    {
                        bool __tmp106_last = __tmp106Reader.EndOfStream;
                        while(!__tmp106_last)
                        {
                            string __tmp106_line = __tmp106Reader.ReadLine();
                            __tmp106_last = __tmp106Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp104Prefix))
                            {
                                __out.Append(__tmp104Prefix);
                                __tmp105_outputWritten = true;
                            }
                            if ((__tmp106_last && !string.IsNullOrEmpty(__tmp106_line)) || (!__tmp106_last && __tmp106_line != null))
                            {
                                __out.Append(__tmp106_line);
                                __tmp105_outputWritten = true;
                            }
                            if (!__tmp106_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp107_line = " = "; //178:59
                    if (!string.IsNullOrEmpty(__tmp107_line))
                    {
                        __out.Append(__tmp107_line);
                        __tmp105_outputWritten = true;
                    }
                    StringBuilder __tmp108 = new StringBuilder();
                    __tmp108.Append(CSharpName(prop, model, PropertyKind.BuilderInstance, true));
                    using(StreamReader __tmp108Reader = new StreamReader(this.__ToStream(__tmp108.ToString())))
                    {
                        bool __tmp108_last = __tmp108Reader.EndOfStream;
                        while(!__tmp108_last)
                        {
                            string __tmp108_line = __tmp108Reader.ReadLine();
                            __tmp108_last = __tmp108Reader.EndOfStream;
                            if ((__tmp108_last && !string.IsNullOrEmpty(__tmp108_line)) || (!__tmp108_last && __tmp108_line != null))
                            {
                                __out.Append(__tmp108_line);
                                __tmp105_outputWritten = true;
                            }
                            if (!__tmp108_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp109_line = ".ToImmutable(MModel);"; //178:122
                    if (!string.IsNullOrEmpty(__tmp109_line))
                    {
                        __out.Append(__tmp109_line);
                        __tmp105_outputWritten = true;
                    }
                    if (__tmp105_outputWritten) __out.AppendLine(true);
                    if (__tmp105_outputWritten)
                    {
                        __out.AppendLine(false); //178:143
                    }
                }
            }
            __out.AppendLine(true); //181:1
            bool __tmp111_outputWritten = false;
            string __tmp110Prefix = "		"; //182:1
            StringBuilder __tmp112 = new StringBuilder();
            __tmp112.Append(CSharpName(model, ModelKind.ImmutableInstance));
            using(StreamReader __tmp112Reader = new StreamReader(this.__ToStream(__tmp112.ToString())))
            {
                bool __tmp112_last = __tmp112Reader.EndOfStream;
                while(!__tmp112_last)
                {
                    string __tmp112_line = __tmp112Reader.ReadLine();
                    __tmp112_last = __tmp112Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp110Prefix))
                    {
                        __out.Append(__tmp110Prefix);
                        __tmp111_outputWritten = true;
                    }
                    if ((__tmp112_last && !string.IsNullOrEmpty(__tmp112_line)) || (!__tmp112_last && __tmp112_line != null))
                    {
                        __out.Append(__tmp112_line);
                        __tmp111_outputWritten = true;
                    }
                    if (!__tmp112_last) __out.AppendLine(true);
                }
            }
            string __tmp113_line = ".initialized = true;"; //182:50
            if (!string.IsNullOrEmpty(__tmp113_line))
            {
                __out.Append(__tmp113_line);
                __tmp111_outputWritten = true;
            }
            if (__tmp111_outputWritten) __out.AppendLine(true);
            if (__tmp111_outputWritten)
            {
                __out.AppendLine(false); //182:70
            }
            __out.Append("	}"); //183:1
            __out.AppendLine(false); //183:3
            __out.Append("}"); //184:1
            __out.AppendLine(false); //184:2
            return __out.ToString();
        }

        public string GenerateMetaModelBuilderInstance(MetaModel model) //187:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //188:2
            bool metaMetaModel = IsMetaMetaModel(model); //189:2
            ImmutableList<ImmutableObject> instances = GetInstances(model); //190:2
            ImmutableDictionary<ImmutableObject,string> instanceNames = GetInstanceNames(model); //191:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //192:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(CSharpName(model, ModelKind.BuilderInstance));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //192:61
            }
            __out.Append("{"); //193:1
            __out.AppendLine(false); //193:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	internal static "; //194:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(CSharpName(model, ModelKind.BuilderInstance));
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp6_outputWritten = true;
                    }
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9_line = " instance = new "; //194:63
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(CSharpName(model, ModelKind.BuilderInstance));
            using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
            {
                bool __tmp10_last = __tmp10Reader.EndOfStream;
                while(!__tmp10_last)
                {
                    string __tmp10_line = __tmp10Reader.ReadLine();
                    __tmp10_last = __tmp10Reader.EndOfStream;
                    if ((__tmp10_last && !string.IsNullOrEmpty(__tmp10_line)) || (!__tmp10_last && __tmp10_line != null))
                    {
                        __out.Append(__tmp10_line);
                        __tmp6_outputWritten = true;
                    }
                    if (!__tmp10_last) __out.AppendLine(true);
                }
            }
            string __tmp11_line = "();"; //194:124
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Append(__tmp11_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //194:127
            }
            __out.AppendLine(true); //195:1
            __out.Append("	private bool creating;"); //196:1
            __out.AppendLine(false); //196:24
            __out.Append("	private bool created;"); //197:1
            __out.AppendLine(false); //197:23
            bool __tmp13_outputWritten = false;
            string __tmp14_line = "	internal "; //198:1
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp13_outputWritten = true;
            }
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(Properties.CoreNs);
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_last = __tmp15Reader.EndOfStream;
                while(!__tmp15_last)
                {
                    string __tmp15_line = __tmp15Reader.ReadLine();
                    __tmp15_last = __tmp15Reader.EndOfStream;
                    if ((__tmp15_last && !string.IsNullOrEmpty(__tmp15_line)) || (!__tmp15_last && __tmp15_line != null))
                    {
                        __out.Append(__tmp15_line);
                        __tmp13_outputWritten = true;
                    }
                    if (!__tmp15_last) __out.AppendLine(true);
                }
            }
            string __tmp16_line = ".MutableModel MModel;"; //198:30
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Append(__tmp16_line);
                __tmp13_outputWritten = true;
            }
            if (__tmp13_outputWritten) __out.AppendLine(true);
            if (__tmp13_outputWritten)
            {
                __out.AppendLine(false); //198:51
            }
            if (!metaMetaModel) //199:3
            {
                bool __tmp18_outputWritten = false;
                string __tmp19_line = "	internal "; //200:1
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Append(__tmp19_line);
                    __tmp18_outputWritten = true;
                }
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(Properties.CoreNs);
                using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                {
                    bool __tmp20_last = __tmp20Reader.EndOfStream;
                    while(!__tmp20_last)
                    {
                        string __tmp20_line = __tmp20Reader.ReadLine();
                        __tmp20_last = __tmp20Reader.EndOfStream;
                        if ((__tmp20_last && !string.IsNullOrEmpty(__tmp20_line)) || (!__tmp20_last && __tmp20_line != null))
                        {
                            __out.Append(__tmp20_line);
                            __tmp18_outputWritten = true;
                        }
                        if (!__tmp20_last) __out.AppendLine(true);
                    }
                }
                string __tmp21_line = ".MutableModelGroup MModelGroup;"; //200:30
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp18_outputWritten = true;
                }
                if (__tmp18_outputWritten) __out.AppendLine(true);
                if (__tmp18_outputWritten)
                {
                    __out.AppendLine(false); //200:61
                }
            }
            __out.AppendLine(true); //202:1
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //203:8
                from cst in __Enumerate((__loop13_var1).GetEnumerator()).OfType<MetaConstant>() //203:38
                select new { __loop13_var1 = __loop13_var1, cst = cst}
                ).ToList(); //203:3
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp22 = __loop13_results[__loop13_iteration];
                var __loop13_var1 = __tmp22.__loop13_var1;
                var cst = __tmp22.cst;
                bool __tmp24_outputWritten = false;
                string __tmp23Prefix = "	"; //204:1
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(GenerateDocumentation(cst));
                using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
                {
                    bool __tmp25_last = __tmp25Reader.EndOfStream;
                    while(!__tmp25_last)
                    {
                        string __tmp25_line = __tmp25Reader.ReadLine();
                        __tmp25_last = __tmp25Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp23Prefix))
                        {
                            __out.Append(__tmp23Prefix);
                            __tmp24_outputWritten = true;
                        }
                        if ((__tmp25_last && !string.IsNullOrEmpty(__tmp25_line)) || (!__tmp25_last && __tmp25_line != null))
                        {
                            __out.Append(__tmp25_line);
                            __tmp24_outputWritten = true;
                        }
                        if (!__tmp25_last || __tmp24_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //204:30
                }
                if (metaMetaModel) //205:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "	internal "; //206:1
                    if (!string.IsNullOrEmpty(__tmp28_line))
                    {
                        __out.Append(__tmp28_line);
                        __tmp27_outputWritten = true;
                    }
                    StringBuilder __tmp29 = new StringBuilder();
                    __tmp29.Append(CSharpName(cst.Type, model, ClassKind.Builder));
                    using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                    {
                        bool __tmp29_last = __tmp29Reader.EndOfStream;
                        while(!__tmp29_last)
                        {
                            string __tmp29_line = __tmp29Reader.ReadLine();
                            __tmp29_last = __tmp29Reader.EndOfStream;
                            if ((__tmp29_last && !string.IsNullOrEmpty(__tmp29_line)) || (!__tmp29_last && __tmp29_line != null))
                            {
                                __out.Append(__tmp29_line);
                                __tmp27_outputWritten = true;
                            }
                            if (!__tmp29_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp30_line = " "; //206:58
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Append(__tmp30_line);
                        __tmp27_outputWritten = true;
                    }
                    StringBuilder __tmp31 = new StringBuilder();
                    __tmp31.Append(CSharpName(cst, model, ClassKind.BuilderInstance));
                    using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
                    {
                        bool __tmp31_last = __tmp31Reader.EndOfStream;
                        while(!__tmp31_last)
                        {
                            string __tmp31_line = __tmp31Reader.ReadLine();
                            __tmp31_last = __tmp31Reader.EndOfStream;
                            if ((__tmp31_last && !string.IsNullOrEmpty(__tmp31_line)) || (!__tmp31_last && __tmp31_line != null))
                            {
                                __out.Append(__tmp31_line);
                                __tmp27_outputWritten = true;
                            }
                            if (!__tmp31_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp32_line = " = null;"; //206:109
                    if (!string.IsNullOrEmpty(__tmp32_line))
                    {
                        __out.Append(__tmp32_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //206:117
                    }
                }
                else //207:4
                {
                    bool __tmp34_outputWritten = false;
                    string __tmp35_line = "	internal "; //208:1
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Append(__tmp35_line);
                        __tmp34_outputWritten = true;
                    }
                    StringBuilder __tmp36 = new StringBuilder();
                    __tmp36.Append(CSharpName(cst.Type, model, ClassKind.Builder, true));
                    using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                    {
                        bool __tmp36_last = __tmp36Reader.EndOfStream;
                        while(!__tmp36_last)
                        {
                            string __tmp36_line = __tmp36Reader.ReadLine();
                            __tmp36_last = __tmp36Reader.EndOfStream;
                            if ((__tmp36_last && !string.IsNullOrEmpty(__tmp36_line)) || (!__tmp36_last && __tmp36_line != null))
                            {
                                __out.Append(__tmp36_line);
                                __tmp34_outputWritten = true;
                            }
                            if (!__tmp36_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp37_line = " "; //208:64
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Append(__tmp37_line);
                        __tmp34_outputWritten = true;
                    }
                    StringBuilder __tmp38 = new StringBuilder();
                    __tmp38.Append(CSharpName(cst, model, ClassKind.BuilderInstance));
                    using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                    {
                        bool __tmp38_last = __tmp38Reader.EndOfStream;
                        while(!__tmp38_last)
                        {
                            string __tmp38_line = __tmp38Reader.ReadLine();
                            __tmp38_last = __tmp38Reader.EndOfStream;
                            if ((__tmp38_last && !string.IsNullOrEmpty(__tmp38_line)) || (!__tmp38_last && __tmp38_line != null))
                            {
                                __out.Append(__tmp38_line);
                                __tmp34_outputWritten = true;
                            }
                            if (!__tmp38_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp39_line = " = null;"; //208:115
                    if (!string.IsNullOrEmpty(__tmp39_line))
                    {
                        __out.Append(__tmp39_line);
                        __tmp34_outputWritten = true;
                    }
                    if (__tmp34_outputWritten) __out.AppendLine(true);
                    if (__tmp34_outputWritten)
                    {
                        __out.AppendLine(false); //208:123
                    }
                }
            }
            __out.AppendLine(true); //211:1
            var __loop14_results = 
                (from obj in __Enumerate((instances).GetEnumerator()) //212:8
                select new { obj = obj}
                ).ToList(); //212:3
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp40 = __loop14_results[__loop14_iteration];
                var obj = __tmp40.obj;
                bool __tmp42_outputWritten = false;
                string __tmp41Prefix = "	"; //213:1
                StringBuilder __tmp43 = new StringBuilder();
                __tmp43.Append(GenerateInstanceDeclaration(model, metaMetaModel, obj, instanceNames));
                using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
                {
                    bool __tmp43_last = __tmp43Reader.EndOfStream;
                    while(!__tmp43_last)
                    {
                        string __tmp43_line = __tmp43Reader.ReadLine();
                        __tmp43_last = __tmp43Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp41Prefix))
                        {
                            __out.Append(__tmp41Prefix);
                            __tmp42_outputWritten = true;
                        }
                        if ((__tmp43_last && !string.IsNullOrEmpty(__tmp43_line)) || (!__tmp43_last && __tmp43_line != null))
                        {
                            __out.Append(__tmp43_line);
                            __tmp42_outputWritten = true;
                        }
                        if (!__tmp43_last || __tmp42_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp42_outputWritten)
                {
                    __out.AppendLine(false); //213:73
                }
            }
            __out.AppendLine(true); //215:1
            bool __tmp45_outputWritten = false;
            string __tmp46_line = "	internal "; //216:1
            if (!string.IsNullOrEmpty(__tmp46_line))
            {
                __out.Append(__tmp46_line);
                __tmp45_outputWritten = true;
            }
            StringBuilder __tmp47 = new StringBuilder();
            __tmp47.Append(CSharpName(model, ModelKind.BuilderInstance));
            using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
            {
                bool __tmp47_last = __tmp47Reader.EndOfStream;
                while(!__tmp47_last)
                {
                    string __tmp47_line = __tmp47Reader.ReadLine();
                    __tmp47_last = __tmp47Reader.EndOfStream;
                    if ((__tmp47_last && !string.IsNullOrEmpty(__tmp47_line)) || (!__tmp47_last && __tmp47_line != null))
                    {
                        __out.Append(__tmp47_line);
                        __tmp45_outputWritten = true;
                    }
                    if (!__tmp47_last) __out.AppendLine(true);
                }
            }
            string __tmp48_line = "()"; //216:56
            if (!string.IsNullOrEmpty(__tmp48_line))
            {
                __out.Append(__tmp48_line);
                __tmp45_outputWritten = true;
            }
            if (__tmp45_outputWritten) __out.AppendLine(true);
            if (__tmp45_outputWritten)
            {
                __out.AppendLine(false); //216:58
            }
            __out.Append("	{"); //217:1
            __out.AppendLine(false); //217:3
            if (metaMetaModel) //218:4
            {
                bool __tmp50_outputWritten = false;
                string __tmp51_line = "		this.MModel = new "; //219:1
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Append(__tmp51_line);
                    __tmp50_outputWritten = true;
                }
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(Properties.CoreNs);
                using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                {
                    bool __tmp52_last = __tmp52Reader.EndOfStream;
                    while(!__tmp52_last)
                    {
                        string __tmp52_line = __tmp52Reader.ReadLine();
                        __tmp52_last = __tmp52Reader.EndOfStream;
                        if ((__tmp52_last && !string.IsNullOrEmpty(__tmp52_line)) || (!__tmp52_last && __tmp52_line != null))
                        {
                            __out.Append(__tmp52_line);
                            __tmp50_outputWritten = true;
                        }
                        if (!__tmp52_last) __out.AppendLine(true);
                    }
                }
                string __tmp53_line = ".MutableModel(\""; //219:40
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp50_outputWritten = true;
                }
                StringBuilder __tmp54 = new StringBuilder();
                __tmp54.Append(model.Name);
                using(StreamReader __tmp54Reader = new StreamReader(this.__ToStream(__tmp54.ToString())))
                {
                    bool __tmp54_last = __tmp54Reader.EndOfStream;
                    while(!__tmp54_last)
                    {
                        string __tmp54_line = __tmp54Reader.ReadLine();
                        __tmp54_last = __tmp54Reader.EndOfStream;
                        if ((__tmp54_last && !string.IsNullOrEmpty(__tmp54_line)) || (!__tmp54_last && __tmp54_line != null))
                        {
                            __out.Append(__tmp54_line);
                            __tmp50_outputWritten = true;
                        }
                        if (!__tmp54_last) __out.AppendLine(true);
                    }
                }
                string __tmp55_line = "\");"; //219:67
                if (!string.IsNullOrEmpty(__tmp55_line))
                {
                    __out.Append(__tmp55_line);
                    __tmp50_outputWritten = true;
                }
                if (__tmp50_outputWritten) __out.AppendLine(true);
                if (__tmp50_outputWritten)
                {
                    __out.AppendLine(false); //219:70
                }
            }
            else //220:4
            {
                bool __tmp57_outputWritten = false;
                string __tmp58_line = "		this.MModelGroup = new "; //221:1
                if (!string.IsNullOrEmpty(__tmp58_line))
                {
                    __out.Append(__tmp58_line);
                    __tmp57_outputWritten = true;
                }
                StringBuilder __tmp59 = new StringBuilder();
                __tmp59.Append(Properties.CoreNs);
                using(StreamReader __tmp59Reader = new StreamReader(this.__ToStream(__tmp59.ToString())))
                {
                    bool __tmp59_last = __tmp59Reader.EndOfStream;
                    while(!__tmp59_last)
                    {
                        string __tmp59_line = __tmp59Reader.ReadLine();
                        __tmp59_last = __tmp59Reader.EndOfStream;
                        if ((__tmp59_last && !string.IsNullOrEmpty(__tmp59_line)) || (!__tmp59_last && __tmp59_line != null))
                        {
                            __out.Append(__tmp59_line);
                            __tmp57_outputWritten = true;
                        }
                        if (!__tmp59_last) __out.AppendLine(true);
                    }
                }
                string __tmp60_line = ".MutableModelGroup();"; //221:45
                if (!string.IsNullOrEmpty(__tmp60_line))
                {
                    __out.Append(__tmp60_line);
                    __tmp57_outputWritten = true;
                }
                if (__tmp57_outputWritten) __out.AppendLine(true);
                if (__tmp57_outputWritten)
                {
                    __out.AppendLine(false); //221:66
                }
                bool __tmp62_outputWritten = false;
                string __tmp63_line = "		this.MModelGroup.AddReference("; //222:1
                if (!string.IsNullOrEmpty(__tmp63_line))
                {
                    __out.Append(__tmp63_line);
                    __tmp62_outputWritten = true;
                }
                StringBuilder __tmp64 = new StringBuilder();
                __tmp64.Append(Properties.MetaNs);
                using(StreamReader __tmp64Reader = new StreamReader(this.__ToStream(__tmp64.ToString())))
                {
                    bool __tmp64_last = __tmp64Reader.EndOfStream;
                    while(!__tmp64_last)
                    {
                        string __tmp64_line = __tmp64Reader.ReadLine();
                        __tmp64_last = __tmp64Reader.EndOfStream;
                        if ((__tmp64_last && !string.IsNullOrEmpty(__tmp64_line)) || (!__tmp64_last && __tmp64_line != null))
                        {
                            __out.Append(__tmp64_line);
                            __tmp62_outputWritten = true;
                        }
                        if (!__tmp64_last) __out.AppendLine(true);
                    }
                }
                string __tmp65_line = ".MetaInstance.MModel.ToMutable(true));"; //222:52
                if (!string.IsNullOrEmpty(__tmp65_line))
                {
                    __out.Append(__tmp65_line);
                    __tmp62_outputWritten = true;
                }
                if (__tmp62_outputWritten) __out.AppendLine(true);
                if (__tmp62_outputWritten)
                {
                    __out.AppendLine(false); //222:90
                }
                bool __tmp67_outputWritten = false;
                string __tmp68_line = "		this.MModel = this.MModelGroup.CreateModel(\""; //223:1
                if (!string.IsNullOrEmpty(__tmp68_line))
                {
                    __out.Append(__tmp68_line);
                    __tmp67_outputWritten = true;
                }
                StringBuilder __tmp69 = new StringBuilder();
                __tmp69.Append(CSharpName(model));
                using(StreamReader __tmp69Reader = new StreamReader(this.__ToStream(__tmp69.ToString())))
                {
                    bool __tmp69_last = __tmp69Reader.EndOfStream;
                    while(!__tmp69_last)
                    {
                        string __tmp69_line = __tmp69Reader.ReadLine();
                        __tmp69_last = __tmp69Reader.EndOfStream;
                        if ((__tmp69_last && !string.IsNullOrEmpty(__tmp69_line)) || (!__tmp69_last && __tmp69_line != null))
                        {
                            __out.Append(__tmp69_line);
                            __tmp67_outputWritten = true;
                        }
                        if (!__tmp69_last) __out.AppendLine(true);
                    }
                }
                string __tmp70_line = "\");"; //223:67
                if (!string.IsNullOrEmpty(__tmp70_line))
                {
                    __out.Append(__tmp70_line);
                    __tmp67_outputWritten = true;
                }
                if (__tmp67_outputWritten) __out.AppendLine(true);
                if (__tmp67_outputWritten)
                {
                    __out.AppendLine(false); //223:70
                }
            }
            __out.Append("	}"); //225:1
            __out.AppendLine(false); //225:3
            __out.AppendLine(true); //226:1
            __out.Append("	internal void Create()"); //227:1
            __out.AppendLine(false); //227:24
            __out.Append("	{"); //228:1
            __out.AppendLine(false); //228:3
            __out.Append("		lock (this)"); //229:1
            __out.AppendLine(false); //229:14
            __out.Append("		{"); //230:1
            __out.AppendLine(false); //230:4
            __out.Append("			if (this.creating || this.created) return;"); //231:1
            __out.AppendLine(false); //231:46
            __out.Append("			this.creating = true;"); //232:1
            __out.AppendLine(false); //232:25
            __out.Append("		}"); //233:1
            __out.AppendLine(false); //233:4
            __out.Append("		this.CreateInstances();"); //234:1
            __out.AppendLine(false); //234:26
            bool __tmp72_outputWritten = false;
            string __tmp71Prefix = "		"; //235:1
            StringBuilder __tmp73 = new StringBuilder();
            __tmp73.Append(CSharpName(model, ModelKind.ImplementationProvider));
            using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
            {
                bool __tmp73_last = __tmp73Reader.EndOfStream;
                while(!__tmp73_last)
                {
                    string __tmp73_line = __tmp73Reader.ReadLine();
                    __tmp73_last = __tmp73Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp71Prefix))
                    {
                        __out.Append(__tmp71Prefix);
                        __tmp72_outputWritten = true;
                    }
                    if ((__tmp73_last && !string.IsNullOrEmpty(__tmp73_line)) || (!__tmp73_last && __tmp73_line != null))
                    {
                        __out.Append(__tmp73_line);
                        __tmp72_outputWritten = true;
                    }
                    if (!__tmp73_last) __out.AppendLine(true);
                }
            }
            string __tmp74_line = ".Implementation."; //235:55
            if (!string.IsNullOrEmpty(__tmp74_line))
            {
                __out.Append(__tmp74_line);
                __tmp72_outputWritten = true;
            }
            StringBuilder __tmp75 = new StringBuilder();
            __tmp75.Append(CSharpName(model, ModelKind.BuilderInstance));
            using(StreamReader __tmp75Reader = new StreamReader(this.__ToStream(__tmp75.ToString())))
            {
                bool __tmp75_last = __tmp75Reader.EndOfStream;
                while(!__tmp75_last)
                {
                    string __tmp75_line = __tmp75Reader.ReadLine();
                    __tmp75_last = __tmp75Reader.EndOfStream;
                    if ((__tmp75_last && !string.IsNullOrEmpty(__tmp75_line)) || (!__tmp75_last && __tmp75_line != null))
                    {
                        __out.Append(__tmp75_line);
                        __tmp72_outputWritten = true;
                    }
                    if (!__tmp75_last) __out.AppendLine(true);
                }
            }
            string __tmp76_line = "(this);"; //235:116
            if (!string.IsNullOrEmpty(__tmp76_line))
            {
                __out.Append(__tmp76_line);
                __tmp72_outputWritten = true;
            }
            if (__tmp72_outputWritten) __out.AppendLine(true);
            if (__tmp72_outputWritten)
            {
                __out.AppendLine(false); //235:123
            }
            __out.Append("        foreach (global::MetaDslx.Modeling.MutableObject obj in this.MModel.Objects)"); //236:1
            __out.AppendLine(false); //236:85
            __out.Append("        {"); //237:1
            __out.AppendLine(false); //237:10
            __out.Append("            obj.MMakeCreated();"); //238:1
            __out.AppendLine(false); //238:32
            __out.Append("        }"); //239:1
            __out.AppendLine(false); //239:10
            __out.Append("		lock (this)"); //240:1
            __out.AppendLine(false); //240:14
            __out.Append("		{"); //241:1
            __out.AppendLine(false); //241:4
            __out.Append("			this.created = true;"); //242:1
            __out.AppendLine(false); //242:24
            __out.Append("		}"); //243:1
            __out.AppendLine(false); //243:4
            __out.Append("	}"); //244:1
            __out.AppendLine(false); //244:3
            __out.AppendLine(true); //245:1
            __out.Append("	internal void EvaluateLazyValues()"); //246:1
            __out.AppendLine(false); //246:36
            __out.Append("	{"); //247:1
            __out.AppendLine(false); //247:3
            __out.Append("		if (!this.created) return;"); //248:1
            __out.AppendLine(false); //248:29
            __out.Append("		this.MModel.EvaluateLazyValues();"); //249:1
            __out.AppendLine(false); //249:36
            __out.Append("	}"); //250:1
            __out.AppendLine(false); //250:3
            __out.AppendLine(true); //251:1
            __out.Append("	private void CreateInstances()"); //252:1
            __out.AppendLine(false); //252:32
            __out.Append("	{"); //253:1
            __out.AppendLine(false); //253:3
            bool __tmp78_outputWritten = false;
            string __tmp77Prefix = "		"; //254:1
            StringBuilder __tmp79 = new StringBuilder();
            __tmp79.Append(Properties.MetaNs);
            using(StreamReader __tmp79Reader = new StreamReader(this.__ToStream(__tmp79.ToString())))
            {
                bool __tmp79_last = __tmp79Reader.EndOfStream;
                while(!__tmp79_last)
                {
                    string __tmp79_line = __tmp79Reader.ReadLine();
                    __tmp79_last = __tmp79Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp77Prefix))
                    {
                        __out.Append(__tmp77Prefix);
                        __tmp78_outputWritten = true;
                    }
                    if ((__tmp79_last && !string.IsNullOrEmpty(__tmp79_line)) || (!__tmp79_last && __tmp79_line != null))
                    {
                        __out.Append(__tmp79_line);
                        __tmp78_outputWritten = true;
                    }
                    if (!__tmp79_last) __out.AppendLine(true);
                }
            }
            string __tmp80_line = ".MetaFactory factory = new "; //254:22
            if (!string.IsNullOrEmpty(__tmp80_line))
            {
                __out.Append(__tmp80_line);
                __tmp78_outputWritten = true;
            }
            StringBuilder __tmp81 = new StringBuilder();
            __tmp81.Append(Properties.MetaNs);
            using(StreamReader __tmp81Reader = new StreamReader(this.__ToStream(__tmp81.ToString())))
            {
                bool __tmp81_last = __tmp81Reader.EndOfStream;
                while(!__tmp81_last)
                {
                    string __tmp81_line = __tmp81Reader.ReadLine();
                    __tmp81_last = __tmp81Reader.EndOfStream;
                    if ((__tmp81_last && !string.IsNullOrEmpty(__tmp81_line)) || (!__tmp81_last && __tmp81_line != null))
                    {
                        __out.Append(__tmp81_line);
                        __tmp78_outputWritten = true;
                    }
                    if (!__tmp81_last) __out.AppendLine(true);
                }
            }
            string __tmp82_line = ".MetaFactory(this.MModel, "; //254:68
            if (!string.IsNullOrEmpty(__tmp82_line))
            {
                __out.Append(__tmp82_line);
                __tmp78_outputWritten = true;
            }
            StringBuilder __tmp83 = new StringBuilder();
            __tmp83.Append(Properties.CoreNs);
            using(StreamReader __tmp83Reader = new StreamReader(this.__ToStream(__tmp83.ToString())))
            {
                bool __tmp83_last = __tmp83Reader.EndOfStream;
                while(!__tmp83_last)
                {
                    string __tmp83_line = __tmp83Reader.ReadLine();
                    __tmp83_last = __tmp83Reader.EndOfStream;
                    if ((__tmp83_last && !string.IsNullOrEmpty(__tmp83_line)) || (!__tmp83_last && __tmp83_line != null))
                    {
                        __out.Append(__tmp83_line);
                        __tmp78_outputWritten = true;
                    }
                    if (!__tmp83_last) __out.AppendLine(true);
                }
            }
            string __tmp84_line = ".ModelFactoryFlags.DontMakeObjectsCreated);"; //254:113
            if (!string.IsNullOrEmpty(__tmp84_line))
            {
                __out.Append(__tmp84_line);
                __tmp78_outputWritten = true;
            }
            if (__tmp78_outputWritten) __out.AppendLine(true);
            if (__tmp78_outputWritten)
            {
                __out.AppendLine(false); //254:156
            }
            if (!metaMetaModel) //255:4
            {
                bool __tmp86_outputWritten = false;
                string __tmp85Prefix = "		"; //256:1
                StringBuilder __tmp87 = new StringBuilder();
                __tmp87.Append(CSharpName(model, ModelKind.Factory));
                using(StreamReader __tmp87Reader = new StreamReader(this.__ToStream(__tmp87.ToString())))
                {
                    bool __tmp87_last = __tmp87Reader.EndOfStream;
                    while(!__tmp87_last)
                    {
                        string __tmp87_line = __tmp87Reader.ReadLine();
                        __tmp87_last = __tmp87Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp85Prefix))
                        {
                            __out.Append(__tmp85Prefix);
                            __tmp86_outputWritten = true;
                        }
                        if ((__tmp87_last && !string.IsNullOrEmpty(__tmp87_line)) || (!__tmp87_last && __tmp87_line != null))
                        {
                            __out.Append(__tmp87_line);
                            __tmp86_outputWritten = true;
                        }
                        if (!__tmp87_last) __out.AppendLine(true);
                    }
                }
                string __tmp88_line = " constantFactory = new "; //256:40
                if (!string.IsNullOrEmpty(__tmp88_line))
                {
                    __out.Append(__tmp88_line);
                    __tmp86_outputWritten = true;
                }
                StringBuilder __tmp89 = new StringBuilder();
                __tmp89.Append(CSharpName(model, ModelKind.Factory));
                using(StreamReader __tmp89Reader = new StreamReader(this.__ToStream(__tmp89.ToString())))
                {
                    bool __tmp89_last = __tmp89Reader.EndOfStream;
                    while(!__tmp89_last)
                    {
                        string __tmp89_line = __tmp89Reader.ReadLine();
                        __tmp89_last = __tmp89Reader.EndOfStream;
                        if ((__tmp89_last && !string.IsNullOrEmpty(__tmp89_line)) || (!__tmp89_last && __tmp89_line != null))
                        {
                            __out.Append(__tmp89_line);
                            __tmp86_outputWritten = true;
                        }
                        if (!__tmp89_last) __out.AppendLine(true);
                    }
                }
                string __tmp90_line = "(this.MModel, global::MetaDslx.Modeling.ModelFactoryFlags.DontMakeObjectsCreated);"; //256:100
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Append(__tmp90_line);
                    __tmp86_outputWritten = true;
                }
                if (__tmp86_outputWritten) __out.AppendLine(true);
                if (__tmp86_outputWritten)
                {
                    __out.AppendLine(false); //256:182
                }
            }
            __out.AppendLine(true); //258:1
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //259:9
                from cst in __Enumerate((__loop15_var1).GetEnumerator()).OfType<MetaConstant>() //259:39
                select new { __loop15_var1 = __loop15_var1, cst = cst}
                ).ToList(); //259:4
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                var __tmp91 = __loop15_results[__loop15_iteration];
                var __loop15_var1 = __tmp91.__loop15_var1;
                var cst = __tmp91.cst;
                if (metaMetaModel) //260:5
                {
                    bool __tmp93_outputWritten = false;
                    string __tmp92Prefix = "		"; //261:1
                    StringBuilder __tmp94 = new StringBuilder();
                    __tmp94.Append(CSharpName(cst, model, ClassKind.BuilderInstance));
                    using(StreamReader __tmp94Reader = new StreamReader(this.__ToStream(__tmp94.ToString())))
                    {
                        bool __tmp94_last = __tmp94Reader.EndOfStream;
                        while(!__tmp94_last)
                        {
                            string __tmp94_line = __tmp94Reader.ReadLine();
                            __tmp94_last = __tmp94Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp92Prefix))
                            {
                                __out.Append(__tmp92Prefix);
                                __tmp93_outputWritten = true;
                            }
                            if ((__tmp94_last && !string.IsNullOrEmpty(__tmp94_line)) || (!__tmp94_last && __tmp94_line != null))
                            {
                                __out.Append(__tmp94_line);
                                __tmp93_outputWritten = true;
                            }
                            if (!__tmp94_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp95_line = " = factory."; //261:53
                    if (!string.IsNullOrEmpty(__tmp95_line))
                    {
                        __out.Append(__tmp95_line);
                        __tmp93_outputWritten = true;
                    }
                    StringBuilder __tmp96 = new StringBuilder();
                    __tmp96.Append(CSharpName(cst.Type, model, ClassKind.Immutable));
                    using(StreamReader __tmp96Reader = new StreamReader(this.__ToStream(__tmp96.ToString())))
                    {
                        bool __tmp96_last = __tmp96Reader.EndOfStream;
                        while(!__tmp96_last)
                        {
                            string __tmp96_line = __tmp96Reader.ReadLine();
                            __tmp96_last = __tmp96Reader.EndOfStream;
                            if ((__tmp96_last && !string.IsNullOrEmpty(__tmp96_line)) || (!__tmp96_last && __tmp96_line != null))
                            {
                                __out.Append(__tmp96_line);
                                __tmp93_outputWritten = true;
                            }
                            if (!__tmp96_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp97_line = "();"; //261:113
                    if (!string.IsNullOrEmpty(__tmp97_line))
                    {
                        __out.Append(__tmp97_line);
                        __tmp93_outputWritten = true;
                    }
                    if (__tmp93_outputWritten) __out.AppendLine(true);
                    if (__tmp93_outputWritten)
                    {
                        __out.AppendLine(false); //261:116
                    }
                }
                else //262:5
                {
                    bool __tmp99_outputWritten = false;
                    string __tmp98Prefix = "		"; //263:1
                    StringBuilder __tmp100 = new StringBuilder();
                    __tmp100.Append(CSharpName(cst, model, ClassKind.BuilderInstance));
                    using(StreamReader __tmp100Reader = new StreamReader(this.__ToStream(__tmp100.ToString())))
                    {
                        bool __tmp100_last = __tmp100Reader.EndOfStream;
                        while(!__tmp100_last)
                        {
                            string __tmp100_line = __tmp100Reader.ReadLine();
                            __tmp100_last = __tmp100Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp98Prefix))
                            {
                                __out.Append(__tmp98Prefix);
                                __tmp99_outputWritten = true;
                            }
                            if ((__tmp100_last && !string.IsNullOrEmpty(__tmp100_line)) || (!__tmp100_last && __tmp100_line != null))
                            {
                                __out.Append(__tmp100_line);
                                __tmp99_outputWritten = true;
                            }
                            if (!__tmp100_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp101_line = " = constantFactory."; //263:53
                    if (!string.IsNullOrEmpty(__tmp101_line))
                    {
                        __out.Append(__tmp101_line);
                        __tmp99_outputWritten = true;
                    }
                    StringBuilder __tmp102 = new StringBuilder();
                    __tmp102.Append(CSharpName(cst.Type, model, ClassKind.Immutable));
                    using(StreamReader __tmp102Reader = new StreamReader(this.__ToStream(__tmp102.ToString())))
                    {
                        bool __tmp102_last = __tmp102Reader.EndOfStream;
                        while(!__tmp102_last)
                        {
                            string __tmp102_line = __tmp102Reader.ReadLine();
                            __tmp102_last = __tmp102Reader.EndOfStream;
                            if ((__tmp102_last && !string.IsNullOrEmpty(__tmp102_line)) || (!__tmp102_last && __tmp102_line != null))
                            {
                                __out.Append(__tmp102_line);
                                __tmp99_outputWritten = true;
                            }
                            if (!__tmp102_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp103_line = "();"; //263:121
                    if (!string.IsNullOrEmpty(__tmp103_line))
                    {
                        __out.Append(__tmp103_line);
                        __tmp99_outputWritten = true;
                    }
                    if (__tmp99_outputWritten) __out.AppendLine(true);
                    if (__tmp99_outputWritten)
                    {
                        __out.AppendLine(false); //263:124
                    }
                }
                if (cst.DotNetName != null) //265:5
                {
                    bool __tmp105_outputWritten = false;
                    string __tmp104Prefix = "		"; //266:1
                    StringBuilder __tmp106 = new StringBuilder();
                    __tmp106.Append(CSharpName(cst, model, ClassKind.BuilderInstance));
                    using(StreamReader __tmp106Reader = new StreamReader(this.__ToStream(__tmp106.ToString())))
                    {
                        bool __tmp106_last = __tmp106Reader.EndOfStream;
                        while(!__tmp106_last)
                        {
                            string __tmp106_line = __tmp106Reader.ReadLine();
                            __tmp106_last = __tmp106Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp104Prefix))
                            {
                                __out.Append(__tmp104Prefix);
                                __tmp105_outputWritten = true;
                            }
                            if ((__tmp106_last && !string.IsNullOrEmpty(__tmp106_line)) || (!__tmp106_last && __tmp106_line != null))
                            {
                                __out.Append(__tmp106_line);
                                __tmp105_outputWritten = true;
                            }
                            if (!__tmp106_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp107_line = ".MName = \""; //266:53
                    if (!string.IsNullOrEmpty(__tmp107_line))
                    {
                        __out.Append(__tmp107_line);
                        __tmp105_outputWritten = true;
                    }
                    StringBuilder __tmp108 = new StringBuilder();
                    __tmp108.Append(cst.DotNetName);
                    using(StreamReader __tmp108Reader = new StreamReader(this.__ToStream(__tmp108.ToString())))
                    {
                        bool __tmp108_last = __tmp108Reader.EndOfStream;
                        while(!__tmp108_last)
                        {
                            string __tmp108_line = __tmp108Reader.ReadLine();
                            __tmp108_last = __tmp108Reader.EndOfStream;
                            if ((__tmp108_last && !string.IsNullOrEmpty(__tmp108_line)) || (!__tmp108_last && __tmp108_line != null))
                            {
                                __out.Append(__tmp108_line);
                                __tmp105_outputWritten = true;
                            }
                            if (!__tmp108_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp109_line = "\";"; //266:79
                    if (!string.IsNullOrEmpty(__tmp109_line))
                    {
                        __out.Append(__tmp109_line);
                        __tmp105_outputWritten = true;
                    }
                    if (__tmp105_outputWritten) __out.AppendLine(true);
                    if (__tmp105_outputWritten)
                    {
                        __out.AppendLine(false); //266:81
                    }
                }
            }
            __out.AppendLine(true); //269:1
            var __loop16_results = 
                (from obj in __Enumerate((instances).GetEnumerator()) //270:9
                select new { obj = obj}
                ).ToList(); //270:4
            for (int __loop16_iteration = 0; __loop16_iteration < __loop16_results.Count; ++__loop16_iteration)
            {
                var __tmp110 = __loop16_results[__loop16_iteration];
                var obj = __tmp110.obj;
                bool __tmp112_outputWritten = false;
                string __tmp111Prefix = "		"; //271:1
                StringBuilder __tmp113 = new StringBuilder();
                __tmp113.Append(GenerateInstance(model, metaMetaModel, obj, instanceNames));
                using(StreamReader __tmp113Reader = new StreamReader(this.__ToStream(__tmp113.ToString())))
                {
                    bool __tmp113_last = __tmp113Reader.EndOfStream;
                    while(!__tmp113_last)
                    {
                        string __tmp113_line = __tmp113Reader.ReadLine();
                        __tmp113_last = __tmp113Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp111Prefix))
                        {
                            __out.Append(__tmp111Prefix);
                            __tmp112_outputWritten = true;
                        }
                        if ((__tmp113_last && !string.IsNullOrEmpty(__tmp113_line)) || (!__tmp113_last && __tmp113_line != null))
                        {
                            __out.Append(__tmp113_line);
                            __tmp112_outputWritten = true;
                        }
                        if (!__tmp113_last || __tmp112_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp112_outputWritten)
                {
                    __out.AppendLine(false); //271:63
                }
            }
            __out.AppendLine(true); //273:1
            var __loop17_results = 
                (from obj in __Enumerate((instances).GetEnumerator()) //274:9
                select new { obj = obj}
                ).ToList(); //274:4
            for (int __loop17_iteration = 0; __loop17_iteration < __loop17_results.Count; ++__loop17_iteration)
            {
                var __tmp114 = __loop17_results[__loop17_iteration];
                var obj = __tmp114.obj;
                bool __tmp116_outputWritten = false;
                string __tmp115Prefix = "		"; //275:1
                StringBuilder __tmp117 = new StringBuilder();
                __tmp117.Append(GenerateInstanceProperties(model, metaMetaModel, obj, instanceNames));
                using(StreamReader __tmp117Reader = new StreamReader(this.__ToStream(__tmp117.ToString())))
                {
                    bool __tmp117_last = __tmp117Reader.EndOfStream;
                    while(!__tmp117_last)
                    {
                        string __tmp117_line = __tmp117Reader.ReadLine();
                        __tmp117_last = __tmp117Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp115Prefix))
                        {
                            __out.Append(__tmp115Prefix);
                            __tmp116_outputWritten = true;
                        }
                        if ((__tmp117_last && !string.IsNullOrEmpty(__tmp117_line)) || (!__tmp117_last && __tmp117_line != null))
                        {
                            __out.Append(__tmp117_line);
                            __tmp116_outputWritten = true;
                        }
                        if (!__tmp117_last || __tmp116_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp116_outputWritten)
                {
                    __out.AppendLine(false); //275:73
                }
            }
            __out.Append("	}"); //277:1
            __out.AppendLine(false); //277:3
            __out.Append("}"); //278:1
            __out.AppendLine(false); //278:2
            return __out.ToString();
        }

        public string GenerateInstanceDeclaration(MetaModel model, bool metaMetaModel, ImmutableObject obj, ImmutableDictionary<ImmutableObject,string> instanceNames) //281:1
        {
            StringBuilder __out = new StringBuilder();
            if (obj != null && obj.MMetaClass != null && instanceNames.ContainsKey(obj)) //282:2
            {
                string name = instanceNames[obj]; //283:3
                if (metaMetaModel) //284:3
                {
                    if (name.StartsWith("__")) //285:4
                    {
                        bool __tmp2_outputWritten = false;
                        string __tmp3_line = "private "; //286:1
                        if (!string.IsNullOrEmpty(__tmp3_line))
                        {
                            __out.Append(__tmp3_line);
                            __tmp2_outputWritten = true;
                        }
                        StringBuilder __tmp4 = new StringBuilder();
                        __tmp4.Append(CSharpName(obj.MMetaClass, model, ClassKind.Builder));
                        using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                        {
                            bool __tmp4_last = __tmp4Reader.EndOfStream;
                            while(!__tmp4_last)
                            {
                                string __tmp4_line = __tmp4Reader.ReadLine();
                                __tmp4_last = __tmp4Reader.EndOfStream;
                                if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                                {
                                    __out.Append(__tmp4_line);
                                    __tmp2_outputWritten = true;
                                }
                                if (!__tmp4_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp5_line = " "; //286:62
                        if (!string.IsNullOrEmpty(__tmp5_line))
                        {
                            __out.Append(__tmp5_line);
                            __tmp2_outputWritten = true;
                        }
                        StringBuilder __tmp6 = new StringBuilder();
                        __tmp6.Append(name);
                        using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                        {
                            bool __tmp6_last = __tmp6Reader.EndOfStream;
                            while(!__tmp6_last)
                            {
                                string __tmp6_line = __tmp6Reader.ReadLine();
                                __tmp6_last = __tmp6Reader.EndOfStream;
                                if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                                {
                                    __out.Append(__tmp6_line);
                                    __tmp2_outputWritten = true;
                                }
                                if (!__tmp6_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp7_line = ";"; //286:69
                        if (!string.IsNullOrEmpty(__tmp7_line))
                        {
                            __out.Append(__tmp7_line);
                            __tmp2_outputWritten = true;
                        }
                        if (__tmp2_outputWritten) __out.AppendLine(true);
                        if (__tmp2_outputWritten)
                        {
                            __out.AppendLine(false); //286:70
                        }
                    }
                    else //287:4
                    {
                        bool __tmp9_outputWritten = false;
                        string __tmp10_line = "internal "; //288:1
                        if (!string.IsNullOrEmpty(__tmp10_line))
                        {
                            __out.Append(__tmp10_line);
                            __tmp9_outputWritten = true;
                        }
                        StringBuilder __tmp11 = new StringBuilder();
                        __tmp11.Append(CSharpName(obj.MMetaClass, model, ClassKind.Builder));
                        using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                        {
                            bool __tmp11_last = __tmp11Reader.EndOfStream;
                            while(!__tmp11_last)
                            {
                                string __tmp11_line = __tmp11Reader.ReadLine();
                                __tmp11_last = __tmp11Reader.EndOfStream;
                                if ((__tmp11_last && !string.IsNullOrEmpty(__tmp11_line)) || (!__tmp11_last && __tmp11_line != null))
                                {
                                    __out.Append(__tmp11_line);
                                    __tmp9_outputWritten = true;
                                }
                                if (!__tmp11_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp12_line = " "; //288:63
                        if (!string.IsNullOrEmpty(__tmp12_line))
                        {
                            __out.Append(__tmp12_line);
                            __tmp9_outputWritten = true;
                        }
                        StringBuilder __tmp13 = new StringBuilder();
                        __tmp13.Append(name);
                        using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                        {
                            bool __tmp13_last = __tmp13Reader.EndOfStream;
                            while(!__tmp13_last)
                            {
                                string __tmp13_line = __tmp13Reader.ReadLine();
                                __tmp13_last = __tmp13Reader.EndOfStream;
                                if ((__tmp13_last && !string.IsNullOrEmpty(__tmp13_line)) || (!__tmp13_last && __tmp13_line != null))
                                {
                                    __out.Append(__tmp13_line);
                                    __tmp9_outputWritten = true;
                                }
                                if (!__tmp13_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp14_line = ";"; //288:70
                        if (!string.IsNullOrEmpty(__tmp14_line))
                        {
                            __out.Append(__tmp14_line);
                            __tmp9_outputWritten = true;
                        }
                        if (__tmp9_outputWritten) __out.AppendLine(true);
                        if (__tmp9_outputWritten)
                        {
                            __out.AppendLine(false); //288:71
                        }
                    }
                }
                else //290:3
                {
                    if (name.StartsWith("__")) //291:4
                    {
                        bool __tmp16_outputWritten = false;
                        string __tmp17_line = "private "; //292:1
                        if (!string.IsNullOrEmpty(__tmp17_line))
                        {
                            __out.Append(__tmp17_line);
                            __tmp16_outputWritten = true;
                        }
                        StringBuilder __tmp18 = new StringBuilder();
                        __tmp18.Append(CSharpName(obj.MMetaClass, model, ClassKind.Builder, true));
                        using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                        {
                            bool __tmp18_last = __tmp18Reader.EndOfStream;
                            while(!__tmp18_last)
                            {
                                string __tmp18_line = __tmp18Reader.ReadLine();
                                __tmp18_last = __tmp18Reader.EndOfStream;
                                if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                                {
                                    __out.Append(__tmp18_line);
                                    __tmp16_outputWritten = true;
                                }
                                if (!__tmp18_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp19_line = " "; //292:68
                        if (!string.IsNullOrEmpty(__tmp19_line))
                        {
                            __out.Append(__tmp19_line);
                            __tmp16_outputWritten = true;
                        }
                        StringBuilder __tmp20 = new StringBuilder();
                        __tmp20.Append(name);
                        using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                        {
                            bool __tmp20_last = __tmp20Reader.EndOfStream;
                            while(!__tmp20_last)
                            {
                                string __tmp20_line = __tmp20Reader.ReadLine();
                                __tmp20_last = __tmp20Reader.EndOfStream;
                                if ((__tmp20_last && !string.IsNullOrEmpty(__tmp20_line)) || (!__tmp20_last && __tmp20_line != null))
                                {
                                    __out.Append(__tmp20_line);
                                    __tmp16_outputWritten = true;
                                }
                                if (!__tmp20_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp21_line = ";"; //292:75
                        if (!string.IsNullOrEmpty(__tmp21_line))
                        {
                            __out.Append(__tmp21_line);
                            __tmp16_outputWritten = true;
                        }
                        if (__tmp16_outputWritten) __out.AppendLine(true);
                        if (__tmp16_outputWritten)
                        {
                            __out.AppendLine(false); //292:76
                        }
                    }
                    else //293:4
                    {
                        bool __tmp23_outputWritten = false;
                        string __tmp24_line = "internal "; //294:1
                        if (!string.IsNullOrEmpty(__tmp24_line))
                        {
                            __out.Append(__tmp24_line);
                            __tmp23_outputWritten = true;
                        }
                        StringBuilder __tmp25 = new StringBuilder();
                        __tmp25.Append(CSharpName(obj.MMetaClass, model, ClassKind.Builder, true));
                        using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
                        {
                            bool __tmp25_last = __tmp25Reader.EndOfStream;
                            while(!__tmp25_last)
                            {
                                string __tmp25_line = __tmp25Reader.ReadLine();
                                __tmp25_last = __tmp25Reader.EndOfStream;
                                if ((__tmp25_last && !string.IsNullOrEmpty(__tmp25_line)) || (!__tmp25_last && __tmp25_line != null))
                                {
                                    __out.Append(__tmp25_line);
                                    __tmp23_outputWritten = true;
                                }
                                if (!__tmp25_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp26_line = " "; //294:69
                        if (!string.IsNullOrEmpty(__tmp26_line))
                        {
                            __out.Append(__tmp26_line);
                            __tmp23_outputWritten = true;
                        }
                        StringBuilder __tmp27 = new StringBuilder();
                        __tmp27.Append(name);
                        using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                        {
                            bool __tmp27_last = __tmp27Reader.EndOfStream;
                            while(!__tmp27_last)
                            {
                                string __tmp27_line = __tmp27Reader.ReadLine();
                                __tmp27_last = __tmp27Reader.EndOfStream;
                                if ((__tmp27_last && !string.IsNullOrEmpty(__tmp27_line)) || (!__tmp27_last && __tmp27_line != null))
                                {
                                    __out.Append(__tmp27_line);
                                    __tmp23_outputWritten = true;
                                }
                                if (!__tmp27_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp28_line = ";"; //294:76
                        if (!string.IsNullOrEmpty(__tmp28_line))
                        {
                            __out.Append(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                        if (__tmp23_outputWritten) __out.AppendLine(true);
                        if (__tmp23_outputWritten)
                        {
                            __out.AppendLine(false); //294:77
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateInstance(MetaModel model, bool metaMetaModel, ImmutableObject obj, ImmutableDictionary<ImmutableObject,string> instanceNames) //300:1
        {
            StringBuilder __out = new StringBuilder();
            if (obj != null && obj.MMetaClass != null && instanceNames.ContainsKey(obj)) //301:2
            {
                string name = instanceNames[obj]; //302:3
                bool __tmp2_outputWritten = false;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(name);
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(!__tmp3_last)
                    {
                        string __tmp3_line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                        {
                            __out.Append(__tmp3_line);
                            __tmp2_outputWritten = true;
                        }
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                }
                string __tmp4_line = " = factory."; //303:7
                if (!string.IsNullOrEmpty(__tmp4_line))
                {
                    __out.Append(__tmp4_line);
                    __tmp2_outputWritten = true;
                }
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(CSharpName(obj.MMetaClass, model, ClassKind.Immutable));
                using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                {
                    bool __tmp5_last = __tmp5Reader.EndOfStream;
                    while(!__tmp5_last)
                    {
                        string __tmp5_line = __tmp5Reader.ReadLine();
                        __tmp5_last = __tmp5Reader.EndOfStream;
                        if ((__tmp5_last && !string.IsNullOrEmpty(__tmp5_line)) || (!__tmp5_last && __tmp5_line != null))
                        {
                            __out.Append(__tmp5_line);
                            __tmp2_outputWritten = true;
                        }
                        if (!__tmp5_last) __out.AppendLine(true);
                    }
                }
                string __tmp6_line = "();"; //303:73
                if (!string.IsNullOrEmpty(__tmp6_line))
                {
                    __out.Append(__tmp6_line);
                    __tmp2_outputWritten = true;
                }
                if (__tmp2_outputWritten) __out.AppendLine(true);
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //303:76
                }
            }
            return __out.ToString();
        }

        public string GenerateInstanceProperties(MetaModel model, bool metaMetaModel, ImmutableObject obj, ImmutableDictionary<ImmutableObject,string> instanceNames) //307:1
        {
            StringBuilder __out = new StringBuilder();
            if (obj != null && obj.MMetaClass != null && instanceNames.ContainsKey(obj)) //308:2
            {
                var __loop18_results = 
                    (from __loop18_var1 in __Enumerate((obj).GetEnumerator()) //309:8
                    from prop in __Enumerate((__loop18_var1.MProperties).GetEnumerator()) //309:13
                    where !prop.IsDerived && !prop.IsDerivedUnion //309:30
                    select new { __loop18_var1 = __loop18_var1, prop = prop}
                    ).ToList(); //309:3
                for (int __loop18_iteration = 0; __loop18_iteration < __loop18_results.Count; ++__loop18_iteration)
                {
                    var __tmp1 = __loop18_results[__loop18_iteration];
                    var __loop18_var1 = __tmp1.__loop18_var1;
                    var prop = __tmp1.prop;
                    if (obj is MetaConstant && prop.Name == "Value") //310:4
                    {
                        string name = instanceNames[obj]; //311:5
                        bool __tmp3_outputWritten = false;
                        StringBuilder __tmp4 = new StringBuilder();
                        __tmp4.Append(name);
                        using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                        {
                            bool __tmp4_last = __tmp4Reader.EndOfStream;
                            while(!__tmp4_last)
                            {
                                string __tmp4_line = __tmp4Reader.ReadLine();
                                __tmp4_last = __tmp4Reader.EndOfStream;
                                if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                                {
                                    __out.Append(__tmp4_line);
                                    __tmp3_outputWritten = true;
                                }
                                if (!__tmp4_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp5_line = ".SetValueLazy(() => "; //312:7
                        if (!string.IsNullOrEmpty(__tmp5_line))
                        {
                            __out.Append(__tmp5_line);
                            __tmp3_outputWritten = true;
                        }
                        StringBuilder __tmp6 = new StringBuilder();
                        __tmp6.Append(CSharpName(((MetaConstant)obj), model, ClassKind.BuilderInstance));
                        using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                        {
                            bool __tmp6_last = __tmp6Reader.EndOfStream;
                            while(!__tmp6_last)
                            {
                                string __tmp6_line = __tmp6Reader.ReadLine();
                                __tmp6_last = __tmp6Reader.EndOfStream;
                                if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                                {
                                    __out.Append(__tmp6_line);
                                    __tmp3_outputWritten = true;
                                }
                                if (!__tmp6_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp7_line = ");"; //312:93
                        if (!string.IsNullOrEmpty(__tmp7_line))
                        {
                            __out.Append(__tmp7_line);
                            __tmp3_outputWritten = true;
                        }
                        if (__tmp3_outputWritten) __out.AppendLine(true);
                        if (__tmp3_outputWritten)
                        {
                            __out.AppendLine(false); //312:95
                        }
                    }
                    else //313:4
                    {
                        object propValue = obj.MGet(prop); //314:5
                        bool __tmp9_outputWritten = false;
                        StringBuilder __tmp10 = new StringBuilder();
                        __tmp10.Append(GenerateInstancePropertyValue(model, metaMetaModel, obj, prop, propValue, instanceNames));
                        using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                        {
                            bool __tmp10_last = __tmp10Reader.EndOfStream;
                            while(!__tmp10_last)
                            {
                                string __tmp10_line = __tmp10Reader.ReadLine();
                                __tmp10_last = __tmp10Reader.EndOfStream;
                                if ((__tmp10_last && !string.IsNullOrEmpty(__tmp10_line)) || (!__tmp10_last && __tmp10_line != null))
                                {
                                    __out.Append(__tmp10_line);
                                    __tmp9_outputWritten = true;
                                }
                                if (!__tmp10_last || __tmp9_outputWritten) __out.AppendLine(true);
                            }
                        }
                        if (__tmp9_outputWritten)
                        {
                            __out.AppendLine(false); //315:91
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateInstancePropertyValue(MetaModel model, bool metaMetaModel, ImmutableObject obj, ModelProperty prop, object value, ImmutableDictionary<ImmutableObject,string> instanceNames) //321:1
        {
            StringBuilder __out = new StringBuilder();
            string name = instanceNames[obj]; //322:2
            ImmutableObject valueObject = value as ImmutableObject; //323:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //324:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //325:2
            if (value == null) //326:2
            {
                if (prop.MutableType != null && prop.MutableType.IsClass) //327:3
                {
                    bool __tmp2_outputWritten = false;
                    StringBuilder __tmp3 = new StringBuilder();
                    __tmp3.Append(name);
                    using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                    {
                        bool __tmp3_last = __tmp3Reader.EndOfStream;
                        while(!__tmp3_last)
                        {
                            string __tmp3_line = __tmp3Reader.ReadLine();
                            __tmp3_last = __tmp3Reader.EndOfStream;
                            if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                            {
                                __out.Append(__tmp3_line);
                                __tmp2_outputWritten = true;
                            }
                            if (!__tmp3_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp4_line = "."; //328:7
                    if (!string.IsNullOrEmpty(__tmp4_line))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    StringBuilder __tmp5 = new StringBuilder();
                    __tmp5.Append(prop.Name);
                    using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                    {
                        bool __tmp5_last = __tmp5Reader.EndOfStream;
                        while(!__tmp5_last)
                        {
                            string __tmp5_line = __tmp5Reader.ReadLine();
                            __tmp5_last = __tmp5Reader.EndOfStream;
                            if ((__tmp5_last && !string.IsNullOrEmpty(__tmp5_line)) || (!__tmp5_last && __tmp5_line != null))
                            {
                                __out.Append(__tmp5_line);
                                __tmp2_outputWritten = true;
                            }
                            if (!__tmp5_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp6_line = " = null;"; //328:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //328:27
                    }
                }
                else //329:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //330:1
                    if (!string.IsNullOrEmpty(__tmp9_line))
                    {
                        __out.Append(__tmp9_line);
                        __tmp8_outputWritten = true;
                    }
                    StringBuilder __tmp10 = new StringBuilder();
                    __tmp10.Append(name);
                    using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                    {
                        bool __tmp10_last = __tmp10Reader.EndOfStream;
                        while(!__tmp10_last)
                        {
                            string __tmp10_line = __tmp10Reader.ReadLine();
                            __tmp10_last = __tmp10Reader.EndOfStream;
                            if ((__tmp10_last && !string.IsNullOrEmpty(__tmp10_line)) || (!__tmp10_last && __tmp10_line != null))
                            {
                                __out.Append(__tmp10_line);
                                __tmp8_outputWritten = true;
                            }
                            if (!__tmp10_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp11_line = "."; //330:10
                    if (!string.IsNullOrEmpty(__tmp11_line))
                    {
                        __out.Append(__tmp11_line);
                        __tmp8_outputWritten = true;
                    }
                    StringBuilder __tmp12 = new StringBuilder();
                    __tmp12.Append(prop.Name);
                    using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                    {
                        bool __tmp12_last = __tmp12Reader.EndOfStream;
                        while(!__tmp12_last)
                        {
                            string __tmp12_line = __tmp12Reader.ReadLine();
                            __tmp12_last = __tmp12Reader.EndOfStream;
                            if ((__tmp12_last && !string.IsNullOrEmpty(__tmp12_line)) || (!__tmp12_last && __tmp12_line != null))
                            {
                                __out.Append(__tmp12_line);
                                __tmp8_outputWritten = true;
                            }
                            if (!__tmp12_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp13_line = " = null;"; //330:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Append(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //330:30
                    }
                }
            }
            else if (value is string) //332:2
            {
                bool __tmp15_outputWritten = false;
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(name);
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_last = __tmp16Reader.EndOfStream;
                    while(!__tmp16_last)
                    {
                        string __tmp16_line = __tmp16Reader.ReadLine();
                        __tmp16_last = __tmp16Reader.EndOfStream;
                        if ((__tmp16_last && !string.IsNullOrEmpty(__tmp16_line)) || (!__tmp16_last && __tmp16_line != null))
                        {
                            __out.Append(__tmp16_line);
                            __tmp15_outputWritten = true;
                        }
                        if (!__tmp16_last) __out.AppendLine(true);
                    }
                }
                string __tmp17_line = "."; //333:7
                if (!string.IsNullOrEmpty(__tmp17_line))
                {
                    __out.Append(__tmp17_line);
                    __tmp15_outputWritten = true;
                }
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(prop.Name);
                using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                {
                    bool __tmp18_last = __tmp18Reader.EndOfStream;
                    while(!__tmp18_last)
                    {
                        string __tmp18_line = __tmp18Reader.ReadLine();
                        __tmp18_last = __tmp18Reader.EndOfStream;
                        if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                        {
                            __out.Append(__tmp18_line);
                            __tmp15_outputWritten = true;
                        }
                        if (!__tmp18_last) __out.AppendLine(true);
                    }
                }
                string __tmp19_line = " = \""; //333:19
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Append(__tmp19_line);
                    __tmp15_outputWritten = true;
                }
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(EscapeText((string)value));
                using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                {
                    bool __tmp20_last = __tmp20Reader.EndOfStream;
                    while(!__tmp20_last)
                    {
                        string __tmp20_line = __tmp20Reader.ReadLine();
                        __tmp20_last = __tmp20Reader.EndOfStream;
                        if ((__tmp20_last && !string.IsNullOrEmpty(__tmp20_line)) || (!__tmp20_last && __tmp20_line != null))
                        {
                            __out.Append(__tmp20_line);
                            __tmp15_outputWritten = true;
                        }
                        if (!__tmp20_last) __out.AppendLine(true);
                    }
                }
                string __tmp21_line = "\";"; //333:50
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //333:52
                }
            }
            else if (value is bool) //334:2
            {
                bool __tmp23_outputWritten = false;
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(name);
                using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                {
                    bool __tmp24_last = __tmp24Reader.EndOfStream;
                    while(!__tmp24_last)
                    {
                        string __tmp24_line = __tmp24Reader.ReadLine();
                        __tmp24_last = __tmp24Reader.EndOfStream;
                        if ((__tmp24_last && !string.IsNullOrEmpty(__tmp24_line)) || (!__tmp24_last && __tmp24_line != null))
                        {
                            __out.Append(__tmp24_line);
                            __tmp23_outputWritten = true;
                        }
                        if (!__tmp24_last) __out.AppendLine(true);
                    }
                }
                string __tmp25_line = "."; //335:7
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Append(__tmp25_line);
                    __tmp23_outputWritten = true;
                }
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(prop.Name);
                using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
                {
                    bool __tmp26_last = __tmp26Reader.EndOfStream;
                    while(!__tmp26_last)
                    {
                        string __tmp26_line = __tmp26Reader.ReadLine();
                        __tmp26_last = __tmp26Reader.EndOfStream;
                        if ((__tmp26_last && !string.IsNullOrEmpty(__tmp26_line)) || (!__tmp26_last && __tmp26_line != null))
                        {
                            __out.Append(__tmp26_line);
                            __tmp23_outputWritten = true;
                        }
                        if (!__tmp26_last) __out.AppendLine(true);
                    }
                }
                string __tmp27_line = " = "; //335:19
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Append(__tmp27_line);
                    __tmp23_outputWritten = true;
                }
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(value.ToString().ToLower());
                using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                {
                    bool __tmp28_last = __tmp28Reader.EndOfStream;
                    while(!__tmp28_last)
                    {
                        string __tmp28_line = __tmp28Reader.ReadLine();
                        __tmp28_last = __tmp28Reader.EndOfStream;
                        if ((__tmp28_last && !string.IsNullOrEmpty(__tmp28_line)) || (!__tmp28_last && __tmp28_line != null))
                        {
                            __out.Append(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                        if (!__tmp28_last) __out.AppendLine(true);
                    }
                }
                string __tmp29_line = ";"; //335:50
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Append(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //335:51
                }
            }
            else if (value.GetType().IsPrimitive) //336:2
            {
                bool __tmp31_outputWritten = false;
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(name);
                using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                {
                    bool __tmp32_last = __tmp32Reader.EndOfStream;
                    while(!__tmp32_last)
                    {
                        string __tmp32_line = __tmp32Reader.ReadLine();
                        __tmp32_last = __tmp32Reader.EndOfStream;
                        if ((__tmp32_last && !string.IsNullOrEmpty(__tmp32_line)) || (!__tmp32_last && __tmp32_line != null))
                        {
                            __out.Append(__tmp32_line);
                            __tmp31_outputWritten = true;
                        }
                        if (!__tmp32_last) __out.AppendLine(true);
                    }
                }
                string __tmp33_line = "."; //337:7
                if (!string.IsNullOrEmpty(__tmp33_line))
                {
                    __out.Append(__tmp33_line);
                    __tmp31_outputWritten = true;
                }
                StringBuilder __tmp34 = new StringBuilder();
                __tmp34.Append(prop.Name);
                using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                {
                    bool __tmp34_last = __tmp34Reader.EndOfStream;
                    while(!__tmp34_last)
                    {
                        string __tmp34_line = __tmp34Reader.ReadLine();
                        __tmp34_last = __tmp34Reader.EndOfStream;
                        if ((__tmp34_last && !string.IsNullOrEmpty(__tmp34_line)) || (!__tmp34_last && __tmp34_line != null))
                        {
                            __out.Append(__tmp34_line);
                            __tmp31_outputWritten = true;
                        }
                        if (!__tmp34_last) __out.AppendLine(true);
                    }
                }
                string __tmp35_line = " = "; //337:19
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Append(__tmp35_line);
                    __tmp31_outputWritten = true;
                }
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(value.ToString());
                using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                {
                    bool __tmp36_last = __tmp36Reader.EndOfStream;
                    while(!__tmp36_last)
                    {
                        string __tmp36_line = __tmp36Reader.ReadLine();
                        __tmp36_last = __tmp36Reader.EndOfStream;
                        if ((__tmp36_last && !string.IsNullOrEmpty(__tmp36_line)) || (!__tmp36_last && __tmp36_line != null))
                        {
                            __out.Append(__tmp36_line);
                            __tmp31_outputWritten = true;
                        }
                        if (!__tmp36_last) __out.AppendLine(true);
                    }
                }
                string __tmp37_line = ";"; //337:40
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //337:41
                }
            }
            else if (value is MetaAttribute) //338:2
            {
                bool __tmp39_outputWritten = false;
                StringBuilder __tmp40 = new StringBuilder();
                __tmp40.Append(name);
                using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                {
                    bool __tmp40_last = __tmp40Reader.EndOfStream;
                    while(!__tmp40_last)
                    {
                        string __tmp40_line = __tmp40Reader.ReadLine();
                        __tmp40_last = __tmp40Reader.EndOfStream;
                        if ((__tmp40_last && !string.IsNullOrEmpty(__tmp40_line)) || (!__tmp40_last && __tmp40_line != null))
                        {
                            __out.Append(__tmp40_line);
                            __tmp39_outputWritten = true;
                        }
                        if (!__tmp40_last) __out.AppendLine(true);
                    }
                }
                string __tmp41_line = "."; //339:7
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Append(__tmp41_line);
                    __tmp39_outputWritten = true;
                }
                StringBuilder __tmp42 = new StringBuilder();
                __tmp42.Append(prop.Name);
                using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
                {
                    bool __tmp42_last = __tmp42Reader.EndOfStream;
                    while(!__tmp42_last)
                    {
                        string __tmp42_line = __tmp42Reader.ReadLine();
                        __tmp42_last = __tmp42Reader.EndOfStream;
                        if ((__tmp42_last && !string.IsNullOrEmpty(__tmp42_line)) || (!__tmp42_last && __tmp42_line != null))
                        {
                            __out.Append(__tmp42_line);
                            __tmp39_outputWritten = true;
                        }
                        if (!__tmp42_last) __out.AppendLine(true);
                    }
                }
                string __tmp43_line = " = "; //339:19
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Append(__tmp43_line);
                    __tmp39_outputWritten = true;
                }
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(GetAttributeValueOf(model, (MetaAttribute)value));
                using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                {
                    bool __tmp44_last = __tmp44Reader.EndOfStream;
                    while(!__tmp44_last)
                    {
                        string __tmp44_line = __tmp44Reader.ReadLine();
                        __tmp44_last = __tmp44Reader.EndOfStream;
                        if ((__tmp44_last && !string.IsNullOrEmpty(__tmp44_line)) || (!__tmp44_last && __tmp44_line != null))
                        {
                            __out.Append(__tmp44_line);
                            __tmp39_outputWritten = true;
                        }
                        if (!__tmp44_last) __out.AppendLine(true);
                    }
                }
                string __tmp45_line = ";"; //339:72
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Append(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //339:73
                }
            }
            else if (value is Enum) //340:2
            {
                bool __tmp47_outputWritten = false;
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append(name);
                using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
                {
                    bool __tmp48_last = __tmp48Reader.EndOfStream;
                    while(!__tmp48_last)
                    {
                        string __tmp48_line = __tmp48Reader.ReadLine();
                        __tmp48_last = __tmp48Reader.EndOfStream;
                        if ((__tmp48_last && !string.IsNullOrEmpty(__tmp48_line)) || (!__tmp48_last && __tmp48_line != null))
                        {
                            __out.Append(__tmp48_line);
                            __tmp47_outputWritten = true;
                        }
                        if (!__tmp48_last) __out.AppendLine(true);
                    }
                }
                string __tmp49_line = "."; //341:7
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Append(__tmp49_line);
                    __tmp47_outputWritten = true;
                }
                StringBuilder __tmp50 = new StringBuilder();
                __tmp50.Append(prop.Name);
                using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                {
                    bool __tmp50_last = __tmp50Reader.EndOfStream;
                    while(!__tmp50_last)
                    {
                        string __tmp50_line = __tmp50Reader.ReadLine();
                        __tmp50_last = __tmp50Reader.EndOfStream;
                        if ((__tmp50_last && !string.IsNullOrEmpty(__tmp50_line)) || (!__tmp50_last && __tmp50_line != null))
                        {
                            __out.Append(__tmp50_line);
                            __tmp47_outputWritten = true;
                        }
                        if (!__tmp50_last) __out.AppendLine(true);
                    }
                }
                string __tmp51_line = " = "; //341:19
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Append(__tmp51_line);
                    __tmp47_outputWritten = true;
                }
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(GetEnumValueOf(model, (Enum)value));
                using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                {
                    bool __tmp52_last = __tmp52Reader.EndOfStream;
                    while(!__tmp52_last)
                    {
                        string __tmp52_line = __tmp52Reader.ReadLine();
                        __tmp52_last = __tmp52Reader.EndOfStream;
                        if ((__tmp52_last && !string.IsNullOrEmpty(__tmp52_line)) || (!__tmp52_last && __tmp52_line != null))
                        {
                            __out.Append(__tmp52_line);
                            __tmp47_outputWritten = true;
                        }
                        if (!__tmp52_last) __out.AppendLine(true);
                    }
                }
                string __tmp53_line = ";"; //341:58
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp47_outputWritten = true;
                }
                if (__tmp47_outputWritten) __out.AppendLine(true);
                if (__tmp47_outputWritten)
                {
                    __out.AppendLine(false); //341:59
                }
            }
            else if (value is MetaExternalType) //342:2
            {
                bool __tmp55_outputWritten = false;
                StringBuilder __tmp56 = new StringBuilder();
                __tmp56.Append(name);
                using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
                {
                    bool __tmp56_last = __tmp56Reader.EndOfStream;
                    while(!__tmp56_last)
                    {
                        string __tmp56_line = __tmp56Reader.ReadLine();
                        __tmp56_last = __tmp56Reader.EndOfStream;
                        if ((__tmp56_last && !string.IsNullOrEmpty(__tmp56_line)) || (!__tmp56_last && __tmp56_line != null))
                        {
                            __out.Append(__tmp56_line);
                            __tmp55_outputWritten = true;
                        }
                        if (!__tmp56_last) __out.AppendLine(true);
                    }
                }
                string __tmp57_line = ".Set"; //343:7
                if (!string.IsNullOrEmpty(__tmp57_line))
                {
                    __out.Append(__tmp57_line);
                    __tmp55_outputWritten = true;
                }
                StringBuilder __tmp58 = new StringBuilder();
                __tmp58.Append(prop.Name);
                using(StreamReader __tmp58Reader = new StreamReader(this.__ToStream(__tmp58.ToString())))
                {
                    bool __tmp58_last = __tmp58Reader.EndOfStream;
                    while(!__tmp58_last)
                    {
                        string __tmp58_line = __tmp58Reader.ReadLine();
                        __tmp58_last = __tmp58Reader.EndOfStream;
                        if ((__tmp58_last && !string.IsNullOrEmpty(__tmp58_line)) || (!__tmp58_last && __tmp58_line != null))
                        {
                            __out.Append(__tmp58_line);
                            __tmp55_outputWritten = true;
                        }
                        if (!__tmp58_last) __out.AppendLine(true);
                    }
                }
                string __tmp59_line = "Lazy(() => "; //343:22
                if (!string.IsNullOrEmpty(__tmp59_line))
                {
                    __out.Append(__tmp59_line);
                    __tmp55_outputWritten = true;
                }
                StringBuilder __tmp60 = new StringBuilder();
                __tmp60.Append(ToPascalCase(((MetaExternalType)value).Name));
                using(StreamReader __tmp60Reader = new StreamReader(this.__ToStream(__tmp60.ToString())))
                {
                    bool __tmp60_last = __tmp60Reader.EndOfStream;
                    while(!__tmp60_last)
                    {
                        string __tmp60_line = __tmp60Reader.ReadLine();
                        __tmp60_last = __tmp60Reader.EndOfStream;
                        if ((__tmp60_last && !string.IsNullOrEmpty(__tmp60_line)) || (!__tmp60_last && __tmp60_line != null))
                        {
                            __out.Append(__tmp60_line);
                            __tmp55_outputWritten = true;
                        }
                        if (!__tmp60_last) __out.AppendLine(true);
                    }
                }
                string __tmp61_line = ");"; //343:80
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Append(__tmp61_line);
                    __tmp55_outputWritten = true;
                }
                if (__tmp55_outputWritten) __out.AppendLine(true);
                if (__tmp55_outputWritten)
                {
                    __out.AppendLine(false); //343:82
                }
            }
            else if (value is MetaPrimitiveType) //344:2
            {
                if (metaMetaModel) //345:3
                {
                    bool __tmp63_outputWritten = false;
                    StringBuilder __tmp64 = new StringBuilder();
                    __tmp64.Append(name);
                    using(StreamReader __tmp64Reader = new StreamReader(this.__ToStream(__tmp64.ToString())))
                    {
                        bool __tmp64_last = __tmp64Reader.EndOfStream;
                        while(!__tmp64_last)
                        {
                            string __tmp64_line = __tmp64Reader.ReadLine();
                            __tmp64_last = __tmp64Reader.EndOfStream;
                            if ((__tmp64_last && !string.IsNullOrEmpty(__tmp64_line)) || (!__tmp64_last && __tmp64_line != null))
                            {
                                __out.Append(__tmp64_line);
                                __tmp63_outputWritten = true;
                            }
                            if (!__tmp64_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp65_line = ".Set"; //346:7
                    if (!string.IsNullOrEmpty(__tmp65_line))
                    {
                        __out.Append(__tmp65_line);
                        __tmp63_outputWritten = true;
                    }
                    StringBuilder __tmp66 = new StringBuilder();
                    __tmp66.Append(prop.Name);
                    using(StreamReader __tmp66Reader = new StreamReader(this.__ToStream(__tmp66.ToString())))
                    {
                        bool __tmp66_last = __tmp66Reader.EndOfStream;
                        while(!__tmp66_last)
                        {
                            string __tmp66_line = __tmp66Reader.ReadLine();
                            __tmp66_last = __tmp66Reader.EndOfStream;
                            if ((__tmp66_last && !string.IsNullOrEmpty(__tmp66_line)) || (!__tmp66_last && __tmp66_line != null))
                            {
                                __out.Append(__tmp66_line);
                                __tmp63_outputWritten = true;
                            }
                            if (!__tmp66_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp67_line = "Lazy(() => "; //346:22
                    if (!string.IsNullOrEmpty(__tmp67_line))
                    {
                        __out.Append(__tmp67_line);
                        __tmp63_outputWritten = true;
                    }
                    StringBuilder __tmp68 = new StringBuilder();
                    __tmp68.Append(ToPascalCase(((MetaPrimitiveType)value).Name));
                    using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
                    {
                        bool __tmp68_last = __tmp68Reader.EndOfStream;
                        while(!__tmp68_last)
                        {
                            string __tmp68_line = __tmp68Reader.ReadLine();
                            __tmp68_last = __tmp68Reader.EndOfStream;
                            if ((__tmp68_last && !string.IsNullOrEmpty(__tmp68_line)) || (!__tmp68_last && __tmp68_line != null))
                            {
                                __out.Append(__tmp68_line);
                                __tmp63_outputWritten = true;
                            }
                            if (!__tmp68_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp69_line = ");"; //346:81
                    if (!string.IsNullOrEmpty(__tmp69_line))
                    {
                        __out.Append(__tmp69_line);
                        __tmp63_outputWritten = true;
                    }
                    if (__tmp63_outputWritten) __out.AppendLine(true);
                    if (__tmp63_outputWritten)
                    {
                        __out.AppendLine(false); //346:83
                    }
                }
                else //347:3
                {
                    bool __tmp71_outputWritten = false;
                    StringBuilder __tmp72 = new StringBuilder();
                    __tmp72.Append(name);
                    using(StreamReader __tmp72Reader = new StreamReader(this.__ToStream(__tmp72.ToString())))
                    {
                        bool __tmp72_last = __tmp72Reader.EndOfStream;
                        while(!__tmp72_last)
                        {
                            string __tmp72_line = __tmp72Reader.ReadLine();
                            __tmp72_last = __tmp72Reader.EndOfStream;
                            if ((__tmp72_last && !string.IsNullOrEmpty(__tmp72_line)) || (!__tmp72_last && __tmp72_line != null))
                            {
                                __out.Append(__tmp72_line);
                                __tmp71_outputWritten = true;
                            }
                            if (!__tmp72_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp73_line = ".Set"; //348:7
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Append(__tmp73_line);
                        __tmp71_outputWritten = true;
                    }
                    StringBuilder __tmp74 = new StringBuilder();
                    __tmp74.Append(prop.Name);
                    using(StreamReader __tmp74Reader = new StreamReader(this.__ToStream(__tmp74.ToString())))
                    {
                        bool __tmp74_last = __tmp74Reader.EndOfStream;
                        while(!__tmp74_last)
                        {
                            string __tmp74_line = __tmp74Reader.ReadLine();
                            __tmp74_last = __tmp74Reader.EndOfStream;
                            if ((__tmp74_last && !string.IsNullOrEmpty(__tmp74_line)) || (!__tmp74_last && __tmp74_line != null))
                            {
                                __out.Append(__tmp74_line);
                                __tmp71_outputWritten = true;
                            }
                            if (!__tmp74_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp75_line = "Lazy(() => "; //348:22
                    if (!string.IsNullOrEmpty(__tmp75_line))
                    {
                        __out.Append(__tmp75_line);
                        __tmp71_outputWritten = true;
                    }
                    StringBuilder __tmp76 = new StringBuilder();
                    __tmp76.Append(CSharpName(((MetaPrimitiveType)value), model, ClassKind.ImmutableInstance, true));
                    using(StreamReader __tmp76Reader = new StreamReader(this.__ToStream(__tmp76.ToString())))
                    {
                        bool __tmp76_last = __tmp76Reader.EndOfStream;
                        while(!__tmp76_last)
                        {
                            string __tmp76_line = __tmp76Reader.ReadLine();
                            __tmp76_last = __tmp76Reader.EndOfStream;
                            if ((__tmp76_last && !string.IsNullOrEmpty(__tmp76_line)) || (!__tmp76_last && __tmp76_line != null))
                            {
                                __out.Append(__tmp76_line);
                                __tmp71_outputWritten = true;
                            }
                            if (!__tmp76_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp77_line = ".ToMutable());"; //348:114
                    if (!string.IsNullOrEmpty(__tmp77_line))
                    {
                        __out.Append(__tmp77_line);
                        __tmp71_outputWritten = true;
                    }
                    if (__tmp71_outputWritten) __out.AppendLine(true);
                    if (__tmp71_outputWritten)
                    {
                        __out.AppendLine(false); //348:128
                    }
                }
            }
            else if (valueObject != null && instanceNames.ContainsKey(valueObject)) //350:2
            {
                bool __tmp79_outputWritten = false;
                StringBuilder __tmp80 = new StringBuilder();
                __tmp80.Append(name);
                using(StreamReader __tmp80Reader = new StreamReader(this.__ToStream(__tmp80.ToString())))
                {
                    bool __tmp80_last = __tmp80Reader.EndOfStream;
                    while(!__tmp80_last)
                    {
                        string __tmp80_line = __tmp80Reader.ReadLine();
                        __tmp80_last = __tmp80Reader.EndOfStream;
                        if ((__tmp80_last && !string.IsNullOrEmpty(__tmp80_line)) || (!__tmp80_last && __tmp80_line != null))
                        {
                            __out.Append(__tmp80_line);
                            __tmp79_outputWritten = true;
                        }
                        if (!__tmp80_last) __out.AppendLine(true);
                    }
                }
                string __tmp81_line = ".Set"; //351:7
                if (!string.IsNullOrEmpty(__tmp81_line))
                {
                    __out.Append(__tmp81_line);
                    __tmp79_outputWritten = true;
                }
                StringBuilder __tmp82 = new StringBuilder();
                __tmp82.Append(prop.Name);
                using(StreamReader __tmp82Reader = new StreamReader(this.__ToStream(__tmp82.ToString())))
                {
                    bool __tmp82_last = __tmp82Reader.EndOfStream;
                    while(!__tmp82_last)
                    {
                        string __tmp82_line = __tmp82Reader.ReadLine();
                        __tmp82_last = __tmp82Reader.EndOfStream;
                        if ((__tmp82_last && !string.IsNullOrEmpty(__tmp82_line)) || (!__tmp82_last && __tmp82_line != null))
                        {
                            __out.Append(__tmp82_line);
                            __tmp79_outputWritten = true;
                        }
                        if (!__tmp82_last) __out.AppendLine(true);
                    }
                }
                string __tmp83_line = "Lazy(() => "; //351:22
                if (!string.IsNullOrEmpty(__tmp83_line))
                {
                    __out.Append(__tmp83_line);
                    __tmp79_outputWritten = true;
                }
                StringBuilder __tmp84 = new StringBuilder();
                __tmp84.Append(instanceNames[valueObject]);
                using(StreamReader __tmp84Reader = new StreamReader(this.__ToStream(__tmp84.ToString())))
                {
                    bool __tmp84_last = __tmp84Reader.EndOfStream;
                    while(!__tmp84_last)
                    {
                        string __tmp84_line = __tmp84Reader.ReadLine();
                        __tmp84_last = __tmp84Reader.EndOfStream;
                        if ((__tmp84_last && !string.IsNullOrEmpty(__tmp84_line)) || (!__tmp84_last && __tmp84_line != null))
                        {
                            __out.Append(__tmp84_line);
                            __tmp79_outputWritten = true;
                        }
                        if (!__tmp84_last) __out.AppendLine(true);
                    }
                }
                string __tmp85_line = ");"; //351:61
                if (!string.IsNullOrEmpty(__tmp85_line))
                {
                    __out.Append(__tmp85_line);
                    __tmp79_outputWritten = true;
                }
                if (__tmp79_outputWritten) __out.AppendLine(true);
                if (__tmp79_outputWritten)
                {
                    __out.AppendLine(false); //351:63
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //352:2
            {
                bool __tmp87_outputWritten = false;
                StringBuilder __tmp88 = new StringBuilder();
                __tmp88.Append(name);
                using(StreamReader __tmp88Reader = new StreamReader(this.__ToStream(__tmp88.ToString())))
                {
                    bool __tmp88_last = __tmp88Reader.EndOfStream;
                    while(!__tmp88_last)
                    {
                        string __tmp88_line = __tmp88Reader.ReadLine();
                        __tmp88_last = __tmp88Reader.EndOfStream;
                        if ((__tmp88_last && !string.IsNullOrEmpty(__tmp88_line)) || (!__tmp88_last && __tmp88_line != null))
                        {
                            __out.Append(__tmp88_line);
                            __tmp87_outputWritten = true;
                        }
                        if (!__tmp88_last) __out.AppendLine(true);
                    }
                }
                string __tmp89_line = ".Set"; //353:7
                if (!string.IsNullOrEmpty(__tmp89_line))
                {
                    __out.Append(__tmp89_line);
                    __tmp87_outputWritten = true;
                }
                StringBuilder __tmp90 = new StringBuilder();
                __tmp90.Append(prop.Name);
                using(StreamReader __tmp90Reader = new StreamReader(this.__ToStream(__tmp90.ToString())))
                {
                    bool __tmp90_last = __tmp90Reader.EndOfStream;
                    while(!__tmp90_last)
                    {
                        string __tmp90_line = __tmp90Reader.ReadLine();
                        __tmp90_last = __tmp90Reader.EndOfStream;
                        if ((__tmp90_last && !string.IsNullOrEmpty(__tmp90_line)) || (!__tmp90_last && __tmp90_line != null))
                        {
                            __out.Append(__tmp90_line);
                            __tmp87_outputWritten = true;
                        }
                        if (!__tmp90_last) __out.AppendLine(true);
                    }
                }
                string __tmp91_line = "Lazy(() => "; //353:22
                if (!string.IsNullOrEmpty(__tmp91_line))
                {
                    __out.Append(__tmp91_line);
                    __tmp87_outputWritten = true;
                }
                StringBuilder __tmp92 = new StringBuilder();
                __tmp92.Append(CSharpName(((MetaType)valueDecl), model, ClassKind.Immutable, true));
                using(StreamReader __tmp92Reader = new StreamReader(this.__ToStream(__tmp92.ToString())))
                {
                    bool __tmp92_last = __tmp92Reader.EndOfStream;
                    while(!__tmp92_last)
                    {
                        string __tmp92_line = __tmp92Reader.ReadLine();
                        __tmp92_last = __tmp92Reader.EndOfStream;
                        if ((__tmp92_last && !string.IsNullOrEmpty(__tmp92_line)) || (!__tmp92_last && __tmp92_line != null))
                        {
                            __out.Append(__tmp92_line);
                            __tmp87_outputWritten = true;
                        }
                        if (!__tmp92_last) __out.AppendLine(true);
                    }
                }
                string __tmp93_line = ");"; //353:101
                if (!string.IsNullOrEmpty(__tmp93_line))
                {
                    __out.Append(__tmp93_line);
                    __tmp87_outputWritten = true;
                }
                if (__tmp87_outputWritten) __out.AppendLine(true);
                if (__tmp87_outputWritten)
                {
                    __out.AppendLine(false); //353:103
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //354:2
            {
                bool __tmp95_outputWritten = false;
                StringBuilder __tmp96 = new StringBuilder();
                __tmp96.Append(name);
                using(StreamReader __tmp96Reader = new StreamReader(this.__ToStream(__tmp96.ToString())))
                {
                    bool __tmp96_last = __tmp96Reader.EndOfStream;
                    while(!__tmp96_last)
                    {
                        string __tmp96_line = __tmp96Reader.ReadLine();
                        __tmp96_last = __tmp96Reader.EndOfStream;
                        if ((__tmp96_last && !string.IsNullOrEmpty(__tmp96_line)) || (!__tmp96_last && __tmp96_line != null))
                        {
                            __out.Append(__tmp96_line);
                            __tmp95_outputWritten = true;
                        }
                        if (!__tmp96_last) __out.AppendLine(true);
                    }
                }
                string __tmp97_line = ".Set"; //355:7
                if (!string.IsNullOrEmpty(__tmp97_line))
                {
                    __out.Append(__tmp97_line);
                    __tmp95_outputWritten = true;
                }
                StringBuilder __tmp98 = new StringBuilder();
                __tmp98.Append(prop.Name);
                using(StreamReader __tmp98Reader = new StreamReader(this.__ToStream(__tmp98.ToString())))
                {
                    bool __tmp98_last = __tmp98Reader.EndOfStream;
                    while(!__tmp98_last)
                    {
                        string __tmp98_line = __tmp98Reader.ReadLine();
                        __tmp98_last = __tmp98Reader.EndOfStream;
                        if ((__tmp98_last && !string.IsNullOrEmpty(__tmp98_line)) || (!__tmp98_last && __tmp98_line != null))
                        {
                            __out.Append(__tmp98_line);
                            __tmp95_outputWritten = true;
                        }
                        if (!__tmp98_last) __out.AppendLine(true);
                    }
                }
                string __tmp99_line = "Lazy(() => "; //355:22
                if (!string.IsNullOrEmpty(__tmp99_line))
                {
                    __out.Append(__tmp99_line);
                    __tmp95_outputWritten = true;
                }
                StringBuilder __tmp100 = new StringBuilder();
                __tmp100.Append(CSharpName(((MetaConstant)valueDecl), model, ClassKind.Immutable, true));
                using(StreamReader __tmp100Reader = new StreamReader(this.__ToStream(__tmp100.ToString())))
                {
                    bool __tmp100_last = __tmp100Reader.EndOfStream;
                    while(!__tmp100_last)
                    {
                        string __tmp100_line = __tmp100Reader.ReadLine();
                        __tmp100_last = __tmp100Reader.EndOfStream;
                        if ((__tmp100_last && !string.IsNullOrEmpty(__tmp100_line)) || (!__tmp100_last && __tmp100_line != null))
                        {
                            __out.Append(__tmp100_line);
                            __tmp95_outputWritten = true;
                        }
                        if (!__tmp100_last) __out.AppendLine(true);
                    }
                }
                string __tmp101_line = ");"; //355:105
                if (!string.IsNullOrEmpty(__tmp101_line))
                {
                    __out.Append(__tmp101_line);
                    __tmp95_outputWritten = true;
                }
                if (__tmp95_outputWritten) __out.AppendLine(true);
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //355:107
                }
            }
            else if (valueCollection != null) //356:2
            {
                var __loop19_results = 
                    (from cvalue in __Enumerate((valueCollection).GetEnumerator()) //357:8
                    select new { cvalue = cvalue}
                    ).ToList(); //357:3
                for (int __loop19_iteration = 0; __loop19_iteration < __loop19_results.Count; ++__loop19_iteration)
                {
                    var __tmp102 = __loop19_results[__loop19_iteration];
                    var cvalue = __tmp102.cvalue;
                    bool __tmp104_outputWritten = false;
                    StringBuilder __tmp105 = new StringBuilder();
                    __tmp105.Append(GenerateInstancePropertyCollectionValue(model, metaMetaModel, obj, prop, cvalue, instanceNames));
                    using(StreamReader __tmp105Reader = new StreamReader(this.__ToStream(__tmp105.ToString())))
                    {
                        bool __tmp105_last = __tmp105Reader.EndOfStream;
                        while(!__tmp105_last)
                        {
                            string __tmp105_line = __tmp105Reader.ReadLine();
                            __tmp105_last = __tmp105Reader.EndOfStream;
                            if ((__tmp105_last && !string.IsNullOrEmpty(__tmp105_line)) || (!__tmp105_last && __tmp105_line != null))
                            {
                                __out.Append(__tmp105_line);
                                __tmp104_outputWritten = true;
                            }
                            if (!__tmp105_last || __tmp104_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp104_outputWritten)
                    {
                        __out.AppendLine(false); //358:98
                    }
                }
            }
            else //360:2
            {
                bool __tmp107_outputWritten = false;
                string __tmp108_line = "// TODO: "; //361:1
                if (!string.IsNullOrEmpty(__tmp108_line))
                {
                    __out.Append(__tmp108_line);
                    __tmp107_outputWritten = true;
                }
                StringBuilder __tmp109 = new StringBuilder();
                __tmp109.Append(name);
                using(StreamReader __tmp109Reader = new StreamReader(this.__ToStream(__tmp109.ToString())))
                {
                    bool __tmp109_last = __tmp109Reader.EndOfStream;
                    while(!__tmp109_last)
                    {
                        string __tmp109_line = __tmp109Reader.ReadLine();
                        __tmp109_last = __tmp109Reader.EndOfStream;
                        if ((__tmp109_last && !string.IsNullOrEmpty(__tmp109_line)) || (!__tmp109_last && __tmp109_line != null))
                        {
                            __out.Append(__tmp109_line);
                            __tmp107_outputWritten = true;
                        }
                        if (!__tmp109_last) __out.AppendLine(true);
                    }
                }
                string __tmp110_line = "."; //361:16
                if (!string.IsNullOrEmpty(__tmp110_line))
                {
                    __out.Append(__tmp110_line);
                    __tmp107_outputWritten = true;
                }
                StringBuilder __tmp111 = new StringBuilder();
                __tmp111.Append(prop.Name);
                using(StreamReader __tmp111Reader = new StreamReader(this.__ToStream(__tmp111.ToString())))
                {
                    bool __tmp111_last = __tmp111Reader.EndOfStream;
                    while(!__tmp111_last)
                    {
                        string __tmp111_line = __tmp111Reader.ReadLine();
                        __tmp111_last = __tmp111Reader.EndOfStream;
                        if ((__tmp111_last && !string.IsNullOrEmpty(__tmp111_line)) || (!__tmp111_last && __tmp111_line != null))
                        {
                            __out.Append(__tmp111_line);
                            __tmp107_outputWritten = true;
                        }
                        if (!__tmp111_last || __tmp107_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp107_outputWritten)
                {
                    __out.AppendLine(false); //361:28
                }
            }
            return __out.ToString();
        }

        public string GenerateInstancePropertyCollectionValue(MetaModel model, bool metaMetaModel, ImmutableObject obj, ModelProperty prop, object value, ImmutableDictionary<ImmutableObject,string> instanceNames) //365:1
        {
            StringBuilder __out = new StringBuilder();
            string name = instanceNames[obj]; //366:2
            ImmutableObject valueObject = value as ImmutableObject; //367:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //368:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //369:2
            if (value == null) //370:2
            {
                if (prop.MutableType != null && prop.MutableType.IsClass) //371:3
                {
                    bool __tmp2_outputWritten = false;
                    StringBuilder __tmp3 = new StringBuilder();
                    __tmp3.Append(name);
                    using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                    {
                        bool __tmp3_last = __tmp3Reader.EndOfStream;
                        while(!__tmp3_last)
                        {
                            string __tmp3_line = __tmp3Reader.ReadLine();
                            __tmp3_last = __tmp3Reader.EndOfStream;
                            if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                            {
                                __out.Append(__tmp3_line);
                                __tmp2_outputWritten = true;
                            }
                            if (!__tmp3_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp4_line = "."; //372:7
                    if (!string.IsNullOrEmpty(__tmp4_line))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    StringBuilder __tmp5 = new StringBuilder();
                    __tmp5.Append(prop.Name);
                    using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
                    {
                        bool __tmp5_last = __tmp5Reader.EndOfStream;
                        while(!__tmp5_last)
                        {
                            string __tmp5_line = __tmp5Reader.ReadLine();
                            __tmp5_last = __tmp5Reader.EndOfStream;
                            if ((__tmp5_last && !string.IsNullOrEmpty(__tmp5_line)) || (!__tmp5_last && __tmp5_line != null))
                            {
                                __out.Append(__tmp5_line);
                                __tmp2_outputWritten = true;
                            }
                            if (!__tmp5_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp6_line = ".Add(null);"; //372:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //372:30
                    }
                }
                else //373:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //374:1
                    if (!string.IsNullOrEmpty(__tmp9_line))
                    {
                        __out.Append(__tmp9_line);
                        __tmp8_outputWritten = true;
                    }
                    StringBuilder __tmp10 = new StringBuilder();
                    __tmp10.Append(name);
                    using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
                    {
                        bool __tmp10_last = __tmp10Reader.EndOfStream;
                        while(!__tmp10_last)
                        {
                            string __tmp10_line = __tmp10Reader.ReadLine();
                            __tmp10_last = __tmp10Reader.EndOfStream;
                            if ((__tmp10_last && !string.IsNullOrEmpty(__tmp10_line)) || (!__tmp10_last && __tmp10_line != null))
                            {
                                __out.Append(__tmp10_line);
                                __tmp8_outputWritten = true;
                            }
                            if (!__tmp10_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp11_line = "."; //374:10
                    if (!string.IsNullOrEmpty(__tmp11_line))
                    {
                        __out.Append(__tmp11_line);
                        __tmp8_outputWritten = true;
                    }
                    StringBuilder __tmp12 = new StringBuilder();
                    __tmp12.Append(prop.Name);
                    using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                    {
                        bool __tmp12_last = __tmp12Reader.EndOfStream;
                        while(!__tmp12_last)
                        {
                            string __tmp12_line = __tmp12Reader.ReadLine();
                            __tmp12_last = __tmp12Reader.EndOfStream;
                            if ((__tmp12_last && !string.IsNullOrEmpty(__tmp12_line)) || (!__tmp12_last && __tmp12_line != null))
                            {
                                __out.Append(__tmp12_line);
                                __tmp8_outputWritten = true;
                            }
                            if (!__tmp12_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp13_line = ".Add(null);"; //374:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Append(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //374:33
                    }
                }
            }
            else if (value is string) //376:2
            {
                bool __tmp15_outputWritten = false;
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(name);
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_last = __tmp16Reader.EndOfStream;
                    while(!__tmp16_last)
                    {
                        string __tmp16_line = __tmp16Reader.ReadLine();
                        __tmp16_last = __tmp16Reader.EndOfStream;
                        if ((__tmp16_last && !string.IsNullOrEmpty(__tmp16_line)) || (!__tmp16_last && __tmp16_line != null))
                        {
                            __out.Append(__tmp16_line);
                            __tmp15_outputWritten = true;
                        }
                        if (!__tmp16_last) __out.AppendLine(true);
                    }
                }
                string __tmp17_line = "."; //377:7
                if (!string.IsNullOrEmpty(__tmp17_line))
                {
                    __out.Append(__tmp17_line);
                    __tmp15_outputWritten = true;
                }
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(prop.Name);
                using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                {
                    bool __tmp18_last = __tmp18Reader.EndOfStream;
                    while(!__tmp18_last)
                    {
                        string __tmp18_line = __tmp18Reader.ReadLine();
                        __tmp18_last = __tmp18Reader.EndOfStream;
                        if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                        {
                            __out.Append(__tmp18_line);
                            __tmp15_outputWritten = true;
                        }
                        if (!__tmp18_last) __out.AppendLine(true);
                    }
                }
                string __tmp19_line = ".Add(\""; //377:19
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Append(__tmp19_line);
                    __tmp15_outputWritten = true;
                }
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(EscapeText((string)value));
                using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                {
                    bool __tmp20_last = __tmp20Reader.EndOfStream;
                    while(!__tmp20_last)
                    {
                        string __tmp20_line = __tmp20Reader.ReadLine();
                        __tmp20_last = __tmp20Reader.EndOfStream;
                        if ((__tmp20_last && !string.IsNullOrEmpty(__tmp20_line)) || (!__tmp20_last && __tmp20_line != null))
                        {
                            __out.Append(__tmp20_line);
                            __tmp15_outputWritten = true;
                        }
                        if (!__tmp20_last) __out.AppendLine(true);
                    }
                }
                string __tmp21_line = "\");"; //377:52
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //377:55
                }
            }
            else if (value is bool) //378:2
            {
                bool __tmp23_outputWritten = false;
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(name);
                using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                {
                    bool __tmp24_last = __tmp24Reader.EndOfStream;
                    while(!__tmp24_last)
                    {
                        string __tmp24_line = __tmp24Reader.ReadLine();
                        __tmp24_last = __tmp24Reader.EndOfStream;
                        if ((__tmp24_last && !string.IsNullOrEmpty(__tmp24_line)) || (!__tmp24_last && __tmp24_line != null))
                        {
                            __out.Append(__tmp24_line);
                            __tmp23_outputWritten = true;
                        }
                        if (!__tmp24_last) __out.AppendLine(true);
                    }
                }
                string __tmp25_line = "."; //379:7
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Append(__tmp25_line);
                    __tmp23_outputWritten = true;
                }
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(prop.Name);
                using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
                {
                    bool __tmp26_last = __tmp26Reader.EndOfStream;
                    while(!__tmp26_last)
                    {
                        string __tmp26_line = __tmp26Reader.ReadLine();
                        __tmp26_last = __tmp26Reader.EndOfStream;
                        if ((__tmp26_last && !string.IsNullOrEmpty(__tmp26_line)) || (!__tmp26_last && __tmp26_line != null))
                        {
                            __out.Append(__tmp26_line);
                            __tmp23_outputWritten = true;
                        }
                        if (!__tmp26_last) __out.AppendLine(true);
                    }
                }
                string __tmp27_line = ".Add("; //379:19
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Append(__tmp27_line);
                    __tmp23_outputWritten = true;
                }
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(value.ToString().ToLower());
                using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                {
                    bool __tmp28_last = __tmp28Reader.EndOfStream;
                    while(!__tmp28_last)
                    {
                        string __tmp28_line = __tmp28Reader.ReadLine();
                        __tmp28_last = __tmp28Reader.EndOfStream;
                        if ((__tmp28_last && !string.IsNullOrEmpty(__tmp28_line)) || (!__tmp28_last && __tmp28_line != null))
                        {
                            __out.Append(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                        if (!__tmp28_last) __out.AppendLine(true);
                    }
                }
                string __tmp29_line = ");"; //379:52
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Append(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //379:54
                }
            }
            else if (value.GetType().IsPrimitive) //380:2
            {
                bool __tmp31_outputWritten = false;
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(name);
                using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                {
                    bool __tmp32_last = __tmp32Reader.EndOfStream;
                    while(!__tmp32_last)
                    {
                        string __tmp32_line = __tmp32Reader.ReadLine();
                        __tmp32_last = __tmp32Reader.EndOfStream;
                        if ((__tmp32_last && !string.IsNullOrEmpty(__tmp32_line)) || (!__tmp32_last && __tmp32_line != null))
                        {
                            __out.Append(__tmp32_line);
                            __tmp31_outputWritten = true;
                        }
                        if (!__tmp32_last) __out.AppendLine(true);
                    }
                }
                string __tmp33_line = "."; //381:7
                if (!string.IsNullOrEmpty(__tmp33_line))
                {
                    __out.Append(__tmp33_line);
                    __tmp31_outputWritten = true;
                }
                StringBuilder __tmp34 = new StringBuilder();
                __tmp34.Append(prop.Name);
                using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                {
                    bool __tmp34_last = __tmp34Reader.EndOfStream;
                    while(!__tmp34_last)
                    {
                        string __tmp34_line = __tmp34Reader.ReadLine();
                        __tmp34_last = __tmp34Reader.EndOfStream;
                        if ((__tmp34_last && !string.IsNullOrEmpty(__tmp34_line)) || (!__tmp34_last && __tmp34_line != null))
                        {
                            __out.Append(__tmp34_line);
                            __tmp31_outputWritten = true;
                        }
                        if (!__tmp34_last) __out.AppendLine(true);
                    }
                }
                string __tmp35_line = ".Add("; //381:19
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Append(__tmp35_line);
                    __tmp31_outputWritten = true;
                }
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(value.ToString());
                using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                {
                    bool __tmp36_last = __tmp36Reader.EndOfStream;
                    while(!__tmp36_last)
                    {
                        string __tmp36_line = __tmp36Reader.ReadLine();
                        __tmp36_last = __tmp36Reader.EndOfStream;
                        if ((__tmp36_last && !string.IsNullOrEmpty(__tmp36_line)) || (!__tmp36_last && __tmp36_line != null))
                        {
                            __out.Append(__tmp36_line);
                            __tmp31_outputWritten = true;
                        }
                        if (!__tmp36_last) __out.AppendLine(true);
                    }
                }
                string __tmp37_line = ");"; //381:42
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //381:44
                }
            }
            else if (value is MetaAttribute) //382:2
            {
                bool __tmp39_outputWritten = false;
                StringBuilder __tmp40 = new StringBuilder();
                __tmp40.Append(name);
                using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                {
                    bool __tmp40_last = __tmp40Reader.EndOfStream;
                    while(!__tmp40_last)
                    {
                        string __tmp40_line = __tmp40Reader.ReadLine();
                        __tmp40_last = __tmp40Reader.EndOfStream;
                        if ((__tmp40_last && !string.IsNullOrEmpty(__tmp40_line)) || (!__tmp40_last && __tmp40_line != null))
                        {
                            __out.Append(__tmp40_line);
                            __tmp39_outputWritten = true;
                        }
                        if (!__tmp40_last) __out.AppendLine(true);
                    }
                }
                string __tmp41_line = "."; //383:7
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Append(__tmp41_line);
                    __tmp39_outputWritten = true;
                }
                StringBuilder __tmp42 = new StringBuilder();
                __tmp42.Append(prop.Name);
                using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
                {
                    bool __tmp42_last = __tmp42Reader.EndOfStream;
                    while(!__tmp42_last)
                    {
                        string __tmp42_line = __tmp42Reader.ReadLine();
                        __tmp42_last = __tmp42Reader.EndOfStream;
                        if ((__tmp42_last && !string.IsNullOrEmpty(__tmp42_line)) || (!__tmp42_last && __tmp42_line != null))
                        {
                            __out.Append(__tmp42_line);
                            __tmp39_outputWritten = true;
                        }
                        if (!__tmp42_last) __out.AppendLine(true);
                    }
                }
                string __tmp43_line = ".Add("; //383:19
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Append(__tmp43_line);
                    __tmp39_outputWritten = true;
                }
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(GetAttributeValueOf(model, (MetaAttribute)value));
                using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                {
                    bool __tmp44_last = __tmp44Reader.EndOfStream;
                    while(!__tmp44_last)
                    {
                        string __tmp44_line = __tmp44Reader.ReadLine();
                        __tmp44_last = __tmp44Reader.EndOfStream;
                        if ((__tmp44_last && !string.IsNullOrEmpty(__tmp44_line)) || (!__tmp44_last && __tmp44_line != null))
                        {
                            __out.Append(__tmp44_line);
                            __tmp39_outputWritten = true;
                        }
                        if (!__tmp44_last) __out.AppendLine(true);
                    }
                }
                string __tmp45_line = ");"; //383:74
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Append(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //383:76
                }
            }
            else if (value is Enum) //384:2
            {
                bool __tmp47_outputWritten = false;
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append(name);
                using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
                {
                    bool __tmp48_last = __tmp48Reader.EndOfStream;
                    while(!__tmp48_last)
                    {
                        string __tmp48_line = __tmp48Reader.ReadLine();
                        __tmp48_last = __tmp48Reader.EndOfStream;
                        if ((__tmp48_last && !string.IsNullOrEmpty(__tmp48_line)) || (!__tmp48_last && __tmp48_line != null))
                        {
                            __out.Append(__tmp48_line);
                            __tmp47_outputWritten = true;
                        }
                        if (!__tmp48_last) __out.AppendLine(true);
                    }
                }
                string __tmp49_line = "."; //385:7
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Append(__tmp49_line);
                    __tmp47_outputWritten = true;
                }
                StringBuilder __tmp50 = new StringBuilder();
                __tmp50.Append(prop.Name);
                using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                {
                    bool __tmp50_last = __tmp50Reader.EndOfStream;
                    while(!__tmp50_last)
                    {
                        string __tmp50_line = __tmp50Reader.ReadLine();
                        __tmp50_last = __tmp50Reader.EndOfStream;
                        if ((__tmp50_last && !string.IsNullOrEmpty(__tmp50_line)) || (!__tmp50_last && __tmp50_line != null))
                        {
                            __out.Append(__tmp50_line);
                            __tmp47_outputWritten = true;
                        }
                        if (!__tmp50_last) __out.AppendLine(true);
                    }
                }
                string __tmp51_line = ".Add("; //385:19
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Append(__tmp51_line);
                    __tmp47_outputWritten = true;
                }
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(GetEnumValueOf(model, (Enum)value));
                using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                {
                    bool __tmp52_last = __tmp52Reader.EndOfStream;
                    while(!__tmp52_last)
                    {
                        string __tmp52_line = __tmp52Reader.ReadLine();
                        __tmp52_last = __tmp52Reader.EndOfStream;
                        if ((__tmp52_last && !string.IsNullOrEmpty(__tmp52_line)) || (!__tmp52_last && __tmp52_line != null))
                        {
                            __out.Append(__tmp52_line);
                            __tmp47_outputWritten = true;
                        }
                        if (!__tmp52_last) __out.AppendLine(true);
                    }
                }
                string __tmp53_line = ");"; //385:60
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp47_outputWritten = true;
                }
                if (__tmp47_outputWritten) __out.AppendLine(true);
                if (__tmp47_outputWritten)
                {
                    __out.AppendLine(false); //385:62
                }
            }
            else if (value is MetaExternalType) //386:2
            {
                bool __tmp55_outputWritten = false;
                StringBuilder __tmp56 = new StringBuilder();
                __tmp56.Append(name);
                using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
                {
                    bool __tmp56_last = __tmp56Reader.EndOfStream;
                    while(!__tmp56_last)
                    {
                        string __tmp56_line = __tmp56Reader.ReadLine();
                        __tmp56_last = __tmp56Reader.EndOfStream;
                        if ((__tmp56_last && !string.IsNullOrEmpty(__tmp56_line)) || (!__tmp56_last && __tmp56_line != null))
                        {
                            __out.Append(__tmp56_line);
                            __tmp55_outputWritten = true;
                        }
                        if (!__tmp56_last) __out.AppendLine(true);
                    }
                }
                string __tmp57_line = "."; //387:7
                if (!string.IsNullOrEmpty(__tmp57_line))
                {
                    __out.Append(__tmp57_line);
                    __tmp55_outputWritten = true;
                }
                StringBuilder __tmp58 = new StringBuilder();
                __tmp58.Append(prop.Name);
                using(StreamReader __tmp58Reader = new StreamReader(this.__ToStream(__tmp58.ToString())))
                {
                    bool __tmp58_last = __tmp58Reader.EndOfStream;
                    while(!__tmp58_last)
                    {
                        string __tmp58_line = __tmp58Reader.ReadLine();
                        __tmp58_last = __tmp58Reader.EndOfStream;
                        if ((__tmp58_last && !string.IsNullOrEmpty(__tmp58_line)) || (!__tmp58_last && __tmp58_line != null))
                        {
                            __out.Append(__tmp58_line);
                            __tmp55_outputWritten = true;
                        }
                        if (!__tmp58_last) __out.AppendLine(true);
                    }
                }
                string __tmp59_line = ".AddLazy(() => "; //387:19
                if (!string.IsNullOrEmpty(__tmp59_line))
                {
                    __out.Append(__tmp59_line);
                    __tmp55_outputWritten = true;
                }
                StringBuilder __tmp60 = new StringBuilder();
                __tmp60.Append(ToPascalCase(((MetaExternalType)value).Name));
                using(StreamReader __tmp60Reader = new StreamReader(this.__ToStream(__tmp60.ToString())))
                {
                    bool __tmp60_last = __tmp60Reader.EndOfStream;
                    while(!__tmp60_last)
                    {
                        string __tmp60_line = __tmp60Reader.ReadLine();
                        __tmp60_last = __tmp60Reader.EndOfStream;
                        if ((__tmp60_last && !string.IsNullOrEmpty(__tmp60_line)) || (!__tmp60_last && __tmp60_line != null))
                        {
                            __out.Append(__tmp60_line);
                            __tmp55_outputWritten = true;
                        }
                        if (!__tmp60_last) __out.AppendLine(true);
                    }
                }
                string __tmp61_line = ");"; //387:81
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Append(__tmp61_line);
                    __tmp55_outputWritten = true;
                }
                if (__tmp55_outputWritten) __out.AppendLine(true);
                if (__tmp55_outputWritten)
                {
                    __out.AppendLine(false); //387:83
                }
            }
            else if (value is MetaPrimitiveType) //388:2
            {
                if (metaMetaModel) //389:3
                {
                    bool __tmp63_outputWritten = false;
                    StringBuilder __tmp64 = new StringBuilder();
                    __tmp64.Append(name);
                    using(StreamReader __tmp64Reader = new StreamReader(this.__ToStream(__tmp64.ToString())))
                    {
                        bool __tmp64_last = __tmp64Reader.EndOfStream;
                        while(!__tmp64_last)
                        {
                            string __tmp64_line = __tmp64Reader.ReadLine();
                            __tmp64_last = __tmp64Reader.EndOfStream;
                            if ((__tmp64_last && !string.IsNullOrEmpty(__tmp64_line)) || (!__tmp64_last && __tmp64_line != null))
                            {
                                __out.Append(__tmp64_line);
                                __tmp63_outputWritten = true;
                            }
                            if (!__tmp64_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp65_line = "."; //390:7
                    if (!string.IsNullOrEmpty(__tmp65_line))
                    {
                        __out.Append(__tmp65_line);
                        __tmp63_outputWritten = true;
                    }
                    StringBuilder __tmp66 = new StringBuilder();
                    __tmp66.Append(prop.Name);
                    using(StreamReader __tmp66Reader = new StreamReader(this.__ToStream(__tmp66.ToString())))
                    {
                        bool __tmp66_last = __tmp66Reader.EndOfStream;
                        while(!__tmp66_last)
                        {
                            string __tmp66_line = __tmp66Reader.ReadLine();
                            __tmp66_last = __tmp66Reader.EndOfStream;
                            if ((__tmp66_last && !string.IsNullOrEmpty(__tmp66_line)) || (!__tmp66_last && __tmp66_line != null))
                            {
                                __out.Append(__tmp66_line);
                                __tmp63_outputWritten = true;
                            }
                            if (!__tmp66_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp67_line = ".AddLazy(() => "; //390:19
                    if (!string.IsNullOrEmpty(__tmp67_line))
                    {
                        __out.Append(__tmp67_line);
                        __tmp63_outputWritten = true;
                    }
                    StringBuilder __tmp68 = new StringBuilder();
                    __tmp68.Append(ToPascalCase(((MetaPrimitiveType)value).Name));
                    using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
                    {
                        bool __tmp68_last = __tmp68Reader.EndOfStream;
                        while(!__tmp68_last)
                        {
                            string __tmp68_line = __tmp68Reader.ReadLine();
                            __tmp68_last = __tmp68Reader.EndOfStream;
                            if ((__tmp68_last && !string.IsNullOrEmpty(__tmp68_line)) || (!__tmp68_last && __tmp68_line != null))
                            {
                                __out.Append(__tmp68_line);
                                __tmp63_outputWritten = true;
                            }
                            if (!__tmp68_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp69_line = ");"; //390:82
                    if (!string.IsNullOrEmpty(__tmp69_line))
                    {
                        __out.Append(__tmp69_line);
                        __tmp63_outputWritten = true;
                    }
                    if (__tmp63_outputWritten) __out.AppendLine(true);
                    if (__tmp63_outputWritten)
                    {
                        __out.AppendLine(false); //390:84
                    }
                }
                else //391:3
                {
                    bool __tmp71_outputWritten = false;
                    StringBuilder __tmp72 = new StringBuilder();
                    __tmp72.Append(name);
                    using(StreamReader __tmp72Reader = new StreamReader(this.__ToStream(__tmp72.ToString())))
                    {
                        bool __tmp72_last = __tmp72Reader.EndOfStream;
                        while(!__tmp72_last)
                        {
                            string __tmp72_line = __tmp72Reader.ReadLine();
                            __tmp72_last = __tmp72Reader.EndOfStream;
                            if ((__tmp72_last && !string.IsNullOrEmpty(__tmp72_line)) || (!__tmp72_last && __tmp72_line != null))
                            {
                                __out.Append(__tmp72_line);
                                __tmp71_outputWritten = true;
                            }
                            if (!__tmp72_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp73_line = "."; //392:7
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Append(__tmp73_line);
                        __tmp71_outputWritten = true;
                    }
                    StringBuilder __tmp74 = new StringBuilder();
                    __tmp74.Append(prop.Name);
                    using(StreamReader __tmp74Reader = new StreamReader(this.__ToStream(__tmp74.ToString())))
                    {
                        bool __tmp74_last = __tmp74Reader.EndOfStream;
                        while(!__tmp74_last)
                        {
                            string __tmp74_line = __tmp74Reader.ReadLine();
                            __tmp74_last = __tmp74Reader.EndOfStream;
                            if ((__tmp74_last && !string.IsNullOrEmpty(__tmp74_line)) || (!__tmp74_last && __tmp74_line != null))
                            {
                                __out.Append(__tmp74_line);
                                __tmp71_outputWritten = true;
                            }
                            if (!__tmp74_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp75_line = ".AddLazy(() => "; //392:19
                    if (!string.IsNullOrEmpty(__tmp75_line))
                    {
                        __out.Append(__tmp75_line);
                        __tmp71_outputWritten = true;
                    }
                    StringBuilder __tmp76 = new StringBuilder();
                    __tmp76.Append(CSharpName(((MetaPrimitiveType)value), model, ClassKind.ImmutableInstance, true));
                    using(StreamReader __tmp76Reader = new StreamReader(this.__ToStream(__tmp76.ToString())))
                    {
                        bool __tmp76_last = __tmp76Reader.EndOfStream;
                        while(!__tmp76_last)
                        {
                            string __tmp76_line = __tmp76Reader.ReadLine();
                            __tmp76_last = __tmp76Reader.EndOfStream;
                            if ((__tmp76_last && !string.IsNullOrEmpty(__tmp76_line)) || (!__tmp76_last && __tmp76_line != null))
                            {
                                __out.Append(__tmp76_line);
                                __tmp71_outputWritten = true;
                            }
                            if (!__tmp76_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp77_line = ".ToMutable());"; //392:115
                    if (!string.IsNullOrEmpty(__tmp77_line))
                    {
                        __out.Append(__tmp77_line);
                        __tmp71_outputWritten = true;
                    }
                    if (__tmp71_outputWritten) __out.AppendLine(true);
                    if (__tmp71_outputWritten)
                    {
                        __out.AppendLine(false); //392:129
                    }
                }
            }
            else if (valueObject != null && instanceNames.ContainsKey(valueObject)) //394:2
            {
                bool __tmp79_outputWritten = false;
                StringBuilder __tmp80 = new StringBuilder();
                __tmp80.Append(name);
                using(StreamReader __tmp80Reader = new StreamReader(this.__ToStream(__tmp80.ToString())))
                {
                    bool __tmp80_last = __tmp80Reader.EndOfStream;
                    while(!__tmp80_last)
                    {
                        string __tmp80_line = __tmp80Reader.ReadLine();
                        __tmp80_last = __tmp80Reader.EndOfStream;
                        if ((__tmp80_last && !string.IsNullOrEmpty(__tmp80_line)) || (!__tmp80_last && __tmp80_line != null))
                        {
                            __out.Append(__tmp80_line);
                            __tmp79_outputWritten = true;
                        }
                        if (!__tmp80_last) __out.AppendLine(true);
                    }
                }
                string __tmp81_line = "."; //395:7
                if (!string.IsNullOrEmpty(__tmp81_line))
                {
                    __out.Append(__tmp81_line);
                    __tmp79_outputWritten = true;
                }
                StringBuilder __tmp82 = new StringBuilder();
                __tmp82.Append(prop.Name);
                using(StreamReader __tmp82Reader = new StreamReader(this.__ToStream(__tmp82.ToString())))
                {
                    bool __tmp82_last = __tmp82Reader.EndOfStream;
                    while(!__tmp82_last)
                    {
                        string __tmp82_line = __tmp82Reader.ReadLine();
                        __tmp82_last = __tmp82Reader.EndOfStream;
                        if ((__tmp82_last && !string.IsNullOrEmpty(__tmp82_line)) || (!__tmp82_last && __tmp82_line != null))
                        {
                            __out.Append(__tmp82_line);
                            __tmp79_outputWritten = true;
                        }
                        if (!__tmp82_last) __out.AppendLine(true);
                    }
                }
                string __tmp83_line = ".AddLazy(() => "; //395:19
                if (!string.IsNullOrEmpty(__tmp83_line))
                {
                    __out.Append(__tmp83_line);
                    __tmp79_outputWritten = true;
                }
                StringBuilder __tmp84 = new StringBuilder();
                __tmp84.Append(instanceNames[valueObject]);
                using(StreamReader __tmp84Reader = new StreamReader(this.__ToStream(__tmp84.ToString())))
                {
                    bool __tmp84_last = __tmp84Reader.EndOfStream;
                    while(!__tmp84_last)
                    {
                        string __tmp84_line = __tmp84Reader.ReadLine();
                        __tmp84_last = __tmp84Reader.EndOfStream;
                        if ((__tmp84_last && !string.IsNullOrEmpty(__tmp84_line)) || (!__tmp84_last && __tmp84_line != null))
                        {
                            __out.Append(__tmp84_line);
                            __tmp79_outputWritten = true;
                        }
                        if (!__tmp84_last) __out.AppendLine(true);
                    }
                }
                string __tmp85_line = ");"; //395:62
                if (!string.IsNullOrEmpty(__tmp85_line))
                {
                    __out.Append(__tmp85_line);
                    __tmp79_outputWritten = true;
                }
                if (__tmp79_outputWritten) __out.AppendLine(true);
                if (__tmp79_outputWritten)
                {
                    __out.AppendLine(false); //395:64
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //396:2
            {
                bool __tmp87_outputWritten = false;
                StringBuilder __tmp88 = new StringBuilder();
                __tmp88.Append(name);
                using(StreamReader __tmp88Reader = new StreamReader(this.__ToStream(__tmp88.ToString())))
                {
                    bool __tmp88_last = __tmp88Reader.EndOfStream;
                    while(!__tmp88_last)
                    {
                        string __tmp88_line = __tmp88Reader.ReadLine();
                        __tmp88_last = __tmp88Reader.EndOfStream;
                        if ((__tmp88_last && !string.IsNullOrEmpty(__tmp88_line)) || (!__tmp88_last && __tmp88_line != null))
                        {
                            __out.Append(__tmp88_line);
                            __tmp87_outputWritten = true;
                        }
                        if (!__tmp88_last) __out.AppendLine(true);
                    }
                }
                string __tmp89_line = "."; //397:7
                if (!string.IsNullOrEmpty(__tmp89_line))
                {
                    __out.Append(__tmp89_line);
                    __tmp87_outputWritten = true;
                }
                StringBuilder __tmp90 = new StringBuilder();
                __tmp90.Append(prop.Name);
                using(StreamReader __tmp90Reader = new StreamReader(this.__ToStream(__tmp90.ToString())))
                {
                    bool __tmp90_last = __tmp90Reader.EndOfStream;
                    while(!__tmp90_last)
                    {
                        string __tmp90_line = __tmp90Reader.ReadLine();
                        __tmp90_last = __tmp90Reader.EndOfStream;
                        if ((__tmp90_last && !string.IsNullOrEmpty(__tmp90_line)) || (!__tmp90_last && __tmp90_line != null))
                        {
                            __out.Append(__tmp90_line);
                            __tmp87_outputWritten = true;
                        }
                        if (!__tmp90_last) __out.AppendLine(true);
                    }
                }
                string __tmp91_line = ".AddLazy(() => "; //397:19
                if (!string.IsNullOrEmpty(__tmp91_line))
                {
                    __out.Append(__tmp91_line);
                    __tmp87_outputWritten = true;
                }
                StringBuilder __tmp92 = new StringBuilder();
                __tmp92.Append(CSharpName(((MetaType)valueDecl), model, ClassKind.Immutable, true));
                using(StreamReader __tmp92Reader = new StreamReader(this.__ToStream(__tmp92.ToString())))
                {
                    bool __tmp92_last = __tmp92Reader.EndOfStream;
                    while(!__tmp92_last)
                    {
                        string __tmp92_line = __tmp92Reader.ReadLine();
                        __tmp92_last = __tmp92Reader.EndOfStream;
                        if ((__tmp92_last && !string.IsNullOrEmpty(__tmp92_line)) || (!__tmp92_last && __tmp92_line != null))
                        {
                            __out.Append(__tmp92_line);
                            __tmp87_outputWritten = true;
                        }
                        if (!__tmp92_last) __out.AppendLine(true);
                    }
                }
                string __tmp93_line = ");"; //397:102
                if (!string.IsNullOrEmpty(__tmp93_line))
                {
                    __out.Append(__tmp93_line);
                    __tmp87_outputWritten = true;
                }
                if (__tmp87_outputWritten) __out.AppendLine(true);
                if (__tmp87_outputWritten)
                {
                    __out.AppendLine(false); //397:104
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //398:2
            {
                bool __tmp95_outputWritten = false;
                StringBuilder __tmp96 = new StringBuilder();
                __tmp96.Append(name);
                using(StreamReader __tmp96Reader = new StreamReader(this.__ToStream(__tmp96.ToString())))
                {
                    bool __tmp96_last = __tmp96Reader.EndOfStream;
                    while(!__tmp96_last)
                    {
                        string __tmp96_line = __tmp96Reader.ReadLine();
                        __tmp96_last = __tmp96Reader.EndOfStream;
                        if ((__tmp96_last && !string.IsNullOrEmpty(__tmp96_line)) || (!__tmp96_last && __tmp96_line != null))
                        {
                            __out.Append(__tmp96_line);
                            __tmp95_outputWritten = true;
                        }
                        if (!__tmp96_last) __out.AppendLine(true);
                    }
                }
                string __tmp97_line = "."; //399:7
                if (!string.IsNullOrEmpty(__tmp97_line))
                {
                    __out.Append(__tmp97_line);
                    __tmp95_outputWritten = true;
                }
                StringBuilder __tmp98 = new StringBuilder();
                __tmp98.Append(prop.Name);
                using(StreamReader __tmp98Reader = new StreamReader(this.__ToStream(__tmp98.ToString())))
                {
                    bool __tmp98_last = __tmp98Reader.EndOfStream;
                    while(!__tmp98_last)
                    {
                        string __tmp98_line = __tmp98Reader.ReadLine();
                        __tmp98_last = __tmp98Reader.EndOfStream;
                        if ((__tmp98_last && !string.IsNullOrEmpty(__tmp98_line)) || (!__tmp98_last && __tmp98_line != null))
                        {
                            __out.Append(__tmp98_line);
                            __tmp95_outputWritten = true;
                        }
                        if (!__tmp98_last) __out.AppendLine(true);
                    }
                }
                string __tmp99_line = ".AddLazy(() => "; //399:19
                if (!string.IsNullOrEmpty(__tmp99_line))
                {
                    __out.Append(__tmp99_line);
                    __tmp95_outputWritten = true;
                }
                StringBuilder __tmp100 = new StringBuilder();
                __tmp100.Append(CSharpName(((MetaConstant)valueDecl), model, ClassKind.Immutable, true));
                using(StreamReader __tmp100Reader = new StreamReader(this.__ToStream(__tmp100.ToString())))
                {
                    bool __tmp100_last = __tmp100Reader.EndOfStream;
                    while(!__tmp100_last)
                    {
                        string __tmp100_line = __tmp100Reader.ReadLine();
                        __tmp100_last = __tmp100Reader.EndOfStream;
                        if ((__tmp100_last && !string.IsNullOrEmpty(__tmp100_line)) || (!__tmp100_last && __tmp100_line != null))
                        {
                            __out.Append(__tmp100_line);
                            __tmp95_outputWritten = true;
                        }
                        if (!__tmp100_last) __out.AppendLine(true);
                    }
                }
                string __tmp101_line = ");"; //399:106
                if (!string.IsNullOrEmpty(__tmp101_line))
                {
                    __out.Append(__tmp101_line);
                    __tmp95_outputWritten = true;
                }
                if (__tmp95_outputWritten) __out.AppendLine(true);
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //399:108
                }
            }
            else //400:2
            {
                bool __tmp103_outputWritten = false;
                string __tmp104_line = "// TODO: "; //401:1
                if (!string.IsNullOrEmpty(__tmp104_line))
                {
                    __out.Append(__tmp104_line);
                    __tmp103_outputWritten = true;
                }
                StringBuilder __tmp105 = new StringBuilder();
                __tmp105.Append(name);
                using(StreamReader __tmp105Reader = new StreamReader(this.__ToStream(__tmp105.ToString())))
                {
                    bool __tmp105_last = __tmp105Reader.EndOfStream;
                    while(!__tmp105_last)
                    {
                        string __tmp105_line = __tmp105Reader.ReadLine();
                        __tmp105_last = __tmp105Reader.EndOfStream;
                        if ((__tmp105_last && !string.IsNullOrEmpty(__tmp105_line)) || (!__tmp105_last && __tmp105_line != null))
                        {
                            __out.Append(__tmp105_line);
                            __tmp103_outputWritten = true;
                        }
                        if (!__tmp105_last) __out.AppendLine(true);
                    }
                }
                string __tmp106_line = "."; //401:16
                if (!string.IsNullOrEmpty(__tmp106_line))
                {
                    __out.Append(__tmp106_line);
                    __tmp103_outputWritten = true;
                }
                StringBuilder __tmp107 = new StringBuilder();
                __tmp107.Append(prop.Name);
                using(StreamReader __tmp107Reader = new StreamReader(this.__ToStream(__tmp107.ToString())))
                {
                    bool __tmp107_last = __tmp107Reader.EndOfStream;
                    while(!__tmp107_last)
                    {
                        string __tmp107_line = __tmp107Reader.ReadLine();
                        __tmp107_last = __tmp107Reader.EndOfStream;
                        if ((__tmp107_last && !string.IsNullOrEmpty(__tmp107_line)) || (!__tmp107_last && __tmp107_line != null))
                        {
                            __out.Append(__tmp107_line);
                            __tmp103_outputWritten = true;
                        }
                        if (!__tmp107_last || __tmp103_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp103_outputWritten)
                {
                    __out.AppendLine(false); //401:28
                }
            }
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //405:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //406:2
            bool metaMetaModel = IsMetaMetaModel(model); //407:2
            __out.Append("/// <summary>"); //408:1
            __out.AppendLine(false); //408:14
            __out.Append("/// Factory class for creating instances of model elements."); //409:1
            __out.AppendLine(false); //409:60
            __out.Append("/// </summary>"); //410:1
            __out.AppendLine(false); //410:15
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //411:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(CSharpName(model, ModelKind.Factory));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5_line = " : "; //411:51
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Append(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(Properties.CoreNs);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7_line = ".ModelFactoryBase"; //411:73
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //411:90
            }
            __out.Append("{"); //412:1
            __out.AppendLine(false); //412:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public "; //413:1
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp9_outputWritten = true;
            }
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(CSharpName(model, ModelKind.Factory));
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(!__tmp11_last)
                {
                    string __tmp11_line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    if ((__tmp11_last && !string.IsNullOrEmpty(__tmp11_line)) || (!__tmp11_last && __tmp11_line != null))
                    {
                        __out.Append(__tmp11_line);
                        __tmp9_outputWritten = true;
                    }
                    if (!__tmp11_last) __out.AppendLine(true);
                }
            }
            string __tmp12_line = "("; //413:46
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Append(__tmp12_line);
                __tmp9_outputWritten = true;
            }
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(Properties.CoreNs);
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13_line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if ((__tmp13_last && !string.IsNullOrEmpty(__tmp13_line)) || (!__tmp13_last && __tmp13_line != null))
                    {
                        __out.Append(__tmp13_line);
                        __tmp9_outputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14_line = ".MutableModel model, "; //413:66
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp9_outputWritten = true;
            }
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(Properties.CoreNs);
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_last = __tmp15Reader.EndOfStream;
                while(!__tmp15_last)
                {
                    string __tmp15_line = __tmp15Reader.ReadLine();
                    __tmp15_last = __tmp15Reader.EndOfStream;
                    if ((__tmp15_last && !string.IsNullOrEmpty(__tmp15_line)) || (!__tmp15_last && __tmp15_line != null))
                    {
                        __out.Append(__tmp15_line);
                        __tmp9_outputWritten = true;
                    }
                    if (!__tmp15_last) __out.AppendLine(true);
                }
            }
            string __tmp16_line = ".ModelFactoryFlags flags = "; //413:106
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Append(__tmp16_line);
                __tmp9_outputWritten = true;
            }
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(Properties.CoreNs);
            using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
            {
                bool __tmp17_last = __tmp17Reader.EndOfStream;
                while(!__tmp17_last)
                {
                    string __tmp17_line = __tmp17Reader.ReadLine();
                    __tmp17_last = __tmp17Reader.EndOfStream;
                    if ((__tmp17_last && !string.IsNullOrEmpty(__tmp17_line)) || (!__tmp17_last && __tmp17_line != null))
                    {
                        __out.Append(__tmp17_line);
                        __tmp9_outputWritten = true;
                    }
                    if (!__tmp17_last) __out.AppendLine(true);
                }
            }
            string __tmp18_line = ".ModelFactoryFlags.None)"; //413:152
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Append(__tmp18_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //413:176
            }
            __out.Append("		: base(model, flags)"); //414:1
            __out.AppendLine(false); //414:23
            __out.Append("	{"); //415:1
            __out.AppendLine(false); //415:3
            bool __tmp20_outputWritten = false;
            string __tmp19Prefix = "		"; //416:1
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(CSharpName(model, ModelKind.Descriptor));
            using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
            {
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(!__tmp21_last)
                {
                    string __tmp21_line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp19Prefix))
                    {
                        __out.Append(__tmp19Prefix);
                        __tmp20_outputWritten = true;
                    }
                    if ((__tmp21_last && !string.IsNullOrEmpty(__tmp21_line)) || (!__tmp21_last && __tmp21_line != null))
                    {
                        __out.Append(__tmp21_line);
                        __tmp20_outputWritten = true;
                    }
                    if (!__tmp21_last) __out.AppendLine(true);
                }
            }
            string __tmp22_line = ".Initialize();"; //416:43
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Append(__tmp22_line);
                __tmp20_outputWritten = true;
            }
            if (__tmp20_outputWritten) __out.AppendLine(true);
            if (__tmp20_outputWritten)
            {
                __out.AppendLine(false); //416:57
            }
            __out.Append("	}"); //417:1
            __out.AppendLine(false); //417:3
            __out.AppendLine(true); //418:1
            bool __tmp24_outputWritten = false;
            string __tmp25_line = "	public override "; //419:1
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Append(__tmp25_line);
                __tmp24_outputWritten = true;
            }
            StringBuilder __tmp26 = new StringBuilder();
            __tmp26.Append(Properties.CoreNs);
            using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
            {
                bool __tmp26_last = __tmp26Reader.EndOfStream;
                while(!__tmp26_last)
                {
                    string __tmp26_line = __tmp26Reader.ReadLine();
                    __tmp26_last = __tmp26Reader.EndOfStream;
                    if ((__tmp26_last && !string.IsNullOrEmpty(__tmp26_line)) || (!__tmp26_last && __tmp26_line != null))
                    {
                        __out.Append(__tmp26_line);
                        __tmp24_outputWritten = true;
                    }
                    if (!__tmp26_last) __out.AppendLine(true);
                }
            }
            string __tmp27_line = ".IMetaModel MMetaModel => "; //419:37
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Append(__tmp27_line);
                __tmp24_outputWritten = true;
            }
            StringBuilder __tmp28 = new StringBuilder();
            __tmp28.Append(CSharpName(model, ModelKind.ImmutableInstance, true));
            using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
            {
                bool __tmp28_last = __tmp28Reader.EndOfStream;
                while(!__tmp28_last)
                {
                    string __tmp28_line = __tmp28Reader.ReadLine();
                    __tmp28_last = __tmp28Reader.EndOfStream;
                    if ((__tmp28_last && !string.IsNullOrEmpty(__tmp28_line)) || (!__tmp28_last && __tmp28_line != null))
                    {
                        __out.Append(__tmp28_line);
                        __tmp24_outputWritten = true;
                    }
                    if (!__tmp28_last) __out.AppendLine(true);
                }
            }
            string __tmp29_line = ".MMetaModel;"; //419:116
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Append(__tmp29_line);
                __tmp24_outputWritten = true;
            }
            if (__tmp24_outputWritten) __out.AppendLine(true);
            if (__tmp24_outputWritten)
            {
                __out.AppendLine(false); //419:128
            }
            __out.AppendLine(true); //420:1
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "	public override "; //421:1
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Append(__tmp32_line);
                __tmp31_outputWritten = true;
            }
            StringBuilder __tmp33 = new StringBuilder();
            __tmp33.Append(Properties.CoreNs);
            using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
            {
                bool __tmp33_last = __tmp33Reader.EndOfStream;
                while(!__tmp33_last)
                {
                    string __tmp33_line = __tmp33Reader.ReadLine();
                    __tmp33_last = __tmp33Reader.EndOfStream;
                    if ((__tmp33_last && !string.IsNullOrEmpty(__tmp33_line)) || (!__tmp33_last && __tmp33_line != null))
                    {
                        __out.Append(__tmp33_line);
                        __tmp31_outputWritten = true;
                    }
                    if (!__tmp33_last) __out.AppendLine(true);
                }
            }
            string __tmp34_line = ".MutableObject Create(string type)"; //421:37
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Append(__tmp34_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //421:71
            }
            __out.Append("	{"); //422:1
            __out.AppendLine(false); //422:3
            __out.Append("		switch (type)"); //423:1
            __out.AppendLine(false); //423:16
            __out.Append("		{"); //424:1
            __out.AppendLine(false); //424:4
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //425:10
                from cls in __Enumerate((__loop20_var1).GetEnumerator()).OfType<MetaClass>() //425:40
                select new { __loop20_var1 = __loop20_var1, cls = cls}
                ).ToList(); //425:5
            for (int __loop20_iteration = 0; __loop20_iteration < __loop20_results.Count; ++__loop20_iteration)
            {
                var __tmp35 = __loop20_results[__loop20_iteration];
                var __loop20_var1 = __tmp35.__loop20_var1;
                var cls = __tmp35.cls;
                if (!cls.IsAbstract) //426:6
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "			case \""; //427:1
                    if (!string.IsNullOrEmpty(__tmp38_line))
                    {
                        __out.Append(__tmp38_line);
                        __tmp37_outputWritten = true;
                    }
                    StringBuilder __tmp39 = new StringBuilder();
                    __tmp39.Append(CSharpName(cls, model));
                    using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
                    {
                        bool __tmp39_last = __tmp39Reader.EndOfStream;
                        while(!__tmp39_last)
                        {
                            string __tmp39_line = __tmp39Reader.ReadLine();
                            __tmp39_last = __tmp39Reader.EndOfStream;
                            if ((__tmp39_last && !string.IsNullOrEmpty(__tmp39_line)) || (!__tmp39_last && __tmp39_line != null))
                            {
                                __out.Append(__tmp39_line);
                                __tmp37_outputWritten = true;
                            }
                            if (!__tmp39_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp40_line = "\": return this."; //427:33
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Append(__tmp40_line);
                        __tmp37_outputWritten = true;
                    }
                    StringBuilder __tmp41 = new StringBuilder();
                    __tmp41.Append(CSharpName(cls, model));
                    using(StreamReader __tmp41Reader = new StreamReader(this.__ToStream(__tmp41.ToString())))
                    {
                        bool __tmp41_last = __tmp41Reader.EndOfStream;
                        while(!__tmp41_last)
                        {
                            string __tmp41_line = __tmp41Reader.ReadLine();
                            __tmp41_last = __tmp41Reader.EndOfStream;
                            if ((__tmp41_last && !string.IsNullOrEmpty(__tmp41_line)) || (!__tmp41_last && __tmp41_line != null))
                            {
                                __out.Append(__tmp41_line);
                                __tmp37_outputWritten = true;
                            }
                            if (!__tmp41_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp42_line = "();"; //427:71
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Append(__tmp42_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //427:74
                    }
                }
            }
            __out.Append("			default:"); //430:1
            __out.AppendLine(false); //430:12
            bool __tmp44_outputWritten = false;
            string __tmp45_line = "				throw new "; //431:1
            if (!string.IsNullOrEmpty(__tmp45_line))
            {
                __out.Append(__tmp45_line);
                __tmp44_outputWritten = true;
            }
            StringBuilder __tmp46 = new StringBuilder();
            __tmp46.Append(Properties.CoreNs);
            using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
            {
                bool __tmp46_last = __tmp46Reader.EndOfStream;
                while(!__tmp46_last)
                {
                    string __tmp46_line = __tmp46Reader.ReadLine();
                    __tmp46_last = __tmp46Reader.EndOfStream;
                    if ((__tmp46_last && !string.IsNullOrEmpty(__tmp46_line)) || (!__tmp46_last && __tmp46_line != null))
                    {
                        __out.Append(__tmp46_line);
                        __tmp44_outputWritten = true;
                    }
                    if (!__tmp46_last) __out.AppendLine(true);
                }
            }
            string __tmp47_line = ".ModelException("; //431:34
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Append(__tmp47_line);
                __tmp44_outputWritten = true;
            }
            StringBuilder __tmp48 = new StringBuilder();
            __tmp48.Append(Properties.CoreNs);
            using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
            {
                bool __tmp48_last = __tmp48Reader.EndOfStream;
                while(!__tmp48_last)
                {
                    string __tmp48_line = __tmp48Reader.ReadLine();
                    __tmp48_last = __tmp48Reader.EndOfStream;
                    if ((__tmp48_last && !string.IsNullOrEmpty(__tmp48_line)) || (!__tmp48_last && __tmp48_line != null))
                    {
                        __out.Append(__tmp48_line);
                        __tmp44_outputWritten = true;
                    }
                    if (!__tmp48_last) __out.AppendLine(true);
                }
            }
            string __tmp49_line = ".ModelErrorCode.ERR_UnknownTypeName.ToDiagnosticWithNoLocation(type));"; //431:69
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Append(__tmp49_line);
                __tmp44_outputWritten = true;
            }
            if (__tmp44_outputWritten) __out.AppendLine(true);
            if (__tmp44_outputWritten)
            {
                __out.AppendLine(false); //431:139
            }
            __out.Append("		}"); //432:1
            __out.AppendLine(false); //432:4
            __out.Append("	}"); //433:1
            __out.AppendLine(false); //433:3
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //434:8
                from cls in __Enumerate((__loop21_var1).GetEnumerator()).OfType<MetaClass>() //434:38
                select new { __loop21_var1 = __loop21_var1, cls = cls}
                ).ToList(); //434:3
            for (int __loop21_iteration = 0; __loop21_iteration < __loop21_results.Count; ++__loop21_iteration)
            {
                var __tmp50 = __loop21_results[__loop21_iteration];
                var __loop21_var1 = __tmp50.__loop21_var1;
                var cls = __tmp50.cls;
                if (!cls.IsAbstract) //435:4
                {
                    __out.AppendLine(true); //436:1
                    __out.Append("	/// <summary>"); //437:1
                    __out.AppendLine(false); //437:15
                    bool __tmp52_outputWritten = false;
                    string __tmp53_line = "	/// Creates a new instance of "; //438:1
                    if (!string.IsNullOrEmpty(__tmp53_line))
                    {
                        __out.Append(__tmp53_line);
                        __tmp52_outputWritten = true;
                    }
                    StringBuilder __tmp54 = new StringBuilder();
                    __tmp54.Append(CSharpName(cls, model));
                    using(StreamReader __tmp54Reader = new StreamReader(this.__ToStream(__tmp54.ToString())))
                    {
                        bool __tmp54_last = __tmp54Reader.EndOfStream;
                        while(!__tmp54_last)
                        {
                            string __tmp54_line = __tmp54Reader.ReadLine();
                            __tmp54_last = __tmp54Reader.EndOfStream;
                            if ((__tmp54_last && !string.IsNullOrEmpty(__tmp54_line)) || (!__tmp54_last && __tmp54_line != null))
                            {
                                __out.Append(__tmp54_line);
                                __tmp52_outputWritten = true;
                            }
                            if (!__tmp54_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp55_line = "."; //438:55
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Append(__tmp55_line);
                        __tmp52_outputWritten = true;
                    }
                    if (__tmp52_outputWritten) __out.AppendLine(true);
                    if (__tmp52_outputWritten)
                    {
                        __out.AppendLine(false); //438:56
                    }
                    __out.Append("	/// </summary>"); //439:1
                    __out.AppendLine(false); //439:16
                    bool __tmp57_outputWritten = false;
                    string __tmp58_line = "	public "; //440:1
                    if (!string.IsNullOrEmpty(__tmp58_line))
                    {
                        __out.Append(__tmp58_line);
                        __tmp57_outputWritten = true;
                    }
                    StringBuilder __tmp59 = new StringBuilder();
                    __tmp59.Append(CSharpName(cls, model, ClassKind.Builder));
                    using(StreamReader __tmp59Reader = new StreamReader(this.__ToStream(__tmp59.ToString())))
                    {
                        bool __tmp59_last = __tmp59Reader.EndOfStream;
                        while(!__tmp59_last)
                        {
                            string __tmp59_line = __tmp59Reader.ReadLine();
                            __tmp59_last = __tmp59Reader.EndOfStream;
                            if ((__tmp59_last && !string.IsNullOrEmpty(__tmp59_line)) || (!__tmp59_last && __tmp59_line != null))
                            {
                                __out.Append(__tmp59_line);
                                __tmp57_outputWritten = true;
                            }
                            if (!__tmp59_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp60_line = " "; //440:51
                    if (!string.IsNullOrEmpty(__tmp60_line))
                    {
                        __out.Append(__tmp60_line);
                        __tmp57_outputWritten = true;
                    }
                    StringBuilder __tmp61 = new StringBuilder();
                    __tmp61.Append(CSharpName(cls, model, ClassKind.FactoryMethod));
                    using(StreamReader __tmp61Reader = new StreamReader(this.__ToStream(__tmp61.ToString())))
                    {
                        bool __tmp61_last = __tmp61Reader.EndOfStream;
                        while(!__tmp61_last)
                        {
                            string __tmp61_line = __tmp61Reader.ReadLine();
                            __tmp61_last = __tmp61Reader.EndOfStream;
                            if ((__tmp61_last && !string.IsNullOrEmpty(__tmp61_line)) || (!__tmp61_last && __tmp61_line != null))
                            {
                                __out.Append(__tmp61_line);
                                __tmp57_outputWritten = true;
                            }
                            if (!__tmp61_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp62_line = "()"; //440:100
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Append(__tmp62_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //440:102
                    }
                    __out.Append("	{"); //441:1
                    __out.AppendLine(false); //441:3
                    bool __tmp64_outputWritten = false;
                    string __tmp63Prefix = "		"; //442:1
                    StringBuilder __tmp65 = new StringBuilder();
                    __tmp65.Append(Properties.CoreNs);
                    using(StreamReader __tmp65Reader = new StreamReader(this.__ToStream(__tmp65.ToString())))
                    {
                        bool __tmp65_last = __tmp65Reader.EndOfStream;
                        while(!__tmp65_last)
                        {
                            string __tmp65_line = __tmp65Reader.ReadLine();
                            __tmp65_last = __tmp65Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp63Prefix))
                            {
                                __out.Append(__tmp63Prefix);
                                __tmp64_outputWritten = true;
                            }
                            if ((__tmp65_last && !string.IsNullOrEmpty(__tmp65_line)) || (!__tmp65_last && __tmp65_line != null))
                            {
                                __out.Append(__tmp65_line);
                                __tmp64_outputWritten = true;
                            }
                            if (!__tmp65_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp66_line = ".MutableObject obj = this.CreateObject(new "; //442:22
                    if (!string.IsNullOrEmpty(__tmp66_line))
                    {
                        __out.Append(__tmp66_line);
                        __tmp64_outputWritten = true;
                    }
                    StringBuilder __tmp67 = new StringBuilder();
                    __tmp67.Append(CSharpName(cls, model, ClassKind.Id));
                    using(StreamReader __tmp67Reader = new StreamReader(this.__ToStream(__tmp67.ToString())))
                    {
                        bool __tmp67_last = __tmp67Reader.EndOfStream;
                        while(!__tmp67_last)
                        {
                            string __tmp67_line = __tmp67Reader.ReadLine();
                            __tmp67_last = __tmp67Reader.EndOfStream;
                            if ((__tmp67_last && !string.IsNullOrEmpty(__tmp67_line)) || (!__tmp67_last && __tmp67_line != null))
                            {
                                __out.Append(__tmp67_line);
                                __tmp64_outputWritten = true;
                            }
                            if (!__tmp67_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp68_line = "());"; //442:102
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Append(__tmp68_line);
                        __tmp64_outputWritten = true;
                    }
                    if (__tmp64_outputWritten) __out.AppendLine(true);
                    if (__tmp64_outputWritten)
                    {
                        __out.AppendLine(false); //442:106
                    }
                    bool __tmp70_outputWritten = false;
                    string __tmp71_line = "		return ("; //443:1
                    if (!string.IsNullOrEmpty(__tmp71_line))
                    {
                        __out.Append(__tmp71_line);
                        __tmp70_outputWritten = true;
                    }
                    StringBuilder __tmp72 = new StringBuilder();
                    __tmp72.Append(CSharpName(cls, model, ClassKind.Builder));
                    using(StreamReader __tmp72Reader = new StreamReader(this.__ToStream(__tmp72.ToString())))
                    {
                        bool __tmp72_last = __tmp72Reader.EndOfStream;
                        while(!__tmp72_last)
                        {
                            string __tmp72_line = __tmp72Reader.ReadLine();
                            __tmp72_last = __tmp72Reader.EndOfStream;
                            if ((__tmp72_last && !string.IsNullOrEmpty(__tmp72_line)) || (!__tmp72_last && __tmp72_line != null))
                            {
                                __out.Append(__tmp72_line);
                                __tmp70_outputWritten = true;
                            }
                            if (!__tmp72_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp73_line = ")obj;"; //443:53
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Append(__tmp73_line);
                        __tmp70_outputWritten = true;
                    }
                    if (__tmp70_outputWritten) __out.AppendLine(true);
                    if (__tmp70_outputWritten)
                    {
                        __out.AppendLine(false); //443:58
                    }
                    __out.Append("	}"); //444:1
                    __out.AppendLine(false); //444:3
                }
            }
            __out.Append("}"); //447:1
            __out.AppendLine(false); //447:2
            __out.AppendLine(true); //448:1
            return __out.ToString();
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //451:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //452:2
            bool metaMetaModel = IsMetaMetaModel(model); //453:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public static class "; //454:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(CSharpName(model, ModelKind.Descriptor));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //454:61
            }
            __out.Append("{"); //455:1
            __out.AppendLine(false); //455:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	private static global::System.Collections.Generic.List<"; //456:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(Properties.CoreNs);
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp6_outputWritten = true;
                    }
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9_line = ".ModelProperty> properties;"; //456:76
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //456:103
            }
            __out.AppendLine(true); //457:1
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	static "; //458:1
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Append(__tmp12_line);
                __tmp11_outputWritten = true;
            }
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(CSharpName(model, ModelKind.Descriptor));
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13_line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if ((__tmp13_last && !string.IsNullOrEmpty(__tmp13_line)) || (!__tmp13_last && __tmp13_line != null))
                    {
                        __out.Append(__tmp13_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14_line = "()"; //458:49
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //458:51
            }
            __out.Append("	{"); //459:1
            __out.AppendLine(false); //459:3
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "		properties = new global::System.Collections.Generic.List<"; //460:1
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp16_outputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(Properties.CoreNs);
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    string __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                    {
                        __out.Append(__tmp18_line);
                        __tmp16_outputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19_line = ".ModelProperty>();"; //460:79
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //460:97
            }
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //461:9
                from cls in __Enumerate((__loop22_var1).GetEnumerator()).OfType<MetaClass>() //461:39
                select new { __loop22_var1 = __loop22_var1, cls = cls}
                ).ToList(); //461:4
            for (int __loop22_iteration = 0; __loop22_iteration < __loop22_results.Count; ++__loop22_iteration)
            {
                var __tmp20 = __loop22_results[__loop22_iteration];
                var __loop22_var1 = __tmp20.__loop22_var1;
                var cls = __tmp20.cls;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "		"; //462:1
                StringBuilder __tmp23 = new StringBuilder();
                __tmp23.Append(CSharpName(cls, model, ClassKind.Descriptor));
                using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
                {
                    bool __tmp23_last = __tmp23Reader.EndOfStream;
                    while(!__tmp23_last)
                    {
                        string __tmp23_line = __tmp23Reader.ReadLine();
                        __tmp23_last = __tmp23Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp21Prefix))
                        {
                            __out.Append(__tmp21Prefix);
                            __tmp22_outputWritten = true;
                        }
                        if ((__tmp23_last && !string.IsNullOrEmpty(__tmp23_line)) || (!__tmp23_last && __tmp23_line != null))
                        {
                            __out.Append(__tmp23_line);
                            __tmp22_outputWritten = true;
                        }
                        if (!__tmp23_last) __out.AppendLine(true);
                    }
                }
                string __tmp24_line = ".Initialize();"; //462:48
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Append(__tmp24_line);
                    __tmp22_outputWritten = true;
                }
                if (__tmp22_outputWritten) __out.AppendLine(true);
                if (__tmp22_outputWritten)
                {
                    __out.AppendLine(false); //462:62
                }
            }
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //464:9
                from cls in __Enumerate((__loop23_var1).GetEnumerator()).OfType<MetaClass>() //464:39
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //464:62
                select new { __loop23_var1 = __loop23_var1, cls = cls, prop = prop}
                ).ToList(); //464:4
            for (int __loop23_iteration = 0; __loop23_iteration < __loop23_results.Count; ++__loop23_iteration)
            {
                var __tmp25 = __loop23_results[__loop23_iteration];
                var __loop23_var1 = __tmp25.__loop23_var1;
                var cls = __tmp25.cls;
                var prop = __tmp25.prop;
                bool __tmp27_outputWritten = false;
                string __tmp28_line = "		properties.Add("; //465:1
                if (!string.IsNullOrEmpty(__tmp28_line))
                {
                    __out.Append(__tmp28_line);
                    __tmp27_outputWritten = true;
                }
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(CSharpName(prop, model, PropertyKind.Descriptor, true));
                using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                {
                    bool __tmp29_last = __tmp29Reader.EndOfStream;
                    while(!__tmp29_last)
                    {
                        string __tmp29_line = __tmp29Reader.ReadLine();
                        __tmp29_last = __tmp29Reader.EndOfStream;
                        if ((__tmp29_last && !string.IsNullOrEmpty(__tmp29_line)) || (!__tmp29_last && __tmp29_line != null))
                        {
                            __out.Append(__tmp29_line);
                            __tmp27_outputWritten = true;
                        }
                        if (!__tmp29_last) __out.AppendLine(true);
                    }
                }
                string __tmp30_line = ");"; //465:73
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Append(__tmp30_line);
                    __tmp27_outputWritten = true;
                }
                if (__tmp27_outputWritten) __out.AppendLine(true);
                if (__tmp27_outputWritten)
                {
                    __out.AppendLine(false); //465:75
                }
            }
            __out.Append("	}"); //467:1
            __out.AppendLine(false); //467:3
            __out.AppendLine(true); //468:1
            __out.Append("	public static void Initialize()"); //469:1
            __out.AppendLine(false); //469:33
            __out.Append("	{"); //470:1
            __out.AppendLine(false); //470:3
            __out.Append("	}"); //471:1
            __out.AppendLine(false); //471:3
            __out.AppendLine(true); //472:1
            bool __tmp32_outputWritten = false;
            string __tmp33_line = "	public const string MUri = \""; //473:1
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Append(__tmp33_line);
                __tmp32_outputWritten = true;
            }
            StringBuilder __tmp34 = new StringBuilder();
            __tmp34.Append(model.Uri);
            using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
            {
                bool __tmp34_last = __tmp34Reader.EndOfStream;
                while(!__tmp34_last)
                {
                    string __tmp34_line = __tmp34Reader.ReadLine();
                    __tmp34_last = __tmp34Reader.EndOfStream;
                    if ((__tmp34_last && !string.IsNullOrEmpty(__tmp34_line)) || (!__tmp34_last && __tmp34_line != null))
                    {
                        __out.Append(__tmp34_line);
                        __tmp32_outputWritten = true;
                    }
                    if (!__tmp34_last) __out.AppendLine(true);
                }
            }
            string __tmp35_line = "\";"; //473:41
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Append(__tmp35_line);
                __tmp32_outputWritten = true;
            }
            if (__tmp32_outputWritten) __out.AppendLine(true);
            if (__tmp32_outputWritten)
            {
                __out.AppendLine(false); //473:43
            }
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "	public const string MPrefix = \""; //474:1
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Append(__tmp38_line);
                __tmp37_outputWritten = true;
            }
            StringBuilder __tmp39 = new StringBuilder();
            __tmp39.Append(model.Prefix);
            using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
            {
                bool __tmp39_last = __tmp39Reader.EndOfStream;
                while(!__tmp39_last)
                {
                    string __tmp39_line = __tmp39Reader.ReadLine();
                    __tmp39_last = __tmp39Reader.EndOfStream;
                    if ((__tmp39_last && !string.IsNullOrEmpty(__tmp39_line)) || (!__tmp39_last && __tmp39_line != null))
                    {
                        __out.Append(__tmp39_line);
                        __tmp37_outputWritten = true;
                    }
                    if (!__tmp39_last) __out.AppendLine(true);
                }
            }
            string __tmp40_line = "\";"; //474:47
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Append(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //474:49
            }
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //475:8
                from cls in __Enumerate((__loop24_var1).GetEnumerator()).OfType<MetaClass>() //475:38
                select new { __loop24_var1 = __loop24_var1, cls = cls}
                ).ToList(); //475:3
            for (int __loop24_iteration = 0; __loop24_iteration < __loop24_results.Count; ++__loop24_iteration)
            {
                var __tmp41 = __loop24_results[__loop24_iteration];
                var __loop24_var1 = __tmp41.__loop24_var1;
                var cls = __tmp41.cls;
                __out.AppendLine(true); //476:1
                bool __tmp43_outputWritten = false;
                string __tmp42Prefix = "	"; //477:1
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(GenerateDescriptorClass(model, cls));
                using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                {
                    bool __tmp44_last = __tmp44Reader.EndOfStream;
                    while(!__tmp44_last)
                    {
                        string __tmp44_line = __tmp44Reader.ReadLine();
                        __tmp44_last = __tmp44Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp42Prefix))
                        {
                            __out.Append(__tmp42Prefix);
                            __tmp43_outputWritten = true;
                        }
                        if ((__tmp44_last && !string.IsNullOrEmpty(__tmp44_line)) || (!__tmp44_last && __tmp44_line != null))
                        {
                            __out.Append(__tmp44_line);
                            __tmp43_outputWritten = true;
                        }
                        if (!__tmp44_last || __tmp43_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //477:39
                }
            }
            __out.Append("}"); //479:1
            __out.AppendLine(false); //479:2
            return __out.ToString();
        }

        public string GenerateDescriptorClass(MetaModel model, MetaClass cls) //482:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(cls));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3_line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                    {
                        __out.Append(__tmp3_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp3_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //483:29
            }
            bool __tmp5_outputWritten = false;
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GenerateAttributes(cls));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                    {
                        __out.Append(__tmp6_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp6_last || __tmp5_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //484:26
            }
            bool __tmp8_outputWritten = false;
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append("[" + Properties.CoreNs);
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9_line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if ((__tmp9_last && !string.IsNullOrEmpty(__tmp9_line)) || (!__tmp9_last && __tmp9_line != null))
                    {
                        __out.Append(__tmp9_line);
                        __tmp8_outputWritten = true;
                    }
                    if (!__tmp9_last) __out.AppendLine(true);
                }
            }
            string __tmp10_line = ".ModelObjectDescriptorAttribute(typeof("; //485:24
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp8_outputWritten = true;
            }
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(CSharpName(cls, null, ClassKind.Id, true));
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(!__tmp11_last)
                {
                    string __tmp11_line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    if ((__tmp11_last && !string.IsNullOrEmpty(__tmp11_line)) || (!__tmp11_last && __tmp11_line != null))
                    {
                        __out.Append(__tmp11_line);
                        __tmp8_outputWritten = true;
                    }
                    if (!__tmp11_last) __out.AppendLine(true);
                }
            }
            string __tmp12_line = "), typeof("; //485:105
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Append(__tmp12_line);
                __tmp8_outputWritten = true;
            }
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(CSharpName(cls, null, ClassKind.Immutable, true));
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13_line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if ((__tmp13_last && !string.IsNullOrEmpty(__tmp13_line)) || (!__tmp13_last && __tmp13_line != null))
                    {
                        __out.Append(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14_line = "), typeof("; //485:164
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp8_outputWritten = true;
            }
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(CSharpName(cls, null, ClassKind.Builder, true));
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_last = __tmp15Reader.EndOfStream;
                while(!__tmp15_last)
                {
                    string __tmp15_line = __tmp15Reader.ReadLine();
                    __tmp15_last = __tmp15Reader.EndOfStream;
                    if ((__tmp15_last && !string.IsNullOrEmpty(__tmp15_line)) || (!__tmp15_last && __tmp15_line != null))
                    {
                        __out.Append(__tmp15_line);
                        __tmp8_outputWritten = true;
                    }
                    if (!__tmp15_last) __out.AppendLine(true);
                }
            }
            string __tmp16_line = ")"; //485:221
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Append(__tmp16_line);
                __tmp8_outputWritten = true;
            }
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(GetDescriptorAncestors(model, cls));
            using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
            {
                bool __tmp17_last = __tmp17Reader.EndOfStream;
                while(!__tmp17_last)
                {
                    string __tmp17_line = __tmp17Reader.ReadLine();
                    __tmp17_last = __tmp17Reader.EndOfStream;
                    if ((__tmp17_last && !string.IsNullOrEmpty(__tmp17_line)) || (!__tmp17_last && __tmp17_line != null))
                    {
                        __out.Append(__tmp17_line);
                        __tmp8_outputWritten = true;
                    }
                    if (!__tmp17_last) __out.AppendLine(true);
                }
            }
            string __tmp18_line = ")"; //485:258
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Append(__tmp18_line);
                __tmp8_outputWritten = true;
            }
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append("]");
            using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
            {
                bool __tmp19_last = __tmp19Reader.EndOfStream;
                while(!__tmp19_last)
                {
                    string __tmp19_line = __tmp19Reader.ReadLine();
                    __tmp19_last = __tmp19Reader.EndOfStream;
                    if ((__tmp19_last && !string.IsNullOrEmpty(__tmp19_line)) || (!__tmp19_last && __tmp19_line != null))
                    {
                        __out.Append(__tmp19_line);
                        __tmp8_outputWritten = true;
                    }
                    if (!__tmp19_last || __tmp8_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp8_outputWritten)
            {
                __out.AppendLine(false); //485:264
            }
            bool __tmp21_outputWritten = false;
            string __tmp22_line = "public static class "; //486:1
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Append(__tmp22_line);
                __tmp21_outputWritten = true;
            }
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(CSharpName(cls, model, ClassKind.Descriptor));
            using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
            {
                bool __tmp23_last = __tmp23Reader.EndOfStream;
                while(!__tmp23_last)
                {
                    string __tmp23_line = __tmp23Reader.ReadLine();
                    __tmp23_last = __tmp23Reader.EndOfStream;
                    if ((__tmp23_last && !string.IsNullOrEmpty(__tmp23_line)) || (!__tmp23_last && __tmp23_line != null))
                    {
                        __out.Append(__tmp23_line);
                        __tmp21_outputWritten = true;
                    }
                    if (!__tmp23_last || __tmp21_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp21_outputWritten)
            {
                __out.AppendLine(false); //486:66
            }
            __out.Append("{"); //487:1
            __out.AppendLine(false); //487:2
            bool __tmp25_outputWritten = false;
            string __tmp26_line = "	private static "; //488:1
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp25_outputWritten = true;
            }
            StringBuilder __tmp27 = new StringBuilder();
            __tmp27.Append(Properties.CoreNs);
            using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
            {
                bool __tmp27_last = __tmp27Reader.EndOfStream;
                while(!__tmp27_last)
                {
                    string __tmp27_line = __tmp27Reader.ReadLine();
                    __tmp27_last = __tmp27Reader.EndOfStream;
                    if ((__tmp27_last && !string.IsNullOrEmpty(__tmp27_line)) || (!__tmp27_last && __tmp27_line != null))
                    {
                        __out.Append(__tmp27_line);
                        __tmp25_outputWritten = true;
                    }
                    if (!__tmp27_last) __out.AppendLine(true);
                }
            }
            string __tmp28_line = ".ModelObjectDescriptor descriptor;"; //488:36
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Append(__tmp28_line);
                __tmp25_outputWritten = true;
            }
            if (__tmp25_outputWritten) __out.AppendLine(true);
            if (__tmp25_outputWritten)
            {
                __out.AppendLine(false); //488:70
            }
            __out.AppendLine(true); //489:1
            bool __tmp30_outputWritten = false;
            string __tmp31_line = "	static "; //490:1
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Append(__tmp31_line);
                __tmp30_outputWritten = true;
            }
            StringBuilder __tmp32 = new StringBuilder();
            __tmp32.Append(CSharpName(cls, model, ClassKind.Descriptor));
            using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
            {
                bool __tmp32_last = __tmp32Reader.EndOfStream;
                while(!__tmp32_last)
                {
                    string __tmp32_line = __tmp32Reader.ReadLine();
                    __tmp32_last = __tmp32Reader.EndOfStream;
                    if ((__tmp32_last && !string.IsNullOrEmpty(__tmp32_line)) || (!__tmp32_last && __tmp32_line != null))
                    {
                        __out.Append(__tmp32_line);
                        __tmp30_outputWritten = true;
                    }
                    if (!__tmp32_last) __out.AppendLine(true);
                }
            }
            string __tmp33_line = "()"; //490:54
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Append(__tmp33_line);
                __tmp30_outputWritten = true;
            }
            if (__tmp30_outputWritten) __out.AppendLine(true);
            if (__tmp30_outputWritten)
            {
                __out.AppendLine(false); //490:56
            }
            __out.Append("	{"); //491:1
            __out.AppendLine(false); //491:3
            bool __tmp35_outputWritten = false;
            string __tmp36_line = "		descriptor = "; //492:1
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Append(__tmp36_line);
                __tmp35_outputWritten = true;
            }
            StringBuilder __tmp37 = new StringBuilder();
            __tmp37.Append(Properties.CoreNs);
            using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
            {
                bool __tmp37_last = __tmp37Reader.EndOfStream;
                while(!__tmp37_last)
                {
                    string __tmp37_line = __tmp37Reader.ReadLine();
                    __tmp37_last = __tmp37Reader.EndOfStream;
                    if ((__tmp37_last && !string.IsNullOrEmpty(__tmp37_line)) || (!__tmp37_last && __tmp37_line != null))
                    {
                        __out.Append(__tmp37_line);
                        __tmp35_outputWritten = true;
                    }
                    if (!__tmp37_last) __out.AppendLine(true);
                }
            }
            string __tmp38_line = ".ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof("; //492:35
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Append(__tmp38_line);
                __tmp35_outputWritten = true;
            }
            StringBuilder __tmp39 = new StringBuilder();
            __tmp39.Append(CSharpName(cls, model, ClassKind.Descriptor));
            using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
            {
                bool __tmp39_last = __tmp39Reader.EndOfStream;
                while(!__tmp39_last)
                {
                    string __tmp39_line = __tmp39Reader.ReadLine();
                    __tmp39_last = __tmp39Reader.EndOfStream;
                    if ((__tmp39_last && !string.IsNullOrEmpty(__tmp39_line)) || (!__tmp39_last && __tmp39_line != null))
                    {
                        __out.Append(__tmp39_line);
                        __tmp35_outputWritten = true;
                    }
                    if (!__tmp39_last) __out.AppendLine(true);
                }
            }
            string __tmp40_line = "));"; //492:141
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Append(__tmp40_line);
                __tmp35_outputWritten = true;
            }
            if (__tmp35_outputWritten) __out.AppendLine(true);
            if (__tmp35_outputWritten)
            {
                __out.AppendLine(false); //492:144
            }
            __out.Append("	}"); //493:1
            __out.AppendLine(false); //493:3
            __out.AppendLine(true); //494:1
            __out.Append("	internal static void Initialize()"); //495:1
            __out.AppendLine(false); //495:35
            __out.Append("	{"); //496:1
            __out.AppendLine(false); //496:3
            __out.Append("	}"); //497:1
            __out.AppendLine(false); //497:3
            __out.AppendLine(true); //498:1
            bool __tmp42_outputWritten = false;
            string __tmp43_line = "	public static "; //499:1
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Append(__tmp43_line);
                __tmp42_outputWritten = true;
            }
            StringBuilder __tmp44 = new StringBuilder();
            __tmp44.Append(Properties.CoreNs);
            using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
            {
                bool __tmp44_last = __tmp44Reader.EndOfStream;
                while(!__tmp44_last)
                {
                    string __tmp44_line = __tmp44Reader.ReadLine();
                    __tmp44_last = __tmp44Reader.EndOfStream;
                    if ((__tmp44_last && !string.IsNullOrEmpty(__tmp44_line)) || (!__tmp44_last && __tmp44_line != null))
                    {
                        __out.Append(__tmp44_line);
                        __tmp42_outputWritten = true;
                    }
                    if (!__tmp44_last) __out.AppendLine(true);
                }
            }
            string __tmp45_line = ".ModelObjectDescriptor MDescriptor"; //499:35
            if (!string.IsNullOrEmpty(__tmp45_line))
            {
                __out.Append(__tmp45_line);
                __tmp42_outputWritten = true;
            }
            if (__tmp42_outputWritten) __out.AppendLine(true);
            if (__tmp42_outputWritten)
            {
                __out.AppendLine(false); //499:69
            }
            __out.Append("	{"); //500:1
            __out.AppendLine(false); //500:3
            __out.Append("		get { return descriptor; }"); //501:1
            __out.AppendLine(false); //501:29
            __out.Append("	}"); //502:1
            __out.AppendLine(false); //502:3
            __out.AppendLine(true); //503:1
            bool __tmp47_outputWritten = false;
            string __tmp48_line = "	public static "; //504:1
            if (!string.IsNullOrEmpty(__tmp48_line))
            {
                __out.Append(__tmp48_line);
                __tmp47_outputWritten = true;
            }
            StringBuilder __tmp49 = new StringBuilder();
            __tmp49.Append(Properties.MetaNs);
            using(StreamReader __tmp49Reader = new StreamReader(this.__ToStream(__tmp49.ToString())))
            {
                bool __tmp49_last = __tmp49Reader.EndOfStream;
                while(!__tmp49_last)
                {
                    string __tmp49_line = __tmp49Reader.ReadLine();
                    __tmp49_last = __tmp49Reader.EndOfStream;
                    if ((__tmp49_last && !string.IsNullOrEmpty(__tmp49_line)) || (!__tmp49_last && __tmp49_line != null))
                    {
                        __out.Append(__tmp49_line);
                        __tmp47_outputWritten = true;
                    }
                    if (!__tmp49_last) __out.AppendLine(true);
                }
            }
            string __tmp50_line = ".MetaClass MMetaClass"; //504:35
            if (!string.IsNullOrEmpty(__tmp50_line))
            {
                __out.Append(__tmp50_line);
                __tmp47_outputWritten = true;
            }
            if (__tmp47_outputWritten) __out.AppendLine(true);
            if (__tmp47_outputWritten)
            {
                __out.AppendLine(false); //504:56
            }
            __out.Append("	{"); //505:1
            __out.AppendLine(false); //505:3
            bool __tmp52_outputWritten = false;
            string __tmp53_line = "		get { return "; //506:1
            if (!string.IsNullOrEmpty(__tmp53_line))
            {
                __out.Append(__tmp53_line);
                __tmp52_outputWritten = true;
            }
            StringBuilder __tmp54 = new StringBuilder();
            __tmp54.Append(CSharpName(cls, null, ClassKind.ImmutableInstance, true));
            using(StreamReader __tmp54Reader = new StreamReader(this.__ToStream(__tmp54.ToString())))
            {
                bool __tmp54_last = __tmp54Reader.EndOfStream;
                while(!__tmp54_last)
                {
                    string __tmp54_line = __tmp54Reader.ReadLine();
                    __tmp54_last = __tmp54Reader.EndOfStream;
                    if ((__tmp54_last && !string.IsNullOrEmpty(__tmp54_line)) || (!__tmp54_last && __tmp54_line != null))
                    {
                        __out.Append(__tmp54_line);
                        __tmp52_outputWritten = true;
                    }
                    if (!__tmp54_last) __out.AppendLine(true);
                }
            }
            string __tmp55_line = "; }"; //506:73
            if (!string.IsNullOrEmpty(__tmp55_line))
            {
                __out.Append(__tmp55_line);
                __tmp52_outputWritten = true;
            }
            if (__tmp52_outputWritten) __out.AppendLine(true);
            if (__tmp52_outputWritten)
            {
                __out.AppendLine(false); //506:76
            }
            __out.Append("	}"); //507:1
            __out.AppendLine(false); //507:3
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //508:8
                from prop in __Enumerate((__loop25_var1.Properties).GetEnumerator()) //508:13
                select new { __loop25_var1 = __loop25_var1, prop = prop}
                ).ToList(); //508:3
            for (int __loop25_iteration = 0; __loop25_iteration < __loop25_results.Count; ++__loop25_iteration)
            {
                var __tmp56 = __loop25_results[__loop25_iteration];
                var __loop25_var1 = __tmp56.__loop25_var1;
                var prop = __tmp56.prop;
                bool __tmp58_outputWritten = false;
                string __tmp57Prefix = "	"; //509:1
                StringBuilder __tmp59 = new StringBuilder();
                __tmp59.Append(GenerateDescriptorProperty(model, cls, prop));
                using(StreamReader __tmp59Reader = new StreamReader(this.__ToStream(__tmp59.ToString())))
                {
                    bool __tmp59_last = __tmp59Reader.EndOfStream;
                    while(!__tmp59_last)
                    {
                        string __tmp59_line = __tmp59Reader.ReadLine();
                        __tmp59_last = __tmp59Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp57Prefix))
                        {
                            __out.Append(__tmp57Prefix);
                            __tmp58_outputWritten = true;
                        }
                        if ((__tmp59_last && !string.IsNullOrEmpty(__tmp59_line)) || (!__tmp59_last && __tmp59_line != null))
                        {
                            __out.Append(__tmp59_line);
                            __tmp58_outputWritten = true;
                        }
                        if (!__tmp59_last || __tmp58_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp58_outputWritten)
                {
                    __out.AppendLine(false); //509:48
                }
            }
            __out.Append("}"); //511:1
            __out.AppendLine(false); //511:2
            return __out.ToString();
        }

        public string GetDescriptorAncestors(MetaModel model, MetaClass cls) //514:1
        {
            string result = ""; //515:2
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //516:7
                from super in __Enumerate((__loop26_var1.SuperClasses).GetEnumerator()) //516:12
                select new { __loop26_var1 = __loop26_var1, super = super}
                ).ToList(); //516:2
            for (int __loop26_iteration = 0; __loop26_iteration < __loop26_results.Count; ++__loop26_iteration)
            {
                string delim; //516:30
                if (__loop26_iteration+1 < __loop26_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop26_results[__loop26_iteration];
                var __loop26_var1 = __tmp1.__loop26_var1;
                var super = __tmp1.super;
                result += "typeof(" + CSharpName(super, model, ClassKind.Descriptor, true) + ")" + delim; //517:3
            }
            if (result.Length > 0) //519:2
            {
                result = ", BaseDescriptors = new global::System.Type[] { " + result + " }"; //520:3
            }
            return result; //522:2
        }

        public string GenerateDescriptorProperty(MetaModel model, MetaClass cls, MetaProperty prop) //525:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //526:1
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(prop));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3_line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                    {
                        __out.Append(__tmp3_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp3_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //527:30
            }
            bool __tmp5_outputWritten = false;
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GenerateAttributes(prop));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                    {
                        __out.Append(__tmp6_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp6_last || __tmp5_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //528:27
            }
            bool __tmp8_outputWritten = false;
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(GenerateDescriptorPropertyAttributes(model, cls, prop));
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9_line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if ((__tmp9_last && !string.IsNullOrEmpty(__tmp9_line)) || (!__tmp9_last && __tmp9_line != null))
                    {
                        __out.Append(__tmp9_line);
                        __tmp8_outputWritten = true;
                    }
                    if (!__tmp9_last || __tmp8_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp8_outputWritten)
            {
                __out.AppendLine(false); //529:57
            }
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "public static readonly "; //530:1
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Append(__tmp12_line);
                __tmp11_outputWritten = true;
            }
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(Properties.CoreNs);
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13_line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if ((__tmp13_last && !string.IsNullOrEmpty(__tmp13_line)) || (!__tmp13_last && __tmp13_line != null))
                    {
                        __out.Append(__tmp13_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14_line = ".ModelProperty "; //530:43
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(CSharpName(prop, model, PropertyKind.Descriptor));
            using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
            {
                bool __tmp15_last = __tmp15Reader.EndOfStream;
                while(!__tmp15_last)
                {
                    string __tmp15_line = __tmp15Reader.ReadLine();
                    __tmp15_last = __tmp15Reader.EndOfStream;
                    if ((__tmp15_last && !string.IsNullOrEmpty(__tmp15_line)) || (!__tmp15_last && __tmp15_line != null))
                    {
                        __out.Append(__tmp15_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp15_last) __out.AppendLine(true);
                }
            }
            string __tmp16_line = " ="; //530:107
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Append(__tmp16_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //530:109
            }
            bool __tmp18_outputWritten = false;
            string __tmp17Prefix = "    "; //531:1
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(Properties.CoreNs);
            using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
            {
                bool __tmp19_last = __tmp19Reader.EndOfStream;
                while(!__tmp19_last)
                {
                    string __tmp19_line = __tmp19Reader.ReadLine();
                    __tmp19_last = __tmp19Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp17Prefix))
                    {
                        __out.Append(__tmp17Prefix);
                        __tmp18_outputWritten = true;
                    }
                    if ((__tmp19_last && !string.IsNullOrEmpty(__tmp19_line)) || (!__tmp19_last && __tmp19_line != null))
                    {
                        __out.Append(__tmp19_line);
                        __tmp18_outputWritten = true;
                    }
                    if (!__tmp19_last) __out.AppendLine(true);
                }
            }
            string __tmp20_line = ".ModelProperty.Register(declaringType: typeof("; //531:24
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp18_outputWritten = true;
            }
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(CSharpName(cls, model, ClassKind.Descriptor));
            using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
            {
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(!__tmp21_last)
                {
                    string __tmp21_line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if ((__tmp21_last && !string.IsNullOrEmpty(__tmp21_line)) || (!__tmp21_last && __tmp21_line != null))
                    {
                        __out.Append(__tmp21_line);
                        __tmp18_outputWritten = true;
                    }
                    if (!__tmp21_last) __out.AppendLine(true);
                }
            }
            string __tmp22_line = "), name: \""; //531:115
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Append(__tmp22_line);
                __tmp18_outputWritten = true;
            }
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(CSharpName(prop, model));
            using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
            {
                bool __tmp23_last = __tmp23Reader.EndOfStream;
                while(!__tmp23_last)
                {
                    string __tmp23_line = __tmp23Reader.ReadLine();
                    __tmp23_last = __tmp23Reader.EndOfStream;
                    if ((__tmp23_last && !string.IsNullOrEmpty(__tmp23_line)) || (!__tmp23_last && __tmp23_line != null))
                    {
                        __out.Append(__tmp23_line);
                        __tmp18_outputWritten = true;
                    }
                    if (!__tmp23_last) __out.AppendLine(true);
                }
            }
            string __tmp24_line = "\","; //531:149
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //531:151
            }
            if (prop.Type is MetaCollectionType) //532:2
            {
                MetaCollectionType collType = (MetaCollectionType)prop.Type; //533:3
                bool __tmp26_outputWritten = false;
                string __tmp27_line = "        immutableType: typeof("; //534:1
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Append(__tmp27_line);
                    __tmp26_outputWritten = true;
                }
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(CSharpName(collType.InnerType, null, ClassKind.Immutable, true));
                using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                {
                    bool __tmp28_last = __tmp28Reader.EndOfStream;
                    while(!__tmp28_last)
                    {
                        string __tmp28_line = __tmp28Reader.ReadLine();
                        __tmp28_last = __tmp28Reader.EndOfStream;
                        if ((__tmp28_last && !string.IsNullOrEmpty(__tmp28_line)) || (!__tmp28_last && __tmp28_line != null))
                        {
                            __out.Append(__tmp28_line);
                            __tmp26_outputWritten = true;
                        }
                        if (!__tmp28_last) __out.AppendLine(true);
                    }
                }
                string __tmp29_line = "),"; //534:95
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Append(__tmp29_line);
                    __tmp26_outputWritten = true;
                }
                if (__tmp26_outputWritten) __out.AppendLine(true);
                if (__tmp26_outputWritten)
                {
                    __out.AppendLine(false); //534:97
                }
                bool __tmp31_outputWritten = false;
                string __tmp32_line = "        mutableType: typeof("; //535:1
                if (!string.IsNullOrEmpty(__tmp32_line))
                {
                    __out.Append(__tmp32_line);
                    __tmp31_outputWritten = true;
                }
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(CSharpName(collType.InnerType, null, ClassKind.Builder, true));
                using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
                {
                    bool __tmp33_last = __tmp33Reader.EndOfStream;
                    while(!__tmp33_last)
                    {
                        string __tmp33_line = __tmp33Reader.ReadLine();
                        __tmp33_last = __tmp33Reader.EndOfStream;
                        if ((__tmp33_last && !string.IsNullOrEmpty(__tmp33_line)) || (!__tmp33_last && __tmp33_line != null))
                        {
                            __out.Append(__tmp33_line);
                            __tmp31_outputWritten = true;
                        }
                        if (!__tmp33_last) __out.AppendLine(true);
                    }
                }
                string __tmp34_line = "),"; //535:91
                if (!string.IsNullOrEmpty(__tmp34_line))
                {
                    __out.Append(__tmp34_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //535:93
                }
            }
            else //536:2
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "        immutableType: typeof("; //537:1
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp36_outputWritten = true;
                }
                StringBuilder __tmp38 = new StringBuilder();
                __tmp38.Append(CSharpName(prop.Type, null, ClassKind.Immutable, true));
                using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                {
                    bool __tmp38_last = __tmp38Reader.EndOfStream;
                    while(!__tmp38_last)
                    {
                        string __tmp38_line = __tmp38Reader.ReadLine();
                        __tmp38_last = __tmp38Reader.EndOfStream;
                        if ((__tmp38_last && !string.IsNullOrEmpty(__tmp38_line)) || (!__tmp38_last && __tmp38_line != null))
                        {
                            __out.Append(__tmp38_line);
                            __tmp36_outputWritten = true;
                        }
                        if (!__tmp38_last) __out.AppendLine(true);
                    }
                }
                string __tmp39_line = "),"; //537:86
                if (!string.IsNullOrEmpty(__tmp39_line))
                {
                    __out.Append(__tmp39_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //537:88
                }
                bool __tmp41_outputWritten = false;
                string __tmp42_line = "        mutableType: typeof("; //538:1
                if (!string.IsNullOrEmpty(__tmp42_line))
                {
                    __out.Append(__tmp42_line);
                    __tmp41_outputWritten = true;
                }
                StringBuilder __tmp43 = new StringBuilder();
                __tmp43.Append(CSharpName(prop.Type, null, ClassKind.Builder, true));
                using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
                {
                    bool __tmp43_last = __tmp43Reader.EndOfStream;
                    while(!__tmp43_last)
                    {
                        string __tmp43_line = __tmp43Reader.ReadLine();
                        __tmp43_last = __tmp43Reader.EndOfStream;
                        if ((__tmp43_last && !string.IsNullOrEmpty(__tmp43_line)) || (!__tmp43_last && __tmp43_line != null))
                        {
                            __out.Append(__tmp43_line);
                            __tmp41_outputWritten = true;
                        }
                        if (!__tmp43_last) __out.AppendLine(true);
                    }
                }
                string __tmp44_line = "),"; //538:82
                if (!string.IsNullOrEmpty(__tmp44_line))
                {
                    __out.Append(__tmp44_line);
                    __tmp41_outputWritten = true;
                }
                if (__tmp41_outputWritten) __out.AppendLine(true);
                if (__tmp41_outputWritten)
                {
                    __out.AppendLine(false); //538:84
                }
            }
            bool __tmp46_outputWritten = false;
            string __tmp47_line = "		metaProperty: () => "; //540:1
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Append(__tmp47_line);
                __tmp46_outputWritten = true;
            }
            StringBuilder __tmp48 = new StringBuilder();
            __tmp48.Append(CSharpName(prop, null, PropertyKind.ImmutableInstance, true));
            using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
            {
                bool __tmp48_last = __tmp48Reader.EndOfStream;
                while(!__tmp48_last)
                {
                    string __tmp48_line = __tmp48Reader.ReadLine();
                    __tmp48_last = __tmp48Reader.EndOfStream;
                    if ((__tmp48_last && !string.IsNullOrEmpty(__tmp48_line)) || (!__tmp48_last && __tmp48_line != null))
                    {
                        __out.Append(__tmp48_line);
                        __tmp46_outputWritten = true;
                    }
                    if (!__tmp48_last) __out.AppendLine(true);
                }
            }
            string __tmp49_line = ","; //540:84
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Append(__tmp49_line);
                __tmp46_outputWritten = true;
            }
            if (__tmp46_outputWritten) __out.AppendLine(true);
            if (__tmp46_outputWritten)
            {
                __out.AppendLine(false); //540:85
            }
            bool __tmp51_outputWritten = false;
            string __tmp52_line = "		defaultValue: "; //541:1
            if (!string.IsNullOrEmpty(__tmp52_line))
            {
                __out.Append(__tmp52_line);
                __tmp51_outputWritten = true;
            }
            StringBuilder __tmp53 = new StringBuilder();
            __tmp53.Append(prop.DefaultValue != null ? prop.DefaultValue : "null");
            using(StreamReader __tmp53Reader = new StreamReader(this.__ToStream(__tmp53.ToString())))
            {
                bool __tmp53_last = __tmp53Reader.EndOfStream;
                while(!__tmp53_last)
                {
                    string __tmp53_line = __tmp53Reader.ReadLine();
                    __tmp53_last = __tmp53Reader.EndOfStream;
                    if ((__tmp53_last && !string.IsNullOrEmpty(__tmp53_line)) || (!__tmp53_last && __tmp53_line != null))
                    {
                        __out.Append(__tmp53_line);
                        __tmp51_outputWritten = true;
                    }
                    if (!__tmp53_last) __out.AppendLine(true);
                }
            }
            string __tmp54_line = ");"; //541:73
            if (!string.IsNullOrEmpty(__tmp54_line))
            {
                __out.Append(__tmp54_line);
                __tmp51_outputWritten = true;
            }
            if (__tmp51_outputWritten) __out.AppendLine(true);
            if (__tmp51_outputWritten)
            {
                __out.AppendLine(false); //541:75
            }
            return __out.ToString();
        }

        public string GenerateDescriptorPropertyAttributes(MetaModel model, MetaClass cls, MetaProperty prop) //544:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Type is MetaCollectionType) //545:2
            {
                bool __tmp2_outputWritten = false;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append("[" + Properties.CoreNs + ".CollectionAttribute]");
                using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
                {
                    bool __tmp3_last = __tmp3Reader.EndOfStream;
                    while(!__tmp3_last)
                    {
                        string __tmp3_line = __tmp3Reader.ReadLine();
                        __tmp3_last = __tmp3Reader.EndOfStream;
                        if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                        {
                            __out.Append(__tmp3_line);
                            __tmp2_outputWritten = true;
                        }
                        if (!__tmp3_last || __tmp2_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //546:48
                }
            }
            if (prop.Type is MetaCollectionType && (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiList)) //548:2
            {
                bool __tmp5_outputWritten = false;
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append("[" + Properties.CoreNs + ".NonUniqueAttribute]");
                using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                {
                    bool __tmp6_last = __tmp6Reader.EndOfStream;
                    while(!__tmp6_last)
                    {
                        string __tmp6_line = __tmp6Reader.ReadLine();
                        __tmp6_last = __tmp6Reader.EndOfStream;
                        if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                        {
                            __out.Append(__tmp6_line);
                            __tmp5_outputWritten = true;
                        }
                        if (!__tmp6_last || __tmp5_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp5_outputWritten)
                {
                    __out.AppendLine(false); //549:47
                }
            }
            if (prop.Type is MetaCollectionType && (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.List || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiList)) //551:2
            {
                bool __tmp8_outputWritten = false;
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append("[" + Properties.CoreNs + ".OrderedAttribute]");
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(!__tmp9_last)
                    {
                        string __tmp9_line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if ((__tmp9_last && !string.IsNullOrEmpty(__tmp9_line)) || (!__tmp9_last && __tmp9_line != null))
                        {
                            __out.Append(__tmp9_line);
                            __tmp8_outputWritten = true;
                        }
                        if (!__tmp9_last || __tmp8_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp8_outputWritten)
                {
                    __out.AppendLine(false); //552:45
                }
            }
            if (prop.IsContainment) //554:2
            {
                bool __tmp11_outputWritten = false;
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append("[" + Properties.CoreNs + ".ContainmentAttribute]");
                using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                {
                    bool __tmp12_last = __tmp12Reader.EndOfStream;
                    while(!__tmp12_last)
                    {
                        string __tmp12_line = __tmp12Reader.ReadLine();
                        __tmp12_last = __tmp12Reader.EndOfStream;
                        if ((__tmp12_last && !string.IsNullOrEmpty(__tmp12_line)) || (!__tmp12_last && __tmp12_line != null))
                        {
                            __out.Append(__tmp12_line);
                            __tmp11_outputWritten = true;
                        }
                        if (!__tmp12_last || __tmp11_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //555:49
                }
            }
            if (prop.Kind != MetaPropertyKind.Normal) //557:2
            {
                bool __tmp14_outputWritten = false;
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append("[" + Properties.CoreNs + ".ReadonlyAttribute]");
                using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
                {
                    bool __tmp15_last = __tmp15Reader.EndOfStream;
                    while(!__tmp15_last)
                    {
                        string __tmp15_line = __tmp15Reader.ReadLine();
                        __tmp15_last = __tmp15Reader.EndOfStream;
                        if ((__tmp15_last && !string.IsNullOrEmpty(__tmp15_line)) || (!__tmp15_last && __tmp15_line != null))
                        {
                            __out.Append(__tmp15_line);
                            __tmp14_outputWritten = true;
                        }
                        if (!__tmp15_last || __tmp14_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp14_outputWritten)
                {
                    __out.AppendLine(false); //558:46
                }
            }
            if (prop.Kind == MetaPropertyKind.Derived) //560:2
            {
                bool __tmp17_outputWritten = false;
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append("[" + Properties.CoreNs + ".DerivedAttribute]");
                using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                {
                    bool __tmp18_last = __tmp18Reader.EndOfStream;
                    while(!__tmp18_last)
                    {
                        string __tmp18_line = __tmp18Reader.ReadLine();
                        __tmp18_last = __tmp18Reader.EndOfStream;
                        if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                        {
                            __out.Append(__tmp18_line);
                            __tmp17_outputWritten = true;
                        }
                        if (!__tmp18_last || __tmp17_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp17_outputWritten)
                {
                    __out.AppendLine(false); //561:45
                }
            }
            if (prop.Kind == MetaPropertyKind.DerivedUnion) //563:2
            {
                bool __tmp20_outputWritten = false;
                StringBuilder __tmp21 = new StringBuilder();
                __tmp21.Append("[" + Properties.CoreNs + ".DerivedUnionAttribute]");
                using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
                {
                    bool __tmp21_last = __tmp21Reader.EndOfStream;
                    while(!__tmp21_last)
                    {
                        string __tmp21_line = __tmp21Reader.ReadLine();
                        __tmp21_last = __tmp21Reader.EndOfStream;
                        if ((__tmp21_last && !string.IsNullOrEmpty(__tmp21_line)) || (!__tmp21_last && __tmp21_line != null))
                        {
                            __out.Append(__tmp21_line);
                            __tmp20_outputWritten = true;
                        }
                        if (!__tmp21_last || __tmp20_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp20_outputWritten)
                {
                    __out.AppendLine(false); //564:50
                }
            }
            var __loop27_results = 
                (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //566:7
                select new { p = p}
                ).ToList(); //566:2
            for (int __loop27_iteration = 0; __loop27_iteration < __loop27_results.Count; ++__loop27_iteration)
            {
                var __tmp22 = __loop27_results[__loop27_iteration];
                var p = __tmp22.p;
                bool __tmp24_outputWritten = false;
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append("[" + Properties.CoreNs + ".OppositeAttribute(typeof(");
                using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
                {
                    bool __tmp25_last = __tmp25Reader.EndOfStream;
                    while(!__tmp25_last)
                    {
                        string __tmp25_line = __tmp25Reader.ReadLine();
                        __tmp25_last = __tmp25Reader.EndOfStream;
                        if ((__tmp25_last && !string.IsNullOrEmpty(__tmp25_line)) || (!__tmp25_last && __tmp25_line != null))
                        {
                            __out.Append(__tmp25_line);
                            __tmp24_outputWritten = true;
                        }
                        if (!__tmp25_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(CSharpName(p.Class, model, ClassKind.Descriptor, true));
                using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
                {
                    bool __tmp26_last = __tmp26Reader.EndOfStream;
                    while(!__tmp26_last)
                    {
                        string __tmp26_line = __tmp26Reader.ReadLine();
                        __tmp26_last = __tmp26Reader.EndOfStream;
                        if ((__tmp26_last && !string.IsNullOrEmpty(__tmp26_line)) || (!__tmp26_last && __tmp26_line != null))
                        {
                            __out.Append(__tmp26_line);
                            __tmp24_outputWritten = true;
                        }
                        if (!__tmp26_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append("), \"");
                using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                {
                    bool __tmp27_last = __tmp27Reader.EndOfStream;
                    while(!__tmp27_last)
                    {
                        string __tmp27_line = __tmp27Reader.ReadLine();
                        __tmp27_last = __tmp27Reader.EndOfStream;
                        if ((__tmp27_last && !string.IsNullOrEmpty(__tmp27_line)) || (!__tmp27_last && __tmp27_line != null))
                        {
                            __out.Append(__tmp27_line);
                            __tmp24_outputWritten = true;
                        }
                        if (!__tmp27_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(CSharpName(p, model));
                using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                {
                    bool __tmp28_last = __tmp28Reader.EndOfStream;
                    while(!__tmp28_last)
                    {
                        string __tmp28_line = __tmp28Reader.ReadLine();
                        __tmp28_last = __tmp28Reader.EndOfStream;
                        if ((__tmp28_last && !string.IsNullOrEmpty(__tmp28_line)) || (!__tmp28_last && __tmp28_line != null))
                        {
                            __out.Append(__tmp28_line);
                            __tmp24_outputWritten = true;
                        }
                        if (!__tmp28_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append("\")]");
                using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                {
                    bool __tmp29_last = __tmp29Reader.EndOfStream;
                    while(!__tmp29_last)
                    {
                        string __tmp29_line = __tmp29Reader.ReadLine();
                        __tmp29_last = __tmp29Reader.EndOfStream;
                        if ((__tmp29_last && !string.IsNullOrEmpty(__tmp29_line)) || (!__tmp29_last && __tmp29_line != null))
                        {
                            __out.Append(__tmp29_line);
                            __tmp24_outputWritten = true;
                        }
                        if (!__tmp29_last || __tmp24_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //567:146
                }
            }
            var __loop28_results = 
                (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //569:7
                select new { p = p}
                ).ToList(); //569:2
            for (int __loop28_iteration = 0; __loop28_iteration < __loop28_results.Count; ++__loop28_iteration)
            {
                var __tmp30 = __loop28_results[__loop28_iteration];
                var p = __tmp30.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //570:3
                {
                    bool __tmp32_outputWritten = false;
                    StringBuilder __tmp33 = new StringBuilder();
                    __tmp33.Append("[" + Properties.CoreNs + ".SubsetsAttribute(typeof(");
                    using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
                    {
                        bool __tmp33_last = __tmp33Reader.EndOfStream;
                        while(!__tmp33_last)
                        {
                            string __tmp33_line = __tmp33Reader.ReadLine();
                            __tmp33_last = __tmp33Reader.EndOfStream;
                            if ((__tmp33_last && !string.IsNullOrEmpty(__tmp33_line)) || (!__tmp33_last && __tmp33_line != null))
                            {
                                __out.Append(__tmp33_line);
                                __tmp32_outputWritten = true;
                            }
                            if (!__tmp33_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp34 = new StringBuilder();
                    __tmp34.Append(CSharpName(p.Class, model, ClassKind.Descriptor, true));
                    using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                    {
                        bool __tmp34_last = __tmp34Reader.EndOfStream;
                        while(!__tmp34_last)
                        {
                            string __tmp34_line = __tmp34Reader.ReadLine();
                            __tmp34_last = __tmp34Reader.EndOfStream;
                            if ((__tmp34_last && !string.IsNullOrEmpty(__tmp34_line)) || (!__tmp34_last && __tmp34_line != null))
                            {
                                __out.Append(__tmp34_line);
                                __tmp32_outputWritten = true;
                            }
                            if (!__tmp34_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp35 = new StringBuilder();
                    __tmp35.Append("), \"");
                    using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
                    {
                        bool __tmp35_last = __tmp35Reader.EndOfStream;
                        while(!__tmp35_last)
                        {
                            string __tmp35_line = __tmp35Reader.ReadLine();
                            __tmp35_last = __tmp35Reader.EndOfStream;
                            if ((__tmp35_last && !string.IsNullOrEmpty(__tmp35_line)) || (!__tmp35_last && __tmp35_line != null))
                            {
                                __out.Append(__tmp35_line);
                                __tmp32_outputWritten = true;
                            }
                            if (!__tmp35_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp36 = new StringBuilder();
                    __tmp36.Append(CSharpName(p, model));
                    using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                    {
                        bool __tmp36_last = __tmp36Reader.EndOfStream;
                        while(!__tmp36_last)
                        {
                            string __tmp36_line = __tmp36Reader.ReadLine();
                            __tmp36_last = __tmp36Reader.EndOfStream;
                            if ((__tmp36_last && !string.IsNullOrEmpty(__tmp36_line)) || (!__tmp36_last && __tmp36_line != null))
                            {
                                __out.Append(__tmp36_line);
                                __tmp32_outputWritten = true;
                            }
                            if (!__tmp36_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp37 = new StringBuilder();
                    __tmp37.Append("\")]");
                    using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
                    {
                        bool __tmp37_last = __tmp37Reader.EndOfStream;
                        while(!__tmp37_last)
                        {
                            string __tmp37_line = __tmp37Reader.ReadLine();
                            __tmp37_last = __tmp37Reader.EndOfStream;
                            if ((__tmp37_last && !string.IsNullOrEmpty(__tmp37_line)) || (!__tmp37_last && __tmp37_line != null))
                            {
                                __out.Append(__tmp37_line);
                                __tmp32_outputWritten = true;
                            }
                            if (!__tmp37_last || __tmp32_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp32_outputWritten)
                    {
                        __out.AppendLine(false); //571:145
                    }
                }
                else //572:3
                {
                    bool __tmp39_outputWritten = false;
                    string __tmp40_line = "// ERROR: subsetted property '"; //573:1
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Append(__tmp40_line);
                        __tmp39_outputWritten = true;
                    }
                    StringBuilder __tmp41 = new StringBuilder();
                    __tmp41.Append(CSharpName(p, model, PropertyKind.Descriptor, true));
                    using(StreamReader __tmp41Reader = new StreamReader(this.__ToStream(__tmp41.ToString())))
                    {
                        bool __tmp41_last = __tmp41Reader.EndOfStream;
                        while(!__tmp41_last)
                        {
                            string __tmp41_line = __tmp41Reader.ReadLine();
                            __tmp41_last = __tmp41Reader.EndOfStream;
                            if ((__tmp41_last && !string.IsNullOrEmpty(__tmp41_line)) || (!__tmp41_last && __tmp41_line != null))
                            {
                                __out.Append(__tmp41_line);
                                __tmp39_outputWritten = true;
                            }
                            if (!__tmp41_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp42_line = "' must be a property of this class or an ancestor class"; //573:83
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Append(__tmp42_line);
                        __tmp39_outputWritten = true;
                    }
                    if (__tmp39_outputWritten) __out.AppendLine(true);
                    if (__tmp39_outputWritten)
                    {
                        __out.AppendLine(false); //573:138
                    }
                }
            }
            var __loop29_results = 
                (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //576:7
                select new { p = p}
                ).ToList(); //576:2
            for (int __loop29_iteration = 0; __loop29_iteration < __loop29_results.Count; ++__loop29_iteration)
            {
                var __tmp43 = __loop29_results[__loop29_iteration];
                var p = __tmp43.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //577:3
                {
                    bool __tmp45_outputWritten = false;
                    StringBuilder __tmp46 = new StringBuilder();
                    __tmp46.Append("[" + Properties.CoreNs + ".RedefinesAttribute(typeof(");
                    using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
                    {
                        bool __tmp46_last = __tmp46Reader.EndOfStream;
                        while(!__tmp46_last)
                        {
                            string __tmp46_line = __tmp46Reader.ReadLine();
                            __tmp46_last = __tmp46Reader.EndOfStream;
                            if ((__tmp46_last && !string.IsNullOrEmpty(__tmp46_line)) || (!__tmp46_last && __tmp46_line != null))
                            {
                                __out.Append(__tmp46_line);
                                __tmp45_outputWritten = true;
                            }
                            if (!__tmp46_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp47 = new StringBuilder();
                    __tmp47.Append(CSharpName(p.Class, model, ClassKind.Descriptor, true));
                    using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
                    {
                        bool __tmp47_last = __tmp47Reader.EndOfStream;
                        while(!__tmp47_last)
                        {
                            string __tmp47_line = __tmp47Reader.ReadLine();
                            __tmp47_last = __tmp47Reader.EndOfStream;
                            if ((__tmp47_last && !string.IsNullOrEmpty(__tmp47_line)) || (!__tmp47_last && __tmp47_line != null))
                            {
                                __out.Append(__tmp47_line);
                                __tmp45_outputWritten = true;
                            }
                            if (!__tmp47_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp48 = new StringBuilder();
                    __tmp48.Append("), \"");
                    using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
                    {
                        bool __tmp48_last = __tmp48Reader.EndOfStream;
                        while(!__tmp48_last)
                        {
                            string __tmp48_line = __tmp48Reader.ReadLine();
                            __tmp48_last = __tmp48Reader.EndOfStream;
                            if ((__tmp48_last && !string.IsNullOrEmpty(__tmp48_line)) || (!__tmp48_last && __tmp48_line != null))
                            {
                                __out.Append(__tmp48_line);
                                __tmp45_outputWritten = true;
                            }
                            if (!__tmp48_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp49 = new StringBuilder();
                    __tmp49.Append(CSharpName(p, model));
                    using(StreamReader __tmp49Reader = new StreamReader(this.__ToStream(__tmp49.ToString())))
                    {
                        bool __tmp49_last = __tmp49Reader.EndOfStream;
                        while(!__tmp49_last)
                        {
                            string __tmp49_line = __tmp49Reader.ReadLine();
                            __tmp49_last = __tmp49Reader.EndOfStream;
                            if ((__tmp49_last && !string.IsNullOrEmpty(__tmp49_line)) || (!__tmp49_last && __tmp49_line != null))
                            {
                                __out.Append(__tmp49_line);
                                __tmp45_outputWritten = true;
                            }
                            if (!__tmp49_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp50 = new StringBuilder();
                    __tmp50.Append("\")]");
                    using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                    {
                        bool __tmp50_last = __tmp50Reader.EndOfStream;
                        while(!__tmp50_last)
                        {
                            string __tmp50_line = __tmp50Reader.ReadLine();
                            __tmp50_last = __tmp50Reader.EndOfStream;
                            if ((__tmp50_last && !string.IsNullOrEmpty(__tmp50_line)) || (!__tmp50_last && __tmp50_line != null))
                            {
                                __out.Append(__tmp50_line);
                                __tmp45_outputWritten = true;
                            }
                            if (!__tmp50_last || __tmp45_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp45_outputWritten)
                    {
                        __out.AppendLine(false); //578:147
                    }
                }
                else //579:3
                {
                    bool __tmp52_outputWritten = false;
                    string __tmp53_line = "// ERROR: redefined property '"; //580:1
                    if (!string.IsNullOrEmpty(__tmp53_line))
                    {
                        __out.Append(__tmp53_line);
                        __tmp52_outputWritten = true;
                    }
                    StringBuilder __tmp54 = new StringBuilder();
                    __tmp54.Append(CSharpName(p, model, PropertyKind.Descriptor, true));
                    using(StreamReader __tmp54Reader = new StreamReader(this.__ToStream(__tmp54.ToString())))
                    {
                        bool __tmp54_last = __tmp54Reader.EndOfStream;
                        while(!__tmp54_last)
                        {
                            string __tmp54_line = __tmp54Reader.ReadLine();
                            __tmp54_last = __tmp54Reader.EndOfStream;
                            if ((__tmp54_last && !string.IsNullOrEmpty(__tmp54_line)) || (!__tmp54_last && __tmp54_line != null))
                            {
                                __out.Append(__tmp54_line);
                                __tmp52_outputWritten = true;
                            }
                            if (!__tmp54_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp55_line = "' must be a property of this class or an ancestor class"; //580:83
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Append(__tmp55_line);
                        __tmp52_outputWritten = true;
                    }
                    if (__tmp52_outputWritten) __out.AppendLine(true);
                    if (__tmp52_outputWritten)
                    {
                        __out.AppendLine(false); //580:138
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //585:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //586:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(CSharpName(model, ModelKind.ImplementationProvider));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //586:68
            }
            __out.Append("{"); //587:1
            __out.AppendLine(false); //587:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	// If there is a compile error at this line, create a new class called "; //588:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(CSharpName(model, ModelKind.Implementation));
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp6_outputWritten = true;
                    }
                    if (!__tmp8_last || __tmp6_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //588:117
            }
            bool __tmp10_outputWritten = false;
            string __tmp11_line = "	// which is a subclass of "; //589:1
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Append(__tmp11_line);
                __tmp10_outputWritten = true;
            }
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(CSharpName(model, ModelKind.ImplementationBase, true));
            using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
            {
                bool __tmp12_last = __tmp12Reader.EndOfStream;
                while(!__tmp12_last)
                {
                    string __tmp12_line = __tmp12Reader.ReadLine();
                    __tmp12_last = __tmp12Reader.EndOfStream;
                    if ((__tmp12_last && !string.IsNullOrEmpty(__tmp12_line)) || (!__tmp12_last && __tmp12_line != null))
                    {
                        __out.Append(__tmp12_line);
                        __tmp10_outputWritten = true;
                    }
                    if (!__tmp12_last) __out.AppendLine(true);
                }
            }
            string __tmp13_line = ":"; //589:82
            if (!string.IsNullOrEmpty(__tmp13_line))
            {
                __out.Append(__tmp13_line);
                __tmp10_outputWritten = true;
            }
            if (__tmp10_outputWritten) __out.AppendLine(true);
            if (__tmp10_outputWritten)
            {
                __out.AppendLine(false); //589:83
            }
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "	private static "; //590:1
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Append(__tmp16_line);
                __tmp15_outputWritten = true;
            }
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(CSharpName(model, ModelKind.Implementation));
            using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
            {
                bool __tmp17_last = __tmp17Reader.EndOfStream;
                while(!__tmp17_last)
                {
                    string __tmp17_line = __tmp17Reader.ReadLine();
                    __tmp17_last = __tmp17Reader.EndOfStream;
                    if ((__tmp17_last && !string.IsNullOrEmpty(__tmp17_line)) || (!__tmp17_last && __tmp17_line != null))
                    {
                        __out.Append(__tmp17_line);
                        __tmp15_outputWritten = true;
                    }
                    if (!__tmp17_last) __out.AppendLine(true);
                }
            }
            string __tmp18_line = " implementation = new "; //590:61
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Append(__tmp18_line);
                __tmp15_outputWritten = true;
            }
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(CSharpName(model, ModelKind.Implementation));
            using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
            {
                bool __tmp19_last = __tmp19Reader.EndOfStream;
                while(!__tmp19_last)
                {
                    string __tmp19_line = __tmp19Reader.ReadLine();
                    __tmp19_last = __tmp19Reader.EndOfStream;
                    if ((__tmp19_last && !string.IsNullOrEmpty(__tmp19_line)) || (!__tmp19_last && __tmp19_line != null))
                    {
                        __out.Append(__tmp19_line);
                        __tmp15_outputWritten = true;
                    }
                    if (!__tmp19_last) __out.AppendLine(true);
                }
            }
            string __tmp20_line = "();"; //590:127
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //590:130
            }
            __out.AppendLine(true); //591:1
            bool __tmp22_outputWritten = false;
            string __tmp23_line = "	public static "; //592:1
            if (!string.IsNullOrEmpty(__tmp23_line))
            {
                __out.Append(__tmp23_line);
                __tmp22_outputWritten = true;
            }
            StringBuilder __tmp24 = new StringBuilder();
            __tmp24.Append(CSharpName(model, ModelKind.Implementation));
            using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
            {
                bool __tmp24_last = __tmp24Reader.EndOfStream;
                while(!__tmp24_last)
                {
                    string __tmp24_line = __tmp24Reader.ReadLine();
                    __tmp24_last = __tmp24Reader.EndOfStream;
                    if ((__tmp24_last && !string.IsNullOrEmpty(__tmp24_line)) || (!__tmp24_last && __tmp24_line != null))
                    {
                        __out.Append(__tmp24_line);
                        __tmp22_outputWritten = true;
                    }
                    if (!__tmp24_last) __out.AppendLine(true);
                }
            }
            string __tmp25_line = " Implementation"; //592:60
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Append(__tmp25_line);
                __tmp22_outputWritten = true;
            }
            if (__tmp22_outputWritten) __out.AppendLine(true);
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //592:75
            }
            __out.Append("	{"); //593:1
            __out.AppendLine(false); //593:3
            __out.Append("		get { return implementation; }"); //594:1
            __out.AppendLine(false); //594:33
            __out.Append("	}"); //595:1
            __out.AppendLine(false); //595:3
            __out.Append("}"); //596:1
            __out.AppendLine(false); //596:2
            return __out.ToString();
        }

        public string GenerateImplementationBase(MetaModel model) //599:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //600:2
            bool metaMetaModel = IsMetaMetaModel(model); //601:2
            __out.Append("/// <summary>"); //602:1
            __out.AppendLine(false); //602:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //603:1
            __out.AppendLine(false); //603:68
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "/// This class has to be be overriden in "; //604:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(CSharpName(model, ModelKind.Implementation, true));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5_line = " to provide custom"; //604:92
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Append(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //604:110
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //605:1
            __out.AppendLine(false); //605:73
            __out.Append("/// </summary>"); //606:1
            __out.AppendLine(false); //606:15
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "internal abstract class "; //607:1
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Append(__tmp8_line);
                __tmp7_outputWritten = true;
            }
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(CSharpName(model, ModelKind.ImplementationBase));
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9_line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if ((__tmp9_last && !string.IsNullOrEmpty(__tmp9_line)) || (!__tmp9_last && __tmp9_line != null))
                    {
                        __out.Append(__tmp9_line);
                        __tmp7_outputWritten = true;
                    }
                    if (!__tmp9_last || __tmp7_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp7_outputWritten)
            {
                __out.AppendLine(false); //607:73
            }
            __out.Append("{"); //608:1
            __out.AppendLine(false); //608:2
            __out.Append("	/// <summary>"); //609:1
            __out.AppendLine(false); //609:15
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	/// Implements the constructor: "; //610:1
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Append(__tmp12_line);
                __tmp11_outputWritten = true;
            }
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(CSharpName(model, ModelKind.BuilderInstance));
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13_line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if ((__tmp13_last && !string.IsNullOrEmpty(__tmp13_line)) || (!__tmp13_last && __tmp13_line != null))
                    {
                        __out.Append(__tmp13_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14_line = "()"; //610:79
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //610:81
            }
            __out.Append("	/// </summary>"); //611:1
            __out.AppendLine(false); //611:16
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	internal virtual void "; //612:1
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp16_outputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(CSharpName(model, ModelKind.BuilderInstance));
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    string __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                    {
                        __out.Append(__tmp18_line);
                        __tmp16_outputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19_line = "("; //612:69
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(CSharpName(model, ModelKind.BuilderInstance));
            using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
            {
                bool __tmp20_last = __tmp20Reader.EndOfStream;
                while(!__tmp20_last)
                {
                    string __tmp20_line = __tmp20Reader.ReadLine();
                    __tmp20_last = __tmp20Reader.EndOfStream;
                    if ((__tmp20_last && !string.IsNullOrEmpty(__tmp20_line)) || (!__tmp20_last && __tmp20_line != null))
                    {
                        __out.Append(__tmp20_line);
                        __tmp16_outputWritten = true;
                    }
                    if (!__tmp20_last) __out.AppendLine(true);
                }
            }
            string __tmp21_line = " _this)"; //612:115
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //612:122
            }
            __out.Append("	{"); //613:1
            __out.AppendLine(false); //613:3
            __out.Append("	}"); //614:1
            __out.AppendLine(false); //614:3
            var __loop30_results = 
                (from __loop30_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //615:8
                from cls in __Enumerate((__loop30_var1).GetEnumerator()).OfType<MetaClass>() //615:38
                select new { __loop30_var1 = __loop30_var1, cls = cls}
                ).ToList(); //615:3
            for (int __loop30_iteration = 0; __loop30_iteration < __loop30_results.Count; ++__loop30_iteration)
            {
                var __tmp22 = __loop30_results[__loop30_iteration];
                var __loop30_var1 = __tmp22.__loop30_var1;
                var cls = __tmp22.cls;
                __out.AppendLine(true); //616:1
                __out.Append("	/// <summary>"); //617:1
                __out.AppendLine(false); //617:15
                bool __tmp24_outputWritten = false;
                string __tmp25_line = "	/// Implements the constructor: "; //618:1
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Append(__tmp25_line);
                    __tmp24_outputWritten = true;
                }
                StringBuilder __tmp26 = new StringBuilder();
                __tmp26.Append(CSharpName(cls, model, ClassKind.Immutable));
                using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
                {
                    bool __tmp26_last = __tmp26Reader.EndOfStream;
                    while(!__tmp26_last)
                    {
                        string __tmp26_line = __tmp26Reader.ReadLine();
                        __tmp26_last = __tmp26Reader.EndOfStream;
                        if ((__tmp26_last && !string.IsNullOrEmpty(__tmp26_line)) || (!__tmp26_last && __tmp26_line != null))
                        {
                            __out.Append(__tmp26_line);
                            __tmp24_outputWritten = true;
                        }
                        if (!__tmp26_last) __out.AppendLine(true);
                    }
                }
                string __tmp27_line = "()"; //618:78
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Append(__tmp27_line);
                    __tmp24_outputWritten = true;
                }
                if (__tmp24_outputWritten) __out.AppendLine(true);
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //618:80
                }
                __out.Append("	/// </summary>"); //619:1
                __out.AppendLine(false); //619:16
                if ((from __loop31_var1 in __Enumerate((cls).GetEnumerator()) //620:15
                from sup in __Enumerate((__loop31_var1.SuperClasses).GetEnumerator()) //620:20
                select new { __loop31_var1 = __loop31_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //620:3
                {
                    __out.Append("	/// Direct superclasses: "); //621:1
                    __out.AppendLine(false); //621:27
                    __out.Append("	/// <ul>"); //622:1
                    __out.AppendLine(false); //622:10
                    var __loop32_results = 
                        (from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //623:8
                        from sup in __Enumerate((__loop32_var1.SuperClasses).GetEnumerator()) //623:13
                        select new { __loop32_var1 = __loop32_var1, sup = sup}
                        ).ToList(); //623:3
                    for (int __loop32_iteration = 0; __loop32_iteration < __loop32_results.Count; ++__loop32_iteration)
                    {
                        var __tmp28 = __loop32_results[__loop32_iteration];
                        var __loop32_var1 = __tmp28.__loop32_var1;
                        var sup = __tmp28.sup;
                        bool __tmp30_outputWritten = false;
                        string __tmp31_line = "	///     <li>"; //624:1
                        if (!string.IsNullOrEmpty(__tmp31_line))
                        {
                            __out.Append(__tmp31_line);
                            __tmp30_outputWritten = true;
                        }
                        StringBuilder __tmp32 = new StringBuilder();
                        __tmp32.Append(CSharpName(sup, model, ClassKind.Immutable, true));
                        using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                        {
                            bool __tmp32_last = __tmp32Reader.EndOfStream;
                            while(!__tmp32_last)
                            {
                                string __tmp32_line = __tmp32Reader.ReadLine();
                                __tmp32_last = __tmp32Reader.EndOfStream;
                                if ((__tmp32_last && !string.IsNullOrEmpty(__tmp32_line)) || (!__tmp32_last && __tmp32_line != null))
                                {
                                    __out.Append(__tmp32_line);
                                    __tmp30_outputWritten = true;
                                }
                                if (!__tmp32_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp33_line = "</li>"; //624:64
                        if (!string.IsNullOrEmpty(__tmp33_line))
                        {
                            __out.Append(__tmp33_line);
                            __tmp30_outputWritten = true;
                        }
                        if (__tmp30_outputWritten) __out.AppendLine(true);
                        if (__tmp30_outputWritten)
                        {
                            __out.AppendLine(false); //624:69
                        }
                    }
                    __out.Append("	/// </ul>"); //626:1
                    __out.AppendLine(false); //626:11
                    __out.Append("	/// All superclasses:"); //627:1
                    __out.AppendLine(false); //627:23
                    __out.Append("	/// <ul>"); //628:1
                    __out.AppendLine(false); //628:10
                    var __loop33_results = 
                        (from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //629:8
                        from sup in __Enumerate((__loop33_var1.GetAllSuperClasses(false)).GetEnumerator()) //629:13
                        select new { __loop33_var1 = __loop33_var1, sup = sup}
                        ).ToList(); //629:3
                    for (int __loop33_iteration = 0; __loop33_iteration < __loop33_results.Count; ++__loop33_iteration)
                    {
                        var __tmp34 = __loop33_results[__loop33_iteration];
                        var __loop33_var1 = __tmp34.__loop33_var1;
                        var sup = __tmp34.sup;
                        bool __tmp36_outputWritten = false;
                        string __tmp37_line = "	///     <li>"; //630:1
                        if (!string.IsNullOrEmpty(__tmp37_line))
                        {
                            __out.Append(__tmp37_line);
                            __tmp36_outputWritten = true;
                        }
                        StringBuilder __tmp38 = new StringBuilder();
                        __tmp38.Append(CSharpName(sup, model, ClassKind.Immutable, true));
                        using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                        {
                            bool __tmp38_last = __tmp38Reader.EndOfStream;
                            while(!__tmp38_last)
                            {
                                string __tmp38_line = __tmp38Reader.ReadLine();
                                __tmp38_last = __tmp38Reader.EndOfStream;
                                if ((__tmp38_last && !string.IsNullOrEmpty(__tmp38_line)) || (!__tmp38_last && __tmp38_line != null))
                                {
                                    __out.Append(__tmp38_line);
                                    __tmp36_outputWritten = true;
                                }
                                if (!__tmp38_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp39_line = "</li>"; //630:64
                        if (!string.IsNullOrEmpty(__tmp39_line))
                        {
                            __out.Append(__tmp39_line);
                            __tmp36_outputWritten = true;
                        }
                        if (__tmp36_outputWritten) __out.AppendLine(true);
                        if (__tmp36_outputWritten)
                        {
                            __out.AppendLine(false); //630:69
                        }
                    }
                    __out.Append("	/// </ul>"); //632:1
                    __out.AppendLine(false); //632:11
                }
                if ((from __loop34_var1 in __Enumerate((cls).GetEnumerator()) //634:15
                from prop in __Enumerate((__loop34_var1.Properties).GetEnumerator()) //634:20
                where prop.Kind == MetaPropertyKind.Readonly //634:36
                select new { __loop34_var1 = __loop34_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //634:3
                {
                    __out.Append("	/// Initializes the following readonly properties:"); //635:1
                    __out.AppendLine(false); //635:52
                    __out.Append("	/// <ul>"); //636:1
                    __out.AppendLine(false); //636:10
                    var __loop35_results = 
                        (from __loop35_var1 in __Enumerate((cls).GetEnumerator()) //637:8
                        from prop in __Enumerate((__loop35_var1.Properties).GetEnumerator()) //637:13
                        where prop.Kind == MetaPropertyKind.Readonly //637:29
                        select new { __loop35_var1 = __loop35_var1, prop = prop}
                        ).ToList(); //637:3
                    for (int __loop35_iteration = 0; __loop35_iteration < __loop35_results.Count; ++__loop35_iteration)
                    {
                        var __tmp40 = __loop35_results[__loop35_iteration];
                        var __loop35_var1 = __tmp40.__loop35_var1;
                        var prop = __tmp40.prop;
                        bool __tmp42_outputWritten = false;
                        string __tmp43_line = "	///     <li>"; //638:1
                        if (!string.IsNullOrEmpty(__tmp43_line))
                        {
                            __out.Append(__tmp43_line);
                            __tmp42_outputWritten = true;
                        }
                        StringBuilder __tmp44 = new StringBuilder();
                        __tmp44.Append(CSharpName(prop, model));
                        using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                        {
                            bool __tmp44_last = __tmp44Reader.EndOfStream;
                            while(!__tmp44_last)
                            {
                                string __tmp44_line = __tmp44Reader.ReadLine();
                                __tmp44_last = __tmp44Reader.EndOfStream;
                                if ((__tmp44_last && !string.IsNullOrEmpty(__tmp44_line)) || (!__tmp44_last && __tmp44_line != null))
                                {
                                    __out.Append(__tmp44_line);
                                    __tmp42_outputWritten = true;
                                }
                                if (!__tmp44_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp45_line = "</li>"; //638:38
                        if (!string.IsNullOrEmpty(__tmp45_line))
                        {
                            __out.Append(__tmp45_line);
                            __tmp42_outputWritten = true;
                        }
                        if (__tmp42_outputWritten) __out.AppendLine(true);
                        if (__tmp42_outputWritten)
                        {
                            __out.AppendLine(false); //638:43
                        }
                    }
                    __out.Append("	/// </ul>"); //640:1
                    __out.AppendLine(false); //640:11
                }
                if ((from __loop36_var1 in __Enumerate((cls).GetEnumerator()) //642:15
                from prop in __Enumerate((__loop36_var1.Properties).GetEnumerator()) //642:20
                where prop.Kind == MetaPropertyKind.Lazy //642:36
                select new { __loop36_var1 = __loop36_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //642:3
                {
                    __out.Append("	/// Initializes the following lazy properties:"); //643:1
                    __out.AppendLine(false); //643:48
                    __out.Append("	/// <ul>"); //644:1
                    __out.AppendLine(false); //644:10
                    var __loop37_results = 
                        (from __loop37_var1 in __Enumerate((cls).GetEnumerator()) //645:8
                        from prop in __Enumerate((__loop37_var1.Properties).GetEnumerator()) //645:13
                        where prop.Kind == MetaPropertyKind.Lazy //645:29
                        select new { __loop37_var1 = __loop37_var1, prop = prop}
                        ).ToList(); //645:3
                    for (int __loop37_iteration = 0; __loop37_iteration < __loop37_results.Count; ++__loop37_iteration)
                    {
                        var __tmp46 = __loop37_results[__loop37_iteration];
                        var __loop37_var1 = __tmp46.__loop37_var1;
                        var prop = __tmp46.prop;
                        bool __tmp48_outputWritten = false;
                        string __tmp49_line = "	///     <li>"; //646:1
                        if (!string.IsNullOrEmpty(__tmp49_line))
                        {
                            __out.Append(__tmp49_line);
                            __tmp48_outputWritten = true;
                        }
                        StringBuilder __tmp50 = new StringBuilder();
                        __tmp50.Append(CSharpName(prop, model));
                        using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                        {
                            bool __tmp50_last = __tmp50Reader.EndOfStream;
                            while(!__tmp50_last)
                            {
                                string __tmp50_line = __tmp50Reader.ReadLine();
                                __tmp50_last = __tmp50Reader.EndOfStream;
                                if ((__tmp50_last && !string.IsNullOrEmpty(__tmp50_line)) || (!__tmp50_last && __tmp50_line != null))
                                {
                                    __out.Append(__tmp50_line);
                                    __tmp48_outputWritten = true;
                                }
                                if (!__tmp50_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp51_line = "</li>"; //646:38
                        if (!string.IsNullOrEmpty(__tmp51_line))
                        {
                            __out.Append(__tmp51_line);
                            __tmp48_outputWritten = true;
                        }
                        if (__tmp48_outputWritten) __out.AppendLine(true);
                        if (__tmp48_outputWritten)
                        {
                            __out.AppendLine(false); //646:43
                        }
                    }
                    __out.Append("	/// </ul>"); //648:1
                    __out.AppendLine(false); //648:11
                }
                if ((from __loop38_var1 in __Enumerate((cls).GetEnumerator()) //650:15
                from prop in __Enumerate((__loop38_var1.Properties).GetEnumerator()) //650:20
                where prop.Kind == MetaPropertyKind.Derived //650:36
                select new { __loop38_var1 = __loop38_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //650:3
                {
                    __out.Append("	/// Initializes the following derived properties:"); //651:1
                    __out.AppendLine(false); //651:51
                    __out.Append("	/// <ul>"); //652:1
                    __out.AppendLine(false); //652:10
                    var __loop39_results = 
                        (from __loop39_var1 in __Enumerate((cls).GetEnumerator()) //653:8
                        from prop in __Enumerate((__loop39_var1.Properties).GetEnumerator()) //653:13
                        where prop.Kind == MetaPropertyKind.Derived //653:29
                        select new { __loop39_var1 = __loop39_var1, prop = prop}
                        ).ToList(); //653:3
                    for (int __loop39_iteration = 0; __loop39_iteration < __loop39_results.Count; ++__loop39_iteration)
                    {
                        var __tmp52 = __loop39_results[__loop39_iteration];
                        var __loop39_var1 = __tmp52.__loop39_var1;
                        var prop = __tmp52.prop;
                        bool __tmp54_outputWritten = false;
                        string __tmp55_line = "	///     <li>"; //654:1
                        if (!string.IsNullOrEmpty(__tmp55_line))
                        {
                            __out.Append(__tmp55_line);
                            __tmp54_outputWritten = true;
                        }
                        StringBuilder __tmp56 = new StringBuilder();
                        __tmp56.Append(CSharpName(prop, model));
                        using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
                        {
                            bool __tmp56_last = __tmp56Reader.EndOfStream;
                            while(!__tmp56_last)
                            {
                                string __tmp56_line = __tmp56Reader.ReadLine();
                                __tmp56_last = __tmp56Reader.EndOfStream;
                                if ((__tmp56_last && !string.IsNullOrEmpty(__tmp56_line)) || (!__tmp56_last && __tmp56_line != null))
                                {
                                    __out.Append(__tmp56_line);
                                    __tmp54_outputWritten = true;
                                }
                                if (!__tmp56_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp57_line = "</li>"; //654:38
                        if (!string.IsNullOrEmpty(__tmp57_line))
                        {
                            __out.Append(__tmp57_line);
                            __tmp54_outputWritten = true;
                        }
                        if (__tmp54_outputWritten) __out.AppendLine(true);
                        if (__tmp54_outputWritten)
                        {
                            __out.AppendLine(false); //654:43
                        }
                    }
                    __out.Append("	/// </ul>"); //656:1
                    __out.AppendLine(false); //656:11
                }
                bool __tmp59_outputWritten = false;
                string __tmp60_line = "	public virtual void "; //658:1
                if (!string.IsNullOrEmpty(__tmp60_line))
                {
                    __out.Append(__tmp60_line);
                    __tmp59_outputWritten = true;
                }
                StringBuilder __tmp61 = new StringBuilder();
                __tmp61.Append(CSharpName(cls, model, ClassKind.Immutable));
                using(StreamReader __tmp61Reader = new StreamReader(this.__ToStream(__tmp61.ToString())))
                {
                    bool __tmp61_last = __tmp61Reader.EndOfStream;
                    while(!__tmp61_last)
                    {
                        string __tmp61_line = __tmp61Reader.ReadLine();
                        __tmp61_last = __tmp61Reader.EndOfStream;
                        if ((__tmp61_last && !string.IsNullOrEmpty(__tmp61_line)) || (!__tmp61_last && __tmp61_line != null))
                        {
                            __out.Append(__tmp61_line);
                            __tmp59_outputWritten = true;
                        }
                        if (!__tmp61_last) __out.AppendLine(true);
                    }
                }
                string __tmp62_line = "("; //658:66
                if (!string.IsNullOrEmpty(__tmp62_line))
                {
                    __out.Append(__tmp62_line);
                    __tmp59_outputWritten = true;
                }
                StringBuilder __tmp63 = new StringBuilder();
                __tmp63.Append(CSharpName(cls, model, ClassKind.Builder));
                using(StreamReader __tmp63Reader = new StreamReader(this.__ToStream(__tmp63.ToString())))
                {
                    bool __tmp63_last = __tmp63Reader.EndOfStream;
                    while(!__tmp63_last)
                    {
                        string __tmp63_line = __tmp63Reader.ReadLine();
                        __tmp63_last = __tmp63Reader.EndOfStream;
                        if ((__tmp63_last && !string.IsNullOrEmpty(__tmp63_line)) || (!__tmp63_last && __tmp63_line != null))
                        {
                            __out.Append(__tmp63_line);
                            __tmp59_outputWritten = true;
                        }
                        if (!__tmp63_last) __out.AppendLine(true);
                    }
                }
                string __tmp64_line = " _this)"; //658:109
                if (!string.IsNullOrEmpty(__tmp64_line))
                {
                    __out.Append(__tmp64_line);
                    __tmp59_outputWritten = true;
                }
                if (__tmp59_outputWritten) __out.AppendLine(true);
                if (__tmp59_outputWritten)
                {
                    __out.AppendLine(false); //658:116
                }
                __out.Append("	{"); //659:1
                __out.AppendLine(false); //659:3
                bool __tmp66_outputWritten = false;
                string __tmp67_line = "		this.Call"; //660:1
                if (!string.IsNullOrEmpty(__tmp67_line))
                {
                    __out.Append(__tmp67_line);
                    __tmp66_outputWritten = true;
                }
                StringBuilder __tmp68 = new StringBuilder();
                __tmp68.Append(CSharpName(cls, model, ClassKind.Immutable));
                using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
                {
                    bool __tmp68_last = __tmp68Reader.EndOfStream;
                    while(!__tmp68_last)
                    {
                        string __tmp68_line = __tmp68Reader.ReadLine();
                        __tmp68_last = __tmp68Reader.EndOfStream;
                        if ((__tmp68_last && !string.IsNullOrEmpty(__tmp68_line)) || (!__tmp68_last && __tmp68_line != null))
                        {
                            __out.Append(__tmp68_line);
                            __tmp66_outputWritten = true;
                        }
                        if (!__tmp68_last) __out.AppendLine(true);
                    }
                }
                string __tmp69_line = "SuperConstructors(_this);"; //660:56
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Append(__tmp69_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //660:81
                }
                var __loop40_results = 
                    (from __loop40_var1 in __Enumerate((cls).GetEnumerator()) //661:9
                    from prop in __Enumerate((__loop40_var1.GetAllFinalProperties()).GetEnumerator()) //661:14
                    select new { __loop40_var1 = __loop40_var1, prop = prop}
                    ).ToList(); //661:4
                for (int __loop40_iteration = 0; __loop40_iteration < __loop40_results.Count; ++__loop40_iteration)
                {
                    var __tmp70 = __loop40_results[__loop40_iteration];
                    var __loop40_var1 = __tmp70.__loop40_var1;
                    var prop = __tmp70.prop;
                    if (metaMetaModel && cls.Name == "MetaConstant" && prop.Name == "Value") //662:5
                    {
                    }
                    else if (prop.DefaultValue != null) //663:5
                    {
                        if (!(prop.Type is MetaCollectionType)) //664:6
                        {
                            bool __tmp72_outputWritten = false;
                            string __tmp73_line = "		_this.Set"; //665:1
                            if (!string.IsNullOrEmpty(__tmp73_line))
                            {
                                __out.Append(__tmp73_line);
                                __tmp72_outputWritten = true;
                            }
                            StringBuilder __tmp74 = new StringBuilder();
                            __tmp74.Append(CSharpName(prop, model, PropertyKind.Builder));
                            using(StreamReader __tmp74Reader = new StreamReader(this.__ToStream(__tmp74.ToString())))
                            {
                                bool __tmp74_last = __tmp74Reader.EndOfStream;
                                while(!__tmp74_last)
                                {
                                    string __tmp74_line = __tmp74Reader.ReadLine();
                                    __tmp74_last = __tmp74Reader.EndOfStream;
                                    if ((__tmp74_last && !string.IsNullOrEmpty(__tmp74_line)) || (!__tmp74_last && __tmp74_line != null))
                                    {
                                        __out.Append(__tmp74_line);
                                        __tmp72_outputWritten = true;
                                    }
                                    if (!__tmp74_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp75_line = "Lazy(() => "; //665:58
                            if (!string.IsNullOrEmpty(__tmp75_line))
                            {
                                __out.Append(__tmp75_line);
                                __tmp72_outputWritten = true;
                            }
                            StringBuilder __tmp76 = new StringBuilder();
                            __tmp76.Append(prop.DefaultValue);
                            using(StreamReader __tmp76Reader = new StreamReader(this.__ToStream(__tmp76.ToString())))
                            {
                                bool __tmp76_last = __tmp76Reader.EndOfStream;
                                while(!__tmp76_last)
                                {
                                    string __tmp76_line = __tmp76Reader.ReadLine();
                                    __tmp76_last = __tmp76Reader.EndOfStream;
                                    if ((__tmp76_last && !string.IsNullOrEmpty(__tmp76_line)) || (!__tmp76_last && __tmp76_line != null))
                                    {
                                        __out.Append(__tmp76_line);
                                        __tmp72_outputWritten = true;
                                    }
                                    if (!__tmp76_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp77_line = ");"; //665:88
                            if (!string.IsNullOrEmpty(__tmp77_line))
                            {
                                __out.Append(__tmp77_line);
                                __tmp72_outputWritten = true;
                            }
                            if (__tmp72_outputWritten) __out.AppendLine(true);
                            if (__tmp72_outputWritten)
                            {
                                __out.AppendLine(false); //665:90
                            }
                        }
                        else //666:6
                        {
                            __out.Append("		// ERROR: default value for collection"); //667:1
                            __out.AppendLine(false); //667:41
                            bool __tmp79_outputWritten = false;
                            string __tmp80_line = "		// _this."; //668:1
                            if (!string.IsNullOrEmpty(__tmp80_line))
                            {
                                __out.Append(__tmp80_line);
                                __tmp79_outputWritten = true;
                            }
                            StringBuilder __tmp81 = new StringBuilder();
                            __tmp81.Append(CSharpName(prop, model, PropertyKind.Builder));
                            using(StreamReader __tmp81Reader = new StreamReader(this.__ToStream(__tmp81.ToString())))
                            {
                                bool __tmp81_last = __tmp81Reader.EndOfStream;
                                while(!__tmp81_last)
                                {
                                    string __tmp81_line = __tmp81Reader.ReadLine();
                                    __tmp81_last = __tmp81Reader.EndOfStream;
                                    if ((__tmp81_last && !string.IsNullOrEmpty(__tmp81_line)) || (!__tmp81_last && __tmp81_line != null))
                                    {
                                        __out.Append(__tmp81_line);
                                        __tmp79_outputWritten = true;
                                    }
                                    if (!__tmp81_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp82_line = " = "; //668:58
                            if (!string.IsNullOrEmpty(__tmp82_line))
                            {
                                __out.Append(__tmp82_line);
                                __tmp79_outputWritten = true;
                            }
                            StringBuilder __tmp83 = new StringBuilder();
                            __tmp83.Append(prop.DefaultValue);
                            using(StreamReader __tmp83Reader = new StreamReader(this.__ToStream(__tmp83.ToString())))
                            {
                                bool __tmp83_last = __tmp83Reader.EndOfStream;
                                while(!__tmp83_last)
                                {
                                    string __tmp83_line = __tmp83Reader.ReadLine();
                                    __tmp83_last = __tmp83Reader.EndOfStream;
                                    if ((__tmp83_last && !string.IsNullOrEmpty(__tmp83_line)) || (!__tmp83_last && __tmp83_line != null))
                                    {
                                        __out.Append(__tmp83_line);
                                        __tmp79_outputWritten = true;
                                    }
                                    if (!__tmp83_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp84_line = ";"; //668:80
                            if (!string.IsNullOrEmpty(__tmp84_line))
                            {
                                __out.Append(__tmp84_line);
                                __tmp79_outputWritten = true;
                            }
                            if (__tmp79_outputWritten) __out.AppendLine(true);
                            if (__tmp79_outputWritten)
                            {
                                __out.AppendLine(false); //668:81
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Lazy || prop.Kind == MetaPropertyKind.Derived) //670:5
                    {
                        if (!(prop.Type is MetaCollectionType)) //671:6
                        {
                            bool __tmp86_outputWritten = false;
                            string __tmp87_line = "		_this.Set"; //672:1
                            if (!string.IsNullOrEmpty(__tmp87_line))
                            {
                                __out.Append(__tmp87_line);
                                __tmp86_outputWritten = true;
                            }
                            StringBuilder __tmp88 = new StringBuilder();
                            __tmp88.Append(CSharpName(prop, model, PropertyKind.Builder));
                            using(StreamReader __tmp88Reader = new StreamReader(this.__ToStream(__tmp88.ToString())))
                            {
                                bool __tmp88_last = __tmp88Reader.EndOfStream;
                                while(!__tmp88_last)
                                {
                                    string __tmp88_line = __tmp88Reader.ReadLine();
                                    __tmp88_last = __tmp88Reader.EndOfStream;
                                    if ((__tmp88_last && !string.IsNullOrEmpty(__tmp88_line)) || (!__tmp88_last && __tmp88_line != null))
                                    {
                                        __out.Append(__tmp88_line);
                                        __tmp86_outputWritten = true;
                                    }
                                    if (!__tmp88_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp89_line = "Lazy(this."; //672:58
                            if (!string.IsNullOrEmpty(__tmp89_line))
                            {
                                __out.Append(__tmp89_line);
                                __tmp86_outputWritten = true;
                            }
                            StringBuilder __tmp90 = new StringBuilder();
                            __tmp90.Append(CSharpName(prop.Class, model, ClassKind.Immutable));
                            using(StreamReader __tmp90Reader = new StreamReader(this.__ToStream(__tmp90.ToString())))
                            {
                                bool __tmp90_last = __tmp90Reader.EndOfStream;
                                while(!__tmp90_last)
                                {
                                    string __tmp90_line = __tmp90Reader.ReadLine();
                                    __tmp90_last = __tmp90Reader.EndOfStream;
                                    if ((__tmp90_last && !string.IsNullOrEmpty(__tmp90_line)) || (!__tmp90_last && __tmp90_line != null))
                                    {
                                        __out.Append(__tmp90_line);
                                        __tmp86_outputWritten = true;
                                    }
                                    if (!__tmp90_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp91_line = "_ComputeProperty_"; //672:119
                            if (!string.IsNullOrEmpty(__tmp91_line))
                            {
                                __out.Append(__tmp91_line);
                                __tmp86_outputWritten = true;
                            }
                            StringBuilder __tmp92 = new StringBuilder();
                            __tmp92.Append(CSharpName(prop, model));
                            using(StreamReader __tmp92Reader = new StreamReader(this.__ToStream(__tmp92.ToString())))
                            {
                                bool __tmp92_last = __tmp92Reader.EndOfStream;
                                while(!__tmp92_last)
                                {
                                    string __tmp92_line = __tmp92Reader.ReadLine();
                                    __tmp92_last = __tmp92Reader.EndOfStream;
                                    if ((__tmp92_last && !string.IsNullOrEmpty(__tmp92_line)) || (!__tmp92_last && __tmp92_line != null))
                                    {
                                        __out.Append(__tmp92_line);
                                        __tmp86_outputWritten = true;
                                    }
                                    if (!__tmp92_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp93_line = ");"; //672:160
                            if (!string.IsNullOrEmpty(__tmp93_line))
                            {
                                __out.Append(__tmp93_line);
                                __tmp86_outputWritten = true;
                            }
                            if (__tmp86_outputWritten) __out.AppendLine(true);
                            if (__tmp86_outputWritten)
                            {
                                __out.AppendLine(false); //672:162
                            }
                        }
                        else //673:6
                        {
                            bool __tmp95_outputWritten = false;
                            string __tmp96_line = "		_this."; //674:1
                            if (!string.IsNullOrEmpty(__tmp96_line))
                            {
                                __out.Append(__tmp96_line);
                                __tmp95_outputWritten = true;
                            }
                            StringBuilder __tmp97 = new StringBuilder();
                            __tmp97.Append(CSharpName(prop, model, PropertyKind.Builder));
                            using(StreamReader __tmp97Reader = new StreamReader(this.__ToStream(__tmp97.ToString())))
                            {
                                bool __tmp97_last = __tmp97Reader.EndOfStream;
                                while(!__tmp97_last)
                                {
                                    string __tmp97_line = __tmp97Reader.ReadLine();
                                    __tmp97_last = __tmp97Reader.EndOfStream;
                                    if ((__tmp97_last && !string.IsNullOrEmpty(__tmp97_line)) || (!__tmp97_last && __tmp97_line != null))
                                    {
                                        __out.Append(__tmp97_line);
                                        __tmp95_outputWritten = true;
                                    }
                                    if (!__tmp97_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp98_line = ".AddRangeLazy<"; //674:55
                            if (!string.IsNullOrEmpty(__tmp98_line))
                            {
                                __out.Append(__tmp98_line);
                                __tmp95_outputWritten = true;
                            }
                            StringBuilder __tmp99 = new StringBuilder();
                            __tmp99.Append(CSharpName(prop.Class, model, ClassKind.Builder));
                            using(StreamReader __tmp99Reader = new StreamReader(this.__ToStream(__tmp99.ToString())))
                            {
                                bool __tmp99_last = __tmp99Reader.EndOfStream;
                                while(!__tmp99_last)
                                {
                                    string __tmp99_line = __tmp99Reader.ReadLine();
                                    __tmp99_last = __tmp99Reader.EndOfStream;
                                    if ((__tmp99_last && !string.IsNullOrEmpty(__tmp99_line)) || (!__tmp99_last && __tmp99_line != null))
                                    {
                                        __out.Append(__tmp99_line);
                                        __tmp95_outputWritten = true;
                                    }
                                    if (!__tmp99_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp100_line = ">(this."; //674:118
                            if (!string.IsNullOrEmpty(__tmp100_line))
                            {
                                __out.Append(__tmp100_line);
                                __tmp95_outputWritten = true;
                            }
                            StringBuilder __tmp101 = new StringBuilder();
                            __tmp101.Append(CSharpName(prop.Class, model, ClassKind.Immutable));
                            using(StreamReader __tmp101Reader = new StreamReader(this.__ToStream(__tmp101.ToString())))
                            {
                                bool __tmp101_last = __tmp101Reader.EndOfStream;
                                while(!__tmp101_last)
                                {
                                    string __tmp101_line = __tmp101Reader.ReadLine();
                                    __tmp101_last = __tmp101Reader.EndOfStream;
                                    if ((__tmp101_last && !string.IsNullOrEmpty(__tmp101_line)) || (!__tmp101_last && __tmp101_line != null))
                                    {
                                        __out.Append(__tmp101_line);
                                        __tmp95_outputWritten = true;
                                    }
                                    if (!__tmp101_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp102_line = "_ComputeProperty_"; //674:176
                            if (!string.IsNullOrEmpty(__tmp102_line))
                            {
                                __out.Append(__tmp102_line);
                                __tmp95_outputWritten = true;
                            }
                            StringBuilder __tmp103 = new StringBuilder();
                            __tmp103.Append(CSharpName(prop, model));
                            using(StreamReader __tmp103Reader = new StreamReader(this.__ToStream(__tmp103.ToString())))
                            {
                                bool __tmp103_last = __tmp103Reader.EndOfStream;
                                while(!__tmp103_last)
                                {
                                    string __tmp103_line = __tmp103Reader.ReadLine();
                                    __tmp103_last = __tmp103Reader.EndOfStream;
                                    if ((__tmp103_last && !string.IsNullOrEmpty(__tmp103_line)) || (!__tmp103_last && __tmp103_line != null))
                                    {
                                        __out.Append(__tmp103_line);
                                        __tmp95_outputWritten = true;
                                    }
                                    if (!__tmp103_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp104_line = ");"; //674:217
                            if (!string.IsNullOrEmpty(__tmp104_line))
                            {
                                __out.Append(__tmp104_line);
                                __tmp95_outputWritten = true;
                            }
                            if (__tmp95_outputWritten) __out.AppendLine(true);
                            if (__tmp95_outputWritten)
                            {
                                __out.AppendLine(false); //674:219
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Readonly) //676:5
                    {
                        if (!(prop.Type is MetaCollectionType)) //677:6
                        {
                            bool __tmp106_outputWritten = false;
                            string __tmp107_line = "		_this.Set"; //678:1
                            if (!string.IsNullOrEmpty(__tmp107_line))
                            {
                                __out.Append(__tmp107_line);
                                __tmp106_outputWritten = true;
                            }
                            StringBuilder __tmp108 = new StringBuilder();
                            __tmp108.Append(CSharpName(prop, model, PropertyKind.Builder));
                            using(StreamReader __tmp108Reader = new StreamReader(this.__ToStream(__tmp108.ToString())))
                            {
                                bool __tmp108_last = __tmp108Reader.EndOfStream;
                                while(!__tmp108_last)
                                {
                                    string __tmp108_line = __tmp108Reader.ReadLine();
                                    __tmp108_last = __tmp108Reader.EndOfStream;
                                    if ((__tmp108_last && !string.IsNullOrEmpty(__tmp108_line)) || (!__tmp108_last && __tmp108_line != null))
                                    {
                                        __out.Append(__tmp108_line);
                                        __tmp106_outputWritten = true;
                                    }
                                    if (!__tmp108_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp109_line = "Lazy(this."; //678:58
                            if (!string.IsNullOrEmpty(__tmp109_line))
                            {
                                __out.Append(__tmp109_line);
                                __tmp106_outputWritten = true;
                            }
                            StringBuilder __tmp110 = new StringBuilder();
                            __tmp110.Append(CSharpName(prop.Class, model, ClassKind.Immutable));
                            using(StreamReader __tmp110Reader = new StreamReader(this.__ToStream(__tmp110.ToString())))
                            {
                                bool __tmp110_last = __tmp110Reader.EndOfStream;
                                while(!__tmp110_last)
                                {
                                    string __tmp110_line = __tmp110Reader.ReadLine();
                                    __tmp110_last = __tmp110Reader.EndOfStream;
                                    if ((__tmp110_last && !string.IsNullOrEmpty(__tmp110_line)) || (!__tmp110_last && __tmp110_line != null))
                                    {
                                        __out.Append(__tmp110_line);
                                        __tmp106_outputWritten = true;
                                    }
                                    if (!__tmp110_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp111_line = "_ComputeProperty_"; //678:119
                            if (!string.IsNullOrEmpty(__tmp111_line))
                            {
                                __out.Append(__tmp111_line);
                                __tmp106_outputWritten = true;
                            }
                            StringBuilder __tmp112 = new StringBuilder();
                            __tmp112.Append(CSharpName(prop, model));
                            using(StreamReader __tmp112Reader = new StreamReader(this.__ToStream(__tmp112.ToString())))
                            {
                                bool __tmp112_last = __tmp112Reader.EndOfStream;
                                while(!__tmp112_last)
                                {
                                    string __tmp112_line = __tmp112Reader.ReadLine();
                                    __tmp112_last = __tmp112Reader.EndOfStream;
                                    if ((__tmp112_last && !string.IsNullOrEmpty(__tmp112_line)) || (!__tmp112_last && __tmp112_line != null))
                                    {
                                        __out.Append(__tmp112_line);
                                        __tmp106_outputWritten = true;
                                    }
                                    if (!__tmp112_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp113_line = ");"; //678:160
                            if (!string.IsNullOrEmpty(__tmp113_line))
                            {
                                __out.Append(__tmp113_line);
                                __tmp106_outputWritten = true;
                            }
                            if (__tmp106_outputWritten) __out.AppendLine(true);
                            if (__tmp106_outputWritten)
                            {
                                __out.AppendLine(false); //678:162
                            }
                        }
                        else //679:6
                        {
                            bool __tmp115_outputWritten = false;
                            string __tmp116_line = "		_this."; //680:1
                            if (!string.IsNullOrEmpty(__tmp116_line))
                            {
                                __out.Append(__tmp116_line);
                                __tmp115_outputWritten = true;
                            }
                            StringBuilder __tmp117 = new StringBuilder();
                            __tmp117.Append(CSharpName(prop, model, PropertyKind.Builder));
                            using(StreamReader __tmp117Reader = new StreamReader(this.__ToStream(__tmp117.ToString())))
                            {
                                bool __tmp117_last = __tmp117Reader.EndOfStream;
                                while(!__tmp117_last)
                                {
                                    string __tmp117_line = __tmp117Reader.ReadLine();
                                    __tmp117_last = __tmp117Reader.EndOfStream;
                                    if ((__tmp117_last && !string.IsNullOrEmpty(__tmp117_line)) || (!__tmp117_last && __tmp117_line != null))
                                    {
                                        __out.Append(__tmp117_line);
                                        __tmp115_outputWritten = true;
                                    }
                                    if (!__tmp117_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp118_line = ".AddRangeLazy("; //680:55
                            if (!string.IsNullOrEmpty(__tmp118_line))
                            {
                                __out.Append(__tmp118_line);
                                __tmp115_outputWritten = true;
                            }
                            StringBuilder __tmp119 = new StringBuilder();
                            __tmp119.Append(CSharpName(prop.Class, model, ClassKind.Immutable));
                            using(StreamReader __tmp119Reader = new StreamReader(this.__ToStream(__tmp119.ToString())))
                            {
                                bool __tmp119_last = __tmp119Reader.EndOfStream;
                                while(!__tmp119_last)
                                {
                                    string __tmp119_line = __tmp119Reader.ReadLine();
                                    __tmp119_last = __tmp119Reader.EndOfStream;
                                    if ((__tmp119_last && !string.IsNullOrEmpty(__tmp119_line)) || (!__tmp119_last && __tmp119_line != null))
                                    {
                                        __out.Append(__tmp119_line);
                                        __tmp115_outputWritten = true;
                                    }
                                    if (!__tmp119_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp120_line = "_ComputeProperty_"; //680:120
                            if (!string.IsNullOrEmpty(__tmp120_line))
                            {
                                __out.Append(__tmp120_line);
                                __tmp115_outputWritten = true;
                            }
                            StringBuilder __tmp121 = new StringBuilder();
                            __tmp121.Append(CSharpName(prop, model));
                            using(StreamReader __tmp121Reader = new StreamReader(this.__ToStream(__tmp121.ToString())))
                            {
                                bool __tmp121_last = __tmp121Reader.EndOfStream;
                                while(!__tmp121_last)
                                {
                                    string __tmp121_line = __tmp121Reader.ReadLine();
                                    __tmp121_last = __tmp121Reader.EndOfStream;
                                    if ((__tmp121_last && !string.IsNullOrEmpty(__tmp121_line)) || (!__tmp121_last && __tmp121_line != null))
                                    {
                                        __out.Append(__tmp121_line);
                                        __tmp115_outputWritten = true;
                                    }
                                    if (!__tmp121_last) __out.AppendLine(true);
                                }
                            }
                            string __tmp122_line = ");"; //680:161
                            if (!string.IsNullOrEmpty(__tmp122_line))
                            {
                                __out.Append(__tmp122_line);
                                __tmp115_outputWritten = true;
                            }
                            if (__tmp115_outputWritten) __out.AppendLine(true);
                            if (__tmp115_outputWritten)
                            {
                                __out.AppendLine(false); //680:163
                            }
                        }
                    }
                }
                __out.Append("	}"); //684:1
                __out.AppendLine(false); //684:3
                __out.AppendLine(true); //685:1
                __out.Append("	/// <summary>"); //686:1
                __out.AppendLine(false); //686:15
                bool __tmp124_outputWritten = false;
                string __tmp125_line = "	/// Calls the super constructors of "; //687:1
                if (!string.IsNullOrEmpty(__tmp125_line))
                {
                    __out.Append(__tmp125_line);
                    __tmp124_outputWritten = true;
                }
                StringBuilder __tmp126 = new StringBuilder();
                __tmp126.Append(CSharpName(cls, model, ClassKind.Immutable));
                using(StreamReader __tmp126Reader = new StreamReader(this.__ToStream(__tmp126.ToString())))
                {
                    bool __tmp126_last = __tmp126Reader.EndOfStream;
                    while(!__tmp126_last)
                    {
                        string __tmp126_line = __tmp126Reader.ReadLine();
                        __tmp126_last = __tmp126Reader.EndOfStream;
                        if ((__tmp126_last && !string.IsNullOrEmpty(__tmp126_line)) || (!__tmp126_last && __tmp126_line != null))
                        {
                            __out.Append(__tmp126_line);
                            __tmp124_outputWritten = true;
                        }
                        if (!__tmp126_last || __tmp124_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp124_outputWritten)
                {
                    __out.AppendLine(false); //687:82
                }
                __out.Append("	/// </summary>"); //688:1
                __out.AppendLine(false); //688:16
                bool __tmp128_outputWritten = false;
                string __tmp129_line = "	protected virtual void Call"; //689:1
                if (!string.IsNullOrEmpty(__tmp129_line))
                {
                    __out.Append(__tmp129_line);
                    __tmp128_outputWritten = true;
                }
                StringBuilder __tmp130 = new StringBuilder();
                __tmp130.Append(CSharpName(cls, model, ClassKind.Immutable));
                using(StreamReader __tmp130Reader = new StreamReader(this.__ToStream(__tmp130.ToString())))
                {
                    bool __tmp130_last = __tmp130Reader.EndOfStream;
                    while(!__tmp130_last)
                    {
                        string __tmp130_line = __tmp130Reader.ReadLine();
                        __tmp130_last = __tmp130Reader.EndOfStream;
                        if ((__tmp130_last && !string.IsNullOrEmpty(__tmp130_line)) || (!__tmp130_last && __tmp130_line != null))
                        {
                            __out.Append(__tmp130_line);
                            __tmp128_outputWritten = true;
                        }
                        if (!__tmp130_last) __out.AppendLine(true);
                    }
                }
                string __tmp131_line = "SuperConstructors("; //689:73
                if (!string.IsNullOrEmpty(__tmp131_line))
                {
                    __out.Append(__tmp131_line);
                    __tmp128_outputWritten = true;
                }
                StringBuilder __tmp132 = new StringBuilder();
                __tmp132.Append(CSharpName(cls, model, ClassKind.Builder));
                using(StreamReader __tmp132Reader = new StreamReader(this.__ToStream(__tmp132.ToString())))
                {
                    bool __tmp132_last = __tmp132Reader.EndOfStream;
                    while(!__tmp132_last)
                    {
                        string __tmp132_line = __tmp132Reader.ReadLine();
                        __tmp132_last = __tmp132Reader.EndOfStream;
                        if ((__tmp132_last && !string.IsNullOrEmpty(__tmp132_line)) || (!__tmp132_last && __tmp132_line != null))
                        {
                            __out.Append(__tmp132_line);
                            __tmp128_outputWritten = true;
                        }
                        if (!__tmp132_last) __out.AppendLine(true);
                    }
                }
                string __tmp133_line = " _this)"; //689:133
                if (!string.IsNullOrEmpty(__tmp133_line))
                {
                    __out.Append(__tmp133_line);
                    __tmp128_outputWritten = true;
                }
                if (__tmp128_outputWritten) __out.AppendLine(true);
                if (__tmp128_outputWritten)
                {
                    __out.AppendLine(false); //689:140
                }
                __out.Append("	{"); //690:1
                __out.AppendLine(false); //690:3
                var __loop41_results = 
                    (from __loop41_var1 in __Enumerate((cls).GetEnumerator()) //691:8
                    from sup in __Enumerate((__loop41_var1.GetAllSuperClasses(false)).GetEnumerator()) //691:13
                    select new { __loop41_var1 = __loop41_var1, sup = sup}
                    ).ToList(); //691:3
                for (int __loop41_iteration = 0; __loop41_iteration < __loop41_results.Count; ++__loop41_iteration)
                {
                    var __tmp134 = __loop41_results[__loop41_iteration];
                    var __loop41_var1 = __tmp134.__loop41_var1;
                    var sup = __tmp134.sup;
                    if (model.Namespace.Declarations.Contains(sup)) //692:4
                    {
                        bool __tmp136_outputWritten = false;
                        string __tmp137_line = "		this."; //693:1
                        if (!string.IsNullOrEmpty(__tmp137_line))
                        {
                            __out.Append(__tmp137_line);
                            __tmp136_outputWritten = true;
                        }
                        StringBuilder __tmp138 = new StringBuilder();
                        __tmp138.Append(CSharpName(sup, model, ClassKind.Immutable));
                        using(StreamReader __tmp138Reader = new StreamReader(this.__ToStream(__tmp138.ToString())))
                        {
                            bool __tmp138_last = __tmp138Reader.EndOfStream;
                            while(!__tmp138_last)
                            {
                                string __tmp138_line = __tmp138Reader.ReadLine();
                                __tmp138_last = __tmp138Reader.EndOfStream;
                                if ((__tmp138_last && !string.IsNullOrEmpty(__tmp138_line)) || (!__tmp138_last && __tmp138_line != null))
                                {
                                    __out.Append(__tmp138_line);
                                    __tmp136_outputWritten = true;
                                }
                                if (!__tmp138_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp139_line = "(_this);"; //693:52
                        if (!string.IsNullOrEmpty(__tmp139_line))
                        {
                            __out.Append(__tmp139_line);
                            __tmp136_outputWritten = true;
                        }
                        if (__tmp136_outputWritten) __out.AppendLine(true);
                        if (__tmp136_outputWritten)
                        {
                            __out.AppendLine(false); //693:60
                        }
                    }
                    else //694:4
                    {
                        bool __tmp141_outputWritten = false;
                        string __tmp140Prefix = "		"; //695:1
                        StringBuilder __tmp142 = new StringBuilder();
                        __tmp142.Append(CSharpName(sup.MetaModel, ModelKind.ImplementationProvider, true));
                        using(StreamReader __tmp142Reader = new StreamReader(this.__ToStream(__tmp142.ToString())))
                        {
                            bool __tmp142_last = __tmp142Reader.EndOfStream;
                            while(!__tmp142_last)
                            {
                                string __tmp142_line = __tmp142Reader.ReadLine();
                                __tmp142_last = __tmp142Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp140Prefix))
                                {
                                    __out.Append(__tmp140Prefix);
                                    __tmp141_outputWritten = true;
                                }
                                if ((__tmp142_last && !string.IsNullOrEmpty(__tmp142_line)) || (!__tmp142_last && __tmp142_line != null))
                                {
                                    __out.Append(__tmp142_line);
                                    __tmp141_outputWritten = true;
                                }
                                if (!__tmp142_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp143_line = "."; //695:69
                        if (!string.IsNullOrEmpty(__tmp143_line))
                        {
                            __out.Append(__tmp143_line);
                            __tmp141_outputWritten = true;
                        }
                        StringBuilder __tmp144 = new StringBuilder();
                        __tmp144.Append(CSharpName(sup, model, ClassKind.Immutable));
                        using(StreamReader __tmp144Reader = new StreamReader(this.__ToStream(__tmp144.ToString())))
                        {
                            bool __tmp144_last = __tmp144Reader.EndOfStream;
                            while(!__tmp144_last)
                            {
                                string __tmp144_line = __tmp144Reader.ReadLine();
                                __tmp144_last = __tmp144Reader.EndOfStream;
                                if ((__tmp144_last && !string.IsNullOrEmpty(__tmp144_line)) || (!__tmp144_last && __tmp144_line != null))
                                {
                                    __out.Append(__tmp144_line);
                                    __tmp141_outputWritten = true;
                                }
                                if (!__tmp144_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp145_line = "(_this);"; //695:114
                        if (!string.IsNullOrEmpty(__tmp145_line))
                        {
                            __out.Append(__tmp145_line);
                            __tmp141_outputWritten = true;
                        }
                        if (__tmp141_outputWritten) __out.AppendLine(true);
                        if (__tmp141_outputWritten)
                        {
                            __out.AppendLine(false); //695:122
                        }
                    }
                }
                __out.Append("	}"); //698:1
                __out.AppendLine(false); //698:3
                __out.AppendLine(true); //699:2
                var __loop42_results = 
                    (from __loop42_var1 in __Enumerate((cls).GetEnumerator()) //700:8
                    from prop in __Enumerate((__loop42_var1.Properties).GetEnumerator()) //700:13
                    where prop.Kind == MetaPropertyKind.Readonly || prop.Kind == MetaPropertyKind.Lazy || prop.Kind == MetaPropertyKind.Derived //700:29
                    select new { __loop42_var1 = __loop42_var1, prop = prop}
                    ).ToList(); //700:3
                for (int __loop42_iteration = 0; __loop42_iteration < __loop42_results.Count; ++__loop42_iteration)
                {
                    var __tmp146 = __loop42_results[__loop42_iteration];
                    var __loop42_var1 = __tmp146.__loop42_var1;
                    var prop = __tmp146.prop;
                    if (metaMetaModel && cls.Name == "MetaConstant" && prop.Name == "Value") //701:4
                    {
                    }
                    else //702:4
                    {
                        __out.Append("	/// <summary>"); //703:1
                        __out.AppendLine(false); //703:15
                        bool __tmp148_outputWritten = false;
                        string __tmp149_line = "	/// Computes the value of the property: "; //704:1
                        if (!string.IsNullOrEmpty(__tmp149_line))
                        {
                            __out.Append(__tmp149_line);
                            __tmp148_outputWritten = true;
                        }
                        StringBuilder __tmp150 = new StringBuilder();
                        __tmp150.Append(CSharpName(cls, model, ClassKind.Immutable));
                        using(StreamReader __tmp150Reader = new StreamReader(this.__ToStream(__tmp150.ToString())))
                        {
                            bool __tmp150_last = __tmp150Reader.EndOfStream;
                            while(!__tmp150_last)
                            {
                                string __tmp150_line = __tmp150Reader.ReadLine();
                                __tmp150_last = __tmp150Reader.EndOfStream;
                                if ((__tmp150_last && !string.IsNullOrEmpty(__tmp150_line)) || (!__tmp150_last && __tmp150_line != null))
                                {
                                    __out.Append(__tmp150_line);
                                    __tmp148_outputWritten = true;
                                }
                                if (!__tmp150_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp151_line = "."; //704:86
                        if (!string.IsNullOrEmpty(__tmp151_line))
                        {
                            __out.Append(__tmp151_line);
                            __tmp148_outputWritten = true;
                        }
                        StringBuilder __tmp152 = new StringBuilder();
                        __tmp152.Append(CSharpName(prop, model));
                        using(StreamReader __tmp152Reader = new StreamReader(this.__ToStream(__tmp152.ToString())))
                        {
                            bool __tmp152_last = __tmp152Reader.EndOfStream;
                            while(!__tmp152_last)
                            {
                                string __tmp152_line = __tmp152Reader.ReadLine();
                                __tmp152_last = __tmp152Reader.EndOfStream;
                                if ((__tmp152_last && !string.IsNullOrEmpty(__tmp152_line)) || (!__tmp152_last && __tmp152_line != null))
                                {
                                    __out.Append(__tmp152_line);
                                    __tmp148_outputWritten = true;
                                }
                                if (!__tmp152_last || __tmp148_outputWritten) __out.AppendLine(true);
                            }
                        }
                        if (__tmp148_outputWritten)
                        {
                            __out.AppendLine(false); //704:111
                        }
                        __out.Append("	/// </summary	"); //705:1
                        __out.AppendLine(false); //705:16
                        bool __tmp154_outputWritten = false;
                        string __tmp155_line = "	public abstract "; //706:1
                        if (!string.IsNullOrEmpty(__tmp155_line))
                        {
                            __out.Append(__tmp155_line);
                            __tmp154_outputWritten = true;
                        }
                        StringBuilder __tmp156 = new StringBuilder();
                        __tmp156.Append(CSharpName(prop.Type, model, ClassKind.BuilderOperation, true));
                        using(StreamReader __tmp156Reader = new StreamReader(this.__ToStream(__tmp156.ToString())))
                        {
                            bool __tmp156_last = __tmp156Reader.EndOfStream;
                            while(!__tmp156_last)
                            {
                                string __tmp156_line = __tmp156Reader.ReadLine();
                                __tmp156_last = __tmp156Reader.EndOfStream;
                                if ((__tmp156_last && !string.IsNullOrEmpty(__tmp156_line)) || (!__tmp156_last && __tmp156_line != null))
                                {
                                    __out.Append(__tmp156_line);
                                    __tmp154_outputWritten = true;
                                }
                                if (!__tmp156_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp157_line = " "; //706:81
                        if (!string.IsNullOrEmpty(__tmp157_line))
                        {
                            __out.Append(__tmp157_line);
                            __tmp154_outputWritten = true;
                        }
                        StringBuilder __tmp158 = new StringBuilder();
                        __tmp158.Append(CSharpName(cls, model, ClassKind.Immutable));
                        using(StreamReader __tmp158Reader = new StreamReader(this.__ToStream(__tmp158.ToString())))
                        {
                            bool __tmp158_last = __tmp158Reader.EndOfStream;
                            while(!__tmp158_last)
                            {
                                string __tmp158_line = __tmp158Reader.ReadLine();
                                __tmp158_last = __tmp158Reader.EndOfStream;
                                if ((__tmp158_last && !string.IsNullOrEmpty(__tmp158_line)) || (!__tmp158_last && __tmp158_line != null))
                                {
                                    __out.Append(__tmp158_line);
                                    __tmp154_outputWritten = true;
                                }
                                if (!__tmp158_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp159_line = "_ComputeProperty_"; //706:126
                        if (!string.IsNullOrEmpty(__tmp159_line))
                        {
                            __out.Append(__tmp159_line);
                            __tmp154_outputWritten = true;
                        }
                        StringBuilder __tmp160 = new StringBuilder();
                        __tmp160.Append(CSharpName(prop, model));
                        using(StreamReader __tmp160Reader = new StreamReader(this.__ToStream(__tmp160.ToString())))
                        {
                            bool __tmp160_last = __tmp160Reader.EndOfStream;
                            while(!__tmp160_last)
                            {
                                string __tmp160_line = __tmp160Reader.ReadLine();
                                __tmp160_last = __tmp160Reader.EndOfStream;
                                if ((__tmp160_last && !string.IsNullOrEmpty(__tmp160_line)) || (!__tmp160_last && __tmp160_line != null))
                                {
                                    __out.Append(__tmp160_line);
                                    __tmp154_outputWritten = true;
                                }
                                if (!__tmp160_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp161_line = "("; //706:167
                        if (!string.IsNullOrEmpty(__tmp161_line))
                        {
                            __out.Append(__tmp161_line);
                            __tmp154_outputWritten = true;
                        }
                        StringBuilder __tmp162 = new StringBuilder();
                        __tmp162.Append(CSharpName(cls, model, ClassKind.Builder));
                        using(StreamReader __tmp162Reader = new StreamReader(this.__ToStream(__tmp162.ToString())))
                        {
                            bool __tmp162_last = __tmp162Reader.EndOfStream;
                            while(!__tmp162_last)
                            {
                                string __tmp162_line = __tmp162Reader.ReadLine();
                                __tmp162_last = __tmp162Reader.EndOfStream;
                                if ((__tmp162_last && !string.IsNullOrEmpty(__tmp162_line)) || (!__tmp162_last && __tmp162_line != null))
                                {
                                    __out.Append(__tmp162_line);
                                    __tmp154_outputWritten = true;
                                }
                                if (!__tmp162_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp163_line = " _this);"; //706:210
                        if (!string.IsNullOrEmpty(__tmp163_line))
                        {
                            __out.Append(__tmp163_line);
                            __tmp154_outputWritten = true;
                        }
                        if (__tmp154_outputWritten) __out.AppendLine(true);
                        if (__tmp154_outputWritten)
                        {
                            __out.AppendLine(false); //706:218
                        }
                    }
                }
                __out.AppendLine(true); //709:2
                bool __tmp165_outputWritten = false;
                string __tmp166_line = "	public virtual void "; //710:1
                if (!string.IsNullOrEmpty(__tmp166_line))
                {
                    __out.Append(__tmp166_line);
                    __tmp165_outputWritten = true;
                }
                StringBuilder __tmp167 = new StringBuilder();
                __tmp167.Append(CSharpName(cls, model, ClassKind.Immutable));
                using(StreamReader __tmp167Reader = new StreamReader(this.__ToStream(__tmp167.ToString())))
                {
                    bool __tmp167_last = __tmp167Reader.EndOfStream;
                    while(!__tmp167_last)
                    {
                        string __tmp167_line = __tmp167Reader.ReadLine();
                        __tmp167_last = __tmp167Reader.EndOfStream;
                        if ((__tmp167_last && !string.IsNullOrEmpty(__tmp167_line)) || (!__tmp167_last && __tmp167_line != null))
                        {
                            __out.Append(__tmp167_line);
                            __tmp165_outputWritten = true;
                        }
                        if (!__tmp167_last) __out.AppendLine(true);
                    }
                }
                string __tmp168_line = "_MValidate("; //710:66
                if (!string.IsNullOrEmpty(__tmp168_line))
                {
                    __out.Append(__tmp168_line);
                    __tmp165_outputWritten = true;
                }
                StringBuilder __tmp169 = new StringBuilder();
                __tmp169.Append(CSharpName(cls, model, ClassKind.Builder));
                using(StreamReader __tmp169Reader = new StreamReader(this.__ToStream(__tmp169.ToString())))
                {
                    bool __tmp169_last = __tmp169Reader.EndOfStream;
                    while(!__tmp169_last)
                    {
                        string __tmp169_line = __tmp169Reader.ReadLine();
                        __tmp169_last = __tmp169Reader.EndOfStream;
                        if ((__tmp169_last && !string.IsNullOrEmpty(__tmp169_line)) || (!__tmp169_last && __tmp169_line != null))
                        {
                            __out.Append(__tmp169_line);
                            __tmp165_outputWritten = true;
                        }
                        if (!__tmp169_last) __out.AppendLine(true);
                    }
                }
                string __tmp170_line = " _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)"; //710:119
                if (!string.IsNullOrEmpty(__tmp170_line))
                {
                    __out.Append(__tmp170_line);
                    __tmp165_outputWritten = true;
                }
                if (__tmp165_outputWritten) __out.AppendLine(true);
                if (__tmp165_outputWritten)
                {
                    __out.AppendLine(false); //710:256
                }
                __out.Append("	{"); //711:1
                __out.AppendLine(false); //711:3
                __out.Append("	}"); //712:1
                __out.AppendLine(false); //712:3
                __out.AppendLine(true); //713:2
                var __loop43_results = 
                    (from __loop43_var1 in __Enumerate((cls).GetEnumerator()) //714:8
                    from op in __Enumerate((__loop43_var1.Operations).GetEnumerator()) //714:13
                    select new { __loop43_var1 = __loop43_var1, op = op}
                    ).ToList(); //714:3
                for (int __loop43_iteration = 0; __loop43_iteration < __loop43_results.Count; ++__loop43_iteration)
                {
                    var __tmp171 = __loop43_results[__loop43_iteration];
                    var __loop43_var1 = __tmp171.__loop43_var1;
                    var op = __tmp171.op;
                    if (!op.IsBuilder) //715:4
                    {
                        __out.AppendLine(true); //716:2
                        __out.Append("	/// <summary>"); //717:1
                        __out.AppendLine(false); //717:15
                        bool __tmp173_outputWritten = false;
                        string __tmp174_line = "	/// Implements the operation: "; //718:1
                        if (!string.IsNullOrEmpty(__tmp174_line))
                        {
                            __out.Append(__tmp174_line);
                            __tmp173_outputWritten = true;
                        }
                        StringBuilder __tmp175 = new StringBuilder();
                        __tmp175.Append(CSharpName(cls, model, ClassKind.Immutable));
                        using(StreamReader __tmp175Reader = new StreamReader(this.__ToStream(__tmp175.ToString())))
                        {
                            bool __tmp175_last = __tmp175Reader.EndOfStream;
                            while(!__tmp175_last)
                            {
                                string __tmp175_line = __tmp175Reader.ReadLine();
                                __tmp175_last = __tmp175Reader.EndOfStream;
                                if ((__tmp175_last && !string.IsNullOrEmpty(__tmp175_line)) || (!__tmp175_last && __tmp175_line != null))
                                {
                                    __out.Append(__tmp175_line);
                                    __tmp173_outputWritten = true;
                                }
                                if (!__tmp175_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp176_line = "."; //718:76
                        if (!string.IsNullOrEmpty(__tmp176_line))
                        {
                            __out.Append(__tmp176_line);
                            __tmp173_outputWritten = true;
                        }
                        StringBuilder __tmp177 = new StringBuilder();
                        __tmp177.Append(op.Name);
                        using(StreamReader __tmp177Reader = new StreamReader(this.__ToStream(__tmp177.ToString())))
                        {
                            bool __tmp177_last = __tmp177Reader.EndOfStream;
                            while(!__tmp177_last)
                            {
                                string __tmp177_line = __tmp177Reader.ReadLine();
                                __tmp177_last = __tmp177Reader.EndOfStream;
                                if ((__tmp177_last && !string.IsNullOrEmpty(__tmp177_line)) || (!__tmp177_last && __tmp177_line != null))
                                {
                                    __out.Append(__tmp177_line);
                                    __tmp173_outputWritten = true;
                                }
                                if (!__tmp177_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp178_line = "()"; //718:86
                        if (!string.IsNullOrEmpty(__tmp178_line))
                        {
                            __out.Append(__tmp178_line);
                            __tmp173_outputWritten = true;
                        }
                        if (__tmp173_outputWritten) __out.AppendLine(true);
                        if (__tmp173_outputWritten)
                        {
                            __out.AppendLine(false); //718:88
                        }
                        __out.Append("	/// </summary>"); //719:1
                        __out.AppendLine(false); //719:16
                        bool __tmp180_outputWritten = false;
                        string __tmp181_line = "	public virtual "; //720:1
                        if (!string.IsNullOrEmpty(__tmp181_line))
                        {
                            __out.Append(__tmp181_line);
                            __tmp180_outputWritten = true;
                        }
                        StringBuilder __tmp182 = new StringBuilder();
                        __tmp182.Append(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation, true));
                        using(StreamReader __tmp182Reader = new StreamReader(this.__ToStream(__tmp182.ToString())))
                        {
                            bool __tmp182_last = __tmp182Reader.EndOfStream;
                            while(!__tmp182_last)
                            {
                                string __tmp182_line = __tmp182Reader.ReadLine();
                                __tmp182_last = __tmp182Reader.EndOfStream;
                                if ((__tmp182_last && !string.IsNullOrEmpty(__tmp182_line)) || (!__tmp182_last && __tmp182_line != null))
                                {
                                    __out.Append(__tmp182_line);
                                    __tmp180_outputWritten = true;
                                }
                                if (!__tmp182_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp183_line = " "; //720:86
                        if (!string.IsNullOrEmpty(__tmp183_line))
                        {
                            __out.Append(__tmp183_line);
                            __tmp180_outputWritten = true;
                        }
                        StringBuilder __tmp184 = new StringBuilder();
                        __tmp184.Append(CSharpName(cls, model, ClassKind.Immutable));
                        using(StreamReader __tmp184Reader = new StreamReader(this.__ToStream(__tmp184.ToString())))
                        {
                            bool __tmp184_last = __tmp184Reader.EndOfStream;
                            while(!__tmp184_last)
                            {
                                string __tmp184_line = __tmp184Reader.ReadLine();
                                __tmp184_last = __tmp184Reader.EndOfStream;
                                if ((__tmp184_last && !string.IsNullOrEmpty(__tmp184_line)) || (!__tmp184_last && __tmp184_line != null))
                                {
                                    __out.Append(__tmp184_line);
                                    __tmp180_outputWritten = true;
                                }
                                if (!__tmp184_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp185_line = "_"; //720:131
                        if (!string.IsNullOrEmpty(__tmp185_line))
                        {
                            __out.Append(__tmp185_line);
                            __tmp180_outputWritten = true;
                        }
                        StringBuilder __tmp186 = new StringBuilder();
                        __tmp186.Append(op.Name);
                        using(StreamReader __tmp186Reader = new StreamReader(this.__ToStream(__tmp186.ToString())))
                        {
                            bool __tmp186_last = __tmp186Reader.EndOfStream;
                            while(!__tmp186_last)
                            {
                                string __tmp186_line = __tmp186Reader.ReadLine();
                                __tmp186_last = __tmp186Reader.EndOfStream;
                                if ((__tmp186_last && !string.IsNullOrEmpty(__tmp186_line)) || (!__tmp186_last && __tmp186_line != null))
                                {
                                    __out.Append(__tmp186_line);
                                    __tmp180_outputWritten = true;
                                }
                                if (!__tmp186_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp187_line = "("; //720:141
                        if (!string.IsNullOrEmpty(__tmp187_line))
                        {
                            __out.Append(__tmp187_line);
                            __tmp180_outputWritten = true;
                        }
                        StringBuilder __tmp188 = new StringBuilder();
                        __tmp188.Append(GetImplParameters(model, cls, op, ClassKind.ImmutableOperation));
                        using(StreamReader __tmp188Reader = new StreamReader(this.__ToStream(__tmp188.ToString())))
                        {
                            bool __tmp188_last = __tmp188Reader.EndOfStream;
                            while(!__tmp188_last)
                            {
                                string __tmp188_line = __tmp188Reader.ReadLine();
                                __tmp188_last = __tmp188Reader.EndOfStream;
                                if ((__tmp188_last && !string.IsNullOrEmpty(__tmp188_line)) || (!__tmp188_last && __tmp188_line != null))
                                {
                                    __out.Append(__tmp188_line);
                                    __tmp180_outputWritten = true;
                                }
                                if (!__tmp188_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp189_line = ")"; //720:207
                        if (!string.IsNullOrEmpty(__tmp189_line))
                        {
                            __out.Append(__tmp189_line);
                            __tmp180_outputWritten = true;
                        }
                        if (__tmp180_outputWritten) __out.AppendLine(true);
                        if (__tmp180_outputWritten)
                        {
                            __out.AppendLine(false); //720:208
                        }
                        __out.Append("	{"); //721:1
                        __out.AppendLine(false); //721:3
                        bool __tmp191_outputWritten = false;
                        string __tmp190Prefix = "		"; //722:1
                        StringBuilder __tmp192 = new StringBuilder();
                        __tmp192.Append(GetReturn(model, op, ClassKind.ImmutableOperation));
                        using(StreamReader __tmp192Reader = new StreamReader(this.__ToStream(__tmp192.ToString())))
                        {
                            bool __tmp192_last = __tmp192Reader.EndOfStream;
                            while(!__tmp192_last)
                            {
                                string __tmp192_line = __tmp192Reader.ReadLine();
                                __tmp192_last = __tmp192Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp190Prefix))
                                {
                                    __out.Append(__tmp190Prefix);
                                    __tmp191_outputWritten = true;
                                }
                                if ((__tmp192_last && !string.IsNullOrEmpty(__tmp192_line)) || (!__tmp192_last && __tmp192_line != null))
                                {
                                    __out.Append(__tmp192_line);
                                    __tmp191_outputWritten = true;
                                }
                                if (!__tmp192_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp193_line = "this."; //722:55
                        if (!string.IsNullOrEmpty(__tmp193_line))
                        {
                            __out.Append(__tmp193_line);
                            __tmp191_outputWritten = true;
                        }
                        StringBuilder __tmp194 = new StringBuilder();
                        __tmp194.Append(CSharpName(op.Class, model, ClassKind.Immutable));
                        using(StreamReader __tmp194Reader = new StreamReader(this.__ToStream(__tmp194.ToString())))
                        {
                            bool __tmp194_last = __tmp194Reader.EndOfStream;
                            while(!__tmp194_last)
                            {
                                string __tmp194_line = __tmp194Reader.ReadLine();
                                __tmp194_last = __tmp194Reader.EndOfStream;
                                if ((__tmp194_last && !string.IsNullOrEmpty(__tmp194_line)) || (!__tmp194_last && __tmp194_line != null))
                                {
                                    __out.Append(__tmp194_line);
                                    __tmp191_outputWritten = true;
                                }
                                if (!__tmp194_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp195_line = "_"; //722:109
                        if (!string.IsNullOrEmpty(__tmp195_line))
                        {
                            __out.Append(__tmp195_line);
                            __tmp191_outputWritten = true;
                        }
                        StringBuilder __tmp196 = new StringBuilder();
                        __tmp196.Append(op.Name);
                        using(StreamReader __tmp196Reader = new StreamReader(this.__ToStream(__tmp196.ToString())))
                        {
                            bool __tmp196_last = __tmp196Reader.EndOfStream;
                            while(!__tmp196_last)
                            {
                                string __tmp196_line = __tmp196Reader.ReadLine();
                                __tmp196_last = __tmp196Reader.EndOfStream;
                                if ((__tmp196_last && !string.IsNullOrEmpty(__tmp196_line)) || (!__tmp196_last && __tmp196_line != null))
                                {
                                    __out.Append(__tmp196_line);
                                    __tmp191_outputWritten = true;
                                }
                                if (!__tmp196_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp197_line = "("; //722:119
                        if (!string.IsNullOrEmpty(__tmp197_line))
                        {
                            __out.Append(__tmp197_line);
                            __tmp191_outputWritten = true;
                        }
                        StringBuilder __tmp198 = new StringBuilder();
                        __tmp198.Append(GetImmBldCallParameterNames(model, op, ClassKind.BuilderOperation));
                        using(StreamReader __tmp198Reader = new StreamReader(this.__ToStream(__tmp198.ToString())))
                        {
                            bool __tmp198_last = __tmp198Reader.EndOfStream;
                            while(!__tmp198_last)
                            {
                                string __tmp198_line = __tmp198Reader.ReadLine();
                                __tmp198_last = __tmp198Reader.EndOfStream;
                                if ((__tmp198_last && !string.IsNullOrEmpty(__tmp198_line)) || (!__tmp198_last && __tmp198_line != null))
                                {
                                    __out.Append(__tmp198_line);
                                    __tmp191_outputWritten = true;
                                }
                                if (!__tmp198_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp199_line = ")"; //722:188
                        if (!string.IsNullOrEmpty(__tmp199_line))
                        {
                            __out.Append(__tmp199_line);
                            __tmp191_outputWritten = true;
                        }
                        StringBuilder __tmp200 = new StringBuilder();
                        __tmp200.Append(GetImmBldReturn(model, op, ClassKind.ImmutableOperation));
                        using(StreamReader __tmp200Reader = new StreamReader(this.__ToStream(__tmp200.ToString())))
                        {
                            bool __tmp200_last = __tmp200Reader.EndOfStream;
                            while(!__tmp200_last)
                            {
                                string __tmp200_line = __tmp200Reader.ReadLine();
                                __tmp200_last = __tmp200Reader.EndOfStream;
                                if ((__tmp200_last && !string.IsNullOrEmpty(__tmp200_line)) || (!__tmp200_last && __tmp200_line != null))
                                {
                                    __out.Append(__tmp200_line);
                                    __tmp191_outputWritten = true;
                                }
                                if (!__tmp200_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp201_line = ";"; //722:247
                        if (!string.IsNullOrEmpty(__tmp201_line))
                        {
                            __out.Append(__tmp201_line);
                            __tmp191_outputWritten = true;
                        }
                        if (__tmp191_outputWritten) __out.AppendLine(true);
                        if (__tmp191_outputWritten)
                        {
                            __out.AppendLine(false); //722:248
                        }
                        __out.Append("	}"); //723:1
                        __out.AppendLine(false); //723:3
                    }
                    __out.AppendLine(true); //725:2
                    __out.Append("	/// <summary>"); //726:1
                    __out.AppendLine(false); //726:15
                    bool __tmp203_outputWritten = false;
                    string __tmp204_line = "	/// Implements the operation: "; //727:1
                    if (!string.IsNullOrEmpty(__tmp204_line))
                    {
                        __out.Append(__tmp204_line);
                        __tmp203_outputWritten = true;
                    }
                    StringBuilder __tmp205 = new StringBuilder();
                    __tmp205.Append(CSharpName(cls, model, ClassKind.Builder));
                    using(StreamReader __tmp205Reader = new StreamReader(this.__ToStream(__tmp205.ToString())))
                    {
                        bool __tmp205_last = __tmp205Reader.EndOfStream;
                        while(!__tmp205_last)
                        {
                            string __tmp205_line = __tmp205Reader.ReadLine();
                            __tmp205_last = __tmp205Reader.EndOfStream;
                            if ((__tmp205_last && !string.IsNullOrEmpty(__tmp205_line)) || (!__tmp205_last && __tmp205_line != null))
                            {
                                __out.Append(__tmp205_line);
                                __tmp203_outputWritten = true;
                            }
                            if (!__tmp205_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp206_line = "."; //727:74
                    if (!string.IsNullOrEmpty(__tmp206_line))
                    {
                        __out.Append(__tmp206_line);
                        __tmp203_outputWritten = true;
                    }
                    StringBuilder __tmp207 = new StringBuilder();
                    __tmp207.Append(op.Name);
                    using(StreamReader __tmp207Reader = new StreamReader(this.__ToStream(__tmp207.ToString())))
                    {
                        bool __tmp207_last = __tmp207Reader.EndOfStream;
                        while(!__tmp207_last)
                        {
                            string __tmp207_line = __tmp207Reader.ReadLine();
                            __tmp207_last = __tmp207Reader.EndOfStream;
                            if ((__tmp207_last && !string.IsNullOrEmpty(__tmp207_line)) || (!__tmp207_last && __tmp207_line != null))
                            {
                                __out.Append(__tmp207_line);
                                __tmp203_outputWritten = true;
                            }
                            if (!__tmp207_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp208_line = "()"; //727:84
                    if (!string.IsNullOrEmpty(__tmp208_line))
                    {
                        __out.Append(__tmp208_line);
                        __tmp203_outputWritten = true;
                    }
                    if (__tmp203_outputWritten) __out.AppendLine(true);
                    if (__tmp203_outputWritten)
                    {
                        __out.AppendLine(false); //727:86
                    }
                    __out.Append("	/// </summary>"); //728:1
                    __out.AppendLine(false); //728:16
                    bool __tmp210_outputWritten = false;
                    string __tmp211_line = "	public abstract "; //729:1
                    if (!string.IsNullOrEmpty(__tmp211_line))
                    {
                        __out.Append(__tmp211_line);
                        __tmp210_outputWritten = true;
                    }
                    StringBuilder __tmp212 = new StringBuilder();
                    __tmp212.Append(CSharpName(op.ReturnType, model, ClassKind.BuilderOperation, true));
                    using(StreamReader __tmp212Reader = new StreamReader(this.__ToStream(__tmp212.ToString())))
                    {
                        bool __tmp212_last = __tmp212Reader.EndOfStream;
                        while(!__tmp212_last)
                        {
                            string __tmp212_line = __tmp212Reader.ReadLine();
                            __tmp212_last = __tmp212Reader.EndOfStream;
                            if ((__tmp212_last && !string.IsNullOrEmpty(__tmp212_line)) || (!__tmp212_last && __tmp212_line != null))
                            {
                                __out.Append(__tmp212_line);
                                __tmp210_outputWritten = true;
                            }
                            if (!__tmp212_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp213_line = " "; //729:85
                    if (!string.IsNullOrEmpty(__tmp213_line))
                    {
                        __out.Append(__tmp213_line);
                        __tmp210_outputWritten = true;
                    }
                    StringBuilder __tmp214 = new StringBuilder();
                    __tmp214.Append(CSharpName(cls, model, ClassKind.Immutable));
                    using(StreamReader __tmp214Reader = new StreamReader(this.__ToStream(__tmp214.ToString())))
                    {
                        bool __tmp214_last = __tmp214Reader.EndOfStream;
                        while(!__tmp214_last)
                        {
                            string __tmp214_line = __tmp214Reader.ReadLine();
                            __tmp214_last = __tmp214Reader.EndOfStream;
                            if ((__tmp214_last && !string.IsNullOrEmpty(__tmp214_line)) || (!__tmp214_last && __tmp214_line != null))
                            {
                                __out.Append(__tmp214_line);
                                __tmp210_outputWritten = true;
                            }
                            if (!__tmp214_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp215_line = "_"; //729:130
                    if (!string.IsNullOrEmpty(__tmp215_line))
                    {
                        __out.Append(__tmp215_line);
                        __tmp210_outputWritten = true;
                    }
                    StringBuilder __tmp216 = new StringBuilder();
                    __tmp216.Append(op.Name);
                    using(StreamReader __tmp216Reader = new StreamReader(this.__ToStream(__tmp216.ToString())))
                    {
                        bool __tmp216_last = __tmp216Reader.EndOfStream;
                        while(!__tmp216_last)
                        {
                            string __tmp216_line = __tmp216Reader.ReadLine();
                            __tmp216_last = __tmp216Reader.EndOfStream;
                            if ((__tmp216_last && !string.IsNullOrEmpty(__tmp216_line)) || (!__tmp216_last && __tmp216_line != null))
                            {
                                __out.Append(__tmp216_line);
                                __tmp210_outputWritten = true;
                            }
                            if (!__tmp216_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp217_line = "("; //729:140
                    if (!string.IsNullOrEmpty(__tmp217_line))
                    {
                        __out.Append(__tmp217_line);
                        __tmp210_outputWritten = true;
                    }
                    StringBuilder __tmp218 = new StringBuilder();
                    __tmp218.Append(GetImplParameters(model, cls, op, ClassKind.BuilderOperation));
                    using(StreamReader __tmp218Reader = new StreamReader(this.__ToStream(__tmp218.ToString())))
                    {
                        bool __tmp218_last = __tmp218Reader.EndOfStream;
                        while(!__tmp218_last)
                        {
                            string __tmp218_line = __tmp218Reader.ReadLine();
                            __tmp218_last = __tmp218Reader.EndOfStream;
                            if ((__tmp218_last && !string.IsNullOrEmpty(__tmp218_line)) || (!__tmp218_last && __tmp218_line != null))
                            {
                                __out.Append(__tmp218_line);
                                __tmp210_outputWritten = true;
                            }
                            if (!__tmp218_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp219_line = ");"; //729:204
                    if (!string.IsNullOrEmpty(__tmp219_line))
                    {
                        __out.Append(__tmp219_line);
                        __tmp210_outputWritten = true;
                    }
                    if (__tmp210_outputWritten) __out.AppendLine(true);
                    if (__tmp210_outputWritten)
                    {
                        __out.AppendLine(false); //729:206
                    }
                }
                __out.AppendLine(true); //731:2
            }
            var __loop44_results = 
                (from __loop44_var1 in __Enumerate((model).GetEnumerator()) //733:8
                from Namespace in __Enumerate((__loop44_var1.Namespace).GetEnumerator()) //733:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //733:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //733:40
                select new { __loop44_var1 = __loop44_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //733:3
            for (int __loop44_iteration = 0; __loop44_iteration < __loop44_results.Count; ++__loop44_iteration)
            {
                var __tmp220 = __loop44_results[__loop44_iteration];
                var __loop44_var1 = __tmp220.__loop44_var1;
                var Namespace = __tmp220.Namespace;
                var Declarations = __tmp220.Declarations;
                var enm = __tmp220.enm;
                var __loop45_results = 
                    (from __loop45_var1 in __Enumerate((enm).GetEnumerator()) //734:8
                    from op in __Enumerate((__loop45_var1.Operations).GetEnumerator()) //734:13
                    select new { __loop45_var1 = __loop45_var1, op = op}
                    ).ToList(); //734:3
                for (int __loop45_iteration = 0; __loop45_iteration < __loop45_results.Count; ++__loop45_iteration)
                {
                    var __tmp221 = __loop45_results[__loop45_iteration];
                    var __loop45_var1 = __tmp221.__loop45_var1;
                    var op = __tmp221.op;
                    __out.AppendLine(true); //735:2
                    __out.Append("	/// <summary>"); //736:1
                    __out.AppendLine(false); //736:15
                    bool __tmp223_outputWritten = false;
                    string __tmp224_line = "	/// Implements the operation: "; //737:1
                    if (!string.IsNullOrEmpty(__tmp224_line))
                    {
                        __out.Append(__tmp224_line);
                        __tmp223_outputWritten = true;
                    }
                    StringBuilder __tmp225 = new StringBuilder();
                    __tmp225.Append(CSharpName(enm, model, ClassKind.Immutable));
                    using(StreamReader __tmp225Reader = new StreamReader(this.__ToStream(__tmp225.ToString())))
                    {
                        bool __tmp225_last = __tmp225Reader.EndOfStream;
                        while(!__tmp225_last)
                        {
                            string __tmp225_line = __tmp225Reader.ReadLine();
                            __tmp225_last = __tmp225Reader.EndOfStream;
                            if ((__tmp225_last && !string.IsNullOrEmpty(__tmp225_line)) || (!__tmp225_last && __tmp225_line != null))
                            {
                                __out.Append(__tmp225_line);
                                __tmp223_outputWritten = true;
                            }
                            if (!__tmp225_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp226_line = "."; //737:76
                    if (!string.IsNullOrEmpty(__tmp226_line))
                    {
                        __out.Append(__tmp226_line);
                        __tmp223_outputWritten = true;
                    }
                    StringBuilder __tmp227 = new StringBuilder();
                    __tmp227.Append(op.Name);
                    using(StreamReader __tmp227Reader = new StreamReader(this.__ToStream(__tmp227.ToString())))
                    {
                        bool __tmp227_last = __tmp227Reader.EndOfStream;
                        while(!__tmp227_last)
                        {
                            string __tmp227_line = __tmp227Reader.ReadLine();
                            __tmp227_last = __tmp227Reader.EndOfStream;
                            if ((__tmp227_last && !string.IsNullOrEmpty(__tmp227_line)) || (!__tmp227_last && __tmp227_line != null))
                            {
                                __out.Append(__tmp227_line);
                                __tmp223_outputWritten = true;
                            }
                            if (!__tmp227_last || __tmp223_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp223_outputWritten)
                    {
                        __out.AppendLine(false); //737:86
                    }
                    __out.Append("	/// </summary>"); //738:1
                    __out.AppendLine(false); //738:16
                    bool __tmp229_outputWritten = false;
                    string __tmp230_line = "	public abstract "; //739:1
                    if (!string.IsNullOrEmpty(__tmp230_line))
                    {
                        __out.Append(__tmp230_line);
                        __tmp229_outputWritten = true;
                    }
                    StringBuilder __tmp231 = new StringBuilder();
                    __tmp231.Append(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation, true));
                    using(StreamReader __tmp231Reader = new StreamReader(this.__ToStream(__tmp231.ToString())))
                    {
                        bool __tmp231_last = __tmp231Reader.EndOfStream;
                        while(!__tmp231_last)
                        {
                            string __tmp231_line = __tmp231Reader.ReadLine();
                            __tmp231_last = __tmp231Reader.EndOfStream;
                            if ((__tmp231_last && !string.IsNullOrEmpty(__tmp231_line)) || (!__tmp231_last && __tmp231_line != null))
                            {
                                __out.Append(__tmp231_line);
                                __tmp229_outputWritten = true;
                            }
                            if (!__tmp231_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp232_line = " "; //739:87
                    if (!string.IsNullOrEmpty(__tmp232_line))
                    {
                        __out.Append(__tmp232_line);
                        __tmp229_outputWritten = true;
                    }
                    StringBuilder __tmp233 = new StringBuilder();
                    __tmp233.Append(CSharpName(enm, model, ClassKind.Immutable));
                    using(StreamReader __tmp233Reader = new StreamReader(this.__ToStream(__tmp233.ToString())))
                    {
                        bool __tmp233_last = __tmp233Reader.EndOfStream;
                        while(!__tmp233_last)
                        {
                            string __tmp233_line = __tmp233Reader.ReadLine();
                            __tmp233_last = __tmp233Reader.EndOfStream;
                            if ((__tmp233_last && !string.IsNullOrEmpty(__tmp233_line)) || (!__tmp233_last && __tmp233_line != null))
                            {
                                __out.Append(__tmp233_line);
                                __tmp229_outputWritten = true;
                            }
                            if (!__tmp233_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp234_line = "_"; //739:132
                    if (!string.IsNullOrEmpty(__tmp234_line))
                    {
                        __out.Append(__tmp234_line);
                        __tmp229_outputWritten = true;
                    }
                    StringBuilder __tmp235 = new StringBuilder();
                    __tmp235.Append(op.Name);
                    using(StreamReader __tmp235Reader = new StreamReader(this.__ToStream(__tmp235.ToString())))
                    {
                        bool __tmp235_last = __tmp235Reader.EndOfStream;
                        while(!__tmp235_last)
                        {
                            string __tmp235_line = __tmp235Reader.ReadLine();
                            __tmp235_last = __tmp235Reader.EndOfStream;
                            if ((__tmp235_last && !string.IsNullOrEmpty(__tmp235_line)) || (!__tmp235_last && __tmp235_line != null))
                            {
                                __out.Append(__tmp235_line);
                                __tmp229_outputWritten = true;
                            }
                            if (!__tmp235_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp236_line = "("; //739:142
                    if (!string.IsNullOrEmpty(__tmp236_line))
                    {
                        __out.Append(__tmp236_line);
                        __tmp229_outputWritten = true;
                    }
                    StringBuilder __tmp237 = new StringBuilder();
                    __tmp237.Append(GetImplParameters(model, enm, op, ClassKind.ImmutableOperation));
                    using(StreamReader __tmp237Reader = new StreamReader(this.__ToStream(__tmp237.ToString())))
                    {
                        bool __tmp237_last = __tmp237Reader.EndOfStream;
                        while(!__tmp237_last)
                        {
                            string __tmp237_line = __tmp237Reader.ReadLine();
                            __tmp237_last = __tmp237Reader.EndOfStream;
                            if ((__tmp237_last && !string.IsNullOrEmpty(__tmp237_line)) || (!__tmp237_last && __tmp237_line != null))
                            {
                                __out.Append(__tmp237_line);
                                __tmp229_outputWritten = true;
                            }
                            if (!__tmp237_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp238_line = ");"; //739:208
                    if (!string.IsNullOrEmpty(__tmp238_line))
                    {
                        __out.Append(__tmp238_line);
                        __tmp229_outputWritten = true;
                    }
                    if (__tmp229_outputWritten) __out.AppendLine(true);
                    if (__tmp229_outputWritten)
                    {
                        __out.AppendLine(false); //739:210
                    }
                }
                __out.AppendLine(true); //741:2
            }
            __out.Append("}"); //743:1
            __out.AppendLine(false); //743:2
            return __out.ToString();
        }

        public string GetImplParameters(MetaModel model, MetaClass cls, MetaOperation op, ClassKind kind) //746:1
        {
            string result = CSharpName(cls, model, kind) + " _this"; //747:2
            string delim = ", "; //748:2
            var __loop46_results = 
                (from __loop46_var1 in __Enumerate((op).GetEnumerator()) //749:7
                from param in __Enumerate((__loop46_var1.Parameters).GetEnumerator()) //749:11
                select new { __loop46_var1 = __loop46_var1, param = param}
                ).ToList(); //749:2
            for (int __loop46_iteration = 0; __loop46_iteration < __loop46_results.Count; ++__loop46_iteration)
            {
                var __tmp1 = __loop46_results[__loop46_iteration];
                var __loop46_var1 = __tmp1.__loop46_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, kind, true) + " " + param.Name; //750:3
            }
            return result; //752:2
        }

        public string GetImplParameters(MetaModel model, MetaEnum enm, MetaOperation op, ClassKind kind) //755:1
        {
            string result = CSharpName(enm, model, kind) + " _this"; //756:2
            string delim = ", "; //757:2
            var __loop47_results = 
                (from __loop47_var1 in __Enumerate((op).GetEnumerator()) //758:7
                from param in __Enumerate((__loop47_var1.Parameters).GetEnumerator()) //758:11
                select new { __loop47_var1 = __loop47_var1, param = param}
                ).ToList(); //758:2
            for (int __loop47_iteration = 0; __loop47_iteration < __loop47_results.Count; ++__loop47_iteration)
            {
                var __tmp1 = __loop47_results[__loop47_iteration];
                var __loop47_var1 = __tmp1.__loop47_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, kind, true) + " " + param.Name; //759:3
            }
            return result; //761:2
        }

        public string GenerateEnum(MetaModel model, MetaEnum enm) //765:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //766:1
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(enm));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3_line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                    {
                        __out.Append(__tmp3_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp3_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //767:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public enum "; //768:1
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Append(__tmp6_line);
                __tmp5_outputWritten = true;
            }
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(CSharpName(enm, model));
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(!__tmp7_last)
                {
                    string __tmp7_line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if ((__tmp7_last && !string.IsNullOrEmpty(__tmp7_line)) || (!__tmp7_last && __tmp7_line != null))
                    {
                        __out.Append(__tmp7_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp7_last || __tmp5_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //768:36
            }
            __out.Append("{"); //769:1
            __out.AppendLine(false); //769:2
            var __loop48_results = 
                (from __loop48_var1 in __Enumerate((enm).GetEnumerator()) //770:8
                from value in __Enumerate((__loop48_var1.EnumLiterals).GetEnumerator()) //770:13
                select new { __loop48_var1 = __loop48_var1, value = value}
                ).ToList(); //770:3
            for (int __loop48_iteration = 0; __loop48_iteration < __loop48_results.Count; ++__loop48_iteration)
            {
                string delim; //770:31
                if (__loop48_iteration+1 < __loop48_results.Count) delim = ",";
                else delim = string.Empty;
                var __tmp8 = __loop48_results[__loop48_iteration];
                var __loop48_var1 = __tmp8.__loop48_var1;
                var value = __tmp8.value;
                bool __tmp10_outputWritten = false;
                string __tmp9Prefix = "	"; //771:1
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(GenerateDocumentation(value));
                using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
                {
                    bool __tmp11_last = __tmp11Reader.EndOfStream;
                    while(!__tmp11_last)
                    {
                        string __tmp11_line = __tmp11Reader.ReadLine();
                        __tmp11_last = __tmp11Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp9Prefix))
                        {
                            __out.Append(__tmp9Prefix);
                            __tmp10_outputWritten = true;
                        }
                        if ((__tmp11_last && !string.IsNullOrEmpty(__tmp11_line)) || (!__tmp11_last && __tmp11_line != null))
                        {
                            __out.Append(__tmp11_line);
                            __tmp10_outputWritten = true;
                        }
                        if (!__tmp11_last || __tmp10_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp10_outputWritten)
                {
                    __out.AppendLine(false); //771:32
                }
                bool __tmp13_outputWritten = false;
                string __tmp12Prefix = "	"; //772:1
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(value.Name);
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_last = __tmp14Reader.EndOfStream;
                    while(!__tmp14_last)
                    {
                        string __tmp14_line = __tmp14Reader.ReadLine();
                        __tmp14_last = __tmp14Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp12Prefix))
                        {
                            __out.Append(__tmp12Prefix);
                            __tmp13_outputWritten = true;
                        }
                        if ((__tmp14_last && !string.IsNullOrEmpty(__tmp14_line)) || (!__tmp14_last && __tmp14_line != null))
                        {
                            __out.Append(__tmp14_line);
                            __tmp13_outputWritten = true;
                        }
                        if (!__tmp14_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(delim);
                using(StreamReader __tmp15Reader = new StreamReader(this.__ToStream(__tmp15.ToString())))
                {
                    bool __tmp15_last = __tmp15Reader.EndOfStream;
                    while(!__tmp15_last)
                    {
                        string __tmp15_line = __tmp15Reader.ReadLine();
                        __tmp15_last = __tmp15Reader.EndOfStream;
                        if ((__tmp15_last && !string.IsNullOrEmpty(__tmp15_line)) || (!__tmp15_last && __tmp15_line != null))
                        {
                            __out.Append(__tmp15_line);
                            __tmp13_outputWritten = true;
                        }
                        if (!__tmp15_last || __tmp13_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //772:21
                }
            }
            __out.Append("}"); //774:1
            __out.AppendLine(false); //774:2
            __out.AppendLine(true); //775:1
            bool __tmp17_outputWritten = false;
            string __tmp18_line = "public static class "; //776:1
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Append(__tmp18_line);
                __tmp17_outputWritten = true;
            }
            StringBuilder __tmp19 = new StringBuilder();
            __tmp19.Append(enm.Name);
            using(StreamReader __tmp19Reader = new StreamReader(this.__ToStream(__tmp19.ToString())))
            {
                bool __tmp19_last = __tmp19Reader.EndOfStream;
                while(!__tmp19_last)
                {
                    string __tmp19_line = __tmp19Reader.ReadLine();
                    __tmp19_last = __tmp19Reader.EndOfStream;
                    if ((__tmp19_last && !string.IsNullOrEmpty(__tmp19_line)) || (!__tmp19_last && __tmp19_line != null))
                    {
                        __out.Append(__tmp19_line);
                        __tmp17_outputWritten = true;
                    }
                    if (!__tmp19_last) __out.AppendLine(true);
                }
            }
            string __tmp20_line = "Extensions"; //776:31
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp17_outputWritten = true;
            }
            if (__tmp17_outputWritten) __out.AppendLine(true);
            if (__tmp17_outputWritten)
            {
                __out.AppendLine(false); //776:41
            }
            __out.Append("{"); //777:1
            __out.AppendLine(false); //777:2
            var __loop49_results = 
                (from __loop49_var1 in __Enumerate((enm).GetEnumerator()) //778:8
                from op in __Enumerate((__loop49_var1.Operations).GetEnumerator()) //778:13
                select new { __loop49_var1 = __loop49_var1, op = op}
                ).ToList(); //778:3
            for (int __loop49_iteration = 0; __loop49_iteration < __loop49_results.Count; ++__loop49_iteration)
            {
                var __tmp21 = __loop49_results[__loop49_iteration];
                var __loop49_var1 = __tmp21.__loop49_var1;
                var op = __tmp21.op;
                bool __tmp23_outputWritten = false;
                string __tmp24_line = "	public static "; //779:1
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Append(__tmp24_line);
                    __tmp23_outputWritten = true;
                }
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation));
                using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
                {
                    bool __tmp25_last = __tmp25Reader.EndOfStream;
                    while(!__tmp25_last)
                    {
                        string __tmp25_line = __tmp25Reader.ReadLine();
                        __tmp25_last = __tmp25Reader.EndOfStream;
                        if ((__tmp25_last && !string.IsNullOrEmpty(__tmp25_line)) || (!__tmp25_last && __tmp25_line != null))
                        {
                            __out.Append(__tmp25_line);
                            __tmp23_outputWritten = true;
                        }
                        if (!__tmp25_last) __out.AppendLine(true);
                    }
                }
                string __tmp26_line = " "; //779:79
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Append(__tmp26_line);
                    __tmp23_outputWritten = true;
                }
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(op.Name);
                using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
                {
                    bool __tmp27_last = __tmp27Reader.EndOfStream;
                    while(!__tmp27_last)
                    {
                        string __tmp27_line = __tmp27Reader.ReadLine();
                        __tmp27_last = __tmp27Reader.EndOfStream;
                        if ((__tmp27_last && !string.IsNullOrEmpty(__tmp27_line)) || (!__tmp27_last && __tmp27_line != null))
                        {
                            __out.Append(__tmp27_line);
                            __tmp23_outputWritten = true;
                        }
                        if (!__tmp27_last) __out.AppendLine(true);
                    }
                }
                string __tmp28_line = "("; //779:89
                if (!string.IsNullOrEmpty(__tmp28_line))
                {
                    __out.Append(__tmp28_line);
                    __tmp23_outputWritten = true;
                }
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(GetEnumImplParameters(model, enm, op, ClassKind.ImmutableOperation));
                using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                {
                    bool __tmp29_last = __tmp29Reader.EndOfStream;
                    while(!__tmp29_last)
                    {
                        string __tmp29_line = __tmp29Reader.ReadLine();
                        __tmp29_last = __tmp29Reader.EndOfStream;
                        if ((__tmp29_last && !string.IsNullOrEmpty(__tmp29_line)) || (!__tmp29_last && __tmp29_line != null))
                        {
                            __out.Append(__tmp29_line);
                            __tmp23_outputWritten = true;
                        }
                        if (!__tmp29_last) __out.AppendLine(true);
                    }
                }
                string __tmp30_line = ")"; //779:159
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Append(__tmp30_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //779:160
                }
                __out.Append("	{"); //780:1
                __out.AppendLine(false); //780:3
                bool __tmp32_outputWritten = false;
                string __tmp31Prefix = "		"; //781:1
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(GetReturn(model, op, ClassKind.ImmutableOperation));
                using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
                {
                    bool __tmp33_last = __tmp33Reader.EndOfStream;
                    while(!__tmp33_last)
                    {
                        string __tmp33_line = __tmp33Reader.ReadLine();
                        __tmp33_last = __tmp33Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp31Prefix))
                        {
                            __out.Append(__tmp31Prefix);
                            __tmp32_outputWritten = true;
                        }
                        if ((__tmp33_last && !string.IsNullOrEmpty(__tmp33_line)) || (!__tmp33_last && __tmp33_line != null))
                        {
                            __out.Append(__tmp33_line);
                            __tmp32_outputWritten = true;
                        }
                        if (!__tmp33_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp34 = new StringBuilder();
                __tmp34.Append(CSharpName(model, ModelKind.ImplementationProvider));
                using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                {
                    bool __tmp34_last = __tmp34Reader.EndOfStream;
                    while(!__tmp34_last)
                    {
                        string __tmp34_line = __tmp34Reader.ReadLine();
                        __tmp34_last = __tmp34Reader.EndOfStream;
                        if ((__tmp34_last && !string.IsNullOrEmpty(__tmp34_line)) || (!__tmp34_last && __tmp34_line != null))
                        {
                            __out.Append(__tmp34_line);
                            __tmp32_outputWritten = true;
                        }
                        if (!__tmp34_last) __out.AppendLine(true);
                    }
                }
                string __tmp35_line = ".Implementation."; //781:107
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Append(__tmp35_line);
                    __tmp32_outputWritten = true;
                }
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(CSharpName(op.Enum, model, ClassKind.Immutable));
                using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                {
                    bool __tmp36_last = __tmp36Reader.EndOfStream;
                    while(!__tmp36_last)
                    {
                        string __tmp36_line = __tmp36Reader.ReadLine();
                        __tmp36_last = __tmp36Reader.EndOfStream;
                        if ((__tmp36_last && !string.IsNullOrEmpty(__tmp36_line)) || (!__tmp36_last && __tmp36_line != null))
                        {
                            __out.Append(__tmp36_line);
                            __tmp32_outputWritten = true;
                        }
                        if (!__tmp36_last) __out.AppendLine(true);
                    }
                }
                string __tmp37_line = "_"; //781:171
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp32_outputWritten = true;
                }
                StringBuilder __tmp38 = new StringBuilder();
                __tmp38.Append(op.Name);
                using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                {
                    bool __tmp38_last = __tmp38Reader.EndOfStream;
                    while(!__tmp38_last)
                    {
                        string __tmp38_line = __tmp38Reader.ReadLine();
                        __tmp38_last = __tmp38Reader.EndOfStream;
                        if ((__tmp38_last && !string.IsNullOrEmpty(__tmp38_line)) || (!__tmp38_last && __tmp38_line != null))
                        {
                            __out.Append(__tmp38_line);
                            __tmp32_outputWritten = true;
                        }
                        if (!__tmp38_last) __out.AppendLine(true);
                    }
                }
                string __tmp39_line = "("; //781:181
                if (!string.IsNullOrEmpty(__tmp39_line))
                {
                    __out.Append(__tmp39_line);
                    __tmp32_outputWritten = true;
                }
                StringBuilder __tmp40 = new StringBuilder();
                __tmp40.Append(GetEnumImplCallParameterNames(model, op, ClassKind.ImmutableOperation));
                using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                {
                    bool __tmp40_last = __tmp40Reader.EndOfStream;
                    while(!__tmp40_last)
                    {
                        string __tmp40_line = __tmp40Reader.ReadLine();
                        __tmp40_last = __tmp40Reader.EndOfStream;
                        if ((__tmp40_last && !string.IsNullOrEmpty(__tmp40_line)) || (!__tmp40_last && __tmp40_line != null))
                        {
                            __out.Append(__tmp40_line);
                            __tmp32_outputWritten = true;
                        }
                        if (!__tmp40_last) __out.AppendLine(true);
                    }
                }
                string __tmp41_line = ");"; //781:254
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Append(__tmp41_line);
                    __tmp32_outputWritten = true;
                }
                if (__tmp32_outputWritten) __out.AppendLine(true);
                if (__tmp32_outputWritten)
                {
                    __out.AppendLine(false); //781:256
                }
                __out.Append("	}"); //782:1
                __out.AppendLine(false); //782:3
            }
            __out.Append("}"); //784:1
            __out.AppendLine(false); //784:2
            return __out.ToString();
        }

        public string GetEnumImplParameters(MetaModel model, MetaEnum enm, MetaOperation op, ClassKind kind) //787:1
        {
            string result = "this " + CSharpName(enm, model, kind) + " _this"; //788:2
            string delim = ", "; //789:2
            var __loop50_results = 
                (from __loop50_var1 in __Enumerate((op).GetEnumerator()) //790:7
                from param in __Enumerate((__loop50_var1.Parameters).GetEnumerator()) //790:11
                select new { __loop50_var1 = __loop50_var1, param = param}
                ).ToList(); //790:2
            for (int __loop50_iteration = 0; __loop50_iteration < __loop50_results.Count; ++__loop50_iteration)
            {
                var __tmp1 = __loop50_results[__loop50_iteration];
                var __loop50_var1 = __tmp1.__loop50_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, kind) + " " + param.Name; //791:3
            }
            return result; //793:2
        }

        public string GetEnumImplCallParameterNames(MetaModel model, MetaOperation op, ClassKind kind) //796:1
        {
            string result = "_this"; //797:2
            string delim = ", "; //798:2
            var __loop51_results = 
                (from __loop51_var1 in __Enumerate((op).GetEnumerator()) //799:7
                from param in __Enumerate((__loop51_var1.Parameters).GetEnumerator()) //799:11
                select new { __loop51_var1 = __loop51_var1, param = param}
                ).ToList(); //799:2
            for (int __loop51_iteration = 0; __loop51_iteration < __loop51_results.Count; ++__loop51_iteration)
            {
                var __tmp1 = __loop51_results[__loop51_iteration];
                var __loop51_var1 = __tmp1.__loop51_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //800:3
            }
            return result; //802:2
        }

        public string GetClassParameters(MetaModel model, MetaClass cls, MetaOperation op, ClassKind kind) //805:1
        {
            string result = ""; //806:2
            var __loop52_results = 
                (from __loop52_var1 in __Enumerate((op).GetEnumerator()) //807:7
                from param in __Enumerate((__loop52_var1.Parameters).GetEnumerator()) //807:11
                select new { __loop52_var1 = __loop52_var1, param = param}
                ).ToList(); //807:2
            for (int __loop52_iteration = 0; __loop52_iteration < __loop52_results.Count; ++__loop52_iteration)
            {
                string delim; //807:27
                if (__loop52_iteration+1 < __loop52_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop52_results[__loop52_iteration];
                var __loop52_var1 = __tmp1.__loop52_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, kind, true) + " " + param.Name + delim; //808:3
            }
            return result; //810:2
        }

        public string GetClassImplCallParameterNames(MetaModel model, MetaOperation op, ClassKind kind) //813:1
        {
            string result = "this"; //814:2
            string delim = ", "; //815:2
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((op).GetEnumerator()) //816:7
                from param in __Enumerate((__loop53_var1.Parameters).GetEnumerator()) //816:11
                select new { __loop53_var1 = __loop53_var1, param = param}
                ).ToList(); //816:2
            for (int __loop53_iteration = 0; __loop53_iteration < __loop53_results.Count; ++__loop53_iteration)
            {
                var __tmp1 = __loop53_results[__loop53_iteration];
                var __loop53_var1 = __tmp1.__loop53_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //817:3
            }
            return result; //819:2
        }

        public string GetReturn(MetaModel model, MetaOperation op, ClassKind kind) //822:1
        {
            if (CSharpName(op.ReturnType, model, ClassKind.Immutable) == "void") //823:5
            {
                return ""; //824:3
            }
            else //825:2
            {
                return "return "; //826:3
            }
        }

        public string GenerateClass(MetaModel model, MetaClass cls) //830:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //831:1
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateImmutableClass(model, cls));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3_line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                    {
                        __out.Append(__tmp3_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp3_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //832:37
            }
            __out.AppendLine(true); //833:1
            bool __tmp5_outputWritten = false;
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GenerateBuilderClass(model, cls));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                    {
                        __out.Append(__tmp6_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp6_last || __tmp5_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //834:35
            }
            return __out.ToString();
        }

        public string GenerateClassInternal(MetaModel model, MetaClass cls) //837:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //838:1
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateIdClass(model, cls));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3_line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                    {
                        __out.Append(__tmp3_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp3_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //839:30
            }
            __out.AppendLine(true); //840:1
            bool __tmp5_outputWritten = false;
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GenerateImmutableImplClass(model, cls));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                    {
                        __out.Append(__tmp6_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp6_last || __tmp5_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //841:41
            }
            __out.AppendLine(true); //842:1
            bool __tmp8_outputWritten = false;
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(GenerateBuilderImplClass(model, cls));
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9_line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if ((__tmp9_last && !string.IsNullOrEmpty(__tmp9_line)) || (!__tmp9_last && __tmp9_line != null))
                    {
                        __out.Append(__tmp9_line);
                        __tmp8_outputWritten = true;
                    }
                    if (!__tmp9_last || __tmp8_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp8_outputWritten)
            {
                __out.AppendLine(false); //843:39
            }
            return __out.ToString();
        }

        public string GenerateIdClass(MetaModel model, MetaClass cls) //846:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //847:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(CSharpName(cls, model, ClassKind.Id));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5_line = " : "; //847:53
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Append(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(Properties.CoreNs);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7_line = ".ObjectId"; //847:75
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //847:84
            }
            __out.Append("{"); //848:1
            __out.AppendLine(false); //848:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public override "; //849:1
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp9_outputWritten = true;
            }
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(Properties.CoreNs);
            using(StreamReader __tmp11Reader = new StreamReader(this.__ToStream(__tmp11.ToString())))
            {
                bool __tmp11_last = __tmp11Reader.EndOfStream;
                while(!__tmp11_last)
                {
                    string __tmp11_line = __tmp11Reader.ReadLine();
                    __tmp11_last = __tmp11Reader.EndOfStream;
                    if ((__tmp11_last && !string.IsNullOrEmpty(__tmp11_line)) || (!__tmp11_last && __tmp11_line != null))
                    {
                        __out.Append(__tmp11_line);
                        __tmp9_outputWritten = true;
                    }
                    if (!__tmp11_last) __out.AppendLine(true);
                }
            }
            string __tmp12_line = ".ModelObjectDescriptor Descriptor { get { return "; //849:37
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Append(__tmp12_line);
                __tmp9_outputWritten = true;
            }
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(CSharpName(cls, null, ClassKind.Descriptor, true));
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13_line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if ((__tmp13_last && !string.IsNullOrEmpty(__tmp13_line)) || (!__tmp13_last && __tmp13_line != null))
                    {
                        __out.Append(__tmp13_line);
                        __tmp9_outputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14_line = ".MDescriptor; } }"; //849:136
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //849:153
            }
            __out.AppendLine(true); //850:1
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	public override "; //851:1
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp16_outputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(Properties.CoreNs);
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    string __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                    {
                        __out.Append(__tmp18_line);
                        __tmp16_outputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19_line = ".ImmutableObjectBase CreateImmutable("; //851:37
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(Properties.CoreNs);
            using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
            {
                bool __tmp20_last = __tmp20Reader.EndOfStream;
                while(!__tmp20_last)
                {
                    string __tmp20_line = __tmp20Reader.ReadLine();
                    __tmp20_last = __tmp20Reader.EndOfStream;
                    if ((__tmp20_last && !string.IsNullOrEmpty(__tmp20_line)) || (!__tmp20_last && __tmp20_line != null))
                    {
                        __out.Append(__tmp20_line);
                        __tmp16_outputWritten = true;
                    }
                    if (!__tmp20_last) __out.AppendLine(true);
                }
            }
            string __tmp21_line = ".ImmutableModel model)"; //851:93
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //851:115
            }
            __out.Append("	{"); //852:1
            __out.AppendLine(false); //852:3
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "		return new "; //853:1
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp23_outputWritten = true;
            }
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(CSharpName(cls, model, ClassKind.ImmutableImpl));
            using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
            {
                bool __tmp25_last = __tmp25Reader.EndOfStream;
                while(!__tmp25_last)
                {
                    string __tmp25_line = __tmp25Reader.ReadLine();
                    __tmp25_last = __tmp25Reader.EndOfStream;
                    if ((__tmp25_last && !string.IsNullOrEmpty(__tmp25_line)) || (!__tmp25_last && __tmp25_line != null))
                    {
                        __out.Append(__tmp25_line);
                        __tmp23_outputWritten = true;
                    }
                    if (!__tmp25_last) __out.AppendLine(true);
                }
            }
            string __tmp26_line = "(this, model);"; //853:62
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //853:76
            }
            __out.Append("	}"); //854:1
            __out.AppendLine(false); //854:3
            __out.AppendLine(true); //855:1
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "	public override "; //856:1
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Append(__tmp29_line);
                __tmp28_outputWritten = true;
            }
            StringBuilder __tmp30 = new StringBuilder();
            __tmp30.Append(Properties.CoreNs);
            using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
            {
                bool __tmp30_last = __tmp30Reader.EndOfStream;
                while(!__tmp30_last)
                {
                    string __tmp30_line = __tmp30Reader.ReadLine();
                    __tmp30_last = __tmp30Reader.EndOfStream;
                    if ((__tmp30_last && !string.IsNullOrEmpty(__tmp30_line)) || (!__tmp30_last && __tmp30_line != null))
                    {
                        __out.Append(__tmp30_line);
                        __tmp28_outputWritten = true;
                    }
                    if (!__tmp30_last) __out.AppendLine(true);
                }
            }
            string __tmp31_line = ".MutableObjectBase CreateMutable("; //856:37
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Append(__tmp31_line);
                __tmp28_outputWritten = true;
            }
            StringBuilder __tmp32 = new StringBuilder();
            __tmp32.Append(Properties.CoreNs);
            using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
            {
                bool __tmp32_last = __tmp32Reader.EndOfStream;
                while(!__tmp32_last)
                {
                    string __tmp32_line = __tmp32Reader.ReadLine();
                    __tmp32_last = __tmp32Reader.EndOfStream;
                    if ((__tmp32_last && !string.IsNullOrEmpty(__tmp32_line)) || (!__tmp32_last && __tmp32_line != null))
                    {
                        __out.Append(__tmp32_line);
                        __tmp28_outputWritten = true;
                    }
                    if (!__tmp32_last) __out.AppendLine(true);
                }
            }
            string __tmp33_line = ".MutableModel model, bool creating)"; //856:89
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Append(__tmp33_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //856:124
            }
            __out.Append("	{"); //857:1
            __out.AppendLine(false); //857:3
            bool __tmp35_outputWritten = false;
            string __tmp36_line = "		return new "; //858:1
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Append(__tmp36_line);
                __tmp35_outputWritten = true;
            }
            StringBuilder __tmp37 = new StringBuilder();
            __tmp37.Append(CSharpName(cls, model, ClassKind.BuilderImpl));
            using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
            {
                bool __tmp37_last = __tmp37Reader.EndOfStream;
                while(!__tmp37_last)
                {
                    string __tmp37_line = __tmp37Reader.ReadLine();
                    __tmp37_last = __tmp37Reader.EndOfStream;
                    if ((__tmp37_last && !string.IsNullOrEmpty(__tmp37_line)) || (!__tmp37_last && __tmp37_line != null))
                    {
                        __out.Append(__tmp37_line);
                        __tmp35_outputWritten = true;
                    }
                    if (!__tmp37_last) __out.AppendLine(true);
                }
            }
            string __tmp38_line = "(this, model, creating);"; //858:60
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Append(__tmp38_line);
                __tmp35_outputWritten = true;
            }
            if (__tmp35_outputWritten) __out.AppendLine(true);
            if (__tmp35_outputWritten)
            {
                __out.AppendLine(false); //858:84
            }
            __out.Append("	}"); //859:1
            __out.AppendLine(false); //859:3
            __out.Append("}"); //860:1
            __out.AppendLine(false); //860:2
            return __out.ToString();
        }

        public string GenerateImmutableClass(MetaModel model, MetaClass cls) //863:1
        {
            StringBuilder __out = new StringBuilder();
            bool metaMetaModel = IsMetaMetaModel(model); //864:2
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(cls));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3_line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                    {
                        __out.Append(__tmp3_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp3_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //865:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //866:1
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Append(__tmp6_line);
                __tmp5_outputWritten = true;
            }
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(CSharpName(cls, model, ClassKind.Immutable));
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(!__tmp7_last)
                {
                    string __tmp7_line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if ((__tmp7_last && !string.IsNullOrEmpty(__tmp7_line)) || (!__tmp7_last && __tmp7_line != null))
                    {
                        __out.Append(__tmp7_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(GetImmutableAncestors(model, cls));
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(metaMetaModel && cls.Name == "MetaModel" ? ", " + Properties.CoreNs + ".IMetaModel" : "");
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9_line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if ((__tmp9_last && !string.IsNullOrEmpty(__tmp9_line)) || (!__tmp9_last && __tmp9_line != null))
                    {
                        __out.Append(__tmp9_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp9_last || __tmp5_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //866:183
            }
            __out.Append("{"); //867:1
            __out.AppendLine(false); //867:2
            if (metaMetaModel && cls.Name == "MetaModel") //868:3
            {
                __out.Append("	/// <summary>"); //869:1
                __out.AppendLine(false); //869:15
                __out.Append("	/// The name of the metamodel."); //870:1
                __out.AppendLine(false); //870:32
                __out.Append("	/// </summary>"); //871:1
                __out.AppendLine(false); //871:16
                __out.Append("	new string Name { get; }"); //872:1
                __out.AppendLine(false); //872:26
            }
            var __loop54_results = 
                (from __loop54_var1 in __Enumerate((cls).GetEnumerator()) //874:8
                from prop in __Enumerate((__loop54_var1.Properties).GetEnumerator()) //874:13
                select new { __loop54_var1 = __loop54_var1, prop = prop}
                ).ToList(); //874:3
            for (int __loop54_iteration = 0; __loop54_iteration < __loop54_results.Count; ++__loop54_iteration)
            {
                var __tmp10 = __loop54_results[__loop54_iteration];
                var __loop54_var1 = __tmp10.__loop54_var1;
                var prop = __tmp10.prop;
                bool __tmp12_outputWritten = false;
                string __tmp11Prefix = "	"; //875:1
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(GenerateImmutableProperty(model, prop));
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_last = __tmp13Reader.EndOfStream;
                    while(!__tmp13_last)
                    {
                        string __tmp13_line = __tmp13Reader.ReadLine();
                        __tmp13_last = __tmp13Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp11Prefix))
                        {
                            __out.Append(__tmp11Prefix);
                            __tmp12_outputWritten = true;
                        }
                        if ((__tmp13_last && !string.IsNullOrEmpty(__tmp13_line)) || (!__tmp13_last && __tmp13_line != null))
                        {
                            __out.Append(__tmp13_line);
                            __tmp12_outputWritten = true;
                        }
                        if (!__tmp13_last || __tmp12_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp12_outputWritten)
                {
                    __out.AppendLine(false); //875:42
                }
            }
            __out.AppendLine(true); //877:1
            var __loop55_results = 
                (from __loop55_var1 in __Enumerate((cls).GetEnumerator()) //878:8
                from op in __Enumerate((__loop55_var1.Operations).GetEnumerator()) //878:13
                where !op.IsBuilder //878:27
                select new { __loop55_var1 = __loop55_var1, op = op}
                ).ToList(); //878:3
            for (int __loop55_iteration = 0; __loop55_iteration < __loop55_results.Count; ++__loop55_iteration)
            {
                var __tmp14 = __loop55_results[__loop55_iteration];
                var __loop55_var1 = __tmp14.__loop55_var1;
                var op = __tmp14.op;
                bool __tmp16_outputWritten = false;
                string __tmp15Prefix = "	"; //879:1
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GenerateImmutableOperation(model, op));
                using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                {
                    bool __tmp17_last = __tmp17Reader.EndOfStream;
                    while(!__tmp17_last)
                    {
                        string __tmp17_line = __tmp17Reader.ReadLine();
                        __tmp17_last = __tmp17Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp15Prefix))
                        {
                            __out.Append(__tmp15Prefix);
                            __tmp16_outputWritten = true;
                        }
                        if ((__tmp17_last && !string.IsNullOrEmpty(__tmp17_line)) || (!__tmp17_last && __tmp17_line != null))
                        {
                            __out.Append(__tmp17_line);
                            __tmp16_outputWritten = true;
                        }
                        if (!__tmp17_last || __tmp16_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp16_outputWritten)
                {
                    __out.AppendLine(false); //879:41
                }
            }
            __out.AppendLine(true); //881:1
            __out.Append("	/// <summary>"); //882:1
            __out.AppendLine(false); //882:15
            bool __tmp19_outputWritten = false;
            string __tmp20_line = "	/// Convert the <see cref=\""; //883:1
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp19_outputWritten = true;
            }
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(CSharpName(cls, model, ClassKind.Immutable));
            using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
            {
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(!__tmp21_last)
                {
                    string __tmp21_line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if ((__tmp21_last && !string.IsNullOrEmpty(__tmp21_line)) || (!__tmp21_last && __tmp21_line != null))
                    {
                        __out.Append(__tmp21_line);
                        __tmp19_outputWritten = true;
                    }
                    if (!__tmp21_last) __out.AppendLine(true);
                }
            }
            string __tmp22_line = "\"/> object to a builder <see cref=\""; //883:73
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Append(__tmp22_line);
                __tmp19_outputWritten = true;
            }
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(CSharpName(cls, model, ClassKind.Builder));
            using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
            {
                bool __tmp23_last = __tmp23Reader.EndOfStream;
                while(!__tmp23_last)
                {
                    string __tmp23_line = __tmp23Reader.ReadLine();
                    __tmp23_last = __tmp23Reader.EndOfStream;
                    if ((__tmp23_last && !string.IsNullOrEmpty(__tmp23_line)) || (!__tmp23_last && __tmp23_line != null))
                    {
                        __out.Append(__tmp23_line);
                        __tmp19_outputWritten = true;
                    }
                    if (!__tmp23_last) __out.AppendLine(true);
                }
            }
            string __tmp24_line = "\"/> object."; //883:150
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp19_outputWritten = true;
            }
            if (__tmp19_outputWritten) __out.AppendLine(true);
            if (__tmp19_outputWritten)
            {
                __out.AppendLine(false); //883:161
            }
            __out.Append("	/// </summary>"); //884:1
            __out.AppendLine(false); //884:16
            bool __tmp26_outputWritten = false;
            string __tmp27_line = "	new "; //885:1
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Append(__tmp27_line);
                __tmp26_outputWritten = true;
            }
            StringBuilder __tmp28 = new StringBuilder();
            __tmp28.Append(CSharpName(cls, model, ClassKind.Builder, true));
            using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
            {
                bool __tmp28_last = __tmp28Reader.EndOfStream;
                while(!__tmp28_last)
                {
                    string __tmp28_line = __tmp28Reader.ReadLine();
                    __tmp28_last = __tmp28Reader.EndOfStream;
                    if ((__tmp28_last && !string.IsNullOrEmpty(__tmp28_line)) || (!__tmp28_last && __tmp28_line != null))
                    {
                        __out.Append(__tmp28_line);
                        __tmp26_outputWritten = true;
                    }
                    if (!__tmp28_last) __out.AppendLine(true);
                }
            }
            string __tmp29_line = " ToMutable();"; //885:54
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Append(__tmp29_line);
                __tmp26_outputWritten = true;
            }
            if (__tmp26_outputWritten) __out.AppendLine(true);
            if (__tmp26_outputWritten)
            {
                __out.AppendLine(false); //885:67
            }
            __out.Append("	/// <summary>"); //886:1
            __out.AppendLine(false); //886:15
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "	/// Convert the <see cref=\""; //887:1
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Append(__tmp32_line);
                __tmp31_outputWritten = true;
            }
            StringBuilder __tmp33 = new StringBuilder();
            __tmp33.Append(CSharpName(cls, model, ClassKind.Immutable));
            using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
            {
                bool __tmp33_last = __tmp33Reader.EndOfStream;
                while(!__tmp33_last)
                {
                    string __tmp33_line = __tmp33Reader.ReadLine();
                    __tmp33_last = __tmp33Reader.EndOfStream;
                    if ((__tmp33_last && !string.IsNullOrEmpty(__tmp33_line)) || (!__tmp33_last && __tmp33_line != null))
                    {
                        __out.Append(__tmp33_line);
                        __tmp31_outputWritten = true;
                    }
                    if (!__tmp33_last) __out.AppendLine(true);
                }
            }
            string __tmp34_line = "\"/> object to a builder <see cref=\""; //887:73
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Append(__tmp34_line);
                __tmp31_outputWritten = true;
            }
            StringBuilder __tmp35 = new StringBuilder();
            __tmp35.Append(CSharpName(cls, model, ClassKind.Builder));
            using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
            {
                bool __tmp35_last = __tmp35Reader.EndOfStream;
                while(!__tmp35_last)
                {
                    string __tmp35_line = __tmp35Reader.ReadLine();
                    __tmp35_last = __tmp35Reader.EndOfStream;
                    if ((__tmp35_last && !string.IsNullOrEmpty(__tmp35_line)) || (!__tmp35_last && __tmp35_line != null))
                    {
                        __out.Append(__tmp35_line);
                        __tmp31_outputWritten = true;
                    }
                    if (!__tmp35_last) __out.AppendLine(true);
                }
            }
            string __tmp36_line = "\"/> object"; //887:150
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Append(__tmp36_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //887:160
            }
            __out.Append("	/// by taking the builder version from the given model."); //888:1
            __out.AppendLine(false); //888:57
            __out.Append("	/// </summary>"); //889:1
            __out.AppendLine(false); //889:16
            __out.Append("	/// <param name=\"model\">The mutable model from which the return value is taken from.</param>"); //890:1
            __out.AppendLine(false); //890:94
            bool __tmp38_outputWritten = false;
            string __tmp39_line = "	new "; //891:1
            if (!string.IsNullOrEmpty(__tmp39_line))
            {
                __out.Append(__tmp39_line);
                __tmp38_outputWritten = true;
            }
            StringBuilder __tmp40 = new StringBuilder();
            __tmp40.Append(CSharpName(cls, model, ClassKind.Builder, true));
            using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
            {
                bool __tmp40_last = __tmp40Reader.EndOfStream;
                while(!__tmp40_last)
                {
                    string __tmp40_line = __tmp40Reader.ReadLine();
                    __tmp40_last = __tmp40Reader.EndOfStream;
                    if ((__tmp40_last && !string.IsNullOrEmpty(__tmp40_line)) || (!__tmp40_last && __tmp40_line != null))
                    {
                        __out.Append(__tmp40_line);
                        __tmp38_outputWritten = true;
                    }
                    if (!__tmp40_last) __out.AppendLine(true);
                }
            }
            string __tmp41_line = " ToMutable("; //891:54
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Append(__tmp41_line);
                __tmp38_outputWritten = true;
            }
            StringBuilder __tmp42 = new StringBuilder();
            __tmp42.Append(Properties.CoreNs);
            using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
            {
                bool __tmp42_last = __tmp42Reader.EndOfStream;
                while(!__tmp42_last)
                {
                    string __tmp42_line = __tmp42Reader.ReadLine();
                    __tmp42_last = __tmp42Reader.EndOfStream;
                    if ((__tmp42_last && !string.IsNullOrEmpty(__tmp42_line)) || (!__tmp42_last && __tmp42_line != null))
                    {
                        __out.Append(__tmp42_line);
                        __tmp38_outputWritten = true;
                    }
                    if (!__tmp42_last) __out.AppendLine(true);
                }
            }
            string __tmp43_line = ".MutableModel model);"; //891:84
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Append(__tmp43_line);
                __tmp38_outputWritten = true;
            }
            if (__tmp38_outputWritten) __out.AppendLine(true);
            if (__tmp38_outputWritten)
            {
                __out.AppendLine(false); //891:105
            }
            __out.Append("}"); //892:1
            __out.AppendLine(false); //892:2
            return __out.ToString();
        }

        public string GenerateImmutableProperty(MetaModel model, MetaProperty prop) //895:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(prop));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3_line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                    {
                        __out.Append(__tmp3_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp3_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //896:30
            }
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name) || (IsMetaMetaModel(model) && prop.Class.Name == "MetaModel")) //897:2
            {
                __out.Append("new "); //898:1
            }
            bool __tmp5_outputWritten = false;
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(CSharpName(prop.Type, model, ClassKind.Immutable, true));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                    {
                        __out.Append(__tmp6_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7_line = " "; //900:57
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp5_outputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(CSharpName(prop, model, PropertyKind.Immutable));
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9_line = " { get; }"; //900:106
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //900:115
            }
            return __out.ToString();
        }

        public string GenerateImmutableOperation(MetaModel model, MetaOperation op) //903:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(op));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3_line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                    {
                        __out.Append(__tmp3_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp3_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //904:28
            }
            bool __tmp5_outputWritten = false;
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation, true));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                    {
                        __out.Append(__tmp6_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7_line = " "; //905:70
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp5_outputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(op.Name);
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9_line = "("; //905:80
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp5_outputWritten = true;
            }
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(GetImmutableOperationParameters(model, op, ClassKind.ImmutableOperation));
            using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
            {
                bool __tmp10_last = __tmp10Reader.EndOfStream;
                while(!__tmp10_last)
                {
                    string __tmp10_line = __tmp10Reader.ReadLine();
                    __tmp10_last = __tmp10Reader.EndOfStream;
                    if ((__tmp10_last && !string.IsNullOrEmpty(__tmp10_line)) || (!__tmp10_last && __tmp10_line != null))
                    {
                        __out.Append(__tmp10_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp10_last) __out.AppendLine(true);
                }
            }
            string __tmp11_line = ");"; //905:155
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Append(__tmp11_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //905:157
            }
            return __out.ToString();
        }

        public string GetImmutableOperationParameters(MetaModel model, MetaOperation op, ClassKind kind) //908:1
        {
            string result = ""; //909:2
            var __loop56_results = 
                (from __loop56_var1 in __Enumerate((op).GetEnumerator()) //910:7
                from param in __Enumerate((__loop56_var1.Parameters).GetEnumerator()) //910:11
                select new { __loop56_var1 = __loop56_var1, param = param}
                ).ToList(); //910:2
            for (int __loop56_iteration = 0; __loop56_iteration < __loop56_results.Count; ++__loop56_iteration)
            {
                string delim; //910:27
                if (__loop56_iteration+1 < __loop56_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop56_results[__loop56_iteration];
                var __loop56_var1 = __tmp1.__loop56_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, kind, true) + " " + param.Name + delim; //911:3
            }
            return result; //913:2
        }

        public string GetImmutableAncestors(MetaModel model, MetaClass cls) //916:1
        {
            string result = ""; //917:2
            var __loop57_results = 
                (from __loop57_var1 in __Enumerate((cls).GetEnumerator()) //918:7
                from super in __Enumerate((__loop57_var1.SuperClasses).GetEnumerator()) //918:12
                select new { __loop57_var1 = __loop57_var1, super = super}
                ).ToList(); //918:2
            for (int __loop57_iteration = 0; __loop57_iteration < __loop57_results.Count; ++__loop57_iteration)
            {
                string delim; //918:30
                if (__loop57_iteration+1 < __loop57_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop57_results[__loop57_iteration];
                var __loop57_var1 = __tmp1.__loop57_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Immutable, true) + delim; //919:3
            }
            if (result == "") //921:2
            {
                result = Properties.CoreNs + ".ImmutableObject"; //922:3
            }
            result = " : " + result; //924:2
            return result; //925:2
        }

        public string GenerateBuilderClass(MetaModel model, MetaClass cls) //928:1
        {
            StringBuilder __out = new StringBuilder();
            bool metaMetaModel = IsMetaMetaModel(model); //929:2
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(cls));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3_line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                    {
                        __out.Append(__tmp3_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp3_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //930:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //931:1
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Append(__tmp6_line);
                __tmp5_outputWritten = true;
            }
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(CSharpName(cls, model, ClassKind.Builder));
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(!__tmp7_last)
                {
                    string __tmp7_line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if ((__tmp7_last && !string.IsNullOrEmpty(__tmp7_line)) || (!__tmp7_last && __tmp7_line != null))
                    {
                        __out.Append(__tmp7_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(GetBuilderAncestors(model, cls));
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(metaMetaModel && cls.Name == "MetaModel" ? ", " + Properties.CoreNs + ".IMetaModel" : "");
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9_line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if ((__tmp9_last && !string.IsNullOrEmpty(__tmp9_line)) || (!__tmp9_last && __tmp9_line != null))
                    {
                        __out.Append(__tmp9_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp9_last || __tmp5_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //931:179
            }
            __out.Append("{"); //932:1
            __out.AppendLine(false); //932:2
            if (metaMetaModel && cls.Name == "MetaModel") //933:3
            {
                __out.Append("	/// <summary>"); //934:1
                __out.AppendLine(false); //934:15
                __out.Append("	/// The name of the metamodel."); //935:1
                __out.AppendLine(false); //935:32
                __out.Append("	/// </summary>"); //936:1
                __out.AppendLine(false); //936:16
                __out.Append("	new string Name { get; set; }"); //937:1
                __out.AppendLine(false); //937:31
            }
            var __loop58_results = 
                (from __loop58_var1 in __Enumerate((cls).GetEnumerator()) //939:8
                from prop in __Enumerate((__loop58_var1.Properties).GetEnumerator()) //939:13
                select new { __loop58_var1 = __loop58_var1, prop = prop}
                ).ToList(); //939:3
            for (int __loop58_iteration = 0; __loop58_iteration < __loop58_results.Count; ++__loop58_iteration)
            {
                var __tmp10 = __loop58_results[__loop58_iteration];
                var __loop58_var1 = __tmp10.__loop58_var1;
                var prop = __tmp10.prop;
                bool __tmp12_outputWritten = false;
                string __tmp11Prefix = "	"; //940:1
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(GenerateBuilderProperty(model, prop));
                using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
                {
                    bool __tmp13_last = __tmp13Reader.EndOfStream;
                    while(!__tmp13_last)
                    {
                        string __tmp13_line = __tmp13Reader.ReadLine();
                        __tmp13_last = __tmp13Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp11Prefix))
                        {
                            __out.Append(__tmp11Prefix);
                            __tmp12_outputWritten = true;
                        }
                        if ((__tmp13_last && !string.IsNullOrEmpty(__tmp13_line)) || (!__tmp13_last && __tmp13_line != null))
                        {
                            __out.Append(__tmp13_line);
                            __tmp12_outputWritten = true;
                        }
                        if (!__tmp13_last || __tmp12_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp12_outputWritten)
                {
                    __out.AppendLine(false); //940:40
                }
            }
            __out.AppendLine(true); //942:1
            var __loop59_results = 
                (from __loop59_var1 in __Enumerate((cls).GetEnumerator()) //943:8
                from op in __Enumerate((__loop59_var1.Operations).GetEnumerator()) //943:13
                select new { __loop59_var1 = __loop59_var1, op = op}
                ).ToList(); //943:3
            for (int __loop59_iteration = 0; __loop59_iteration < __loop59_results.Count; ++__loop59_iteration)
            {
                var __tmp14 = __loop59_results[__loop59_iteration];
                var __loop59_var1 = __tmp14.__loop59_var1;
                var op = __tmp14.op;
                bool __tmp16_outputWritten = false;
                string __tmp15Prefix = "	"; //944:1
                StringBuilder __tmp17 = new StringBuilder();
                __tmp17.Append(GenerateBuilderOperation(model, op));
                using(StreamReader __tmp17Reader = new StreamReader(this.__ToStream(__tmp17.ToString())))
                {
                    bool __tmp17_last = __tmp17Reader.EndOfStream;
                    while(!__tmp17_last)
                    {
                        string __tmp17_line = __tmp17Reader.ReadLine();
                        __tmp17_last = __tmp17Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp15Prefix))
                        {
                            __out.Append(__tmp15Prefix);
                            __tmp16_outputWritten = true;
                        }
                        if ((__tmp17_last && !string.IsNullOrEmpty(__tmp17_line)) || (!__tmp17_last && __tmp17_line != null))
                        {
                            __out.Append(__tmp17_line);
                            __tmp16_outputWritten = true;
                        }
                        if (!__tmp17_last || __tmp16_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp16_outputWritten)
                {
                    __out.AppendLine(false); //944:39
                }
            }
            __out.AppendLine(true); //946:1
            __out.Append("	/// <summary>"); //947:1
            __out.AppendLine(false); //947:15
            bool __tmp19_outputWritten = false;
            string __tmp20_line = "	/// Convert the <see cref=\""; //948:1
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp19_outputWritten = true;
            }
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(CSharpName(cls, model, ClassKind.Builder));
            using(StreamReader __tmp21Reader = new StreamReader(this.__ToStream(__tmp21.ToString())))
            {
                bool __tmp21_last = __tmp21Reader.EndOfStream;
                while(!__tmp21_last)
                {
                    string __tmp21_line = __tmp21Reader.ReadLine();
                    __tmp21_last = __tmp21Reader.EndOfStream;
                    if ((__tmp21_last && !string.IsNullOrEmpty(__tmp21_line)) || (!__tmp21_last && __tmp21_line != null))
                    {
                        __out.Append(__tmp21_line);
                        __tmp19_outputWritten = true;
                    }
                    if (!__tmp21_last) __out.AppendLine(true);
                }
            }
            string __tmp22_line = "\"/> object to an immutable <see cref=\""; //948:71
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Append(__tmp22_line);
                __tmp19_outputWritten = true;
            }
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(CSharpName(cls, model, ClassKind.Immutable));
            using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
            {
                bool __tmp23_last = __tmp23Reader.EndOfStream;
                while(!__tmp23_last)
                {
                    string __tmp23_line = __tmp23Reader.ReadLine();
                    __tmp23_last = __tmp23Reader.EndOfStream;
                    if ((__tmp23_last && !string.IsNullOrEmpty(__tmp23_line)) || (!__tmp23_last && __tmp23_line != null))
                    {
                        __out.Append(__tmp23_line);
                        __tmp19_outputWritten = true;
                    }
                    if (!__tmp23_last) __out.AppendLine(true);
                }
            }
            string __tmp24_line = "\"/> object."; //948:153
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp19_outputWritten = true;
            }
            if (__tmp19_outputWritten) __out.AppendLine(true);
            if (__tmp19_outputWritten)
            {
                __out.AppendLine(false); //948:164
            }
            __out.Append("	/// </summary>"); //949:1
            __out.AppendLine(false); //949:16
            bool __tmp26_outputWritten = false;
            string __tmp27_line = "	new "; //950:1
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Append(__tmp27_line);
                __tmp26_outputWritten = true;
            }
            StringBuilder __tmp28 = new StringBuilder();
            __tmp28.Append(CSharpName(cls, model, ClassKind.Immutable, true));
            using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
            {
                bool __tmp28_last = __tmp28Reader.EndOfStream;
                while(!__tmp28_last)
                {
                    string __tmp28_line = __tmp28Reader.ReadLine();
                    __tmp28_last = __tmp28Reader.EndOfStream;
                    if ((__tmp28_last && !string.IsNullOrEmpty(__tmp28_line)) || (!__tmp28_last && __tmp28_line != null))
                    {
                        __out.Append(__tmp28_line);
                        __tmp26_outputWritten = true;
                    }
                    if (!__tmp28_last) __out.AppendLine(true);
                }
            }
            string __tmp29_line = " ToImmutable();"; //950:56
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Append(__tmp29_line);
                __tmp26_outputWritten = true;
            }
            if (__tmp26_outputWritten) __out.AppendLine(true);
            if (__tmp26_outputWritten)
            {
                __out.AppendLine(false); //950:71
            }
            __out.Append("	/// <summary>"); //951:1
            __out.AppendLine(false); //951:15
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "	/// Convert the <see cref=\""; //952:1
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Append(__tmp32_line);
                __tmp31_outputWritten = true;
            }
            StringBuilder __tmp33 = new StringBuilder();
            __tmp33.Append(CSharpName(cls, model, ClassKind.Builder));
            using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
            {
                bool __tmp33_last = __tmp33Reader.EndOfStream;
                while(!__tmp33_last)
                {
                    string __tmp33_line = __tmp33Reader.ReadLine();
                    __tmp33_last = __tmp33Reader.EndOfStream;
                    if ((__tmp33_last && !string.IsNullOrEmpty(__tmp33_line)) || (!__tmp33_last && __tmp33_line != null))
                    {
                        __out.Append(__tmp33_line);
                        __tmp31_outputWritten = true;
                    }
                    if (!__tmp33_last) __out.AppendLine(true);
                }
            }
            string __tmp34_line = "\"/> object to an immutable <see cref=\""; //952:71
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Append(__tmp34_line);
                __tmp31_outputWritten = true;
            }
            StringBuilder __tmp35 = new StringBuilder();
            __tmp35.Append(CSharpName(cls, model, ClassKind.Immutable));
            using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
            {
                bool __tmp35_last = __tmp35Reader.EndOfStream;
                while(!__tmp35_last)
                {
                    string __tmp35_line = __tmp35Reader.ReadLine();
                    __tmp35_last = __tmp35Reader.EndOfStream;
                    if ((__tmp35_last && !string.IsNullOrEmpty(__tmp35_line)) || (!__tmp35_last && __tmp35_line != null))
                    {
                        __out.Append(__tmp35_line);
                        __tmp31_outputWritten = true;
                    }
                    if (!__tmp35_last) __out.AppendLine(true);
                }
            }
            string __tmp36_line = "\"/> object"; //952:153
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Append(__tmp36_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //952:163
            }
            __out.Append("	/// by taking the immutable version from the given model."); //953:1
            __out.AppendLine(false); //953:59
            __out.Append("	/// </summary>"); //954:1
            __out.AppendLine(false); //954:16
            __out.Append("	/// <param name=\"model\">The immutable model from which the return value is taken from.</param>"); //955:1
            __out.AppendLine(false); //955:96
            bool __tmp38_outputWritten = false;
            string __tmp39_line = "	new "; //956:1
            if (!string.IsNullOrEmpty(__tmp39_line))
            {
                __out.Append(__tmp39_line);
                __tmp38_outputWritten = true;
            }
            StringBuilder __tmp40 = new StringBuilder();
            __tmp40.Append(CSharpName(cls, model, ClassKind.Immutable, true));
            using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
            {
                bool __tmp40_last = __tmp40Reader.EndOfStream;
                while(!__tmp40_last)
                {
                    string __tmp40_line = __tmp40Reader.ReadLine();
                    __tmp40_last = __tmp40Reader.EndOfStream;
                    if ((__tmp40_last && !string.IsNullOrEmpty(__tmp40_line)) || (!__tmp40_last && __tmp40_line != null))
                    {
                        __out.Append(__tmp40_line);
                        __tmp38_outputWritten = true;
                    }
                    if (!__tmp40_last) __out.AppendLine(true);
                }
            }
            string __tmp41_line = " ToImmutable("; //956:56
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Append(__tmp41_line);
                __tmp38_outputWritten = true;
            }
            StringBuilder __tmp42 = new StringBuilder();
            __tmp42.Append(Properties.CoreNs);
            using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
            {
                bool __tmp42_last = __tmp42Reader.EndOfStream;
                while(!__tmp42_last)
                {
                    string __tmp42_line = __tmp42Reader.ReadLine();
                    __tmp42_last = __tmp42Reader.EndOfStream;
                    if ((__tmp42_last && !string.IsNullOrEmpty(__tmp42_line)) || (!__tmp42_last && __tmp42_line != null))
                    {
                        __out.Append(__tmp42_line);
                        __tmp38_outputWritten = true;
                    }
                    if (!__tmp42_last) __out.AppendLine(true);
                }
            }
            string __tmp43_line = ".ImmutableModel model);"; //956:88
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Append(__tmp43_line);
                __tmp38_outputWritten = true;
            }
            if (__tmp38_outputWritten) __out.AppendLine(true);
            if (__tmp38_outputWritten)
            {
                __out.AppendLine(false); //956:111
            }
            __out.Append("}"); //957:1
            __out.AppendLine(false); //957:2
            return __out.ToString();
        }

        public string GenerateBuilderProperty(MetaModel model, MetaProperty prop) //960:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(prop));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3_line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                    {
                        __out.Append(__tmp3_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp3_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //961:30
            }
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name) || (IsMetaMetaModel(model) && prop.Class.Name == "MetaModel")) //962:3
            {
                __out.Append("new "); //963:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal) && !(prop.Type is MetaCollectionType)) //965:3
            {
                bool __tmp5_outputWritten = false;
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
                using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                {
                    bool __tmp6_last = __tmp6Reader.EndOfStream;
                    while(!__tmp6_last)
                    {
                        string __tmp6_line = __tmp6Reader.ReadLine();
                        __tmp6_last = __tmp6Reader.EndOfStream;
                        if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                        {
                            __out.Append(__tmp6_line);
                            __tmp5_outputWritten = true;
                        }
                        if (!__tmp6_last) __out.AppendLine(true);
                    }
                }
                string __tmp7_line = " "; //966:55
                if (!string.IsNullOrEmpty(__tmp7_line))
                {
                    __out.Append(__tmp7_line);
                    __tmp5_outputWritten = true;
                }
                StringBuilder __tmp8 = new StringBuilder();
                __tmp8.Append(CSharpName(prop, model, PropertyKind.Builder));
                using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
                {
                    bool __tmp8_last = __tmp8Reader.EndOfStream;
                    while(!__tmp8_last)
                    {
                        string __tmp8_line = __tmp8Reader.ReadLine();
                        __tmp8_last = __tmp8Reader.EndOfStream;
                        if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                        {
                            __out.Append(__tmp8_line);
                            __tmp5_outputWritten = true;
                        }
                        if (!__tmp8_last) __out.AppendLine(true);
                    }
                }
                string __tmp9_line = " { get; set; }"; //966:102
                if (!string.IsNullOrEmpty(__tmp9_line))
                {
                    __out.Append(__tmp9_line);
                    __tmp5_outputWritten = true;
                }
                if (__tmp5_outputWritten) __out.AppendLine(true);
                if (__tmp5_outputWritten)
                {
                    __out.AppendLine(false); //966:116
                }
            }
            else //967:3
            {
                bool __tmp11_outputWritten = false;
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
                using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                {
                    bool __tmp12_last = __tmp12Reader.EndOfStream;
                    while(!__tmp12_last)
                    {
                        string __tmp12_line = __tmp12Reader.ReadLine();
                        __tmp12_last = __tmp12Reader.EndOfStream;
                        if ((__tmp12_last && !string.IsNullOrEmpty(__tmp12_line)) || (!__tmp12_last && __tmp12_line != null))
                        {
                            __out.Append(__tmp12_line);
                            __tmp11_outputWritten = true;
                        }
                        if (!__tmp12_last) __out.AppendLine(true);
                    }
                }
                string __tmp13_line = " "; //968:55
                if (!string.IsNullOrEmpty(__tmp13_line))
                {
                    __out.Append(__tmp13_line);
                    __tmp11_outputWritten = true;
                }
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(CSharpName(prop, model, PropertyKind.Builder));
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_last = __tmp14Reader.EndOfStream;
                    while(!__tmp14_last)
                    {
                        string __tmp14_line = __tmp14Reader.ReadLine();
                        __tmp14_last = __tmp14Reader.EndOfStream;
                        if ((__tmp14_last && !string.IsNullOrEmpty(__tmp14_line)) || (!__tmp14_last && __tmp14_line != null))
                        {
                            __out.Append(__tmp14_line);
                            __tmp11_outputWritten = true;
                        }
                        if (!__tmp14_last) __out.AppendLine(true);
                    }
                }
                string __tmp15_line = " { get; }"; //968:102
                if (!string.IsNullOrEmpty(__tmp15_line))
                {
                    __out.Append(__tmp15_line);
                    __tmp11_outputWritten = true;
                }
                if (__tmp11_outputWritten) __out.AppendLine(true);
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //968:111
                }
            }
            if (!(prop.Type is MetaCollectionType)) //970:3
            {
                bool __tmp17_outputWritten = false;
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(GenerateDocumentation(prop));
                using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
                {
                    bool __tmp18_last = __tmp18Reader.EndOfStream;
                    while(!__tmp18_last)
                    {
                        string __tmp18_line = __tmp18Reader.ReadLine();
                        __tmp18_last = __tmp18Reader.EndOfStream;
                        if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                        {
                            __out.Append(__tmp18_line);
                            __tmp17_outputWritten = true;
                        }
                        if (!__tmp18_last || __tmp17_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp17_outputWritten)
                {
                    __out.AppendLine(false); //971:30
                }
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //972:4
                {
                    __out.Append("new "); //973:1
                }
                bool __tmp20_outputWritten = false;
                string __tmp21_line = "void Set"; //975:1
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp20_outputWritten = true;
                }
                StringBuilder __tmp22 = new StringBuilder();
                __tmp22.Append(CSharpName(prop, model, PropertyKind.Builder));
                using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                {
                    bool __tmp22_last = __tmp22Reader.EndOfStream;
                    while(!__tmp22_last)
                    {
                        string __tmp22_line = __tmp22Reader.ReadLine();
                        __tmp22_last = __tmp22Reader.EndOfStream;
                        if ((__tmp22_last && !string.IsNullOrEmpty(__tmp22_line)) || (!__tmp22_last && __tmp22_line != null))
                        {
                            __out.Append(__tmp22_line);
                            __tmp20_outputWritten = true;
                        }
                        if (!__tmp22_last) __out.AppendLine(true);
                    }
                }
                string __tmp23_line = "Lazy(global::System.Func<"; //975:55
                if (!string.IsNullOrEmpty(__tmp23_line))
                {
                    __out.Append(__tmp23_line);
                    __tmp20_outputWritten = true;
                }
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
                using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                {
                    bool __tmp24_last = __tmp24Reader.EndOfStream;
                    while(!__tmp24_last)
                    {
                        string __tmp24_line = __tmp24Reader.ReadLine();
                        __tmp24_last = __tmp24Reader.EndOfStream;
                        if ((__tmp24_last && !string.IsNullOrEmpty(__tmp24_line)) || (!__tmp24_last && __tmp24_line != null))
                        {
                            __out.Append(__tmp24_line);
                            __tmp20_outputWritten = true;
                        }
                        if (!__tmp24_last) __out.AppendLine(true);
                    }
                }
                string __tmp25_line = "> lazy);"; //975:134
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Append(__tmp25_line);
                    __tmp20_outputWritten = true;
                }
                if (__tmp20_outputWritten) __out.AppendLine(true);
                if (__tmp20_outputWritten)
                {
                    __out.AppendLine(false); //975:142
                }
                bool __tmp27_outputWritten = false;
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(GenerateDocumentation(prop));
                using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                {
                    bool __tmp28_last = __tmp28Reader.EndOfStream;
                    while(!__tmp28_last)
                    {
                        string __tmp28_line = __tmp28Reader.ReadLine();
                        __tmp28_last = __tmp28Reader.EndOfStream;
                        if ((__tmp28_last && !string.IsNullOrEmpty(__tmp28_line)) || (!__tmp28_last && __tmp28_line != null))
                        {
                            __out.Append(__tmp28_line);
                            __tmp27_outputWritten = true;
                        }
                        if (!__tmp28_last || __tmp27_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp27_outputWritten)
                {
                    __out.AppendLine(false); //976:30
                }
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //977:4
                {
                    __out.Append("new "); //978:1
                }
                bool __tmp30_outputWritten = false;
                string __tmp31_line = "void Set"; //980:1
                if (!string.IsNullOrEmpty(__tmp31_line))
                {
                    __out.Append(__tmp31_line);
                    __tmp30_outputWritten = true;
                }
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(CSharpName(prop, model, PropertyKind.Builder));
                using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
                {
                    bool __tmp32_last = __tmp32Reader.EndOfStream;
                    while(!__tmp32_last)
                    {
                        string __tmp32_line = __tmp32Reader.ReadLine();
                        __tmp32_last = __tmp32Reader.EndOfStream;
                        if ((__tmp32_last && !string.IsNullOrEmpty(__tmp32_line)) || (!__tmp32_last && __tmp32_line != null))
                        {
                            __out.Append(__tmp32_line);
                            __tmp30_outputWritten = true;
                        }
                        if (!__tmp32_last) __out.AppendLine(true);
                    }
                }
                string __tmp33_line = "Lazy(global::System.Func<"; //980:55
                if (!string.IsNullOrEmpty(__tmp33_line))
                {
                    __out.Append(__tmp33_line);
                    __tmp30_outputWritten = true;
                }
                StringBuilder __tmp34 = new StringBuilder();
                __tmp34.Append(CSharpName(prop.Class, model, ClassKind.Builder));
                using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                {
                    bool __tmp34_last = __tmp34Reader.EndOfStream;
                    while(!__tmp34_last)
                    {
                        string __tmp34_line = __tmp34Reader.ReadLine();
                        __tmp34_last = __tmp34Reader.EndOfStream;
                        if ((__tmp34_last && !string.IsNullOrEmpty(__tmp34_line)) || (!__tmp34_last && __tmp34_line != null))
                        {
                            __out.Append(__tmp34_line);
                            __tmp30_outputWritten = true;
                        }
                        if (!__tmp34_last) __out.AppendLine(true);
                    }
                }
                string __tmp35_line = ", "; //980:129
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Append(__tmp35_line);
                    __tmp30_outputWritten = true;
                }
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
                using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                {
                    bool __tmp36_last = __tmp36Reader.EndOfStream;
                    while(!__tmp36_last)
                    {
                        string __tmp36_line = __tmp36Reader.ReadLine();
                        __tmp36_last = __tmp36Reader.EndOfStream;
                        if ((__tmp36_last && !string.IsNullOrEmpty(__tmp36_line)) || (!__tmp36_last && __tmp36_line != null))
                        {
                            __out.Append(__tmp36_line);
                            __tmp30_outputWritten = true;
                        }
                        if (!__tmp36_last) __out.AppendLine(true);
                    }
                }
                string __tmp37_line = "> lazy);"; //980:185
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp30_outputWritten = true;
                }
                if (__tmp30_outputWritten) __out.AppendLine(true);
                if (__tmp30_outputWritten)
                {
                    __out.AppendLine(false); //980:193
                }
                bool __tmp39_outputWritten = false;
                StringBuilder __tmp40 = new StringBuilder();
                __tmp40.Append(GenerateDocumentation(prop));
                using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                {
                    bool __tmp40_last = __tmp40Reader.EndOfStream;
                    while(!__tmp40_last)
                    {
                        string __tmp40_line = __tmp40Reader.ReadLine();
                        __tmp40_last = __tmp40Reader.EndOfStream;
                        if ((__tmp40_last && !string.IsNullOrEmpty(__tmp40_line)) || (!__tmp40_last && __tmp40_line != null))
                        {
                            __out.Append(__tmp40_line);
                            __tmp39_outputWritten = true;
                        }
                        if (!__tmp40_last || __tmp39_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //981:30
                }
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //982:4
                {
                    __out.Append("new "); //983:1
                }
                bool __tmp42_outputWritten = false;
                string __tmp43_line = "void Set"; //985:1
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Append(__tmp43_line);
                    __tmp42_outputWritten = true;
                }
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(CSharpName(prop, model, PropertyKind.Builder));
                using(StreamReader __tmp44Reader = new StreamReader(this.__ToStream(__tmp44.ToString())))
                {
                    bool __tmp44_last = __tmp44Reader.EndOfStream;
                    while(!__tmp44_last)
                    {
                        string __tmp44_line = __tmp44Reader.ReadLine();
                        __tmp44_last = __tmp44Reader.EndOfStream;
                        if ((__tmp44_last && !string.IsNullOrEmpty(__tmp44_line)) || (!__tmp44_last && __tmp44_line != null))
                        {
                            __out.Append(__tmp44_line);
                            __tmp42_outputWritten = true;
                        }
                        if (!__tmp44_last) __out.AppendLine(true);
                    }
                }
                string __tmp45_line = "Lazy(global::System.Func<"; //985:55
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Append(__tmp45_line);
                    __tmp42_outputWritten = true;
                }
                StringBuilder __tmp46 = new StringBuilder();
                __tmp46.Append(CSharpName(prop.Class, model, ClassKind.Immutable));
                using(StreamReader __tmp46Reader = new StreamReader(this.__ToStream(__tmp46.ToString())))
                {
                    bool __tmp46_last = __tmp46Reader.EndOfStream;
                    while(!__tmp46_last)
                    {
                        string __tmp46_line = __tmp46Reader.ReadLine();
                        __tmp46_last = __tmp46Reader.EndOfStream;
                        if ((__tmp46_last && !string.IsNullOrEmpty(__tmp46_line)) || (!__tmp46_last && __tmp46_line != null))
                        {
                            __out.Append(__tmp46_line);
                            __tmp42_outputWritten = true;
                        }
                        if (!__tmp46_last) __out.AppendLine(true);
                    }
                }
                string __tmp47_line = ", "; //985:131
                if (!string.IsNullOrEmpty(__tmp47_line))
                {
                    __out.Append(__tmp47_line);
                    __tmp42_outputWritten = true;
                }
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append(CSharpName(prop.Type, model, ClassKind.Immutable, true));
                using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
                {
                    bool __tmp48_last = __tmp48Reader.EndOfStream;
                    while(!__tmp48_last)
                    {
                        string __tmp48_line = __tmp48Reader.ReadLine();
                        __tmp48_last = __tmp48Reader.EndOfStream;
                        if ((__tmp48_last && !string.IsNullOrEmpty(__tmp48_line)) || (!__tmp48_last && __tmp48_line != null))
                        {
                            __out.Append(__tmp48_line);
                            __tmp42_outputWritten = true;
                        }
                        if (!__tmp48_last) __out.AppendLine(true);
                    }
                }
                string __tmp49_line = "> immutableLazy, global::System.Func<"; //985:189
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Append(__tmp49_line);
                    __tmp42_outputWritten = true;
                }
                StringBuilder __tmp50 = new StringBuilder();
                __tmp50.Append(CSharpName(prop.Class, model, ClassKind.Builder));
                using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                {
                    bool __tmp50_last = __tmp50Reader.EndOfStream;
                    while(!__tmp50_last)
                    {
                        string __tmp50_line = __tmp50Reader.ReadLine();
                        __tmp50_last = __tmp50Reader.EndOfStream;
                        if ((__tmp50_last && !string.IsNullOrEmpty(__tmp50_line)) || (!__tmp50_last && __tmp50_line != null))
                        {
                            __out.Append(__tmp50_line);
                            __tmp42_outputWritten = true;
                        }
                        if (!__tmp50_last) __out.AppendLine(true);
                    }
                }
                string __tmp51_line = ", "; //985:275
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Append(__tmp51_line);
                    __tmp42_outputWritten = true;
                }
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
                using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                {
                    bool __tmp52_last = __tmp52Reader.EndOfStream;
                    while(!__tmp52_last)
                    {
                        string __tmp52_line = __tmp52Reader.ReadLine();
                        __tmp52_last = __tmp52Reader.EndOfStream;
                        if ((__tmp52_last && !string.IsNullOrEmpty(__tmp52_line)) || (!__tmp52_last && __tmp52_line != null))
                        {
                            __out.Append(__tmp52_line);
                            __tmp42_outputWritten = true;
                        }
                        if (!__tmp52_last) __out.AppendLine(true);
                    }
                }
                string __tmp53_line = "> mutableLazy);"; //985:331
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp42_outputWritten = true;
                }
                if (__tmp42_outputWritten) __out.AppendLine(true);
                if (__tmp42_outputWritten)
                {
                    __out.AppendLine(false); //985:346
                }
            }
            return __out.ToString();
        }

        public string GenerateBuilderOperation(MetaModel model, MetaOperation op) //989:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(GenerateDocumentation(op));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3_line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                    {
                        __out.Append(__tmp3_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp3_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //990:28
            }
            bool __tmp5_outputWritten = false;
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(CSharpName(op.ReturnType, model, ClassKind.BuilderOperation, true));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                    {
                        __out.Append(__tmp6_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7_line = " "; //991:68
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp5_outputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(op.Name);
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9_line = "("; //991:78
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp5_outputWritten = true;
            }
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(GetBuilderOperationParameters(model, op, ClassKind.BuilderOperation));
            using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
            {
                bool __tmp10_last = __tmp10Reader.EndOfStream;
                while(!__tmp10_last)
                {
                    string __tmp10_line = __tmp10Reader.ReadLine();
                    __tmp10_last = __tmp10Reader.EndOfStream;
                    if ((__tmp10_last && !string.IsNullOrEmpty(__tmp10_line)) || (!__tmp10_last && __tmp10_line != null))
                    {
                        __out.Append(__tmp10_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp10_last) __out.AppendLine(true);
                }
            }
            string __tmp11_line = ");"; //991:149
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Append(__tmp11_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //991:151
            }
            return __out.ToString();
        }

        public string GetBuilderOperationParameters(MetaModel model, MetaOperation op, ClassKind kind) //994:1
        {
            string result = ""; //995:2
            var __loop60_results = 
                (from __loop60_var1 in __Enumerate((op).GetEnumerator()) //996:7
                from param in __Enumerate((__loop60_var1.Parameters).GetEnumerator()) //996:11
                select new { __loop60_var1 = __loop60_var1, param = param}
                ).ToList(); //996:2
            for (int __loop60_iteration = 0; __loop60_iteration < __loop60_results.Count; ++__loop60_iteration)
            {
                string delim; //996:27
                if (__loop60_iteration+1 < __loop60_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop60_results[__loop60_iteration];
                var __loop60_var1 = __tmp1.__loop60_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, kind, true) + " " + param.Name + delim; //997:3
            }
            return result; //999:2
        }

        public string GetBuilderAncestors(MetaModel model, MetaClass cls) //1002:1
        {
            string result = ""; //1003:2
            var __loop61_results = 
                (from __loop61_var1 in __Enumerate((cls).GetEnumerator()) //1004:7
                from super in __Enumerate((__loop61_var1.SuperClasses).GetEnumerator()) //1004:12
                select new { __loop61_var1 = __loop61_var1, super = super}
                ).ToList(); //1004:2
            for (int __loop61_iteration = 0; __loop61_iteration < __loop61_results.Count; ++__loop61_iteration)
            {
                string delim; //1004:30
                if (__loop61_iteration+1 < __loop61_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop61_results[__loop61_iteration];
                var __loop61_var1 = __tmp1.__loop61_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Builder, true) + delim; //1005:3
            }
            if (result == "") //1007:2
            {
                result = Properties.CoreNs + ".MutableObject"; //1008:3
            }
            result = " : " + result; //1010:2
            return result; //1011:2
        }

        public string GenerateImmutableImplClass(MetaModel model, MetaClass cls) //1014:1
        {
            StringBuilder __out = new StringBuilder();
            bool metaMetaModel = IsMetaMetaModel(model); //1015:2
            string metaNs = metaMetaModel ? "" : Properties.MetaNs + "."; //1016:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //1017:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(CSharpName(cls, model, ClassKind.ImmutableImpl));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5_line = " : "; //1017:64
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Append(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(Properties.CoreNs);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7_line = ".ImmutableObjectBase, "; //1017:86
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(CSharpName(cls, model, ClassKind.Immutable));
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp8_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1017:152
            }
            __out.Append("{"); //1018:1
            __out.AppendLine(false); //1018:2
            var __loop62_results = 
                (from __loop62_var1 in __Enumerate((cls).GetEnumerator()) //1019:8
                from prop in __Enumerate((__loop62_var1.GetAllProperties()).GetEnumerator()) //1019:13
                select new { __loop62_var1 = __loop62_var1, prop = prop}
                ).ToList(); //1019:3
            for (int __loop62_iteration = 0; __loop62_iteration < __loop62_results.Count; ++__loop62_iteration)
            {
                var __tmp9 = __loop62_results[__loop62_iteration];
                var __loop62_var1 = __tmp9.__loop62_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //1020:1
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(GenerateImmutableField(model, cls, prop));
                using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                {
                    bool __tmp12_last = __tmp12Reader.EndOfStream;
                    while(!__tmp12_last)
                    {
                        string __tmp12_line = __tmp12Reader.ReadLine();
                        __tmp12_last = __tmp12Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp10Prefix))
                        {
                            __out.Append(__tmp10Prefix);
                            __tmp11_outputWritten = true;
                        }
                        if ((__tmp12_last && !string.IsNullOrEmpty(__tmp12_line)) || (!__tmp12_last && __tmp12_line != null))
                        {
                            __out.Append(__tmp12_line);
                            __tmp11_outputWritten = true;
                        }
                        if (!__tmp12_last || __tmp11_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //1020:44
                }
            }
            __out.AppendLine(true); //1022:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //1023:1
            if (!string.IsNullOrEmpty(__tmp15_line))
            {
                __out.Append(__tmp15_line);
                __tmp14_outputWritten = true;
            }
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(CSharpName(cls, model, ClassKind.ImmutableImpl));
            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
            {
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    string __tmp16_line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if ((__tmp16_last && !string.IsNullOrEmpty(__tmp16_line)) || (!__tmp16_last && __tmp16_line != null))
                    {
                        __out.Append(__tmp16_line);
                        __tmp14_outputWritten = true;
                    }
                    if (!__tmp16_last) __out.AppendLine(true);
                }
            }
            string __tmp17_line = "("; //1023:59
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp14_outputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(Properties.CoreNs);
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    string __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                    {
                        __out.Append(__tmp18_line);
                        __tmp14_outputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19_line = ".ObjectId id, "; //1023:79
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp14_outputWritten = true;
            }
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(Properties.CoreNs);
            using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
            {
                bool __tmp20_last = __tmp20Reader.EndOfStream;
                while(!__tmp20_last)
                {
                    string __tmp20_line = __tmp20Reader.ReadLine();
                    __tmp20_last = __tmp20Reader.EndOfStream;
                    if ((__tmp20_last && !string.IsNullOrEmpty(__tmp20_line)) || (!__tmp20_last && __tmp20_line != null))
                    {
                        __out.Append(__tmp20_line);
                        __tmp14_outputWritten = true;
                    }
                    if (!__tmp20_last) __out.AppendLine(true);
                }
            }
            string __tmp21_line = ".ImmutableModel model)"; //1023:112
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //1023:134
            }
            __out.Append("		: base(id, model)"); //1024:1
            __out.AppendLine(false); //1024:20
            __out.Append("	{"); //1025:1
            __out.AppendLine(false); //1025:3
            __out.Append("	}"); //1026:1
            __out.AppendLine(false); //1026:3
            __out.AppendLine(true); //1027:2
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	public override "; //1028:1
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp23_outputWritten = true;
            }
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(Properties.CoreNs);
            using(StreamReader __tmp25Reader = new StreamReader(this.__ToStream(__tmp25.ToString())))
            {
                bool __tmp25_last = __tmp25Reader.EndOfStream;
                while(!__tmp25_last)
                {
                    string __tmp25_line = __tmp25Reader.ReadLine();
                    __tmp25_last = __tmp25Reader.EndOfStream;
                    if ((__tmp25_last && !string.IsNullOrEmpty(__tmp25_line)) || (!__tmp25_last && __tmp25_line != null))
                    {
                        __out.Append(__tmp25_line);
                        __tmp23_outputWritten = true;
                    }
                    if (!__tmp25_last) __out.AppendLine(true);
                }
            }
            string __tmp26_line = ".IMetaModel MMetaModel"; //1028:37
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //1028:59
            }
            __out.Append("	{"); //1029:1
            __out.AppendLine(false); //1029:3
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "		get { return "; //1030:1
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Append(__tmp29_line);
                __tmp28_outputWritten = true;
            }
            StringBuilder __tmp30 = new StringBuilder();
            __tmp30.Append(CSharpName(cls.MetaModel, ModelKind.ImmutableInstance, true));
            using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
            {
                bool __tmp30_last = __tmp30Reader.EndOfStream;
                while(!__tmp30_last)
                {
                    string __tmp30_line = __tmp30Reader.ReadLine();
                    __tmp30_last = __tmp30Reader.EndOfStream;
                    if ((__tmp30_last && !string.IsNullOrEmpty(__tmp30_line)) || (!__tmp30_last && __tmp30_line != null))
                    {
                        __out.Append(__tmp30_line);
                        __tmp28_outputWritten = true;
                    }
                    if (!__tmp30_last) __out.AppendLine(true);
                }
            }
            string __tmp31_line = ".MMetaModel; }"; //1030:77
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Append(__tmp31_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //1030:91
            }
            __out.Append("	}"); //1031:1
            __out.AppendLine(false); //1031:3
            __out.AppendLine(true); //1032:2
            bool __tmp33_outputWritten = false;
            string __tmp34_line = "	public override "; //1033:1
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Append(__tmp34_line);
                __tmp33_outputWritten = true;
            }
            StringBuilder __tmp35 = new StringBuilder();
            __tmp35.Append(metaNs);
            using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
            {
                bool __tmp35_last = __tmp35Reader.EndOfStream;
                while(!__tmp35_last)
                {
                    string __tmp35_line = __tmp35Reader.ReadLine();
                    __tmp35_last = __tmp35Reader.EndOfStream;
                    if ((__tmp35_last && !string.IsNullOrEmpty(__tmp35_line)) || (!__tmp35_last && __tmp35_line != null))
                    {
                        __out.Append(__tmp35_line);
                        __tmp33_outputWritten = true;
                    }
                    if (!__tmp35_last) __out.AppendLine(true);
                }
            }
            string __tmp36_line = "MetaClass MMetaClass"; //1033:26
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Append(__tmp36_line);
                __tmp33_outputWritten = true;
            }
            if (__tmp33_outputWritten) __out.AppendLine(true);
            if (__tmp33_outputWritten)
            {
                __out.AppendLine(false); //1033:46
            }
            __out.Append("	{"); //1034:1
            __out.AppendLine(false); //1034:3
            bool __tmp38_outputWritten = false;
            string __tmp39_line = "		get { return "; //1035:1
            if (!string.IsNullOrEmpty(__tmp39_line))
            {
                __out.Append(__tmp39_line);
                __tmp38_outputWritten = true;
            }
            StringBuilder __tmp40 = new StringBuilder();
            __tmp40.Append(CSharpName(cls, model, ClassKind.ImmutableInstance, true));
            using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
            {
                bool __tmp40_last = __tmp40Reader.EndOfStream;
                while(!__tmp40_last)
                {
                    string __tmp40_line = __tmp40Reader.ReadLine();
                    __tmp40_last = __tmp40Reader.EndOfStream;
                    if ((__tmp40_last && !string.IsNullOrEmpty(__tmp40_line)) || (!__tmp40_last && __tmp40_line != null))
                    {
                        __out.Append(__tmp40_line);
                        __tmp38_outputWritten = true;
                    }
                    if (!__tmp40_last) __out.AppendLine(true);
                }
            }
            string __tmp41_line = "; }"; //1035:74
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Append(__tmp41_line);
                __tmp38_outputWritten = true;
            }
            if (__tmp38_outputWritten) __out.AppendLine(true);
            if (__tmp38_outputWritten)
            {
                __out.AppendLine(false); //1035:77
            }
            __out.Append("	}"); //1036:1
            __out.AppendLine(false); //1036:3
            __out.AppendLine(true); //1037:2
            bool __tmp43_outputWritten = false;
            string __tmp44_line = "	public new "; //1038:1
            if (!string.IsNullOrEmpty(__tmp44_line))
            {
                __out.Append(__tmp44_line);
                __tmp43_outputWritten = true;
            }
            StringBuilder __tmp45 = new StringBuilder();
            __tmp45.Append(CSharpName(cls, model, ClassKind.Builder));
            using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
            {
                bool __tmp45_last = __tmp45Reader.EndOfStream;
                while(!__tmp45_last)
                {
                    string __tmp45_line = __tmp45Reader.ReadLine();
                    __tmp45_last = __tmp45Reader.EndOfStream;
                    if ((__tmp45_last && !string.IsNullOrEmpty(__tmp45_line)) || (!__tmp45_last && __tmp45_line != null))
                    {
                        __out.Append(__tmp45_line);
                        __tmp43_outputWritten = true;
                    }
                    if (!__tmp45_last) __out.AppendLine(true);
                }
            }
            string __tmp46_line = " ToMutable()"; //1038:55
            if (!string.IsNullOrEmpty(__tmp46_line))
            {
                __out.Append(__tmp46_line);
                __tmp43_outputWritten = true;
            }
            if (__tmp43_outputWritten) __out.AppendLine(true);
            if (__tmp43_outputWritten)
            {
                __out.AppendLine(false); //1038:67
            }
            __out.Append("	{"); //1039:1
            __out.AppendLine(false); //1039:3
            bool __tmp48_outputWritten = false;
            string __tmp49_line = "		return ("; //1040:1
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Append(__tmp49_line);
                __tmp48_outputWritten = true;
            }
            StringBuilder __tmp50 = new StringBuilder();
            __tmp50.Append(CSharpName(cls, model, ClassKind.Builder));
            using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
            {
                bool __tmp50_last = __tmp50Reader.EndOfStream;
                while(!__tmp50_last)
                {
                    string __tmp50_line = __tmp50Reader.ReadLine();
                    __tmp50_last = __tmp50Reader.EndOfStream;
                    if ((__tmp50_last && !string.IsNullOrEmpty(__tmp50_line)) || (!__tmp50_last && __tmp50_line != null))
                    {
                        __out.Append(__tmp50_line);
                        __tmp48_outputWritten = true;
                    }
                    if (!__tmp50_last) __out.AppendLine(true);
                }
            }
            string __tmp51_line = ")base.ToMutable();"; //1040:53
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Append(__tmp51_line);
                __tmp48_outputWritten = true;
            }
            if (__tmp48_outputWritten) __out.AppendLine(true);
            if (__tmp48_outputWritten)
            {
                __out.AppendLine(false); //1040:71
            }
            __out.Append("	}"); //1041:1
            __out.AppendLine(false); //1041:3
            __out.AppendLine(true); //1042:2
            bool __tmp53_outputWritten = false;
            string __tmp54_line = "	public new "; //1043:1
            if (!string.IsNullOrEmpty(__tmp54_line))
            {
                __out.Append(__tmp54_line);
                __tmp53_outputWritten = true;
            }
            StringBuilder __tmp55 = new StringBuilder();
            __tmp55.Append(CSharpName(cls, model, ClassKind.Builder));
            using(StreamReader __tmp55Reader = new StreamReader(this.__ToStream(__tmp55.ToString())))
            {
                bool __tmp55_last = __tmp55Reader.EndOfStream;
                while(!__tmp55_last)
                {
                    string __tmp55_line = __tmp55Reader.ReadLine();
                    __tmp55_last = __tmp55Reader.EndOfStream;
                    if ((__tmp55_last && !string.IsNullOrEmpty(__tmp55_line)) || (!__tmp55_last && __tmp55_line != null))
                    {
                        __out.Append(__tmp55_line);
                        __tmp53_outputWritten = true;
                    }
                    if (!__tmp55_last) __out.AppendLine(true);
                }
            }
            string __tmp56_line = " ToMutable("; //1043:55
            if (!string.IsNullOrEmpty(__tmp56_line))
            {
                __out.Append(__tmp56_line);
                __tmp53_outputWritten = true;
            }
            StringBuilder __tmp57 = new StringBuilder();
            __tmp57.Append(Properties.CoreNs);
            using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
            {
                bool __tmp57_last = __tmp57Reader.EndOfStream;
                while(!__tmp57_last)
                {
                    string __tmp57_line = __tmp57Reader.ReadLine();
                    __tmp57_last = __tmp57Reader.EndOfStream;
                    if ((__tmp57_last && !string.IsNullOrEmpty(__tmp57_line)) || (!__tmp57_last && __tmp57_line != null))
                    {
                        __out.Append(__tmp57_line);
                        __tmp53_outputWritten = true;
                    }
                    if (!__tmp57_last) __out.AppendLine(true);
                }
            }
            string __tmp58_line = ".MutableModel model)"; //1043:85
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Append(__tmp58_line);
                __tmp53_outputWritten = true;
            }
            if (__tmp53_outputWritten) __out.AppendLine(true);
            if (__tmp53_outputWritten)
            {
                __out.AppendLine(false); //1043:105
            }
            __out.Append("	{"); //1044:1
            __out.AppendLine(false); //1044:3
            bool __tmp60_outputWritten = false;
            string __tmp61_line = "		return ("; //1045:1
            if (!string.IsNullOrEmpty(__tmp61_line))
            {
                __out.Append(__tmp61_line);
                __tmp60_outputWritten = true;
            }
            StringBuilder __tmp62 = new StringBuilder();
            __tmp62.Append(CSharpName(cls, model, ClassKind.Builder));
            using(StreamReader __tmp62Reader = new StreamReader(this.__ToStream(__tmp62.ToString())))
            {
                bool __tmp62_last = __tmp62Reader.EndOfStream;
                while(!__tmp62_last)
                {
                    string __tmp62_line = __tmp62Reader.ReadLine();
                    __tmp62_last = __tmp62Reader.EndOfStream;
                    if ((__tmp62_last && !string.IsNullOrEmpty(__tmp62_line)) || (!__tmp62_last && __tmp62_line != null))
                    {
                        __out.Append(__tmp62_line);
                        __tmp60_outputWritten = true;
                    }
                    if (!__tmp62_last) __out.AppendLine(true);
                }
            }
            string __tmp63_line = ")base.ToMutable(model);"; //1045:53
            if (!string.IsNullOrEmpty(__tmp63_line))
            {
                __out.Append(__tmp63_line);
                __tmp60_outputWritten = true;
            }
            if (__tmp60_outputWritten) __out.AppendLine(true);
            if (__tmp60_outputWritten)
            {
                __out.AppendLine(false); //1045:76
            }
            __out.Append("	}"); //1046:1
            __out.AppendLine(false); //1046:3
            var __loop63_results = 
                (from __loop63_var1 in __Enumerate((cls).GetEnumerator()) //1047:8
                from sup in __Enumerate((__loop63_var1.GetAllSuperClasses(false)).GetEnumerator()) //1047:13
                select new { __loop63_var1 = __loop63_var1, sup = sup}
                ).ToList(); //1047:3
            for (int __loop63_iteration = 0; __loop63_iteration < __loop63_results.Count; ++__loop63_iteration)
            {
                var __tmp64 = __loop63_results[__loop63_iteration];
                var __loop63_var1 = __tmp64.__loop63_var1;
                var sup = __tmp64.sup;
                __out.AppendLine(true); //1048:2
                bool __tmp66_outputWritten = false;
                string __tmp65Prefix = "	"; //1049:1
                StringBuilder __tmp67 = new StringBuilder();
                __tmp67.Append(CSharpName(sup, model, ClassKind.Builder, true));
                using(StreamReader __tmp67Reader = new StreamReader(this.__ToStream(__tmp67.ToString())))
                {
                    bool __tmp67_last = __tmp67Reader.EndOfStream;
                    while(!__tmp67_last)
                    {
                        string __tmp67_line = __tmp67Reader.ReadLine();
                        __tmp67_last = __tmp67Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp65Prefix))
                        {
                            __out.Append(__tmp65Prefix);
                            __tmp66_outputWritten = true;
                        }
                        if ((__tmp67_last && !string.IsNullOrEmpty(__tmp67_line)) || (!__tmp67_last && __tmp67_line != null))
                        {
                            __out.Append(__tmp67_line);
                            __tmp66_outputWritten = true;
                        }
                        if (!__tmp67_last) __out.AppendLine(true);
                    }
                }
                string __tmp68_line = " "; //1049:50
                if (!string.IsNullOrEmpty(__tmp68_line))
                {
                    __out.Append(__tmp68_line);
                    __tmp66_outputWritten = true;
                }
                StringBuilder __tmp69 = new StringBuilder();
                __tmp69.Append(CSharpName(sup, model, ClassKind.Immutable, true));
                using(StreamReader __tmp69Reader = new StreamReader(this.__ToStream(__tmp69.ToString())))
                {
                    bool __tmp69_last = __tmp69Reader.EndOfStream;
                    while(!__tmp69_last)
                    {
                        string __tmp69_line = __tmp69Reader.ReadLine();
                        __tmp69_last = __tmp69Reader.EndOfStream;
                        if ((__tmp69_last && !string.IsNullOrEmpty(__tmp69_line)) || (!__tmp69_last && __tmp69_line != null))
                        {
                            __out.Append(__tmp69_line);
                            __tmp66_outputWritten = true;
                        }
                        if (!__tmp69_last) __out.AppendLine(true);
                    }
                }
                string __tmp70_line = ".ToMutable()"; //1049:101
                if (!string.IsNullOrEmpty(__tmp70_line))
                {
                    __out.Append(__tmp70_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //1049:113
                }
                __out.Append("	{"); //1050:1
                __out.AppendLine(false); //1050:3
                __out.Append("		return this.ToMutable();"); //1051:1
                __out.AppendLine(false); //1051:27
                __out.Append("	}"); //1052:1
                __out.AppendLine(false); //1052:3
                __out.AppendLine(true); //1053:2
                bool __tmp72_outputWritten = false;
                string __tmp71Prefix = "	"; //1054:1
                StringBuilder __tmp73 = new StringBuilder();
                __tmp73.Append(CSharpName(sup, model, ClassKind.Builder, true));
                using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
                {
                    bool __tmp73_last = __tmp73Reader.EndOfStream;
                    while(!__tmp73_last)
                    {
                        string __tmp73_line = __tmp73Reader.ReadLine();
                        __tmp73_last = __tmp73Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp71Prefix))
                        {
                            __out.Append(__tmp71Prefix);
                            __tmp72_outputWritten = true;
                        }
                        if ((__tmp73_last && !string.IsNullOrEmpty(__tmp73_line)) || (!__tmp73_last && __tmp73_line != null))
                        {
                            __out.Append(__tmp73_line);
                            __tmp72_outputWritten = true;
                        }
                        if (!__tmp73_last) __out.AppendLine(true);
                    }
                }
                string __tmp74_line = " "; //1054:50
                if (!string.IsNullOrEmpty(__tmp74_line))
                {
                    __out.Append(__tmp74_line);
                    __tmp72_outputWritten = true;
                }
                StringBuilder __tmp75 = new StringBuilder();
                __tmp75.Append(CSharpName(sup, model, ClassKind.Immutable, true));
                using(StreamReader __tmp75Reader = new StreamReader(this.__ToStream(__tmp75.ToString())))
                {
                    bool __tmp75_last = __tmp75Reader.EndOfStream;
                    while(!__tmp75_last)
                    {
                        string __tmp75_line = __tmp75Reader.ReadLine();
                        __tmp75_last = __tmp75Reader.EndOfStream;
                        if ((__tmp75_last && !string.IsNullOrEmpty(__tmp75_line)) || (!__tmp75_last && __tmp75_line != null))
                        {
                            __out.Append(__tmp75_line);
                            __tmp72_outputWritten = true;
                        }
                        if (!__tmp75_last) __out.AppendLine(true);
                    }
                }
                string __tmp76_line = ".ToMutable("; //1054:101
                if (!string.IsNullOrEmpty(__tmp76_line))
                {
                    __out.Append(__tmp76_line);
                    __tmp72_outputWritten = true;
                }
                StringBuilder __tmp77 = new StringBuilder();
                __tmp77.Append(Properties.CoreNs);
                using(StreamReader __tmp77Reader = new StreamReader(this.__ToStream(__tmp77.ToString())))
                {
                    bool __tmp77_last = __tmp77Reader.EndOfStream;
                    while(!__tmp77_last)
                    {
                        string __tmp77_line = __tmp77Reader.ReadLine();
                        __tmp77_last = __tmp77Reader.EndOfStream;
                        if ((__tmp77_last && !string.IsNullOrEmpty(__tmp77_line)) || (!__tmp77_last && __tmp77_line != null))
                        {
                            __out.Append(__tmp77_line);
                            __tmp72_outputWritten = true;
                        }
                        if (!__tmp77_last) __out.AppendLine(true);
                    }
                }
                string __tmp78_line = ".MutableModel model)"; //1054:131
                if (!string.IsNullOrEmpty(__tmp78_line))
                {
                    __out.Append(__tmp78_line);
                    __tmp72_outputWritten = true;
                }
                if (__tmp72_outputWritten) __out.AppendLine(true);
                if (__tmp72_outputWritten)
                {
                    __out.AppendLine(false); //1054:151
                }
                __out.Append("	{"); //1055:1
                __out.AppendLine(false); //1055:3
                __out.Append("		return this.ToMutable(model);"); //1056:1
                __out.AppendLine(false); //1056:32
                __out.Append("	}"); //1057:1
                __out.AppendLine(false); //1057:3
            }
            var __loop64_results = 
                (from __loop64_var1 in __Enumerate((cls).GetEnumerator()) //1059:8
                from prop in __Enumerate((__loop64_var1.GetAllProperties()).GetEnumerator()) //1059:13
                select new { __loop64_var1 = __loop64_var1, prop = prop}
                ).ToList(); //1059:3
            for (int __loop64_iteration = 0; __loop64_iteration < __loop64_results.Count; ++__loop64_iteration)
            {
                var __tmp79 = __loop64_results[__loop64_iteration];
                var __loop64_var1 = __tmp79.__loop64_var1;
                var prop = __tmp79.prop;
                __out.AppendLine(true); //1060:2
                bool __tmp81_outputWritten = false;
                string __tmp80Prefix = "	"; //1061:1
                StringBuilder __tmp82 = new StringBuilder();
                __tmp82.Append(GenerateImmutablePropertyImpl(model, cls, prop));
                using(StreamReader __tmp82Reader = new StreamReader(this.__ToStream(__tmp82.ToString())))
                {
                    bool __tmp82_last = __tmp82Reader.EndOfStream;
                    while(!__tmp82_last)
                    {
                        string __tmp82_line = __tmp82Reader.ReadLine();
                        __tmp82_last = __tmp82Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp80Prefix))
                        {
                            __out.Append(__tmp80Prefix);
                            __tmp81_outputWritten = true;
                        }
                        if ((__tmp82_last && !string.IsNullOrEmpty(__tmp82_line)) || (!__tmp82_last && __tmp82_line != null))
                        {
                            __out.Append(__tmp82_line);
                            __tmp81_outputWritten = true;
                        }
                        if (!__tmp82_last || __tmp81_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp81_outputWritten)
                {
                    __out.AppendLine(false); //1061:51
                }
            }
            var __loop65_results = 
                (from __loop65_var1 in __Enumerate((cls).GetEnumerator()) //1063:8
                from op in __Enumerate((__loop65_var1.GetAllOperations()).GetEnumerator()) //1063:13
                where !op.IsBuilder //1063:35
                select new { __loop65_var1 = __loop65_var1, op = op}
                ).ToList(); //1063:3
            for (int __loop65_iteration = 0; __loop65_iteration < __loop65_results.Count; ++__loop65_iteration)
            {
                var __tmp83 = __loop65_results[__loop65_iteration];
                var __loop65_var1 = __tmp83.__loop65_var1;
                var op = __tmp83.op;
                __out.AppendLine(true); //1064:2
                bool __tmp85_outputWritten = false;
                string __tmp84Prefix = "	"; //1065:1
                StringBuilder __tmp86 = new StringBuilder();
                __tmp86.Append(GenerateImmutableOperationImpl(model, cls, op));
                using(StreamReader __tmp86Reader = new StreamReader(this.__ToStream(__tmp86.ToString())))
                {
                    bool __tmp86_last = __tmp86Reader.EndOfStream;
                    while(!__tmp86_last)
                    {
                        string __tmp86_line = __tmp86Reader.ReadLine();
                        __tmp86_last = __tmp86Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp84Prefix))
                        {
                            __out.Append(__tmp84Prefix);
                            __tmp85_outputWritten = true;
                        }
                        if ((__tmp86_last && !string.IsNullOrEmpty(__tmp86_line)) || (!__tmp86_last && __tmp86_line != null))
                        {
                            __out.Append(__tmp86_line);
                            __tmp85_outputWritten = true;
                        }
                        if (!__tmp86_last || __tmp85_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp85_outputWritten)
                {
                    __out.AppendLine(false); //1065:50
                }
            }
            if (metaMetaModel && cls.Name == "MetaModel") //1068:3
            {
                bool __tmp88_outputWritten = false;
                string __tmp87Prefix = "	"; //1069:1
                StringBuilder __tmp89 = new StringBuilder();
                __tmp89.Append(Properties.CoreNs);
                using(StreamReader __tmp89Reader = new StreamReader(this.__ToStream(__tmp89.ToString())))
                {
                    bool __tmp89_last = __tmp89Reader.EndOfStream;
                    while(!__tmp89_last)
                    {
                        string __tmp89_line = __tmp89Reader.ReadLine();
                        __tmp89_last = __tmp89Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp87Prefix))
                        {
                            __out.Append(__tmp87Prefix);
                            __tmp88_outputWritten = true;
                        }
                        if ((__tmp89_last && !string.IsNullOrEmpty(__tmp89_line)) || (!__tmp89_last && __tmp89_line != null))
                        {
                            __out.Append(__tmp89_line);
                            __tmp88_outputWritten = true;
                        }
                        if (!__tmp89_last) __out.AppendLine(true);
                    }
                }
                string __tmp90_line = ".ModelId "; //1069:21
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Append(__tmp90_line);
                    __tmp88_outputWritten = true;
                }
                StringBuilder __tmp91 = new StringBuilder();
                __tmp91.Append(Properties.CoreNs);
                using(StreamReader __tmp91Reader = new StreamReader(this.__ToStream(__tmp91.ToString())))
                {
                    bool __tmp91_last = __tmp91Reader.EndOfStream;
                    while(!__tmp91_last)
                    {
                        string __tmp91_line = __tmp91Reader.ReadLine();
                        __tmp91_last = __tmp91Reader.EndOfStream;
                        if ((__tmp91_last && !string.IsNullOrEmpty(__tmp91_line)) || (!__tmp91_last && __tmp91_line != null))
                        {
                            __out.Append(__tmp91_line);
                            __tmp88_outputWritten = true;
                        }
                        if (!__tmp91_last) __out.AppendLine(true);
                    }
                }
                string __tmp92_line = ".IModel.Id => "; //1069:49
                if (!string.IsNullOrEmpty(__tmp92_line))
                {
                    __out.Append(__tmp92_line);
                    __tmp88_outputWritten = true;
                }
                StringBuilder __tmp93 = new StringBuilder();
                __tmp93.Append(CSharpName(model, ModelKind.ImmutableInstance));
                using(StreamReader __tmp93Reader = new StreamReader(this.__ToStream(__tmp93.ToString())))
                {
                    bool __tmp93_last = __tmp93Reader.EndOfStream;
                    while(!__tmp93_last)
                    {
                        string __tmp93_line = __tmp93Reader.ReadLine();
                        __tmp93_last = __tmp93Reader.EndOfStream;
                        if ((__tmp93_last && !string.IsNullOrEmpty(__tmp93_line)) || (!__tmp93_last && __tmp93_line != null))
                        {
                            __out.Append(__tmp93_line);
                            __tmp88_outputWritten = true;
                        }
                        if (!__tmp93_last) __out.AppendLine(true);
                    }
                }
                string __tmp94_line = ".MModel.Id;"; //1069:110
                if (!string.IsNullOrEmpty(__tmp94_line))
                {
                    __out.Append(__tmp94_line);
                    __tmp88_outputWritten = true;
                }
                if (__tmp88_outputWritten) __out.AppendLine(true);
                if (__tmp88_outputWritten)
                {
                    __out.AppendLine(false); //1069:121
                }
                bool __tmp96_outputWritten = false;
                string __tmp97_line = "	string "; //1070:1
                if (!string.IsNullOrEmpty(__tmp97_line))
                {
                    __out.Append(__tmp97_line);
                    __tmp96_outputWritten = true;
                }
                StringBuilder __tmp98 = new StringBuilder();
                __tmp98.Append(Properties.CoreNs);
                using(StreamReader __tmp98Reader = new StreamReader(this.__ToStream(__tmp98.ToString())))
                {
                    bool __tmp98_last = __tmp98Reader.EndOfStream;
                    while(!__tmp98_last)
                    {
                        string __tmp98_line = __tmp98Reader.ReadLine();
                        __tmp98_last = __tmp98Reader.EndOfStream;
                        if ((__tmp98_last && !string.IsNullOrEmpty(__tmp98_line)) || (!__tmp98_last && __tmp98_line != null))
                        {
                            __out.Append(__tmp98_line);
                            __tmp96_outputWritten = true;
                        }
                        if (!__tmp98_last) __out.AppendLine(true);
                    }
                }
                string __tmp99_line = ".IModel.Name => this.Name;"; //1070:28
                if (!string.IsNullOrEmpty(__tmp99_line))
                {
                    __out.Append(__tmp99_line);
                    __tmp96_outputWritten = true;
                }
                if (__tmp96_outputWritten) __out.AppendLine(true);
                if (__tmp96_outputWritten)
                {
                    __out.AppendLine(false); //1070:54
                }
                bool __tmp101_outputWritten = false;
                string __tmp100Prefix = "	"; //1071:1
                StringBuilder __tmp102 = new StringBuilder();
                __tmp102.Append(Properties.CoreNs);
                using(StreamReader __tmp102Reader = new StreamReader(this.__ToStream(__tmp102.ToString())))
                {
                    bool __tmp102_last = __tmp102Reader.EndOfStream;
                    while(!__tmp102_last)
                    {
                        string __tmp102_line = __tmp102Reader.ReadLine();
                        __tmp102_last = __tmp102Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp100Prefix))
                        {
                            __out.Append(__tmp100Prefix);
                            __tmp101_outputWritten = true;
                        }
                        if ((__tmp102_last && !string.IsNullOrEmpty(__tmp102_line)) || (!__tmp102_last && __tmp102_line != null))
                        {
                            __out.Append(__tmp102_line);
                            __tmp101_outputWritten = true;
                        }
                        if (!__tmp102_last) __out.AppendLine(true);
                    }
                }
                string __tmp103_line = ".ModelVersion "; //1071:21
                if (!string.IsNullOrEmpty(__tmp103_line))
                {
                    __out.Append(__tmp103_line);
                    __tmp101_outputWritten = true;
                }
                StringBuilder __tmp104 = new StringBuilder();
                __tmp104.Append(Properties.CoreNs);
                using(StreamReader __tmp104Reader = new StreamReader(this.__ToStream(__tmp104.ToString())))
                {
                    bool __tmp104_last = __tmp104Reader.EndOfStream;
                    while(!__tmp104_last)
                    {
                        string __tmp104_line = __tmp104Reader.ReadLine();
                        __tmp104_last = __tmp104Reader.EndOfStream;
                        if ((__tmp104_last && !string.IsNullOrEmpty(__tmp104_line)) || (!__tmp104_last && __tmp104_line != null))
                        {
                            __out.Append(__tmp104_line);
                            __tmp101_outputWritten = true;
                        }
                        if (!__tmp104_last) __out.AppendLine(true);
                    }
                }
                string __tmp105_line = ".IModel.Version => "; //1071:54
                if (!string.IsNullOrEmpty(__tmp105_line))
                {
                    __out.Append(__tmp105_line);
                    __tmp101_outputWritten = true;
                }
                StringBuilder __tmp106 = new StringBuilder();
                __tmp106.Append(CSharpName(model, ModelKind.ImmutableInstance));
                using(StreamReader __tmp106Reader = new StreamReader(this.__ToStream(__tmp106.ToString())))
                {
                    bool __tmp106_last = __tmp106Reader.EndOfStream;
                    while(!__tmp106_last)
                    {
                        string __tmp106_line = __tmp106Reader.ReadLine();
                        __tmp106_last = __tmp106Reader.EndOfStream;
                        if ((__tmp106_last && !string.IsNullOrEmpty(__tmp106_line)) || (!__tmp106_last && __tmp106_line != null))
                        {
                            __out.Append(__tmp106_line);
                            __tmp101_outputWritten = true;
                        }
                        if (!__tmp106_last) __out.AppendLine(true);
                    }
                }
                string __tmp107_line = ".MModel.Version;"; //1071:120
                if (!string.IsNullOrEmpty(__tmp107_line))
                {
                    __out.Append(__tmp107_line);
                    __tmp101_outputWritten = true;
                }
                if (__tmp101_outputWritten) __out.AppendLine(true);
                if (__tmp101_outputWritten)
                {
                    __out.AppendLine(false); //1071:136
                }
                bool __tmp109_outputWritten = false;
                string __tmp110_line = "	global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> "; //1072:1
                if (!string.IsNullOrEmpty(__tmp110_line))
                {
                    __out.Append(__tmp110_line);
                    __tmp109_outputWritten = true;
                }
                StringBuilder __tmp111 = new StringBuilder();
                __tmp111.Append(Properties.CoreNs);
                using(StreamReader __tmp111Reader = new StreamReader(this.__ToStream(__tmp111.ToString())))
                {
                    bool __tmp111_last = __tmp111Reader.EndOfStream;
                    while(!__tmp111_last)
                    {
                        string __tmp111_line = __tmp111Reader.ReadLine();
                        __tmp111_last = __tmp111Reader.EndOfStream;
                        if ((__tmp111_last && !string.IsNullOrEmpty(__tmp111_line)) || (!__tmp111_last && __tmp111_line != null))
                        {
                            __out.Append(__tmp111_line);
                            __tmp109_outputWritten = true;
                        }
                        if (!__tmp111_last) __out.AppendLine(true);
                    }
                }
                string __tmp112_line = ".IModel.Objects => "; //1072:108
                if (!string.IsNullOrEmpty(__tmp112_line))
                {
                    __out.Append(__tmp112_line);
                    __tmp109_outputWritten = true;
                }
                StringBuilder __tmp113 = new StringBuilder();
                __tmp113.Append(CSharpName(model, ModelKind.ImmutableInstance));
                using(StreamReader __tmp113Reader = new StreamReader(this.__ToStream(__tmp113.ToString())))
                {
                    bool __tmp113_last = __tmp113Reader.EndOfStream;
                    while(!__tmp113_last)
                    {
                        string __tmp113_line = __tmp113Reader.ReadLine();
                        __tmp113_last = __tmp113Reader.EndOfStream;
                        if ((__tmp113_last && !string.IsNullOrEmpty(__tmp113_line)) || (!__tmp113_last && __tmp113_line != null))
                        {
                            __out.Append(__tmp113_line);
                            __tmp109_outputWritten = true;
                        }
                        if (!__tmp113_last) __out.AppendLine(true);
                    }
                }
                string __tmp114_line = ".MModel.Objects;"; //1072:174
                if (!string.IsNullOrEmpty(__tmp114_line))
                {
                    __out.Append(__tmp114_line);
                    __tmp109_outputWritten = true;
                }
                if (__tmp109_outputWritten) __out.AppendLine(true);
                if (__tmp109_outputWritten)
                {
                    __out.AppendLine(false); //1072:190
                }
                bool __tmp116_outputWritten = false;
                string __tmp117_line = "	string "; //1073:1
                if (!string.IsNullOrEmpty(__tmp117_line))
                {
                    __out.Append(__tmp117_line);
                    __tmp116_outputWritten = true;
                }
                StringBuilder __tmp118 = new StringBuilder();
                __tmp118.Append(Properties.CoreNs);
                using(StreamReader __tmp118Reader = new StreamReader(this.__ToStream(__tmp118.ToString())))
                {
                    bool __tmp118_last = __tmp118Reader.EndOfStream;
                    while(!__tmp118_last)
                    {
                        string __tmp118_line = __tmp118Reader.ReadLine();
                        __tmp118_last = __tmp118Reader.EndOfStream;
                        if ((__tmp118_last && !string.IsNullOrEmpty(__tmp118_line)) || (!__tmp118_last && __tmp118_line != null))
                        {
                            __out.Append(__tmp118_line);
                            __tmp116_outputWritten = true;
                        }
                        if (!__tmp118_last) __out.AppendLine(true);
                    }
                }
                string __tmp119_line = ".IMetaModel.Uri => this.Uri;"; //1073:28
                if (!string.IsNullOrEmpty(__tmp119_line))
                {
                    __out.Append(__tmp119_line);
                    __tmp116_outputWritten = true;
                }
                if (__tmp116_outputWritten) __out.AppendLine(true);
                if (__tmp116_outputWritten)
                {
                    __out.AppendLine(false); //1073:56
                }
                bool __tmp121_outputWritten = false;
                string __tmp122_line = "	string "; //1074:1
                if (!string.IsNullOrEmpty(__tmp122_line))
                {
                    __out.Append(__tmp122_line);
                    __tmp121_outputWritten = true;
                }
                StringBuilder __tmp123 = new StringBuilder();
                __tmp123.Append(Properties.CoreNs);
                using(StreamReader __tmp123Reader = new StreamReader(this.__ToStream(__tmp123.ToString())))
                {
                    bool __tmp123_last = __tmp123Reader.EndOfStream;
                    while(!__tmp123_last)
                    {
                        string __tmp123_line = __tmp123Reader.ReadLine();
                        __tmp123_last = __tmp123Reader.EndOfStream;
                        if ((__tmp123_last && !string.IsNullOrEmpty(__tmp123_line)) || (!__tmp123_last && __tmp123_line != null))
                        {
                            __out.Append(__tmp123_line);
                            __tmp121_outputWritten = true;
                        }
                        if (!__tmp123_last) __out.AppendLine(true);
                    }
                }
                string __tmp124_line = ".IMetaModel.Prefix => this.Prefix;"; //1074:28
                if (!string.IsNullOrEmpty(__tmp124_line))
                {
                    __out.Append(__tmp124_line);
                    __tmp121_outputWritten = true;
                }
                if (__tmp121_outputWritten) __out.AppendLine(true);
                if (__tmp121_outputWritten)
                {
                    __out.AppendLine(false); //1074:62
                }
                bool __tmp126_outputWritten = false;
                string __tmp125Prefix = "	"; //1075:1
                StringBuilder __tmp127 = new StringBuilder();
                __tmp127.Append(Properties.CoreNs);
                using(StreamReader __tmp127Reader = new StreamReader(this.__ToStream(__tmp127.ToString())))
                {
                    bool __tmp127_last = __tmp127Reader.EndOfStream;
                    while(!__tmp127_last)
                    {
                        string __tmp127_line = __tmp127Reader.ReadLine();
                        __tmp127_last = __tmp127Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp125Prefix))
                        {
                            __out.Append(__tmp125Prefix);
                            __tmp126_outputWritten = true;
                        }
                        if ((__tmp127_last && !string.IsNullOrEmpty(__tmp127_line)) || (!__tmp127_last && __tmp127_line != null))
                        {
                            __out.Append(__tmp127_line);
                            __tmp126_outputWritten = true;
                        }
                        if (!__tmp127_last) __out.AppendLine(true);
                    }
                }
                string __tmp128_line = ".IModelGroup "; //1075:21
                if (!string.IsNullOrEmpty(__tmp128_line))
                {
                    __out.Append(__tmp128_line);
                    __tmp126_outputWritten = true;
                }
                StringBuilder __tmp129 = new StringBuilder();
                __tmp129.Append(Properties.CoreNs);
                using(StreamReader __tmp129Reader = new StreamReader(this.__ToStream(__tmp129.ToString())))
                {
                    bool __tmp129_last = __tmp129Reader.EndOfStream;
                    while(!__tmp129_last)
                    {
                        string __tmp129_line = __tmp129Reader.ReadLine();
                        __tmp129_last = __tmp129Reader.EndOfStream;
                        if ((__tmp129_last && !string.IsNullOrEmpty(__tmp129_line)) || (!__tmp129_last && __tmp129_line != null))
                        {
                            __out.Append(__tmp129_line);
                            __tmp126_outputWritten = true;
                        }
                        if (!__tmp129_last) __out.AppendLine(true);
                    }
                }
                string __tmp130_line = ".IModel.ModelGroup => "; //1075:53
                if (!string.IsNullOrEmpty(__tmp130_line))
                {
                    __out.Append(__tmp130_line);
                    __tmp126_outputWritten = true;
                }
                StringBuilder __tmp131 = new StringBuilder();
                __tmp131.Append(CSharpName(model, ModelKind.ImmutableInstance));
                using(StreamReader __tmp131Reader = new StreamReader(this.__ToStream(__tmp131.ToString())))
                {
                    bool __tmp131_last = __tmp131Reader.EndOfStream;
                    while(!__tmp131_last)
                    {
                        string __tmp131_line = __tmp131Reader.ReadLine();
                        __tmp131_last = __tmp131Reader.EndOfStream;
                        if ((__tmp131_last && !string.IsNullOrEmpty(__tmp131_line)) || (!__tmp131_last && __tmp131_line != null))
                        {
                            __out.Append(__tmp131_line);
                            __tmp126_outputWritten = true;
                        }
                        if (!__tmp131_last) __out.AppendLine(true);
                    }
                }
                string __tmp132_line = ".MModel.ModelGroup;"; //1075:122
                if (!string.IsNullOrEmpty(__tmp132_line))
                {
                    __out.Append(__tmp132_line);
                    __tmp126_outputWritten = true;
                }
                if (__tmp126_outputWritten) __out.AppendLine(true);
                if (__tmp126_outputWritten)
                {
                    __out.AppendLine(false); //1075:141
                }
                bool __tmp134_outputWritten = false;
                string __tmp135_line = "	string "; //1076:1
                if (!string.IsNullOrEmpty(__tmp135_line))
                {
                    __out.Append(__tmp135_line);
                    __tmp134_outputWritten = true;
                }
                StringBuilder __tmp136 = new StringBuilder();
                __tmp136.Append(Properties.CoreNs);
                using(StreamReader __tmp136Reader = new StreamReader(this.__ToStream(__tmp136.ToString())))
                {
                    bool __tmp136_last = __tmp136Reader.EndOfStream;
                    while(!__tmp136_last)
                    {
                        string __tmp136_line = __tmp136Reader.ReadLine();
                        __tmp136_last = __tmp136Reader.EndOfStream;
                        if ((__tmp136_last && !string.IsNullOrEmpty(__tmp136_line)) || (!__tmp136_last && __tmp136_line != null))
                        {
                            __out.Append(__tmp136_line);
                            __tmp134_outputWritten = true;
                        }
                        if (!__tmp136_last) __out.AppendLine(true);
                    }
                }
                string __tmp137_line = ".IMetaModel.Namespace => this.Namespace.FullName;"; //1076:28
                if (!string.IsNullOrEmpty(__tmp137_line))
                {
                    __out.Append(__tmp137_line);
                    __tmp134_outputWritten = true;
                }
                if (__tmp134_outputWritten) __out.AppendLine(true);
                if (__tmp134_outputWritten)
                {
                    __out.AppendLine(false); //1076:77
                }
                __out.AppendLine(true); //1077:1
                bool __tmp139_outputWritten = false;
                string __tmp140_line = "	public "; //1078:1
                if (!string.IsNullOrEmpty(__tmp140_line))
                {
                    __out.Append(__tmp140_line);
                    __tmp139_outputWritten = true;
                }
                StringBuilder __tmp141 = new StringBuilder();
                __tmp141.Append(Properties.CoreNs);
                using(StreamReader __tmp141Reader = new StreamReader(this.__ToStream(__tmp141.ToString())))
                {
                    bool __tmp141_last = __tmp141Reader.EndOfStream;
                    while(!__tmp141_last)
                    {
                        string __tmp141_line = __tmp141Reader.ReadLine();
                        __tmp141_last = __tmp141Reader.EndOfStream;
                        if ((__tmp141_last && !string.IsNullOrEmpty(__tmp141_line)) || (!__tmp141_last && __tmp141_line != null))
                        {
                            __out.Append(__tmp141_line);
                            __tmp139_outputWritten = true;
                        }
                        if (!__tmp141_last) __out.AppendLine(true);
                    }
                }
                string __tmp142_line = ".IModelFactory CreateFactory("; //1078:28
                if (!string.IsNullOrEmpty(__tmp142_line))
                {
                    __out.Append(__tmp142_line);
                    __tmp139_outputWritten = true;
                }
                StringBuilder __tmp143 = new StringBuilder();
                __tmp143.Append(Properties.CoreNs);
                using(StreamReader __tmp143Reader = new StreamReader(this.__ToStream(__tmp143.ToString())))
                {
                    bool __tmp143_last = __tmp143Reader.EndOfStream;
                    while(!__tmp143_last)
                    {
                        string __tmp143_line = __tmp143Reader.ReadLine();
                        __tmp143_last = __tmp143Reader.EndOfStream;
                        if ((__tmp143_last && !string.IsNullOrEmpty(__tmp143_line)) || (!__tmp143_last && __tmp143_line != null))
                        {
                            __out.Append(__tmp143_line);
                            __tmp139_outputWritten = true;
                        }
                        if (!__tmp143_last) __out.AppendLine(true);
                    }
                }
                string __tmp144_line = ".MutableModel model, "; //1078:76
                if (!string.IsNullOrEmpty(__tmp144_line))
                {
                    __out.Append(__tmp144_line);
                    __tmp139_outputWritten = true;
                }
                StringBuilder __tmp145 = new StringBuilder();
                __tmp145.Append(Properties.CoreNs);
                using(StreamReader __tmp145Reader = new StreamReader(this.__ToStream(__tmp145.ToString())))
                {
                    bool __tmp145_last = __tmp145Reader.EndOfStream;
                    while(!__tmp145_last)
                    {
                        string __tmp145_line = __tmp145Reader.ReadLine();
                        __tmp145_last = __tmp145Reader.EndOfStream;
                        if ((__tmp145_last && !string.IsNullOrEmpty(__tmp145_line)) || (!__tmp145_last && __tmp145_line != null))
                        {
                            __out.Append(__tmp145_line);
                            __tmp139_outputWritten = true;
                        }
                        if (!__tmp145_last) __out.AppendLine(true);
                    }
                }
                string __tmp146_line = ".ModelFactoryFlags flags = "; //1078:116
                if (!string.IsNullOrEmpty(__tmp146_line))
                {
                    __out.Append(__tmp146_line);
                    __tmp139_outputWritten = true;
                }
                StringBuilder __tmp147 = new StringBuilder();
                __tmp147.Append(Properties.CoreNs);
                using(StreamReader __tmp147Reader = new StreamReader(this.__ToStream(__tmp147.ToString())))
                {
                    bool __tmp147_last = __tmp147Reader.EndOfStream;
                    while(!__tmp147_last)
                    {
                        string __tmp147_line = __tmp147Reader.ReadLine();
                        __tmp147_last = __tmp147Reader.EndOfStream;
                        if ((__tmp147_last && !string.IsNullOrEmpty(__tmp147_line)) || (!__tmp147_last && __tmp147_line != null))
                        {
                            __out.Append(__tmp147_line);
                            __tmp139_outputWritten = true;
                        }
                        if (!__tmp147_last) __out.AppendLine(true);
                    }
                }
                string __tmp148_line = ".ModelFactoryFlags.None)"; //1078:162
                if (!string.IsNullOrEmpty(__tmp148_line))
                {
                    __out.Append(__tmp148_line);
                    __tmp139_outputWritten = true;
                }
                if (__tmp139_outputWritten) __out.AppendLine(true);
                if (__tmp139_outputWritten)
                {
                    __out.AppendLine(false); //1078:186
                }
                __out.Append("	{"); //1079:1
                __out.AppendLine(false); //1079:3
                bool __tmp150_outputWritten = false;
                string __tmp151_line = "		return new "; //1080:1
                if (!string.IsNullOrEmpty(__tmp151_line))
                {
                    __out.Append(__tmp151_line);
                    __tmp150_outputWritten = true;
                }
                StringBuilder __tmp152 = new StringBuilder();
                __tmp152.Append(CSharpName(model, ModelKind.Factory));
                using(StreamReader __tmp152Reader = new StreamReader(this.__ToStream(__tmp152.ToString())))
                {
                    bool __tmp152_last = __tmp152Reader.EndOfStream;
                    while(!__tmp152_last)
                    {
                        string __tmp152_line = __tmp152Reader.ReadLine();
                        __tmp152_last = __tmp152Reader.EndOfStream;
                        if ((__tmp152_last && !string.IsNullOrEmpty(__tmp152_line)) || (!__tmp152_last && __tmp152_line != null))
                        {
                            __out.Append(__tmp152_line);
                            __tmp150_outputWritten = true;
                        }
                        if (!__tmp152_last) __out.AppendLine(true);
                    }
                }
                string __tmp153_line = "(model, flags);"; //1080:51
                if (!string.IsNullOrEmpty(__tmp153_line))
                {
                    __out.Append(__tmp153_line);
                    __tmp150_outputWritten = true;
                }
                if (__tmp150_outputWritten) __out.AppendLine(true);
                if (__tmp150_outputWritten)
                {
                    __out.AppendLine(false); //1080:66
                }
                __out.Append("	}"); //1081:1
                __out.AppendLine(false); //1081:3
            }
            __out.Append("}"); //1083:1
            __out.AppendLine(false); //1083:2
            return __out.ToString();
        }

        public string GenerateImmutableField(MetaModel model, MetaClass cls, MetaProperty prop) //1086:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3_line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                    {
                        __out.Append(__tmp3_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp3_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1087:54
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "private "; //1088:1
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Append(__tmp6_line);
                __tmp5_outputWritten = true;
            }
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(CSharpName(prop.Type, model, ClassKind.Immutable, true));
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(!__tmp7_last)
                {
                    string __tmp7_line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if ((__tmp7_last && !string.IsNullOrEmpty(__tmp7_line)) || (!__tmp7_last && __tmp7_line != null))
                    {
                        __out.Append(__tmp7_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            string __tmp8_line = " "; //1088:65
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Append(__tmp8_line);
                __tmp5_outputWritten = true;
            }
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(GetFieldName(prop, cls));
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9_line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if ((__tmp9_last && !string.IsNullOrEmpty(__tmp9_line)) || (!__tmp9_last && __tmp9_line != null))
                    {
                        __out.Append(__tmp9_line);
                        __tmp5_outputWritten = true;
                    }
                    if (!__tmp9_last) __out.AppendLine(true);
                }
            }
            string __tmp10_line = ";"; //1088:90
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //1088:91
            }
            return __out.ToString();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //1091:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1092:1
            if (cls.GetAllFinalProperties().Contains(prop)) //1093:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //1094:1
                if (!string.IsNullOrEmpty(__tmp3_line))
                {
                    __out.Append(__tmp3_line);
                    __tmp2_outputWritten = true;
                }
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(CSharpName(prop.Type, model, ClassKind.Immutable, true));
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(!__tmp4_last)
                    {
                        string __tmp4_line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                        {
                            __out.Append(__tmp4_line);
                            __tmp2_outputWritten = true;
                        }
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
                string __tmp5_line = " "; //1094:64
                if (!string.IsNullOrEmpty(__tmp5_line))
                {
                    __out.Append(__tmp5_line);
                    __tmp2_outputWritten = true;
                }
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append(prop.Name);
                using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                {
                    bool __tmp6_last = __tmp6Reader.EndOfStream;
                    while(!__tmp6_last)
                    {
                        string __tmp6_line = __tmp6Reader.ReadLine();
                        __tmp6_last = __tmp6Reader.EndOfStream;
                        if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                        {
                            __out.Append(__tmp6_line);
                            __tmp2_outputWritten = true;
                        }
                        if (!__tmp6_last || __tmp2_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //1094:76
                }
            }
            else //1095:2
            {
                bool __tmp8_outputWritten = false;
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(!__tmp9_last)
                    {
                        string __tmp9_line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if ((__tmp9_last && !string.IsNullOrEmpty(__tmp9_line)) || (!__tmp9_last && __tmp9_line != null))
                        {
                            __out.Append(__tmp9_line);
                            __tmp8_outputWritten = true;
                        }
                        if (!__tmp9_last || __tmp8_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp8_outputWritten)
                {
                    __out.AppendLine(false); //1096:54
                }
                bool __tmp11_outputWritten = false;
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(CSharpName(prop.Type, model, ClassKind.Immutable, true));
                using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                {
                    bool __tmp12_last = __tmp12Reader.EndOfStream;
                    while(!__tmp12_last)
                    {
                        string __tmp12_line = __tmp12Reader.ReadLine();
                        __tmp12_last = __tmp12Reader.EndOfStream;
                        if ((__tmp12_last && !string.IsNullOrEmpty(__tmp12_line)) || (!__tmp12_last && __tmp12_line != null))
                        {
                            __out.Append(__tmp12_line);
                            __tmp11_outputWritten = true;
                        }
                        if (!__tmp12_last) __out.AppendLine(true);
                    }
                }
                string __tmp13_line = " "; //1097:57
                if (!string.IsNullOrEmpty(__tmp13_line))
                {
                    __out.Append(__tmp13_line);
                    __tmp11_outputWritten = true;
                }
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(CSharpName(prop.Class, model, ClassKind.Immutable, true));
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_last = __tmp14Reader.EndOfStream;
                    while(!__tmp14_last)
                    {
                        string __tmp14_line = __tmp14Reader.ReadLine();
                        __tmp14_last = __tmp14Reader.EndOfStream;
                        if ((__tmp14_last && !string.IsNullOrEmpty(__tmp14_line)) || (!__tmp14_last && __tmp14_line != null))
                        {
                            __out.Append(__tmp14_line);
                            __tmp11_outputWritten = true;
                        }
                        if (!__tmp14_last) __out.AppendLine(true);
                    }
                }
                string __tmp15_line = "."; //1097:115
                if (!string.IsNullOrEmpty(__tmp15_line))
                {
                    __out.Append(__tmp15_line);
                    __tmp11_outputWritten = true;
                }
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(prop.Name);
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_last = __tmp16Reader.EndOfStream;
                    while(!__tmp16_last)
                    {
                        string __tmp16_line = __tmp16Reader.ReadLine();
                        __tmp16_last = __tmp16Reader.EndOfStream;
                        if ((__tmp16_last && !string.IsNullOrEmpty(__tmp16_line)) || (!__tmp16_last && __tmp16_line != null))
                        {
                            __out.Append(__tmp16_line);
                            __tmp11_outputWritten = true;
                        }
                        if (!__tmp16_last || __tmp11_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //1097:127
                }
            }
            __out.Append("{"); //1099:1
            __out.AppendLine(false); //1099:2
            if (prop.Type is MetaCollectionType) //1100:6
            {
                if (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.Set || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet) //1101:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "    get { return this.GetSet<"; //1102:1
                    if (!string.IsNullOrEmpty(__tmp19_line))
                    {
                        __out.Append(__tmp19_line);
                        __tmp18_outputWritten = true;
                    }
                    StringBuilder __tmp20 = new StringBuilder();
                    __tmp20.Append(CSharpName(((MetaCollectionType)prop.Type).InnerType, model, ClassKind.Immutable, true));
                    using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                    {
                        bool __tmp20_last = __tmp20Reader.EndOfStream;
                        while(!__tmp20_last)
                        {
                            string __tmp20_line = __tmp20Reader.ReadLine();
                            __tmp20_last = __tmp20Reader.EndOfStream;
                            if ((__tmp20_last && !string.IsNullOrEmpty(__tmp20_line)) || (!__tmp20_last && __tmp20_line != null))
                            {
                                __out.Append(__tmp20_line);
                                __tmp18_outputWritten = true;
                            }
                            if (!__tmp20_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp21_line = ">("; //1102:118
                    if (!string.IsNullOrEmpty(__tmp21_line))
                    {
                        __out.Append(__tmp21_line);
                        __tmp18_outputWritten = true;
                    }
                    StringBuilder __tmp22 = new StringBuilder();
                    __tmp22.Append(CSharpName(prop, null, PropertyKind.Descriptor, true));
                    using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                    {
                        bool __tmp22_last = __tmp22Reader.EndOfStream;
                        while(!__tmp22_last)
                        {
                            string __tmp22_line = __tmp22Reader.ReadLine();
                            __tmp22_last = __tmp22Reader.EndOfStream;
                            if ((__tmp22_last && !string.IsNullOrEmpty(__tmp22_line)) || (!__tmp22_last && __tmp22_line != null))
                            {
                                __out.Append(__tmp22_line);
                                __tmp18_outputWritten = true;
                            }
                            if (!__tmp22_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp23_line = ", ref "; //1102:174
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Append(__tmp23_line);
                        __tmp18_outputWritten = true;
                    }
                    StringBuilder __tmp24 = new StringBuilder();
                    __tmp24.Append(GetFieldName(prop, cls));
                    using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                    {
                        bool __tmp24_last = __tmp24Reader.EndOfStream;
                        while(!__tmp24_last)
                        {
                            string __tmp24_line = __tmp24Reader.ReadLine();
                            __tmp24_last = __tmp24Reader.EndOfStream;
                            if ((__tmp24_last && !string.IsNullOrEmpty(__tmp24_line)) || (!__tmp24_last && __tmp24_line != null))
                            {
                                __out.Append(__tmp24_line);
                                __tmp18_outputWritten = true;
                            }
                            if (!__tmp24_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp25_line = "); }"; //1102:204
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Append(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //1102:208
                    }
                }
                else //1103:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "    get { return this.GetList<"; //1104:1
                    if (!string.IsNullOrEmpty(__tmp28_line))
                    {
                        __out.Append(__tmp28_line);
                        __tmp27_outputWritten = true;
                    }
                    StringBuilder __tmp29 = new StringBuilder();
                    __tmp29.Append(CSharpName(((MetaCollectionType)prop.Type).InnerType, model, ClassKind.Immutable, true));
                    using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                    {
                        bool __tmp29_last = __tmp29Reader.EndOfStream;
                        while(!__tmp29_last)
                        {
                            string __tmp29_line = __tmp29Reader.ReadLine();
                            __tmp29_last = __tmp29Reader.EndOfStream;
                            if ((__tmp29_last && !string.IsNullOrEmpty(__tmp29_line)) || (!__tmp29_last && __tmp29_line != null))
                            {
                                __out.Append(__tmp29_line);
                                __tmp27_outputWritten = true;
                            }
                            if (!__tmp29_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp30_line = ">("; //1104:119
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Append(__tmp30_line);
                        __tmp27_outputWritten = true;
                    }
                    StringBuilder __tmp31 = new StringBuilder();
                    __tmp31.Append(CSharpName(prop, null, PropertyKind.Descriptor, true));
                    using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
                    {
                        bool __tmp31_last = __tmp31Reader.EndOfStream;
                        while(!__tmp31_last)
                        {
                            string __tmp31_line = __tmp31Reader.ReadLine();
                            __tmp31_last = __tmp31Reader.EndOfStream;
                            if ((__tmp31_last && !string.IsNullOrEmpty(__tmp31_line)) || (!__tmp31_last && __tmp31_line != null))
                            {
                                __out.Append(__tmp31_line);
                                __tmp27_outputWritten = true;
                            }
                            if (!__tmp31_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp32_line = ", ref "; //1104:175
                    if (!string.IsNullOrEmpty(__tmp32_line))
                    {
                        __out.Append(__tmp32_line);
                        __tmp27_outputWritten = true;
                    }
                    StringBuilder __tmp33 = new StringBuilder();
                    __tmp33.Append(GetFieldName(prop, cls));
                    using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
                    {
                        bool __tmp33_last = __tmp33Reader.EndOfStream;
                        while(!__tmp33_last)
                        {
                            string __tmp33_line = __tmp33Reader.ReadLine();
                            __tmp33_last = __tmp33Reader.EndOfStream;
                            if ((__tmp33_last && !string.IsNullOrEmpty(__tmp33_line)) || (!__tmp33_last && __tmp33_line != null))
                            {
                                __out.Append(__tmp33_line);
                                __tmp27_outputWritten = true;
                            }
                            if (!__tmp33_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp34_line = "); }"; //1104:205
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Append(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //1104:209
                    }
                }
            }
            else if (IsReferenceType(prop.Type)) //1106:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "    get { return this.GetReference<"; //1107:1
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp36_outputWritten = true;
                }
                StringBuilder __tmp38 = new StringBuilder();
                __tmp38.Append(CSharpName(prop.Type, model, ClassKind.Immutable, true));
                using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                {
                    bool __tmp38_last = __tmp38Reader.EndOfStream;
                    while(!__tmp38_last)
                    {
                        string __tmp38_line = __tmp38Reader.ReadLine();
                        __tmp38_last = __tmp38Reader.EndOfStream;
                        if ((__tmp38_last && !string.IsNullOrEmpty(__tmp38_line)) || (!__tmp38_last && __tmp38_line != null))
                        {
                            __out.Append(__tmp38_line);
                            __tmp36_outputWritten = true;
                        }
                        if (!__tmp38_last) __out.AppendLine(true);
                    }
                }
                string __tmp39_line = ">("; //1107:92
                if (!string.IsNullOrEmpty(__tmp39_line))
                {
                    __out.Append(__tmp39_line);
                    __tmp36_outputWritten = true;
                }
                StringBuilder __tmp40 = new StringBuilder();
                __tmp40.Append(CSharpName(prop, null, PropertyKind.Descriptor, true));
                using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                {
                    bool __tmp40_last = __tmp40Reader.EndOfStream;
                    while(!__tmp40_last)
                    {
                        string __tmp40_line = __tmp40Reader.ReadLine();
                        __tmp40_last = __tmp40Reader.EndOfStream;
                        if ((__tmp40_last && !string.IsNullOrEmpty(__tmp40_line)) || (!__tmp40_last && __tmp40_line != null))
                        {
                            __out.Append(__tmp40_line);
                            __tmp36_outputWritten = true;
                        }
                        if (!__tmp40_last) __out.AppendLine(true);
                    }
                }
                string __tmp41_line = ", ref "; //1107:148
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Append(__tmp41_line);
                    __tmp36_outputWritten = true;
                }
                StringBuilder __tmp42 = new StringBuilder();
                __tmp42.Append(GetFieldName(prop, cls));
                using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
                {
                    bool __tmp42_last = __tmp42Reader.EndOfStream;
                    while(!__tmp42_last)
                    {
                        string __tmp42_line = __tmp42Reader.ReadLine();
                        __tmp42_last = __tmp42Reader.EndOfStream;
                        if ((__tmp42_last && !string.IsNullOrEmpty(__tmp42_line)) || (!__tmp42_last && __tmp42_line != null))
                        {
                            __out.Append(__tmp42_line);
                            __tmp36_outputWritten = true;
                        }
                        if (!__tmp42_last) __out.AppendLine(true);
                    }
                }
                string __tmp43_line = "); }"; //1107:178
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Append(__tmp43_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //1107:182
                }
            }
            else //1108:3
            {
                bool __tmp45_outputWritten = false;
                string __tmp46_line = "    get { return this.GetValue<"; //1109:1
                if (!string.IsNullOrEmpty(__tmp46_line))
                {
                    __out.Append(__tmp46_line);
                    __tmp45_outputWritten = true;
                }
                StringBuilder __tmp47 = new StringBuilder();
                __tmp47.Append(CSharpName(prop.Type, model, ClassKind.Immutable, true));
                using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
                {
                    bool __tmp47_last = __tmp47Reader.EndOfStream;
                    while(!__tmp47_last)
                    {
                        string __tmp47_line = __tmp47Reader.ReadLine();
                        __tmp47_last = __tmp47Reader.EndOfStream;
                        if ((__tmp47_last && !string.IsNullOrEmpty(__tmp47_line)) || (!__tmp47_last && __tmp47_line != null))
                        {
                            __out.Append(__tmp47_line);
                            __tmp45_outputWritten = true;
                        }
                        if (!__tmp47_last) __out.AppendLine(true);
                    }
                }
                string __tmp48_line = ">("; //1109:88
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Append(__tmp48_line);
                    __tmp45_outputWritten = true;
                }
                StringBuilder __tmp49 = new StringBuilder();
                __tmp49.Append(CSharpName(prop, null, PropertyKind.Descriptor, true));
                using(StreamReader __tmp49Reader = new StreamReader(this.__ToStream(__tmp49.ToString())))
                {
                    bool __tmp49_last = __tmp49Reader.EndOfStream;
                    while(!__tmp49_last)
                    {
                        string __tmp49_line = __tmp49Reader.ReadLine();
                        __tmp49_last = __tmp49Reader.EndOfStream;
                        if ((__tmp49_last && !string.IsNullOrEmpty(__tmp49_line)) || (!__tmp49_last && __tmp49_line != null))
                        {
                            __out.Append(__tmp49_line);
                            __tmp45_outputWritten = true;
                        }
                        if (!__tmp49_last) __out.AppendLine(true);
                    }
                }
                string __tmp50_line = ", ref "; //1109:144
                if (!string.IsNullOrEmpty(__tmp50_line))
                {
                    __out.Append(__tmp50_line);
                    __tmp45_outputWritten = true;
                }
                StringBuilder __tmp51 = new StringBuilder();
                __tmp51.Append(GetFieldName(prop, cls));
                using(StreamReader __tmp51Reader = new StreamReader(this.__ToStream(__tmp51.ToString())))
                {
                    bool __tmp51_last = __tmp51Reader.EndOfStream;
                    while(!__tmp51_last)
                    {
                        string __tmp51_line = __tmp51Reader.ReadLine();
                        __tmp51_last = __tmp51Reader.EndOfStream;
                        if ((__tmp51_last && !string.IsNullOrEmpty(__tmp51_line)) || (!__tmp51_last && __tmp51_line != null))
                        {
                            __out.Append(__tmp51_line);
                            __tmp45_outputWritten = true;
                        }
                        if (!__tmp51_last) __out.AppendLine(true);
                    }
                }
                string __tmp52_line = "); }"; //1109:174
                if (!string.IsNullOrEmpty(__tmp52_line))
                {
                    __out.Append(__tmp52_line);
                    __tmp45_outputWritten = true;
                }
                if (__tmp45_outputWritten) __out.AppendLine(true);
                if (__tmp45_outputWritten)
                {
                    __out.AppendLine(false); //1109:178
                }
            }
            __out.Append("}"); //1111:1
            __out.AppendLine(false); //1111:2
            return __out.ToString();
        }

        public string GenerateImmutableOperationImpl(MetaModel model, MetaClass cls, MetaOperation op) //1114:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1115:1
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation, true));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3_line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                    {
                        __out.Append(__tmp3_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            string __tmp4_line = " "; //1116:70
            if (!string.IsNullOrEmpty(__tmp4_line))
            {
                __out.Append(__tmp4_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(CSharpName(op.Class, model, ClassKind.Immutable, true));
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(!__tmp5_last)
                {
                    string __tmp5_line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if ((__tmp5_last && !string.IsNullOrEmpty(__tmp5_line)) || (!__tmp5_last && __tmp5_line != null))
                    {
                        __out.Append(__tmp5_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp5_last) __out.AppendLine(true);
                }
            }
            string __tmp6_line = "."; //1116:126
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Append(__tmp6_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(op.Name);
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(!__tmp7_last)
                {
                    string __tmp7_line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if ((__tmp7_last && !string.IsNullOrEmpty(__tmp7_line)) || (!__tmp7_last && __tmp7_line != null))
                    {
                        __out.Append(__tmp7_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            string __tmp8_line = "("; //1116:136
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Append(__tmp8_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(GetClassParameters(model, op.Class, op, ClassKind.ImmutableOperation));
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9_line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if ((__tmp9_last && !string.IsNullOrEmpty(__tmp9_line)) || (!__tmp9_last && __tmp9_line != null))
                    {
                        __out.Append(__tmp9_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp9_last) __out.AppendLine(true);
                }
            }
            string __tmp10_line = ")"; //1116:208
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1116:209
            }
            __out.Append("{"); //1117:1
            __out.AppendLine(false); //1117:2
            var finalOp = GetFinalOperation(cls, op); //1118:2
            bool __tmp12_outputWritten = false;
            string __tmp11Prefix = "    "; //1119:1
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(GetReturn(model, finalOp, ClassKind.ImmutableOperation));
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13_line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp11Prefix))
                    {
                        __out.Append(__tmp11Prefix);
                        __tmp12_outputWritten = true;
                    }
                    if ((__tmp13_last && !string.IsNullOrEmpty(__tmp13_line)) || (!__tmp13_last && __tmp13_line != null))
                    {
                        __out.Append(__tmp13_line);
                        __tmp12_outputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(CSharpName(model, ModelKind.ImplementationProvider));
            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
            {
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(!__tmp14_last)
                {
                    string __tmp14_line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if ((__tmp14_last && !string.IsNullOrEmpty(__tmp14_line)) || (!__tmp14_last && __tmp14_line != null))
                    {
                        __out.Append(__tmp14_line);
                        __tmp12_outputWritten = true;
                    }
                    if (!__tmp14_last) __out.AppendLine(true);
                }
            }
            string __tmp15_line = ".Implementation."; //1119:114
            if (!string.IsNullOrEmpty(__tmp15_line))
            {
                __out.Append(__tmp15_line);
                __tmp12_outputWritten = true;
            }
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(CSharpName(finalOp.Class, model, ClassKind.Immutable));
            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
            {
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    string __tmp16_line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if ((__tmp16_last && !string.IsNullOrEmpty(__tmp16_line)) || (!__tmp16_last && __tmp16_line != null))
                    {
                        __out.Append(__tmp16_line);
                        __tmp12_outputWritten = true;
                    }
                    if (!__tmp16_last) __out.AppendLine(true);
                }
            }
            string __tmp17_line = "_"; //1119:184
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp12_outputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(finalOp.Name);
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    string __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                    {
                        __out.Append(__tmp18_line);
                        __tmp12_outputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19_line = "("; //1119:199
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp12_outputWritten = true;
            }
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(GetClassImplCallParameterNames(model, finalOp, ClassKind.ImmutableOperation));
            using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
            {
                bool __tmp20_last = __tmp20Reader.EndOfStream;
                while(!__tmp20_last)
                {
                    string __tmp20_line = __tmp20Reader.ReadLine();
                    __tmp20_last = __tmp20Reader.EndOfStream;
                    if ((__tmp20_last && !string.IsNullOrEmpty(__tmp20_line)) || (!__tmp20_last && __tmp20_line != null))
                    {
                        __out.Append(__tmp20_line);
                        __tmp12_outputWritten = true;
                    }
                    if (!__tmp20_last) __out.AppendLine(true);
                }
            }
            string __tmp21_line = ");"; //1119:278
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp12_outputWritten = true;
            }
            if (__tmp12_outputWritten) __out.AppendLine(true);
            if (__tmp12_outputWritten)
            {
                __out.AppendLine(false); //1119:280
            }
            __out.Append("}"); //1120:1
            __out.AppendLine(false); //1120:2
            return __out.ToString();
        }

        public string GenerateBuilderImplClass(MetaModel model, MetaClass cls) //1123:1
        {
            StringBuilder __out = new StringBuilder();
            bool metaMetaModel = IsMetaMetaModel(model); //1124:2
            string metaNs = metaMetaModel ? "" : Properties.MetaNs + "."; //1125:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //1126:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(CSharpName(cls, model, ClassKind.BuilderImpl));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5_line = " : "; //1126:62
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Append(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(Properties.CoreNs);
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7_line = ".MutableObjectBase, "; //1126:84
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(CSharpName(cls, model, ClassKind.Builder));
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp8_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1126:146
            }
            __out.Append("{"); //1127:1
            __out.AppendLine(false); //1127:2
            var __loop66_results = 
                (from __loop66_var1 in __Enumerate((cls).GetEnumerator()) //1128:8
                from prop in __Enumerate((__loop66_var1.GetAllProperties()).GetEnumerator()) //1128:13
                where prop.Type is MetaCollectionType //1128:37
                select new { __loop66_var1 = __loop66_var1, prop = prop}
                ).ToList(); //1128:3
            for (int __loop66_iteration = 0; __loop66_iteration < __loop66_results.Count; ++__loop66_iteration)
            {
                var __tmp9 = __loop66_results[__loop66_iteration];
                var __loop66_var1 = __tmp9.__loop66_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //1129:1
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(GenerateBuilderField(model, cls, prop));
                using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                {
                    bool __tmp12_last = __tmp12Reader.EndOfStream;
                    while(!__tmp12_last)
                    {
                        string __tmp12_line = __tmp12Reader.ReadLine();
                        __tmp12_last = __tmp12Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp10Prefix))
                        {
                            __out.Append(__tmp10Prefix);
                            __tmp11_outputWritten = true;
                        }
                        if ((__tmp12_last && !string.IsNullOrEmpty(__tmp12_line)) || (!__tmp12_last && __tmp12_line != null))
                        {
                            __out.Append(__tmp12_line);
                            __tmp11_outputWritten = true;
                        }
                        if (!__tmp12_last || __tmp11_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //1129:42
                }
            }
            __out.AppendLine(true); //1131:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //1132:1
            if (!string.IsNullOrEmpty(__tmp15_line))
            {
                __out.Append(__tmp15_line);
                __tmp14_outputWritten = true;
            }
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(CSharpName(cls, model, ClassKind.BuilderImpl));
            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
            {
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    string __tmp16_line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if ((__tmp16_last && !string.IsNullOrEmpty(__tmp16_line)) || (!__tmp16_last && __tmp16_line != null))
                    {
                        __out.Append(__tmp16_line);
                        __tmp14_outputWritten = true;
                    }
                    if (!__tmp16_last) __out.AppendLine(true);
                }
            }
            string __tmp17_line = "("; //1132:57
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp14_outputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(Properties.CoreNs);
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    string __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                    {
                        __out.Append(__tmp18_line);
                        __tmp14_outputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19_line = ".ObjectId id, "; //1132:77
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp14_outputWritten = true;
            }
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(Properties.CoreNs);
            using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
            {
                bool __tmp20_last = __tmp20Reader.EndOfStream;
                while(!__tmp20_last)
                {
                    string __tmp20_line = __tmp20Reader.ReadLine();
                    __tmp20_last = __tmp20Reader.EndOfStream;
                    if ((__tmp20_last && !string.IsNullOrEmpty(__tmp20_line)) || (!__tmp20_last && __tmp20_line != null))
                    {
                        __out.Append(__tmp20_line);
                        __tmp14_outputWritten = true;
                    }
                    if (!__tmp20_last) __out.AppendLine(true);
                }
            }
            string __tmp21_line = ".MutableModel model, bool creating)"; //1132:110
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //1132:145
            }
            __out.Append("		: base(id, model, creating)"); //1133:1
            __out.AppendLine(false); //1133:30
            __out.Append("	{"); //1134:1
            __out.AppendLine(false); //1134:3
            __out.Append("	}"); //1135:1
            __out.AppendLine(false); //1135:3
            __out.AppendLine(true); //1136:2
            __out.Append("	protected override void MInit()"); //1137:1
            __out.AppendLine(false); //1137:33
            __out.Append("	{"); //1138:1
            __out.AppendLine(false); //1138:3
            bool __tmp23_outputWritten = false;
            string __tmp22Prefix = "		"; //1139:1
            StringBuilder __tmp24 = new StringBuilder();
            __tmp24.Append(CSharpName(model, ModelKind.ImplementationProvider));
            using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
            {
                bool __tmp24_last = __tmp24Reader.EndOfStream;
                while(!__tmp24_last)
                {
                    string __tmp24_line = __tmp24Reader.ReadLine();
                    __tmp24_last = __tmp24Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp22Prefix))
                    {
                        __out.Append(__tmp22Prefix);
                        __tmp23_outputWritten = true;
                    }
                    if ((__tmp24_last && !string.IsNullOrEmpty(__tmp24_line)) || (!__tmp24_last && __tmp24_line != null))
                    {
                        __out.Append(__tmp24_line);
                        __tmp23_outputWritten = true;
                    }
                    if (!__tmp24_last) __out.AppendLine(true);
                }
            }
            string __tmp25_line = ".Implementation."; //1139:55
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Append(__tmp25_line);
                __tmp23_outputWritten = true;
            }
            StringBuilder __tmp26 = new StringBuilder();
            __tmp26.Append(CSharpName(cls, model, ClassKind.Immutable));
            using(StreamReader __tmp26Reader = new StreamReader(this.__ToStream(__tmp26.ToString())))
            {
                bool __tmp26_last = __tmp26Reader.EndOfStream;
                while(!__tmp26_last)
                {
                    string __tmp26_line = __tmp26Reader.ReadLine();
                    __tmp26_last = __tmp26Reader.EndOfStream;
                    if ((__tmp26_last && !string.IsNullOrEmpty(__tmp26_line)) || (!__tmp26_last && __tmp26_line != null))
                    {
                        __out.Append(__tmp26_line);
                        __tmp23_outputWritten = true;
                    }
                    if (!__tmp26_last) __out.AppendLine(true);
                }
            }
            string __tmp27_line = "(this);"; //1139:115
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Append(__tmp27_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //1139:122
            }
            __out.Append("	}"); //1140:1
            __out.AppendLine(false); //1140:3
            __out.AppendLine(true); //1141:2
            __out.Append("	public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)"); //1142:1
            __out.AppendLine(false); //1142:162
            __out.Append("	{"); //1143:1
            __out.AppendLine(false); //1143:3
            bool __tmp29_outputWritten = false;
            string __tmp28Prefix = "		"; //1144:1
            StringBuilder __tmp30 = new StringBuilder();
            __tmp30.Append(CSharpName(model, ModelKind.ImplementationProvider));
            using(StreamReader __tmp30Reader = new StreamReader(this.__ToStream(__tmp30.ToString())))
            {
                bool __tmp30_last = __tmp30Reader.EndOfStream;
                while(!__tmp30_last)
                {
                    string __tmp30_line = __tmp30Reader.ReadLine();
                    __tmp30_last = __tmp30Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp28Prefix))
                    {
                        __out.Append(__tmp28Prefix);
                        __tmp29_outputWritten = true;
                    }
                    if ((__tmp30_last && !string.IsNullOrEmpty(__tmp30_line)) || (!__tmp30_last && __tmp30_line != null))
                    {
                        __out.Append(__tmp30_line);
                        __tmp29_outputWritten = true;
                    }
                    if (!__tmp30_last) __out.AppendLine(true);
                }
            }
            string __tmp31_line = ".Implementation."; //1144:55
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Append(__tmp31_line);
                __tmp29_outputWritten = true;
            }
            StringBuilder __tmp32 = new StringBuilder();
            __tmp32.Append(CSharpName(cls, model, ClassKind.Immutable));
            using(StreamReader __tmp32Reader = new StreamReader(this.__ToStream(__tmp32.ToString())))
            {
                bool __tmp32_last = __tmp32Reader.EndOfStream;
                while(!__tmp32_last)
                {
                    string __tmp32_line = __tmp32Reader.ReadLine();
                    __tmp32_last = __tmp32Reader.EndOfStream;
                    if ((__tmp32_last && !string.IsNullOrEmpty(__tmp32_line)) || (!__tmp32_last && __tmp32_line != null))
                    {
                        __out.Append(__tmp32_line);
                        __tmp29_outputWritten = true;
                    }
                    if (!__tmp32_last) __out.AppendLine(true);
                }
            }
            string __tmp33_line = "_MValidate(this, diagnostics, cancellationToken);"; //1144:115
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Append(__tmp33_line);
                __tmp29_outputWritten = true;
            }
            if (__tmp29_outputWritten) __out.AppendLine(true);
            if (__tmp29_outputWritten)
            {
                __out.AppendLine(false); //1144:164
            }
            __out.Append("	}"); //1145:1
            __out.AppendLine(false); //1145:3
            __out.AppendLine(true); //1146:2
            bool __tmp35_outputWritten = false;
            string __tmp36_line = "	public override "; //1147:1
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Append(__tmp36_line);
                __tmp35_outputWritten = true;
            }
            StringBuilder __tmp37 = new StringBuilder();
            __tmp37.Append(Properties.CoreNs);
            using(StreamReader __tmp37Reader = new StreamReader(this.__ToStream(__tmp37.ToString())))
            {
                bool __tmp37_last = __tmp37Reader.EndOfStream;
                while(!__tmp37_last)
                {
                    string __tmp37_line = __tmp37Reader.ReadLine();
                    __tmp37_last = __tmp37Reader.EndOfStream;
                    if ((__tmp37_last && !string.IsNullOrEmpty(__tmp37_line)) || (!__tmp37_last && __tmp37_line != null))
                    {
                        __out.Append(__tmp37_line);
                        __tmp35_outputWritten = true;
                    }
                    if (!__tmp37_last) __out.AppendLine(true);
                }
            }
            string __tmp38_line = ".IMetaModel MMetaModel"; //1147:37
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Append(__tmp38_line);
                __tmp35_outputWritten = true;
            }
            if (__tmp35_outputWritten) __out.AppendLine(true);
            if (__tmp35_outputWritten)
            {
                __out.AppendLine(false); //1147:59
            }
            __out.Append("	{"); //1148:1
            __out.AppendLine(false); //1148:3
            bool __tmp40_outputWritten = false;
            string __tmp41_line = "		get { return "; //1149:1
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Append(__tmp41_line);
                __tmp40_outputWritten = true;
            }
            StringBuilder __tmp42 = new StringBuilder();
            __tmp42.Append(CSharpName(cls.MetaModel, ModelKind.ImmutableInstance, true));
            using(StreamReader __tmp42Reader = new StreamReader(this.__ToStream(__tmp42.ToString())))
            {
                bool __tmp42_last = __tmp42Reader.EndOfStream;
                while(!__tmp42_last)
                {
                    string __tmp42_line = __tmp42Reader.ReadLine();
                    __tmp42_last = __tmp42Reader.EndOfStream;
                    if ((__tmp42_last && !string.IsNullOrEmpty(__tmp42_line)) || (!__tmp42_last && __tmp42_line != null))
                    {
                        __out.Append(__tmp42_line);
                        __tmp40_outputWritten = true;
                    }
                    if (!__tmp42_last) __out.AppendLine(true);
                }
            }
            string __tmp43_line = ".MMetaModel; }"; //1149:77
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Append(__tmp43_line);
                __tmp40_outputWritten = true;
            }
            if (__tmp40_outputWritten) __out.AppendLine(true);
            if (__tmp40_outputWritten)
            {
                __out.AppendLine(false); //1149:91
            }
            __out.Append("	}"); //1150:1
            __out.AppendLine(false); //1150:3
            __out.AppendLine(true); //1151:2
            bool __tmp45_outputWritten = false;
            string __tmp46_line = "	public override "; //1152:1
            if (!string.IsNullOrEmpty(__tmp46_line))
            {
                __out.Append(__tmp46_line);
                __tmp45_outputWritten = true;
            }
            StringBuilder __tmp47 = new StringBuilder();
            __tmp47.Append(metaNs);
            using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
            {
                bool __tmp47_last = __tmp47Reader.EndOfStream;
                while(!__tmp47_last)
                {
                    string __tmp47_line = __tmp47Reader.ReadLine();
                    __tmp47_last = __tmp47Reader.EndOfStream;
                    if ((__tmp47_last && !string.IsNullOrEmpty(__tmp47_line)) || (!__tmp47_last && __tmp47_line != null))
                    {
                        __out.Append(__tmp47_line);
                        __tmp45_outputWritten = true;
                    }
                    if (!__tmp47_last) __out.AppendLine(true);
                }
            }
            string __tmp48_line = "MetaClass MMetaClass"; //1152:26
            if (!string.IsNullOrEmpty(__tmp48_line))
            {
                __out.Append(__tmp48_line);
                __tmp45_outputWritten = true;
            }
            if (__tmp45_outputWritten) __out.AppendLine(true);
            if (__tmp45_outputWritten)
            {
                __out.AppendLine(false); //1152:46
            }
            __out.Append("	{"); //1153:1
            __out.AppendLine(false); //1153:3
            bool __tmp50_outputWritten = false;
            string __tmp51_line = "		get { return "; //1154:1
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Append(__tmp51_line);
                __tmp50_outputWritten = true;
            }
            StringBuilder __tmp52 = new StringBuilder();
            __tmp52.Append(CSharpName(cls, model, ClassKind.ImmutableInstance, true));
            using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
            {
                bool __tmp52_last = __tmp52Reader.EndOfStream;
                while(!__tmp52_last)
                {
                    string __tmp52_line = __tmp52Reader.ReadLine();
                    __tmp52_last = __tmp52Reader.EndOfStream;
                    if ((__tmp52_last && !string.IsNullOrEmpty(__tmp52_line)) || (!__tmp52_last && __tmp52_line != null))
                    {
                        __out.Append(__tmp52_line);
                        __tmp50_outputWritten = true;
                    }
                    if (!__tmp52_last) __out.AppendLine(true);
                }
            }
            string __tmp53_line = "; }"; //1154:74
            if (!string.IsNullOrEmpty(__tmp53_line))
            {
                __out.Append(__tmp53_line);
                __tmp50_outputWritten = true;
            }
            if (__tmp50_outputWritten) __out.AppendLine(true);
            if (__tmp50_outputWritten)
            {
                __out.AppendLine(false); //1154:77
            }
            __out.Append("	}"); //1155:1
            __out.AppendLine(false); //1155:3
            __out.AppendLine(true); //1156:2
            bool __tmp55_outputWritten = false;
            string __tmp56_line = "	public new "; //1157:1
            if (!string.IsNullOrEmpty(__tmp56_line))
            {
                __out.Append(__tmp56_line);
                __tmp55_outputWritten = true;
            }
            StringBuilder __tmp57 = new StringBuilder();
            __tmp57.Append(CSharpName(cls, model, ClassKind.Immutable));
            using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
            {
                bool __tmp57_last = __tmp57Reader.EndOfStream;
                while(!__tmp57_last)
                {
                    string __tmp57_line = __tmp57Reader.ReadLine();
                    __tmp57_last = __tmp57Reader.EndOfStream;
                    if ((__tmp57_last && !string.IsNullOrEmpty(__tmp57_line)) || (!__tmp57_last && __tmp57_line != null))
                    {
                        __out.Append(__tmp57_line);
                        __tmp55_outputWritten = true;
                    }
                    if (!__tmp57_last) __out.AppendLine(true);
                }
            }
            string __tmp58_line = " ToImmutable()"; //1157:57
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Append(__tmp58_line);
                __tmp55_outputWritten = true;
            }
            if (__tmp55_outputWritten) __out.AppendLine(true);
            if (__tmp55_outputWritten)
            {
                __out.AppendLine(false); //1157:71
            }
            __out.Append("	{"); //1158:1
            __out.AppendLine(false); //1158:3
            bool __tmp60_outputWritten = false;
            string __tmp61_line = "		return ("; //1159:1
            if (!string.IsNullOrEmpty(__tmp61_line))
            {
                __out.Append(__tmp61_line);
                __tmp60_outputWritten = true;
            }
            StringBuilder __tmp62 = new StringBuilder();
            __tmp62.Append(CSharpName(cls, model, ClassKind.Immutable));
            using(StreamReader __tmp62Reader = new StreamReader(this.__ToStream(__tmp62.ToString())))
            {
                bool __tmp62_last = __tmp62Reader.EndOfStream;
                while(!__tmp62_last)
                {
                    string __tmp62_line = __tmp62Reader.ReadLine();
                    __tmp62_last = __tmp62Reader.EndOfStream;
                    if ((__tmp62_last && !string.IsNullOrEmpty(__tmp62_line)) || (!__tmp62_last && __tmp62_line != null))
                    {
                        __out.Append(__tmp62_line);
                        __tmp60_outputWritten = true;
                    }
                    if (!__tmp62_last) __out.AppendLine(true);
                }
            }
            string __tmp63_line = ")base.ToImmutable();"; //1159:55
            if (!string.IsNullOrEmpty(__tmp63_line))
            {
                __out.Append(__tmp63_line);
                __tmp60_outputWritten = true;
            }
            if (__tmp60_outputWritten) __out.AppendLine(true);
            if (__tmp60_outputWritten)
            {
                __out.AppendLine(false); //1159:75
            }
            __out.Append("	}"); //1160:1
            __out.AppendLine(false); //1160:3
            __out.AppendLine(true); //1161:2
            bool __tmp65_outputWritten = false;
            string __tmp66_line = "	public new "; //1162:1
            if (!string.IsNullOrEmpty(__tmp66_line))
            {
                __out.Append(__tmp66_line);
                __tmp65_outputWritten = true;
            }
            StringBuilder __tmp67 = new StringBuilder();
            __tmp67.Append(CSharpName(cls, model, ClassKind.Immutable));
            using(StreamReader __tmp67Reader = new StreamReader(this.__ToStream(__tmp67.ToString())))
            {
                bool __tmp67_last = __tmp67Reader.EndOfStream;
                while(!__tmp67_last)
                {
                    string __tmp67_line = __tmp67Reader.ReadLine();
                    __tmp67_last = __tmp67Reader.EndOfStream;
                    if ((__tmp67_last && !string.IsNullOrEmpty(__tmp67_line)) || (!__tmp67_last && __tmp67_line != null))
                    {
                        __out.Append(__tmp67_line);
                        __tmp65_outputWritten = true;
                    }
                    if (!__tmp67_last) __out.AppendLine(true);
                }
            }
            string __tmp68_line = " ToImmutable("; //1162:57
            if (!string.IsNullOrEmpty(__tmp68_line))
            {
                __out.Append(__tmp68_line);
                __tmp65_outputWritten = true;
            }
            StringBuilder __tmp69 = new StringBuilder();
            __tmp69.Append(Properties.CoreNs);
            using(StreamReader __tmp69Reader = new StreamReader(this.__ToStream(__tmp69.ToString())))
            {
                bool __tmp69_last = __tmp69Reader.EndOfStream;
                while(!__tmp69_last)
                {
                    string __tmp69_line = __tmp69Reader.ReadLine();
                    __tmp69_last = __tmp69Reader.EndOfStream;
                    if ((__tmp69_last && !string.IsNullOrEmpty(__tmp69_line)) || (!__tmp69_last && __tmp69_line != null))
                    {
                        __out.Append(__tmp69_line);
                        __tmp65_outputWritten = true;
                    }
                    if (!__tmp69_last) __out.AppendLine(true);
                }
            }
            string __tmp70_line = ".ImmutableModel model)"; //1162:89
            if (!string.IsNullOrEmpty(__tmp70_line))
            {
                __out.Append(__tmp70_line);
                __tmp65_outputWritten = true;
            }
            if (__tmp65_outputWritten) __out.AppendLine(true);
            if (__tmp65_outputWritten)
            {
                __out.AppendLine(false); //1162:111
            }
            __out.Append("	{"); //1163:1
            __out.AppendLine(false); //1163:3
            bool __tmp72_outputWritten = false;
            string __tmp73_line = "		return ("; //1164:1
            if (!string.IsNullOrEmpty(__tmp73_line))
            {
                __out.Append(__tmp73_line);
                __tmp72_outputWritten = true;
            }
            StringBuilder __tmp74 = new StringBuilder();
            __tmp74.Append(CSharpName(cls, model, ClassKind.Immutable));
            using(StreamReader __tmp74Reader = new StreamReader(this.__ToStream(__tmp74.ToString())))
            {
                bool __tmp74_last = __tmp74Reader.EndOfStream;
                while(!__tmp74_last)
                {
                    string __tmp74_line = __tmp74Reader.ReadLine();
                    __tmp74_last = __tmp74Reader.EndOfStream;
                    if ((__tmp74_last && !string.IsNullOrEmpty(__tmp74_line)) || (!__tmp74_last && __tmp74_line != null))
                    {
                        __out.Append(__tmp74_line);
                        __tmp72_outputWritten = true;
                    }
                    if (!__tmp74_last) __out.AppendLine(true);
                }
            }
            string __tmp75_line = ")base.ToImmutable(model);"; //1164:55
            if (!string.IsNullOrEmpty(__tmp75_line))
            {
                __out.Append(__tmp75_line);
                __tmp72_outputWritten = true;
            }
            if (__tmp72_outputWritten) __out.AppendLine(true);
            if (__tmp72_outputWritten)
            {
                __out.AppendLine(false); //1164:80
            }
            __out.Append("	}"); //1165:1
            __out.AppendLine(false); //1165:3
            var __loop67_results = 
                (from __loop67_var1 in __Enumerate((cls).GetEnumerator()) //1166:8
                from sup in __Enumerate((__loop67_var1.GetAllSuperClasses(false)).GetEnumerator()) //1166:13
                select new { __loop67_var1 = __loop67_var1, sup = sup}
                ).ToList(); //1166:3
            for (int __loop67_iteration = 0; __loop67_iteration < __loop67_results.Count; ++__loop67_iteration)
            {
                var __tmp76 = __loop67_results[__loop67_iteration];
                var __loop67_var1 = __tmp76.__loop67_var1;
                var sup = __tmp76.sup;
                __out.AppendLine(true); //1167:2
                bool __tmp78_outputWritten = false;
                string __tmp77Prefix = "	"; //1168:1
                StringBuilder __tmp79 = new StringBuilder();
                __tmp79.Append(CSharpName(sup, model, ClassKind.Immutable, true));
                using(StreamReader __tmp79Reader = new StreamReader(this.__ToStream(__tmp79.ToString())))
                {
                    bool __tmp79_last = __tmp79Reader.EndOfStream;
                    while(!__tmp79_last)
                    {
                        string __tmp79_line = __tmp79Reader.ReadLine();
                        __tmp79_last = __tmp79Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp77Prefix))
                        {
                            __out.Append(__tmp77Prefix);
                            __tmp78_outputWritten = true;
                        }
                        if ((__tmp79_last && !string.IsNullOrEmpty(__tmp79_line)) || (!__tmp79_last && __tmp79_line != null))
                        {
                            __out.Append(__tmp79_line);
                            __tmp78_outputWritten = true;
                        }
                        if (!__tmp79_last) __out.AppendLine(true);
                    }
                }
                string __tmp80_line = " "; //1168:52
                if (!string.IsNullOrEmpty(__tmp80_line))
                {
                    __out.Append(__tmp80_line);
                    __tmp78_outputWritten = true;
                }
                StringBuilder __tmp81 = new StringBuilder();
                __tmp81.Append(CSharpName(sup, model, ClassKind.Builder, true));
                using(StreamReader __tmp81Reader = new StreamReader(this.__ToStream(__tmp81.ToString())))
                {
                    bool __tmp81_last = __tmp81Reader.EndOfStream;
                    while(!__tmp81_last)
                    {
                        string __tmp81_line = __tmp81Reader.ReadLine();
                        __tmp81_last = __tmp81Reader.EndOfStream;
                        if ((__tmp81_last && !string.IsNullOrEmpty(__tmp81_line)) || (!__tmp81_last && __tmp81_line != null))
                        {
                            __out.Append(__tmp81_line);
                            __tmp78_outputWritten = true;
                        }
                        if (!__tmp81_last) __out.AppendLine(true);
                    }
                }
                string __tmp82_line = ".ToImmutable()"; //1168:101
                if (!string.IsNullOrEmpty(__tmp82_line))
                {
                    __out.Append(__tmp82_line);
                    __tmp78_outputWritten = true;
                }
                if (__tmp78_outputWritten) __out.AppendLine(true);
                if (__tmp78_outputWritten)
                {
                    __out.AppendLine(false); //1168:115
                }
                __out.Append("	{"); //1169:1
                __out.AppendLine(false); //1169:3
                __out.Append("		return this.ToImmutable();"); //1170:1
                __out.AppendLine(false); //1170:29
                __out.Append("	}"); //1171:1
                __out.AppendLine(false); //1171:3
                __out.AppendLine(true); //1172:2
                bool __tmp84_outputWritten = false;
                string __tmp83Prefix = "	"; //1173:1
                StringBuilder __tmp85 = new StringBuilder();
                __tmp85.Append(CSharpName(sup, model, ClassKind.Immutable, true));
                using(StreamReader __tmp85Reader = new StreamReader(this.__ToStream(__tmp85.ToString())))
                {
                    bool __tmp85_last = __tmp85Reader.EndOfStream;
                    while(!__tmp85_last)
                    {
                        string __tmp85_line = __tmp85Reader.ReadLine();
                        __tmp85_last = __tmp85Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp83Prefix))
                        {
                            __out.Append(__tmp83Prefix);
                            __tmp84_outputWritten = true;
                        }
                        if ((__tmp85_last && !string.IsNullOrEmpty(__tmp85_line)) || (!__tmp85_last && __tmp85_line != null))
                        {
                            __out.Append(__tmp85_line);
                            __tmp84_outputWritten = true;
                        }
                        if (!__tmp85_last) __out.AppendLine(true);
                    }
                }
                string __tmp86_line = " "; //1173:52
                if (!string.IsNullOrEmpty(__tmp86_line))
                {
                    __out.Append(__tmp86_line);
                    __tmp84_outputWritten = true;
                }
                StringBuilder __tmp87 = new StringBuilder();
                __tmp87.Append(CSharpName(sup, model, ClassKind.Builder, true));
                using(StreamReader __tmp87Reader = new StreamReader(this.__ToStream(__tmp87.ToString())))
                {
                    bool __tmp87_last = __tmp87Reader.EndOfStream;
                    while(!__tmp87_last)
                    {
                        string __tmp87_line = __tmp87Reader.ReadLine();
                        __tmp87_last = __tmp87Reader.EndOfStream;
                        if ((__tmp87_last && !string.IsNullOrEmpty(__tmp87_line)) || (!__tmp87_last && __tmp87_line != null))
                        {
                            __out.Append(__tmp87_line);
                            __tmp84_outputWritten = true;
                        }
                        if (!__tmp87_last) __out.AppendLine(true);
                    }
                }
                string __tmp88_line = ".ToImmutable("; //1173:101
                if (!string.IsNullOrEmpty(__tmp88_line))
                {
                    __out.Append(__tmp88_line);
                    __tmp84_outputWritten = true;
                }
                StringBuilder __tmp89 = new StringBuilder();
                __tmp89.Append(Properties.CoreNs);
                using(StreamReader __tmp89Reader = new StreamReader(this.__ToStream(__tmp89.ToString())))
                {
                    bool __tmp89_last = __tmp89Reader.EndOfStream;
                    while(!__tmp89_last)
                    {
                        string __tmp89_line = __tmp89Reader.ReadLine();
                        __tmp89_last = __tmp89Reader.EndOfStream;
                        if ((__tmp89_last && !string.IsNullOrEmpty(__tmp89_line)) || (!__tmp89_last && __tmp89_line != null))
                        {
                            __out.Append(__tmp89_line);
                            __tmp84_outputWritten = true;
                        }
                        if (!__tmp89_last) __out.AppendLine(true);
                    }
                }
                string __tmp90_line = ".ImmutableModel model)"; //1173:133
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Append(__tmp90_line);
                    __tmp84_outputWritten = true;
                }
                if (__tmp84_outputWritten) __out.AppendLine(true);
                if (__tmp84_outputWritten)
                {
                    __out.AppendLine(false); //1173:155
                }
                __out.Append("	{"); //1174:1
                __out.AppendLine(false); //1174:3
                __out.Append("		return this.ToImmutable(model);"); //1175:1
                __out.AppendLine(false); //1175:34
                __out.Append("	}"); //1176:1
                __out.AppendLine(false); //1176:3
            }
            var __loop68_results = 
                (from __loop68_var1 in __Enumerate((cls).GetEnumerator()) //1178:8
                from prop in __Enumerate((__loop68_var1.GetAllProperties()).GetEnumerator()) //1178:13
                select new { __loop68_var1 = __loop68_var1, prop = prop}
                ).ToList(); //1178:3
            for (int __loop68_iteration = 0; __loop68_iteration < __loop68_results.Count; ++__loop68_iteration)
            {
                var __tmp91 = __loop68_results[__loop68_iteration];
                var __loop68_var1 = __tmp91.__loop68_var1;
                var prop = __tmp91.prop;
                __out.AppendLine(true); //1179:2
                bool __tmp93_outputWritten = false;
                string __tmp92Prefix = "	"; //1180:1
                StringBuilder __tmp94 = new StringBuilder();
                __tmp94.Append(GenerateBuilderPropertyImpl(model, cls, prop));
                using(StreamReader __tmp94Reader = new StreamReader(this.__ToStream(__tmp94.ToString())))
                {
                    bool __tmp94_last = __tmp94Reader.EndOfStream;
                    while(!__tmp94_last)
                    {
                        string __tmp94_line = __tmp94Reader.ReadLine();
                        __tmp94_last = __tmp94Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp92Prefix))
                        {
                            __out.Append(__tmp92Prefix);
                            __tmp93_outputWritten = true;
                        }
                        if ((__tmp94_last && !string.IsNullOrEmpty(__tmp94_line)) || (!__tmp94_last && __tmp94_line != null))
                        {
                            __out.Append(__tmp94_line);
                            __tmp93_outputWritten = true;
                        }
                        if (!__tmp94_last || __tmp93_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp93_outputWritten)
                {
                    __out.AppendLine(false); //1180:49
                }
            }
            var __loop69_results = 
                (from __loop69_var1 in __Enumerate((cls).GetEnumerator()) //1182:8
                from op in __Enumerate((__loop69_var1.GetAllOperations()).GetEnumerator()) //1182:13
                select new { __loop69_var1 = __loop69_var1, op = op}
                ).ToList(); //1182:3
            for (int __loop69_iteration = 0; __loop69_iteration < __loop69_results.Count; ++__loop69_iteration)
            {
                var __tmp95 = __loop69_results[__loop69_iteration];
                var __loop69_var1 = __tmp95.__loop69_var1;
                var op = __tmp95.op;
                __out.AppendLine(true); //1183:2
                bool __tmp97_outputWritten = false;
                string __tmp96Prefix = "	"; //1184:1
                StringBuilder __tmp98 = new StringBuilder();
                __tmp98.Append(GenerateBuilderOperationImpl(model, cls, op));
                using(StreamReader __tmp98Reader = new StreamReader(this.__ToStream(__tmp98.ToString())))
                {
                    bool __tmp98_last = __tmp98Reader.EndOfStream;
                    while(!__tmp98_last)
                    {
                        string __tmp98_line = __tmp98Reader.ReadLine();
                        __tmp98_last = __tmp98Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp96Prefix))
                        {
                            __out.Append(__tmp96Prefix);
                            __tmp97_outputWritten = true;
                        }
                        if ((__tmp98_last && !string.IsNullOrEmpty(__tmp98_line)) || (!__tmp98_last && __tmp98_line != null))
                        {
                            __out.Append(__tmp98_line);
                            __tmp97_outputWritten = true;
                        }
                        if (!__tmp98_last || __tmp97_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp97_outputWritten)
                {
                    __out.AppendLine(false); //1184:48
                }
            }
            if (metaMetaModel && cls.Name == "MetaModel") //1186:3
            {
                __out.AppendLine(true); //1187:1
                bool __tmp100_outputWritten = false;
                string __tmp99Prefix = "	"; //1188:1
                StringBuilder __tmp101 = new StringBuilder();
                __tmp101.Append(Properties.CoreNs);
                using(StreamReader __tmp101Reader = new StreamReader(this.__ToStream(__tmp101.ToString())))
                {
                    bool __tmp101_last = __tmp101Reader.EndOfStream;
                    while(!__tmp101_last)
                    {
                        string __tmp101_line = __tmp101Reader.ReadLine();
                        __tmp101_last = __tmp101Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp99Prefix))
                        {
                            __out.Append(__tmp99Prefix);
                            __tmp100_outputWritten = true;
                        }
                        if ((__tmp101_last && !string.IsNullOrEmpty(__tmp101_line)) || (!__tmp101_last && __tmp101_line != null))
                        {
                            __out.Append(__tmp101_line);
                            __tmp100_outputWritten = true;
                        }
                        if (!__tmp101_last) __out.AppendLine(true);
                    }
                }
                string __tmp102_line = ".ModelId "; //1188:21
                if (!string.IsNullOrEmpty(__tmp102_line))
                {
                    __out.Append(__tmp102_line);
                    __tmp100_outputWritten = true;
                }
                StringBuilder __tmp103 = new StringBuilder();
                __tmp103.Append(Properties.CoreNs);
                using(StreamReader __tmp103Reader = new StreamReader(this.__ToStream(__tmp103.ToString())))
                {
                    bool __tmp103_last = __tmp103Reader.EndOfStream;
                    while(!__tmp103_last)
                    {
                        string __tmp103_line = __tmp103Reader.ReadLine();
                        __tmp103_last = __tmp103Reader.EndOfStream;
                        if ((__tmp103_last && !string.IsNullOrEmpty(__tmp103_line)) || (!__tmp103_last && __tmp103_line != null))
                        {
                            __out.Append(__tmp103_line);
                            __tmp100_outputWritten = true;
                        }
                        if (!__tmp103_last) __out.AppendLine(true);
                    }
                }
                string __tmp104_line = ".IModel.Id => "; //1188:49
                if (!string.IsNullOrEmpty(__tmp104_line))
                {
                    __out.Append(__tmp104_line);
                    __tmp100_outputWritten = true;
                }
                StringBuilder __tmp105 = new StringBuilder();
                __tmp105.Append(CSharpName(model, ModelKind.ImmutableInstance));
                using(StreamReader __tmp105Reader = new StreamReader(this.__ToStream(__tmp105.ToString())))
                {
                    bool __tmp105_last = __tmp105Reader.EndOfStream;
                    while(!__tmp105_last)
                    {
                        string __tmp105_line = __tmp105Reader.ReadLine();
                        __tmp105_last = __tmp105Reader.EndOfStream;
                        if ((__tmp105_last && !string.IsNullOrEmpty(__tmp105_line)) || (!__tmp105_last && __tmp105_line != null))
                        {
                            __out.Append(__tmp105_line);
                            __tmp100_outputWritten = true;
                        }
                        if (!__tmp105_last) __out.AppendLine(true);
                    }
                }
                string __tmp106_line = ".MModel.Id;"; //1188:110
                if (!string.IsNullOrEmpty(__tmp106_line))
                {
                    __out.Append(__tmp106_line);
                    __tmp100_outputWritten = true;
                }
                if (__tmp100_outputWritten) __out.AppendLine(true);
                if (__tmp100_outputWritten)
                {
                    __out.AppendLine(false); //1188:121
                }
                bool __tmp108_outputWritten = false;
                string __tmp109_line = "	string "; //1189:1
                if (!string.IsNullOrEmpty(__tmp109_line))
                {
                    __out.Append(__tmp109_line);
                    __tmp108_outputWritten = true;
                }
                StringBuilder __tmp110 = new StringBuilder();
                __tmp110.Append(Properties.CoreNs);
                using(StreamReader __tmp110Reader = new StreamReader(this.__ToStream(__tmp110.ToString())))
                {
                    bool __tmp110_last = __tmp110Reader.EndOfStream;
                    while(!__tmp110_last)
                    {
                        string __tmp110_line = __tmp110Reader.ReadLine();
                        __tmp110_last = __tmp110Reader.EndOfStream;
                        if ((__tmp110_last && !string.IsNullOrEmpty(__tmp110_line)) || (!__tmp110_last && __tmp110_line != null))
                        {
                            __out.Append(__tmp110_line);
                            __tmp108_outputWritten = true;
                        }
                        if (!__tmp110_last) __out.AppendLine(true);
                    }
                }
                string __tmp111_line = ".IModel.Name => this.Name;"; //1189:28
                if (!string.IsNullOrEmpty(__tmp111_line))
                {
                    __out.Append(__tmp111_line);
                    __tmp108_outputWritten = true;
                }
                if (__tmp108_outputWritten) __out.AppendLine(true);
                if (__tmp108_outputWritten)
                {
                    __out.AppendLine(false); //1189:54
                }
                bool __tmp113_outputWritten = false;
                string __tmp112Prefix = "	"; //1190:1
                StringBuilder __tmp114 = new StringBuilder();
                __tmp114.Append(Properties.CoreNs);
                using(StreamReader __tmp114Reader = new StreamReader(this.__ToStream(__tmp114.ToString())))
                {
                    bool __tmp114_last = __tmp114Reader.EndOfStream;
                    while(!__tmp114_last)
                    {
                        string __tmp114_line = __tmp114Reader.ReadLine();
                        __tmp114_last = __tmp114Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp112Prefix))
                        {
                            __out.Append(__tmp112Prefix);
                            __tmp113_outputWritten = true;
                        }
                        if ((__tmp114_last && !string.IsNullOrEmpty(__tmp114_line)) || (!__tmp114_last && __tmp114_line != null))
                        {
                            __out.Append(__tmp114_line);
                            __tmp113_outputWritten = true;
                        }
                        if (!__tmp114_last) __out.AppendLine(true);
                    }
                }
                string __tmp115_line = ".ModelVersion "; //1190:21
                if (!string.IsNullOrEmpty(__tmp115_line))
                {
                    __out.Append(__tmp115_line);
                    __tmp113_outputWritten = true;
                }
                StringBuilder __tmp116 = new StringBuilder();
                __tmp116.Append(Properties.CoreNs);
                using(StreamReader __tmp116Reader = new StreamReader(this.__ToStream(__tmp116.ToString())))
                {
                    bool __tmp116_last = __tmp116Reader.EndOfStream;
                    while(!__tmp116_last)
                    {
                        string __tmp116_line = __tmp116Reader.ReadLine();
                        __tmp116_last = __tmp116Reader.EndOfStream;
                        if ((__tmp116_last && !string.IsNullOrEmpty(__tmp116_line)) || (!__tmp116_last && __tmp116_line != null))
                        {
                            __out.Append(__tmp116_line);
                            __tmp113_outputWritten = true;
                        }
                        if (!__tmp116_last) __out.AppendLine(true);
                    }
                }
                string __tmp117_line = ".IModel.Version => "; //1190:54
                if (!string.IsNullOrEmpty(__tmp117_line))
                {
                    __out.Append(__tmp117_line);
                    __tmp113_outputWritten = true;
                }
                StringBuilder __tmp118 = new StringBuilder();
                __tmp118.Append(CSharpName(model, ModelKind.ImmutableInstance));
                using(StreamReader __tmp118Reader = new StreamReader(this.__ToStream(__tmp118.ToString())))
                {
                    bool __tmp118_last = __tmp118Reader.EndOfStream;
                    while(!__tmp118_last)
                    {
                        string __tmp118_line = __tmp118Reader.ReadLine();
                        __tmp118_last = __tmp118Reader.EndOfStream;
                        if ((__tmp118_last && !string.IsNullOrEmpty(__tmp118_line)) || (!__tmp118_last && __tmp118_line != null))
                        {
                            __out.Append(__tmp118_line);
                            __tmp113_outputWritten = true;
                        }
                        if (!__tmp118_last) __out.AppendLine(true);
                    }
                }
                string __tmp119_line = ".MModel.Version;"; //1190:120
                if (!string.IsNullOrEmpty(__tmp119_line))
                {
                    __out.Append(__tmp119_line);
                    __tmp113_outputWritten = true;
                }
                if (__tmp113_outputWritten) __out.AppendLine(true);
                if (__tmp113_outputWritten)
                {
                    __out.AppendLine(false); //1190:136
                }
                bool __tmp121_outputWritten = false;
                string __tmp122_line = "	global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> "; //1191:1
                if (!string.IsNullOrEmpty(__tmp122_line))
                {
                    __out.Append(__tmp122_line);
                    __tmp121_outputWritten = true;
                }
                StringBuilder __tmp123 = new StringBuilder();
                __tmp123.Append(Properties.CoreNs);
                using(StreamReader __tmp123Reader = new StreamReader(this.__ToStream(__tmp123.ToString())))
                {
                    bool __tmp123_last = __tmp123Reader.EndOfStream;
                    while(!__tmp123_last)
                    {
                        string __tmp123_line = __tmp123Reader.ReadLine();
                        __tmp123_last = __tmp123Reader.EndOfStream;
                        if ((__tmp123_last && !string.IsNullOrEmpty(__tmp123_line)) || (!__tmp123_last && __tmp123_line != null))
                        {
                            __out.Append(__tmp123_line);
                            __tmp121_outputWritten = true;
                        }
                        if (!__tmp123_last) __out.AppendLine(true);
                    }
                }
                string __tmp124_line = ".IModel.Objects => "; //1191:108
                if (!string.IsNullOrEmpty(__tmp124_line))
                {
                    __out.Append(__tmp124_line);
                    __tmp121_outputWritten = true;
                }
                StringBuilder __tmp125 = new StringBuilder();
                __tmp125.Append(CSharpName(model, ModelKind.ImmutableInstance));
                using(StreamReader __tmp125Reader = new StreamReader(this.__ToStream(__tmp125.ToString())))
                {
                    bool __tmp125_last = __tmp125Reader.EndOfStream;
                    while(!__tmp125_last)
                    {
                        string __tmp125_line = __tmp125Reader.ReadLine();
                        __tmp125_last = __tmp125Reader.EndOfStream;
                        if ((__tmp125_last && !string.IsNullOrEmpty(__tmp125_line)) || (!__tmp125_last && __tmp125_line != null))
                        {
                            __out.Append(__tmp125_line);
                            __tmp121_outputWritten = true;
                        }
                        if (!__tmp125_last) __out.AppendLine(true);
                    }
                }
                string __tmp126_line = ".MModel.Objects;"; //1191:174
                if (!string.IsNullOrEmpty(__tmp126_line))
                {
                    __out.Append(__tmp126_line);
                    __tmp121_outputWritten = true;
                }
                if (__tmp121_outputWritten) __out.AppendLine(true);
                if (__tmp121_outputWritten)
                {
                    __out.AppendLine(false); //1191:190
                }
                bool __tmp128_outputWritten = false;
                string __tmp129_line = "	string "; //1192:1
                if (!string.IsNullOrEmpty(__tmp129_line))
                {
                    __out.Append(__tmp129_line);
                    __tmp128_outputWritten = true;
                }
                StringBuilder __tmp130 = new StringBuilder();
                __tmp130.Append(Properties.CoreNs);
                using(StreamReader __tmp130Reader = new StreamReader(this.__ToStream(__tmp130.ToString())))
                {
                    bool __tmp130_last = __tmp130Reader.EndOfStream;
                    while(!__tmp130_last)
                    {
                        string __tmp130_line = __tmp130Reader.ReadLine();
                        __tmp130_last = __tmp130Reader.EndOfStream;
                        if ((__tmp130_last && !string.IsNullOrEmpty(__tmp130_line)) || (!__tmp130_last && __tmp130_line != null))
                        {
                            __out.Append(__tmp130_line);
                            __tmp128_outputWritten = true;
                        }
                        if (!__tmp130_last) __out.AppendLine(true);
                    }
                }
                string __tmp131_line = ".IMetaModel.Uri => this.Uri;"; //1192:28
                if (!string.IsNullOrEmpty(__tmp131_line))
                {
                    __out.Append(__tmp131_line);
                    __tmp128_outputWritten = true;
                }
                if (__tmp128_outputWritten) __out.AppendLine(true);
                if (__tmp128_outputWritten)
                {
                    __out.AppendLine(false); //1192:56
                }
                bool __tmp133_outputWritten = false;
                string __tmp134_line = "	string "; //1193:1
                if (!string.IsNullOrEmpty(__tmp134_line))
                {
                    __out.Append(__tmp134_line);
                    __tmp133_outputWritten = true;
                }
                StringBuilder __tmp135 = new StringBuilder();
                __tmp135.Append(Properties.CoreNs);
                using(StreamReader __tmp135Reader = new StreamReader(this.__ToStream(__tmp135.ToString())))
                {
                    bool __tmp135_last = __tmp135Reader.EndOfStream;
                    while(!__tmp135_last)
                    {
                        string __tmp135_line = __tmp135Reader.ReadLine();
                        __tmp135_last = __tmp135Reader.EndOfStream;
                        if ((__tmp135_last && !string.IsNullOrEmpty(__tmp135_line)) || (!__tmp135_last && __tmp135_line != null))
                        {
                            __out.Append(__tmp135_line);
                            __tmp133_outputWritten = true;
                        }
                        if (!__tmp135_last) __out.AppendLine(true);
                    }
                }
                string __tmp136_line = ".IMetaModel.Prefix => this.Prefix;"; //1193:28
                if (!string.IsNullOrEmpty(__tmp136_line))
                {
                    __out.Append(__tmp136_line);
                    __tmp133_outputWritten = true;
                }
                if (__tmp133_outputWritten) __out.AppendLine(true);
                if (__tmp133_outputWritten)
                {
                    __out.AppendLine(false); //1193:62
                }
                bool __tmp138_outputWritten = false;
                string __tmp137Prefix = "	"; //1194:1
                StringBuilder __tmp139 = new StringBuilder();
                __tmp139.Append(Properties.CoreNs);
                using(StreamReader __tmp139Reader = new StreamReader(this.__ToStream(__tmp139.ToString())))
                {
                    bool __tmp139_last = __tmp139Reader.EndOfStream;
                    while(!__tmp139_last)
                    {
                        string __tmp139_line = __tmp139Reader.ReadLine();
                        __tmp139_last = __tmp139Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp137Prefix))
                        {
                            __out.Append(__tmp137Prefix);
                            __tmp138_outputWritten = true;
                        }
                        if ((__tmp139_last && !string.IsNullOrEmpty(__tmp139_line)) || (!__tmp139_last && __tmp139_line != null))
                        {
                            __out.Append(__tmp139_line);
                            __tmp138_outputWritten = true;
                        }
                        if (!__tmp139_last) __out.AppendLine(true);
                    }
                }
                string __tmp140_line = ".IModelGroup "; //1194:21
                if (!string.IsNullOrEmpty(__tmp140_line))
                {
                    __out.Append(__tmp140_line);
                    __tmp138_outputWritten = true;
                }
                StringBuilder __tmp141 = new StringBuilder();
                __tmp141.Append(Properties.CoreNs);
                using(StreamReader __tmp141Reader = new StreamReader(this.__ToStream(__tmp141.ToString())))
                {
                    bool __tmp141_last = __tmp141Reader.EndOfStream;
                    while(!__tmp141_last)
                    {
                        string __tmp141_line = __tmp141Reader.ReadLine();
                        __tmp141_last = __tmp141Reader.EndOfStream;
                        if ((__tmp141_last && !string.IsNullOrEmpty(__tmp141_line)) || (!__tmp141_last && __tmp141_line != null))
                        {
                            __out.Append(__tmp141_line);
                            __tmp138_outputWritten = true;
                        }
                        if (!__tmp141_last) __out.AppendLine(true);
                    }
                }
                string __tmp142_line = ".IModel.ModelGroup => "; //1194:53
                if (!string.IsNullOrEmpty(__tmp142_line))
                {
                    __out.Append(__tmp142_line);
                    __tmp138_outputWritten = true;
                }
                StringBuilder __tmp143 = new StringBuilder();
                __tmp143.Append(CSharpName(model, ModelKind.ImmutableInstance));
                using(StreamReader __tmp143Reader = new StreamReader(this.__ToStream(__tmp143.ToString())))
                {
                    bool __tmp143_last = __tmp143Reader.EndOfStream;
                    while(!__tmp143_last)
                    {
                        string __tmp143_line = __tmp143Reader.ReadLine();
                        __tmp143_last = __tmp143Reader.EndOfStream;
                        if ((__tmp143_last && !string.IsNullOrEmpty(__tmp143_line)) || (!__tmp143_last && __tmp143_line != null))
                        {
                            __out.Append(__tmp143_line);
                            __tmp138_outputWritten = true;
                        }
                        if (!__tmp143_last) __out.AppendLine(true);
                    }
                }
                string __tmp144_line = ".MModel.ModelGroup;"; //1194:122
                if (!string.IsNullOrEmpty(__tmp144_line))
                {
                    __out.Append(__tmp144_line);
                    __tmp138_outputWritten = true;
                }
                if (__tmp138_outputWritten) __out.AppendLine(true);
                if (__tmp138_outputWritten)
                {
                    __out.AppendLine(false); //1194:141
                }
                bool __tmp146_outputWritten = false;
                string __tmp147_line = "	string "; //1195:1
                if (!string.IsNullOrEmpty(__tmp147_line))
                {
                    __out.Append(__tmp147_line);
                    __tmp146_outputWritten = true;
                }
                StringBuilder __tmp148 = new StringBuilder();
                __tmp148.Append(Properties.CoreNs);
                using(StreamReader __tmp148Reader = new StreamReader(this.__ToStream(__tmp148.ToString())))
                {
                    bool __tmp148_last = __tmp148Reader.EndOfStream;
                    while(!__tmp148_last)
                    {
                        string __tmp148_line = __tmp148Reader.ReadLine();
                        __tmp148_last = __tmp148Reader.EndOfStream;
                        if ((__tmp148_last && !string.IsNullOrEmpty(__tmp148_line)) || (!__tmp148_last && __tmp148_line != null))
                        {
                            __out.Append(__tmp148_line);
                            __tmp146_outputWritten = true;
                        }
                        if (!__tmp148_last) __out.AppendLine(true);
                    }
                }
                string __tmp149_line = ".IMetaModel.Namespace => this.Namespace.FullName;"; //1195:28
                if (!string.IsNullOrEmpty(__tmp149_line))
                {
                    __out.Append(__tmp149_line);
                    __tmp146_outputWritten = true;
                }
                if (__tmp146_outputWritten) __out.AppendLine(true);
                if (__tmp146_outputWritten)
                {
                    __out.AppendLine(false); //1195:77
                }
                __out.AppendLine(true); //1196:1
                bool __tmp151_outputWritten = false;
                string __tmp152_line = "	public "; //1197:1
                if (!string.IsNullOrEmpty(__tmp152_line))
                {
                    __out.Append(__tmp152_line);
                    __tmp151_outputWritten = true;
                }
                StringBuilder __tmp153 = new StringBuilder();
                __tmp153.Append(Properties.CoreNs);
                using(StreamReader __tmp153Reader = new StreamReader(this.__ToStream(__tmp153.ToString())))
                {
                    bool __tmp153_last = __tmp153Reader.EndOfStream;
                    while(!__tmp153_last)
                    {
                        string __tmp153_line = __tmp153Reader.ReadLine();
                        __tmp153_last = __tmp153Reader.EndOfStream;
                        if ((__tmp153_last && !string.IsNullOrEmpty(__tmp153_line)) || (!__tmp153_last && __tmp153_line != null))
                        {
                            __out.Append(__tmp153_line);
                            __tmp151_outputWritten = true;
                        }
                        if (!__tmp153_last) __out.AppendLine(true);
                    }
                }
                string __tmp154_line = ".IModelFactory CreateFactory("; //1197:28
                if (!string.IsNullOrEmpty(__tmp154_line))
                {
                    __out.Append(__tmp154_line);
                    __tmp151_outputWritten = true;
                }
                StringBuilder __tmp155 = new StringBuilder();
                __tmp155.Append(Properties.CoreNs);
                using(StreamReader __tmp155Reader = new StreamReader(this.__ToStream(__tmp155.ToString())))
                {
                    bool __tmp155_last = __tmp155Reader.EndOfStream;
                    while(!__tmp155_last)
                    {
                        string __tmp155_line = __tmp155Reader.ReadLine();
                        __tmp155_last = __tmp155Reader.EndOfStream;
                        if ((__tmp155_last && !string.IsNullOrEmpty(__tmp155_line)) || (!__tmp155_last && __tmp155_line != null))
                        {
                            __out.Append(__tmp155_line);
                            __tmp151_outputWritten = true;
                        }
                        if (!__tmp155_last) __out.AppendLine(true);
                    }
                }
                string __tmp156_line = ".MutableModel model, "; //1197:76
                if (!string.IsNullOrEmpty(__tmp156_line))
                {
                    __out.Append(__tmp156_line);
                    __tmp151_outputWritten = true;
                }
                StringBuilder __tmp157 = new StringBuilder();
                __tmp157.Append(Properties.CoreNs);
                using(StreamReader __tmp157Reader = new StreamReader(this.__ToStream(__tmp157.ToString())))
                {
                    bool __tmp157_last = __tmp157Reader.EndOfStream;
                    while(!__tmp157_last)
                    {
                        string __tmp157_line = __tmp157Reader.ReadLine();
                        __tmp157_last = __tmp157Reader.EndOfStream;
                        if ((__tmp157_last && !string.IsNullOrEmpty(__tmp157_line)) || (!__tmp157_last && __tmp157_line != null))
                        {
                            __out.Append(__tmp157_line);
                            __tmp151_outputWritten = true;
                        }
                        if (!__tmp157_last) __out.AppendLine(true);
                    }
                }
                string __tmp158_line = ".ModelFactoryFlags flags = "; //1197:116
                if (!string.IsNullOrEmpty(__tmp158_line))
                {
                    __out.Append(__tmp158_line);
                    __tmp151_outputWritten = true;
                }
                StringBuilder __tmp159 = new StringBuilder();
                __tmp159.Append(Properties.CoreNs);
                using(StreamReader __tmp159Reader = new StreamReader(this.__ToStream(__tmp159.ToString())))
                {
                    bool __tmp159_last = __tmp159Reader.EndOfStream;
                    while(!__tmp159_last)
                    {
                        string __tmp159_line = __tmp159Reader.ReadLine();
                        __tmp159_last = __tmp159Reader.EndOfStream;
                        if ((__tmp159_last && !string.IsNullOrEmpty(__tmp159_line)) || (!__tmp159_last && __tmp159_line != null))
                        {
                            __out.Append(__tmp159_line);
                            __tmp151_outputWritten = true;
                        }
                        if (!__tmp159_last) __out.AppendLine(true);
                    }
                }
                string __tmp160_line = ".ModelFactoryFlags.None)"; //1197:162
                if (!string.IsNullOrEmpty(__tmp160_line))
                {
                    __out.Append(__tmp160_line);
                    __tmp151_outputWritten = true;
                }
                if (__tmp151_outputWritten) __out.AppendLine(true);
                if (__tmp151_outputWritten)
                {
                    __out.AppendLine(false); //1197:186
                }
                __out.Append("	{"); //1198:1
                __out.AppendLine(false); //1198:3
                bool __tmp162_outputWritten = false;
                string __tmp163_line = "		return new "; //1199:1
                if (!string.IsNullOrEmpty(__tmp163_line))
                {
                    __out.Append(__tmp163_line);
                    __tmp162_outputWritten = true;
                }
                StringBuilder __tmp164 = new StringBuilder();
                __tmp164.Append(CSharpName(model, ModelKind.Factory));
                using(StreamReader __tmp164Reader = new StreamReader(this.__ToStream(__tmp164.ToString())))
                {
                    bool __tmp164_last = __tmp164Reader.EndOfStream;
                    while(!__tmp164_last)
                    {
                        string __tmp164_line = __tmp164Reader.ReadLine();
                        __tmp164_last = __tmp164Reader.EndOfStream;
                        if ((__tmp164_last && !string.IsNullOrEmpty(__tmp164_line)) || (!__tmp164_last && __tmp164_line != null))
                        {
                            __out.Append(__tmp164_line);
                            __tmp162_outputWritten = true;
                        }
                        if (!__tmp164_last) __out.AppendLine(true);
                    }
                }
                string __tmp165_line = "(model, flags);"; //1199:51
                if (!string.IsNullOrEmpty(__tmp165_line))
                {
                    __out.Append(__tmp165_line);
                    __tmp162_outputWritten = true;
                }
                if (__tmp162_outputWritten) __out.AppendLine(true);
                if (__tmp162_outputWritten)
                {
                    __out.AppendLine(false); //1199:66
                }
                __out.Append("	}"); //1200:1
                __out.AppendLine(false); //1200:3
            }
            __out.Append("}"); //1202:1
            __out.AppendLine(false); //1202:2
            return __out.ToString();
        }

        public string GenerateBuilderField(MetaModel model, MetaClass cls, MetaProperty prop) //1205:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "private "; //1206:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last) __out.AppendLine(true);
                }
            }
            string __tmp5_line = " "; //1206:63
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Append(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GetFieldName(prop, cls));
            using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
            {
                bool __tmp6_last = __tmp6Reader.EndOfStream;
                while(!__tmp6_last)
                {
                    string __tmp6_line = __tmp6Reader.ReadLine();
                    __tmp6_last = __tmp6Reader.EndOfStream;
                    if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp6_last) __out.AppendLine(true);
                }
            }
            string __tmp7_line = ";"; //1206:88
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1206:89
            }
            return __out.ToString();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //1209:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1210:1
            if (cls.GetAllFinalProperties().Contains(prop)) //1211:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //1212:1
                if (!string.IsNullOrEmpty(__tmp3_line))
                {
                    __out.Append(__tmp3_line);
                    __tmp2_outputWritten = true;
                }
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
                using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
                {
                    bool __tmp4_last = __tmp4Reader.EndOfStream;
                    while(!__tmp4_last)
                    {
                        string __tmp4_line = __tmp4Reader.ReadLine();
                        __tmp4_last = __tmp4Reader.EndOfStream;
                        if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                        {
                            __out.Append(__tmp4_line);
                            __tmp2_outputWritten = true;
                        }
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
                string __tmp5_line = " "; //1212:62
                if (!string.IsNullOrEmpty(__tmp5_line))
                {
                    __out.Append(__tmp5_line);
                    __tmp2_outputWritten = true;
                }
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append(prop.Name);
                using(StreamReader __tmp6Reader = new StreamReader(this.__ToStream(__tmp6.ToString())))
                {
                    bool __tmp6_last = __tmp6Reader.EndOfStream;
                    while(!__tmp6_last)
                    {
                        string __tmp6_line = __tmp6Reader.ReadLine();
                        __tmp6_last = __tmp6Reader.EndOfStream;
                        if ((__tmp6_last && !string.IsNullOrEmpty(__tmp6_line)) || (!__tmp6_last && __tmp6_line != null))
                        {
                            __out.Append(__tmp6_line);
                            __tmp2_outputWritten = true;
                        }
                        if (!__tmp6_last || __tmp2_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //1212:74
                }
            }
            else //1213:2
            {
                bool __tmp8_outputWritten = false;
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
                {
                    bool __tmp9_last = __tmp9Reader.EndOfStream;
                    while(!__tmp9_last)
                    {
                        string __tmp9_line = __tmp9Reader.ReadLine();
                        __tmp9_last = __tmp9Reader.EndOfStream;
                        if ((__tmp9_last && !string.IsNullOrEmpty(__tmp9_line)) || (!__tmp9_last && __tmp9_line != null))
                        {
                            __out.Append(__tmp9_line);
                            __tmp8_outputWritten = true;
                        }
                        if (!__tmp9_last || __tmp8_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp8_outputWritten)
                {
                    __out.AppendLine(false); //1214:54
                }
                bool __tmp11_outputWritten = false;
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
                using(StreamReader __tmp12Reader = new StreamReader(this.__ToStream(__tmp12.ToString())))
                {
                    bool __tmp12_last = __tmp12Reader.EndOfStream;
                    while(!__tmp12_last)
                    {
                        string __tmp12_line = __tmp12Reader.ReadLine();
                        __tmp12_last = __tmp12Reader.EndOfStream;
                        if ((__tmp12_last && !string.IsNullOrEmpty(__tmp12_line)) || (!__tmp12_last && __tmp12_line != null))
                        {
                            __out.Append(__tmp12_line);
                            __tmp11_outputWritten = true;
                        }
                        if (!__tmp12_last) __out.AppendLine(true);
                    }
                }
                string __tmp13_line = " "; //1215:55
                if (!string.IsNullOrEmpty(__tmp13_line))
                {
                    __out.Append(__tmp13_line);
                    __tmp11_outputWritten = true;
                }
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(CSharpName(prop.Class, model, ClassKind.Builder, true));
                using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
                {
                    bool __tmp14_last = __tmp14Reader.EndOfStream;
                    while(!__tmp14_last)
                    {
                        string __tmp14_line = __tmp14Reader.ReadLine();
                        __tmp14_last = __tmp14Reader.EndOfStream;
                        if ((__tmp14_last && !string.IsNullOrEmpty(__tmp14_line)) || (!__tmp14_last && __tmp14_line != null))
                        {
                            __out.Append(__tmp14_line);
                            __tmp11_outputWritten = true;
                        }
                        if (!__tmp14_last) __out.AppendLine(true);
                    }
                }
                string __tmp15_line = "."; //1215:111
                if (!string.IsNullOrEmpty(__tmp15_line))
                {
                    __out.Append(__tmp15_line);
                    __tmp11_outputWritten = true;
                }
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(prop.Name);
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_last = __tmp16Reader.EndOfStream;
                    while(!__tmp16_last)
                    {
                        string __tmp16_line = __tmp16Reader.ReadLine();
                        __tmp16_last = __tmp16Reader.EndOfStream;
                        if ((__tmp16_last && !string.IsNullOrEmpty(__tmp16_line)) || (!__tmp16_last && __tmp16_line != null))
                        {
                            __out.Append(__tmp16_line);
                            __tmp11_outputWritten = true;
                        }
                        if (!__tmp16_last || __tmp11_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //1215:123
                }
            }
            __out.Append("{"); //1217:1
            __out.AppendLine(false); //1217:2
            if (prop.Type is MetaCollectionType) //1218:3
            {
                if (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.Set || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet) //1219:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "	get { return this.GetSet<"; //1220:1
                    if (!string.IsNullOrEmpty(__tmp19_line))
                    {
                        __out.Append(__tmp19_line);
                        __tmp18_outputWritten = true;
                    }
                    StringBuilder __tmp20 = new StringBuilder();
                    __tmp20.Append(CSharpName(((MetaCollectionType)prop.Type).InnerType, model, ClassKind.Builder, true));
                    using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
                    {
                        bool __tmp20_last = __tmp20Reader.EndOfStream;
                        while(!__tmp20_last)
                        {
                            string __tmp20_line = __tmp20Reader.ReadLine();
                            __tmp20_last = __tmp20Reader.EndOfStream;
                            if ((__tmp20_last && !string.IsNullOrEmpty(__tmp20_line)) || (!__tmp20_last && __tmp20_line != null))
                            {
                                __out.Append(__tmp20_line);
                                __tmp18_outputWritten = true;
                            }
                            if (!__tmp20_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp21_line = ">("; //1220:113
                    if (!string.IsNullOrEmpty(__tmp21_line))
                    {
                        __out.Append(__tmp21_line);
                        __tmp18_outputWritten = true;
                    }
                    StringBuilder __tmp22 = new StringBuilder();
                    __tmp22.Append(CSharpName(prop, null, PropertyKind.Descriptor, true));
                    using(StreamReader __tmp22Reader = new StreamReader(this.__ToStream(__tmp22.ToString())))
                    {
                        bool __tmp22_last = __tmp22Reader.EndOfStream;
                        while(!__tmp22_last)
                        {
                            string __tmp22_line = __tmp22Reader.ReadLine();
                            __tmp22_last = __tmp22Reader.EndOfStream;
                            if ((__tmp22_last && !string.IsNullOrEmpty(__tmp22_line)) || (!__tmp22_last && __tmp22_line != null))
                            {
                                __out.Append(__tmp22_line);
                                __tmp18_outputWritten = true;
                            }
                            if (!__tmp22_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp23_line = ", ref "; //1220:169
                    if (!string.IsNullOrEmpty(__tmp23_line))
                    {
                        __out.Append(__tmp23_line);
                        __tmp18_outputWritten = true;
                    }
                    StringBuilder __tmp24 = new StringBuilder();
                    __tmp24.Append(GetFieldName(prop, cls));
                    using(StreamReader __tmp24Reader = new StreamReader(this.__ToStream(__tmp24.ToString())))
                    {
                        bool __tmp24_last = __tmp24Reader.EndOfStream;
                        while(!__tmp24_last)
                        {
                            string __tmp24_line = __tmp24Reader.ReadLine();
                            __tmp24_last = __tmp24Reader.EndOfStream;
                            if ((__tmp24_last && !string.IsNullOrEmpty(__tmp24_line)) || (!__tmp24_last && __tmp24_line != null))
                            {
                                __out.Append(__tmp24_line);
                                __tmp18_outputWritten = true;
                            }
                            if (!__tmp24_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp25_line = "); }"; //1220:199
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Append(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //1220:203
                    }
                }
                else //1221:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "	get { return this.GetList<"; //1222:1
                    if (!string.IsNullOrEmpty(__tmp28_line))
                    {
                        __out.Append(__tmp28_line);
                        __tmp27_outputWritten = true;
                    }
                    StringBuilder __tmp29 = new StringBuilder();
                    __tmp29.Append(CSharpName(((MetaCollectionType)prop.Type).InnerType, model, ClassKind.Builder, true));
                    using(StreamReader __tmp29Reader = new StreamReader(this.__ToStream(__tmp29.ToString())))
                    {
                        bool __tmp29_last = __tmp29Reader.EndOfStream;
                        while(!__tmp29_last)
                        {
                            string __tmp29_line = __tmp29Reader.ReadLine();
                            __tmp29_last = __tmp29Reader.EndOfStream;
                            if ((__tmp29_last && !string.IsNullOrEmpty(__tmp29_line)) || (!__tmp29_last && __tmp29_line != null))
                            {
                                __out.Append(__tmp29_line);
                                __tmp27_outputWritten = true;
                            }
                            if (!__tmp29_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp30_line = ">("; //1222:114
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Append(__tmp30_line);
                        __tmp27_outputWritten = true;
                    }
                    StringBuilder __tmp31 = new StringBuilder();
                    __tmp31.Append(CSharpName(prop, null, PropertyKind.Descriptor, true));
                    using(StreamReader __tmp31Reader = new StreamReader(this.__ToStream(__tmp31.ToString())))
                    {
                        bool __tmp31_last = __tmp31Reader.EndOfStream;
                        while(!__tmp31_last)
                        {
                            string __tmp31_line = __tmp31Reader.ReadLine();
                            __tmp31_last = __tmp31Reader.EndOfStream;
                            if ((__tmp31_last && !string.IsNullOrEmpty(__tmp31_line)) || (!__tmp31_last && __tmp31_line != null))
                            {
                                __out.Append(__tmp31_line);
                                __tmp27_outputWritten = true;
                            }
                            if (!__tmp31_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp32_line = ", ref "; //1222:170
                    if (!string.IsNullOrEmpty(__tmp32_line))
                    {
                        __out.Append(__tmp32_line);
                        __tmp27_outputWritten = true;
                    }
                    StringBuilder __tmp33 = new StringBuilder();
                    __tmp33.Append(GetFieldName(prop, cls));
                    using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
                    {
                        bool __tmp33_last = __tmp33Reader.EndOfStream;
                        while(!__tmp33_last)
                        {
                            string __tmp33_line = __tmp33Reader.ReadLine();
                            __tmp33_last = __tmp33Reader.EndOfStream;
                            if ((__tmp33_last && !string.IsNullOrEmpty(__tmp33_line)) || (!__tmp33_last && __tmp33_line != null))
                            {
                                __out.Append(__tmp33_line);
                                __tmp27_outputWritten = true;
                            }
                            if (!__tmp33_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp34_line = "); }"; //1222:200
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Append(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //1222:204
                    }
                }
            }
            else if (IsReferenceType(prop.Type)) //1224:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "	get { return this.GetReference<"; //1225:1
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp36_outputWritten = true;
                }
                StringBuilder __tmp38 = new StringBuilder();
                __tmp38.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
                using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
                {
                    bool __tmp38_last = __tmp38Reader.EndOfStream;
                    while(!__tmp38_last)
                    {
                        string __tmp38_line = __tmp38Reader.ReadLine();
                        __tmp38_last = __tmp38Reader.EndOfStream;
                        if ((__tmp38_last && !string.IsNullOrEmpty(__tmp38_line)) || (!__tmp38_last && __tmp38_line != null))
                        {
                            __out.Append(__tmp38_line);
                            __tmp36_outputWritten = true;
                        }
                        if (!__tmp38_last) __out.AppendLine(true);
                    }
                }
                string __tmp39_line = ">("; //1225:87
                if (!string.IsNullOrEmpty(__tmp39_line))
                {
                    __out.Append(__tmp39_line);
                    __tmp36_outputWritten = true;
                }
                StringBuilder __tmp40 = new StringBuilder();
                __tmp40.Append(CSharpName(prop, null, PropertyKind.Descriptor, true));
                using(StreamReader __tmp40Reader = new StreamReader(this.__ToStream(__tmp40.ToString())))
                {
                    bool __tmp40_last = __tmp40Reader.EndOfStream;
                    while(!__tmp40_last)
                    {
                        string __tmp40_line = __tmp40Reader.ReadLine();
                        __tmp40_last = __tmp40Reader.EndOfStream;
                        if ((__tmp40_last && !string.IsNullOrEmpty(__tmp40_line)) || (!__tmp40_last && __tmp40_line != null))
                        {
                            __out.Append(__tmp40_line);
                            __tmp36_outputWritten = true;
                        }
                        if (!__tmp40_last) __out.AppendLine(true);
                    }
                }
                string __tmp41_line = "); }"; //1225:143
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Append(__tmp41_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //1225:147
                }
            }
            else //1226:3
            {
                bool __tmp43_outputWritten = false;
                string __tmp44_line = "	get { return this.GetValue<"; //1227:1
                if (!string.IsNullOrEmpty(__tmp44_line))
                {
                    __out.Append(__tmp44_line);
                    __tmp43_outputWritten = true;
                }
                StringBuilder __tmp45 = new StringBuilder();
                __tmp45.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
                using(StreamReader __tmp45Reader = new StreamReader(this.__ToStream(__tmp45.ToString())))
                {
                    bool __tmp45_last = __tmp45Reader.EndOfStream;
                    while(!__tmp45_last)
                    {
                        string __tmp45_line = __tmp45Reader.ReadLine();
                        __tmp45_last = __tmp45Reader.EndOfStream;
                        if ((__tmp45_last && !string.IsNullOrEmpty(__tmp45_line)) || (!__tmp45_last && __tmp45_line != null))
                        {
                            __out.Append(__tmp45_line);
                            __tmp43_outputWritten = true;
                        }
                        if (!__tmp45_last) __out.AppendLine(true);
                    }
                }
                string __tmp46_line = ">("; //1227:83
                if (!string.IsNullOrEmpty(__tmp46_line))
                {
                    __out.Append(__tmp46_line);
                    __tmp43_outputWritten = true;
                }
                StringBuilder __tmp47 = new StringBuilder();
                __tmp47.Append(CSharpName(prop, null, PropertyKind.Descriptor, true));
                using(StreamReader __tmp47Reader = new StreamReader(this.__ToStream(__tmp47.ToString())))
                {
                    bool __tmp47_last = __tmp47Reader.EndOfStream;
                    while(!__tmp47_last)
                    {
                        string __tmp47_line = __tmp47Reader.ReadLine();
                        __tmp47_last = __tmp47Reader.EndOfStream;
                        if ((__tmp47_last && !string.IsNullOrEmpty(__tmp47_line)) || (!__tmp47_last && __tmp47_line != null))
                        {
                            __out.Append(__tmp47_line);
                            __tmp43_outputWritten = true;
                        }
                        if (!__tmp47_last) __out.AppendLine(true);
                    }
                }
                string __tmp48_line = "); }"; //1227:139
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Append(__tmp48_line);
                    __tmp43_outputWritten = true;
                }
                if (__tmp43_outputWritten) __out.AppendLine(true);
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //1227:143
                }
            }
            if ((prop.Kind == MetaPropertyKind.Normal) && !(prop.Type is MetaCollectionType)) //1229:3
            {
                if (IsReferenceType(prop.Type)) //1230:4
                {
                    bool __tmp50_outputWritten = false;
                    string __tmp51_line = "	set { this.SetReference<"; //1231:1
                    if (!string.IsNullOrEmpty(__tmp51_line))
                    {
                        __out.Append(__tmp51_line);
                        __tmp50_outputWritten = true;
                    }
                    StringBuilder __tmp52 = new StringBuilder();
                    __tmp52.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
                    using(StreamReader __tmp52Reader = new StreamReader(this.__ToStream(__tmp52.ToString())))
                    {
                        bool __tmp52_last = __tmp52Reader.EndOfStream;
                        while(!__tmp52_last)
                        {
                            string __tmp52_line = __tmp52Reader.ReadLine();
                            __tmp52_last = __tmp52Reader.EndOfStream;
                            if ((__tmp52_last && !string.IsNullOrEmpty(__tmp52_line)) || (!__tmp52_last && __tmp52_line != null))
                            {
                                __out.Append(__tmp52_line);
                                __tmp50_outputWritten = true;
                            }
                            if (!__tmp52_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp53_line = ">("; //1231:80
                    if (!string.IsNullOrEmpty(__tmp53_line))
                    {
                        __out.Append(__tmp53_line);
                        __tmp50_outputWritten = true;
                    }
                    StringBuilder __tmp54 = new StringBuilder();
                    __tmp54.Append(CSharpName(prop, null, PropertyKind.Descriptor, true));
                    using(StreamReader __tmp54Reader = new StreamReader(this.__ToStream(__tmp54.ToString())))
                    {
                        bool __tmp54_last = __tmp54Reader.EndOfStream;
                        while(!__tmp54_last)
                        {
                            string __tmp54_line = __tmp54Reader.ReadLine();
                            __tmp54_last = __tmp54Reader.EndOfStream;
                            if ((__tmp54_last && !string.IsNullOrEmpty(__tmp54_line)) || (!__tmp54_last && __tmp54_line != null))
                            {
                                __out.Append(__tmp54_line);
                                __tmp50_outputWritten = true;
                            }
                            if (!__tmp54_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp55_line = ", value); }"; //1231:136
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Append(__tmp55_line);
                        __tmp50_outputWritten = true;
                    }
                    if (__tmp50_outputWritten) __out.AppendLine(true);
                    if (__tmp50_outputWritten)
                    {
                        __out.AppendLine(false); //1231:147
                    }
                }
                else //1232:4
                {
                    bool __tmp57_outputWritten = false;
                    string __tmp58_line = "	set { this.SetValue<"; //1233:1
                    if (!string.IsNullOrEmpty(__tmp58_line))
                    {
                        __out.Append(__tmp58_line);
                        __tmp57_outputWritten = true;
                    }
                    StringBuilder __tmp59 = new StringBuilder();
                    __tmp59.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
                    using(StreamReader __tmp59Reader = new StreamReader(this.__ToStream(__tmp59.ToString())))
                    {
                        bool __tmp59_last = __tmp59Reader.EndOfStream;
                        while(!__tmp59_last)
                        {
                            string __tmp59_line = __tmp59Reader.ReadLine();
                            __tmp59_last = __tmp59Reader.EndOfStream;
                            if ((__tmp59_last && !string.IsNullOrEmpty(__tmp59_line)) || (!__tmp59_last && __tmp59_line != null))
                            {
                                __out.Append(__tmp59_line);
                                __tmp57_outputWritten = true;
                            }
                            if (!__tmp59_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp60_line = ">("; //1233:76
                    if (!string.IsNullOrEmpty(__tmp60_line))
                    {
                        __out.Append(__tmp60_line);
                        __tmp57_outputWritten = true;
                    }
                    StringBuilder __tmp61 = new StringBuilder();
                    __tmp61.Append(CSharpName(prop, null, PropertyKind.Descriptor, true));
                    using(StreamReader __tmp61Reader = new StreamReader(this.__ToStream(__tmp61.ToString())))
                    {
                        bool __tmp61_last = __tmp61Reader.EndOfStream;
                        while(!__tmp61_last)
                        {
                            string __tmp61_line = __tmp61Reader.ReadLine();
                            __tmp61_last = __tmp61Reader.EndOfStream;
                            if ((__tmp61_last && !string.IsNullOrEmpty(__tmp61_line)) || (!__tmp61_last && __tmp61_line != null))
                            {
                                __out.Append(__tmp61_line);
                                __tmp57_outputWritten = true;
                            }
                            if (!__tmp61_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp62_line = ", value); }"; //1233:132
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Append(__tmp62_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //1233:143
                    }
                }
            }
            __out.Append("}"); //1236:1
            __out.AppendLine(false); //1236:2
            if (!(prop.Type is MetaCollectionType)) //1237:2
            {
                __out.AppendLine(true); //1238:1
                bool __tmp64_outputWritten = false;
                string __tmp65_line = "void "; //1239:1
                if (!string.IsNullOrEmpty(__tmp65_line))
                {
                    __out.Append(__tmp65_line);
                    __tmp64_outputWritten = true;
                }
                StringBuilder __tmp66 = new StringBuilder();
                __tmp66.Append(CSharpName(prop.Class, model, ClassKind.Builder, true));
                using(StreamReader __tmp66Reader = new StreamReader(this.__ToStream(__tmp66.ToString())))
                {
                    bool __tmp66_last = __tmp66Reader.EndOfStream;
                    while(!__tmp66_last)
                    {
                        string __tmp66_line = __tmp66Reader.ReadLine();
                        __tmp66_last = __tmp66Reader.EndOfStream;
                        if ((__tmp66_last && !string.IsNullOrEmpty(__tmp66_line)) || (!__tmp66_last && __tmp66_line != null))
                        {
                            __out.Append(__tmp66_line);
                            __tmp64_outputWritten = true;
                        }
                        if (!__tmp66_last) __out.AppendLine(true);
                    }
                }
                string __tmp67_line = ".Set"; //1239:61
                if (!string.IsNullOrEmpty(__tmp67_line))
                {
                    __out.Append(__tmp67_line);
                    __tmp64_outputWritten = true;
                }
                StringBuilder __tmp68 = new StringBuilder();
                __tmp68.Append(prop.Name);
                using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
                {
                    bool __tmp68_last = __tmp68Reader.EndOfStream;
                    while(!__tmp68_last)
                    {
                        string __tmp68_line = __tmp68Reader.ReadLine();
                        __tmp68_last = __tmp68Reader.EndOfStream;
                        if ((__tmp68_last && !string.IsNullOrEmpty(__tmp68_line)) || (!__tmp68_last && __tmp68_line != null))
                        {
                            __out.Append(__tmp68_line);
                            __tmp64_outputWritten = true;
                        }
                        if (!__tmp68_last) __out.AppendLine(true);
                    }
                }
                string __tmp69_line = "Lazy(global::System.Func<"; //1239:76
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Append(__tmp69_line);
                    __tmp64_outputWritten = true;
                }
                StringBuilder __tmp70 = new StringBuilder();
                __tmp70.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
                using(StreamReader __tmp70Reader = new StreamReader(this.__ToStream(__tmp70.ToString())))
                {
                    bool __tmp70_last = __tmp70Reader.EndOfStream;
                    while(!__tmp70_last)
                    {
                        string __tmp70_line = __tmp70Reader.ReadLine();
                        __tmp70_last = __tmp70Reader.EndOfStream;
                        if ((__tmp70_last && !string.IsNullOrEmpty(__tmp70_line)) || (!__tmp70_last && __tmp70_line != null))
                        {
                            __out.Append(__tmp70_line);
                            __tmp64_outputWritten = true;
                        }
                        if (!__tmp70_last) __out.AppendLine(true);
                    }
                }
                string __tmp71_line = "> lazy)"; //1239:155
                if (!string.IsNullOrEmpty(__tmp71_line))
                {
                    __out.Append(__tmp71_line);
                    __tmp64_outputWritten = true;
                }
                if (__tmp64_outputWritten) __out.AppendLine(true);
                if (__tmp64_outputWritten)
                {
                    __out.AppendLine(false); //1239:162
                }
                __out.Append("{"); //1240:1
                __out.AppendLine(false); //1240:2
                if (IsReferenceType(prop.Type)) //1241:3
                {
                    bool __tmp73_outputWritten = false;
                    string __tmp74_line = "	this.SetLazyReference("; //1242:1
                    if (!string.IsNullOrEmpty(__tmp74_line))
                    {
                        __out.Append(__tmp74_line);
                        __tmp73_outputWritten = true;
                    }
                    StringBuilder __tmp75 = new StringBuilder();
                    __tmp75.Append(CSharpName(prop, model, PropertyKind.Descriptor, true));
                    using(StreamReader __tmp75Reader = new StreamReader(this.__ToStream(__tmp75.ToString())))
                    {
                        bool __tmp75_last = __tmp75Reader.EndOfStream;
                        while(!__tmp75_last)
                        {
                            string __tmp75_line = __tmp75Reader.ReadLine();
                            __tmp75_last = __tmp75Reader.EndOfStream;
                            if ((__tmp75_last && !string.IsNullOrEmpty(__tmp75_line)) || (!__tmp75_last && __tmp75_line != null))
                            {
                                __out.Append(__tmp75_line);
                                __tmp73_outputWritten = true;
                            }
                            if (!__tmp75_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp76_line = ", lazy);"; //1242:79
                    if (!string.IsNullOrEmpty(__tmp76_line))
                    {
                        __out.Append(__tmp76_line);
                        __tmp73_outputWritten = true;
                    }
                    if (__tmp73_outputWritten) __out.AppendLine(true);
                    if (__tmp73_outputWritten)
                    {
                        __out.AppendLine(false); //1242:87
                    }
                }
                else //1243:3
                {
                    bool __tmp78_outputWritten = false;
                    string __tmp79_line = "	this.SetLazyValue("; //1244:1
                    if (!string.IsNullOrEmpty(__tmp79_line))
                    {
                        __out.Append(__tmp79_line);
                        __tmp78_outputWritten = true;
                    }
                    StringBuilder __tmp80 = new StringBuilder();
                    __tmp80.Append(CSharpName(prop, model, PropertyKind.Descriptor, true));
                    using(StreamReader __tmp80Reader = new StreamReader(this.__ToStream(__tmp80.ToString())))
                    {
                        bool __tmp80_last = __tmp80Reader.EndOfStream;
                        while(!__tmp80_last)
                        {
                            string __tmp80_line = __tmp80Reader.ReadLine();
                            __tmp80_last = __tmp80Reader.EndOfStream;
                            if ((__tmp80_last && !string.IsNullOrEmpty(__tmp80_line)) || (!__tmp80_last && __tmp80_line != null))
                            {
                                __out.Append(__tmp80_line);
                                __tmp78_outputWritten = true;
                            }
                            if (!__tmp80_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp81_line = ", lazy);"; //1244:75
                    if (!string.IsNullOrEmpty(__tmp81_line))
                    {
                        __out.Append(__tmp81_line);
                        __tmp78_outputWritten = true;
                    }
                    if (__tmp78_outputWritten) __out.AppendLine(true);
                    if (__tmp78_outputWritten)
                    {
                        __out.AppendLine(false); //1244:83
                    }
                }
                __out.Append("}"); //1246:1
                __out.AppendLine(false); //1246:2
                __out.AppendLine(true); //1247:1
                bool __tmp83_outputWritten = false;
                string __tmp84_line = "void "; //1248:1
                if (!string.IsNullOrEmpty(__tmp84_line))
                {
                    __out.Append(__tmp84_line);
                    __tmp83_outputWritten = true;
                }
                StringBuilder __tmp85 = new StringBuilder();
                __tmp85.Append(CSharpName(prop.Class, model, ClassKind.Builder, true));
                using(StreamReader __tmp85Reader = new StreamReader(this.__ToStream(__tmp85.ToString())))
                {
                    bool __tmp85_last = __tmp85Reader.EndOfStream;
                    while(!__tmp85_last)
                    {
                        string __tmp85_line = __tmp85Reader.ReadLine();
                        __tmp85_last = __tmp85Reader.EndOfStream;
                        if ((__tmp85_last && !string.IsNullOrEmpty(__tmp85_line)) || (!__tmp85_last && __tmp85_line != null))
                        {
                            __out.Append(__tmp85_line);
                            __tmp83_outputWritten = true;
                        }
                        if (!__tmp85_last) __out.AppendLine(true);
                    }
                }
                string __tmp86_line = ".Set"; //1248:61
                if (!string.IsNullOrEmpty(__tmp86_line))
                {
                    __out.Append(__tmp86_line);
                    __tmp83_outputWritten = true;
                }
                StringBuilder __tmp87 = new StringBuilder();
                __tmp87.Append(prop.Name);
                using(StreamReader __tmp87Reader = new StreamReader(this.__ToStream(__tmp87.ToString())))
                {
                    bool __tmp87_last = __tmp87Reader.EndOfStream;
                    while(!__tmp87_last)
                    {
                        string __tmp87_line = __tmp87Reader.ReadLine();
                        __tmp87_last = __tmp87Reader.EndOfStream;
                        if ((__tmp87_last && !string.IsNullOrEmpty(__tmp87_line)) || (!__tmp87_last && __tmp87_line != null))
                        {
                            __out.Append(__tmp87_line);
                            __tmp83_outputWritten = true;
                        }
                        if (!__tmp87_last) __out.AppendLine(true);
                    }
                }
                string __tmp88_line = "Lazy(global::System.Func<"; //1248:76
                if (!string.IsNullOrEmpty(__tmp88_line))
                {
                    __out.Append(__tmp88_line);
                    __tmp83_outputWritten = true;
                }
                StringBuilder __tmp89 = new StringBuilder();
                __tmp89.Append(CSharpName(prop.Class, model, ClassKind.Builder, true));
                using(StreamReader __tmp89Reader = new StreamReader(this.__ToStream(__tmp89.ToString())))
                {
                    bool __tmp89_last = __tmp89Reader.EndOfStream;
                    while(!__tmp89_last)
                    {
                        string __tmp89_line = __tmp89Reader.ReadLine();
                        __tmp89_last = __tmp89Reader.EndOfStream;
                        if ((__tmp89_last && !string.IsNullOrEmpty(__tmp89_line)) || (!__tmp89_last && __tmp89_line != null))
                        {
                            __out.Append(__tmp89_line);
                            __tmp83_outputWritten = true;
                        }
                        if (!__tmp89_last) __out.AppendLine(true);
                    }
                }
                string __tmp90_line = ", "; //1248:156
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Append(__tmp90_line);
                    __tmp83_outputWritten = true;
                }
                StringBuilder __tmp91 = new StringBuilder();
                __tmp91.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
                using(StreamReader __tmp91Reader = new StreamReader(this.__ToStream(__tmp91.ToString())))
                {
                    bool __tmp91_last = __tmp91Reader.EndOfStream;
                    while(!__tmp91_last)
                    {
                        string __tmp91_line = __tmp91Reader.ReadLine();
                        __tmp91_last = __tmp91Reader.EndOfStream;
                        if ((__tmp91_last && !string.IsNullOrEmpty(__tmp91_line)) || (!__tmp91_last && __tmp91_line != null))
                        {
                            __out.Append(__tmp91_line);
                            __tmp83_outputWritten = true;
                        }
                        if (!__tmp91_last) __out.AppendLine(true);
                    }
                }
                string __tmp92_line = "> lazy)"; //1248:212
                if (!string.IsNullOrEmpty(__tmp92_line))
                {
                    __out.Append(__tmp92_line);
                    __tmp83_outputWritten = true;
                }
                if (__tmp83_outputWritten) __out.AppendLine(true);
                if (__tmp83_outputWritten)
                {
                    __out.AppendLine(false); //1248:219
                }
                __out.Append("{"); //1249:1
                __out.AppendLine(false); //1249:2
                if (IsReferenceType(prop.Type)) //1250:3
                {
                    bool __tmp94_outputWritten = false;
                    string __tmp95_line = "	this.SetLazyReference("; //1251:1
                    if (!string.IsNullOrEmpty(__tmp95_line))
                    {
                        __out.Append(__tmp95_line);
                        __tmp94_outputWritten = true;
                    }
                    StringBuilder __tmp96 = new StringBuilder();
                    __tmp96.Append(CSharpName(prop, model, PropertyKind.Descriptor, true));
                    using(StreamReader __tmp96Reader = new StreamReader(this.__ToStream(__tmp96.ToString())))
                    {
                        bool __tmp96_last = __tmp96Reader.EndOfStream;
                        while(!__tmp96_last)
                        {
                            string __tmp96_line = __tmp96Reader.ReadLine();
                            __tmp96_last = __tmp96Reader.EndOfStream;
                            if ((__tmp96_last && !string.IsNullOrEmpty(__tmp96_line)) || (!__tmp96_last && __tmp96_line != null))
                            {
                                __out.Append(__tmp96_line);
                                __tmp94_outputWritten = true;
                            }
                            if (!__tmp96_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp97_line = ", lazy);"; //1251:79
                    if (!string.IsNullOrEmpty(__tmp97_line))
                    {
                        __out.Append(__tmp97_line);
                        __tmp94_outputWritten = true;
                    }
                    if (__tmp94_outputWritten) __out.AppendLine(true);
                    if (__tmp94_outputWritten)
                    {
                        __out.AppendLine(false); //1251:87
                    }
                }
                else //1252:3
                {
                    bool __tmp99_outputWritten = false;
                    string __tmp100_line = "	this.SetLazyValue("; //1253:1
                    if (!string.IsNullOrEmpty(__tmp100_line))
                    {
                        __out.Append(__tmp100_line);
                        __tmp99_outputWritten = true;
                    }
                    StringBuilder __tmp101 = new StringBuilder();
                    __tmp101.Append(CSharpName(prop, model, PropertyKind.Descriptor, true));
                    using(StreamReader __tmp101Reader = new StreamReader(this.__ToStream(__tmp101.ToString())))
                    {
                        bool __tmp101_last = __tmp101Reader.EndOfStream;
                        while(!__tmp101_last)
                        {
                            string __tmp101_line = __tmp101Reader.ReadLine();
                            __tmp101_last = __tmp101Reader.EndOfStream;
                            if ((__tmp101_last && !string.IsNullOrEmpty(__tmp101_line)) || (!__tmp101_last && __tmp101_line != null))
                            {
                                __out.Append(__tmp101_line);
                                __tmp99_outputWritten = true;
                            }
                            if (!__tmp101_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp102_line = ", lazy);"; //1253:75
                    if (!string.IsNullOrEmpty(__tmp102_line))
                    {
                        __out.Append(__tmp102_line);
                        __tmp99_outputWritten = true;
                    }
                    if (__tmp99_outputWritten) __out.AppendLine(true);
                    if (__tmp99_outputWritten)
                    {
                        __out.AppendLine(false); //1253:83
                    }
                }
                __out.Append("}"); //1255:1
                __out.AppendLine(false); //1255:2
                __out.AppendLine(true); //1256:1
                bool __tmp104_outputWritten = false;
                string __tmp105_line = "void "; //1257:1
                if (!string.IsNullOrEmpty(__tmp105_line))
                {
                    __out.Append(__tmp105_line);
                    __tmp104_outputWritten = true;
                }
                StringBuilder __tmp106 = new StringBuilder();
                __tmp106.Append(CSharpName(prop.Class, model, ClassKind.Builder, true));
                using(StreamReader __tmp106Reader = new StreamReader(this.__ToStream(__tmp106.ToString())))
                {
                    bool __tmp106_last = __tmp106Reader.EndOfStream;
                    while(!__tmp106_last)
                    {
                        string __tmp106_line = __tmp106Reader.ReadLine();
                        __tmp106_last = __tmp106Reader.EndOfStream;
                        if ((__tmp106_last && !string.IsNullOrEmpty(__tmp106_line)) || (!__tmp106_last && __tmp106_line != null))
                        {
                            __out.Append(__tmp106_line);
                            __tmp104_outputWritten = true;
                        }
                        if (!__tmp106_last) __out.AppendLine(true);
                    }
                }
                string __tmp107_line = ".Set"; //1257:61
                if (!string.IsNullOrEmpty(__tmp107_line))
                {
                    __out.Append(__tmp107_line);
                    __tmp104_outputWritten = true;
                }
                StringBuilder __tmp108 = new StringBuilder();
                __tmp108.Append(prop.Name);
                using(StreamReader __tmp108Reader = new StreamReader(this.__ToStream(__tmp108.ToString())))
                {
                    bool __tmp108_last = __tmp108Reader.EndOfStream;
                    while(!__tmp108_last)
                    {
                        string __tmp108_line = __tmp108Reader.ReadLine();
                        __tmp108_last = __tmp108Reader.EndOfStream;
                        if ((__tmp108_last && !string.IsNullOrEmpty(__tmp108_line)) || (!__tmp108_last && __tmp108_line != null))
                        {
                            __out.Append(__tmp108_line);
                            __tmp104_outputWritten = true;
                        }
                        if (!__tmp108_last) __out.AppendLine(true);
                    }
                }
                string __tmp109_line = "Lazy(global::System.Func<"; //1257:76
                if (!string.IsNullOrEmpty(__tmp109_line))
                {
                    __out.Append(__tmp109_line);
                    __tmp104_outputWritten = true;
                }
                StringBuilder __tmp110 = new StringBuilder();
                __tmp110.Append(CSharpName(prop.Class, model, ClassKind.Immutable, true));
                using(StreamReader __tmp110Reader = new StreamReader(this.__ToStream(__tmp110.ToString())))
                {
                    bool __tmp110_last = __tmp110Reader.EndOfStream;
                    while(!__tmp110_last)
                    {
                        string __tmp110_line = __tmp110Reader.ReadLine();
                        __tmp110_last = __tmp110Reader.EndOfStream;
                        if ((__tmp110_last && !string.IsNullOrEmpty(__tmp110_line)) || (!__tmp110_last && __tmp110_line != null))
                        {
                            __out.Append(__tmp110_line);
                            __tmp104_outputWritten = true;
                        }
                        if (!__tmp110_last) __out.AppendLine(true);
                    }
                }
                string __tmp111_line = ", "; //1257:158
                if (!string.IsNullOrEmpty(__tmp111_line))
                {
                    __out.Append(__tmp111_line);
                    __tmp104_outputWritten = true;
                }
                StringBuilder __tmp112 = new StringBuilder();
                __tmp112.Append(CSharpName(prop.Type, model, ClassKind.Immutable, true));
                using(StreamReader __tmp112Reader = new StreamReader(this.__ToStream(__tmp112.ToString())))
                {
                    bool __tmp112_last = __tmp112Reader.EndOfStream;
                    while(!__tmp112_last)
                    {
                        string __tmp112_line = __tmp112Reader.ReadLine();
                        __tmp112_last = __tmp112Reader.EndOfStream;
                        if ((__tmp112_last && !string.IsNullOrEmpty(__tmp112_line)) || (!__tmp112_last && __tmp112_line != null))
                        {
                            __out.Append(__tmp112_line);
                            __tmp104_outputWritten = true;
                        }
                        if (!__tmp112_last) __out.AppendLine(true);
                    }
                }
                string __tmp113_line = "> immutableLazy, global::System.Func<"; //1257:216
                if (!string.IsNullOrEmpty(__tmp113_line))
                {
                    __out.Append(__tmp113_line);
                    __tmp104_outputWritten = true;
                }
                StringBuilder __tmp114 = new StringBuilder();
                __tmp114.Append(CSharpName(prop.Class, model, ClassKind.Builder, true));
                using(StreamReader __tmp114Reader = new StreamReader(this.__ToStream(__tmp114.ToString())))
                {
                    bool __tmp114_last = __tmp114Reader.EndOfStream;
                    while(!__tmp114_last)
                    {
                        string __tmp114_line = __tmp114Reader.ReadLine();
                        __tmp114_last = __tmp114Reader.EndOfStream;
                        if ((__tmp114_last && !string.IsNullOrEmpty(__tmp114_line)) || (!__tmp114_last && __tmp114_line != null))
                        {
                            __out.Append(__tmp114_line);
                            __tmp104_outputWritten = true;
                        }
                        if (!__tmp114_last) __out.AppendLine(true);
                    }
                }
                string __tmp115_line = ", "; //1257:308
                if (!string.IsNullOrEmpty(__tmp115_line))
                {
                    __out.Append(__tmp115_line);
                    __tmp104_outputWritten = true;
                }
                StringBuilder __tmp116 = new StringBuilder();
                __tmp116.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
                using(StreamReader __tmp116Reader = new StreamReader(this.__ToStream(__tmp116.ToString())))
                {
                    bool __tmp116_last = __tmp116Reader.EndOfStream;
                    while(!__tmp116_last)
                    {
                        string __tmp116_line = __tmp116Reader.ReadLine();
                        __tmp116_last = __tmp116Reader.EndOfStream;
                        if ((__tmp116_last && !string.IsNullOrEmpty(__tmp116_line)) || (!__tmp116_last && __tmp116_line != null))
                        {
                            __out.Append(__tmp116_line);
                            __tmp104_outputWritten = true;
                        }
                        if (!__tmp116_last) __out.AppendLine(true);
                    }
                }
                string __tmp117_line = "> mutableLazy)"; //1257:364
                if (!string.IsNullOrEmpty(__tmp117_line))
                {
                    __out.Append(__tmp117_line);
                    __tmp104_outputWritten = true;
                }
                if (__tmp104_outputWritten) __out.AppendLine(true);
                if (__tmp104_outputWritten)
                {
                    __out.AppendLine(false); //1257:378
                }
                __out.Append("{"); //1258:1
                __out.AppendLine(false); //1258:2
                if (IsReferenceType(prop.Type)) //1259:3
                {
                    bool __tmp119_outputWritten = false;
                    string __tmp120_line = "	this.SetLazyReference("; //1260:1
                    if (!string.IsNullOrEmpty(__tmp120_line))
                    {
                        __out.Append(__tmp120_line);
                        __tmp119_outputWritten = true;
                    }
                    StringBuilder __tmp121 = new StringBuilder();
                    __tmp121.Append(CSharpName(prop, model, PropertyKind.Descriptor, true));
                    using(StreamReader __tmp121Reader = new StreamReader(this.__ToStream(__tmp121.ToString())))
                    {
                        bool __tmp121_last = __tmp121Reader.EndOfStream;
                        while(!__tmp121_last)
                        {
                            string __tmp121_line = __tmp121Reader.ReadLine();
                            __tmp121_last = __tmp121Reader.EndOfStream;
                            if ((__tmp121_last && !string.IsNullOrEmpty(__tmp121_line)) || (!__tmp121_last && __tmp121_line != null))
                            {
                                __out.Append(__tmp121_line);
                                __tmp119_outputWritten = true;
                            }
                            if (!__tmp121_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp122_line = ", immutableLazy, mutableLazy);"; //1260:79
                    if (!string.IsNullOrEmpty(__tmp122_line))
                    {
                        __out.Append(__tmp122_line);
                        __tmp119_outputWritten = true;
                    }
                    if (__tmp119_outputWritten) __out.AppendLine(true);
                    if (__tmp119_outputWritten)
                    {
                        __out.AppendLine(false); //1260:109
                    }
                }
                else //1261:3
                {
                    bool __tmp124_outputWritten = false;
                    string __tmp125_line = "	this.SetLazyValue("; //1262:1
                    if (!string.IsNullOrEmpty(__tmp125_line))
                    {
                        __out.Append(__tmp125_line);
                        __tmp124_outputWritten = true;
                    }
                    StringBuilder __tmp126 = new StringBuilder();
                    __tmp126.Append(CSharpName(prop, model, PropertyKind.Descriptor, true));
                    using(StreamReader __tmp126Reader = new StreamReader(this.__ToStream(__tmp126.ToString())))
                    {
                        bool __tmp126_last = __tmp126Reader.EndOfStream;
                        while(!__tmp126_last)
                        {
                            string __tmp126_line = __tmp126Reader.ReadLine();
                            __tmp126_last = __tmp126Reader.EndOfStream;
                            if ((__tmp126_last && !string.IsNullOrEmpty(__tmp126_line)) || (!__tmp126_last && __tmp126_line != null))
                            {
                                __out.Append(__tmp126_line);
                                __tmp124_outputWritten = true;
                            }
                            if (!__tmp126_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp127_line = ", immutableLazy, mutableLazy);"; //1262:75
                    if (!string.IsNullOrEmpty(__tmp127_line))
                    {
                        __out.Append(__tmp127_line);
                        __tmp124_outputWritten = true;
                    }
                    if (__tmp124_outputWritten) __out.AppendLine(true);
                    if (__tmp124_outputWritten)
                    {
                        __out.AppendLine(false); //1262:105
                    }
                }
                __out.Append("}"); //1264:1
                __out.AppendLine(false); //1264:2
            }
            return __out.ToString();
        }

        public string GenerateBuilderOperationImpl(MetaModel model, MetaClass cls, MetaOperation op) //1268:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1269:1
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(CSharpName(op.ReturnType, model, ClassKind.BuilderOperation, true));
            using(StreamReader __tmp3Reader = new StreamReader(this.__ToStream(__tmp3.ToString())))
            {
                bool __tmp3_last = __tmp3Reader.EndOfStream;
                while(!__tmp3_last)
                {
                    string __tmp3_line = __tmp3Reader.ReadLine();
                    __tmp3_last = __tmp3Reader.EndOfStream;
                    if ((__tmp3_last && !string.IsNullOrEmpty(__tmp3_line)) || (!__tmp3_last && __tmp3_line != null))
                    {
                        __out.Append(__tmp3_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp3_last) __out.AppendLine(true);
                }
            }
            string __tmp4_line = " "; //1270:68
            if (!string.IsNullOrEmpty(__tmp4_line))
            {
                __out.Append(__tmp4_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(CSharpName(op.Class, model, ClassKind.Builder, true));
            using(StreamReader __tmp5Reader = new StreamReader(this.__ToStream(__tmp5.ToString())))
            {
                bool __tmp5_last = __tmp5Reader.EndOfStream;
                while(!__tmp5_last)
                {
                    string __tmp5_line = __tmp5Reader.ReadLine();
                    __tmp5_last = __tmp5Reader.EndOfStream;
                    if ((__tmp5_last && !string.IsNullOrEmpty(__tmp5_line)) || (!__tmp5_last && __tmp5_line != null))
                    {
                        __out.Append(__tmp5_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp5_last) __out.AppendLine(true);
                }
            }
            string __tmp6_line = "."; //1270:122
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Append(__tmp6_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(op.Name);
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(!__tmp7_last)
                {
                    string __tmp7_line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if ((__tmp7_last && !string.IsNullOrEmpty(__tmp7_line)) || (!__tmp7_last && __tmp7_line != null))
                    {
                        __out.Append(__tmp7_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp7_last) __out.AppendLine(true);
                }
            }
            string __tmp8_line = "("; //1270:132
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Append(__tmp8_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(GetClassParameters(model, op.Class, op, ClassKind.BuilderOperation));
            using(StreamReader __tmp9Reader = new StreamReader(this.__ToStream(__tmp9.ToString())))
            {
                bool __tmp9_last = __tmp9Reader.EndOfStream;
                while(!__tmp9_last)
                {
                    string __tmp9_line = __tmp9Reader.ReadLine();
                    __tmp9_last = __tmp9Reader.EndOfStream;
                    if ((__tmp9_last && !string.IsNullOrEmpty(__tmp9_line)) || (!__tmp9_last && __tmp9_line != null))
                    {
                        __out.Append(__tmp9_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp9_last) __out.AppendLine(true);
                }
            }
            string __tmp10_line = ")"; //1270:202
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1270:203
            }
            __out.Append("{"); //1271:1
            __out.AppendLine(false); //1271:2
            var finalOp = GetFinalOperation(cls, op); //1272:2
            bool __tmp12_outputWritten = false;
            string __tmp11Prefix = "    "; //1273:1
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(GetReturn(model, finalOp, ClassKind.BuilderOperation));
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13_line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp11Prefix))
                    {
                        __out.Append(__tmp11Prefix);
                        __tmp12_outputWritten = true;
                    }
                    if ((__tmp13_last && !string.IsNullOrEmpty(__tmp13_line)) || (!__tmp13_last && __tmp13_line != null))
                    {
                        __out.Append(__tmp13_line);
                        __tmp12_outputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            StringBuilder __tmp14 = new StringBuilder();
            __tmp14.Append(CSharpName(model, ModelKind.ImplementationProvider));
            using(StreamReader __tmp14Reader = new StreamReader(this.__ToStream(__tmp14.ToString())))
            {
                bool __tmp14_last = __tmp14Reader.EndOfStream;
                while(!__tmp14_last)
                {
                    string __tmp14_line = __tmp14Reader.ReadLine();
                    __tmp14_last = __tmp14Reader.EndOfStream;
                    if ((__tmp14_last && !string.IsNullOrEmpty(__tmp14_line)) || (!__tmp14_last && __tmp14_line != null))
                    {
                        __out.Append(__tmp14_line);
                        __tmp12_outputWritten = true;
                    }
                    if (!__tmp14_last) __out.AppendLine(true);
                }
            }
            string __tmp15_line = ".Implementation."; //1273:112
            if (!string.IsNullOrEmpty(__tmp15_line))
            {
                __out.Append(__tmp15_line);
                __tmp12_outputWritten = true;
            }
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(CSharpName(finalOp.Class, model, ClassKind.Immutable));
            using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
            {
                bool __tmp16_last = __tmp16Reader.EndOfStream;
                while(!__tmp16_last)
                {
                    string __tmp16_line = __tmp16Reader.ReadLine();
                    __tmp16_last = __tmp16Reader.EndOfStream;
                    if ((__tmp16_last && !string.IsNullOrEmpty(__tmp16_line)) || (!__tmp16_last && __tmp16_line != null))
                    {
                        __out.Append(__tmp16_line);
                        __tmp12_outputWritten = true;
                    }
                    if (!__tmp16_last) __out.AppendLine(true);
                }
            }
            string __tmp17_line = "_"; //1273:182
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp12_outputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(finalOp.Name);
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    string __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                    {
                        __out.Append(__tmp18_line);
                        __tmp12_outputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19_line = "("; //1273:197
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp12_outputWritten = true;
            }
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(GetClassImplCallParameterNames(model, finalOp, ClassKind.BuilderOperation));
            using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
            {
                bool __tmp20_last = __tmp20Reader.EndOfStream;
                while(!__tmp20_last)
                {
                    string __tmp20_line = __tmp20Reader.ReadLine();
                    __tmp20_last = __tmp20Reader.EndOfStream;
                    if ((__tmp20_last && !string.IsNullOrEmpty(__tmp20_line)) || (!__tmp20_last && __tmp20_line != null))
                    {
                        __out.Append(__tmp20_line);
                        __tmp12_outputWritten = true;
                    }
                    if (!__tmp20_last) __out.AppendLine(true);
                }
            }
            string __tmp21_line = ");"; //1273:274
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp12_outputWritten = true;
            }
            if (__tmp12_outputWritten) __out.AppendLine(true);
            if (__tmp12_outputWritten)
            {
                __out.AppendLine(false); //1273:276
            }
            __out.Append("}"); //1274:1
            __out.AppendLine(false); //1274:2
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
