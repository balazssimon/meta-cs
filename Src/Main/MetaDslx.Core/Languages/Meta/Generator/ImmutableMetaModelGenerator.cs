﻿using System;
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
    using __Hidden_ImmutableMetaModelGenerator_1739053740;
    namespace __Hidden_ImmutableMetaModelGenerator_1739053740
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
            ImmutableModelList<string> lines = elem.GetDocumentationLines(); //44:2
            if (lines.Count > 0) //45:2
            {
                __out.Append("/**"); //46:1
                __out.AppendLine(false); //46:4
                __out.Append(" * <summary>"); //47:1
                __out.AppendLine(false); //47:13
                var __loop2_results = 
                    (from line in __Enumerate((lines).GetEnumerator()) //48:8
                    select new { line = line}
                    ).ToList(); //48:3
                for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
                {
                    var __tmp1 = __loop2_results[__loop2_iteration];
                    var line = __tmp1.line;
                    bool __tmp3_outputWritten = false;
                    string __tmp4_line = " * "; //49:1
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
                        __out.AppendLine(false); //49:10
                    }
                }
                __out.Append(" * </summary>"); //51:1
                __out.AppendLine(false); //51:14
                __out.Append(" */"); //52:1
                __out.AppendLine(false); //52:4
            }
            return __out.ToString();
        }

        public string GenerateAnnotations(MetaAnnotatedElement elem) //56:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop3_results = 
                (from __loop3_var1 in __Enumerate((elem).GetEnumerator()) //57:7
                from annot in __Enumerate((__loop3_var1.Annotations).GetEnumerator()) //57:13
                select new { __loop3_var1 = __loop3_var1, annot = annot}
                ).ToList(); //57:2
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
                string __tmp6_line = "."; //58:25
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
                string __tmp8_line = "Attribute"; //58:38
                if (!string.IsNullOrEmpty(__tmp8_line))
                {
                    __out.Append(__tmp8_line);
                    __tmp3_outputWritten = true;
                }
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append("]");
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
                            __tmp3_outputWritten = true;
                        }
                        if (!__tmp9_last || __tmp3_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp3_outputWritten)
                {
                    __out.AppendLine(false); //58:52
                }
            }
            return __out.ToString();
        }

        public string GenerateMetamodel(MetaModel model) //62:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //63:1
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
                __out.AppendLine(false); //63:67
            }
            __out.Append("{"); //64:1
            __out.AppendLine(false); //64:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	using global::"; //65:1
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
            string __tmp9_line = ";"; //65:74
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //65:75
            }
            __out.AppendLine(true); //66:1
            bool __tmp11_outputWritten = false;
            string __tmp10Prefix = "	"; //67:1
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
                __out.AppendLine(false); //67:36
            }
            __out.AppendLine(true); //68:1
            bool __tmp14_outputWritten = false;
            string __tmp13Prefix = "	"; //69:1
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
                __out.AppendLine(false); //69:26
            }
            __out.AppendLine(true); //70:1
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //71:8
                from enm in __Enumerate((__loop4_var1).GetEnumerator()).OfType<MetaEnum>() //71:38
                select new { __loop4_var1 = __loop4_var1, enm = enm}
                ).ToList(); //71:3
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp16 = __loop4_results[__loop4_iteration];
                var __loop4_var1 = __tmp16.__loop4_var1;
                var enm = __tmp16.enm;
                bool __tmp18_outputWritten = false;
                string __tmp17Prefix = "	"; //72:1
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
                    __out.AppendLine(false); //72:28
                }
            }
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //74:8
                from cls in __Enumerate((__loop5_var1).GetEnumerator()).OfType<MetaClass>() //74:38
                select new { __loop5_var1 = __loop5_var1, cls = cls}
                ).ToList(); //74:3
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp20 = __loop5_results[__loop5_iteration];
                var __loop5_var1 = __tmp20.__loop5_var1;
                var cls = __tmp20.cls;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "	"; //75:1
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
                    __out.AppendLine(false); //75:29
                }
            }
            __out.AppendLine(true); //77:1
            bool __tmp25_outputWritten = false;
            string __tmp24Prefix = "	"; //78:1
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
                __out.AppendLine(false); //78:38
            }
            __out.Append("}"); //79:1
            __out.AppendLine(false); //79:2
            __out.AppendLine(true); //80:1
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "namespace "; //81:1
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
                __out.AppendLine(false); //81:69
            }
            __out.Append("{"); //82:1
            __out.AppendLine(false); //82:2
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //83:8
                from cls in __Enumerate((__loop6_var1).GetEnumerator()).OfType<MetaClass>() //83:38
                select new { __loop6_var1 = __loop6_var1, cls = cls}
                ).ToList(); //83:3
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp31 = __loop6_results[__loop6_iteration];
                var __loop6_var1 = __tmp31.__loop6_var1;
                var cls = __tmp31.cls;
                bool __tmp33_outputWritten = false;
                string __tmp32Prefix = "	"; //84:1
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
                    __out.AppendLine(false); //84:37
                }
            }
            __out.AppendLine(true); //86:1
            bool __tmp36_outputWritten = false;
            string __tmp35Prefix = "	"; //87:1
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
                __out.AppendLine(false); //87:43
            }
            __out.AppendLine(true); //88:1
            bool __tmp39_outputWritten = false;
            string __tmp38Prefix = "	"; //89:1
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
                __out.AppendLine(false); //89:37
            }
            __out.AppendLine(true); //90:1
            bool __tmp42_outputWritten = false;
            string __tmp41Prefix = "	"; //91:1
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
                __out.AppendLine(false); //91:41
            }
            __out.Append("}"); //92:1
            __out.AppendLine(false); //92:2
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //95:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //96:2
            bool metaMetaModel = IsMetaMetaModel(model); //97:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //98:1
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
                __out.AppendLine(false); //98:61
            }
            __out.Append("{"); //99:1
            __out.AppendLine(false); //99:2
            __out.Append("	private static bool initialized;"); //100:1
            __out.AppendLine(false); //100:34
            __out.AppendLine(true); //101:1
            __out.Append("	public static bool IsInitialized"); //102:1
            __out.AppendLine(false); //102:34
            __out.Append("	{"); //103:1
            __out.AppendLine(false); //103:3
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "		get { return "; //104:1
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
            string __tmp9_line = ".initialized; }"; //104:63
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //104:78
            }
            __out.Append("	}"); //105:1
            __out.AppendLine(false); //105:3
            __out.AppendLine(true); //106:1
            if (metaMetaModel) //107:3
            {
                bool __tmp11_outputWritten = false;
                string __tmp12_line = "	public static readonly "; //108:1
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
                string __tmp14_line = "MetaModel MetaMetaModel;"; //108:33
                if (!string.IsNullOrEmpty(__tmp14_line))
                {
                    __out.Append(__tmp14_line);
                    __tmp11_outputWritten = true;
                }
                if (__tmp11_outputWritten) __out.AppendLine(true);
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //108:57
                }
            }
            else //109:3
            {
                bool __tmp16_outputWritten = false;
                string __tmp17_line = "	public static readonly "; //110:1
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
                string __tmp19_line = "MetaModel MetaModel;"; //110:33
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Append(__tmp19_line);
                    __tmp16_outputWritten = true;
                }
                if (__tmp16_outputWritten) __out.AppendLine(true);
                if (__tmp16_outputWritten)
                {
                    __out.AppendLine(false); //110:53
                }
            }
            bool __tmp21_outputWritten = false;
            string __tmp22_line = "	public static readonly "; //112:1
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
            string __tmp24_line = ".ImmutableModel Model;"; //112:44
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp21_outputWritten = true;
            }
            if (__tmp21_outputWritten) __out.AppendLine(true);
            if (__tmp21_outputWritten)
            {
                __out.AppendLine(false); //112:66
            }
            __out.AppendLine(true); //113:1
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //114:8
                from cst in __Enumerate((__loop7_var1).GetEnumerator()).OfType<MetaConstant>() //114:38
                select new { __loop7_var1 = __loop7_var1, cst = cst}
                ).ToList(); //114:3
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                var __tmp25 = __loop7_results[__loop7_iteration];
                var __loop7_var1 = __tmp25.__loop7_var1;
                var cst = __tmp25.cst;
                bool __tmp27_outputWritten = false;
                string __tmp26Prefix = "	"; //115:1
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
                    __out.AppendLine(false); //115:30
                }
                if (metaMetaModel) //116:4
                {
                    bool __tmp30_outputWritten = false;
                    string __tmp31_line = "	public static readonly "; //117:1
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
                    string __tmp33_line = " "; //117:74
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
                    string __tmp35_line = ";"; //117:127
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Append(__tmp35_line);
                        __tmp30_outputWritten = true;
                    }
                    if (__tmp30_outputWritten) __out.AppendLine(true);
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //117:128
                    }
                }
                else //118:4
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "	public static readonly "; //119:1
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
                    string __tmp40_line = " "; //119:80
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
                    string __tmp42_line = ";"; //119:133
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Append(__tmp42_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //119:134
                    }
                }
            }
            __out.AppendLine(true); //122:1
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //123:8
                from cls in __Enumerate((__loop8_var1).GetEnumerator()).OfType<MetaClass>() //123:38
                select new { __loop8_var1 = __loop8_var1, cls = cls}
                ).ToList(); //123:3
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp43 = __loop8_results[__loop8_iteration];
                var __loop8_var1 = __tmp43.__loop8_var1;
                var cls = __tmp43.cls;
                bool __tmp45_outputWritten = false;
                string __tmp44Prefix = "	"; //124:1
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
                    __out.AppendLine(false); //124:30
                }
                bool __tmp48_outputWritten = false;
                string __tmp49_line = "	public static readonly "; //125:1
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
                string __tmp51_line = "MetaClass "; //125:33
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
                string __tmp53_line = ";"; //125:95
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp48_outputWritten = true;
                }
                if (__tmp48_outputWritten) __out.AppendLine(true);
                if (__tmp48_outputWritten)
                {
                    __out.AppendLine(false); //125:96
                }
                var __loop9_results = 
                    (from __loop9_var1 in __Enumerate((cls).GetEnumerator()) //126:9
                    from prop in __Enumerate((__loop9_var1.Properties).GetEnumerator()) //126:14
                    select new { __loop9_var1 = __loop9_var1, prop = prop}
                    ).ToList(); //126:4
                for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
                {
                    var __tmp54 = __loop9_results[__loop9_iteration];
                    var __loop9_var1 = __tmp54.__loop9_var1;
                    var prop = __tmp54.prop;
                    bool __tmp56_outputWritten = false;
                    string __tmp55Prefix = "	"; //127:1
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
                        __out.AppendLine(false); //127:31
                    }
                    bool __tmp59_outputWritten = false;
                    string __tmp60_line = "	public static readonly "; //128:1
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
                    string __tmp62_line = "MetaProperty "; //128:33
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
                    string __tmp64_line = ";"; //128:102
                    if (!string.IsNullOrEmpty(__tmp64_line))
                    {
                        __out.Append(__tmp64_line);
                        __tmp59_outputWritten = true;
                    }
                    if (__tmp59_outputWritten) __out.AppendLine(true);
                    if (__tmp59_outputWritten)
                    {
                        __out.AppendLine(false); //128:103
                    }
                }
            }
            __out.AppendLine(true); //131:1
            bool __tmp66_outputWritten = false;
            string __tmp67_line = "	static "; //132:1
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
            string __tmp69_line = "()"; //132:56
            if (!string.IsNullOrEmpty(__tmp69_line))
            {
                __out.Append(__tmp69_line);
                __tmp66_outputWritten = true;
            }
            if (__tmp66_outputWritten) __out.AppendLine(true);
            if (__tmp66_outputWritten)
            {
                __out.AppendLine(false); //132:58
            }
            __out.Append("	{"); //133:1
            __out.AppendLine(false); //133:3
            if (metaMetaModel) //134:4
            {
                bool __tmp71_outputWritten = false;
                string __tmp70Prefix = "		"; //135:1
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
                string __tmp73_line = ".instance.Create();"; //135:48
                if (!string.IsNullOrEmpty(__tmp73_line))
                {
                    __out.Append(__tmp73_line);
                    __tmp71_outputWritten = true;
                }
                if (__tmp71_outputWritten) __out.AppendLine(true);
                if (__tmp71_outputWritten)
                {
                    __out.AppendLine(false); //135:67
                }
                bool __tmp75_outputWritten = false;
                string __tmp74Prefix = "		"; //136:1
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
                string __tmp77_line = ".instance.EvaluateLazyValues();"; //136:48
                if (!string.IsNullOrEmpty(__tmp77_line))
                {
                    __out.Append(__tmp77_line);
                    __tmp75_outputWritten = true;
                }
                if (__tmp75_outputWritten) __out.AppendLine(true);
                if (__tmp75_outputWritten)
                {
                    __out.AppendLine(false); //136:79
                }
                bool __tmp79_outputWritten = false;
                string __tmp80_line = "		MetaMetaModel = "; //137:1
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
                string __tmp82_line = ".instance.MetaMetaModel.ToImmutable();"; //137:64
                if (!string.IsNullOrEmpty(__tmp82_line))
                {
                    __out.Append(__tmp82_line);
                    __tmp79_outputWritten = true;
                }
                if (__tmp79_outputWritten) __out.AppendLine(true);
                if (__tmp79_outputWritten)
                {
                    __out.AppendLine(false); //137:102
                }
            }
            else //138:4
            {
                bool __tmp84_outputWritten = false;
                string __tmp83Prefix = "		"; //139:1
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
                string __tmp86_line = ".instance.Create();"; //139:48
                if (!string.IsNullOrEmpty(__tmp86_line))
                {
                    __out.Append(__tmp86_line);
                    __tmp84_outputWritten = true;
                }
                if (__tmp84_outputWritten) __out.AppendLine(true);
                if (__tmp84_outputWritten)
                {
                    __out.AppendLine(false); //139:67
                }
                bool __tmp88_outputWritten = false;
                string __tmp87Prefix = "		"; //140:1
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
                string __tmp90_line = ".instance.EvaluateLazyValues();"; //140:48
                if (!string.IsNullOrEmpty(__tmp90_line))
                {
                    __out.Append(__tmp90_line);
                    __tmp88_outputWritten = true;
                }
                if (__tmp88_outputWritten) __out.AppendLine(true);
                if (__tmp88_outputWritten)
                {
                    __out.AppendLine(false); //140:79
                }
                bool __tmp92_outputWritten = false;
                string __tmp93_line = "		MetaModel = "; //141:1
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
                string __tmp95_line = ".instance.MetaModel.ToImmutable();"; //141:60
                if (!string.IsNullOrEmpty(__tmp95_line))
                {
                    __out.Append(__tmp95_line);
                    __tmp92_outputWritten = true;
                }
                if (__tmp92_outputWritten) __out.AppendLine(true);
                if (__tmp92_outputWritten)
                {
                    __out.AppendLine(false); //141:94
                }
            }
            bool __tmp97_outputWritten = false;
            string __tmp98_line = "		Model = "; //143:1
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
            string __tmp100_line = ".instance.Model.ToImmutable();"; //143:56
            if (!string.IsNullOrEmpty(__tmp100_line))
            {
                __out.Append(__tmp100_line);
                __tmp97_outputWritten = true;
            }
            if (__tmp97_outputWritten) __out.AppendLine(true);
            if (__tmp97_outputWritten)
            {
                __out.AppendLine(false); //143:86
            }
            __out.AppendLine(true); //144:1
            var __loop10_results = 
                (from __loop10_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //145:9
                from cst in __Enumerate((__loop10_var1).GetEnumerator()).OfType<MetaConstant>() //145:39
                select new { __loop10_var1 = __loop10_var1, cst = cst}
                ).ToList(); //145:4
            for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
            {
                var __tmp101 = __loop10_results[__loop10_iteration];
                var __loop10_var1 = __tmp101.__loop10_var1;
                var cst = __tmp101.cst;
                if (metaMetaModel) //146:5
                {
                    bool __tmp103_outputWritten = false;
                    string __tmp102Prefix = "		"; //147:1
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
                    string __tmp105_line = " = "; //147:55
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
                    string __tmp107_line = ".ToImmutable(Model);"; //147:114
                    if (!string.IsNullOrEmpty(__tmp107_line))
                    {
                        __out.Append(__tmp107_line);
                        __tmp103_outputWritten = true;
                    }
                    if (__tmp103_outputWritten) __out.AppendLine(true);
                    if (__tmp103_outputWritten)
                    {
                        __out.AppendLine(false); //147:134
                    }
                }
                else //148:5
                {
                    bool __tmp109_outputWritten = false;
                    string __tmp108Prefix = "		"; //149:1
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
                    string __tmp111_line = " = "; //149:55
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
                    string __tmp113_line = ".ToImmutable(Model);"; //149:114
                    if (!string.IsNullOrEmpty(__tmp113_line))
                    {
                        __out.Append(__tmp113_line);
                        __tmp109_outputWritten = true;
                    }
                    if (__tmp109_outputWritten) __out.AppendLine(true);
                    if (__tmp109_outputWritten)
                    {
                        __out.AppendLine(false); //149:134
                    }
                }
            }
            __out.AppendLine(true); //152:1
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //153:9
                from cls in __Enumerate((__loop11_var1).GetEnumerator()).OfType<MetaClass>() //153:39
                select new { __loop11_var1 = __loop11_var1, cls = cls}
                ).ToList(); //153:4
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp114 = __loop11_results[__loop11_iteration];
                var __loop11_var1 = __tmp114.__loop11_var1;
                var cls = __tmp114.cls;
                bool __tmp116_outputWritten = false;
                string __tmp115Prefix = "		"; //154:1
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
                string __tmp118_line = " = "; //154:55
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
                string __tmp120_line = ".ToImmutable(Model);"; //154:114
                if (!string.IsNullOrEmpty(__tmp120_line))
                {
                    __out.Append(__tmp120_line);
                    __tmp116_outputWritten = true;
                }
                if (__tmp116_outputWritten) __out.AppendLine(true);
                if (__tmp116_outputWritten)
                {
                    __out.AppendLine(false); //154:134
                }
                var __loop12_results = 
                    (from __loop12_var1 in __Enumerate((cls).GetEnumerator()) //155:10
                    from prop in __Enumerate((__loop12_var1.Properties).GetEnumerator()) //155:15
                    select new { __loop12_var1 = __loop12_var1, prop = prop}
                    ).ToList(); //155:5
                for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
                {
                    var __tmp121 = __loop12_results[__loop12_iteration];
                    var __loop12_var1 = __tmp121.__loop12_var1;
                    var prop = __tmp121.prop;
                    bool __tmp123_outputWritten = false;
                    string __tmp122Prefix = "		"; //156:1
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
                    string __tmp125_line = " = "; //156:59
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
                    string __tmp127_line = ".ToImmutable(Model);"; //156:122
                    if (!string.IsNullOrEmpty(__tmp127_line))
                    {
                        __out.Append(__tmp127_line);
                        __tmp123_outputWritten = true;
                    }
                    if (__tmp123_outputWritten) __out.AppendLine(true);
                    if (__tmp123_outputWritten)
                    {
                        __out.AppendLine(false); //156:142
                    }
                }
            }
            __out.AppendLine(true); //159:1
            bool __tmp129_outputWritten = false;
            string __tmp128Prefix = "		"; //160:1
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
            string __tmp131_line = ".initialized = true;"; //160:50
            if (!string.IsNullOrEmpty(__tmp131_line))
            {
                __out.Append(__tmp131_line);
                __tmp129_outputWritten = true;
            }
            if (__tmp129_outputWritten) __out.AppendLine(true);
            if (__tmp129_outputWritten)
            {
                __out.AppendLine(false); //160:70
            }
            __out.Append("	}"); //161:1
            __out.AppendLine(false); //161:3
            __out.Append("}"); //162:1
            __out.AppendLine(false); //162:2
            return __out.ToString();
        }

        public string GenerateMetaModelBuilderInstance(MetaModel model) //165:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //166:2
            bool metaMetaModel = IsMetaMetaModel(model); //167:2
            ImmutableList<ImmutableSymbol> symbolList = GetSymbolInstances(model); //168:2
            ImmutableDictionary<ImmutableSymbol,string> symbolNames = GetSymbolInstanceNames(model); //169:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //170:1
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
                __out.AppendLine(false); //170:61
            }
            __out.Append("{"); //171:1
            __out.AppendLine(false); //171:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	internal static "; //172:1
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
            string __tmp9_line = " instance = new "; //172:63
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
            string __tmp11_line = "();"; //172:124
            if (!string.IsNullOrEmpty(__tmp11_line))
            {
                __out.Append(__tmp11_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //172:127
            }
            __out.AppendLine(true); //173:1
            __out.Append("	private bool creating;"); //174:1
            __out.AppendLine(false); //174:24
            __out.Append("	private bool created;"); //175:1
            __out.AppendLine(false); //175:23
            if (metaMetaModel) //176:3
            {
                bool __tmp13_outputWritten = false;
                string __tmp14_line = "	internal "; //177:1
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
                string __tmp16_line = "MetaModelBuilder MetaMetaModel;"; //177:19
                if (!string.IsNullOrEmpty(__tmp16_line))
                {
                    __out.Append(__tmp16_line);
                    __tmp13_outputWritten = true;
                }
                if (__tmp13_outputWritten) __out.AppendLine(true);
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //177:50
                }
            }
            else //178:3
            {
                bool __tmp18_outputWritten = false;
                string __tmp19_line = "	internal "; //179:1
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
                string __tmp21_line = "MetaModelBuilder MetaModel;"; //179:19
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp18_outputWritten = true;
                }
                if (__tmp18_outputWritten) __out.AppendLine(true);
                if (__tmp18_outputWritten)
                {
                    __out.AppendLine(false); //179:46
                }
            }
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	internal "; //181:1
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
            string __tmp26_line = ".MutableModel Model;"; //181:30
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //181:50
            }
            if (!metaMetaModel) //182:3
            {
                bool __tmp28_outputWritten = false;
                string __tmp29_line = "	internal "; //183:1
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
                string __tmp31_line = ".MutableModelGroup ModelGroup;"; //183:30
                if (!string.IsNullOrEmpty(__tmp31_line))
                {
                    __out.Append(__tmp31_line);
                    __tmp28_outputWritten = true;
                }
                if (__tmp28_outputWritten) __out.AppendLine(true);
                if (__tmp28_outputWritten)
                {
                    __out.AppendLine(false); //183:60
                }
            }
            __out.AppendLine(true); //185:1
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //186:8
                from cst in __Enumerate((__loop13_var1).GetEnumerator()).OfType<MetaConstant>() //186:38
                select new { __loop13_var1 = __loop13_var1, cst = cst}
                ).ToList(); //186:3
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp32 = __loop13_results[__loop13_iteration];
                var __loop13_var1 = __tmp32.__loop13_var1;
                var cst = __tmp32.cst;
                bool __tmp34_outputWritten = false;
                string __tmp33Prefix = "	"; //187:1
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
                    __out.AppendLine(false); //187:30
                }
                if (metaMetaModel) //188:4
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "	internal "; //189:1
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
                    string __tmp40_line = " "; //189:58
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
                    string __tmp42_line = " = null;"; //189:109
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Append(__tmp42_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //189:117
                    }
                }
                else //190:4
                {
                    bool __tmp44_outputWritten = false;
                    string __tmp45_line = "	internal "; //191:1
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
                    string __tmp47_line = " "; //191:64
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
                    string __tmp49_line = " = null;"; //191:115
                    if (!string.IsNullOrEmpty(__tmp49_line))
                    {
                        __out.Append(__tmp49_line);
                        __tmp44_outputWritten = true;
                    }
                    if (__tmp44_outputWritten) __out.AppendLine(true);
                    if (__tmp44_outputWritten)
                    {
                        __out.AppendLine(false); //191:123
                    }
                }
            }
            __out.AppendLine(true); //194:1
            var __loop14_results = 
                (from symbol in __Enumerate((symbolList).GetEnumerator()) //195:8
                select new { symbol = symbol}
                ).ToList(); //195:3
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp50 = __loop14_results[__loop14_iteration];
                var symbol = __tmp50.symbol;
                bool __tmp52_outputWritten = false;
                string __tmp51Prefix = "	"; //196:1
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
                    __out.AppendLine(false); //196:80
                }
            }
            __out.AppendLine(true); //198:1
            bool __tmp55_outputWritten = false;
            string __tmp56_line = "	internal "; //199:1
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
            string __tmp58_line = "()"; //199:56
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Append(__tmp58_line);
                __tmp55_outputWritten = true;
            }
            if (__tmp55_outputWritten) __out.AppendLine(true);
            if (__tmp55_outputWritten)
            {
                __out.AppendLine(false); //199:58
            }
            __out.Append("	{"); //200:1
            __out.AppendLine(false); //200:3
            if (metaMetaModel) //201:4
            {
                bool __tmp60_outputWritten = false;
                string __tmp61_line = "		this.Model = new "; //202:1
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
                string __tmp63_line = ".MutableModel(\"MetaDslx.Core\");"; //202:39
                if (!string.IsNullOrEmpty(__tmp63_line))
                {
                    __out.Append(__tmp63_line);
                    __tmp60_outputWritten = true;
                }
                if (__tmp60_outputWritten) __out.AppendLine(true);
                if (__tmp60_outputWritten)
                {
                    __out.AppendLine(false); //202:70
                }
            }
            else //203:4
            {
                bool __tmp65_outputWritten = false;
                string __tmp66_line = "		this.ModelGroup = new "; //204:1
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
                string __tmp68_line = ".MutableModelGroup();"; //204:44
                if (!string.IsNullOrEmpty(__tmp68_line))
                {
                    __out.Append(__tmp68_line);
                    __tmp65_outputWritten = true;
                }
                if (__tmp65_outputWritten) __out.AppendLine(true);
                if (__tmp65_outputWritten)
                {
                    __out.AppendLine(false); //204:65
                }
                bool __tmp70_outputWritten = false;
                string __tmp71_line = "		this.ModelGroup.AddReference("; //205:1
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
                string __tmp73_line = ".MetaInstance.Model.ToMutable(true));"; //205:51
                if (!string.IsNullOrEmpty(__tmp73_line))
                {
                    __out.Append(__tmp73_line);
                    __tmp70_outputWritten = true;
                }
                if (__tmp70_outputWritten) __out.AppendLine(true);
                if (__tmp70_outputWritten)
                {
                    __out.AppendLine(false); //205:88
                }
                bool __tmp75_outputWritten = false;
                string __tmp76_line = "		this.Model = this.ModelGroup.CreateModel(\""; //206:1
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
                string __tmp78_line = "\");"; //206:65
                if (!string.IsNullOrEmpty(__tmp78_line))
                {
                    __out.Append(__tmp78_line);
                    __tmp75_outputWritten = true;
                }
                if (__tmp75_outputWritten) __out.AppendLine(true);
                if (__tmp75_outputWritten)
                {
                    __out.AppendLine(false); //206:68
                }
            }
            __out.Append("	}"); //208:1
            __out.AppendLine(false); //208:3
            __out.AppendLine(true); //209:1
            __out.Append("	internal void Create()"); //210:1
            __out.AppendLine(false); //210:24
            __out.Append("	{"); //211:1
            __out.AppendLine(false); //211:3
            __out.Append("		lock (this)"); //212:1
            __out.AppendLine(false); //212:14
            __out.Append("		{"); //213:1
            __out.AppendLine(false); //213:4
            __out.Append("			if (this.creating || this.created) return;"); //214:1
            __out.AppendLine(false); //214:46
            __out.Append("			this.creating = true;"); //215:1
            __out.AppendLine(false); //215:25
            __out.Append("		}"); //216:1
            __out.AppendLine(false); //216:4
            bool __tmp80_outputWritten = false;
            string __tmp79Prefix = "		"; //217:1
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
            string __tmp82_line = ".Implementation."; //217:55
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
            string __tmp84_line = "(this);"; //217:116
            if (!string.IsNullOrEmpty(__tmp84_line))
            {
                __out.Append(__tmp84_line);
                __tmp80_outputWritten = true;
            }
            if (__tmp80_outputWritten) __out.AppendLine(true);
            if (__tmp80_outputWritten)
            {
                __out.AppendLine(false); //217:123
            }
            __out.Append("		this.CreateSymbols();"); //218:1
            __out.AppendLine(false); //218:24
            __out.Append("		lock (this)"); //219:1
            __out.AppendLine(false); //219:14
            __out.Append("		{"); //220:1
            __out.AppendLine(false); //220:4
            __out.Append("			this.created = true;"); //221:1
            __out.AppendLine(false); //221:24
            __out.Append("		}"); //222:1
            __out.AppendLine(false); //222:4
            __out.Append("	}"); //223:1
            __out.AppendLine(false); //223:3
            __out.AppendLine(true); //224:1
            __out.Append("	internal void EvaluateLazyValues()"); //225:1
            __out.AppendLine(false); //225:36
            __out.Append("	{"); //226:1
            __out.AppendLine(false); //226:3
            __out.Append("		if (!this.created) return;"); //227:1
            __out.AppendLine(false); //227:29
            __out.Append("		this.Model.EvaluateLazyValues();"); //228:1
            __out.AppendLine(false); //228:35
            __out.Append("	}"); //229:1
            __out.AppendLine(false); //229:3
            __out.AppendLine(true); //230:1
            __out.Append("	private void CreateSymbols()"); //231:1
            __out.AppendLine(false); //231:30
            __out.Append("	{"); //232:1
            __out.AppendLine(false); //232:3
            bool __tmp86_outputWritten = false;
            string __tmp85Prefix = "		"; //233:1
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
            string __tmp88_line = ".MetaFactory factory = new "; //233:22
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
            string __tmp90_line = ".MetaFactory(this.Model, "; //233:68
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
            string __tmp92_line = ".ModelFactoryFlags.DontMakeSymbolsCreated);"; //233:112
            if (!string.IsNullOrEmpty(__tmp92_line))
            {
                __out.Append(__tmp92_line);
                __tmp86_outputWritten = true;
            }
            if (__tmp86_outputWritten) __out.AppendLine(true);
            if (__tmp86_outputWritten)
            {
                __out.AppendLine(false); //233:155
            }
            __out.AppendLine(true); //234:1
            var __loop15_results = 
                (from symbol in __Enumerate((symbolList).GetEnumerator()) //235:9
                select new { symbol = symbol}
                ).ToList(); //235:4
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                var __tmp93 = __loop15_results[__loop15_iteration];
                var symbol = __tmp93.symbol;
                bool __tmp95_outputWritten = false;
                string __tmp94Prefix = "		"; //236:1
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
                    __out.AppendLine(false); //236:70
                }
            }
            __out.AppendLine(true); //238:1
            var __loop16_results = 
                (from symbol in __Enumerate((symbolList).GetEnumerator()) //239:9
                select new { symbol = symbol}
                ).ToList(); //239:4
            for (int __loop16_iteration = 0; __loop16_iteration < __loop16_results.Count; ++__loop16_iteration)
            {
                var __tmp97 = __loop16_results[__loop16_iteration];
                var symbol = __tmp97.symbol;
                bool __tmp99_outputWritten = false;
                string __tmp98Prefix = "		"; //240:1
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
                    __out.AppendLine(false); //240:80
                }
            }
            __out.AppendLine(true); //242:1
            __out.Append("		foreach (global::MetaDslx.Core.MutableSymbol symbol in this.Model.Symbols)"); //243:1
            __out.AppendLine(false); //243:77
            __out.Append("		{"); //244:1
            __out.AppendLine(false); //244:4
            __out.Append("			symbol.MMakeCreated();"); //245:1
            __out.AppendLine(false); //245:26
            __out.Append("		}"); //246:1
            __out.AppendLine(false); //246:4
            __out.Append("	}"); //247:1
            __out.AppendLine(false); //247:3
            __out.Append("}"); //248:1
            __out.AppendLine(false); //248:2
            return __out.ToString();
        }

        public string GenerateSymbolInstanceDeclaration(MetaModel model, bool metaMetaModel, ImmutableSymbol symbol, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //251:1
        {
            StringBuilder __out = new StringBuilder();
            if (symbol != null && symbol.MMetaClass != null && symbolNames.ContainsKey(symbol)) //252:2
            {
                string name = symbolNames[symbol]; //253:3
                if (metaMetaModel) //254:3
                {
                    if (name.StartsWith("__")) //255:4
                    {
                        bool __tmp2_outputWritten = false;
                        string __tmp3_line = "private "; //256:1
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
                        string __tmp5_line = " "; //256:65
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
                        string __tmp7_line = ";"; //256:72
                        if (!string.IsNullOrEmpty(__tmp7_line))
                        {
                            __out.Append(__tmp7_line);
                            __tmp2_outputWritten = true;
                        }
                        if (__tmp2_outputWritten) __out.AppendLine(true);
                        if (__tmp2_outputWritten)
                        {
                            __out.AppendLine(false); //256:73
                        }
                    }
                    else //257:4
                    {
                        bool __tmp9_outputWritten = false;
                        string __tmp10_line = "internal "; //258:1
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
                        string __tmp12_line = " "; //258:66
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
                        string __tmp14_line = ";"; //258:73
                        if (!string.IsNullOrEmpty(__tmp14_line))
                        {
                            __out.Append(__tmp14_line);
                            __tmp9_outputWritten = true;
                        }
                        if (__tmp9_outputWritten) __out.AppendLine(true);
                        if (__tmp9_outputWritten)
                        {
                            __out.AppendLine(false); //258:74
                        }
                    }
                }
                else //260:3
                {
                    if (name.StartsWith("__")) //261:4
                    {
                        bool __tmp16_outputWritten = false;
                        string __tmp17_line = "private "; //262:1
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
                        string __tmp19_line = " "; //262:71
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
                        string __tmp21_line = ";"; //262:78
                        if (!string.IsNullOrEmpty(__tmp21_line))
                        {
                            __out.Append(__tmp21_line);
                            __tmp16_outputWritten = true;
                        }
                        if (__tmp16_outputWritten) __out.AppendLine(true);
                        if (__tmp16_outputWritten)
                        {
                            __out.AppendLine(false); //262:79
                        }
                    }
                    else //263:4
                    {
                        bool __tmp23_outputWritten = false;
                        string __tmp24_line = "internal "; //264:1
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
                        string __tmp26_line = " "; //264:72
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
                        string __tmp28_line = ";"; //264:79
                        if (!string.IsNullOrEmpty(__tmp28_line))
                        {
                            __out.Append(__tmp28_line);
                            __tmp23_outputWritten = true;
                        }
                        if (__tmp23_outputWritten) __out.AppendLine(true);
                        if (__tmp23_outputWritten)
                        {
                            __out.AppendLine(false); //264:80
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateSymbolInstance(MetaModel model, bool metaMetaModel, ImmutableSymbol symbol, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //270:1
        {
            StringBuilder __out = new StringBuilder();
            if (symbol != null && symbol.MMetaClass != null && symbolNames.ContainsKey(symbol)) //271:2
            {
                string name = symbolNames[symbol]; //272:3
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
                string __tmp4_line = " = factory."; //273:7
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
                string __tmp6_line = "();"; //273:76
                if (!string.IsNullOrEmpty(__tmp6_line))
                {
                    __out.Append(__tmp6_line);
                    __tmp2_outputWritten = true;
                }
                if (__tmp2_outputWritten) __out.AppendLine(true);
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //273:79
                }
                if (symbol is MetaModel) //274:3
                {
                    if (metaMetaModel) //275:4
                    {
                        bool __tmp8_outputWritten = false;
                        string __tmp9_line = "MetaMetaModel = "; //276:1
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
                        string __tmp11_line = ";"; //276:23
                        if (!string.IsNullOrEmpty(__tmp11_line))
                        {
                            __out.Append(__tmp11_line);
                            __tmp8_outputWritten = true;
                        }
                        if (__tmp8_outputWritten) __out.AppendLine(true);
                        if (__tmp8_outputWritten)
                        {
                            __out.AppendLine(false); //276:24
                        }
                    }
                    else //277:4
                    {
                        bool __tmp13_outputWritten = false;
                        string __tmp14_line = "MetaModel = "; //278:1
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
                        string __tmp16_line = ";"; //278:19
                        if (!string.IsNullOrEmpty(__tmp16_line))
                        {
                            __out.Append(__tmp16_line);
                            __tmp13_outputWritten = true;
                        }
                        if (__tmp13_outputWritten) __out.AppendLine(true);
                        if (__tmp13_outputWritten)
                        {
                            __out.AppendLine(false); //278:20
                        }
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateSymbolInstanceProperties(MetaModel model, bool metaMetaModel, ImmutableSymbol symbol, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //284:1
        {
            StringBuilder __out = new StringBuilder();
            if (symbol != null && symbol.MMetaClass != null && symbolNames.ContainsKey(symbol)) //285:2
            {
                var __loop17_results = 
                    (from __loop17_var1 in __Enumerate((symbol).GetEnumerator()) //286:8
                    from prop in __Enumerate((__loop17_var1.MProperties).GetEnumerator()) //286:16
                    where !prop.IsDerived && !prop.IsDerivedUnion //286:33
                    select new { __loop17_var1 = __loop17_var1, prop = prop}
                    ).ToList(); //286:3
                for (int __loop17_iteration = 0; __loop17_iteration < __loop17_results.Count; ++__loop17_iteration)
                {
                    var __tmp1 = __loop17_results[__loop17_iteration];
                    var __loop17_var1 = __tmp1.__loop17_var1;
                    var prop = __tmp1.prop;
                    object propValue = symbol.MGet(prop); //287:4
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
                        __out.AppendLine(false); //288:98
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateSymbolInstancePropertyValue(MetaModel model, bool metaMetaModel, ImmutableSymbol symbol, ModelProperty prop, object value, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //293:1
        {
            StringBuilder __out = new StringBuilder();
            string name = symbolNames[symbol]; //294:2
            ImmutableSymbol valueSymbol = value as ImmutableSymbol; //295:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //296:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //297:2
            if (value == null) //298:2
            {
                if (prop.MutableTypeInfo.Type != null && prop.MutableTypeInfo.Type.IsClass) //299:3
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
                    string __tmp4_line = "."; //300:7
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
                    string __tmp6_line = " = null;"; //300:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //300:27
                    }
                }
                else //301:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //302:1
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
                    string __tmp11_line = "."; //302:10
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
                    string __tmp13_line = " = null;"; //302:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Append(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //302:30
                    }
                }
            }
            else if (value is string) //304:2
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
                string __tmp17_line = "."; //305:7
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
                string __tmp19_line = " = \""; //305:19
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
                string __tmp21_line = "\";"; //305:50
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //305:52
                }
            }
            else if (value is bool) //306:2
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
                string __tmp25_line = "."; //307:7
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
                string __tmp27_line = " = "; //307:19
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
                string __tmp29_line = ";"; //307:50
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Append(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //307:51
                }
            }
            else if (value.GetType().IsPrimitive) //308:2
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
                string __tmp33_line = "."; //309:7
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
                string __tmp35_line = " = "; //309:19
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
                string __tmp37_line = ";"; //309:40
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //309:41
                }
            }
            else if (value is Enum) //310:2
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
                string __tmp41_line = "."; //311:7
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
                string __tmp43_line = " = "; //311:19
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
                string __tmp45_line = ";"; //311:51
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Append(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //311:52
                }
            }
            else if (value is MetaPrimitiveType) //312:2
            {
                if (metaMetaModel) //313:3
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
                    string __tmp49_line = "."; //314:7
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
                    string __tmp51_line = "Lazy = () => "; //314:19
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
                    string __tmp53_line = ";"; //314:80
                    if (!string.IsNullOrEmpty(__tmp53_line))
                    {
                        __out.Append(__tmp53_line);
                        __tmp47_outputWritten = true;
                    }
                    if (__tmp47_outputWritten) __out.AppendLine(true);
                    if (__tmp47_outputWritten)
                    {
                        __out.AppendLine(false); //314:81
                    }
                }
                else //315:3
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
                    string __tmp57_line = "."; //316:7
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
                    string __tmp59_line = "Lazy = () => "; //316:19
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
                    string __tmp61_line = ".ToMutable();"; //316:113
                    if (!string.IsNullOrEmpty(__tmp61_line))
                    {
                        __out.Append(__tmp61_line);
                        __tmp55_outputWritten = true;
                    }
                    if (__tmp55_outputWritten) __out.AppendLine(true);
                    if (__tmp55_outputWritten)
                    {
                        __out.AppendLine(false); //316:126
                    }
                }
            }
            else if (valueSymbol != null && symbolNames.ContainsKey(valueSymbol)) //318:2
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
                string __tmp65_line = "."; //319:7
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
                string __tmp67_line = "Lazy = () => "; //319:19
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
                string __tmp69_line = ";"; //319:58
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Append(__tmp69_line);
                    __tmp63_outputWritten = true;
                }
                if (__tmp63_outputWritten) __out.AppendLine(true);
                if (__tmp63_outputWritten)
                {
                    __out.AppendLine(false); //319:59
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //320:2
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
                string __tmp73_line = "."; //321:7
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
                string __tmp75_line = "Lazy = () => "; //321:19
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
                string __tmp77_line = ";"; //321:100
                if (!string.IsNullOrEmpty(__tmp77_line))
                {
                    __out.Append(__tmp77_line);
                    __tmp71_outputWritten = true;
                }
                if (__tmp71_outputWritten) __out.AppendLine(true);
                if (__tmp71_outputWritten)
                {
                    __out.AppendLine(false); //321:101
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //322:2
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
                string __tmp81_line = "."; //323:7
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
                string __tmp83_line = "Lazy = () => "; //323:19
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
                string __tmp85_line = ";"; //323:104
                if (!string.IsNullOrEmpty(__tmp85_line))
                {
                    __out.Append(__tmp85_line);
                    __tmp79_outputWritten = true;
                }
                if (__tmp79_outputWritten) __out.AppendLine(true);
                if (__tmp79_outputWritten)
                {
                    __out.AppendLine(false); //323:105
                }
            }
            else if (valueCollection != null) //324:2
            {
                var __loop18_results = 
                    (from cvalue in __Enumerate((valueCollection).GetEnumerator()) //325:8
                    select new { cvalue = cvalue}
                    ).ToList(); //325:3
                for (int __loop18_iteration = 0; __loop18_iteration < __loop18_results.Count; ++__loop18_iteration)
                {
                    var __tmp86 = __loop18_results[__loop18_iteration];
                    var cvalue = __tmp86.cvalue;
                    bool __tmp88_outputWritten = false;
                    StringBuilder __tmp89 = new StringBuilder();
                    __tmp89.Append(GenerateSymbolInstancePropertyCollectionValue(model, metaMetaModel, symbol, prop, cvalue, symbolNames));
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
                        __out.AppendLine(false); //326:105
                    }
                }
            }
            else //328:2
            {
                bool __tmp91_outputWritten = false;
                string __tmp92_line = "// TODO: "; //329:1
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
                string __tmp94_line = "."; //329:16
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
                    __out.AppendLine(false); //329:28
                }
            }
            return __out.ToString();
        }

        public string GenerateSymbolInstancePropertyCollectionValue(MetaModel model, bool metaMetaModel, ImmutableSymbol symbol, ModelProperty prop, object value, ImmutableDictionary<ImmutableSymbol,string> symbolNames) //333:1
        {
            StringBuilder __out = new StringBuilder();
            string name = symbolNames[symbol]; //334:2
            ImmutableSymbol valueSymbol = value as ImmutableSymbol; //335:2
            MetaDeclaration valueDecl = value as MetaDeclaration; //336:2
            IEnumerable<object> valueCollection = value as IEnumerable<object>; //337:2
            if (value == null) //338:2
            {
                if (prop.MutableTypeInfo.Type != null && prop.MutableTypeInfo.Type.IsClass) //339:3
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
                    string __tmp4_line = "."; //340:7
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
                    string __tmp6_line = ".Add(null);"; //340:19
                    if (!string.IsNullOrEmpty(__tmp6_line))
                    {
                        __out.Append(__tmp6_line);
                        __tmp2_outputWritten = true;
                    }
                    if (__tmp2_outputWritten) __out.AppendLine(true);
                    if (__tmp2_outputWritten)
                    {
                        __out.AppendLine(false); //340:30
                    }
                }
                else //341:3
                {
                    bool __tmp8_outputWritten = false;
                    string __tmp9_line = "// "; //342:1
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
                    string __tmp11_line = "."; //342:10
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
                    string __tmp13_line = ".Add(null);"; //342:22
                    if (!string.IsNullOrEmpty(__tmp13_line))
                    {
                        __out.Append(__tmp13_line);
                        __tmp8_outputWritten = true;
                    }
                    if (__tmp8_outputWritten) __out.AppendLine(true);
                    if (__tmp8_outputWritten)
                    {
                        __out.AppendLine(false); //342:33
                    }
                }
            }
            else if (value is string) //344:2
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
                string __tmp17_line = "."; //345:7
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
                string __tmp19_line = ".Add(\""; //345:19
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
                string __tmp21_line = "\");"; //345:52
                if (!string.IsNullOrEmpty(__tmp21_line))
                {
                    __out.Append(__tmp21_line);
                    __tmp15_outputWritten = true;
                }
                if (__tmp15_outputWritten) __out.AppendLine(true);
                if (__tmp15_outputWritten)
                {
                    __out.AppendLine(false); //345:55
                }
            }
            else if (value is bool) //346:2
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
                string __tmp25_line = "."; //347:7
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
                string __tmp27_line = ".Add("; //347:19
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
                string __tmp29_line = ");"; //347:52
                if (!string.IsNullOrEmpty(__tmp29_line))
                {
                    __out.Append(__tmp29_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //347:54
                }
            }
            else if (value.GetType().IsPrimitive) //348:2
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
                string __tmp33_line = "."; //349:7
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
                string __tmp35_line = ".Add("; //349:19
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
                string __tmp37_line = ");"; //349:42
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp31_outputWritten = true;
                }
                if (__tmp31_outputWritten) __out.AppendLine(true);
                if (__tmp31_outputWritten)
                {
                    __out.AppendLine(false); //349:44
                }
            }
            else if (value is Enum) //350:2
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
                string __tmp41_line = "."; //351:7
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
                string __tmp43_line = ".Add("; //351:19
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
                string __tmp45_line = ");"; //351:53
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Append(__tmp45_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //351:55
                }
            }
            else if (value is MetaPrimitiveType) //352:2
            {
                if (metaMetaModel) //353:3
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
                    string __tmp49_line = "."; //354:7
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
                    string __tmp51_line = ".AddLazy(() => "; //354:19
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
                    string __tmp53_line = ");"; //354:82
                    if (!string.IsNullOrEmpty(__tmp53_line))
                    {
                        __out.Append(__tmp53_line);
                        __tmp47_outputWritten = true;
                    }
                    if (__tmp47_outputWritten) __out.AppendLine(true);
                    if (__tmp47_outputWritten)
                    {
                        __out.AppendLine(false); //354:84
                    }
                }
                else //355:3
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
                    string __tmp57_line = "."; //356:7
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
                    string __tmp59_line = ".AddLazy(() => "; //356:19
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
                    string __tmp61_line = ".ToMutable());"; //356:115
                    if (!string.IsNullOrEmpty(__tmp61_line))
                    {
                        __out.Append(__tmp61_line);
                        __tmp55_outputWritten = true;
                    }
                    if (__tmp55_outputWritten) __out.AppendLine(true);
                    if (__tmp55_outputWritten)
                    {
                        __out.AppendLine(false); //356:129
                    }
                }
            }
            else if (valueSymbol != null && symbolNames.ContainsKey(valueSymbol)) //358:2
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
                string __tmp65_line = "."; //359:7
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
                string __tmp67_line = ".AddLazy(() => "; //359:19
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
                string __tmp69_line = ");"; //359:60
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Append(__tmp69_line);
                    __tmp63_outputWritten = true;
                }
                if (__tmp63_outputWritten) __out.AppendLine(true);
                if (__tmp63_outputWritten)
                {
                    __out.AppendLine(false); //359:62
                }
            }
            else if (valueDecl != null && valueDecl is MetaType) //360:2
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
                string __tmp73_line = "."; //361:7
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
                string __tmp75_line = ".AddLazy(() => "; //361:19
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
                string __tmp77_line = ");"; //361:102
                if (!string.IsNullOrEmpty(__tmp77_line))
                {
                    __out.Append(__tmp77_line);
                    __tmp71_outputWritten = true;
                }
                if (__tmp71_outputWritten) __out.AppendLine(true);
                if (__tmp71_outputWritten)
                {
                    __out.AppendLine(false); //361:104
                }
            }
            else if (valueDecl != null && valueDecl is MetaConstant) //362:2
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
                string __tmp81_line = "."; //363:7
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
                string __tmp83_line = ".AddLazy(() => "; //363:19
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
                string __tmp85_line = ");"; //363:106
                if (!string.IsNullOrEmpty(__tmp85_line))
                {
                    __out.Append(__tmp85_line);
                    __tmp79_outputWritten = true;
                }
                if (__tmp79_outputWritten) __out.AppendLine(true);
                if (__tmp79_outputWritten)
                {
                    __out.AppendLine(false); //363:108
                }
            }
            else //364:2
            {
                bool __tmp87_outputWritten = false;
                string __tmp88_line = "// TODO: "; //365:1
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
                string __tmp90_line = "."; //365:16
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
                    __out.AppendLine(false); //365:28
                }
            }
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //369:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //370:1
            __out.AppendLine(false); //370:14
            __out.Append("/// Factory class for creating instances of model elements."); //371:1
            __out.AppendLine(false); //371:60
            __out.Append("/// </summary>"); //372:1
            __out.AppendLine(false); //372:15
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //373:1
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
            string __tmp5_line = " : "; //373:51
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
            string __tmp7_line = ".ModelFactory"; //373:73
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //373:86
            }
            __out.Append("{"); //374:1
            __out.AppendLine(false); //374:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public "; //375:1
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
            string __tmp12_line = "("; //375:46
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
            string __tmp14_line = ".MutableModel model, "; //375:66
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
            string __tmp16_line = ".ModelFactoryFlags flags = "; //375:106
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
            string __tmp18_line = ".ModelFactoryFlags.None)"; //375:152
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Append(__tmp18_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //375:176
            }
            __out.Append("		: base(model, flags)"); //376:1
            __out.AppendLine(false); //376:23
            __out.Append("	{"); //377:1
            __out.AppendLine(false); //377:3
            bool __tmp20_outputWritten = false;
            string __tmp19Prefix = "		"; //378:1
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
            string __tmp22_line = ".Initialize();"; //378:43
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Append(__tmp22_line);
                __tmp20_outputWritten = true;
            }
            if (__tmp20_outputWritten) __out.AppendLine(true);
            if (__tmp20_outputWritten)
            {
                __out.AppendLine(false); //378:57
            }
            __out.Append("	}"); //379:1
            __out.AppendLine(false); //379:3
            __out.AppendLine(true); //380:1
            bool __tmp24_outputWritten = false;
            string __tmp25_line = "	public override "; //381:1
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
            string __tmp27_line = ".MutableSymbol Create(string type)"; //381:37
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Append(__tmp27_line);
                __tmp24_outputWritten = true;
            }
            if (__tmp24_outputWritten) __out.AppendLine(true);
            if (__tmp24_outputWritten)
            {
                __out.AppendLine(false); //381:71
            }
            __out.Append("	{"); //382:1
            __out.AppendLine(false); //382:3
            __out.Append("		switch (type)"); //383:1
            __out.AppendLine(false); //383:16
            __out.Append("		{"); //384:1
            __out.AppendLine(false); //384:4
            var __loop19_results = 
                (from __loop19_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //385:10
                from cls in __Enumerate((__loop19_var1).GetEnumerator()).OfType<MetaClass>() //385:40
                select new { __loop19_var1 = __loop19_var1, cls = cls}
                ).ToList(); //385:5
            for (int __loop19_iteration = 0; __loop19_iteration < __loop19_results.Count; ++__loop19_iteration)
            {
                var __tmp28 = __loop19_results[__loop19_iteration];
                var __loop19_var1 = __tmp28.__loop19_var1;
                var cls = __tmp28.cls;
                if (!cls.IsAbstract) //386:6
                {
                    bool __tmp30_outputWritten = false;
                    string __tmp31_line = "			case \""; //387:1
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
                    string __tmp33_line = "\": return this."; //387:33
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
                    string __tmp35_line = "();"; //387:71
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Append(__tmp35_line);
                        __tmp30_outputWritten = true;
                    }
                    if (__tmp30_outputWritten) __out.AppendLine(true);
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //387:74
                    }
                }
            }
            __out.Append("			default:"); //390:1
            __out.AppendLine(false); //390:12
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "				throw new "; //391:1
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
            string __tmp40_line = ".ModelException(global::MetaDslx.Compiler.Diagnostics.Location.None, new global::MetaDslx.Compiler.Diagnostics.DiagnosticInfo("; //391:34
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
            string __tmp42_line = ".ModelErrorCode.ERR_UnknownTypeName, type));"; //391:179
            if (!string.IsNullOrEmpty(__tmp42_line))
            {
                __out.Append(__tmp42_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //391:223
            }
            __out.Append("		}"); //392:1
            __out.AppendLine(false); //392:4
            __out.Append("	}"); //393:1
            __out.AppendLine(false); //393:3
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //394:8
                from cls in __Enumerate((__loop20_var1).GetEnumerator()).OfType<MetaClass>() //394:38
                select new { __loop20_var1 = __loop20_var1, cls = cls}
                ).ToList(); //394:3
            for (int __loop20_iteration = 0; __loop20_iteration < __loop20_results.Count; ++__loop20_iteration)
            {
                var __tmp43 = __loop20_results[__loop20_iteration];
                var __loop20_var1 = __tmp43.__loop20_var1;
                var cls = __tmp43.cls;
                if (!cls.IsAbstract) //395:4
                {
                    __out.AppendLine(true); //396:1
                    __out.Append("	/// <summary>"); //397:1
                    __out.AppendLine(false); //397:15
                    bool __tmp45_outputWritten = false;
                    string __tmp46_line = "	/// Creates a new instance of "; //398:1
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
                    string __tmp48_line = "."; //398:55
                    if (!string.IsNullOrEmpty(__tmp48_line))
                    {
                        __out.Append(__tmp48_line);
                        __tmp45_outputWritten = true;
                    }
                    if (__tmp45_outputWritten) __out.AppendLine(true);
                    if (__tmp45_outputWritten)
                    {
                        __out.AppendLine(false); //398:56
                    }
                    __out.Append("	/// </summary>"); //399:1
                    __out.AppendLine(false); //399:16
                    bool __tmp50_outputWritten = false;
                    string __tmp51_line = "	public "; //400:1
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
                    string __tmp53_line = " "; //400:51
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
                    string __tmp55_line = "()"; //400:100
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Append(__tmp55_line);
                        __tmp50_outputWritten = true;
                    }
                    if (__tmp50_outputWritten) __out.AppendLine(true);
                    if (__tmp50_outputWritten)
                    {
                        __out.AppendLine(false); //400:102
                    }
                    __out.Append("	{"); //401:1
                    __out.AppendLine(false); //401:3
                    bool __tmp57_outputWritten = false;
                    string __tmp56Prefix = "		"; //402:1
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
                    string __tmp59_line = ".MutableSymbol symbol = this.CreateSymbol(new "; //402:22
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
                    string __tmp61_line = "());"; //402:105
                    if (!string.IsNullOrEmpty(__tmp61_line))
                    {
                        __out.Append(__tmp61_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //402:109
                    }
                    bool __tmp63_outputWritten = false;
                    string __tmp64_line = "		return ("; //403:1
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
                    string __tmp66_line = ")symbol;"; //403:53
                    if (!string.IsNullOrEmpty(__tmp66_line))
                    {
                        __out.Append(__tmp66_line);
                        __tmp63_outputWritten = true;
                    }
                    if (__tmp63_outputWritten) __out.AppendLine(true);
                    if (__tmp63_outputWritten)
                    {
                        __out.AppendLine(false); //403:61
                    }
                    __out.Append("	}"); //404:1
                    __out.AppendLine(false); //404:3
                }
            }
            __out.Append("}"); //407:1
            __out.AppendLine(false); //407:2
            __out.AppendLine(true); //408:1
            return __out.ToString();
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //411:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //412:2
            bool metaMetaModel = IsMetaMetaModel(model); //413:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public static class "; //414:1
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
                __out.AppendLine(false); //414:61
            }
            __out.Append("{"); //415:1
            __out.AppendLine(false); //415:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	private static global::System.Collections.Generic.List<"; //416:1
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
            string __tmp9_line = ".ModelProperty> properties;"; //416:76
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //416:103
            }
            __out.AppendLine(true); //417:1
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	static "; //418:1
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
            string __tmp14_line = "()"; //418:49
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //418:51
            }
            __out.Append("	{"); //419:1
            __out.AppendLine(false); //419:3
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "		properties = new global::System.Collections.Generic.List<"; //420:1
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
            string __tmp19_line = ".ModelProperty>();"; //420:79
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //420:97
            }
            var __loop21_results = 
                (from __loop21_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //421:9
                from cls in __Enumerate((__loop21_var1).GetEnumerator()).OfType<MetaClass>() //421:39
                select new { __loop21_var1 = __loop21_var1, cls = cls}
                ).ToList(); //421:4
            for (int __loop21_iteration = 0; __loop21_iteration < __loop21_results.Count; ++__loop21_iteration)
            {
                var __tmp20 = __loop21_results[__loop21_iteration];
                var __loop21_var1 = __tmp20.__loop21_var1;
                var cls = __tmp20.cls;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "		"; //422:1
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
                string __tmp24_line = ".Initialize();"; //422:48
                if (!string.IsNullOrEmpty(__tmp24_line))
                {
                    __out.Append(__tmp24_line);
                    __tmp22_outputWritten = true;
                }
                if (__tmp22_outputWritten) __out.AppendLine(true);
                if (__tmp22_outputWritten)
                {
                    __out.AppendLine(false); //422:62
                }
            }
            var __loop22_results = 
                (from __loop22_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //424:9
                from cls in __Enumerate((__loop22_var1).GetEnumerator()).OfType<MetaClass>() //424:39
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //424:62
                select new { __loop22_var1 = __loop22_var1, cls = cls, prop = prop}
                ).ToList(); //424:4
            for (int __loop22_iteration = 0; __loop22_iteration < __loop22_results.Count; ++__loop22_iteration)
            {
                var __tmp25 = __loop22_results[__loop22_iteration];
                var __loop22_var1 = __tmp25.__loop22_var1;
                var cls = __tmp25.cls;
                var prop = __tmp25.prop;
                bool __tmp27_outputWritten = false;
                string __tmp28_line = "		properties.Add("; //425:1
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
                string __tmp30_line = ");"; //425:73
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Append(__tmp30_line);
                    __tmp27_outputWritten = true;
                }
                if (__tmp27_outputWritten) __out.AppendLine(true);
                if (__tmp27_outputWritten)
                {
                    __out.AppendLine(false); //425:75
                }
            }
            __out.Append("	}"); //427:1
            __out.AppendLine(false); //427:3
            __out.AppendLine(true); //428:1
            __out.Append("	public static void Initialize()"); //429:1
            __out.AppendLine(false); //429:33
            __out.Append("	{"); //430:1
            __out.AppendLine(false); //430:3
            __out.Append("	}"); //431:1
            __out.AppendLine(false); //431:3
            __out.AppendLine(true); //432:1
            bool __tmp32_outputWritten = false;
            string __tmp33_line = "	public const string Uri = \""; //433:1
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
            string __tmp35_line = "\";"; //433:40
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Append(__tmp35_line);
                __tmp32_outputWritten = true;
            }
            if (__tmp32_outputWritten) __out.AppendLine(true);
            if (__tmp32_outputWritten)
            {
                __out.AppendLine(false); //433:42
            }
            var __loop23_results = 
                (from __loop23_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //434:8
                from cls in __Enumerate((__loop23_var1).GetEnumerator()).OfType<MetaClass>() //434:38
                select new { __loop23_var1 = __loop23_var1, cls = cls}
                ).ToList(); //434:3
            for (int __loop23_iteration = 0; __loop23_iteration < __loop23_results.Count; ++__loop23_iteration)
            {
                var __tmp36 = __loop23_results[__loop23_iteration];
                var __loop23_var1 = __tmp36.__loop23_var1;
                var cls = __tmp36.cls;
                __out.AppendLine(true); //435:1
                bool __tmp38_outputWritten = false;
                string __tmp37Prefix = "	"; //436:1
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
                    __out.AppendLine(false); //436:39
                }
            }
            __out.Append("}"); //438:1
            __out.AppendLine(false); //438:2
            return __out.ToString();
        }

        public string GenerateDescriptorClass(MetaModel model, MetaClass cls) //441:1
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
                __out.AppendLine(false); //442:29
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
                __out.AppendLine(false); //443:27
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
            string __tmp10_line = ".ModelSymbolDescriptorAttribute(typeof("; //444:24
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
            string __tmp12_line = "), typeof("; //444:112
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
            string __tmp14_line = ")"; //444:169
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
            string __tmp16_line = ")"; //444:206
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
                __out.AppendLine(false); //444:212
            }
            bool __tmp19_outputWritten = false;
            string __tmp20_line = "public static class "; //445:1
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
                __out.AppendLine(false); //445:66
            }
            __out.Append("{"); //446:1
            __out.AppendLine(false); //446:2
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	private static "; //447:1
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
            string __tmp26_line = ".ModelSymbolInfo modelSymbolInfo;"; //447:36
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //447:69
            }
            __out.AppendLine(true); //448:1
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "	static "; //449:1
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
            string __tmp31_line = "()"; //449:54
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Append(__tmp31_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //449:56
            }
            __out.Append("	{"); //450:1
            __out.AppendLine(false); //450:3
            bool __tmp33_outputWritten = false;
            string __tmp34_line = "		modelSymbolInfo = "; //451:1
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
            string __tmp36_line = ".ModelSymbolInfo.GetDescriptorSymbolInfo(typeof("; //451:40
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
            string __tmp38_line = "));"; //451:133
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Append(__tmp38_line);
                __tmp33_outputWritten = true;
            }
            if (__tmp33_outputWritten) __out.AppendLine(true);
            if (__tmp33_outputWritten)
            {
                __out.AppendLine(false); //451:136
            }
            __out.Append("	}"); //452:1
            __out.AppendLine(false); //452:3
            __out.AppendLine(true); //453:1
            __out.Append("	internal static void Initialize()"); //454:1
            __out.AppendLine(false); //454:35
            __out.Append("	{"); //455:1
            __out.AppendLine(false); //455:3
            __out.Append("	}"); //456:1
            __out.AppendLine(false); //456:3
            __out.AppendLine(true); //457:1
            bool __tmp40_outputWritten = false;
            string __tmp41_line = "	public static "; //458:1
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
            string __tmp43_line = ".ModelSymbolInfo SymbolInfo"; //458:35
            if (!string.IsNullOrEmpty(__tmp43_line))
            {
                __out.Append(__tmp43_line);
                __tmp40_outputWritten = true;
            }
            if (__tmp40_outputWritten) __out.AppendLine(true);
            if (__tmp40_outputWritten)
            {
                __out.AppendLine(false); //458:62
            }
            __out.Append("	{"); //459:1
            __out.AppendLine(false); //459:3
            __out.Append("		get { return modelSymbolInfo; }"); //460:1
            __out.AppendLine(false); //460:34
            __out.Append("	}"); //461:1
            __out.AppendLine(false); //461:3
            __out.AppendLine(true); //462:1
            if (cls.Name == "MetaClass") //463:3
            {
                bool __tmp45_outputWritten = false;
                string __tmp46_line = "	public static "; //464:1
                if (!string.IsNullOrEmpty(__tmp46_line))
                {
                    __out.Append(__tmp46_line);
                    __tmp45_outputWritten = true;
                }
                StringBuilder __tmp47 = new StringBuilder();
                __tmp47.Append(Properties.MetaNs);
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
                string __tmp48_line = ".MetaClass _MetaClass"; //464:35
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Append(__tmp48_line);
                    __tmp45_outputWritten = true;
                }
                if (__tmp45_outputWritten) __out.AppendLine(true);
                if (__tmp45_outputWritten)
                {
                    __out.AppendLine(false); //464:56
                }
            }
            else //465:3
            {
                bool __tmp50_outputWritten = false;
                string __tmp51_line = "	public static "; //466:1
                if (!string.IsNullOrEmpty(__tmp51_line))
                {
                    __out.Append(__tmp51_line);
                    __tmp50_outputWritten = true;
                }
                StringBuilder __tmp52 = new StringBuilder();
                __tmp52.Append(Properties.MetaNs);
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
                string __tmp53_line = ".MetaClass MetaClass"; //466:35
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp50_outputWritten = true;
                }
                if (__tmp50_outputWritten) __out.AppendLine(true);
                if (__tmp50_outputWritten)
                {
                    __out.AppendLine(false); //466:55
                }
            }
            __out.Append("	{"); //468:1
            __out.AppendLine(false); //468:3
            bool __tmp55_outputWritten = false;
            string __tmp56_line = "		get { return "; //469:1
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
            string __tmp58_line = "; }"; //469:73
            if (!string.IsNullOrEmpty(__tmp58_line))
            {
                __out.Append(__tmp58_line);
                __tmp55_outputWritten = true;
            }
            if (__tmp55_outputWritten) __out.AppendLine(true);
            if (__tmp55_outputWritten)
            {
                __out.AppendLine(false); //469:76
            }
            __out.Append("	}"); //470:1
            __out.AppendLine(false); //470:3
            var __loop24_results = 
                (from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //471:8
                from prop in __Enumerate((__loop24_var1.Properties).GetEnumerator()) //471:13
                select new { __loop24_var1 = __loop24_var1, prop = prop}
                ).ToList(); //471:3
            for (int __loop24_iteration = 0; __loop24_iteration < __loop24_results.Count; ++__loop24_iteration)
            {
                var __tmp59 = __loop24_results[__loop24_iteration];
                var __loop24_var1 = __tmp59.__loop24_var1;
                var prop = __tmp59.prop;
                bool __tmp61_outputWritten = false;
                string __tmp60Prefix = "	"; //472:1
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
                    __out.AppendLine(false); //472:48
                }
            }
            __out.Append("}"); //474:1
            __out.AppendLine(false); //474:2
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
                __out.AppendLine(false); //490:30
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
                __out.AppendLine(false); //491:28
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
                __out.AppendLine(false); //492:58
            }
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "public static readonly "; //493:1
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
            string __tmp14_line = ".ModelProperty "; //493:43
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
            string __tmp16_line = " ="; //493:107
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Append(__tmp16_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //493:109
            }
            bool __tmp18_outputWritten = false;
            string __tmp17Prefix = "    "; //494:1
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
            string __tmp20_line = ".ModelProperty.Register(typeof("; //494:24
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
            string __tmp22_line = "), \""; //494:100
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
            string __tmp24_line = "\","; //494:128
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //494:130
            }
            if (prop.Type is MetaCollectionType) //495:2
            {
                MetaCollectionType collType = (MetaCollectionType)prop.Type; //496:3
                bool __tmp26_outputWritten = false;
                string __tmp27_line = "        new "; //497:1
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
                string __tmp29_line = ".ModelPropertyTypeInfo(typeof("; //497:32
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
                string __tmp31_line = "), typeof("; //497:126
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
                string __tmp33_line = ")),"; //497:191
                if (!string.IsNullOrEmpty(__tmp33_line))
                {
                    __out.Append(__tmp33_line);
                    __tmp26_outputWritten = true;
                }
                if (__tmp26_outputWritten) __out.AppendLine(true);
                if (__tmp26_outputWritten)
                {
                    __out.AppendLine(false); //497:194
                }
                bool __tmp35_outputWritten = false;
                string __tmp36_line = "        new "; //498:1
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
                string __tmp38_line = ".ModelPropertyTypeInfo(typeof("; //498:32
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
                string __tmp40_line = "), typeof("; //498:124
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
                string __tmp42_line = ")),"; //498:187
                if (!string.IsNullOrEmpty(__tmp42_line))
                {
                    __out.Append(__tmp42_line);
                    __tmp35_outputWritten = true;
                }
                if (__tmp35_outputWritten) __out.AppendLine(true);
                if (__tmp35_outputWritten)
                {
                    __out.AppendLine(false); //498:190
                }
            }
            else //499:2
            {
                bool __tmp44_outputWritten = false;
                string __tmp45_line = "        new "; //500:1
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
                string __tmp47_line = ".ModelPropertyTypeInfo(typeof("; //500:32
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
                string __tmp49_line = "), null),"; //500:117
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Append(__tmp49_line);
                    __tmp44_outputWritten = true;
                }
                if (__tmp44_outputWritten) __out.AppendLine(true);
                if (__tmp44_outputWritten)
                {
                    __out.AppendLine(false); //500:126
                }
                bool __tmp51_outputWritten = false;
                string __tmp52_line = "        new "; //501:1
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
                string __tmp54_line = ".ModelPropertyTypeInfo(typeof("; //501:32
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
                string __tmp56_line = "), null),"; //501:115
                if (!string.IsNullOrEmpty(__tmp56_line))
                {
                    __out.Append(__tmp56_line);
                    __tmp51_outputWritten = true;
                }
                if (__tmp51_outputWritten) __out.AppendLine(true);
                if (__tmp51_outputWritten)
                {
                    __out.AppendLine(false); //501:124
                }
            }
            bool __tmp58_outputWritten = false;
            string __tmp59_line = "		() => "; //503:1
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
            string __tmp61_line = ");"; //503:70
            if (!string.IsNullOrEmpty(__tmp61_line))
            {
                __out.Append(__tmp61_line);
                __tmp58_outputWritten = true;
            }
            if (__tmp58_outputWritten) __out.AppendLine(true);
            if (__tmp58_outputWritten)
            {
                __out.AppendLine(false); //503:72
            }
            return __out.ToString();
        }

        public string GenerateDescriptorPropertyAnnotations(MetaModel model, MetaClass cls, MetaProperty prop) //506:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Kind == MetaPropertyKind.Containment) //507:2
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
                    __out.AppendLine(false); //508:49
                }
            }
            if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //510:2
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
                    __out.AppendLine(false); //511:46
                }
            }
            var __loop26_results = 
                (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //513:7
                select new { p = p}
                ).ToList(); //513:2
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
                    __out.AppendLine(false); //514:146
                }
            }
            var __loop27_results = 
                (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //516:7
                select new { p = p}
                ).ToList(); //516:2
            for (int __loop27_iteration = 0; __loop27_iteration < __loop27_results.Count; ++__loop27_iteration)
            {
                var __tmp15 = __loop27_results[__loop27_iteration];
                var p = __tmp15.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //517:3
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
                        __out.AppendLine(false); //518:145
                    }
                }
                else //519:3
                {
                    bool __tmp24_outputWritten = false;
                    string __tmp25_line = "// ERROR: subsetted property '"; //520:1
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
                    string __tmp27_line = "' must be a property of this class or an ancestor class"; //520:83
                    if (!string.IsNullOrEmpty(__tmp27_line))
                    {
                        __out.Append(__tmp27_line);
                        __tmp24_outputWritten = true;
                    }
                    if (__tmp24_outputWritten) __out.AppendLine(true);
                    if (__tmp24_outputWritten)
                    {
                        __out.AppendLine(false); //520:138
                    }
                }
            }
            var __loop28_results = 
                (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //523:7
                select new { p = p}
                ).ToList(); //523:2
            for (int __loop28_iteration = 0; __loop28_iteration < __loop28_results.Count; ++__loop28_iteration)
            {
                var __tmp28 = __loop28_results[__loop28_iteration];
                var p = __tmp28.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //524:3
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
                        __out.AppendLine(false); //525:147
                    }
                }
                else //526:3
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "// ERROR: redefined property '"; //527:1
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
                    string __tmp40_line = "' must be a property of this class or an ancestor class"; //527:83
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Append(__tmp40_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //527:138
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //532:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //533:1
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
                __out.AppendLine(false); //533:68
            }
            __out.Append("{"); //534:1
            __out.AppendLine(false); //534:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	// If there is a compile error at this line, create a new class called "; //535:1
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
                __out.AppendLine(false); //535:117
            }
            bool __tmp10_outputWritten = false;
            string __tmp11_line = "	// which is a subclass of "; //536:1
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
            string __tmp13_line = ":"; //536:82
            if (!string.IsNullOrEmpty(__tmp13_line))
            {
                __out.Append(__tmp13_line);
                __tmp10_outputWritten = true;
            }
            if (__tmp10_outputWritten) __out.AppendLine(true);
            if (__tmp10_outputWritten)
            {
                __out.AppendLine(false); //536:83
            }
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "	private static "; //537:1
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
            string __tmp18_line = " implementation = new "; //537:61
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
            string __tmp20_line = "();"; //537:127
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //537:130
            }
            __out.AppendLine(true); //538:1
            bool __tmp22_outputWritten = false;
            string __tmp23_line = "	public static "; //539:1
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
            string __tmp25_line = " Implementation"; //539:60
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Append(__tmp25_line);
                __tmp22_outputWritten = true;
            }
            if (__tmp22_outputWritten) __out.AppendLine(true);
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //539:75
            }
            __out.Append("	{"); //540:1
            __out.AppendLine(false); //540:3
            __out.Append("		get { return implementation; }"); //541:1
            __out.AppendLine(false); //541:33
            __out.Append("	}"); //542:1
            __out.AppendLine(false); //542:3
            __out.Append("}"); //543:1
            __out.AppendLine(false); //543:2
            return __out.ToString();
        }

        public string GenerateImplementationBase(MetaModel model) //546:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //547:1
            __out.AppendLine(false); //547:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //548:1
            __out.AppendLine(false); //548:68
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "/// This class has to be be overriden in "; //549:1
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
            string __tmp5_line = " to provide custom"; //549:92
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Append(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //549:110
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //550:1
            __out.AppendLine(false); //550:73
            __out.Append("/// </summary>"); //551:1
            __out.AppendLine(false); //551:15
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "internal abstract class "; //552:1
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
                __out.AppendLine(false); //552:73
            }
            __out.Append("{"); //553:1
            __out.AppendLine(false); //553:2
            __out.Append("	/// <summary>"); //554:1
            __out.AppendLine(false); //554:15
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	/// Implements the constructor: "; //555:1
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
            string __tmp14_line = "()"; //555:79
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //555:81
            }
            __out.Append("	/// </summary>"); //556:1
            __out.AppendLine(false); //556:16
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	internal virtual void "; //557:1
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
            string __tmp19_line = "("; //557:69
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
            string __tmp21_line = " _this)"; //557:115
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //557:122
            }
            __out.Append("	{"); //558:1
            __out.AppendLine(false); //558:3
            __out.Append("	}"); //559:1
            __out.AppendLine(false); //559:3
            var __loop29_results = 
                (from __loop29_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //560:8
                from cls in __Enumerate((__loop29_var1).GetEnumerator()).OfType<MetaClass>() //560:38
                select new { __loop29_var1 = __loop29_var1, cls = cls}
                ).ToList(); //560:3
            for (int __loop29_iteration = 0; __loop29_iteration < __loop29_results.Count; ++__loop29_iteration)
            {
                var __tmp22 = __loop29_results[__loop29_iteration];
                var __loop29_var1 = __tmp22.__loop29_var1;
                var cls = __tmp22.cls;
                __out.AppendLine(true); //561:1
                __out.Append("	/// <summary>"); //562:1
                __out.AppendLine(false); //562:15
                bool __tmp24_outputWritten = false;
                string __tmp25_line = "	/// Implements the constructor: "; //563:1
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
                string __tmp27_line = "()"; //563:78
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Append(__tmp27_line);
                    __tmp24_outputWritten = true;
                }
                if (__tmp24_outputWritten) __out.AppendLine(true);
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //563:80
                }
                __out.Append("	/// </summary>"); //564:1
                __out.AppendLine(false); //564:16
                if ((from __loop30_var1 in __Enumerate((cls).GetEnumerator()) //565:15
                from sup in __Enumerate((__loop30_var1.SuperClasses).GetEnumerator()) //565:20
                select new { __loop30_var1 = __loop30_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //565:3
                {
                    __out.Append("	/// Direct superclasses: "); //566:1
                    __out.AppendLine(false); //566:27
                    __out.Append("	/// <ul>"); //567:1
                    __out.AppendLine(false); //567:10
                    var __loop31_results = 
                        (from __loop31_var1 in __Enumerate((cls).GetEnumerator()) //568:8
                        from sup in __Enumerate((__loop31_var1.SuperClasses).GetEnumerator()) //568:13
                        select new { __loop31_var1 = __loop31_var1, sup = sup}
                        ).ToList(); //568:3
                    for (int __loop31_iteration = 0; __loop31_iteration < __loop31_results.Count; ++__loop31_iteration)
                    {
                        var __tmp28 = __loop31_results[__loop31_iteration];
                        var __loop31_var1 = __tmp28.__loop31_var1;
                        var sup = __tmp28.sup;
                        bool __tmp30_outputWritten = false;
                        string __tmp31_line = "	///     <li>"; //569:1
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
                        string __tmp33_line = "</li>"; //569:64
                        if (!string.IsNullOrEmpty(__tmp33_line))
                        {
                            __out.Append(__tmp33_line);
                            __tmp30_outputWritten = true;
                        }
                        if (__tmp30_outputWritten) __out.AppendLine(true);
                        if (__tmp30_outputWritten)
                        {
                            __out.AppendLine(false); //569:69
                        }
                    }
                    __out.Append("	/// </ul>"); //571:1
                    __out.AppendLine(false); //571:11
                    __out.Append("	/// All superclasses:"); //572:1
                    __out.AppendLine(false); //572:23
                    __out.Append("	/// <ul>"); //573:1
                    __out.AppendLine(false); //573:10
                    var __loop32_results = 
                        (from __loop32_var1 in __Enumerate((cls).GetEnumerator()) //574:8
                        from sup in __Enumerate((__loop32_var1.GetAllSuperClasses(false)).GetEnumerator()) //574:13
                        select new { __loop32_var1 = __loop32_var1, sup = sup}
                        ).ToList(); //574:3
                    for (int __loop32_iteration = 0; __loop32_iteration < __loop32_results.Count; ++__loop32_iteration)
                    {
                        var __tmp34 = __loop32_results[__loop32_iteration];
                        var __loop32_var1 = __tmp34.__loop32_var1;
                        var sup = __tmp34.sup;
                        bool __tmp36_outputWritten = false;
                        string __tmp37_line = "	///     <li>"; //575:1
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
                        string __tmp39_line = "</li>"; //575:64
                        if (!string.IsNullOrEmpty(__tmp39_line))
                        {
                            __out.Append(__tmp39_line);
                            __tmp36_outputWritten = true;
                        }
                        if (__tmp36_outputWritten) __out.AppendLine(true);
                        if (__tmp36_outputWritten)
                        {
                            __out.AppendLine(false); //575:69
                        }
                    }
                    __out.Append("	/// </ul>"); //577:1
                    __out.AppendLine(false); //577:11
                }
                if ((from __loop33_var1 in __Enumerate((cls).GetEnumerator()) //579:15
                from prop in __Enumerate((__loop33_var1.Properties).GetEnumerator()) //579:20
                where prop.Kind == MetaPropertyKind.Readonly //579:36
                select new { __loop33_var1 = __loop33_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //579:3
                {
                    __out.Append("	/// Initializes the following readonly properties:"); //580:1
                    __out.AppendLine(false); //580:52
                    __out.Append("	/// <ul>"); //581:1
                    __out.AppendLine(false); //581:10
                    var __loop34_results = 
                        (from __loop34_var1 in __Enumerate((cls).GetEnumerator()) //582:8
                        from prop in __Enumerate((__loop34_var1.Properties).GetEnumerator()) //582:13
                        where prop.Kind == MetaPropertyKind.Readonly //582:29
                        select new { __loop34_var1 = __loop34_var1, prop = prop}
                        ).ToList(); //582:3
                    for (int __loop34_iteration = 0; __loop34_iteration < __loop34_results.Count; ++__loop34_iteration)
                    {
                        var __tmp40 = __loop34_results[__loop34_iteration];
                        var __loop34_var1 = __tmp40.__loop34_var1;
                        var prop = __tmp40.prop;
                        bool __tmp42_outputWritten = false;
                        string __tmp43_line = "	///     <li>"; //583:1
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
                        string __tmp45_line = "</li>"; //583:38
                        if (!string.IsNullOrEmpty(__tmp45_line))
                        {
                            __out.Append(__tmp45_line);
                            __tmp42_outputWritten = true;
                        }
                        if (__tmp42_outputWritten) __out.AppendLine(true);
                        if (__tmp42_outputWritten)
                        {
                            __out.AppendLine(false); //583:43
                        }
                    }
                    __out.Append("	/// </ul>"); //585:1
                    __out.AppendLine(false); //585:11
                }
                if ((from __loop35_var1 in __Enumerate((cls).GetEnumerator()) //587:15
                from prop in __Enumerate((__loop35_var1.Properties).GetEnumerator()) //587:20
                where prop.Kind == MetaPropertyKind.Lazy //587:36
                select new { __loop35_var1 = __loop35_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //587:3
                {
                    __out.Append("	/// Initializes the following lazy properties:"); //588:1
                    __out.AppendLine(false); //588:48
                    __out.Append("	/// <ul>"); //589:1
                    __out.AppendLine(false); //589:10
                    var __loop36_results = 
                        (from __loop36_var1 in __Enumerate((cls).GetEnumerator()) //590:8
                        from prop in __Enumerate((__loop36_var1.Properties).GetEnumerator()) //590:13
                        where prop.Kind == MetaPropertyKind.Lazy //590:29
                        select new { __loop36_var1 = __loop36_var1, prop = prop}
                        ).ToList(); //590:3
                    for (int __loop36_iteration = 0; __loop36_iteration < __loop36_results.Count; ++__loop36_iteration)
                    {
                        var __tmp46 = __loop36_results[__loop36_iteration];
                        var __loop36_var1 = __tmp46.__loop36_var1;
                        var prop = __tmp46.prop;
                        bool __tmp48_outputWritten = false;
                        string __tmp49_line = "	///     <li>"; //591:1
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
                        string __tmp51_line = "</li>"; //591:38
                        if (!string.IsNullOrEmpty(__tmp51_line))
                        {
                            __out.Append(__tmp51_line);
                            __tmp48_outputWritten = true;
                        }
                        if (__tmp48_outputWritten) __out.AppendLine(true);
                        if (__tmp48_outputWritten)
                        {
                            __out.AppendLine(false); //591:43
                        }
                    }
                    __out.Append("	/// </ul>"); //593:1
                    __out.AppendLine(false); //593:11
                }
                if ((from __loop37_var1 in __Enumerate((cls).GetEnumerator()) //595:15
                from prop in __Enumerate((__loop37_var1.Properties).GetEnumerator()) //595:20
                where prop.Kind == MetaPropertyKind.Derived //595:36
                select new { __loop37_var1 = __loop37_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //595:3
                {
                    __out.Append("	/// Initializes the following derived properties:"); //596:1
                    __out.AppendLine(false); //596:51
                    __out.Append("	/// <ul>"); //597:1
                    __out.AppendLine(false); //597:10
                    var __loop38_results = 
                        (from __loop38_var1 in __Enumerate((cls).GetEnumerator()) //598:8
                        from prop in __Enumerate((__loop38_var1.Properties).GetEnumerator()) //598:13
                        where prop.Kind == MetaPropertyKind.Derived //598:29
                        select new { __loop38_var1 = __loop38_var1, prop = prop}
                        ).ToList(); //598:3
                    for (int __loop38_iteration = 0; __loop38_iteration < __loop38_results.Count; ++__loop38_iteration)
                    {
                        var __tmp52 = __loop38_results[__loop38_iteration];
                        var __loop38_var1 = __tmp52.__loop38_var1;
                        var prop = __tmp52.prop;
                        bool __tmp54_outputWritten = false;
                        string __tmp55_line = "	///     <li>"; //599:1
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
                        string __tmp57_line = "</li>"; //599:38
                        if (!string.IsNullOrEmpty(__tmp57_line))
                        {
                            __out.Append(__tmp57_line);
                            __tmp54_outputWritten = true;
                        }
                        if (__tmp54_outputWritten) __out.AppendLine(true);
                        if (__tmp54_outputWritten)
                        {
                            __out.AppendLine(false); //599:43
                        }
                    }
                    __out.Append("	/// </ul>"); //601:1
                    __out.AppendLine(false); //601:11
                }
                bool __tmp59_outputWritten = false;
                string __tmp60_line = "	public virtual void "; //603:1
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
                string __tmp62_line = "("; //603:66
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
                string __tmp64_line = " _this)"; //603:109
                if (!string.IsNullOrEmpty(__tmp64_line))
                {
                    __out.Append(__tmp64_line);
                    __tmp59_outputWritten = true;
                }
                if (__tmp59_outputWritten) __out.AppendLine(true);
                if (__tmp59_outputWritten)
                {
                    __out.AppendLine(false); //603:116
                }
                __out.Append("	{"); //604:1
                __out.AppendLine(false); //604:3
                bool __tmp66_outputWritten = false;
                string __tmp67_line = "		this.Call"; //605:1
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
                string __tmp69_line = "SuperConstructors(_this);"; //605:56
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Append(__tmp69_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //605:81
                }
                __out.Append("	}"); //606:1
                __out.AppendLine(false); //606:3
                __out.AppendLine(true); //607:1
                __out.Append("	/// <summary>"); //608:1
                __out.AppendLine(false); //608:15
                bool __tmp71_outputWritten = false;
                string __tmp72_line = "	/// Calls the super constructors of "; //609:1
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
                    __out.AppendLine(false); //609:82
                }
                __out.Append("	/// </summary>"); //610:1
                __out.AppendLine(false); //610:16
                bool __tmp75_outputWritten = false;
                string __tmp76_line = "	protected virtual void Call"; //611:1
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
                string __tmp78_line = "SuperConstructors("; //611:73
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
                string __tmp80_line = " _this)"; //611:133
                if (!string.IsNullOrEmpty(__tmp80_line))
                {
                    __out.Append(__tmp80_line);
                    __tmp75_outputWritten = true;
                }
                if (__tmp75_outputWritten) __out.AppendLine(true);
                if (__tmp75_outputWritten)
                {
                    __out.AppendLine(false); //611:140
                }
                __out.Append("	{"); //612:1
                __out.AppendLine(false); //612:3
                var __loop39_results = 
                    (from __loop39_var1 in __Enumerate((cls).GetEnumerator()) //613:8
                    from sup in __Enumerate((__loop39_var1.GetAllSuperClasses(false)).GetEnumerator()) //613:13
                    select new { __loop39_var1 = __loop39_var1, sup = sup}
                    ).ToList(); //613:3
                for (int __loop39_iteration = 0; __loop39_iteration < __loop39_results.Count; ++__loop39_iteration)
                {
                    var __tmp81 = __loop39_results[__loop39_iteration];
                    var __loop39_var1 = __tmp81.__loop39_var1;
                    var sup = __tmp81.sup;
                    if (model.Namespace.Declarations.Contains(sup)) //614:4
                    {
                        bool __tmp83_outputWritten = false;
                        string __tmp84_line = "		this."; //615:1
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
                        string __tmp86_line = "(_this);"; //615:52
                        if (!string.IsNullOrEmpty(__tmp86_line))
                        {
                            __out.Append(__tmp86_line);
                            __tmp83_outputWritten = true;
                        }
                        if (__tmp83_outputWritten) __out.AppendLine(true);
                        if (__tmp83_outputWritten)
                        {
                            __out.AppendLine(false); //615:60
                        }
                    }
                    else //616:4
                    {
                        bool __tmp88_outputWritten = false;
                        string __tmp87Prefix = "		"; //617:1
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
                        string __tmp90_line = "."; //617:69
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
                        string __tmp92_line = "(_this);"; //617:114
                        if (!string.IsNullOrEmpty(__tmp92_line))
                        {
                            __out.Append(__tmp92_line);
                            __tmp88_outputWritten = true;
                        }
                        if (__tmp88_outputWritten) __out.AppendLine(true);
                        if (__tmp88_outputWritten)
                        {
                            __out.AppendLine(false); //617:122
                        }
                    }
                }
                __out.Append("	}"); //620:1
                __out.AppendLine(false); //620:3
                var __loop40_results = 
                    (from __loop40_var1 in __Enumerate((cls).GetEnumerator()) //621:8
                    from op in __Enumerate((__loop40_var1.Operations).GetEnumerator()) //621:13
                    select new { __loop40_var1 = __loop40_var1, op = op}
                    ).ToList(); //621:3
                for (int __loop40_iteration = 0; __loop40_iteration < __loop40_results.Count; ++__loop40_iteration)
                {
                    var __tmp93 = __loop40_results[__loop40_iteration];
                    var __loop40_var1 = __tmp93.__loop40_var1;
                    var op = __tmp93.op;
                    __out.AppendLine(true); //622:2
                    __out.Append("	/// <summary>"); //623:1
                    __out.AppendLine(false); //623:15
                    bool __tmp95_outputWritten = false;
                    string __tmp96_line = "	/// Implements the operation: "; //624:1
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
                    string __tmp98_line = "."; //624:76
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
                    string __tmp100_line = "()"; //624:86
                    if (!string.IsNullOrEmpty(__tmp100_line))
                    {
                        __out.Append(__tmp100_line);
                        __tmp95_outputWritten = true;
                    }
                    if (__tmp95_outputWritten) __out.AppendLine(true);
                    if (__tmp95_outputWritten)
                    {
                        __out.AppendLine(false); //624:88
                    }
                    __out.Append("	/// </summary>"); //625:1
                    __out.AppendLine(false); //625:16
                    bool __tmp102_outputWritten = false;
                    string __tmp103_line = "	public virtual "; //626:1
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
                    string __tmp105_line = " "; //626:77
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
                    string __tmp107_line = "_"; //626:122
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
                    string __tmp109_line = "("; //626:132
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
                    string __tmp111_line = ")"; //626:168
                    if (!string.IsNullOrEmpty(__tmp111_line))
                    {
                        __out.Append(__tmp111_line);
                        __tmp102_outputWritten = true;
                    }
                    if (__tmp102_outputWritten) __out.AppendLine(true);
                    if (__tmp102_outputWritten)
                    {
                        __out.AppendLine(false); //626:169
                    }
                    __out.Append("	{"); //627:1
                    __out.AppendLine(false); //627:3
                    __out.Append("		throw new NotImplementedException();"); //628:1
                    __out.AppendLine(false); //628:39
                    __out.Append("	}"); //629:1
                    __out.AppendLine(false); //629:3
                }
                __out.AppendLine(true); //631:2
            }
            var __loop41_results = 
                (from __loop41_var1 in __Enumerate((model).GetEnumerator()) //633:8
                from Namespace in __Enumerate((__loop41_var1.Namespace).GetEnumerator()) //633:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //633:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //633:40
                select new { __loop41_var1 = __loop41_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //633:3
            for (int __loop41_iteration = 0; __loop41_iteration < __loop41_results.Count; ++__loop41_iteration)
            {
                var __tmp112 = __loop41_results[__loop41_iteration];
                var __loop41_var1 = __tmp112.__loop41_var1;
                var Namespace = __tmp112.Namespace;
                var Declarations = __tmp112.Declarations;
                var enm = __tmp112.enm;
                var __loop42_results = 
                    (from __loop42_var1 in __Enumerate((enm).GetEnumerator()) //634:8
                    from op in __Enumerate((__loop42_var1.Operations).GetEnumerator()) //634:13
                    select new { __loop42_var1 = __loop42_var1, op = op}
                    ).ToList(); //634:3
                for (int __loop42_iteration = 0; __loop42_iteration < __loop42_results.Count; ++__loop42_iteration)
                {
                    var __tmp113 = __loop42_results[__loop42_iteration];
                    var __loop42_var1 = __tmp113.__loop42_var1;
                    var op = __tmp113.op;
                    __out.AppendLine(true); //635:2
                    __out.Append("	/// <summary>"); //636:1
                    __out.AppendLine(false); //636:15
                    bool __tmp115_outputWritten = false;
                    string __tmp116_line = "	/// Implements the operation: "; //637:1
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
                    string __tmp118_line = "."; //637:76
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
                        __out.AppendLine(false); //637:86
                    }
                    __out.Append("	/// </summary>"); //638:1
                    __out.AppendLine(false); //638:16
                    bool __tmp121_outputWritten = false;
                    string __tmp122_line = "	public virtual "; //639:1
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
                    string __tmp124_line = " "; //639:77
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
                    string __tmp126_line = "_"; //639:122
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
                    string __tmp128_line = "("; //639:132
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
                    string __tmp130_line = ")"; //639:168
                    if (!string.IsNullOrEmpty(__tmp130_line))
                    {
                        __out.Append(__tmp130_line);
                        __tmp121_outputWritten = true;
                    }
                    if (__tmp121_outputWritten) __out.AppendLine(true);
                    if (__tmp121_outputWritten)
                    {
                        __out.AppendLine(false); //639:169
                    }
                    __out.Append("	{"); //640:1
                    __out.AppendLine(false); //640:3
                    __out.Append("		throw new NotImplementedException();"); //641:1
                    __out.AppendLine(false); //641:39
                    __out.Append("	}"); //642:1
                    __out.AppendLine(false); //642:3
                }
                __out.AppendLine(true); //644:2
            }
            __out.Append("}"); //646:1
            __out.AppendLine(false); //646:2
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
                __out.AppendLine(false); //670:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public enum "; //671:1
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
                __out.AppendLine(false); //671:36
            }
            __out.Append("{"); //672:1
            __out.AppendLine(false); //672:2
            var __loop45_results = 
                (from __loop45_var1 in __Enumerate((enm).GetEnumerator()) //673:8
                from value in __Enumerate((__loop45_var1.EnumLiterals).GetEnumerator()) //673:13
                select new { __loop45_var1 = __loop45_var1, value = value}
                ).ToList(); //673:3
            for (int __loop45_iteration = 0; __loop45_iteration < __loop45_results.Count; ++__loop45_iteration)
            {
                string delim; //673:31
                if (__loop45_iteration+1 < __loop45_results.Count) delim = ",";
                else delim = string.Empty;
                var __tmp8 = __loop45_results[__loop45_iteration];
                var __loop45_var1 = __tmp8.__loop45_var1;
                var value = __tmp8.value;
                bool __tmp10_outputWritten = false;
                string __tmp9Prefix = "	"; //674:1
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
                    __out.AppendLine(false); //674:32
                }
                bool __tmp13_outputWritten = false;
                string __tmp12Prefix = "	"; //675:1
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
                    __out.AppendLine(false); //675:21
                }
            }
            __out.Append("}"); //677:1
            __out.AppendLine(false); //677:2
            __out.AppendLine(true); //678:1
            bool __tmp17_outputWritten = false;
            string __tmp18_line = "public static class "; //679:1
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
            string __tmp20_line = "Extensions"; //679:31
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp17_outputWritten = true;
            }
            if (__tmp17_outputWritten) __out.AppendLine(true);
            if (__tmp17_outputWritten)
            {
                __out.AppendLine(false); //679:41
            }
            __out.Append("{"); //680:1
            __out.AppendLine(false); //680:2
            var __loop46_results = 
                (from __loop46_var1 in __Enumerate((enm).GetEnumerator()) //681:8
                from op in __Enumerate((__loop46_var1.Operations).GetEnumerator()) //681:13
                select new { __loop46_var1 = __loop46_var1, op = op}
                ).ToList(); //681:3
            for (int __loop46_iteration = 0; __loop46_iteration < __loop46_results.Count; ++__loop46_iteration)
            {
                var __tmp21 = __loop46_results[__loop46_iteration];
                var __loop46_var1 = __tmp21.__loop46_var1;
                var op = __tmp21.op;
                bool __tmp23_outputWritten = false;
                string __tmp24_line = "	public static "; //682:1
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
                string __tmp26_line = " "; //682:70
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
                string __tmp28_line = "("; //682:80
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
                string __tmp30_line = ")"; //682:120
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Append(__tmp30_line);
                    __tmp23_outputWritten = true;
                }
                if (__tmp23_outputWritten) __out.AppendLine(true);
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //682:121
                }
                __out.Append("	{"); //683:1
                __out.AppendLine(false); //683:3
                bool __tmp32_outputWritten = false;
                string __tmp31Prefix = "		"; //684:1
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
                string __tmp35_line = ".Implementation."; //684:77
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
                string __tmp37_line = "_"; //684:143
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
                string __tmp39_line = "("; //684:153
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
                string __tmp41_line = ");"; //684:196
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Append(__tmp41_line);
                    __tmp32_outputWritten = true;
                }
                if (__tmp32_outputWritten) __out.AppendLine(true);
                if (__tmp32_outputWritten)
                {
                    __out.AppendLine(false); //684:198
                }
                __out.Append("	}"); //685:1
                __out.AppendLine(false); //685:3
            }
            __out.Append("}"); //687:1
            __out.AppendLine(false); //687:2
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
                __out.AppendLine(false); //744:37
            }
            __out.AppendLine(true); //745:1
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
                __out.AppendLine(false); //746:35
            }
            return __out.ToString();
        }

        public string GenerateClassInternal(MetaModel model, MetaClass cls) //749:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //750:1
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
                __out.AppendLine(false); //751:30
            }
            __out.AppendLine(true); //752:1
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
                __out.AppendLine(false); //753:41
            }
            __out.AppendLine(true); //754:1
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
                __out.AppendLine(false); //755:39
            }
            return __out.ToString();
        }

        public string GenerateIdClass(MetaModel model, MetaClass cls) //758:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //759:1
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
            string __tmp5_line = " : "; //759:53
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
            string __tmp7_line = ".SymbolId"; //759:75
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //759:84
            }
            __out.Append("{"); //760:1
            __out.AppendLine(false); //760:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "	public override "; //761:1
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
            string __tmp12_line = ".ModelSymbolInfo SymbolInfo { get { return "; //761:37
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
            string __tmp14_line = ".SymbolInfo; } }"; //761:130
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //761:146
            }
            __out.AppendLine(true); //762:1
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	public override "; //763:1
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
            string __tmp19_line = ".ImmutableSymbolBase CreateImmutable("; //763:37
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
            string __tmp21_line = ".ImmutableModel model)"; //763:93
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //763:115
            }
            __out.Append("	{"); //764:1
            __out.AppendLine(false); //764:3
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "		return new "; //765:1
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
            string __tmp26_line = "(this, model);"; //765:62
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //765:76
            }
            __out.Append("	}"); //766:1
            __out.AppendLine(false); //766:3
            __out.AppendLine(true); //767:1
            bool __tmp28_outputWritten = false;
            string __tmp29_line = "	public override "; //768:1
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
            string __tmp31_line = ".MutableSymbolBase CreateMutable("; //768:37
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
            string __tmp33_line = ".MutableModel model, bool creating)"; //768:89
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Append(__tmp33_line);
                __tmp28_outputWritten = true;
            }
            if (__tmp28_outputWritten) __out.AppendLine(true);
            if (__tmp28_outputWritten)
            {
                __out.AppendLine(false); //768:124
            }
            __out.Append("	{"); //769:1
            __out.AppendLine(false); //769:3
            bool __tmp35_outputWritten = false;
            string __tmp36_line = "		return new "; //770:1
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
            string __tmp38_line = "(this, model, creating);"; //770:60
            if (!string.IsNullOrEmpty(__tmp38_line))
            {
                __out.Append(__tmp38_line);
                __tmp35_outputWritten = true;
            }
            if (__tmp35_outputWritten) __out.AppendLine(true);
            if (__tmp35_outputWritten)
            {
                __out.AppendLine(false); //770:84
            }
            __out.Append("	}"); //771:1
            __out.AppendLine(false); //771:3
            __out.Append("}"); //772:1
            __out.AppendLine(false); //772:2
            return __out.ToString();
        }

        public string GenerateImmutableClass(MetaModel model, MetaClass cls) //775:1
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
                __out.AppendLine(false); //776:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //777:1
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
                __out.AppendLine(false); //777:97
            }
            __out.Append("{"); //778:1
            __out.AppendLine(false); //778:2
            var __loop52_results = 
                (from __loop52_var1 in __Enumerate((cls).GetEnumerator()) //779:8
                from prop in __Enumerate((__loop52_var1.Properties).GetEnumerator()) //779:13
                select new { __loop52_var1 = __loop52_var1, prop = prop}
                ).ToList(); //779:3
            for (int __loop52_iteration = 0; __loop52_iteration < __loop52_results.Count; ++__loop52_iteration)
            {
                var __tmp9 = __loop52_results[__loop52_iteration];
                var __loop52_var1 = __tmp9.__loop52_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //780:1
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
                    __out.AppendLine(false); //780:42
                }
            }
            __out.AppendLine(true); //782:1
            var __loop53_results = 
                (from __loop53_var1 in __Enumerate((cls).GetEnumerator()) //783:8
                from op in __Enumerate((__loop53_var1.Operations).GetEnumerator()) //783:13
                select new { __loop53_var1 = __loop53_var1, op = op}
                ).ToList(); //783:3
            for (int __loop53_iteration = 0; __loop53_iteration < __loop53_results.Count; ++__loop53_iteration)
            {
                var __tmp13 = __loop53_results[__loop53_iteration];
                var __loop53_var1 = __tmp13.__loop53_var1;
                var op = __tmp13.op;
                bool __tmp15_outputWritten = false;
                string __tmp14Prefix = "	"; //784:1
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
                    __out.AppendLine(false); //784:41
                }
            }
            __out.AppendLine(true); //786:1
            bool __tmp18_outputWritten = false;
            string __tmp19_line = "	new "; //787:1
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
            string __tmp21_line = " ToMutable();"; //787:54
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //787:67
            }
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	new "; //788:1
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
            string __tmp26_line = " ToMutable("; //788:54
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
            string __tmp28_line = ".MutableModel model);"; //788:84
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Append(__tmp28_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //788:105
            }
            __out.Append("}"); //789:1
            __out.AppendLine(false); //789:2
            return __out.ToString();
        }

        public string GenerateImmutableProperty(MetaModel model, MetaProperty prop) //792:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //793:2
            {
                __out.Append("new "); //794:1
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
            string __tmp4_line = " "; //796:57
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
            string __tmp6_line = " { get; }"; //796:106
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Append(__tmp6_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //796:115
            }
            return __out.ToString();
        }

        public string GenerateImmutableOperation(MetaModel model, MetaOperation op) //799:1
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
            string __tmp4_line = " "; //800:61
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
            string __tmp6_line = "("; //800:71
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
            string __tmp8_line = ");"; //800:116
            if (!string.IsNullOrEmpty(__tmp8_line))
            {
                __out.Append(__tmp8_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //800:118
            }
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
                __out.AppendLine(false); //824:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public interface "; //825:1
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
                __out.AppendLine(false); //825:93
            }
            __out.Append("{"); //826:1
            __out.AppendLine(false); //826:2
            var __loop56_results = 
                (from __loop56_var1 in __Enumerate((cls).GetEnumerator()) //827:8
                from prop in __Enumerate((__loop56_var1.Properties).GetEnumerator()) //827:13
                select new { __loop56_var1 = __loop56_var1, prop = prop}
                ).ToList(); //827:3
            for (int __loop56_iteration = 0; __loop56_iteration < __loop56_results.Count; ++__loop56_iteration)
            {
                var __tmp9 = __loop56_results[__loop56_iteration];
                var __loop56_var1 = __tmp9.__loop56_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //828:1
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
                    __out.AppendLine(false); //828:40
                }
            }
            __out.AppendLine(true); //830:1
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	new "; //831:1
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
            string __tmp17_line = " ToImmutable();"; //831:56
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //831:71
            }
            bool __tmp19_outputWritten = false;
            string __tmp20_line = "	new "; //832:1
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
            string __tmp22_line = " ToImmutable("; //832:56
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
            string __tmp24_line = ".ImmutableModel model);"; //832:88
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp19_outputWritten = true;
            }
            if (__tmp19_outputWritten) __out.AppendLine(true);
            if (__tmp19_outputWritten)
            {
                __out.AppendLine(false); //832:111
            }
            __out.Append("}"); //833:1
            __out.AppendLine(false); //833:2
            return __out.ToString();
        }

        public string GenerateBuilderProperty(MetaModel model, MetaProperty prop) //836:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //837:3
            {
                __out.Append("new "); //838:1
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //840:3
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
                string __tmp4_line = " "; //841:55
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
                string __tmp6_line = " { get; set; }"; //841:102
                if (!string.IsNullOrEmpty(__tmp6_line))
                {
                    __out.Append(__tmp6_line);
                    __tmp2_outputWritten = true;
                }
                if (__tmp2_outputWritten) __out.AppendLine(true);
                if (__tmp2_outputWritten)
                {
                    __out.AppendLine(false); //841:116
                }
            }
            else //842:3
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
                string __tmp10_line = " "; //843:55
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
                string __tmp12_line = " { get; }"; //843:102
                if (!string.IsNullOrEmpty(__tmp12_line))
                {
                    __out.Append(__tmp12_line);
                    __tmp8_outputWritten = true;
                }
                if (__tmp8_outputWritten) __out.AppendLine(true);
                if (__tmp8_outputWritten)
                {
                    __out.AppendLine(false); //843:111
                }
            }
            if (!(prop.Type is MetaCollectionType)) //845:3
            {
                if (prop.Class.GetAllSuperProperties(false).Any(p => p.Name == prop.Name)) //846:4
                {
                    __out.Append("new "); //847:1
                }
                bool __tmp14_outputWritten = false;
                string __tmp15_line = "Func<"; //849:1
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
                string __tmp17_line = "> "; //849:60
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
                string __tmp19_line = "Lazy { get; set; }"; //849:108
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Append(__tmp19_line);
                    __tmp14_outputWritten = true;
                }
                if (__tmp14_outputWritten) __out.AppendLine(true);
                if (__tmp14_outputWritten)
                {
                    __out.AppendLine(false); //849:126
                }
            }
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
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //866:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //867:1
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
            string __tmp5_line = " : "; //867:64
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
            string __tmp7_line = ".ImmutableSymbolBase, "; //867:86
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
                __out.AppendLine(false); //867:152
            }
            __out.Append("{"); //868:1
            __out.AppendLine(false); //868:2
            var __loop58_results = 
                (from __loop58_var1 in __Enumerate((cls).GetEnumerator()) //869:8
                from prop in __Enumerate((__loop58_var1.GetAllProperties()).GetEnumerator()) //869:13
                select new { __loop58_var1 = __loop58_var1, prop = prop}
                ).ToList(); //869:3
            for (int __loop58_iteration = 0; __loop58_iteration < __loop58_results.Count; ++__loop58_iteration)
            {
                var __tmp9 = __loop58_results[__loop58_iteration];
                var __loop58_var1 = __tmp9.__loop58_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //870:1
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
                    __out.AppendLine(false); //870:44
                }
            }
            __out.AppendLine(true); //872:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //873:1
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
            string __tmp17_line = "("; //873:59
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
            string __tmp19_line = ".SymbolId id, "; //873:79
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
            string __tmp21_line = ".ImmutableModel model)"; //873:112
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //873:134
            }
            __out.Append("		: base(id, model)"); //874:1
            __out.AppendLine(false); //874:20
            __out.Append("	{"); //875:1
            __out.AppendLine(false); //875:3
            __out.Append("	}"); //876:1
            __out.AppendLine(false); //876:3
            __out.AppendLine(true); //877:2
            bool __tmp23_outputWritten = false;
            string __tmp24_line = "	public override "; //878:1
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
            string __tmp26_line = "MetaModel MMetaModel"; //878:26
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //878:46
            }
            __out.Append("	{"); //879:1
            __out.AppendLine(false); //879:3
            if (IsMetaMetaModel(model)) //880:4
            {
                bool __tmp28_outputWritten = false;
                string __tmp29_line = "		get { return "; //881:1
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
                string __tmp31_line = ".MetaMetaModel; }"; //881:77
                if (!string.IsNullOrEmpty(__tmp31_line))
                {
                    __out.Append(__tmp31_line);
                    __tmp28_outputWritten = true;
                }
                if (__tmp28_outputWritten) __out.AppendLine(true);
                if (__tmp28_outputWritten)
                {
                    __out.AppendLine(false); //881:94
                }
            }
            else //882:4
            {
                bool __tmp33_outputWritten = false;
                string __tmp34_line = "		get { return "; //883:1
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
                string __tmp36_line = ".MetaModel; }"; //883:77
                if (!string.IsNullOrEmpty(__tmp36_line))
                {
                    __out.Append(__tmp36_line);
                    __tmp33_outputWritten = true;
                }
                if (__tmp33_outputWritten) __out.AppendLine(true);
                if (__tmp33_outputWritten)
                {
                    __out.AppendLine(false); //883:90
                }
            }
            __out.Append("	}"); //885:1
            __out.AppendLine(false); //885:3
            __out.AppendLine(true); //886:2
            bool __tmp38_outputWritten = false;
            string __tmp39_line = "	public override "; //887:1
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
            string __tmp41_line = "MetaClass MMetaClass"; //887:26
            if (!string.IsNullOrEmpty(__tmp41_line))
            {
                __out.Append(__tmp41_line);
                __tmp38_outputWritten = true;
            }
            if (__tmp38_outputWritten) __out.AppendLine(true);
            if (__tmp38_outputWritten)
            {
                __out.AppendLine(false); //887:46
            }
            __out.Append("	{"); //888:1
            __out.AppendLine(false); //888:3
            bool __tmp43_outputWritten = false;
            string __tmp44_line = "		get { return "; //889:1
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
            string __tmp46_line = "; }"; //889:74
            if (!string.IsNullOrEmpty(__tmp46_line))
            {
                __out.Append(__tmp46_line);
                __tmp43_outputWritten = true;
            }
            if (__tmp43_outputWritten) __out.AppendLine(true);
            if (__tmp43_outputWritten)
            {
                __out.AppendLine(false); //889:77
            }
            __out.Append("	}"); //890:1
            __out.AppendLine(false); //890:3
            __out.AppendLine(true); //891:2
            bool __tmp48_outputWritten = false;
            string __tmp49_line = "	public new "; //892:1
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
            string __tmp51_line = " ToMutable()"; //892:55
            if (!string.IsNullOrEmpty(__tmp51_line))
            {
                __out.Append(__tmp51_line);
                __tmp48_outputWritten = true;
            }
            if (__tmp48_outputWritten) __out.AppendLine(true);
            if (__tmp48_outputWritten)
            {
                __out.AppendLine(false); //892:67
            }
            __out.Append("	{"); //893:1
            __out.AppendLine(false); //893:3
            bool __tmp53_outputWritten = false;
            string __tmp54_line = "		return ("; //894:1
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
            string __tmp56_line = ")base.ToMutable();"; //894:53
            if (!string.IsNullOrEmpty(__tmp56_line))
            {
                __out.Append(__tmp56_line);
                __tmp53_outputWritten = true;
            }
            if (__tmp53_outputWritten) __out.AppendLine(true);
            if (__tmp53_outputWritten)
            {
                __out.AppendLine(false); //894:71
            }
            __out.Append("	}"); //895:1
            __out.AppendLine(false); //895:3
            __out.AppendLine(true); //896:2
            bool __tmp58_outputWritten = false;
            string __tmp59_line = "	public new "; //897:1
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
            string __tmp61_line = " ToMutable("; //897:55
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
            string __tmp63_line = ".MutableModel model)"; //897:85
            if (!string.IsNullOrEmpty(__tmp63_line))
            {
                __out.Append(__tmp63_line);
                __tmp58_outputWritten = true;
            }
            if (__tmp58_outputWritten) __out.AppendLine(true);
            if (__tmp58_outputWritten)
            {
                __out.AppendLine(false); //897:105
            }
            __out.Append("	{"); //898:1
            __out.AppendLine(false); //898:3
            bool __tmp65_outputWritten = false;
            string __tmp66_line = "		return ("; //899:1
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
            string __tmp68_line = ")base.ToMutable(model);"; //899:53
            if (!string.IsNullOrEmpty(__tmp68_line))
            {
                __out.Append(__tmp68_line);
                __tmp65_outputWritten = true;
            }
            if (__tmp65_outputWritten) __out.AppendLine(true);
            if (__tmp65_outputWritten)
            {
                __out.AppendLine(false); //899:76
            }
            __out.Append("	}"); //900:1
            __out.AppendLine(false); //900:3
            var __loop59_results = 
                (from __loop59_var1 in __Enumerate((cls).GetEnumerator()) //901:8
                from sup in __Enumerate((__loop59_var1.GetAllSuperClasses(false)).GetEnumerator()) //901:13
                select new { __loop59_var1 = __loop59_var1, sup = sup}
                ).ToList(); //901:3
            for (int __loop59_iteration = 0; __loop59_iteration < __loop59_results.Count; ++__loop59_iteration)
            {
                var __tmp69 = __loop59_results[__loop59_iteration];
                var __loop59_var1 = __tmp69.__loop59_var1;
                var sup = __tmp69.sup;
                __out.AppendLine(true); //902:2
                bool __tmp71_outputWritten = false;
                string __tmp70Prefix = "	"; //903:1
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
                string __tmp73_line = " "; //903:50
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
                string __tmp75_line = ".ToMutable()"; //903:101
                if (!string.IsNullOrEmpty(__tmp75_line))
                {
                    __out.Append(__tmp75_line);
                    __tmp71_outputWritten = true;
                }
                if (__tmp71_outputWritten) __out.AppendLine(true);
                if (__tmp71_outputWritten)
                {
                    __out.AppendLine(false); //903:113
                }
                __out.Append("	{"); //904:1
                __out.AppendLine(false); //904:3
                __out.Append("		return this.ToMutable();"); //905:1
                __out.AppendLine(false); //905:27
                __out.Append("	}"); //906:1
                __out.AppendLine(false); //906:3
                __out.AppendLine(true); //907:2
                bool __tmp77_outputWritten = false;
                string __tmp76Prefix = "	"; //908:1
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
                string __tmp79_line = " "; //908:50
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
                string __tmp81_line = ".ToMutable("; //908:101
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
                string __tmp83_line = ".MutableModel model)"; //908:131
                if (!string.IsNullOrEmpty(__tmp83_line))
                {
                    __out.Append(__tmp83_line);
                    __tmp77_outputWritten = true;
                }
                if (__tmp77_outputWritten) __out.AppendLine(true);
                if (__tmp77_outputWritten)
                {
                    __out.AppendLine(false); //908:151
                }
                __out.Append("	{"); //909:1
                __out.AppendLine(false); //909:3
                __out.Append("		return this.ToMutable(model);"); //910:1
                __out.AppendLine(false); //910:32
                __out.Append("	}"); //911:1
                __out.AppendLine(false); //911:3
            }
            var __loop60_results = 
                (from __loop60_var1 in __Enumerate((cls).GetEnumerator()) //913:8
                from prop in __Enumerate((__loop60_var1.GetAllProperties()).GetEnumerator()) //913:13
                select new { __loop60_var1 = __loop60_var1, prop = prop}
                ).ToList(); //913:3
            for (int __loop60_iteration = 0; __loop60_iteration < __loop60_results.Count; ++__loop60_iteration)
            {
                var __tmp84 = __loop60_results[__loop60_iteration];
                var __loop60_var1 = __tmp84.__loop60_var1;
                var prop = __tmp84.prop;
                __out.AppendLine(true); //914:2
                bool __tmp86_outputWritten = false;
                string __tmp85Prefix = "	"; //915:1
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
                    __out.AppendLine(false); //915:51
                }
            }
            var __loop61_results = 
                (from __loop61_var1 in __Enumerate((cls).GetEnumerator()) //917:8
                from op in __Enumerate((__loop61_var1.GetAllOperations()).GetEnumerator()) //917:13
                select new { __loop61_var1 = __loop61_var1, op = op}
                ).ToList(); //917:3
            for (int __loop61_iteration = 0; __loop61_iteration < __loop61_results.Count; ++__loop61_iteration)
            {
                var __tmp88 = __loop61_results[__loop61_iteration];
                var __loop61_var1 = __tmp88.__loop61_var1;
                var op = __tmp88.op;
                __out.AppendLine(true); //918:2
                bool __tmp90_outputWritten = false;
                string __tmp89Prefix = "	"; //919:1
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
                    __out.AppendLine(false); //919:50
                }
            }
            __out.Append("}"); //921:1
            __out.AppendLine(false); //921:2
            return __out.ToString();
        }

        public string GenerateImmutableField(MetaModel model, MetaClass cls, MetaProperty prop) //924:1
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
                __out.AppendLine(false); //925:54
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "private "; //926:1
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
            string __tmp8_line = " "; //926:65
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
            string __tmp10_line = ";"; //926:90
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp5_outputWritten = true;
            }
            if (__tmp5_outputWritten) __out.AppendLine(true);
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //926:91
            }
            return __out.ToString();
        }

        public string GenerateImmutablePropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //929:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //930:1
            if (cls.GetAllFinalProperties().Contains(prop)) //931:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //932:1
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
                string __tmp5_line = " "; //932:64
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
                    __out.AppendLine(false); //932:76
                }
            }
            else //933:2
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
                    __out.AppendLine(false); //934:54
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
                string __tmp13_line = " "; //935:57
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
                string __tmp15_line = "."; //935:115
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
                    __out.AppendLine(false); //935:127
                }
            }
            __out.Append("{"); //937:1
            __out.AppendLine(false); //937:2
            if (prop.Type is MetaCollectionType) //938:6
            {
                if (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.Set || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet) //939:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "    get { return this.GetSet<"; //940:1
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
                    string __tmp21_line = ">("; //940:118
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
                    string __tmp23_line = ", ref "; //940:174
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
                    string __tmp25_line = "); }"; //940:204
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Append(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //940:208
                    }
                }
                else //941:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "    get { return this.GetList<"; //942:1
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
                    string __tmp30_line = ">("; //942:119
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
                    string __tmp32_line = ", ref "; //942:175
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
                    string __tmp34_line = "); }"; //942:205
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Append(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //942:209
                    }
                }
            }
            else if (IsReferenceType(prop.Type)) //944:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "    get { return this.GetReference<"; //945:1
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
                string __tmp39_line = ">("; //945:92
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
                string __tmp41_line = ", ref "; //945:148
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
                string __tmp43_line = "); }"; //945:178
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Append(__tmp43_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //945:182
                }
            }
            else //946:3
            {
                bool __tmp45_outputWritten = false;
                string __tmp46_line = "    get { return this.GetValue<"; //947:1
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
                string __tmp48_line = ">("; //947:88
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
                string __tmp50_line = ", ref "; //947:144
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
                string __tmp52_line = "); }"; //947:174
                if (!string.IsNullOrEmpty(__tmp52_line))
                {
                    __out.Append(__tmp52_line);
                    __tmp45_outputWritten = true;
                }
                if (__tmp45_outputWritten) __out.AppendLine(true);
                if (__tmp45_outputWritten)
                {
                    __out.AppendLine(false); //947:178
                }
            }
            __out.Append("}"); //949:1
            __out.AppendLine(false); //949:2
            return __out.ToString();
        }

        public string GenerateImmutableOperationImpl(MetaModel model, MetaClass cls, MetaOperation op) //952:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //953:1
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
            string __tmp4_line = " "; //954:61
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
            string __tmp6_line = "."; //954:118
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
            string __tmp8_line = "("; //954:128
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
            string __tmp10_line = ")"; //954:182
            if (!string.IsNullOrEmpty(__tmp10_line))
            {
                __out.Append(__tmp10_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //954:183
            }
            __out.Append("{"); //955:1
            __out.AppendLine(false); //955:2
            bool __tmp12_outputWritten = false;
            string __tmp11Prefix = "    "; //956:1
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
            string __tmp15_line = ".Implementation."; //956:85
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
            string __tmp17_line = "_"; //956:151
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
            string __tmp19_line = "("; //956:161
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
            string __tmp21_line = ");"; //956:205
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp12_outputWritten = true;
            }
            if (__tmp12_outputWritten) __out.AppendLine(true);
            if (__tmp12_outputWritten)
            {
                __out.AppendLine(false); //956:207
            }
            __out.Append("}"); //957:1
            __out.AppendLine(false); //957:2
            return __out.ToString();
        }

        public string GenerateBuilderImplClass(MetaModel model, MetaClass cls) //960:1
        {
            StringBuilder __out = new StringBuilder();
            string metaNs = IsMetaMetaModel(model) ? "" : Properties.MetaNs + "."; //961:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "internal class "; //962:1
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
            string __tmp5_line = " : "; //962:62
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
            string __tmp7_line = ".MutableSymbolBase, "; //962:84
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
                __out.AppendLine(false); //962:146
            }
            __out.Append("{"); //963:1
            __out.AppendLine(false); //963:2
            var __loop62_results = 
                (from __loop62_var1 in __Enumerate((cls).GetEnumerator()) //964:8
                from prop in __Enumerate((__loop62_var1.GetAllProperties()).GetEnumerator()) //964:13
                where prop.Type is MetaCollectionType //964:37
                select new { __loop62_var1 = __loop62_var1, prop = prop}
                ).ToList(); //964:3
            for (int __loop62_iteration = 0; __loop62_iteration < __loop62_results.Count; ++__loop62_iteration)
            {
                var __tmp9 = __loop62_results[__loop62_iteration];
                var __loop62_var1 = __tmp9.__loop62_var1;
                var prop = __tmp9.prop;
                bool __tmp11_outputWritten = false;
                string __tmp10Prefix = "	"; //965:1
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
                    __out.AppendLine(false); //965:42
                }
            }
            __out.AppendLine(true); //967:2
            bool __tmp14_outputWritten = false;
            string __tmp15_line = "	internal "; //968:1
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
            string __tmp17_line = "("; //968:57
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
            string __tmp19_line = ".SymbolId id, "; //968:77
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
            string __tmp21_line = ".MutableModel model, bool creating)"; //968:110
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp14_outputWritten = true;
            }
            if (__tmp14_outputWritten) __out.AppendLine(true);
            if (__tmp14_outputWritten)
            {
                __out.AppendLine(false); //968:145
            }
            __out.Append("		: base(id, model, creating)"); //969:1
            __out.AppendLine(false); //969:30
            __out.Append("	{"); //970:1
            __out.AppendLine(false); //970:3
            __out.Append("	}"); //971:1
            __out.AppendLine(false); //971:3
            __out.AppendLine(true); //972:2
            __out.Append("	protected override void MInit()"); //973:1
            __out.AppendLine(false); //973:33
            __out.Append("	{"); //974:1
            __out.AppendLine(false); //974:3
            bool __tmp23_outputWritten = false;
            string __tmp22Prefix = "		"; //975:1
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
            string __tmp25_line = ".Implementation."; //975:55
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
            string __tmp27_line = "(this);"; //975:115
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Append(__tmp27_line);
                __tmp23_outputWritten = true;
            }
            if (__tmp23_outputWritten) __out.AppendLine(true);
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //975:122
            }
            __out.Append("	}"); //976:1
            __out.AppendLine(false); //976:3
            __out.AppendLine(true); //977:2
            bool __tmp29_outputWritten = false;
            string __tmp30_line = "	public override "; //978:1
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
            string __tmp32_line = "MetaModel MMetaModel"; //978:26
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Append(__tmp32_line);
                __tmp29_outputWritten = true;
            }
            if (__tmp29_outputWritten) __out.AppendLine(true);
            if (__tmp29_outputWritten)
            {
                __out.AppendLine(false); //978:46
            }
            __out.Append("	{"); //979:1
            __out.AppendLine(false); //979:3
            if (IsMetaMetaModel(model)) //980:4
            {
                bool __tmp34_outputWritten = false;
                string __tmp35_line = "		get { return "; //981:1
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
                string __tmp37_line = ".MetaMetaModel; }"; //981:77
                if (!string.IsNullOrEmpty(__tmp37_line))
                {
                    __out.Append(__tmp37_line);
                    __tmp34_outputWritten = true;
                }
                if (__tmp34_outputWritten) __out.AppendLine(true);
                if (__tmp34_outputWritten)
                {
                    __out.AppendLine(false); //981:94
                }
            }
            else //982:4
            {
                bool __tmp39_outputWritten = false;
                string __tmp40_line = "		get { return "; //983:1
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
                string __tmp42_line = ".MetaModel; }"; //983:77
                if (!string.IsNullOrEmpty(__tmp42_line))
                {
                    __out.Append(__tmp42_line);
                    __tmp39_outputWritten = true;
                }
                if (__tmp39_outputWritten) __out.AppendLine(true);
                if (__tmp39_outputWritten)
                {
                    __out.AppendLine(false); //983:90
                }
            }
            __out.Append("	}"); //985:1
            __out.AppendLine(false); //985:3
            __out.AppendLine(true); //986:2
            bool __tmp44_outputWritten = false;
            string __tmp45_line = "	public override "; //987:1
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
            string __tmp47_line = "MetaClass MMetaClass"; //987:26
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Append(__tmp47_line);
                __tmp44_outputWritten = true;
            }
            if (__tmp44_outputWritten) __out.AppendLine(true);
            if (__tmp44_outputWritten)
            {
                __out.AppendLine(false); //987:46
            }
            __out.Append("	{"); //988:1
            __out.AppendLine(false); //988:3
            bool __tmp49_outputWritten = false;
            string __tmp50_line = "		get { return "; //989:1
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
            string __tmp52_line = "; }"; //989:74
            if (!string.IsNullOrEmpty(__tmp52_line))
            {
                __out.Append(__tmp52_line);
                __tmp49_outputWritten = true;
            }
            if (__tmp49_outputWritten) __out.AppendLine(true);
            if (__tmp49_outputWritten)
            {
                __out.AppendLine(false); //989:77
            }
            __out.Append("	}"); //990:1
            __out.AppendLine(false); //990:3
            __out.AppendLine(true); //991:2
            bool __tmp54_outputWritten = false;
            string __tmp55_line = "	public new "; //992:1
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
            string __tmp57_line = " ToImmutable()"; //992:57
            if (!string.IsNullOrEmpty(__tmp57_line))
            {
                __out.Append(__tmp57_line);
                __tmp54_outputWritten = true;
            }
            if (__tmp54_outputWritten) __out.AppendLine(true);
            if (__tmp54_outputWritten)
            {
                __out.AppendLine(false); //992:71
            }
            __out.Append("	{"); //993:1
            __out.AppendLine(false); //993:3
            bool __tmp59_outputWritten = false;
            string __tmp60_line = "		return ("; //994:1
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
            string __tmp62_line = ")base.ToImmutable();"; //994:55
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Append(__tmp62_line);
                __tmp59_outputWritten = true;
            }
            if (__tmp59_outputWritten) __out.AppendLine(true);
            if (__tmp59_outputWritten)
            {
                __out.AppendLine(false); //994:75
            }
            __out.Append("	}"); //995:1
            __out.AppendLine(false); //995:3
            __out.AppendLine(true); //996:2
            bool __tmp64_outputWritten = false;
            string __tmp65_line = "	public new "; //997:1
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
            string __tmp67_line = " ToImmutable("; //997:57
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
            string __tmp69_line = ".ImmutableModel model)"; //997:89
            if (!string.IsNullOrEmpty(__tmp69_line))
            {
                __out.Append(__tmp69_line);
                __tmp64_outputWritten = true;
            }
            if (__tmp64_outputWritten) __out.AppendLine(true);
            if (__tmp64_outputWritten)
            {
                __out.AppendLine(false); //997:111
            }
            __out.Append("	{"); //998:1
            __out.AppendLine(false); //998:3
            bool __tmp71_outputWritten = false;
            string __tmp72_line = "		return ("; //999:1
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
            string __tmp74_line = ")base.ToImmutable(model);"; //999:55
            if (!string.IsNullOrEmpty(__tmp74_line))
            {
                __out.Append(__tmp74_line);
                __tmp71_outputWritten = true;
            }
            if (__tmp71_outputWritten) __out.AppendLine(true);
            if (__tmp71_outputWritten)
            {
                __out.AppendLine(false); //999:80
            }
            __out.Append("	}"); //1000:1
            __out.AppendLine(false); //1000:3
            var __loop63_results = 
                (from __loop63_var1 in __Enumerate((cls).GetEnumerator()) //1001:8
                from sup in __Enumerate((__loop63_var1.GetAllSuperClasses(false)).GetEnumerator()) //1001:13
                select new { __loop63_var1 = __loop63_var1, sup = sup}
                ).ToList(); //1001:3
            for (int __loop63_iteration = 0; __loop63_iteration < __loop63_results.Count; ++__loop63_iteration)
            {
                var __tmp75 = __loop63_results[__loop63_iteration];
                var __loop63_var1 = __tmp75.__loop63_var1;
                var sup = __tmp75.sup;
                __out.AppendLine(true); //1002:2
                bool __tmp77_outputWritten = false;
                string __tmp76Prefix = "	"; //1003:1
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
                string __tmp79_line = " "; //1003:52
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
                string __tmp81_line = ".ToImmutable()"; //1003:101
                if (!string.IsNullOrEmpty(__tmp81_line))
                {
                    __out.Append(__tmp81_line);
                    __tmp77_outputWritten = true;
                }
                if (__tmp77_outputWritten) __out.AppendLine(true);
                if (__tmp77_outputWritten)
                {
                    __out.AppendLine(false); //1003:115
                }
                __out.Append("	{"); //1004:1
                __out.AppendLine(false); //1004:3
                __out.Append("		return this.ToImmutable();"); //1005:1
                __out.AppendLine(false); //1005:29
                __out.Append("	}"); //1006:1
                __out.AppendLine(false); //1006:3
                __out.AppendLine(true); //1007:2
                bool __tmp83_outputWritten = false;
                string __tmp82Prefix = "	"; //1008:1
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
                string __tmp85_line = " "; //1008:52
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
                string __tmp87_line = ".ToImmutable("; //1008:101
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
                string __tmp89_line = ".ImmutableModel model)"; //1008:133
                if (!string.IsNullOrEmpty(__tmp89_line))
                {
                    __out.Append(__tmp89_line);
                    __tmp83_outputWritten = true;
                }
                if (__tmp83_outputWritten) __out.AppendLine(true);
                if (__tmp83_outputWritten)
                {
                    __out.AppendLine(false); //1008:155
                }
                __out.Append("	{"); //1009:1
                __out.AppendLine(false); //1009:3
                __out.Append("		return this.ToImmutable(model);"); //1010:1
                __out.AppendLine(false); //1010:34
                __out.Append("	}"); //1011:1
                __out.AppendLine(false); //1011:3
            }
            var __loop64_results = 
                (from __loop64_var1 in __Enumerate((cls).GetEnumerator()) //1013:8
                from prop in __Enumerate((__loop64_var1.GetAllProperties()).GetEnumerator()) //1013:13
                select new { __loop64_var1 = __loop64_var1, prop = prop}
                ).ToList(); //1013:3
            for (int __loop64_iteration = 0; __loop64_iteration < __loop64_results.Count; ++__loop64_iteration)
            {
                var __tmp90 = __loop64_results[__loop64_iteration];
                var __loop64_var1 = __tmp90.__loop64_var1;
                var prop = __tmp90.prop;
                __out.AppendLine(true); //1014:2
                bool __tmp92_outputWritten = false;
                string __tmp91Prefix = "	"; //1015:1
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
                    __out.AppendLine(false); //1015:49
                }
            }
            __out.Append("}"); //1017:1
            __out.AppendLine(false); //1017:2
            return __out.ToString();
        }

        public string GenerateBuilderField(MetaModel model, MetaClass cls, MetaProperty prop) //1020:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "private "; //1021:1
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
            string __tmp5_line = " "; //1021:63
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
            string __tmp7_line = ";"; //1021:88
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //1021:89
            }
            return __out.ToString();
        }

        public string GenerateBuilderPropertyImpl(MetaModel model, MetaClass cls, MetaProperty prop) //1024:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //1025:1
            if (cls.GetAllFinalProperties().Contains(prop)) //1026:2
            {
                bool __tmp2_outputWritten = false;
                string __tmp3_line = "public "; //1027:1
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
                string __tmp5_line = " "; //1027:62
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
                    __out.AppendLine(false); //1027:74
                }
            }
            else //1028:2
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
                    __out.AppendLine(false); //1029:54
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
                string __tmp13_line = " "; //1030:55
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
                string __tmp15_line = "."; //1030:111
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
                    __out.AppendLine(false); //1030:123
                }
            }
            __out.Append("{"); //1032:1
            __out.AppendLine(false); //1032:2
            if (prop.Type is MetaCollectionType) //1033:3
            {
                if (((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.Set || ((MetaCollectionType)prop.Type).Kind == MetaCollectionKind.MultiSet) //1034:4
                {
                    bool __tmp18_outputWritten = false;
                    string __tmp19_line = "	get { return this.GetSet<"; //1035:1
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
                    string __tmp21_line = ">("; //1035:113
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
                    string __tmp23_line = ", ref "; //1035:169
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
                    string __tmp25_line = "); }"; //1035:199
                    if (!string.IsNullOrEmpty(__tmp25_line))
                    {
                        __out.Append(__tmp25_line);
                        __tmp18_outputWritten = true;
                    }
                    if (__tmp18_outputWritten) __out.AppendLine(true);
                    if (__tmp18_outputWritten)
                    {
                        __out.AppendLine(false); //1035:203
                    }
                }
                else //1036:4
                {
                    bool __tmp27_outputWritten = false;
                    string __tmp28_line = "	get { return this.GetList<"; //1037:1
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
                    string __tmp30_line = ">("; //1037:114
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
                    string __tmp32_line = ", ref "; //1037:170
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
                    string __tmp34_line = "); }"; //1037:200
                    if (!string.IsNullOrEmpty(__tmp34_line))
                    {
                        __out.Append(__tmp34_line);
                        __tmp27_outputWritten = true;
                    }
                    if (__tmp27_outputWritten) __out.AppendLine(true);
                    if (__tmp27_outputWritten)
                    {
                        __out.AppendLine(false); //1037:204
                    }
                }
            }
            else if (IsReferenceType(prop.Type)) //1039:3
            {
                bool __tmp36_outputWritten = false;
                string __tmp37_line = "	get { return this.GetReference<"; //1040:1
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
                string __tmp39_line = ">("; //1040:87
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
                string __tmp41_line = "); }"; //1040:143
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Append(__tmp41_line);
                    __tmp36_outputWritten = true;
                }
                if (__tmp36_outputWritten) __out.AppendLine(true);
                if (__tmp36_outputWritten)
                {
                    __out.AppendLine(false); //1040:147
                }
            }
            else //1041:3
            {
                bool __tmp43_outputWritten = false;
                string __tmp44_line = "	get { return this.GetValue<"; //1042:1
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
                string __tmp46_line = ">("; //1042:83
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
                string __tmp48_line = "); }"; //1042:139
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Append(__tmp48_line);
                    __tmp43_outputWritten = true;
                }
                if (__tmp43_outputWritten) __out.AppendLine(true);
                if (__tmp43_outputWritten)
                {
                    __out.AppendLine(false); //1042:143
                }
            }
            if ((prop.Kind == MetaPropertyKind.Normal || prop.Kind == MetaPropertyKind.Containment) && !(prop.Type is MetaCollectionType)) //1044:3
            {
                if (IsReferenceType(prop.Type)) //1045:4
                {
                    bool __tmp50_outputWritten = false;
                    string __tmp51_line = "	set { this.SetReference<"; //1046:1
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
                    string __tmp53_line = ">("; //1046:80
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
                    string __tmp55_line = ", value); }"; //1046:136
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Append(__tmp55_line);
                        __tmp50_outputWritten = true;
                    }
                    if (__tmp50_outputWritten) __out.AppendLine(true);
                    if (__tmp50_outputWritten)
                    {
                        __out.AppendLine(false); //1046:147
                    }
                }
                else //1047:4
                {
                    bool __tmp57_outputWritten = false;
                    string __tmp58_line = "	set { this.SetValue<"; //1048:1
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
                    string __tmp60_line = ">("; //1048:76
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
                    string __tmp62_line = ", value); }"; //1048:132
                    if (!string.IsNullOrEmpty(__tmp62_line))
                    {
                        __out.Append(__tmp62_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //1048:143
                    }
                }
            }
            __out.Append("}"); //1051:1
            __out.AppendLine(false); //1051:2
            if (!(prop.Type is MetaCollectionType)) //1052:2
            {
                __out.AppendLine(true); //1053:1
                if (cls.GetAllFinalProperties().Contains(prop)) //1054:3
                {
                    bool __tmp64_outputWritten = false;
                    string __tmp65_line = "public Func<"; //1055:1
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
                    string __tmp67_line = "> "; //1055:67
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
                    string __tmp69_line = "Lazy"; //1055:80
                    if (!string.IsNullOrEmpty(__tmp69_line))
                    {
                        __out.Append(__tmp69_line);
                        __tmp64_outputWritten = true;
                    }
                    if (__tmp64_outputWritten) __out.AppendLine(true);
                    if (__tmp64_outputWritten)
                    {
                        __out.AppendLine(false); //1055:84
                    }
                }
                else //1056:3
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
                        __out.AppendLine(false); //1057:54
                    }
                    bool __tmp74_outputWritten = false;
                    string __tmp75_line = "Func<"; //1058:1
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
                    string __tmp77_line = "> "; //1058:60
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
                    string __tmp79_line = "."; //1058:117
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
                    string __tmp81_line = "Lazy"; //1058:129
                    if (!string.IsNullOrEmpty(__tmp81_line))
                    {
                        __out.Append(__tmp81_line);
                        __tmp74_outputWritten = true;
                    }
                    if (__tmp74_outputWritten) __out.AppendLine(true);
                    if (__tmp74_outputWritten)
                    {
                        __out.AppendLine(false); //1058:133
                    }
                }
                __out.Append("{"); //1060:1
                __out.AppendLine(false); //1060:2
                if (IsReferenceType(prop.Type)) //1061:3
                {
                    bool __tmp83_outputWritten = false;
                    string __tmp84_line = "	get { return this.GetLazyReference<"; //1062:1
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
                    string __tmp86_line = ">("; //1062:91
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
                    string __tmp88_line = "); }"; //1062:147
                    if (!string.IsNullOrEmpty(__tmp88_line))
                    {
                        __out.Append(__tmp88_line);
                        __tmp83_outputWritten = true;
                    }
                    if (__tmp83_outputWritten) __out.AppendLine(true);
                    if (__tmp83_outputWritten)
                    {
                        __out.AppendLine(false); //1062:151
                    }
                    bool __tmp90_outputWritten = false;
                    string __tmp91_line = "	set { this.SetLazyReference("; //1063:1
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
                    string __tmp93_line = ", value); }"; //1063:85
                    if (!string.IsNullOrEmpty(__tmp93_line))
                    {
                        __out.Append(__tmp93_line);
                        __tmp90_outputWritten = true;
                    }
                    if (__tmp90_outputWritten) __out.AppendLine(true);
                    if (__tmp90_outputWritten)
                    {
                        __out.AppendLine(false); //1063:96
                    }
                }
                else //1064:3
                {
                    bool __tmp95_outputWritten = false;
                    string __tmp96_line = "	get { return this.GetLazyValue<"; //1065:1
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
                    string __tmp98_line = ">("; //1065:87
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
                    string __tmp100_line = "); }"; //1065:143
                    if (!string.IsNullOrEmpty(__tmp100_line))
                    {
                        __out.Append(__tmp100_line);
                        __tmp95_outputWritten = true;
                    }
                    if (__tmp95_outputWritten) __out.AppendLine(true);
                    if (__tmp95_outputWritten)
                    {
                        __out.AppendLine(false); //1065:147
                    }
                    bool __tmp102_outputWritten = false;
                    string __tmp103_line = "	set { this.SetLazyValue("; //1066:1
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
                    string __tmp105_line = ", value); }"; //1066:81
                    if (!string.IsNullOrEmpty(__tmp105_line))
                    {
                        __out.Append(__tmp105_line);
                        __tmp102_outputWritten = true;
                    }
                    if (__tmp102_outputWritten) __out.AppendLine(true);
                    if (__tmp102_outputWritten)
                    {
                        __out.AppendLine(false); //1066:92
                    }
                }
                __out.Append("}"); //1068:1
                __out.AppendLine(false); //1068:2
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
