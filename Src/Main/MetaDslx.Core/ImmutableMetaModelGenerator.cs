using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable //1:1
{
    using __Hidden_ImmutableMetaModelGenerator_78252175;
    namespace __Hidden_ImmutableMetaModelGenerator_78252175
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

        public string GenerateMetamodel(MetaModel model) //45:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //46:1
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
                __out.AppendLine(false); //46:67
            }
            __out.Append("{"); //47:1
            __out.AppendLine(false); //47:2
            bool __tmp6_outputWritten = false;
            string __tmp5Prefix = "	"; //48:1
            StringBuilder __tmp7 = new StringBuilder();
            __tmp7.Append(GenerateMetaModelInstance(model));
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
                __out.AppendLine(false); //48:36
            }
            __out.AppendLine(true); //49:1
            bool __tmp9_outputWritten = false;
            string __tmp8Prefix = "	"; //50:1
            StringBuilder __tmp10 = new StringBuilder();
            __tmp10.Append(GenerateFactory(model));
            using(StreamReader __tmp10Reader = new StreamReader(this.__ToStream(__tmp10.ToString())))
            {
                bool __tmp10_last = __tmp10Reader.EndOfStream;
                while(!__tmp10_last)
                {
                    string __tmp10_line = __tmp10Reader.ReadLine();
                    __tmp10_last = __tmp10Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp8Prefix))
                    {
                        __out.Append(__tmp8Prefix);
                        __tmp9_outputWritten = true;
                    }
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
                __out.AppendLine(false); //50:26
            }
            __out.AppendLine(true); //51:1
            var __loop3_results = 
                (from __loop3_var1 in __Enumerate((model).GetEnumerator()) //52:8
                from Namespace in __Enumerate((__loop3_var1.Namespace).GetEnumerator()) //52:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //52:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //52:40
                select new { __loop3_var1 = __loop3_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //52:3
            for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
            {
                var __tmp11 = __loop3_results[__loop3_iteration];
                var __loop3_var1 = __tmp11.__loop3_var1;
                var Namespace = __tmp11.Namespace;
                var Declarations = __tmp11.Declarations;
                var enm = __tmp11.enm;
                __out.AppendLine(true); //53:1
                bool __tmp13_outputWritten = false;
                string __tmp12Prefix = "	"; //54:1
                StringBuilder __tmp14 = new StringBuilder();
                __tmp14.Append(GenerateEnum(model, enm));
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
                        if (!__tmp14_last || __tmp13_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //54:28
                }
            }
            __out.AppendLine(true); //56:1
            bool __tmp16_outputWritten = false;
            string __tmp15Prefix = "	"; //57:1
            StringBuilder __tmp17 = new StringBuilder();
            __tmp17.Append(GenerateMetaModelDescriptor(model));
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
                __out.AppendLine(false); //57:38
            }
            __out.Append("}"); //58:1
            __out.AppendLine(false); //58:2
            __out.AppendLine(true); //59:1
            bool __tmp19_outputWritten = false;
            string __tmp20_line = "namespace "; //60:1
            if (!string.IsNullOrEmpty(__tmp20_line))
            {
                __out.Append(__tmp20_line);
                __tmp19_outputWritten = true;
            }
            StringBuilder __tmp21 = new StringBuilder();
            __tmp21.Append(CSharpName(model.Namespace, NamespaceKind.Implementation, true));
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
                __out.AppendLine(false); //60:75
            }
            __out.Append("{"); //61:1
            __out.AppendLine(false); //61:2
            bool __tmp23_outputWritten = false;
            string __tmp22Prefix = "	"; //62:1
            StringBuilder __tmp24 = new StringBuilder();
            __tmp24.Append(GenerateMetaModelBuilderInstance(model));
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
                __out.AppendLine(false); //62:43
            }
            __out.AppendLine(true); //63:1
            bool __tmp26_outputWritten = false;
            string __tmp25Prefix = "	"; //64:1
            StringBuilder __tmp27 = new StringBuilder();
            __tmp27.Append(GenerateImplementationProvider(model));
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
                __out.AppendLine(false); //64:41
            }
            __out.Append("}"); //65:1
            __out.AppendLine(false); //65:2
            __out.AppendLine(true); //66:1
            bool __tmp29_outputWritten = false;
            string __tmp30_line = "namespace "; //67:1
            if (!string.IsNullOrEmpty(__tmp30_line))
            {
                __out.Append(__tmp30_line);
                __tmp29_outputWritten = true;
            }
            StringBuilder __tmp31 = new StringBuilder();
            __tmp31.Append(CSharpName(model.Namespace, NamespaceKind.Internal, true));
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
                __out.AppendLine(false); //67:69
            }
            __out.Append("{"); //68:1
            __out.AppendLine(false); //68:2
            bool __tmp33_outputWritten = false;
            string __tmp32Prefix = "	"; //69:1
            StringBuilder __tmp34 = new StringBuilder();
            __tmp34.Append(GenerateImplementationBase(model));
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
                __out.AppendLine(false); //69:37
            }
            __out.Append("}"); //70:1
            __out.AppendLine(false); //70:2
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //73:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //74:1
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
                __out.AppendLine(false); //74:61
            }
            __out.Append("{"); //75:1
            __out.AppendLine(false); //75:2
            if (IsCoreModel(model)) //76:3
            {
                bool __tmp6_outputWritten = false;
                string __tmp7_line = "	internal readonly "; //77:1
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
                string __tmp9_line = " _MetaModel;"; //77:65
                if (!string.IsNullOrEmpty(__tmp9_line))
                {
                    __out.Append(__tmp9_line);
                    __tmp6_outputWritten = true;
                }
                if (__tmp6_outputWritten) __out.AppendLine(true);
                if (__tmp6_outputWritten)
                {
                    __out.AppendLine(false); //77:77
                }
            }
            else //78:3
            {
                bool __tmp11_outputWritten = false;
                string __tmp12_line = "	internal readonly "; //79:1
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
                string __tmp14_line = " MetaModel;"; //79:65
                if (!string.IsNullOrEmpty(__tmp14_line))
                {
                    __out.Append(__tmp14_line);
                    __tmp11_outputWritten = true;
                }
                if (__tmp11_outputWritten) __out.AppendLine(true);
                if (__tmp11_outputWritten)
                {
                    __out.AppendLine(false); //79:76
                }
            }
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "	internal readonly "; //81:1
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
            string __tmp19_line = ".MutableModel Model;"; //81:39
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //81:59
            }
            __out.AppendLine(true); //82:1
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //83:8
                from cst in __Enumerate((__loop4_var1).GetEnumerator()).OfType<MetaConstant>() //83:38
                select new { __loop4_var1 = __loop4_var1, cst = cst}
                ).ToList(); //83:3
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                var __tmp20 = __loop4_results[__loop4_iteration];
                var __loop4_var1 = __tmp20.__loop4_var1;
                var cst = __tmp20.cst;
                bool __tmp22_outputWritten = false;
                string __tmp21Prefix = "	"; //84:1
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
                    __out.AppendLine(false); //84:30
                }
                bool __tmp25_outputWritten = false;
                string __tmp26_line = "	public static readonly "; //85:1
                if (!string.IsNullOrEmpty(__tmp26_line))
                {
                    __out.Append(__tmp26_line);
                    __tmp25_outputWritten = true;
                }
                StringBuilder __tmp27 = new StringBuilder();
                __tmp27.Append(CSharpName(cst.Type, model, ClassKind.Immutable, true));
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
                string __tmp28_line = " "; //85:80
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
                string __tmp30_line = " = "; //85:133
                if (!string.IsNullOrEmpty(__tmp30_line))
                {
                    __out.Append(__tmp30_line);
                    __tmp25_outputWritten = true;
                }
                StringBuilder __tmp31 = new StringBuilder();
                __tmp31.Append(CSharpName(cst, model, ClassKind.BuilderInstance, true));
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
                            __tmp25_outputWritten = true;
                        }
                        if (!__tmp31_last) __out.AppendLine(true);
                    }
                }
                string __tmp32_line = ";"; //85:192
                if (!string.IsNullOrEmpty(__tmp32_line))
                {
                    __out.Append(__tmp32_line);
                    __tmp25_outputWritten = true;
                }
                if (__tmp25_outputWritten) __out.AppendLine(true);
                if (__tmp25_outputWritten)
                {
                    __out.AppendLine(false); //85:193
                }
            }
            __out.AppendLine(true); //87:1
            var __loop5_results = 
                (from __loop5_var1 in __Enumerate((model.Namespace.Declarations).GetEnumerator()) //88:8
                from cls in __Enumerate((__loop5_var1).GetEnumerator()).OfType<MetaClass>() //88:38
                select new { __loop5_var1 = __loop5_var1, cls = cls}
                ).ToList(); //88:3
            for (int __loop5_iteration = 0; __loop5_iteration < __loop5_results.Count; ++__loop5_iteration)
            {
                var __tmp33 = __loop5_results[__loop5_iteration];
                var __loop5_var1 = __tmp33.__loop5_var1;
                var cls = __tmp33.cls;
                bool __tmp35_outputWritten = false;
                string __tmp34Prefix = "	"; //89:1
                StringBuilder __tmp36 = new StringBuilder();
                __tmp36.Append(GenerateDocumentation(cls));
                using(StreamReader __tmp36Reader = new StreamReader(this.__ToStream(__tmp36.ToString())))
                {
                    bool __tmp36_last = __tmp36Reader.EndOfStream;
                    while(!__tmp36_last)
                    {
                        string __tmp36_line = __tmp36Reader.ReadLine();
                        __tmp36_last = __tmp36Reader.EndOfStream;
                        if (!string.IsNullOrEmpty(__tmp34Prefix))
                        {
                            __out.Append(__tmp34Prefix);
                            __tmp35_outputWritten = true;
                        }
                        if ((__tmp36_last && !string.IsNullOrEmpty(__tmp36_line)) || (!__tmp36_last && __tmp36_line != null))
                        {
                            __out.Append(__tmp36_line);
                            __tmp35_outputWritten = true;
                        }
                        if (!__tmp36_last || __tmp35_outputWritten) __out.AppendLine(true);
                    }
                }
                if (__tmp35_outputWritten)
                {
                    __out.AppendLine(false); //89:30
                }
                bool __tmp38_outputWritten = false;
                string __tmp39_line = "	public static readonly "; //90:1
                if (!string.IsNullOrEmpty(__tmp39_line))
                {
                    __out.Append(__tmp39_line);
                    __tmp38_outputWritten = true;
                }
                StringBuilder __tmp40 = new StringBuilder();
                __tmp40.Append(Properties.CoreNs);
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
                string __tmp41_line = ".MetaClass "; //90:44
                if (!string.IsNullOrEmpty(__tmp41_line))
                {
                    __out.Append(__tmp41_line);
                    __tmp38_outputWritten = true;
                }
                StringBuilder __tmp42 = new StringBuilder();
                __tmp42.Append(CSharpName(cls, model, ClassKind.ImmutableInstance));
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
                string __tmp43_line = " = "; //90:107
                if (!string.IsNullOrEmpty(__tmp43_line))
                {
                    __out.Append(__tmp43_line);
                    __tmp38_outputWritten = true;
                }
                StringBuilder __tmp44 = new StringBuilder();
                __tmp44.Append(CSharpName(cls, model, ClassKind.BuilderInstance, true));
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
                string __tmp45_line = ";"; //90:166
                if (!string.IsNullOrEmpty(__tmp45_line))
                {
                    __out.Append(__tmp45_line);
                    __tmp38_outputWritten = true;
                }
                if (__tmp38_outputWritten) __out.AppendLine(true);
                if (__tmp38_outputWritten)
                {
                    __out.AppendLine(false); //90:167
                }
                var __loop6_results = 
                    (from __loop6_var1 in __Enumerate((cls).GetEnumerator()) //91:9
                    from prop in __Enumerate((__loop6_var1.Properties).GetEnumerator()) //91:14
                    select new { __loop6_var1 = __loop6_var1, prop = prop}
                    ).ToList(); //91:4
                for (int __loop6_iteration = 0; __loop6_iteration < __loop6_results.Count; ++__loop6_iteration)
                {
                    var __tmp46 = __loop6_results[__loop6_iteration];
                    var __loop6_var1 = __tmp46.__loop6_var1;
                    var prop = __tmp46.prop;
                    bool __tmp48_outputWritten = false;
                    string __tmp47Prefix = "	"; //92:1
                    StringBuilder __tmp49 = new StringBuilder();
                    __tmp49.Append(GenerateDocumentation(prop));
                    using(StreamReader __tmp49Reader = new StreamReader(this.__ToStream(__tmp49.ToString())))
                    {
                        bool __tmp49_last = __tmp49Reader.EndOfStream;
                        while(!__tmp49_last)
                        {
                            string __tmp49_line = __tmp49Reader.ReadLine();
                            __tmp49_last = __tmp49Reader.EndOfStream;
                            if (!string.IsNullOrEmpty(__tmp47Prefix))
                            {
                                __out.Append(__tmp47Prefix);
                                __tmp48_outputWritten = true;
                            }
                            if ((__tmp49_last && !string.IsNullOrEmpty(__tmp49_line)) || (!__tmp49_last && __tmp49_line != null))
                            {
                                __out.Append(__tmp49_line);
                                __tmp48_outputWritten = true;
                            }
                            if (!__tmp49_last || __tmp48_outputWritten) __out.AppendLine(true);
                        }
                    }
                    if (__tmp48_outputWritten)
                    {
                        __out.AppendLine(false); //92:31
                    }
                    bool __tmp51_outputWritten = false;
                    string __tmp52_line = "	public static readonly "; //93:1
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
                    string __tmp54_line = ".MetaProperty "; //93:44
                    if (!string.IsNullOrEmpty(__tmp54_line))
                    {
                        __out.Append(__tmp54_line);
                        __tmp51_outputWritten = true;
                    }
                    StringBuilder __tmp55 = new StringBuilder();
                    __tmp55.Append(CSharpName(prop, model, PropertyKind.ImmutableInstance));
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
                    string __tmp56_line = " = "; //93:111
                    if (!string.IsNullOrEmpty(__tmp56_line))
                    {
                        __out.Append(__tmp56_line);
                        __tmp51_outputWritten = true;
                    }
                    StringBuilder __tmp57 = new StringBuilder();
                    __tmp57.Append(CSharpName(prop, model, PropertyKind.BuilderInstance, true));
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
                                __tmp51_outputWritten = true;
                            }
                            if (!__tmp57_last) __out.AppendLine(true);
                        }
                    }
                    string __tmp58_line = ";"; //93:171
                    if (!string.IsNullOrEmpty(__tmp58_line))
                    {
                        __out.Append(__tmp58_line);
                        __tmp51_outputWritten = true;
                    }
                    if (__tmp51_outputWritten) __out.AppendLine(true);
                    if (__tmp51_outputWritten)
                    {
                        __out.AppendLine(false); //93:172
                    }
                }
            }
            __out.Append("}"); //96:1
            __out.AppendLine(false); //96:2
            return __out.ToString();
        }

        public string GenerateMetaModelBuilderInstance(MetaModel model) //99:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //100:1
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
                __out.AppendLine(false); //100:59
            }
            __out.Append("{"); //101:1
            __out.AppendLine(false); //101:2
            __out.Append("}"); //102:1
            __out.AppendLine(false); //102:2
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //105:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //106:1
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
                    if (!__tmp4_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //106:51
            }
            __out.Append("{"); //107:1
            __out.AppendLine(false); //107:2
            __out.Append("}"); //108:1
            __out.AppendLine(false); //108:2
            return __out.ToString();
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //111:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public static class "; //112:1
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
                __out.AppendLine(false); //112:61
            }
            __out.Append("{"); //113:1
            __out.AppendLine(false); //113:2
            __out.Append("}"); //114:1
            __out.AppendLine(false); //114:2
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //117:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //118:1
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
                __out.AppendLine(false); //118:66
            }
            __out.Append("{"); //119:1
            __out.AppendLine(false); //119:2
            __out.Append("}"); //120:1
            __out.AppendLine(false); //120:2
            return __out.ToString();
        }

        public string GenerateImplementationBase(MetaModel model) //123:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //124:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(CSharpName(model, ModelKind.ImplementationBase));
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
                __out.AppendLine(false); //124:62
            }
            __out.Append("{"); //125:1
            __out.AppendLine(false); //125:2
            __out.Append("}"); //126:1
            __out.AppendLine(false); //126:2
            return __out.ToString();
        }

        public string GenerateEnum(MetaModel mmodel, MetaEnum enm) //129:1
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
                __out.AppendLine(false); //130:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public enum "; //131:1
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
                __out.AppendLine(false); //131:37
            }
            __out.Append("{"); //132:1
            __out.AppendLine(false); //132:2
            var __loop7_results = 
                (from __loop7_var1 in __Enumerate((enm).GetEnumerator()) //133:8
                from value in __Enumerate((__loop7_var1.EnumLiterals).GetEnumerator()) //133:13
                select new { __loop7_var1 = __loop7_var1, value = value}
                ).ToList(); //133:3
            for (int __loop7_iteration = 0; __loop7_iteration < __loop7_results.Count; ++__loop7_iteration)
            {
                string delim; //133:31
                if (__loop7_iteration+1 < __loop7_results.Count) delim = ",";
                else delim = string.Empty;
                var __tmp8 = __loop7_results[__loop7_iteration];
                var __loop7_var1 = __tmp8.__loop7_var1;
                var value = __tmp8.value;
                bool __tmp10_outputWritten = false;
                string __tmp9Prefix = "	"; //134:1
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
                    __out.AppendLine(false); //134:32
                }
                bool __tmp13_outputWritten = false;
                string __tmp12Prefix = "	"; //135:1
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
                    __out.AppendLine(false); //135:21
                }
            }
            __out.Append("}"); //137:1
            __out.AppendLine(false); //137:2
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

