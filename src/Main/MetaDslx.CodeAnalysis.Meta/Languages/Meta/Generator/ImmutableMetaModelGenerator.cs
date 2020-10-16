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
        string ToCamelCase(string identifier); //44:8
        string ToPascalCase(string identifier); //45:8
        string EscapeText(string text); //46:8
        bool IsMetaMetaModel(MetaModel mmodel); //47:8
        string GetEnumValueOf(MetaModel mmodel, Enum menum); //48:8
        string GetAttributeValueOf(MetaModel mmodel, MetaAttribute mattr); //49:8
        string GetAttributeName(MetaAttribute mattr); //50:8
        string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false); //51:8
        string CSharpName(IMetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false); //52:8
        string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false); //53:8
        string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false); //54:8
        string CSharpName(MetaConstant mconst, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false); //55:8
        ImmutableList<ImmutableObject> GetInstances(MetaModel mmodel); //56:8
        ImmutableDictionary<ImmutableObject,string> GetInstanceNames(MetaModel mmodel); //57:8
        string GetFieldName(MetaProperty mproperty, MetaClass mclass); //58:8
        bool IsReferenceType(MetaType mtype); //59:8
        string GetImmBldCallParameterNames(MetaModel mmodel, MetaOperation operation, ClassKind kind); //60:8
        string GetImmBldReturn(MetaModel mmodel, MetaOperation operation, ClassKind kind); //61:8
        MetaOperation GetFinalOperation(MetaClass cls, MetaOperation operation); //62:8
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
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //23:7
                from mm in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaModel>() //23:18
                select new { __loop1_var1 = __loop1_var1, mm = mm}
                ).ToList(); //23:2
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

        public string GenerateImplementation() //29:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("using System;"); //30:1
            __out.AppendLine(false); //30:14
            __out.Append("using System.Collections.Generic;"); //31:1
            __out.AppendLine(false); //31:34
            __out.Append("using System.IO;"); //32:1
            __out.AppendLine(false); //32:17
            __out.Append("using System.Linq;"); //33:1
            __out.AppendLine(false); //33:19
            __out.Append("using System.Text;"); //34:1
            __out.AppendLine(false); //34:19
            __out.Append("using System.Threading;"); //35:1
            __out.AppendLine(false); //35:24
            __out.Append("using System.Threading.Tasks;"); //36:1
            __out.AppendLine(false); //36:30
            __out.Append("using System.Diagnostics;"); //37:1
            __out.AppendLine(false); //37:26
            __out.AppendLine(true); //38:1
            var __loop2_results = 
                (from __loop2_var1 in __Enumerate((Instances).GetEnumerator()) //39:7
                from mm in __Enumerate((__loop2_var1).GetEnumerator()).OfType<MetaModel>() //39:18
                select new { __loop2_var1 = __loop2_var1, mm = mm}
                ).ToList(); //39:2
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                var __tmp1 = __loop2_results[__loop2_iteration];
                var __loop2_var1 = __tmp1.__loop2_var1;
                var mm = __tmp1.mm;
                bool __tmp3_outputWritten = false;
                StringBuilder __tmp4 = new StringBuilder();
                __tmp4.Append(GenerateMetamodelImplementation(mm));
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
                    __out.AppendLine(false); //40:38
                }
            }
            return __out.ToString();
        }

        internal string ToCamelCase(string identifier) //44:8
        {
            return this.extensionFunctions.ToCamelCase(identifier); //44:8
        }

        internal string ToPascalCase(string identifier) //45:8
        {
            return this.extensionFunctions.ToPascalCase(identifier); //45:8
        }

        internal string EscapeText(string text) //46:8
        {
            return this.extensionFunctions.EscapeText(text); //46:8
        }

        internal bool IsMetaMetaModel(MetaModel mmodel) //47:8
        {
            return this.extensionFunctions.IsMetaMetaModel(mmodel); //47:8
        }

        internal string GetEnumValueOf(MetaModel mmodel, Enum menum) //48:8
        {
            return this.extensionFunctions.GetEnumValueOf(mmodel, menum); //48:8
        }

        internal string GetAttributeValueOf(MetaModel mmodel, MetaAttribute mattr) //49:8
        {
            return this.extensionFunctions.GetAttributeValueOf(mmodel, mattr); //49:8
        }

        internal string GetAttributeName(MetaAttribute mattr) //50:8
        {
            return this.extensionFunctions.GetAttributeName(mattr); //50:8
        }

        internal string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false) //51:8
        {
            return this.extensionFunctions.CSharpName(mnamespace, kind, fullName); //51:8
        }

        internal string CSharpName(IMetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false) //52:8
        {
            return this.extensionFunctions.CSharpName(mmodel, kind, fullName); //52:8
        }

        internal string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false) //53:8
        {
            return this.extensionFunctions.CSharpName(mtype, mmodel, kind, fullName); //53:8
        }

        internal string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false) //54:8
        {
            return this.extensionFunctions.CSharpName(mproperty, mmodel, kind, fullName); //54:8
        }

        internal string CSharpName(MetaConstant mconst, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false) //55:8
        {
            return this.extensionFunctions.CSharpName(mconst, mmodel, kind, fullName); //55:8
        }

        internal ImmutableList<ImmutableObject> GetInstances(MetaModel mmodel) //56:8
        {
            return this.extensionFunctions.GetInstances(mmodel); //56:8
        }

        internal ImmutableDictionary<ImmutableObject,string> GetInstanceNames(MetaModel mmodel) //57:8
        {
            return this.extensionFunctions.GetInstanceNames(mmodel); //57:8
        }

        internal string GetFieldName(MetaProperty mproperty, MetaClass mclass) //58:8
        {
            return this.extensionFunctions.GetFieldName(mproperty, mclass); //58:8
        }

        internal bool IsReferenceType(MetaType mtype) //59:8
        {
            return this.extensionFunctions.IsReferenceType(mtype); //59:8
        }

        internal string GetImmBldCallParameterNames(MetaModel mmodel, MetaOperation operation, ClassKind kind) //60:8
        {
            return this.extensionFunctions.GetImmBldCallParameterNames(mmodel, operation, kind); //60:8
        }

        internal string GetImmBldReturn(MetaModel mmodel, MetaOperation operation, ClassKind kind) //61:8
        {
            return this.extensionFunctions.GetImmBldReturn(mmodel, operation, kind); //61:8
        }

        internal MetaOperation GetFinalOperation(MetaClass cls, MetaOperation operation) //62:8
        {
            return this.extensionFunctions.GetFinalOperation(cls, operation); //62:8
        }

        public string GenerateDocumentation(MetaDocumentedElement elem) //64:1
        {
            StringBuilder __out = new StringBuilder();
            var lines = elem.GetDocumentationLines(); //65:2
            if (lines.Count > 0) //66:2
            {
                var __loop3_results = 
                    (from line in __Enumerate((lines).GetEnumerator()) //67:8
                    select new { line = line}
                    ).ToList(); //67:3
                for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
                {
                    var __tmp1 = __loop3_results[__loop3_iteration];
                    var line = __tmp1.line;
                    bool __tmp3_outputWritten = false;
                    string __tmp4_line = "///"; //68:1
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
                        __out.AppendLine(false); //68:10
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateAttributes(MetaElement elem) //73:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((elem).GetEnumerator()) //74:7
                from attr in __Enumerate((__loop4_var1.Attributes).GetEnumerator()) //74:13
                select new { __loop4_var1 = __loop4_var1, attr = attr}
                ).ToList(); //74:2
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp1 = __loop4_results[__loop4_iteration];
                var __loop4_var1 = __tmp1.__loop4_var1;
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
                string __tmp6_line = "."; //75:25
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
                    __out.AppendLine(false); //75:55
                }
            }
            return __out.ToString();
        }

        public string GenerateMetamodel(MetaModel model) //79:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //80:1
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
                __out.AppendLine(false); //80:67
            }
            __out.Append("{"); //81:1
            __out.AppendLine(false); //81:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	using global::"; //82:1
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
            string __tmp9_line = ";"; //82:74
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //82:75
            }
            __out.AppendLine(true); //83:1
            bool __tmp11_outputWritten = false;
            string __tmp10Prefix = "	"; //84:1
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
                __out.AppendLine(false); //84:28
            }
            __out.AppendLine(true); //85:1
            bool __tmp14_outputWritten = false;
            string __tmp13Prefix = "	"; //86:1
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
                __out.AppendLine(false); //86:36
            }
            __out.AppendLine(true); //87:1
            bool __tmp17_outputWritten = false;
            string __tmp16Prefix = "	"; //88:1
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
                __out.AppendLine(false); //88:26
            }
            __out.AppendLine(true); //89:1
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //90:8
                from enm in __Enumerate((__loop5_var1).GetEnumerator()).OfType<MetaEnum>() //90:38
                select new { __loop5_var1 = __loop5_var1, enm = enm}
                ).ToList(); //90:3
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp19 = __loop5_results[__loop5_iteration];
                var __loop5_var1 = __tmp19.__loop5_var1;
                var enm = __tmp19.enm;
                bool __tmp21_outputWritten = false;
                string __tmp20Prefix = "	"; //91:1
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
                    __out.AppendLine(false); //91:28
                }
            }
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //93:8
                from cls in __Enumerate((__loop6_var1).GetEnumerator()).OfType<MetaClass>() //93:38
                select new { __loop6_var1 = __loop6_var1, cls = cls}
                ).ToList(); //93:3
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp23 = __loop6_results[__loop6_iteration];
                var __loop6_var1 = __tmp23.__loop6_var1;
                var cls = __tmp23.cls;
                bool __tmp25_outputWritten = false;
                string __tmp24Prefix = "	"; //94:1
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
                    __out.AppendLine(false); //94:29
                }
            }
            __out.AppendLine(true); //96:1
            bool __tmp28_outputWritten = false;
            string __tmp27Prefix = "	"; //97:1
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
                __out.AppendLine(false); //97:38
            }
            __out.Append("}"); //98:1
            __out.AppendLine(false); //98:2
            __out.AppendLine(true); //99:1
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "namespace "; //100:1
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
                __out.AppendLine(false); //100:69
            }
            __out.Append("{"); //101:1
            __out.AppendLine(false); //101:2
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //102:8
                from cls in __Enumerate((__loop7_var1).GetEnumerator()).OfType<MetaClass>() //102:38
                select new { __loop7_var1 = __loop7_var1, cls = cls}
                ).ToList(); //102:3
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp34 = __loop7_results[__loop7_iteration];
                var __loop7_var1 = __tmp34.__loop7_var1;
                var cls = __tmp34.cls;
                bool __tmp36_outputWritten = false;
                string __tmp35Prefix = "	"; //103:1
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
                    __out.AppendLine(false); //103:37
                }
            }
            __out.AppendLine(true); //105:1
            bool __tmp39_outputWritten = false;
            string __tmp38Prefix = "	"; //106:1
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
                __out.AppendLine(false); //106:43
            }
            __out.AppendLine(true); //107:1
            bool __tmp42_outputWritten = false;
            string __tmp41Prefix = "	"; //108:1
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
                __out.AppendLine(false); //108:37
            }
            __out.AppendLine(true); //109:1
            bool __tmp45_outputWritten = false;
            string __tmp44Prefix = "	"; //110:1
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
                __out.AppendLine(false); //110:41
            }
            __out.Append("}"); //111:1
            __out.AppendLine(false); //111:2
            return __out.ToString();
        }

        public string GenerateMetamodelImplementation(MetaModel model) //114:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //115:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //116:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(CSharpName(model.Namespace, NamespaceKind.Internal, true));
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
                __out.AppendLine(false); //116:69
            }
            __out.Append("{"); //117:1
            __out.AppendLine(false); //117:2
            bool __tmp6_outputWritten = false;
            string __tmp5Prefix = "	"; //118:1
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(GenerateImplementation(model));
            using(StreamReader __tmp7Reader = new StreamReader(this.__ToStream(__tmp7.ToString())))
            {
                bool __tmp7_last = __tmp7Reader.EndOfStream;
                while(!__tmp7_last)
                {
                    string __tmp7_line = __tmp7Reader.ReadLine();
                    __tmp7_last = __tmp7Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp5Prefix))
                    {
                        __out.Append(__tmp5Prefix);
                        __tmp6_outputWritten = true;
                    }
                    if ((__tmp7_last && !string.IsNullOrEmpty(__tmp7_line)) || (!__tmp7_last && __tmp7_line != null))
                    {
                        __out.Append(__tmp7_line);
                        __tmp6_outputWritten = true;
                    }
                    if (!__tmp7_last || __tmp6_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //118:33
            }
            __out.Append("}"); //119:1
            __out.AppendLine(false); //119:2
            return __out.ToString();
        }

        public string GenerateMetaModel(MetaModel model) //122:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //123:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //124:1
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
            string __tmp5_line = " : "; //124:55
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
            string __tmp7_line = ".IMetaModel"; //124:77
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //124:88
            }
            __out.Append("{"); //125:1
            __out.AppendLine(false); //125:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	internal "; //126:1
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
            string __tmp12_line = "()"; //126:50
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Append(__tmp12_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //126:52
            }
            __out.Append("	{"); //127:1
            __out.AppendLine(false); //127:3
            __out.Append("	}"); //128:1
            __out.AppendLine(false); //128:3
            __out.AppendLine(true); //129:1
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	public "; //130:1
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
            string __tmp17_line = ".ModelId Id => "; //130:28
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
            string __tmp19_line = ".MModel.Id;"; //130:90
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //130:101
            }
            bool __tmp21_outputWritten = false;
            string __tmp22_line = "	public string Name => \""; //131:1
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
            string __tmp24_line = "\";"; //131:37
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp21_outputWritten = true;
            }
            if (__tmp21_outputWritten) __out.AppendLine(true);
            if (__tmp21_outputWritten)
            {
                __out.AppendLine(false); //131:39
            }
            bool __tmp26_outputWritten = false;
            string __tmp27_line = "	public "; //132:1
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
            string __tmp29_line = ".ModelVersion Version => "; //132:28
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
            string __tmp31_line = ".MModel.Version;"; //132:100
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Append(__tmp31_line);
                __tmp26_outputWritten = true;
            }
            if (__tmp26_outputWritten) __out.AppendLine(true);
            if (__tmp26_outputWritten)
            {
                __out.AppendLine(false); //132:116
            }
            bool __tmp33_outputWritten = false;
            string __tmp34_line = "	public global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> Objects => "; //133:1
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
            string __tmp36_line = ".MModel.Objects;"; //133:154
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Append(__tmp36_line);
                __tmp33_outputWritten = true;
            }
            if (__tmp33_outputWritten) __out.AppendLine(true);
            if (__tmp33_outputWritten)
            {
                __out.AppendLine(false); //133:170
            }
            bool __tmp38_outputWritten = false;
            string __tmp39_line = "	public string Uri => \""; //134:1
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
            string __tmp41_line = "\";"; //134:35
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Append(__tmp41_line);
                __tmp38_outputWritten = true;
            }
            if (__tmp38_outputWritten) __out.AppendLine(true);
            if (__tmp38_outputWritten)
            {
                __out.AppendLine(false); //134:37
            }
            bool __tmp43_outputWritten = false;
            string __tmp44_line = "	public string Prefix => \""; //135:1
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
            string __tmp46_line = "\";"; //135:41
            if (!string.IsNullOrEmpty(__tmp46_line))
            {
                __out.Append(__tmp46_line);
                __tmp43_outputWritten = true;
            }
            if (__tmp43_outputWritten) __out.AppendLine(true);
            if (__tmp43_outputWritten)
            {
                __out.AppendLine(false); //135:43
            }
            bool __tmp48_outputWritten = false;
            string __tmp49_line = "	public "; //136:1
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
            string __tmp51_line = ".IModelGroup ModelGroup => "; //136:28
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
            string __tmp53_line = ".MModel.ModelGroup;"; //136:102
            if (!string.IsNullOrEmpty(__tmp53_line))
            {
                __out.Append(__tmp53_line);
                __tmp48_outputWritten = true;
            }
            if (__tmp48_outputWritten) __out.AppendLine(true);
            if (__tmp48_outputWritten)
            {
                __out.AppendLine(false); //136:121
            }
            bool __tmp55_outputWritten = false;
            string __tmp56_line = "	public string Namespace => \""; //137:1
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
            string __tmp58_line = "\";"; //137:86
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Append(__tmp58_line);
                __tmp55_outputWritten = true;
            }
            if (__tmp55_outputWritten) __out.AppendLine(true);
            if (__tmp55_outputWritten)
            {
                __out.AppendLine(false); //137:88
            }
            __out.AppendLine(true); //138:1
            bool __tmp60_outputWritten = false;
            string __tmp61_line = "	public "; //139:1
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
            string __tmp63_line = ".IModelFactory CreateFactory("; //139:28
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
            string __tmp65_line = ".MutableModel model, "; //139:76
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
            string __tmp67_line = ".ModelFactoryFlags flags = "; //139:116
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
            string __tmp69_line = ".ModelFactoryFlags.None)"; //139:162
            if (!string.IsNullOrEmpty(__tmp69_line))
            {
                __out.Append(__tmp69_line);
                __tmp60_outputWritten = true;
            }
            if (__tmp60_outputWritten) __out.AppendLine(true);
            if (__tmp60_outputWritten)
            {
                __out.AppendLine(false); //139:186
            }
            __out.Append("	{"); //140:1
            __out.AppendLine(false); //140:3
            bool __tmp71_outputWritten = false;
            string __tmp72_line = "		return new "; //141:1
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
            string __tmp74_line = "(model, flags);"; //141:51
            if (!string.IsNullOrEmpty(__tmp74_line))
            {
                __out.Append(__tmp74_line);
                __tmp71_outputWritten = true;
            }
            if (__tmp71_outputWritten) __out.AppendLine(true);
            if (__tmp71_outputWritten)
            {
                __out.AppendLine(false); //141:66
            }
            __out.Append("	}"); //142:1
            __out.AppendLine(false); //142:3
            __out.AppendLine(true); //143:1
            __out.Append("    public override string ToString()"); //144:1
            __out.AppendLine(false); //144:38
            __out.Append("    {"); //145:1
            __out.AppendLine(false); //145:6
            __out.Append("        return $\"{Name} ({Version})\";"); //146:1
            __out.AppendLine(false); //146:38
            __out.Append("    }"); //147:1
            __out.AppendLine(false); //147:6
            __out.Append("}"); //148:1
            __out.AppendLine(false); //148:2
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //151:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //152:2
            bool metaMetaModel = IsMetaMetaModel(model); //153:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //154:1
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
                __out.AppendLine(false); //154:61
            }
            __out.Append("{"); //155:1
            __out.AppendLine(false); //155:2
            __out.Append("	private static bool initialized;"); //156:1
            __out.AppendLine(false); //156:34
            __out.AppendLine(true); //157:1
            __out.Append("	public static bool IsInitialized"); //158:1
            __out.AppendLine(false); //158:34
            __out.Append("	{"); //159:1
            __out.AppendLine(false); //159:3
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "		get { return "; //160:1
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
            string __tmp9_line = ".initialized; }"; //160:63
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //160:78
            }
            __out.Append("	}"); //161:1
            __out.AppendLine(false); //161:3
            __out.AppendLine(true); //162:1
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	public static readonly "; //163:1
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
            string __tmp14_line = ".IMetaModel MMetaModel;"; //163:44
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //163:67
            }
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	public static readonly "; //164:1
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
            string __tmp19_line = ".ImmutableModel MModel;"; //164:44
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //164:67
            }
            __out.AppendLine(true); //165:1
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //166:8
                from cst in __Enumerate((__loop8_var1).GetEnumerator()).OfType<MetaConstant>() //166:38
                select new { __loop8_var1 = __loop8_var1, cst = cst}
                ).ToList(); //166:3
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp20 = __loop8_results[__loop8_iteration];
                var __loop8_var1 = __tmp20.__loop8_var1;
                var cst = __tmp20.cst;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "	"; //167:1
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
                    __out.AppendLine(false); //167:30
                }
                if (metaMetaModel) //168:4
                {
                    bool __tmp25_outputWritten = false;
                    string __tmp26_line = "	public static readonly "; //169:1
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
                    string __tmp28_line = " "; //169:74
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
                    string __tmp30_line = ";"; //169:127
                    if (!string.IsNullOrEmpty(__tmp30_line))
                    {
                        __out.Append(__tmp30_line);
                        __tmp25_outputWritten = true;
                    }
                    if (__tmp25_outputWritten) __out.AppendLine(true);
                    if (__tmp25_outputWritten)
                    {
                        __out.AppendLine(false); //169:128
                    }
                }
                else //170:4
                {
                    bool __tmp32_outputWritten = false;
                    string __tmp33_line = "	public static readonly "; //171:1
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
                    string __tmp35_line = " "; //171:80
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
                    string __tmp37_line = ";"; //171:133
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Append(__tmp37_line);
                        __tmp32_outputWritten = true;
                    }
                    if (__tmp32_outputWritten) __out.AppendLine(true);
                    if (__tmp32_outputWritten)
                    {
                        __out.AppendLine(false); //171:134
                    }
                }
            }
            __out.AppendLine(true); //174:1
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //175:8
                from cls in __Enumerate((__loop9_var1).GetEnumerator()).OfType<MetaClass>() //175:38
                select new { __loop9_var1 = __loop9_var1, cls = cls}
                ).ToList(); //175:3
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp38 = __loop9_results[__loop9_iteration];
                var __loop9_var1 = __tmp38.__loop9_var1;
                var cls = __tmp38.cls;
                bool __tmp40_outputWritten = false;
                string __tmp39Prefix = "	"; //176:1
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
                    __out.AppendLine(false); //176:30
                }
                bool __tmp43_outputWritten = false;
                string __tmp44_line = "	public static readonly "; //177:1
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
                string __tmp46_line = "MetaClass "; //177:33
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
                string __tmp48_line = ";"; //177:95
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Append(__tmp48_line);
                    __tmp43_outputWritten = true;
                }
                if (__tmp43_outputWritten) __out.AppendLine(true);
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //177:96
                }
                var __loop10_results = 
                    (from __loop10_var1 in __Enumerate((cls).GetEnumerator()) //178:9
                    from prop in __Enumerate((__loop10_var1.Properties).GetEnumerator()) //178:14
                    select new { __loop10_var1 = __loop10_var1, prop = prop}
                    ).ToList(); //178:4
                for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
                {
                    var __tmp49 = __loop10_results[__loop10_iteration];
                    var __loop10_var1 = __tmp49.__loop10_var1;
                    var prop = __tmp49.prop;
                    bool __tmp51_outputWritten = false;
                    string __tmp50Prefix = "	"; //179:1
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
                        __out.AppendLine(false); //179:31
                    }
                    bool __tmp54_outputWritten = false;
                    string __tmp55_line = "	public static readonly "; //180:1
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
                    string __tmp57_line = "MetaProperty "; //180:33
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
                    string __tmp59_line = ";"; //180:102
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Append(__tmp59_line);
                        __tmp54_outputWritten = true;
                    }
                    if (__tmp54_outputWritten) __out.AppendLine(true);
                    if (__tmp54_outputWritten)
                    {
                        __out.AppendLine(false); //180:103
                    }
                }
            }
            __out.AppendLine(true); //183:1
            bool __tmp61_outputWritten = false;
            string __tmp62_line = "	static "; //184:1
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
            string __tmp64_line = "()"; //184:56
            if (!string.IsNullOrEmpty(__tmp64_line))
            {
                __out.Append(__tmp64_line);
                __tmp61_outputWritten = true;
            }
            if (__tmp61_outputWritten) __out.AppendLine(true);
            if (__tmp61_outputWritten)
            {
                __out.AppendLine(false); //184:58
            }
            __out.Append("	{"); //185:1
            __out.AppendLine(false); //185:3
            bool __tmp66_outputWritten = false;
            string __tmp65Prefix = "		"; //186:1
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
            string __tmp68_line = ".instance.Create();"; //186:48
            if (!string.IsNullOrEmpty(__tmp68_line))
            {
                __out.Append(__tmp68_line);
                __tmp66_outputWritten = true;
            }
            if (__tmp66_outputWritten) __out.AppendLine(true);
            if (__tmp66_outputWritten)
            {
                __out.AppendLine(false); //186:67
            }
            bool __tmp70_outputWritten = false;
            string __tmp69Prefix = "		"; //187:1
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
            string __tmp72_line = ".instance.EvaluateLazyValues();"; //187:48
            if (!string.IsNullOrEmpty(__tmp72_line))
            {
                __out.Append(__tmp72_line);
                __tmp70_outputWritten = true;
            }
            if (__tmp70_outputWritten) __out.AppendLine(true);
            if (__tmp70_outputWritten)
            {
                __out.AppendLine(false); //187:79
            }
            bool __tmp74_outputWritten = false;
            string __tmp75_line = "		MMetaModel = new "; //188:1
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
            string __tmp77_line = "();"; //188:59
            if (!string.IsNullOrEmpty(__tmp77_line))
            {
                __out.Append(__tmp77_line);
                __tmp74_outputWritten = true;
            }
            if (__tmp74_outputWritten) __out.AppendLine(true);
            if (__tmp74_outputWritten)
            {
                __out.AppendLine(false); //188:62
            }
            bool __tmp79_outputWritten = false;
            string __tmp80_line = "		MModel = "; //189:1
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
            string __tmp82_line = ".instance.MModel.ToImmutable();"; //189:57
            if (!string.IsNullOrEmpty(__tmp82_line))
            {
                __out.Append(__tmp82_line);
                __tmp79_outputWritten = true;
            }
            if (__tmp79_outputWritten) __out.AppendLine(true);
            if (__tmp79_outputWritten)
            {
                __out.AppendLine(false); //189:88
            }
            __out.AppendLine(true); //190:1
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //191:9
                from cst in __Enumerate((__loop11_var1).GetEnumerator()).OfType<MetaConstant>() //191:39
                select new { __loop11_var1 = __loop11_var1, cst = cst}
                ).ToList(); //191:4
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp83 = __loop11_results[__loop11_iteration];
                var __loop11_var1 = __tmp83.__loop11_var1;
                var cst = __tmp83.cst;
                if (metaMetaModel) //192:5
                {
                    bool __tmp85_outputWritten = false;
                    string __tmp84Prefix = "		"; //193:1
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
                    string __tmp87_line = " = "; //193:55
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
                    string __tmp89_line = ".ToImmutable(MModel);"; //193:114
                    if (!string.IsNullOrEmpty(__tmp89_line))
                    {
                        __out.Append(__tmp89_line);
                        __tmp85_outputWritten = true;
                    }
                    if (__tmp85_outputWritten) __out.AppendLine(true);
                    if (__tmp85_outputWritten)
                    {
                        __out.AppendLine(false); //193:135
                    }
                }
                else //194:5
                {
                    bool __tmp91_outputWritten = false;
                    string __tmp90Prefix = "		"; //195:1
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
                    string __tmp93_line = " = "; //195:55
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
                    string __tmp95_line = ".ToImmutable(MModel);"; //195:114
                    if (!string.IsNullOrEmpty(__tmp95_line))
                    {
                        __out.Append(__tmp95_line);
                        __tmp91_outputWritten = true;
                    }
                    if (__tmp91_outputWritten) __out.AppendLine(true);
                    if (__tmp91_outputWritten)
                    {
                        __out.AppendLine(false); //195:135
                    }
                }
            }
            __out.AppendLine(true); //198:1
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //199:9
                from cls in __Enumerate((__loop12_var1).GetEnumerator()).OfType<MetaClass>() //199:39
                select new { __loop12_var1 = __loop12_var1, cls = cls}
                ).ToList(); //199:4
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp96 = __loop12_results[__loop12_iteration];
                var __loop12_var1 = __tmp96.__loop12_var1;
                var cls = __tmp96.cls;
                bool __tmp98_outputWritten = false;
                string __tmp97Prefix = "		"; //200:1
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
                string __tmp100_line = " = "; //200:55
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
                string __tmp102_line = ".ToImmutable(MModel);"; //200:114
                if (!string.IsNullOrEmpty(__tmp102_line))
                {
                    __out.Append(__tmp102_line);
                    __tmp98_outputWritten = true;
                }
                if (__tmp98_outputWritten) __out.AppendLine(true);
                if (__tmp98_outputWritten)
                {
                    __out.AppendLine(false); //200:135
                }
                var __loop13_results = 
                    (from __loop13_var1 in __Enumerate((cls).GetEnumerator()) //201:10
                    from prop in __Enumerate((__loop13_var1.Properties).GetEnumerator()) //201:15
                    select new { __loop13_var1 = __loop13_var1, prop = prop}
                    ).ToList(); //201:5
                for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
                {
                    var __tmp103 = __loop13_results[__loop13_iteration];
                    var __loop13_var1 = __tmp103.__loop13_var1;
                    var prop = __tmp103.prop;
                    bool __tmp105_outputWritten = false;
                    string __tmp104Prefix = "		"; //202:1
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
                    string __tmp107_line = " = "; //202:59
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
                    string __tmp109_line = ".ToImmutable(MModel);"; //202:122
                    if (!string.IsNullOrEmpty(__tmp109_line))
                    {
                        __out.Append(__tmp109_line);
                        __tmp105_outputWritten = true;
                    }
                    if (__tmp105_outputWritten) __out.AppendLine(true);
                    if (__tmp105_outputWritten)
                    {
                        __out.AppendLine(false); //202:143
                    }
                }
            }
            __out.AppendLine(true); //205:1
            bool __tmp111_outputWritten = false;
            string __tmp110Prefix = "		"; //206:1
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
            string __tmp113_line = ".initialized = true;"; //206:50
            if (!string.IsNullOrEmpty(__tmp113_line))
            {
                __out.Append(__tmp113_line);
                __tmp111_outputWritten = true;
            }
            if (__tmp111_outputWritten) __out.AppendLine(true);
            if (__tmp111_outputWritten)
            {
                __out.AppendLine(false); //206:70
            }
            __out.Append("	}"); //207:1
            __out.AppendLine(false); //207:3
            __out.Append("}"); //208:1
            __out.AppendLine(false); //208:2
            return __out.ToString();
        }

        public string GenerateMetaModelBuilderInstance(MetaModel model) //211:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //212:2
            bool metaMetaModel = IsMetaMetaModel(model); //213:2
            ImmutableList<ImmutableObject> instances = GetInstances(model); //214:2
            ImmutableDictionary<ImmutableObject,string> instanceNames = GetInstanceNames(model); //215:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //216:1
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
                __out.AppendLine(false); //216:61
            }
            __out.Append("{"); //217:1
            __out.AppendLine(false); //217:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	internal static "; //218:1
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
            string __tmp9_line = " instance = new "; //218:63
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
            string __tmp11_line = "();"; //218:124
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Append(__tmp11_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //218:127
            }
            __out.AppendLine(true); //219:1
            __out.Append("	private bool creating;"); //220:1
            __out.AppendLine(false); //220:24
            __out.Append("	private bool created;"); //221:1
            __out.AppendLine(false); //221:23
            bool __tmp13_outputWritten = false;
            string __tmp14_line = "	internal "; //222:1
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
            string __tmp16_line = ".MutableModel MModel;"; //222:30
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Append(__tmp16_line);
                __tmp13_outputWritten = true;
            }
            if (__tmp13_outputWritten) __out.AppendLine(true);
            if (__tmp13_outputWritten)
            {
                __out.AppendLine(false); //222:51
            }
            if (!metaMetaModel) //223:3
            {
                bool __tmp18_outputWritten = false;
                string __tmp19_line = "	internal "; //224:1
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
                string __tmp21_line = ".MutableModelGroup MModelGroup;"; //224:30
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp18_outputWritten = true;
                }
                if (__tmp18_outputWritten) __out.AppendLine(true);
                if (__tmp18_outputWritten)
                {
                    __out.AppendLine(false); //224:61
                }
            }
            __out.AppendLine(true); //226:1
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //227:8
                from cst in __Enumerate((__loop14_var1).GetEnumerator()).OfType<MetaConstant>() //227:38
                select new { __loop14_var1 = __loop14_var1, cst = cst}
                ).ToList(); //227:3
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp22 = __loop14_results[__loop14_iteration];
                var __loop14_var1 = __tmp22.__loop14_var1;
                var cst = __tmp22.cst;
                bool __tmp24_outputWritten = false;
                string __tmp23Prefix = "	"; //228:1
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
                    __out.AppendLine(false); //228:30
                }
                if (metaMetaModel) //229:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "	internal "; //230:1
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
                    string __tmp30_line = " "; //230:58
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
                    string __tmp32_line = " = null;"; //230:109
                    if (!string.IsNullOrEmpty(__tmp32_line))
                    {
                        __out.Append(__tmp32_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //230:117
                    }
                }
                else //231:4
                {
                    bool __tmp34_outputWritten = false;
                    string __tmp35_line = "	internal "; //232:1
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
                    string __tmp37_line = " "; //232:64
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
                    string __tmp39_line = " = null;"; //232:115
                    if (!string.IsNullOrEmpty(__tmp39_line))
                    {
                        __out.Append(__tmp39_line);
                        __tmp34_outputWritten = true;
                    }
                    if (__tmp34_outputWritten) __out.AppendLine(true);
                    if (__tmp34_outputWritten)
                    {
                        __out.AppendLine(false); //232:123
                    }
                }
            }
            __out.AppendLine(true); //235:1
            var __loop15_results = 
                (from obj in __Enumerate((instances).GetEnumerator()) //236:8
                select new { obj = obj}
                ).ToList(); //236:3
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                var __tmp40 = __loop15_results[__loop15_iteration];
                var obj = __tmp40.obj;
                bool __tmp42_outputWritten = false;
                string __tmp41Prefix = "	"; //237:1
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
                    __out.AppendLine(false); //237:73
                }
            }
            __out.AppendLine(true); //239:1
            bool __tmp45_outputWritten = false;
            string __tmp46_line = "	internal "; //240:1
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
            string __tmp48_line = "()"; //240:56
            if (!string.IsNullOrEmpty(__tmp48_line))
            {
                __out.Append(__tmp48_line);
                __tmp45_outputWritten = true;
            }
            if (__tmp45_outputWritten) __out.AppendLine(true);
            if (__tmp45_outputWritten)
            {
                __out.AppendLine(false); //240:58
            }
            __out.Append("	{"); //241:1
            __out.AppendLine(false); //241:3
            if (metaMetaModel) //242:4
            {
                bool __tmp50_outputWritten = false;
                string __tmp51_line = "		this.MModel = new "; //243:1
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
                string __tmp53_line = ".MutableModel(\""; //243:40
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
                string __tmp55_line = "\");"; //243:67
                if (!string.IsNullOrEmpty(__tmp55_line))
                {
                    __out.Append(__tmp55_line);
                    __tmp50_outputWritten = true;
                }
                if (__tmp50_outputWritten) __out.AppendLine(true);
                if (__tmp50_outputWritten)
                {
                    __out.AppendLine(false); //243:70
                }
            }
            else //244:4
            {
                bool __tmp57_outputWritten = false;
                string __tmp58_line = "		this.MModelGroup = new "; //245:1
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
                string __tmp60_line = ".MutableModelGroup();"; //245:45
                if (!string.IsNullOrEmpty(__tmp60_line))
                {
                    __out.Append(__tmp60_line);
                    __tmp57_outputWritten = true;
                }
                if (__tmp57_outputWritten) __out.AppendLine(true);
                if (__tmp57_outputWritten)
                {
                    __out.AppendLine(false); //245:66
                }
                bool __tmp62_outputWritten = false;
                string __tmp63_line = "		this.MModelGroup.AddReference("; //246:1
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
                string __tmp65_line = ".MetaInstance.MModel.ToMutable(true));"; //246:52
                if (!string.IsNullOrEmpty(__tmp65_line))
                {
                    __out.Append(__tmp65_line);
                    __tmp62_outputWritten = true;
                }
                if (__tmp62_outputWritten) __out.AppendLine(true);
                if (__tmp62_outputWritten)
                {
                    __out.AppendLine(false); //246:90
                }
                bool __tmp67_outputWritten = false;
                string __tmp68_line = "		this.MModel = this.MModelGroup.CreateModel(\""; //247:1
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
                string __tmp70_line = "\");"; //247:67
                if (!string.IsNullOrEmpty(__tmp70_line))
                {
                    __out.Append(__tmp70_line);
                    __tmp67_outputWritten = true;
                }
                if (__tmp67_outputWritten) __out.AppendLine(true);
                if (__tmp67_outputWritten)
                {
                    __out.AppendLine(false); //247:70
                }
            }
            __out.Append("	}"); //249:1
            __out.AppendLine(false); //249:3
            __out.AppendLine(true); //250:1
            __out.Append("	internal void Create()"); //251:1
            __out.AppendLine(false); //251:24
            __out.Append("	{"); //252:1
            __out.AppendLine(false); //252:3
            __out.Append("		lock (this)"); //253:1
            __out.AppendLine(false); //253:14
            __out.Append("		{"); //254:1
            __out.AppendLine(false); //254:4
            __out.Append("			if (this.creating || this.created) return;"); //255:1
            __out.AppendLine(false); //255:46
            __out.Append("			this.creating = true;"); //256:1
            __out.AppendLine(false); //256:25
            __out.Append("		}"); //257:1
            __out.AppendLine(false); //257:4
            __out.Append("		this.CreateInstances();"); //258:1
            __out.AppendLine(false); //258:26
            bool __tmp72_outputWritten = false;
            string __tmp71Prefix = "		"; //259:1
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
            string __tmp74_line = ".Implementation."; //259:55
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
            string __tmp76_line = "(this);"; //259:116
            if (!string.IsNullOrEmpty(__tmp76_line))
            {
                __out.Append(__tmp76_line);
                __tmp72_outputWritten = true;
            }
            if (__tmp72_outputWritten) __out.AppendLine(true);
            if (__tmp72_outputWritten)
            {
                __out.AppendLine(false); //259:123
            }
            __out.Append("        foreach (global::MetaDslx.Modeling.MutableObject obj in this.MModel.Objects)"); //260:1
            __out.AppendLine(false); //260:85
            __out.Append("        {"); //261:1
            __out.AppendLine(false); //261:10
            __out.Append("            obj.MMakeCreated();"); //262:1
            __out.AppendLine(false); //262:32
            __out.Append("        }"); //263:1
            __out.AppendLine(false); //263:10
            __out.Append("		lock (this)"); //264:1
            __out.AppendLine(false); //264:14
            __out.Append("		{"); //265:1
            __out.AppendLine(false); //265:4
            __out.Append("			this.created = true;"); //266:1
            __out.AppendLine(false); //266:24
            __out.Append("		}"); //267:1
            __out.AppendLine(false); //267:4
            __out.Append("	}"); //268:1
            __out.AppendLine(false); //268:3
            __out.AppendLine(true); //269:1
            __out.Append("	internal void EvaluateLazyValues()"); //270:1
            __out.AppendLine(false); //270:36
            __out.Append("	{"); //271:1
            __out.AppendLine(false); //271:3
            __out.Append("		if (!this.created) return;"); //272:1
            __out.AppendLine(false); //272:29
            __out.Append("		this.MModel.EvaluateLazyValues();"); //273:1
            __out.AppendLine(false); //273:36
            __out.Append("	}"); //274:1
            __out.AppendLine(false); //274:3
            __out.AppendLine(true); //275:1
            __out.Append("	private void CreateInstances()"); //276:1
            __out.AppendLine(false); //276:32
            __out.Append("	{"); //277:1
            __out.AppendLine(false); //277:3
            bool __tmp78_outputWritten = false;
            string __tmp77Prefix = "		"; //278:1
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
            string __tmp80_line = ".MetaFactory factory = new "; //278:22
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
            string __tmp82_line = ".MetaFactory(this.MModel, "; //278:68
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
            string __tmp84_line = ".ModelFactoryFlags.DontMakeObjectsCreated);"; //278:113
            if (!string.IsNullOrEmpty(__tmp84_line))
            {
                __out.Append(__tmp84_line);
                __tmp78_outputWritten = true;
            }
            if (__tmp78_outputWritten) __out.AppendLine(true);
            if (__tmp78_outputWritten)
            {
                __out.AppendLine(false); //278:156
            }
            if (!metaMetaModel) //279:4
            {
                bool __tmp86_outputWritten = false;
                string __tmp85Prefix = "		"; //280:1
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
                string __tmp88_line = " constantFactory = new "; //280:40
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
                string __tmp90_line = "(this.MModel, global::MetaDslx.Modeling.ModelFactoryFlags.DontMakeObjectsCreated);"; //280:100
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Append(__tmp90_line);
                    __tmp86_outputWritten = true;
                }
                if (__tmp86_outputWritten) __out.AppendLine(true);
                if (__tmp86_outputWritten)
                {
                    __out.AppendLine(false); //280:182
                }
            }
            __out.AppendLine(true); //282:1
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //283:9
                from cst in __Enumerate((__loop16_var1).GetEnumerator()).OfType<MetaConstant>() //283:39
                select new { __loop16_var1 = __loop16_var1, cst = cst}
                ).ToList(); //283:4
            for (int __loop16_iteration = 0; __loop16_iteration < __loop16_results.Count; ++__loop16_iteration)
            {
                var __tmp91 = __loop16_results[__loop16_iteration];
                var __loop16_var1 = __tmp91.__loop16_var1;
                var cst = __tmp91.cst;
                if (metaMetaModel) //284:5
                {
                    bool __tmp93_outputWritten = false;
                    string __tmp92Prefix = "		"; //285:1
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
                    string __tmp95_line = " = factory."; //285:53
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
                    string __tmp97_line = "();"; //285:113
                    if (!string.IsNullOrEmpty(__tmp97_line))
                    {
                        __out.Append(__tmp97_line);
                        __tmp93_outputWritten = true;
                    }
                    if (__tmp93_outputWritten) __out.AppendLine(true);
                    if (__tmp93_outputWritten)
                    {
                        __out.AppendLine(false); //285:116
                    }
                }
                else //286:5
                {
                    bool __tmp99_outputWritten = false;
                    string __tmp98Prefix = "		"; //287:1
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
                    string __tmp101_line = " = constantFactory."; //287:53
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
                    string __tmp103_line = "();"; //287:121
                    if (!string.IsNullOrEmpty(__tmp103_line))
                    {
                        __out.Append(__tmp103_line);
                        __tmp99_outputWritten = true;
                    }
                    if (__tmp99_outputWritten) __out.AppendLine(true);
                    if (__tmp99_outputWritten)
                    {
                        __out.AppendLine(false); //287:124
                    }
                }
                if (cst.DotNetName != null) //289:5
                {
                    bool __tmp105_outputWritten = false;
                    string __tmp104Prefix = "		"; //290:1
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
                    string __tmp107_line = ".MName = \""; //290:53
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
                    string __tmp109_line = "\";"; //290:79
                    if (!string.IsNullOrEmpty(__tmp109_line))
                    {
                        __out.Append(__tmp109_line);
                        __tmp105_outputWritten = true;
                    }
                    if (__tmp105_outputWritten) __out.AppendLine(true);
                    if (__tmp105_outputWritten)
                    {
                        __out.AppendLine(false); //290:81
                    }
                }
            }
            __out.AppendLine(true); //293:1
            var __loop17_results = 
                (from obj in __Enumerate((instances).GetEnumerator()) //294:9
                select new { obj = obj}
                ).ToList(); //294:4
            for (int __loop17_iteration = 0; __loop17_iteration < __loop17_results.Count; ++__loop17_iteration)
            {
                var __tmp110 = __loop17_results[__loop17_iteration];
                var obj = __tmp110.obj;
                bool __tmp112_outputWritten = false;
                string __tmp111Prefix = "		"; //295:1
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
                    __out.AppendLine(false); //295:63
                }
            }
            __out.AppendLine(true); //297:1
            var __loop18_results = 
                (from obj in __Enumerate((instances).GetEnumerator()) //298:9
                select new { obj = obj}
                ).ToList(); //298:4
            for (int __loop18_iteration = 0; __loop18_iteration < __loop18_results.Count; ++__loop18_iteration)
            {
                var __tmp114 = __loop18_results[__loop18_iteration];
                var obj = __tmp114.obj;
                bool __tmp116_outputWritten = false;
                string __tmp115Prefix = "		"; //299:1
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
                    __out.AppendLine(false); //299:73
                }
            }
            __out.Append("	}"); //301:1
            __out.AppendLine(false); //301:3
            __out.Append("}"); //302:1
            __out.AppendLine(false); //302:2
            return __out.ToString();
        }

        public string GenerateInstanceDeclaration(MetaModel model, bool metaMetaModel, ImmutableObject obj, ImmutableDictionary<ImmutableObject,string> instanceNames) //305:1
        {
            StringBuilder __out = new StringBuilder();
            if (obj != null && obj.MMetaClass != null && instanceNames.ContainsKey(obj)) //306:2
            {
                string name = instanceNames[obj]; //307:3
                if (metaMetaModel) //308:3
                {
                    if (name.StartsWith("__")) //309:4
                    {
                        bool __tmp2_outputWritten = false;
                        string __tmp3_line = "private "; //310:1
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
                        string __tmp5_line = " "; //310:62
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
                        string __tmp7_line = ";"; //310:69
                        if (!string.IsNullOrEmpty(__tmp7_line))
                        {
                            __out.Append(__tmp7_line);
                            __tmp2_outputWritten = true;
                        }
                        if (__tmp2_outputWritten) __out.AppendLine(true);
                        if (__tmp2_outputWritten)
                        {
                            __out.AppendLine(false); //310:70
                        }
                    }
                    else //311:4
                    {
                        bool __tmp9_outputWritten = false;
                        string __tmp10_line = "internal "; //312:1
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
                        string __tmp12_line = " "; //312:63
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
                        string __tmp14_line = ";"; //312:70
                        if (!string.IsNullOrEmpty(__tmp14_line))
                        {
                            __out.Append(__tmp14_line);
                            __tmp9_outputWritten = true;
                        }
                        if (__tmp9_outputWritten) __out.AppendLine(true);
                        if (__tmp9_outputWritten)
                        {
                            __out.AppendLine(false); //312:71
                        }
                    }
                }
                else //314:3
                {
                    if (name.StartsWith("__")) //315:4
                    {
                        bool __tmp16_outputWritten = false;
                        string __tmp17_line = "private "; //316:1
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
                        string __tmp19_line = " "; //316:68
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
                        string __tmp21_line = ";"; //316:75
                        if (!string.IsNullOrEmpty(__tmp21_line))
                        {
                            __out.Append(__tmp21_line);
                            __tmp16_outputWritten = true;
                        }
                        if (__tmp16_outputWritten) __out.AppendLine(true);
                        if (__tmp16_outputWritten)
                        {
                            __out.AppendLine(false); //316:76
                        }
                    }
                    else //317:4
                    {
                        bool __tmp23_outputWritten = false;
                        string __tmp24_line = "internal "; //318:1
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
                        string __tmp26_line = " "; //318:69
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
                        string __tmp28_line = ";"; //318:76
                        if (!string.IsNullOrEmpty(__tmp28_line))
                        {
                            __out.Append(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                        if (__tmp23_outputWritten) __out.AppendLine(true);
                        if (__tmp23_outputWritten)
                        {
                            __out.AppendLine(false); //318:77
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateInstance(MetaModel model, bool metaMetaModel, ImmutableObject obj, ImmutableDictionary<ImmutableObject,string> instanceNames) //324:1
        {
            StringBuilder __out = new StringBuilder();
            if (obj != null && obj.MMetaClass != null && instanceNames.ContainsKey(obj)) //325:2
            {
                string name = instanceNames[obj]; //326:3
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
                string __tmp4_line = " = factory."; //327:7
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
                string __tmp6_line = "();"; //327:73
                if (!string.IsNullOrEmpty(__tmp6_line))
                {
                    __out.Append(__tmp6_line);
                    __tmp2_outputWritten = true;
                }
                if (__tmp2_outputWritten) __out.AppendLine(true);
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //327:76
                }
            }
            return __out.ToString();
        }

        public string GenerateInstanceProperties(MetaModel model, bool metaMetaModel, ImmutableObject obj, ImmutableDictionary<ImmutableObject,string> instanceNames) //331:1
        {
            StringBuilder __out = new StringBuilder();
            if (obj != null && obj.MMetaClass != null && instanceNames.ContainsKey(obj)) //332:2
            {
                var __loop19_results = 
                    (from __loop19_var1 in __Enumerate((obj).GetEnumerator()) //333:8
                    from prop in __Enumerate((__loop19_var1.MProperties).GetEnumerator()) //333:13
                    where !prop.IsDerived && !prop.IsDerivedUnion //333:30
                    select new { __loop19_var1 = __loop19_var1, prop = prop}
                    ).ToList(); //333:3
                for (int __loop19_iteration = 0; __loop19_iteration < __loop19_results.Count; ++__loop19_iteration)
                {
                    var __tmp1 = __loop19_results[__loop19_iteration];
                    var __loop19_var1 = __tmp1.__loop19_var1;
                    var prop = __tmp1.prop;
                    if (obj is MetaConstant && prop.Name == "Value") //334:4
                    {
                        string name = instanceNames[obj]; //335:5
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
                        string __tmp5_line = ".SetValueLazy(() => "; //336:7
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
                        string __tmp7_line = ");"; //336:93
                        if (!string.IsNullOrEmpty(__tmp7_line))
                        {
                            __out.Append(__tmp7_line);
                            __tmp3_outputWritten = true;
                        }
                        if (__tmp3_outputWritten) __out.AppendLine(true);
                        if (__tmp3_outputWritten)
                        {
                            __out.AppendLine(false); //336:95
                        }
                    }
                    else //337:4
                    {
                        object propValue = obj.MGet(prop); //338:5
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
                            __out.AppendLine(false); //339:91
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateInstancePropertyValue(MetaModel model, bool metaMetaModel, ImmutableObject obj, ModelProperty prop, object value, ImmutableDictionary<ImmutableObject,string> instanceNames) //345:1
        {
            StringBuilder __out = new StringBuilder();
            string name = instanceNames[obj]; //346:2
            ImmutableObject valueObject = value as ImmutableObject; //347:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //348:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //349:2
            if (value == null) //350:2
            {
                if (prop.MutableType != null && prop.MutableType.IsClass) //351:3
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
                    string __tmp4_line = "."; //352:7
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
                    string __tmp6_line = " = null;"; //352:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //352:27
                    }
                }
                else //353:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //354:1
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
                    string __tmp11_line = "."; //354:10
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
                    string __tmp13_line = " = null;"; //354:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Append(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //354:30
                    }
                }
            }
            else if (value is string) //356:2
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
                string __tmp17_line = "."; //357:7
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
                string __tmp19_line = " = \""; //357:19
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
                string __tmp21_line = "\";"; //357:50
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //357:52
                }
            }
            else if (value is bool) //358:2
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
                string __tmp25_line = "."; //359:7
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
                string __tmp27_line = " = "; //359:19
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
                string __tmp29_line = ";"; //359:50
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Append(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //359:51
                }
            }
            else if (value.GetType().IsPrimitive) //360:2
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
                string __tmp33_line = "."; //361:7
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
                string __tmp35_line = " = "; //361:19
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
                string __tmp37_line = ";"; //361:40
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //361:41
                }
            }
            else if (value is MetaAttribute) //362:2
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
                string __tmp41_line = "."; //363:7
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
                string __tmp43_line = " = "; //363:19
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
                string __tmp45_line = ";"; //363:72
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Append(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //363:73
                }
            }
            else if (value is Enum) //364:2
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
                string __tmp49_line = "."; //365:7
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
                string __tmp51_line = " = "; //365:19
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
                string __tmp53_line = ";"; //365:58
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp47_outputWritten = true;
                }
                if (__tmp47_outputWritten) __out.AppendLine(true);
                if (__tmp47_outputWritten)
                {
                    __out.AppendLine(false); //365:59
                }
            }
            else if (value is MetaExternalType) //366:2
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
                string __tmp57_line = ".Set"; //367:7
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
                string __tmp59_line = "Lazy(() => "; //367:22
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
                string __tmp61_line = ");"; //367:80
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Append(__tmp61_line);
                    __tmp55_outputWritten = true;
                }
                if (__tmp55_outputWritten) __out.AppendLine(true);
                if (__tmp55_outputWritten)
                {
                    __out.AppendLine(false); //367:82
                }
            }
            else if (value is MetaPrimitiveType) //368:2
            {
                if (metaMetaModel) //369:3
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
                    string __tmp65_line = ".Set"; //370:7
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
                    string __tmp67_line = "Lazy(() => "; //370:22
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
                    string __tmp69_line = ");"; //370:81
                    if (!string.IsNullOrEmpty(__tmp69_line))
                    {
                        __out.Append(__tmp69_line);
                        __tmp63_outputWritten = true;
                    }
                    if (__tmp63_outputWritten) __out.AppendLine(true);
                    if (__tmp63_outputWritten)
                    {
                        __out.AppendLine(false); //370:83
                    }
                }
                else //371:3
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
                    string __tmp73_line = ".Set"; //372:7
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
                    string __tmp75_line = "Lazy(() => "; //372:22
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
                    string __tmp77_line = ".ToMutable());"; //372:114
                    if (!string.IsNullOrEmpty(__tmp77_line))
                    {
                        __out.Append(__tmp77_line);
                        __tmp71_outputWritten = true;
                    }
                    if (__tmp71_outputWritten) __out.AppendLine(true);
                    if (__tmp71_outputWritten)
                    {
                        __out.AppendLine(false); //372:128
                    }
                }
            }
            else if (valueObject != null && instanceNames.ContainsKey(valueObject)) //374:2
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
                string __tmp81_line = ".Set"; //375:7
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
                string __tmp83_line = "Lazy(() => "; //375:22
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
                string __tmp85_line = ");"; //375:61
                if (!string.IsNullOrEmpty(__tmp85_line))
                {
                    __out.Append(__tmp85_line);
                    __tmp79_outputWritten = true;
                }
                if (__tmp79_outputWritten) __out.AppendLine(true);
                if (__tmp79_outputWritten)
                {
                    __out.AppendLine(false); //375:63
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //376:2
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
                string __tmp89_line = ".Set"; //377:7
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
                string __tmp91_line = "Lazy(() => "; //377:22
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
                string __tmp93_line = ");"; //377:101
                if (!string.IsNullOrEmpty(__tmp93_line))
                {
                    __out.Append(__tmp93_line);
                    __tmp87_outputWritten = true;
                }
                if (__tmp87_outputWritten) __out.AppendLine(true);
                if (__tmp87_outputWritten)
                {
                    __out.AppendLine(false); //377:103
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //378:2
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
                string __tmp97_line = ".Set"; //379:7
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
                string __tmp99_line = "Lazy(() => "; //379:22
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
                string __tmp101_line = ");"; //379:105
                if (!string.IsNullOrEmpty(__tmp101_line))
                {
                    __out.Append(__tmp101_line);
                    __tmp95_outputWritten = true;
                }
                if (__tmp95_outputWritten) __out.AppendLine(true);
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //379:107
                }
            }
            else if (valueCollection != null) //380:2
            {
                var __loop20_results = 
                    (from cvalue in __Enumerate((valueCollection).GetEnumerator()) //381:8
                    select new { cvalue = cvalue}
                    ).ToList(); //381:3
                for (int __loop20_iteration = 0; __loop20_iteration < __loop20_results.Count; ++__loop20_iteration)
                {
                    var __tmp102 = __loop20_results[__loop20_iteration];
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
                        __out.AppendLine(false); //382:98
                    }
                }
            }
            else //384:2
            {
                bool __tmp107_outputWritten = false;
                string __tmp108_line = "// TODO: "; //385:1
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
                string __tmp110_line = "."; //385:16
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
                    __out.AppendLine(false); //385:28
                }
            }
            return __out.ToString();
        }

        public string GenerateInstancePropertyCollectionValue(MetaModel model, bool metaMetaModel, ImmutableObject obj, ModelProperty prop, object value, ImmutableDictionary<ImmutableObject,string> instanceNames) //389:1
        {
            StringBuilder __out = new StringBuilder();
            string name = instanceNames[obj]; //390:2
            ImmutableObject valueObject = value as ImmutableObject; //391:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //392:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //393:2
            if (value == null) //394:2
            {
                if (prop.MutableType != null && prop.MutableType.IsClass) //395:3
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
                    string __tmp4_line = "."; //396:7
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
                    string __tmp6_line = ".Add(null);"; //396:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //396:30
                    }
                }
                else //397:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //398:1
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
                    string __tmp11_line = "."; //398:10
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
                    string __tmp13_line = ".Add(null);"; //398:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Append(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //398:33
                    }
                }
            }
            else if (value is string) //400:2
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
                string __tmp17_line = "."; //401:7
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
                string __tmp19_line = ".Add(\""; //401:19
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
                string __tmp21_line = "\");"; //401:52
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //401:55
                }
            }
            else if (value is bool) //402:2
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
                string __tmp25_line = "."; //403:7
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
                string __tmp27_line = ".Add("; //403:19
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
                string __tmp29_line = ");"; //403:52
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Append(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //403:54
                }
            }
            else if (value.GetType().IsPrimitive) //404:2
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
                string __tmp33_line = "."; //405:7
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
                string __tmp35_line = ".Add("; //405:19
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
                string __tmp37_line = ");"; //405:42
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //405:44
                }
            }
            else if (value is MetaAttribute) //406:2
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
                string __tmp41_line = "."; //407:7
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
                string __tmp43_line = ".Add("; //407:19
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
                string __tmp45_line = ");"; //407:74
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Append(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //407:76
                }
            }
            else if (value is Enum) //408:2
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
                string __tmp49_line = "."; //409:7
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
                string __tmp51_line = ".Add("; //409:19
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
                string __tmp53_line = ");"; //409:60
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp47_outputWritten = true;
                }
                if (__tmp47_outputWritten) __out.AppendLine(true);
                if (__tmp47_outputWritten)
                {
                    __out.AppendLine(false); //409:62
                }
            }
            else if (value is MetaExternalType) //410:2
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
                string __tmp57_line = "."; //411:7
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
                string __tmp59_line = ".AddLazy(() => "; //411:19
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
                string __tmp61_line = ");"; //411:81
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Append(__tmp61_line);
                    __tmp55_outputWritten = true;
                }
                if (__tmp55_outputWritten) __out.AppendLine(true);
                if (__tmp55_outputWritten)
                {
                    __out.AppendLine(false); //411:83
                }
            }
            else if (value is MetaPrimitiveType) //412:2
            {
                if (metaMetaModel) //413:3
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
                    string __tmp65_line = "."; //414:7
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
                    string __tmp67_line = ".AddLazy(() => "; //414:19
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
                    string __tmp69_line = ");"; //414:82
                    if (!string.IsNullOrEmpty(__tmp69_line))
                    {
                        __out.Append(__tmp69_line);
                        __tmp63_outputWritten = true;
                    }
                    if (__tmp63_outputWritten) __out.AppendLine(true);
                    if (__tmp63_outputWritten)
                    {
                        __out.AppendLine(false); //414:84
                    }
                }
                else //415:3
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
                    string __tmp73_line = "."; //416:7
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
                    string __tmp75_line = ".AddLazy(() => "; //416:19
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
                    string __tmp77_line = ".ToMutable());"; //416:115
                    if (!string.IsNullOrEmpty(__tmp77_line))
                    {
                        __out.Append(__tmp77_line);
                        __tmp71_outputWritten = true;
                    }
                    if (__tmp71_outputWritten) __out.AppendLine(true);
                    if (__tmp71_outputWritten)
                    {
                        __out.AppendLine(false); //416:129
                    }
                }
            }
            else if (valueObject != null && instanceNames.ContainsKey(valueObject)) //418:2
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
                string __tmp81_line = "."; //419:7
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
                string __tmp83_line = ".AddLazy(() => "; //419:19
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
                string __tmp85_line = ");"; //419:62
                if (!string.IsNullOrEmpty(__tmp85_line))
                {
                    __out.Append(__tmp85_line);
                    __tmp79_outputWritten = true;
                }
                if (__tmp79_outputWritten) __out.AppendLine(true);
                if (__tmp79_outputWritten)
                {
                    __out.AppendLine(false); //419:64
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //420:2
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
                string __tmp89_line = "."; //421:7
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
                string __tmp91_line = ".AddLazy(() => "; //421:19
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
                string __tmp93_line = ");"; //421:102
                if (!string.IsNullOrEmpty(__tmp93_line))
                {
                    __out.Append(__tmp93_line);
                    __tmp87_outputWritten = true;
                }
                if (__tmp87_outputWritten) __out.AppendLine(true);
                if (__tmp87_outputWritten)
                {
                    __out.AppendLine(false); //421:104
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //422:2
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
                string __tmp97_line = "."; //423:7
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
                string __tmp99_line = ".AddLazy(() => "; //423:19
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
                string __tmp101_line = ");"; //423:106
                if (!string.IsNullOrEmpty(__tmp101_line))
                {
                    __out.Append(__tmp101_line);
                    __tmp95_outputWritten = true;
                }
                if (__tmp95_outputWritten) __out.AppendLine(true);
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //423:108
                }
            }
            else //424:2
            {
                bool __tmp103_outputWritten = false;
                string __tmp104_line = "// TODO: "; //425:1
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
                string __tmp106_line = "."; //425:16
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
                    __out.AppendLine(false); //425:28
                }
            }
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //429:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //430:2
            bool metaMetaModel = IsMetaMetaModel(model); //431:2
            __out.Append("/// <summary>"); //432:1
            __out.AppendLine(false); //432:14
            __out.Append("/// Factory class for creating instances of model elements."); //433:1
            __out.AppendLine(false); //433:60
            __out.Append("/// </summary>"); //434:1
            __out.AppendLine(false); //434:15
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //435:1
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
            string __tmp5_line = " : "; //435:51
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
            string __tmp7_line = ".ModelFactoryBase"; //435:73
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //435:90
            }
            __out.Append("{"); //436:1
            __out.AppendLine(false); //436:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public "; //437:1
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
            string __tmp12_line = "("; //437:46
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
            string __tmp14_line = ".MutableModel model, "; //437:66
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
            string __tmp16_line = ".ModelFactoryFlags flags = "; //437:106
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
            string __tmp18_line = ".ModelFactoryFlags.None)"; //437:152
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Append(__tmp18_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //437:176
            }
            __out.Append("		: base(model, flags)"); //438:1
            __out.AppendLine(false); //438:23
            __out.Append("	{"); //439:1
            __out.AppendLine(false); //439:3
            bool __tmp20_outputWritten = false;
            string __tmp19Prefix = "		"; //440:1
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
            string __tmp22_line = ".Initialize();"; //440:43
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Append(__tmp22_line);
                __tmp20_outputWritten = true;
            }
            if (__tmp20_outputWritten) __out.AppendLine(true);
            if (__tmp20_outputWritten)
            {
                __out.AppendLine(false); //440:57
            }
            __out.Append("	}"); //441:1
            __out.AppendLine(false); //441:3
            __out.AppendLine(true); //442:1
            bool __tmp24_outputWritten = false;
            string __tmp25_line = "	public override "; //443:1
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
            string __tmp27_line = ".IMetaModel MMetaModel => "; //443:37
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
            string __tmp29_line = ".MMetaModel;"; //443:116
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Append(__tmp29_line);
                __tmp24_outputWritten = true;
            }
            if (__tmp24_outputWritten) __out.AppendLine(true);
            if (__tmp24_outputWritten)
            {
                __out.AppendLine(false); //443:128
            }
            __out.AppendLine(true); //444:1
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "	public override "; //445:1
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
            string __tmp34_line = ".MutableObject Create(string type)"; //445:37
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Append(__tmp34_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //445:71
            }
            __out.Append("	{"); //446:1
            __out.AppendLine(false); //446:3
            __out.Append("		switch (type)"); //447:1
            __out.AppendLine(false); //447:16
            __out.Append("		{"); //448:1
            __out.AppendLine(false); //448:4
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //449:10
                from cls in __Enumerate((__loop21_var1).GetEnumerator()).OfType<MetaClass>() //449:40
                select new { __loop21_var1 = __loop21_var1, cls = cls}
                ).ToList(); //449:5
            for (int __loop21_iteration = 0; __loop21_iteration < __loop21_results.Count; ++__loop21_iteration)
            {
                var __tmp35 = __loop21_results[__loop21_iteration];
                var __loop21_var1 = __tmp35.__loop21_var1;
                var cls = __tmp35.cls;
                if (!cls.IsAbstract) //450:6
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "			case \""; //451:1
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
                    string __tmp40_line = "\": return this."; //451:33
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
                    string __tmp42_line = "();"; //451:71
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Append(__tmp42_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //451:74
                    }
                }
            }
            __out.Append("			default:"); //454:1
            __out.AppendLine(false); //454:12
            bool __tmp44_outputWritten = false;
            string __tmp45_line = "				throw new "; //455:1
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
            string __tmp47_line = ".ModelException("; //455:34
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
            string __tmp49_line = ".ModelErrorCode.ERR_UnknownTypeName.ToDiagnosticWithNoLocation(type));"; //455:69
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Append(__tmp49_line);
                __tmp44_outputWritten = true;
            }
            if (__tmp44_outputWritten) __out.AppendLine(true);
            if (__tmp44_outputWritten)
            {
                __out.AppendLine(false); //455:139
            }
            __out.Append("		}"); //456:1
            __out.AppendLine(false); //456:4
            __out.Append("	}"); //457:1
            __out.AppendLine(false); //457:3
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //458:8
                from cls in __Enumerate((__loop22_var1).GetEnumerator()).OfType<MetaClass>() //458:38
                select new { __loop22_var1 = __loop22_var1, cls = cls}
                ).ToList(); //458:3
            for (int __loop22_iteration = 0; __loop22_iteration < __loop22_results.Count; ++__loop22_iteration)
            {
                var __tmp50 = __loop22_results[__loop22_iteration];
                var __loop22_var1 = __tmp50.__loop22_var1;
                var cls = __tmp50.cls;
                if (!cls.IsAbstract) //459:4
                {
                    __out.AppendLine(true); //460:1
                    __out.Append("	/// <summary>"); //461:1
                    __out.AppendLine(false); //461:15
                    bool __tmp52_outputWritten = false;
                    string __tmp53_line = "	/// Creates a new instance of "; //462:1
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
                    string __tmp55_line = "."; //462:55
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Append(__tmp55_line);
                        __tmp52_outputWritten = true;
                    }
                    if (__tmp52_outputWritten) __out.AppendLine(true);
                    if (__tmp52_outputWritten)
                    {
                        __out.AppendLine(false); //462:56
                    }
                    __out.Append("	/// </summary>"); //463:1
                    __out.AppendLine(false); //463:16
                    bool __tmp57_outputWritten = false;
                    string __tmp58_line = "	public "; //464:1
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
                    string __tmp60_line = " "; //464:51
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
                    string __tmp62_line = "()"; //464:100
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Append(__tmp62_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //464:102
                    }
                    __out.Append("	{"); //465:1
                    __out.AppendLine(false); //465:3
                    bool __tmp64_outputWritten = false;
                    string __tmp63Prefix = "		"; //466:1
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
                    string __tmp66_line = ".MutableObject obj = this.CreateObject(new "; //466:22
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
                    string __tmp68_line = "());"; //466:102
                    if (!string.IsNullOrEmpty(__tmp68_line))
                    {
                        __out.Append(__tmp68_line);
                        __tmp64_outputWritten = true;
                    }
                    if (__tmp64_outputWritten) __out.AppendLine(true);
                    if (__tmp64_outputWritten)
                    {
                        __out.AppendLine(false); //466:106
                    }
                    bool __tmp70_outputWritten = false;
                    string __tmp71_line = "		return ("; //467:1
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
                    string __tmp73_line = ")obj;"; //467:53
                    if (!string.IsNullOrEmpty(__tmp73_line))
                    {
                        __out.Append(__tmp73_line);
                        __tmp70_outputWritten = true;
                    }
                    if (__tmp70_outputWritten) __out.AppendLine(true);
                    if (__tmp70_outputWritten)
                    {
                        __out.AppendLine(false); //467:58
                    }
                    __out.Append("	}"); //468:1
                    __out.AppendLine(false); //468:3
                }
            }
            __out.Append("}"); //471:1
            __out.AppendLine(false); //471:2
            __out.AppendLine(true); //472:1
            return __out.ToString();
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //475:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //476:2
            bool metaMetaModel = IsMetaMetaModel(model); //477:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public static class "; //478:1
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
                __out.AppendLine(false); //478:61
            }
            __out.Append("{"); //479:1
            __out.AppendLine(false); //479:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	private static global::System.Collections.Generic.List<"; //480:1
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
            string __tmp9_line = ".ModelProperty> properties;"; //480:76
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //480:103
            }
            __out.AppendLine(true); //481:1
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	static "; //482:1
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
            string __tmp14_line = "()"; //482:49
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //482:51
            }
            __out.Append("	{"); //483:1
            __out.AppendLine(false); //483:3
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "		properties = new global::System.Collections.Generic.List<"; //484:1
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
            string __tmp19_line = ".ModelProperty>();"; //484:79
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //484:97
            }
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //485:9
                from cls in __Enumerate((__loop23_var1).GetEnumerator()).OfType<MetaClass>() //485:39
                select new { __loop23_var1 = __loop23_var1, cls = cls}
                ).ToList(); //485:4
            for (int __loop23_iteration = 0; __loop23_iteration < __loop23_results.Count; ++__loop23_iteration)
            {
                var __tmp20 = __loop23_results[__loop23_iteration];
                var __loop23_var1 = __tmp20.__loop23_var1;
                var cls = __tmp20.cls;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "		"; //486:1
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
                string __tmp24_line = ".Initialize();"; //486:48
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Append(__tmp24_line);
                    __tmp22_outputWritten = true;
                }
                if (__tmp22_outputWritten) __out.AppendLine(true);
                if (__tmp22_outputWritten)
                {
                    __out.AppendLine(false); //486:62
                }
            }
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //488:9
                from cls in __Enumerate((__loop24_var1).GetEnumerator()).OfType<MetaClass>() //488:39
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //488:62
                select new { __loop24_var1 = __loop24_var1, cls = cls, prop = prop}
                ).ToList(); //488:4
            for (int __loop24_iteration = 0; __loop24_iteration < __loop24_results.Count; ++__loop24_iteration)
            {
                var __tmp25 = __loop24_results[__loop24_iteration];
                var __loop24_var1 = __tmp25.__loop24_var1;
                var cls = __tmp25.cls;
                var prop = __tmp25.prop;
                bool __tmp27_outputWritten = false;
                string __tmp28_line = "		properties.Add("; //489:1
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
                string __tmp30_line = ");"; //489:73
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Append(__tmp30_line);
                    __tmp27_outputWritten = true;
                }
                if (__tmp27_outputWritten) __out.AppendLine(true);
                if (__tmp27_outputWritten)
                {
                    __out.AppendLine(false); //489:75
                }
            }
            __out.Append("	}"); //491:1
            __out.AppendLine(false); //491:3
            __out.AppendLine(true); //492:1
            __out.Append("	public static void Initialize()"); //493:1
            __out.AppendLine(false); //493:33
            __out.Append("	{"); //494:1
            __out.AppendLine(false); //494:3
            __out.Append("	}"); //495:1
            __out.AppendLine(false); //495:3
            __out.AppendLine(true); //496:1
            bool __tmp32_outputWritten = false;
            string __tmp33_line = "	public const string MUri = \""; //497:1
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
            string __tmp35_line = "\";"; //497:41
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Append(__tmp35_line);
                __tmp32_outputWritten = true;
            }
            if (__tmp32_outputWritten) __out.AppendLine(true);
            if (__tmp32_outputWritten)
            {
                __out.AppendLine(false); //497:43
            }
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "	public const string MPrefix = \""; //498:1
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
            string __tmp40_line = "\";"; //498:47
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Append(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //498:49
            }
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //499:8
                from cls in __Enumerate((__loop25_var1).GetEnumerator()).OfType<MetaClass>() //499:38
                select new { __loop25_var1 = __loop25_var1, cls = cls}
                ).ToList(); //499:3
            for (int __loop25_iteration = 0; __loop25_iteration < __loop25_results.Count; ++__loop25_iteration)
            {
                var __tmp41 = __loop25_results[__loop25_iteration];
                var __loop25_var1 = __tmp41.__loop25_var1;
                var cls = __tmp41.cls;
                __out.AppendLine(true); //500:1
                bool __tmp43_outputWritten = false;
                string __tmp42Prefix = "	"; //501:1
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
                    __out.AppendLine(false); //501:39
                }
            }
            __out.Append("}"); //503:1
            __out.AppendLine(false); //503:2
            return __out.ToString();
        }

        public string GenerateDescriptorClass(MetaModel model, MetaClass cls) //506:1
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
                __out.AppendLine(false); //507:29
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
                __out.AppendLine(false); //508:26
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
            string __tmp10_line = ".ModelObjectDescriptorAttribute(typeof("; //509:24
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
            string __tmp12_line = "), typeof("; //509:105
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
            string __tmp14_line = "), typeof("; //509:164
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
            string __tmp16_line = ")"; //509:221
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
            string __tmp18_line = ")"; //509:258
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
                __out.AppendLine(false); //509:264
            }
            bool __tmp21_outputWritten = false;
            string __tmp22_line = "public static class "; //510:1
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
                __out.AppendLine(false); //510:66
            }
            __out.Append("{"); //511:1
            __out.AppendLine(false); //511:2
            bool __tmp25_outputWritten = false;
            string __tmp26_line = "	private static "; //512:1
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
            string __tmp28_line = ".ModelObjectDescriptor descriptor;"; //512:36
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Append(__tmp28_line);
                __tmp25_outputWritten = true;
            }
            if (__tmp25_outputWritten) __out.AppendLine(true);
            if (__tmp25_outputWritten)
            {
                __out.AppendLine(false); //512:70
            }
            __out.AppendLine(true); //513:1
            bool __tmp30_outputWritten = false;
            string __tmp31_line = "	static "; //514:1
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
            string __tmp33_line = "()"; //514:54
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Append(__tmp33_line);
                __tmp30_outputWritten = true;
            }
            if (__tmp30_outputWritten) __out.AppendLine(true);
            if (__tmp30_outputWritten)
            {
                __out.AppendLine(false); //514:56
            }
            __out.Append("	{"); //515:1
            __out.AppendLine(false); //515:3
            bool __tmp35_outputWritten = false;
            string __tmp36_line = "		descriptor = "; //516:1
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
            string __tmp38_line = ".ModelObjectDescriptor.GetDescriptorForDescriptorType(typeof("; //516:35
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
            string __tmp40_line = "));"; //516:141
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Append(__tmp40_line);
                __tmp35_outputWritten = true;
            }
            if (__tmp35_outputWritten) __out.AppendLine(true);
            if (__tmp35_outputWritten)
            {
                __out.AppendLine(false); //516:144
            }
            __out.Append("	}"); //517:1
            __out.AppendLine(false); //517:3
            __out.AppendLine(true); //518:1
            __out.Append("	internal static void Initialize()"); //519:1
            __out.AppendLine(false); //519:35
            __out.Append("	{"); //520:1
            __out.AppendLine(false); //520:3
            __out.Append("	}"); //521:1
            __out.AppendLine(false); //521:3
            __out.AppendLine(true); //522:1
            bool __tmp42_outputWritten = false;
            string __tmp43_line = "	public static "; //523:1
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
            string __tmp45_line = ".ModelObjectDescriptor MDescriptor"; //523:35
            if (!string.IsNullOrEmpty(__tmp45_line))
            {
                __out.Append(__tmp45_line);
                __tmp42_outputWritten = true;
            }
            if (__tmp42_outputWritten) __out.AppendLine(true);
            if (__tmp42_outputWritten)
            {
                __out.AppendLine(false); //523:69
            }
            __out.Append("	{"); //524:1
            __out.AppendLine(false); //524:3
            __out.Append("		get { return descriptor; }"); //525:1
            __out.AppendLine(false); //525:29
            __out.Append("	}"); //526:1
            __out.AppendLine(false); //526:3
            __out.AppendLine(true); //527:1
            bool __tmp47_outputWritten = false;
            string __tmp48_line = "	public static "; //528:1
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
            string __tmp50_line = ".MetaClass MMetaClass"; //528:35
            if (!string.IsNullOrEmpty(__tmp50_line))
            {
                __out.Append(__tmp50_line);
                __tmp47_outputWritten = true;
            }
            if (__tmp47_outputWritten) __out.AppendLine(true);
            if (__tmp47_outputWritten)
            {
                __out.AppendLine(false); //528:56
            }
            __out.Append("	{"); //529:1
            __out.AppendLine(false); //529:3
            bool __tmp52_outputWritten = false;
            string __tmp53_line = "		get { return "; //530:1
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
            string __tmp55_line = "; }"; //530:73
            if (!string.IsNullOrEmpty(__tmp55_line))
            {
                __out.Append(__tmp55_line);
                __tmp52_outputWritten = true;
            }
            if (__tmp52_outputWritten) __out.AppendLine(true);
            if (__tmp52_outputWritten)
            {
                __out.AppendLine(false); //530:76
            }
            __out.Append("	}"); //531:1
            __out.AppendLine(false); //531:3
            var __loop26_results = 
                (from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //532:8
                from prop in __Enumerate((__loop26_var1.Properties).GetEnumerator()) //532:13
                select new { __loop26_var1 = __loop26_var1, prop = prop}
                ).ToList(); //532:3
            for (int __loop26_iteration = 0; __loop26_iteration < __loop26_results.Count; ++__loop26_iteration)
            {
                var __tmp56 = __loop26_results[__loop26_iteration];
                var __loop26_var1 = __tmp56.__loop26_var1;
                var prop = __tmp56.prop;
                bool __tmp58_outputWritten = false;
                string __tmp57Prefix = "	"; //533:1
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
                    __out.AppendLine(false); //533:48
                }
            }
            __out.Append("}"); //535:1
            __out.AppendLine(false); //535:2
            return __out.ToString();
        }

        public string GetDescriptorAncestors(MetaModel model, MetaClass cls) //538:1
        {
            string result = ""; //539:2
            var __loop27_results = 
                (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //540:7
                from super in __Enumerate((__loop27_var1.SuperClasses).GetEnumerator()) //540:12
                select new { __loop27_var1 = __loop27_var1, super = super}
                ).ToList(); //540:2
            for (int __loop27_iteration = 0; __loop27_iteration < __loop27_results.Count; ++__loop27_iteration)
            {
                string delim; //540:30
                if (__loop27_iteration+1 < __loop27_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop27_results[__loop27_iteration];
                var __loop27_var1 = __tmp1.__loop27_var1;
                var super = __tmp1.super;
                result += "typeof(" + CSharpName(super, model, ClassKind.Descriptor, true) + ")" + delim; //541:3
            }
            if (result.Length > 0) //543:2
            {
                result = ", BaseDescriptors = new global::System.Type[] { " + result + " }"; //544:3
            }
            return result; //546:2
        }

        public string GenerateDescriptorProperty(MetaModel model, MetaClass cls, MetaProperty prop) //549:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //550:1
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
                __out.AppendLine(false); //551:30
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
                __out.AppendLine(false); //552:27
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
                __out.AppendLine(false); //553:57
            }
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "public static readonly "; //554:1
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
            string __tmp14_line = ".ModelProperty "; //554:43
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
            string __tmp16_line = " ="; //554:107
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Append(__tmp16_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //554:109
            }
            bool __tmp18_outputWritten = false;
            string __tmp17Prefix = "    "; //555:1
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
            string __tmp20_line = ".ModelProperty.Register(declaringType: typeof("; //555:24
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
            string __tmp22_line = "), name: \""; //555:115
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
            string __tmp24_line = "\","; //555:149
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //555:151
            }
            if (prop.Type is MetaCollectionType) //556:2
            {
                MetaCollectionType collType = (MetaCollectionType)prop.Type; //557:3
                bool __tmp26_outputWritten = false;
                string __tmp27_line = "        immutableType: typeof("; //558:1
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
                string __tmp29_line = "),"; //558:95
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Append(__tmp29_line);
                    __tmp26_outputWritten = true;
                }
                if (__tmp26_outputWritten) __out.AppendLine(true);
                if (__tmp26_outputWritten)
                {
                    __out.AppendLine(false); //558:97
                }
                bool __tmp31_outputWritten = false;
                string __tmp32_line = "        mutableType: typeof("; //559:1
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
                string __tmp34_line = "),"; //559:91
                if (!string.IsNullOrEmpty(__tmp34_line))
                {
                    __out.Append(__tmp34_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //559:93
                }
            }
            else //560:2
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "        immutableType: typeof("; //561:1
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
                string __tmp39_line = "),"; //561:86
                if (!string.IsNullOrEmpty(__tmp39_line))
                {
                    __out.Append(__tmp39_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //561:88
                }
                bool __tmp41_outputWritten = false;
                string __tmp42_line = "        mutableType: typeof("; //562:1
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
                string __tmp44_line = "),"; //562:82
                if (!string.IsNullOrEmpty(__tmp44_line))
                {
                    __out.Append(__tmp44_line);
                    __tmp41_outputWritten = true;
                }
                if (__tmp41_outputWritten) __out.AppendLine(true);
                if (__tmp41_outputWritten)
                {
                    __out.AppendLine(false); //562:84
                }
            }
            bool __tmp46_outputWritten = false;
            string __tmp47_line = "		metaProperty: () => "; //564:1
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
            string __tmp49_line = ","; //564:84
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Append(__tmp49_line);
                __tmp46_outputWritten = true;
            }
            if (__tmp46_outputWritten) __out.AppendLine(true);
            if (__tmp46_outputWritten)
            {
                __out.AppendLine(false); //564:85
            }
            bool __tmp51_outputWritten = false;
            string __tmp52_line = "		defaultValue: "; //565:1
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
            string __tmp54_line = ");"; //565:73
            if (!string.IsNullOrEmpty(__tmp54_line))
            {
                __out.Append(__tmp54_line);
                __tmp51_outputWritten = true;
            }
            if (__tmp51_outputWritten) __out.AppendLine(true);
            if (__tmp51_outputWritten)
            {
                __out.AppendLine(false); //565:75
            }
            return __out.ToString();
        }

        public string GenerateDescriptorPropertyAttributes(MetaModel model, MetaClass cls, MetaProperty prop) //568:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Type is MetaCollectionType) //569:2
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
                    __out.AppendLine(false); //570:48
                }
            }
            if (prop.Type is MetaCollectionType && (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiList)) //572:2
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
                    __out.AppendLine(false); //573:47
                }
            }
            if (prop.Type is MetaCollectionType && (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.List || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiList)) //575:2
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
                    __out.AppendLine(false); //576:45
                }
            }
            if (prop.IsContainment) //578:2
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
                    __out.AppendLine(false); //579:49
                }
            }
            if (prop.Kind != MetaPropertyKind.Normal) //581:2
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
                    __out.AppendLine(false); //582:46
                }
            }
            if (prop.Kind == MetaPropertyKind.Derived) //584:2
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
                    __out.AppendLine(false); //585:45
                }
            }
            if (prop.Kind == MetaPropertyKind.DerivedUnion) //587:2
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
                    __out.AppendLine(false); //588:50
                }
            }
            var __loop28_results = 
                (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //590:7
                select new { p = p}
                ).ToList(); //590:2
            for (int __loop28_iteration = 0; __loop28_iteration < __loop28_results.Count; ++__loop28_iteration)
            {
                var __tmp22 = __loop28_results[__loop28_iteration];
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
                    __out.AppendLine(false); //591:146
                }
            }
            var __loop29_results = 
                (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //593:7
                select new { p = p}
                ).ToList(); //593:2
            for (int __loop29_iteration = 0; __loop29_iteration < __loop29_results.Count; ++__loop29_iteration)
            {
                var __tmp30 = __loop29_results[__loop29_iteration];
                var p = __tmp30.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //594:3
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
                        __out.AppendLine(false); //595:145
                    }
                }
                else //596:3
                {
                    bool __tmp39_outputWritten = false;
                    string __tmp40_line = "// ERROR: subsetted property '"; //597:1
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
                    string __tmp42_line = "' must be a property of this class or an ancestor class"; //597:83
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Append(__tmp42_line);
                        __tmp39_outputWritten = true;
                    }
                    if (__tmp39_outputWritten) __out.AppendLine(true);
                    if (__tmp39_outputWritten)
                    {
                        __out.AppendLine(false); //597:138
                    }
                }
            }
            var __loop30_results = 
                (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //600:7
                select new { p = p}
                ).ToList(); //600:2
            for (int __loop30_iteration = 0; __loop30_iteration < __loop30_results.Count; ++__loop30_iteration)
            {
                var __tmp43 = __loop30_results[__loop30_iteration];
                var p = __tmp43.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //601:3
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
                        __out.AppendLine(false); //602:147
                    }
                }
                else //603:3
                {
                    bool __tmp52_outputWritten = false;
                    string __tmp53_line = "// ERROR: redefined property '"; //604:1
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
                    string __tmp55_line = "' must be a property of this class or an ancestor class"; //604:83
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Append(__tmp55_line);
                        __tmp52_outputWritten = true;
                    }
                    if (__tmp52_outputWritten) __out.AppendLine(true);
                    if (__tmp52_outputWritten)
                    {
                        __out.AppendLine(false); //604:138
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //609:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //610:1
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
                __out.AppendLine(false); //610:68
            }
            __out.Append("{"); //611:1
            __out.AppendLine(false); //611:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	// If there is a compile error at this line, create a new class called "; //612:1
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
                __out.AppendLine(false); //612:117
            }
            bool __tmp10_outputWritten = false;
            string __tmp11_line = "	// which is a subclass of "; //613:1
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
            string __tmp13_line = ":"; //613:82
            if (!string.IsNullOrEmpty(__tmp13_line))
            {
                __out.Append(__tmp13_line);
                __tmp10_outputWritten = true;
            }
            if (__tmp10_outputWritten) __out.AppendLine(true);
            if (__tmp10_outputWritten)
            {
                __out.AppendLine(false); //613:83
            }
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "	private static "; //614:1
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
            string __tmp18_line = " implementation = new "; //614:61
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
            string __tmp20_line = "();"; //614:127
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //614:130
            }
            __out.AppendLine(true); //615:1
            bool __tmp22_outputWritten = false;
            string __tmp23_line = "	public static "; //616:1
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
            string __tmp25_line = " Implementation"; //616:60
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Append(__tmp25_line);
                __tmp22_outputWritten = true;
            }
            if (__tmp22_outputWritten) __out.AppendLine(true);
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //616:75
            }
            __out.Append("	{"); //617:1
            __out.AppendLine(false); //617:3
            __out.Append("		get { return implementation; }"); //618:1
            __out.AppendLine(false); //618:33
            __out.Append("	}"); //619:1
            __out.AppendLine(false); //619:3
            __out.Append("}"); //620:1
            __out.AppendLine(false); //620:2
            return __out.ToString();
        }

        public string GenerateImplementationBase(MetaModel model) //623:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //624:2
            bool metaMetaModel = IsMetaMetaModel(model); //625:2
            __out.Append("/// <summary>"); //626:1
            __out.AppendLine(false); //626:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //627:1
            __out.AppendLine(false); //627:68
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "/// This class has to be be overriden in "; //628:1
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
            string __tmp5_line = " to provide custom"; //628:92
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Append(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //628:110
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //629:1
            __out.AppendLine(false); //629:73
            __out.Append("/// </summary>"); //630:1
            __out.AppendLine(false); //630:15
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "internal abstract class "; //631:1
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
                __out.AppendLine(false); //631:73
            }
            __out.Append("{"); //632:1
            __out.AppendLine(false); //632:2
            __out.Append("	/// <summary>"); //633:1
            __out.AppendLine(false); //633:15
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	/// Implements the constructor: "; //634:1
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
            string __tmp14_line = "()"; //634:79
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //634:81
            }
            __out.Append("	/// </summary>"); //635:1
            __out.AppendLine(false); //635:16
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	internal virtual void "; //636:1
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
            string __tmp19_line = "("; //636:69
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
            string __tmp21_line = " _this)"; //636:115
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //636:122
            }
            __out.Append("	{"); //637:1
            __out.AppendLine(false); //637:3
            __out.Append("	}"); //638:1
            __out.AppendLine(false); //638:3
            var __loop31_results = 
                (from __loop31_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //639:8
                from cls in __Enumerate((__loop31_var1).GetEnumerator()).OfType<MetaClass>() //639:38
                select new { __loop31_var1 = __loop31_var1, cls = cls}
                ).ToList(); //639:3
            for (int __loop31_iteration = 0; __loop31_iteration < __loop31_results.Count; ++__loop31_iteration)
            {
                var __tmp22 = __loop31_results[__loop31_iteration];
                var __loop31_var1 = __tmp22.__loop31_var1;
                var cls = __tmp22.cls;
                __out.AppendLine(true); //640:1
                __out.Append("	/// <summary>"); //641:1
                __out.AppendLine(false); //641:15
                bool __tmp24_outputWritten = false;
                string __tmp25_line = "	/// Implements the constructor: "; //642:1
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
                string __tmp27_line = "()"; //642:78
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Append(__tmp27_line);
                    __tmp24_outputWritten = true;
                }
                if (__tmp24_outputWritten) __out.AppendLine(true);
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //642:80
                }
                __out.Append("	/// </summary>"); //643:1
                __out.AppendLine(false); //643:16
                if ((from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //644:15
                from sup in __Enumerate((__loop32_var1.SuperClasses).GetEnumerator()) //644:20
                select new { __loop32_var1 = __loop32_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //644:3
                {
                    __out.Append("	/// Direct superclasses: "); //645:1
                    __out.AppendLine(false); //645:27
                    __out.Append("	/// <ul>"); //646:1
                    __out.AppendLine(false); //646:10
                    var __loop33_results = 
                        (from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //647:8
                        from sup in __Enumerate((__loop33_var1.SuperClasses).GetEnumerator()) //647:13
                        select new { __loop33_var1 = __loop33_var1, sup = sup}
                        ).ToList(); //647:3
                    for (int __loop33_iteration = 0; __loop33_iteration < __loop33_results.Count; ++__loop33_iteration)
                    {
                        var __tmp28 = __loop33_results[__loop33_iteration];
                        var __loop33_var1 = __tmp28.__loop33_var1;
                        var sup = __tmp28.sup;
                        bool __tmp30_outputWritten = false;
                        string __tmp31_line = "	///     <li>"; //648:1
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
                        string __tmp33_line = "</li>"; //648:64
                        if (!string.IsNullOrEmpty(__tmp33_line))
                        {
                            __out.Append(__tmp33_line);
                            __tmp30_outputWritten = true;
                        }
                        if (__tmp30_outputWritten) __out.AppendLine(true);
                        if (__tmp30_outputWritten)
                        {
                            __out.AppendLine(false); //648:69
                        }
                    }
                    __out.Append("	/// </ul>"); //650:1
                    __out.AppendLine(false); //650:11
                    __out.Append("	/// All superclasses:"); //651:1
                    __out.AppendLine(false); //651:23
                    __out.Append("	/// <ul>"); //652:1
                    __out.AppendLine(false); //652:10
                    var __loop34_results = 
                        (from __loop34_var1 in __Enumerate((cls).GetEnumerator()) //653:8
                        from sup in __Enumerate((__loop34_var1.GetAllSuperClasses(false)).GetEnumerator()) //653:13
                        select new { __loop34_var1 = __loop34_var1, sup = sup}
                        ).ToList(); //653:3
                    for (int __loop34_iteration = 0; __loop34_iteration < __loop34_results.Count; ++__loop34_iteration)
                    {
                        var __tmp34 = __loop34_results[__loop34_iteration];
                        var __loop34_var1 = __tmp34.__loop34_var1;
                        var sup = __tmp34.sup;
                        bool __tmp36_outputWritten = false;
                        string __tmp37_line = "	///     <li>"; //654:1
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
                        string __tmp39_line = "</li>"; //654:64
                        if (!string.IsNullOrEmpty(__tmp39_line))
                        {
                            __out.Append(__tmp39_line);
                            __tmp36_outputWritten = true;
                        }
                        if (__tmp36_outputWritten) __out.AppendLine(true);
                        if (__tmp36_outputWritten)
                        {
                            __out.AppendLine(false); //654:69
                        }
                    }
                    __out.Append("	/// </ul>"); //656:1
                    __out.AppendLine(false); //656:11
                }
                if ((from __loop35_var1 in __Enumerate((cls).GetEnumerator()) //658:15
                from prop in __Enumerate((__loop35_var1.Properties).GetEnumerator()) //658:20
                where prop.Kind == MetaPropertyKind.Readonly //658:36
                select new { __loop35_var1 = __loop35_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //658:3
                {
                    __out.Append("	/// Initializes the following readonly properties:"); //659:1
                    __out.AppendLine(false); //659:52
                    __out.Append("	/// <ul>"); //660:1
                    __out.AppendLine(false); //660:10
                    var __loop36_results = 
                        (from __loop36_var1 in __Enumerate((cls).GetEnumerator()) //661:8
                        from prop in __Enumerate((__loop36_var1.Properties).GetEnumerator()) //661:13
                        where prop.Kind == MetaPropertyKind.Readonly //661:29
                        select new { __loop36_var1 = __loop36_var1, prop = prop}
                        ).ToList(); //661:3
                    for (int __loop36_iteration = 0; __loop36_iteration < __loop36_results.Count; ++__loop36_iteration)
                    {
                        var __tmp40 = __loop36_results[__loop36_iteration];
                        var __loop36_var1 = __tmp40.__loop36_var1;
                        var prop = __tmp40.prop;
                        bool __tmp42_outputWritten = false;
                        string __tmp43_line = "	///     <li>"; //662:1
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
                        string __tmp45_line = "</li>"; //662:38
                        if (!string.IsNullOrEmpty(__tmp45_line))
                        {
                            __out.Append(__tmp45_line);
                            __tmp42_outputWritten = true;
                        }
                        if (__tmp42_outputWritten) __out.AppendLine(true);
                        if (__tmp42_outputWritten)
                        {
                            __out.AppendLine(false); //662:43
                        }
                    }
                    __out.Append("	/// </ul>"); //664:1
                    __out.AppendLine(false); //664:11
                }
                if ((from __loop37_var1 in __Enumerate((cls).GetEnumerator()) //666:15
                from prop in __Enumerate((__loop37_var1.Properties).GetEnumerator()) //666:20
                where prop.Kind == MetaPropertyKind.Lazy //666:36
                select new { __loop37_var1 = __loop37_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //666:3
                {
                    __out.Append("	/// Initializes the following lazy properties:"); //667:1
                    __out.AppendLine(false); //667:48
                    __out.Append("	/// <ul>"); //668:1
                    __out.AppendLine(false); //668:10
                    var __loop38_results = 
                        (from __loop38_var1 in __Enumerate((cls).GetEnumerator()) //669:8
                        from prop in __Enumerate((__loop38_var1.Properties).GetEnumerator()) //669:13
                        where prop.Kind == MetaPropertyKind.Lazy //669:29
                        select new { __loop38_var1 = __loop38_var1, prop = prop}
                        ).ToList(); //669:3
                    for (int __loop38_iteration = 0; __loop38_iteration < __loop38_results.Count; ++__loop38_iteration)
                    {
                        var __tmp46 = __loop38_results[__loop38_iteration];
                        var __loop38_var1 = __tmp46.__loop38_var1;
                        var prop = __tmp46.prop;
                        bool __tmp48_outputWritten = false;
                        string __tmp49_line = "	///     <li>"; //670:1
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
                        string __tmp51_line = "</li>"; //670:38
                        if (!string.IsNullOrEmpty(__tmp51_line))
                        {
                            __out.Append(__tmp51_line);
                            __tmp48_outputWritten = true;
                        }
                        if (__tmp48_outputWritten) __out.AppendLine(true);
                        if (__tmp48_outputWritten)
                        {
                            __out.AppendLine(false); //670:43
                        }
                    }
                    __out.Append("	/// </ul>"); //672:1
                    __out.AppendLine(false); //672:11
                }
                if ((from __loop39_var1 in __Enumerate((cls).GetEnumerator()) //674:15
                from prop in __Enumerate((__loop39_var1.Properties).GetEnumerator()) //674:20
                where prop.Kind == MetaPropertyKind.Derived //674:36
                select new { __loop39_var1 = __loop39_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //674:3
                {
                    __out.Append("	/// Initializes the following derived properties:"); //675:1
                    __out.AppendLine(false); //675:51
                    __out.Append("	/// <ul>"); //676:1
                    __out.AppendLine(false); //676:10
                    var __loop40_results = 
                        (from __loop40_var1 in __Enumerate((cls).GetEnumerator()) //677:8
                        from prop in __Enumerate((__loop40_var1.Properties).GetEnumerator()) //677:13
                        where prop.Kind == MetaPropertyKind.Derived //677:29
                        select new { __loop40_var1 = __loop40_var1, prop = prop}
                        ).ToList(); //677:3
                    for (int __loop40_iteration = 0; __loop40_iteration < __loop40_results.Count; ++__loop40_iteration)
                    {
                        var __tmp52 = __loop40_results[__loop40_iteration];
                        var __loop40_var1 = __tmp52.__loop40_var1;
                        var prop = __tmp52.prop;
                        bool __tmp54_outputWritten = false;
                        string __tmp55_line = "	///     <li>"; //678:1
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
                        string __tmp57_line = "</li>"; //678:38
                        if (!string.IsNullOrEmpty(__tmp57_line))
                        {
                            __out.Append(__tmp57_line);
                            __tmp54_outputWritten = true;
                        }
                        if (__tmp54_outputWritten) __out.AppendLine(true);
                        if (__tmp54_outputWritten)
                        {
                            __out.AppendLine(false); //678:43
                        }
                    }
                    __out.Append("	/// </ul>"); //680:1
                    __out.AppendLine(false); //680:11
                }
                bool __tmp59_outputWritten = false;
                string __tmp60_line = "	public virtual void "; //682:1
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
                string __tmp62_line = "("; //682:66
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
                string __tmp64_line = " _this)"; //682:109
                if (!string.IsNullOrEmpty(__tmp64_line))
                {
                    __out.Append(__tmp64_line);
                    __tmp59_outputWritten = true;
                }
                if (__tmp59_outputWritten) __out.AppendLine(true);
                if (__tmp59_outputWritten)
                {
                    __out.AppendLine(false); //682:116
                }
                __out.Append("	{"); //683:1
                __out.AppendLine(false); //683:3
                bool __tmp66_outputWritten = false;
                string __tmp67_line = "		this.Call"; //684:1
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
                string __tmp69_line = "SuperConstructors(_this);"; //684:56
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Append(__tmp69_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //684:81
                }
                var __loop41_results = 
                    (from __loop41_var1 in __Enumerate((cls).GetEnumerator()) //685:9
                    from prop in __Enumerate((__loop41_var1.GetAllFinalProperties()).GetEnumerator()) //685:14
                    select new { __loop41_var1 = __loop41_var1, prop = prop}
                    ).ToList(); //685:4
                for (int __loop41_iteration = 0; __loop41_iteration < __loop41_results.Count; ++__loop41_iteration)
                {
                    var __tmp70 = __loop41_results[__loop41_iteration];
                    var __loop41_var1 = __tmp70.__loop41_var1;
                    var prop = __tmp70.prop;
                    if (metaMetaModel && cls.Name == "MetaConstant" && prop.Name == "Value") //686:5
                    {
                    }
                    else if (prop.DefaultValue != null) //687:5
                    {
                        if (!(prop.Type is MetaCollectionType)) //688:6
                        {
                            bool __tmp72_outputWritten = false;
                            string __tmp73_line = "		_this.Set"; //689:1
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
                            string __tmp75_line = "Lazy(() => "; //689:58
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
                            string __tmp77_line = ");"; //689:88
                            if (!string.IsNullOrEmpty(__tmp77_line))
                            {
                                __out.Append(__tmp77_line);
                                __tmp72_outputWritten = true;
                            }
                            if (__tmp72_outputWritten) __out.AppendLine(true);
                            if (__tmp72_outputWritten)
                            {
                                __out.AppendLine(false); //689:90
                            }
                        }
                        else //690:6
                        {
                            __out.Append("		// ERROR: default value for collection"); //691:1
                            __out.AppendLine(false); //691:41
                            bool __tmp79_outputWritten = false;
                            string __tmp80_line = "		// _this."; //692:1
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
                            string __tmp82_line = " = "; //692:58
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
                            string __tmp84_line = ";"; //692:80
                            if (!string.IsNullOrEmpty(__tmp84_line))
                            {
                                __out.Append(__tmp84_line);
                                __tmp79_outputWritten = true;
                            }
                            if (__tmp79_outputWritten) __out.AppendLine(true);
                            if (__tmp79_outputWritten)
                            {
                                __out.AppendLine(false); //692:81
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Lazy || prop.Kind == MetaPropertyKind.Derived) //694:5
                    {
                        if (!(prop.Type is MetaCollectionType)) //695:6
                        {
                            bool __tmp86_outputWritten = false;
                            string __tmp87_line = "		_this.Set"; //696:1
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
                            string __tmp89_line = "Lazy(this."; //696:58
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
                            string __tmp91_line = "_ComputeProperty_"; //696:119
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
                            string __tmp93_line = ");"; //696:160
                            if (!string.IsNullOrEmpty(__tmp93_line))
                            {
                                __out.Append(__tmp93_line);
                                __tmp86_outputWritten = true;
                            }
                            if (__tmp86_outputWritten) __out.AppendLine(true);
                            if (__tmp86_outputWritten)
                            {
                                __out.AppendLine(false); //696:162
                            }
                        }
                        else //697:6
                        {
                            bool __tmp95_outputWritten = false;
                            string __tmp96_line = "		_this."; //698:1
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
                            string __tmp98_line = ".AddRangeLazy<"; //698:55
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
                            string __tmp100_line = ">(this."; //698:118
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
                            string __tmp102_line = "_ComputeProperty_"; //698:176
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
                            string __tmp104_line = ");"; //698:217
                            if (!string.IsNullOrEmpty(__tmp104_line))
                            {
                                __out.Append(__tmp104_line);
                                __tmp95_outputWritten = true;
                            }
                            if (__tmp95_outputWritten) __out.AppendLine(true);
                            if (__tmp95_outputWritten)
                            {
                                __out.AppendLine(false); //698:219
                            }
                        }
                    }
                    else if (prop.Kind == MetaPropertyKind.Readonly) //700:5
                    {
                        if (!(prop.Type is MetaCollectionType)) //701:6
                        {
                            bool __tmp106_outputWritten = false;
                            string __tmp107_line = "		_this.Set"; //702:1
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
                            string __tmp109_line = "Lazy(this."; //702:58
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
                            string __tmp111_line = "_ComputeProperty_"; //702:119
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
                            string __tmp113_line = ");"; //702:160
                            if (!string.IsNullOrEmpty(__tmp113_line))
                            {
                                __out.Append(__tmp113_line);
                                __tmp106_outputWritten = true;
                            }
                            if (__tmp106_outputWritten) __out.AppendLine(true);
                            if (__tmp106_outputWritten)
                            {
                                __out.AppendLine(false); //702:162
                            }
                        }
                        else //703:6
                        {
                            bool __tmp115_outputWritten = false;
                            string __tmp116_line = "		_this."; //704:1
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
                            string __tmp118_line = ".AddRangeLazy("; //704:55
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
                            string __tmp120_line = "_ComputeProperty_"; //704:120
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
                            string __tmp122_line = ");"; //704:161
                            if (!string.IsNullOrEmpty(__tmp122_line))
                            {
                                __out.Append(__tmp122_line);
                                __tmp115_outputWritten = true;
                            }
                            if (__tmp115_outputWritten) __out.AppendLine(true);
                            if (__tmp115_outputWritten)
                            {
                                __out.AppendLine(false); //704:163
                            }
                        }
                    }
                }
                __out.Append("	}"); //708:1
                __out.AppendLine(false); //708:3
                __out.AppendLine(true); //709:1
                __out.Append("	/// <summary>"); //710:1
                __out.AppendLine(false); //710:15
                bool __tmp124_outputWritten = false;
                string __tmp125_line = "	/// Calls the super constructors of "; //711:1
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
                    __out.AppendLine(false); //711:82
                }
                __out.Append("	/// </summary>"); //712:1
                __out.AppendLine(false); //712:16
                bool __tmp128_outputWritten = false;
                string __tmp129_line = "	protected virtual void Call"; //713:1
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
                string __tmp131_line = "SuperConstructors("; //713:73
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
                string __tmp133_line = " _this)"; //713:133
                if (!string.IsNullOrEmpty(__tmp133_line))
                {
                    __out.Append(__tmp133_line);
                    __tmp128_outputWritten = true;
                }
                if (__tmp128_outputWritten) __out.AppendLine(true);
                if (__tmp128_outputWritten)
                {
                    __out.AppendLine(false); //713:140
                }
                __out.Append("	{"); //714:1
                __out.AppendLine(false); //714:3
                var __loop42_results = 
                    (from __loop42_var1 in __Enumerate((cls).GetEnumerator()) //715:8
                    from sup in __Enumerate((__loop42_var1.GetAllSuperClasses(false)).GetEnumerator()) //715:13
                    select new { __loop42_var1 = __loop42_var1, sup = sup}
                    ).ToList(); //715:3
                for (int __loop42_iteration = 0; __loop42_iteration < __loop42_results.Count; ++__loop42_iteration)
                {
                    var __tmp134 = __loop42_results[__loop42_iteration];
                    var __loop42_var1 = __tmp134.__loop42_var1;
                    var sup = __tmp134.sup;
                    if (model.Namespace.Declarations.Contains(sup)) //716:4
                    {
                        bool __tmp136_outputWritten = false;
                        string __tmp137_line = "		this."; //717:1
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
                        string __tmp139_line = "(_this);"; //717:52
                        if (!string.IsNullOrEmpty(__tmp139_line))
                        {
                            __out.Append(__tmp139_line);
                            __tmp136_outputWritten = true;
                        }
                        if (__tmp136_outputWritten) __out.AppendLine(true);
                        if (__tmp136_outputWritten)
                        {
                            __out.AppendLine(false); //717:60
                        }
                    }
                    else //718:4
                    {
                        bool __tmp141_outputWritten = false;
                        string __tmp140Prefix = "		"; //719:1
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
                        string __tmp143_line = "."; //719:69
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
                        string __tmp145_line = "(_this);"; //719:114
                        if (!string.IsNullOrEmpty(__tmp145_line))
                        {
                            __out.Append(__tmp145_line);
                            __tmp141_outputWritten = true;
                        }
                        if (__tmp141_outputWritten) __out.AppendLine(true);
                        if (__tmp141_outputWritten)
                        {
                            __out.AppendLine(false); //719:122
                        }
                    }
                }
                __out.Append("	}"); //722:1
                __out.AppendLine(false); //722:3
                __out.AppendLine(true); //723:2
                var __loop43_results = 
                    (from __loop43_var1 in __Enumerate((cls).GetEnumerator()) //724:8
                    from prop in __Enumerate((__loop43_var1.Properties).GetEnumerator()) //724:13
                    where prop.Kind == MetaPropertyKind.Readonly || prop.Kind == MetaPropertyKind.Lazy || prop.Kind == MetaPropertyKind.Derived //724:29
                    select new { __loop43_var1 = __loop43_var1, prop = prop}
                    ).ToList(); //724:3
                for (int __loop43_iteration = 0; __loop43_iteration < __loop43_results.Count; ++__loop43_iteration)
                {
                    var __tmp146 = __loop43_results[__loop43_iteration];
                    var __loop43_var1 = __tmp146.__loop43_var1;
                    var prop = __tmp146.prop;
                    if (metaMetaModel && cls.Name == "MetaConstant" && prop.Name == "Value") //725:4
                    {
                    }
                    else //726:4
                    {
                        __out.Append("	/// <summary>"); //727:1
                        __out.AppendLine(false); //727:15
                        bool __tmp148_outputWritten = false;
                        string __tmp149_line = "	/// Computes the value of the property: "; //728:1
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
                        string __tmp151_line = "."; //728:86
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
                            __out.AppendLine(false); //728:111
                        }
                        __out.Append("	/// </summary	"); //729:1
                        __out.AppendLine(false); //729:16
                        bool __tmp154_outputWritten = false;
                        string __tmp155_line = "	public abstract "; //730:1
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
                        string __tmp157_line = " "; //730:81
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
                        string __tmp159_line = "_ComputeProperty_"; //730:126
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
                        string __tmp161_line = "("; //730:167
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
                        string __tmp163_line = " _this);"; //730:210
                        if (!string.IsNullOrEmpty(__tmp163_line))
                        {
                            __out.Append(__tmp163_line);
                            __tmp154_outputWritten = true;
                        }
                        if (__tmp154_outputWritten) __out.AppendLine(true);
                        if (__tmp154_outputWritten)
                        {
                            __out.AppendLine(false); //730:218
                        }
                    }
                }
                __out.AppendLine(true); //733:2
                bool __tmp165_outputWritten = false;
                string __tmp166_line = "	public virtual void "; //734:1
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
                string __tmp168_line = "_MValidate("; //734:66
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
                string __tmp170_line = " _this, global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)"; //734:119
                if (!string.IsNullOrEmpty(__tmp170_line))
                {
                    __out.Append(__tmp170_line);
                    __tmp165_outputWritten = true;
                }
                if (__tmp165_outputWritten) __out.AppendLine(true);
                if (__tmp165_outputWritten)
                {
                    __out.AppendLine(false); //734:256
                }
                __out.Append("	{"); //735:1
                __out.AppendLine(false); //735:3
                __out.Append("	}"); //736:1
                __out.AppendLine(false); //736:3
                __out.AppendLine(true); //737:2
                var __loop44_results = 
                    (from __loop44_var1 in __Enumerate((cls).GetEnumerator()) //738:8
                    from op in __Enumerate((__loop44_var1.Operations).GetEnumerator()) //738:13
                    select new { __loop44_var1 = __loop44_var1, op = op}
                    ).ToList(); //738:3
                for (int __loop44_iteration = 0; __loop44_iteration < __loop44_results.Count; ++__loop44_iteration)
                {
                    var __tmp171 = __loop44_results[__loop44_iteration];
                    var __loop44_var1 = __tmp171.__loop44_var1;
                    var op = __tmp171.op;
                    if (!op.IsBuilder) //739:4
                    {
                        __out.AppendLine(true); //740:2
                        __out.Append("	/// <summary>"); //741:1
                        __out.AppendLine(false); //741:15
                        bool __tmp173_outputWritten = false;
                        string __tmp174_line = "	/// Implements the operation: "; //742:1
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
                        string __tmp176_line = "."; //742:76
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
                        string __tmp178_line = "()"; //742:86
                        if (!string.IsNullOrEmpty(__tmp178_line))
                        {
                            __out.Append(__tmp178_line);
                            __tmp173_outputWritten = true;
                        }
                        if (__tmp173_outputWritten) __out.AppendLine(true);
                        if (__tmp173_outputWritten)
                        {
                            __out.AppendLine(false); //742:88
                        }
                        __out.Append("	/// </summary>"); //743:1
                        __out.AppendLine(false); //743:16
                        bool __tmp180_outputWritten = false;
                        string __tmp181_line = "	public virtual "; //744:1
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
                        string __tmp183_line = " "; //744:86
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
                        string __tmp185_line = "_"; //744:131
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
                        string __tmp187_line = "("; //744:141
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
                        string __tmp189_line = ")"; //744:207
                        if (!string.IsNullOrEmpty(__tmp189_line))
                        {
                            __out.Append(__tmp189_line);
                            __tmp180_outputWritten = true;
                        }
                        if (__tmp180_outputWritten) __out.AppendLine(true);
                        if (__tmp180_outputWritten)
                        {
                            __out.AppendLine(false); //744:208
                        }
                        __out.Append("	{"); //745:1
                        __out.AppendLine(false); //745:3
                        bool __tmp191_outputWritten = false;
                        string __tmp190Prefix = "		"; //746:1
                        StringBuilder __tmp192 = new StringBuilder();
                        __tmp192.Append(GetReturn(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation, true)));
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
                        string __tmp193_line = "this."; //746:83
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
                        string __tmp195_line = "_"; //746:137
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
                        string __tmp197_line = "("; //746:147
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
                        string __tmp199_line = ")"; //746:216
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
                        string __tmp201_line = ";"; //746:275
                        if (!string.IsNullOrEmpty(__tmp201_line))
                        {
                            __out.Append(__tmp201_line);
                            __tmp191_outputWritten = true;
                        }
                        if (__tmp191_outputWritten) __out.AppendLine(true);
                        if (__tmp191_outputWritten)
                        {
                            __out.AppendLine(false); //746:276
                        }
                        __out.Append("	}"); //747:1
                        __out.AppendLine(false); //747:3
                    }
                    __out.AppendLine(true); //749:2
                    __out.Append("	/// <summary>"); //750:1
                    __out.AppendLine(false); //750:15
                    bool __tmp203_outputWritten = false;
                    string __tmp204_line = "	/// Implements the operation: "; //751:1
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
                    string __tmp206_line = "."; //751:74
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
                    string __tmp208_line = "()"; //751:84
                    if (!string.IsNullOrEmpty(__tmp208_line))
                    {
                        __out.Append(__tmp208_line);
                        __tmp203_outputWritten = true;
                    }
                    if (__tmp203_outputWritten) __out.AppendLine(true);
                    if (__tmp203_outputWritten)
                    {
                        __out.AppendLine(false); //751:86
                    }
                    __out.Append("	/// </summary>"); //752:1
                    __out.AppendLine(false); //752:16
                    bool __tmp210_outputWritten = false;
                    string __tmp211_line = "	public abstract "; //753:1
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
                    string __tmp213_line = " "; //753:85
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
                    string __tmp215_line = "_"; //753:130
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
                    string __tmp217_line = "("; //753:140
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
                    string __tmp219_line = ");"; //753:204
                    if (!string.IsNullOrEmpty(__tmp219_line))
                    {
                        __out.Append(__tmp219_line);
                        __tmp210_outputWritten = true;
                    }
                    if (__tmp210_outputWritten) __out.AppendLine(true);
                    if (__tmp210_outputWritten)
                    {
                        __out.AppendLine(false); //753:206
                    }
                }
                __out.AppendLine(true); //755:2
            }
            var __loop45_results = 
                (from __loop45_var1 in __Enumerate((model).GetEnumerator()) //757:8
                from Namespace in __Enumerate((__loop45_var1.Namespace).GetEnumerator()) //757:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //757:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //757:40
                select new { __loop45_var1 = __loop45_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //757:3
            for (int __loop45_iteration = 0; __loop45_iteration < __loop45_results.Count; ++__loop45_iteration)
            {
                var __tmp220 = __loop45_results[__loop45_iteration];
                var __loop45_var1 = __tmp220.__loop45_var1;
                var Namespace = __tmp220.Namespace;
                var Declarations = __tmp220.Declarations;
                var enm = __tmp220.enm;
                var __loop46_results = 
                    (from __loop46_var1 in __Enumerate((enm).GetEnumerator()) //758:8
                    from op in __Enumerate((__loop46_var1.Operations).GetEnumerator()) //758:13
                    select new { __loop46_var1 = __loop46_var1, op = op}
                    ).ToList(); //758:3
                for (int __loop46_iteration = 0; __loop46_iteration < __loop46_results.Count; ++__loop46_iteration)
                {
                    var __tmp221 = __loop46_results[__loop46_iteration];
                    var __loop46_var1 = __tmp221.__loop46_var1;
                    var op = __tmp221.op;
                    __out.AppendLine(true); //759:2
                    __out.Append("	/// <summary>"); //760:1
                    __out.AppendLine(false); //760:15
                    bool __tmp223_outputWritten = false;
                    string __tmp224_line = "	/// Implements the operation: "; //761:1
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
                    string __tmp226_line = "."; //761:76
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
                        __out.AppendLine(false); //761:86
                    }
                    __out.Append("	/// </summary>"); //762:1
                    __out.AppendLine(false); //762:16
                    bool __tmp229_outputWritten = false;
                    string __tmp230_line = "	public abstract "; //763:1
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
                    string __tmp232_line = " "; //763:87
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
                    string __tmp234_line = "_"; //763:132
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
                    string __tmp236_line = "("; //763:142
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
                    string __tmp238_line = ");"; //763:208
                    if (!string.IsNullOrEmpty(__tmp238_line))
                    {
                        __out.Append(__tmp238_line);
                        __tmp229_outputWritten = true;
                    }
                    if (__tmp229_outputWritten) __out.AppendLine(true);
                    if (__tmp229_outputWritten)
                    {
                        __out.AppendLine(false); //763:210
                    }
                }
                __out.AppendLine(true); //765:2
            }
            __out.Append("}"); //767:1
            __out.AppendLine(false); //767:2
            return __out.ToString();
        }

        public string GenerateImplementation(MetaModel model) //770:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //771:2
            bool metaMetaModel = IsMetaMetaModel(model); //772:2
            __out.Append("/// <summary>"); //773:1
            __out.AppendLine(false); //773:14
            __out.Append("/// Class for implementing the behavior of the model elements."); //774:1
            __out.AppendLine(false); //774:63
            __out.Append("/// </summary>"); //775:1
            __out.AppendLine(false); //775:15
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //776:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(CSharpName(model, ModelKind.Implementation));
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
            string __tmp5_line = " : "; //776:60
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Append(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(CSharpName(model, ModelKind.ImplementationBase));
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
                __out.AppendLine(false); //776:111
            }
            __out.Append("{"); //777:1
            __out.AppendLine(false); //777:2
            var __loop47_results = 
                (from __loop47_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //778:8
                from cls in __Enumerate((__loop47_var1).GetEnumerator()).OfType<MetaClass>() //778:38
                select new { __loop47_var1 = __loop47_var1, cls = cls}
                ).ToList(); //778:3
            for (int __loop47_iteration = 0; __loop47_iteration < __loop47_results.Count; ++__loop47_iteration)
            {
                var __tmp7 = __loop47_results[__loop47_iteration];
                var __loop47_var1 = __tmp7.__loop47_var1;
                var cls = __tmp7.cls;
                var __loop48_results = 
                    (from __loop48_var1 in __Enumerate((cls).GetEnumerator()) //779:8
                    from prop in __Enumerate((__loop48_var1.Properties).GetEnumerator()) //779:13
                    where prop.Kind == MetaPropertyKind.Readonly || prop.Kind == MetaPropertyKind.Lazy || prop.Kind == MetaPropertyKind.Derived //779:29
                    select new { __loop48_var1 = __loop48_var1, prop = prop}
                    ).ToList(); //779:3
                for (int __loop48_iteration = 0; __loop48_iteration < __loop48_results.Count; ++__loop48_iteration)
                {
                    var __tmp8 = __loop48_results[__loop48_iteration];
                    var __loop48_var1 = __tmp8.__loop48_var1;
                    var prop = __tmp8.prop;
                    if (metaMetaModel && cls.Name == "MetaConstant" && prop.Name == "Value") //780:4
                    {
                    }
                    else //781:4
                    {
                        __out.AppendLine(true); //782:2
                        __out.Append("	/// <summary>"); //783:1
                        __out.AppendLine(false); //783:15
                        bool __tmp10_outputWritten = false;
                        string __tmp11_line = "	/// Computes the value of the property: "; //784:1
                        if (!string.IsNullOrEmpty(__tmp11_line))
                        {
                            __out.Append(__tmp11_line);
                            __tmp10_outputWritten = true;
                        }
                        StringBuilder __tmp12 = new StringBuilder();
                        __tmp12.Append(CSharpName(cls, model, ClassKind.Immutable));
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
                        string __tmp13_line = "."; //784:86
                        if (!string.IsNullOrEmpty(__tmp13_line))
                        {
                            __out.Append(__tmp13_line);
                            __tmp10_outputWritten = true;
                        }
                        StringBuilder __tmp14 = new StringBuilder();
                        __tmp14.Append(CSharpName(prop, model));
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
                                    __tmp10_outputWritten = true;
                                }
                                if (!__tmp14_last || __tmp10_outputWritten) __out.AppendLine(true);
                            }
                        }
                        if (__tmp10_outputWritten)
                        {
                            __out.AppendLine(false); //784:111
                        }
                        __out.Append("	/// </summary	"); //785:1
                        __out.AppendLine(false); //785:16
                        bool __tmp16_outputWritten = false;
                        string __tmp17_line = "	public override "; //786:1
                        if (!string.IsNullOrEmpty(__tmp17_line))
                        {
                            __out.Append(__tmp17_line);
                            __tmp16_outputWritten = true;
                        }
                        StringBuilder __tmp18 = new StringBuilder();
                        __tmp18.Append(CSharpName(prop.Type, model, ClassKind.BuilderOperation, true));
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
                        string __tmp19_line = " "; //786:81
                        if (!string.IsNullOrEmpty(__tmp19_line))
                        {
                            __out.Append(__tmp19_line);
                            __tmp16_outputWritten = true;
                        }
                        StringBuilder __tmp20 = new StringBuilder();
                        __tmp20.Append(CSharpName(cls, model, ClassKind.Immutable));
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
                        string __tmp21_line = "_ComputeProperty_"; //786:126
                        if (!string.IsNullOrEmpty(__tmp21_line))
                        {
                            __out.Append(__tmp21_line);
                            __tmp16_outputWritten = true;
                        }
                        StringBuilder __tmp22 = new StringBuilder();
                        __tmp22.Append(CSharpName(prop, model));
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
                                    __tmp16_outputWritten = true;
                                }
                                if (!__tmp22_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp23_line = "("; //786:167
                        if (!string.IsNullOrEmpty(__tmp23_line))
                        {
                            __out.Append(__tmp23_line);
                            __tmp16_outputWritten = true;
                        }
                        StringBuilder __tmp24 = new StringBuilder();
                        __tmp24.Append(CSharpName(cls, model, ClassKind.Builder));
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
                                    __tmp16_outputWritten = true;
                                }
                                if (!__tmp24_last) __out.AppendLine(true);
                            }
                        }
                        string __tmp25_line = " _this)"; //786:210
                        if (!string.IsNullOrEmpty(__tmp25_line))
                        {
                            __out.Append(__tmp25_line);
                            __tmp16_outputWritten = true;
                        }
                        if (__tmp16_outputWritten) __out.AppendLine(true);
                        if (__tmp16_outputWritten)
                        {
                            __out.AppendLine(false); //786:217
                        }
                        __out.Append("	{"); //787:1
                        __out.AppendLine(false); //787:3
                        bool __tmp27_outputWritten = false;
                        string __tmp26Prefix = "		"; //788:1
                        StringBuilder __tmp28 = new StringBuilder();
                        __tmp28.Append(GetDefaultReturn(CSharpName(prop.Type, model, ClassKind.BuilderOperation, true)));
                        using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
                        {
                            bool __tmp28_last = __tmp28Reader.EndOfStream;
                            while(!__tmp28_last)
                            {
                                string __tmp28_line = __tmp28Reader.ReadLine();
                                __tmp28_last = __tmp28Reader.EndOfStream;
                                if (!string.IsNullOrEmpty(__tmp26Prefix))
                                {
                                    __out.Append(__tmp26Prefix);
                                    __tmp27_outputWritten = true;
                                }
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
                            __out.AppendLine(false); //788:84
                        }
                        __out.Append("	}"); //789:1
                        __out.AppendLine(false); //789:3
                    }
                }
                var __loop49_results = 
                    (from __loop49_var1 in __Enumerate((cls).GetEnumerator()) //792:8
                    from op in __Enumerate((__loop49_var1.Operations).GetEnumerator()) //792:13
                    select new { __loop49_var1 = __loop49_var1, op = op}
                    ).ToList(); //792:3
                for (int __loop49_iteration = 0; __loop49_iteration < __loop49_results.Count; ++__loop49_iteration)
                {
                    var __tmp29 = __loop49_results[__loop49_iteration];
                    var __loop49_var1 = __tmp29.__loop49_var1;
                    var op = __tmp29.op;
                    __out.AppendLine(true); //793:2
                    __out.Append("	/// <summary>"); //794:1
                    __out.AppendLine(false); //794:15
                    bool __tmp31_outputWritten = false;
                    string __tmp32_line = "	/// Implements the operation: "; //795:1
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
                    string __tmp34_line = "."; //795:74
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Append(__tmp34_line);
                        __tmp31_outputWritten = true;
                    }
                    StringBuilder __tmp35 = new StringBuilder();
                    __tmp35.Append(op.Name);
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
                    string __tmp36_line = "()"; //795:84
                    if (!string.IsNullOrEmpty(__tmp36_line))
                    {
                        __out.Append(__tmp36_line);
                        __tmp31_outputWritten = true;
                    }
                    if (__tmp31_outputWritten) __out.AppendLine(true);
                    if (__tmp31_outputWritten)
                    {
                        __out.AppendLine(false); //795:86
                    }
                    __out.Append("	/// </summary>"); //796:1
                    __out.AppendLine(false); //796:16
                    bool __tmp38_outputWritten = false;
                    string __tmp39_line = "	public override "; //797:1
                    if (!string.IsNullOrEmpty(__tmp39_line))
                    {
                        __out.Append(__tmp39_line);
                        __tmp38_outputWritten = true;
                    }
                    StringBuilder __tmp40 = new StringBuilder();
                    __tmp40.Append(CSharpName(op.ReturnType, model, ClassKind.BuilderOperation, true));
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
                    string __tmp41_line = " "; //797:85
                    if (!string.IsNullOrEmpty(__tmp41_line))
                    {
                        __out.Append(__tmp41_line);
                        __tmp38_outputWritten = true;
                    }
                    StringBuilder __tmp42 = new StringBuilder();
                    __tmp42.Append(CSharpName(cls, model, ClassKind.Immutable));
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
                    string __tmp43_line = "_"; //797:130
                    if (!string.IsNullOrEmpty(__tmp43_line))
                    {
                        __out.Append(__tmp43_line);
                        __tmp38_outputWritten = true;
                    }
                    StringBuilder __tmp44 = new StringBuilder();
                    __tmp44.Append(op.Name);
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
                                __tmp38_outputWritten = true;
                            }
                            if (!__tmp44_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp45_line = "("; //797:140
                    if (!string.IsNullOrEmpty(__tmp45_line))
                    {
                        __out.Append(__tmp45_line);
                        __tmp38_outputWritten = true;
                    }
                    StringBuilder __tmp46 = new StringBuilder();
                    __tmp46.Append(GetImplParameters(model, cls, op, ClassKind.BuilderOperation));
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
                                __tmp38_outputWritten = true;
                            }
                            if (!__tmp46_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp47_line = ")"; //797:204
                    if (!string.IsNullOrEmpty(__tmp47_line))
                    {
                        __out.Append(__tmp47_line);
                        __tmp38_outputWritten = true;
                    }
                    if (__tmp38_outputWritten) __out.AppendLine(true);
                    if (__tmp38_outputWritten)
                    {
                        __out.AppendLine(false); //797:205
                    }
                    __out.Append("	{"); //798:1
                    __out.AppendLine(false); //798:3
                    bool __tmp49_outputWritten = false;
                    string __tmp48Prefix = "		"; //799:1
                    StringBuilder __tmp50 = new StringBuilder();
                    __tmp50.Append(GetDefaultReturn(CSharpName(op.ReturnType, model, ClassKind.BuilderOperation, true)));
                    using(StreamReader __tmp50Reader = new StreamReader(this.__ToStream(__tmp50.ToString())))
                    {
                        bool __tmp50_last = __tmp50Reader.EndOfStream;
                        while(!__tmp50_last)
                        {
                            string __tmp50_line = __tmp50Reader.ReadLine();
                            __tmp50_last = __tmp50Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp48Prefix))
                            {
                                __out.Append(__tmp48Prefix);
                                __tmp49_outputWritten = true;
                            }
                            if ((__tmp50_last && !string.IsNullOrEmpty(__tmp50_line)) || (!__tmp50_last && __tmp50_line != null))
                            {
                                __out.Append(__tmp50_line);
                                __tmp49_outputWritten = true;
                            }
                            if (!__tmp50_last || __tmp49_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp49_outputWritten)
                    {
                        __out.AppendLine(false); //799:88
                    }
                    __out.Append("	}"); //800:1
                    __out.AppendLine(false); //800:3
                }
                __out.AppendLine(true); //802:2
            }
            var __loop50_results = 
                (from __loop50_var1 in __Enumerate((model).GetEnumerator()) //804:8
                from Namespace in __Enumerate((__loop50_var1.Namespace).GetEnumerator()) //804:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //804:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //804:40
                select new { __loop50_var1 = __loop50_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //804:3
            for (int __loop50_iteration = 0; __loop50_iteration < __loop50_results.Count; ++__loop50_iteration)
            {
                var __tmp51 = __loop50_results[__loop50_iteration];
                var __loop50_var1 = __tmp51.__loop50_var1;
                var Namespace = __tmp51.Namespace;
                var Declarations = __tmp51.Declarations;
                var enm = __tmp51.enm;
                var __loop51_results = 
                    (from __loop51_var1 in __Enumerate((enm).GetEnumerator()) //805:8
                    from op in __Enumerate((__loop51_var1.Operations).GetEnumerator()) //805:13
                    select new { __loop51_var1 = __loop51_var1, op = op}
                    ).ToList(); //805:3
                for (int __loop51_iteration = 0; __loop51_iteration < __loop51_results.Count; ++__loop51_iteration)
                {
                    var __tmp52 = __loop51_results[__loop51_iteration];
                    var __loop51_var1 = __tmp52.__loop51_var1;
                    var op = __tmp52.op;
                    __out.AppendLine(true); //806:2
                    __out.Append("	/// <summary>"); //807:1
                    __out.AppendLine(false); //807:15
                    bool __tmp54_outputWritten = false;
                    string __tmp55_line = "	/// Implements the operation: "; //808:1
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Append(__tmp55_line);
                        __tmp54_outputWritten = true;
                    }
                    StringBuilder __tmp56 = new StringBuilder();
                    __tmp56.Append(CSharpName(enm, model, ClassKind.Immutable));
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
                    string __tmp57_line = "."; //808:76
                    if (!string.IsNullOrEmpty(__tmp57_line))
                    {
                        __out.Append(__tmp57_line);
                        __tmp54_outputWritten = true;
                    }
                    StringBuilder __tmp58 = new StringBuilder();
                    __tmp58.Append(op.Name);
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
                            if (!__tmp58_last || __tmp54_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp54_outputWritten)
                    {
                        __out.AppendLine(false); //808:86
                    }
                    __out.Append("	/// </summary>"); //809:1
                    __out.AppendLine(false); //809:16
                    bool __tmp60_outputWritten = false;
                    string __tmp61_line = "	public override "; //810:1
                    if (!string.IsNullOrEmpty(__tmp61_line))
                    {
                        __out.Append(__tmp61_line);
                        __tmp60_outputWritten = true;
                    }
                    StringBuilder __tmp62 = new StringBuilder();
                    __tmp62.Append(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation, true));
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
                    string __tmp63_line = " "; //810:87
                    if (!string.IsNullOrEmpty(__tmp63_line))
                    {
                        __out.Append(__tmp63_line);
                        __tmp60_outputWritten = true;
                    }
                    StringBuilder __tmp64 = new StringBuilder();
                    __tmp64.Append(CSharpName(enm, model, ClassKind.Immutable));
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
                    string __tmp65_line = "_"; //810:132
                    if (!string.IsNullOrEmpty(__tmp65_line))
                    {
                        __out.Append(__tmp65_line);
                        __tmp60_outputWritten = true;
                    }
                    StringBuilder __tmp66 = new StringBuilder();
                    __tmp66.Append(op.Name);
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
                    string __tmp67_line = "("; //810:142
                    if (!string.IsNullOrEmpty(__tmp67_line))
                    {
                        __out.Append(__tmp67_line);
                        __tmp60_outputWritten = true;
                    }
                    StringBuilder __tmp68 = new StringBuilder();
                    __tmp68.Append(GetImplParameters(model, enm, op, ClassKind.ImmutableOperation));
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
                    string __tmp69_line = ")"; //810:208
                    if (!string.IsNullOrEmpty(__tmp69_line))
                    {
                        __out.Append(__tmp69_line);
                        __tmp60_outputWritten = true;
                    }
                    if (__tmp60_outputWritten) __out.AppendLine(true);
                    if (__tmp60_outputWritten)
                    {
                        __out.AppendLine(false); //810:209
                    }
                    __out.Append("	{"); //811:1
                    __out.AppendLine(false); //811:3
                    bool __tmp71_outputWritten = false;
                    string __tmp70Prefix = "		"; //812:1
                    StringBuilder __tmp72 = new StringBuilder();
                    __tmp72.Append(GetDefaultReturn(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation, true)));
                    using(StreamReader __tmp72Reader = new StreamReader(this.__ToStream(__tmp72.ToString())))
                    {
                        bool __tmp72_last = __tmp72Reader.EndOfStream;
                        while(!__tmp72_last)
                        {
                            string __tmp72_line = __tmp72Reader.ReadLine();
                            __tmp72_last = __tmp72Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp70Prefix))
                            {
                                __out.Append(__tmp70Prefix);
                                __tmp71_outputWritten = true;
                            }
                            if ((__tmp72_last && !string.IsNullOrEmpty(__tmp72_line)) || (!__tmp72_last && __tmp72_line != null))
                            {
                                __out.Append(__tmp72_line);
                                __tmp71_outputWritten = true;
                            }
                            if (!__tmp72_last || __tmp71_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp71_outputWritten)
                    {
                        __out.AppendLine(false); //812:90
                    }
                    __out.Append("	}"); //813:1
                    __out.AppendLine(false); //813:3
                }
                __out.AppendLine(true); //815:2
            }
            __out.Append("}"); //817:1
            __out.AppendLine(false); //817:2
            return __out.ToString();
        }

        public string GetImplParameters(MetaModel model, MetaClass cls, MetaOperation op, ClassKind kind) //820:1
        {
            string result = CSharpName(cls, model, kind) + " _this"; //821:2
            string delim = ", "; //822:2
            var __loop52_results = 
                (from __loop52_var1 in __Enumerate((op).GetEnumerator()) //823:7
                from param in __Enumerate((__loop52_var1.Parameters).GetEnumerator()) //823:11
                select new { __loop52_var1 = __loop52_var1, param = param}
                ).ToList(); //823:2
            for (int __loop52_iteration = 0; __loop52_iteration < __loop52_results.Count; ++__loop52_iteration)
            {
                var __tmp1 = __loop52_results[__loop52_iteration];
                var __loop52_var1 = __tmp1.__loop52_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, kind, true) + " " + param.Name; //824:3
            }
            return result; //826:2
        }

        public string GetImplParameters(MetaModel model, MetaEnum enm, MetaOperation op, ClassKind kind) //829:1
        {
            string result = CSharpName(enm, model, kind) + " _this"; //830:2
            string delim = ", "; //831:2
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((op).GetEnumerator()) //832:7
                from param in __Enumerate((__loop53_var1.Parameters).GetEnumerator()) //832:11
                select new { __loop53_var1 = __loop53_var1, param = param}
                ).ToList(); //832:2
            for (int __loop53_iteration = 0; __loop53_iteration < __loop53_results.Count; ++__loop53_iteration)
            {
                var __tmp1 = __loop53_results[__loop53_iteration];
                var __loop53_var1 = __tmp1.__loop53_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, kind, true) + " " + param.Name; //833:3
            }
            return result; //835:2
        }

        public string GenerateEnum(MetaModel model, MetaEnum enm) //839:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //840:1
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
                __out.AppendLine(false); //841:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public enum "; //842:1
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
                __out.AppendLine(false); //842:36
            }
            __out.Append("{"); //843:1
            __out.AppendLine(false); //843:2
            var __loop54_results = 
                (from __loop54_var1 in __Enumerate((enm).GetEnumerator()) //844:8
                from value in __Enumerate((__loop54_var1.EnumLiterals).GetEnumerator()) //844:13
                select new { __loop54_var1 = __loop54_var1, value = value}
                ).ToList(); //844:3
            for (int __loop54_iteration = 0; __loop54_iteration < __loop54_results.Count; ++__loop54_iteration)
            {
                string delim; //844:31
                if (__loop54_iteration+1 < __loop54_results.Count) delim = ",";
                else delim = string.Empty;
                var __tmp8 = __loop54_results[__loop54_iteration];
                var __loop54_var1 = __tmp8.__loop54_var1;
                var value = __tmp8.value;
                bool __tmp10_outputWritten = false;
                string __tmp9Prefix = "	"; //845:1
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
                    __out.AppendLine(false); //845:32
                }
                bool __tmp13_outputWritten = false;
                string __tmp12Prefix = "	"; //846:1
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
                    __out.AppendLine(false); //846:21
                }
            }
            __out.Append("}"); //848:1
            __out.AppendLine(false); //848:2
            __out.AppendLine(true); //849:1
            bool __tmp17_outputWritten = false;
            string __tmp18_line = "public static class "; //850:1
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
            string __tmp20_line = "Extensions"; //850:31
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp17_outputWritten = true;
            }
            if (__tmp17_outputWritten) __out.AppendLine(true);
            if (__tmp17_outputWritten)
            {
                __out.AppendLine(false); //850:41
            }
            __out.Append("{"); //851:1
            __out.AppendLine(false); //851:2
            var __loop55_results = 
                (from __loop55_var1 in __Enumerate((enm).GetEnumerator()) //852:8
                from op in __Enumerate((__loop55_var1.Operations).GetEnumerator()) //852:13
                select new { __loop55_var1 = __loop55_var1, op = op}
                ).ToList(); //852:3
            for (int __loop55_iteration = 0; __loop55_iteration < __loop55_results.Count; ++__loop55_iteration)
            {
                var __tmp21 = __loop55_results[__loop55_iteration];
                var __loop55_var1 = __tmp21.__loop55_var1;
                var op = __tmp21.op;
                bool __tmp23_outputWritten = false;
                string __tmp24_line = "	public static "; //853:1
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
                string __tmp26_line = " "; //853:79
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
                string __tmp28_line = "("; //853:89
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
                string __tmp30_line = ")"; //853:159
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Append(__tmp30_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //853:160
                }
                __out.Append("	{"); //854:1
                __out.AppendLine(false); //854:3
                bool __tmp32_outputWritten = false;
                string __tmp31Prefix = "		"; //855:1
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(GetReturn(CSharpName(op.ReturnType, model, ClassKind.ImmutableOperation)));
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
                string __tmp35_line = ".Implementation."; //855:129
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
                string __tmp37_line = "_"; //855:193
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
                string __tmp39_line = "("; //855:203
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
                string __tmp41_line = ");"; //855:276
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Append(__tmp41_line);
                    __tmp32_outputWritten = true;
                }
                if (__tmp32_outputWritten) __out.AppendLine(true);
                if (__tmp32_outputWritten)
                {
                    __out.AppendLine(false); //855:278
                }
                __out.Append("	}"); //856:1
                __out.AppendLine(false); //856:3
            }
            __out.Append("}"); //858:1
            __out.AppendLine(false); //858:2
            return __out.ToString();
        }

        public string GetEnumImplParameters(MetaModel model, MetaEnum enm, MetaOperation op, ClassKind kind) //861:1
        {
            string result = "this " + CSharpName(enm, model, kind) + " _this"; //862:2
            string delim = ", "; //863:2
            var __loop56_results = 
                (from __loop56_var1 in __Enumerate((op).GetEnumerator()) //864:7
                from param in __Enumerate((__loop56_var1.Parameters).GetEnumerator()) //864:11
                select new { __loop56_var1 = __loop56_var1, param = param}
                ).ToList(); //864:2
            for (int __loop56_iteration = 0; __loop56_iteration < __loop56_results.Count; ++__loop56_iteration)
            {
                var __tmp1 = __loop56_results[__loop56_iteration];
                var __loop56_var1 = __tmp1.__loop56_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, kind) + " " + param.Name; //865:3
            }
            return result; //867:2
        }

        public string GetEnumImplCallParameterNames(MetaModel model, MetaOperation op, ClassKind kind) //870:1
        {
            string result = "_this"; //871:2
            string delim = ", "; //872:2
            var __loop57_results = 
                (from __loop57_var1 in __Enumerate((op).GetEnumerator()) //873:7
                from param in __Enumerate((__loop57_var1.Parameters).GetEnumerator()) //873:11
                select new { __loop57_var1 = __loop57_var1, param = param}
                ).ToList(); //873:2
            for (int __loop57_iteration = 0; __loop57_iteration < __loop57_results.Count; ++__loop57_iteration)
            {
                var __tmp1 = __loop57_results[__loop57_iteration];
                var __loop57_var1 = __tmp1.__loop57_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //874:3
            }
            return result; //876:2
        }

        public string GetClassParameters(MetaModel model, MetaClass cls, MetaOperation op, ClassKind kind) //879:1
        {
            string result = ""; //880:2
            var __loop58_results = 
                (from __loop58_var1 in __Enumerate((op).GetEnumerator()) //881:7
                from param in __Enumerate((__loop58_var1.Parameters).GetEnumerator()) //881:11
                select new { __loop58_var1 = __loop58_var1, param = param}
                ).ToList(); //881:2
            for (int __loop58_iteration = 0; __loop58_iteration < __loop58_results.Count; ++__loop58_iteration)
            {
                string delim; //881:27
                if (__loop58_iteration+1 < __loop58_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop58_results[__loop58_iteration];
                var __loop58_var1 = __tmp1.__loop58_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, kind, true) + " " + param.Name + delim; //882:3
            }
            return result; //884:2
        }

        public string GetClassImplCallParameterNames(MetaModel model, MetaOperation op, ClassKind kind) //887:1
        {
            string result = "this"; //888:2
            string delim = ", "; //889:2
            var __loop59_results = 
                (from __loop59_var1 in __Enumerate((op).GetEnumerator()) //890:7
                from param in __Enumerate((__loop59_var1.Parameters).GetEnumerator()) //890:11
                select new { __loop59_var1 = __loop59_var1, param = param}
                ).ToList(); //890:2
            for (int __loop59_iteration = 0; __loop59_iteration < __loop59_results.Count; ++__loop59_iteration)
            {
                var __tmp1 = __loop59_results[__loop59_iteration];
                var __loop59_var1 = __tmp1.__loop59_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //891:3
            }
            return result; //893:2
        }

        public string GetReturn(string returnType) //896:1
        {
            if (returnType == "void") //897:5
            {
                return ""; //898:3
            }
            else //899:2
            {
                return "return "; //900:3
            }
        }

        public string GetDefaultReturn(string returnType) //904:1
        {
            if (returnType == "void") //905:5
            {
                return ""; //906:3
            }
            else //907:2
            {
                return "return default(" + returnType + ");"; //908:3
            }
        }

        public string GenerateClass(MetaModel model, MetaClass cls) //912:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //913:1
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
                __out.AppendLine(false); //914:37
            }
            __out.AppendLine(true); //915:1
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
                __out.AppendLine(false); //916:35
            }
            return __out.ToString();
        }

        public string GenerateClassInternal(MetaModel model, MetaClass cls) //919:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //920:1
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
                __out.AppendLine(false); //921:30
            }
            __out.AppendLine(true); //922:1
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
                __out.AppendLine(false); //923:41
            }
            __out.AppendLine(true); //924:1
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
                __out.AppendLine(false); //925:39
            }
            return __out.ToString();
        }

        public string GenerateIdClass(MetaModel model, MetaClass cls) //928:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //929:1
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
            string __tmp5_line = " : "; //929:53
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
            string __tmp7_line = ".ObjectId"; //929:75
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //929:84
            }
            __out.Append("{"); //930:1
            __out.AppendLine(false); //930:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public override "; //931:1
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
            string __tmp12_line = ".ModelObjectDescriptor Descriptor { get { return "; //931:37
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
            string __tmp14_line = ".MDescriptor; } }"; //931:136
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //931:153
            }
            __out.AppendLine(true); //932:1
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	public override "; //933:1
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
            string __tmp19_line = ".ImmutableObjectBase CreateImmutable("; //933:37
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
            string __tmp21_line = ".ImmutableModel model)"; //933:93
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //933:115
            }
            __out.Append("	{"); //934:1
            __out.AppendLine(false); //934:3
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "		return new "; //935:1
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
            string __tmp26_line = "(this, model);"; //935:62
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //935:76
            }
            __out.Append("	}"); //936:1
            __out.AppendLine(false); //936:3
            __out.AppendLine(true); //937:1
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "	public override "; //938:1
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
            string __tmp31_line = ".MutableObjectBase CreateMutable("; //938:37
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
            string __tmp33_line = ".MutableModel model, bool creating)"; //938:89
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Append(__tmp33_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //938:124
            }
            __out.Append("	{"); //939:1
            __out.AppendLine(false); //939:3
            bool __tmp35_outputWritten = false;
            string __tmp36_line = "		return new "; //940:1
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
            string __tmp38_line = "(this, model, creating);"; //940:60
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Append(__tmp38_line);
                __tmp35_outputWritten = true;
            }
            if (__tmp35_outputWritten) __out.AppendLine(true);
            if (__tmp35_outputWritten)
            {
                __out.AppendLine(false); //940:84
            }
            __out.Append("	}"); //941:1
            __out.AppendLine(false); //941:3
            __out.Append("}"); //942:1
            __out.AppendLine(false); //942:2
            return __out.ToString();
        }

        public string GenerateImmutableClass(MetaModel model, MetaClass cls) //945:1
        {
            StringBuilder __out = new StringBuilder();
            bool metaMetaModel = IsMetaMetaModel(model); //946:2
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
                __out.AppendLine(false); //947:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //948:1
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
                __out.AppendLine(false); //948:183
            }
            __out.Append("{"); //949:1
            __out.AppendLine(false); //949:2
            if (metaMetaModel && cls.Name == "MetaModel") //950:3
            {
                __out.Append("	/// <summary>"); //951:1
                __out.AppendLine(false); //951:15
                __out.Append("	/// The name of the metamodel."); //952:1
                __out.AppendLine(false); //952:32
                __out.Append("	/// </summary>"); //953:1
                __out.AppendLine(false); //953:16
                __out.Append("	new string Name { get; }"); //954:1
                __out.AppendLine(false); //954:26
            }
            var __loop60_results = 
                (from __loop60_var1 in __Enumerate((cls).GetEnumerator()) //956:8
                from prop in __Enumerate((__loop60_var1.Properties).GetEnumerator()) //956:13
                select new { __loop60_var1 = __loop60_var1, prop = prop}
                ).ToList(); //956:3
            for (int __loop60_iteration = 0; __loop60_iteration < __loop60_results.Count; ++__loop60_iteration)
            {
                var __tmp10 = __loop60_results[__loop60_iteration];
                var __loop60_var1 = __tmp10.__loop60_var1;
                var prop = __tmp10.prop;
                bool __tmp12_outputWritten = false;
                string __tmp11Prefix = "	"; //957:1
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
                    __out.AppendLine(false); //957:42
                }
            }
            __out.AppendLine(true); //959:1
            var __loop61_results = 
                (from __loop61_var1 in __Enumerate((cls).GetEnumerator()) //960:8
                from op in __Enumerate((__loop61_var1.Operations).GetEnumerator()) //960:13
                where !op.IsBuilder //960:27
                select new { __loop61_var1 = __loop61_var1, op = op}
                ).ToList(); //960:3
            for (int __loop61_iteration = 0; __loop61_iteration < __loop61_results.Count; ++__loop61_iteration)
            {
                var __tmp14 = __loop61_results[__loop61_iteration];
                var __loop61_var1 = __tmp14.__loop61_var1;
                var op = __tmp14.op;
                bool __tmp16_outputWritten = false;
                string __tmp15Prefix = "	"; //961:1
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
                    __out.AppendLine(false); //961:41
                }
            }
            __out.AppendLine(true); //963:1
            __out.Append("	/// <summary>"); //964:1
            __out.AppendLine(false); //964:15
            bool __tmp19_outputWritten = false;
            string __tmp20_line = "	/// Convert the <see cref=\""; //965:1
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
            string __tmp22_line = "\"/> object to a builder <see cref=\""; //965:73
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
            string __tmp24_line = "\"/> object."; //965:150
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp19_outputWritten = true;
            }
            if (__tmp19_outputWritten) __out.AppendLine(true);
            if (__tmp19_outputWritten)
            {
                __out.AppendLine(false); //965:161
            }
            __out.Append("	/// </summary>"); //966:1
            __out.AppendLine(false); //966:16
            bool __tmp26_outputWritten = false;
            string __tmp27_line = "	new "; //967:1
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
            string __tmp29_line = " ToMutable();"; //967:54
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Append(__tmp29_line);
                __tmp26_outputWritten = true;
            }
            if (__tmp26_outputWritten) __out.AppendLine(true);
            if (__tmp26_outputWritten)
            {
                __out.AppendLine(false); //967:67
            }
            __out.Append("	/// <summary>"); //968:1
            __out.AppendLine(false); //968:15
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "	/// Convert the <see cref=\""; //969:1
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
            string __tmp34_line = "\"/> object to a builder <see cref=\""; //969:73
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
            string __tmp36_line = "\"/> object"; //969:150
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Append(__tmp36_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //969:160
            }
            __out.Append("	/// by taking the builder version from the given model."); //970:1
            __out.AppendLine(false); //970:57
            __out.Append("	/// </summary>"); //971:1
            __out.AppendLine(false); //971:16
            __out.Append("	/// <param name=\"model\">The mutable model from which the return value is taken from.</param>"); //972:1
            __out.AppendLine(false); //972:94
            bool __tmp38_outputWritten = false;
            string __tmp39_line = "	new "; //973:1
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
            string __tmp41_line = " ToMutable("; //973:54
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
            string __tmp43_line = ".MutableModel model);"; //973:84
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Append(__tmp43_line);
                __tmp38_outputWritten = true;
            }
            if (__tmp38_outputWritten) __out.AppendLine(true);
            if (__tmp38_outputWritten)
            {
                __out.AppendLine(false); //973:105
            }
            __out.Append("}"); //974:1
            __out.AppendLine(false); //974:2
            return __out.ToString();
        }

        public string GenerateImmutableProperty(MetaModel model, MetaProperty prop) //977:1
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
                __out.AppendLine(false); //978:30
            }
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name) || (IsMetaMetaModel(model) && prop.Class.Name == "MetaModel")) //979:2
            {
                __out.Append("new "); //980:1
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
            string __tmp7_line = " "; //982:57
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
            string __tmp9_line = " { get; }"; //982:106
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //982:115
            }
            return __out.ToString();
        }

        public string GenerateImmutableOperation(MetaModel model, MetaOperation op) //985:1
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
                __out.AppendLine(false); //986:28
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
            string __tmp7_line = " "; //987:70
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
            string __tmp9_line = "("; //987:80
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
            string __tmp11_line = ");"; //987:155
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Append(__tmp11_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //987:157
            }
            return __out.ToString();
        }

        public string GetImmutableOperationParameters(MetaModel model, MetaOperation op, ClassKind kind) //990:1
        {
            string result = ""; //991:2
            var __loop62_results = 
                (from __loop62_var1 in __Enumerate((op).GetEnumerator()) //992:7
                from param in __Enumerate((__loop62_var1.Parameters).GetEnumerator()) //992:11
                select new { __loop62_var1 = __loop62_var1, param = param}
                ).ToList(); //992:2
            for (int __loop62_iteration = 0; __loop62_iteration < __loop62_results.Count; ++__loop62_iteration)
            {
                string delim; //992:27
                if (__loop62_iteration+1 < __loop62_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop62_results[__loop62_iteration];
                var __loop62_var1 = __tmp1.__loop62_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, kind, true) + " " + param.Name + delim; //993:3
            }
            return result; //995:2
        }

        public string GetImmutableAncestors(MetaModel model, MetaClass cls) //998:1
        {
            string result = ""; //999:2
            var __loop63_results = 
                (from __loop63_var1 in __Enumerate((cls).GetEnumerator()) //1000:7
                from super in __Enumerate((__loop63_var1.SuperClasses).GetEnumerator()) //1000:12
                select new { __loop63_var1 = __loop63_var1, super = super}
                ).ToList(); //1000:2
            for (int __loop63_iteration = 0; __loop63_iteration < __loop63_results.Count; ++__loop63_iteration)
            {
                string delim; //1000:30
                if (__loop63_iteration+1 < __loop63_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop63_results[__loop63_iteration];
                var __loop63_var1 = __tmp1.__loop63_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Immutable, true) + delim; //1001:3
            }
            if (result == "") //1003:2
            {
                result = Properties.CoreNs + ".ImmutableObject"; //1004:3
            }
            result = " : " + result; //1006:2
            return result; //1007:2
        }

        public string GenerateBuilderClass(MetaModel model, MetaClass cls) //1010:1
        {
            StringBuilder __out = new StringBuilder();
            bool metaMetaModel = IsMetaMetaModel(model); //1011:2
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
                __out.AppendLine(false); //1012:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //1013:1
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
                __out.AppendLine(false); //1013:179
            }
            __out.Append("{"); //1014:1
            __out.AppendLine(false); //1014:2
            if (metaMetaModel && cls.Name == "MetaModel") //1015:3
            {
                __out.Append("	/// <summary>"); //1016:1
                __out.AppendLine(false); //1016:15
                __out.Append("	/// The name of the metamodel."); //1017:1
                __out.AppendLine(false); //1017:32
                __out.Append("	/// </summary>"); //1018:1
                __out.AppendLine(false); //1018:16
                __out.Append("	new string Name { get; set; }"); //1019:1
                __out.AppendLine(false); //1019:31
            }
            var __loop64_results = 
                (from __loop64_var1 in __Enumerate((cls).GetEnumerator()) //1021:8
                from prop in __Enumerate((__loop64_var1.Properties).GetEnumerator()) //1021:13
                select new { __loop64_var1 = __loop64_var1, prop = prop}
                ).ToList(); //1021:3
            for (int __loop64_iteration = 0; __loop64_iteration < __loop64_results.Count; ++__loop64_iteration)
            {
                var __tmp10 = __loop64_results[__loop64_iteration];
                var __loop64_var1 = __tmp10.__loop64_var1;
                var prop = __tmp10.prop;
                bool __tmp12_outputWritten = false;
                string __tmp11Prefix = "	"; //1022:1
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
                    __out.AppendLine(false); //1022:40
                }
            }
            __out.AppendLine(true); //1024:1
            var __loop65_results = 
                (from __loop65_var1 in __Enumerate((cls).GetEnumerator()) //1025:8
                from op in __Enumerate((__loop65_var1.Operations).GetEnumerator()) //1025:13
                select new { __loop65_var1 = __loop65_var1, op = op}
                ).ToList(); //1025:3
            for (int __loop65_iteration = 0; __loop65_iteration < __loop65_results.Count; ++__loop65_iteration)
            {
                var __tmp14 = __loop65_results[__loop65_iteration];
                var __loop65_var1 = __tmp14.__loop65_var1;
                var op = __tmp14.op;
                bool __tmp16_outputWritten = false;
                string __tmp15Prefix = "	"; //1026:1
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
                    __out.AppendLine(false); //1026:39
                }
            }
            __out.AppendLine(true); //1028:1
            __out.Append("	/// <summary>"); //1029:1
            __out.AppendLine(false); //1029:15
            bool __tmp19_outputWritten = false;
            string __tmp20_line = "	/// Convert the <see cref=\""; //1030:1
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
            string __tmp22_line = "\"/> object to an immutable <see cref=\""; //1030:71
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
            string __tmp24_line = "\"/> object."; //1030:153
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp19_outputWritten = true;
            }
            if (__tmp19_outputWritten) __out.AppendLine(true);
            if (__tmp19_outputWritten)
            {
                __out.AppendLine(false); //1030:164
            }
            __out.Append("	/// </summary>"); //1031:1
            __out.AppendLine(false); //1031:16
            bool __tmp26_outputWritten = false;
            string __tmp27_line = "	new "; //1032:1
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
            string __tmp29_line = " ToImmutable();"; //1032:56
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Append(__tmp29_line);
                __tmp26_outputWritten = true;
            }
            if (__tmp26_outputWritten) __out.AppendLine(true);
            if (__tmp26_outputWritten)
            {
                __out.AppendLine(false); //1032:71
            }
            __out.Append("	/// <summary>"); //1033:1
            __out.AppendLine(false); //1033:15
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "	/// Convert the <see cref=\""; //1034:1
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
            string __tmp34_line = "\"/> object to an immutable <see cref=\""; //1034:71
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
            string __tmp36_line = "\"/> object"; //1034:153
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Append(__tmp36_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //1034:163
            }
            __out.Append("	/// by taking the immutable version from the given model."); //1035:1
            __out.AppendLine(false); //1035:59
            __out.Append("	/// </summary>"); //1036:1
            __out.AppendLine(false); //1036:16
            __out.Append("	/// <param name=\"model\">The immutable model from which the return value is taken from.</param>"); //1037:1
            __out.AppendLine(false); //1037:96
            bool __tmp38_outputWritten = false;
            string __tmp39_line = "	new "; //1038:1
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
            string __tmp41_line = " ToImmutable("; //1038:56
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
            string __tmp43_line = ".ImmutableModel model);"; //1038:88
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Append(__tmp43_line);
                __tmp38_outputWritten = true;
            }
            if (__tmp38_outputWritten) __out.AppendLine(true);
            if (__tmp38_outputWritten)
            {
                __out.AppendLine(false); //1038:111
            }
            __out.Append("}"); //1039:1
            __out.AppendLine(false); //1039:2
            return __out.ToString();
        }

        public string GenerateBuilderProperty(MetaModel model, MetaProperty prop) //1042:1
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
                __out.AppendLine(false); //1043:30
            }
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name) || (IsMetaMetaModel(model) && prop.Class.Name == "MetaModel")) //1044:3
            {
                __out.Append("new "); //1045:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal) && !(prop.Type is MetaCollectionType)) //1047:3
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
                string __tmp7_line = " "; //1048:55
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
                string __tmp9_line = " { get; set; }"; //1048:102
                if (!string.IsNullOrEmpty(__tmp9_line))
                {
                    __out.Append(__tmp9_line);
                    __tmp5_outputWritten = true;
                }
                if (__tmp5_outputWritten) __out.AppendLine(true);
                if (__tmp5_outputWritten)
                {
                    __out.AppendLine(false); //1048:116
                }
            }
            else //1049:3
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
                string __tmp13_line = " "; //1050:55
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
                string __tmp15_line = " { get; }"; //1050:102
                if (!string.IsNullOrEmpty(__tmp15_line))
                {
                    __out.Append(__tmp15_line);
                    __tmp11_outputWritten = true;
                }
                if (__tmp11_outputWritten) __out.AppendLine(true);
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //1050:111
                }
            }
            if (!(prop.Type is MetaCollectionType)) //1052:3
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
                    __out.AppendLine(false); //1053:30
                }
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //1054:4
                {
                    __out.Append("new "); //1055:1
                }
                bool __tmp20_outputWritten = false;
                string __tmp21_line = "void Set"; //1057:1
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
                string __tmp23_line = "Lazy(global::System.Func<"; //1057:55
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
                string __tmp25_line = "> lazy);"; //1057:134
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Append(__tmp25_line);
                    __tmp20_outputWritten = true;
                }
                if (__tmp20_outputWritten) __out.AppendLine(true);
                if (__tmp20_outputWritten)
                {
                    __out.AppendLine(false); //1057:142
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
                    __out.AppendLine(false); //1058:30
                }
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //1059:4
                {
                    __out.Append("new "); //1060:1
                }
                bool __tmp30_outputWritten = false;
                string __tmp31_line = "void Set"; //1062:1
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
                string __tmp33_line = "Lazy(global::System.Func<"; //1062:55
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
                string __tmp35_line = ", "; //1062:129
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
                string __tmp37_line = "> lazy);"; //1062:185
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp30_outputWritten = true;
                }
                if (__tmp30_outputWritten) __out.AppendLine(true);
                if (__tmp30_outputWritten)
                {
                    __out.AppendLine(false); //1062:193
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
                    __out.AppendLine(false); //1063:30
                }
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //1064:4
                {
                    __out.Append("new "); //1065:1
                }
                bool __tmp42_outputWritten = false;
                string __tmp43_line = "void Set"; //1067:1
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
                string __tmp45_line = "Lazy(global::System.Func<"; //1067:55
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
                string __tmp47_line = ", "; //1067:131
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
                string __tmp49_line = "> immutableLazy, global::System.Func<"; //1067:189
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
                string __tmp51_line = ", "; //1067:275
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
                string __tmp53_line = "> mutableLazy);"; //1067:331
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp42_outputWritten = true;
                }
                if (__tmp42_outputWritten) __out.AppendLine(true);
                if (__tmp42_outputWritten)
                {
                    __out.AppendLine(false); //1067:346
                }
            }
            return __out.ToString();
        }

        public string GenerateBuilderOperation(MetaModel model, MetaOperation op) //1071:1
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
                __out.AppendLine(false); //1072:28
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
            string __tmp7_line = " "; //1073:68
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
            string __tmp9_line = "("; //1073:78
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
            string __tmp11_line = ");"; //1073:149
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Append(__tmp11_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //1073:151
            }
            return __out.ToString();
        }

        public string GetBuilderOperationParameters(MetaModel model, MetaOperation op, ClassKind kind) //1076:1
        {
            string result = ""; //1077:2
            var __loop66_results = 
                (from __loop66_var1 in __Enumerate((op).GetEnumerator()) //1078:7
                from param in __Enumerate((__loop66_var1.Parameters).GetEnumerator()) //1078:11
                select new { __loop66_var1 = __loop66_var1, param = param}
                ).ToList(); //1078:2
            for (int __loop66_iteration = 0; __loop66_iteration < __loop66_results.Count; ++__loop66_iteration)
            {
                string delim; //1078:27
                if (__loop66_iteration+1 < __loop66_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop66_results[__loop66_iteration];
                var __loop66_var1 = __tmp1.__loop66_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, kind, true) + " " + param.Name + delim; //1079:3
            }
            return result; //1081:2
        }

        public string GetBuilderAncestors(MetaModel model, MetaClass cls) //1084:1
        {
            string result = ""; //1085:2
            var __loop67_results = 
                (from __loop67_var1 in __Enumerate((cls).GetEnumerator()) //1086:7
                from super in __Enumerate((__loop67_var1.SuperClasses).GetEnumerator()) //1086:12
                select new { __loop67_var1 = __loop67_var1, super = super}
                ).ToList(); //1086:2
            for (int __loop67_iteration = 0; __loop67_iteration < __loop67_results.Count; ++__loop67_iteration)
            {
                string delim; //1086:30
                if (__loop67_iteration+1 < __loop67_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop67_results[__loop67_iteration];
                var __loop67_var1 = __tmp1.__loop67_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Builder, true) + delim; //1087:3
            }
            if (result == "") //1089:2
            {
                result = Properties.CoreNs + ".MutableObject"; //1090:3
            }
            result = " : " + result; //1092:2
            return result; //1093:2
        }

        public string GenerateImmutableImplClass(MetaModel model, MetaClass cls) //1096:1
        {
            StringBuilder __out = new StringBuilder();
            bool metaMetaModel = IsMetaMetaModel(model); //1097:2
            string metaNs = metaMetaModel ? "" : Properties.MetaNs + "."; //1098:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //1099:1
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
            string __tmp5_line = " : "; //1099:64
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
            string __tmp7_line = ".ImmutableObjectBase, "; //1099:86
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
                __out.AppendLine(false); //1099:152
            }
            __out.Append("{"); //1100:1
            __out.AppendLine(false); //1100:2
            var __loop68_results = 
                (from __loop68_var1 in __Enumerate((cls).GetEnumerator()) //1101:8
                from prop in __Enumerate((__loop68_var1.GetAllProperties()).GetEnumerator()) //1101:13
                select new { __loop68_var1 = __loop68_var1, prop = prop}
                ).ToList(); //1101:3
            for (int __loop68_iteration = 0; __loop68_iteration < __loop68_results.Count; ++__loop68_iteration)
            {
                var __tmp9 = __loop68_results[__loop68_iteration];
                var __loop68_var1 = __tmp9.__loop68_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //1102:1
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
                    __out.AppendLine(false); //1102:44
                }
            }
            __out.AppendLine(true); //1104:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //1105:1
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
            string __tmp17_line = "("; //1105:59
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
            string __tmp19_line = ".ObjectId id, "; //1105:79
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
            string __tmp21_line = ".ImmutableModel model)"; //1105:112
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //1105:134
            }
            __out.Append("		: base(id, model)"); //1106:1
            __out.AppendLine(false); //1106:20
            __out.Append("	{"); //1107:1
            __out.AppendLine(false); //1107:3
            __out.Append("	}"); //1108:1
            __out.AppendLine(false); //1108:3
            __out.AppendLine(true); //1109:2
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	public override "; //1110:1
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
            string __tmp26_line = ".IMetaModel MMetaModel"; //1110:37
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //1110:59
            }
            __out.Append("	{"); //1111:1
            __out.AppendLine(false); //1111:3
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "		get { return "; //1112:1
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
            string __tmp31_line = ".MMetaModel; }"; //1112:77
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Append(__tmp31_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //1112:91
            }
            __out.Append("	}"); //1113:1
            __out.AppendLine(false); //1113:3
            __out.AppendLine(true); //1114:2
            bool __tmp33_outputWritten = false;
            string __tmp34_line = "	public override "; //1115:1
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
            string __tmp36_line = "MetaClass MMetaClass"; //1115:26
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Append(__tmp36_line);
                __tmp33_outputWritten = true;
            }
            if (__tmp33_outputWritten) __out.AppendLine(true);
            if (__tmp33_outputWritten)
            {
                __out.AppendLine(false); //1115:46
            }
            __out.Append("	{"); //1116:1
            __out.AppendLine(false); //1116:3
            bool __tmp38_outputWritten = false;
            string __tmp39_line = "		get { return "; //1117:1
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
            string __tmp41_line = "; }"; //1117:74
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Append(__tmp41_line);
                __tmp38_outputWritten = true;
            }
            if (__tmp38_outputWritten) __out.AppendLine(true);
            if (__tmp38_outputWritten)
            {
                __out.AppendLine(false); //1117:77
            }
            __out.Append("	}"); //1118:1
            __out.AppendLine(false); //1118:3
            __out.AppendLine(true); //1119:2
            bool __tmp43_outputWritten = false;
            string __tmp44_line = "	public new "; //1120:1
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
            string __tmp46_line = " ToMutable()"; //1120:55
            if (!string.IsNullOrEmpty(__tmp46_line))
            {
                __out.Append(__tmp46_line);
                __tmp43_outputWritten = true;
            }
            if (__tmp43_outputWritten) __out.AppendLine(true);
            if (__tmp43_outputWritten)
            {
                __out.AppendLine(false); //1120:67
            }
            __out.Append("	{"); //1121:1
            __out.AppendLine(false); //1121:3
            bool __tmp48_outputWritten = false;
            string __tmp49_line = "		return ("; //1122:1
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
            string __tmp51_line = ")base.ToMutable();"; //1122:53
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Append(__tmp51_line);
                __tmp48_outputWritten = true;
            }
            if (__tmp48_outputWritten) __out.AppendLine(true);
            if (__tmp48_outputWritten)
            {
                __out.AppendLine(false); //1122:71
            }
            __out.Append("	}"); //1123:1
            __out.AppendLine(false); //1123:3
            __out.AppendLine(true); //1124:2
            bool __tmp53_outputWritten = false;
            string __tmp54_line = "	public new "; //1125:1
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
            string __tmp56_line = " ToMutable("; //1125:55
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
            string __tmp58_line = ".MutableModel model)"; //1125:85
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Append(__tmp58_line);
                __tmp53_outputWritten = true;
            }
            if (__tmp53_outputWritten) __out.AppendLine(true);
            if (__tmp53_outputWritten)
            {
                __out.AppendLine(false); //1125:105
            }
            __out.Append("	{"); //1126:1
            __out.AppendLine(false); //1126:3
            bool __tmp60_outputWritten = false;
            string __tmp61_line = "		return ("; //1127:1
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
            string __tmp63_line = ")base.ToMutable(model);"; //1127:53
            if (!string.IsNullOrEmpty(__tmp63_line))
            {
                __out.Append(__tmp63_line);
                __tmp60_outputWritten = true;
            }
            if (__tmp60_outputWritten) __out.AppendLine(true);
            if (__tmp60_outputWritten)
            {
                __out.AppendLine(false); //1127:76
            }
            __out.Append("	}"); //1128:1
            __out.AppendLine(false); //1128:3
            var __loop69_results = 
                (from __loop69_var1 in __Enumerate((cls).GetEnumerator()) //1129:8
                from sup in __Enumerate((__loop69_var1.GetAllSuperClasses(false)).GetEnumerator()) //1129:13
                select new { __loop69_var1 = __loop69_var1, sup = sup}
                ).ToList(); //1129:3
            for (int __loop69_iteration = 0; __loop69_iteration < __loop69_results.Count; ++__loop69_iteration)
            {
                var __tmp64 = __loop69_results[__loop69_iteration];
                var __loop69_var1 = __tmp64.__loop69_var1;
                var sup = __tmp64.sup;
                __out.AppendLine(true); //1130:2
                bool __tmp66_outputWritten = false;
                string __tmp65Prefix = "	"; //1131:1
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
                string __tmp68_line = " "; //1131:50
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
                string __tmp70_line = ".ToMutable()"; //1131:101
                if (!string.IsNullOrEmpty(__tmp70_line))
                {
                    __out.Append(__tmp70_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //1131:113
                }
                __out.Append("	{"); //1132:1
                __out.AppendLine(false); //1132:3
                __out.Append("		return this.ToMutable();"); //1133:1
                __out.AppendLine(false); //1133:27
                __out.Append("	}"); //1134:1
                __out.AppendLine(false); //1134:3
                __out.AppendLine(true); //1135:2
                bool __tmp72_outputWritten = false;
                string __tmp71Prefix = "	"; //1136:1
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
                string __tmp74_line = " "; //1136:50
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
                string __tmp76_line = ".ToMutable("; //1136:101
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
                string __tmp78_line = ".MutableModel model)"; //1136:131
                if (!string.IsNullOrEmpty(__tmp78_line))
                {
                    __out.Append(__tmp78_line);
                    __tmp72_outputWritten = true;
                }
                if (__tmp72_outputWritten) __out.AppendLine(true);
                if (__tmp72_outputWritten)
                {
                    __out.AppendLine(false); //1136:151
                }
                __out.Append("	{"); //1137:1
                __out.AppendLine(false); //1137:3
                __out.Append("		return this.ToMutable(model);"); //1138:1
                __out.AppendLine(false); //1138:32
                __out.Append("	}"); //1139:1
                __out.AppendLine(false); //1139:3
            }
            var __loop70_results = 
                (from __loop70_var1 in __Enumerate((cls).GetEnumerator()) //1141:8
                from prop in __Enumerate((__loop70_var1.GetAllProperties()).GetEnumerator()) //1141:13
                select new { __loop70_var1 = __loop70_var1, prop = prop}
                ).ToList(); //1141:3
            for (int __loop70_iteration = 0; __loop70_iteration < __loop70_results.Count; ++__loop70_iteration)
            {
                var __tmp79 = __loop70_results[__loop70_iteration];
                var __loop70_var1 = __tmp79.__loop70_var1;
                var prop = __tmp79.prop;
                __out.AppendLine(true); //1142:2
                bool __tmp81_outputWritten = false;
                string __tmp80Prefix = "	"; //1143:1
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
                    __out.AppendLine(false); //1143:51
                }
            }
            var __loop71_results = 
                (from __loop71_var1 in __Enumerate((cls).GetEnumerator()) //1145:8
                from op in __Enumerate((__loop71_var1.GetAllOperations()).GetEnumerator()) //1145:13
                where !op.IsBuilder //1145:35
                select new { __loop71_var1 = __loop71_var1, op = op}
                ).ToList(); //1145:3
            for (int __loop71_iteration = 0; __loop71_iteration < __loop71_results.Count; ++__loop71_iteration)
            {
                var __tmp83 = __loop71_results[__loop71_iteration];
                var __loop71_var1 = __tmp83.__loop71_var1;
                var op = __tmp83.op;
                __out.AppendLine(true); //1146:2
                bool __tmp85_outputWritten = false;
                string __tmp84Prefix = "	"; //1147:1
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
                    __out.AppendLine(false); //1147:50
                }
            }
            if (metaMetaModel && cls.Name == "MetaModel") //1150:3
            {
                bool __tmp88_outputWritten = false;
                string __tmp87Prefix = "	"; //1151:1
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
                string __tmp90_line = ".ModelId "; //1151:21
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
                string __tmp92_line = ".IModel.Id => "; //1151:49
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
                string __tmp94_line = ".MModel.Id;"; //1151:110
                if (!string.IsNullOrEmpty(__tmp94_line))
                {
                    __out.Append(__tmp94_line);
                    __tmp88_outputWritten = true;
                }
                if (__tmp88_outputWritten) __out.AppendLine(true);
                if (__tmp88_outputWritten)
                {
                    __out.AppendLine(false); //1151:121
                }
                bool __tmp96_outputWritten = false;
                string __tmp97_line = "	string "; //1152:1
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
                string __tmp99_line = ".IModel.Name => this.Name;"; //1152:28
                if (!string.IsNullOrEmpty(__tmp99_line))
                {
                    __out.Append(__tmp99_line);
                    __tmp96_outputWritten = true;
                }
                if (__tmp96_outputWritten) __out.AppendLine(true);
                if (__tmp96_outputWritten)
                {
                    __out.AppendLine(false); //1152:54
                }
                bool __tmp101_outputWritten = false;
                string __tmp100Prefix = "	"; //1153:1
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
                string __tmp103_line = ".ModelVersion "; //1153:21
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
                string __tmp105_line = ".IModel.Version => "; //1153:54
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
                string __tmp107_line = ".MModel.Version;"; //1153:120
                if (!string.IsNullOrEmpty(__tmp107_line))
                {
                    __out.Append(__tmp107_line);
                    __tmp101_outputWritten = true;
                }
                if (__tmp101_outputWritten) __out.AppendLine(true);
                if (__tmp101_outputWritten)
                {
                    __out.AppendLine(false); //1153:136
                }
                bool __tmp109_outputWritten = false;
                string __tmp110_line = "	global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> "; //1154:1
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
                string __tmp112_line = ".IModel.Objects => "; //1154:108
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
                string __tmp114_line = ".MModel.Objects;"; //1154:174
                if (!string.IsNullOrEmpty(__tmp114_line))
                {
                    __out.Append(__tmp114_line);
                    __tmp109_outputWritten = true;
                }
                if (__tmp109_outputWritten) __out.AppendLine(true);
                if (__tmp109_outputWritten)
                {
                    __out.AppendLine(false); //1154:190
                }
                bool __tmp116_outputWritten = false;
                string __tmp117_line = "	string "; //1155:1
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
                string __tmp119_line = ".IMetaModel.Uri => this.Uri;"; //1155:28
                if (!string.IsNullOrEmpty(__tmp119_line))
                {
                    __out.Append(__tmp119_line);
                    __tmp116_outputWritten = true;
                }
                if (__tmp116_outputWritten) __out.AppendLine(true);
                if (__tmp116_outputWritten)
                {
                    __out.AppendLine(false); //1155:56
                }
                bool __tmp121_outputWritten = false;
                string __tmp122_line = "	string "; //1156:1
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
                string __tmp124_line = ".IMetaModel.Prefix => this.Prefix;"; //1156:28
                if (!string.IsNullOrEmpty(__tmp124_line))
                {
                    __out.Append(__tmp124_line);
                    __tmp121_outputWritten = true;
                }
                if (__tmp121_outputWritten) __out.AppendLine(true);
                if (__tmp121_outputWritten)
                {
                    __out.AppendLine(false); //1156:62
                }
                bool __tmp126_outputWritten = false;
                string __tmp125Prefix = "	"; //1157:1
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
                string __tmp128_line = ".IModelGroup "; //1157:21
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
                string __tmp130_line = ".IModel.ModelGroup => "; //1157:53
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
                string __tmp132_line = ".MModel.ModelGroup;"; //1157:122
                if (!string.IsNullOrEmpty(__tmp132_line))
                {
                    __out.Append(__tmp132_line);
                    __tmp126_outputWritten = true;
                }
                if (__tmp126_outputWritten) __out.AppendLine(true);
                if (__tmp126_outputWritten)
                {
                    __out.AppendLine(false); //1157:141
                }
                bool __tmp134_outputWritten = false;
                string __tmp135_line = "	string "; //1158:1
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
                string __tmp137_line = ".IMetaModel.Namespace => this.Namespace.FullName;"; //1158:28
                if (!string.IsNullOrEmpty(__tmp137_line))
                {
                    __out.Append(__tmp137_line);
                    __tmp134_outputWritten = true;
                }
                if (__tmp134_outputWritten) __out.AppendLine(true);
                if (__tmp134_outputWritten)
                {
                    __out.AppendLine(false); //1158:77
                }
                __out.AppendLine(true); //1159:1
                bool __tmp139_outputWritten = false;
                string __tmp140_line = "	public "; //1160:1
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
                string __tmp142_line = ".IModelFactory CreateFactory("; //1160:28
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
                string __tmp144_line = ".MutableModel model, "; //1160:76
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
                string __tmp146_line = ".ModelFactoryFlags flags = "; //1160:116
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
                string __tmp148_line = ".ModelFactoryFlags.None)"; //1160:162
                if (!string.IsNullOrEmpty(__tmp148_line))
                {
                    __out.Append(__tmp148_line);
                    __tmp139_outputWritten = true;
                }
                if (__tmp139_outputWritten) __out.AppendLine(true);
                if (__tmp139_outputWritten)
                {
                    __out.AppendLine(false); //1160:186
                }
                __out.Append("	{"); //1161:1
                __out.AppendLine(false); //1161:3
                bool __tmp150_outputWritten = false;
                string __tmp151_line = "		return new "; //1162:1
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
                string __tmp153_line = "(model, flags);"; //1162:51
                if (!string.IsNullOrEmpty(__tmp153_line))
                {
                    __out.Append(__tmp153_line);
                    __tmp150_outputWritten = true;
                }
                if (__tmp150_outputWritten) __out.AppendLine(true);
                if (__tmp150_outputWritten)
                {
                    __out.AppendLine(false); //1162:66
                }
                __out.Append("	}"); //1163:1
                __out.AppendLine(false); //1163:3
            }
            __out.Append("}"); //1165:1
            __out.AppendLine(false); //1165:2
            return __out.ToString();
        }

        public string GenerateImmutableField(MetaModel model, MetaClass cls, MetaProperty prop) //1168:1
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
                __out.AppendLine(false); //1169:54
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "private "; //1170:1
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
            string __tmp8_line = " "; //1170:65
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
            string __tmp10_line = ";"; //1170:90
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //1170:91
            }
            return __out.ToString();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //1173:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1174:1
            if (cls.GetAllFinalProperties().Contains(prop)) //1175:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //1176:1
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
                string __tmp5_line = " "; //1176:64
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
                    __out.AppendLine(false); //1176:76
                }
            }
            else //1177:2
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
                    __out.AppendLine(false); //1178:54
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
                string __tmp13_line = " "; //1179:57
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
                string __tmp15_line = "."; //1179:115
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
                    __out.AppendLine(false); //1179:127
                }
            }
            __out.Append("{"); //1181:1
            __out.AppendLine(false); //1181:2
            if (prop.Type is MetaCollectionType) //1182:6
            {
                if (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.Set || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet) //1183:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "    get { return this.GetSet<"; //1184:1
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
                    string __tmp21_line = ">("; //1184:118
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
                    string __tmp23_line = ", ref "; //1184:174
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
                    string __tmp25_line = "); }"; //1184:204
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Append(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //1184:208
                    }
                }
                else //1185:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "    get { return this.GetList<"; //1186:1
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
                    string __tmp30_line = ">("; //1186:119
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
                    string __tmp32_line = ", ref "; //1186:175
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
                    string __tmp34_line = "); }"; //1186:205
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Append(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //1186:209
                    }
                }
            }
            else if (IsReferenceType(prop.Type)) //1188:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "    get { return this.GetReference<"; //1189:1
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
                string __tmp39_line = ">("; //1189:92
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
                string __tmp41_line = ", ref "; //1189:148
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
                string __tmp43_line = "); }"; //1189:178
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Append(__tmp43_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //1189:182
                }
            }
            else //1190:3
            {
                bool __tmp45_outputWritten = false;
                string __tmp46_line = "    get { return this.GetValue<"; //1191:1
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
                string __tmp48_line = ">("; //1191:88
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
                string __tmp50_line = ", ref "; //1191:144
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
                string __tmp52_line = "); }"; //1191:174
                if (!string.IsNullOrEmpty(__tmp52_line))
                {
                    __out.Append(__tmp52_line);
                    __tmp45_outputWritten = true;
                }
                if (__tmp45_outputWritten) __out.AppendLine(true);
                if (__tmp45_outputWritten)
                {
                    __out.AppendLine(false); //1191:178
                }
            }
            __out.Append("}"); //1193:1
            __out.AppendLine(false); //1193:2
            return __out.ToString();
        }

        public string GenerateImmutableOperationImpl(MetaModel model, MetaClass cls, MetaOperation op) //1196:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1197:1
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
            string __tmp4_line = " "; //1198:70
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
            string __tmp6_line = "."; //1198:126
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
            string __tmp8_line = "("; //1198:136
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
            string __tmp10_line = ")"; //1198:208
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1198:209
            }
            __out.Append("{"); //1199:1
            __out.AppendLine(false); //1199:2
            var finalOp = GetFinalOperation(cls, op); //1200:2
            bool __tmp12_outputWritten = false;
            string __tmp11Prefix = "    "; //1201:1
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(GetReturn(CSharpName(finalOp.ReturnType, model, ClassKind.ImmutableOperation)));
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
            string __tmp15_line = ".Implementation."; //1201:136
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
            string __tmp17_line = "_"; //1201:206
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
            string __tmp19_line = "("; //1201:221
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
            string __tmp21_line = ");"; //1201:300
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp12_outputWritten = true;
            }
            if (__tmp12_outputWritten) __out.AppendLine(true);
            if (__tmp12_outputWritten)
            {
                __out.AppendLine(false); //1201:302
            }
            __out.Append("}"); //1202:1
            __out.AppendLine(false); //1202:2
            return __out.ToString();
        }

        public string GenerateBuilderImplClass(MetaModel model, MetaClass cls) //1205:1
        {
            StringBuilder __out = new StringBuilder();
            bool metaMetaModel = IsMetaMetaModel(model); //1206:2
            string metaNs = metaMetaModel ? "" : Properties.MetaNs + "."; //1207:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //1208:1
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
            string __tmp5_line = " : "; //1208:62
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
            string __tmp7_line = ".MutableObjectBase, "; //1208:84
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
                __out.AppendLine(false); //1208:146
            }
            __out.Append("{"); //1209:1
            __out.AppendLine(false); //1209:2
            var __loop72_results = 
                (from __loop72_var1 in __Enumerate((cls).GetEnumerator()) //1210:8
                from prop in __Enumerate((__loop72_var1.GetAllProperties()).GetEnumerator()) //1210:13
                where prop.Type is MetaCollectionType //1210:37
                select new { __loop72_var1 = __loop72_var1, prop = prop}
                ).ToList(); //1210:3
            for (int __loop72_iteration = 0; __loop72_iteration < __loop72_results.Count; ++__loop72_iteration)
            {
                var __tmp9 = __loop72_results[__loop72_iteration];
                var __loop72_var1 = __tmp9.__loop72_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //1211:1
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
                    __out.AppendLine(false); //1211:42
                }
            }
            __out.AppendLine(true); //1213:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //1214:1
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
            string __tmp17_line = "("; //1214:57
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
            string __tmp19_line = ".ObjectId id, "; //1214:77
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
            string __tmp21_line = ".MutableModel model, bool creating)"; //1214:110
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //1214:145
            }
            __out.Append("		: base(id, model, creating)"); //1215:1
            __out.AppendLine(false); //1215:30
            __out.Append("	{"); //1216:1
            __out.AppendLine(false); //1216:3
            __out.Append("	}"); //1217:1
            __out.AppendLine(false); //1217:3
            __out.AppendLine(true); //1218:2
            __out.Append("	protected override void MInit()"); //1219:1
            __out.AppendLine(false); //1219:33
            __out.Append("	{"); //1220:1
            __out.AppendLine(false); //1220:3
            bool __tmp23_outputWritten = false;
            string __tmp22Prefix = "		"; //1221:1
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
            string __tmp25_line = ".Implementation."; //1221:55
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
            string __tmp27_line = "(this);"; //1221:115
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Append(__tmp27_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //1221:122
            }
            __out.Append("	}"); //1222:1
            __out.AppendLine(false); //1222:3
            __out.AppendLine(true); //1223:2
            __out.Append("	public override void MValidate(global::Microsoft.CodeAnalysis.DiagnosticBag diagnostics, global::System.Threading.CancellationToken cancellationToken = default)"); //1224:1
            __out.AppendLine(false); //1224:162
            __out.Append("	{"); //1225:1
            __out.AppendLine(false); //1225:3
            bool __tmp29_outputWritten = false;
            string __tmp28Prefix = "		"; //1226:1
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
            string __tmp31_line = ".Implementation."; //1226:55
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
            string __tmp33_line = "_MValidate(this, diagnostics, cancellationToken);"; //1226:115
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Append(__tmp33_line);
                __tmp29_outputWritten = true;
            }
            if (__tmp29_outputWritten) __out.AppendLine(true);
            if (__tmp29_outputWritten)
            {
                __out.AppendLine(false); //1226:164
            }
            __out.Append("	}"); //1227:1
            __out.AppendLine(false); //1227:3
            __out.AppendLine(true); //1228:2
            bool __tmp35_outputWritten = false;
            string __tmp36_line = "	public override "; //1229:1
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
            string __tmp38_line = ".IMetaModel MMetaModel"; //1229:37
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Append(__tmp38_line);
                __tmp35_outputWritten = true;
            }
            if (__tmp35_outputWritten) __out.AppendLine(true);
            if (__tmp35_outputWritten)
            {
                __out.AppendLine(false); //1229:59
            }
            __out.Append("	{"); //1230:1
            __out.AppendLine(false); //1230:3
            bool __tmp40_outputWritten = false;
            string __tmp41_line = "		get { return "; //1231:1
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
            string __tmp43_line = ".MMetaModel; }"; //1231:77
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Append(__tmp43_line);
                __tmp40_outputWritten = true;
            }
            if (__tmp40_outputWritten) __out.AppendLine(true);
            if (__tmp40_outputWritten)
            {
                __out.AppendLine(false); //1231:91
            }
            __out.Append("	}"); //1232:1
            __out.AppendLine(false); //1232:3
            __out.AppendLine(true); //1233:2
            bool __tmp45_outputWritten = false;
            string __tmp46_line = "	public override "; //1234:1
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
            string __tmp48_line = "MetaClass MMetaClass"; //1234:26
            if (!string.IsNullOrEmpty(__tmp48_line))
            {
                __out.Append(__tmp48_line);
                __tmp45_outputWritten = true;
            }
            if (__tmp45_outputWritten) __out.AppendLine(true);
            if (__tmp45_outputWritten)
            {
                __out.AppendLine(false); //1234:46
            }
            __out.Append("	{"); //1235:1
            __out.AppendLine(false); //1235:3
            bool __tmp50_outputWritten = false;
            string __tmp51_line = "		get { return "; //1236:1
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
            string __tmp53_line = "; }"; //1236:74
            if (!string.IsNullOrEmpty(__tmp53_line))
            {
                __out.Append(__tmp53_line);
                __tmp50_outputWritten = true;
            }
            if (__tmp50_outputWritten) __out.AppendLine(true);
            if (__tmp50_outputWritten)
            {
                __out.AppendLine(false); //1236:77
            }
            __out.Append("	}"); //1237:1
            __out.AppendLine(false); //1237:3
            __out.AppendLine(true); //1238:2
            bool __tmp55_outputWritten = false;
            string __tmp56_line = "	public new "; //1239:1
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
            string __tmp58_line = " ToImmutable()"; //1239:57
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Append(__tmp58_line);
                __tmp55_outputWritten = true;
            }
            if (__tmp55_outputWritten) __out.AppendLine(true);
            if (__tmp55_outputWritten)
            {
                __out.AppendLine(false); //1239:71
            }
            __out.Append("	{"); //1240:1
            __out.AppendLine(false); //1240:3
            bool __tmp60_outputWritten = false;
            string __tmp61_line = "		return ("; //1241:1
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
            string __tmp63_line = ")base.ToImmutable();"; //1241:55
            if (!string.IsNullOrEmpty(__tmp63_line))
            {
                __out.Append(__tmp63_line);
                __tmp60_outputWritten = true;
            }
            if (__tmp60_outputWritten) __out.AppendLine(true);
            if (__tmp60_outputWritten)
            {
                __out.AppendLine(false); //1241:75
            }
            __out.Append("	}"); //1242:1
            __out.AppendLine(false); //1242:3
            __out.AppendLine(true); //1243:2
            bool __tmp65_outputWritten = false;
            string __tmp66_line = "	public new "; //1244:1
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
            string __tmp68_line = " ToImmutable("; //1244:57
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
            string __tmp70_line = ".ImmutableModel model)"; //1244:89
            if (!string.IsNullOrEmpty(__tmp70_line))
            {
                __out.Append(__tmp70_line);
                __tmp65_outputWritten = true;
            }
            if (__tmp65_outputWritten) __out.AppendLine(true);
            if (__tmp65_outputWritten)
            {
                __out.AppendLine(false); //1244:111
            }
            __out.Append("	{"); //1245:1
            __out.AppendLine(false); //1245:3
            bool __tmp72_outputWritten = false;
            string __tmp73_line = "		return ("; //1246:1
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
            string __tmp75_line = ")base.ToImmutable(model);"; //1246:55
            if (!string.IsNullOrEmpty(__tmp75_line))
            {
                __out.Append(__tmp75_line);
                __tmp72_outputWritten = true;
            }
            if (__tmp72_outputWritten) __out.AppendLine(true);
            if (__tmp72_outputWritten)
            {
                __out.AppendLine(false); //1246:80
            }
            __out.Append("	}"); //1247:1
            __out.AppendLine(false); //1247:3
            var __loop73_results = 
                (from __loop73_var1 in __Enumerate((cls).GetEnumerator()) //1248:8
                from sup in __Enumerate((__loop73_var1.GetAllSuperClasses(false)).GetEnumerator()) //1248:13
                select new { __loop73_var1 = __loop73_var1, sup = sup}
                ).ToList(); //1248:3
            for (int __loop73_iteration = 0; __loop73_iteration < __loop73_results.Count; ++__loop73_iteration)
            {
                var __tmp76 = __loop73_results[__loop73_iteration];
                var __loop73_var1 = __tmp76.__loop73_var1;
                var sup = __tmp76.sup;
                __out.AppendLine(true); //1249:2
                bool __tmp78_outputWritten = false;
                string __tmp77Prefix = "	"; //1250:1
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
                string __tmp80_line = " "; //1250:52
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
                string __tmp82_line = ".ToImmutable()"; //1250:101
                if (!string.IsNullOrEmpty(__tmp82_line))
                {
                    __out.Append(__tmp82_line);
                    __tmp78_outputWritten = true;
                }
                if (__tmp78_outputWritten) __out.AppendLine(true);
                if (__tmp78_outputWritten)
                {
                    __out.AppendLine(false); //1250:115
                }
                __out.Append("	{"); //1251:1
                __out.AppendLine(false); //1251:3
                __out.Append("		return this.ToImmutable();"); //1252:1
                __out.AppendLine(false); //1252:29
                __out.Append("	}"); //1253:1
                __out.AppendLine(false); //1253:3
                __out.AppendLine(true); //1254:2
                bool __tmp84_outputWritten = false;
                string __tmp83Prefix = "	"; //1255:1
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
                string __tmp86_line = " "; //1255:52
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
                string __tmp88_line = ".ToImmutable("; //1255:101
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
                string __tmp90_line = ".ImmutableModel model)"; //1255:133
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Append(__tmp90_line);
                    __tmp84_outputWritten = true;
                }
                if (__tmp84_outputWritten) __out.AppendLine(true);
                if (__tmp84_outputWritten)
                {
                    __out.AppendLine(false); //1255:155
                }
                __out.Append("	{"); //1256:1
                __out.AppendLine(false); //1256:3
                __out.Append("		return this.ToImmutable(model);"); //1257:1
                __out.AppendLine(false); //1257:34
                __out.Append("	}"); //1258:1
                __out.AppendLine(false); //1258:3
            }
            var __loop74_results = 
                (from __loop74_var1 in __Enumerate((cls).GetEnumerator()) //1260:8
                from prop in __Enumerate((__loop74_var1.GetAllProperties()).GetEnumerator()) //1260:13
                select new { __loop74_var1 = __loop74_var1, prop = prop}
                ).ToList(); //1260:3
            for (int __loop74_iteration = 0; __loop74_iteration < __loop74_results.Count; ++__loop74_iteration)
            {
                var __tmp91 = __loop74_results[__loop74_iteration];
                var __loop74_var1 = __tmp91.__loop74_var1;
                var prop = __tmp91.prop;
                __out.AppendLine(true); //1261:2
                bool __tmp93_outputWritten = false;
                string __tmp92Prefix = "	"; //1262:1
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
                    __out.AppendLine(false); //1262:49
                }
            }
            var __loop75_results = 
                (from __loop75_var1 in __Enumerate((cls).GetEnumerator()) //1264:8
                from op in __Enumerate((__loop75_var1.GetAllOperations()).GetEnumerator()) //1264:13
                select new { __loop75_var1 = __loop75_var1, op = op}
                ).ToList(); //1264:3
            for (int __loop75_iteration = 0; __loop75_iteration < __loop75_results.Count; ++__loop75_iteration)
            {
                var __tmp95 = __loop75_results[__loop75_iteration];
                var __loop75_var1 = __tmp95.__loop75_var1;
                var op = __tmp95.op;
                __out.AppendLine(true); //1265:2
                bool __tmp97_outputWritten = false;
                string __tmp96Prefix = "	"; //1266:1
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
                    __out.AppendLine(false); //1266:48
                }
            }
            if (metaMetaModel && cls.Name == "MetaModel") //1268:3
            {
                __out.AppendLine(true); //1269:1
                bool __tmp100_outputWritten = false;
                string __tmp99Prefix = "	"; //1270:1
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
                string __tmp102_line = ".ModelId "; //1270:21
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
                string __tmp104_line = ".IModel.Id => "; //1270:49
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
                string __tmp106_line = ".MModel.Id;"; //1270:110
                if (!string.IsNullOrEmpty(__tmp106_line))
                {
                    __out.Append(__tmp106_line);
                    __tmp100_outputWritten = true;
                }
                if (__tmp100_outputWritten) __out.AppendLine(true);
                if (__tmp100_outputWritten)
                {
                    __out.AppendLine(false); //1270:121
                }
                bool __tmp108_outputWritten = false;
                string __tmp109_line = "	string "; //1271:1
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
                string __tmp111_line = ".IModel.Name => this.Name;"; //1271:28
                if (!string.IsNullOrEmpty(__tmp111_line))
                {
                    __out.Append(__tmp111_line);
                    __tmp108_outputWritten = true;
                }
                if (__tmp108_outputWritten) __out.AppendLine(true);
                if (__tmp108_outputWritten)
                {
                    __out.AppendLine(false); //1271:54
                }
                bool __tmp113_outputWritten = false;
                string __tmp112Prefix = "	"; //1272:1
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
                string __tmp115_line = ".ModelVersion "; //1272:21
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
                string __tmp117_line = ".IModel.Version => "; //1272:54
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
                string __tmp119_line = ".MModel.Version;"; //1272:120
                if (!string.IsNullOrEmpty(__tmp119_line))
                {
                    __out.Append(__tmp119_line);
                    __tmp113_outputWritten = true;
                }
                if (__tmp113_outputWritten) __out.AppendLine(true);
                if (__tmp113_outputWritten)
                {
                    __out.AppendLine(false); //1272:136
                }
                bool __tmp121_outputWritten = false;
                string __tmp122_line = "	global::System.Collections.Generic.IEnumerable<global::MetaDslx.Modeling.IModelObject> "; //1273:1
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
                string __tmp124_line = ".IModel.Objects => "; //1273:108
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
                string __tmp126_line = ".MModel.Objects;"; //1273:174
                if (!string.IsNullOrEmpty(__tmp126_line))
                {
                    __out.Append(__tmp126_line);
                    __tmp121_outputWritten = true;
                }
                if (__tmp121_outputWritten) __out.AppendLine(true);
                if (__tmp121_outputWritten)
                {
                    __out.AppendLine(false); //1273:190
                }
                bool __tmp128_outputWritten = false;
                string __tmp129_line = "	string "; //1274:1
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
                string __tmp131_line = ".IMetaModel.Uri => this.Uri;"; //1274:28
                if (!string.IsNullOrEmpty(__tmp131_line))
                {
                    __out.Append(__tmp131_line);
                    __tmp128_outputWritten = true;
                }
                if (__tmp128_outputWritten) __out.AppendLine(true);
                if (__tmp128_outputWritten)
                {
                    __out.AppendLine(false); //1274:56
                }
                bool __tmp133_outputWritten = false;
                string __tmp134_line = "	string "; //1275:1
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
                string __tmp136_line = ".IMetaModel.Prefix => this.Prefix;"; //1275:28
                if (!string.IsNullOrEmpty(__tmp136_line))
                {
                    __out.Append(__tmp136_line);
                    __tmp133_outputWritten = true;
                }
                if (__tmp133_outputWritten) __out.AppendLine(true);
                if (__tmp133_outputWritten)
                {
                    __out.AppendLine(false); //1275:62
                }
                bool __tmp138_outputWritten = false;
                string __tmp137Prefix = "	"; //1276:1
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
                string __tmp140_line = ".IModelGroup "; //1276:21
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
                string __tmp142_line = ".IModel.ModelGroup => "; //1276:53
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
                string __tmp144_line = ".MModel.ModelGroup;"; //1276:122
                if (!string.IsNullOrEmpty(__tmp144_line))
                {
                    __out.Append(__tmp144_line);
                    __tmp138_outputWritten = true;
                }
                if (__tmp138_outputWritten) __out.AppendLine(true);
                if (__tmp138_outputWritten)
                {
                    __out.AppendLine(false); //1276:141
                }
                bool __tmp146_outputWritten = false;
                string __tmp147_line = "	string "; //1277:1
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
                string __tmp149_line = ".IMetaModel.Namespace => this.Namespace.FullName;"; //1277:28
                if (!string.IsNullOrEmpty(__tmp149_line))
                {
                    __out.Append(__tmp149_line);
                    __tmp146_outputWritten = true;
                }
                if (__tmp146_outputWritten) __out.AppendLine(true);
                if (__tmp146_outputWritten)
                {
                    __out.AppendLine(false); //1277:77
                }
                __out.AppendLine(true); //1278:1
                bool __tmp151_outputWritten = false;
                string __tmp152_line = "	public "; //1279:1
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
                string __tmp154_line = ".IModelFactory CreateFactory("; //1279:28
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
                string __tmp156_line = ".MutableModel model, "; //1279:76
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
                string __tmp158_line = ".ModelFactoryFlags flags = "; //1279:116
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
                string __tmp160_line = ".ModelFactoryFlags.None)"; //1279:162
                if (!string.IsNullOrEmpty(__tmp160_line))
                {
                    __out.Append(__tmp160_line);
                    __tmp151_outputWritten = true;
                }
                if (__tmp151_outputWritten) __out.AppendLine(true);
                if (__tmp151_outputWritten)
                {
                    __out.AppendLine(false); //1279:186
                }
                __out.Append("	{"); //1280:1
                __out.AppendLine(false); //1280:3
                bool __tmp162_outputWritten = false;
                string __tmp163_line = "		return new "; //1281:1
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
                string __tmp165_line = "(model, flags);"; //1281:51
                if (!string.IsNullOrEmpty(__tmp165_line))
                {
                    __out.Append(__tmp165_line);
                    __tmp162_outputWritten = true;
                }
                if (__tmp162_outputWritten) __out.AppendLine(true);
                if (__tmp162_outputWritten)
                {
                    __out.AppendLine(false); //1281:66
                }
                __out.Append("	}"); //1282:1
                __out.AppendLine(false); //1282:3
            }
            __out.Append("}"); //1284:1
            __out.AppendLine(false); //1284:2
            return __out.ToString();
        }

        public string GenerateBuilderField(MetaModel model, MetaClass cls, MetaProperty prop) //1287:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "private "; //1288:1
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
            string __tmp5_line = " "; //1288:63
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
            string __tmp7_line = ";"; //1288:88
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1288:89
            }
            return __out.ToString();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //1291:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1292:1
            if (cls.GetAllFinalProperties().Contains(prop)) //1293:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //1294:1
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
                string __tmp5_line = " "; //1294:62
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
                    __out.AppendLine(false); //1294:74
                }
            }
            else //1295:2
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
                    __out.AppendLine(false); //1296:54
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
                string __tmp13_line = " "; //1297:55
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
                string __tmp15_line = "."; //1297:111
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
                    __out.AppendLine(false); //1297:123
                }
            }
            __out.Append("{"); //1299:1
            __out.AppendLine(false); //1299:2
            if (prop.Type is MetaCollectionType) //1300:3
            {
                if (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.Set || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet) //1301:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "	get { return this.GetSet<"; //1302:1
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
                    string __tmp21_line = ">("; //1302:113
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
                    string __tmp23_line = ", ref "; //1302:169
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
                    string __tmp25_line = "); }"; //1302:199
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Append(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //1302:203
                    }
                }
                else //1303:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "	get { return this.GetList<"; //1304:1
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
                    string __tmp30_line = ">("; //1304:114
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
                    string __tmp32_line = ", ref "; //1304:170
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
                    string __tmp34_line = "); }"; //1304:200
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Append(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //1304:204
                    }
                }
            }
            else if (IsReferenceType(prop.Type)) //1306:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "	get { return this.GetReference<"; //1307:1
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
                string __tmp39_line = ">("; //1307:87
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
                string __tmp41_line = "); }"; //1307:143
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Append(__tmp41_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //1307:147
                }
            }
            else //1308:3
            {
                bool __tmp43_outputWritten = false;
                string __tmp44_line = "	get { return this.GetValue<"; //1309:1
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
                string __tmp46_line = ">("; //1309:83
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
                string __tmp48_line = "); }"; //1309:139
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Append(__tmp48_line);
                    __tmp43_outputWritten = true;
                }
                if (__tmp43_outputWritten) __out.AppendLine(true);
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //1309:143
                }
            }
            if ((prop.Kind == MetaPropertyKind.Normal) && !(prop.Type is MetaCollectionType)) //1311:3
            {
                if (IsReferenceType(prop.Type)) //1312:4
                {
                    bool __tmp50_outputWritten = false;
                    string __tmp51_line = "	set { this.SetReference<"; //1313:1
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
                    string __tmp53_line = ">("; //1313:80
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
                    string __tmp55_line = ", value); }"; //1313:136
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Append(__tmp55_line);
                        __tmp50_outputWritten = true;
                    }
                    if (__tmp50_outputWritten) __out.AppendLine(true);
                    if (__tmp50_outputWritten)
                    {
                        __out.AppendLine(false); //1313:147
                    }
                }
                else //1314:4
                {
                    bool __tmp57_outputWritten = false;
                    string __tmp58_line = "	set { this.SetValue<"; //1315:1
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
                    string __tmp60_line = ">("; //1315:76
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
                    string __tmp62_line = ", value); }"; //1315:132
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Append(__tmp62_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //1315:143
                    }
                }
            }
            __out.Append("}"); //1318:1
            __out.AppendLine(false); //1318:2
            if (!(prop.Type is MetaCollectionType)) //1319:2
            {
                __out.AppendLine(true); //1320:1
                bool __tmp64_outputWritten = false;
                string __tmp65_line = "void "; //1321:1
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
                string __tmp67_line = ".Set"; //1321:61
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
                string __tmp69_line = "Lazy(global::System.Func<"; //1321:76
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
                string __tmp71_line = "> lazy)"; //1321:155
                if (!string.IsNullOrEmpty(__tmp71_line))
                {
                    __out.Append(__tmp71_line);
                    __tmp64_outputWritten = true;
                }
                if (__tmp64_outputWritten) __out.AppendLine(true);
                if (__tmp64_outputWritten)
                {
                    __out.AppendLine(false); //1321:162
                }
                __out.Append("{"); //1322:1
                __out.AppendLine(false); //1322:2
                if (IsReferenceType(prop.Type)) //1323:3
                {
                    bool __tmp73_outputWritten = false;
                    string __tmp74_line = "	this.SetLazyReference("; //1324:1
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
                    string __tmp76_line = ", lazy);"; //1324:79
                    if (!string.IsNullOrEmpty(__tmp76_line))
                    {
                        __out.Append(__tmp76_line);
                        __tmp73_outputWritten = true;
                    }
                    if (__tmp73_outputWritten) __out.AppendLine(true);
                    if (__tmp73_outputWritten)
                    {
                        __out.AppendLine(false); //1324:87
                    }
                }
                else //1325:3
                {
                    bool __tmp78_outputWritten = false;
                    string __tmp79_line = "	this.SetLazyValue("; //1326:1
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
                    string __tmp81_line = ", lazy);"; //1326:75
                    if (!string.IsNullOrEmpty(__tmp81_line))
                    {
                        __out.Append(__tmp81_line);
                        __tmp78_outputWritten = true;
                    }
                    if (__tmp78_outputWritten) __out.AppendLine(true);
                    if (__tmp78_outputWritten)
                    {
                        __out.AppendLine(false); //1326:83
                    }
                }
                __out.Append("}"); //1328:1
                __out.AppendLine(false); //1328:2
                __out.AppendLine(true); //1329:1
                bool __tmp83_outputWritten = false;
                string __tmp84_line = "void "; //1330:1
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
                string __tmp86_line = ".Set"; //1330:61
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
                string __tmp88_line = "Lazy(global::System.Func<"; //1330:76
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
                string __tmp90_line = ", "; //1330:156
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
                string __tmp92_line = "> lazy)"; //1330:212
                if (!string.IsNullOrEmpty(__tmp92_line))
                {
                    __out.Append(__tmp92_line);
                    __tmp83_outputWritten = true;
                }
                if (__tmp83_outputWritten) __out.AppendLine(true);
                if (__tmp83_outputWritten)
                {
                    __out.AppendLine(false); //1330:219
                }
                __out.Append("{"); //1331:1
                __out.AppendLine(false); //1331:2
                if (IsReferenceType(prop.Type)) //1332:3
                {
                    bool __tmp94_outputWritten = false;
                    string __tmp95_line = "	this.SetLazyReference("; //1333:1
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
                    string __tmp97_line = ", lazy);"; //1333:79
                    if (!string.IsNullOrEmpty(__tmp97_line))
                    {
                        __out.Append(__tmp97_line);
                        __tmp94_outputWritten = true;
                    }
                    if (__tmp94_outputWritten) __out.AppendLine(true);
                    if (__tmp94_outputWritten)
                    {
                        __out.AppendLine(false); //1333:87
                    }
                }
                else //1334:3
                {
                    bool __tmp99_outputWritten = false;
                    string __tmp100_line = "	this.SetLazyValue("; //1335:1
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
                    string __tmp102_line = ", lazy);"; //1335:75
                    if (!string.IsNullOrEmpty(__tmp102_line))
                    {
                        __out.Append(__tmp102_line);
                        __tmp99_outputWritten = true;
                    }
                    if (__tmp99_outputWritten) __out.AppendLine(true);
                    if (__tmp99_outputWritten)
                    {
                        __out.AppendLine(false); //1335:83
                    }
                }
                __out.Append("}"); //1337:1
                __out.AppendLine(false); //1337:2
                __out.AppendLine(true); //1338:1
                bool __tmp104_outputWritten = false;
                string __tmp105_line = "void "; //1339:1
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
                string __tmp107_line = ".Set"; //1339:61
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
                string __tmp109_line = "Lazy(global::System.Func<"; //1339:76
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
                string __tmp111_line = ", "; //1339:158
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
                string __tmp113_line = "> immutableLazy, global::System.Func<"; //1339:216
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
                string __tmp115_line = ", "; //1339:308
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
                string __tmp117_line = "> mutableLazy)"; //1339:364
                if (!string.IsNullOrEmpty(__tmp117_line))
                {
                    __out.Append(__tmp117_line);
                    __tmp104_outputWritten = true;
                }
                if (__tmp104_outputWritten) __out.AppendLine(true);
                if (__tmp104_outputWritten)
                {
                    __out.AppendLine(false); //1339:378
                }
                __out.Append("{"); //1340:1
                __out.AppendLine(false); //1340:2
                if (IsReferenceType(prop.Type)) //1341:3
                {
                    bool __tmp119_outputWritten = false;
                    string __tmp120_line = "	this.SetLazyReference("; //1342:1
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
                    string __tmp122_line = ", immutableLazy, mutableLazy);"; //1342:79
                    if (!string.IsNullOrEmpty(__tmp122_line))
                    {
                        __out.Append(__tmp122_line);
                        __tmp119_outputWritten = true;
                    }
                    if (__tmp119_outputWritten) __out.AppendLine(true);
                    if (__tmp119_outputWritten)
                    {
                        __out.AppendLine(false); //1342:109
                    }
                }
                else //1343:3
                {
                    bool __tmp124_outputWritten = false;
                    string __tmp125_line = "	this.SetLazyValue("; //1344:1
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
                    string __tmp127_line = ", immutableLazy, mutableLazy);"; //1344:75
                    if (!string.IsNullOrEmpty(__tmp127_line))
                    {
                        __out.Append(__tmp127_line);
                        __tmp124_outputWritten = true;
                    }
                    if (__tmp124_outputWritten) __out.AppendLine(true);
                    if (__tmp124_outputWritten)
                    {
                        __out.AppendLine(false); //1344:105
                    }
                }
                __out.Append("}"); //1346:1
                __out.AppendLine(false); //1346:2
            }
            return __out.ToString();
        }

        public string GenerateBuilderOperationImpl(MetaModel model, MetaClass cls, MetaOperation op) //1350:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1351:1
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
            string __tmp4_line = " "; //1352:68
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
            string __tmp6_line = "."; //1352:122
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
            string __tmp8_line = "("; //1352:132
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
            string __tmp10_line = ")"; //1352:202
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1352:203
            }
            __out.Append("{"); //1353:1
            __out.AppendLine(false); //1353:2
            var finalOp = GetFinalOperation(cls, op); //1354:2
            bool __tmp12_outputWritten = false;
            string __tmp11Prefix = "    "; //1355:1
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(GetReturn(CSharpName(finalOp.ReturnType, model, ClassKind.BuilderOperation)));
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
            string __tmp15_line = ".Implementation."; //1355:134
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
            string __tmp17_line = "_"; //1355:204
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
            string __tmp19_line = "("; //1355:219
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
            string __tmp21_line = ");"; //1355:296
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp12_outputWritten = true;
            }
            if (__tmp12_outputWritten) __out.AppendLine(true);
            if (__tmp12_outputWritten)
            {
                __out.AppendLine(false); //1355:298
            }
            __out.Append("}"); //1356:1
            __out.AppendLine(false); //1356:2
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
