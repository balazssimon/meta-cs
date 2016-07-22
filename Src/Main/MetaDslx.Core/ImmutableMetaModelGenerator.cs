using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable //1:1
{
    using __Hidden_ImmutableMetaModelGenerator_1235495003;
    namespace __Hidden_ImmutableMetaModelGenerator_1235495003
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
        string ToCamelCase(string identifier); //19:8
        string ToPascalCase(string identifier); //20:8
        string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false); //21:8
        string CSharpName(MetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false); //22:8
        string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false); //23:8
        string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false); //24:8
    }

    public class ImmutableMetaModelGenerator //2:1
    {
        // If you see an error at this line, create a class called ImmutableMetaModelGeneratorExtensions
        // which implements the interface IImmutableMetaModelGeneratorExtensions
        private IImmutableMetaModelGeneratorExtensions extensionFunctions = new ImmutableMetaModelGeneratorExtensions();
        private IEnumerable<ImmutableSymbol> Instances; //2:1

        public ImmutableMetaModelGenerator() //2:1
        {
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

        public string Generate() //4:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("using System;"); //5:1
            __out.AppendLine(false); //5:14
            __out.Append("using System.Collections.Generic;"); //6:1
            __out.AppendLine(false); //6:34
            __out.Append("using System.IO;"); //7:1
            __out.AppendLine(false); //7:17
            __out.Append("using System.Linq;"); //8:1
            __out.AppendLine(false); //8:19
            __out.Append("using System.Text;"); //9:1
            __out.AppendLine(false); //9:19
            __out.Append("using System.Threading;"); //10:1
            __out.AppendLine(false); //10:24
            __out.Append("using System.Threading.Tasks;"); //11:1
            __out.AppendLine(false); //11:30
            __out.Append("using System.Diagnostics;"); //12:1
            __out.AppendLine(false); //12:26
            __out.AppendLine(true); //13:1
            var __loop1_results = 
                (from __loop1_var1 in __Enumerate((Instances).GetEnumerator()) //14:8
                from mm in __Enumerate((__loop1_var1).GetEnumerator()).OfType<MetaModel>() //14:19
                select new { __loop1_var1 = __loop1_var1, mm = mm}
                ).ToList(); //14:3
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
                        if (!__tmp4_last || __tmp3_outputWritten)
                        {
                            if (!__tmp4_last) __out.AppendLine(true);
                        }
                    }
                }
                if (__tmp3_outputWritten)
                {
                    __out.AppendLine(false); //15:24
                }
            }
            return __out.ToString();
        }

        internal string ToCamelCase(string identifier) //19:8
        {
            return this.extensionFunctions.ToCamelCase(identifier); //19:8
        }

        internal string ToPascalCase(string identifier) //20:8
        {
            return this.extensionFunctions.ToPascalCase(identifier); //20:8
        }

        internal string CSharpName(MetaNamespace mnamespace, NamespaceKind kind = NamespaceKind.Public, bool fullName = false) //21:8
        {
            return this.extensionFunctions.CSharpName(mnamespace, kind, fullName); //21:8
        }

        internal string CSharpName(MetaModel mmodel, ModelKind kind = ModelKind.None, bool fullName = false) //22:8
        {
            return this.extensionFunctions.CSharpName(mmodel, kind, fullName); //22:8
        }

        internal string CSharpName(MetaType mtype, MetaModel mmodel, ClassKind kind = ClassKind.None, bool fullName = false) //23:8
        {
            return this.extensionFunctions.CSharpName(mtype, mmodel, kind, fullName); //23:8
        }

        internal string CSharpName(MetaProperty mproperty, MetaModel mmodel, PropertyKind kind = PropertyKind.None, bool fullName = false) //24:8
        {
            return this.extensionFunctions.CSharpName(mproperty, mmodel, kind, fullName); //24:8
        }

        public string GenerateMetamodel(MetaModel model) //26:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //27:1
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
                    if (!__tmp4_last || __tmp2_outputWritten)
                    {
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //27:67
            }
            __out.Append("{"); //28:1
            __out.AppendLine(false); //28:2
            bool __tmp6_outputWritten = false;
            string __tmp5Prefix = "	"; //29:1
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
                    if (!__tmp7_last || __tmp6_outputWritten)
                    {
                        if (!__tmp7_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //29:36
            }
            __out.AppendLine(true); //30:1
            bool __tmp9_outputWritten = false;
            string __tmp8Prefix = "	"; //31:1
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
                    if (!__tmp10_last || __tmp9_outputWritten)
                    {
                        if (!__tmp10_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp9_outputWritten)
            {
                __out.AppendLine(false); //31:26
            }
            __out.AppendLine(true); //32:1
            var __loop2_results = 
                (from __loop2_var1 in __Enumerate((model).GetEnumerator()) //33:8
                from Namespace in __Enumerate((__loop2_var1.Namespace).GetEnumerator()) //33:15
                from Declarations in __Enumerate((Namespace.Declarations).GetEnumerator()) //33:26
                from enm in __Enumerate((Declarations).GetEnumerator()).OfType<MetaEnum>() //33:40
                select new { __loop2_var1 = __loop2_var1, Namespace = Namespace, Declarations = Declarations, enm = enm}
                ).ToList(); //33:3
            for (int __loop2_iteration = 0; __loop2_iteration < __loop2_results.Count; ++__loop2_iteration)
            {
                var __tmp11 = __loop2_results[__loop2_iteration];
                var __loop2_var1 = __tmp11.__loop2_var1;
                var Namespace = __tmp11.Namespace;
                var Declarations = __tmp11.Declarations;
                var enm = __tmp11.enm;
                __out.AppendLine(true); //34:1
                bool __tmp13_outputWritten = false;
                string __tmp12Prefix = "	"; //35:1
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
                        if (!__tmp14_last || __tmp13_outputWritten)
                        {
                            if (!__tmp14_last) __out.AppendLine(true);
                        }
                    }
                }
                if (__tmp13_outputWritten)
                {
                    __out.AppendLine(false); //35:28
                }
            }
            __out.AppendLine(true); //37:1
            bool __tmp16_outputWritten = false;
            string __tmp15Prefix = "	"; //38:1
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
                    if (!__tmp17_last || __tmp16_outputWritten)
                    {
                        if (!__tmp17_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //38:38
            }
            __out.Append("}"); //39:1
            __out.AppendLine(false); //39:2
            __out.AppendLine(true); //40:1
            bool __tmp19_outputWritten = false;
            string __tmp20_line = "namespace "; //41:1
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
                    if (!__tmp21_last || __tmp19_outputWritten)
                    {
                        if (!__tmp21_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp19_outputWritten)
            {
                __out.AppendLine(false); //41:75
            }
            __out.Append("{"); //42:1
            __out.AppendLine(false); //42:2
            bool __tmp23_outputWritten = false;
            string __tmp22Prefix = "	"; //43:1
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
                    if (!__tmp24_last || __tmp23_outputWritten)
                    {
                        if (!__tmp24_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp23_outputWritten)
            {
                __out.AppendLine(false); //43:43
            }
            __out.AppendLine(true); //44:1
            bool __tmp26_outputWritten = false;
            string __tmp25Prefix = "	"; //45:1
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
                    if (!__tmp27_last || __tmp26_outputWritten)
                    {
                        if (!__tmp27_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp26_outputWritten)
            {
                __out.AppendLine(false); //45:41
            }
            __out.Append("}"); //46:1
            __out.AppendLine(false); //46:2
            __out.AppendLine(true); //47:1
            bool __tmp29_outputWritten = false;
            string __tmp30_line = "namespace "; //48:1
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
                    if (!__tmp31_last || __tmp29_outputWritten)
                    {
                        if (!__tmp31_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp29_outputWritten)
            {
                __out.AppendLine(false); //48:69
            }
            __out.Append("{"); //49:1
            __out.AppendLine(false); //49:2
            bool __tmp33_outputWritten = false;
            string __tmp32Prefix = "	"; //50:1
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
                    if (!__tmp34_last || __tmp33_outputWritten)
                    {
                        if (!__tmp34_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp33_outputWritten)
            {
                __out.AppendLine(false); //50:37
            }
            __out.Append("}"); //51:1
            __out.AppendLine(false); //51:2
            return __out.ToString();
        }

        public string GenerateMetaModelDescriptor(MetaModel model) //54:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public static class "; //55:1
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
                    if (!__tmp4_last || __tmp2_outputWritten)
                    {
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //55:61
            }
            __out.Append("{"); //56:1
            __out.AppendLine(false); //56:2
            __out.Append("}"); //57:1
            __out.AppendLine(false); //57:2
            return __out.ToString();
        }

        public string GenerateMetaModelInstance(MetaModel model) //60:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //61:1
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
                    if (!__tmp4_last || __tmp2_outputWritten)
                    {
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //61:61
            }
            __out.Append("{"); //62:1
            __out.AppendLine(false); //62:2
            __out.Append("}"); //63:1
            __out.AppendLine(false); //63:2
            return __out.ToString();
        }

        public string GenerateMetaModelBuilderInstance(MetaModel model) //66:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //67:1
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
                    if (!__tmp4_last || __tmp2_outputWritten)
                    {
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //67:59
            }
            __out.Append("{"); //68:1
            __out.AppendLine(false); //68:2
            __out.Append("}"); //69:1
            __out.AppendLine(false); //69:2
            return __out.ToString();
        }

        public string GenerateFactory(MetaModel model) //72:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //73:1
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
                    if (!__tmp4_last || __tmp2_outputWritten)
                    {
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //73:51
            }
            __out.Append("{"); //74:1
            __out.AppendLine(false); //74:2
            __out.Append("}"); //75:1
            __out.AppendLine(false); //75:2
            return __out.ToString();
        }

        public string GenerateImplementationProvider(MetaModel model) //78:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //79:1
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
                    if (!__tmp4_last || __tmp2_outputWritten)
                    {
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //79:66
            }
            __out.Append("{"); //80:1
            __out.AppendLine(false); //80:2
            __out.Append("}"); //81:1
            __out.AppendLine(false); //81:2
            return __out.ToString();
        }

        public string GenerateImplementationBase(MetaModel model) //84:1
        {
            StringBuilder __out = new StringBuilder();
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "public class "; //85:1
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
                    if (!__tmp4_last || __tmp2_outputWritten)
                    {
                        if (!__tmp4_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //85:62
            }
            __out.Append("{"); //86:1
            __out.AppendLine(false); //86:2
            __out.Append("}"); //87:1
            __out.AppendLine(false); //87:2
            return __out.ToString();
        }

        public string GenerateDocumentation(MetaDocumentedElement elem) //90:1
        {
            StringBuilder __out = new StringBuilder();
            ImmutableModelList<string> lines = elem.GetDocumentationLines(); //91:2
            if (lines.Count > 0) //92:2
            {
                __out.Append("/**"); //93:1
                __out.AppendLine(false); //93:4
                __out.Append(" * <summary>"); //94:1
                __out.AppendLine(false); //94:13
                var __loop3_results = 
                    (from line in __Enumerate((lines).GetEnumerator()) //95:8
                    select new { line = line}
                    ).ToList(); //95:3
                for (int __loop3_iteration = 0; __loop3_iteration < __loop3_results.Count; ++__loop3_iteration)
                {
                    var __tmp1 = __loop3_results[__loop3_iteration];
                    var line = __tmp1.line;
                    bool __tmp3_outputWritten = false;
                    string __tmp4_line = " * "; //96:1
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
                            if (!__tmp5_last || __tmp3_outputWritten)
                            {
                                if (!__tmp5_last) __out.AppendLine(true);
                            }
                        }
                    }
                    if (__tmp3_outputWritten)
                    {
                        __out.AppendLine(false); //96:10
                    }
                }
                __out.Append(" * </summary>"); //98:1
                __out.AppendLine(false); //98:14
                __out.Append(" */"); //99:1
                __out.AppendLine(false); //99:4
            }
            return __out.ToString();
        }

        public string GenerateEnum(MetaModel mmodel, MetaEnum enm) //103:1
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
                    if (!__tmp3_last || __tmp2_outputWritten)
                    {
                        if (!__tmp3_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //104:29
            }
            bool __tmp5_outputWritten = false;
            string __tmp6_line = "public enum "; //105:1
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
                    if (!__tmp7_last || __tmp5_outputWritten)
                    {
                        if (!__tmp7_last) __out.AppendLine(true);
                    }
                }
            }
            if (__tmp5_outputWritten)
            {
                __out.AppendLine(false); //105:37
            }
            __out.Append("{"); //106:1
            __out.AppendLine(false); //106:2
            var __loop4_results = 
                (from __loop4_var1 in __Enumerate((enm).GetEnumerator()) //107:8
                from value in __Enumerate((__loop4_var1.EnumLiterals).GetEnumerator()) //107:13
                select new { __loop4_var1 = __loop4_var1, value = value}
                ).ToList(); //107:3
            for (int __loop4_iteration = 0; __loop4_iteration < __loop4_results.Count; ++__loop4_iteration)
            {
                string delim; //107:31
                if (__loop4_iteration+1 < __loop4_results.Count) delim = ",";
                else delim = string.Empty;
                var __tmp8 = __loop4_results[__loop4_iteration];
                var __loop4_var1 = __tmp8.__loop4_var1;
                var value = __tmp8.value;
                bool __tmp10_outputWritten = false;
                string __tmp9Prefix = "	"; //108:1
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
                        if (!__tmp11_last || __tmp10_outputWritten)
                        {
                            if (!__tmp11_last) __out.AppendLine(true);
                        }
                    }
                }
                if (__tmp10_outputWritten)
                {
                    __out.AppendLine(false); //108:32
                }
                string __tmp12Prefix = "	"; //109:1
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
                        }
                        if ((__tmp14_last && !string.IsNullOrEmpty(__tmp14_line)) || (!__tmp14_last && __tmp14_line != null))
                        {
                            __out.Append(__tmp14_line);
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
                        }
                    }
                }
            }
            __out.Append("}"); //111:1
            __out.AppendLine(false); //111:2
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

