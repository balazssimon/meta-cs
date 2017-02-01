using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable; //4:1

namespace MetaDslx.Core //1:1
{
    using __Hidden_ImmutableMetaModelGenerator_884725023;
    namespace __Hidden_ImmutableMetaModelGenerator_884725023
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
        string ToCamelCase(string identifier); //25:8
        string ToPascalCase(string identifier); //26:8
        string EscapeText(string text); //27:8
        bool IsCoreModel(MetaModel mmodel); //28:8
        string GetEnumValueOf(Enum menum); //29:8
        string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false); //30:8
        string CSharpName(MetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false); //31:8
        string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false); //32:8
        string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false); //33:8
        string CSharpName(MetaConstant mconst, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false); //34:8
        ImmutableDictionary<ImmutableSymbol,string> GetSymbolInstanceNames(MetaModel mmodel); //35:8
        string GetFieldName(MetaProperty mproperty, MetaClass mclass); //36:8
        bool IsReferenceType(MetaType mtype); //37:8
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

        public __Properties Properties { get; private set; } //6:1

        public class __Properties //6:1
        {
            internal __Properties()
            {
                this.CoreNs = "global::MetaDslx.Core"; //7:18
            }
            public string CoreNs { get; set; } //7:2
        }

        public string Generate() //10:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("using System;"); //11:1
            __out.AppendLine(false); //11:14
            __out.Append("using System.Collections.Generic;"); //12:1
            __out.AppendLine(false); //12:34
            __out.Append("using System.IO;"); //13:1
            __out.AppendLine(false); //13:17
            __out.Append("using System.Linq;"); //14:1
            __out.AppendLine(false); //14:19
            __out.Append("using System.Text;"); //15:1
            __out.AppendLine(false); //15:19
            __out.Append("using System.Threading;"); //16:1
            __out.AppendLine(false); //16:24
            __out.Append("using System.Threading.Tasks;"); //17:1
            __out.AppendLine(false); //17:30
            __out.Append("using System.Diagnostics;"); //18:1
            __out.AppendLine(false); //18:26
            __out.AppendLine(true); //19:1
            var __loop1_results = 
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //20:8
                from mm in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaModel>() //20:19
                select new { __loop1_var1 = __loop1_var1, mm = mm}
                ).ToList(); //20:3
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
                    __out.AppendLine(false); //21:24
                }
            }
            return __out.ToString();
        }

        internal string ToCamelCase(string identifier) //25:8
        {
            return this.extensionFunctions.ToCamelCase(identifier); //25:8
        }

        internal string ToPascalCase(string identifier) //26:8
        {
            return this.extensionFunctions.ToPascalCase(identifier); //26:8
        }

        internal string EscapeText(string text) //27:8
        {
            return this.extensionFunctions.EscapeText(text); //27:8
        }

        internal bool IsCoreModel(MetaModel mmodel) //28:8
        {
            return this.extensionFunctions.IsCoreModel(mmodel); //28:8
        }

        internal string GetEnumValueOf(Enum menum) //29:8
        {
            return this.extensionFunctions.GetEnumValueOf(menum); //29:8
        }

        internal string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false) //30:8
        {
            return this.extensionFunctions.CSharpName(mnamespace, kind, fullName); //30:8
        }

        internal string CSharpName(MetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false) //31:8
        {
            return this.extensionFunctions.CSharpName(mmodel, kind, fullName); //31:8
        }

        internal string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false) //32:8
        {
            return this.extensionFunctions.CSharpName(mtype, mmodel, kind, fullName); //32:8
        }

        internal string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false) //33:8
        {
            return this.extensionFunctions.CSharpName(mproperty, mmodel, kind, fullName); //33:8
        }

        internal string CSharpName(MetaConstant mconst, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false) //34:8
        {
            return this.extensionFunctions.CSharpName(mconst, mmodel, kind, fullName); //34:8
        }

        internal ImmutableDictionary<ImmutableSymbol,string> GetSymbolInstanceNames(MetaModel mmodel) //35:8
        {
            return this.extensionFunctions.GetSymbolInstanceNames(mmodel); //35:8
        }

        internal string GetFieldName(MetaProperty mproperty, MetaClass mclass) //36:8
        {
            return this.extensionFunctions.GetFieldName(mproperty, mclass); //36:8
        }

        internal bool IsReferenceType(MetaType mtype) //37:8
        {
            return this.extensionFunctions.IsReferenceType(mtype); //37:8
        }

        public string GenerateDocumentation(MetaDocumentedElement elem) //39:1
        {
            StringBuilder __out = new StringBuilder();
            ImmutableModelList<string> lines = elem.GetDocumentationLines(); //40:2
            if (lines.Count > 0) //41:2
            {
                __out.Append("/**"); //42:1
                __out.AppendLine(false); //42:4
                __out.Append(" * <summary>"); //43:1
                __out.AppendLine(false); //43:13
                var __loop2_results = 
                    (from line in __Enumerate((lines).GetEnumerator()) //44:8
                    select new { line = line}
                    ).ToList(); //44:3
                for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
                {
                    var __tmp1 = __loop2_results[__loop2_iteration];
                    var line = __tmp1.line;
                    bool __tmp3_outputWritten = false;
                    string __tmp4_line = " * "; //45:1
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
                        __out.AppendLine(false); //45:10
                    }
                }
                __out.Append(" * </summary>"); //47:1
                __out.AppendLine(false); //47:14
                __out.Append(" */"); //48:1
                __out.AppendLine(false); //48:4
            }
            return __out.ToString();
        }

        public string GenerateAnnotations(MetaAnnotatedElement elem) //52:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop3_results = 
                (from __loop3_var1 in __Enumerate((elem).GetEnumerator()) //53:7
                from annot in __Enumerate((__loop3_var1.Annotations).GetEnumerator()) //53:13
                select new { __loop3_var1 = __loop3_var1, annot = annot}
                ).ToList(); //53:2
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
                string __tmp6_line = "."; //54:25
                if (!string.IsNullOrEmpty(__tmp6_line))
                {
                    __out.Append(__tmp6_line);
                    __tmp3_outputWritten = true;
                }
                StringBuilder __tmp7 = new StringBuilder();
                __tmp7.Append(annot.Name);
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
                    __out.AppendLine(false); //54:43
                }
            }
            return __out.ToString();
        }

        public string GenerateMetamodel(MetaModel model) //58:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //59:1
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
                __out.AppendLine(false); //59:67
            }
            __out.Append("{"); //60:1
            __out.AppendLine(false); //60:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	using global::"; //61:1
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
            string __tmp9_line = ";"; //61:74
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //61:75
            }
            __out.AppendLine(true); //62:1
            bool __tmp11_outputWritten = false;
            string __tmp10Prefix = "	"; //63:1
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
                __out.AppendLine(false); //63:36
            }
            __out.AppendLine(true); //64:1
            bool __tmp14_outputWritten = false;
            string __tmp13Prefix = "	"; //65:1
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
                __out.AppendLine(false); //65:26
            }
            __out.AppendLine(true); //66:1
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //67:8
                from enm in __Enumerate((__loop4_var1).GetEnumerator()).OfType<MetaEnum>() //67:38
                select new { __loop4_var1 = __loop4_var1, enm = enm}
                ).ToList(); //67:3
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp16 = __loop4_results[__loop4_iteration];
                var __loop4_var1 = __tmp16.__loop4_var1;
                var enm = __tmp16.enm;
                bool __tmp18_outputWritten = false;
                string __tmp17Prefix = "	"; //68:1
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
                    __out.AppendLine(false); //68:28
                }
            }
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //70:8
                from cls in __Enumerate((__loop5_var1).GetEnumerator()).OfType<MetaClass>() //70:38
                select new { __loop5_var1 = __loop5_var1, cls = cls}
                ).ToList(); //70:3
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp20 = __loop5_results[__loop5_iteration];
                var __loop5_var1 = __tmp20.__loop5_var1;
                var cls = __tmp20.cls;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "	"; //71:1
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
                    __out.AppendLine(false); //71:29
                }
            }
            __out.AppendLine(true); //73:1
            bool __tmp25_outputWritten = false;
            string __tmp24Prefix = "	"; //74:1
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
                __out.AppendLine(false); //74:38
            }
            __out.Append("}"); //75:1
            __out.AppendLine(false); //75:2
            __out.AppendLine(true); //76:1
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "namespace "; //77:1
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
                __out.AppendLine(false); //77:69
            }
            __out.Append("{"); //78:1
            __out.AppendLine(false); //78:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //79:8
                from cls in __Enumerate((__loop6_var1).GetEnumerator()).OfType<MetaClass>() //79:38
                select new { __loop6_var1 = __loop6_var1, cls = cls}
                ).ToList(); //79:3
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp31 = __loop6_results[__loop6_iteration];
                var __loop6_var1 = __tmp31.__loop6_var1;
                var cls = __tmp31.cls;
                bool __tmp33_outputWritten = false;
                string __tmp32Prefix = "	"; //80:1
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
                    __out.AppendLine(false); //80:37
                }
            }
            __out.AppendLine(true); //82:1
            bool __tmp36_outputWritten = false;
            string __tmp35Prefix = "	"; //83:1
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
                __out.AppendLine(false); //83:43
            }
            __out.AppendLine(true); //84:1
            bool __tmp39_outputWritten = false;
            string __tmp38Prefix = "	"; //85:1
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
                __out.AppendLine(false); //85:37
            }
            __out.AppendLine(true); //86:1
            bool __tmp42_outputWritten = false;
            string __tmp41Prefix = "	"; //87:1
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
                __out.AppendLine(false); //87:41
            }
            __out.Append("}"); //88:1
            __out.AppendLine(false); //88:2
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //91:1
        {
            StringBuilder __out = new StringBuilder();
            string coreNs = IsCoreModel(model) ? "" : Properties.CoreNs + "."; //92:2
            bool coreModel = IsCoreModel(model); //93:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //94:1
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
                __out.AppendLine(false); //94:61
            }
            __out.Append("{"); //95:1
            __out.AppendLine(false); //95:2
            __out.Append("	private static bool initialized;"); //96:1
            __out.AppendLine(false); //96:34
            __out.AppendLine(true); //97:1
            __out.Append("	public static bool IsInitialized"); //98:1
            __out.AppendLine(false); //98:34
            __out.Append("	{"); //99:1
            __out.AppendLine(false); //99:3
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "		get { return "; //100:1
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
            string __tmp9_line = ".initialized; }"; //100:63
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //100:78
            }
            __out.Append("	}"); //101:1
            __out.AppendLine(false); //101:3
            __out.AppendLine(true); //102:1
            if (coreModel) //103:3
            {
                bool __tmp11_outputWritten = false;
                string __tmp12_line = "	public static readonly "; //104:1
                if (!string.IsNullOrEmpty(__tmp12_line))
                {
                    __out.Append(__tmp12_line);
                    __tmp11_outputWritten = true;
                }
                StringBuilder __tmp13 = new StringBuilder();
                __tmp13.Append(coreNs);
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
                string __tmp14_line = "MetaModel _MetaModel;"; //104:33
                if (!string.IsNullOrEmpty(__tmp14_line))
                {
                    __out.Append(__tmp14_line);
                    __tmp11_outputWritten = true;
                }
                if (__tmp11_outputWritten) __out.AppendLine(true);
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //104:54
                }
            }
            else //105:3
            {
                bool __tmp16_outputWritten = false;
                string __tmp17_line = "	public static readonly "; //106:1
                if (!string.IsNullOrEmpty(__tmp17_line))
                {
                    __out.Append(__tmp17_line);
                    __tmp16_outputWritten = true;
                }
                StringBuilder __tmp18 = new StringBuilder();
                __tmp18.Append(coreNs);
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
                string __tmp19_line = "MetaModel MetaModel;"; //106:33
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Append(__tmp19_line);
                    __tmp16_outputWritten = true;
                }
                if (__tmp16_outputWritten) __out.AppendLine(true);
                if (__tmp16_outputWritten)
                {
                    __out.AppendLine(false); //106:53
                }
            }
            bool __tmp21_outputWritten = false;
            string __tmp22_line = "	public static readonly "; //108:1
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
            string __tmp24_line = ".ImmutableModel Model;"; //108:44
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp21_outputWritten = true;
            }
            if (__tmp21_outputWritten) __out.AppendLine(true);
            if (__tmp21_outputWritten)
            {
                __out.AppendLine(false); //108:66
            }
            __out.AppendLine(true); //109:1
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //110:8
                from cst in __Enumerate((__loop7_var1).GetEnumerator()).OfType<MetaConstant>() //110:38
                select new { __loop7_var1 = __loop7_var1, cst = cst}
                ).ToList(); //110:3
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp25 = __loop7_results[__loop7_iteration];
                var __loop7_var1 = __tmp25.__loop7_var1;
                var cst = __tmp25.cst;
                bool __tmp27_outputWritten = false;
                string __tmp26Prefix = "	"; //111:1
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
                    __out.AppendLine(false); //111:30
                }
                if (coreModel) //112:4
                {
                    bool __tmp30_outputWritten = false;
                    string __tmp31_line = "	public static readonly "; //113:1
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
                    string __tmp33_line = " "; //113:74
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
                    string __tmp35_line = ";"; //113:127
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Append(__tmp35_line);
                        __tmp30_outputWritten = true;
                    }
                    if (__tmp30_outputWritten) __out.AppendLine(true);
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //113:128
                    }
                }
                else //114:4
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "	public static readonly "; //115:1
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
                    string __tmp40_line = " "; //115:80
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
                    string __tmp42_line = ";"; //115:133
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Append(__tmp42_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //115:134
                    }
                }
            }
            __out.AppendLine(true); //118:1
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //119:8
                from cls in __Enumerate((__loop8_var1).GetEnumerator()).OfType<MetaClass>() //119:38
                select new { __loop8_var1 = __loop8_var1, cls = cls}
                ).ToList(); //119:3
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp43 = __loop8_results[__loop8_iteration];
                var __loop8_var1 = __tmp43.__loop8_var1;
                var cls = __tmp43.cls;
                bool __tmp45_outputWritten = false;
                string __tmp44Prefix = "	"; //120:1
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
                    __out.AppendLine(false); //120:30
                }
                bool __tmp48_outputWritten = false;
                string __tmp49_line = "	public static readonly "; //121:1
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Append(__tmp49_line);
                    __tmp48_outputWritten = true;
                }
                StringBuilder __tmp50 = new StringBuilder();
                __tmp50.Append(coreNs);
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
                string __tmp51_line = "MetaClass "; //121:33
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
                string __tmp53_line = ";"; //121:95
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp48_outputWritten = true;
                }
                if (__tmp48_outputWritten) __out.AppendLine(true);
                if (__tmp48_outputWritten)
                {
                    __out.AppendLine(false); //121:96
                }
                var __loop9_results = 
                    (from __loop9_var1 in __Enumerate((cls).GetEnumerator()) //122:9
                    from prop in __Enumerate((__loop9_var1.Properties).GetEnumerator()) //122:14
                    select new { __loop9_var1 = __loop9_var1, prop = prop}
                    ).ToList(); //122:4
                for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
                {
                    var __tmp54 = __loop9_results[__loop9_iteration];
                    var __loop9_var1 = __tmp54.__loop9_var1;
                    var prop = __tmp54.prop;
                    bool __tmp56_outputWritten = false;
                    string __tmp55Prefix = "	"; //123:1
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
                        __out.AppendLine(false); //123:31
                    }
                    bool __tmp59_outputWritten = false;
                    string __tmp60_line = "	public static readonly "; //124:1
                    if (!string.IsNullOrEmpty(__tmp60_line))
                    {
                        __out.Append(__tmp60_line);
                        __tmp59_outputWritten = true;
                    }
                    StringBuilder __tmp61 = new StringBuilder();
                    __tmp61.Append(coreNs);
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
                    string __tmp62_line = "MetaProperty "; //124:33
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
                    string __tmp64_line = ";"; //124:102
                    if (!string.IsNullOrEmpty(__tmp64_line))
                    {
                        __out.Append(__tmp64_line);
                        __tmp59_outputWritten = true;
                    }
                    if (__tmp59_outputWritten) __out.AppendLine(true);
                    if (__tmp59_outputWritten)
                    {
                        __out.AppendLine(false); //124:103
                    }
                }
            }
            __out.AppendLine(true); //127:1
            bool __tmp66_outputWritten = false;
            string __tmp67_line = "	static "; //128:1
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
            string __tmp69_line = "()"; //128:56
            if (!string.IsNullOrEmpty(__tmp69_line))
            {
                __out.Append(__tmp69_line);
                __tmp66_outputWritten = true;
            }
            if (__tmp66_outputWritten) __out.AppendLine(true);
            if (__tmp66_outputWritten)
            {
                __out.AppendLine(false); //128:58
            }
            __out.Append("	{"); //129:1
            __out.AppendLine(false); //129:3
            if (coreModel) //130:4
            {
                bool __tmp71_outputWritten = false;
                string __tmp70Prefix = "		"; //131:1
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
                string __tmp73_line = ".instance.Create();"; //131:48
                if (!string.IsNullOrEmpty(__tmp73_line))
                {
                    __out.Append(__tmp73_line);
                    __tmp71_outputWritten = true;
                }
                if (__tmp71_outputWritten) __out.AppendLine(true);
                if (__tmp71_outputWritten)
                {
                    __out.AppendLine(false); //131:67
                }
                bool __tmp75_outputWritten = false;
                string __tmp74Prefix = "		"; //132:1
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
                string __tmp77_line = ".instance.EvaluateLazyValues();"; //132:48
                if (!string.IsNullOrEmpty(__tmp77_line))
                {
                    __out.Append(__tmp77_line);
                    __tmp75_outputWritten = true;
                }
                if (__tmp75_outputWritten) __out.AppendLine(true);
                if (__tmp75_outputWritten)
                {
                    __out.AppendLine(false); //132:79
                }
                bool __tmp79_outputWritten = false;
                string __tmp80_line = "		_MetaModel = "; //133:1
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
                string __tmp82_line = ".instance._MetaModel.ToImmutable();"; //133:61
                if (!string.IsNullOrEmpty(__tmp82_line))
                {
                    __out.Append(__tmp82_line);
                    __tmp79_outputWritten = true;
                }
                if (__tmp79_outputWritten) __out.AppendLine(true);
                if (__tmp79_outputWritten)
                {
                    __out.AppendLine(false); //133:96
                }
            }
            else //134:4
            {
                bool __tmp84_outputWritten = false;
                string __tmp83Prefix = "		"; //135:1
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
                string __tmp86_line = ".instance.Create();"; //135:48
                if (!string.IsNullOrEmpty(__tmp86_line))
                {
                    __out.Append(__tmp86_line);
                    __tmp84_outputWritten = true;
                }
                if (__tmp84_outputWritten) __out.AppendLine(true);
                if (__tmp84_outputWritten)
                {
                    __out.AppendLine(false); //135:67
                }
                bool __tmp88_outputWritten = false;
                string __tmp87Prefix = "		"; //136:1
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
                string __tmp90_line = ".instance.EvaluateLazyValues();"; //136:48
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Append(__tmp90_line);
                    __tmp88_outputWritten = true;
                }
                if (__tmp88_outputWritten) __out.AppendLine(true);
                if (__tmp88_outputWritten)
                {
                    __out.AppendLine(false); //136:79
                }
                bool __tmp92_outputWritten = false;
                string __tmp93_line = "		MetaModel = "; //137:1
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
                string __tmp95_line = ".instance.MetaModel.ToImmutable();"; //137:60
                if (!string.IsNullOrEmpty(__tmp95_line))
                {
                    __out.Append(__tmp95_line);
                    __tmp92_outputWritten = true;
                }
                if (__tmp92_outputWritten) __out.AppendLine(true);
                if (__tmp92_outputWritten)
                {
                    __out.AppendLine(false); //137:94
                }
            }
            bool __tmp97_outputWritten = false;
            string __tmp98_line = "		Model = "; //139:1
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
            string __tmp100_line = ".instance.Model.ToImmutable();"; //139:56
            if (!string.IsNullOrEmpty(__tmp100_line))
            {
                __out.Append(__tmp100_line);
                __tmp97_outputWritten = true;
            }
            if (__tmp97_outputWritten) __out.AppendLine(true);
            if (__tmp97_outputWritten)
            {
                __out.AppendLine(false); //139:86
            }
            __out.AppendLine(true); //140:1
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //141:9
                from cst in __Enumerate((__loop10_var1).GetEnumerator()).OfType<MetaConstant>() //141:39
                select new { __loop10_var1 = __loop10_var1, cst = cst}
                ).ToList(); //141:4
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp101 = __loop10_results[__loop10_iteration];
                var __loop10_var1 = __tmp101.__loop10_var1;
                var cst = __tmp101.cst;
                if (coreModel) //142:5
                {
                    bool __tmp103_outputWritten = false;
                    string __tmp102Prefix = "		"; //143:1
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
                    string __tmp105_line = " = "; //143:55
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
                    string __tmp107_line = ".ToImmutable(Model);"; //143:114
                    if (!string.IsNullOrEmpty(__tmp107_line))
                    {
                        __out.Append(__tmp107_line);
                        __tmp103_outputWritten = true;
                    }
                    if (__tmp103_outputWritten) __out.AppendLine(true);
                    if (__tmp103_outputWritten)
                    {
                        __out.AppendLine(false); //143:134
                    }
                }
                else //144:5
                {
                    bool __tmp109_outputWritten = false;
                    string __tmp108Prefix = "		"; //145:1
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
                    string __tmp111_line = " = "; //145:55
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
                    string __tmp113_line = ".ToImmutable(Model);"; //145:114
                    if (!string.IsNullOrEmpty(__tmp113_line))
                    {
                        __out.Append(__tmp113_line);
                        __tmp109_outputWritten = true;
                    }
                    if (__tmp109_outputWritten) __out.AppendLine(true);
                    if (__tmp109_outputWritten)
                    {
                        __out.AppendLine(false); //145:134
                    }
                }
            }
            __out.AppendLine(true); //148:1
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //149:9
                from cls in __Enumerate((__loop11_var1).GetEnumerator()).OfType<MetaClass>() //149:39
                select new { __loop11_var1 = __loop11_var1, cls = cls}
                ).ToList(); //149:4
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp114 = __loop11_results[__loop11_iteration];
                var __loop11_var1 = __tmp114.__loop11_var1;
                var cls = __tmp114.cls;
                bool __tmp116_outputWritten = false;
                string __tmp115Prefix = "		"; //150:1
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
                string __tmp118_line = " = "; //150:55
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
                string __tmp120_line = ".ToImmutable(Model);"; //150:114
                if (!string.IsNullOrEmpty(__tmp120_line))
                {
                    __out.Append(__tmp120_line);
                    __tmp116_outputWritten = true;
                }
                if (__tmp116_outputWritten) __out.AppendLine(true);
                if (__tmp116_outputWritten)
                {
                    __out.AppendLine(false); //150:134
                }
                var __loop12_results = 
                    (from __loop12_var1 in __Enumerate((cls).GetEnumerator()) //151:10
                    from prop in __Enumerate((__loop12_var1.Properties).GetEnumerator()) //151:15
                    select new { __loop12_var1 = __loop12_var1, prop = prop}
                    ).ToList(); //151:5
                for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
                {
                    var __tmp121 = __loop12_results[__loop12_iteration];
                    var __loop12_var1 = __tmp121.__loop12_var1;
                    var prop = __tmp121.prop;
                    bool __tmp123_outputWritten = false;
                    string __tmp122Prefix = "		"; //152:1
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
                    string __tmp125_line = " = "; //152:59
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
                    string __tmp127_line = ".ToImmutable(Model);"; //152:122
                    if (!string.IsNullOrEmpty(__tmp127_line))
                    {
                        __out.Append(__tmp127_line);
                        __tmp123_outputWritten = true;
                    }
                    if (__tmp123_outputWritten) __out.AppendLine(true);
                    if (__tmp123_outputWritten)
                    {
                        __out.AppendLine(false); //152:142
                    }
                }
            }
            __out.AppendLine(true); //155:1
            bool __tmp129_outputWritten = false;
            string __tmp128Prefix = "		"; //156:1
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
            string __tmp131_line = ".initialized = true;"; //156:50
            if (!string.IsNullOrEmpty(__tmp131_line))
            {
                __out.Append(__tmp131_line);
                __tmp129_outputWritten = true;
            }
            if (__tmp129_outputWritten) __out.AppendLine(true);
            if (__tmp129_outputWritten)
            {
                __out.AppendLine(false); //156:70
            }
            __out.Append("	}"); //157:1
            __out.AppendLine(false); //157:3
            __out.Append("}"); //158:1
            __out.AppendLine(false); //158:2
            return __out.ToString();
        }

        public string GenerateMetaModelBuilderInstance(MetaModel model) //161:1
        {
            StringBuilder __out = new StringBuilder();
            string coreNs = IsCoreModel(model) ? "" : Properties.CoreNs + "."; //162:2
            bool coreModel = IsCoreModel(model); //163:2
            ImmutableDictionary<ImmutableSymbol,string> symbolNames = GetSymbolInstanceNames(model); //164:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //165:1
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
                __out.AppendLine(false); //165:61
            }
            __out.Append("{"); //166:1
            __out.AppendLine(false); //166:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	internal static "; //167:1
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
            string __tmp9_line = " instance = new "; //167:63
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
            string __tmp11_line = "();"; //167:124
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Append(__tmp11_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //167:127
            }
            __out.AppendLine(true); //168:1
            __out.Append("	private bool creating;"); //169:1
            __out.AppendLine(false); //169:24
            __out.Append("	private bool created;"); //170:1
            __out.AppendLine(false); //170:23
            if (coreModel) //171:3
            {
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "	internal "; //172:1
                if (!string.IsNullOrEmpty(__tmp14_line))
                {
                    __out.Append(__tmp14_line);
                    __tmp13_outputWritten = true;
                }
                StringBuilder __tmp15 = new StringBuilder();
                __tmp15.Append(coreNs);
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
                string __tmp16_line = "MetaModelBuilder _MetaModel;"; //172:19
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Append(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //172:47
                }
            }
            else //173:3
            {
                bool __tmp18_outputWritten = false;
                string __tmp19_line = "	internal "; //174:1
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Append(__tmp19_line);
                    __tmp18_outputWritten = true;
                }
                StringBuilder __tmp20 = new StringBuilder();
                __tmp20.Append(coreNs);
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
                string __tmp21_line = "MetaModelBuilder MetaModel;"; //174:19
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp18_outputWritten = true;
                }
                if (__tmp18_outputWritten) __out.AppendLine(true);
                if (__tmp18_outputWritten)
                {
                    __out.AppendLine(false); //174:46
                }
            }
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	internal "; //176:1
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
            string __tmp26_line = ".MutableModel Model;"; //176:30
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //176:50
            }
            if (!coreModel) //177:3
            {
                bool __tmp28_outputWritten = false;
                string __tmp29_line = "	internal "; //178:1
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
                string __tmp31_line = ".MutableModelGroup ModelGroup;"; //178:30
                if (!string.IsNullOrEmpty(__tmp31_line))
                {
                    __out.Append(__tmp31_line);
                    __tmp28_outputWritten = true;
                }
                if (__tmp28_outputWritten) __out.AppendLine(true);
                if (__tmp28_outputWritten)
                {
                    __out.AppendLine(false); //178:60
                }
            }
            __out.AppendLine(true); //180:1
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //181:8
                from cst in __Enumerate((__loop13_var1).GetEnumerator()).OfType<MetaConstant>() //181:38
                select new { __loop13_var1 = __loop13_var1, cst = cst}
                ).ToList(); //181:3
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp32 = __loop13_results[__loop13_iteration];
                var __loop13_var1 = __tmp32.__loop13_var1;
                var cst = __tmp32.cst;
                bool __tmp34_outputWritten = false;
                string __tmp33Prefix = "	"; //182:1
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
                    __out.AppendLine(false); //182:30
                }
                if (coreModel) //183:4
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "	internal "; //184:1
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
                    string __tmp40_line = " "; //184:58
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
                    string __tmp42_line = " = null;"; //184:109
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Append(__tmp42_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //184:117
                    }
                }
                else //185:4
                {
                    bool __tmp44_outputWritten = false;
                    string __tmp45_line = "	internal "; //186:1
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
                    string __tmp47_line = " "; //186:64
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
                    string __tmp49_line = " = null;"; //186:115
                    if (!string.IsNullOrEmpty(__tmp49_line))
                    {
                        __out.Append(__tmp49_line);
                        __tmp44_outputWritten = true;
                    }
                    if (__tmp44_outputWritten) __out.AppendLine(true);
                    if (__tmp44_outputWritten)
                    {
                        __out.AppendLine(false); //186:123
                    }
                }
            }
            __out.AppendLine(true); //189:1
            var __loop14_results = 
                (from symbol in __Enumerate((Instances).GetEnumerator()) //190:8
                select new { symbol = symbol}
                ).ToList(); //190:3
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp50 = __loop14_results[__loop14_iteration];
                var symbol = __tmp50.symbol;
                bool __tmp52_outputWritten = false;
                string __tmp51Prefix = "	"; //191:1
                StringBuilder __tmp53 = new StringBuilder();
                __tmp53.Append(GenerateSymbolInstanceDeclaration(model, coreModel, symbol, symbolNames));
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
                    __out.AppendLine(false); //191:76
                }
            }
            __out.AppendLine(true); //193:1
            bool __tmp55_outputWritten = false;
            string __tmp56_line = "	internal "; //194:1
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
            string __tmp58_line = "()"; //194:56
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Append(__tmp58_line);
                __tmp55_outputWritten = true;
            }
            if (__tmp55_outputWritten) __out.AppendLine(true);
            if (__tmp55_outputWritten)
            {
                __out.AppendLine(false); //194:58
            }
            __out.Append("	{"); //195:1
            __out.AppendLine(false); //195:3
            if (coreModel) //196:4
            {
                bool __tmp60_outputWritten = false;
                string __tmp61_line = "		this.Model = new "; //197:1
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
                string __tmp63_line = ".MutableModel();"; //197:39
                if (!string.IsNullOrEmpty(__tmp63_line))
                {
                    __out.Append(__tmp63_line);
                    __tmp60_outputWritten = true;
                }
                if (__tmp60_outputWritten) __out.AppendLine(true);
                if (__tmp60_outputWritten)
                {
                    __out.AppendLine(false); //197:55
                }
            }
            else //198:4
            {
                bool __tmp65_outputWritten = false;
                string __tmp66_line = "		this.ModelGroup = new "; //199:1
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
                string __tmp68_line = ".MutableModelGroup();"; //199:44
                if (!string.IsNullOrEmpty(__tmp68_line))
                {
                    __out.Append(__tmp68_line);
                    __tmp65_outputWritten = true;
                }
                if (__tmp65_outputWritten) __out.AppendLine(true);
                if (__tmp65_outputWritten)
                {
                    __out.AppendLine(false); //199:65
                }
                bool __tmp70_outputWritten = false;
                string __tmp71_line = "		this.ModelGroup.AddReference("; //200:1
                if (!string.IsNullOrEmpty(__tmp71_line))
                {
                    __out.Append(__tmp71_line);
                    __tmp70_outputWritten = true;
                }
                StringBuilder __tmp72 = new StringBuilder();
                __tmp72.Append(Properties.CoreNs);
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
                string __tmp73_line = ".MetaInstance.Model.ToMutable(true));"; //200:51
                if (!string.IsNullOrEmpty(__tmp73_line))
                {
                    __out.Append(__tmp73_line);
                    __tmp70_outputWritten = true;
                }
                if (__tmp70_outputWritten) __out.AppendLine(true);
                if (__tmp70_outputWritten)
                {
                    __out.AppendLine(false); //200:88
                }
                __out.Append("		this.Model = this.ModelGroup.CreateModel();"); //201:1
                __out.AppendLine(false); //201:46
            }
            __out.Append("	}"); //203:1
            __out.AppendLine(false); //203:3
            __out.AppendLine(true); //204:1
            __out.Append("	internal void Create()"); //205:1
            __out.AppendLine(false); //205:24
            __out.Append("	{"); //206:1
            __out.AppendLine(false); //206:3
            __out.Append("		lock (this)"); //207:1
            __out.AppendLine(false); //207:14
            __out.Append("		{"); //208:1
            __out.AppendLine(false); //208:4
            __out.Append("			if (this.creating || this.created) return;"); //209:1
            __out.AppendLine(false); //209:46
            __out.Append("			this.creating = true;"); //210:1
            __out.AppendLine(false); //210:25
            __out.Append("		}"); //211:1
            __out.AppendLine(false); //211:4
            bool __tmp75_outputWritten = false;
            string __tmp74Prefix = "		"; //212:1
            StringBuilder __tmp76 = new StringBuilder();
            __tmp76.Append(CSharpName(model, ModelKind.ImplementationProvider));
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
            string __tmp77_line = ".Implementation."; //212:55
            if (!string.IsNullOrEmpty(__tmp77_line))
            {
                __out.Append(__tmp77_line);
                __tmp75_outputWritten = true;
            }
            StringBuilder __tmp78 = new StringBuilder();
            __tmp78.Append(CSharpName(model, ModelKind.BuilderInstance));
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
                        __tmp75_outputWritten = true;
                    }
                    if (!__tmp78_last) __out.AppendLine(true);
                }
            }
            string __tmp79_line = "(this);"; //212:116
            if (!string.IsNullOrEmpty(__tmp79_line))
            {
                __out.Append(__tmp79_line);
                __tmp75_outputWritten = true;
            }
            if (__tmp75_outputWritten) __out.AppendLine(true);
            if (__tmp75_outputWritten)
            {
                __out.AppendLine(false); //212:123
            }
            __out.Append("		this.CreateSymbols();"); //213:1
            __out.AppendLine(false); //213:24
            __out.Append("		lock (this)"); //214:1
            __out.AppendLine(false); //214:14
            __out.Append("		{"); //215:1
            __out.AppendLine(false); //215:4
            __out.Append("			this.created = true;"); //216:1
            __out.AppendLine(false); //216:24
            __out.Append("		}"); //217:1
            __out.AppendLine(false); //217:4
            __out.Append("	}"); //218:1
            __out.AppendLine(false); //218:3
            __out.AppendLine(true); //219:1
            __out.Append("	internal void EvaluateLazyValues()"); //220:1
            __out.AppendLine(false); //220:36
            __out.Append("	{"); //221:1
            __out.AppendLine(false); //221:3
            __out.Append("		if (!this.created) return;"); //222:1
            __out.AppendLine(false); //222:29
            __out.Append("		this.Model.EvaluateLazyValues();"); //223:1
            __out.AppendLine(false); //223:35
            __out.Append("	}"); //224:1
            __out.AppendLine(false); //224:3
            __out.AppendLine(true); //225:1
            __out.Append("	private void CreateSymbols()"); //226:1
            __out.AppendLine(false); //226:30
            __out.Append("	{"); //227:1
            __out.AppendLine(false); //227:3
            bool __tmp81_outputWritten = false;
            string __tmp80Prefix = "		"; //228:1
            StringBuilder __tmp82 = new StringBuilder();
            __tmp82.Append(Properties.CoreNs);
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
                    if (!__tmp82_last) __out.AppendLine(true);
                }
            }
            string __tmp83_line = ".MetaFactory factory = new "; //228:22
            if (!string.IsNullOrEmpty(__tmp83_line))
            {
                __out.Append(__tmp83_line);
                __tmp81_outputWritten = true;
            }
            StringBuilder __tmp84 = new StringBuilder();
            __tmp84.Append(Properties.CoreNs);
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
                        __tmp81_outputWritten = true;
                    }
                    if (!__tmp84_last) __out.AppendLine(true);
                }
            }
            string __tmp85_line = ".MetaFactory(this.Model, "; //228:68
            if (!string.IsNullOrEmpty(__tmp85_line))
            {
                __out.Append(__tmp85_line);
                __tmp81_outputWritten = true;
            }
            StringBuilder __tmp86 = new StringBuilder();
            __tmp86.Append(Properties.CoreNs);
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
                        __tmp81_outputWritten = true;
                    }
                    if (!__tmp86_last) __out.AppendLine(true);
                }
            }
            string __tmp87_line = ".ModelFactoryFlags.DontMakeSymbolsCreated);"; //228:112
            if (!string.IsNullOrEmpty(__tmp87_line))
            {
                __out.Append(__tmp87_line);
                __tmp81_outputWritten = true;
            }
            if (__tmp81_outputWritten) __out.AppendLine(true);
            if (__tmp81_outputWritten)
            {
                __out.AppendLine(false); //228:155
            }
            __out.AppendLine(true); //229:1
            var __loop15_results = 
                (from symbol in __Enumerate((Instances).GetEnumerator()) //230:9
                select new { symbol = symbol}
                ).ToList(); //230:4
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                var __tmp88 = __loop15_results[__loop15_iteration];
                var symbol = __tmp88.symbol;
                bool __tmp90_outputWritten = false;
                string __tmp89Prefix = "		"; //231:1
                StringBuilder __tmp91 = new StringBuilder();
                __tmp91.Append(GenerateSymbolInstance(model, coreModel, symbol, symbolNames));
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
                    __out.AppendLine(false); //231:66
                }
            }
            __out.AppendLine(true); //233:1
            var __loop16_results = 
                (from symbol in __Enumerate((Instances).GetEnumerator()) //234:9
                select new { symbol = symbol}
                ).ToList(); //234:4
            for (int __loop16_iteration = 0; __loop16_iteration < __loop16_results.Count; ++__loop16_iteration)
            {
                var __tmp92 = __loop16_results[__loop16_iteration];
                var symbol = __tmp92.symbol;
                bool __tmp94_outputWritten = false;
                string __tmp93Prefix = "		"; //235:1
                StringBuilder __tmp95 = new StringBuilder();
                __tmp95.Append(GenerateSymbolInstanceProperties(model, coreModel, symbol, symbolNames));
                using(StreamReader __tmp95Reader = new StreamReader(this.__ToStream(__tmp95.ToString())))
                {
                    bool __tmp95_last = __tmp95Reader.EndOfStream;
                    while(!__tmp95_last)
                    {
                        string __tmp95_line = __tmp95Reader.ReadLine();
                        __tmp95_last = __tmp95Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp93Prefix))
                        {
                            __out.Append(__tmp93Prefix);
                            __tmp94_outputWritten = true;
                        }
                        if ((__tmp95_last && !string.IsNullOrEmpty(__tmp95_line)) || (!__tmp95_last && __tmp95_line != null))
                        {
                            __out.Append(__tmp95_line);
                            __tmp94_outputWritten = true;
                        }
                        if (!__tmp95_last || __tmp94_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp94_outputWritten)
                {
                    __out.AppendLine(false); //235:76
                }
            }
            __out.AppendLine(true); //237:1
            __out.Append("		foreach (global::MetaDslx.Core.MutableSymbol symbol in this.Model.Symbols)"); //238:1
            __out.AppendLine(false); //238:77
            __out.Append("		{"); //239:1
            __out.AppendLine(false); //239:4
            __out.Append("			symbol.MMakeCreated();"); //240:1
            __out.AppendLine(false); //240:26
            __out.Append("		}"); //241:1
            __out.AppendLine(false); //241:4
            __out.Append("	}"); //242:1
            __out.AppendLine(false); //242:3
            __out.Append("}"); //243:1
            __out.AppendLine(false); //243:2
            return __out.ToString();
        }

        public string GenerateSymbolInstanceDeclaration(MetaModel model, bool coreModel, ImmutableSymbol symbol, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //246:1
        {
            StringBuilder __out = new StringBuilder();
            if (symbol != null && symbol.MMetaClass != null && symbolNames.ContainsKey(symbol)) //247:2
            {
                string name = symbolNames[symbol]; //248:3
                if (coreModel) //249:3
                {
                    if (name.StartsWith("__")) //250:4
                    {
                        bool __tmp2_outputWritten = false;
                        string __tmp3_line = "private "; //251:1
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
                        string __tmp5_line = " "; //251:65
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
                        string __tmp7_line = ";"; //251:72
                        if (!string.IsNullOrEmpty(__tmp7_line))
                        {
                            __out.Append(__tmp7_line);
                            __tmp2_outputWritten = true;
                        }
                        if (__tmp2_outputWritten) __out.AppendLine(true);
                        if (__tmp2_outputWritten)
                        {
                            __out.AppendLine(false); //251:73
                        }
                    }
                    else //252:4
                    {
                        bool __tmp9_outputWritten = false;
                        string __tmp10_line = "internal "; //253:1
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
                        string __tmp12_line = " "; //253:66
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
                        string __tmp14_line = ";"; //253:73
                        if (!string.IsNullOrEmpty(__tmp14_line))
                        {
                            __out.Append(__tmp14_line);
                            __tmp9_outputWritten = true;
                        }
                        if (__tmp9_outputWritten) __out.AppendLine(true);
                        if (__tmp9_outputWritten)
                        {
                            __out.AppendLine(false); //253:74
                        }
                    }
                }
                else //255:3
                {
                    if (name.StartsWith("__")) //256:4
                    {
                        bool __tmp16_outputWritten = false;
                        string __tmp17_line = "private "; //257:1
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
                        string __tmp19_line = " "; //257:71
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
                        string __tmp21_line = ";"; //257:78
                        if (!string.IsNullOrEmpty(__tmp21_line))
                        {
                            __out.Append(__tmp21_line);
                            __tmp16_outputWritten = true;
                        }
                        if (__tmp16_outputWritten) __out.AppendLine(true);
                        if (__tmp16_outputWritten)
                        {
                            __out.AppendLine(false); //257:79
                        }
                    }
                    else //258:4
                    {
                        bool __tmp23_outputWritten = false;
                        string __tmp24_line = "internal "; //259:1
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
                        string __tmp26_line = " "; //259:72
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
                        string __tmp28_line = ";"; //259:79
                        if (!string.IsNullOrEmpty(__tmp28_line))
                        {
                            __out.Append(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                        if (__tmp23_outputWritten) __out.AppendLine(true);
                        if (__tmp23_outputWritten)
                        {
                            __out.AppendLine(false); //259:80
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateSymbolInstance(MetaModel model, bool coreModel, ImmutableSymbol symbol, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //265:1
        {
            StringBuilder __out = new StringBuilder();
            if (symbol != null && symbol.MMetaClass != null && symbolNames.ContainsKey(symbol)) //266:2
            {
                string name = symbolNames[symbol]; //267:3
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
                string __tmp4_line = " = factory."; //268:7
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
                string __tmp6_line = "();"; //268:76
                if (!string.IsNullOrEmpty(__tmp6_line))
                {
                    __out.Append(__tmp6_line);
                    __tmp2_outputWritten = true;
                }
                if (__tmp2_outputWritten) __out.AppendLine(true);
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //268:79
                }
                if (symbol is MetaModel) //269:3
                {
                    if (coreModel) //270:4
                    {
                        bool __tmp8_outputWritten = false;
                        string __tmp9_line = "_MetaModel = "; //271:1
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
                        string __tmp11_line = ";"; //271:20
                        if (!string.IsNullOrEmpty(__tmp11_line))
                        {
                            __out.Append(__tmp11_line);
                            __tmp8_outputWritten = true;
                        }
                        if (__tmp8_outputWritten) __out.AppendLine(true);
                        if (__tmp8_outputWritten)
                        {
                            __out.AppendLine(false); //271:21
                        }
                    }
                    else //272:4
                    {
                        bool __tmp13_outputWritten = false;
                        string __tmp14_line = "MetaModel = "; //273:1
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
                        string __tmp16_line = ";"; //273:19
                        if (!string.IsNullOrEmpty(__tmp16_line))
                        {
                            __out.Append(__tmp16_line);
                            __tmp13_outputWritten = true;
                        }
                        if (__tmp13_outputWritten) __out.AppendLine(true);
                        if (__tmp13_outputWritten)
                        {
                            __out.AppendLine(false); //273:20
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateSymbolInstanceProperties(MetaModel model, bool coreModel, ImmutableSymbol symbol, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //279:1
        {
            StringBuilder __out = new StringBuilder();
            if (symbol != null && symbol.MMetaClass != null && symbolNames.ContainsKey(symbol)) //280:2
            {
                var __loop17_results = 
                    (from __loop17_var1 in __Enumerate((symbol).GetEnumerator()) //281:8
                    from prop in __Enumerate((__loop17_var1.MProperties).GetEnumerator()) //281:16
                    where !prop.IsDerived && !prop.IsDerivedUnion //281:33
                    select new { __loop17_var1 = __loop17_var1, prop = prop}
                    ).ToList(); //281:3
                for (int __loop17_iteration = 0; __loop17_iteration < __loop17_results.Count; ++__loop17_iteration)
                {
                    var __tmp1 = __loop17_results[__loop17_iteration];
                    var __loop17_var1 = __tmp1.__loop17_var1;
                    var prop = __tmp1.prop;
                    object propValue = symbol.MGet(prop); //282:4
                    bool __tmp3_outputWritten = false;
                    StringBuilder __tmp4 = new StringBuilder();
                    __tmp4.Append(GenerateSymbolInstancePropertyValue(model, coreModel, symbol, prop, propValue, symbolNames));
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
                        __out.AppendLine(false); //283:94
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateSymbolInstancePropertyValue(MetaModel model, bool coreModel, ImmutableSymbol symbol, ModelProperty prop, object value, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //288:1
        {
            StringBuilder __out = new StringBuilder();
            string name = symbolNames[symbol]; //289:2
            ImmutableSymbol valueSymbol = value as ImmutableSymbol; //290:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //291:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //292:2
            if (value == null) //293:2
            {
                if (prop.MutableTypeInfo.Type != null && prop.MutableTypeInfo.Type.IsClass) //294:3
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
                    string __tmp4_line = "."; //295:7
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
                    string __tmp6_line = " = null;"; //295:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //295:27
                    }
                }
                else //296:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //297:1
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
                    string __tmp11_line = "."; //297:10
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
                    string __tmp13_line = " = null;"; //297:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Append(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //297:30
                    }
                }
            }
            else if (value is string) //299:2
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
                string __tmp17_line = "."; //300:7
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
                string __tmp19_line = " = \""; //300:19
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
                string __tmp21_line = "\";"; //300:50
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //300:52
                }
            }
            else if (value is bool) //301:2
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
                string __tmp25_line = "."; //302:7
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
                string __tmp27_line = " = "; //302:19
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
                string __tmp29_line = ";"; //302:50
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Append(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //302:51
                }
            }
            else if (value.GetType().IsPrimitive) //303:2
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
                string __tmp33_line = "."; //304:7
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
                string __tmp35_line = " = "; //304:19
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
                string __tmp37_line = ";"; //304:40
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //304:41
                }
            }
            else if (value is Enum) //305:2
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
                string __tmp41_line = "."; //306:7
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
                string __tmp43_line = " = "; //306:19
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Append(__tmp43_line);
                    __tmp39_outputWritten = true;
                }
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(GetEnumValueOf((Enum)value));
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
                string __tmp45_line = ";"; //306:51
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Append(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //306:52
                }
            }
            else if (value is MetaPrimitiveType) //307:2
            {
                if (coreModel) //308:3
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
                    string __tmp49_line = "."; //309:7
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
                    string __tmp51_line = "Lazy = () => "; //309:19
                    if (!string.IsNullOrEmpty(__tmp51_line))
                    {
                        __out.Append(__tmp51_line);
                        __tmp47_outputWritten = true;
                    }
                    StringBuilder __tmp52 = new StringBuilder();
                    __tmp52.Append(ToPascalCase(((MetaPrimitiveType)value).Name));
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
                    string __tmp53_line = ";"; //309:80
                    if (!string.IsNullOrEmpty(__tmp53_line))
                    {
                        __out.Append(__tmp53_line);
                        __tmp47_outputWritten = true;
                    }
                    if (__tmp47_outputWritten) __out.AppendLine(true);
                    if (__tmp47_outputWritten)
                    {
                        __out.AppendLine(false); //309:81
                    }
                }
                else //310:3
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
                    string __tmp57_line = "."; //311:7
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
                    string __tmp59_line = "Lazy = () => "; //311:19
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Append(__tmp59_line);
                        __tmp55_outputWritten = true;
                    }
                    StringBuilder __tmp60 = new StringBuilder();
                    __tmp60.Append(CSharpName(((MetaPrimitiveType)value), model, ClassKind.ImmutableInstance, true));
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
                    string __tmp61_line = ".ToMutable();"; //311:113
                    if (!string.IsNullOrEmpty(__tmp61_line))
                    {
                        __out.Append(__tmp61_line);
                        __tmp55_outputWritten = true;
                    }
                    if (__tmp55_outputWritten) __out.AppendLine(true);
                    if (__tmp55_outputWritten)
                    {
                        __out.AppendLine(false); //311:126
                    }
                }
            }
            else if (valueSymbol != null && symbolNames.ContainsKey(valueSymbol)) //313:2
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
                string __tmp65_line = "."; //314:7
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
                string __tmp67_line = "Lazy = () => "; //314:19
                if (!string.IsNullOrEmpty(__tmp67_line))
                {
                    __out.Append(__tmp67_line);
                    __tmp63_outputWritten = true;
                }
                StringBuilder __tmp68 = new StringBuilder();
                __tmp68.Append(symbolNames[valueSymbol]);
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
                string __tmp69_line = ";"; //314:58
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Append(__tmp69_line);
                    __tmp63_outputWritten = true;
                }
                if (__tmp63_outputWritten) __out.AppendLine(true);
                if (__tmp63_outputWritten)
                {
                    __out.AppendLine(false); //314:59
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //315:2
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
                string __tmp73_line = "."; //316:7
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
                string __tmp75_line = "Lazy = () => "; //316:19
                if (!string.IsNullOrEmpty(__tmp75_line))
                {
                    __out.Append(__tmp75_line);
                    __tmp71_outputWritten = true;
                }
                StringBuilder __tmp76 = new StringBuilder();
                __tmp76.Append(CSharpName(((MetaType)valueDecl), model, ClassKind.Immutable, true));
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
                string __tmp77_line = ".ToMutable();"; //316:100
                if (!string.IsNullOrEmpty(__tmp77_line))
                {
                    __out.Append(__tmp77_line);
                    __tmp71_outputWritten = true;
                }
                if (__tmp71_outputWritten) __out.AppendLine(true);
                if (__tmp71_outputWritten)
                {
                    __out.AppendLine(false); //316:113
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //317:2
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
                string __tmp81_line = "."; //318:7
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
                string __tmp83_line = "Lazy = () => "; //318:19
                if (!string.IsNullOrEmpty(__tmp83_line))
                {
                    __out.Append(__tmp83_line);
                    __tmp79_outputWritten = true;
                }
                StringBuilder __tmp84 = new StringBuilder();
                __tmp84.Append(CSharpName(((MetaConstant)valueDecl), model, ClassKind.Immutable, true));
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
                string __tmp85_line = ".ToMutable();"; //318:104
                if (!string.IsNullOrEmpty(__tmp85_line))
                {
                    __out.Append(__tmp85_line);
                    __tmp79_outputWritten = true;
                }
                if (__tmp79_outputWritten) __out.AppendLine(true);
                if (__tmp79_outputWritten)
                {
                    __out.AppendLine(false); //318:117
                }
            }
            else if (valueCollection != null) //319:2
            {
                var __loop18_results = 
                    (from cvalue in __Enumerate((valueCollection).GetEnumerator()) //320:8
                    select new { cvalue = cvalue}
                    ).ToList(); //320:3
                for (int __loop18_iteration = 0; __loop18_iteration < __loop18_results.Count; ++__loop18_iteration)
                {
                    var __tmp86 = __loop18_results[__loop18_iteration];
                    var cvalue = __tmp86.cvalue;
                    bool __tmp88_outputWritten = false;
                    StringBuilder __tmp89 = new StringBuilder();
                    __tmp89.Append(GenerateSymbolInstancePropertyCollectionValue(model, coreModel, symbol, prop, cvalue, symbolNames));
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
                                __tmp88_outputWritten = true;
                            }
                            if (!__tmp89_last || __tmp88_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp88_outputWritten)
                    {
                        __out.AppendLine(false); //321:101
                    }
                }
            }
            else //323:2
            {
                bool __tmp91_outputWritten = false;
                string __tmp92_line = "// TODO: "; //324:1
                if (!string.IsNullOrEmpty(__tmp92_line))
                {
                    __out.Append(__tmp92_line);
                    __tmp91_outputWritten = true;
                }
                StringBuilder __tmp93 = new StringBuilder();
                __tmp93.Append(name);
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
                            __tmp91_outputWritten = true;
                        }
                        if (!__tmp93_last) __out.AppendLine(true);
                    }
                }
                string __tmp94_line = "."; //324:16
                if (!string.IsNullOrEmpty(__tmp94_line))
                {
                    __out.Append(__tmp94_line);
                    __tmp91_outputWritten = true;
                }
                StringBuilder __tmp95 = new StringBuilder();
                __tmp95.Append(prop.Name);
                using(StreamReader __tmp95Reader = new StreamReader(this.__ToStream(__tmp95.ToString())))
                {
                    bool __tmp95_last = __tmp95Reader.EndOfStream;
                    while(!__tmp95_last)
                    {
                        string __tmp95_line = __tmp95Reader.ReadLine();
                        __tmp95_last = __tmp95Reader.EndOfStream;
                        if ((__tmp95_last && !string.IsNullOrEmpty(__tmp95_line)) || (!__tmp95_last && __tmp95_line != null))
                        {
                            __out.Append(__tmp95_line);
                            __tmp91_outputWritten = true;
                        }
                        if (!__tmp95_last || __tmp91_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp91_outputWritten)
                {
                    __out.AppendLine(false); //324:28
                }
            }
            return __out.ToString();
        }

        public string GenerateSymbolInstancePropertyCollectionValue(MetaModel model, bool coreModel, ImmutableSymbol symbol, ModelProperty prop, object value, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //328:1
        {
            StringBuilder __out = new StringBuilder();
            string name = symbolNames[symbol]; //329:2
            ImmutableSymbol valueSymbol = value as ImmutableSymbol; //330:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //331:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //332:2
            if (value == null) //333:2
            {
                if (prop.MutableTypeInfo.Type != null && prop.MutableTypeInfo.Type.IsClass) //334:3
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
                    string __tmp4_line = "."; //335:7
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
                    string __tmp6_line = ".Add(null);"; //335:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //335:30
                    }
                }
                else //336:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //337:1
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
                    string __tmp11_line = "."; //337:10
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
                    string __tmp13_line = ".Add(null);"; //337:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Append(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //337:33
                    }
                }
            }
            else if (value is string) //339:2
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
                string __tmp17_line = "."; //340:7
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
                string __tmp19_line = ".Add(\""; //340:19
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
                string __tmp21_line = "\");"; //340:52
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //340:55
                }
            }
            else if (value is bool) //341:2
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
                string __tmp25_line = "."; //342:7
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
                string __tmp27_line = ".Add("; //342:19
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
                string __tmp29_line = ");"; //342:52
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Append(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //342:54
                }
            }
            else if (value.GetType().IsPrimitive) //343:2
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
                string __tmp33_line = "."; //344:7
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
                string __tmp35_line = ".Add("; //344:19
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
                string __tmp37_line = ");"; //344:42
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //344:44
                }
            }
            else if (value is Enum) //345:2
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
                string __tmp41_line = "."; //346:7
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
                string __tmp43_line = ".Add("; //346:19
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Append(__tmp43_line);
                    __tmp39_outputWritten = true;
                }
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(GetEnumValueOf((Enum)value));
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
                string __tmp45_line = ");"; //346:53
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Append(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //346:55
                }
            }
            else if (value is MetaPrimitiveType) //347:2
            {
                if (coreModel) //348:3
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
                    string __tmp49_line = "."; //349:7
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
                    string __tmp51_line = ".AddLazy(() => "; //349:19
                    if (!string.IsNullOrEmpty(__tmp51_line))
                    {
                        __out.Append(__tmp51_line);
                        __tmp47_outputWritten = true;
                    }
                    StringBuilder __tmp52 = new StringBuilder();
                    __tmp52.Append(ToPascalCase(((MetaPrimitiveType)value).Name));
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
                    string __tmp53_line = ");"; //349:82
                    if (!string.IsNullOrEmpty(__tmp53_line))
                    {
                        __out.Append(__tmp53_line);
                        __tmp47_outputWritten = true;
                    }
                    if (__tmp47_outputWritten) __out.AppendLine(true);
                    if (__tmp47_outputWritten)
                    {
                        __out.AppendLine(false); //349:84
                    }
                }
                else //350:3
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
                    string __tmp57_line = "."; //351:7
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
                    string __tmp59_line = ".AddLazy(() => "; //351:19
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Append(__tmp59_line);
                        __tmp55_outputWritten = true;
                    }
                    StringBuilder __tmp60 = new StringBuilder();
                    __tmp60.Append(CSharpName(((MetaPrimitiveType)value), model, ClassKind.ImmutableInstance, true));
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
                    string __tmp61_line = ".ToMutable());"; //351:115
                    if (!string.IsNullOrEmpty(__tmp61_line))
                    {
                        __out.Append(__tmp61_line);
                        __tmp55_outputWritten = true;
                    }
                    if (__tmp55_outputWritten) __out.AppendLine(true);
                    if (__tmp55_outputWritten)
                    {
                        __out.AppendLine(false); //351:129
                    }
                }
            }
            else if (valueSymbol != null && symbolNames.ContainsKey(valueSymbol)) //353:2
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
                string __tmp65_line = "."; //354:7
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
                string __tmp67_line = ".AddLazy(() => "; //354:19
                if (!string.IsNullOrEmpty(__tmp67_line))
                {
                    __out.Append(__tmp67_line);
                    __tmp63_outputWritten = true;
                }
                StringBuilder __tmp68 = new StringBuilder();
                __tmp68.Append(symbolNames[valueSymbol]);
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
                string __tmp69_line = ");"; //354:60
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Append(__tmp69_line);
                    __tmp63_outputWritten = true;
                }
                if (__tmp63_outputWritten) __out.AppendLine(true);
                if (__tmp63_outputWritten)
                {
                    __out.AppendLine(false); //354:62
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //355:2
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
                string __tmp73_line = "."; //356:7
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
                string __tmp75_line = ".AddLazy(() => "; //356:19
                if (!string.IsNullOrEmpty(__tmp75_line))
                {
                    __out.Append(__tmp75_line);
                    __tmp71_outputWritten = true;
                }
                StringBuilder __tmp76 = new StringBuilder();
                __tmp76.Append(CSharpName(((MetaType)valueDecl), model, ClassKind.Immutable, true));
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
                string __tmp77_line = ".ToMutable());"; //356:102
                if (!string.IsNullOrEmpty(__tmp77_line))
                {
                    __out.Append(__tmp77_line);
                    __tmp71_outputWritten = true;
                }
                if (__tmp71_outputWritten) __out.AppendLine(true);
                if (__tmp71_outputWritten)
                {
                    __out.AppendLine(false); //356:116
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //357:2
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
                string __tmp81_line = "."; //358:7
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
                string __tmp83_line = ".AddLazy(() => "; //358:19
                if (!string.IsNullOrEmpty(__tmp83_line))
                {
                    __out.Append(__tmp83_line);
                    __tmp79_outputWritten = true;
                }
                StringBuilder __tmp84 = new StringBuilder();
                __tmp84.Append(CSharpName(((MetaConstant)valueDecl), model, ClassKind.Immutable, true));
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
                string __tmp85_line = ".ToMutable());"; //358:106
                if (!string.IsNullOrEmpty(__tmp85_line))
                {
                    __out.Append(__tmp85_line);
                    __tmp79_outputWritten = true;
                }
                if (__tmp79_outputWritten) __out.AppendLine(true);
                if (__tmp79_outputWritten)
                {
                    __out.AppendLine(false); //358:120
                }
            }
            else //359:2
            {
                bool __tmp87_outputWritten = false;
                string __tmp88_line = "// TODO: "; //360:1
                if (!string.IsNullOrEmpty(__tmp88_line))
                {
                    __out.Append(__tmp88_line);
                    __tmp87_outputWritten = true;
                }
                StringBuilder __tmp89 = new StringBuilder();
                __tmp89.Append(name);
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
                            __tmp87_outputWritten = true;
                        }
                        if (!__tmp89_last) __out.AppendLine(true);
                    }
                }
                string __tmp90_line = "."; //360:16
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Append(__tmp90_line);
                    __tmp87_outputWritten = true;
                }
                StringBuilder __tmp91 = new StringBuilder();
                __tmp91.Append(prop.Name);
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
                            __tmp87_outputWritten = true;
                        }
                        if (!__tmp91_last || __tmp87_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp87_outputWritten)
                {
                    __out.AppendLine(false); //360:28
                }
            }
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //364:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //365:1
            __out.AppendLine(false); //365:14
            __out.Append("/// Factory class for creating instances of model elements."); //366:1
            __out.AppendLine(false); //366:60
            __out.Append("/// </summary>"); //367:1
            __out.AppendLine(false); //367:15
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //368:1
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
            string __tmp5_line = " : "; //368:51
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
            string __tmp7_line = ".ModelFactory"; //368:73
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //368:86
            }
            __out.Append("{"); //369:1
            __out.AppendLine(false); //369:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public "; //370:1
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
            string __tmp12_line = "("; //370:46
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
            string __tmp14_line = ".MutableModel model, "; //370:66
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
            string __tmp16_line = ".ModelFactoryFlags flags = "; //370:106
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
            string __tmp18_line = ".ModelFactoryFlags.None)"; //370:152
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Append(__tmp18_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //370:176
            }
            __out.Append("		: base(model, flags)"); //371:1
            __out.AppendLine(false); //371:23
            __out.Append("	{"); //372:1
            __out.AppendLine(false); //372:3
            bool __tmp20_outputWritten = false;
            string __tmp19Prefix = "		"; //373:1
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
            string __tmp22_line = ".Initialize();"; //373:43
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Append(__tmp22_line);
                __tmp20_outputWritten = true;
            }
            if (__tmp20_outputWritten) __out.AppendLine(true);
            if (__tmp20_outputWritten)
            {
                __out.AppendLine(false); //373:57
            }
            __out.Append("	}"); //374:1
            __out.AppendLine(false); //374:3
            __out.AppendLine(true); //375:1
            bool __tmp24_outputWritten = false;
            string __tmp25_line = "	public override "; //376:1
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
            string __tmp27_line = ".MutableSymbol Create(string type)"; //376:37
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Append(__tmp27_line);
                __tmp24_outputWritten = true;
            }
            if (__tmp24_outputWritten) __out.AppendLine(true);
            if (__tmp24_outputWritten)
            {
                __out.AppendLine(false); //376:71
            }
            __out.Append("	{"); //377:1
            __out.AppendLine(false); //377:3
            __out.Append("		switch (type)"); //378:1
            __out.AppendLine(false); //378:16
            __out.Append("		{"); //379:1
            __out.AppendLine(false); //379:4
            var __loop19_results = 
                (from __loop19_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //380:10
                from cls in __Enumerate((__loop19_var1).GetEnumerator()).OfType<MetaClass>() //380:40
                select new { __loop19_var1 = __loop19_var1, cls = cls}
                ).ToList(); //380:5
            for (int __loop19_iteration = 0; __loop19_iteration < __loop19_results.Count; ++__loop19_iteration)
            {
                var __tmp28 = __loop19_results[__loop19_iteration];
                var __loop19_var1 = __tmp28.__loop19_var1;
                var cls = __tmp28.cls;
                if (!cls.IsAbstract) //381:6
                {
                    bool __tmp30_outputWritten = false;
                    string __tmp31_line = "			case \""; //382:1
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
                    string __tmp33_line = "\": return this."; //382:33
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
                    string __tmp35_line = "();"; //382:71
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Append(__tmp35_line);
                        __tmp30_outputWritten = true;
                    }
                    if (__tmp30_outputWritten) __out.AppendLine(true);
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //382:74
                    }
                }
            }
            __out.Append("			default:"); //385:1
            __out.AppendLine(false); //385:12
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "				throw new "; //386:1
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
            string __tmp40_line = ".ModelException(\"Unknown type name: \" + type);"; //386:34
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Append(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //386:80
            }
            __out.Append("		}"); //387:1
            __out.AppendLine(false); //387:4
            __out.Append("	}"); //388:1
            __out.AppendLine(false); //388:3
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //389:8
                from cls in __Enumerate((__loop20_var1).GetEnumerator()).OfType<MetaClass>() //389:38
                select new { __loop20_var1 = __loop20_var1, cls = cls}
                ).ToList(); //389:3
            for (int __loop20_iteration = 0; __loop20_iteration < __loop20_results.Count; ++__loop20_iteration)
            {
                var __tmp41 = __loop20_results[__loop20_iteration];
                var __loop20_var1 = __tmp41.__loop20_var1;
                var cls = __tmp41.cls;
                if (!cls.IsAbstract) //390:4
                {
                    __out.AppendLine(true); //391:1
                    __out.Append("	/// <summary>"); //392:1
                    __out.AppendLine(false); //392:15
                    bool __tmp43_outputWritten = false;
                    string __tmp44_line = "	/// Creates a new instance of "; //393:1
                    if (!string.IsNullOrEmpty(__tmp44_line))
                    {
                        __out.Append(__tmp44_line);
                        __tmp43_outputWritten = true;
                    }
                    StringBuilder __tmp45 = new StringBuilder();
                    __tmp45.Append(CSharpName(cls, model));
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
                    string __tmp46_line = "."; //393:55
                    if (!string.IsNullOrEmpty(__tmp46_line))
                    {
                        __out.Append(__tmp46_line);
                        __tmp43_outputWritten = true;
                    }
                    if (__tmp43_outputWritten) __out.AppendLine(true);
                    if (__tmp43_outputWritten)
                    {
                        __out.AppendLine(false); //393:56
                    }
                    __out.Append("	/// </summary>"); //394:1
                    __out.AppendLine(false); //394:16
                    bool __tmp48_outputWritten = false;
                    string __tmp49_line = "	public "; //395:1
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
                    string __tmp51_line = " "; //395:51
                    if (!string.IsNullOrEmpty(__tmp51_line))
                    {
                        __out.Append(__tmp51_line);
                        __tmp48_outputWritten = true;
                    }
                    StringBuilder __tmp52 = new StringBuilder();
                    __tmp52.Append(CSharpName(cls, model, ClassKind.FactoryMethod));
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
                    string __tmp53_line = "()"; //395:100
                    if (!string.IsNullOrEmpty(__tmp53_line))
                    {
                        __out.Append(__tmp53_line);
                        __tmp48_outputWritten = true;
                    }
                    if (__tmp48_outputWritten) __out.AppendLine(true);
                    if (__tmp48_outputWritten)
                    {
                        __out.AppendLine(false); //395:102
                    }
                    __out.Append("	{"); //396:1
                    __out.AppendLine(false); //396:3
                    bool __tmp55_outputWritten = false;
                    string __tmp54Prefix = "		"; //397:1
                    StringBuilder __tmp56 = new StringBuilder();
                    __tmp56.Append(Properties.CoreNs);
                    using(StreamReader __tmp56Reader = new StreamReader(this.__ToStream(__tmp56.ToString())))
                    {
                        bool __tmp56_last = __tmp56Reader.EndOfStream;
                        while(!__tmp56_last)
                        {
                            string __tmp56_line = __tmp56Reader.ReadLine();
                            __tmp56_last = __tmp56Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp54Prefix))
                            {
                                __out.Append(__tmp54Prefix);
                                __tmp55_outputWritten = true;
                            }
                            if ((__tmp56_last && !string.IsNullOrEmpty(__tmp56_line)) || (!__tmp56_last && __tmp56_line != null))
                            {
                                __out.Append(__tmp56_line);
                                __tmp55_outputWritten = true;
                            }
                            if (!__tmp56_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp57_line = ".MutableSymbol symbol = this.CreateSymbol(new "; //397:22
                    if (!string.IsNullOrEmpty(__tmp57_line))
                    {
                        __out.Append(__tmp57_line);
                        __tmp55_outputWritten = true;
                    }
                    StringBuilder __tmp58 = new StringBuilder();
                    __tmp58.Append(CSharpName(cls, model, ClassKind.Id));
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
                    string __tmp59_line = "());"; //397:105
                    if (!string.IsNullOrEmpty(__tmp59_line))
                    {
                        __out.Append(__tmp59_line);
                        __tmp55_outputWritten = true;
                    }
                    if (__tmp55_outputWritten) __out.AppendLine(true);
                    if (__tmp55_outputWritten)
                    {
                        __out.AppendLine(false); //397:109
                    }
                    bool __tmp61_outputWritten = false;
                    string __tmp62_line = "		return ("; //398:1
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Append(__tmp62_line);
                        __tmp61_outputWritten = true;
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
                                __tmp61_outputWritten = true;
                            }
                            if (!__tmp63_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp64_line = ")symbol;"; //398:53
                    if (!string.IsNullOrEmpty(__tmp64_line))
                    {
                        __out.Append(__tmp64_line);
                        __tmp61_outputWritten = true;
                    }
                    if (__tmp61_outputWritten) __out.AppendLine(true);
                    if (__tmp61_outputWritten)
                    {
                        __out.AppendLine(false); //398:61
                    }
                    __out.Append("	}"); //399:1
                    __out.AppendLine(false); //399:3
                }
            }
            __out.Append("}"); //402:1
            __out.AppendLine(false); //402:2
            __out.AppendLine(true); //403:1
            return __out.ToString();
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //406:1
        {
            StringBuilder __out = new StringBuilder();
            string coreNs = IsCoreModel(model) ? "" : Properties.CoreNs + "."; //407:2
            bool coreModel = IsCoreModel(model); //408:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public static class "; //409:1
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
                __out.AppendLine(false); //409:61
            }
            __out.Append("{"); //410:1
            __out.AppendLine(false); //410:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	private static global::System.Collections.Generic.List<"; //411:1
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
            string __tmp9_line = ".ModelProperty> properties;"; //411:76
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //411:103
            }
            __out.AppendLine(true); //412:1
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	static "; //413:1
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
            string __tmp14_line = "()"; //413:49
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //413:51
            }
            __out.Append("	{"); //414:1
            __out.AppendLine(false); //414:3
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "		properties = new global::System.Collections.Generic.List<"; //415:1
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
            string __tmp19_line = ".ModelProperty>();"; //415:79
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //415:97
            }
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //416:9
                from cls in __Enumerate((__loop21_var1).GetEnumerator()).OfType<MetaClass>() //416:39
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //416:62
                select new { __loop21_var1 = __loop21_var1, cls = cls, prop = prop}
                ).ToList(); //416:4
            for (int __loop21_iteration = 0; __loop21_iteration < __loop21_results.Count; ++__loop21_iteration)
            {
                var __tmp20 = __loop21_results[__loop21_iteration];
                var __loop21_var1 = __tmp20.__loop21_var1;
                var cls = __tmp20.cls;
                var prop = __tmp20.prop;
                bool __tmp22_outputWritten = false;
                string __tmp23_line = "		properties.Add("; //417:1
                if (!string.IsNullOrEmpty(__tmp23_line))
                {
                    __out.Append(__tmp23_line);
                    __tmp22_outputWritten = true;
                }
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(CSharpName(prop, model, PropertyKind.Descriptor, true));
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
                string __tmp25_line = ");"; //417:73
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Append(__tmp25_line);
                    __tmp22_outputWritten = true;
                }
                if (__tmp22_outputWritten) __out.AppendLine(true);
                if (__tmp22_outputWritten)
                {
                    __out.AppendLine(false); //417:75
                }
            }
            __out.Append("	}"); //419:1
            __out.AppendLine(false); //419:3
            __out.AppendLine(true); //420:1
            __out.Append("	public static void Initialize()"); //421:1
            __out.AppendLine(false); //421:33
            __out.Append("	{"); //422:1
            __out.AppendLine(false); //422:3
            __out.Append("	}"); //423:1
            __out.AppendLine(false); //423:3
            __out.AppendLine(true); //424:1
            bool __tmp27_outputWritten = false;
            string __tmp28_line = "	public const string Uri = \""; //425:1
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Append(__tmp28_line);
                __tmp27_outputWritten = true;
            }
            StringBuilder __tmp29 = new StringBuilder();
            __tmp29.Append(model.Uri);
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
            string __tmp30_line = "\";"; //425:40
            if (!string.IsNullOrEmpty(__tmp30_line))
            {
                __out.Append(__tmp30_line);
                __tmp27_outputWritten = true;
            }
            if (__tmp27_outputWritten) __out.AppendLine(true);
            if (__tmp27_outputWritten)
            {
                __out.AppendLine(false); //425:42
            }
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //426:8
                from cls in __Enumerate((__loop22_var1).GetEnumerator()).OfType<MetaClass>() //426:38
                select new { __loop22_var1 = __loop22_var1, cls = cls}
                ).ToList(); //426:3
            for (int __loop22_iteration = 0; __loop22_iteration < __loop22_results.Count; ++__loop22_iteration)
            {
                var __tmp31 = __loop22_results[__loop22_iteration];
                var __loop22_var1 = __tmp31.__loop22_var1;
                var cls = __tmp31.cls;
                __out.AppendLine(true); //427:1
                bool __tmp33_outputWritten = false;
                string __tmp32Prefix = "	"; //428:1
                StringBuilder __tmp34 = new StringBuilder();
                __tmp34.Append(GenerateDescriptorClass(model, cls));
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
                    __out.AppendLine(false); //428:39
                }
            }
            __out.Append("}"); //430:1
            __out.AppendLine(false); //430:2
            return __out.ToString();
        }

        public string GenerateDescriptorClass(MetaModel model, MetaClass cls) //433:1
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
                __out.AppendLine(false); //434:29
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
                __out.AppendLine(false); //435:27
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
            string __tmp10_line = ".ModelSymbolDescriptorAttribute(typeof("; //436:24
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp8_outputWritten = true;
            }
            StringBuilder __tmp11 = new StringBuilder();
            __tmp11.Append(CSharpName(cls, null, ClassKind.Immutable, true));
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
            string __tmp12_line = "), typeof("; //436:112
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Append(__tmp12_line);
                __tmp8_outputWritten = true;
            }
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(CSharpName(cls, null, ClassKind.Builder, true));
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
            string __tmp14_line = ")"; //436:169
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp8_outputWritten = true;
            }
            StringBuilder __tmp15 = new StringBuilder();
            __tmp15.Append(GetDescriptorAncestors(model, cls));
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
            string __tmp16_line = ")"; //436:206
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Append(__tmp16_line);
                __tmp8_outputWritten = true;
            }
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append("]");
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
                    if (!__tmp17_last || __tmp8_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp8_outputWritten)
            {
                __out.AppendLine(false); //436:212
            }
            bool __tmp19_outputWritten = false;
            string __tmp20_line = "public static class "; //437:1
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp19_outputWritten = true;
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
                        __tmp19_outputWritten = true;
                    }
                    if (!__tmp21_last || __tmp19_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp19_outputWritten)
            {
                __out.AppendLine(false); //437:66
            }
            __out.Append("{"); //438:1
            __out.AppendLine(false); //438:2
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	private static "; //439:1
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
            string __tmp26_line = ".ModelSymbolInfo modelSymbolInfo;"; //439:36
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //439:69
            }
            __out.AppendLine(true); //440:1
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "	static "; //441:1
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Append(__tmp29_line);
                __tmp28_outputWritten = true;
            }
            StringBuilder __tmp30 = new StringBuilder();
            __tmp30.Append(CSharpName(cls, model, ClassKind.Descriptor));
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
            string __tmp31_line = "()"; //441:54
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Append(__tmp31_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //441:56
            }
            __out.Append("	{"); //442:1
            __out.AppendLine(false); //442:3
            bool __tmp33_outputWritten = false;
            string __tmp34_line = "		modelSymbolInfo = "; //443:1
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Append(__tmp34_line);
                __tmp33_outputWritten = true;
            }
            StringBuilder __tmp35 = new StringBuilder();
            __tmp35.Append(Properties.CoreNs);
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
            string __tmp36_line = ".ModelSymbolInfo.GetDescriptorSymbolInfo(typeof("; //443:40
            if (!string.IsNullOrEmpty(__tmp36_line))
            {
                __out.Append(__tmp36_line);
                __tmp33_outputWritten = true;
            }
            StringBuilder __tmp37 = new StringBuilder();
            __tmp37.Append(CSharpName(cls, model, ClassKind.Descriptor));
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
                        __tmp33_outputWritten = true;
                    }
                    if (!__tmp37_last) __out.AppendLine(true);
                }
            }
            string __tmp38_line = "));"; //443:133
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Append(__tmp38_line);
                __tmp33_outputWritten = true;
            }
            if (__tmp33_outputWritten) __out.AppendLine(true);
            if (__tmp33_outputWritten)
            {
                __out.AppendLine(false); //443:136
            }
            __out.Append("	}"); //444:1
            __out.AppendLine(false); //444:3
            __out.AppendLine(true); //445:1
            bool __tmp40_outputWritten = false;
            string __tmp41_line = "	public static "; //446:1
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Append(__tmp41_line);
                __tmp40_outputWritten = true;
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
                        __tmp40_outputWritten = true;
                    }
                    if (!__tmp42_last) __out.AppendLine(true);
                }
            }
            string __tmp43_line = ".ModelSymbolInfo SymbolInfo"; //446:35
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Append(__tmp43_line);
                __tmp40_outputWritten = true;
            }
            if (__tmp40_outputWritten) __out.AppendLine(true);
            if (__tmp40_outputWritten)
            {
                __out.AppendLine(false); //446:62
            }
            __out.Append("	{"); //447:1
            __out.AppendLine(false); //447:3
            __out.Append("		get { return modelSymbolInfo; }"); //448:1
            __out.AppendLine(false); //448:34
            __out.Append("	}"); //449:1
            __out.AppendLine(false); //449:3
            __out.AppendLine(true); //450:1
            if (cls.Name == "MetaClass") //451:3
            {
                bool __tmp45_outputWritten = false;
                string __tmp46_line = "	public static "; //452:1
                if (!string.IsNullOrEmpty(__tmp46_line))
                {
                    __out.Append(__tmp46_line);
                    __tmp45_outputWritten = true;
                }
                StringBuilder __tmp47 = new StringBuilder();
                __tmp47.Append(Properties.CoreNs);
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
                string __tmp48_line = ".MetaClass _MetaClass"; //452:35
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Append(__tmp48_line);
                    __tmp45_outputWritten = true;
                }
                if (__tmp45_outputWritten) __out.AppendLine(true);
                if (__tmp45_outputWritten)
                {
                    __out.AppendLine(false); //452:56
                }
            }
            else //453:3
            {
                bool __tmp50_outputWritten = false;
                string __tmp51_line = "	public static "; //454:1
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
                string __tmp53_line = ".MetaClass MetaClass"; //454:35
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp50_outputWritten = true;
                }
                if (__tmp50_outputWritten) __out.AppendLine(true);
                if (__tmp50_outputWritten)
                {
                    __out.AppendLine(false); //454:55
                }
            }
            __out.Append("	{"); //456:1
            __out.AppendLine(false); //456:3
            bool __tmp55_outputWritten = false;
            string __tmp56_line = "		get { return "; //457:1
            if (!string.IsNullOrEmpty(__tmp56_line))
            {
                __out.Append(__tmp56_line);
                __tmp55_outputWritten = true;
            }
            StringBuilder __tmp57 = new StringBuilder();
            __tmp57.Append(CSharpName(cls, null, ClassKind.ImmutableInstance, true));
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
            string __tmp58_line = "; }"; //457:73
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Append(__tmp58_line);
                __tmp55_outputWritten = true;
            }
            if (__tmp55_outputWritten) __out.AppendLine(true);
            if (__tmp55_outputWritten)
            {
                __out.AppendLine(false); //457:76
            }
            __out.Append("	}"); //458:1
            __out.AppendLine(false); //458:3
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((cls).GetEnumerator()) //459:8
                from prop in __Enumerate((__loop23_var1.Properties).GetEnumerator()) //459:13
                select new { __loop23_var1 = __loop23_var1, prop = prop}
                ).ToList(); //459:3
            for (int __loop23_iteration = 0; __loop23_iteration < __loop23_results.Count; ++__loop23_iteration)
            {
                var __tmp59 = __loop23_results[__loop23_iteration];
                var __loop23_var1 = __tmp59.__loop23_var1;
                var prop = __tmp59.prop;
                bool __tmp61_outputWritten = false;
                string __tmp60Prefix = "	"; //460:1
                StringBuilder __tmp62 = new StringBuilder();
                __tmp62.Append(GenerateDescriptorProperty(model, cls, prop));
                using(StreamReader __tmp62Reader = new StreamReader(this.__ToStream(__tmp62.ToString())))
                {
                    bool __tmp62_last = __tmp62Reader.EndOfStream;
                    while(!__tmp62_last)
                    {
                        string __tmp62_line = __tmp62Reader.ReadLine();
                        __tmp62_last = __tmp62Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp60Prefix))
                        {
                            __out.Append(__tmp60Prefix);
                            __tmp61_outputWritten = true;
                        }
                        if ((__tmp62_last && !string.IsNullOrEmpty(__tmp62_line)) || (!__tmp62_last && __tmp62_line != null))
                        {
                            __out.Append(__tmp62_line);
                            __tmp61_outputWritten = true;
                        }
                        if (!__tmp62_last || __tmp61_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp61_outputWritten)
                {
                    __out.AppendLine(false); //460:48
                }
            }
            __out.Append("}"); //462:1
            __out.AppendLine(false); //462:2
            return __out.ToString();
        }

        public string GetDescriptorAncestors(MetaModel model, MetaClass cls) //465:1
        {
            string result = ""; //466:2
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //467:7
                from super in __Enumerate((__loop24_var1.SuperClasses).GetEnumerator()) //467:12
                select new { __loop24_var1 = __loop24_var1, super = super}
                ).ToList(); //467:2
            for (int __loop24_iteration = 0; __loop24_iteration < __loop24_results.Count; ++__loop24_iteration)
            {
                string delim; //467:30
                if (__loop24_iteration+1 < __loop24_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop24_results[__loop24_iteration];
                var __loop24_var1 = __tmp1.__loop24_var1;
                var super = __tmp1.super;
                result += "typeof(" + CSharpName(super, model, ClassKind.Descriptor, true) + ")" + delim; //468:3
            }
            if (result.Length > 0) //470:2
            {
                result = ", BaseSymbolDescriptors = new global::System.Type[] { " + result + " }"; //471:3
            }
            return result; //473:2
        }

        public string GenerateDescriptorProperty(MetaModel model, MetaClass cls, MetaProperty prop) //476:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //477:1
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
                __out.AppendLine(false); //478:30
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
                __out.AppendLine(false); //479:28
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
                __out.AppendLine(false); //480:58
            }
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "public static readonly "; //481:1
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
            string __tmp14_line = ".ModelProperty "; //481:43
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
            string __tmp16_line = " ="; //481:107
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Append(__tmp16_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //481:109
            }
            bool __tmp18_outputWritten = false;
            string __tmp17Prefix = "    "; //482:1
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
            string __tmp20_line = ".ModelProperty.Register(typeof("; //482:24
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
            string __tmp22_line = "), \""; //482:100
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
            string __tmp24_line = "\","; //482:128
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //482:130
            }
            if (prop.Type is MetaCollectionType) //483:2
            {
                MetaCollectionType collType = (MetaCollectionType)prop.Type; //484:3
                bool __tmp26_outputWritten = false;
                string __tmp27_line = "        new "; //485:1
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
                string __tmp29_line = ".ModelPropertyTypeInfo(typeof("; //485:32
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
                string __tmp31_line = "), typeof("; //485:126
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
                string __tmp33_line = ")),"; //485:191
                if (!string.IsNullOrEmpty(__tmp33_line))
                {
                    __out.Append(__tmp33_line);
                    __tmp26_outputWritten = true;
                }
                if (__tmp26_outputWritten) __out.AppendLine(true);
                if (__tmp26_outputWritten)
                {
                    __out.AppendLine(false); //485:194
                }
                bool __tmp35_outputWritten = false;
                string __tmp36_line = "        new "; //486:1
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
                string __tmp38_line = ".ModelPropertyTypeInfo(typeof("; //486:32
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
                string __tmp40_line = "), typeof("; //486:124
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
                string __tmp42_line = ")),"; //486:187
                if (!string.IsNullOrEmpty(__tmp42_line))
                {
                    __out.Append(__tmp42_line);
                    __tmp35_outputWritten = true;
                }
                if (__tmp35_outputWritten) __out.AppendLine(true);
                if (__tmp35_outputWritten)
                {
                    __out.AppendLine(false); //486:190
                }
            }
            else //487:2
            {
                bool __tmp44_outputWritten = false;
                string __tmp45_line = "        new "; //488:1
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
                string __tmp47_line = ".ModelPropertyTypeInfo(typeof("; //488:32
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
                string __tmp49_line = "), null),"; //488:117
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Append(__tmp49_line);
                    __tmp44_outputWritten = true;
                }
                if (__tmp44_outputWritten) __out.AppendLine(true);
                if (__tmp44_outputWritten)
                {
                    __out.AppendLine(false); //488:126
                }
                bool __tmp51_outputWritten = false;
                string __tmp52_line = "        new "; //489:1
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
                string __tmp54_line = ".ModelPropertyTypeInfo(typeof("; //489:32
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
                string __tmp56_line = "), null),"; //489:115
                if (!string.IsNullOrEmpty(__tmp56_line))
                {
                    __out.Append(__tmp56_line);
                    __tmp51_outputWritten = true;
                }
                if (__tmp51_outputWritten) __out.AppendLine(true);
                if (__tmp51_outputWritten)
                {
                    __out.AppendLine(false); //489:124
                }
            }
            bool __tmp58_outputWritten = false;
            string __tmp59_line = "		() => "; //491:1
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
            string __tmp61_line = ");"; //491:70
            if (!string.IsNullOrEmpty(__tmp61_line))
            {
                __out.Append(__tmp61_line);
                __tmp58_outputWritten = true;
            }
            if (__tmp58_outputWritten) __out.AppendLine(true);
            if (__tmp58_outputWritten)
            {
                __out.AppendLine(false); //491:72
            }
            return __out.ToString();
        }

        public string GenerateDescriptorPropertyAnnotations(MetaModel model, MetaClass cls, MetaProperty prop) //494:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Kind == MetaPropertyKind.Containment) //495:2
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
                    __out.AppendLine(false); //496:49
                }
            }
            if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //498:2
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
                    __out.AppendLine(false); //499:46
                }
            }
            var __loop25_results = 
                (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //501:7
                select new { p = p}
                ).ToList(); //501:2
            for (int __loop25_iteration = 0; __loop25_iteration < __loop25_results.Count; ++__loop25_iteration)
            {
                var __tmp7 = __loop25_results[__loop25_iteration];
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
                    __out.AppendLine(false); //502:146
                }
            }
            var __loop26_results = 
                (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //504:7
                select new { p = p}
                ).ToList(); //504:2
            for (int __loop26_iteration = 0; __loop26_iteration < __loop26_results.Count; ++__loop26_iteration)
            {
                var __tmp15 = __loop26_results[__loop26_iteration];
                var p = __tmp15.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //505:3
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
                        __out.AppendLine(false); //506:145
                    }
                }
                else //507:3
                {
                    bool __tmp24_outputWritten = false;
                    string __tmp25_line = "// ERROR: subsetted property '"; //508:1
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
                    string __tmp27_line = "' must be a property of this class or an ancestor class"; //508:83
                    if (!string.IsNullOrEmpty(__tmp27_line))
                    {
                        __out.Append(__tmp27_line);
                        __tmp24_outputWritten = true;
                    }
                    if (__tmp24_outputWritten) __out.AppendLine(true);
                    if (__tmp24_outputWritten)
                    {
                        __out.AppendLine(false); //508:138
                    }
                }
            }
            var __loop27_results = 
                (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //511:7
                select new { p = p}
                ).ToList(); //511:2
            for (int __loop27_iteration = 0; __loop27_iteration < __loop27_results.Count; ++__loop27_iteration)
            {
                var __tmp28 = __loop27_results[__loop27_iteration];
                var p = __tmp28.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //512:3
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
                        __out.AppendLine(false); //513:147
                    }
                }
                else //514:3
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "// ERROR: redefined property '"; //515:1
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
                    string __tmp40_line = "' must be a property of this class or an ancestor class"; //515:83
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Append(__tmp40_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //515:138
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //520:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //521:1
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
                __out.AppendLine(false); //521:68
            }
            __out.Append("{"); //522:1
            __out.AppendLine(false); //522:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	// If there is a compile error at this line, create a new class called "; //523:1
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
                __out.AppendLine(false); //523:117
            }
            bool __tmp10_outputWritten = false;
            string __tmp11_line = "	// which is a subclass of "; //524:1
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
            string __tmp13_line = ":"; //524:82
            if (!string.IsNullOrEmpty(__tmp13_line))
            {
                __out.Append(__tmp13_line);
                __tmp10_outputWritten = true;
            }
            if (__tmp10_outputWritten) __out.AppendLine(true);
            if (__tmp10_outputWritten)
            {
                __out.AppendLine(false); //524:83
            }
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "	private static "; //525:1
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
            string __tmp18_line = " implementation = new "; //525:61
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
            string __tmp20_line = "();"; //525:127
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //525:130
            }
            __out.AppendLine(true); //526:1
            bool __tmp22_outputWritten = false;
            string __tmp23_line = "	public static "; //527:1
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
            string __tmp25_line = " Implementation"; //527:60
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Append(__tmp25_line);
                __tmp22_outputWritten = true;
            }
            if (__tmp22_outputWritten) __out.AppendLine(true);
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //527:75
            }
            __out.Append("	{"); //528:1
            __out.AppendLine(false); //528:3
            __out.Append("		get { return implementation; }"); //529:1
            __out.AppendLine(false); //529:33
            __out.Append("	}"); //530:1
            __out.AppendLine(false); //530:3
            __out.Append("}"); //531:1
            __out.AppendLine(false); //531:2
            return __out.ToString();
        }

        public string GenerateImplementationBase(MetaModel model) //534:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //535:1
            __out.AppendLine(false); //535:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //536:1
            __out.AppendLine(false); //536:68
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "/// This class has to be be overriden in "; //537:1
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
            string __tmp5_line = " to provide custom"; //537:92
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Append(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //537:110
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //538:1
            __out.AppendLine(false); //538:73
            __out.Append("/// </summary>"); //539:1
            __out.AppendLine(false); //539:15
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "internal abstract class "; //540:1
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
                __out.AppendLine(false); //540:73
            }
            __out.Append("{"); //541:1
            __out.AppendLine(false); //541:2
            __out.Append("	/// <summary>"); //542:1
            __out.AppendLine(false); //542:15
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	/// Implements the constructor: "; //543:1
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
            string __tmp14_line = "()"; //543:79
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //543:81
            }
            __out.Append("	/// </summary>"); //544:1
            __out.AppendLine(false); //544:16
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	internal virtual void "; //545:1
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
            string __tmp19_line = "("; //545:69
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
            string __tmp21_line = " _this)"; //545:115
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //545:122
            }
            __out.Append("	{"); //546:1
            __out.AppendLine(false); //546:3
            __out.Append("	}"); //547:1
            __out.AppendLine(false); //547:3
            var __loop28_results = 
                (from __loop28_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //548:8
                from cls in __Enumerate((__loop28_var1).GetEnumerator()).OfType<MetaClass>() //548:38
                select new { __loop28_var1 = __loop28_var1, cls = cls}
                ).ToList(); //548:3
            for (int __loop28_iteration = 0; __loop28_iteration < __loop28_results.Count; ++__loop28_iteration)
            {
                var __tmp22 = __loop28_results[__loop28_iteration];
                var __loop28_var1 = __tmp22.__loop28_var1;
                var cls = __tmp22.cls;
                __out.AppendLine(true); //549:1
                __out.Append("	/// <summary>"); //550:1
                __out.AppendLine(false); //550:15
                bool __tmp24_outputWritten = false;
                string __tmp25_line = "	/// Implements the constructor: "; //551:1
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
                string __tmp27_line = "()"; //551:78
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Append(__tmp27_line);
                    __tmp24_outputWritten = true;
                }
                if (__tmp24_outputWritten) __out.AppendLine(true);
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //551:80
                }
                __out.Append("	/// </summary>"); //552:1
                __out.AppendLine(false); //552:16
                if ((from __loop29_var1 in __Enumerate((cls).GetEnumerator()) //553:15
                from sup in __Enumerate((__loop29_var1.SuperClasses).GetEnumerator()) //553:20
                select new { __loop29_var1 = __loop29_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //553:3
                {
                    __out.Append("	/// Direct superclasses: "); //554:1
                    __out.AppendLine(false); //554:27
                    __out.Append("	/// <ul>"); //555:1
                    __out.AppendLine(false); //555:10
                    var __loop30_results = 
                        (from __loop30_var1 in __Enumerate((cls).GetEnumerator()) //556:8
                        from sup in __Enumerate((__loop30_var1.SuperClasses).GetEnumerator()) //556:13
                        select new { __loop30_var1 = __loop30_var1, sup = sup}
                        ).ToList(); //556:3
                    for (int __loop30_iteration = 0; __loop30_iteration < __loop30_results.Count; ++__loop30_iteration)
                    {
                        var __tmp28 = __loop30_results[__loop30_iteration];
                        var __loop30_var1 = __tmp28.__loop30_var1;
                        var sup = __tmp28.sup;
                        bool __tmp30_outputWritten = false;
                        string __tmp31_line = "	///     <li>"; //557:1
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
                        string __tmp33_line = "</li>"; //557:64
                        if (!string.IsNullOrEmpty(__tmp33_line))
                        {
                            __out.Append(__tmp33_line);
                            __tmp30_outputWritten = true;
                        }
                        if (__tmp30_outputWritten) __out.AppendLine(true);
                        if (__tmp30_outputWritten)
                        {
                            __out.AppendLine(false); //557:69
                        }
                    }
                    __out.Append("	/// </ul>"); //559:1
                    __out.AppendLine(false); //559:11
                    __out.Append("	/// All superclasses:"); //560:1
                    __out.AppendLine(false); //560:23
                    __out.Append("	/// <ul>"); //561:1
                    __out.AppendLine(false); //561:10
                    var __loop31_results = 
                        (from __loop31_var1 in __Enumerate((cls).GetEnumerator()) //562:8
                        from sup in __Enumerate((__loop31_var1.GetAllSuperClasses(false)).GetEnumerator()) //562:13
                        select new { __loop31_var1 = __loop31_var1, sup = sup}
                        ).ToList(); //562:3
                    for (int __loop31_iteration = 0; __loop31_iteration < __loop31_results.Count; ++__loop31_iteration)
                    {
                        var __tmp34 = __loop31_results[__loop31_iteration];
                        var __loop31_var1 = __tmp34.__loop31_var1;
                        var sup = __tmp34.sup;
                        bool __tmp36_outputWritten = false;
                        string __tmp37_line = "	///     <li>"; //563:1
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
                        string __tmp39_line = "</li>"; //563:64
                        if (!string.IsNullOrEmpty(__tmp39_line))
                        {
                            __out.Append(__tmp39_line);
                            __tmp36_outputWritten = true;
                        }
                        if (__tmp36_outputWritten) __out.AppendLine(true);
                        if (__tmp36_outputWritten)
                        {
                            __out.AppendLine(false); //563:69
                        }
                    }
                    __out.Append("	/// </ul>"); //565:1
                    __out.AppendLine(false); //565:11
                }
                if ((from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //567:15
                from prop in __Enumerate((__loop32_var1.Properties).GetEnumerator()) //567:20
                where prop.Kind == MetaPropertyKind.Readonly //567:36
                select new { __loop32_var1 = __loop32_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //567:3
                {
                    __out.Append("	/// Initializes the following readonly properties:"); //568:1
                    __out.AppendLine(false); //568:52
                    __out.Append("	/// <ul>"); //569:1
                    __out.AppendLine(false); //569:10
                    var __loop33_results = 
                        (from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //570:8
                        from prop in __Enumerate((__loop33_var1.Properties).GetEnumerator()) //570:13
                        where prop.Kind == MetaPropertyKind.Readonly //570:29
                        select new { __loop33_var1 = __loop33_var1, prop = prop}
                        ).ToList(); //570:3
                    for (int __loop33_iteration = 0; __loop33_iteration < __loop33_results.Count; ++__loop33_iteration)
                    {
                        var __tmp40 = __loop33_results[__loop33_iteration];
                        var __loop33_var1 = __tmp40.__loop33_var1;
                        var prop = __tmp40.prop;
                        bool __tmp42_outputWritten = false;
                        string __tmp43_line = "	///     <li>"; //571:1
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
                        string __tmp45_line = "</li>"; //571:38
                        if (!string.IsNullOrEmpty(__tmp45_line))
                        {
                            __out.Append(__tmp45_line);
                            __tmp42_outputWritten = true;
                        }
                        if (__tmp42_outputWritten) __out.AppendLine(true);
                        if (__tmp42_outputWritten)
                        {
                            __out.AppendLine(false); //571:43
                        }
                    }
                    __out.Append("	/// </ul>"); //573:1
                    __out.AppendLine(false); //573:11
                }
                if ((from __loop34_var1 in __Enumerate((cls).GetEnumerator()) //575:15
                from prop in __Enumerate((__loop34_var1.Properties).GetEnumerator()) //575:20
                where prop.Kind == MetaPropertyKind.Lazy //575:36
                select new { __loop34_var1 = __loop34_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //575:3
                {
                    __out.Append("	/// Initializes the following lazy properties:"); //576:1
                    __out.AppendLine(false); //576:48
                    __out.Append("	/// <ul>"); //577:1
                    __out.AppendLine(false); //577:10
                    var __loop35_results = 
                        (from __loop35_var1 in __Enumerate((cls).GetEnumerator()) //578:8
                        from prop in __Enumerate((__loop35_var1.Properties).GetEnumerator()) //578:13
                        where prop.Kind == MetaPropertyKind.Lazy //578:29
                        select new { __loop35_var1 = __loop35_var1, prop = prop}
                        ).ToList(); //578:3
                    for (int __loop35_iteration = 0; __loop35_iteration < __loop35_results.Count; ++__loop35_iteration)
                    {
                        var __tmp46 = __loop35_results[__loop35_iteration];
                        var __loop35_var1 = __tmp46.__loop35_var1;
                        var prop = __tmp46.prop;
                        bool __tmp48_outputWritten = false;
                        string __tmp49_line = "	///     <li>"; //579:1
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
                        string __tmp51_line = "</li>"; //579:38
                        if (!string.IsNullOrEmpty(__tmp51_line))
                        {
                            __out.Append(__tmp51_line);
                            __tmp48_outputWritten = true;
                        }
                        if (__tmp48_outputWritten) __out.AppendLine(true);
                        if (__tmp48_outputWritten)
                        {
                            __out.AppendLine(false); //579:43
                        }
                    }
                    __out.Append("	/// </ul>"); //581:1
                    __out.AppendLine(false); //581:11
                }
                if ((from __loop36_var1 in __Enumerate((cls).GetEnumerator()) //583:15
                from prop in __Enumerate((__loop36_var1.Properties).GetEnumerator()) //583:20
                where prop.Kind == MetaPropertyKind.Derived //583:36
                select new { __loop36_var1 = __loop36_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //583:3
                {
                    __out.Append("	/// Initializes the following derived properties:"); //584:1
                    __out.AppendLine(false); //584:51
                    __out.Append("	/// <ul>"); //585:1
                    __out.AppendLine(false); //585:10
                    var __loop37_results = 
                        (from __loop37_var1 in __Enumerate((cls).GetEnumerator()) //586:8
                        from prop in __Enumerate((__loop37_var1.Properties).GetEnumerator()) //586:13
                        where prop.Kind == MetaPropertyKind.Derived //586:29
                        select new { __loop37_var1 = __loop37_var1, prop = prop}
                        ).ToList(); //586:3
                    for (int __loop37_iteration = 0; __loop37_iteration < __loop37_results.Count; ++__loop37_iteration)
                    {
                        var __tmp52 = __loop37_results[__loop37_iteration];
                        var __loop37_var1 = __tmp52.__loop37_var1;
                        var prop = __tmp52.prop;
                        bool __tmp54_outputWritten = false;
                        string __tmp55_line = "	///     <li>"; //587:1
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
                        string __tmp57_line = "</li>"; //587:38
                        if (!string.IsNullOrEmpty(__tmp57_line))
                        {
                            __out.Append(__tmp57_line);
                            __tmp54_outputWritten = true;
                        }
                        if (__tmp54_outputWritten) __out.AppendLine(true);
                        if (__tmp54_outputWritten)
                        {
                            __out.AppendLine(false); //587:43
                        }
                    }
                    __out.Append("	/// </ul>"); //589:1
                    __out.AppendLine(false); //589:11
                }
                bool __tmp59_outputWritten = false;
                string __tmp60_line = "	public virtual void "; //591:1
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
                string __tmp62_line = "("; //591:66
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
                string __tmp64_line = " _this)"; //591:109
                if (!string.IsNullOrEmpty(__tmp64_line))
                {
                    __out.Append(__tmp64_line);
                    __tmp59_outputWritten = true;
                }
                if (__tmp59_outputWritten) __out.AppendLine(true);
                if (__tmp59_outputWritten)
                {
                    __out.AppendLine(false); //591:116
                }
                __out.Append("	{"); //592:1
                __out.AppendLine(false); //592:3
                bool __tmp66_outputWritten = false;
                string __tmp67_line = "		this.Call"; //593:1
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
                string __tmp69_line = "SuperConstructors(_this);"; //593:56
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Append(__tmp69_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //593:81
                }
                __out.Append("	}"); //594:1
                __out.AppendLine(false); //594:3
                __out.AppendLine(true); //595:1
                __out.Append("	/// <summary>"); //596:1
                __out.AppendLine(false); //596:15
                bool __tmp71_outputWritten = false;
                string __tmp72_line = "	/// Calls the super constructors of "; //597:1
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
                    __out.AppendLine(false); //597:82
                }
                __out.Append("	/// </summary>"); //598:1
                __out.AppendLine(false); //598:16
                bool __tmp75_outputWritten = false;
                string __tmp76_line = "	protected virtual void Call"; //599:1
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
                string __tmp78_line = "SuperConstructors("; //599:73
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
                string __tmp80_line = " _this)"; //599:133
                if (!string.IsNullOrEmpty(__tmp80_line))
                {
                    __out.Append(__tmp80_line);
                    __tmp75_outputWritten = true;
                }
                if (__tmp75_outputWritten) __out.AppendLine(true);
                if (__tmp75_outputWritten)
                {
                    __out.AppendLine(false); //599:140
                }
                __out.Append("	{"); //600:1
                __out.AppendLine(false); //600:3
                var __loop38_results = 
                    (from __loop38_var1 in __Enumerate((cls).GetEnumerator()) //601:8
                    from sup in __Enumerate((__loop38_var1.GetAllSuperClasses(false)).GetEnumerator()) //601:13
                    select new { __loop38_var1 = __loop38_var1, sup = sup}
                    ).ToList(); //601:3
                for (int __loop38_iteration = 0; __loop38_iteration < __loop38_results.Count; ++__loop38_iteration)
                {
                    var __tmp81 = __loop38_results[__loop38_iteration];
                    var __loop38_var1 = __tmp81.__loop38_var1;
                    var sup = __tmp81.sup;
                    if (model.Namespace.Declarations.Contains(sup)) //602:4
                    {
                        bool __tmp83_outputWritten = false;
                        string __tmp84_line = "		this."; //603:1
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
                        string __tmp86_line = "(_this);"; //603:52
                        if (!string.IsNullOrEmpty(__tmp86_line))
                        {
                            __out.Append(__tmp86_line);
                            __tmp83_outputWritten = true;
                        }
                        if (__tmp83_outputWritten) __out.AppendLine(true);
                        if (__tmp83_outputWritten)
                        {
                            __out.AppendLine(false); //603:60
                        }
                    }
                    else //604:4
                    {
                        bool __tmp88_outputWritten = false;
                        string __tmp87Prefix = "		"; //605:1
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
                        string __tmp90_line = "."; //605:69
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
                        string __tmp92_line = "(_this);"; //605:114
                        if (!string.IsNullOrEmpty(__tmp92_line))
                        {
                            __out.Append(__tmp92_line);
                            __tmp88_outputWritten = true;
                        }
                        if (__tmp88_outputWritten) __out.AppendLine(true);
                        if (__tmp88_outputWritten)
                        {
                            __out.AppendLine(false); //605:122
                        }
                    }
                }
                __out.Append("	}"); //608:1
                __out.AppendLine(false); //608:3
                var __loop39_results = 
                    (from __loop39_var1 in __Enumerate((cls).GetEnumerator()) //609:8
                    from op in __Enumerate((__loop39_var1.Operations).GetEnumerator()) //609:13
                    select new { __loop39_var1 = __loop39_var1, op = op}
                    ).ToList(); //609:3
                for (int __loop39_iteration = 0; __loop39_iteration < __loop39_results.Count; ++__loop39_iteration)
                {
                    var __tmp93 = __loop39_results[__loop39_iteration];
                    var __loop39_var1 = __tmp93.__loop39_var1;
                    var op = __tmp93.op;
                    __out.AppendLine(true); //610:2
                    __out.Append("	/// <summary>"); //611:1
                    __out.AppendLine(false); //611:15
                    bool __tmp95_outputWritten = false;
                    string __tmp96_line = "	/// Implements the operation: "; //612:1
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
                    string __tmp98_line = "."; //612:76
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
                    string __tmp100_line = "()"; //612:86
                    if (!string.IsNullOrEmpty(__tmp100_line))
                    {
                        __out.Append(__tmp100_line);
                        __tmp95_outputWritten = true;
                    }
                    if (__tmp95_outputWritten) __out.AppendLine(true);
                    if (__tmp95_outputWritten)
                    {
                        __out.AppendLine(false); //612:88
                    }
                    __out.Append("	/// </summary>"); //613:1
                    __out.AppendLine(false); //613:16
                    bool __tmp102_outputWritten = false;
                    string __tmp103_line = "	public virtual "; //614:1
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
                    string __tmp105_line = " "; //614:77
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
                    string __tmp107_line = "_"; //614:122
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
                    string __tmp109_line = "("; //614:132
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
                    string __tmp111_line = ")"; //614:168
                    if (!string.IsNullOrEmpty(__tmp111_line))
                    {
                        __out.Append(__tmp111_line);
                        __tmp102_outputWritten = true;
                    }
                    if (__tmp102_outputWritten) __out.AppendLine(true);
                    if (__tmp102_outputWritten)
                    {
                        __out.AppendLine(false); //614:169
                    }
                    __out.Append("	{"); //615:1
                    __out.AppendLine(false); //615:3
                    __out.Append("		throw new NotImplementedException();"); //616:1
                    __out.AppendLine(false); //616:39
                    __out.Append("	}"); //617:1
                    __out.AppendLine(false); //617:3
                }
                __out.AppendLine(true); //619:2
            }
            var __loop40_results = 
                (from __loop40_var1 in __Enumerate((model).GetEnumerator()) //621:8
                from Namespace in __Enumerate((__loop40_var1.Namespace).GetEnumerator()) //621:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //621:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //621:40
                select new { __loop40_var1 = __loop40_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //621:3
            for (int __loop40_iteration = 0; __loop40_iteration < __loop40_results.Count; ++__loop40_iteration)
            {
                var __tmp112 = __loop40_results[__loop40_iteration];
                var __loop40_var1 = __tmp112.__loop40_var1;
                var Namespace = __tmp112.Namespace;
                var Declarations = __tmp112.Declarations;
                var enm = __tmp112.enm;
                var __loop41_results = 
                    (from __loop41_var1 in __Enumerate((enm).GetEnumerator()) //622:8
                    from op in __Enumerate((__loop41_var1.Operations).GetEnumerator()) //622:13
                    select new { __loop41_var1 = __loop41_var1, op = op}
                    ).ToList(); //622:3
                for (int __loop41_iteration = 0; __loop41_iteration < __loop41_results.Count; ++__loop41_iteration)
                {
                    var __tmp113 = __loop41_results[__loop41_iteration];
                    var __loop41_var1 = __tmp113.__loop41_var1;
                    var op = __tmp113.op;
                    __out.AppendLine(true); //623:2
                    __out.Append("	/// <summary>"); //624:1
                    __out.AppendLine(false); //624:15
                    bool __tmp115_outputWritten = false;
                    string __tmp116_line = "	/// Implements the operation: "; //625:1
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
                    string __tmp118_line = "."; //625:76
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
                        __out.AppendLine(false); //625:86
                    }
                    __out.Append("	/// </summary>"); //626:1
                    __out.AppendLine(false); //626:16
                    bool __tmp121_outputWritten = false;
                    string __tmp122_line = "	public virtual "; //627:1
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
                    string __tmp124_line = " "; //627:77
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
                    string __tmp126_line = "_"; //627:122
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
                    string __tmp128_line = "("; //627:132
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
                    string __tmp130_line = ")"; //627:168
                    if (!string.IsNullOrEmpty(__tmp130_line))
                    {
                        __out.Append(__tmp130_line);
                        __tmp121_outputWritten = true;
                    }
                    if (__tmp121_outputWritten) __out.AppendLine(true);
                    if (__tmp121_outputWritten)
                    {
                        __out.AppendLine(false); //627:169
                    }
                    __out.Append("	{"); //628:1
                    __out.AppendLine(false); //628:3
                    __out.Append("		throw new NotImplementedException();"); //629:1
                    __out.AppendLine(false); //629:39
                    __out.Append("	}"); //630:1
                    __out.AppendLine(false); //630:3
                }
                __out.AppendLine(true); //632:2
            }
            __out.Append("}"); //634:1
            __out.AppendLine(false); //634:2
            return __out.ToString();
        }

        public string GetImplParameters(MetaModel model, MetaClass cls, MetaOperation op) //637:1
        {
            string result = CSharpName(cls, model, ClassKind.Immutable) + " _this"; //638:2
            string delim = ", "; //639:2
            var __loop42_results = 
                (from __loop42_var1 in __Enumerate((op).GetEnumerator()) //640:7
                from param in __Enumerate((__loop42_var1.Parameters).GetEnumerator()) //640:11
                select new { __loop42_var1 = __loop42_var1, param = param}
                ).ToList(); //640:2
            for (int __loop42_iteration = 0; __loop42_iteration < __loop42_results.Count; ++__loop42_iteration)
            {
                var __tmp1 = __loop42_results[__loop42_iteration];
                var __loop42_var1 = __tmp1.__loop42_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, ClassKind.Immutable, true) + " " + param.Name; //641:3
            }
            return result; //643:2
        }

        public string GetImplParameters(MetaModel model, MetaEnum enm, MetaOperation op) //646:1
        {
            string result = CSharpName(enm, model, ClassKind.Immutable) + " _this"; //647:2
            string delim = ", "; //648:2
            var __loop43_results = 
                (from __loop43_var1 in __Enumerate((op).GetEnumerator()) //649:7
                from param in __Enumerate((__loop43_var1.Parameters).GetEnumerator()) //649:11
                select new { __loop43_var1 = __loop43_var1, param = param}
                ).ToList(); //649:2
            for (int __loop43_iteration = 0; __loop43_iteration < __loop43_results.Count; ++__loop43_iteration)
            {
                var __tmp1 = __loop43_results[__loop43_iteration];
                var __loop43_var1 = __tmp1.__loop43_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, ClassKind.Immutable, true) + " " + param.Name; //650:3
            }
            return result; //652:2
        }

        public string GenerateEnum(MetaModel model, MetaEnum enm) //656:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //657:1
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
                __out.AppendLine(false); //658:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public enum "; //659:1
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
                __out.AppendLine(false); //659:36
            }
            __out.Append("{"); //660:1
            __out.AppendLine(false); //660:2
            var __loop44_results = 
                (from __loop44_var1 in __Enumerate((enm).GetEnumerator()) //661:8
                from value in __Enumerate((__loop44_var1.EnumLiterals).GetEnumerator()) //661:13
                select new { __loop44_var1 = __loop44_var1, value = value}
                ).ToList(); //661:3
            for (int __loop44_iteration = 0; __loop44_iteration < __loop44_results.Count; ++__loop44_iteration)
            {
                string delim; //661:31
                if (__loop44_iteration+1 < __loop44_results.Count) delim = ",";
                else delim = string.Empty;
                var __tmp8 = __loop44_results[__loop44_iteration];
                var __loop44_var1 = __tmp8.__loop44_var1;
                var value = __tmp8.value;
                bool __tmp10_outputWritten = false;
                string __tmp9Prefix = "	"; //662:1
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
                    __out.AppendLine(false); //662:32
                }
                bool __tmp13_outputWritten = false;
                string __tmp12Prefix = "	"; //663:1
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
                    __out.AppendLine(false); //663:21
                }
            }
            __out.Append("}"); //665:1
            __out.AppendLine(false); //665:2
            __out.AppendLine(true); //666:1
            bool __tmp17_outputWritten = false;
            string __tmp18_line = "public static class "; //667:1
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
            string __tmp20_line = "Extensions"; //667:31
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp17_outputWritten = true;
            }
            if (__tmp17_outputWritten) __out.AppendLine(true);
            if (__tmp17_outputWritten)
            {
                __out.AppendLine(false); //667:41
            }
            __out.Append("{"); //668:1
            __out.AppendLine(false); //668:2
            var __loop45_results = 
                (from __loop45_var1 in __Enumerate((enm).GetEnumerator()) //669:8
                from op in __Enumerate((__loop45_var1.Operations).GetEnumerator()) //669:13
                select new { __loop45_var1 = __loop45_var1, op = op}
                ).ToList(); //669:3
            for (int __loop45_iteration = 0; __loop45_iteration < __loop45_results.Count; ++__loop45_iteration)
            {
                var __tmp21 = __loop45_results[__loop45_iteration];
                var __loop45_var1 = __tmp21.__loop45_var1;
                var op = __tmp21.op;
                bool __tmp23_outputWritten = false;
                string __tmp24_line = "	public static "; //670:1
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
                string __tmp26_line = " "; //670:70
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
                string __tmp28_line = "("; //670:80
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
                string __tmp30_line = ")"; //670:120
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Append(__tmp30_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //670:121
                }
                __out.Append("	{"); //671:1
                __out.AppendLine(false); //671:3
                bool __tmp32_outputWritten = false;
                string __tmp31Prefix = "		"; //672:1
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
                string __tmp35_line = ".Implementation."; //672:77
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
                string __tmp37_line = "_"; //672:143
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
                string __tmp39_line = "("; //672:153
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
                string __tmp41_line = ");"; //672:196
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Append(__tmp41_line);
                    __tmp32_outputWritten = true;
                }
                if (__tmp32_outputWritten) __out.AppendLine(true);
                if (__tmp32_outputWritten)
                {
                    __out.AppendLine(false); //672:198
                }
                __out.Append("	}"); //673:1
                __out.AppendLine(false); //673:3
            }
            __out.Append("}"); //675:1
            __out.AppendLine(false); //675:2
            return __out.ToString();
        }

        public string GetEnumImplParameters(MetaModel model, MetaEnum enm, MetaOperation op) //678:1
        {
            string result = "this " + CSharpName(enm, model, ClassKind.Immutable) + " _this"; //679:2
            string delim = ", "; //680:2
            var __loop46_results = 
                (from __loop46_var1 in __Enumerate((op).GetEnumerator()) //681:7
                from param in __Enumerate((__loop46_var1.Parameters).GetEnumerator()) //681:11
                select new { __loop46_var1 = __loop46_var1, param = param}
                ).ToList(); //681:2
            for (int __loop46_iteration = 0; __loop46_iteration < __loop46_results.Count; ++__loop46_iteration)
            {
                var __tmp1 = __loop46_results[__loop46_iteration];
                var __loop46_var1 = __tmp1.__loop46_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, ClassKind.Immutable) + " " + param.Name; //682:3
            }
            return result; //684:2
        }

        public string GetEnumImplCallParameterNames(MetaModel model, MetaOperation op) //687:1
        {
            string result = "_this"; //688:2
            string delim = ", "; //689:2
            var __loop47_results = 
                (from __loop47_var1 in __Enumerate((op).GetEnumerator()) //690:7
                from param in __Enumerate((__loop47_var1.Parameters).GetEnumerator()) //690:11
                select new { __loop47_var1 = __loop47_var1, param = param}
                ).ToList(); //690:2
            for (int __loop47_iteration = 0; __loop47_iteration < __loop47_results.Count; ++__loop47_iteration)
            {
                var __tmp1 = __loop47_results[__loop47_iteration];
                var __loop47_var1 = __tmp1.__loop47_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //691:3
            }
            return result; //693:2
        }

        public string GetClassParameters(MetaModel model, MetaClass cls, MetaOperation op) //696:1
        {
            string result = ""; //697:2
            var __loop48_results = 
                (from __loop48_var1 in __Enumerate((op).GetEnumerator()) //698:7
                from param in __Enumerate((__loop48_var1.Parameters).GetEnumerator()) //698:11
                select new { __loop48_var1 = __loop48_var1, param = param}
                ).ToList(); //698:2
            for (int __loop48_iteration = 0; __loop48_iteration < __loop48_results.Count; ++__loop48_iteration)
            {
                string delim; //698:27
                if (__loop48_iteration+1 < __loop48_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop48_results[__loop48_iteration];
                var __loop48_var1 = __tmp1.__loop48_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, ClassKind.Immutable) + " " + param.Name + delim; //699:3
            }
            return result; //701:2
        }

        public string GetClassImplParameters(MetaModel model, MetaClass cls, MetaOperation op) //704:1
        {
            string result = CSharpName(cls, model, ClassKind.Immutable) + " _this"; //705:2
            string delim = ", "; //706:2
            var __loop49_results = 
                (from __loop49_var1 in __Enumerate((op).GetEnumerator()) //707:7
                from param in __Enumerate((__loop49_var1.Parameters).GetEnumerator()) //707:11
                select new { __loop49_var1 = __loop49_var1, param = param}
                ).ToList(); //707:2
            for (int __loop49_iteration = 0; __loop49_iteration < __loop49_results.Count; ++__loop49_iteration)
            {
                var __tmp1 = __loop49_results[__loop49_iteration];
                var __loop49_var1 = __tmp1.__loop49_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, ClassKind.Immutable) + " " + param.Name; //708:3
            }
            return result; //710:2
        }

        public string GetClassImplCallParameterNames(MetaModel model, MetaOperation op) //713:1
        {
            string result = "this"; //714:2
            string delim = ", "; //715:2
            var __loop50_results = 
                (from __loop50_var1 in __Enumerate((op).GetEnumerator()) //716:7
                from param in __Enumerate((__loop50_var1.Parameters).GetEnumerator()) //716:11
                select new { __loop50_var1 = __loop50_var1, param = param}
                ).ToList(); //716:2
            for (int __loop50_iteration = 0; __loop50_iteration < __loop50_results.Count; ++__loop50_iteration)
            {
                var __tmp1 = __loop50_results[__loop50_iteration];
                var __loop50_var1 = __tmp1.__loop50_var1;
                var param = __tmp1.param;
                result += delim + param.Name; //717:3
            }
            return result; //719:2
        }

        public string GetReturn(MetaModel model, MetaOperation op) //722:1
        {
            if (CSharpName(op.ReturnType, model, ClassKind.Immutable) == "void") //723:5
            {
                return ""; //724:3
            }
            else //725:2
            {
                return "return "; //726:3
            }
        }

        public string GenerateClass(MetaModel model, MetaClass cls) //730:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //731:1
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
                __out.AppendLine(false); //732:37
            }
            __out.AppendLine(true); //733:1
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
                __out.AppendLine(false); //734:35
            }
            return __out.ToString();
        }

        public string GenerateClassInternal(MetaModel model, MetaClass cls) //737:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //738:1
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
                __out.AppendLine(false); //739:30
            }
            __out.AppendLine(true); //740:1
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
                __out.AppendLine(false); //741:41
            }
            __out.AppendLine(true); //742:1
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
                __out.AppendLine(false); //743:39
            }
            return __out.ToString();
        }

        public string GenerateIdClass(MetaModel model, MetaClass cls) //746:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //747:1
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
            string __tmp5_line = " : "; //747:53
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
            string __tmp7_line = ".SymbolId"; //747:75
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //747:84
            }
            __out.Append("{"); //748:1
            __out.AppendLine(false); //748:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public override "; //749:1
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
            string __tmp12_line = ".ModelSymbolInfo SymbolInfo { get { return "; //749:37
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
            string __tmp14_line = ".SymbolInfo; } }"; //749:130
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //749:146
            }
            __out.AppendLine(true); //750:1
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	public override "; //751:1
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
            string __tmp19_line = ".ImmutableSymbolBase CreateImmutable("; //751:37
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
            string __tmp21_line = ".ImmutableModel model)"; //751:93
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //751:115
            }
            __out.Append("	{"); //752:1
            __out.AppendLine(false); //752:3
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "		return new "; //753:1
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
            string __tmp26_line = "(this, model);"; //753:62
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //753:76
            }
            __out.Append("	}"); //754:1
            __out.AppendLine(false); //754:3
            __out.AppendLine(true); //755:1
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "	public override "; //756:1
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
            string __tmp31_line = ".MutableSymbolBase CreateMutable("; //756:37
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
            string __tmp33_line = ".MutableModel model, bool creating)"; //756:89
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Append(__tmp33_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //756:124
            }
            __out.Append("	{"); //757:1
            __out.AppendLine(false); //757:3
            bool __tmp35_outputWritten = false;
            string __tmp36_line = "		return new "; //758:1
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
            string __tmp38_line = "(this, model, creating);"; //758:60
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Append(__tmp38_line);
                __tmp35_outputWritten = true;
            }
            if (__tmp35_outputWritten) __out.AppendLine(true);
            if (__tmp35_outputWritten)
            {
                __out.AppendLine(false); //758:84
            }
            __out.Append("	}"); //759:1
            __out.AppendLine(false); //759:3
            __out.Append("}"); //760:1
            __out.AppendLine(false); //760:2
            return __out.ToString();
        }

        public string GenerateImmutableClass(MetaModel model, MetaClass cls) //763:1
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
                __out.AppendLine(false); //764:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //765:1
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
                __out.AppendLine(false); //765:97
            }
            __out.Append("{"); //766:1
            __out.AppendLine(false); //766:2
            var __loop51_results = 
                (from __loop51_var1 in __Enumerate((cls).GetEnumerator()) //767:8
                from prop in __Enumerate((__loop51_var1.Properties).GetEnumerator()) //767:13
                select new { __loop51_var1 = __loop51_var1, prop = prop}
                ).ToList(); //767:3
            for (int __loop51_iteration = 0; __loop51_iteration < __loop51_results.Count; ++__loop51_iteration)
            {
                var __tmp9 = __loop51_results[__loop51_iteration];
                var __loop51_var1 = __tmp9.__loop51_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //768:1
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
                    __out.AppendLine(false); //768:42
                }
            }
            __out.AppendLine(true); //770:1
            var __loop52_results = 
                (from __loop52_var1 in __Enumerate((cls).GetEnumerator()) //771:8
                from op in __Enumerate((__loop52_var1.Operations).GetEnumerator()) //771:13
                select new { __loop52_var1 = __loop52_var1, op = op}
                ).ToList(); //771:3
            for (int __loop52_iteration = 0; __loop52_iteration < __loop52_results.Count; ++__loop52_iteration)
            {
                var __tmp13 = __loop52_results[__loop52_iteration];
                var __loop52_var1 = __tmp13.__loop52_var1;
                var op = __tmp13.op;
                bool __tmp15_outputWritten = false;
                string __tmp14Prefix = "	"; //772:1
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
                    __out.AppendLine(false); //772:41
                }
            }
            __out.AppendLine(true); //774:1
            bool __tmp18_outputWritten = false;
            string __tmp19_line = "	new "; //775:1
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
            string __tmp21_line = " ToMutable();"; //775:54
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //775:67
            }
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	new "; //776:1
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
            string __tmp26_line = " ToMutable("; //776:54
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
            string __tmp28_line = ".MutableModel model);"; //776:84
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Append(__tmp28_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //776:105
            }
            __out.Append("}"); //777:1
            __out.AppendLine(false); //777:2
            return __out.ToString();
        }

        public string GenerateImmutableProperty(MetaModel model, MetaProperty prop) //780:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //781:2
            {
                __out.Append("new "); //782:1
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
            string __tmp4_line = " "; //784:57
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
            string __tmp6_line = " { get; }"; //784:106
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Append(__tmp6_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //784:115
            }
            return __out.ToString();
        }

        public string GenerateImmutableOperation(MetaModel model, MetaOperation op) //787:1
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
            string __tmp4_line = " "; //788:61
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
            string __tmp6_line = "("; //788:71
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
            string __tmp8_line = ");"; //788:116
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Append(__tmp8_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //788:118
            }
            return __out.ToString();
        }

        public string GetImmutableOperationParameters(MetaModel model, MetaOperation op) //791:1
        {
            string result = ""; //792:2
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((op).GetEnumerator()) //793:7
                from param in __Enumerate((__loop53_var1.Parameters).GetEnumerator()) //793:11
                select new { __loop53_var1 = __loop53_var1, param = param}
                ).ToList(); //793:2
            for (int __loop53_iteration = 0; __loop53_iteration < __loop53_results.Count; ++__loop53_iteration)
            {
                string delim; //793:27
                if (__loop53_iteration+1 < __loop53_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop53_results[__loop53_iteration];
                var __loop53_var1 = __tmp1.__loop53_var1;
                var param = __tmp1.param;
                result += CSharpName(param.Type, model, ClassKind.Immutable, true) + " " + param.Name + delim; //794:3
            }
            return result; //796:2
        }

        public string GetImmutableAncestors(MetaModel model, MetaClass cls) //799:1
        {
            string result = ""; //800:2
            var __loop54_results = 
                (from __loop54_var1 in __Enumerate((cls).GetEnumerator()) //801:7
                from super in __Enumerate((__loop54_var1.SuperClasses).GetEnumerator()) //801:12
                select new { __loop54_var1 = __loop54_var1, super = super}
                ).ToList(); //801:2
            for (int __loop54_iteration = 0; __loop54_iteration < __loop54_results.Count; ++__loop54_iteration)
            {
                string delim; //801:30
                if (__loop54_iteration+1 < __loop54_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop54_results[__loop54_iteration];
                var __loop54_var1 = __tmp1.__loop54_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Immutable, true) + delim; //802:3
            }
            if (result == "") //804:2
            {
                result = Properties.CoreNs + ".ImmutableSymbol"; //805:3
            }
            result = " : " + result; //807:2
            return result; //808:2
        }

        public string GenerateBuilderClass(MetaModel model, MetaClass cls) //811:1
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
                __out.AppendLine(false); //812:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //813:1
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
                __out.AppendLine(false); //813:93
            }
            __out.Append("{"); //814:1
            __out.AppendLine(false); //814:2
            var __loop55_results = 
                (from __loop55_var1 in __Enumerate((cls).GetEnumerator()) //815:8
                from prop in __Enumerate((__loop55_var1.Properties).GetEnumerator()) //815:13
                select new { __loop55_var1 = __loop55_var1, prop = prop}
                ).ToList(); //815:3
            for (int __loop55_iteration = 0; __loop55_iteration < __loop55_results.Count; ++__loop55_iteration)
            {
                var __tmp9 = __loop55_results[__loop55_iteration];
                var __loop55_var1 = __tmp9.__loop55_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //816:1
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
                    __out.AppendLine(false); //816:40
                }
            }
            __out.AppendLine(true); //818:1
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	new "; //819:1
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
            string __tmp17_line = " ToImmutable();"; //819:56
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //819:71
            }
            bool __tmp19_outputWritten = false;
            string __tmp20_line = "	new "; //820:1
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
            string __tmp22_line = " ToImmutable("; //820:56
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
            string __tmp24_line = ".ImmutableModel model);"; //820:88
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp19_outputWritten = true;
            }
            if (__tmp19_outputWritten) __out.AppendLine(true);
            if (__tmp19_outputWritten)
            {
                __out.AppendLine(false); //820:111
            }
            __out.Append("}"); //821:1
            __out.AppendLine(false); //821:2
            return __out.ToString();
        }

        public string GenerateBuilderProperty(MetaModel model, MetaProperty prop) //824:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //825:3
            {
                __out.Append("new "); //826:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //828:3
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
                string __tmp4_line = " "; //829:55
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
                string __tmp6_line = " { get; set; }"; //829:102
                if (!string.IsNullOrEmpty(__tmp6_line))
                {
                    __out.Append(__tmp6_line);
                    __tmp2_outputWritten = true;
                }
                if (__tmp2_outputWritten) __out.AppendLine(true);
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //829:116
                }
            }
            else //830:3
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
                string __tmp10_line = " "; //831:55
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
                string __tmp12_line = " { get; }"; //831:102
                if (!string.IsNullOrEmpty(__tmp12_line))
                {
                    __out.Append(__tmp12_line);
                    __tmp8_outputWritten = true;
                }
                if (__tmp8_outputWritten) __out.AppendLine(true);
                if (__tmp8_outputWritten)
                {
                    __out.AppendLine(false); //831:111
                }
            }
            if (!(prop.Type is MetaCollectionType)) //833:3
            {
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //834:4
                {
                    __out.Append("new "); //835:1
                }
                bool __tmp14_outputWritten = false;
                string __tmp15_line = "Func<"; //837:1
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
                string __tmp17_line = "> "; //837:60
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
                string __tmp19_line = "Lazy { get; set; }"; //837:108
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Append(__tmp19_line);
                    __tmp14_outputWritten = true;
                }
                if (__tmp14_outputWritten) __out.AppendLine(true);
                if (__tmp14_outputWritten)
                {
                    __out.AppendLine(false); //837:126
                }
            }
            return __out.ToString();
        }

        public string GetBuilderAncestors(MetaModel model, MetaClass cls) //841:1
        {
            string result = ""; //842:2
            var __loop56_results = 
                (from __loop56_var1 in __Enumerate((cls).GetEnumerator()) //843:7
                from super in __Enumerate((__loop56_var1.SuperClasses).GetEnumerator()) //843:12
                select new { __loop56_var1 = __loop56_var1, super = super}
                ).ToList(); //843:2
            for (int __loop56_iteration = 0; __loop56_iteration < __loop56_results.Count; ++__loop56_iteration)
            {
                string delim; //843:30
                if (__loop56_iteration+1 < __loop56_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop56_results[__loop56_iteration];
                var __loop56_var1 = __tmp1.__loop56_var1;
                var super = __tmp1.super;
                result += CSharpName(super, model, ClassKind.Builder, true) + delim; //844:3
            }
            if (result == "") //846:2
            {
                result = Properties.CoreNs + ".MutableSymbol"; //847:3
            }
            result = " : " + result; //849:2
            return result; //850:2
        }

        public string GenerateImmutableImplClass(MetaModel model, MetaClass cls) //853:1
        {
            StringBuilder __out = new StringBuilder();
            string coreNs = IsCoreModel(model) ? "" : Properties.CoreNs + "."; //854:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //855:1
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
            string __tmp5_line = " : "; //855:64
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
            string __tmp7_line = ".ImmutableSymbolBase, "; //855:86
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
                __out.AppendLine(false); //855:152
            }
            __out.Append("{"); //856:1
            __out.AppendLine(false); //856:2
            var __loop57_results = 
                (from __loop57_var1 in __Enumerate((cls).GetEnumerator()) //857:8
                from prop in __Enumerate((__loop57_var1.GetAllProperties()).GetEnumerator()) //857:13
                select new { __loop57_var1 = __loop57_var1, prop = prop}
                ).ToList(); //857:3
            for (int __loop57_iteration = 0; __loop57_iteration < __loop57_results.Count; ++__loop57_iteration)
            {
                var __tmp9 = __loop57_results[__loop57_iteration];
                var __loop57_var1 = __tmp9.__loop57_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //858:1
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
                    __out.AppendLine(false); //858:44
                }
            }
            __out.AppendLine(true); //860:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //861:1
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
            string __tmp17_line = "("; //861:59
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
            string __tmp19_line = ".SymbolId id, "; //861:79
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
            string __tmp21_line = ".ImmutableModel model)"; //861:112
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //861:134
            }
            __out.Append("		: base(id, model)"); //862:1
            __out.AppendLine(false); //862:20
            __out.Append("	{"); //863:1
            __out.AppendLine(false); //863:3
            __out.Append("	}"); //864:1
            __out.AppendLine(false); //864:3
            __out.AppendLine(true); //865:2
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	public override "; //866:1
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp23_outputWritten = true;
            }
            StringBuilder __tmp25 = new StringBuilder();
            __tmp25.Append(coreNs);
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
            string __tmp26_line = "MetaModel MMetaModel"; //866:26
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //866:46
            }
            __out.Append("	{"); //867:1
            __out.AppendLine(false); //867:3
            if (IsCoreModel(model)) //868:4
            {
                bool __tmp28_outputWritten = false;
                string __tmp29_line = "		get { return "; //869:1
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
                string __tmp31_line = "._MetaModel; }"; //869:77
                if (!string.IsNullOrEmpty(__tmp31_line))
                {
                    __out.Append(__tmp31_line);
                    __tmp28_outputWritten = true;
                }
                if (__tmp28_outputWritten) __out.AppendLine(true);
                if (__tmp28_outputWritten)
                {
                    __out.AppendLine(false); //869:91
                }
            }
            else //870:4
            {
                bool __tmp33_outputWritten = false;
                string __tmp34_line = "		get { return "; //871:1
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
                string __tmp36_line = ".MetaModel; }"; //871:77
                if (!string.IsNullOrEmpty(__tmp36_line))
                {
                    __out.Append(__tmp36_line);
                    __tmp33_outputWritten = true;
                }
                if (__tmp33_outputWritten) __out.AppendLine(true);
                if (__tmp33_outputWritten)
                {
                    __out.AppendLine(false); //871:90
                }
            }
            __out.Append("	}"); //873:1
            __out.AppendLine(false); //873:3
            __out.AppendLine(true); //874:2
            bool __tmp38_outputWritten = false;
            string __tmp39_line = "	public override "; //875:1
            if (!string.IsNullOrEmpty(__tmp39_line))
            {
                __out.Append(__tmp39_line);
                __tmp38_outputWritten = true;
            }
            StringBuilder __tmp40 = new StringBuilder();
            __tmp40.Append(coreNs);
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
            string __tmp41_line = "MetaClass MMetaClass"; //875:26
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Append(__tmp41_line);
                __tmp38_outputWritten = true;
            }
            if (__tmp38_outputWritten) __out.AppendLine(true);
            if (__tmp38_outputWritten)
            {
                __out.AppendLine(false); //875:46
            }
            __out.Append("	{"); //876:1
            __out.AppendLine(false); //876:3
            bool __tmp43_outputWritten = false;
            string __tmp44_line = "		get { return "; //877:1
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
            string __tmp46_line = "; }"; //877:74
            if (!string.IsNullOrEmpty(__tmp46_line))
            {
                __out.Append(__tmp46_line);
                __tmp43_outputWritten = true;
            }
            if (__tmp43_outputWritten) __out.AppendLine(true);
            if (__tmp43_outputWritten)
            {
                __out.AppendLine(false); //877:77
            }
            __out.Append("	}"); //878:1
            __out.AppendLine(false); //878:3
            __out.AppendLine(true); //879:2
            bool __tmp48_outputWritten = false;
            string __tmp49_line = "	public new "; //880:1
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
            string __tmp51_line = " ToMutable()"; //880:55
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Append(__tmp51_line);
                __tmp48_outputWritten = true;
            }
            if (__tmp48_outputWritten) __out.AppendLine(true);
            if (__tmp48_outputWritten)
            {
                __out.AppendLine(false); //880:67
            }
            __out.Append("	{"); //881:1
            __out.AppendLine(false); //881:3
            bool __tmp53_outputWritten = false;
            string __tmp54_line = "		return ("; //882:1
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
            string __tmp56_line = ")base.ToMutable();"; //882:53
            if (!string.IsNullOrEmpty(__tmp56_line))
            {
                __out.Append(__tmp56_line);
                __tmp53_outputWritten = true;
            }
            if (__tmp53_outputWritten) __out.AppendLine(true);
            if (__tmp53_outputWritten)
            {
                __out.AppendLine(false); //882:71
            }
            __out.Append("	}"); //883:1
            __out.AppendLine(false); //883:3
            __out.AppendLine(true); //884:2
            bool __tmp58_outputWritten = false;
            string __tmp59_line = "	public new "; //885:1
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
            string __tmp61_line = " ToMutable("; //885:55
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
            string __tmp63_line = ".MutableModel model)"; //885:85
            if (!string.IsNullOrEmpty(__tmp63_line))
            {
                __out.Append(__tmp63_line);
                __tmp58_outputWritten = true;
            }
            if (__tmp58_outputWritten) __out.AppendLine(true);
            if (__tmp58_outputWritten)
            {
                __out.AppendLine(false); //885:105
            }
            __out.Append("	{"); //886:1
            __out.AppendLine(false); //886:3
            bool __tmp65_outputWritten = false;
            string __tmp66_line = "		return ("; //887:1
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
            string __tmp68_line = ")base.ToMutable(model);"; //887:53
            if (!string.IsNullOrEmpty(__tmp68_line))
            {
                __out.Append(__tmp68_line);
                __tmp65_outputWritten = true;
            }
            if (__tmp65_outputWritten) __out.AppendLine(true);
            if (__tmp65_outputWritten)
            {
                __out.AppendLine(false); //887:76
            }
            __out.Append("	}"); //888:1
            __out.AppendLine(false); //888:3
            var __loop58_results = 
                (from __loop58_var1 in __Enumerate((cls).GetEnumerator()) //889:8
                from sup in __Enumerate((__loop58_var1.GetAllSuperClasses(false)).GetEnumerator()) //889:13
                select new { __loop58_var1 = __loop58_var1, sup = sup}
                ).ToList(); //889:3
            for (int __loop58_iteration = 0; __loop58_iteration < __loop58_results.Count; ++__loop58_iteration)
            {
                var __tmp69 = __loop58_results[__loop58_iteration];
                var __loop58_var1 = __tmp69.__loop58_var1;
                var sup = __tmp69.sup;
                __out.AppendLine(true); //890:2
                bool __tmp71_outputWritten = false;
                string __tmp70Prefix = "	"; //891:1
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
                string __tmp73_line = " "; //891:50
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
                string __tmp75_line = ".ToMutable()"; //891:101
                if (!string.IsNullOrEmpty(__tmp75_line))
                {
                    __out.Append(__tmp75_line);
                    __tmp71_outputWritten = true;
                }
                if (__tmp71_outputWritten) __out.AppendLine(true);
                if (__tmp71_outputWritten)
                {
                    __out.AppendLine(false); //891:113
                }
                __out.Append("	{"); //892:1
                __out.AppendLine(false); //892:3
                __out.Append("		return this.ToMutable();"); //893:1
                __out.AppendLine(false); //893:27
                __out.Append("	}"); //894:1
                __out.AppendLine(false); //894:3
                __out.AppendLine(true); //895:2
                bool __tmp77_outputWritten = false;
                string __tmp76Prefix = "	"; //896:1
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
                string __tmp79_line = " "; //896:50
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
                string __tmp81_line = ".ToMutable("; //896:101
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
                string __tmp83_line = ".MutableModel model)"; //896:131
                if (!string.IsNullOrEmpty(__tmp83_line))
                {
                    __out.Append(__tmp83_line);
                    __tmp77_outputWritten = true;
                }
                if (__tmp77_outputWritten) __out.AppendLine(true);
                if (__tmp77_outputWritten)
                {
                    __out.AppendLine(false); //896:151
                }
                __out.Append("	{"); //897:1
                __out.AppendLine(false); //897:3
                __out.Append("		return this.ToMutable(model);"); //898:1
                __out.AppendLine(false); //898:32
                __out.Append("	}"); //899:1
                __out.AppendLine(false); //899:3
            }
            var __loop59_results = 
                (from __loop59_var1 in __Enumerate((cls).GetEnumerator()) //901:8
                from prop in __Enumerate((__loop59_var1.GetAllProperties()).GetEnumerator()) //901:13
                select new { __loop59_var1 = __loop59_var1, prop = prop}
                ).ToList(); //901:3
            for (int __loop59_iteration = 0; __loop59_iteration < __loop59_results.Count; ++__loop59_iteration)
            {
                var __tmp84 = __loop59_results[__loop59_iteration];
                var __loop59_var1 = __tmp84.__loop59_var1;
                var prop = __tmp84.prop;
                __out.AppendLine(true); //902:2
                bool __tmp86_outputWritten = false;
                string __tmp85Prefix = "	"; //903:1
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
                    __out.AppendLine(false); //903:51
                }
            }
            var __loop60_results = 
                (from __loop60_var1 in __Enumerate((cls).GetEnumerator()) //905:8
                from op in __Enumerate((__loop60_var1.GetAllOperations()).GetEnumerator()) //905:13
                select new { __loop60_var1 = __loop60_var1, op = op}
                ).ToList(); //905:3
            for (int __loop60_iteration = 0; __loop60_iteration < __loop60_results.Count; ++__loop60_iteration)
            {
                var __tmp88 = __loop60_results[__loop60_iteration];
                var __loop60_var1 = __tmp88.__loop60_var1;
                var op = __tmp88.op;
                __out.AppendLine(true); //906:2
                bool __tmp90_outputWritten = false;
                string __tmp89Prefix = "	"; //907:1
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
                    __out.AppendLine(false); //907:50
                }
            }
            __out.Append("}"); //909:1
            __out.AppendLine(false); //909:2
            return __out.ToString();
        }

        public string GenerateImmutableField(MetaModel model, MetaClass cls, MetaProperty prop) //912:1
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
                __out.AppendLine(false); //913:54
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "private "; //914:1
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
            string __tmp8_line = " "; //914:65
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
            string __tmp10_line = ";"; //914:90
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //914:91
            }
            return __out.ToString();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //917:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //918:1
            if (cls.GetAllFinalProperties().Contains(prop)) //919:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //920:1
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
                string __tmp5_line = " "; //920:64
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
                    __out.AppendLine(false); //920:76
                }
            }
            else //921:2
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
                    __out.AppendLine(false); //922:54
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
                string __tmp13_line = " "; //923:57
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
                string __tmp15_line = "."; //923:115
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
                    __out.AppendLine(false); //923:127
                }
            }
            __out.Append("{"); //925:1
            __out.AppendLine(false); //925:2
            if (prop.Type is MetaCollectionType) //926:6
            {
                if (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.Set || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet) //927:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "    get { return this.GetSet<"; //928:1
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
                    string __tmp21_line = ">("; //928:118
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
                    string __tmp23_line = ", ref "; //928:174
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
                    string __tmp25_line = "); }"; //928:204
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Append(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //928:208
                    }
                }
                else //929:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "    get { return this.GetList<"; //930:1
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
                    string __tmp30_line = ">("; //930:119
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
                    string __tmp32_line = ", ref "; //930:175
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
                    string __tmp34_line = "); }"; //930:205
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Append(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //930:209
                    }
                }
            }
            else if (IsReferenceType(prop.Type)) //932:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "    get { return this.GetReference<"; //933:1
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
                string __tmp39_line = ">("; //933:92
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
                string __tmp41_line = ", ref "; //933:148
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
                string __tmp43_line = "); }"; //933:178
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Append(__tmp43_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //933:182
                }
            }
            else //934:3
            {
                bool __tmp45_outputWritten = false;
                string __tmp46_line = "    get { return this.GetValue<"; //935:1
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
                string __tmp48_line = ">("; //935:88
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
                string __tmp50_line = ", ref "; //935:144
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
                string __tmp52_line = "); }"; //935:174
                if (!string.IsNullOrEmpty(__tmp52_line))
                {
                    __out.Append(__tmp52_line);
                    __tmp45_outputWritten = true;
                }
                if (__tmp45_outputWritten) __out.AppendLine(true);
                if (__tmp45_outputWritten)
                {
                    __out.AppendLine(false); //935:178
                }
            }
            __out.Append("}"); //937:1
            __out.AppendLine(false); //937:2
            return __out.ToString();
        }

        public string GenerateImmutableOperationImpl(MetaModel model, MetaClass cls, MetaOperation op) //940:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //941:1
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
            string __tmp4_line = " "; //942:61
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
            string __tmp6_line = "."; //942:118
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
            string __tmp8_line = "("; //942:128
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
            string __tmp10_line = ")"; //942:182
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //942:183
            }
            __out.Append("{"); //943:1
            __out.AppendLine(false); //943:2
            bool __tmp12_outputWritten = false;
            string __tmp11Prefix = "    "; //944:1
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
            string __tmp15_line = ".Implementation."; //944:85
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
            string __tmp17_line = "_"; //944:151
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
            string __tmp19_line = "("; //944:161
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
            string __tmp21_line = ");"; //944:205
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp12_outputWritten = true;
            }
            if (__tmp12_outputWritten) __out.AppendLine(true);
            if (__tmp12_outputWritten)
            {
                __out.AppendLine(false); //944:207
            }
            __out.Append("}"); //945:1
            __out.AppendLine(false); //945:2
            return __out.ToString();
        }

        public string GenerateBuilderImplClass(MetaModel model, MetaClass cls) //948:1
        {
            StringBuilder __out = new StringBuilder();
            string coreNs = IsCoreModel(model) ? "" : Properties.CoreNs + "."; //949:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //950:1
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
            string __tmp5_line = " : "; //950:62
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
            string __tmp7_line = ".MutableSymbolBase, "; //950:84
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
                __out.AppendLine(false); //950:146
            }
            __out.Append("{"); //951:1
            __out.AppendLine(false); //951:2
            var __loop61_results = 
                (from __loop61_var1 in __Enumerate((cls).GetEnumerator()) //952:8
                from prop in __Enumerate((__loop61_var1.GetAllProperties()).GetEnumerator()) //952:13
                where prop.Type is MetaCollectionType //952:37
                select new { __loop61_var1 = __loop61_var1, prop = prop}
                ).ToList(); //952:3
            for (int __loop61_iteration = 0; __loop61_iteration < __loop61_results.Count; ++__loop61_iteration)
            {
                var __tmp9 = __loop61_results[__loop61_iteration];
                var __loop61_var1 = __tmp9.__loop61_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //953:1
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
                    __out.AppendLine(false); //953:42
                }
            }
            __out.AppendLine(true); //955:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //956:1
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
            string __tmp17_line = "("; //956:57
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
            string __tmp19_line = ".SymbolId id, "; //956:77
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
            string __tmp21_line = ".MutableModel model, bool creating)"; //956:110
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //956:145
            }
            __out.Append("		: base(id, model, creating)"); //957:1
            __out.AppendLine(false); //957:30
            __out.Append("	{"); //958:1
            __out.AppendLine(false); //958:3
            __out.Append("	}"); //959:1
            __out.AppendLine(false); //959:3
            __out.AppendLine(true); //960:2
            __out.Append("	protected override void MInit()"); //961:1
            __out.AppendLine(false); //961:33
            __out.Append("	{"); //962:1
            __out.AppendLine(false); //962:3
            bool __tmp23_outputWritten = false;
            string __tmp22Prefix = "		"; //963:1
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
            string __tmp25_line = ".Implementation."; //963:55
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
            string __tmp27_line = "(this);"; //963:115
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Append(__tmp27_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //963:122
            }
            __out.Append("	}"); //964:1
            __out.AppendLine(false); //964:3
            __out.AppendLine(true); //965:2
            bool __tmp29_outputWritten = false;
            string __tmp30_line = "	public override "; //966:1
            if (!string.IsNullOrEmpty(__tmp30_line))
            {
                __out.Append(__tmp30_line);
                __tmp29_outputWritten = true;
            }
            StringBuilder __tmp31 = new StringBuilder();
            __tmp31.Append(coreNs);
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
            string __tmp32_line = "MetaModel MMetaModel"; //966:26
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Append(__tmp32_line);
                __tmp29_outputWritten = true;
            }
            if (__tmp29_outputWritten) __out.AppendLine(true);
            if (__tmp29_outputWritten)
            {
                __out.AppendLine(false); //966:46
            }
            __out.Append("	{"); //967:1
            __out.AppendLine(false); //967:3
            if (IsCoreModel(model)) //968:4
            {
                bool __tmp34_outputWritten = false;
                string __tmp35_line = "		get { return "; //969:1
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
                string __tmp37_line = "._MetaModel; }"; //969:77
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp34_outputWritten = true;
                }
                if (__tmp34_outputWritten) __out.AppendLine(true);
                if (__tmp34_outputWritten)
                {
                    __out.AppendLine(false); //969:91
                }
            }
            else //970:4
            {
                bool __tmp39_outputWritten = false;
                string __tmp40_line = "		get { return "; //971:1
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
                string __tmp42_line = ".MetaModel; }"; //971:77
                if (!string.IsNullOrEmpty(__tmp42_line))
                {
                    __out.Append(__tmp42_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //971:90
                }
            }
            __out.Append("	}"); //973:1
            __out.AppendLine(false); //973:3
            __out.AppendLine(true); //974:2
            bool __tmp44_outputWritten = false;
            string __tmp45_line = "	public override "; //975:1
            if (!string.IsNullOrEmpty(__tmp45_line))
            {
                __out.Append(__tmp45_line);
                __tmp44_outputWritten = true;
            }
            StringBuilder __tmp46 = new StringBuilder();
            __tmp46.Append(coreNs);
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
            string __tmp47_line = "MetaClass MMetaClass"; //975:26
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Append(__tmp47_line);
                __tmp44_outputWritten = true;
            }
            if (__tmp44_outputWritten) __out.AppendLine(true);
            if (__tmp44_outputWritten)
            {
                __out.AppendLine(false); //975:46
            }
            __out.Append("	{"); //976:1
            __out.AppendLine(false); //976:3
            bool __tmp49_outputWritten = false;
            string __tmp50_line = "		get { return "; //977:1
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
            string __tmp52_line = "; }"; //977:74
            if (!string.IsNullOrEmpty(__tmp52_line))
            {
                __out.Append(__tmp52_line);
                __tmp49_outputWritten = true;
            }
            if (__tmp49_outputWritten) __out.AppendLine(true);
            if (__tmp49_outputWritten)
            {
                __out.AppendLine(false); //977:77
            }
            __out.Append("	}"); //978:1
            __out.AppendLine(false); //978:3
            __out.AppendLine(true); //979:2
            bool __tmp54_outputWritten = false;
            string __tmp55_line = "	public new "; //980:1
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
            string __tmp57_line = " ToImmutable()"; //980:57
            if (!string.IsNullOrEmpty(__tmp57_line))
            {
                __out.Append(__tmp57_line);
                __tmp54_outputWritten = true;
            }
            if (__tmp54_outputWritten) __out.AppendLine(true);
            if (__tmp54_outputWritten)
            {
                __out.AppendLine(false); //980:71
            }
            __out.Append("	{"); //981:1
            __out.AppendLine(false); //981:3
            bool __tmp59_outputWritten = false;
            string __tmp60_line = "		return ("; //982:1
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
            string __tmp62_line = ")base.ToImmutable();"; //982:55
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Append(__tmp62_line);
                __tmp59_outputWritten = true;
            }
            if (__tmp59_outputWritten) __out.AppendLine(true);
            if (__tmp59_outputWritten)
            {
                __out.AppendLine(false); //982:75
            }
            __out.Append("	}"); //983:1
            __out.AppendLine(false); //983:3
            __out.AppendLine(true); //984:2
            bool __tmp64_outputWritten = false;
            string __tmp65_line = "	public new "; //985:1
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
            string __tmp67_line = " ToImmutable("; //985:57
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
            string __tmp69_line = ".ImmutableModel model)"; //985:89
            if (!string.IsNullOrEmpty(__tmp69_line))
            {
                __out.Append(__tmp69_line);
                __tmp64_outputWritten = true;
            }
            if (__tmp64_outputWritten) __out.AppendLine(true);
            if (__tmp64_outputWritten)
            {
                __out.AppendLine(false); //985:111
            }
            __out.Append("	{"); //986:1
            __out.AppendLine(false); //986:3
            bool __tmp71_outputWritten = false;
            string __tmp72_line = "		return ("; //987:1
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
            string __tmp74_line = ")base.ToImmutable(model);"; //987:55
            if (!string.IsNullOrEmpty(__tmp74_line))
            {
                __out.Append(__tmp74_line);
                __tmp71_outputWritten = true;
            }
            if (__tmp71_outputWritten) __out.AppendLine(true);
            if (__tmp71_outputWritten)
            {
                __out.AppendLine(false); //987:80
            }
            __out.Append("	}"); //988:1
            __out.AppendLine(false); //988:3
            var __loop62_results = 
                (from __loop62_var1 in __Enumerate((cls).GetEnumerator()) //989:8
                from sup in __Enumerate((__loop62_var1.GetAllSuperClasses(false)).GetEnumerator()) //989:13
                select new { __loop62_var1 = __loop62_var1, sup = sup}
                ).ToList(); //989:3
            for (int __loop62_iteration = 0; __loop62_iteration < __loop62_results.Count; ++__loop62_iteration)
            {
                var __tmp75 = __loop62_results[__loop62_iteration];
                var __loop62_var1 = __tmp75.__loop62_var1;
                var sup = __tmp75.sup;
                __out.AppendLine(true); //990:2
                bool __tmp77_outputWritten = false;
                string __tmp76Prefix = "	"; //991:1
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
                string __tmp79_line = " "; //991:52
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
                string __tmp81_line = ".ToImmutable()"; //991:101
                if (!string.IsNullOrEmpty(__tmp81_line))
                {
                    __out.Append(__tmp81_line);
                    __tmp77_outputWritten = true;
                }
                if (__tmp77_outputWritten) __out.AppendLine(true);
                if (__tmp77_outputWritten)
                {
                    __out.AppendLine(false); //991:115
                }
                __out.Append("	{"); //992:1
                __out.AppendLine(false); //992:3
                __out.Append("		return this.ToImmutable();"); //993:1
                __out.AppendLine(false); //993:29
                __out.Append("	}"); //994:1
                __out.AppendLine(false); //994:3
                __out.AppendLine(true); //995:2
                bool __tmp83_outputWritten = false;
                string __tmp82Prefix = "	"; //996:1
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
                string __tmp85_line = " "; //996:52
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
                string __tmp87_line = ".ToImmutable("; //996:101
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
                string __tmp89_line = ".ImmutableModel model)"; //996:133
                if (!string.IsNullOrEmpty(__tmp89_line))
                {
                    __out.Append(__tmp89_line);
                    __tmp83_outputWritten = true;
                }
                if (__tmp83_outputWritten) __out.AppendLine(true);
                if (__tmp83_outputWritten)
                {
                    __out.AppendLine(false); //996:155
                }
                __out.Append("	{"); //997:1
                __out.AppendLine(false); //997:3
                __out.Append("		return this.ToImmutable(model);"); //998:1
                __out.AppendLine(false); //998:34
                __out.Append("	}"); //999:1
                __out.AppendLine(false); //999:3
            }
            var __loop63_results = 
                (from __loop63_var1 in __Enumerate((cls).GetEnumerator()) //1001:8
                from prop in __Enumerate((__loop63_var1.GetAllProperties()).GetEnumerator()) //1001:13
                select new { __loop63_var1 = __loop63_var1, prop = prop}
                ).ToList(); //1001:3
            for (int __loop63_iteration = 0; __loop63_iteration < __loop63_results.Count; ++__loop63_iteration)
            {
                var __tmp90 = __loop63_results[__loop63_iteration];
                var __loop63_var1 = __tmp90.__loop63_var1;
                var prop = __tmp90.prop;
                __out.AppendLine(true); //1002:2
                bool __tmp92_outputWritten = false;
                string __tmp91Prefix = "	"; //1003:1
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
                    __out.AppendLine(false); //1003:49
                }
            }
            __out.Append("}"); //1005:1
            __out.AppendLine(false); //1005:2
            return __out.ToString();
        }

        public string GenerateBuilderField(MetaModel model, MetaClass cls, MetaProperty prop) //1008:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "private "; //1009:1
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
            string __tmp5_line = " "; //1009:63
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
            string __tmp7_line = ";"; //1009:88
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1009:89
            }
            return __out.ToString();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //1012:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1013:1
            if (cls.GetAllFinalProperties().Contains(prop)) //1014:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //1015:1
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
                string __tmp5_line = " "; //1015:62
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
                    __out.AppendLine(false); //1015:74
                }
            }
            else //1016:2
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
                    __out.AppendLine(false); //1017:54
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
                string __tmp13_line = " "; //1018:55
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
                string __tmp15_line = "."; //1018:111
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
                    __out.AppendLine(false); //1018:123
                }
            }
            __out.Append("{"); //1020:1
            __out.AppendLine(false); //1020:2
            if (prop.Type is MetaCollectionType) //1021:3
            {
                if (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.Set || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet) //1022:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "	get { return this.GetSet<"; //1023:1
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
                    string __tmp21_line = ">("; //1023:113
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
                    string __tmp23_line = ", ref "; //1023:169
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
                    string __tmp25_line = "); }"; //1023:199
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Append(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //1023:203
                    }
                }
                else //1024:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "	get { return this.GetList<"; //1025:1
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
                    string __tmp30_line = ">("; //1025:114
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
                    string __tmp32_line = ", ref "; //1025:170
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
                    string __tmp34_line = "); }"; //1025:200
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Append(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //1025:204
                    }
                }
            }
            else if (IsReferenceType(prop.Type)) //1027:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "	get { return this.GetReference<"; //1028:1
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
                string __tmp39_line = ">("; //1028:87
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
                string __tmp41_line = "); }"; //1028:143
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Append(__tmp41_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //1028:147
                }
            }
            else //1029:3
            {
                bool __tmp43_outputWritten = false;
                string __tmp44_line = "	get { return this.GetValue<"; //1030:1
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
                string __tmp46_line = ">("; //1030:83
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
                string __tmp48_line = "); }"; //1030:139
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Append(__tmp48_line);
                    __tmp43_outputWritten = true;
                }
                if (__tmp43_outputWritten) __out.AppendLine(true);
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //1030:143
                }
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //1032:3
            {
                if (IsReferenceType(prop.Type)) //1033:4
                {
                    bool __tmp50_outputWritten = false;
                    string __tmp51_line = "	set { this.SetReference<"; //1034:1
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
                    string __tmp53_line = ">("; //1034:80
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
                    string __tmp55_line = ", value); }"; //1034:136
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Append(__tmp55_line);
                        __tmp50_outputWritten = true;
                    }
                    if (__tmp50_outputWritten) __out.AppendLine(true);
                    if (__tmp50_outputWritten)
                    {
                        __out.AppendLine(false); //1034:147
                    }
                }
                else //1035:4
                {
                    bool __tmp57_outputWritten = false;
                    string __tmp58_line = "	set { this.SetValue<"; //1036:1
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
                    string __tmp60_line = ">("; //1036:76
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
                    string __tmp62_line = ", value); }"; //1036:132
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Append(__tmp62_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //1036:143
                    }
                }
            }
            __out.Append("}"); //1039:1
            __out.AppendLine(false); //1039:2
            if (!(prop.Type is MetaCollectionType)) //1040:2
            {
                __out.AppendLine(true); //1041:1
                if (cls.GetAllFinalProperties().Contains(prop)) //1042:3
                {
                    bool __tmp64_outputWritten = false;
                    string __tmp65_line = "public Func<"; //1043:1
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
                    string __tmp67_line = "> "; //1043:67
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
                    string __tmp69_line = "Lazy"; //1043:80
                    if (!string.IsNullOrEmpty(__tmp69_line))
                    {
                        __out.Append(__tmp69_line);
                        __tmp64_outputWritten = true;
                    }
                    if (__tmp64_outputWritten) __out.AppendLine(true);
                    if (__tmp64_outputWritten)
                    {
                        __out.AppendLine(false); //1043:84
                    }
                }
                else //1044:3
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
                        __out.AppendLine(false); //1045:54
                    }
                    bool __tmp74_outputWritten = false;
                    string __tmp75_line = "Func<"; //1046:1
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
                    string __tmp77_line = "> "; //1046:60
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
                    string __tmp79_line = "."; //1046:117
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
                    string __tmp81_line = "Lazy"; //1046:129
                    if (!string.IsNullOrEmpty(__tmp81_line))
                    {
                        __out.Append(__tmp81_line);
                        __tmp74_outputWritten = true;
                    }
                    if (__tmp74_outputWritten) __out.AppendLine(true);
                    if (__tmp74_outputWritten)
                    {
                        __out.AppendLine(false); //1046:133
                    }
                }
                __out.Append("{"); //1048:1
                __out.AppendLine(false); //1048:2
                if (IsReferenceType(prop.Type)) //1049:3
                {
                    bool __tmp83_outputWritten = false;
                    string __tmp84_line = "	get { return this.GetLazyReference<"; //1050:1
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
                    string __tmp86_line = ">("; //1050:91
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
                    string __tmp88_line = "); }"; //1050:147
                    if (!string.IsNullOrEmpty(__tmp88_line))
                    {
                        __out.Append(__tmp88_line);
                        __tmp83_outputWritten = true;
                    }
                    if (__tmp83_outputWritten) __out.AppendLine(true);
                    if (__tmp83_outputWritten)
                    {
                        __out.AppendLine(false); //1050:151
                    }
                    bool __tmp90_outputWritten = false;
                    string __tmp91_line = "	set { this.SetLazyReference("; //1051:1
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
                    string __tmp93_line = ", value); }"; //1051:85
                    if (!string.IsNullOrEmpty(__tmp93_line))
                    {
                        __out.Append(__tmp93_line);
                        __tmp90_outputWritten = true;
                    }
                    if (__tmp90_outputWritten) __out.AppendLine(true);
                    if (__tmp90_outputWritten)
                    {
                        __out.AppendLine(false); //1051:96
                    }
                }
                else //1052:3
                {
                    bool __tmp95_outputWritten = false;
                    string __tmp96_line = "	get { return this.GetLazyValue<"; //1053:1
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
                    string __tmp98_line = ">("; //1053:87
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
                    string __tmp100_line = "); }"; //1053:143
                    if (!string.IsNullOrEmpty(__tmp100_line))
                    {
                        __out.Append(__tmp100_line);
                        __tmp95_outputWritten = true;
                    }
                    if (__tmp95_outputWritten) __out.AppendLine(true);
                    if (__tmp95_outputWritten)
                    {
                        __out.AppendLine(false); //1053:147
                    }
                    bool __tmp102_outputWritten = false;
                    string __tmp103_line = "	set { this.SetLazyValue("; //1054:1
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
                    string __tmp105_line = ", value); }"; //1054:81
                    if (!string.IsNullOrEmpty(__tmp105_line))
                    {
                        __out.Append(__tmp105_line);
                        __tmp102_outputWritten = true;
                    }
                    if (__tmp102_outputWritten) __out.AppendLine(true);
                    if (__tmp102_outputWritten)
                    {
                        __out.AppendLine(false); //1054:92
                    }
                }
                __out.Append("}"); //1056:1
                __out.AppendLine(false); //1056:2
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
