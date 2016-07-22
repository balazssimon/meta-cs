using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable //1:1
{
    using __Hidden_ImmutableMetaModelGenerator_1857000377;
    namespace __Hidden_ImmutableMetaModelGenerator_1857000377
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
        string ToCamelCase(string identifier); //23:8
        string ToPascalCase(string identifier); //24:8
        bool IsCoreModel(MetaModel mmodel); //25:8
        string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false); //26:8
        string CSharpName(MetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false); //27:8
        string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false); //28:8
        string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false); //29:8
        string CSharpName(MetaConstant mconst, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false); //30:8
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

        public __Properties Properties { get; private set; } //4:1

        public class __Properties //4:1
        {
            internal __Properties()
            {
                this.CoreNs = "global::MetaDslx.Core.Immutable"; //5:18
            }
            public string CoreNs { get; set; } //5:2
        }

        public string Generate() //8:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("using System;"); //9:1
            __out.AppendLine(false); //9:14
            __out.Append("using System.Collections.Generic;"); //10:1
            __out.AppendLine(false); //10:34
            __out.Append("using System.IO;"); //11:1
            __out.AppendLine(false); //11:17
            __out.Append("using System.Linq;"); //12:1
            __out.AppendLine(false); //12:19
            __out.Append("using System.Text;"); //13:1
            __out.AppendLine(false); //13:19
            __out.Append("using System.Threading;"); //14:1
            __out.AppendLine(false); //14:24
            __out.Append("using System.Threading.Tasks;"); //15:1
            __out.AppendLine(false); //15:30
            __out.Append("using System.Diagnostics;"); //16:1
            __out.AppendLine(false); //16:26
            __out.AppendLine(true); //17:1
            var __loop1_results = 
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //18:8
                from mm in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaModel>() //18:19
                select new { __loop1_var1 = __loop1_var1, mm = mm}
                ).ToList(); //18:3
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
                    __out.AppendLine(false); //19:24
                }
            }
            return __out.ToString();
        }

        internal string ToCamelCase(string identifier) //23:8
        {
            return this.extensionFunctions.ToCamelCase(identifier); //23:8
        }

        internal string ToPascalCase(string identifier) //24:8
        {
            return this.extensionFunctions.ToPascalCase(identifier); //24:8
        }

        internal bool IsCoreModel(MetaModel mmodel) //25:8
        {
            return this.extensionFunctions.IsCoreModel(mmodel); //25:8
        }

        internal string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false) //26:8
        {
            return this.extensionFunctions.CSharpName(mnamespace, kind, fullName); //26:8
        }

        internal string CSharpName(MetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false) //27:8
        {
            return this.extensionFunctions.CSharpName(mmodel, kind, fullName); //27:8
        }

        internal string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false) //28:8
        {
            return this.extensionFunctions.CSharpName(mtype, mmodel, kind, fullName); //28:8
        }

        internal string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false) //29:8
        {
            return this.extensionFunctions.CSharpName(mproperty, mmodel, kind, fullName); //29:8
        }

        internal string CSharpName(MetaConstant mconst, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false) //30:8
        {
            return this.extensionFunctions.CSharpName(mconst, mmodel, kind, fullName); //30:8
        }

        public string GenerateDocumentation(MetaDocumentedElement elem) //32:1
        {
            StringBuilder __out = new StringBuilder();
            ImmutableModelList<string> lines = elem.GetDocumentationLines(); //33:2
            if (lines.Count > 0) //34:2
            {
                __out.Append("/**"); //35:1
                __out.AppendLine(false); //35:4
                __out.Append(" * <summary>"); //36:1
                __out.AppendLine(false); //36:13
                var __loop2_results = 
                    (from line in __Enumerate((lines).GetEnumerator()) //37:8
                    select new { line = line}
                    ).ToList(); //37:3
                for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
                {
                    var __tmp1 = __loop2_results[__loop2_iteration];
                    var line = __tmp1.line;
                    bool __tmp3_outputWritten = false;
                    string __tmp4_line = " * "; //38:1
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
                        __out.AppendLine(false); //38:10
                    }
                }
                __out.Append(" * </summary>"); //40:1
                __out.AppendLine(false); //40:14
                __out.Append(" */"); //41:1
                __out.AppendLine(false); //41:4
            }
            return __out.ToString();
        }

        public string GenerateAnnotations(MetaAnnotatedElement elem) //45:1
        {
            StringBuilder __out = new StringBuilder();
            var __loop3_results = 
                (from __loop3_var1 in __Enumerate((elem).GetEnumerator()) //46:7
                from annot in __Enumerate((__loop3_var1.Annotations).GetEnumerator()) //46:13
                select new { __loop3_var1 = __loop3_var1, annot = annot}
                ).ToList(); //46:2
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
                __tmp5.Append(annot.Name);
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
                StringBuilder __tmp6 = new StringBuilder();
                __tmp6.Append("]");
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
                        if (!__tmp6_last || __tmp3_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp3_outputWritten)
                {
                    __out.AppendLine(false); //47:23
                }
            }
            return __out.ToString();
        }

        public string GenerateMetamodel(MetaModel model) //51:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //52:1
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
                __out.AppendLine(false); //52:67
            }
            __out.Append("{"); //53:1
            __out.AppendLine(false); //53:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	using global::"; //54:1
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
            string __tmp9_line = ";"; //54:74
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //54:75
            }
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	using global::"; //55:1
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Append(__tmp12_line);
                __tmp11_outputWritten = true;
            }
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(CSharpName(model.Namespace, NamespaceKind.Implementation, true));
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
            string __tmp14_line = ";"; //55:80
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //55:81
            }
            __out.AppendLine(true); //56:1
            bool __tmp16_outputWritten = false;
            string __tmp15Prefix = "	"; //57:1
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(GenerateMetaModelInstance(model));
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
                __out.AppendLine(false); //57:36
            }
            __out.AppendLine(true); //58:1
            bool __tmp19_outputWritten = false;
            string __tmp18Prefix = "	"; //59:1
            StringBuilder __tmp20 = new StringBuilder();
            __tmp20.Append(GenerateFactory(model));
            using(StreamReader __tmp20Reader = new StreamReader(this.__ToStream(__tmp20.ToString())))
            {
                bool __tmp20_last = __tmp20Reader.EndOfStream;
                while(!__tmp20_last)
                {
                    string __tmp20_line = __tmp20Reader.ReadLine();
                    __tmp20_last = __tmp20Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp18Prefix))
                    {
                        __out.Append(__tmp18Prefix);
                        __tmp19_outputWritten = true;
                    }
                    if ((__tmp20_last && !string.IsNullOrEmpty(__tmp20_line)) || (!__tmp20_last && __tmp20_line != null))
                    {
                        __out.Append(__tmp20_line);
                        __tmp19_outputWritten = true;
                    }
                    if (!__tmp20_last || __tmp19_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp19_outputWritten)
            {
                __out.AppendLine(false); //59:26
            }
            __out.AppendLine(true); //60:1
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((model).GetEnumerator()) //61:8
                from Namespace in __Enumerate((__loop4_var1.Namespace).GetEnumerator()) //61:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //61:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //61:40
                select new { __loop4_var1 = __loop4_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //61:3
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp21 = __loop4_results[__loop4_iteration];
                var __loop4_var1 = __tmp21.__loop4_var1;
                var Namespace = __tmp21.Namespace;
                var Declarations = __tmp21.Declarations;
                var enm = __tmp21.enm;
                __out.AppendLine(true); //62:1
                bool __tmp23_outputWritten = false;
                string __tmp22Prefix = "	"; //63:1
                StringBuilder __tmp24 = new StringBuilder();
                __tmp24.Append(GenerateEnum(model, enm));
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
                        if (!__tmp24_last || __tmp23_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp23_outputWritten)
                {
                    __out.AppendLine(false); //63:28
                }
            }
            __out.AppendLine(true); //65:1
            bool __tmp26_outputWritten = false;
            string __tmp25Prefix = "	"; //66:1
            StringBuilder __tmp27 = new StringBuilder();
            __tmp27.Append(GenerateMetaModelDescriptor(model));
            using(StreamReader __tmp27Reader = new StreamReader(this.__ToStream(__tmp27.ToString())))
            {
                bool __tmp27_last = __tmp27Reader.EndOfStream;
                while(!__tmp27_last)
                {
                    string __tmp27_line = __tmp27Reader.ReadLine();
                    __tmp27_last = __tmp27Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp25Prefix))
                    {
                        __out.Append(__tmp25Prefix);
                        __tmp26_outputWritten = true;
                    }
                    if ((__tmp27_last && !string.IsNullOrEmpty(__tmp27_line)) || (!__tmp27_last && __tmp27_line != null))
                    {
                        __out.Append(__tmp27_line);
                        __tmp26_outputWritten = true;
                    }
                    if (!__tmp27_last || __tmp26_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp26_outputWritten)
            {
                __out.AppendLine(false); //66:38
            }
            __out.Append("}"); //67:1
            __out.AppendLine(false); //67:2
            __out.AppendLine(true); //68:1
            bool __tmp29_outputWritten = false;
            string __tmp30_line = "namespace "; //69:1
            if (!string.IsNullOrEmpty(__tmp30_line))
            {
                __out.Append(__tmp30_line);
                __tmp29_outputWritten = true;
            }
            StringBuilder __tmp31 = new StringBuilder();
            __tmp31.Append(CSharpName(model.Namespace, NamespaceKind.Implementation, true));
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
                    if (!__tmp31_last || __tmp29_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp29_outputWritten)
            {
                __out.AppendLine(false); //69:75
            }
            __out.Append("{"); //70:1
            __out.AppendLine(false); //70:2
            bool __tmp33_outputWritten = false;
            string __tmp32Prefix = "	"; //71:1
            StringBuilder __tmp34 = new StringBuilder();
            __tmp34.Append(GenerateMetaModelBuilderInstance(model));
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
                __out.AppendLine(false); //71:43
            }
            __out.AppendLine(true); //72:1
            bool __tmp36_outputWritten = false;
            string __tmp35Prefix = "	"; //73:1
            StringBuilder __tmp37 = new StringBuilder();
            __tmp37.Append(GenerateImplementationProvider(model));
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
                __out.AppendLine(false); //73:41
            }
            __out.Append("}"); //74:1
            __out.AppendLine(false); //74:2
            __out.AppendLine(true); //75:1
            bool __tmp39_outputWritten = false;
            string __tmp40_line = "namespace "; //76:1
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Append(__tmp40_line);
                __tmp39_outputWritten = true;
            }
            StringBuilder __tmp41 = new StringBuilder();
            __tmp41.Append(CSharpName(model.Namespace, NamespaceKind.Internal, true));
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
                    if (!__tmp41_last || __tmp39_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp39_outputWritten)
            {
                __out.AppendLine(false); //76:69
            }
            __out.Append("{"); //77:1
            __out.AppendLine(false); //77:2
            bool __tmp43_outputWritten = false;
            string __tmp42Prefix = "	"; //78:1
            StringBuilder __tmp44 = new StringBuilder();
            __tmp44.Append(GenerateImplementationBase(model));
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
                __out.AppendLine(false); //78:37
            }
            __out.Append("}"); //79:1
            __out.AppendLine(false); //79:2
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //82:1
        {
            StringBuilder __out = new StringBuilder();
            string coreNs = IsCoreModel(model) ? "" : Properties.CoreNs + "."; //83:2
            bool coreModel = IsCoreModel(model); //84:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //85:1
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
                __out.AppendLine(false); //85:61
            }
            __out.Append("{"); //86:1
            __out.AppendLine(false); //86:2
            __out.Append("	private static bool initialized;"); //87:1
            __out.AppendLine(false); //87:34
            __out.AppendLine(true); //88:1
            __out.Append("	public static bool IsInitialized"); //89:1
            __out.AppendLine(false); //89:34
            __out.Append("	{"); //90:1
            __out.AppendLine(false); //90:3
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "		get { return "; //91:1
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
            string __tmp9_line = ".initialized; }"; //91:63
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //91:78
            }
            __out.Append("	}"); //92:1
            __out.AppendLine(false); //92:3
            __out.AppendLine(true); //93:1
            if (coreModel) //94:3
            {
                bool __tmp11_outputWritten = false;
                string __tmp12_line = "	public static readonly "; //95:1
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
                string __tmp14_line = "MetaModel _MetaModel;"; //95:33
                if (!string.IsNullOrEmpty(__tmp14_line))
                {
                    __out.Append(__tmp14_line);
                    __tmp11_outputWritten = true;
                }
                if (__tmp11_outputWritten) __out.AppendLine(true);
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //95:54
                }
            }
            else //96:3
            {
                bool __tmp16_outputWritten = false;
                string __tmp17_line = "	public static readonly "; //97:1
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
                string __tmp19_line = "MetaModel MetaModel;"; //97:33
                if (!string.IsNullOrEmpty(__tmp19_line))
                {
                    __out.Append(__tmp19_line);
                    __tmp16_outputWritten = true;
                }
                if (__tmp16_outputWritten) __out.AppendLine(true);
                if (__tmp16_outputWritten)
                {
                    __out.AppendLine(false); //97:53
                }
            }
            bool __tmp21_outputWritten = false;
            string __tmp22_line = "	public static readonly "; //99:1
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
            string __tmp24_line = ".ImmutableModel Model;"; //99:44
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp21_outputWritten = true;
            }
            if (__tmp21_outputWritten) __out.AppendLine(true);
            if (__tmp21_outputWritten)
            {
                __out.AppendLine(false); //99:66
            }
            __out.AppendLine(true); //100:1
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //101:8
                from cst in __Enumerate((__loop5_var1).GetEnumerator()).OfType<MetaConstant>() //101:38
                select new { __loop5_var1 = __loop5_var1, cst = cst}
                ).ToList(); //101:3
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp25 = __loop5_results[__loop5_iteration];
                var __loop5_var1 = __tmp25.__loop5_var1;
                var cst = __tmp25.cst;
                bool __tmp27_outputWritten = false;
                string __tmp26Prefix = "	"; //102:1
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
                    __out.AppendLine(false); //102:30
                }
                if (coreModel) //103:4
                {
                    bool __tmp30_outputWritten = false;
                    string __tmp31_line = "	public static readonly "; //104:1
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
                    string __tmp33_line = " "; //104:74
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
                    string __tmp35_line = ";"; //104:127
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Append(__tmp35_line);
                        __tmp30_outputWritten = true;
                    }
                    if (__tmp30_outputWritten) __out.AppendLine(true);
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //104:128
                    }
                }
                else //105:4
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "	public static readonly "; //106:1
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
                    string __tmp40_line = " "; //106:80
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
                    string __tmp42_line = ";"; //106:133
                    if (!string.IsNullOrEmpty(__tmp42_line))
                    {
                        __out.Append(__tmp42_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //106:134
                    }
                }
            }
            __out.AppendLine(true); //109:1
            var __loop6_results = 
                (from __loop6_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //110:8
                from cls in __Enumerate((__loop6_var1).GetEnumerator()).OfType<MetaClass>() //110:38
                select new { __loop6_var1 = __loop6_var1, cls = cls}
                ).ToList(); //110:3
            for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
            {
                var __tmp43 = __loop6_results[__loop6_iteration];
                var __loop6_var1 = __tmp43.__loop6_var1;
                var cls = __tmp43.cls;
                bool __tmp45_outputWritten = false;
                string __tmp44Prefix = "	"; //111:1
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
                    __out.AppendLine(false); //111:30
                }
                bool __tmp48_outputWritten = false;
                string __tmp49_line = "	public static readonly "; //112:1
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
                string __tmp51_line = "MetaClass "; //112:33
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
                string __tmp53_line = ";"; //112:95
                if (!string.IsNullOrEmpty(__tmp53_line))
                {
                    __out.Append(__tmp53_line);
                    __tmp48_outputWritten = true;
                }
                if (__tmp48_outputWritten) __out.AppendLine(true);
                if (__tmp48_outputWritten)
                {
                    __out.AppendLine(false); //112:96
                }
                var __loop7_results = 
                    (from __loop7_var1 in __Enumerate((cls).GetEnumerator()) //113:9
                    from prop in __Enumerate((__loop7_var1.Properties).GetEnumerator()) //113:14
                    select new { __loop7_var1 = __loop7_var1, prop = prop}
                    ).ToList(); //113:4
                for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
                {
                    var __tmp54 = __loop7_results[__loop7_iteration];
                    var __loop7_var1 = __tmp54.__loop7_var1;
                    var prop = __tmp54.prop;
                    bool __tmp56_outputWritten = false;
                    string __tmp55Prefix = "	"; //114:1
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
                        __out.AppendLine(false); //114:31
                    }
                    bool __tmp59_outputWritten = false;
                    string __tmp60_line = "	public static readonly "; //115:1
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
                    string __tmp62_line = "MetaProperty "; //115:33
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
                    string __tmp64_line = ";"; //115:102
                    if (!string.IsNullOrEmpty(__tmp64_line))
                    {
                        __out.Append(__tmp64_line);
                        __tmp59_outputWritten = true;
                    }
                    if (__tmp59_outputWritten) __out.AppendLine(true);
                    if (__tmp59_outputWritten)
                    {
                        __out.AppendLine(false); //115:103
                    }
                }
            }
            __out.AppendLine(true); //118:1
            bool __tmp66_outputWritten = false;
            string __tmp67_line = "	static "; //119:1
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
            string __tmp69_line = "()"; //119:56
            if (!string.IsNullOrEmpty(__tmp69_line))
            {
                __out.Append(__tmp69_line);
                __tmp66_outputWritten = true;
            }
            if (__tmp66_outputWritten) __out.AppendLine(true);
            if (__tmp66_outputWritten)
            {
                __out.AppendLine(false); //119:58
            }
            __out.Append("	{"); //120:1
            __out.AppendLine(false); //120:3
            if (coreModel) //121:4
            {
                bool __tmp71_outputWritten = false;
                string __tmp72_line = "		_MetaModel = "; //122:1
                if (!string.IsNullOrEmpty(__tmp72_line))
                {
                    __out.Append(__tmp72_line);
                    __tmp71_outputWritten = true;
                }
                StringBuilder __tmp73 = new StringBuilder();
                __tmp73.Append(CSharpName(model, ModelKind.BuilderInstance));
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
                string __tmp74_line = "._MetaModel.ToImmutable();"; //122:61
                if (!string.IsNullOrEmpty(__tmp74_line))
                {
                    __out.Append(__tmp74_line);
                    __tmp71_outputWritten = true;
                }
                if (__tmp71_outputWritten) __out.AppendLine(true);
                if (__tmp71_outputWritten)
                {
                    __out.AppendLine(false); //122:87
                }
            }
            else //123:4
            {
                bool __tmp76_outputWritten = false;
                string __tmp77_line = "		MetaModel = "; //124:1
                if (!string.IsNullOrEmpty(__tmp77_line))
                {
                    __out.Append(__tmp77_line);
                    __tmp76_outputWritten = true;
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
                            __tmp76_outputWritten = true;
                        }
                        if (!__tmp78_last) __out.AppendLine(true);
                    }
                }
                string __tmp79_line = ".MetaModel.ToImmutable();"; //124:60
                if (!string.IsNullOrEmpty(__tmp79_line))
                {
                    __out.Append(__tmp79_line);
                    __tmp76_outputWritten = true;
                }
                if (__tmp76_outputWritten) __out.AppendLine(true);
                if (__tmp76_outputWritten)
                {
                    __out.AppendLine(false); //124:85
                }
            }
            bool __tmp81_outputWritten = false;
            string __tmp82_line = "		Model = "; //126:1
            if (!string.IsNullOrEmpty(__tmp82_line))
            {
                __out.Append(__tmp82_line);
                __tmp81_outputWritten = true;
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
                        __tmp81_outputWritten = true;
                    }
                    if (!__tmp83_last) __out.AppendLine(true);
                }
            }
            string __tmp84_line = ".Model.ToImmutable();"; //126:56
            if (!string.IsNullOrEmpty(__tmp84_line))
            {
                __out.Append(__tmp84_line);
                __tmp81_outputWritten = true;
            }
            if (__tmp81_outputWritten) __out.AppendLine(true);
            if (__tmp81_outputWritten)
            {
                __out.AppendLine(false); //126:77
            }
            __out.AppendLine(true); //127:1
            var __loop8_results = 
                (from __loop8_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //128:9
                from cst in __Enumerate((__loop8_var1).GetEnumerator()).OfType<MetaConstant>() //128:39
                select new { __loop8_var1 = __loop8_var1, cst = cst}
                ).ToList(); //128:4
            for (int __loop8_iteration = 0; __loop8_iteration < __loop8_results.Count; ++__loop8_iteration)
            {
                var __tmp85 = __loop8_results[__loop8_iteration];
                var __loop8_var1 = __tmp85.__loop8_var1;
                var cst = __tmp85.cst;
                if (coreModel) //129:5
                {
                    bool __tmp87_outputWritten = false;
                    string __tmp86Prefix = "		"; //130:1
                    StringBuilder __tmp88 = new StringBuilder();
                    __tmp88.Append(CSharpName(cst, model, ClassKind.ImmutableInstance));
                    using(StreamReader __tmp88Reader = new StreamReader(this.__ToStream(__tmp88.ToString())))
                    {
                        bool __tmp88_last = __tmp88Reader.EndOfStream;
                        while(!__tmp88_last)
                        {
                            string __tmp88_line = __tmp88Reader.ReadLine();
                            __tmp88_last = __tmp88Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp86Prefix))
                            {
                                __out.Append(__tmp86Prefix);
                                __tmp87_outputWritten = true;
                            }
                            if ((__tmp88_last && !string.IsNullOrEmpty(__tmp88_line)) || (!__tmp88_last && __tmp88_line != null))
                            {
                                __out.Append(__tmp88_line);
                                __tmp87_outputWritten = true;
                            }
                            if (!__tmp88_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp89_line = " = "; //130:55
                    if (!string.IsNullOrEmpty(__tmp89_line))
                    {
                        __out.Append(__tmp89_line);
                        __tmp87_outputWritten = true;
                    }
                    StringBuilder __tmp90 = new StringBuilder();
                    __tmp90.Append(CSharpName(cst, model, ClassKind.BuilderInstance, true));
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
                    string __tmp91_line = ".ToImmutable(Model);"; //130:114
                    if (!string.IsNullOrEmpty(__tmp91_line))
                    {
                        __out.Append(__tmp91_line);
                        __tmp87_outputWritten = true;
                    }
                    if (__tmp87_outputWritten) __out.AppendLine(true);
                    if (__tmp87_outputWritten)
                    {
                        __out.AppendLine(false); //130:134
                    }
                }
                else //131:5
                {
                    bool __tmp93_outputWritten = false;
                    string __tmp92Prefix = "		"; //132:1
                    StringBuilder __tmp94 = new StringBuilder();
                    __tmp94.Append(CSharpName(cst, model, ClassKind.ImmutableInstance));
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
                    string __tmp95_line = " = "; //132:55
                    if (!string.IsNullOrEmpty(__tmp95_line))
                    {
                        __out.Append(__tmp95_line);
                        __tmp93_outputWritten = true;
                    }
                    StringBuilder __tmp96 = new StringBuilder();
                    __tmp96.Append(CSharpName(cst, model, ClassKind.BuilderInstance, true));
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
                    string __tmp97_line = ".ToImmutable(Model);"; //132:114
                    if (!string.IsNullOrEmpty(__tmp97_line))
                    {
                        __out.Append(__tmp97_line);
                        __tmp93_outputWritten = true;
                    }
                    if (__tmp93_outputWritten) __out.AppendLine(true);
                    if (__tmp93_outputWritten)
                    {
                        __out.AppendLine(false); //132:134
                    }
                }
            }
            __out.AppendLine(true); //135:1
            var __loop9_results = 
                (from __loop9_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //136:9
                from cls in __Enumerate((__loop9_var1).GetEnumerator()).OfType<MetaClass>() //136:39
                select new { __loop9_var1 = __loop9_var1, cls = cls}
                ).ToList(); //136:4
            for (int __loop9_iteration = 0; __loop9_iteration < __loop9_results.Count; ++__loop9_iteration)
            {
                var __tmp98 = __loop9_results[__loop9_iteration];
                var __loop9_var1 = __tmp98.__loop9_var1;
                var cls = __tmp98.cls;
                bool __tmp100_outputWritten = false;
                string __tmp99Prefix = "		"; //137:1
                StringBuilder __tmp101 = new StringBuilder();
                __tmp101.Append(CSharpName(cls, model, ClassKind.ImmutableInstance));
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
                string __tmp102_line = " = "; //137:55
                if (!string.IsNullOrEmpty(__tmp102_line))
                {
                    __out.Append(__tmp102_line);
                    __tmp100_outputWritten = true;
                }
                StringBuilder __tmp103 = new StringBuilder();
                __tmp103.Append(CSharpName(cls, model, ClassKind.BuilderInstance, true));
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
                string __tmp104_line = ".ToImmutable(Model);"; //137:114
                if (!string.IsNullOrEmpty(__tmp104_line))
                {
                    __out.Append(__tmp104_line);
                    __tmp100_outputWritten = true;
                }
                if (__tmp100_outputWritten) __out.AppendLine(true);
                if (__tmp100_outputWritten)
                {
                    __out.AppendLine(false); //137:134
                }
                var __loop10_results = 
                    (from __loop10_var1 in __Enumerate((cls).GetEnumerator()) //138:10
                    from prop in __Enumerate((__loop10_var1.Properties).GetEnumerator()) //138:15
                    select new { __loop10_var1 = __loop10_var1, prop = prop}
                    ).ToList(); //138:5
                for (int __loop10_iteration = 0; __loop10_iteration < __loop10_results.Count; ++__loop10_iteration)
                {
                    var __tmp105 = __loop10_results[__loop10_iteration];
                    var __loop10_var1 = __tmp105.__loop10_var1;
                    var prop = __tmp105.prop;
                    bool __tmp107_outputWritten = false;
                    string __tmp106Prefix = "		"; //139:1
                    StringBuilder __tmp108 = new StringBuilder();
                    __tmp108.Append(CSharpName(prop, model, PropertyKind.ImmutableInstance));
                    using(StreamReader __tmp108Reader = new StreamReader(this.__ToStream(__tmp108.ToString())))
                    {
                        bool __tmp108_last = __tmp108Reader.EndOfStream;
                        while(!__tmp108_last)
                        {
                            string __tmp108_line = __tmp108Reader.ReadLine();
                            __tmp108_last = __tmp108Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp106Prefix))
                            {
                                __out.Append(__tmp106Prefix);
                                __tmp107_outputWritten = true;
                            }
                            if ((__tmp108_last && !string.IsNullOrEmpty(__tmp108_line)) || (!__tmp108_last && __tmp108_line != null))
                            {
                                __out.Append(__tmp108_line);
                                __tmp107_outputWritten = true;
                            }
                            if (!__tmp108_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp109_line = " = "; //139:59
                    if (!string.IsNullOrEmpty(__tmp109_line))
                    {
                        __out.Append(__tmp109_line);
                        __tmp107_outputWritten = true;
                    }
                    StringBuilder __tmp110 = new StringBuilder();
                    __tmp110.Append(CSharpName(prop, model, PropertyKind.BuilderInstance, true));
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
                                __tmp107_outputWritten = true;
                            }
                            if (!__tmp110_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp111_line = ".ToImmutable(Model);"; //139:122
                    if (!string.IsNullOrEmpty(__tmp111_line))
                    {
                        __out.Append(__tmp111_line);
                        __tmp107_outputWritten = true;
                    }
                    if (__tmp107_outputWritten) __out.AppendLine(true);
                    if (__tmp107_outputWritten)
                    {
                        __out.AppendLine(false); //139:142
                    }
                }
            }
            __out.AppendLine(true); //142:1
            bool __tmp113_outputWritten = false;
            string __tmp112Prefix = "		"; //143:1
            StringBuilder __tmp114 = new StringBuilder();
            __tmp114.Append(CSharpName(model, ModelKind.ImmutableInstance));
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
            string __tmp115_line = ".initialized = true;"; //143:50
            if (!string.IsNullOrEmpty(__tmp115_line))
            {
                __out.Append(__tmp115_line);
                __tmp113_outputWritten = true;
            }
            if (__tmp113_outputWritten) __out.AppendLine(true);
            if (__tmp113_outputWritten)
            {
                __out.AppendLine(false); //143:70
            }
            __out.Append("	}"); //144:1
            __out.AppendLine(false); //144:3
            __out.Append("}"); //145:1
            __out.AppendLine(false); //145:2
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //148:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //149:1
            __out.AppendLine(false); //149:14
            __out.Append("/// Factory class for creating instances of model elements."); //150:1
            __out.AppendLine(false); //150:60
            __out.Append("/// </summary>"); //151:1
            __out.AppendLine(false); //151:15
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //152:1
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
            string __tmp5_line = " : "; //152:51
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
            string __tmp7_line = ".ModelFactory"; //152:73
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //152:86
            }
            __out.Append("{"); //153:1
            __out.AppendLine(false); //153:2
            bool __tmp9_outputWritten = false;
            string __tmp10_line = "    public "; //154:1
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
            string __tmp12_line = "("; //154:49
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
            string __tmp14_line = ".MutableModel model, "; //154:69
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
            string __tmp16_line = ".ModelFactoryFlags flags = "; //154:109
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
            string __tmp18_line = ".ModelFactoryFlags.None)"; //154:155
            if (!string.IsNullOrEmpty(__tmp18_line))
            {
                __out.Append(__tmp18_line);
                __tmp9_outputWritten = true;
            }
            if (__tmp9_outputWritten) __out.AppendLine(true);
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //154:179
            }
            __out.Append("        : base(model, flags)"); //155:1
            __out.AppendLine(false); //155:29
            __out.Append("    {"); //156:1
            __out.AppendLine(false); //156:6
            bool __tmp20_outputWritten = false;
            string __tmp19Prefix = "		"; //157:1
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
            string __tmp22_line = ".Initialize();"; //157:43
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Append(__tmp22_line);
                __tmp20_outputWritten = true;
            }
            if (__tmp20_outputWritten) __out.AppendLine(true);
            if (__tmp20_outputWritten)
            {
                __out.AppendLine(false); //157:57
            }
            __out.Append("    }"); //158:1
            __out.AppendLine(false); //158:6
            __out.AppendLine(true); //159:1
            bool __tmp24_outputWritten = false;
            string __tmp25_line = "    public override "; //160:1
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
            string __tmp27_line = ".MutableSymbolBase Create(string type)"; //160:40
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Append(__tmp27_line);
                __tmp24_outputWritten = true;
            }
            if (__tmp24_outputWritten) __out.AppendLine(true);
            if (__tmp24_outputWritten)
            {
                __out.AppendLine(false); //160:78
            }
            __out.Append("    {"); //161:1
            __out.AppendLine(false); //161:6
            __out.Append("        switch (type)"); //162:1
            __out.AppendLine(false); //162:22
            __out.Append("        {"); //163:1
            __out.AppendLine(false); //163:10
            var __loop11_results = 
                (from __loop11_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //164:10
                from cls in __Enumerate((__loop11_var1).GetEnumerator()).OfType<MetaClass>() //164:40
                select new { __loop11_var1 = __loop11_var1, cls = cls}
                ).ToList(); //164:5
            for (int __loop11_iteration = 0; __loop11_iteration < __loop11_results.Count; ++__loop11_iteration)
            {
                var __tmp28 = __loop11_results[__loop11_iteration];
                var __loop11_var1 = __tmp28.__loop11_var1;
                var cls = __tmp28.cls;
                if (!cls.IsAbstract) //165:6
                {
                    bool __tmp30_outputWritten = false;
                    string __tmp31_line = "            case \""; //166:1
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
                    string __tmp33_line = "\": return ("; //166:42
                    if (!string.IsNullOrEmpty(__tmp33_line))
                    {
                        __out.Append(__tmp33_line);
                        __tmp30_outputWritten = true;
                    }
                    StringBuilder __tmp34 = new StringBuilder();
                    __tmp34.Append(Properties.CoreNs);
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
                    string __tmp35_line = ".MutableSymbolBase)this."; //166:72
                    if (!string.IsNullOrEmpty(__tmp35_line))
                    {
                        __out.Append(__tmp35_line);
                        __tmp30_outputWritten = true;
                    }
                    StringBuilder __tmp36 = new StringBuilder();
                    __tmp36.Append(CSharpName(cls, model));
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
                    string __tmp37_line = "();"; //166:119
                    if (!string.IsNullOrEmpty(__tmp37_line))
                    {
                        __out.Append(__tmp37_line);
                        __tmp30_outputWritten = true;
                    }
                    if (__tmp30_outputWritten) __out.AppendLine(true);
                    if (__tmp30_outputWritten)
                    {
                        __out.AppendLine(false); //166:122
                    }
                }
            }
            __out.Append("            default:"); //169:1
            __out.AppendLine(false); //169:21
            bool __tmp39_outputWritten = false;
            string __tmp40_line = "                throw new "; //170:1
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Append(__tmp40_line);
                __tmp39_outputWritten = true;
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
                        __tmp39_outputWritten = true;
                    }
                    if (!__tmp41_last) __out.AppendLine(true);
                }
            }
            string __tmp42_line = ".ModelException(\"Unknown type name: \" + type);"; //170:46
            if (!string.IsNullOrEmpty(__tmp42_line))
            {
                __out.Append(__tmp42_line);
                __tmp39_outputWritten = true;
            }
            if (__tmp39_outputWritten) __out.AppendLine(true);
            if (__tmp39_outputWritten)
            {
                __out.AppendLine(false); //170:92
            }
            __out.Append("        }"); //171:1
            __out.AppendLine(false); //171:10
            __out.Append("    }"); //172:1
            __out.AppendLine(false); //172:6
            var __loop12_results = 
                (from __loop12_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //173:8
                from cls in __Enumerate((__loop12_var1).GetEnumerator()).OfType<MetaClass>() //173:38
                select new { __loop12_var1 = __loop12_var1, cls = cls}
                ).ToList(); //173:3
            for (int __loop12_iteration = 0; __loop12_iteration < __loop12_results.Count; ++__loop12_iteration)
            {
                var __tmp43 = __loop12_results[__loop12_iteration];
                var __loop12_var1 = __tmp43.__loop12_var1;
                var cls = __tmp43.cls;
                if (!cls.IsAbstract) //174:4
                {
                    __out.AppendLine(true); //175:1
                    __out.Append("    /// <summary>"); //176:1
                    __out.AppendLine(false); //176:18
                    bool __tmp45_outputWritten = false;
                    string __tmp46_line = "    /// Creates a new instance of "; //177:1
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
                    string __tmp48_line = "."; //177:58
                    if (!string.IsNullOrEmpty(__tmp48_line))
                    {
                        __out.Append(__tmp48_line);
                        __tmp45_outputWritten = true;
                    }
                    if (__tmp45_outputWritten) __out.AppendLine(true);
                    if (__tmp45_outputWritten)
                    {
                        __out.AppendLine(false); //177:59
                    }
                    __out.Append("    /// </summary>"); //178:1
                    __out.AppendLine(false); //178:19
                    bool __tmp50_outputWritten = false;
                    string __tmp51_line = "    public "; //179:1
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
                    string __tmp53_line = " "; //179:54
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
                    string __tmp55_line = "()"; //179:103
                    if (!string.IsNullOrEmpty(__tmp55_line))
                    {
                        __out.Append(__tmp55_line);
                        __tmp50_outputWritten = true;
                    }
                    if (__tmp50_outputWritten) __out.AppendLine(true);
                    if (__tmp50_outputWritten)
                    {
                        __out.AppendLine(false); //179:105
                    }
                    __out.Append("	{"); //180:1
                    __out.AppendLine(false); //180:3
                    bool __tmp57_outputWritten = false;
                    string __tmp56Prefix = "		"; //181:1
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
                    string __tmp59_line = ".MutableSymbolBase symbol = this.CreateSymbol(new "; //181:22
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
                    string __tmp61_line = "());"; //181:109
                    if (!string.IsNullOrEmpty(__tmp61_line))
                    {
                        __out.Append(__tmp61_line);
                        __tmp57_outputWritten = true;
                    }
                    if (__tmp57_outputWritten) __out.AppendLine(true);
                    if (__tmp57_outputWritten)
                    {
                        __out.AppendLine(false); //181:113
                    }
                    bool __tmp63_outputWritten = false;
                    string __tmp64_line = "		return ("; //182:1
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
                    string __tmp66_line = ")symbol;"; //182:53
                    if (!string.IsNullOrEmpty(__tmp66_line))
                    {
                        __out.Append(__tmp66_line);
                        __tmp63_outputWritten = true;
                    }
                    if (__tmp63_outputWritten) __out.AppendLine(true);
                    if (__tmp63_outputWritten)
                    {
                        __out.AppendLine(false); //182:61
                    }
                    __out.Append("	}"); //183:1
                    __out.AppendLine(false); //183:3
                }
            }
            __out.Append("}"); //186:1
            __out.AppendLine(false); //186:2
            __out.AppendLine(true); //187:1
            return __out.ToString();
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //190:1
        {
            StringBuilder __out = new StringBuilder();
            string coreNs = IsCoreModel(model) ? "" : Properties.CoreNs + "."; //191:2
            bool coreModel = IsCoreModel(model); //192:2
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public static class "; //193:1
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
                __out.AppendLine(false); //193:61
            }
            __out.Append("{"); //194:1
            __out.AppendLine(false); //194:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	private static global::System.Collections.Generic.List<"; //195:1
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
            string __tmp9_line = ".ModelProperty> properties;"; //195:76
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //195:103
            }
            __out.AppendLine(true); //196:1
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	static "; //197:1
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
            string __tmp14_line = "()"; //197:49
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //197:51
            }
            __out.Append("	{"); //198:1
            __out.AppendLine(false); //198:3
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "		properties = new global::System.Collections.Generic.List<"; //199:1
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
            string __tmp19_line = ".ModelProperty>();"; //199:79
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //199:97
            }
            var __loop13_results = 
                (from __loop13_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //200:9
                from cls in __Enumerate((__loop13_var1).GetEnumerator()).OfType<MetaClass>() //200:39
                from prop in __Enumerate((cls.Properties).GetEnumerator()) //200:62
                select new { __loop13_var1 = __loop13_var1, cls = cls, prop = prop}
                ).ToList(); //200:4
            for (int __loop13_iteration = 0; __loop13_iteration < __loop13_results.Count; ++__loop13_iteration)
            {
                var __tmp20 = __loop13_results[__loop13_iteration];
                var __loop13_var1 = __tmp20.__loop13_var1;
                var cls = __tmp20.cls;
                var prop = __tmp20.prop;
                bool __tmp22_outputWritten = false;
                string __tmp23_line = "		properties.Add("; //201:1
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
                string __tmp25_line = ");"; //201:73
                if (!string.IsNullOrEmpty(__tmp25_line))
                {
                    __out.Append(__tmp25_line);
                    __tmp22_outputWritten = true;
                }
                if (__tmp22_outputWritten) __out.AppendLine(true);
                if (__tmp22_outputWritten)
                {
                    __out.AppendLine(false); //201:75
                }
            }
            __out.Append("	}"); //203:1
            __out.AppendLine(false); //203:3
            __out.AppendLine(true); //204:1
            __out.Append("	public static void Initialize()"); //205:1
            __out.AppendLine(false); //205:33
            __out.Append("	{"); //206:1
            __out.AppendLine(false); //206:3
            __out.Append("	}"); //207:1
            __out.AppendLine(false); //207:3
            __out.AppendLine(true); //208:1
            bool __tmp27_outputWritten = false;
            string __tmp28_line = "	public const string Uri = \""; //209:1
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
            string __tmp30_line = "\";"; //209:40
            if (!string.IsNullOrEmpty(__tmp30_line))
            {
                __out.Append(__tmp30_line);
                __tmp27_outputWritten = true;
            }
            if (__tmp27_outputWritten) __out.AppendLine(true);
            if (__tmp27_outputWritten)
            {
                __out.AppendLine(false); //209:42
            }
            var __loop14_results = 
                (from __loop14_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //210:8
                from cls in __Enumerate((__loop14_var1).GetEnumerator()).OfType<MetaClass>() //210:38
                select new { __loop14_var1 = __loop14_var1, cls = cls}
                ).ToList(); //210:3
            for (int __loop14_iteration = 0; __loop14_iteration < __loop14_results.Count; ++__loop14_iteration)
            {
                var __tmp31 = __loop14_results[__loop14_iteration];
                var __loop14_var1 = __tmp31.__loop14_var1;
                var cls = __tmp31.cls;
                __out.AppendLine(true); //211:1
                bool __tmp33_outputWritten = false;
                string __tmp32Prefix = "	"; //212:1
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
                    __out.AppendLine(false); //212:39
                }
            }
            __out.Append("}"); //214:1
            __out.AppendLine(false); //214:2
            return __out.ToString();
        }

        public string GenerateDescriptorClass(MetaModel model, MetaClass cls) //217:1
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
                __out.AppendLine(false); //218:29
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
                __out.AppendLine(false); //219:27
            }
            if (cls.SuperClasses.Count > 0) //220:2
            {
                bool __tmp8_outputWritten = false;
                StringBuilder __tmp9 = new StringBuilder();
                __tmp9.Append("[" + Properties.CoreNs + ".ModelSymbolDecriptorAttribute(");
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
                StringBuilder __tmp10 = new StringBuilder();
                __tmp10.Append(GetDescriptorAncestors(model, cls));
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
                StringBuilder __tmp11 = new StringBuilder();
                __tmp11.Append(")]");
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
                        if (!__tmp11_last || __tmp8_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp8_outputWritten)
                {
                    __out.AppendLine(false); //221:100
                }
            }
            else //222:2
            {
                bool __tmp13_outputWritten = false;
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append("[" + Properties.CoreNs + ".ModelSymbolDecriptorAttribute]");
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
                            __tmp13_outputWritten = true;
                        }
                        if (!__tmp14_last || __tmp13_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //223:58
                }
            }
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "public static class "; //225:1
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp16_outputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(CSharpName(cls, model, ClassKind.Descriptor));
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
                    if (!__tmp18_last || __tmp16_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //225:66
            }
            __out.Append("{"); //226:1
            __out.AppendLine(false); //226:2
            bool __tmp20_outputWritten = false;
            string __tmp21_line = "	private static "; //227:1
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp20_outputWritten = true;
            }
            StringBuilder __tmp22 = new StringBuilder();
            __tmp22.Append(Properties.CoreNs);
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
            string __tmp23_line = ".ModelSymbolInfo modelSymbolInfo;"; //227:36
            if (!string.IsNullOrEmpty(__tmp23_line))
            {
                __out.Append(__tmp23_line);
                __tmp20_outputWritten = true;
            }
            if (__tmp20_outputWritten) __out.AppendLine(true);
            if (__tmp20_outputWritten)
            {
                __out.AppendLine(false); //227:69
            }
            __out.AppendLine(true); //228:1
            bool __tmp25_outputWritten = false;
            string __tmp26_line = "	static "; //229:1
            if (!string.IsNullOrEmpty(__tmp26_line))
            {
                __out.Append(__tmp26_line);
                __tmp25_outputWritten = true;
            }
            StringBuilder __tmp27 = new StringBuilder();
            __tmp27.Append(CSharpName(cls, model, ClassKind.Descriptor));
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
            string __tmp28_line = "()"; //229:54
            if (!string.IsNullOrEmpty(__tmp28_line))
            {
                __out.Append(__tmp28_line);
                __tmp25_outputWritten = true;
            }
            if (__tmp25_outputWritten) __out.AppendLine(true);
            if (__tmp25_outputWritten)
            {
                __out.AppendLine(false); //229:56
            }
            __out.Append("	{"); //230:1
            __out.AppendLine(false); //230:3
            bool __tmp30_outputWritten = false;
            string __tmp31_line = "		modelSymbolInfo = "; //231:1
            if (!string.IsNullOrEmpty(__tmp31_line))
            {
                __out.Append(__tmp31_line);
                __tmp30_outputWritten = true;
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
                        __tmp30_outputWritten = true;
                    }
                    if (!__tmp32_last) __out.AppendLine(true);
                }
            }
            string __tmp33_line = ".ModelSymbolInfo.GetSymbolInfo(typeof("; //231:40
            if (!string.IsNullOrEmpty(__tmp33_line))
            {
                __out.Append(__tmp33_line);
                __tmp30_outputWritten = true;
            }
            StringBuilder __tmp34 = new StringBuilder();
            __tmp34.Append(CSharpName(cls, model, ClassKind.Descriptor));
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
            string __tmp35_line = "));"; //231:123
            if (!string.IsNullOrEmpty(__tmp35_line))
            {
                __out.Append(__tmp35_line);
                __tmp30_outputWritten = true;
            }
            if (__tmp30_outputWritten) __out.AppendLine(true);
            if (__tmp30_outputWritten)
            {
                __out.AppendLine(false); //231:126
            }
            __out.Append("	}"); //232:1
            __out.AppendLine(false); //232:3
            __out.AppendLine(true); //233:1
            bool __tmp37_outputWritten = false;
            string __tmp38_line = "	public static "; //234:1
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
            string __tmp40_line = ".ModelSymbolInfo ModelSymbolInfo"; //234:35
            if (!string.IsNullOrEmpty(__tmp40_line))
            {
                __out.Append(__tmp40_line);
                __tmp37_outputWritten = true;
            }
            if (__tmp37_outputWritten) __out.AppendLine(true);
            if (__tmp37_outputWritten)
            {
                __out.AppendLine(false); //234:67
            }
            __out.Append("	{"); //235:1
            __out.AppendLine(false); //235:3
            __out.Append("		get { return modelSymbolInfo; }"); //236:1
            __out.AppendLine(false); //236:34
            __out.Append("	}"); //237:1
            __out.AppendLine(false); //237:3
            __out.AppendLine(true); //238:1
            if (cls.Name == "MetaClass") //239:3
            {
                bool __tmp42_outputWritten = false;
                string __tmp43_line = "	public static "; //240:1
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
                string __tmp45_line = ".MetaClass _MetaClass"; //240:35
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Append(__tmp45_line);
                    __tmp42_outputWritten = true;
                }
                if (__tmp42_outputWritten) __out.AppendLine(true);
                if (__tmp42_outputWritten)
                {
                    __out.AppendLine(false); //240:56
                }
            }
            else //241:3
            {
                bool __tmp47_outputWritten = false;
                string __tmp48_line = "	public static "; //242:1
                if (!string.IsNullOrEmpty(__tmp48_line))
                {
                    __out.Append(__tmp48_line);
                    __tmp47_outputWritten = true;
                }
                StringBuilder __tmp49 = new StringBuilder();
                __tmp49.Append(Properties.CoreNs);
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
                string __tmp50_line = ".MetaClass MetaClass"; //242:35
                if (!string.IsNullOrEmpty(__tmp50_line))
                {
                    __out.Append(__tmp50_line);
                    __tmp47_outputWritten = true;
                }
                if (__tmp47_outputWritten) __out.AppendLine(true);
                if (__tmp47_outputWritten)
                {
                    __out.AppendLine(false); //242:55
                }
            }
            __out.Append("	{"); //244:1
            __out.AppendLine(false); //244:3
            bool __tmp52_outputWritten = false;
            string __tmp53_line = "		get { return "; //245:1
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
            string __tmp55_line = "; }"; //245:73
            if (!string.IsNullOrEmpty(__tmp55_line))
            {
                __out.Append(__tmp55_line);
                __tmp52_outputWritten = true;
            }
            if (__tmp52_outputWritten) __out.AppendLine(true);
            if (__tmp52_outputWritten)
            {
                __out.AppendLine(false); //245:76
            }
            __out.Append("	}"); //246:1
            __out.AppendLine(false); //246:3
            var __loop15_results = 
                (from __loop15_var1 in __Enumerate((cls).GetEnumerator()) //247:8
                from prop in __Enumerate((__loop15_var1.Properties).GetEnumerator()) //247:13
                select new { __loop15_var1 = __loop15_var1, prop = prop}
                ).ToList(); //247:3
            for (int __loop15_iteration = 0; __loop15_iteration < __loop15_results.Count; ++__loop15_iteration)
            {
                var __tmp56 = __loop15_results[__loop15_iteration];
                var __loop15_var1 = __tmp56.__loop15_var1;
                var prop = __tmp56.prop;
                bool __tmp58_outputWritten = false;
                string __tmp57Prefix = "	"; //248:1
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
                    __out.AppendLine(false); //248:48
                }
            }
            __out.Append("}"); //250:1
            __out.AppendLine(false); //250:2
            return __out.ToString();
        }

        public string GetDescriptorAncestors(MetaModel model, MetaClass cls) //253:1
        {
            string result = ""; //254:2
            var __loop16_results = 
                (from __loop16_var1 in __Enumerate((cls).GetEnumerator()) //255:7
                from super in __Enumerate((__loop16_var1.SuperClasses).GetEnumerator()) //255:12
                select new { __loop16_var1 = __loop16_var1, super = super}
                ).ToList(); //255:2
            for (int __loop16_iteration = 0; __loop16_iteration < __loop16_results.Count; ++__loop16_iteration)
            {
                string delim; //255:30
                if (__loop16_iteration+1 < __loop16_results.Count) delim = ", ";
                else delim = string.Empty;
                var __tmp1 = __loop16_results[__loop16_iteration];
                var __loop16_var1 = __tmp1.__loop16_var1;
                var super = __tmp1.super;
                result += "typeof(" + CSharpName(super, model, ClassKind.Descriptor, true) + ")" + delim; //256:3
            }
            return result; //258:2
        }

        public string GenerateDescriptorProperty(MetaModel model, MetaClass cls, MetaProperty prop) //261:1
        {
            StringBuilder __out = new StringBuilder();
            __out.AppendLine(true); //262:1
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
                __out.AppendLine(false); //263:30
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
                __out.AppendLine(false); //264:28
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
                __out.AppendLine(false); //265:58
            }
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "public static readonly "; //266:1
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
            string __tmp14_line = ".ModelProperty "; //266:43
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
            string __tmp16_line = " ="; //266:107
            if (!string.IsNullOrEmpty(__tmp16_line))
            {
                __out.Append(__tmp16_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //266:109
            }
            bool __tmp18_outputWritten = false;
            string __tmp17Prefix = "    "; //267:1
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
            string __tmp20_line = ".ModelProperty.Register(typeof("; //267:24
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
            string __tmp22_line = "), \""; //267:100
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
            string __tmp24_line = "\","; //267:128
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp18_outputWritten = true;
            }
            if (__tmp18_outputWritten) __out.AppendLine(true);
            if (__tmp18_outputWritten)
            {
                __out.AppendLine(false); //267:130
            }
            if (prop.Type is MetaCollectionType) //268:2
            {
                MetaCollectionType collType = (MetaCollectionType)prop.Type; //269:3
                bool __tmp26_outputWritten = false;
                string __tmp27_line = "        new "; //270:1
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
                string __tmp29_line = ".ModelPropertyTypeInfo(typeof("; //270:32
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
                string __tmp31_line = "), typeof("; //270:126
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
                string __tmp33_line = ")),"; //270:191
                if (!string.IsNullOrEmpty(__tmp33_line))
                {
                    __out.Append(__tmp33_line);
                    __tmp26_outputWritten = true;
                }
                if (__tmp26_outputWritten) __out.AppendLine(true);
                if (__tmp26_outputWritten)
                {
                    __out.AppendLine(false); //270:194
                }
                bool __tmp35_outputWritten = false;
                string __tmp36_line = "        new "; //271:1
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
                string __tmp38_line = ".ModelPropertyTypeInfo(typeof("; //271:32
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
                string __tmp40_line = "), typeof("; //271:124
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
                string __tmp42_line = ")),"; //271:187
                if (!string.IsNullOrEmpty(__tmp42_line))
                {
                    __out.Append(__tmp42_line);
                    __tmp35_outputWritten = true;
                }
                if (__tmp35_outputWritten) __out.AppendLine(true);
                if (__tmp35_outputWritten)
                {
                    __out.AppendLine(false); //271:190
                }
            }
            else //272:2
            {
                bool __tmp44_outputWritten = false;
                string __tmp45_line = "        new "; //273:1
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
                string __tmp47_line = ".ModelPropertyTypeInfo(typeof("; //273:32
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
                string __tmp49_line = "), null),"; //273:117
                if (!string.IsNullOrEmpty(__tmp49_line))
                {
                    __out.Append(__tmp49_line);
                    __tmp44_outputWritten = true;
                }
                if (__tmp44_outputWritten) __out.AppendLine(true);
                if (__tmp44_outputWritten)
                {
                    __out.AppendLine(false); //273:126
                }
                bool __tmp51_outputWritten = false;
                string __tmp52_line = "        new "; //274:1
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
                string __tmp54_line = ".ModelPropertyTypeInfo(typeof("; //274:32
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
                string __tmp56_line = "), null),"; //274:115
                if (!string.IsNullOrEmpty(__tmp56_line))
                {
                    __out.Append(__tmp56_line);
                    __tmp51_outputWritten = true;
                }
                if (__tmp51_outputWritten) __out.AppendLine(true);
                if (__tmp51_outputWritten)
                {
                    __out.AppendLine(false); //274:124
                }
            }
            bool __tmp58_outputWritten = false;
            string __tmp59_line = "		() => "; //276:1
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
            string __tmp61_line = ");"; //276:70
            if (!string.IsNullOrEmpty(__tmp61_line))
            {
                __out.Append(__tmp61_line);
                __tmp58_outputWritten = true;
            }
            if (__tmp58_outputWritten) __out.AppendLine(true);
            if (__tmp58_outputWritten)
            {
                __out.AppendLine(false); //276:72
            }
            return __out.ToString();
        }

        public string GenerateDescriptorPropertyAnnotations(MetaModel model, MetaClass cls, MetaProperty prop) //279:1
        {
            StringBuilder __out = new StringBuilder();
            if (prop.Kind == MetaPropertyKind.Containment) //280:2
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
                    __out.AppendLine(false); //281:49
                }
            }
            if (prop.Kind != MetaPropertyKind.Normal && prop.Kind != MetaPropertyKind.Containment) //283:2
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
                    __out.AppendLine(false); //284:46
                }
            }
            var __loop17_results = 
                (from p in __Enumerate((prop.OppositeProperties).GetEnumerator()) //286:7
                select new { p = p}
                ).ToList(); //286:2
            for (int __loop17_iteration = 0; __loop17_iteration < __loop17_results.Count; ++__loop17_iteration)
            {
                var __tmp7 = __loop17_results[__loop17_iteration];
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
                    __out.AppendLine(false); //287:146
                }
            }
            var __loop18_results = 
                (from p in __Enumerate((prop.SubsettedProperties).GetEnumerator()) //289:7
                select new { p = p}
                ).ToList(); //289:2
            for (int __loop18_iteration = 0; __loop18_iteration < __loop18_results.Count; ++__loop18_iteration)
            {
                var __tmp15 = __loop18_results[__loop18_iteration];
                var p = __tmp15.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //290:3
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
                        __out.AppendLine(false); //291:145
                    }
                }
                else //292:3
                {
                    bool __tmp24_outputWritten = false;
                    string __tmp25_line = "// ERROR: subsetted property '"; //293:1
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
                    string __tmp27_line = "' must be a property of this class or an ancestor class"; //293:83
                    if (!string.IsNullOrEmpty(__tmp27_line))
                    {
                        __out.Append(__tmp27_line);
                        __tmp24_outputWritten = true;
                    }
                    if (__tmp24_outputWritten) __out.AppendLine(true);
                    if (__tmp24_outputWritten)
                    {
                        __out.AppendLine(false); //293:138
                    }
                }
            }
            var __loop19_results = 
                (from p in __Enumerate((prop.RedefinedProperties).GetEnumerator()) //296:7
                select new { p = p}
                ).ToList(); //296:2
            for (int __loop19_iteration = 0; __loop19_iteration < __loop19_results.Count; ++__loop19_iteration)
            {
                var __tmp28 = __loop19_results[__loop19_iteration];
                var p = __tmp28.p;
                if (cls.GetAllSuperClasses(true).Contains(p.Class)) //297:3
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
                        __out.AppendLine(false); //298:147
                    }
                }
                else //299:3
                {
                    bool __tmp37_outputWritten = false;
                    string __tmp38_line = "// ERROR: redefined property '"; //300:1
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
                    string __tmp40_line = "' must be a property of this class or an ancestor class"; //300:83
                    if (!string.IsNullOrEmpty(__tmp40_line))
                    {
                        __out.Append(__tmp40_line);
                        __tmp37_outputWritten = true;
                    }
                    if (__tmp37_outputWritten) __out.AppendLine(true);
                    if (__tmp37_outputWritten)
                    {
                        __out.AppendLine(false); //300:138
                    }
                }
            }
            return __out.ToString();
        }

        public string GenerateMetaModelBuilderInstance(MetaModel model) //305:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //306:1
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
                __out.AppendLine(false); //306:59
            }
            __out.Append("{"); //307:1
            __out.AppendLine(false); //307:2
            __out.Append("}"); //308:1
            __out.AppendLine(false); //308:2
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //311:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //312:1
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
                __out.AppendLine(false); //312:66
            }
            __out.Append("{"); //313:1
            __out.AppendLine(false); //313:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "	// If there is a compile error at this line, create a new class called "; //314:1
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
                __out.AppendLine(false); //314:117
            }
            bool __tmp10_outputWritten = false;
            string __tmp11_line = "	// which is a subclass of "; //315:1
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
            string __tmp13_line = ":"; //315:82
            if (!string.IsNullOrEmpty(__tmp13_line))
            {
                __out.Append(__tmp13_line);
                __tmp10_outputWritten = true;
            }
            if (__tmp10_outputWritten) __out.AppendLine(true);
            if (__tmp10_outputWritten)
            {
                __out.AppendLine(false); //315:83
            }
            bool __tmp15_outputWritten = false;
            string __tmp16_line = "	private static "; //316:1
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
            string __tmp18_line = " implementation = new "; //316:61
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
            string __tmp20_line = "();"; //316:127
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp15_outputWritten = true;
            }
            if (__tmp15_outputWritten) __out.AppendLine(true);
            if (__tmp15_outputWritten)
            {
                __out.AppendLine(false); //316:130
            }
            __out.AppendLine(true); //317:1
            bool __tmp22_outputWritten = false;
            string __tmp23_line = "	public static "; //318:1
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
            string __tmp25_line = " Implementation"; //318:60
            if (!string.IsNullOrEmpty(__tmp25_line))
            {
                __out.Append(__tmp25_line);
                __tmp22_outputWritten = true;
            }
            if (__tmp22_outputWritten) __out.AppendLine(true);
            if (__tmp22_outputWritten)
            {
                __out.AppendLine(false); //318:75
            }
            __out.Append("	{"); //319:1
            __out.AppendLine(false); //319:3
            __out.Append("		get { return implementation; }"); //320:1
            __out.AppendLine(false); //320:33
            __out.Append("	}"); //321:1
            __out.AppendLine(false); //321:3
            __out.Append("}"); //322:1
            __out.AppendLine(false); //322:2
            return __out.ToString();
        }

        public string GenerateImplementationBase(MetaModel model) //325:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("/// <summary>"); //326:1
            __out.AppendLine(false); //326:14
            __out.Append("/// Base class for implementing the behavior of the model elements."); //327:1
            __out.AppendLine(false); //327:68
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "/// This class has to be be overriden in "; //328:1
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
            string __tmp5_line = " to provide custom"; //328:92
            if (!string.IsNullOrEmpty(__tmp5_line))
            {
                __out.Append(__tmp5_line);
                __tmp2_outputWritten = true;
            }
            if (__tmp2_outputWritten) __out.AppendLine(true);
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //328:110
            }
            __out.Append("/// implementation for the constructors, operations and property values."); //329:1
            __out.AppendLine(false); //329:73
            __out.Append("/// </summary>"); //330:1
            __out.AppendLine(false); //330:15
            bool __tmp7_outputWritten = false;
            string __tmp8_line = "internal abstract class "; //331:1
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
                __out.AppendLine(false); //331:73
            }
            __out.Append("{"); //332:1
            __out.AppendLine(false); //332:2
            __out.Append("	/// <summary>"); //333:1
            __out.AppendLine(false); //333:15
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	/// Implements the constructor: "; //334:1
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
            string __tmp14_line = "()"; //334:79
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //334:81
            }
            __out.Append("	/// </summary>"); //335:1
            __out.AppendLine(false); //335:16
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	public virtual void "; //336:1
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
            string __tmp19_line = "("; //336:67
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
            string __tmp21_line = " _this)"; //336:113
            if (!string.IsNullOrEmpty(__tmp21_line))
            {
                __out.Append(__tmp21_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //336:120
            }
            __out.Append("	{"); //337:1
            __out.AppendLine(false); //337:3
            __out.Append("	}"); //338:1
            __out.AppendLine(false); //338:3
            var __loop20_results = 
                (from __loop20_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //339:8
                from cls in __Enumerate((__loop20_var1).GetEnumerator()).OfType<MetaClass>() //339:38
                select new { __loop20_var1 = __loop20_var1, cls = cls}
                ).ToList(); //339:3
            for (int __loop20_iteration = 0; __loop20_iteration < __loop20_results.Count; ++__loop20_iteration)
            {
                var __tmp22 = __loop20_results[__loop20_iteration];
                var __loop20_var1 = __tmp22.__loop20_var1;
                var cls = __tmp22.cls;
                __out.AppendLine(true); //340:1
                __out.Append("	/// <summary>"); //341:1
                __out.AppendLine(false); //341:15
                bool __tmp24_outputWritten = false;
                string __tmp25_line = "	/// Implements the constructor: "; //342:1
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
                string __tmp27_line = "()"; //342:78
                if (!string.IsNullOrEmpty(__tmp27_line))
                {
                    __out.Append(__tmp27_line);
                    __tmp24_outputWritten = true;
                }
                if (__tmp24_outputWritten) __out.AppendLine(true);
                if (__tmp24_outputWritten)
                {
                    __out.AppendLine(false); //342:80
                }
                __out.Append("	/// </summary>"); //343:1
                __out.AppendLine(false); //343:16
                if ((from __loop21_var1 in __Enumerate((cls).GetEnumerator()) //344:15
                from sup in __Enumerate((__loop21_var1.SuperClasses).GetEnumerator()) //344:20
                select new { __loop21_var1 = __loop21_var1, sup = sup}
                ).GetEnumerator().MoveNext()) //344:3
                {
                    __out.Append("	/// Direct superclasses: "); //345:1
                    __out.AppendLine(false); //345:27
                    __out.Append("	/// <ul>"); //346:1
                    __out.AppendLine(false); //346:10
                    var __loop22_results = 
                        (from __loop22_var1 in __Enumerate((cls).GetEnumerator()) //347:8
                        from sup in __Enumerate((__loop22_var1.SuperClasses).GetEnumerator()) //347:13
                        select new { __loop22_var1 = __loop22_var1, sup = sup}
                        ).ToList(); //347:3
                    for (int __loop22_iteration = 0; __loop22_iteration < __loop22_results.Count; ++__loop22_iteration)
                    {
                        var __tmp28 = __loop22_results[__loop22_iteration];
                        var __loop22_var1 = __tmp28.__loop22_var1;
                        var sup = __tmp28.sup;
                        bool __tmp30_outputWritten = false;
                        string __tmp31_line = "	///     <li>"; //348:1
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
                        string __tmp33_line = "</li>"; //348:64
                        if (!string.IsNullOrEmpty(__tmp33_line))
                        {
                            __out.Append(__tmp33_line);
                            __tmp30_outputWritten = true;
                        }
                        if (__tmp30_outputWritten) __out.AppendLine(true);
                        if (__tmp30_outputWritten)
                        {
                            __out.AppendLine(false); //348:69
                        }
                    }
                    __out.Append("	/// </ul>"); //350:1
                    __out.AppendLine(false); //350:11
                    __out.Append("	/// All superclasses:"); //351:1
                    __out.AppendLine(false); //351:23
                    __out.Append("	/// <ul>"); //352:1
                    __out.AppendLine(false); //352:10
                    var __loop23_results = 
                        (from __loop23_var1 in __Enumerate((cls).GetEnumerator()) //353:8
                        from sup in __Enumerate((__loop23_var1.GetAllSuperClasses(false)).GetEnumerator()) //353:13
                        select new { __loop23_var1 = __loop23_var1, sup = sup}
                        ).ToList(); //353:3
                    for (int __loop23_iteration = 0; __loop23_iteration < __loop23_results.Count; ++__loop23_iteration)
                    {
                        var __tmp34 = __loop23_results[__loop23_iteration];
                        var __loop23_var1 = __tmp34.__loop23_var1;
                        var sup = __tmp34.sup;
                        bool __tmp36_outputWritten = false;
                        string __tmp37_line = "	///     <li>"; //354:1
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
                        string __tmp39_line = "</li>"; //354:64
                        if (!string.IsNullOrEmpty(__tmp39_line))
                        {
                            __out.Append(__tmp39_line);
                            __tmp36_outputWritten = true;
                        }
                        if (__tmp36_outputWritten) __out.AppendLine(true);
                        if (__tmp36_outputWritten)
                        {
                            __out.AppendLine(false); //354:69
                        }
                    }
                    __out.Append("	/// </ul>"); //356:1
                    __out.AppendLine(false); //356:11
                }
                if ((from __loop24_var1 in __Enumerate((cls).GetEnumerator()) //358:15
                from prop in __Enumerate((__loop24_var1.Properties).GetEnumerator()) //358:20
                where prop.Kind == MetaPropertyKind.Readonly //358:36
                select new { __loop24_var1 = __loop24_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //358:3
                {
                    __out.Append("	/// Initializes the following readonly properties:"); //359:1
                    __out.AppendLine(false); //359:52
                    __out.Append("	/// <ul>"); //360:1
                    __out.AppendLine(false); //360:10
                    var __loop25_results = 
                        (from __loop25_var1 in __Enumerate((cls).GetEnumerator()) //361:8
                        from prop in __Enumerate((__loop25_var1.Properties).GetEnumerator()) //361:13
                        where prop.Kind == MetaPropertyKind.Readonly //361:29
                        select new { __loop25_var1 = __loop25_var1, prop = prop}
                        ).ToList(); //361:3
                    for (int __loop25_iteration = 0; __loop25_iteration < __loop25_results.Count; ++__loop25_iteration)
                    {
                        var __tmp40 = __loop25_results[__loop25_iteration];
                        var __loop25_var1 = __tmp40.__loop25_var1;
                        var prop = __tmp40.prop;
                        bool __tmp42_outputWritten = false;
                        string __tmp43_line = "	///     <li>"; //362:1
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
                        string __tmp45_line = "</li>"; //362:38
                        if (!string.IsNullOrEmpty(__tmp45_line))
                        {
                            __out.Append(__tmp45_line);
                            __tmp42_outputWritten = true;
                        }
                        if (__tmp42_outputWritten) __out.AppendLine(true);
                        if (__tmp42_outputWritten)
                        {
                            __out.AppendLine(false); //362:43
                        }
                    }
                    __out.Append("	/// </ul>"); //364:1
                    __out.AppendLine(false); //364:11
                }
                if ((from __loop26_var1 in __Enumerate((cls).GetEnumerator()) //366:15
                from prop in __Enumerate((__loop26_var1.Properties).GetEnumerator()) //366:20
                where prop.Kind == MetaPropertyKind.Lazy //366:36
                select new { __loop26_var1 = __loop26_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //366:3
                {
                    __out.Append("	/// Initializes the following lazy properties:"); //367:1
                    __out.AppendLine(false); //367:48
                    __out.Append("	/// <ul>"); //368:1
                    __out.AppendLine(false); //368:10
                    var __loop27_results = 
                        (from __loop27_var1 in __Enumerate((cls).GetEnumerator()) //369:8
                        from prop in __Enumerate((__loop27_var1.Properties).GetEnumerator()) //369:13
                        where prop.Kind == MetaPropertyKind.Lazy //369:29
                        select new { __loop27_var1 = __loop27_var1, prop = prop}
                        ).ToList(); //369:3
                    for (int __loop27_iteration = 0; __loop27_iteration < __loop27_results.Count; ++__loop27_iteration)
                    {
                        var __tmp46 = __loop27_results[__loop27_iteration];
                        var __loop27_var1 = __tmp46.__loop27_var1;
                        var prop = __tmp46.prop;
                        bool __tmp48_outputWritten = false;
                        string __tmp49_line = "	///     <li>"; //370:1
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
                        string __tmp51_line = "</li>"; //370:38
                        if (!string.IsNullOrEmpty(__tmp51_line))
                        {
                            __out.Append(__tmp51_line);
                            __tmp48_outputWritten = true;
                        }
                        if (__tmp48_outputWritten) __out.AppendLine(true);
                        if (__tmp48_outputWritten)
                        {
                            __out.AppendLine(false); //370:43
                        }
                    }
                    __out.Append("	/// </ul>"); //372:1
                    __out.AppendLine(false); //372:11
                }
                if ((from __loop28_var1 in __Enumerate((cls).GetEnumerator()) //374:15
                from prop in __Enumerate((__loop28_var1.Properties).GetEnumerator()) //374:20
                where prop.Kind == MetaPropertyKind.Derived //374:36
                select new { __loop28_var1 = __loop28_var1, prop = prop}
                ).GetEnumerator().MoveNext()) //374:3
                {
                    __out.Append("	/// Initializes the following derived properties:"); //375:1
                    __out.AppendLine(false); //375:51
                    __out.Append("	/// <ul>"); //376:1
                    __out.AppendLine(false); //376:10
                    var __loop29_results = 
                        (from __loop29_var1 in __Enumerate((cls).GetEnumerator()) //377:8
                        from prop in __Enumerate((__loop29_var1.Properties).GetEnumerator()) //377:13
                        where prop.Kind == MetaPropertyKind.Derived //377:29
                        select new { __loop29_var1 = __loop29_var1, prop = prop}
                        ).ToList(); //377:3
                    for (int __loop29_iteration = 0; __loop29_iteration < __loop29_results.Count; ++__loop29_iteration)
                    {
                        var __tmp52 = __loop29_results[__loop29_iteration];
                        var __loop29_var1 = __tmp52.__loop29_var1;
                        var prop = __tmp52.prop;
                        bool __tmp54_outputWritten = false;
                        string __tmp55_line = "	///     <li>"; //378:1
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
                        string __tmp57_line = "</li>"; //378:38
                        if (!string.IsNullOrEmpty(__tmp57_line))
                        {
                            __out.Append(__tmp57_line);
                            __tmp54_outputWritten = true;
                        }
                        if (__tmp54_outputWritten) __out.AppendLine(true);
                        if (__tmp54_outputWritten)
                        {
                            __out.AppendLine(false); //378:43
                        }
                    }
                    __out.Append("	/// </ul>"); //380:1
                    __out.AppendLine(false); //380:11
                }
                bool __tmp59_outputWritten = false;
                string __tmp60_line = "	public virtual void "; //382:1
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
                string __tmp62_line = "("; //382:66
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
                string __tmp64_line = " _this)"; //382:109
                if (!string.IsNullOrEmpty(__tmp64_line))
                {
                    __out.Append(__tmp64_line);
                    __tmp59_outputWritten = true;
                }
                if (__tmp59_outputWritten) __out.AppendLine(true);
                if (__tmp59_outputWritten)
                {
                    __out.AppendLine(false); //382:116
                }
                __out.Append("	{"); //383:1
                __out.AppendLine(false); //383:3
                bool __tmp66_outputWritten = false;
                string __tmp67_line = "		this.Call"; //384:1
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
                string __tmp69_line = "SuperConstructors(_this);"; //384:56
                if (!string.IsNullOrEmpty(__tmp69_line))
                {
                    __out.Append(__tmp69_line);
                    __tmp66_outputWritten = true;
                }
                if (__tmp66_outputWritten) __out.AppendLine(true);
                if (__tmp66_outputWritten)
                {
                    __out.AppendLine(false); //384:81
                }
                __out.Append("	}"); //385:1
                __out.AppendLine(false); //385:3
                __out.AppendLine(true); //386:1
                __out.Append("	/// <summary>"); //387:1
                __out.AppendLine(false); //387:15
                bool __tmp71_outputWritten = false;
                string __tmp72_line = "	/// Calls the super constructors of "; //388:1
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
                    __out.AppendLine(false); //388:82
                }
                __out.Append("	/// </summary>"); //389:1
                __out.AppendLine(false); //389:16
                bool __tmp75_outputWritten = false;
                string __tmp76_line = "	protected virtual void Call"; //390:1
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
                string __tmp78_line = "SuperConstructors("; //390:73
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
                string __tmp80_line = " _this)"; //390:133
                if (!string.IsNullOrEmpty(__tmp80_line))
                {
                    __out.Append(__tmp80_line);
                    __tmp75_outputWritten = true;
                }
                if (__tmp75_outputWritten) __out.AppendLine(true);
                if (__tmp75_outputWritten)
                {
                    __out.AppendLine(false); //390:140
                }
                __out.Append("	{"); //391:1
                __out.AppendLine(false); //391:3
                var __loop30_results = 
                    (from __loop30_var1 in __Enumerate((cls).GetEnumerator()) //392:8
                    from sup in __Enumerate((__loop30_var1.GetAllSuperClasses(false)).GetEnumerator()) //392:13
                    select new { __loop30_var1 = __loop30_var1, sup = sup}
                    ).ToList(); //392:3
                for (int __loop30_iteration = 0; __loop30_iteration < __loop30_results.Count; ++__loop30_iteration)
                {
                    var __tmp81 = __loop30_results[__loop30_iteration];
                    var __loop30_var1 = __tmp81.__loop30_var1;
                    var sup = __tmp81.sup;
                    if (model.Namespace.Declarations.Contains(sup)) //393:4
                    {
                        bool __tmp83_outputWritten = false;
                        string __tmp84_line = "		this."; //394:1
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
                        string __tmp86_line = "(_this);"; //394:52
                        if (!string.IsNullOrEmpty(__tmp86_line))
                        {
                            __out.Append(__tmp86_line);
                            __tmp83_outputWritten = true;
                        }
                        if (__tmp83_outputWritten) __out.AppendLine(true);
                        if (__tmp83_outputWritten)
                        {
                            __out.AppendLine(false); //394:60
                        }
                    }
                    else //395:4
                    {
                        bool __tmp88_outputWritten = false;
                        string __tmp87Prefix = "		"; //396:1
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
                        string __tmp90_line = "."; //396:69
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
                        string __tmp92_line = "(_this);"; //396:114
                        if (!string.IsNullOrEmpty(__tmp92_line))
                        {
                            __out.Append(__tmp92_line);
                            __tmp88_outputWritten = true;
                        }
                        if (__tmp88_outputWritten) __out.AppendLine(true);
                        if (__tmp88_outputWritten)
                        {
                            __out.AppendLine(false); //396:122
                        }
                    }
                }
                __out.Append("	}"); //399:1
                __out.AppendLine(false); //399:3
                var __loop31_results = 
                    (from __loop31_var1 in __Enumerate((cls).GetEnumerator()) //400:8
                    from op in __Enumerate((__loop31_var1.Operations).GetEnumerator()) //400:13
                    select new { __loop31_var1 = __loop31_var1, op = op}
                    ).ToList(); //400:3
                for (int __loop31_iteration = 0; __loop31_iteration < __loop31_results.Count; ++__loop31_iteration)
                {
                    var __tmp93 = __loop31_results[__loop31_iteration];
                    var __loop31_var1 = __tmp93.__loop31_var1;
                    var op = __tmp93.op;
                    __out.AppendLine(true); //401:2
                    __out.Append("	/// <summary>"); //402:1
                    __out.AppendLine(false); //402:15
                    bool __tmp95_outputWritten = false;
                    string __tmp96_line = "	/// Implements the operation: "; //403:1
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
                    string __tmp98_line = "."; //403:76
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
                    string __tmp100_line = "()"; //403:86
                    if (!string.IsNullOrEmpty(__tmp100_line))
                    {
                        __out.Append(__tmp100_line);
                        __tmp95_outputWritten = true;
                    }
                    if (__tmp95_outputWritten) __out.AppendLine(true);
                    if (__tmp95_outputWritten)
                    {
                        __out.AppendLine(false); //403:88
                    }
                    __out.Append("	/// </summary>"); //404:1
                    __out.AppendLine(false); //404:16
                    bool __tmp102_outputWritten = false;
                    string __tmp103_line = "	public virtual "; //405:1
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
                    string __tmp105_line = " "; //405:77
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
                    string __tmp107_line = "_"; //405:122
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
                    string __tmp109_line = "("; //405:132
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
                    string __tmp111_line = ")"; //405:168
                    if (!string.IsNullOrEmpty(__tmp111_line))
                    {
                        __out.Append(__tmp111_line);
                        __tmp102_outputWritten = true;
                    }
                    if (__tmp102_outputWritten) __out.AppendLine(true);
                    if (__tmp102_outputWritten)
                    {
                        __out.AppendLine(false); //405:169
                    }
                    __out.Append("	{"); //406:1
                    __out.AppendLine(false); //406:3
                    __out.Append("		throw new NotImplementedException();"); //407:1
                    __out.AppendLine(false); //407:39
                    __out.Append("	}"); //408:1
                    __out.AppendLine(false); //408:3
                }
                __out.AppendLine(true); //410:2
            }
            var __loop32_results = 
                (from __loop32_var1 in __Enumerate((model).GetEnumerator()) //412:8
                from Namespace in __Enumerate((__loop32_var1.Namespace).GetEnumerator()) //412:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //412:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //412:40
                select new { __loop32_var1 = __loop32_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //412:3
            for (int __loop32_iteration = 0; __loop32_iteration < __loop32_results.Count; ++__loop32_iteration)
            {
                var __tmp112 = __loop32_results[__loop32_iteration];
                var __loop32_var1 = __tmp112.__loop32_var1;
                var Namespace = __tmp112.Namespace;
                var Declarations = __tmp112.Declarations;
                var enm = __tmp112.enm;
                var __loop33_results = 
                    (from __loop33_var1 in __Enumerate((enm).GetEnumerator()) //413:8
                    from op in __Enumerate((__loop33_var1.Operations).GetEnumerator()) //413:13
                    select new { __loop33_var1 = __loop33_var1, op = op}
                    ).ToList(); //413:3
                for (int __loop33_iteration = 0; __loop33_iteration < __loop33_results.Count; ++__loop33_iteration)
                {
                    var __tmp113 = __loop33_results[__loop33_iteration];
                    var __loop33_var1 = __tmp113.__loop33_var1;
                    var op = __tmp113.op;
                    __out.AppendLine(true); //414:2
                    __out.Append("	/// <summary>"); //415:1
                    __out.AppendLine(false); //415:15
                    bool __tmp115_outputWritten = false;
                    string __tmp116_line = "	/// Implements the operation: "; //416:1
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
                    string __tmp118_line = "."; //416:76
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
                        __out.AppendLine(false); //416:86
                    }
                    __out.Append("	/// </summary>"); //417:1
                    __out.AppendLine(false); //417:16
                    bool __tmp121_outputWritten = false;
                    string __tmp122_line = "	public virtual "; //418:1
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
                    string __tmp124_line = " "; //418:77
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
                    string __tmp126_line = "_"; //418:122
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
                    string __tmp128_line = "("; //418:132
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
                    string __tmp130_line = ")"; //418:168
                    if (!string.IsNullOrEmpty(__tmp130_line))
                    {
                        __out.Append(__tmp130_line);
                        __tmp121_outputWritten = true;
                    }
                    if (__tmp121_outputWritten) __out.AppendLine(true);
                    if (__tmp121_outputWritten)
                    {
                        __out.AppendLine(false); //418:169
                    }
                    __out.Append("	{"); //419:1
                    __out.AppendLine(false); //419:3
                    __out.Append("		throw new NotImplementedException();"); //420:1
                    __out.AppendLine(false); //420:39
                    __out.Append("	}"); //421:1
                    __out.AppendLine(false); //421:3
                }
                __out.AppendLine(true); //423:2
            }
            __out.Append("}"); //425:1
            __out.AppendLine(false); //425:2
            return __out.ToString();
        }

        public string GetImplParameters(MetaModel model, MetaClass cls, MetaOperation op) //428:1
        {
            string result = CSharpName(cls, model, ClassKind.Immutable) + " _this"; //429:2
            string delim = ", "; //430:2
            var __loop34_results = 
                (from __loop34_var1 in __Enumerate((op).GetEnumerator()) //431:7
                from param in __Enumerate((__loop34_var1.Parameters).GetEnumerator()) //431:11
                select new { __loop34_var1 = __loop34_var1, param = param}
                ).ToList(); //431:2
            for (int __loop34_iteration = 0; __loop34_iteration < __loop34_results.Count; ++__loop34_iteration)
            {
                var __tmp1 = __loop34_results[__loop34_iteration];
                var __loop34_var1 = __tmp1.__loop34_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, ClassKind.Immutable, true) + " " + param.Name; //432:3
            }
            return result; //434:2
        }

        public string GetImplParameters(MetaModel model, MetaEnum enm, MetaOperation op) //437:1
        {
            string result = CSharpName(enm, model, ClassKind.Immutable) + " _this"; //438:2
            string delim = ", "; //439:2
            var __loop35_results = 
                (from __loop35_var1 in __Enumerate((op).GetEnumerator()) //440:7
                from param in __Enumerate((__loop35_var1.Parameters).GetEnumerator()) //440:11
                select new { __loop35_var1 = __loop35_var1, param = param}
                ).ToList(); //440:2
            for (int __loop35_iteration = 0; __loop35_iteration < __loop35_results.Count; ++__loop35_iteration)
            {
                var __tmp1 = __loop35_results[__loop35_iteration];
                var __loop35_var1 = __tmp1.__loop35_var1;
                var param = __tmp1.param;
                result += delim + CSharpName(param.Type, model, ClassKind.Immutable, true) + " " + param.Name; //441:3
            }
            return result; //443:2
        }

        public string GenerateEnum(MetaModel mmodel, MetaEnum enm) //447:1
        {
            StringBuilder __out = new StringBuilder();
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
                __out.AppendLine(false); //448:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public enum "; //449:1
            if (!string.IsNullOrEmpty(__tmp6_line))
            {
                __out.Append(__tmp6_line);
                __tmp5_outputWritten = true;
            }
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(CSharpName(enm, mmodel));
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
                __out.AppendLine(false); //449:37
            }
            __out.Append("{"); //450:1
            __out.AppendLine(false); //450:2
            var __loop36_results = 
                (from __loop36_var1 in __Enumerate((enm).GetEnumerator()) //451:8
                from value in __Enumerate((__loop36_var1.EnumLiterals).GetEnumerator()) //451:13
                select new { __loop36_var1 = __loop36_var1, value = value}
                ).ToList(); //451:3
            for (int __loop36_iteration = 0; __loop36_iteration < __loop36_results.Count; ++__loop36_iteration)
            {
                string delim; //451:31
                if (__loop36_iteration+1 < __loop36_results.Count) delim = ",";
                else delim = string.Empty;
                var __tmp8 = __loop36_results[__loop36_iteration];
                var __loop36_var1 = __tmp8.__loop36_var1;
                var value = __tmp8.value;
                bool __tmp10_outputWritten = false;
                string __tmp9Prefix = "	"; //452:1
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
                    __out.AppendLine(false); //452:32
                }
                bool __tmp13_outputWritten = false;
                string __tmp12Prefix = "	"; //453:1
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
                    __out.AppendLine(false); //453:21
                }
            }
            __out.Append("}"); //455:1
            __out.AppendLine(false); //455:2
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
