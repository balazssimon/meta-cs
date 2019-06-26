using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Modeling; //4:1
using MetaDslx.Languages.Meta.Symbols; //5:1
using System.Collections.Immutable; //6:1

namespace MetaDslx.Languages.Meta.Generator //1:1
{
    using MetaAnnotation = MetaAttribute;
    using MetaAnnotatedElement = MetaElement;

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
        string GetEnumValueOf(Enum menum); //32:8
        string GetAttributeValueOf(MetaAnnotation mannot); //33:8
        string GetAttributeName(MetaAnnotation mannot); //34:8
        string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false); //35:8
        string CSharpName(MetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false); //36:8
        string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false); //37:8
        string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false); //38:8
        string CSharpName(MetaConstant mconst, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false); //39:8
        ImmutableList<ImmutableSymbol> GetSymbolInstances(MetaModel mmodel); //40:8
        ImmutableDictionary<ImmutableSymbol,string> GetSymbolInstanceNames(MetaModel mmodel); //41:8
        string GetFieldName(MetaProperty mproperty, MetaClass mclass); //42:8
        bool IsReferenceType(MetaType mtype); //43:8
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

        public __Properties Properties { get; private set; } //8:1

        public class __Properties //8:1
        {
            internal __Properties()
            {
                this.CoreNs = "global::MetaDslx.Modeling"; //9:18
                this.MetaNs = "global::MetaDslx.Languages.Meta.Symbols"; //10:18
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

        internal string GetEnumValueOf(Enum menum) //32:8
        {
            return this.extensionFunctions.GetEnumValueOf(menum); //32:8
        }

        internal string GetAttributeValueOf(MetaAnnotation mannot) //33:8
        {
            return this.extensionFunctions.GetAttributeValueOf(mannot); //33:8
        }

        internal string GetAttributeName(MetaAnnotation mannot) //34:8
        {
            return this.extensionFunctions.GetAttributeName(mannot); //34:8
        }

        internal string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false) //35:8
        {
            return this.extensionFunctions.CSharpName(mnamespace, kind, fullName); //35:8
        }

        internal string CSharpName(MetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false) //36:8
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

        internal ImmutableList<ImmutableSymbol> GetSymbolInstances(MetaModel mmodel) //40:8
        {
            return this.extensionFunctions.GetSymbolInstances(mmodel); //40:8
        }

        internal ImmutableDictionary<ImmutableSymbol,string> GetSymbolInstanceNames(MetaModel mmodel) //41:8
        {
            return this.extensionFunctions.GetSymbolInstanceNames(mmodel); //41:8
        }

        internal string GetFieldName(MetaProperty mproperty, MetaClass mclass) //42:8
        {
            return this.extensionFunctions.GetFieldName(mproperty, mclass); //42:8
        }

        internal bool IsReferenceType(MetaType mtype) //43:8
        {
            return this.extensionFunctions.IsReferenceType(mtype); //43:8
        }

        public string GenerateDocumentation(MetaDocumentedElement elem) //45:1
        {
            StringBuilder __out = new StringBuilder();
            ImmutableModelList<string> lines = elem.GetDocumentationLines(); //46:2
            if (lines.Count > 0) //47:2
            {
                __out.Append("/**"); //48:1
                __out.AppendLine(false); //48:4
                __out.Append(" * <summary>"); //49:1
                __out.AppendLine(false); //49:13
                var __loop2_results = 
                    (from line in __Enumerate((lines).GetEnumerator()) //50:8
                    select new { line = line}
                    ).ToList(); //50:3
                for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
                {
                    var __tmp1 = __loop2_results[__loop2_iteration];
                    var line = __tmp1.line;
                    bool __tmp3_outputWritten = false;
                    string __tmp4_line = " * "; //51:1
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
                        __out.AppendLine(false); //51:10
                    }
                }
                __out.Append(" * </summary>"); //53:1
                __out.AppendLine(false); //53:14
                __out.Append(" */"); //54:1
                __out.AppendLine(false); //54:4
            }
            return __out.ToString();
        }

        public string GenerateAnnotations(MetaAnnotatedElement elem) //58:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop3_results = 
                (from __loop3_var1 in __Enumerate((elem).GetEnumerator()) //59:7
                from annot in __Enumerate((__loop3_var1.Attributes).GetEnumerator()) //59:13
                select new { __loop3_var1 = __loop3_var1, annot = annot}
                ).ToList(); //59:2
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                var __tmp1 = __loop3_results[__loop3_iteration];
                var __loop3_var1 = __tmp1.__loop3_var1;
                var annot = __tmp1.annot;
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
                string __tmp6_line = "."; //60:25
                if (!string.IsNullOrEmpty(__tmp6_line))
                {
                    __out.Append(__tmp6_line);
                    __tmp3_outputWritten = true;
                }
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(GetAttributeName(annot));
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
                    __out.AppendLine(false); //60:56
                }
            }
            return __out.ToString();
        }

        public string GenerateMetamodel(MetaModel model) //64:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //65:1
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
                __out.AppendLine(false); //65:67
            }
            __out.Append("{"); //66:1
            __out.AppendLine(false); //66:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	using global::"; //67:1
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
            string __tmp9_line = ";"; //67:74
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //67:75
            }
            __out.AppendLine(true); //68:1
            bool __tmp11_outputWritten = false;
            string __tmp10Prefix = "	"; //69:1
            StringBuilder __tmp12 = new StringBuilder();
            __tmp12.Append(GenerateMetaModelInstance(model));
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
                __out.AppendLine(false); //69:36
            }
            __out.AppendLine(true); //70:1
            bool __tmp14_outputWritten = false;
            string __tmp13Prefix = "	"; //71:1
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(GenerateFactory(model));
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
                __out.AppendLine(false); //71:26
            }
            __out.AppendLine(true); //72:1
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //73:8
                from enm in __Enumerate((__loop4_var1).GetEnumerator()).OfType<MetaEnum>() //73:38
                select new { __loop4_var1 = __loop4_var1, enm = enm}
                ).ToList(); //73:3
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp16 = __loop4_results[__loop4_iteration];
                var __loop4_var1 = __tmp16.__loop4_var1;
                var enm = __tmp16.enm;
                bool __tmp18_outputWritten = false;
                string __tmp17Prefix = "	"; //74:1
                StringBuilder __tmp19 = new StringBuilder();
                __tmp19.Append(GenerateEnum(model, enm));
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
                        if (!__tmp19_last || __tmp18_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp18_outputWritten)
                {
                    __out.AppendLine(false); //74:28
                }
            }
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //76:8
                from cls in __Enumerate((__loop5_var1).GetEnumerator()).OfType<MetaClass>() //76:38
                select new { __loop5_var1 = __loop5_var1, cls = cls}
                ).ToList(); //76:3
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp20 = __loop5_results[__loop5_iteration];
                var __loop5_var1 = __tmp20.__loop5_var1;
                var cls = __tmp20.cls;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "	"; //77:1
                StringBuilder __tmp23 = new StringBuilder();
                __tmp23.Append(GenerateClass(model, cls));
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
                    __out.AppendLine(false); //77:29
                }
            }
            __out.AppendLine(true); //79:1
            bool __tmp25_outputWritten = false;
            string __tmp24Prefix = "	"; //80:1
            StringBuilder __tmp26 = new StringBuilder();
            __tmp26.Append(GenerateMetaModelDescriptor(model));
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
                __out.AppendLine(false); //80:38
            }
            __out.Append("}"); //81:1
            __out.AppendLine(false); //81:2
            __out.AppendLine(true); //82:1
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "namespace "; //83:1
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Append(__tmp29_line);
                __tmp28_outputWritten = true;
            }
            StringBuilder __tmp30 = new StringBuilder();
            __tmp30.Append(CSharpName(model.Namespace, NamespaceKind.Internal, true));
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
                    if (!__tmp30_last || __tmp28_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //83:69
            }
            __out.Append("{"); //84:1
            __out.AppendLine(false); //84:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //85:8
                from cls in __Enumerate((__loop6_var1).GetEnumerator()).OfType<MetaClass>() //85:38
                select new { __loop6_var1 = __loop6_var1, cls = cls}
                ).ToList(); //85:3
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp31 = __loop6_results[__loop6_iteration];
                var __loop6_var1 = __tmp31.__loop6_var1;
                var cls = __tmp31.cls;
                bool __tmp33_outputWritten = false;
                string __tmp32Prefix = "	"; //86:1
                StringBuilder __tmp34 = new StringBuilder();
                __tmp34.Append(GenerateClassInternal(model, cls));
                using(StreamReader __tmp34Reader = new StreamReader(this.__ToStream(__tmp34.ToString())))
                {
                    bool __tmp34_last = __tmp34Reader.EndOfStream;
                    while(!__tmp34_last)
                    {
                        string __tmp34_line = __tmp34Reader.ReadLine();
                        __tmp34_last = __tmp34Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp32Prefix))
                        {
                            __out.Append(__tmp32Prefix);
                            __tmp33_outputWritten = true;
                        }
                        if ((__tmp34_last && !string.IsNullOrEmpty(__tmp34_line)) || (!__tmp34_last && __tmp34_line != null))
                        {
                            __out.Append(__tmp34_line);
                            __tmp33_outputWritten = true;
                        }
                        if (!__tmp34_last || __tmp33_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp33_outputWritten)
                {
                    __out.AppendLine(false); //86:37
                }
            }
            __out.AppendLine(true); //88:1
            bool __tmp36_outputWritten = false;
            string __tmp35Prefix = "	"; //89:1
            StringBuilder __tmp37 = new StringBuilder();
            __tmp37.Append(GenerateMetaModelBuilderInstance(model));
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
                __out.AppendLine(false); //89:43
            }
            __out.AppendLine(true); //90:1
            bool __tmp39_outputWritten = false;
            string __tmp38Prefix = "	"; //91:1
            StringBuilder __tmp40 = new StringBuilder();
            __tmp40.Append(GenerateImplementationBase(model));
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
                __out.AppendLine(false); //91:37
            }
            __out.AppendLine(true); //92:1
            bool __tmp42_outputWritten = false;
            string __tmp41Prefix = "	"; //93:1
            StringBuilder __tmp43 = new StringBuilder();
            __tmp43.Append(GenerateImplementationProvider(model));
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
                __out.AppendLine(false); //93:41
            }
            __out.Append("}"); //94:1
            __out.AppendLine(false); //94:2
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //97:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //98:2
            bool metaMetaModel = IsMetaMetaModel(model); //99:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //100:1
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
                __out.AppendLine(false); //100:61
            }
            __out.Append("{"); //101:1
            __out.AppendLine(false); //101:2
            __out.Append("	private static bool initialized;"); //102:1
            __out.AppendLine(false); //102:34
            __out.AppendLine(true); //103:1
            __out.Append("	public static bool IsInitialized"); //104:1
            __out.AppendLine(false); //104:34
            __out.Append("	{"); //105:1
            __out.AppendLine(false); //105:3
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "		get { return "; //106:1
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
            string __tmp9_line = ".initialized; }"; //106:63
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //106:78
            }
            __out.Append("	}"); //107:1
            __out.AppendLine(false); //107:3
            __out.AppendLine(true); //108:1
            if (metaMetaModel) //109:3
            {
                bool __tmp11_outputWritten = false;
                string __tmp12_line = "	public static readonly "; //110:1
                if (!string.IsNullOrEmpty(__tmp12_line))
                {
                    __out.Append(__tmp12_line);
                    __tmp11_outputWritten = true;
                }
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(metaNs);
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
                string __tmp14_line = "MetaModel MetaMetaModel;"; //110:33
                if (!string.IsNullOrEmpty(__tmp14_line))
                {
                    __out.Append(__tmp14_line);
                    __tmp11_outputWritten = true;
                }
                if (__tmp11_outputWritten) __out.AppendLine(true);
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //110:57
                }
            }
            else //111:3
            {
                bool __tmp16_outputWritten = false;
                string __tmp17_line = "	public static readonly "; //112:1
                if (!string.IsNullOrEmpty(__tmp17_line))
                {
                    __out.Append(__tmp17_line);
                    __tmp16_outputWritten = true;
                }
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(metaNs);
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
                string __tmp19_line = "MetaModel MetaModel;"; //112:33
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Append(__tmp19_line);
                    __tmp16_outputWritten = true;
                }
                if (__tmp16_outputWritten) __out.AppendLine(true);
                if (__tmp16_outputWritten)
                {
                    __out.AppendLine(false); //112:53
                }
            }
            bool __tmp21_outputWritten = false;
            string __tmp22_line = "	public static readonly "; //114:1
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Append(__tmp22_line);
                __tmp21_outputWritten = true;
            }
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(Properties.CoreNs);
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
            string __tmp24_line = ".ImmutableModel Model;"; //114:44
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp21_outputWritten = true;
            }
            if (__tmp21_outputWritten) __out.AppendLine(true);
            if (__tmp21_outputWritten)
            {
                __out.AppendLine(false); //114:66
            }
            __out.AppendLine(true); //115:1
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //116:8
                from cst in __Enumerate((__loop7_var1).GetEnumerator()).OfType<MetaConstant>() //116:38
                select new { __loop7_var1 = __loop7_var1, cst = cst}
                ).ToList(); //116:3
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp25 = __loop7_results[__loop7_iteration];
                var __loop7_var1 = __tmp25.__loop7_var1;
                var cst = __tmp25.cst;
                bool __tmp27_outputWritten = false;
                string __tmp26Prefix = "	"; //117:1
                StringBuilder __tmp28 = new StringBuilder();
                __tmp28.Append(GenerateDocumentation(cst));
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
                    __out.AppendLine(false); //117:30
                }
                if (metaMetaModel) //118:4
                {
                    bool __tmp30_outputWritten = false;
                    string __tmp31_line = "	public static readonly "; //119:1
                    if (!string.IsNullOrEmpty(__tmp31_line))
                    {
                        __out.Append(__tmp31_line);
                        __tmp30_outputWritten = true;
                    }
                    StringBuilder __tmp32 = new StringBuilder();
                    __tmp32.Append(CSharpName(cst.Type, model, ClassKind.Immutable));
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
                    string __tmp33_line = " "; //119:74
                    if (!string.IsNullOrEmpty(__tmp33_line))
                    {
                        __out.Append(__tmp33_line);
                        __tmp30_outputWritten = true;
                    }
                    StringBuilder __tmp34 = new StringBuilder();
                    __tmp34.Append(CSharpName(cst, model, ClassKind.ImmutableInstance));
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
                    string __tmp35_line = ";"; //119:127
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Append(__tmp35_line);
                        __tmp30_outputWritten = true;
                    }
                    if (__tmp30_outputWritten) __out.AppendLine(true);
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //119:128
                    }
                }
                else //120:4
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "	public static readonly "; //121:1
                    if (!string.IsNullOrEmpty(__tmp38_line))
                    {
                        __out.Append(__tmp38_line);
                        __tmp37_outputWritten = true;
                    }
                    StringBuilder __tmp39 = new StringBuilder();
                    __tmp39.Append(CSharpName(cst.Type, model, ClassKind.Immutable, true));
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
                    string __tmp40_line = " "; //121:80
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Append(__tmp40_line);
                        __tmp37_outputWritten = true;
                    }
                    StringBuilder __tmp41 = new StringBuilder();
                    __tmp41.Append(CSharpName(cst, model, ClassKind.ImmutableInstance));
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
                    string __tmp42_line = ";"; //121:133
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Append(__tmp42_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //121:134
                    }
                }
            }
            __out.AppendLine(true); //124:1
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //125:8
                from cls in __Enumerate((__loop8_var1).GetEnumerator()).OfType<MetaClass>() //125:38
                select new { __loop8_var1 = __loop8_var1, cls = cls}
                ).ToList(); //125:3
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp43 = __loop8_results[__loop8_iteration];
                var __loop8_var1 = __tmp43.__loop8_var1;
                var cls = __tmp43.cls;
                bool __tmp45_outputWritten = false;
                string __tmp44Prefix = "	"; //126:1
                StringBuilder __tmp46 = new StringBuilder();
                __tmp46.Append(GenerateDocumentation(cls));
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
                    __out.AppendLine(false); //126:30
                }
                bool __tmp48_outputWritten = false;
                string __tmp49_line = "	public static readonly "; //127:1
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Append(__tmp49_line);
                    __tmp48_outputWritten = true;
                }
                StringBuilder __tmp50 = new StringBuilder();
                __tmp50.Append(metaNs);
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
                string __tmp51_line = "MetaClass "; //127:33
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Append(__tmp51_line);
                    __tmp48_outputWritten = true;
                }
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(CSharpName(cls, model, ClassKind.ImmutableInstance));
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
                string __tmp53_line = ";"; //127:95
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp48_outputWritten = true;
                }
                if (__tmp48_outputWritten) __out.AppendLine(true);
                if (__tmp48_outputWritten)
                {
                    __out.AppendLine(false); //127:96
                }
                var __loop9_results = 
                    (from __loop9_var1 in __Enumerate((cls).GetEnumerator()) //128:9
                    from prop in __Enumerate((__loop9_var1.Properties).GetEnumerator()) //128:14
                    select new { __loop9_var1 = __loop9_var1, prop = prop}
                    ).ToList(); //128:4
                for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
                {
                    var __tmp54 = __loop9_results[__loop9_iteration];
                    var __loop9_var1 = __tmp54.__loop9_var1;
                    var prop = __tmp54.prop;
                    bool __tmp56_outputWritten = false;
                    string __tmp55Prefix = "	"; //129:1
                    StringBuilder __tmp57 = new StringBuilder();
                    __tmp57.Append(GenerateDocumentation(prop));
                    using(StreamReader __tmp57Reader = new StreamReader(this.__ToStream(__tmp57.ToString())))
                    {
                        bool __tmp57_last = __tmp57Reader.EndOfStream;
                        while(!__tmp57_last)
                        {
                            string __tmp57_line = __tmp57Reader.ReadLine();
                            __tmp57_last = __tmp57Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp55Prefix))
                            {
                                __out.Append(__tmp55Prefix);
                                __tmp56_outputWritten = true;
                            }
                            if ((__tmp57_last && !string.IsNullOrEmpty(__tmp57_line)) || (!__tmp57_last && __tmp57_line != null))
                            {
                                __out.Append(__tmp57_line);
                                __tmp56_outputWritten = true;
                            }
                            if (!__tmp57_last || __tmp56_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp56_outputWritten)
                    {
                        __out.AppendLine(false); //129:31
                    }
                    bool __tmp59_outputWritten = false;
                    string __tmp60_line = "	public static readonly "; //130:1
                    if (!string.IsNullOrEmpty(__tmp60_line))
                    {
                        __out.Append(__tmp60_line);
                        __tmp59_outputWritten = true;
                    }
                    StringBuilder __tmp61 = new StringBuilder();
                    __tmp61.Append(metaNs);
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
                    string __tmp62_line = "MetaProperty "; //130:33
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Append(__tmp62_line);
                        __tmp59_outputWritten = true;
                    }
                    StringBuilder __tmp63 = new StringBuilder();
                    __tmp63.Append(CSharpName(prop, model, PropertyKind.ImmutableInstance));
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
                    string __tmp64_line = ";"; //130:102
                    if (!string.IsNullOrEmpty(__tmp64_line))
                    {
                        __out.Append(__tmp64_line);
                        __tmp59_outputWritten = true;
                    }
                    if (__tmp59_outputWritten) __out.AppendLine(true);
                    if (__tmp59_outputWritten)
                    {
                        __out.AppendLine(false); //130:103
                    }
                }
            }
            __out.AppendLine(true); //133:1
            bool __tmp66_outputWritten = false;
            string __tmp67_line = "	static "; //134:1
            if (!string.IsNullOrEmpty(__tmp67_line))
            {
                __out.Append(__tmp67_line);
                __tmp66_outputWritten = true;
            }
            StringBuilder __tmp68 = new StringBuilder();
            __tmp68.Append(CSharpName(model, ModelKind.ImmutableInstance));
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
            string __tmp69_line = "()"; //134:56
            if (!string.IsNullOrEmpty(__tmp69_line))
            {
                __out.Append(__tmp69_line);
                __tmp66_outputWritten = true;
            }
            if (__tmp66_outputWritten) __out.AppendLine(true);
            if (__tmp66_outputWritten)
            {
                __out.AppendLine(false); //134:58
            }
            __out.Append("	{"); //135:1
            __out.AppendLine(false); //135:3
            if (metaMetaModel) //136:4
            {
                bool __tmp71_outputWritten = false;
                string __tmp70Prefix = "		"; //137:1
                StringBuilder __tmp72 = new StringBuilder();
                __tmp72.Append(CSharpName(model, ModelKind.BuilderInstance));
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
                        if (!__tmp72_last) __out.AppendLine(true);
                    }
                }
                string __tmp73_line = ".instance.Create();"; //137:48
                if (!string.IsNullOrEmpty(__tmp73_line))
                {
                    __out.Append(__tmp73_line);
                    __tmp71_outputWritten = true;
                }
                if (__tmp71_outputWritten) __out.AppendLine(true);
                if (__tmp71_outputWritten)
                {
                    __out.AppendLine(false); //137:67
                }
                bool __tmp75_outputWritten = false;
                string __tmp74Prefix = "		"; //138:1
                StringBuilder __tmp76 = new StringBuilder();
                __tmp76.Append(CSharpName(model, ModelKind.BuilderInstance));
                using(StreamReader __tmp76Reader = new StreamReader(this.__ToStream(__tmp76.ToString())))
                {
                    bool __tmp76_last = __tmp76Reader.EndOfStream;
                    while(!__tmp76_last)
                    {
                        string __tmp76_line = __tmp76Reader.ReadLine();
                        __tmp76_last = __tmp76Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp74Prefix))
                        {
                            __out.Append(__tmp74Prefix);
                            __tmp75_outputWritten = true;
                        }
                        if ((__tmp76_last && !string.IsNullOrEmpty(__tmp76_line)) || (!__tmp76_last && __tmp76_line != null))
                        {
                            __out.Append(__tmp76_line);
                            __tmp75_outputWritten = true;
                        }
                        if (!__tmp76_last) __out.AppendLine(true);
                    }
                }
                string __tmp77_line = ".instance.EvaluateLazyValues();"; //138:48
                if (!string.IsNullOrEmpty(__tmp77_line))
                {
                    __out.Append(__tmp77_line);
                    __tmp75_outputWritten = true;
                }
                if (__tmp75_outputWritten) __out.AppendLine(true);
                if (__tmp75_outputWritten)
                {
                    __out.AppendLine(false); //138:79
                }
                bool __tmp79_outputWritten = false;
                string __tmp80_line = "		MetaMetaModel = "; //139:1
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
                string __tmp82_line = ".instance.MetaMetaModel.ToImmutable();"; //139:64
                if (!string.IsNullOrEmpty(__tmp82_line))
                {
                    __out.Append(__tmp82_line);
                    __tmp79_outputWritten = true;
                }
                if (__tmp79_outputWritten) __out.AppendLine(true);
                if (__tmp79_outputWritten)
                {
                    __out.AppendLine(false); //139:102
                }
            }
            else //140:4
            {
                bool __tmp84_outputWritten = false;
                string __tmp83Prefix = "		"; //141:1
                StringBuilder __tmp85 = new StringBuilder();
                __tmp85.Append(CSharpName(model, ModelKind.BuilderInstance));
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
                string __tmp86_line = ".instance.Create();"; //141:48
                if (!string.IsNullOrEmpty(__tmp86_line))
                {
                    __out.Append(__tmp86_line);
                    __tmp84_outputWritten = true;
                }
                if (__tmp84_outputWritten) __out.AppendLine(true);
                if (__tmp84_outputWritten)
                {
                    __out.AppendLine(false); //141:67
                }
                bool __tmp88_outputWritten = false;
                string __tmp87Prefix = "		"; //142:1
                StringBuilder __tmp89 = new StringBuilder();
                __tmp89.Append(CSharpName(model, ModelKind.BuilderInstance));
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
                string __tmp90_line = ".instance.EvaluateLazyValues();"; //142:48
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Append(__tmp90_line);
                    __tmp88_outputWritten = true;
                }
                if (__tmp88_outputWritten) __out.AppendLine(true);
                if (__tmp88_outputWritten)
                {
                    __out.AppendLine(false); //142:79
                }
                bool __tmp92_outputWritten = false;
                string __tmp93_line = "		MetaModel = "; //143:1
                if (!string.IsNullOrEmpty(__tmp93_line))
                {
                    __out.Append(__tmp93_line);
                    __tmp92_outputWritten = true;
                }
                StringBuilder __tmp94 = new StringBuilder();
                __tmp94.Append(CSharpName(model, ModelKind.BuilderInstance));
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
                            __tmp92_outputWritten = true;
                        }
                        if (!__tmp94_last) __out.AppendLine(true);
                    }
                }
                string __tmp95_line = ".instance.MetaModel.ToImmutable();"; //143:60
                if (!string.IsNullOrEmpty(__tmp95_line))
                {
                    __out.Append(__tmp95_line);
                    __tmp92_outputWritten = true;
                }
                if (__tmp92_outputWritten) __out.AppendLine(true);
                if (__tmp92_outputWritten)
                {
                    __out.AppendLine(false); //143:94
                }
            }
            bool __tmp97_outputWritten = false;
            string __tmp98_line = "		Model = "; //145:1
            if (!string.IsNullOrEmpty(__tmp98_line))
            {
                __out.Append(__tmp98_line);
                __tmp97_outputWritten = true;
            }
            StringBuilder __tmp99 = new StringBuilder();
            __tmp99.Append(CSharpName(model, ModelKind.BuilderInstance));
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
                        __tmp97_outputWritten = true;
                    }
                    if (!__tmp99_last) __out.AppendLine(true);
                }
            }
            string __tmp100_line = ".instance.Model.ToImmutable();"; //145:56
            if (!string.IsNullOrEmpty(__tmp100_line))
            {
                __out.Append(__tmp100_line);
                __tmp97_outputWritten = true;
            }
            if (__tmp97_outputWritten) __out.AppendLine(true);
            if (__tmp97_outputWritten)
            {
                __out.AppendLine(false); //145:86
            }
            __out.AppendLine(true); //146:1
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //147:9
                from cst in __Enumerate((__loop10_var1).GetEnumerator()).OfType<MetaConstant>() //147:39
                select new { __loop10_var1 = __loop10_var1, cst = cst}
                ).ToList(); //147:4
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp101 = __loop10_results[__loop10_iteration];
                var __loop10_var1 = __tmp101.__loop10_var1;
                var cst = __tmp101.cst;
                if (metaMetaModel) //148:5
                {
                    bool __tmp103_outputWritten = false;
                    string __tmp102Prefix = "		"; //149:1
                    StringBuilder __tmp104 = new StringBuilder();
                    __tmp104.Append(CSharpName(cst, model, ClassKind.ImmutableInstance));
                    using(StreamReader __tmp104Reader = new StreamReader(this.__ToStream(__tmp104.ToString())))
                    {
                        bool __tmp104_last = __tmp104Reader.EndOfStream;
                        while(!__tmp104_last)
                        {
                            string __tmp104_line = __tmp104Reader.ReadLine();
                            __tmp104_last = __tmp104Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp102Prefix))
                            {
                                __out.Append(__tmp102Prefix);
                                __tmp103_outputWritten = true;
                            }
                            if ((__tmp104_last && !string.IsNullOrEmpty(__tmp104_line)) || (!__tmp104_last && __tmp104_line != null))
                            {
                                __out.Append(__tmp104_line);
                                __tmp103_outputWritten = true;
                            }
                            if (!__tmp104_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp105_line = " = "; //149:55
                    if (!string.IsNullOrEmpty(__tmp105_line))
                    {
                        __out.Append(__tmp105_line);
                        __tmp103_outputWritten = true;
                    }
                    StringBuilder __tmp106 = new StringBuilder();
                    __tmp106.Append(CSharpName(cst, model, ClassKind.BuilderInstance, true));
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
                                __tmp103_outputWritten = true;
                            }
                            if (!__tmp106_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp107_line = ".ToImmutable(Model);"; //149:114
                    if (!string.IsNullOrEmpty(__tmp107_line))
                    {
                        __out.Append(__tmp107_line);
                        __tmp103_outputWritten = true;
                    }
                    if (__tmp103_outputWritten) __out.AppendLine(true);
                    if (__tmp103_outputWritten)
                    {
                        __out.AppendLine(false); //149:134
                    }
                }
                else //150:5
                {
                    bool __tmp109_outputWritten = false;
                    string __tmp108Prefix = "		"; //151:1
                    StringBuilder __tmp110 = new StringBuilder();
                    __tmp110.Append(CSharpName(cst, model, ClassKind.ImmutableInstance));
                    using(StreamReader __tmp110Reader = new StreamReader(this.__ToStream(__tmp110.ToString())))
                    {
                        bool __tmp110_last = __tmp110Reader.EndOfStream;
                        while(!__tmp110_last)
                        {
                            string __tmp110_line = __tmp110Reader.ReadLine();
                            __tmp110_last = __tmp110Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp108Prefix))
                            {
                                __out.Append(__tmp108Prefix);
                                __tmp109_outputWritten = true;
                            }
                            if ((__tmp110_last && !string.IsNullOrEmpty(__tmp110_line)) || (!__tmp110_last && __tmp110_line != null))
                            {
                                __out.Append(__tmp110_line);
                                __tmp109_outputWritten = true;
                            }
                            if (!__tmp110_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp111_line = " = "; //151:55
                    if (!string.IsNullOrEmpty(__tmp111_line))
                    {
                        __out.Append(__tmp111_line);
                        __tmp109_outputWritten = true;
                    }
                    StringBuilder __tmp112 = new StringBuilder();
                    __tmp112.Append(CSharpName(cst, model, ClassKind.BuilderInstance, true));
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
                                __tmp109_outputWritten = true;
                            }
                            if (!__tmp112_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp113_line = ".ToImmutable(Model);"; //151:114
                    if (!string.IsNullOrEmpty(__tmp113_line))
                    {
                        __out.Append(__tmp113_line);
                        __tmp109_outputWritten = true;
                    }
                    if (__tmp109_outputWritten) __out.AppendLine(true);
                    if (__tmp109_outputWritten)
                    {
                        __out.AppendLine(false); //151:134
                    }
                }
            }
            __out.AppendLine(true); //154:1
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //155:9
                from cls in __Enumerate((__loop11_var1).GetEnumerator()).OfType<MetaClass>() //155:39
                select new { __loop11_var1 = __loop11_var1, cls = cls}
                ).ToList(); //155:4
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp114 = __loop11_results[__loop11_iteration];
                var __loop11_var1 = __tmp114.__loop11_var1;
                var cls = __tmp114.cls;
                bool __tmp116_outputWritten = false;
                string __tmp115Prefix = "		"; //156:1
                StringBuilder __tmp117 = new StringBuilder();
                __tmp117.Append(CSharpName(cls, model, ClassKind.ImmutableInstance));
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
                        if (!__tmp117_last) __out.AppendLine(true);
                    }
                }
                string __tmp118_line = " = "; //156:55
                if (!string.IsNullOrEmpty(__tmp118_line))
                {
                    __out.Append(__tmp118_line);
                    __tmp116_outputWritten = true;
                }
                StringBuilder __tmp119 = new StringBuilder();
                __tmp119.Append(CSharpName(cls, model, ClassKind.BuilderInstance, true));
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
                            __tmp116_outputWritten = true;
                        }
                        if (!__tmp119_last) __out.AppendLine(true);
                    }
                }
                string __tmp120_line = ".ToImmutable(Model);"; //156:114
                if (!string.IsNullOrEmpty(__tmp120_line))
                {
                    __out.Append(__tmp120_line);
                    __tmp116_outputWritten = true;
                }
                if (__tmp116_outputWritten) __out.AppendLine(true);
                if (__tmp116_outputWritten)
                {
                    __out.AppendLine(false); //156:134
                }
                var __loop12_results = 
                    (from __loop12_var1 in __Enumerate((cls).GetEnumerator()) //157:10
                    from prop in __Enumerate((__loop12_var1.Properties).GetEnumerator()) //157:15
                    select new { __loop12_var1 = __loop12_var1, prop = prop}
                    ).ToList(); //157:5
                for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
                {
                    var __tmp121 = __loop12_results[__loop12_iteration];
                    var __loop12_var1 = __tmp121.__loop12_var1;
                    var prop = __tmp121.prop;
                    bool __tmp123_outputWritten = false;
                    string __tmp122Prefix = "		"; //158:1
                    StringBuilder __tmp124 = new StringBuilder();
                    __tmp124.Append(CSharpName(prop, model, PropertyKind.ImmutableInstance));
                    using(StreamReader __tmp124Reader = new StreamReader(this.__ToStream(__tmp124.ToString())))
                    {
                        bool __tmp124_last = __tmp124Reader.EndOfStream;
                        while(!__tmp124_last)
                        {
                            string __tmp124_line = __tmp124Reader.ReadLine();
                            __tmp124_last = __tmp124Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp122Prefix))
                            {
                                __out.Append(__tmp122Prefix);
                                __tmp123_outputWritten = true;
                            }
                            if ((__tmp124_last && !string.IsNullOrEmpty(__tmp124_line)) || (!__tmp124_last && __tmp124_line != null))
                            {
                                __out.Append(__tmp124_line);
                                __tmp123_outputWritten = true;
                            }
                            if (!__tmp124_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp125_line = " = "; //158:59
                    if (!string.IsNullOrEmpty(__tmp125_line))
                    {
                        __out.Append(__tmp125_line);
                        __tmp123_outputWritten = true;
                    }
                    StringBuilder __tmp126 = new StringBuilder();
                    __tmp126.Append(CSharpName(prop, model, PropertyKind.BuilderInstance, true));
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
                                __tmp123_outputWritten = true;
                            }
                            if (!__tmp126_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp127_line = ".ToImmutable(Model);"; //158:122
                    if (!string.IsNullOrEmpty(__tmp127_line))
                    {
                        __out.Append(__tmp127_line);
                        __tmp123_outputWritten = true;
                    }
                    if (__tmp123_outputWritten) __out.AppendLine(true);
                    if (__tmp123_outputWritten)
                    {
                        __out.AppendLine(false); //158:142
                    }
                }
            }
            __out.AppendLine(true); //161:1
            bool __tmp129_outputWritten = false;
            string __tmp128Prefix = "		"; //162:1
            StringBuilder __tmp130 = new StringBuilder();
            __tmp130.Append(CSharpName(model, ModelKind.ImmutableInstance));
            using(StreamReader __tmp130Reader = new StreamReader(this.__ToStream(__tmp130.ToString())))
            {
                bool __tmp130_last = __tmp130Reader.EndOfStream;
                while(!__tmp130_last)
                {
                    string __tmp130_line = __tmp130Reader.ReadLine();
                    __tmp130_last = __tmp130Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp128Prefix))
                    {
                        __out.Append(__tmp128Prefix);
                        __tmp129_outputWritten = true;
                    }
                    if ((__tmp130_last && !string.IsNullOrEmpty(__tmp130_line)) || (!__tmp130_last && __tmp130_line != null))
                    {
                        __out.Append(__tmp130_line);
                        __tmp129_outputWritten = true;
                    }
                    if (!__tmp130_last) __out.AppendLine(true);
                }
            }
            string __tmp131_line = ".initialized = true;"; //162:50
            if (!string.IsNullOrEmpty(__tmp131_line))
            {
                __out.Append(__tmp131_line);
                __tmp129_outputWritten = true;
            }
            if (__tmp129_outputWritten) __out.AppendLine(true);
            if (__tmp129_outputWritten)
            {
                __out.AppendLine(false); //162:70
            }
            __out.Append("	}"); //163:1
            __out.AppendLine(false); //163:3
            __out.Append("}"); //164:1
            __out.AppendLine(false); //164:2
            return __out.ToString();
        }

        public string GenerateMetaModelBuilderInstance(MetaModel model) //167:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //168:2
            bool metaMetaModel = IsMetaMetaModel(model); //169:2
            ImmutableList<ImmutableSymbol> symbolList = GetSymbolInstances(model); //170:2
            ImmutableDictionary<ImmutableSymbol,string> symbolNames = GetSymbolInstanceNames(model); //171:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //172:1
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
                __out.AppendLine(false); //172:61
            }
            __out.Append("{"); //173:1
            __out.AppendLine(false); //173:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	internal static "; //174:1
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
            string __tmp9_line = " instance = new "; //174:63
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
            string __tmp11_line = "();"; //174:124
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Append(__tmp11_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //174:127
            }
            __out.AppendLine(true); //175:1
            __out.Append("	private bool creating;"); //176:1
            __out.AppendLine(false); //176:24
            __out.Append("	private bool created;"); //177:1
            __out.AppendLine(false); //177:23
            if (metaMetaModel) //178:3
            {
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "	internal "; //179:1
                if (!string.IsNullOrEmpty(__tmp14_line))
                {
                    __out.Append(__tmp14_line);
                    __tmp13_outputWritten = true;
                }
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(metaNs);
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
                string __tmp16_line = "MetaModelBuilder MetaMetaModel;"; //179:19
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Append(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //179:50
                }
            }
            else //180:3
            {
                bool __tmp18_outputWritten = false;
                string __tmp19_line = "	internal "; //181:1
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Append(__tmp19_line);
                    __tmp18_outputWritten = true;
                }
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(metaNs);
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
                string __tmp21_line = "MetaModelBuilder MetaModel;"; //181:19
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp18_outputWritten = true;
                }
                if (__tmp18_outputWritten) __out.AppendLine(true);
                if (__tmp18_outputWritten)
                {
                    __out.AppendLine(false); //181:46
                }
            }
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	internal "; //183:1
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
            string __tmp26_line = ".MutableModel Model;"; //183:30
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //183:50
            }
            if (!metaMetaModel) //184:3
            {
                bool __tmp28_outputWritten = false;
                string __tmp29_line = "	internal "; //185:1
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
                string __tmp31_line = ".MutableModelGroup ModelGroup;"; //185:30
                if (!string.IsNullOrEmpty(__tmp31_line))
                {
                    __out.Append(__tmp31_line);
                    __tmp28_outputWritten = true;
                }
                if (__tmp28_outputWritten) __out.AppendLine(true);
                if (__tmp28_outputWritten)
                {
                    __out.AppendLine(false); //185:60
                }
            }
            __out.AppendLine(true); //187:1
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //188:8
                from cst in __Enumerate((__loop13_var1).GetEnumerator()).OfType<MetaConstant>() //188:38
                select new { __loop13_var1 = __loop13_var1, cst = cst}
                ).ToList(); //188:3
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp32 = __loop13_results[__loop13_iteration];
                var __loop13_var1 = __tmp32.__loop13_var1;
                var cst = __tmp32.cst;
                bool __tmp34_outputWritten = false;
                string __tmp33Prefix = "	"; //189:1
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(GenerateDocumentation(cst));
                using(StreamReader __tmp35Reader = new StreamReader(this.__ToStream(__tmp35.ToString())))
                {
                    bool __tmp35_last = __tmp35Reader.EndOfStream;
                    while(!__tmp35_last)
                    {
                        string __tmp35_line = __tmp35Reader.ReadLine();
                        __tmp35_last = __tmp35Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp33Prefix))
                        {
                            __out.Append(__tmp33Prefix);
                            __tmp34_outputWritten = true;
                        }
                        if ((__tmp35_last && !string.IsNullOrEmpty(__tmp35_line)) || (!__tmp35_last && __tmp35_line != null))
                        {
                            __out.Append(__tmp35_line);
                            __tmp34_outputWritten = true;
                        }
                        if (!__tmp35_last || __tmp34_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp34_outputWritten)
                {
                    __out.AppendLine(false); //189:30
                }
                if (metaMetaModel) //190:4
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "	internal "; //191:1
                    if (!string.IsNullOrEmpty(__tmp38_line))
                    {
                        __out.Append(__tmp38_line);
                        __tmp37_outputWritten = true;
                    }
                    StringBuilder __tmp39 = new StringBuilder();
                    __tmp39.Append(CSharpName(cst.Type, model, ClassKind.Builder));
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
                    string __tmp40_line = " "; //191:58
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Append(__tmp40_line);
                        __tmp37_outputWritten = true;
                    }
                    StringBuilder __tmp41 = new StringBuilder();
                    __tmp41.Append(CSharpName(cst, model, ClassKind.BuilderInstance));
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
                    string __tmp42_line = " = null;"; //191:109
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Append(__tmp42_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //191:117
                    }
                }
                else //192:4
                {
                    bool __tmp44_outputWritten = false;
                    string __tmp45_line = "	internal "; //193:1
                    if (!string.IsNullOrEmpty(__tmp45_line))
                    {
                        __out.Append(__tmp45_line);
                        __tmp44_outputWritten = true;
                    }
                    StringBuilder __tmp46 = new StringBuilder();
                    __tmp46.Append(CSharpName(cst.Type, model, ClassKind.Builder, true));
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
                    string __tmp47_line = " "; //193:64
                    if (!string.IsNullOrEmpty(__tmp47_line))
                    {
                        __out.Append(__tmp47_line);
                        __tmp44_outputWritten = true;
                    }
                    StringBuilder __tmp48 = new StringBuilder();
                    __tmp48.Append(CSharpName(cst, model, ClassKind.BuilderInstance));
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
                    string __tmp49_line = " = null;"; //193:115
                    if (!string.IsNullOrEmpty(__tmp49_line))
                    {
                        __out.Append(__tmp49_line);
                        __tmp44_outputWritten = true;
                    }
                    if (__tmp44_outputWritten) __out.AppendLine(true);
                    if (__tmp44_outputWritten)
                    {
                        __out.AppendLine(false); //193:123
                    }
                }
            }
            __out.AppendLine(true); //196:1
            var __loop14_results = 
                (from symbol in __Enumerate((symbolList).GetEnumerator()) //197:8
                select new { symbol = symbol}
                ).ToList(); //197:3
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp50 = __loop14_results[__loop14_iteration];
                var symbol = __tmp50.symbol;
                bool __tmp52_outputWritten = false;
                string __tmp51Prefix = "	"; //198:1
                StringBuilder __tmp53 = new StringBuilder();
                __tmp53.Append(GenerateSymbolInstanceDeclaration(model, metaMetaModel, symbol, symbolNames));
                using(StreamReader __tmp53Reader = new StreamReader(this.__ToStream(__tmp53.ToString())))
                {
                    bool __tmp53_last = __tmp53Reader.EndOfStream;
                    while(!__tmp53_last)
                    {
                        string __tmp53_line = __tmp53Reader.ReadLine();
                        __tmp53_last = __tmp53Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp51Prefix))
                        {
                            __out.Append(__tmp51Prefix);
                            __tmp52_outputWritten = true;
                        }
                        if ((__tmp53_last && !string.IsNullOrEmpty(__tmp53_line)) || (!__tmp53_last && __tmp53_line != null))
                        {
                            __out.Append(__tmp53_line);
                            __tmp52_outputWritten = true;
                        }
                        if (!__tmp53_last || __tmp52_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp52_outputWritten)
                {
                    __out.AppendLine(false); //198:80
                }
            }
            __out.AppendLine(true); //200:1
            bool __tmp55_outputWritten = false;
            string __tmp56_line = "	internal "; //201:1
            if (!string.IsNullOrEmpty(__tmp56_line))
            {
                __out.Append(__tmp56_line);
                __tmp55_outputWritten = true;
            }
            StringBuilder __tmp57 = new StringBuilder();
            __tmp57.Append(CSharpName(model, ModelKind.BuilderInstance));
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
            string __tmp58_line = "()"; //201:56
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Append(__tmp58_line);
                __tmp55_outputWritten = true;
            }
            if (__tmp55_outputWritten) __out.AppendLine(true);
            if (__tmp55_outputWritten)
            {
                __out.AppendLine(false); //201:58
            }
            __out.Append("	{"); //202:1
            __out.AppendLine(false); //202:3
            if (metaMetaModel) //203:4
            {
                bool __tmp60_outputWritten = false;
                string __tmp61_line = "		this.Model = new "; //204:1
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
                string __tmp63_line = ".MutableModel(\"MetaDslx.Modeling\");"; //204:39
                if (!string.IsNullOrEmpty(__tmp63_line))
                {
                    __out.Append(__tmp63_line);
                    __tmp60_outputWritten = true;
                }
                if (__tmp60_outputWritten) __out.AppendLine(true);
                if (__tmp60_outputWritten)
                {
                    __out.AppendLine(false); //204:74
                }
            }
            else //205:4
            {
                bool __tmp65_outputWritten = false;
                string __tmp66_line = "		this.ModelGroup = new "; //206:1
                if (!string.IsNullOrEmpty(__tmp66_line))
                {
                    __out.Append(__tmp66_line);
                    __tmp65_outputWritten = true;
                }
                StringBuilder __tmp67 = new StringBuilder();
                __tmp67.Append(Properties.CoreNs);
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
                string __tmp68_line = ".MutableModelGroup();"; //206:44
                if (!string.IsNullOrEmpty(__tmp68_line))
                {
                    __out.Append(__tmp68_line);
                    __tmp65_outputWritten = true;
                }
                if (__tmp65_outputWritten) __out.AppendLine(true);
                if (__tmp65_outputWritten)
                {
                    __out.AppendLine(false); //206:65
                }
                bool __tmp70_outputWritten = false;
                string __tmp71_line = "		this.ModelGroup.AddReference("; //207:1
                if (!string.IsNullOrEmpty(__tmp71_line))
                {
                    __out.Append(__tmp71_line);
                    __tmp70_outputWritten = true;
                }
                StringBuilder __tmp72 = new StringBuilder();
                __tmp72.Append(Properties.MetaNs);
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
                string __tmp73_line = ".MetaInstance.Model.ToMutable(true));"; //207:51
                if (!string.IsNullOrEmpty(__tmp73_line))
                {
                    __out.Append(__tmp73_line);
                    __tmp70_outputWritten = true;
                }
                if (__tmp70_outputWritten) __out.AppendLine(true);
                if (__tmp70_outputWritten)
                {
                    __out.AppendLine(false); //207:88
                }
                bool __tmp75_outputWritten = false;
                string __tmp76_line = "		this.Model = this.ModelGroup.CreateModel(\""; //208:1
                if (!string.IsNullOrEmpty(__tmp76_line))
                {
                    __out.Append(__tmp76_line);
                    __tmp75_outputWritten = true;
                }
                StringBuilder __tmp77 = new StringBuilder();
                __tmp77.Append(CSharpName(model));
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
                            __tmp75_outputWritten = true;
                        }
                        if (!__tmp77_last) __out.AppendLine(true);
                    }
                }
                string __tmp78_line = "\");"; //208:65
                if (!string.IsNullOrEmpty(__tmp78_line))
                {
                    __out.Append(__tmp78_line);
                    __tmp75_outputWritten = true;
                }
                if (__tmp75_outputWritten) __out.AppendLine(true);
                if (__tmp75_outputWritten)
                {
                    __out.AppendLine(false); //208:68
                }
            }
            __out.Append("	}"); //210:1
            __out.AppendLine(false); //210:3
            __out.AppendLine(true); //211:1
            __out.Append("	internal void Create()"); //212:1
            __out.AppendLine(false); //212:24
            __out.Append("	{"); //213:1
            __out.AppendLine(false); //213:3
            __out.Append("		lock (this)"); //214:1
            __out.AppendLine(false); //214:14
            __out.Append("		{"); //215:1
            __out.AppendLine(false); //215:4
            __out.Append("			if (this.creating || this.created) return;"); //216:1
            __out.AppendLine(false); //216:46
            __out.Append("			this.creating = true;"); //217:1
            __out.AppendLine(false); //217:25
            __out.Append("		}"); //218:1
            __out.AppendLine(false); //218:4
            bool __tmp80_outputWritten = false;
            string __tmp79Prefix = "		"; //219:1
            StringBuilder __tmp81 = new StringBuilder();
            __tmp81.Append(CSharpName(model, ModelKind.ImplementationProvider));
            using(StreamReader __tmp81Reader = new StreamReader(this.__ToStream(__tmp81.ToString())))
            {
                bool __tmp81_last = __tmp81Reader.EndOfStream;
                while(!__tmp81_last)
                {
                    string __tmp81_line = __tmp81Reader.ReadLine();
                    __tmp81_last = __tmp81Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp79Prefix))
                    {
                        __out.Append(__tmp79Prefix);
                        __tmp80_outputWritten = true;
                    }
                    if ((__tmp81_last && !string.IsNullOrEmpty(__tmp81_line)) || (!__tmp81_last && __tmp81_line != null))
                    {
                        __out.Append(__tmp81_line);
                        __tmp80_outputWritten = true;
                    }
                    if (!__tmp81_last) __out.AppendLine(true);
                }
            }
            string __tmp82_line = ".Implementation."; //219:55
            if (!string.IsNullOrEmpty(__tmp82_line))
            {
                __out.Append(__tmp82_line);
                __tmp80_outputWritten = true;
            }
            StringBuilder __tmp83 = new StringBuilder();
            __tmp83.Append(CSharpName(model, ModelKind.BuilderInstance));
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
                        __tmp80_outputWritten = true;
                    }
                    if (!__tmp83_last) __out.AppendLine(true);
                }
            }
            string __tmp84_line = "(this);"; //219:116
            if (!string.IsNullOrEmpty(__tmp84_line))
            {
                __out.Append(__tmp84_line);
                __tmp80_outputWritten = true;
            }
            if (__tmp80_outputWritten) __out.AppendLine(true);
            if (__tmp80_outputWritten)
            {
                __out.AppendLine(false); //219:123
            }
            __out.Append("		this.CreateSymbols();"); //220:1
            __out.AppendLine(false); //220:24
            __out.Append("		lock (this)"); //221:1
            __out.AppendLine(false); //221:14
            __out.Append("		{"); //222:1
            __out.AppendLine(false); //222:4
            __out.Append("			this.created = true;"); //223:1
            __out.AppendLine(false); //223:24
            __out.Append("		}"); //224:1
            __out.AppendLine(false); //224:4
            __out.Append("	}"); //225:1
            __out.AppendLine(false); //225:3
            __out.AppendLine(true); //226:1
            __out.Append("	internal void EvaluateLazyValues()"); //227:1
            __out.AppendLine(false); //227:36
            __out.Append("	{"); //228:1
            __out.AppendLine(false); //228:3
            __out.Append("		if (!this.created) return;"); //229:1
            __out.AppendLine(false); //229:29
            __out.Append("		this.Model.EvaluateLazyValues();"); //230:1
            __out.AppendLine(false); //230:35
            __out.Append("	}"); //231:1
            __out.AppendLine(false); //231:3
            __out.AppendLine(true); //232:1
            __out.Append("	private void CreateSymbols()"); //233:1
            __out.AppendLine(false); //233:30
            __out.Append("	{"); //234:1
            __out.AppendLine(false); //234:3
            bool __tmp86_outputWritten = false;
            string __tmp85Prefix = "		"; //235:1
            StringBuilder __tmp87 = new StringBuilder();
            __tmp87.Append(Properties.MetaNs);
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
            string __tmp88_line = ".MetaFactory factory = new "; //235:22
            if (!string.IsNullOrEmpty(__tmp88_line))
            {
                __out.Append(__tmp88_line);
                __tmp86_outputWritten = true;
            }
            StringBuilder __tmp89 = new StringBuilder();
            __tmp89.Append(Properties.MetaNs);
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
            string __tmp90_line = ".MetaFactory(this.Model, "; //235:68
            if (!string.IsNullOrEmpty(__tmp90_line))
            {
                __out.Append(__tmp90_line);
                __tmp86_outputWritten = true;
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
                        __tmp86_outputWritten = true;
                    }
                    if (!__tmp91_last) __out.AppendLine(true);
                }
            }
            string __tmp92_line = ".ModelFactoryFlags.DontMakeSymbolsCreated);"; //235:112
            if (!string.IsNullOrEmpty(__tmp92_line))
            {
                __out.Append(__tmp92_line);
                __tmp86_outputWritten = true;
            }
            if (__tmp86_outputWritten) __out.AppendLine(true);
            if (__tmp86_outputWritten)
            {
                __out.AppendLine(false); //235:155
            }
            __out.AppendLine(true); //236:1
            var __loop15_results = 
                (from symbol in __Enumerate((symbolList).GetEnumerator()) //237:9
                select new { symbol = symbol}
                ).ToList(); //237:4
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                var __tmp93 = __loop15_results[__loop15_iteration];
                var symbol = __tmp93.symbol;
                bool __tmp95_outputWritten = false;
                string __tmp94Prefix = "		"; //238:1
                StringBuilder __tmp96 = new StringBuilder();
                __tmp96.Append(GenerateSymbolInstance(model, metaMetaModel, symbol, symbolNames));
                using(StreamReader __tmp96Reader = new StreamReader(this.__ToStream(__tmp96.ToString())))
                {
                    bool __tmp96_last = __tmp96Reader.EndOfStream;
                    while(!__tmp96_last)
                    {
                        string __tmp96_line = __tmp96Reader.ReadLine();
                        __tmp96_last = __tmp96Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp94Prefix))
                        {
                            __out.Append(__tmp94Prefix);
                            __tmp95_outputWritten = true;
                        }
                        if ((__tmp96_last && !string.IsNullOrEmpty(__tmp96_line)) || (!__tmp96_last && __tmp96_line != null))
                        {
                            __out.Append(__tmp96_line);
                            __tmp95_outputWritten = true;
                        }
                        if (!__tmp96_last || __tmp95_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //238:70
                }
            }
            __out.AppendLine(true); //240:1
            var __loop16_results = 
                (from symbol in __Enumerate((symbolList).GetEnumerator()) //241:9
                select new { symbol = symbol}
                ).ToList(); //241:4
            for (int __loop16_iteration = 0; __loop16_iteration < __loop16_results.Count; ++__loop16_iteration)
            {
                var __tmp97 = __loop16_results[__loop16_iteration];
                var symbol = __tmp97.symbol;
                bool __tmp99_outputWritten = false;
                string __tmp98Prefix = "		"; //242:1
                StringBuilder __tmp100 = new StringBuilder();
                __tmp100.Append(GenerateSymbolInstanceProperties(model, metaMetaModel, symbol, symbolNames));
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
                        if (!__tmp100_last || __tmp99_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp99_outputWritten)
                {
                    __out.AppendLine(false); //242:80
                }
            }
            __out.AppendLine(true); //244:1
            __out.Append("		foreach (global::MetaDslx.Modeling.MutableSymbol symbol in this.Model.Symbols)"); //245:1
            __out.AppendLine(false); //245:81
            __out.Append("		{"); //246:1
            __out.AppendLine(false); //246:4
            __out.Append("			symbol.MMakeCreated();"); //247:1
            __out.AppendLine(false); //247:26
            __out.Append("		}"); //248:1
            __out.AppendLine(false); //248:4
            __out.Append("	}"); //249:1
            __out.AppendLine(false); //249:3
            __out.Append("}"); //250:1
            __out.AppendLine(false); //250:2
            return __out.ToString();
        }

        public string GenerateSymbolInstanceDeclaration(MetaModel model, bool metaMetaModel, ImmutableSymbol symbol, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //253:1
        {
            StringBuilder __out = new StringBuilder();
            if (symbol != null && symbol.MMetaClass != null && symbolNames.ContainsKey(symbol)) //254:2
            {
                string name = symbolNames[symbol]; //255:3
                if (metaMetaModel) //256:3
                {
                    if (name.StartsWith("__")) //257:4
                    {
                        bool __tmp2_outputWritten = false;
                        string __tmp3_line = "private "; //258:1
                        if (!string.IsNullOrEmpty(__tmp3_line))
                        {
                            __out.Append(__tmp3_line);
                            __tmp2_outputWritten = true;
                        }
                        StringBuilder __tmp4 = new StringBuilder();
                        __tmp4.Append(CSharpName(symbol.MMetaClass, model, ClassKind.Builder));
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
                        string __tmp5_line = " "; //258:65
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
                        string __tmp7_line = ";"; //258:72
                        if (!string.IsNullOrEmpty(__tmp7_line))
                        {
                            __out.Append(__tmp7_line);
                            __tmp2_outputWritten = true;
                        }
                        if (__tmp2_outputWritten) __out.AppendLine(true);
                        if (__tmp2_outputWritten)
                        {
                            __out.AppendLine(false); //258:73
                        }
                    }
                    else //259:4
                    {
                        bool __tmp9_outputWritten = false;
                        string __tmp10_line = "internal "; //260:1
                        if (!string.IsNullOrEmpty(__tmp10_line))
                        {
                            __out.Append(__tmp10_line);
                            __tmp9_outputWritten = true;
                        }
                        StringBuilder __tmp11 = new StringBuilder();
                        __tmp11.Append(CSharpName(symbol.MMetaClass, model, ClassKind.Builder));
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
                        string __tmp12_line = " "; //260:66
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
                        string __tmp14_line = ";"; //260:73
                        if (!string.IsNullOrEmpty(__tmp14_line))
                        {
                            __out.Append(__tmp14_line);
                            __tmp9_outputWritten = true;
                        }
                        if (__tmp9_outputWritten) __out.AppendLine(true);
                        if (__tmp9_outputWritten)
                        {
                            __out.AppendLine(false); //260:74
                        }
                    }
                }
                else //262:3
                {
                    if (name.StartsWith("__")) //263:4
                    {
                        bool __tmp16_outputWritten = false;
                        string __tmp17_line = "private "; //264:1
                        if (!string.IsNullOrEmpty(__tmp17_line))
                        {
                            __out.Append(__tmp17_line);
                            __tmp16_outputWritten = true;
                        }
                        StringBuilder __tmp18 = new StringBuilder();
                        __tmp18.Append(CSharpName(symbol.MMetaClass, model, ClassKind.Builder, true));
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
                        string __tmp19_line = " "; //264:71
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
                        string __tmp21_line = ";"; //264:78
                        if (!string.IsNullOrEmpty(__tmp21_line))
                        {
                            __out.Append(__tmp21_line);
                            __tmp16_outputWritten = true;
                        }
                        if (__tmp16_outputWritten) __out.AppendLine(true);
                        if (__tmp16_outputWritten)
                        {
                            __out.AppendLine(false); //264:79
                        }
                    }
                    else //265:4
                    {
                        bool __tmp23_outputWritten = false;
                        string __tmp24_line = "internal "; //266:1
                        if (!string.IsNullOrEmpty(__tmp24_line))
                        {
                            __out.Append(__tmp24_line);
                            __tmp23_outputWritten = true;
                        }
                        StringBuilder __tmp25 = new StringBuilder();
                        __tmp25.Append(CSharpName(symbol.MMetaClass, model, ClassKind.Builder, true));
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
                        string __tmp26_line = " "; //266:72
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
                        string __tmp28_line = ";"; //266:79
                        if (!string.IsNullOrEmpty(__tmp28_line))
                        {
                            __out.Append(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                        if (__tmp23_outputWritten) __out.AppendLine(true);
                        if (__tmp23_outputWritten)
                        {
                            __out.AppendLine(false); //266:80
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateSymbolInstance(MetaModel model, bool metaMetaModel, ImmutableSymbol symbol, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //272:1
        {
            StringBuilder __out = new StringBuilder();
            if (symbol != null && symbol.MMetaClass != null && symbolNames.ContainsKey(symbol)) //273:2
            {
                string name = symbolNames[symbol]; //274:3
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
                string __tmp4_line = " = factory."; //275:7
                if (!string.IsNullOrEmpty(__tmp4_line))
                {
                    __out.Append(__tmp4_line);
                    __tmp2_outputWritten = true;
                }
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(CSharpName(symbol.MMetaClass, model, ClassKind.Immutable));
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
                string __tmp6_line = "();"; //275:76
                if (!string.IsNullOrEmpty(__tmp6_line))
                {
                    __out.Append(__tmp6_line);
                    __tmp2_outputWritten = true;
                }
                if (__tmp2_outputWritten) __out.AppendLine(true);
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //275:79
                }
                if (symbol is MetaModel) //276:3
                {
                    if (metaMetaModel) //277:4
                    {
                        bool __tmp8_outputWritten = false;
                        string __tmp9_line = "MetaMetaModel = "; //278:1
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
                        string __tmp11_line = ";"; //278:23
                        if (!string.IsNullOrEmpty(__tmp11_line))
                        {
                            __out.Append(__tmp11_line);
                            __tmp8_outputWritten = true;
                        }
                        if (__tmp8_outputWritten) __out.AppendLine(true);
                        if (__tmp8_outputWritten)
                        {
                            __out.AppendLine(false); //278:24
                        }
                    }
                    else //279:4
                    {
                        bool __tmp13_outputWritten = false;
                        string __tmp14_line = "MetaModel = "; //280:1
                        if (!string.IsNullOrEmpty(__tmp14_line))
                        {
                            __out.Append(__tmp14_line);
                            __tmp13_outputWritten = true;
                        }
                        StringBuilder __tmp15 = new StringBuilder();
                        __tmp15.Append(name);
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
                        string __tmp16_line = ";"; //280:19
                        if (!string.IsNullOrEmpty(__tmp16_line))
                        {
                            __out.Append(__tmp16_line);
                            __tmp13_outputWritten = true;
                        }
                        if (__tmp13_outputWritten) __out.AppendLine(true);
                        if (__tmp13_outputWritten)
                        {
                            __out.AppendLine(false); //280:20
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateSymbolInstanceProperties(MetaModel model, bool metaMetaModel, ImmutableSymbol symbol, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //286:1
        {
            StringBuilder __out = new StringBuilder();
            if (symbol != null && symbol.MMetaClass != null && symbolNames.ContainsKey(symbol)) //287:2
            {
                var __loop17_results = 
                    (from __loop17_var1 in __Enumerate((symbol).GetEnumerator()) //288:8
                    from prop in __Enumerate((__loop17_var1.MProperties).GetEnumerator()) //288:16
                    where !prop.IsDerived && !prop.IsDerivedUnion //288:33
                    select new { __loop17_var1 = __loop17_var1, prop = prop}
                    ).ToList(); //288:3
                for (int __loop17_iteration = 0; __loop17_iteration < __loop17_results.Count; ++__loop17_iteration)
                {
                    var __tmp1 = __loop17_results[__loop17_iteration];
                    var __loop17_var1 = __tmp1.__loop17_var1;
                    var prop = __tmp1.prop;
                    object propValue = symbol.MGet(prop); //289:4
                    bool __tmp3_outputWritten = false;
                    StringBuilder __tmp4 = new StringBuilder();
                    __tmp4.Append(GenerateSymbolInstancePropertyValue(model, metaMetaModel, symbol, prop, propValue, symbolNames));
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
                        __out.AppendLine(false); //290:98
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateSymbolInstancePropertyValue(MetaModel model, bool metaMetaModel, ImmutableSymbol symbol, ModelProperty prop, object value, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //295:1
        {
            StringBuilder __out = new StringBuilder();
            string name = symbolNames[symbol]; //296:2
            ImmutableSymbol valueSymbol = value as ImmutableSymbol; //297:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //298:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //299:2
            if (value == null) //300:2
            {
                if (prop.MutableTypeInfo.Type != null && prop.MutableTypeInfo.Type.IsClass) //301:3
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
                    string __tmp4_line = "."; //302:7
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
                    string __tmp6_line = " = null;"; //302:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //302:27
                    }
                }
                else //303:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //304:1
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
                    string __tmp11_line = "."; //304:10
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
                    string __tmp13_line = " = null;"; //304:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Append(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //304:30
                    }
                }
            }
            else if (value is string) //306:2
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
                string __tmp17_line = "."; //307:7
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
                string __tmp19_line = " = \""; //307:19
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
                string __tmp21_line = "\";"; //307:50
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //307:52
                }
            }
            else if (value is bool) //308:2
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
                string __tmp25_line = "."; //309:7
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
                string __tmp27_line = " = "; //309:19
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
                string __tmp29_line = ";"; //309:50
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Append(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //309:51
                }
            }
            else if (value.GetType().IsPrimitive) //310:2
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
                string __tmp33_line = "."; //311:7
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
                string __tmp35_line = " = "; //311:19
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
                string __tmp37_line = ";"; //311:40
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //311:41
                }
            }
            else if (value is MetaAnnotation) //312:2
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
                string __tmp41_line = "."; //313:7
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
                string __tmp43_line = " = "; //313:19
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Append(__tmp43_line);
                    __tmp39_outputWritten = true;
                }
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(GetAttributeValueOf((MetaAnnotation)value));
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
                string __tmp45_line = ";"; //313:66
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Append(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //313:67
                }
            }
            else if (value is Enum) //314:2
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
                string __tmp49_line = "."; //315:7
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
                string __tmp51_line = " = "; //315:19
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Append(__tmp51_line);
                    __tmp47_outputWritten = true;
                }
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(GetEnumValueOf((Enum)value));
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
                string __tmp53_line = ";"; //315:51
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp47_outputWritten = true;
                }
                if (__tmp47_outputWritten) __out.AppendLine(true);
                if (__tmp47_outputWritten)
                {
                    __out.AppendLine(false); //315:52
                }
            }
            else if (value is MetaExternalType) //316:2
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
                string __tmp57_line = "."; //317:7
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
                string __tmp59_line = "Lazy = () => "; //317:19
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
                string __tmp61_line = ";"; //317:79
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Append(__tmp61_line);
                    __tmp55_outputWritten = true;
                }
                if (__tmp55_outputWritten) __out.AppendLine(true);
                if (__tmp55_outputWritten)
                {
                    __out.AppendLine(false); //317:80
                }
            }
            else if (value is MetaPrimitiveType) //318:2
            {
                if (metaMetaModel) //319:3
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
                    string __tmp65_line = "."; //320:7
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
                    string __tmp67_line = "Lazy = () => "; //320:19
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
                    string __tmp69_line = ";"; //320:80
                    if (!string.IsNullOrEmpty(__tmp69_line))
                    {
                        __out.Append(__tmp69_line);
                        __tmp63_outputWritten = true;
                    }
                    if (__tmp63_outputWritten) __out.AppendLine(true);
                    if (__tmp63_outputWritten)
                    {
                        __out.AppendLine(false); //320:81
                    }
                }
                else //321:3
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
                    string __tmp73_line = "."; //322:7
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
                    string __tmp75_line = "Lazy = () => "; //322:19
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
                    string __tmp77_line = ".ToMutable();"; //322:113
                    if (!string.IsNullOrEmpty(__tmp77_line))
                    {
                        __out.Append(__tmp77_line);
                        __tmp71_outputWritten = true;
                    }
                    if (__tmp71_outputWritten) __out.AppendLine(true);
                    if (__tmp71_outputWritten)
                    {
                        __out.AppendLine(false); //322:126
                    }
                }
            }
            else if (valueSymbol != null && symbolNames.ContainsKey(valueSymbol)) //324:2
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
                string __tmp81_line = "."; //325:7
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
                string __tmp83_line = "Lazy = () => "; //325:19
                if (!string.IsNullOrEmpty(__tmp83_line))
                {
                    __out.Append(__tmp83_line);
                    __tmp79_outputWritten = true;
                }
                StringBuilder __tmp84 = new StringBuilder();
                __tmp84.Append(symbolNames[valueSymbol]);
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
                string __tmp85_line = ";"; //325:58
                if (!string.IsNullOrEmpty(__tmp85_line))
                {
                    __out.Append(__tmp85_line);
                    __tmp79_outputWritten = true;
                }
                if (__tmp79_outputWritten) __out.AppendLine(true);
                if (__tmp79_outputWritten)
                {
                    __out.AppendLine(false); //325:59
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //326:2
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
                string __tmp89_line = "."; //327:7
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
                string __tmp91_line = "Lazy = () => "; //327:19
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
                string __tmp93_line = ";"; //327:100
                if (!string.IsNullOrEmpty(__tmp93_line))
                {
                    __out.Append(__tmp93_line);
                    __tmp87_outputWritten = true;
                }
                if (__tmp87_outputWritten) __out.AppendLine(true);
                if (__tmp87_outputWritten)
                {
                    __out.AppendLine(false); //327:101
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //328:2
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
                string __tmp97_line = "."; //329:7
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
                string __tmp99_line = "Lazy = () => "; //329:19
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
                string __tmp101_line = ";"; //329:104
                if (!string.IsNullOrEmpty(__tmp101_line))
                {
                    __out.Append(__tmp101_line);
                    __tmp95_outputWritten = true;
                }
                if (__tmp95_outputWritten) __out.AppendLine(true);
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //329:105
                }
            }
            else if (valueCollection != null) //330:2
            {
                var __loop18_results = 
                    (from cvalue in __Enumerate((valueCollection).GetEnumerator()) //331:8
                    select new { cvalue = cvalue}
                    ).ToList(); //331:3
                for (int __loop18_iteration = 0; __loop18_iteration < __loop18_results.Count; ++__loop18_iteration)
                {
                    var __tmp102 = __loop18_results[__loop18_iteration];
                    var cvalue = __tmp102.cvalue;
                    bool __tmp104_outputWritten = false;
                    StringBuilder __tmp105 = new StringBuilder();
                    __tmp105.Append(GenerateSymbolInstancePropertyCollectionValue(model, metaMetaModel, symbol, prop, cvalue, symbolNames));
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
                        __out.AppendLine(false); //332:105
                    }
                }
            }
            else //334:2
            {
                bool __tmp107_outputWritten = false;
                string __tmp108_line = "// TODO: "; //335:1
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
                string __tmp110_line = "."; //335:16
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
                    __out.AppendLine(false); //335:28
                }
            }
            return __out.ToString();
        }

        public string GenerateSymbolInstancePropertyCollectionValue(MetaModel model, bool metaMetaModel, ImmutableSymbol symbol, ModelProperty prop, object value, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //339:1
        {
            StringBuilder __out = new StringBuilder();
            string name = symbolNames[symbol]; //340:2
            ImmutableSymbol valueSymbol = value as ImmutableSymbol; //341:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //342:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //343:2
            if (value == null) //344:2
            {
                if (prop.MutableTypeInfo.Type != null && prop.MutableTypeInfo.Type.IsClass) //345:3
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
                    string __tmp4_line = "."; //346:7
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
                    string __tmp6_line = ".Add(null);"; //346:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //346:30
                    }
                }
                else //347:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //348:1
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
                    string __tmp11_line = "."; //348:10
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
                    string __tmp13_line = ".Add(null);"; //348:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Append(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //348:33
                    }
                }
            }
            else if (value is string) //350:2
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
                string __tmp17_line = "."; //351:7
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
                string __tmp19_line = ".Add(\""; //351:19
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
                string __tmp21_line = "\");"; //351:52
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //351:55
                }
            }
            else if (value is bool) //352:2
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
                string __tmp25_line = "."; //353:7
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
                string __tmp27_line = ".Add("; //353:19
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
                string __tmp29_line = ");"; //353:52
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Append(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //353:54
                }
            }
            else if (value.GetType().IsPrimitive) //354:2
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
                string __tmp33_line = "."; //355:7
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
                string __tmp35_line = ".Add("; //355:19
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
                string __tmp37_line = ");"; //355:42
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //355:44
                }
            }
            else if (value is MetaAnnotation) //356:2
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
                string __tmp41_line = "."; //357:7
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
                string __tmp43_line = ".Add("; //357:19
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Append(__tmp43_line);
                    __tmp39_outputWritten = true;
                }
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(GetAttributeValueOf((MetaAnnotation)value));
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
                string __tmp45_line = ");"; //357:68
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Append(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //357:70
                }
            }
            else if (value is Enum) //358:2
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
                string __tmp49_line = "."; //359:7
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
                string __tmp51_line = ".Add("; //359:19
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Append(__tmp51_line);
                    __tmp47_outputWritten = true;
                }
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(GetEnumValueOf((Enum)value));
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
                string __tmp53_line = ");"; //359:53
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp47_outputWritten = true;
                }
                if (__tmp47_outputWritten) __out.AppendLine(true);
                if (__tmp47_outputWritten)
                {
                    __out.AppendLine(false); //359:55
                }
            }
            else if (value is MetaExternalType) //360:2
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
                string __tmp57_line = "."; //361:7
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
                string __tmp59_line = ".AddLazy(() => "; //361:19
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
                string __tmp61_line = ");"; //361:81
                if (!string.IsNullOrEmpty(__tmp61_line))
                {
                    __out.Append(__tmp61_line);
                    __tmp55_outputWritten = true;
                }
                if (__tmp55_outputWritten) __out.AppendLine(true);
                if (__tmp55_outputWritten)
                {
                    __out.AppendLine(false); //361:83
                }
            }
            else if (value is MetaPrimitiveType) //362:2
            {
                if (metaMetaModel) //363:3
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
                    string __tmp65_line = "."; //364:7
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
                    string __tmp67_line = ".AddLazy(() => "; //364:19
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
                    string __tmp69_line = ");"; //364:82
                    if (!string.IsNullOrEmpty(__tmp69_line))
                    {
                        __out.Append(__tmp69_line);
                        __tmp63_outputWritten = true;
                    }
                    if (__tmp63_outputWritten) __out.AppendLine(true);
                    if (__tmp63_outputWritten)
                    {
                        __out.AppendLine(false); //364:84
                    }
                }
                else //365:3
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
                    string __tmp73_line = "."; //366:7
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
                    string __tmp75_line = ".AddLazy(() => "; //366:19
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
                    string __tmp77_line = ".ToMutable());"; //366:115
                    if (!string.IsNullOrEmpty(__tmp77_line))
                    {
                        __out.Append(__tmp77_line);
                        __tmp71_outputWritten = true;
                    }
                    if (__tmp71_outputWritten) __out.AppendLine(true);
                    if (__tmp71_outputWritten)
                    {
                        __out.AppendLine(false); //366:129
                    }
                }
            }
            else if (valueSymbol != null && symbolNames.ContainsKey(valueSymbol)) //368:2
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
                string __tmp81_line = "."; //369:7
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
                string __tmp83_line = ".AddLazy(() => "; //369:19
                if (!string.IsNullOrEmpty(__tmp83_line))
                {
                    __out.Append(__tmp83_line);
                    __tmp79_outputWritten = true;
                }
                StringBuilder __tmp84 = new StringBuilder();
                __tmp84.Append(symbolNames[valueSymbol]);
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
                string __tmp85_line = ");"; //369:60
                if (!string.IsNullOrEmpty(__tmp85_line))
                {
                    __out.Append(__tmp85_line);
                    __tmp79_outputWritten = true;
                }
                if (__tmp79_outputWritten) __out.AppendLine(true);
                if (__tmp79_outputWritten)
                {
                    __out.AppendLine(false); //369:62
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //370:2
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
                string __tmp89_line = "."; //371:7
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
                string __tmp91_line = ".AddLazy(() => "; //371:19
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
                string __tmp93_line = ");"; //371:102
                if (!string.IsNullOrEmpty(__tmp93_line))
                {
                    __out.Append(__tmp93_line);
                    __tmp87_outputWritten = true;
                }
                if (__tmp87_outputWritten) __out.AppendLine(true);
                if (__tmp87_outputWritten)
                {
                    __out.AppendLine(false); //371:104
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //372:2
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
                string __tmp97_line = "."; //373:7
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
                string __tmp99_line = ".AddLazy(() => "; //373:19
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
                string __tmp101_line = ");"; //373:106
                if (!string.IsNullOrEmpty(__tmp101_line))
                {
                    __out.Append(__tmp101_line);
                    __tmp95_outputWritten = true;
                }
                if (__tmp95_outputWritten) __out.AppendLine(true);
                if (__tmp95_outputWritten)
                {
                    __out.AppendLine(false); //373:108
                }
            }
            else //374:2
            {
                bool __tmp103_outputWritten = false;
                string __tmp104_line = "// TODO: "; //375:1
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
                string __tmp106_line = "."; //375:16
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
                    __out.AppendLine(false); //375:28
                }
            }
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //379:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //380:1
            __out.AppendLine(false); //380:14
            __out.Append("/// Factory class for creating instances of model elements."); //381:1
            __out.AppendLine(false); //381:60
            __out.Append("/// </summary>"); //382:1
            __out.AppendLine(false); //382:15
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //383:1
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
            string __tmp5_line = " : "; //383:51
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
            string __tmp7_line = ".ModelFactory"; //383:73
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //383:86
            }
            __out.Append("{"); //384:1
            __out.AppendLine(false); //384:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public "; //385:1
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
            string __tmp12_line = "("; //385:46
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
            string __tmp14_line = ".MutableModel model, "; //385:66
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
            string __tmp16_line = ".ModelFactoryFlags flags = "; //385:106
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
            string __tmp18_line = ".ModelFactoryFlags.None)"; //385:152
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Append(__tmp18_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //385:176
            }
            __out.Append("		: base(model, flags)"); //386:1
            __out.AppendLine(false); //386:23
            __out.Append("	{"); //387:1
            __out.AppendLine(false); //387:3
            bool __tmp20_outputWritten = false;
            string __tmp19Prefix = "		"; //388:1
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
            string __tmp22_line = ".Initialize();"; //388:43
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Append(__tmp22_line);
                __tmp20_outputWritten = true;
            }
            if (__tmp20_outputWritten) __out.AppendLine(true);
            if (__tmp20_outputWritten)
            {
                __out.AppendLine(false); //388:57
            }
            __out.Append("	}"); //389:1
            __out.AppendLine(false); //389:3
            __out.AppendLine(true); //390:1
            bool __tmp24_outputWritten = false;
            string __tmp25_line = "	public override "; //391:1
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
            string __tmp27_line = ".MutableSymbol Create(string type)"; //391:37
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Append(__tmp27_line);
                __tmp24_outputWritten = true;
            }
            if (__tmp24_outputWritten) __out.AppendLine(true);
            if (__tmp24_outputWritten)
            {
                __out.AppendLine(false); //391:71
            }
            __out.Append("	{"); //392:1
            __out.AppendLine(false); //392:3
            __out.Append("		switch (type)"); //393:1
            __out.AppendLine(false); //393:16
            __out.Append("		{"); //394:1
            __out.AppendLine(false); //394:4
            var __loop19_results = 
                (from __loop19_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //395:10
                from cls in __Enumerate((__loop19_var1).GetEnumerator()).OfType<MetaClass>() //395:40
                select new { __loop19_var1 = __loop19_var1, cls = cls}
                ).ToList(); //395:5
            for (int __loop19_iteration = 0; __loop19_iteration < __loop19_results.Count; ++__loop19_iteration)
            {
                var __tmp28 = __loop19_results[__loop19_iteration];
                var __loop19_var1 = __tmp28.__loop19_var1;
                var cls = __tmp28.cls;
                if (!cls.IsAbstract) //396:6
                {
                    bool __tmp30_outputWritten = false;
                    string __tmp31_line = "			case \""; //397:1
                    if (!string.IsNullOrEmpty(__tmp31_line))
                    {
                        __out.Append(__tmp31_line);
                        __tmp30_outputWritten = true;
                    }
                    StringBuilder __tmp32 = new StringBuilder();
                    __tmp32.Append(CSharpName(cls, model));
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
                    string __tmp33_line = "\": return this."; //397:33
                    if (!string.IsNullOrEmpty(__tmp33_line))
                    {
                        __out.Append(__tmp33_line);
                        __tmp30_outputWritten = true;
                    }
                    StringBuilder __tmp34 = new StringBuilder();
                    __tmp34.Append(CSharpName(cls, model));
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
                    string __tmp35_line = "();"; //397:71
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Append(__tmp35_line);
                        __tmp30_outputWritten = true;
                    }
                    if (__tmp30_outputWritten) __out.AppendLine(true);
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //397:74
                    }
                }
            }
            __out.Append("			default:"); //400:1
            __out.AppendLine(false); //400:12
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "				throw new "; //401:1
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Append(__tmp38_line);
                __tmp37_outputWritten = true;
            }
            StringBuilder __tmp39 = new StringBuilder();
            __tmp39.Append(Properties.CoreNs);
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
            string __tmp40_line = ".ModelException(global::Microsoft.CodeAnalysis.Location.None, new global::MetaDslx.CodeAnalysis.LanguageDiagnosticInfo("; //401:34
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Append(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            StringBuilder __tmp41 = new StringBuilder();
            __tmp41.Append(Properties.CoreNs);
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
            string __tmp42_line = ".ModelErrorCode.ERR_UnknownTypeName, type));"; //401:172
            if (!string.IsNullOrEmpty(__tmp42_line))
            {
                __out.Append(__tmp42_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //401:216
            }
            __out.Append("		}"); //402:1
            __out.AppendLine(false); //402:4
            __out.Append("	}"); //403:1
            __out.AppendLine(false); //403:3
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //404:8
                from cls in __Enumerate((__loop20_var1).GetEnumerator()).OfType<MetaClass>() //404:38
                select new { __loop20_var1 = __loop20_var1, cls = cls}
                ).ToList(); //404:3
            for (int __loop20_iteration = 0; __loop20_iteration < __loop20_results.Count; ++__loop20_iteration)
            {
                var __tmp43 = __loop20_results[__loop20_iteration];
                var __loop20_var1 = __tmp43.__loop20_var1;
                var cls = __tmp43.cls;
                if (!cls.IsAbstract) //405:4
                {
                    __out.AppendLine(true); //406:1
                    __out.Append("	/// <summary>"); //407:1
                    __out.AppendLine(false); //407:15
                    bool __tmp45_outputWritten = false;
                    string __tmp46_line = "	/// Creates a new instance of "; //408:1
                    if (!string.IsNullOrEmpty(__tmp46_line))
                    {
                        __out.Append(__tmp46_line);
                        __tmp45_outputWritten = true;
                    }
                    StringBuilder __tmp47 = new StringBuilder();
                    __tmp47.Append(CSharpName(cls, model));
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
                    string __tmp48_line = "."; //408:55
                    if (!string.IsNullOrEmpty(__tmp48_line))
                    {
                        __out.Append(__tmp48_line);
                        __tmp45_outputWritten = true;
                    }
                    if (__tmp45_outputWritten) __out.AppendLine(true);
                    if (__tmp45_outputWritten)
                    {
                        __out.AppendLine(false); //408:56
                    }
                    __out.Append("	/// </summary>"); //409:1
                    __out.AppendLine(false); //409:16
                    bool __tmp50_outputWritten = false;
                    string __tmp51_line = "	public "; //410:1
                    if (!string.IsNullOrEmpty(__tmp51_line))
                    {
                        __out.Append(__tmp51_line);
                        __tmp50_outputWritten = true;
                    }
                    StringBuilder __tmp52 = new StringBuilder();
                    __tmp52.Append(CSharpName(cls, model, ClassKind.Builder));
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
                    string __tmp53_line = " "; //410:51
                    if (!string.IsNullOrEmpty(__tmp53_line))
                    {
                        __out.Append(__tmp53_line);
                        __tmp50_outputWritten = true;
                    }
                    StringBuilder __tmp54 = new StringBuilder();
                    __tmp54.Append(CSharpName(cls, model, ClassKind.FactoryMethod));
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
                    string __tmp55_line = "()"; //410:100
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Append(__tmp55_line);
                        __tmp50_outputWritten = true;
                    }
                    if (__tmp50_outputWritten) __out.AppendLine(true);
                    if (__tmp50_outputWritten)
                    {
                        __out.AppendLine(false); //410:102
                    }
                    __out.Append("	{"); //411:1
                    __out.AppendLine(false); //411:3
                    bool __tmp57_outputWritten = false;
                    string __tmp56Prefix = "		"; //412:1
                    StringBuilder __tmp58 = new StringBuilder();
                    __tmp58.Append(Properties.CoreNs);
                    using(StreamReader __tmp58Reader = new StreamReader(this.__ToStream(__tmp58.ToString())))
                    {
                        bool __tmp58_last = __tmp58Reader.EndOfStream;
                        while(!__tmp58_last)
                        {
                            string __tmp58_line = __tmp58Reader.ReadLine();
                            __tmp58_last = __tmp58Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp56Prefix))
                            {
                                __out.Append(__tmp56Prefix);
                                __tmp57_outputWritten = true;
                            }
                            if ((__tmp58_last && !string.IsNullOrEmpty(__tmp58_line)) || (!__tmp58_last && __tmp58_line != null))
                            {
                                __out.Append(__tmp58_line);
                                __tmp57_outputWritten = true;
                            }
                            if (!__tmp58_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp59_line = ".MutableSymbol symbol = this.CreateSymbol(new "; //412:22
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Append(__tmp59_line);
                        __tmp57_outputWritten = true;
                    }
                    StringBuilder __tmp60 = new StringBuilder();
                    __tmp60.Append(CSharpName(cls, model, ClassKind.Id));
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
                                __tmp57_outputWritten = true;
                            }
                            if (!__tmp60_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp61_line = "());"; //412:105
                    if (!string.IsNullOrEmpty(__tmp61_line))
                    {
                        __out.Append(__tmp61_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //412:109
                    }
                    bool __tmp63_outputWritten = false;
                    string __tmp64_line = "		return ("; //413:1
                    if (!string.IsNullOrEmpty(__tmp64_line))
                    {
                        __out.Append(__tmp64_line);
                        __tmp63_outputWritten = true;
                    }
                    StringBuilder __tmp65 = new StringBuilder();
                    __tmp65.Append(CSharpName(cls, model, ClassKind.Builder));
                    using(StreamReader __tmp65Reader = new StreamReader(this.__ToStream(__tmp65.ToString())))
                    {
                        bool __tmp65_last = __tmp65Reader.EndOfStream;
                        while(!__tmp65_last)
                        {
                            string __tmp65_line = __tmp65Reader.ReadLine();
                            __tmp65_last = __tmp65Reader.EndOfStream;
                            if ((__tmp65_last && !string.IsNullOrEmpty(__tmp65_line)) || (!__tmp65_last && __tmp65_line != null))
                            {
                                __out.Append(__tmp65_line);
                                __tmp63_outputWritten = true;
                            }
                            if (!__tmp65_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp66_line = ")symbol;"; //413:53
                    if (!string.IsNullOrEmpty(__tmp66_line))
                    {
                        __out.Append(__tmp66_line);
                        __tmp63_outputWritten = true;
                    }
                    if (__tmp63_outputWritten) __out.AppendLine(true);
                    if (__tmp63_outputWritten)
                    {
                        __out.AppendLine(false); //413:61
                    }
                    __out.Append("	}"); //414:1
                    __out.AppendLine(false); //414:3
                }
            }
            __out.Append("}"); //417:1
            __out.AppendLine(false); //417:2
            __out.AppendLine(true); //418:1
            return __out.ToString();
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //421:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //422:2
            bool metaMetaModel = IsMetaMetaModel(model); //423:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public static class "; //424:1
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
                __out.AppendLine(false); //424:61
            }
            __out.Append("{"); //425:1
            __out.AppendLine(false); //425:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	private static global::System.Collections.Generic.List<"; //426:1
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
            string __tmp9_line = ".ModelProperty> properties;"; //426:76
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //426:103
            }
            __out.AppendLine(true); //427:1
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	static "; //428:1
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
            string __tmp14_line = "()"; //428:49
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //428:51
            }
            __out.Append("	{"); //429:1
            __out.AppendLine(false); //429:3
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "		properties = new global::System.Collections.Generic.List<"; //430:1
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
            string __tmp19_line = ".ModelProperty>();"; //430:79
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //430:97
            }
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //431:9
                from cls in __Enumerate((__loop21_var1).GetEnumerator()).OfType<MetaClass>() //431:39
                select new { __loop21_var1 = __loop21_var1, cls = cls}
                ).ToList(); //431:4
            for (int __loop21_iteration = 0; __loop21_iteration < __loop21_results.Count; ++__loop21_iteration)
            {
                var __tmp20 = __loop21_results[__loop21_iteration];
                var __loop21_var1 = __tmp20.__loop21_var1;
                var cls = __tmp20.cls;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "		"; //432:1
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
                string __tmp24_line = ".Initialize();"; //432:48
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Append(__tmp24_line);
                    __tmp22_outputWritten = true;
                }
                if (__tmp22_outputWritten) __out.AppendLine(true);
                if (__tmp22_outputWritten)
                {
                    __out.AppendLine(false); //432:62
                }
            }
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //434:9
                from cls in __Enumerate((__loop22_var1).GetEnumerator()).OfType<MetaClass>() //434:39
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //434:62
                select new { __loop22_var1 = __loop22_var1, cls = cls, prop = prop}
                ).ToList(); //434:4
            for (int __loop22_iteration = 0; __loop22_iteration < __loop22_results.Count; ++__loop22_iteration)
            {
                var __tmp25 = __loop22_results[__loop22_iteration];
                var __loop22_var1 = __tmp25.__loop22_var1;
                var cls = __tmp25.cls;
                var prop = __tmp25.prop;
                bool __tmp27_outputWritten = false;
                string __tmp28_line = "		properties.Add("; //435:1
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
                string __tmp30_line = ");"; //435:73
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Append(__tmp30_line);
                    __tmp27_outputWritten = true;
                }
                if (__tmp27_outputWritten) __out.AppendLine(true);
                if (__tmp27_outputWritten)
                {
                    __out.AppendLine(false); //435:75
                }
            }
            __out.Append("	}"); //437:1
            __out.AppendLine(false); //437:3
            __out.AppendLine(true); //438:1
            __out.Append("	public static void Initialize()"); //439:1
            __out.AppendLine(false); //439:33
            __out.Append("	{"); //440:1
            __out.AppendLine(false); //440:3
            __out.Append("	}"); //441:1
            __out.AppendLine(false); //441:3
            __out.AppendLine(true); //442:1
            bool __tmp32_outputWritten = false;
            string __tmp33_line = "	public const string Uri = \""; //443:1
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
            string __tmp35_line = "\";"; //443:40
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Append(__tmp35_line);
                __tmp32_outputWritten = true;
            }
            if (__tmp32_outputWritten) __out.AppendLine(true);
            if (__tmp32_outputWritten)
            {
                __out.AppendLine(false); //443:42
            }
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //444:8
                from cls in __Enumerate((__loop23_var1).GetEnumerator()).OfType<MetaClass>() //444:38
                select new { __loop23_var1 = __loop23_var1, cls = cls}
                ).ToList(); //444:3
            for (int __loop23_iteration = 0; __loop23_iteration < __loop23_results.Count; ++__loop23_iteration)
            {
                var __tmp36 = __loop23_results[__loop23_iteration];
                var __loop23_var1 = __tmp36.__loop23_var1;
                var cls = __tmp36.cls;
                __out.AppendLine(true); //445:1
                bool __tmp38_outputWritten = false;
                string __tmp37Prefix = "	"; //446:1
                StringBuilder __tmp39 = new StringBuilder();
                __tmp39.Append(GenerateDescriptorClass(model, cls));
                using(StreamReader __tmp39Reader = new StreamReader(this.__ToStream(__tmp39.ToString())))
                {
                    bool __tmp39_last = __tmp39Reader.EndOfStream;
                    while(!__tmp39_last)
                    {
                        string __tmp39_line = __tmp39Reader.ReadLine();
                        __tmp39_last = __tmp39Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp37Prefix))
                        {
                            __out.Append(__tmp37Prefix);
                            __tmp38_outputWritten = true;
                        }
                        if ((__tmp39_last && !string.IsNullOrEmpty(__tmp39_line)) || (!__tmp39_last && __tmp39_line != null))
                        {
                            __out.Append(__tmp39_line);
                            __tmp38_outputWritten = true;
                        }
                        if (!__tmp39_last || __tmp38_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp38_outputWritten)
                {
                    __out.AppendLine(false); //446:39
                }
            }
            __out.Append("}"); //448:1
            __out.AppendLine(false); //448:2
            return __out.ToString();
        }

        public string GenerateDescriptorClass(MetaModel model, MetaClass cls) //451:1
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
                __out.AppendLine(false); //452:29
            }
            bool __tmp5_outputWritten = false;
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GenerateAnnotations(cls));
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
                __out.AppendLine(false); //453:27
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
            string __tmp10_line = ".ModelSymbolDescriptorAttribute(typeof("; //454:24
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
            string __tmp12_line = "), typeof("; //454:105
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
            string __tmp14_line = "), typeof("; //454:164
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
            string __tmp16_line = ")"; //454:221
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
            string __tmp18_line = ")"; //454:258
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
                __out.AppendLine(false); //454:264
            }
            bool __tmp21_outputWritten = false;
            string __tmp22_line = "public static class "; //455:1
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
                __out.AppendLine(false); //455:66
            }
            __out.Append("{"); //456:1
            __out.AppendLine(false); //456:2
            bool __tmp25_outputWritten = false;
            string __tmp26_line = "	private static "; //457:1
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
            string __tmp28_line = ".ModelSymbolInfo modelSymbolInfo;"; //457:36
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Append(__tmp28_line);
                __tmp25_outputWritten = true;
            }
            if (__tmp25_outputWritten) __out.AppendLine(true);
            if (__tmp25_outputWritten)
            {
                __out.AppendLine(false); //457:69
            }
            __out.AppendLine(true); //458:1
            bool __tmp30_outputWritten = false;
            string __tmp31_line = "	static "; //459:1
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
            string __tmp33_line = "()"; //459:54
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Append(__tmp33_line);
                __tmp30_outputWritten = true;
            }
            if (__tmp30_outputWritten) __out.AppendLine(true);
            if (__tmp30_outputWritten)
            {
                __out.AppendLine(false); //459:56
            }
            __out.Append("	{"); //460:1
            __out.AppendLine(false); //460:3
            bool __tmp35_outputWritten = false;
            string __tmp36_line = "		modelSymbolInfo = "; //461:1
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
            string __tmp38_line = ".ModelSymbolInfo.GetDescriptorSymbolInfo(typeof("; //461:40
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
            string __tmp40_line = "));"; //461:133
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Append(__tmp40_line);
                __tmp35_outputWritten = true;
            }
            if (__tmp35_outputWritten) __out.AppendLine(true);
            if (__tmp35_outputWritten)
            {
                __out.AppendLine(false); //461:136
            }
            __out.Append("	}"); //462:1
            __out.AppendLine(false); //462:3
            __out.AppendLine(true); //463:1
            __out.Append("	internal static void Initialize()"); //464:1
            __out.AppendLine(false); //464:35
            __out.Append("	{"); //465:1
            __out.AppendLine(false); //465:3
            __out.Append("	}"); //466:1
            __out.AppendLine(false); //466:3
            __out.AppendLine(true); //467:1
            bool __tmp42_outputWritten = false;
            string __tmp43_line = "	public static "; //468:1
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
            string __tmp45_line = ".ModelSymbolInfo SymbolInfo"; //468:35
            if (!string.IsNullOrEmpty(__tmp45_line))
            {
                __out.Append(__tmp45_line);
                __tmp42_outputWritten = true;
            }
            if (__tmp42_outputWritten) __out.AppendLine(true);
            if (__tmp42_outputWritten)
            {
                __out.AppendLine(false); //468:62
            }
            __out.Append("	{"); //469:1
            __out.AppendLine(false); //469:3
            __out.Append("		get { return modelSymbolInfo; }"); //470:1
            __out.AppendLine(false); //470:34
            __out.Append("	}"); //471:1
            __out.AppendLine(false); //471:3
            __out.AppendLine(true); //472:1
            if (cls.Name == "MetaClass") //473:3
            {
                bool __tmp47_outputWritten = false;
                string __tmp48_line = "	public static "; //474:1
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
                string __tmp50_line = ".MetaClass _MetaClass"; //474:35
                if (!string.IsNullOrEmpty(__tmp50_line))
                {
                    __out.Append(__tmp50_line);
                    __tmp47_outputWritten = true;
                }
                if (__tmp47_outputWritten) __out.AppendLine(true);
                if (__tmp47_outputWritten)
                {
                    __out.AppendLine(false); //474:56
                }
            }
            else //475:3
            {
                bool __tmp52_outputWritten = false;
                string __tmp53_line = "	public static "; //476:1
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp52_outputWritten = true;
                }
                StringBuilder __tmp54 = new StringBuilder();
                __tmp54.Append(Properties.MetaNs);
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
                string __tmp55_line = ".MetaClass MetaClass"; //476:35
                if (!string.IsNullOrEmpty(__tmp55_line))
                {
                    __out.Append(__tmp55_line);
                    __tmp52_outputWritten = true;
                }
                if (__tmp52_outputWritten) __out.AppendLine(true);
                if (__tmp52_outputWritten)
                {
                    __out.AppendLine(false); //476:55
                }
            }
            __out.Append("	{"); //478:1
            __out.AppendLine(false); //478:3
            bool __tmp57_outputWritten = false;
            string __tmp58_line = "		get { return "; //479:1
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Append(__tmp58_line);
                __tmp57_outputWritten = true;
            }
            StringBuilder __tmp59 = new StringBuilder();
            __tmp59.Append(CSharpName(cls, null, ClassKind.ImmutableInstance, true));
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
            string __tmp60_line = "; }"; //479:73
            if (!string.IsNullOrEmpty(__tmp60_line))
            {
                __out.Append(__tmp60_line);
                __tmp57_outputWritten = true;
            }
            if (__tmp57_outputWritten) __out.AppendLine(true);
            if (__tmp57_outputWritten)
            {
                __out.AppendLine(false); //479:76
            }
            __out.Append("	}"); //480:1
            __out.AppendLine(false); //480:3
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //481:8
                from prop in __Enumerate((__loop24_var1.Properties).GetEnumerator()) //481:13
                select new { __loop24_var1 = __loop24_var1, prop = prop}
                ).ToList(); //481:3
            for (int __loop24_iteration = 0; __loop24_iteration < __loop24_results.Count; ++__loop24_iteration)
            {
                var __tmp61 = __loop24_results[__loop24_iteration];
                var __loop24_var1 = __tmp61.__loop24_var1;
                var prop = __tmp61.prop;
                bool __tmp63_outputWritten = false;
                string __tmp62Prefix = "	"; //482:1
                StringBuilder __tmp64 = new StringBuilder();
                __tmp64.Append(GenerateDescriptorProperty(model, cls, prop));
                using(StreamReader __tmp64Reader = new StreamReader(this.__ToStream(__tmp64.ToString())))
                {
                    bool __tmp64_last = __tmp64Reader.EndOfStream;
                    while(!__tmp64_last)
                    {
                        string __tmp64_line = __tmp64Reader.ReadLine();
                        __tmp64_last = __tmp64Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp62Prefix))
                        {
                            __out.Append(__tmp62Prefix);
                            __tmp63_outputWritten = true;
                        }
                        if ((__tmp64_last && !string.IsNullOrEmpty(__tmp64_line)) || (!__tmp64_last && __tmp64_line != null))
                        {
                            __out.Append(__tmp64_line);
                            __tmp63_outputWritten = true;
                        }
                        if (!__tmp64_last || __tmp63_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp63_outputWritten)
                {
                    __out.AppendLine(false); //482:48
                }
            }
            __out.Append("}"); //484:1
            __out.AppendLine(false); //484:2
            return __out.ToString();
        }

        public string GetDescriptorAncestors(MetaModel model, MetaClass cls) //487:1
        {
            string result = ""; //488:2
            var __loop25_results = 
                (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //489:7
                from super in __Enumerate((__loop25_var1.SuperClasses).GetEnumerator()) //489:12
                select new { __loop25_var1 = __loop25_var1, super = super}
                ).ToList(); //489:2
            for (int __loop25_iteration = 0; __loop25_iteration < __loop25_results.Count; ++__loop25_iteration)
            {
                string delim; //489:30
                if (__loop25_iteration+1 < __loop25_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop25_results[__loop25_iteration];
                var __loop25_var1 = __tmp1.__loop25_var1;
                var super = __tmp1.super;
                result += "typeof(" + CSharpName(super, model, ClassKind.Descriptor, true) + ")" + delim; //490:3
            }
            if (result.Length > 0) //492:2
            {
                result = ", BaseSymbolDescriptors = new global::System.Type[] { " + result + " }"; //493:3
            }
            return result; //495:2
        }

        public string GenerateDescriptorProperty(MetaModel model, MetaClass cls, MetaProperty prop) //498:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //499:1
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
                __out.AppendLine(false); //500:30
            }
            bool __tmp5_outputWritten = false;
            StringBuilder __tmp6 = new StringBuilder();
            __tmp6.Append(GenerateAnnotations(prop));
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
                __out.AppendLine(false); //501:28
            }
            bool __tmp8_outputWritten = false;
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(GenerateDescriptorPropertyAnnotations(model, cls, prop));
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
                __out.AppendLine(false); //502:58
            }
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "public static readonly "; //503:1
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
            string __tmp14_line = ".ModelProperty "; //503:43
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
            string __tmp16_line = " ="; //503:107
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Append(__tmp16_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //503:109
            }
            bool __tmp18_outputWritten = false;
            string __tmp17Prefix = "    "; //504:1
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
            string __tmp20_line = ".ModelProperty.Register(typeof("; //504:24
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
            string __tmp22_line = "), \""; //504:100
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
            string __tmp24_line = "\","; //504:128
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //504:130
            }
            if (prop.Type is MetaCollectionType) //505:2
            {
                MetaCollectionType collType = (MetaCollectionType)prop.Type; //506:3
                bool __tmp26_outputWritten = false;
                string __tmp27_line = "        new "; //507:1
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
                string __tmp29_line = ".ModelPropertyTypeInfo(typeof("; //507:32
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Append(__tmp29_line);
                    __tmp26_outputWritten = true;
                }
                StringBuilder __tmp30 = new StringBuilder();
                __tmp30.Append(CSharpName(collType.InnerType, null, ClassKind.Immutable, true));
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
                string __tmp31_line = "), typeof("; //507:126
                if (!string.IsNullOrEmpty(__tmp31_line))
                {
                    __out.Append(__tmp31_line);
                    __tmp26_outputWritten = true;
                }
                StringBuilder __tmp32 = new StringBuilder();
                __tmp32.Append(CSharpName(prop.Type, null, ClassKind.Immutable, true));
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
                            __tmp26_outputWritten = true;
                        }
                        if (!__tmp32_last) __out.AppendLine(true);
                    }
                }
                string __tmp33_line = ")),"; //507:191
                if (!string.IsNullOrEmpty(__tmp33_line))
                {
                    __out.Append(__tmp33_line);
                    __tmp26_outputWritten = true;
                }
                if (__tmp26_outputWritten) __out.AppendLine(true);
                if (__tmp26_outputWritten)
                {
                    __out.AppendLine(false); //507:194
                }
                bool __tmp35_outputWritten = false;
                string __tmp36_line = "        new "; //508:1
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
                string __tmp38_line = ".ModelPropertyTypeInfo(typeof("; //508:32
                if (!string.IsNullOrEmpty(__tmp38_line))
                {
                    __out.Append(__tmp38_line);
                    __tmp35_outputWritten = true;
                }
                StringBuilder __tmp39 = new StringBuilder();
                __tmp39.Append(CSharpName(collType.InnerType, null, ClassKind.Builder, true));
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
                string __tmp40_line = "), typeof("; //508:124
                if (!string.IsNullOrEmpty(__tmp40_line))
                {
                    __out.Append(__tmp40_line);
                    __tmp35_outputWritten = true;
                }
                StringBuilder __tmp41 = new StringBuilder();
                __tmp41.Append(CSharpName(prop.Type, null, ClassKind.Builder, true));
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
                            __tmp35_outputWritten = true;
                        }
                        if (!__tmp41_last) __out.AppendLine(true);
                    }
                }
                string __tmp42_line = ")),"; //508:187
                if (!string.IsNullOrEmpty(__tmp42_line))
                {
                    __out.Append(__tmp42_line);
                    __tmp35_outputWritten = true;
                }
                if (__tmp35_outputWritten) __out.AppendLine(true);
                if (__tmp35_outputWritten)
                {
                    __out.AppendLine(false); //508:190
                }
            }
            else //509:2
            {
                bool __tmp44_outputWritten = false;
                string __tmp45_line = "        new "; //510:1
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
                string __tmp47_line = ".ModelPropertyTypeInfo(typeof("; //510:32
                if (!string.IsNullOrEmpty(__tmp47_line))
                {
                    __out.Append(__tmp47_line);
                    __tmp44_outputWritten = true;
                }
                StringBuilder __tmp48 = new StringBuilder();
                __tmp48.Append(CSharpName(prop.Type, null, ClassKind.Immutable, true));
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
                string __tmp49_line = "), null),"; //510:117
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Append(__tmp49_line);
                    __tmp44_outputWritten = true;
                }
                if (__tmp44_outputWritten) __out.AppendLine(true);
                if (__tmp44_outputWritten)
                {
                    __out.AppendLine(false); //510:126
                }
                bool __tmp51_outputWritten = false;
                string __tmp52_line = "        new "; //511:1
                if (!string.IsNullOrEmpty(__tmp52_line))
                {
                    __out.Append(__tmp52_line);
                    __tmp51_outputWritten = true;
                }
                StringBuilder __tmp53 = new StringBuilder();
                __tmp53.Append(Properties.CoreNs);
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
                string __tmp54_line = ".ModelPropertyTypeInfo(typeof("; //511:32
                if (!string.IsNullOrEmpty(__tmp54_line))
                {
                    __out.Append(__tmp54_line);
                    __tmp51_outputWritten = true;
                }
                StringBuilder __tmp55 = new StringBuilder();
                __tmp55.Append(CSharpName(prop.Type, null, ClassKind.Builder, true));
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
                            __tmp51_outputWritten = true;
                        }
                        if (!__tmp55_last) __out.AppendLine(true);
                    }
                }
                string __tmp56_line = "), null),"; //511:115
                if (!string.IsNullOrEmpty(__tmp56_line))
                {
                    __out.Append(__tmp56_line);
                    __tmp51_outputWritten = true;
                }
                if (__tmp51_outputWritten) __out.AppendLine(true);
                if (__tmp51_outputWritten)
                {
                    __out.AppendLine(false); //511:124
                }
            }
            bool __tmp58_outputWritten = false;
            string __tmp59_line = "		() => "; //513:1
            if (!string.IsNullOrEmpty(__tmp59_line))
            {
                __out.Append(__tmp59_line);
                __tmp58_outputWritten = true;
            }
            StringBuilder __tmp60 = new StringBuilder();
            __tmp60.Append(CSharpName(prop, null, PropertyKind.ImmutableInstance, true));
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
                        __tmp58_outputWritten = true;
                    }
                    if (!__tmp60_last) __out.AppendLine(true);
                }
            }
            string __tmp61_line = ");"; //513:70
            if (!string.IsNullOrEmpty(__tmp61_line))
            {
                __out.Append(__tmp61_line);
                __tmp58_outputWritten = true;
            }
            if (__tmp58_outputWritten) __out.AppendLine(true);
            if (__tmp58_outputWritten)
            {
                __out.AppendLine(false); //513:72
            }
            return __out.ToString();
        }

        public string GenerateDescriptorPropertyAnnotations(MetaModel model, MetaClass cls, MetaProperty prop) //516:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Kind == MetaPropertyKind.Containment) //517:2
            {
                bool __tmp2_outputWritten = false;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append("[" + Properties.CoreNs + ".ContainmentAttribute]");
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
                    __out.AppendLine(false); //518:49
                }
            }
            if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //520:2
            {
                bool __tmp5_outputWritten = false;
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append("[" + Properties.CoreNs + ".ReadonlyAttribute]");
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
                    __out.AppendLine(false); //521:46
                }
            }
            var __loop26_results = 
                (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //523:7
                select new { p = p}
                ).ToList(); //523:2
            for (int __loop26_iteration = 0; __loop26_iteration < __loop26_results.Count; ++__loop26_iteration)
            {
                var __tmp7 = __loop26_results[__loop26_iteration];
                var p = __tmp7.p;
                bool __tmp9_outputWritten = false;
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append("[" + Properties.CoreNs + ".OppositeAttribute(typeof(");
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
                        if (!__tmp10_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(CSharpName(p.Class, model, ClassKind.Descriptor, true));
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
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append("), \"");
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
                            __tmp9_outputWritten = true;
                        }
                        if (!__tmp12_last) __out.AppendLine(true);
                    }
                }
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(CSharpName(p, model));
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
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append("\")]");
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
                            __tmp9_outputWritten = true;
                        }
                        if (!__tmp14_last || __tmp9_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp9_outputWritten)
                {
                    __out.AppendLine(false); //524:146
                }
            }
            var __loop27_results = 
                (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //526:7
                select new { p = p}
                ).ToList(); //526:2
            for (int __loop27_iteration = 0; __loop27_iteration < __loop27_results.Count; ++__loop27_iteration)
            {
                var __tmp15 = __loop27_results[__loop27_iteration];
                var p = __tmp15.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //527:3
                {
                    bool __tmp17_outputWritten = false;
                    StringBuilder __tmp18 = new StringBuilder();
                    __tmp18.Append("[" + Properties.CoreNs + ".SubsetsAttribute(typeof(");
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
                            if (!__tmp18_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp19 = new StringBuilder();
                    __tmp19.Append(CSharpName(p.Class, model, ClassKind.Descriptor, true));
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
                    StringBuilder __tmp20 = new StringBuilder();
                    __tmp20.Append("), \"");
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
                                __tmp17_outputWritten = true;
                            }
                            if (!__tmp20_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp21 = new StringBuilder();
                    __tmp21.Append(CSharpName(p, model));
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
                                __tmp17_outputWritten = true;
                            }
                            if (!__tmp21_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp22 = new StringBuilder();
                    __tmp22.Append("\")]");
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
                                __tmp17_outputWritten = true;
                            }
                            if (!__tmp22_last || __tmp17_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp17_outputWritten)
                    {
                        __out.AppendLine(false); //528:145
                    }
                }
                else //529:3
                {
                    bool __tmp24_outputWritten = false;
                    string __tmp25_line = "// ERROR: subsetted property '"; //530:1
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Append(__tmp25_line);
                        __tmp24_outputWritten = true;
                    }
                    StringBuilder __tmp26 = new StringBuilder();
                    __tmp26.Append(CSharpName(p, model, PropertyKind.Descriptor, true));
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
                    string __tmp27_line = "' must be a property of this class or an ancestor class"; //530:83
                    if (!string.IsNullOrEmpty(__tmp27_line))
                    {
                        __out.Append(__tmp27_line);
                        __tmp24_outputWritten = true;
                    }
                    if (__tmp24_outputWritten) __out.AppendLine(true);
                    if (__tmp24_outputWritten)
                    {
                        __out.AppendLine(false); //530:138
                    }
                }
            }
            var __loop28_results = 
                (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //533:7
                select new { p = p}
                ).ToList(); //533:2
            for (int __loop28_iteration = 0; __loop28_iteration < __loop28_results.Count; ++__loop28_iteration)
            {
                var __tmp28 = __loop28_results[__loop28_iteration];
                var p = __tmp28.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //534:3
                {
                    bool __tmp30_outputWritten = false;
                    StringBuilder __tmp31 = new StringBuilder();
                    __tmp31.Append("[" + Properties.CoreNs + ".RedefinesAttribute(typeof(");
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
                                __tmp30_outputWritten = true;
                            }
                            if (!__tmp31_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp32 = new StringBuilder();
                    __tmp32.Append(CSharpName(p.Class, model, ClassKind.Descriptor, true));
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
                    StringBuilder __tmp33 = new StringBuilder();
                    __tmp33.Append("), \"");
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
                                __tmp30_outputWritten = true;
                            }
                            if (!__tmp33_last) __out.AppendLine(true);
                        }
                    }
                    StringBuilder __tmp34 = new StringBuilder();
                    __tmp34.Append(CSharpName(p, model));
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
                    StringBuilder __tmp35 = new StringBuilder();
                    __tmp35.Append("\")]");
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
                                __tmp30_outputWritten = true;
                            }
                            if (!__tmp35_last || __tmp30_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //535:147
                    }
                }
                else //536:3
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "// ERROR: redefined property '"; //537:1
                    if (!string.IsNullOrEmpty(__tmp38_line))
                    {
                        __out.Append(__tmp38_line);
                        __tmp37_outputWritten = true;
                    }
                    StringBuilder __tmp39 = new StringBuilder();
                    __tmp39.Append(CSharpName(p, model, PropertyKind.Descriptor, true));
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
                    string __tmp40_line = "' must be a property of this class or an ancestor class"; //537:83
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Append(__tmp40_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //537:138
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //542:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //543:1
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
                __out.AppendLine(false); //543:68
            }
            __out.Append("{"); //544:1
            __out.AppendLine(false); //544:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	// If there is a compile error at this line, create a new class called "; //545:1
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
                __out.AppendLine(false); //545:117
            }
            bool __tmp10_outputWritten = false;
            string __tmp11_line = "	// which is a subclass of "; //546:1
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
            string __tmp13_line = ":"; //546:82
            if (!string.IsNullOrEmpty(__tmp13_line))
            {
                __out.Append(__tmp13_line);
                __tmp10_outputWritten = true;
            }
            if (__tmp10_outputWritten) __out.AppendLine(true);
            if (__tmp10_outputWritten)
            {
                __out.AppendLine(false); //546:83
            }
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "	private static "; //547:1
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
            string __tmp18_line = " implementation = new "; //547:61
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
            string __tmp20_line = "();"; //547:127
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //547:130
            }
            __out.AppendLine(true); //548:1
            bool __tmp22_outputWritten = false;
            string __tmp23_line = "	public static "; //549:1
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
            string __tmp25_line = " Implementation"; //549:60
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Append(__tmp25_line);
                __tmp22_outputWritten = true;
            }
            if (__tmp22_outputWritten) __out.AppendLine(true);
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //549:75
            }
            __out.Append("	{"); //550:1
            __out.AppendLine(false); //550:3
            __out.Append("		get { return implementation; }"); //551:1
            __out.AppendLine(false); //551:33
            __out.Append("	}"); //552:1
            __out.AppendLine(false); //552:3
            __out.Append("}"); //553:1
            __out.AppendLine(false); //553:2
            return __out.ToString();
        }

        public string GenerateImplementationBase(MetaModel model) //556:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //557:1
            __out.AppendLine(false); //557:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //558:1
            __out.AppendLine(false); //558:68
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "/// This class has to be be overriden in "; //559:1
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
            string __tmp5_line = " to provide custom"; //559:92
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Append(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //559:110
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //560:1
            __out.AppendLine(false); //560:73
            __out.Append("/// </summary>"); //561:1
            __out.AppendLine(false); //561:15
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "internal abstract class "; //562:1
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
                __out.AppendLine(false); //562:73
            }
            __out.Append("{"); //563:1
            __out.AppendLine(false); //563:2
            __out.Append("	/// <summary>"); //564:1
            __out.AppendLine(false); //564:15
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	/// Implements the constructor: "; //565:1
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
            string __tmp14_line = "()"; //565:79
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //565:81
            }
            __out.Append("	/// </summary>"); //566:1
            __out.AppendLine(false); //566:16
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	internal virtual void "; //567:1
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
            string __tmp19_line = "("; //567:69
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
            string __tmp21_line = " _this)"; //567:115
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //567:122
            }
            __out.Append("	{"); //568:1
            __out.AppendLine(false); //568:3
            __out.Append("	}"); //569:1
            __out.AppendLine(false); //569:3
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //570:8
                from cls in __Enumerate((__loop29_var1).GetEnumerator()).OfType<MetaClass>() //570:38
                select new { __loop29_var1 = __loop29_var1, cls = cls}
                ).ToList(); //570:3
            for (int __loop29_iteration = 0; __loop29_iteration < __loop29_results.Count; ++__loop29_iteration)
            {
                var __tmp22 = __loop29_results[__loop29_iteration];
                var __loop29_var1 = __tmp22.__loop29_var1;
                var cls = __tmp22.cls;
                __out.AppendLine(true); //571:1
                __out.Append("	/// <summary>"); //572:1
                __out.AppendLine(false); //572:15
                bool __tmp24_outputWritten = false;
                string __tmp25_line = "	/// Implements the constructor: "; //573:1
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
                string __tmp27_line = "()"; //573:78
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Append(__tmp27_line);
                    __tmp24_outputWritten = true;
                }
                if (__tmp24_outputWritten) __out.AppendLine(true);
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //573:80
                }
                __out.Append("	/// </summary>"); //574:1
                __out.AppendLine(false); //574:16
                if ((from __loop30_var1 in __Enumerate((cls).GetEnumerator()) //575:15
                from sup in __Enumerate((__loop30_var1.SuperClasses).GetEnumerator()) //575:20
                select new { __loop30_var1 = __loop30_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //575:3
                {
                    __out.Append("	/// Direct superclasses: "); //576:1
                    __out.AppendLine(false); //576:27
                    __out.Append("	/// <ul>"); //577:1
                    __out.AppendLine(false); //577:10
                    var __loop31_results = 
                        (from __loop31_var1 in __Enumerate((cls).GetEnumerator()) //578:8
                        from sup in __Enumerate((__loop31_var1.SuperClasses).GetEnumerator()) //578:13
                        select new { __loop31_var1 = __loop31_var1, sup = sup}
                        ).ToList(); //578:3
                    for (int __loop31_iteration = 0; __loop31_iteration < __loop31_results.Count; ++__loop31_iteration)
                    {
                        var __tmp28 = __loop31_results[__loop31_iteration];
                        var __loop31_var1 = __tmp28.__loop31_var1;
                        var sup = __tmp28.sup;
                        bool __tmp30_outputWritten = false;
                        string __tmp31_line = "	///     <li>"; //579:1
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
                        string __tmp33_line = "</li>"; //579:64
                        if (!string.IsNullOrEmpty(__tmp33_line))
                        {
                            __out.Append(__tmp33_line);
                            __tmp30_outputWritten = true;
                        }
                        if (__tmp30_outputWritten) __out.AppendLine(true);
                        if (__tmp30_outputWritten)
                        {
                            __out.AppendLine(false); //579:69
                        }
                    }
                    __out.Append("	/// </ul>"); //581:1
                    __out.AppendLine(false); //581:11
                    __out.Append("	/// All superclasses:"); //582:1
                    __out.AppendLine(false); //582:23
                    __out.Append("	/// <ul>"); //583:1
                    __out.AppendLine(false); //583:10
                    var __loop32_results = 
                        (from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //584:8
                        from sup in __Enumerate((__loop32_var1.GetAllSuperClasses(false)).GetEnumerator()) //584:13
                        select new { __loop32_var1 = __loop32_var1, sup = sup}
                        ).ToList(); //584:3
                    for (int __loop32_iteration = 0; __loop32_iteration < __loop32_results.Count; ++__loop32_iteration)
                    {
                        var __tmp34 = __loop32_results[__loop32_iteration];
                        var __loop32_var1 = __tmp34.__loop32_var1;
                        var sup = __tmp34.sup;
                        bool __tmp36_outputWritten = false;
                        string __tmp37_line = "	///     <li>"; //585:1
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
                        string __tmp39_line = "</li>"; //585:64
                        if (!string.IsNullOrEmpty(__tmp39_line))
                        {
                            __out.Append(__tmp39_line);
                            __tmp36_outputWritten = true;
                        }
                        if (__tmp36_outputWritten) __out.AppendLine(true);
                        if (__tmp36_outputWritten)
                        {
                            __out.AppendLine(false); //585:69
                        }
                    }
                    __out.Append("	/// </ul>"); //587:1
                    __out.AppendLine(false); //587:11
                }
                if ((from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //589:15
                from prop in __Enumerate((__loop33_var1.Properties).GetEnumerator()) //589:20
                where prop.Kind == MetaPropertyKind.Readonly //589:36
                select new { __loop33_var1 = __loop33_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //589:3
                {
                    __out.Append("	/// Initializes the following readonly properties:"); //590:1
                    __out.AppendLine(false); //590:52
                    __out.Append("	/// <ul>"); //591:1
                    __out.AppendLine(false); //591:10
                    var __loop34_results = 
                        (from __loop34_var1 in __Enumerate((cls).GetEnumerator()) //592:8
                        from prop in __Enumerate((__loop34_var1.Properties).GetEnumerator()) //592:13
                        where prop.Kind == MetaPropertyKind.Readonly //592:29
                        select new { __loop34_var1 = __loop34_var1, prop = prop}
                        ).ToList(); //592:3
                    for (int __loop34_iteration = 0; __loop34_iteration < __loop34_results.Count; ++__loop34_iteration)
                    {
                        var __tmp40 = __loop34_results[__loop34_iteration];
                        var __loop34_var1 = __tmp40.__loop34_var1;
                        var prop = __tmp40.prop;
                        bool __tmp42_outputWritten = false;
                        string __tmp43_line = "	///     <li>"; //593:1
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
                        string __tmp45_line = "</li>"; //593:38
                        if (!string.IsNullOrEmpty(__tmp45_line))
                        {
                            __out.Append(__tmp45_line);
                            __tmp42_outputWritten = true;
                        }
                        if (__tmp42_outputWritten) __out.AppendLine(true);
                        if (__tmp42_outputWritten)
                        {
                            __out.AppendLine(false); //593:43
                        }
                    }
                    __out.Append("	/// </ul>"); //595:1
                    __out.AppendLine(false); //595:11
                }
                if ((from __loop35_var1 in __Enumerate((cls).GetEnumerator()) //597:15
                from prop in __Enumerate((__loop35_var1.Properties).GetEnumerator()) //597:20
                where prop.Kind == MetaPropertyKind.Lazy //597:36
                select new { __loop35_var1 = __loop35_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //597:3
                {
                    __out.Append("	/// Initializes the following lazy properties:"); //598:1
                    __out.AppendLine(false); //598:48
                    __out.Append("	/// <ul>"); //599:1
                    __out.AppendLine(false); //599:10
                    var __loop36_results = 
                        (from __loop36_var1 in __Enumerate((cls).GetEnumerator()) //600:8
                        from prop in __Enumerate((__loop36_var1.Properties).GetEnumerator()) //600:13
                        where prop.Kind == MetaPropertyKind.Lazy //600:29
                        select new { __loop36_var1 = __loop36_var1, prop = prop}
                        ).ToList(); //600:3
                    for (int __loop36_iteration = 0; __loop36_iteration < __loop36_results.Count; ++__loop36_iteration)
                    {
                        var __tmp46 = __loop36_results[__loop36_iteration];
                        var __loop36_var1 = __tmp46.__loop36_var1;
                        var prop = __tmp46.prop;
                        bool __tmp48_outputWritten = false;
                        string __tmp49_line = "	///     <li>"; //601:1
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
                        string __tmp51_line = "</li>"; //601:38
                        if (!string.IsNullOrEmpty(__tmp51_line))
                        {
                            __out.Append(__tmp51_line);
                            __tmp48_outputWritten = true;
                        }
                        if (__tmp48_outputWritten) __out.AppendLine(true);
                        if (__tmp48_outputWritten)
                        {
                            __out.AppendLine(false); //601:43
                        }
                    }
                    __out.Append("	/// </ul>"); //603:1
                    __out.AppendLine(false); //603:11
                }
                if ((from __loop37_var1 in __Enumerate((cls).GetEnumerator()) //605:15
                from prop in __Enumerate((__loop37_var1.Properties).GetEnumerator()) //605:20
                where prop.Kind == MetaPropertyKind.Derived //605:36
                select new { __loop37_var1 = __loop37_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //605:3
                {
                    __out.Append("	/// Initializes the following derived properties:"); //606:1
                    __out.AppendLine(false); //606:51
                    __out.Append("	/// <ul>"); //607:1
                    __out.AppendLine(false); //607:10
                    var __loop38_results = 
                        (from __loop38_var1 in __Enumerate((cls).GetEnumerator()) //608:8
                        from prop in __Enumerate((__loop38_var1.Properties).GetEnumerator()) //608:13
                        where prop.Kind == MetaPropertyKind.Derived //608:29
                        select new { __loop38_var1 = __loop38_var1, prop = prop}
                        ).ToList(); //608:3
                    for (int __loop38_iteration = 0; __loop38_iteration < __loop38_results.Count; ++__loop38_iteration)
                    {
                        var __tmp52 = __loop38_results[__loop38_iteration];
                        var __loop38_var1 = __tmp52.__loop38_var1;
                        var prop = __tmp52.prop;
                        bool __tmp54_outputWritten = false;
                        string __tmp55_line = "	///     <li>"; //609:1
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
                        string __tmp57_line = "</li>"; //609:38
                        if (!string.IsNullOrEmpty(__tmp57_line))
                        {
                            __out.Append(__tmp57_line);
                            __tmp54_outputWritten = true;
                        }
                        if (__tmp54_outputWritten) __out.AppendLine(true);
                        if (__tmp54_outputWritten)
                        {
                            __out.AppendLine(false); //609:43
                        }
                    }
                    __out.Append("	/// </ul>"); //611:1
                    __out.AppendLine(false); //611:11
                }
                bool __tmp59_outputWritten = false;
                string __tmp60_line = "	public virtual void "; //613:1
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
                string __tmp62_line = "("; //613:66
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
                string __tmp64_line = " _this)"; //613:109
                if (!string.IsNullOrEmpty(__tmp64_line))
                {
                    __out.Append(__tmp64_line);
                    __tmp59_outputWritten = true;
                }
                if (__tmp59_outputWritten) __out.AppendLine(true);
                if (__tmp59_outputWritten)
                {
                    __out.AppendLine(false); //613:116
                }
                __out.Append("	{"); //614:1
                __out.AppendLine(false); //614:3
                bool __tmp66_outputWritten = false;
                string __tmp67_line = "		this.Call"; //615:1
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
                string __tmp69_line = "SuperConstructors(_this);"; //615:56
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Append(__tmp69_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //615:81
                }
                __out.Append("	}"); //616:1
                __out.AppendLine(false); //616:3
                __out.AppendLine(true); //617:1
                __out.Append("	/// <summary>"); //618:1
                __out.AppendLine(false); //618:15
                bool __tmp71_outputWritten = false;
                string __tmp72_line = "	/// Calls the super constructors of "; //619:1
                if (!string.IsNullOrEmpty(__tmp72_line))
                {
                    __out.Append(__tmp72_line);
                    __tmp71_outputWritten = true;
                }
                StringBuilder __tmp73 = new StringBuilder();
                __tmp73.Append(CSharpName(cls, model, ClassKind.Immutable));
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
                        if (!__tmp73_last || __tmp71_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp71_outputWritten)
                {
                    __out.AppendLine(false); //619:82
                }
                __out.Append("	/// </summary>"); //620:1
                __out.AppendLine(false); //620:16
                bool __tmp75_outputWritten = false;
                string __tmp76_line = "	protected virtual void Call"; //621:1
                if (!string.IsNullOrEmpty(__tmp76_line))
                {
                    __out.Append(__tmp76_line);
                    __tmp75_outputWritten = true;
                }
                StringBuilder __tmp77 = new StringBuilder();
                __tmp77.Append(CSharpName(cls, model, ClassKind.Immutable));
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
                            __tmp75_outputWritten = true;
                        }
                        if (!__tmp77_last) __out.AppendLine(true);
                    }
                }
                string __tmp78_line = "SuperConstructors("; //621:73
                if (!string.IsNullOrEmpty(__tmp78_line))
                {
                    __out.Append(__tmp78_line);
                    __tmp75_outputWritten = true;
                }
                StringBuilder __tmp79 = new StringBuilder();
                __tmp79.Append(CSharpName(cls, model, ClassKind.Builder));
                using(StreamReader __tmp79Reader = new StreamReader(this.__ToStream(__tmp79.ToString())))
                {
                    bool __tmp79_last = __tmp79Reader.EndOfStream;
                    while(!__tmp79_last)
                    {
                        string __tmp79_line = __tmp79Reader.ReadLine();
                        __tmp79_last = __tmp79Reader.EndOfStream;
                        if ((__tmp79_last && !string.IsNullOrEmpty(__tmp79_line)) || (!__tmp79_last && __tmp79_line != null))
                        {
                            __out.Append(__tmp79_line);
                            __tmp75_outputWritten = true;
                        }
                        if (!__tmp79_last) __out.AppendLine(true);
                    }
                }
                string __tmp80_line = " _this)"; //621:133
                if (!string.IsNullOrEmpty(__tmp80_line))
                {
                    __out.Append(__tmp80_line);
                    __tmp75_outputWritten = true;
                }
                if (__tmp75_outputWritten) __out.AppendLine(true);
                if (__tmp75_outputWritten)
                {
                    __out.AppendLine(false); //621:140
                }
                __out.Append("	{"); //622:1
                __out.AppendLine(false); //622:3
                var __loop39_results = 
                    (from __loop39_var1 in __Enumerate((cls).GetEnumerator()) //623:8
                    from sup in __Enumerate((__loop39_var1.GetAllSuperClasses(false)).GetEnumerator()) //623:13
                    select new { __loop39_var1 = __loop39_var1, sup = sup}
                    ).ToList(); //623:3
                for (int __loop39_iteration = 0; __loop39_iteration < __loop39_results.Count; ++__loop39_iteration)
                {
                    var __tmp81 = __loop39_results[__loop39_iteration];
                    var __loop39_var1 = __tmp81.__loop39_var1;
                    var sup = __tmp81.sup;
                    if (model.Namespace.Declarations.Contains(sup)) //624:4
                    {
                        bool __tmp83_outputWritten = false;
                        string __tmp84_line = "		this."; //625:1
                        if (!string.IsNullOrEmpty(__tmp84_line))
                        {
                            __out.Append(__tmp84_line);
                            __tmp83_outputWritten = true;
                        }
                        StringBuilder __tmp85 = new StringBuilder();
                        __tmp85.Append(CSharpName(sup, model, ClassKind.Immutable));
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
                        string __tmp86_line = "(_this);"; //625:52
                        if (!string.IsNullOrEmpty(__tmp86_line))
                        {
                            __out.Append(__tmp86_line);
                            __tmp83_outputWritten = true;
                        }
                        if (__tmp83_outputWritten) __out.AppendLine(true);
                        if (__tmp83_outputWritten)
                        {
                            __out.AppendLine(false); //625:60
                        }
                    }
                    else //626:4
                    {
                        bool __tmp88_outputWritten = false;
                        string __tmp87Prefix = "		"; //627:1
                        StringBuilder __tmp89 = new StringBuilder();
                        __tmp89.Append(CSharpName(sup.MetaModel, ModelKind.ImplementationProvider, true));
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
                        string __tmp90_line = "."; //627:69
                        if (!string.IsNullOrEmpty(__tmp90_line))
                        {
                            __out.Append(__tmp90_line);
                            __tmp88_outputWritten = true;
                        }
                        StringBuilder __tmp91 = new StringBuilder();
                        __tmp91.Append(CSharpName(sup, model, ClassKind.Immutable));
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
                        string __tmp92_line = "(_this);"; //627:114
                        if (!string.IsNullOrEmpty(__tmp92_line))
                        {
                            __out.Append(__tmp92_line);
                            __tmp88_outputWritten = true;
                        }
                        if (__tmp88_outputWritten) __out.AppendLine(true);
                        if (__tmp88_outputWritten)
                        {
                            __out.AppendLine(false); //627:122
                        }
                    }
                }
                __out.Append("	}"); //630:1
                __out.AppendLine(false); //630:3
                var __loop40_results = 
                    (from __loop40_var1 in __Enumerate((cls).GetEnumerator()) //631:8
                    from op in __Enumerate((__loop40_var1.Operations).GetEnumerator()) //631:13
                    select new { __loop40_var1 = __loop40_var1, op = op}
                    ).ToList(); //631:3
                for (int __loop40_iteration = 0; __loop40_iteration < __loop40_results.Count; ++__loop40_iteration)
                {
                    var __tmp93 = __loop40_results[__loop40_iteration];
                    var __loop40_var1 = __tmp93.__loop40_var1;
                    var op = __tmp93.op;
                    __out.AppendLine(true); //632:2
                    __out.Append("	/// <summary>"); //633:1
                    __out.AppendLine(false); //633:15
                    bool __tmp95_outputWritten = false;
                    string __tmp96_line = "	/// Implements the operation: "; //634:1
                    if (!string.IsNullOrEmpty(__tmp96_line))
                    {
                        __out.Append(__tmp96_line);
                        __tmp95_outputWritten = true;
                    }
                    StringBuilder __tmp97 = new StringBuilder();
                    __tmp97.Append(CSharpName(cls, model, ClassKind.Immutable));
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
                    string __tmp98_line = "."; //634:76
                    if (!string.IsNullOrEmpty(__tmp98_line))
                    {
                        __out.Append(__tmp98_line);
                        __tmp95_outputWritten = true;
                    }
                    StringBuilder __tmp99 = new StringBuilder();
                    __tmp99.Append(op.Name);
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
                    string __tmp100_line = "()"; //634:86
                    if (!string.IsNullOrEmpty(__tmp100_line))
                    {
                        __out.Append(__tmp100_line);
                        __tmp95_outputWritten = true;
                    }
                    if (__tmp95_outputWritten) __out.AppendLine(true);
                    if (__tmp95_outputWritten)
                    {
                        __out.AppendLine(false); //634:88
                    }
                    __out.Append("	/// </summary>"); //635:1
                    __out.AppendLine(false); //635:16
                    bool __tmp102_outputWritten = false;
                    string __tmp103_line = "	public virtual "; //636:1
                    if (!string.IsNullOrEmpty(__tmp103_line))
                    {
                        __out.Append(__tmp103_line);
                        __tmp102_outputWritten = true;
                    }
                    StringBuilder __tmp104 = new StringBuilder();
                    __tmp104.Append(CSharpName(op.ReturnType, model, ClassKind.Immutable, true));
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
                                __tmp102_outputWritten = true;
                            }
                            if (!__tmp104_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp105_line = " "; //636:77
                    if (!string.IsNullOrEmpty(__tmp105_line))
                    {
                        __out.Append(__tmp105_line);
                        __tmp102_outputWritten = true;
                    }
                    StringBuilder __tmp106 = new StringBuilder();
                    __tmp106.Append(CSharpName(cls, model, ClassKind.Immutable));
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
                                __tmp102_outputWritten = true;
                            }
                            if (!__tmp106_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp107_line = "_"; //636:122
                    if (!string.IsNullOrEmpty(__tmp107_line))
                    {
                        __out.Append(__tmp107_line);
                        __tmp102_outputWritten = true;
                    }
                    StringBuilder __tmp108 = new StringBuilder();
                    __tmp108.Append(op.Name);
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
                                __tmp102_outputWritten = true;
                            }
                            if (!__tmp108_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp109_line = "("; //636:132
                    if (!string.IsNullOrEmpty(__tmp109_line))
                    {
                        __out.Append(__tmp109_line);
                        __tmp102_outputWritten = true;
                    }
                    StringBuilder __tmp110 = new StringBuilder();
                    __tmp110.Append(GetImplParameters(model, cls, op));
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
                                __tmp102_outputWritten = true;
                            }
                            if (!__tmp110_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp111_line = ")"; //636:168
                    if (!string.IsNullOrEmpty(__tmp111_line))
                    {
                        __out.Append(__tmp111_line);
                        __tmp102_outputWritten = true;
                    }
                    if (__tmp102_outputWritten) __out.AppendLine(true);
                    if (__tmp102_outputWritten)
                    {
                        __out.AppendLine(false); //636:169
                    }
                    __out.Append("	{"); //637:1
                    __out.AppendLine(false); //637:3
                    __out.Append("		throw new NotImplementedException();"); //638:1
                    __out.AppendLine(false); //638:39
                    __out.Append("	}"); //639:1
                    __out.AppendLine(false); //639:3
                }
                __out.AppendLine(true); //641:2
            }
            var __loop41_results = 
                (from __loop41_var1 in __Enumerate((model).GetEnumerator()) //643:8
                from Namespace in __Enumerate((__loop41_var1.Namespace).GetEnumerator()) //643:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //643:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //643:40
                select new { __loop41_var1 = __loop41_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //643:3
            for (int __loop41_iteration = 0; __loop41_iteration < __loop41_results.Count; ++__loop41_iteration)
            {
                var __tmp112 = __loop41_results[__loop41_iteration];
                var __loop41_var1 = __tmp112.__loop41_var1;
                var Namespace = __tmp112.Namespace;
                var Declarations = __tmp112.Declarations;
                var enm = __tmp112.enm;
                var __loop42_results = 
                    (from __loop42_var1 in __Enumerate((enm).GetEnumerator()) //644:8
                    from op in __Enumerate((__loop42_var1.Operations).GetEnumerator()) //644:13
                    select new { __loop42_var1 = __loop42_var1, op = op}
                    ).ToList(); //644:3
                for (int __loop42_iteration = 0; __loop42_iteration < __loop42_results.Count; ++__loop42_iteration)
                {
                    var __tmp113 = __loop42_results[__loop42_iteration];
                    var __loop42_var1 = __tmp113.__loop42_var1;
                    var op = __tmp113.op;
                    __out.AppendLine(true); //645:2
                    __out.Append("	/// <summary>"); //646:1
                    __out.AppendLine(false); //646:15
                    bool __tmp115_outputWritten = false;
                    string __tmp116_line = "	/// Implements the operation: "; //647:1
                    if (!string.IsNullOrEmpty(__tmp116_line))
                    {
                        __out.Append(__tmp116_line);
                        __tmp115_outputWritten = true;
                    }
                    StringBuilder __tmp117 = new StringBuilder();
                    __tmp117.Append(CSharpName(enm, model, ClassKind.Immutable));
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
                    string __tmp118_line = "."; //647:76
                    if (!string.IsNullOrEmpty(__tmp118_line))
                    {
                        __out.Append(__tmp118_line);
                        __tmp115_outputWritten = true;
                    }
                    StringBuilder __tmp119 = new StringBuilder();
                    __tmp119.Append(op.Name);
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
                            if (!__tmp119_last || __tmp115_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp115_outputWritten)
                    {
                        __out.AppendLine(false); //647:86
                    }
                    __out.Append("	/// </summary>"); //648:1
                    __out.AppendLine(false); //648:16
                    bool __tmp121_outputWritten = false;
                    string __tmp122_line = "	public virtual "; //649:1
                    if (!string.IsNullOrEmpty(__tmp122_line))
                    {
                        __out.Append(__tmp122_line);
                        __tmp121_outputWritten = true;
                    }
                    StringBuilder __tmp123 = new StringBuilder();
                    __tmp123.Append(CSharpName(op.ReturnType, model, ClassKind.Immutable, true));
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
                    string __tmp124_line = " "; //649:77
                    if (!string.IsNullOrEmpty(__tmp124_line))
                    {
                        __out.Append(__tmp124_line);
                        __tmp121_outputWritten = true;
                    }
                    StringBuilder __tmp125 = new StringBuilder();
                    __tmp125.Append(CSharpName(enm, model, ClassKind.Immutable));
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
                    string __tmp126_line = "_"; //649:122
                    if (!string.IsNullOrEmpty(__tmp126_line))
                    {
                        __out.Append(__tmp126_line);
                        __tmp121_outputWritten = true;
                    }
                    StringBuilder __tmp127 = new StringBuilder();
                    __tmp127.Append(op.Name);
                    using(StreamReader __tmp127Reader = new StreamReader(this.__ToStream(__tmp127.ToString())))
                    {
                        bool __tmp127_last = __tmp127Reader.EndOfStream;
                        while(!__tmp127_last)
                        {
                            string __tmp127_line = __tmp127Reader.ReadLine();
                            __tmp127_last = __tmp127Reader.EndOfStream;
                            if ((__tmp127_last && !string.IsNullOrEmpty(__tmp127_line)) || (!__tmp127_last && __tmp127_line != null))
                            {
                                __out.Append(__tmp127_line);
                                __tmp121_outputWritten = true;
                            }
                            if (!__tmp127_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp128_line = "("; //649:132
                    if (!string.IsNullOrEmpty(__tmp128_line))
                    {
                        __out.Append(__tmp128_line);
                        __tmp121_outputWritten = true;
                    }
                    StringBuilder __tmp129 = new StringBuilder();
                    __tmp129.Append(GetImplParameters(model, enm, op));
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
                                __tmp121_outputWritten = true;
                            }
                            if (!__tmp129_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp130_line = ")"; //649:168
                    if (!string.IsNullOrEmpty(__tmp130_line))
                    {
                        __out.Append(__tmp130_line);
                        __tmp121_outputWritten = true;
                    }
                    if (__tmp121_outputWritten) __out.AppendLine(true);
                    if (__tmp121_outputWritten)
                    {
                        __out.AppendLine(false); //649:169
                    }
                    __out.Append("	{"); //650:1
                    __out.AppendLine(false); //650:3
                    __out.Append("		throw new NotImplementedException();"); //651:1
                    __out.AppendLine(false); //651:39
                    __out.Append("	}"); //652:1
                    __out.AppendLine(false); //652:3
                }
                __out.AppendLine(true); //654:2
            }
            __out.Append("}"); //656:1
            __out.AppendLine(false); //656:2
            return __out.ToString();
        }

        public string GetImplParameters(MetaModel model, MetaClass cls, MetaOperation op) //659:1
        {
            string result = CSharpName(cls, model, ClassKind.Immutable) + " _this"; //660:2
            string delim = ", "; //661:2
            var __loop43_results = 
                (from __loop43_var1 in __Enumerate((op).GetEnumerator()) //662:7
                from param in __Enumerate((__loop43_var1.Parameters).GetEnumerator()) //662:11
                select new { __loop43_var1 = __loop43_var1, param = param}
                ).ToList(); //662:2
            for (int __loop43_iteration = 0; __loop43_iteration < __loop43_results.Count; ++__loop43_iteration)
            {
                var __tmp1 = __loop43_results[__loop43_iteration];
                var __loop43_var1 = __tmp1.__loop43_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, ClassKind.Immutable, true) + " " + param.Name; //663:3
            }
            return result; //665:2
        }

        public string GetImplParameters(MetaModel model, MetaEnum enm, MetaOperation op) //668:1
        {
            string result = CSharpName(enm, model, ClassKind.Immutable) + " _this"; //669:2
            string delim = ", "; //670:2
            var __loop44_results = 
                (from __loop44_var1 in __Enumerate((op).GetEnumerator()) //671:7
                from param in __Enumerate((__loop44_var1.Parameters).GetEnumerator()) //671:11
                select new { __loop44_var1 = __loop44_var1, param = param}
                ).ToList(); //671:2
            for (int __loop44_iteration = 0; __loop44_iteration < __loop44_results.Count; ++__loop44_iteration)
            {
                var __tmp1 = __loop44_results[__loop44_iteration];
                var __loop44_var1 = __tmp1.__loop44_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, ClassKind.Immutable, true) + " " + param.Name; //672:3
            }
            return result; //674:2
        }

        public string GenerateEnum(MetaModel model, MetaEnum enm) //678:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //679:1
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
                __out.AppendLine(false); //680:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public enum "; //681:1
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
                __out.AppendLine(false); //681:36
            }
            __out.Append("{"); //682:1
            __out.AppendLine(false); //682:2
            var __loop45_results = 
                (from __loop45_var1 in __Enumerate((enm).GetEnumerator()) //683:8
                from value in __Enumerate((__loop45_var1.EnumLiterals).GetEnumerator()) //683:13
                select new { __loop45_var1 = __loop45_var1, value = value}
                ).ToList(); //683:3
            for (int __loop45_iteration = 0; __loop45_iteration < __loop45_results.Count; ++__loop45_iteration)
            {
                string delim; //683:31
                if (__loop45_iteration+1 < __loop45_results.Count) delim = ",";
                else delim = string.Empty;
                var __tmp8 = __loop45_results[__loop45_iteration];
                var __loop45_var1 = __tmp8.__loop45_var1;
                var value = __tmp8.value;
                bool __tmp10_outputWritten = false;
                string __tmp9Prefix = "	"; //684:1
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
                    __out.AppendLine(false); //684:32
                }
                bool __tmp13_outputWritten = false;
                string __tmp12Prefix = "	"; //685:1
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
                    __out.AppendLine(false); //685:21
                }
            }
            __out.Append("}"); //687:1
            __out.AppendLine(false); //687:2
            __out.AppendLine(true); //688:1
            bool __tmp17_outputWritten = false;
            string __tmp18_line = "public static class "; //689:1
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
            string __tmp20_line = "Extensions"; //689:31
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp17_outputWritten = true;
            }
            if (__tmp17_outputWritten) __out.AppendLine(true);
            if (__tmp17_outputWritten)
            {
                __out.AppendLine(false); //689:41
            }
            __out.Append("{"); //690:1
            __out.AppendLine(false); //690:2
            var __loop46_results = 
                (from __loop46_var1 in __Enumerate((enm).GetEnumerator()) //691:8
                from op in __Enumerate((__loop46_var1.Operations).GetEnumerator()) //691:13
                select new { __loop46_var1 = __loop46_var1, op = op}
                ).ToList(); //691:3
            for (int __loop46_iteration = 0; __loop46_iteration < __loop46_results.Count; ++__loop46_iteration)
            {
                var __tmp21 = __loop46_results[__loop46_iteration];
                var __loop46_var1 = __tmp21.__loop46_var1;
                var op = __tmp21.op;
                bool __tmp23_outputWritten = false;
                string __tmp24_line = "	public static "; //692:1
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Append(__tmp24_line);
                    __tmp23_outputWritten = true;
                }
                StringBuilder __tmp25 = new StringBuilder();
                __tmp25.Append(CSharpName(op.ReturnType, model, ClassKind.Immutable));
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
                string __tmp26_line = " "; //692:70
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
                string __tmp28_line = "("; //692:80
                if (!string.IsNullOrEmpty(__tmp28_line))
                {
                    __out.Append(__tmp28_line);
                    __tmp23_outputWritten = true;
                }
                StringBuilder __tmp29 = new StringBuilder();
                __tmp29.Append(GetEnumImplParameters(model, enm, op));
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
                string __tmp30_line = ")"; //692:120
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Append(__tmp30_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //692:121
                }
                __out.Append("	{"); //693:1
                __out.AppendLine(false); //693:3
                bool __tmp32_outputWritten = false;
                string __tmp31Prefix = "		"; //694:1
                StringBuilder __tmp33 = new StringBuilder();
                __tmp33.Append(GetReturn(model, op));
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
                string __tmp35_line = ".Implementation."; //694:77
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Append(__tmp35_line);
                    __tmp32_outputWritten = true;
                }
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(CSharpName(op.Parent, model, ClassKind.Immutable));
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
                string __tmp37_line = "_"; //694:143
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
                string __tmp39_line = "("; //694:153
                if (!string.IsNullOrEmpty(__tmp39_line))
                {
                    __out.Append(__tmp39_line);
                    __tmp32_outputWritten = true;
                }
                StringBuilder __tmp40 = new StringBuilder();
                __tmp40.Append(GetEnumImplCallParameterNames(model, op));
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
                string __tmp41_line = ");"; //694:196
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Append(__tmp41_line);
                    __tmp32_outputWritten = true;
                }
                if (__tmp32_outputWritten) __out.AppendLine(true);
                if (__tmp32_outputWritten)
                {
                    __out.AppendLine(false); //694:198
                }
                __out.Append("	}"); //695:1
                __out.AppendLine(false); //695:3
            }
            __out.Append("}"); //697:1
            __out.AppendLine(false); //697:2
            return __out.ToString();
        }

        public string GetEnumImplParameters(MetaModel model, MetaEnum enm, MetaOperation op) //700:1
        {
            string result = "this " + CSharpName(enm, model, ClassKind.Immutable) + " _this"; //701:2
            string delim = ", "; //702:2
            var __loop47_results = 
                (from __loop47_var1 in __Enumerate((op).GetEnumerator()) //703:7
                from param in __Enumerate((__loop47_var1.Parameters).GetEnumerator()) //703:11
                select new { __loop47_var1 = __loop47_var1, param = param}
                ).ToList(); //703:2
            for (int __loop47_iteration = 0; __loop47_iteration < __loop47_results.Count; ++__loop47_iteration)
            {
                var __tmp1 = __loop47_results[__loop47_iteration];
                var __loop47_var1 = __tmp1.__loop47_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, ClassKind.Immutable) + " " + param.Name; //704:3
            }
            return result; //706:2
        }

        public string GetEnumImplCallParameterNames(MetaModel model, MetaOperation op) //709:1
        {
            string result = "_this"; //710:2
            string delim = ", "; //711:2
            var __loop48_results = 
                (from __loop48_var1 in __Enumerate((op).GetEnumerator()) //712:7
                from param in __Enumerate((__loop48_var1.Parameters).GetEnumerator()) //712:11
                select new { __loop48_var1 = __loop48_var1, param = param}
                ).ToList(); //712:2
            for (int __loop48_iteration = 0; __loop48_iteration < __loop48_results.Count; ++__loop48_iteration)
            {
                var __tmp1 = __loop48_results[__loop48_iteration];
                var __loop48_var1 = __tmp1.__loop48_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //713:3
            }
            return result; //715:2
        }

        public string GetClassParameters(MetaModel model, MetaClass cls, MetaOperation op) //718:1
        {
            string result = ""; //719:2
            var __loop49_results = 
                (from __loop49_var1 in __Enumerate((op).GetEnumerator()) //720:7
                from param in __Enumerate((__loop49_var1.Parameters).GetEnumerator()) //720:11
                select new { __loop49_var1 = __loop49_var1, param = param}
                ).ToList(); //720:2
            for (int __loop49_iteration = 0; __loop49_iteration < __loop49_results.Count; ++__loop49_iteration)
            {
                string delim; //720:27
                if (__loop49_iteration+1 < __loop49_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop49_results[__loop49_iteration];
                var __loop49_var1 = __tmp1.__loop49_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, ClassKind.Immutable) + " " + param.Name + delim; //721:3
            }
            return result; //723:2
        }

        public string GetClassImplParameters(MetaModel model, MetaClass cls, MetaOperation op) //726:1
        {
            string result = CSharpName(cls, model, ClassKind.Immutable) + " _this"; //727:2
            string delim = ", "; //728:2
            var __loop50_results = 
                (from __loop50_var1 in __Enumerate((op).GetEnumerator()) //729:7
                from param in __Enumerate((__loop50_var1.Parameters).GetEnumerator()) //729:11
                select new { __loop50_var1 = __loop50_var1, param = param}
                ).ToList(); //729:2
            for (int __loop50_iteration = 0; __loop50_iteration < __loop50_results.Count; ++__loop50_iteration)
            {
                var __tmp1 = __loop50_results[__loop50_iteration];
                var __loop50_var1 = __tmp1.__loop50_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, ClassKind.Immutable) + " " + param.Name; //730:3
            }
            return result; //732:2
        }

        public string GetClassImplCallParameterNames(MetaModel model, MetaOperation op) //735:1
        {
            string result = "this"; //736:2
            string delim = ", "; //737:2
            var __loop51_results = 
                (from __loop51_var1 in __Enumerate((op).GetEnumerator()) //738:7
                from param in __Enumerate((__loop51_var1.Parameters).GetEnumerator()) //738:11
                select new { __loop51_var1 = __loop51_var1, param = param}
                ).ToList(); //738:2
            for (int __loop51_iteration = 0; __loop51_iteration < __loop51_results.Count; ++__loop51_iteration)
            {
                var __tmp1 = __loop51_results[__loop51_iteration];
                var __loop51_var1 = __tmp1.__loop51_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //739:3
            }
            return result; //741:2
        }

        public string GetReturn(MetaModel model, MetaOperation op) //744:1
        {
            if (CSharpName(op.ReturnType, model, ClassKind.Immutable) == "void") //745:5
            {
                return ""; //746:3
            }
            else //747:2
            {
                return "return "; //748:3
            }
        }

        public string GenerateClass(MetaModel model, MetaClass cls) //752:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //753:1
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
                __out.AppendLine(false); //754:37
            }
            __out.AppendLine(true); //755:1
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
                __out.AppendLine(false); //756:35
            }
            return __out.ToString();
        }

        public string GenerateClassInternal(MetaModel model, MetaClass cls) //759:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //760:1
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
                __out.AppendLine(false); //761:30
            }
            __out.AppendLine(true); //762:1
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
                __out.AppendLine(false); //763:41
            }
            __out.AppendLine(true); //764:1
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
                __out.AppendLine(false); //765:39
            }
            return __out.ToString();
        }

        public string GenerateIdClass(MetaModel model, MetaClass cls) //768:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //769:1
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
            string __tmp5_line = " : "; //769:53
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
            string __tmp7_line = ".SymbolId"; //769:75
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //769:84
            }
            __out.Append("{"); //770:1
            __out.AppendLine(false); //770:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public override "; //771:1
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
            string __tmp12_line = ".ModelSymbolInfo SymbolInfo { get { return "; //771:37
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
            string __tmp14_line = ".SymbolInfo; } }"; //771:130
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //771:146
            }
            __out.AppendLine(true); //772:1
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	public override "; //773:1
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
            string __tmp19_line = ".ImmutableSymbolBase CreateImmutable("; //773:37
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
            string __tmp21_line = ".ImmutableModel model)"; //773:93
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //773:115
            }
            __out.Append("	{"); //774:1
            __out.AppendLine(false); //774:3
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "		return new "; //775:1
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
            string __tmp26_line = "(this, model);"; //775:62
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //775:76
            }
            __out.Append("	}"); //776:1
            __out.AppendLine(false); //776:3
            __out.AppendLine(true); //777:1
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "	public override "; //778:1
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
            string __tmp31_line = ".MutableSymbolBase CreateMutable("; //778:37
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
            string __tmp33_line = ".MutableModel model, bool creating)"; //778:89
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Append(__tmp33_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //778:124
            }
            __out.Append("	{"); //779:1
            __out.AppendLine(false); //779:3
            bool __tmp35_outputWritten = false;
            string __tmp36_line = "		return new "; //780:1
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
            string __tmp38_line = "(this, model, creating);"; //780:60
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Append(__tmp38_line);
                __tmp35_outputWritten = true;
            }
            if (__tmp35_outputWritten) __out.AppendLine(true);
            if (__tmp35_outputWritten)
            {
                __out.AppendLine(false); //780:84
            }
            __out.Append("	}"); //781:1
            __out.AppendLine(false); //781:3
            __out.Append("}"); //782:1
            __out.AppendLine(false); //782:2
            return __out.ToString();
        }

        public string GenerateImmutableClass(MetaModel model, MetaClass cls) //785:1
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
                __out.AppendLine(false); //786:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //787:1
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
                    if (!__tmp8_last || __tmp5_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //787:97
            }
            __out.Append("{"); //788:1
            __out.AppendLine(false); //788:2
            var __loop52_results = 
                (from __loop52_var1 in __Enumerate((cls).GetEnumerator()) //789:8
                from prop in __Enumerate((__loop52_var1.Properties).GetEnumerator()) //789:13
                select new { __loop52_var1 = __loop52_var1, prop = prop}
                ).ToList(); //789:3
            for (int __loop52_iteration = 0; __loop52_iteration < __loop52_results.Count; ++__loop52_iteration)
            {
                var __tmp9 = __loop52_results[__loop52_iteration];
                var __loop52_var1 = __tmp9.__loop52_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //790:1
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(GenerateImmutableProperty(model, prop));
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
                    __out.AppendLine(false); //790:42
                }
            }
            __out.AppendLine(true); //792:1
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((cls).GetEnumerator()) //793:8
                from op in __Enumerate((__loop53_var1.Operations).GetEnumerator()) //793:13
                select new { __loop53_var1 = __loop53_var1, op = op}
                ).ToList(); //793:3
            for (int __loop53_iteration = 0; __loop53_iteration < __loop53_results.Count; ++__loop53_iteration)
            {
                var __tmp13 = __loop53_results[__loop53_iteration];
                var __loop53_var1 = __tmp13.__loop53_var1;
                var op = __tmp13.op;
                bool __tmp15_outputWritten = false;
                string __tmp14Prefix = "	"; //794:1
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(GenerateImmutableOperation(model, op));
                using(StreamReader __tmp16Reader = new StreamReader(this.__ToStream(__tmp16.ToString())))
                {
                    bool __tmp16_last = __tmp16Reader.EndOfStream;
                    while(!__tmp16_last)
                    {
                        string __tmp16_line = __tmp16Reader.ReadLine();
                        __tmp16_last = __tmp16Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp14Prefix))
                        {
                            __out.Append(__tmp14Prefix);
                            __tmp15_outputWritten = true;
                        }
                        if ((__tmp16_last && !string.IsNullOrEmpty(__tmp16_line)) || (!__tmp16_last && __tmp16_line != null))
                        {
                            __out.Append(__tmp16_line);
                            __tmp15_outputWritten = true;
                        }
                        if (!__tmp16_last || __tmp15_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //794:41
                }
            }
            __out.AppendLine(true); //796:1
            bool __tmp18_outputWritten = false;
            string __tmp19_line = "	new "; //797:1
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp18_outputWritten = true;
            }
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(CSharpName(cls, model, ClassKind.Builder, true));
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
            string __tmp21_line = " ToMutable();"; //797:54
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //797:67
            }
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	new "; //798:1
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp23_outputWritten = true;
            }
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(CSharpName(cls, model, ClassKind.Builder, true));
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
            string __tmp26_line = " ToMutable("; //798:54
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
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
                        __tmp23_outputWritten = true;
                    }
                    if (!__tmp27_last) __out.AppendLine(true);
                }
            }
            string __tmp28_line = ".MutableModel model);"; //798:84
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Append(__tmp28_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //798:105
            }
            __out.Append("}"); //799:1
            __out.AppendLine(false); //799:2
            return __out.ToString();
        }

        public string GenerateImmutableProperty(MetaModel model, MetaProperty prop) //802:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //803:2
            {
                __out.Append("new "); //804:1
            }
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(CSharpName(prop.Type, model, ClassKind.Immutable, true));
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
            string __tmp4_line = " "; //806:57
            if (!string.IsNullOrEmpty(__tmp4_line))
            {
                __out.Append(__tmp4_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(CSharpName(prop, model, PropertyKind.Immutable));
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
            string __tmp6_line = " { get; }"; //806:106
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Append(__tmp6_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //806:115
            }
            return __out.ToString();
        }

        public string GenerateImmutableOperation(MetaModel model, MetaOperation op) //809:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(CSharpName(op.ReturnType, model, ClassKind.Immutable, true));
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
            string __tmp4_line = " "; //810:61
            if (!string.IsNullOrEmpty(__tmp4_line))
            {
                __out.Append(__tmp4_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(op.Name);
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
            string __tmp6_line = "("; //810:71
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Append(__tmp6_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(GetImmutableOperationParameters(model, op));
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
            string __tmp8_line = ");"; //810:116
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Append(__tmp8_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //810:118
            }
            return __out.ToString();
        }

        public string GetImmutableOperationParameters(MetaModel model, MetaOperation op) //813:1
        {
            string result = ""; //814:2
            var __loop54_results = 
                (from __loop54_var1 in __Enumerate((op).GetEnumerator()) //815:7
                from param in __Enumerate((__loop54_var1.Parameters).GetEnumerator()) //815:11
                select new { __loop54_var1 = __loop54_var1, param = param}
                ).ToList(); //815:2
            for (int __loop54_iteration = 0; __loop54_iteration < __loop54_results.Count; ++__loop54_iteration)
            {
                string delim; //815:27
                if (__loop54_iteration+1 < __loop54_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop54_results[__loop54_iteration];
                var __loop54_var1 = __tmp1.__loop54_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, ClassKind.Immutable, true) + " " + param.Name + delim; //816:3
            }
            return result; //818:2
        }

        public string GetImmutableAncestors(MetaModel model, MetaClass cls) //821:1
        {
            string result = ""; //822:2
            var __loop55_results = 
                (from __loop55_var1 in __Enumerate((cls).GetEnumerator()) //823:7
                from super in __Enumerate((__loop55_var1.SuperClasses).GetEnumerator()) //823:12
                select new { __loop55_var1 = __loop55_var1, super = super}
                ).ToList(); //823:2
            for (int __loop55_iteration = 0; __loop55_iteration < __loop55_results.Count; ++__loop55_iteration)
            {
                string delim; //823:30
                if (__loop55_iteration+1 < __loop55_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop55_results[__loop55_iteration];
                var __loop55_var1 = __tmp1.__loop55_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Immutable, true) + delim; //824:3
            }
            if (result == "") //826:2
            {
                result = Properties.CoreNs + ".ImmutableSymbol"; //827:3
            }
            result = " : " + result; //829:2
            return result; //830:2
        }

        public string GenerateBuilderClass(MetaModel model, MetaClass cls) //833:1
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
                __out.AppendLine(false); //834:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //835:1
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
                    if (!__tmp8_last || __tmp5_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //835:93
            }
            __out.Append("{"); //836:1
            __out.AppendLine(false); //836:2
            var __loop56_results = 
                (from __loop56_var1 in __Enumerate((cls).GetEnumerator()) //837:8
                from prop in __Enumerate((__loop56_var1.Properties).GetEnumerator()) //837:13
                select new { __loop56_var1 = __loop56_var1, prop = prop}
                ).ToList(); //837:3
            for (int __loop56_iteration = 0; __loop56_iteration < __loop56_results.Count; ++__loop56_iteration)
            {
                var __tmp9 = __loop56_results[__loop56_iteration];
                var __loop56_var1 = __tmp9.__loop56_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //838:1
                StringBuilder __tmp12 = new StringBuilder();
                __tmp12.Append(GenerateBuilderProperty(model, prop));
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
                    __out.AppendLine(false); //838:40
                }
            }
            __out.AppendLine(true); //840:1
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	new "; //841:1
            if (!string.IsNullOrEmpty(__tmp15_line))
            {
                __out.Append(__tmp15_line);
                __tmp14_outputWritten = true;
            }
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(CSharpName(cls, model, ClassKind.Immutable, true));
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
            string __tmp17_line = " ToImmutable();"; //841:56
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //841:71
            }
            bool __tmp19_outputWritten = false;
            string __tmp20_line = "	new "; //842:1
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp19_outputWritten = true;
            }
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(CSharpName(cls, model, ClassKind.Immutable, true));
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
            string __tmp22_line = " ToImmutable("; //842:56
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Append(__tmp22_line);
                __tmp19_outputWritten = true;
            }
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append(Properties.CoreNs);
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
            string __tmp24_line = ".ImmutableModel model);"; //842:88
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp19_outputWritten = true;
            }
            if (__tmp19_outputWritten) __out.AppendLine(true);
            if (__tmp19_outputWritten)
            {
                __out.AppendLine(false); //842:111
            }
            __out.Append("}"); //843:1
            __out.AppendLine(false); //843:2
            return __out.ToString();
        }

        public string GenerateBuilderProperty(MetaModel model, MetaProperty prop) //846:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //847:3
            {
                __out.Append("new "); //848:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //850:3
            {
                bool __tmp2_outputWritten = false;
                StringBuilder __tmp3 = new StringBuilder();
                __tmp3.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
                string __tmp4_line = " "; //851:55
                if (!string.IsNullOrEmpty(__tmp4_line))
                {
                    __out.Append(__tmp4_line);
                    __tmp2_outputWritten = true;
                }
                StringBuilder __tmp5 = new StringBuilder();
                __tmp5.Append(CSharpName(prop, model, PropertyKind.Builder));
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
                string __tmp6_line = " { get; set; }"; //851:102
                if (!string.IsNullOrEmpty(__tmp6_line))
                {
                    __out.Append(__tmp6_line);
                    __tmp2_outputWritten = true;
                }
                if (__tmp2_outputWritten) __out.AppendLine(true);
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //851:116
                }
            }
            else //852:3
            {
                bool __tmp8_outputWritten = false;
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
                string __tmp10_line = " "; //853:55
                if (!string.IsNullOrEmpty(__tmp10_line))
                {
                    __out.Append(__tmp10_line);
                    __tmp8_outputWritten = true;
                }
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(CSharpName(prop, model, PropertyKind.Builder));
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
                string __tmp12_line = " { get; }"; //853:102
                if (!string.IsNullOrEmpty(__tmp12_line))
                {
                    __out.Append(__tmp12_line);
                    __tmp8_outputWritten = true;
                }
                if (__tmp8_outputWritten) __out.AppendLine(true);
                if (__tmp8_outputWritten)
                {
                    __out.AppendLine(false); //853:111
                }
            }
            if (!(prop.Type is MetaCollectionType)) //855:3
            {
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //856:4
                {
                    __out.Append("new "); //857:1
                }
                bool __tmp14_outputWritten = false;
                string __tmp15_line = "Func<"; //859:1
                if (!string.IsNullOrEmpty(__tmp15_line))
                {
                    __out.Append(__tmp15_line);
                    __tmp14_outputWritten = true;
                }
                StringBuilder __tmp16 = new StringBuilder();
                __tmp16.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
                string __tmp17_line = "> "; //859:60
                if (!string.IsNullOrEmpty(__tmp17_line))
                {
                    __out.Append(__tmp17_line);
                    __tmp14_outputWritten = true;
                }
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(CSharpName(prop, model, PropertyKind.Builder));
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
                string __tmp19_line = "Lazy { get; set; }"; //859:108
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Append(__tmp19_line);
                    __tmp14_outputWritten = true;
                }
                if (__tmp14_outputWritten) __out.AppendLine(true);
                if (__tmp14_outputWritten)
                {
                    __out.AppendLine(false); //859:126
                }
            }
            return __out.ToString();
        }

        public string GetBuilderAncestors(MetaModel model, MetaClass cls) //863:1
        {
            string result = ""; //864:2
            var __loop57_results = 
                (from __loop57_var1 in __Enumerate((cls).GetEnumerator()) //865:7
                from super in __Enumerate((__loop57_var1.SuperClasses).GetEnumerator()) //865:12
                select new { __loop57_var1 = __loop57_var1, super = super}
                ).ToList(); //865:2
            for (int __loop57_iteration = 0; __loop57_iteration < __loop57_results.Count; ++__loop57_iteration)
            {
                string delim; //865:30
                if (__loop57_iteration+1 < __loop57_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop57_results[__loop57_iteration];
                var __loop57_var1 = __tmp1.__loop57_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Builder, true) + delim; //866:3
            }
            if (result == "") //868:2
            {
                result = Properties.CoreNs + ".MutableSymbol"; //869:3
            }
            result = " : " + result; //871:2
            return result; //872:2
        }

        public string GenerateImmutableImplClass(MetaModel model, MetaClass cls) //875:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //876:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //877:1
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
            string __tmp5_line = " : "; //877:64
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
            string __tmp7_line = ".ImmutableSymbolBase, "; //877:86
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
                __out.AppendLine(false); //877:152
            }
            __out.Append("{"); //878:1
            __out.AppendLine(false); //878:2
            var __loop58_results = 
                (from __loop58_var1 in __Enumerate((cls).GetEnumerator()) //879:8
                from prop in __Enumerate((__loop58_var1.GetAllProperties()).GetEnumerator()) //879:13
                select new { __loop58_var1 = __loop58_var1, prop = prop}
                ).ToList(); //879:3
            for (int __loop58_iteration = 0; __loop58_iteration < __loop58_results.Count; ++__loop58_iteration)
            {
                var __tmp9 = __loop58_results[__loop58_iteration];
                var __loop58_var1 = __tmp9.__loop58_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //880:1
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
                    __out.AppendLine(false); //880:44
                }
            }
            __out.AppendLine(true); //882:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //883:1
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
            string __tmp17_line = "("; //883:59
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
            string __tmp19_line = ".SymbolId id, "; //883:79
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
            string __tmp21_line = ".ImmutableModel model)"; //883:112
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //883:134
            }
            __out.Append("		: base(id, model)"); //884:1
            __out.AppendLine(false); //884:20
            __out.Append("	{"); //885:1
            __out.AppendLine(false); //885:3
            __out.Append("	}"); //886:1
            __out.AppendLine(false); //886:3
            __out.AppendLine(true); //887:2
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	public override "; //888:1
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp23_outputWritten = true;
            }
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(metaNs);
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
            string __tmp26_line = "MetaModel MMetaModel"; //888:26
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //888:46
            }
            __out.Append("	{"); //889:1
            __out.AppendLine(false); //889:3
            if (IsMetaMetaModel(model)) //890:4
            {
                bool __tmp28_outputWritten = false;
                string __tmp29_line = "		get { return "; //891:1
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
                string __tmp31_line = ".MetaMetaModel; }"; //891:77
                if (!string.IsNullOrEmpty(__tmp31_line))
                {
                    __out.Append(__tmp31_line);
                    __tmp28_outputWritten = true;
                }
                if (__tmp28_outputWritten) __out.AppendLine(true);
                if (__tmp28_outputWritten)
                {
                    __out.AppendLine(false); //891:94
                }
            }
            else //892:4
            {
                bool __tmp33_outputWritten = false;
                string __tmp34_line = "		get { return "; //893:1
                if (!string.IsNullOrEmpty(__tmp34_line))
                {
                    __out.Append(__tmp34_line);
                    __tmp33_outputWritten = true;
                }
                StringBuilder __tmp35 = new StringBuilder();
                __tmp35.Append(CSharpName(cls.MetaModel, ModelKind.ImmutableInstance, true));
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
                string __tmp36_line = ".MetaModel; }"; //893:77
                if (!string.IsNullOrEmpty(__tmp36_line))
                {
                    __out.Append(__tmp36_line);
                    __tmp33_outputWritten = true;
                }
                if (__tmp33_outputWritten) __out.AppendLine(true);
                if (__tmp33_outputWritten)
                {
                    __out.AppendLine(false); //893:90
                }
            }
            __out.Append("	}"); //895:1
            __out.AppendLine(false); //895:3
            __out.AppendLine(true); //896:2
            bool __tmp38_outputWritten = false;
            string __tmp39_line = "	public override "; //897:1
            if (!string.IsNullOrEmpty(__tmp39_line))
            {
                __out.Append(__tmp39_line);
                __tmp38_outputWritten = true;
            }
            StringBuilder __tmp40 = new StringBuilder();
            __tmp40.Append(metaNs);
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
            string __tmp41_line = "MetaClass MMetaClass"; //897:26
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Append(__tmp41_line);
                __tmp38_outputWritten = true;
            }
            if (__tmp38_outputWritten) __out.AppendLine(true);
            if (__tmp38_outputWritten)
            {
                __out.AppendLine(false); //897:46
            }
            __out.Append("	{"); //898:1
            __out.AppendLine(false); //898:3
            bool __tmp43_outputWritten = false;
            string __tmp44_line = "		get { return "; //899:1
            if (!string.IsNullOrEmpty(__tmp44_line))
            {
                __out.Append(__tmp44_line);
                __tmp43_outputWritten = true;
            }
            StringBuilder __tmp45 = new StringBuilder();
            __tmp45.Append(CSharpName(cls, model, ClassKind.ImmutableInstance, true));
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
            string __tmp46_line = "; }"; //899:74
            if (!string.IsNullOrEmpty(__tmp46_line))
            {
                __out.Append(__tmp46_line);
                __tmp43_outputWritten = true;
            }
            if (__tmp43_outputWritten) __out.AppendLine(true);
            if (__tmp43_outputWritten)
            {
                __out.AppendLine(false); //899:77
            }
            __out.Append("	}"); //900:1
            __out.AppendLine(false); //900:3
            __out.AppendLine(true); //901:2
            bool __tmp48_outputWritten = false;
            string __tmp49_line = "	public new "; //902:1
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
            string __tmp51_line = " ToMutable()"; //902:55
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Append(__tmp51_line);
                __tmp48_outputWritten = true;
            }
            if (__tmp48_outputWritten) __out.AppendLine(true);
            if (__tmp48_outputWritten)
            {
                __out.AppendLine(false); //902:67
            }
            __out.Append("	{"); //903:1
            __out.AppendLine(false); //903:3
            bool __tmp53_outputWritten = false;
            string __tmp54_line = "		return ("; //904:1
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
            string __tmp56_line = ")base.ToMutable();"; //904:53
            if (!string.IsNullOrEmpty(__tmp56_line))
            {
                __out.Append(__tmp56_line);
                __tmp53_outputWritten = true;
            }
            if (__tmp53_outputWritten) __out.AppendLine(true);
            if (__tmp53_outputWritten)
            {
                __out.AppendLine(false); //904:71
            }
            __out.Append("	}"); //905:1
            __out.AppendLine(false); //905:3
            __out.AppendLine(true); //906:2
            bool __tmp58_outputWritten = false;
            string __tmp59_line = "	public new "; //907:1
            if (!string.IsNullOrEmpty(__tmp59_line))
            {
                __out.Append(__tmp59_line);
                __tmp58_outputWritten = true;
            }
            StringBuilder __tmp60 = new StringBuilder();
            __tmp60.Append(CSharpName(cls, model, ClassKind.Builder));
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
                        __tmp58_outputWritten = true;
                    }
                    if (!__tmp60_last) __out.AppendLine(true);
                }
            }
            string __tmp61_line = " ToMutable("; //907:55
            if (!string.IsNullOrEmpty(__tmp61_line))
            {
                __out.Append(__tmp61_line);
                __tmp58_outputWritten = true;
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
                        __tmp58_outputWritten = true;
                    }
                    if (!__tmp62_last) __out.AppendLine(true);
                }
            }
            string __tmp63_line = ".MutableModel model)"; //907:85
            if (!string.IsNullOrEmpty(__tmp63_line))
            {
                __out.Append(__tmp63_line);
                __tmp58_outputWritten = true;
            }
            if (__tmp58_outputWritten) __out.AppendLine(true);
            if (__tmp58_outputWritten)
            {
                __out.AppendLine(false); //907:105
            }
            __out.Append("	{"); //908:1
            __out.AppendLine(false); //908:3
            bool __tmp65_outputWritten = false;
            string __tmp66_line = "		return ("; //909:1
            if (!string.IsNullOrEmpty(__tmp66_line))
            {
                __out.Append(__tmp66_line);
                __tmp65_outputWritten = true;
            }
            StringBuilder __tmp67 = new StringBuilder();
            __tmp67.Append(CSharpName(cls, model, ClassKind.Builder));
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
            string __tmp68_line = ")base.ToMutable(model);"; //909:53
            if (!string.IsNullOrEmpty(__tmp68_line))
            {
                __out.Append(__tmp68_line);
                __tmp65_outputWritten = true;
            }
            if (__tmp65_outputWritten) __out.AppendLine(true);
            if (__tmp65_outputWritten)
            {
                __out.AppendLine(false); //909:76
            }
            __out.Append("	}"); //910:1
            __out.AppendLine(false); //910:3
            var __loop59_results = 
                (from __loop59_var1 in __Enumerate((cls).GetEnumerator()) //911:8
                from sup in __Enumerate((__loop59_var1.GetAllSuperClasses(false)).GetEnumerator()) //911:13
                select new { __loop59_var1 = __loop59_var1, sup = sup}
                ).ToList(); //911:3
            for (int __loop59_iteration = 0; __loop59_iteration < __loop59_results.Count; ++__loop59_iteration)
            {
                var __tmp69 = __loop59_results[__loop59_iteration];
                var __loop59_var1 = __tmp69.__loop59_var1;
                var sup = __tmp69.sup;
                __out.AppendLine(true); //912:2
                bool __tmp71_outputWritten = false;
                string __tmp70Prefix = "	"; //913:1
                StringBuilder __tmp72 = new StringBuilder();
                __tmp72.Append(CSharpName(sup, model, ClassKind.Builder, true));
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
                        if (!__tmp72_last) __out.AppendLine(true);
                    }
                }
                string __tmp73_line = " "; //913:50
                if (!string.IsNullOrEmpty(__tmp73_line))
                {
                    __out.Append(__tmp73_line);
                    __tmp71_outputWritten = true;
                }
                StringBuilder __tmp74 = new StringBuilder();
                __tmp74.Append(CSharpName(sup, model, ClassKind.Immutable, true));
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
                string __tmp75_line = ".ToMutable()"; //913:101
                if (!string.IsNullOrEmpty(__tmp75_line))
                {
                    __out.Append(__tmp75_line);
                    __tmp71_outputWritten = true;
                }
                if (__tmp71_outputWritten) __out.AppendLine(true);
                if (__tmp71_outputWritten)
                {
                    __out.AppendLine(false); //913:113
                }
                __out.Append("	{"); //914:1
                __out.AppendLine(false); //914:3
                __out.Append("		return this.ToMutable();"); //915:1
                __out.AppendLine(false); //915:27
                __out.Append("	}"); //916:1
                __out.AppendLine(false); //916:3
                __out.AppendLine(true); //917:2
                bool __tmp77_outputWritten = false;
                string __tmp76Prefix = "	"; //918:1
                StringBuilder __tmp78 = new StringBuilder();
                __tmp78.Append(CSharpName(sup, model, ClassKind.Builder, true));
                using(StreamReader __tmp78Reader = new StreamReader(this.__ToStream(__tmp78.ToString())))
                {
                    bool __tmp78_last = __tmp78Reader.EndOfStream;
                    while(!__tmp78_last)
                    {
                        string __tmp78_line = __tmp78Reader.ReadLine();
                        __tmp78_last = __tmp78Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp76Prefix))
                        {
                            __out.Append(__tmp76Prefix);
                            __tmp77_outputWritten = true;
                        }
                        if ((__tmp78_last && !string.IsNullOrEmpty(__tmp78_line)) || (!__tmp78_last && __tmp78_line != null))
                        {
                            __out.Append(__tmp78_line);
                            __tmp77_outputWritten = true;
                        }
                        if (!__tmp78_last) __out.AppendLine(true);
                    }
                }
                string __tmp79_line = " "; //918:50
                if (!string.IsNullOrEmpty(__tmp79_line))
                {
                    __out.Append(__tmp79_line);
                    __tmp77_outputWritten = true;
                }
                StringBuilder __tmp80 = new StringBuilder();
                __tmp80.Append(CSharpName(sup, model, ClassKind.Immutable, true));
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
                            __tmp77_outputWritten = true;
                        }
                        if (!__tmp80_last) __out.AppendLine(true);
                    }
                }
                string __tmp81_line = ".ToMutable("; //918:101
                if (!string.IsNullOrEmpty(__tmp81_line))
                {
                    __out.Append(__tmp81_line);
                    __tmp77_outputWritten = true;
                }
                StringBuilder __tmp82 = new StringBuilder();
                __tmp82.Append(Properties.CoreNs);
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
                            __tmp77_outputWritten = true;
                        }
                        if (!__tmp82_last) __out.AppendLine(true);
                    }
                }
                string __tmp83_line = ".MutableModel model)"; //918:131
                if (!string.IsNullOrEmpty(__tmp83_line))
                {
                    __out.Append(__tmp83_line);
                    __tmp77_outputWritten = true;
                }
                if (__tmp77_outputWritten) __out.AppendLine(true);
                if (__tmp77_outputWritten)
                {
                    __out.AppendLine(false); //918:151
                }
                __out.Append("	{"); //919:1
                __out.AppendLine(false); //919:3
                __out.Append("		return this.ToMutable(model);"); //920:1
                __out.AppendLine(false); //920:32
                __out.Append("	}"); //921:1
                __out.AppendLine(false); //921:3
            }
            var __loop60_results = 
                (from __loop60_var1 in __Enumerate((cls).GetEnumerator()) //923:8
                from prop in __Enumerate((__loop60_var1.GetAllProperties()).GetEnumerator()) //923:13
                select new { __loop60_var1 = __loop60_var1, prop = prop}
                ).ToList(); //923:3
            for (int __loop60_iteration = 0; __loop60_iteration < __loop60_results.Count; ++__loop60_iteration)
            {
                var __tmp84 = __loop60_results[__loop60_iteration];
                var __loop60_var1 = __tmp84.__loop60_var1;
                var prop = __tmp84.prop;
                __out.AppendLine(true); //924:2
                bool __tmp86_outputWritten = false;
                string __tmp85Prefix = "	"; //925:1
                StringBuilder __tmp87 = new StringBuilder();
                __tmp87.Append(GenerateImmutablePropertyImpl(model, cls, prop));
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
                        if (!__tmp87_last || __tmp86_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp86_outputWritten)
                {
                    __out.AppendLine(false); //925:51
                }
            }
            var __loop61_results = 
                (from __loop61_var1 in __Enumerate((cls).GetEnumerator()) //927:8
                from op in __Enumerate((__loop61_var1.GetAllOperations()).GetEnumerator()) //927:13
                select new { __loop61_var1 = __loop61_var1, op = op}
                ).ToList(); //927:3
            for (int __loop61_iteration = 0; __loop61_iteration < __loop61_results.Count; ++__loop61_iteration)
            {
                var __tmp88 = __loop61_results[__loop61_iteration];
                var __loop61_var1 = __tmp88.__loop61_var1;
                var op = __tmp88.op;
                __out.AppendLine(true); //928:2
                bool __tmp90_outputWritten = false;
                string __tmp89Prefix = "	"; //929:1
                StringBuilder __tmp91 = new StringBuilder();
                __tmp91.Append(GenerateImmutableOperationImpl(model, cls, op));
                using(StreamReader __tmp91Reader = new StreamReader(this.__ToStream(__tmp91.ToString())))
                {
                    bool __tmp91_last = __tmp91Reader.EndOfStream;
                    while(!__tmp91_last)
                    {
                        string __tmp91_line = __tmp91Reader.ReadLine();
                        __tmp91_last = __tmp91Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp89Prefix))
                        {
                            __out.Append(__tmp89Prefix);
                            __tmp90_outputWritten = true;
                        }
                        if ((__tmp91_last && !string.IsNullOrEmpty(__tmp91_line)) || (!__tmp91_last && __tmp91_line != null))
                        {
                            __out.Append(__tmp91_line);
                            __tmp90_outputWritten = true;
                        }
                        if (!__tmp91_last || __tmp90_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp90_outputWritten)
                {
                    __out.AppendLine(false); //929:50
                }
            }
            __out.Append("}"); //931:1
            __out.AppendLine(false); //931:2
            return __out.ToString();
        }

        public string GenerateImmutableField(MetaModel model, MetaClass cls, MetaProperty prop) //934:1
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
                __out.AppendLine(false); //935:54
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "private "; //936:1
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
            string __tmp8_line = " "; //936:65
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
            string __tmp10_line = ";"; //936:90
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //936:91
            }
            return __out.ToString();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //939:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //940:1
            if (cls.GetAllFinalProperties().Contains(prop)) //941:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //942:1
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
                string __tmp5_line = " "; //942:64
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
                    __out.AppendLine(false); //942:76
                }
            }
            else //943:2
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
                    __out.AppendLine(false); //944:54
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
                string __tmp13_line = " "; //945:57
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
                string __tmp15_line = "."; //945:115
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
                    __out.AppendLine(false); //945:127
                }
            }
            __out.Append("{"); //947:1
            __out.AppendLine(false); //947:2
            if (prop.Type is MetaCollectionType) //948:6
            {
                if (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.Set || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet) //949:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "    get { return this.GetSet<"; //950:1
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
                    string __tmp21_line = ">("; //950:118
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
                    string __tmp23_line = ", ref "; //950:174
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
                    string __tmp25_line = "); }"; //950:204
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Append(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //950:208
                    }
                }
                else //951:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "    get { return this.GetList<"; //952:1
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
                    string __tmp30_line = ">("; //952:119
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
                    string __tmp32_line = ", ref "; //952:175
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
                    string __tmp34_line = "); }"; //952:205
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Append(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //952:209
                    }
                }
            }
            else if (IsReferenceType(prop.Type)) //954:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "    get { return this.GetReference<"; //955:1
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
                string __tmp39_line = ">("; //955:92
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
                string __tmp41_line = ", ref "; //955:148
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
                string __tmp43_line = "); }"; //955:178
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Append(__tmp43_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //955:182
                }
            }
            else //956:3
            {
                bool __tmp45_outputWritten = false;
                string __tmp46_line = "    get { return this.GetValue<"; //957:1
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
                string __tmp48_line = ">("; //957:88
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
                string __tmp50_line = ", ref "; //957:144
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
                string __tmp52_line = "); }"; //957:174
                if (!string.IsNullOrEmpty(__tmp52_line))
                {
                    __out.Append(__tmp52_line);
                    __tmp45_outputWritten = true;
                }
                if (__tmp45_outputWritten) __out.AppendLine(true);
                if (__tmp45_outputWritten)
                {
                    __out.AppendLine(false); //957:178
                }
            }
            __out.Append("}"); //959:1
            __out.AppendLine(false); //959:2
            return __out.ToString();
        }

        public string GenerateImmutableOperationImpl(MetaModel model, MetaClass cls, MetaOperation op) //962:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //963:1
            bool __tmp2_outputWritten = false;
            StringBuilder __tmp3 = new StringBuilder();
            __tmp3.Append(CSharpName(op.ReturnType, model, ClassKind.Immutable, true));
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
            string __tmp4_line = " "; //964:61
            if (!string.IsNullOrEmpty(__tmp4_line))
            {
                __out.Append(__tmp4_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp5 = new StringBuilder();
            __tmp5.Append(CSharpName(op.Parent, model, ClassKind.Immutable, true));
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
            string __tmp6_line = "."; //964:118
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
            string __tmp8_line = "("; //964:128
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Append(__tmp8_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp9 = new StringBuilder();
            __tmp9.Append(GetClassParameters(model, (MetaClass)op.Parent, op));
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
            string __tmp10_line = ")"; //964:182
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //964:183
            }
            __out.Append("{"); //965:1
            __out.AppendLine(false); //965:2
            bool __tmp12_outputWritten = false;
            string __tmp11Prefix = "    "; //966:1
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(GetReturn(model, op));
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
            __tmp14.Append(CSharpName(model, ModelKind.ImplementationProvider, true));
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
            string __tmp15_line = ".Implementation."; //966:85
            if (!string.IsNullOrEmpty(__tmp15_line))
            {
                __out.Append(__tmp15_line);
                __tmp12_outputWritten = true;
            }
            StringBuilder __tmp16 = new StringBuilder();
            __tmp16.Append(CSharpName(op.Parent, model, ClassKind.Immutable));
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
            string __tmp17_line = "_"; //966:151
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp12_outputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(op.Name);
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
            string __tmp19_line = "("; //966:161
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp12_outputWritten = true;
            }
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(GetClassImplCallParameterNames(model, op));
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
            string __tmp21_line = ");"; //966:205
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp12_outputWritten = true;
            }
            if (__tmp12_outputWritten) __out.AppendLine(true);
            if (__tmp12_outputWritten)
            {
                __out.AppendLine(false); //966:207
            }
            __out.Append("}"); //967:1
            __out.AppendLine(false); //967:2
            return __out.ToString();
        }

        public string GenerateBuilderImplClass(MetaModel model, MetaClass cls) //970:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //971:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //972:1
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
            string __tmp5_line = " : "; //972:62
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
            string __tmp7_line = ".MutableSymbolBase, "; //972:84
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
                __out.AppendLine(false); //972:146
            }
            __out.Append("{"); //973:1
            __out.AppendLine(false); //973:2
            var __loop62_results = 
                (from __loop62_var1 in __Enumerate((cls).GetEnumerator()) //974:8
                from prop in __Enumerate((__loop62_var1.GetAllProperties()).GetEnumerator()) //974:13
                where prop.Type is MetaCollectionType //974:37
                select new { __loop62_var1 = __loop62_var1, prop = prop}
                ).ToList(); //974:3
            for (int __loop62_iteration = 0; __loop62_iteration < __loop62_results.Count; ++__loop62_iteration)
            {
                var __tmp9 = __loop62_results[__loop62_iteration];
                var __loop62_var1 = __tmp9.__loop62_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //975:1
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
                    __out.AppendLine(false); //975:42
                }
            }
            __out.AppendLine(true); //977:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //978:1
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
            string __tmp17_line = "("; //978:57
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
            string __tmp19_line = ".SymbolId id, "; //978:77
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
            string __tmp21_line = ".MutableModel model, bool creating)"; //978:110
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //978:145
            }
            __out.Append("		: base(id, model, creating)"); //979:1
            __out.AppendLine(false); //979:30
            __out.Append("	{"); //980:1
            __out.AppendLine(false); //980:3
            __out.Append("	}"); //981:1
            __out.AppendLine(false); //981:3
            __out.AppendLine(true); //982:2
            __out.Append("	protected override void MInit()"); //983:1
            __out.AppendLine(false); //983:33
            __out.Append("	{"); //984:1
            __out.AppendLine(false); //984:3
            bool __tmp23_outputWritten = false;
            string __tmp22Prefix = "		"; //985:1
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
            string __tmp25_line = ".Implementation."; //985:55
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
            string __tmp27_line = "(this);"; //985:115
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Append(__tmp27_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //985:122
            }
            __out.Append("	}"); //986:1
            __out.AppendLine(false); //986:3
            __out.AppendLine(true); //987:2
            bool __tmp29_outputWritten = false;
            string __tmp30_line = "	public override "; //988:1
            if (!string.IsNullOrEmpty(__tmp30_line))
            {
                __out.Append(__tmp30_line);
                __tmp29_outputWritten = true;
            }
            StringBuilder __tmp31 = new StringBuilder();
            __tmp31.Append(metaNs);
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
                        __tmp29_outputWritten = true;
                    }
                    if (!__tmp31_last) __out.AppendLine(true);
                }
            }
            string __tmp32_line = "MetaModel MMetaModel"; //988:26
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Append(__tmp32_line);
                __tmp29_outputWritten = true;
            }
            if (__tmp29_outputWritten) __out.AppendLine(true);
            if (__tmp29_outputWritten)
            {
                __out.AppendLine(false); //988:46
            }
            __out.Append("	{"); //989:1
            __out.AppendLine(false); //989:3
            if (IsMetaMetaModel(model)) //990:4
            {
                bool __tmp34_outputWritten = false;
                string __tmp35_line = "		get { return "; //991:1
                if (!string.IsNullOrEmpty(__tmp35_line))
                {
                    __out.Append(__tmp35_line);
                    __tmp34_outputWritten = true;
                }
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(CSharpName(cls.MetaModel, ModelKind.ImmutableInstance, true));
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
                string __tmp37_line = ".MetaMetaModel; }"; //991:77
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp34_outputWritten = true;
                }
                if (__tmp34_outputWritten) __out.AppendLine(true);
                if (__tmp34_outputWritten)
                {
                    __out.AppendLine(false); //991:94
                }
            }
            else //992:4
            {
                bool __tmp39_outputWritten = false;
                string __tmp40_line = "		get { return "; //993:1
                if (!string.IsNullOrEmpty(__tmp40_line))
                {
                    __out.Append(__tmp40_line);
                    __tmp39_outputWritten = true;
                }
                StringBuilder __tmp41 = new StringBuilder();
                __tmp41.Append(CSharpName(cls.MetaModel, ModelKind.ImmutableInstance, true));
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
                string __tmp42_line = ".MetaModel; }"; //993:77
                if (!string.IsNullOrEmpty(__tmp42_line))
                {
                    __out.Append(__tmp42_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //993:90
                }
            }
            __out.Append("	}"); //995:1
            __out.AppendLine(false); //995:3
            __out.AppendLine(true); //996:2
            bool __tmp44_outputWritten = false;
            string __tmp45_line = "	public override "; //997:1
            if (!string.IsNullOrEmpty(__tmp45_line))
            {
                __out.Append(__tmp45_line);
                __tmp44_outputWritten = true;
            }
            StringBuilder __tmp46 = new StringBuilder();
            __tmp46.Append(metaNs);
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
            string __tmp47_line = "MetaClass MMetaClass"; //997:26
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Append(__tmp47_line);
                __tmp44_outputWritten = true;
            }
            if (__tmp44_outputWritten) __out.AppendLine(true);
            if (__tmp44_outputWritten)
            {
                __out.AppendLine(false); //997:46
            }
            __out.Append("	{"); //998:1
            __out.AppendLine(false); //998:3
            bool __tmp49_outputWritten = false;
            string __tmp50_line = "		get { return "; //999:1
            if (!string.IsNullOrEmpty(__tmp50_line))
            {
                __out.Append(__tmp50_line);
                __tmp49_outputWritten = true;
            }
            StringBuilder __tmp51 = new StringBuilder();
            __tmp51.Append(CSharpName(cls, model, ClassKind.ImmutableInstance, true));
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
                        __tmp49_outputWritten = true;
                    }
                    if (!__tmp51_last) __out.AppendLine(true);
                }
            }
            string __tmp52_line = "; }"; //999:74
            if (!string.IsNullOrEmpty(__tmp52_line))
            {
                __out.Append(__tmp52_line);
                __tmp49_outputWritten = true;
            }
            if (__tmp49_outputWritten) __out.AppendLine(true);
            if (__tmp49_outputWritten)
            {
                __out.AppendLine(false); //999:77
            }
            __out.Append("	}"); //1000:1
            __out.AppendLine(false); //1000:3
            __out.AppendLine(true); //1001:2
            bool __tmp54_outputWritten = false;
            string __tmp55_line = "	public new "; //1002:1
            if (!string.IsNullOrEmpty(__tmp55_line))
            {
                __out.Append(__tmp55_line);
                __tmp54_outputWritten = true;
            }
            StringBuilder __tmp56 = new StringBuilder();
            __tmp56.Append(CSharpName(cls, model, ClassKind.Immutable));
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
            string __tmp57_line = " ToImmutable()"; //1002:57
            if (!string.IsNullOrEmpty(__tmp57_line))
            {
                __out.Append(__tmp57_line);
                __tmp54_outputWritten = true;
            }
            if (__tmp54_outputWritten) __out.AppendLine(true);
            if (__tmp54_outputWritten)
            {
                __out.AppendLine(false); //1002:71
            }
            __out.Append("	{"); //1003:1
            __out.AppendLine(false); //1003:3
            bool __tmp59_outputWritten = false;
            string __tmp60_line = "		return ("; //1004:1
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
            string __tmp62_line = ")base.ToImmutable();"; //1004:55
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Append(__tmp62_line);
                __tmp59_outputWritten = true;
            }
            if (__tmp59_outputWritten) __out.AppendLine(true);
            if (__tmp59_outputWritten)
            {
                __out.AppendLine(false); //1004:75
            }
            __out.Append("	}"); //1005:1
            __out.AppendLine(false); //1005:3
            __out.AppendLine(true); //1006:2
            bool __tmp64_outputWritten = false;
            string __tmp65_line = "	public new "; //1007:1
            if (!string.IsNullOrEmpty(__tmp65_line))
            {
                __out.Append(__tmp65_line);
                __tmp64_outputWritten = true;
            }
            StringBuilder __tmp66 = new StringBuilder();
            __tmp66.Append(CSharpName(cls, model, ClassKind.Immutable));
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
            string __tmp67_line = " ToImmutable("; //1007:57
            if (!string.IsNullOrEmpty(__tmp67_line))
            {
                __out.Append(__tmp67_line);
                __tmp64_outputWritten = true;
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
                        __tmp64_outputWritten = true;
                    }
                    if (!__tmp68_last) __out.AppendLine(true);
                }
            }
            string __tmp69_line = ".ImmutableModel model)"; //1007:89
            if (!string.IsNullOrEmpty(__tmp69_line))
            {
                __out.Append(__tmp69_line);
                __tmp64_outputWritten = true;
            }
            if (__tmp64_outputWritten) __out.AppendLine(true);
            if (__tmp64_outputWritten)
            {
                __out.AppendLine(false); //1007:111
            }
            __out.Append("	{"); //1008:1
            __out.AppendLine(false); //1008:3
            bool __tmp71_outputWritten = false;
            string __tmp72_line = "		return ("; //1009:1
            if (!string.IsNullOrEmpty(__tmp72_line))
            {
                __out.Append(__tmp72_line);
                __tmp71_outputWritten = true;
            }
            StringBuilder __tmp73 = new StringBuilder();
            __tmp73.Append(CSharpName(cls, model, ClassKind.Immutable));
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
            string __tmp74_line = ")base.ToImmutable(model);"; //1009:55
            if (!string.IsNullOrEmpty(__tmp74_line))
            {
                __out.Append(__tmp74_line);
                __tmp71_outputWritten = true;
            }
            if (__tmp71_outputWritten) __out.AppendLine(true);
            if (__tmp71_outputWritten)
            {
                __out.AppendLine(false); //1009:80
            }
            __out.Append("	}"); //1010:1
            __out.AppendLine(false); //1010:3
            var __loop63_results = 
                (from __loop63_var1 in __Enumerate((cls).GetEnumerator()) //1011:8
                from sup in __Enumerate((__loop63_var1.GetAllSuperClasses(false)).GetEnumerator()) //1011:13
                select new { __loop63_var1 = __loop63_var1, sup = sup}
                ).ToList(); //1011:3
            for (int __loop63_iteration = 0; __loop63_iteration < __loop63_results.Count; ++__loop63_iteration)
            {
                var __tmp75 = __loop63_results[__loop63_iteration];
                var __loop63_var1 = __tmp75.__loop63_var1;
                var sup = __tmp75.sup;
                __out.AppendLine(true); //1012:2
                bool __tmp77_outputWritten = false;
                string __tmp76Prefix = "	"; //1013:1
                StringBuilder __tmp78 = new StringBuilder();
                __tmp78.Append(CSharpName(sup, model, ClassKind.Immutable, true));
                using(StreamReader __tmp78Reader = new StreamReader(this.__ToStream(__tmp78.ToString())))
                {
                    bool __tmp78_last = __tmp78Reader.EndOfStream;
                    while(!__tmp78_last)
                    {
                        string __tmp78_line = __tmp78Reader.ReadLine();
                        __tmp78_last = __tmp78Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp76Prefix))
                        {
                            __out.Append(__tmp76Prefix);
                            __tmp77_outputWritten = true;
                        }
                        if ((__tmp78_last && !string.IsNullOrEmpty(__tmp78_line)) || (!__tmp78_last && __tmp78_line != null))
                        {
                            __out.Append(__tmp78_line);
                            __tmp77_outputWritten = true;
                        }
                        if (!__tmp78_last) __out.AppendLine(true);
                    }
                }
                string __tmp79_line = " "; //1013:52
                if (!string.IsNullOrEmpty(__tmp79_line))
                {
                    __out.Append(__tmp79_line);
                    __tmp77_outputWritten = true;
                }
                StringBuilder __tmp80 = new StringBuilder();
                __tmp80.Append(CSharpName(sup, model, ClassKind.Builder, true));
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
                            __tmp77_outputWritten = true;
                        }
                        if (!__tmp80_last) __out.AppendLine(true);
                    }
                }
                string __tmp81_line = ".ToImmutable()"; //1013:101
                if (!string.IsNullOrEmpty(__tmp81_line))
                {
                    __out.Append(__tmp81_line);
                    __tmp77_outputWritten = true;
                }
                if (__tmp77_outputWritten) __out.AppendLine(true);
                if (__tmp77_outputWritten)
                {
                    __out.AppendLine(false); //1013:115
                }
                __out.Append("	{"); //1014:1
                __out.AppendLine(false); //1014:3
                __out.Append("		return this.ToImmutable();"); //1015:1
                __out.AppendLine(false); //1015:29
                __out.Append("	}"); //1016:1
                __out.AppendLine(false); //1016:3
                __out.AppendLine(true); //1017:2
                bool __tmp83_outputWritten = false;
                string __tmp82Prefix = "	"; //1018:1
                StringBuilder __tmp84 = new StringBuilder();
                __tmp84.Append(CSharpName(sup, model, ClassKind.Immutable, true));
                using(StreamReader __tmp84Reader = new StreamReader(this.__ToStream(__tmp84.ToString())))
                {
                    bool __tmp84_last = __tmp84Reader.EndOfStream;
                    while(!__tmp84_last)
                    {
                        string __tmp84_line = __tmp84Reader.ReadLine();
                        __tmp84_last = __tmp84Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp82Prefix))
                        {
                            __out.Append(__tmp82Prefix);
                            __tmp83_outputWritten = true;
                        }
                        if ((__tmp84_last && !string.IsNullOrEmpty(__tmp84_line)) || (!__tmp84_last && __tmp84_line != null))
                        {
                            __out.Append(__tmp84_line);
                            __tmp83_outputWritten = true;
                        }
                        if (!__tmp84_last) __out.AppendLine(true);
                    }
                }
                string __tmp85_line = " "; //1018:52
                if (!string.IsNullOrEmpty(__tmp85_line))
                {
                    __out.Append(__tmp85_line);
                    __tmp83_outputWritten = true;
                }
                StringBuilder __tmp86 = new StringBuilder();
                __tmp86.Append(CSharpName(sup, model, ClassKind.Builder, true));
                using(StreamReader __tmp86Reader = new StreamReader(this.__ToStream(__tmp86.ToString())))
                {
                    bool __tmp86_last = __tmp86Reader.EndOfStream;
                    while(!__tmp86_last)
                    {
                        string __tmp86_line = __tmp86Reader.ReadLine();
                        __tmp86_last = __tmp86Reader.EndOfStream;
                        if ((__tmp86_last && !string.IsNullOrEmpty(__tmp86_line)) || (!__tmp86_last && __tmp86_line != null))
                        {
                            __out.Append(__tmp86_line);
                            __tmp83_outputWritten = true;
                        }
                        if (!__tmp86_last) __out.AppendLine(true);
                    }
                }
                string __tmp87_line = ".ToImmutable("; //1018:101
                if (!string.IsNullOrEmpty(__tmp87_line))
                {
                    __out.Append(__tmp87_line);
                    __tmp83_outputWritten = true;
                }
                StringBuilder __tmp88 = new StringBuilder();
                __tmp88.Append(Properties.CoreNs);
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
                            __tmp83_outputWritten = true;
                        }
                        if (!__tmp88_last) __out.AppendLine(true);
                    }
                }
                string __tmp89_line = ".ImmutableModel model)"; //1018:133
                if (!string.IsNullOrEmpty(__tmp89_line))
                {
                    __out.Append(__tmp89_line);
                    __tmp83_outputWritten = true;
                }
                if (__tmp83_outputWritten) __out.AppendLine(true);
                if (__tmp83_outputWritten)
                {
                    __out.AppendLine(false); //1018:155
                }
                __out.Append("	{"); //1019:1
                __out.AppendLine(false); //1019:3
                __out.Append("		return this.ToImmutable(model);"); //1020:1
                __out.AppendLine(false); //1020:34
                __out.Append("	}"); //1021:1
                __out.AppendLine(false); //1021:3
            }
            var __loop64_results = 
                (from __loop64_var1 in __Enumerate((cls).GetEnumerator()) //1023:8
                from prop in __Enumerate((__loop64_var1.GetAllProperties()).GetEnumerator()) //1023:13
                select new { __loop64_var1 = __loop64_var1, prop = prop}
                ).ToList(); //1023:3
            for (int __loop64_iteration = 0; __loop64_iteration < __loop64_results.Count; ++__loop64_iteration)
            {
                var __tmp90 = __loop64_results[__loop64_iteration];
                var __loop64_var1 = __tmp90.__loop64_var1;
                var prop = __tmp90.prop;
                __out.AppendLine(true); //1024:2
                bool __tmp92_outputWritten = false;
                string __tmp91Prefix = "	"; //1025:1
                StringBuilder __tmp93 = new StringBuilder();
                __tmp93.Append(GenerateBuilderPropertyImpl(model, cls, prop));
                using(StreamReader __tmp93Reader = new StreamReader(this.__ToStream(__tmp93.ToString())))
                {
                    bool __tmp93_last = __tmp93Reader.EndOfStream;
                    while(!__tmp93_last)
                    {
                        string __tmp93_line = __tmp93Reader.ReadLine();
                        __tmp93_last = __tmp93Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp91Prefix))
                        {
                            __out.Append(__tmp91Prefix);
                            __tmp92_outputWritten = true;
                        }
                        if ((__tmp93_last && !string.IsNullOrEmpty(__tmp93_line)) || (!__tmp93_last && __tmp93_line != null))
                        {
                            __out.Append(__tmp93_line);
                            __tmp92_outputWritten = true;
                        }
                        if (!__tmp93_last || __tmp92_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp92_outputWritten)
                {
                    __out.AppendLine(false); //1025:49
                }
            }
            __out.Append("}"); //1027:1
            __out.AppendLine(false); //1027:2
            return __out.ToString();
        }

        public string GenerateBuilderField(MetaModel model, MetaClass cls, MetaProperty prop) //1030:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "private "; //1031:1
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
            string __tmp5_line = " "; //1031:63
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
            string __tmp7_line = ";"; //1031:88
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1031:89
            }
            return __out.ToString();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //1034:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1035:1
            if (cls.GetAllFinalProperties().Contains(prop)) //1036:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //1037:1
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
                string __tmp5_line = " "; //1037:62
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
                    __out.AppendLine(false); //1037:74
                }
            }
            else //1038:2
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
                    __out.AppendLine(false); //1039:54
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
                string __tmp13_line = " "; //1040:55
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
                string __tmp15_line = "."; //1040:111
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
                    __out.AppendLine(false); //1040:123
                }
            }
            __out.Append("{"); //1042:1
            __out.AppendLine(false); //1042:2
            if (prop.Type is MetaCollectionType) //1043:3
            {
                if (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.Set || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet) //1044:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "	get { return this.GetSet<"; //1045:1
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
                    string __tmp21_line = ">("; //1045:113
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
                    string __tmp23_line = ", ref "; //1045:169
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
                    string __tmp25_line = "); }"; //1045:199
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Append(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //1045:203
                    }
                }
                else //1046:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "	get { return this.GetList<"; //1047:1
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
                    string __tmp30_line = ">("; //1047:114
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
                    string __tmp32_line = ", ref "; //1047:170
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
                    string __tmp34_line = "); }"; //1047:200
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Append(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //1047:204
                    }
                }
            }
            else if (IsReferenceType(prop.Type)) //1049:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "	get { return this.GetReference<"; //1050:1
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
                string __tmp39_line = ">("; //1050:87
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
                string __tmp41_line = "); }"; //1050:143
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Append(__tmp41_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //1050:147
                }
            }
            else //1051:3
            {
                bool __tmp43_outputWritten = false;
                string __tmp44_line = "	get { return this.GetValue<"; //1052:1
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
                string __tmp46_line = ">("; //1052:83
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
                string __tmp48_line = "); }"; //1052:139
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Append(__tmp48_line);
                    __tmp43_outputWritten = true;
                }
                if (__tmp43_outputWritten) __out.AppendLine(true);
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //1052:143
                }
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //1054:3
            {
                if (IsReferenceType(prop.Type)) //1055:4
                {
                    bool __tmp50_outputWritten = false;
                    string __tmp51_line = "	set { this.SetReference<"; //1056:1
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
                    string __tmp53_line = ">("; //1056:80
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
                    string __tmp55_line = ", value); }"; //1056:136
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Append(__tmp55_line);
                        __tmp50_outputWritten = true;
                    }
                    if (__tmp50_outputWritten) __out.AppendLine(true);
                    if (__tmp50_outputWritten)
                    {
                        __out.AppendLine(false); //1056:147
                    }
                }
                else //1057:4
                {
                    bool __tmp57_outputWritten = false;
                    string __tmp58_line = "	set { this.SetValue<"; //1058:1
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
                    string __tmp60_line = ">("; //1058:76
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
                    string __tmp62_line = ", value); }"; //1058:132
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Append(__tmp62_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //1058:143
                    }
                }
            }
            __out.Append("}"); //1061:1
            __out.AppendLine(false); //1061:2
            if (!(prop.Type is MetaCollectionType)) //1062:2
            {
                __out.AppendLine(true); //1063:1
                if (cls.GetAllFinalProperties().Contains(prop)) //1064:3
                {
                    bool __tmp64_outputWritten = false;
                    string __tmp65_line = "public Func<"; //1065:1
                    if (!string.IsNullOrEmpty(__tmp65_line))
                    {
                        __out.Append(__tmp65_line);
                        __tmp64_outputWritten = true;
                    }
                    StringBuilder __tmp66 = new StringBuilder();
                    __tmp66.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
                    string __tmp67_line = "> "; //1065:67
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
                    string __tmp69_line = "Lazy"; //1065:80
                    if (!string.IsNullOrEmpty(__tmp69_line))
                    {
                        __out.Append(__tmp69_line);
                        __tmp64_outputWritten = true;
                    }
                    if (__tmp64_outputWritten) __out.AppendLine(true);
                    if (__tmp64_outputWritten)
                    {
                        __out.AppendLine(false); //1065:84
                    }
                }
                else //1066:3
                {
                    bool __tmp71_outputWritten = false;
                    StringBuilder __tmp72 = new StringBuilder();
                    __tmp72.Append("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
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
                            if (!__tmp72_last || __tmp71_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp71_outputWritten)
                    {
                        __out.AppendLine(false); //1067:54
                    }
                    bool __tmp74_outputWritten = false;
                    string __tmp75_line = "Func<"; //1068:1
                    if (!string.IsNullOrEmpty(__tmp75_line))
                    {
                        __out.Append(__tmp75_line);
                        __tmp74_outputWritten = true;
                    }
                    StringBuilder __tmp76 = new StringBuilder();
                    __tmp76.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
                    string __tmp77_line = "> "; //1068:60
                    if (!string.IsNullOrEmpty(__tmp77_line))
                    {
                        __out.Append(__tmp77_line);
                        __tmp74_outputWritten = true;
                    }
                    StringBuilder __tmp78 = new StringBuilder();
                    __tmp78.Append(CSharpName(prop.Class, model, ClassKind.Builder, true));
                    using(StreamReader __tmp78Reader = new StreamReader(this.__ToStream(__tmp78.ToString())))
                    {
                        bool __tmp78_last = __tmp78Reader.EndOfStream;
                        while(!__tmp78_last)
                        {
                            string __tmp78_line = __tmp78Reader.ReadLine();
                            __tmp78_last = __tmp78Reader.EndOfStream;
                            if ((__tmp78_last && !string.IsNullOrEmpty(__tmp78_line)) || (!__tmp78_last && __tmp78_line != null))
                            {
                                __out.Append(__tmp78_line);
                                __tmp74_outputWritten = true;
                            }
                            if (!__tmp78_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp79_line = "."; //1068:117
                    if (!string.IsNullOrEmpty(__tmp79_line))
                    {
                        __out.Append(__tmp79_line);
                        __tmp74_outputWritten = true;
                    }
                    StringBuilder __tmp80 = new StringBuilder();
                    __tmp80.Append(prop.Name);
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
                                __tmp74_outputWritten = true;
                            }
                            if (!__tmp80_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp81_line = "Lazy"; //1068:129
                    if (!string.IsNullOrEmpty(__tmp81_line))
                    {
                        __out.Append(__tmp81_line);
                        __tmp74_outputWritten = true;
                    }
                    if (__tmp74_outputWritten) __out.AppendLine(true);
                    if (__tmp74_outputWritten)
                    {
                        __out.AppendLine(false); //1068:133
                    }
                }
                __out.Append("{"); //1070:1
                __out.AppendLine(false); //1070:2
                if (IsReferenceType(prop.Type)) //1071:3
                {
                    bool __tmp83_outputWritten = false;
                    string __tmp84_line = "	get { return this.GetLazyReference<"; //1072:1
                    if (!string.IsNullOrEmpty(__tmp84_line))
                    {
                        __out.Append(__tmp84_line);
                        __tmp83_outputWritten = true;
                    }
                    StringBuilder __tmp85 = new StringBuilder();
                    __tmp85.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
                    string __tmp86_line = ">("; //1072:91
                    if (!string.IsNullOrEmpty(__tmp86_line))
                    {
                        __out.Append(__tmp86_line);
                        __tmp83_outputWritten = true;
                    }
                    StringBuilder __tmp87 = new StringBuilder();
                    __tmp87.Append(CSharpName(prop, null, PropertyKind.Descriptor, true));
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
                    string __tmp88_line = "); }"; //1072:147
                    if (!string.IsNullOrEmpty(__tmp88_line))
                    {
                        __out.Append(__tmp88_line);
                        __tmp83_outputWritten = true;
                    }
                    if (__tmp83_outputWritten) __out.AppendLine(true);
                    if (__tmp83_outputWritten)
                    {
                        __out.AppendLine(false); //1072:151
                    }
                    bool __tmp90_outputWritten = false;
                    string __tmp91_line = "	set { this.SetLazyReference("; //1073:1
                    if (!string.IsNullOrEmpty(__tmp91_line))
                    {
                        __out.Append(__tmp91_line);
                        __tmp90_outputWritten = true;
                    }
                    StringBuilder __tmp92 = new StringBuilder();
                    __tmp92.Append(CSharpName(prop, model, PropertyKind.Descriptor, true));
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
                                __tmp90_outputWritten = true;
                            }
                            if (!__tmp92_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp93_line = ", value); }"; //1073:85
                    if (!string.IsNullOrEmpty(__tmp93_line))
                    {
                        __out.Append(__tmp93_line);
                        __tmp90_outputWritten = true;
                    }
                    if (__tmp90_outputWritten) __out.AppendLine(true);
                    if (__tmp90_outputWritten)
                    {
                        __out.AppendLine(false); //1073:96
                    }
                }
                else //1074:3
                {
                    bool __tmp95_outputWritten = false;
                    string __tmp96_line = "	get { return this.GetLazyValue<"; //1075:1
                    if (!string.IsNullOrEmpty(__tmp96_line))
                    {
                        __out.Append(__tmp96_line);
                        __tmp95_outputWritten = true;
                    }
                    StringBuilder __tmp97 = new StringBuilder();
                    __tmp97.Append(CSharpName(prop.Type, model, ClassKind.Builder, true));
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
                    string __tmp98_line = ">("; //1075:87
                    if (!string.IsNullOrEmpty(__tmp98_line))
                    {
                        __out.Append(__tmp98_line);
                        __tmp95_outputWritten = true;
                    }
                    StringBuilder __tmp99 = new StringBuilder();
                    __tmp99.Append(CSharpName(prop, null, PropertyKind.Descriptor, true));
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
                    string __tmp100_line = "); }"; //1075:143
                    if (!string.IsNullOrEmpty(__tmp100_line))
                    {
                        __out.Append(__tmp100_line);
                        __tmp95_outputWritten = true;
                    }
                    if (__tmp95_outputWritten) __out.AppendLine(true);
                    if (__tmp95_outputWritten)
                    {
                        __out.AppendLine(false); //1075:147
                    }
                    bool __tmp102_outputWritten = false;
                    string __tmp103_line = "	set { this.SetLazyValue("; //1076:1
                    if (!string.IsNullOrEmpty(__tmp103_line))
                    {
                        __out.Append(__tmp103_line);
                        __tmp102_outputWritten = true;
                    }
                    StringBuilder __tmp104 = new StringBuilder();
                    __tmp104.Append(CSharpName(prop, model, PropertyKind.Descriptor, true));
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
                                __tmp102_outputWritten = true;
                            }
                            if (!__tmp104_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp105_line = ", value); }"; //1076:81
                    if (!string.IsNullOrEmpty(__tmp105_line))
                    {
                        __out.Append(__tmp105_line);
                        __tmp102_outputWritten = true;
                    }
                    if (__tmp102_outputWritten) __out.AppendLine(true);
                    if (__tmp102_outputWritten)
                    {
                        __out.AppendLine(false); //1076:92
                    }
                }
                __out.Append("}"); //1078:1
                __out.AppendLine(false); //1078:2
            }
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
